using Microsoft.Data.SqlClient;
using WebAppServer.Models;

namespace WebAppServer.DAOs.MSSDAOs
{
    public class AlumnoMSSDAO: IBase<Alumno,int,SqlTransaction>
    {
        private SqlConnection ObtenerConexion()
        {
            return new SqlConnection(ConexionString.Conexion);
        }

        #region Caso GetAll.
        public async Task<List<Alumno>> GetAll(ITransaction<SqlTransaction>? transaccion = null)
        {
            var lista = new List<Alumno>();

            string sqlQuery = "SELECT p.* FROM Alumnos p";

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
        #region Caso GetById.
        public async Task<Alumno?> GetByKey(int id, ITransaction<SqlTransaction>? transaccion = null)
        {
            Alumno? objeto = null;

            string sqlQuery = "SELECT TOP 1 p.* FROM Alumnos p WHERE p.Id = @Id";

            var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion == null)
                await conexion.OpenAsync();

            using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
            query.Parameters.AddWithValue("@Id", id);

            var reader = await query.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                objeto = ReadAsObjeto(reader);
            }
            return objeto;
        }
        #endregion
        #region Caso Insert.
        public async Task<bool> Insert(Alumno nuevo, ITransaction<SqlTransaction>? transaccion = null)
        {
            string sqlQuery = "INSERT INTO Alumnos(Nombre,LU,Nota) OUTPUT INSERTED.ID VALUES (@Nombre,@LU,@Nota)";

            var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion == null)
            {
                await conexion.OpenAsync();
            }

            using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
            query.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
            query.Parameters.AddWithValue("@LU", nuevo.LU);
            query.Parameters.AddWithValue("@Nota", nuevo.Nota);

            var respuesta = await query.ExecuteScalarAsync();
            nuevo.Id = Convert.ToInt32(respuesta);
            return nuevo.Id > 0;
        }
        #endregion
        #region Caso Update.
        public async Task<bool> Update(Alumno actualizar, ITransaction<SqlTransaction>? transaccion = null)
        {
            string sqlQuery = "UPDATE Alumnos SET Nombre = @Nombre, LU = @LU,Nota = @Nota WHERE Id = @Id";

            var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion == null)
            {
                await conexion.OpenAsync();
            }

            using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
            query.Parameters.AddWithValue("@Nombre", actualizar.Nombre);
            query.Parameters.AddWithValue("@LU", actualizar.LU);
            query.Parameters.AddWithValue("@Nota", actualizar.Nota);
            query.Parameters.AddWithValue("@Id", actualizar.Id);

            int cantidad = await query.ExecuteNonQueryAsync();
            return cantidad > 0;
        }
        #endregion
        #region Caso Delete.
        public async Task<bool> Delete(int id, ITransaction<SqlTransaction>? transaccion = null)
        {
            string sqlQuery = "DELETE FROM Alumnos WHERE Id = @Id";

            var conexion = transaccion?.GetInternalTransaction()?.Connection ?? ObtenerConexion();
            if (transaccion == null)
            {
                await conexion.OpenAsync();
            }

            using var query = new SqlCommand(sqlQuery, conexion, transaccion?.GetInternalTransaction());
            query.Parameters.AddWithValue("@Id", id);

            int eliminados = await query.ExecuteNonQueryAsync();
            return eliminados > 0;
        }
        #endregion
        private Alumno ReadAsObjeto(SqlDataReader reader)
        {
            int id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0;
            int lu = reader["LU"] != DBNull.Value ? Convert.ToInt32(reader["LU"]) : 0;
            decimal nota = reader["Nota"] != DBNull.Value ? Convert.ToDecimal(reader["Nota"]) : 0;
            string nombre = reader["Nombre"] != DBNull.Value ? Convert.ToString(reader["Nombre"]) : "";
            return new Alumno
            {
                Id = id,
                LU = lu,
                Nombre = nombre,
                Nota = nota
            };
        }
    }
}
