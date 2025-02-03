using Abstracciones.Modelos.Categorias;
using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.General.Conversiones.Categorias.ConvertirACategoriasDto
{
    public interface IConvertirACategoriasDto
    {
        CategoriasDto ConvertirObjetoACategoriasDto(CategoriasTabla laCategoria);
    }
}
