﻿using Abstracciones.LN.Interfaces.General.Conversiones.Productos.ConvertirAProductosTabla;
using Abstracciones.Modelos.Productos;
using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.General.Conversiones.Productos.ProductosTablaAProductosDto
{
    public class ConvertirAProductosTabla : IConvertirAProductosTabla
    {
        public ProductosTabla ConvertirObjetoAProductosTabla(ProductosDto elProducto)
        {
            return new ProductosTabla
            {
                Producto_ID = elProducto.Producto_ID,
                nombre = elProducto.nombre,
                descripcion = elProducto.descripcion,
                precio = elProducto.precio,
                stock = elProducto.stock,
                imagen = elProducto.imagen,
                CodigoDelProducto = elProducto.CodigoDelProducto,
                Estado = elProducto.Estado,
                Categoria_ID = elProducto.Categoria_ID
            };
        }
    }
}
