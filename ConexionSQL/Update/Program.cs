using Microsoft.Data.SqlClient;
using System.Data;

var id = 5;
var lu = 181;
var nom = "Nacho";
var nota = 8;

var cadenaConexion = "workstation id=PruebaAlumnosDB.mssql.somee.com;packet size=4096;user id=J0S3MG_SQLLogin_2;pwd=jjj68abtub;data source=PruebaAlumnosDB.mssql.somee.com;persist security info=False;initial catalog=PruebaAlumnosDB;TrustServerCertificate=True";
var query = "UPDATE Alumnos SET Nombre = @Nom, LU = @LU,Nota = @Nota WHERE Id = @Id";

using var conexion = new SqlConnection(cadenaConexion);
conexion.Open();

var comando = new SqlCommand(query, conexion);
comando.Parameters.AddWithValue("@Id", id);
comando.Parameters.AddWithValue("@Nom", nom);
comando.Parameters.AddWithValue("@LU", lu);
comando.Parameters.AddWithValue("@Nota", nota);

var nuevo = comando.ExecuteScalar();
Console.WriteLine($"{nuevo}");
