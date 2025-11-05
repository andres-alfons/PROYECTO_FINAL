using DAL;
using ENTITY;
using System;
using System.Collections.ObjectModel;
using System.Linq;


namespace BLL
{
    public class ServiciosUsuario : ICrudEscritura<Usuario>, ICrudLectura<Usuario>
    {
        UsuarioRepository usuarioRepository;
        public ServiciosUsuario()
        {
            usuarioRepository = new UsuarioRepository(Utils.ARC_USUARIO);
        }

        public bool Actualizar(Usuario entidad)
        {
            return usuarioRepository.Actualizar(entidad);
        }

        public ReadOnlyCollection<Usuario> MostrarTodos()
        {
            var lista = usuarioRepository.MostrarTodos();
            return new ReadOnlyCollection<Usuario>(lista);
        }

        public bool Eliminar(Usuario entidad)
        {
            return usuarioRepository.Eliminar(entidad);
        }

        public string Guardar(Usuario entidad)
        {
            return usuarioRepository.Guardar(entidad);
        }

        public Usuario ObtenerPorId(int id)
        {
            //validar
            return usuarioRepository.ObtenerPorId(id);
        }

        public bool ExisteId(int id)
        {
            foreach (var usuario in MostrarTodos())
            {
                if (usuario.IdUsuario == id)
                {
                    return false;
                }
            }
            return true;
        }

        public bool ExisteNombreUsuario(string nombreUsuario)
        {
            foreach (var usuario in MostrarTodos())
            {
                if (usuario.NombreUsuario==nombreUsuario)
                {
                    return false;
                }
            }
            return true;
        }

    }
}

