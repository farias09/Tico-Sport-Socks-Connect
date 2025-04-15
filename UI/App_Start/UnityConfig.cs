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

using Abstracciones.AD.Interfaces.Mensajes;
using Abstracciones.LN.Interfaces.Mensajes;
using AcessoADatos.Mensajes;
using LN.Mensajes;
using System.Web.Http;
using Unity.Mvc5;
using Unity.WebApi;
using System.Configuration;
using Abstracciones.AD.Interfaces.Usuarios.ActualizarUsuario;
using Abstracciones.AD.Interfaces.Usuarios.EliminarUsuario;
using Abstracciones.LN.Interfaces.Usuarios.ActualizarUsuario;
using Abstracciones.LN.Interfaces.Usuarios.EliminarUsuario;
using AccesoADatos.Usuarios.ActualizarUsuario;
using AccesoADatos.Usuarios.EliminarUsuario;
using LN.Usuarios.ActualizarUsuario;
using LN.Usuarios.EliminarUsuario;
using Abstracciones.LN.Interfaces.Usuarios.CrearUsuario;
using LN.Usuarios.CrearUsuario;
using AcessoADatos.Usuarios.CrearUsuario;
using Abstracciones.AD.Interfaces.Usuarios.CrearUsuario;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Data.Entity;
using TicoSportSocksConnect.UI.Models;
using TicoSportSocksConnect.UI;
using Unity.Injection;
using System.Web;
using Abstracciones.AD.Interfaces.Cajas.CerrarCaja;
using Abstracciones.LN.Interfaces.Cajas.CerrarCaja;
using AcessoADatos.Cajas.CerrarCaja;
using LN.Cajas.CerrarCaja;
using AcessoADatos.MovimientosCajas;

namespace UI
{
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer().AddExtension(new Diagnostic());
              RegisterTypes(container);
              return container;
          });

        public static IUnityContainer Container => container.Value;
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            // Registrar tipos en el contenedor de Unity

            container.RegisterType<Contexto>(new HierarchicalLifetimeManager());

            container.RegisterType<ICrearVentaLN, CrearVentaLN>();
            container.RegisterType<ICrearVentaAD, CrearVentaAD>();

            container.RegisterType<IListarVentaLN, ListarVentaLN>();
            container.RegisterType<IListarVentaAD, ListarVentaAD>();

            container.RegisterType<IConvertirAVentasTabla, ConvertirAVentasTabla>();
            container.RegisterType<IConvertirAVentasDto, ConvertirAVentaDto>();

            //Usuarios
            container.RegisterType<ICrearUsuarioLN, CrearUsuarioLN>();
            container.RegisterType<ICrearUsuarioAD, CrearUsuarioAD>();
            container.RegisterType<IListarUsuarioLN, ListarUsuarioLN>();
            container.RegisterType<IListarUsuarioAD, ListarUsuarioAD>();
            container.RegisterType<IActualizarUsuarioLN, ActualizarUsuarioLN>();
            container.RegisterType<IActualizarUsuarioAD, ActualizarUsuarioAD>();
            container.RegisterType<IEliminarUsuarioLN, EliminarUsuarioLN>();
            container.RegisterType<IEliminarUsuarioAD, EliminarUsuarioAD>();

            container.RegisterType<IConvertirAUsuariosDto, ConvertirAUsuarioDto>();
            container.RegisterType<IConvertirAUsuariosTabla, ConvertirAUsuarioTabla>();

            //Cajas
            container.RegisterType<IListarCajaLN, ListarCajaLN>();
            container.RegisterType<IListarCajaAD, ListarCajaAD>();

            container.RegisterType<IConvertirACajasDto, ConvertirACajasDto>();
            container.RegisterType<IConvertirACajasTabla, ConvertirACajasTabla>();


            container.RegisterType<ICrearCajaLN, CrearCajaLN>();
            container.RegisterType<ICrearCajaAD, CrearCajaAD>();

            container.RegisterType<ICerrarCajaLN, CerrarCajaLN>();
            container.RegisterType<ICerrarCajaAD, CerrarCajaAD>();

            container.RegisterType<ICrearMovimientoLN, CrearMovimientoLN>();
            container.RegisterType<ICrearMovimientoAD, CrearMovimientoAD>();

            container.RegisterType<IListarMovimientosLN, ListarMovimientosLN>();
            container.RegisterType<IListarMovimientosAD, ListarMovimientosAD>();

            container.RegisterType<Contexto>(new HierarchicalLifetimeManager());

            container.RegisterType<IConvertirObjetoAMovimientosCajaTabla, ConvertirObjetoAMovimientosCajaTabla>();


            container.RegisterType<IMensajeRepositorio, MensajeRepositorio>();
            container.RegisterType<IMensajeService, MensajeService>();

            //Identity
            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<ApplicationUserManager>(new HierarchicalLifetimeManager());
            container.RegisterType<ApplicationSignInManager>(new HierarchicalLifetimeManager());
            container.RegisterFactory<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication);
        }
    }
}
