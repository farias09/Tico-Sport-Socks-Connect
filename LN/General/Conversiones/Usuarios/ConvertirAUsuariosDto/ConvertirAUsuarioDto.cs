﻿using Abstracciones.LN.Interfaces.General.Conversiones.Usuarios.ConvertirAUsuariosDto;
using Abstracciones.Modelos.Usuarios;
using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.General.Conversiones.Usuarios.ConvertirAUsuariosDto
{
    public class ConvertirAUsuarioDto : IConvertirAUsuariosDto
    {
        public UsuarioDto ConvertirObjetoAUsuarioDto(UsuariosTabla elUsuario)
        {
            return new UsuarioDto
            {
                Usuario_ID = elUsuario.Usuario_ID,
                Nombre = elUsuario.Nombre,
                Email = elUsuario.Email,
                Telefono = elUsuario.Telefono,
                Direccion = elUsuario.Direccion,
                Provincia = elUsuario.Provincia,
                Numero = elUsuario.Numero,
                Rol_ID = elUsuario.Rol_ID,
                estado = elUsuario.estado,
                FechaRegistro = elUsuario.FechaRegistro
            };
        }
    }
}