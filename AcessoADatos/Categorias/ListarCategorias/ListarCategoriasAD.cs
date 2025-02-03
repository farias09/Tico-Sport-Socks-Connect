using Abstracciones.AD.Interfaces.Categorias.ListarCategorias;
using Abstracciones.Modelos.Categorias;
using AccesoADatos;
using System.Collections.Generic;
using System.Linq;

namespace AcessoADatos.Categorias.ListarCategorias
{
    public class ListarCategoriasAD : IListarCategoriasAD
    {
        Contexto _elContexto;

        public ListarCategoriasAD()
        {
            _elContexto = new Contexto();
        }

        public List<CategoriasDto> Listar()
        {
            List<CategoriasDto> laListaDeProductos = (from laCategoria in _elContexto.CategoriaTabla
                                                     select new CategoriasDto
                                                     {
                                                         Categoria_ID = laCategoria.Categoria_ID,
                                                         nombre = laCategoria.nombre,
                                                         descripcion = laCategoria.descripcion

                                                     }).ToList();
            return laListaDeProductos;
        }
    }
}
