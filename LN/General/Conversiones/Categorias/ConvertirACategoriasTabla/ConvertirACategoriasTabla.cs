using Abstracciones.LN.Interfaces.General.Conversiones.Categorias.ConvertirACategoriasTabla;
using Abstracciones.Modelos.Categorias;
using Abstracciones.ModelosBaseDeDatos;

namespace LN.General.Conversiones.Categorias.ConvertirACategoriasTabla
{
    public class ConvertirACategoriasTabla : IConvertirACategoriasTabla
    {
        public CategoriasTabla ConvertirObjetoACategoriasTabla(CategoriasDto laCategoria)
        {
            return new CategoriasTabla
            {
                Categoria_ID = laCategoria.Categoria_ID,
                nombre = laCategoria.nombre,
                descripcion = laCategoria.descripcion
            };
        }
    }
}
