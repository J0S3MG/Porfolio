using WebAppServer.Models;

namespace WebAppServer.Services
{
    public class AlumnoService
    {
        //CRUD = GetAll,GetById, Insert, Update, Delete.
        List<Alumno> alumnos = new List<Alumno>()
        {
            new Alumno(){Nombre = "Maxi",Id = 1,LU = 177,Nota = 10},
            new Alumno(){Nombre = "Marti",Id = 2,LU = 178, Nota = 9.5m},
            new Alumno(){Nombre = "Manuel", Id = 3,LU = 179,Nota = 9}
        };
        #region Caso GetAll.
        public List<Alumno> GetAll()
        {
            return alumnos.OrderBy(a => a.LU).ToList();
        }
        #endregion
        #region Caso GetById.
        public Alumno? GetById(int id)
        {
            return alumnos.Where(a => a.Id == id).FirstOrDefault();//Expresion lamda.
        }
        #endregion
        #region Caso Insert.
        public Alumno Insert(Alumno a)
        {
            alumnos.Add(a);
            return a;
        }
        #endregion
        #region Caso Update.
        public bool Update(Alumno a1)
        {
            var a2 = GetById(a1.Id);
            if(a2 != null)
            {
                a2.Nombre = a1.Nombre;
                a2.LU = a1.LU;
                a2.Nota = a1.Nota;
                return true;
            }
            return false;
        }
        #endregion
        #region Caso Delete.
        public bool Delete(int id)
        {
            var a = GetById(id);
            if(a != null)
            {
                alumnos.Remove(a);
                return true;
            }
            return false;
        }
        #endregion
    }
}
