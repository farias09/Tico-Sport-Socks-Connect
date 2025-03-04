using Abstracciones.AD.Interfaces.Usuarios.ActualizarUsuario;
using Abstracciones.ModelosBaseDeDatos;
using AccesoADatos;

namespace AccesoADatos.Usuarios.ActualizarUsuario
{
    public class ActualizarUsuarioAD : IActualizarUsuarioAD
    {
        private readonly Contexto _elContexto;

        public ActualizarUsuarioAD(Contexto contexto)
        {
            _elContexto = contexto;
        }

        public int Actualizar(UsuariosTabla elUsuarioAActualizar)
        {
            _elContexto.Entry(elUsuarioAActualizar).State = System.Data.Entity.EntityState.Modified;
            return _elContexto.SaveChanges();
        }
    }
}