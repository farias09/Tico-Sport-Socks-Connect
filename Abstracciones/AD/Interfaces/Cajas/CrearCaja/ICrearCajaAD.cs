using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.AD.Interfaces.Cajas.CrearCaja
{
    public interface ICrearCajaAD
    {
        int Crear(CajasTabla laCajaAGuardar);
    }
}
