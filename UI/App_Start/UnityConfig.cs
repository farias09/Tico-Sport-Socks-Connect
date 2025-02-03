using System;
using Unity;
using Abstracciones.LN.Interfaces.Usuarios;
using LN.Usuarios;
using Abstracciones.LN.Interfaces.Cajas;
using LN.Cajas;
using Abstracciones.LN.Interfaces.Ventas.CrearVenta;
using Abstracciones.LN.Interfaces.Ventas.ListarVenta;
using LN.Ventas.CrearVenta;
using LN.Ventas.ListarVenta;
using Abstracciones.AD.Interfaces.Ventas.CrearVenta;
using AcessoADatos.Ventas.CrearVenta;
using Abstracciones.LN.Interfaces.General.Conversiones.Ventas.ConvertirAVentasTabla;
using LN.General.Conversiones.Ventas.ConvertirAVentasTabla;
using Abstracciones.AD.Interfaces.Ventas.ListarVenta;
using AcessoADatos.Ventas.ListarVenta;
using Abstracciones.LN.Interfaces.General.Conversiones.Ventas.ConvertirAVentasDto;
using LN.General.Conversiones.Ventas.ConvertirAVentasDto;
using Abstracciones.AD.Interfaces.Usuarios;
using Abstracciones.AD.Interfaces.Cajas;
using AcessoADatos.Usuarios.CrearUsuario;
using AcessoADatos.Usuarios.ListarUsuario;
using AcessoADatos.Cajas.ListarCaja;
using AcessoADatos.Cajas.CrearCaja;
using Abstracciones.AD.Interfaces.Cajas.ListarCaja;
using Abstracciones.AD.Interfaces.Usuarios.ListarUsuario;
using Abstracciones.LN.Interfaces.Cajas.ListarCaja;
using Abstracciones.LN.Interfaces.Usuarios.ListarUsuario;
using LN.Cajas.ListarCaja;
using LN.Usuarios.ListarUsuario;
using Abstracciones.LN.Interfaces.General.Conversiones.Usuarios.ConvertirAUsuariosDto;
using LN.General.Conversiones.Usuarios.ConvertirAUsuariosDto;
using Abstracciones.LN.Interfaces.General.Conversiones.Cajas.ConvertirACajasDto;
using LN.General.Conversiones.Cajas.ConvertirACajasDto;
using Abstracciones.LN.Interfaces.General.Conversiones.Usuarios.ConvertirAUsuariosTabla;
using LN.General.Conversiones.Cajas.ConvertirACajasTabla;
using LN.General.Conversiones.Usuarios.ConvertirAUsuariosTabla;
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


        }
    }
}
