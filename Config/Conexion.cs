using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MoccaMusic.Config
{
    public static class Conexion
    {
        private static readonly string connectionString;

        static Conexion()
        {
            connectionString = "Server=(local);Database=MusicStore;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        }

        public static SqlConnection GetConnection()
        {
            try
            {
                var connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al conectar con la base de datos: {ex.Message}");
                throw;
            }
        }
    }
}
