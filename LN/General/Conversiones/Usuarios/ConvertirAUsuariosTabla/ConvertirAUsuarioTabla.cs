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
    public class ConvertirAUsuarioTabla : IConvertirAUsuariosTabla
    {
        public UsuariosTabla ConvertirObjetoAUsuariosTabla(UsuarioDto elUsuario)
        {
            return new UsuariosTabla
            {
                Nombre = elUsuario.Nombre,
                Email = elUsuario.Email,
                Rol_ID = elUsuario.Rol_ID,
                estado = elUsuario.estado,
                FechaRegistro = elUsuario.FechaRegistro,
                Contraseña = elUsuario.Contraseña,
                Numero = elUsuario.Numero ?? "N/A" // Asignar un valor por defecto si es nulo
            };
        }
    }
}