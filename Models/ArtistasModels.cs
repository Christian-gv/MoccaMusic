using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MoccaMusic.Config;


namespace MoccaMusic.Models
{
    internal class ArtistasModels
    { 
    public int ID_Artista { get; set; }
    public string Nombre { get; set; }

    public List<ArtistasModels> Todos()
    {
        var artistas = new List<ArtistasModels>();
        try
        {
            using (var conexion = Conexion.GetConnection())
            {
                var consulta = "SELECT ID_Artista, Nombre FROM Artistas";
                using (var comando = new SqlCommand(consulta, conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            artistas.Add(new ArtistasModels
                            {
                                ID_Artista = Convert.ToInt32(lector["ID_Artista"].ToString()),
                                Nombre = lector["Nombre"].ToString()
                            });
                        }
                    }
                }
            }
        }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL al obtener la lista de artistas: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al obtener la lista de artistas: {ex.Message}");
            }
            return artistas;
        }

        public ArtistasModels Insertar(ArtistasModels artista)
        {
            try
            {
                using (var conexion = Conexion.GetConnection()) 
                {
                    var consulta = "INSERT INTO Artistas (Nombre) " +
                                   "OUTPUT inserted.ID_Artista, inserted.Nombre " +
                                   "VALUES (@Nombre)";
                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", artista.Nombre);
                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                return new ArtistasModels
                                {
                                    ID_Artista = Convert.ToInt32(lector["ID_Artista"]),
                                    Nombre = lector["Nombre"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL al insertar el artista: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al insertar el artista: {ex.Message}");
            }
            return null;
        }
    }
}