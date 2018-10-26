using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Videoclub
{

    class Alquiler
    {
    static String connectionString = ConfigurationManager.ConnectionStrings["ConexionVIDEOCLUB"].ConnectionString;
    static SqlConnection conexion = new SqlConnection(connectionString);
    static string cadena;
    static SqlCommand comando;
    static SqlDataReader registros;
    }
}
