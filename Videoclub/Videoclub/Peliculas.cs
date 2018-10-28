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

        private int movieId;
        private string titulo;
        private string director;
        private int publico;
        private string sinopsis;
        private string alquilada;

       

        public Peliculas()
        {
        }

        public Peliculas(int movieId,string titulo, string director, int publico, string sinopsis, string alquilada)
        {
            this.movieId = movieId;
            this.titulo=titulo;
            this.director = director;
            this.publico = publico;
            this.sinopsis = sinopsis;
            this.alquilada = alquilada;
        }

        public int GetmovieId()
        {
            return movieId;
        }
        public string GetTitulo()
        {
            return titulo;
        }
        public string GerDirector()
        {
            return director;
        }
        public int GetPublico()
        {
            return publico;
        }
        public string GetSinopsis()
        {
            return sinopsis;
        }
        public string GetAlquilada()
        {
            return alquilada;
        }

        public void SetMovieId(int movieId)
        {
            this.movieId = movieId;
        }
        public void SetTitulo(string titulo)
        {
            this.titulo = titulo;
        }
        public void SetDirector(string director)
        {
            this.director = director;
        }
        public void SetPublico(int publico)
        {
            this.publico = publico;
        }
        public void SetSinopsis(string sinopsis)
        {
            this.sinopsis = sinopsis;
        }
        public void SetAlquilada(string alquilada)
        {
            this.alquilada = alquilada;
        }



    }
}
