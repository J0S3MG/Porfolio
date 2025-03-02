using WebAppServer.DAOs.MSSDAOs;
using WebAppServer.Models;

namespace WebAppServer.Services
{
    public class AlumnoService
    {
        AlumnoMSSDAO alumnoDAO;
        public AlumnoService(AlumnoMSSDAO alumnoDao)
        {
            alumnoDAO = alumnoDao;
        }
        #region Caso GetAll.
        public async Task<List<Alumno>> GetAll()
        {
            return await alumnoDAO.GetAll();
        }
        #endregion
        #region Caso GetById.
        public async Task<Alumno?> GetById(int id)
        {
            return await alumnoDAO.GetByKey(id);
        }
        #endregion
        #region Caso Insert.
        public async Task<bool> Insert(Alumno a)
        {
            return await alumnoDAO.Insert(a);
        }
        #endregion
        #region Caso Update.
        public async Task<bool> Update(Alumno a)
        {
            return await alumnoDAO.Update(a);
        }
        #endregion
        #region Caso Delete.
        public async Task<bool> Delete(int id)
        {
            return await alumnoDAO.Delete(id);
        }
        #endregion
    }
}
