using Microsoft.Data.SqlClient;
using System.Data;

var id = 6;

var cadenaConexion = "workstation id=PruebaAlumnosDB.mssql.somee.com;packet size=4096;user id=J0S3MG_SQLLogin_2;pwd=jjj68abtub;data source=PruebaAlumnosDB.mssql.somee.com;persist security info=False;initial catalog=PruebaAlumnosDB;TrustServerCertificate=True";
var query = "DELETE FROM Alumnos WHERE Id = @Id";

using var conexion = new SqlConnection(cadenaConexion);
conexion.Open();

var comando = new SqlCommand(query, conexion);
comando.Parameters.AddWithValue("@Id", id);
