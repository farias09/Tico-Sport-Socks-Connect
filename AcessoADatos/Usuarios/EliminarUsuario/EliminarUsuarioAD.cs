using Abstracciones.AD.Interfaces.Usuarios.EliminarUsuario;
using Abstracciones.ModelosBaseDeDatos;
using AccesoADatos;

namespace AccesoADatos.Usuarios.EliminarUsuario
{
    public class EliminarUsuarioAD : IEliminarUsuarioAD
    {
        private readonly Contexto _elContexto;

        public EliminarUsuarioAD(Contexto contexto)
        {
            _elContexto = contexto;
        }

        public int Eliminar(int usuarioId)
        {
            var usuario = _elContexto.UsuariosTabla.Find(usuarioId);
            if (usuario != null)
            {
                _elContexto.UsuariosTabla.Remove(usuario);
                return _elContexto.SaveChanges();
            }
            return 0;
        }
    }
}