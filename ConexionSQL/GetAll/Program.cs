using Microsoft.Data.SqlClient;
using System.Data;

var cadenaConexion = "workstation id=PruebaAlumnosDB.mssql.somee.com;packet size=4096;user id=J0S3MG_SQLLogin_2;pwd=jjj68abtub;data source=PruebaAlumnosDB.mssql.somee.com;persist security info=False;initial catalog=PruebaAlumnosDB;TrustServerCertificate=True";
var query = "SELECT * FROM Alumnos";

using var conexion = new SqlConnection(cadenaConexion);
conexion.Open();

using var comando = new SqlCommand(query, conexion);
var reader = comando.ExecuteReader();
while (reader.Read())
{
    Console.WriteLine($"{reader["id"]};{reader["nombre"]};{reader["lu"]};{reader["nota"]}");
}