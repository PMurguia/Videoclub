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

        private int rentId;
        private int peliculaId;
        private string usuario;
        private DateTime fechaRent;
        private DateTime fechaDev;

        public Alquiler()
        {

        }

        public Alquiler(int rentId,int peliculaId, string usuario, DateTime fechaRent, DateTime fechaDev)
        {
            this.rentId = rentId;
            this.peliculaId = peliculaId;
            this.usuario = usuario;
            this.fechaRent = fechaRent;
            this.fechaDev = fechaDev;
        }

        public int GetRentId()
        {
            return rentId;
        }
        public int GetPeliculaId()
        {
            return peliculaId;
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

        public void SetRentId(int rentId)
        {
            this.rentId = rentId;
        }
        public void SetPeliculaId(int peliculaId)
        {
            this.peliculaId = peliculaId;
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

        public static void Rent()
        {
            //List<Peliculas> libres = new List<Peliculas>();

            conexion.Open();
            cadena = "SELECT * FROM PELICULAS WHERE ESTADO = 'LIBRE'";
            comando = new SqlCommand(cadena, conexion);
            registros = comando.ExecuteReader();
            while (registros.Read())
            {
                
                Console.WriteLine(registros["MOVIE_ID"].ToString() + " " + registros["TITULO"].ToString() + "\nSinopsis: \n" + registros["SINOPSIS"].ToString());
                Console.WriteLine();
                //Peliculas p = new Peliculas();
                //libres.Add(p);
            }

            conexion.Close();

            Console.WriteLine("¿Qué película desea alquilar? ");
            int option = Int32.Parse(Console.ReadLine());
            

            conexion.Open();
            cadena = "UPDATE PELICULAS SET ESTADO = 'ALQUILADA' WHERE MOVIE_ID = '" + option + "'";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            Console.WriteLine("\nPelícula alquilada. Esperamos que la disfrute. ");
           

        }

    }
}
