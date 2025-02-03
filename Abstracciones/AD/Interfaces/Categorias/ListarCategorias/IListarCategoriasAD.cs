using Abstracciones.Modelos.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.AD.Interfaces.Categorias.ListarCategorias
{
    public interface IListarCategoriasAD
    {
        List<CategoriasDto> Listar();
    }
}
