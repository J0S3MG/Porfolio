using WebAppServer.Models;
using WebAppServer.DAOs.MSSDAOs;

namespace WebAppServer.Services
{
    public class RolesService
    {
        RolesMSSDAO _rolesDao = new();
        async public Task<List<RolModel>> GetAll()
        {
            return await _rolesDao.GetAll();
        }
    }
}
