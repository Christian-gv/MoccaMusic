using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoccaMusic.Config;
using MoccaMusic.Controllers;
using MoccaMusic.Models;

namespace MoccaMusic.Controllers
{
    class ArtistasControllers
    {
        ArtistasModels _artistasModel = new ArtistasModels();

        public List<ArtistasModels> Todos()
        {
            return _artistasModel.Todos();
        }
        public ArtistasModels Insertar(ArtistasModels artistasModel)
        {
            return _artistasModel.Insertar(artistasModel);
        }
        public bool Modificar(ArtistasModels artista)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "UPDATE Artistas SET Nombre = @Nombre WHERE ID_Artista = @ID_Artista";
                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", artista.Nombre);
                        comando.Parameters.AddWithValue("@ID_Artista", artista.ID_Artista);

                        int filasAfectadas = comando.ExecuteNonQuery(); // Ejecutar la actualización
                        return filasAfectadas > 0; // Devuelve true si se modificó alguna fila
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL al modificar el artista: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al modificar el artista: {ex.Message}");
                return false;
            }
        }
        public bool Eliminar(int idArtista)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "DELETE FROM Artistas WHERE ID_Artista = @ID_Artista";
                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Artista", idArtista);

                        int filasAfectadas = comando.ExecuteNonQuery(); // Ejecutar la eliminación
                        return filasAfectadas > 0; // Devuelve true si se eliminó alguna fila
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL al eliminar el artista: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al eliminar el artista: {ex.Message}");
                return false;
            }
        }
    }
}
