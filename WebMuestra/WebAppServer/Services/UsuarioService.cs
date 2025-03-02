using WebAppServer.Models;
using WebAppServer.DAOs.MSSDAOs;

namespace WebAppServer.Services
{
    public class UsuarioService
    {
        UsuarioMSSDAO _usuariosDao = new();
        UsuarioRoleMSSDAO _usuarioRolesDao = new();

        async public Task<List<Usuario>> GetAll()
        {
            return await _usuariosDao.GetAll();
        }

        async public Task<Usuario> GetByNombre(string nombre)
        {
            return await _usuariosDao.GetByKey(nombre);
        }

        async public Task CrearNuevo(Usuario objeto)
        {
            await _usuariosDao.Insert(objeto);
        }

        async public Task<Usuario> VerificarLogin(Usuario usuario)
        {
            var objeto = await _usuariosDao.GetByKey(usuario.Nombre);
            if (objeto!=null && objeto.Clave == usuario.Clave)
            {
                return objeto;
            }
            return null;
        }

        async public Task<List<UsuarioRole>> GetRolesByUsuario(string nombreUsuario)
        {
            var usuario = new UsuarioRole { NombreUsuario=nombreUsuario.ToUpper(), NombreRol="%" };
            return await _usuarioRolesDao.GetByUsuario(usuario);
        }

        async public Task Actualizar(Usuario objeto)
        {
            await _usuariosDao.Update(objeto);
        }

        async public Task Eliminar(string nombre)
        {
            var objeto = await GetByNombre(nombre);
            if (objeto != null)
            {
                await _usuariosDao.Delete(nombre);
            }
        }
    }
}
