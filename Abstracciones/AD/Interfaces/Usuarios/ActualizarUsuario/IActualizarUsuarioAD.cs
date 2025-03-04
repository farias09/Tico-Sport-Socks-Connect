using Abstracciones.ModelosBaseDeDatos;

namespace Abstracciones.AD.Interfaces.Usuarios.ActualizarUsuario
{
    public interface IActualizarUsuarioAD
    {
        int Actualizar(UsuariosTabla elUsuarioAActualizar);
    }
}