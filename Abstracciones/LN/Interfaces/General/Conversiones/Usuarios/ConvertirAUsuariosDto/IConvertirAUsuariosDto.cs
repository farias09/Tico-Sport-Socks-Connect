using Abstracciones.Modelos.Usuarios;
using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.General.Conversiones.Usuarios.ConvertirAUsuariosDto
{
    public interface IConvertirAUsuariosDto
    {
        UsuarioDto ConvertirObjetoAUsuarioDto(UsuariosTabla elUsuario);
    }
}
