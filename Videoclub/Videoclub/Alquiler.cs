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

        private string pelicula;
        private string usuario;
        private DateTime fechaRent;
        private DateTime fechaDev;

        public Alquiler()
        {

        }

        public Alquiler(string pelicula, string usuario, DateTime fechaRent, DateTime fechaDev)
        {
            this.pelicula = pelicula;
            this.usuario = usuario;
            this.fechaRent = fechaRent;
            this.fechaDev = fechaDev;
        }

        public string GetPelicula()
        {
            return pelicula;
        }
        public string GetUsuario()
        {
            return usuario;
        }
        public DateTime GetFechaRent()
        {
            return fechaRent;
        }
        public DateTime GetFechaDev()
        {
            return fechaDev;
        }

        public void SetPelicula(string pelicula)
        {
            this.pelicula = pelicula;
        }
        public void SetUsuario(string usuario)
        {
            this.usuario = usuario;
        }
        public void SetFechaRent(DateTime fechaRent)
        {
            this.fechaRent = fechaRent;
        }
        public void SetFechaDev(DateTime fechaDev)
        {
            this.fechaDev = fechaDev;
        }





    }
}
