using Abstracciones.AD.Interfaces.Usuarios.EliminarUsuario;
using Abstracciones.LN.Interfaces.Usuarios.EliminarUsuario;

namespace LN.Usuarios.EliminarUsuario
{
    public class EliminarUsuarioLN : IEliminarUsuarioLN
    {
        private readonly IEliminarUsuarioAD _eliminarUsuarioAD;

        public EliminarUsuarioLN(IEliminarUsuarioAD eliminarUsuarioAD)
        {
            _eliminarUsuarioAD = eliminarUsuarioAD;
        }

        public int Eliminar(int usuarioId)
        {
            return _eliminarUsuarioAD.Eliminar(usuarioId);
        }
    }
}