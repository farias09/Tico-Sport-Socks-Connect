using Abstracciones.LN.Interfaces.General.Conversiones.Usuarios.ConvertirAUsuariosTabla;
using Abstracciones.Modelos.Usuarios;
using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.General.Conversiones.Usuarios.ConvertirAUsuariosTabla
{
    internal class ConvertirAUsuarioTabla : IConvertirAUsuariosTabla
    {
        public UsuariosTabla ConvertirAUsuariosDTO(UsuarioDto elUsuario)
        {
            return new UsuariosTabla
            {
                Nombre = elUsuario.Nombre,
                Email = elUsuario.Email,
                Telefono = elUsuario.Telefono,
                Direccion = elUsuario.Direccion,
                Provincia = elUsuario.Provincia,
                Rol = elUsuario.Rol
            };
        }
    }
}
