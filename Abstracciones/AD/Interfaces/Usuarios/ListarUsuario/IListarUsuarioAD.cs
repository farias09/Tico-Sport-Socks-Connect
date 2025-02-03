using Abstracciones.Modelos.Usuarios;
using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.AD.Interfaces.Usuarios.ListarUsuario
{
    public interface IListarUsuarioAD
    {
        List<UsuarioDto> Listar();
    }
}
