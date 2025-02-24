using Abstracciones.AD.Interfaces.Cajas.CrearCaja;
using Abstracciones.AD.Interfaces.Cajas.ListarCaja;
using Abstracciones.AD.Interfaces.MoviemientosCaja;
using Abstracciones.AD.Interfaces.Usuarios.ListarUsuario;
using Abstracciones.AD.Interfaces.Ventas.CrearVenta;
using Abstracciones.AD.Interfaces.Ventas.ListarVenta;
using Abstracciones.LN.Interfaces.Cajas.CrearCaja;
using Abstracciones.LN.Interfaces.Cajas.ListarCaja;
using Abstracciones.LN.Interfaces.General.Conversiones.Cajas.ConvertirACajasDto;
using Abstracciones.LN.Interfaces.General.Conversiones.MovimientosCaja;
using Abstracciones.LN.Interfaces.General.Conversiones.Usuarios.ConvertirAUsuariosDto;
using Abstracciones.LN.Interfaces.General.Conversiones.Usuarios.ConvertirAUsuariosTabla;
using Abstracciones.LN.Interfaces.General.Conversiones.Ventas.ConvertirAVentasDto;
using Abstracciones.LN.Interfaces.General.Conversiones.Ventas.ConvertirAVentasTabla;
using Abstracciones.LN.Interfaces.MovimientosCaja;
using Abstracciones.LN.Interfaces.Usuarios.ListarUsuario;
using Abstracciones.LN.Interfaces.Ventas.CrearVenta;
using Abstracciones.LN.Interfaces.Ventas.ListarVenta;
using AccesoADatos;
using AccesoADatos.Cajas.CrearCaja;
using AccesoADatos.MovimientosCajas.CrearMovimiento;
using AcessoADatos.Cajas.ListarCaja;
using AcessoADatos.Usuarios.ListarUsuario;
using AcessoADatos.Ventas.CrearVenta;
using AcessoADatos.Ventas.ListarVenta;
using LN.Cajas.CrearCaja;
using LN.Cajas.ListarCaja;
using LN.General.Conversiones.Cajas.ConvertirACajasDto;
using LN.General.Conversiones.Cajas.ConvertirACajasTabla;
using LN.General.Conversiones.MovimientosCaja;
using LN.General.Conversiones.Usuarios.ConvertirAUsuariosDto;
using LN.General.Conversiones.Usuarios.ConvertirAUsuariosTabla;
using LN.General.Conversiones.Ventas.ConvertirAVentasDto;
using LN.General.Conversiones.Ventas.ConvertirAVentasTabla;
using LN.MovimientosCaja;
using LN.Usuarios.ListarUsuario;
using LN.Ventas.CrearVenta;
using LN.Ventas.ListarVenta;
using System;
using Unity;
using Unity.Lifetime;
namespace UI
{
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        public static IUnityContainer Container => container.Value;
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ICrearVentaLN, CrearVentaLN>();
            container.RegisterType<ICrearVentaAD, CrearVentaAD>();

            container.RegisterType<IListarVentaLN, ListarVentaLN>();       
            container.RegisterType<IListarVentaAD, ListarVentaAD>();

            container.RegisterType<IConvertirAVentasTabla, ConvertirAVentasTabla>();
            container.RegisterType<IConvertirAVentasDto, ConvertirAVentaDto>();

            container.RegisterType<IListarUsuarioLN, ListarUsuarioLN>();
            container.RegisterType<IListarUsuarioAD, ListarUsuarioAD>();

            container.RegisterType<IConvertirAUsuariosDto, ConvertirAUsuarioDto>();
            container.RegisterType<IConvertirAUsuariosTabla, ConvertirAUsuarioTabla>();

            container.RegisterType<IListarCajaLN, ListarCajaLN>();
            container.RegisterType<IListarCajaAD, ListarCajaAD>();

            container.RegisterType<IConvertirACajasDto, ConvertirACajasDto>();
            container.RegisterType<IConvertirACajasTabla, ConvertirACajasTabla>();

            container.RegisterType<ICrearCajaLN, CrearCajaLN>();
            container.RegisterType<ICrearCajaAD, CrearCajaAD>();

            container.RegisterType<ICrearMovimientoLN, CrearMovimientoLN>();
            container.RegisterType<ICrearMovimientoAD, CrearMovimientoAD>();

            container.RegisterType<Contexto>(new HierarchicalLifetimeManager());

            container.RegisterType<IConvertirObjetoAMovimientosCajaTabla, ConvertirObjetoAMovimientosCajaTabla>();

        }
    }
}
