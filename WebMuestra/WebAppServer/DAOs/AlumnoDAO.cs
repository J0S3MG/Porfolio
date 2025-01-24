using Microsoft.Data.SqlClient;
using WebAppServer.Models;

namespace WebAppServer.DAOs
{
    public class AlumnoDAO
    {
        private readonly string cadenaconexion; 

        public AlumnoDAO(string cadena)
        {
            cadenaconexion = cadena;
        }

        #region Caso GetAll.
        public List<Alumno> GetAll()
        {
            var alumnos = new List<Alumno>();

            using var conexion = new SqlConnection(cadenaconexion);
            conexion.Open();

            var query = "SELECT * FROM Alumnos";
            using var comando = new SqlCommand(query,conexion);

            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                alumnos.Add(new Alumno()
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    LU = reader.GetInt32(2),
                    Nota = reader.GetDecimal(3)
                });
            }
            return alumnos;
        }
        #endregion
        #region Caso GetById.
        public Alumno? GetById(int id)
        {
            Alumno alumno = null;
            using var conexion = new SqlConnection(cadenaconexion);
            conexion.Open();

            var query = "SELECT * FROM Alumnos WHERE Id = @Id";
            using var comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@Id", id);

            var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                alumno = new Alumno()
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    LU = reader.GetInt32(2),
                    Nota = reader.GetDecimal(3)
                };
            }
            return alumno;
        }
        #endregion
        #region Caso Insert.
        public Alumno? Insert(Alumno a)
        {
            using var conexion = new SqlConnection(cadenaconexion);
            conexion.Open();

            var query = "INSERT INTO Alumnos(Nombre,LU,Nota) OUTPUT INSERTED.ID VALUES (@Nombre,@LU,@Nota)";
            using var comando = new SqlCommand(query,conexion);
            comando.Parameters.AddWithValue("@Nombre",a.Nombre);
            comando.Parameters.AddWithValue("@LU",a.LU);
            comando.Parameters.AddWithValue("@Nota",a.Nota);

            int id = (int)comando.ExecuteScalar();
            Alumno? a2 = GetById(id);
            return a2;
        }
        #endregion
        #region Caso Update.
        public bool Update(Alumno a)
        {
            using var conexion = new SqlConnection(cadenaconexion);
            conexion.Open();

            var query = "UPDATE Alumnos SET Nombre = @Nombre, LU = @LU,Nota = @Nota WHERE Id = @Id";
            using var comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@Id", a.Id);
            comando.Parameters.AddWithValue("@Nombre", a.Nombre);
            comando.Parameters.AddWithValue("@LU", a.LU);
            comando.Parameters.AddWithValue("@Nota", a.Nota);

            return true;
        }
        #endregion
        #region Caso Delete.
        public bool Delete(int id)
        {
            using var conexion = new SqlConnection(cadenaconexion);
            conexion.Open();

            var query = "DELETE  FROM Alumnos WHERE Id = @Id";
            using var comando = new SqlCommand(query,conexion);
            comando.Parameters.AddWithValue("@Id", id);

            return true;
        }
        #endregion
    }
}
