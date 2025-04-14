using Abstracciones.AD.Interfaces.Usuarios.ListarUsuario;
using Abstracciones.Modelos.Usuarios;
using Abstracciones.Modelos.Ventas;
using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoADatos.Usuarios.ListarUsuario
{
    public class ListarUsuarioAD : IListarUsuarioAD
    {
        private readonly Contexto _elContexto;

        public ListarUsuarioAD(Contexto contexto)
        {
            _elContexto = contexto;
        }

        public List<UsuarioDto> Listar()
        {
            List<UsuarioDto> laListaDeUsuarios = (from elUsuario in _elContexto.UsuariosTabla
                                                  select new UsuarioDto
                                                  {
                                                      Usuario_ID = elUsuario.Usuario_ID,
                                                      Nombre = elUsuario.Nombre,
                                                      Email = elUsuario.Email,
                                                      Telefono = elUsuario.Telefono,
                                                      Direccion = elUsuario.Direccion,
                                                      Provincia = elUsuario.Provincia,
                                                      Rol_ID = elUsuario.Rol_ID,
                                                      Numero = elUsuario.Numero,
                                                      estado = elUsuario.estado,
                                                      FechaRegistro = elUsuario.FechaRegistro,
                                                      Contraseña = elUsuario.Contraseña
                                                  }).ToList();
            return laListaDeUsuarios;
        }

        public UsuarioDto ObtenerUsuarioPorId(int usuarioId)
        {
            return _elContexto.UsuariosTabla
                .Where(u => u.Usuario_ID == usuarioId)
                .Select(u => new UsuarioDto
                {
                    Usuario_ID = u.Usuario_ID,
                    Nombre = u.Nombre,
                    Email = u.Email,
                    Direccion = u.Direccion,
                    Provincia = u.Provincia,
                    Numero = u.Numero,
                    Rol_ID = u.Rol_ID,
                    estado = u.estado,
                    FechaRegistro = u.FechaRegistro
                })
                .FirstOrDefault();
        }

        public List<UsuarioDto> BuscarClientes(string query)
        {
            return _elContexto.UsuariosTabla
                .Where(u => u.Rol_ID == 2 &&
                           (u.Nombre.Contains(query) ||
                            u.Email.Contains(query) ||
                            u.Telefono.Contains(query)))
                .Select(u => new UsuarioDto
                {
                    Usuario_ID = u.Usuario_ID,
                    Nombre = u.Nombre,
                    Email = u.Email,
                    Telefono = u.Telefono,
                    Direccion = u.Direccion,
                    Provincia = u.Provincia,
                    Numero = u.Numero,
                    Rol_ID = u.Rol_ID,
                    estado = u.estado,
                    FechaRegistro = u.FechaRegistro,
                    Contraseña = u.Contraseña
                })
                .ToList();
        }
    }
}
