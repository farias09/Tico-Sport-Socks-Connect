using Abstracciones.AD.Interfaces.Productos.ListarProducto;
using Abstracciones.LN.Interfaces.General.Conversiones.Productos.ConvertirAProductosDto;
using Abstracciones.LN.Interfaces.Productos.ListarProducto;
using Abstracciones.Modelos.Productos;
using Abstracciones.ModelosBaseDeDatos;
using AcessoADatos.Productos.ListarProductos;
using LN.General.Conversiones.Productos.ConvertirAProductosDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.Productos.ListarProductos
{
    public class ListarProductoLN : IListarProductoLN
    {
        IListarProductoAD _listarProductoAD;
        IConvertirAProductosDto _convertirAProductosDto;

        public ListarProductoLN()
        {
            _listarProductoAD = new ListarProductoAD();
            _convertirAProductosDto = new ConvertirAProductosDto();
        }

        public List<ProductosDto> Listar()
        {
            List<ProductosDto> laListaDeProductos = _listarProductoAD.Listar();
            return laListaDeProductos;
        }

        private List<ProductosDto> ObtenerLaListaConvertida(List<ProductosTabla> laListaDeProductos)
        {
            List<ProductosDto> laListaDeCodigos = new List<ProductosDto>();
            foreach(ProductosTabla elProducto in laListaDeProductos)
            {
                laListaDeCodigos.Add(_convertirAProductosDto.ConvertirObjetoAProductoDto(elProducto));
            }
            return laListaDeCodigos;
        }
    }
}
