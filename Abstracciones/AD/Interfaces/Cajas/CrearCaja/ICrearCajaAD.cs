using Abstracciones.ModelosBaseDeDatos;

namespace Abstracciones.AD.Interfaces.Cajas.CrearCaja
{
    public interface ICrearCajaAD
    {
        int Crear(CajasTabla laCajaAGuardar);

        bool HayCajaAbierta();
    }
}
