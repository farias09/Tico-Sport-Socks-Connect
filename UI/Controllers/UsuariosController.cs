using System.Web.Mvc;
using Abstracciones.LN.Interfaces.Usuarios.CrearUsuario;
using Abstracciones.LN.Interfaces.Usuarios.ListarUsuario;
using Abstracciones.LN.Interfaces.Usuarios.ActualizarUsuario;
using Abstracciones.LN.Interfaces.Usuarios.EliminarUsuario;
using UI.Models;
using System.Collections.Generic;
using System.Linq;
using Abstracciones.Modelos.Usuarios;
using System;

namespace UI.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IListarUsuarioLN _listarUsuarioLN;
        private readonly ICrearUsuarioLN _crearUsuarioLN;
        private readonly IActualizarUsuarioLN _actualizarUsuarioLN;
        private readonly IEliminarUsuarioLN _eliminarUsuarioLN;

        public UsuariosController(
            IListarUsuarioLN listarUsuarioLN,
            ICrearUsuarioLN crearUsuarioLN,
            IActualizarUsuarioLN actualizarUsuarioLN,
            IEliminarUsuarioLN eliminarUsuarioLN)
        {
            _listarUsuarioLN = listarUsuarioLN;
            _crearUsuarioLN = crearUsuarioLN;
            _actualizarUsuarioLN = actualizarUsuarioLN;
            _eliminarUsuarioLN = eliminarUsuarioLN;
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuariosDto = _listarUsuarioLN.Listar();
            var usuariosViewModel = usuariosDto.Select(u => new UsuarioViewModel
            {
                Id = u.Usuario_ID,
                Nombre = u.Nombre,
                Email = u.Email,
                Telefono = u.Telefono,
                Direccion = u.Direccion,
                Provincia = u.Provincia,
                Numero = u.Numero,
                Contraseña = u.Contraseña, // Contraseña desencriptada
                FechaRegistro = u.FechaRegistro,
                Estado = u.estado,
                Rol = u.Rol_ID == 1 ? "Administrador" : "Usuario"
            }).ToList();

            return View(usuariosViewModel);
        }

        // POST: Usuarios/Crear
        [HttpPost]
        public ActionResult Crear(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var usuarioDto = new Abstracciones.Modelos.Usuarios.UsuarioDto
                {
                    Nombre = usuarioViewModel.Nombre,
                    Email = usuarioViewModel.Email,
                    Rol_ID = usuarioViewModel.Rol == "Administrador" ? 1 : 2,
                    estado = true,
                    FechaRegistro = System.DateTime.Now,
                    Contraseña = usuarioViewModel.Contraseña,
                    Numero = "N/A" // Asignar un valor por defecto
                };

                _crearUsuarioLN.Crear(usuarioDto);
                return RedirectToAction("Index");
            }

            return View("Index", _listarUsuarioLN.Listar());
        }

        // POST: Usuarios/Editar
        [HttpPost]
        public ActionResult Editar(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Obtener el usuario existente primero
                    var usuarioExistente = _listarUsuarioLN.ObtenerUsuarioPorId(usuarioViewModel.Id);

                    if (usuarioExistente == null)
                    {
                        TempData["ErrorMessage"] = "Usuario no encontrado";
                        return RedirectToAction("Index");
                    }

                    // Actualizar todos los campos permitidos
                    var usuarioDto = new UsuarioDto
                    {
                        Usuario_ID = usuarioViewModel.Id,
                        Nombre = usuarioViewModel.Nombre,
                        Email = usuarioViewModel.Email,
                        Telefono = usuarioViewModel.Telefono,
                        Direccion = usuarioViewModel.Direccion,
                        Provincia = usuarioViewModel.Provincia,
                        Numero = usuarioViewModel.Numero,
                        Rol_ID = usuarioViewModel.Rol == "Administrador" ? 1 : 2,
                        estado = usuarioViewModel.Estado,
                        FechaRegistro = usuarioExistente.FechaRegistro,
                        Contraseña = usuarioExistente.Contraseña // Mantener la contraseña original
                    };

                    _actualizarUsuarioLN.Actualizar(usuarioDto);
                    TempData["SuccessMessage"] = "Usuario actualizado correctamente";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error al actualizar usuario: {ex.Message}";
                    return RedirectToAction("Index");
                }
            }

            TempData["ErrorMessage"] = "Datos del formulario inválidos";
            return RedirectToAction("Index");
        }

        // POST: Usuarios/Eliminar
        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            _eliminarUsuarioLN.Eliminar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Clientes()
        {
            var usuariosDto = _listarUsuarioLN.Listar();

            var clientesViewModel = usuariosDto
                .Where(u => u.Rol_ID == 2) // Solo clientes
                .Select(u => new UsuarioViewModel
                {
                    Id = u.Usuario_ID,
                    Nombre = u.Nombre,
                    Email = u.Email,
                    Telefono = u.Telefono,
                    Direccion = u.Direccion,
                    Provincia = u.Provincia,
                    Numero = u.Numero,
                    Contraseña = u.Contraseña,
                    FechaRegistro = u.FechaRegistro,
                    Estado = u.estado,
                    Rol = "Cliente"
                })
                .ToList();

            return View("Index", clientesViewModel); // Usa la misma vista de Index
        }

        public ActionResult Administradores()
        {
            var usuariosDto = _listarUsuarioLN.Listar();

            var adminsViewModel = usuariosDto
                .Where(u => u.Rol_ID == 1) 
                .Select(u => new UsuarioViewModel
                {
                    Id = u.Usuario_ID,
                    Nombre = u.Nombre,
                    Email = u.Email,
                    Telefono = u.Telefono,
                    Direccion = u.Direccion,
                    Provincia = u.Provincia,
                    Numero = u.Numero,
                    Contraseña = u.Contraseña,
                    FechaRegistro = u.FechaRegistro,
                    Estado = u.estado,
                    Rol = "Administrador" 
                })
                .ToList();

            return View("Index", adminsViewModel); 
        }
    }
}