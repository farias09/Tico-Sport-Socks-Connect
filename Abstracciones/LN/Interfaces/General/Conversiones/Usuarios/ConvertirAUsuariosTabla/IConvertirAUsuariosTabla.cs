using Abstracciones.Modelos.Usuarios;
using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.General.Conversiones.Usuarios.ConvertirAUsuariosTabla
{
    public interface IConvertirAUsuariosTabla
    {
        UsuariosTabla ConvertirObjetoAUsuariosTabla(UsuarioDto elUsuario);
    }
}
