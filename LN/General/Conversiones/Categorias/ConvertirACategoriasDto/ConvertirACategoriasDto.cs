using Abstracciones.LN.Interfaces.General.Conversiones.Categorias.ConvertirACategoriasDto;
using Abstracciones.Modelos.Categorias;
using Abstracciones.ModelosBaseDeDatos;

namespace LN.General.Conversiones.Categorias.ConvertirACategoriasDto
{
    public class ConvertirACategoriasDto : IConvertirACategoriasDto
    {
        public CategoriasDto ConvertirObjetoACategoriasDto(CategoriasTabla laCategoria)
        {
            return new CategoriasDto
            {
                Categoria_ID = laCategoria.Categoria_ID,
                nombre = laCategoria.nombre,
                descripcion = laCategoria.descripcion
            };
        }
    }
}
