using Microsoft.Data.SqlClient;
using WebAppServer.Models;

namespace WebAppServer.DAOs.MSSDAOs
{
    public class RolesMSSDAO
    {
        private SqlConnection ObtenerConexion()
        {
            return new SqlConnection(ConexionString.Conexion);
        }
        #region Caso GetAll.
        public async Task<List<RolModel>> GetAll(ITransaction<SqlTransaction>? transaccion = null)
        {
            var lista = new List<RolModel>();

            string sqlQuery = "SELECT r.* FROM Roles r";

            var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion is null)
                await conexion.OpenAsync();

            using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());

            var reader = await query.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var objeto = ReadAsObjeto(reader);
                lista.Add(objeto);
            }
            return lista;
        }
        #endregion
        #region Caso GetByKey.
        async public Task<RolModel?> GetByKey(string nombre, ITransaction<SqlTransaction>? transaccion = null)
        {
            RolModel objeto = null;

            string sqlQuery = "SELECT TOP 1 r.* FROM Roles r WHERE r.Nombre=@Nombre"
            ;

            var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion is null)
                await conexion.OpenAsync();

            using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
            query.Parameters.AddWithValue("@Nombre", nombre);

            var reader = await query.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                objeto = ReadAsObjeto(reader);
            }
            return objeto;
        }
        #endregion
        #region Caso Insert.
        async public Task<bool> Insert(RolModel nuevo, ITransaction<SqlTransaction>? transaccion = null)
        {
            string sqlQuery = "INSERT Roles(Nombre) VALUES (@Nombre)";

            var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion is null)
                await conexion.OpenAsync();

            using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
            query.Parameters.AddWithValue("@Nombre", nuevo.Nombre);

            var respuesta = await query.ExecuteNonQueryAsync();
            int cantidad = Convert.ToInt32(respuesta);
            return cantidad > 0;
        }
        #endregion
        #region Caso Update.
        async public Task<bool> Update(RolModel actualizar, ITransaction<SqlTransaction>? transaccion = null)
        {
            string sqlQuery = "UPDATE Roles SET Nombre=@Nombre WHERE Nombre=@Nombre";

            var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion is null)
                await conexion.OpenAsync();

            using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
            query.Parameters.AddWithValue("@Nombre", actualizar.Nombre);

            int cantidad = await query.ExecuteNonQueryAsync();

            return cantidad > 0;
        }
        #endregion
        #region Caso Delete.
        async public Task<bool> Delete(string nombre, ITransaction<SqlTransaction>? transaccion = null)
        {
            string sqlQuery = "DELETE FROM Roles WHERE Nombre=@Nombre";

            var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion is null)
                await conexion.OpenAsync();

            using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
            query.Parameters.AddWithValue("@Nombre", nombre);

            int? eliminados = await query.ExecuteNonQueryAsync();

            return eliminados > 0;
        }
        #endregion
        #region Caso ReadAsObjeto.
        protected RolModel ReadAsObjeto(SqlDataReader reader)
        {
            string nombre = reader["Nombre"] != DBNull.Value ? Convert.ToString(reader["Nombre"]) : "";

            var objeto = new RolModel { Nombre = nombre };

            return objeto;
        }
        #endregion
    }
}
