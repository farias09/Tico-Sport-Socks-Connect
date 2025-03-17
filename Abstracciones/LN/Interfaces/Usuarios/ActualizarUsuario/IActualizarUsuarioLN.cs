using Abstracciones.Modelos.Usuarios;

namespace Abstracciones.LN.Interfaces.Usuarios.ActualizarUsuario
{
    public interface IActualizarUsuarioLN
    {
        int Actualizar(UsuarioDto modelo);
    }
}