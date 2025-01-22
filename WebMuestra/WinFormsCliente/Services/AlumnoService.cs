using System.Text;
using System.Text.Json;
using WinFormsCliente.Models;

namespace WinFormsCliente.Services
{
    public class AlumnoService
    {
        #region Caso GetAll.
        public async Task<List<Alumno>> GetAll()
        {
            var alumnos = new List<Alumno>();
            var url = "http://localhost:5062/api/Alumno";

            var cliente = new HttpClient();
            var response = await cliente.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var Json = await response.Content.ReadAsStringAsync();
                alumnos = JsonSerializer.Deserialize<List<Alumno>>(Json);
            }
            return alumnos;
        }
        #endregion
        #region Caso GetById.
        public async Task<Alumno> GetById(int id)
        {
            var a = new Alumno();
            var url = "http://localhost:5062/api/Alumno";

            var cliente = new HttpClient();
            var response = await cliente.GetAsync($"{url}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var Json = await response.Content.ReadAsStringAsync();
                a = JsonSerializer.Deserialize<Alumno>(Json);
            }
            return a;
        }
        #endregion
        #region Caso Insert.
        public async Task<Alumno> Insert(Alumno a)
        {
            var a2 = new Alumno();
            var url = "http://localhost:5062/api/Alumno";

            var cliente = new HttpClient();

            var Json = JsonSerializer.Serialize(a);
            var cont = new StringContent(Json, Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync(url,cont);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                a2 = JsonSerializer.Deserialize<Alumno>(json);
            }
            return a2;
        }
        #endregion
        #region Caso Update.
        public async Task<Alumno> Update(Alumno a)
        {
            var a2 = new Alumno();
            var url = "http://localhost:5062/api/Alumno";

            var cliente = new HttpClient();

            var Json = JsonSerializer.Serialize(a);
            var cont = new StringContent(Json, Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync(url, cont);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                a2 = JsonSerializer.Deserialize<Alumno>(json);
            }
            return a2;
        }
        #endregion
        #region Caso Delete.
        public async Task<bool> Delete(int id)
        {
            var url = "http://localhost:5062/api/Alumno";
            var cliente = new HttpClient();

            var response = await cliente.DeleteAsync($"{url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
