using System.Data;
using Microsoft.Data.SqlClient;

namespace Proyecto_Formulario
{
    public static class Conexion
    {
        
        private static string cadenaConexion = "Server= CYNTHIA\\SQLEXPRESS; Database=BD_Proyecto; Integrated Security=True; TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}