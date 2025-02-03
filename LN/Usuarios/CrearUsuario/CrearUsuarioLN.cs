using Abstracciones.AD.Interfaces.Usuarios.CrearUsuario;
using Abstracciones.LN.Interfaces.General.Conversiones.Usuarios.ConvertirAUsuariosTabla;
using Abstracciones.LN.Interfaces.General.Conversiones.Ventas.ConvertirAVentasTabla;
using Abstracciones.LN.Interfaces.Usuarios.CrearUsuario;
using Abstracciones.Modelos.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.Usuarios.CrearUsuario
{
    public class CrearUsuarioLN : ICrearUsuarioLN
    {
        private readonly ICrearUsuarioAD _crearUsuarioAD;
        private readonly IConvertirAUsuariosTabla _convertirAUsuariosTabla;

        public CrearUsuarioLN(ICrearUsuarioAD crearUsuarioAD, IConvertirAUsuariosTabla convertirAUsuariosTabla)
        {
            _crearUsuarioAD = crearUsuarioAD;
            _convertirAUsuariosTabla = convertirAUsuariosTabla;
        }

        public int Crear(UsuarioDto modelo)
        {
            modelo.estado = true;
            int cantidadDeDatosGuardados = _crearUsuarioAD.Crear(_convertirAUsuariosTabla.ConvertirObjetoAUsuariosTabla(modelo));
            return cantidadDeDatosGuardados;
        }
    }
}
