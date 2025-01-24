using WebAppServer.DAOs;
using WebAppServer.Models;

namespace WebAppServer.Services
{
    public class AlumnoService
    {
        //CRUD = GetAll,GetById, Insert, Update, Delete.
        string cadena = "workstation id=PruebaAlumnosDB.mssql.somee.com;packet size=4096;user id=J0S3MG_SQLLogin_2;pwd=jjj68abtub;data source=PruebaAlumnosDB.mssql.somee.com;persist security info=False;initial catalog=PruebaAlumnosDB;TrustServerCertificate=True";
        AlumnoDAO alumnoDAO;
        public AlumnoService()
        {
            alumnoDAO = new AlumnoDAO(cadena);
        }
        #region Caso GetAll.
        public List<Alumno> GetAll()
        {
            return alumnoDAO.GetAll().OrderBy(a => a.LU).ToList();
        }
        #endregion
        #region Caso GetById.
        public Alumno? GetById(int id)
        {
            return alumnoDAO.GetById(id);
        }
        #endregion
        #region Caso Insert.
        public Alumno? Insert(Alumno a)
        {
            return alumnoDAO.Insert(a);
        }
        #endregion
        #region Caso Update.
        public bool Update(Alumno a)
        {
            return alumnoDAO.Update(a);
        }
        #endregion
        #region Caso Delete.
        public bool Delete(int id)
        {
            return alumnoDAO.Delete(id);
        }
        #endregion
    }
}
