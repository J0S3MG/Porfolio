using Microsoft.Data.SqlClient;
using WebAppServer.Models;

namespace WebAppServer.DAOs.MSSDAOs
{
    public class UsuarioRoleMSSDAO: IBase<UsuarioRole, UsuarioRole, SqlTransaction>
    {
        private SqlConnection ObtenerConexion()
        {
            return new SqlConnection(ConexionString.Conexion);
        }
        #region Caso GetAll.
        async public Task<List<UsuarioRole>> GetAll(ITransaction<SqlTransaction>? transaccion = null)
        {
            var lista = new List<UsuarioRole>();

            string sqlQuery = "SELECT u_r.* FROM Usuarios_Roles u_r ";

            var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion is null)
                await conexion.OpenAsync();

            using var query = new SqlCommand(sqlQuery, conexion);

            var reader = await query.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var objeto = ReadAsObjecto(reader);
                lista.Add(objeto);
            }
            return lista;
        }
        #endregion
        #region Caso GetByKey.
        async public Task<UsuarioRole?> GetByKey(UsuarioRole usuarioRol, ITransaction<SqlTransaction>? transaccion = null)
        {
            UsuarioRole objeto = null;

            string sqlQuery =
            @"SELECT TOP 1 u_r.* 
            FROM Usuarios_Roles u_r
            WHERE UPPER(TRIM(u_r.Nombre_Usuario)) LIKE UPPER(TRIM(@NombreUsuario))
            AND UPPER(TRIM(u_r.Nombre_Rol)) LIKE UPPER(TRIM(@NombreRol))";

            var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion is null)
                await conexion.OpenAsync();

            using var query = new SqlCommand(sqlQuery, conexion);
            query.Parameters.AddWithValue("@NombreUsuario", usuarioRol?.NombreUsuario);
            query.Parameters.AddWithValue("@NombreRol", usuarioRol?.NombreRol);

            var reader = await query.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                objeto = ReadAsObjecto(reader);
            }
            return objeto;
        }
        #endregion
        #region Caso GetByUsuario.
        async public Task<List<UsuarioRole?>> GetByUsuario(UsuarioRole usuarioRol, ITransaction<SqlTransaction>? transaccion = null)
        {
            List<UsuarioRole> objetos = new List<UsuarioRole>();

            string sqlQuery =
            @"SELECT u_r.* 
            FROM Usuarios_Roles u_r
            WHERE UPPER(TRIM(u_r.Nombre_Usuario)) LIKE UPPER(TRIM(@NombreUsuario))
            AND UPPER(TRIM(u_r.Nombre_Rol)) LIKE UPPER(TRIM(@NombreRol))";

            var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion is null)
                await conexion.OpenAsync();

            using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
            query.Parameters.AddWithValue("@NombreUsuario", usuarioRol?.NombreUsuario);
            query.Parameters.AddWithValue("@NombreRol", usuarioRol?.NombreRol);

            var reader = await query.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var objeto = ReadAsObjecto(reader);
                objetos.Add(objeto);
            }
            return objetos;
        }
        #endregion
        #region Caso Insert.
        async public Task<bool> Insert(UsuarioRole nuevo, ITransaction<SqlTransaction>? transaccion = null)
        {
            string sqlQuery =
            @"INSERT Usuarios_Roles(Nombre_Usuario, Nombre_Rol)
            VALUES (@NombreUsuario, @NombreRol)";

            var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion is null)
                await conexion.OpenAsync();

            using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
            query.Parameters.AddWithValue("@NombreUsuario", nuevo.NombreUsuario);
            query.Parameters.AddWithValue("@NombreRol", nuevo.NombreRol);

            int cantInsertados = Convert.ToInt32(await query.ExecuteNonQueryAsync());
            return cantInsertados > 0;
        }
        #endregion
        #region Caso Update.
        async public Task<bool> Update(UsuarioRole actualizar, ITransaction<SqlTransaction>? transaccion = null)
        {
            string sqlQuery =
            @"UPDATE Usuarios_Roles SET Nombre_Usuario=@Nombre_Usuario, Nombre_Rol=@Nombre_Rol
            WHERE UPPER(TRIM(Nombre_Usuario)) LIKE UPPER(@NombreUsuario) 
            AND UPPER(TRIM(Nombre_Rol)) LIKE UPPER(@NombreRol)";

            var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion is null)
                await conexion.OpenAsync();

            using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
            query.Parameters.AddWithValue("@NombreUsuario", actualizar.NombreUsuario);
            query.Parameters.AddWithValue("@NombreRol", actualizar.NombreRol);

            int cantidad = await query.ExecuteNonQueryAsync();

            return cantidad > 0;
        }
        #endregion
        #region Caso Delete.
        async public Task<bool> Delete(UsuarioRole usuarioRol, ITransaction<SqlTransaction>? transaccion = null)
        {
            string sqlQuery =
            @"DELETE FROM Usuarios_Roles
            WHERE UPPER(TRIM(Nombre_Usuario)) LIKE UPPER(@NombreUsuario)
            AND UPPER(TRIM(Nombre_Rol)) LIKE UPPER(@NombreRol)";

            var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion is null)
                await conexion.OpenAsync();

            using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
            query.Parameters.AddWithValue("@NombreUsuario", usuarioRol.NombreUsuario);
            query.Parameters.AddWithValue("@NombreRol", usuarioRol.NombreRol);

            int eliminados = await query.ExecuteNonQueryAsync();

            return eliminados > 0;
        }
        #endregion
        #region Caso ReadAsObjecto.
        protected UsuarioRole ReadAsObjecto(SqlDataReader reader)
        {
            string nombreUsuario = reader["Nombre_Usuario"] != DBNull.Value ? Convert.ToString(reader["Nombre_Usuario"]) : "";
            string nombreRol = reader["Nombre_Rol"] != DBNull.Value ? Convert.ToString(reader["Nombre_Rol"]) : "";

            var objeto = new UsuarioRole { NombreUsuario = nombreUsuario, NombreRol=nombreRol };

            return objeto;
        }
        #endregion
    }
}
