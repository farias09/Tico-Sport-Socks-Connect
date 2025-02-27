﻿using TicoSportSocksConnect.Abstracciones.AD.Interfaces.Inventario;
using TicoSportSocksConnect.Abstracciones.LN.Interfaces.Inventario;
using TicoSportSocksConnect.LN.Inventario;
using TicoSportsSocksConnect.AccesoADatos.Inventario;

namespace Frontend.Extenciones
{
    public static class InyeccionDeDependencias
    {
        public static void ConfigurarDependencias(this IServiceCollection services)
        {
            // Registrar implementaciones de Acceso a Datos
            services.AddScoped<IProductoCrearAD, ProductoCrearAD>();
            services.AddScoped<IProductoLeerAD, ProductoLeerAD>();
            services.AddScoped<IProductoActualizarAD, ProductoActualizarAD>();
            services.AddScoped<IProductoEliminarAD, ProductoEliminarAD>();

            // Registrar implementaciones de Lógica de Negocio
            services.AddScoped<IProductoCrearLN, ProductoCrearLN>();
            services.AddScoped<IProductoLeerLN, ProductoLeerLN>();
            services.AddScoped<IProductoActualizarLN, ProductoActualizarLN>();
            services.AddScoped<IProductoEliminarLN, ProductoEliminarLN>();
        }
    }
}
