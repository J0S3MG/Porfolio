using Microsoft.Data.SqlClient;
using WebAppServer.Models;

namespace WebAppServer.DAOs.MSSDAOs
{
    public class UsuarioMSSDAO: IBase<Usuario,string, SqlTransaction>
    {
        private SqlConnection ObtenerConexion()
        {
            return new SqlConnection(ConexionString.Conexion);
        }
        #region Caso GetAll.
        async public Task<List<Usuario>> GetAll(ITransaction<SqlTransaction>? transaccion = null)
        {
            var lista = new List<Usuario>();

            string sqlQuery = "SELECT u.* FROM Usuarios u";

            using var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion is null)
                await conexion.OpenAsync();

            using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());

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
        async public Task<Usuario?> GetByKey(string nombre, ITransaction<SqlTransaction>? transaccion = null)
        {
            Usuario objeto = null;

            string sqlQuery = "SELECT TOP 1 u.* FROM Usuarios u WHERE UPPER(TRIM(u.Nombre)) LIKE UPPER(TRIM(@Nombre))";

            using var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion is null)
                await conexion.OpenAsync();

            using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
            query.Parameters.AddWithValue("@Nombre", nombre);

            var reader = await query.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                objeto = ReadAsObjecto(reader);
            }
            return objeto;
        }
        #endregion
        #region Caso Insert.
        async public Task<bool> Insert(Usuario nuevo, ITransaction<SqlTransaction>? transaccion = null)
        {
            string sqlQuery = "INSERT Usuarios(Nombre, Clave) VALUES (@Nombre, @Clave)";

            var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion is null)
                await conexion.OpenAsync();

            using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
            query.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
            query.Parameters.AddWithValue("@Clave", nuevo.Clave);

            int cantInsertados = Convert.ToInt32(await query.ExecuteNonQueryAsync());
            return cantInsertados > 0;
        }
        #endregion
        #region Caso Update.
        async public Task<bool> Update(Usuario actualizar, ITransaction<SqlTransaction>? transaccion = null)
        {
            string sqlQuery = "UPDATE Usuarios SET Clave=@Clave WHERE UPPER(TRIM(Nombre)) LIKE UPPER(@Nombre_Usuario)";

            using var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion is null)
                await conexion.OpenAsync();

            using var query = new SqlCommand(sqlQuery, conexion);
            query.Parameters.AddWithValue("@Clave", actualizar.Clave);
            query.Parameters.AddWithValue("@Nombre_Usuario", actualizar.Nombre);

            int cantidad = await query.ExecuteNonQueryAsync();

            return cantidad > 0;
        }
        #endregion
        #region Caso Delete.
        async public Task<bool> Delete(string nombre, ITransaction<SqlTransaction>? transaccion = null)
        {
            string sqlQuery = "DELETE FROM Usuarios WHERE UPPER(TRIM(Nombre)) LIKE UPPER(@Nombre)";

            using var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion is null)
                await conexion.OpenAsync();

            using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
            query.Parameters.AddWithValue("@Nombre", nombre);

            int eliminados = await query.ExecuteNonQueryAsync();

            return eliminados > 0;
        }
        #endregion
        #region Caso ReadAsObjecto.
        protected Usuario ReadAsObjecto(SqlDataReader reader, ITransaction<SqlTransaction>? transaccion = null)
        {
            string nombre = reader["Nombre"] != DBNull.Value ? Convert.ToString(reader["Nombre"]) : "";
            string clave = reader["Clave"] != DBNull.Value ? Convert.ToString(reader["Clave"]) : "";

            var objeto = new Usuario { Nombre = nombre, Clave=clave };

            return objeto;
        }
        #endregion
    }
}
