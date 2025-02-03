using Abstracciones.AD.Interfaces.Usuarios.CrearUsuario;
using Abstracciones.ModelosBaseDeDatos;
using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoADatos.Usuarios.CrearUsuario
{
    public class CrearUsuarioAD : ICrearUsuarioAD
    {
        private readonly Contexto _elContexto;

        public CrearUsuarioAD(Contexto contexto)
        {
            _elContexto = contexto;
        }

        public int Crear(UsuariosTabla elUsuarioAGuardar)
        {
            try
            {
                _elContexto.UsuariosTabla.Add(elUsuarioAGuardar);
                EntityState estado = _elContexto.Entry(elUsuarioAGuardar).State = System.Data.Entity.EntityState.Added;
                int cantidadDeDatosGuardados = _elContexto.SaveChanges();
                return cantidadDeDatosGuardados;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al crear el usuario en la base de datos.", ex);
            }
        }
    }
}
