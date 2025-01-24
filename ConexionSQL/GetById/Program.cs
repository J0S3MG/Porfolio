using Microsoft.Data.SqlClient;
using System.Data;

var id = 5;

var cadenaConexion = "workstation id=PruebaAlumnosDB.mssql.somee.com;packet size=4096;user id=J0S3MG_SQLLogin_2;pwd=jjj68abtub;data source=PruebaAlumnosDB.mssql.somee.com;persist security info=False;initial catalog=PruebaAlumnosDB;TrustServerCertificate=True";
var query = "SELECT * FROM Alumnos WHERE Id = @Id";

using var conexion = new SqlConnection(cadenaConexion);
conexion.Open();

var comando = new SqlCommand(query, conexion);
comando.Parameters.AddWithValue("@Id", id);

var dt = new DataTable(query);
var adaptador = new SqlDataAdapter(comando);
adaptador.Fill(dt);

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine($"{dr["id"]};{dr["nombre"]};{dr["lu"]};{dr["nota"]}");
}
