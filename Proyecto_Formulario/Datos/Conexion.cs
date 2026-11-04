using Microsoft.Data.SqlClient;

namespace Proyecto_Formulario
{
    public static class Conexion
    {

        #region Configuración de conexión

        private static string cadenaConexion = "Server=.; Database=BD_Proyecto; Integrated Security=True; TrustServerCertificate=True;";

        // Crear y devolver una nueva conexión a la base de datos
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
        #endregion

    }
}