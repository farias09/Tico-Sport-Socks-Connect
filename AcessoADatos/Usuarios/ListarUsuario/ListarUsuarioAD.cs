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
                                                    Rol = elUsuario.Rol,
                                                    estado = elUsuario.estado           
                                                  }).ToList();
            return laListaDeUsuarios;
        }
    }
}
