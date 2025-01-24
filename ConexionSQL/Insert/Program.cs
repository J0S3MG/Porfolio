using Microsoft.Data.SqlClient;
using System.Data;

var lu = 181;
var nom = "Fili";
var nota = 6;

var cadenaConexion = "workstation id=PruebaAlumnosDB.mssql.somee.com;packet size=4096;user id=J0S3MG_SQLLogin_2;pwd=jjj68abtub;data source=PruebaAlumnosDB.mssql.somee.com;persist security info=False;initial catalog=PruebaAlumnosDB;TrustServerCertificate=True";
var query = "INSERT INTO Alumnos(Nombre,LU,Nota) OUTPUT INSERTED.ID VALUES (@Nombre,@LU,@Nota)";

using var conexion = new SqlConnection(cadenaConexion);
conexion.Open();

var comando = new SqlCommand(query, conexion);
comando.Parameters.AddWithValue("@Nombre", nom);
comando.Parameters.AddWithValue("@LU", lu);
comando.Parameters.AddWithValue("@Nota",nota);

var nuevo = comando.ExecuteScalar();
Console.WriteLine($"{nuevo}");
