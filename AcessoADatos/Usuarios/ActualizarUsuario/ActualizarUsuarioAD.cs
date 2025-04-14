using Abstracciones.AD.Interfaces.Usuarios.ActualizarUsuario;
using Abstracciones.ModelosBaseDeDatos;
using System.Data.Entity;

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
            // Obtener el usuario existente
            var usuarioExistente = _elContexto.UsuariosTabla.Find(elUsuarioAActualizar.Usuario_ID);

            if (usuarioExistente == null)
            {
                return 0;
            }

            // Actualizar solo los campos permitidos
            usuarioExistente.Nombre = elUsuarioAActualizar.Nombre;
            usuarioExistente.Email = elUsuarioAActualizar.Email;
            usuarioExistente.Telefono = elUsuarioAActualizar.Telefono;
            usuarioExistente.Direccion = elUsuarioAActualizar.Direccion;
            usuarioExistente.Provincia = elUsuarioAActualizar.Provincia;
            usuarioExistente.Numero = elUsuarioAActualizar.Numero;
            usuarioExistente.Rol_ID = elUsuarioAActualizar.Rol_ID;

            // No actualizamos: estado, FechaRegistro ni Contraseña

            _elContexto.Entry(usuarioExistente).State = EntityState.Modified;
            return _elContexto.SaveChanges();
        }
    }
}