using MoccaMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoccaMusic.Controllers
{
    class VentasController
    {
        VentasModel _ventasModel = new VentasModel();
        public List<VentasModel> Todos()
        {
            try
            {
                return _ventasModel.Todos();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener todas las ventas: {ex.Message}");
                return new List<VentasModel>();
            }
        }
        public VentasModel Insertar(VentasModel venta)
        {
            try
            {
                return _ventasModel.Insertar(venta);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar la venta: {ex.Message}");
                return null;
            }
        }
        public bool Eliminar(int idVenta)
        {
            try
            {
                return _ventasModel.Eliminar(idVenta);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la venta: {ex.Message}");
                return false;
            }
        }
        public bool Modificar(VentasModel venta)
        {
            try
            {
                return _ventasModel.Modificar(venta);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar la venta: {ex.Message}");
                return false;
            }
        }
    }
}
