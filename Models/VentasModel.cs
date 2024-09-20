using MoccaMusic.Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoccaMusic.Models
{
    public class VentasModel
    {
        public int ID_Venta { get; set; }
        public int ID_Album { get; set; }
        public DateTime Fecha_Venta { get; set; }

        public List<VentasModel> Todos()
        {
            var ventas = new List<VentasModel>();
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "SELECT ID_Venta, ID_Album, Fecha_Venta FROM Ventas";
                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        using (var lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                ventas.Add(new VentasModel
                                {
                                    ID_Venta = Convert.ToInt32(lector["ID_Venta"]),
                                    ID_Album = Convert.ToInt32(lector["ID_Album"]),
                                    Fecha_Venta = Convert.ToDateTime(lector["Fecha_Venta"])
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al obtener las ventas: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");
            }
            return ventas;
        }

        public VentasModel Insertar(VentasModel venta)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "INSERT INTO Ventas (ID_Album, Fecha_Venta) " +
                                   "OUTPUT inserted.ID_Venta, inserted.ID_Album, inserted.Fecha_Venta " +
                                   "VALUES (@ID_Album, @Fecha_Venta)";
                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Album", venta.ID_Album);
                        comando.Parameters.AddWithValue("@Fecha_Venta", venta.Fecha_Venta);

                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                return new VentasModel
                                {
                                    ID_Venta = Convert.ToInt32(lector["ID_Venta"]),
                                    ID_Album = Convert.ToInt32(lector["ID_Album"]),
                                    Fecha_Venta = Convert.ToDateTime(lector["Fecha_Venta"])
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al insertar la venta: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");
            }
            return null;
        }
       public bool Eliminar(int idVenta)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "DELETE FROM Ventas WHERE ID_Venta = @ID_Venta";
                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Venta", idVenta);
                        var filasAfectadas = comando.ExecuteNonQuery();

                        return filasAfectadas > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al eliminar la venta: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");
            }
            return false;
        }

  public bool Modificar(VentasModel venta)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "UPDATE Ventas SET ID_Album = @ID_Album, Fecha_Venta = @Fecha_Venta " +
                                   "WHERE ID_Venta = @ID_Venta";
                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Album", venta.ID_Album);
                        comando.Parameters.AddWithValue("@Fecha_Venta", venta.Fecha_Venta);
                        comando.Parameters.AddWithValue("@ID_Venta", venta.ID_Venta);

                        var filasAfectadas = comando.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al modificar la venta: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");
            }
            return false;
        }
    }
}
