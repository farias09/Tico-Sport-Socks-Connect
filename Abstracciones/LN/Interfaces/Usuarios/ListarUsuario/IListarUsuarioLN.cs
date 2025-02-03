using Abstracciones.Modelos.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.Usuarios.ListarUsuario
{
    public interface IListarUsuarioLN
    {
        List<UsuarioDto> Listar();
    }
}
