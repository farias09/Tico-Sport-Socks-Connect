using Abstracciones.AD.Interfaces.Categorias.ListarCategorias;
using Abstracciones.LN.Interfaces.Categorias.ListarCategorias;
using Abstracciones.LN.Interfaces.General.Conversiones.Categorias.ConvertirACategoriasDto;
using Abstracciones.Modelos.Categorias;
using Abstracciones.ModelosBaseDeDatos;
using AcessoADatos.Categorias.ListarCategorias;
using LN.General.Conversiones.Categorias.ConvertirACategoriasDto;
using System.Collections.Generic;

namespace LN.Categorias.ListarCategorias
{
    public class ListarCategoriasLN : IListarCategoriasLN
    {
        IListarCategoriasAD _listarCategoriasAD;
        IConvertirACategoriasDto _convertirACategoriasDto;

        public ListarCategoriasLN()
        {
            _listarCategoriasAD = new ListarCategoriasAD();
            _convertirACategoriasDto = new ConvertirACategoriasDto();
        }

        public List<CategoriasDto> Listar()
        {
            List<CategoriasDto> laListaDeCategorias = _listarCategoriasAD.Listar();
            return laListaDeCategorias;
        }

        private List<CategoriasDto> ObtenerLaListaConvertida(List<CategoriasTabla> laListaDeCategorias)
        {
            List<CategoriasDto> laListaDeCodigos = new List<CategoriasDto>();
            foreach (CategoriasTabla laCategoria in laListaDeCategorias)
            {
                laListaDeCodigos.Add(_convertirACategoriasDto.ConvertirObjetoACategoriasDto(laCategoria));
            }
            return laListaDeCodigos;
        }
    }
}
