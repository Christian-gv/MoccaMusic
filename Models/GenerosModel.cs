using MoccaMusic.Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoccaMusic.Models
{
    internal class GenerosModel { 
    public int ID_Genero { get; set; }
    public string Nombre { get; set; }

    // Método para obtener todos los géneros
    public List<GenerosModel> Todos()
    {
        var generos = new List<GenerosModel>();
        try
        {
            using (var conexion = Conexion.GetConnection())
            {
                var consulta = "SELECT ID_Genero, Nombre FROM Generos";
                using (var comando = new SqlCommand(consulta, conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            generos.Add(new GenerosModel
                            {
                                ID_Genero = Convert.ToInt32(lector["ID_Genero"].ToString()),
                                Nombre = lector["Nombre"].ToString()
                            });
                        }
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Error SQL al obtener los géneros: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error general al obtener los géneros: {ex.Message}");
        }
        return generos;
    }

    // Método para insertar un nuevo género
    public GenerosModel Insertar(GenerosModel genero)
    {
        try
        {
            using (var conexion = Conexion.GetConnection())
            {
                var consulta = "INSERT INTO Generos (Nombre) " +
                               "OUTPUT inserted.ID_Genero, inserted.Nombre " +
                               "VALUES (@Nombre)";
                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", genero.Nombre);
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            return new GenerosModel
                            {
                                ID_Genero = Convert.ToInt32(lector["ID_Genero"]),
                                Nombre = lector["Nombre"].ToString()
                            };
                        }
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Error SQL al insertar el género: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error general al insertar el género: {ex.Message}");
        }
        return null;
    }

    // Método para modificar un género existente
    public bool Modificar(GenerosModel genero)
    {
        try
        {
            using (var conexion = Conexion.GetConnection())
            {
                var consulta = "UPDATE Generos SET Nombre = @Nombre WHERE ID_Genero = @ID_Genero";
                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", genero.Nombre);
                    comando.Parameters.AddWithValue("@ID_Genero", genero.ID_Genero);

                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Error SQL al modificar el género: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error general al modificar el género: {ex.Message}");
            return false;
        }
    }

    // Método para eliminar un género existente
    public bool Eliminar(int idGenero)
    {
        try
        {
            using (var conexion = Conexion.GetConnection())
            {
                var consulta = "DELETE FROM Generos WHERE ID_Genero = @ID_Genero";
                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@ID_Genero", idGenero);

                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Error SQL al eliminar el género: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error general al eliminar el género: {ex.Message}");
            return false;
        }
    }
}
}
