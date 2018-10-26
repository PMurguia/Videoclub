using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Videoclub
{

    class Peliculas
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["ConexionVIDEOCLUB"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;
        static SqlDataReader registros;

        private string nombre;
        private string director;
        private string publico;
        private string sinopsis;
        private bool alquilada;

        public Peliculas()
        {
        }

        public Peliculas(string nombre, string director, string publico, string sinopsis, bool alquilada)
        {
            this.nombre = nombre;
            this.director = director;
            this.publico = publico;
            this.sinopsis = sinopsis;
            this.alquilada = alquilada;
        }

        public string GetNombre()
        {
            return nombre;
        }
        public string GerDirector()
        {
            return director;
        }
        public string GetPublico()
        {
            return publico;
        }
        public string GetSinopsis()
        {
            return sinopsis;
        }
        public bool GetAlquilada()
        {
            return alquilada;
        }

       



    }
}
