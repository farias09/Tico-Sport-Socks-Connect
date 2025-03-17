using Abstracciones.AD.Interfaces.Usuarios.ActualizarUsuario;
using Abstracciones.LN.Interfaces.General.Conversiones.Usuarios.ConvertirAUsuariosTabla;
using Abstracciones.LN.Interfaces.Usuarios.ActualizarUsuario;
using Abstracciones.Modelos.Usuarios;

namespace LN.Usuarios.ActualizarUsuario
{
    public class ActualizarUsuarioLN : IActualizarUsuarioLN
    {
        private readonly IActualizarUsuarioAD _actualizarUsuarioAD;
        private readonly IConvertirAUsuariosTabla _convertirAUsuariosTabla;

        public ActualizarUsuarioLN(IActualizarUsuarioAD actualizarUsuarioAD, IConvertirAUsuariosTabla convertirAUsuariosTabla)
        {
            _actualizarUsuarioAD = actualizarUsuarioAD;
            _convertirAUsuariosTabla = convertirAUsuariosTabla;
        }

        public int Actualizar(UsuarioDto modelo)
        {
            var usuarioTabla = _convertirAUsuariosTabla.ConvertirObjetoAUsuariosTabla(modelo);
            return _actualizarUsuarioAD.Actualizar(usuarioTabla);
        }
    }
}