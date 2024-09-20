using MoccaMusic.Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoccaMusic.Models
{
    public class AlbumesModel
    {
        public int ID_Album { get; set; }
        public string Titulo { get; set; }
        public int ID_Artista { get; set; }
        public int ID_Genero { get; set; }
        public string NombreArtista { get; set; } // para mostrar el nombre del artista
        public string NombreGenero { get; set; }  // para mostrar el nombre del género

        public List<AlbumesModel> Todos()
        {
            var albumes = new List<AlbumesModel>();
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = @"
                    SELECT Albumes.ID_Album, Albumes.Titulo, Artistas.Nombre AS NombreArtista, 
                           Generos.Nombre AS NombreGenero
                    FROM Albumes
                    INNER JOIN Artistas ON Albumes.ID_Artista = Artistas.ID_Artista
                    INNER JOIN Generos ON Albumes.ID_Genero = Generos.ID_Genero";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        using (var lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                albumes.Add(new AlbumesModel
                                {
                                    ID_Album = Convert.ToInt32(lector["ID_Album"]),
                                    Titulo = lector["Titulo"].ToString(),
                                    NombreArtista = lector["NombreArtista"].ToString(),
                                    NombreGenero = lector["NombreGenero"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al obtener la lista de álbumes:{ ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al obtener la lista de álbumes: {ex.Message}");
            }
            return albumes;
        }

        public AlbumesModel Insertar(AlbumesModel album)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = @"
                    INSERT INTO Albumes (Titulo, ID_Artista, ID_Genero) 
                    OUTPUT inserted.ID_Album, inserted.Titulo
                    VALUES (@Titulo, @ID_Artista, @ID_Genero)";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Titulo", album.Titulo);
                        comando.Parameters.AddWithValue("@ID_Artista", album.ID_Artista);
                        comando.Parameters.AddWithValue("@ID_Genero", album.ID_Genero);

                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                return new AlbumesModel
                                {
                                    ID_Album = Convert.ToInt32(lector["ID_Album"]),
                                    Titulo = lector["Titulo"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al insertar el álbum: {ex.Message}");
                }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar el álbum: {ex.Message}");
            }
            return null;
        }
        public bool Eliminar(int idAlbum)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "DELETE FROM Albumes WHERE ID_Album = @ID_Album";
                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Album", idAlbum);
                        int filasAfectadas = comando.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la lista de álbumes:{ex.Message}");
                return false;
            }
        }

  
        public bool Modificar(AlbumesModel album)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "UPDATE Albumes SET Titulo = @Titulo, ID_Artista = @ID_Artista, ID_Genero = @ID_Genero WHERE ID_Album = @ID_Album";
                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Titulo", album.Titulo);
                        comando.Parameters.AddWithValue("@ID_Artista", album.ID_Artista);
                        comando.Parameters.AddWithValue("@ID_Genero", album.ID_Genero);
                        comando.Parameters.AddWithValue("@ID_Album", album.ID_Album);
                        int filasAfectadas = comando.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar la lista de álbumes:{ex.Message}");
                return false;
            }
        }
    }
}