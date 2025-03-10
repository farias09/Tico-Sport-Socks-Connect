using Abstracciones.AD.Interfaces.Usuarios.ListarUsuario;
using Abstracciones.LN.Interfaces.General.Conversiones.Usuarios.ConvertirAUsuariosDto;
using Abstracciones.LN.Interfaces.Usuarios.ListarUsuario;
using Abstracciones.Modelos.Usuarios;
using Abstracciones.Utilidades;
using LN.Cajas.ListarCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.Usuarios.ListarUsuario
{
    public class ListarUsuarioLN : IListarUsuarioLN
    {
        private readonly IListarUsuarioAD _listarUsuarioAD;
        private readonly IConvertirAUsuariosDto convertirAUsuariosDto;

        public ListarUsuarioLN(IListarUsuarioAD listarUsuarioAD, IConvertirAUsuariosDto convertirAUsuariosDto)
        {
            this._listarUsuarioAD = listarUsuarioAD;
            this.convertirAUsuariosDto = convertirAUsuariosDto;
        }

        public List<UsuarioDto> Listar()
        {
            List<UsuarioDto> laListaDeUsuarios = _listarUsuarioAD.Listar();

            // Desencriptar la contraseña para cada usuario
            foreach (var usuario in laListaDeUsuarios)
            {
                if (!string.IsNullOrEmpty(usuario.Contraseña))
                {
                    usuario.Contraseña = AesEncryption.Decrypt(usuario.Contraseña);
                }
                else
                {
                    usuario.Contraseña = "Sin contraseña";
                }
            }

            return laListaDeUsuarios;
        }

        public UsuarioDto ObtenerUsuarioPorId(int usuarioId)
        {
            var usuario = _listarUsuarioAD.Listar().FirstOrDefault(u => u.Usuario_ID == usuarioId);
            return usuario;
        }
    }
}
