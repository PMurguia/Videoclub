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
        private DateTime fechaExpiring;
        private string movTitle;

        public Alquiler()
        {

        }

        public Alquiler(int rentId, int peliculaId, string usuario, DateTime fechaRent, DateTime fechaDev, DateTime fechaExpiring, string movTitle)
        {
            this.rentId = rentId;
            this.peliculaId = peliculaId;
            this.usuario = usuario;
            this.fechaRent = fechaRent;
            this.fechaDev = fechaDev;
            this.fechaExpiring = fechaExpiring;
            this.movTitle = movTitle;
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
        public DateTime GetFechaExpiring()
        {
            return fechaExpiring;
        }
        public string GetMovTitle()
        {
            return movTitle;
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
        public void SetFechaExpiring(DateTime fechaExpiring)
        {
            this.fechaExpiring = fechaExpiring;
        }
        public void SetMovTitle(string movTitle)
        {
            this.movTitle = movTitle;
        }

        public static void Rent(Cliente cliente)
        {

            conexion.Open();
            cadena = "SELECT * FROM PELICULAS WHERE PUBLICO <= '" + cliente.Edad() + "' AND ESTADO = 'LIBRE'";
            comando = new SqlCommand(cadena, conexion);
            registros = comando.ExecuteReader();
            while (registros.Read())
            {
                if (registros["ESTADO"].ToString() == "LIBRE")
                {

                    Console.WriteLine(registros["MOVIE_ID"].ToString() + " " + registros["TITULO"].ToString() + "\nSinopsis: \n" + registros["SINOPSIS"].ToString());
                    Console.WriteLine();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(registros["MOVIE_ID"].ToString() + " " + registros["TITULO"].ToString() + "\nSinopsis: \n" + registros["SINOPSIS"].ToString());
                    Console.WriteLine();
                    Console.ResetColor();

                }
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

            conexion.Open();

            Peliculas pelicula = new Peliculas();
            cadena = "SELECT * FROM PELICULAS WHERE MOVIE_ID = '" + option + "'";
            comando = new SqlCommand(cadena, conexion);
            registros = comando.ExecuteReader();
            if (registros.Read())
            {
                pelicula.SetMovieId(option);
                pelicula.SetTitulo(registros["TITULO"].ToString());
                pelicula.SetDirector(registros["DIRECTOR"].ToString());
                pelicula.SetPublico(Int32.Parse(registros["PUBLICO"].ToString()));
                pelicula.SetSinopsis(registros["SINOPSIS"].ToString());
                pelicula.SetAlquilada(registros["ESTADO"].ToString());

            }
            conexion.Close();

            conexion.Open();
            cadena = "INSERT INTO ALQUILERES (MOV_ID, USUARIO, RENT_DATE, RENT_EXPIRING,MOV_TITLE) VALUES ('" + pelicula.GetmovieId() + "','" + cliente.GetUsername() + "','" + DateTime.Now + "','" + DateTime.Now.AddDays(1) + "','" + pelicula.GetTitulo() + "')";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();

        }

        public static void MyRentings(Cliente cliente)
        {
            Alquiler alquiler = new Alquiler();
            List<Alquiler> rent = new List<Alquiler>();
            conexion.Open();
            cadena = "SELECT MOV_TITLE,RENT_DATE,RENT_DEV,RENT_EXPIRING FROM ALQUILERES WHERE USUARIO = '" + cliente.GetUsername() + "' AND RENT_DEV LIKE 'NULL'";
            comando = new SqlCommand(cadena, conexion);
            registros = comando.ExecuteReader();
            Console.WriteLine("Información para el usuario: los alquileres en rojo son aquellos que tienen vencida la fecha de devoución de la película. Por favor, devuélvala a la mayor brevedad.");
            while (registros.Read())
            {
                alquiler.SetPeliculaId(Int32.Parse(registros["MOV_ID"].ToString()));
                alquiler.SetMovTitle(registros["MOV_TITLE"].ToString());
                alquiler.SetFechaRent(DateTime.Parse(registros["RENT_DATE"].ToString()));
                alquiler.SetFechaExpiring(DateTime.Parse(registros["DATE_EXPIRING"].ToString()));
                alquiler.SetFechaDev(DateTime.Parse(registros["DATE_DEV"].ToString()));
                rent.Add(alquiler);
                if (alquiler.fechaExpiring < DateTime.Now)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(registros["MOV_ID"].ToString() + " " + registros["MOV_TITLE"].ToString() + " " + registros["RENT_DATE"].ToString() + " " + registros["DATE_EXPIRING"].ToString());
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(registros["MOV_ID"].ToString() + " " + registros["MOV_TITLE"].ToString() + " " + registros["RENT_DATE"].ToString() + " " + registros["DATE_EXPIRING"].ToString());
                }
            }
            conexion.Close();

            int option = 0;
            const int DEVOLUTION = 1, AUMENT = 2, EXIT = 3;
            do
            {

                Console.WriteLine("\n¿Desea realizar alguna operación?\n1. Devolver película\n2. Aumentar alquiler\n3. Salir. ");
                option = Int32.Parse(Console.ReadLine());
                switch (option)
                {
                    case DEVOLUTION:
                        Devolution();
                        break;

                    case AUMENT:
                        Console.WriteLine("¿A qué película quiere aumentarle el tiempo de alquiler?");
                        int pelicula = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("¿Cuántos días quiere aumentar el alquiler de la película?");
                        int days = Int32.Parse(Console.ReadLine());

                        conexion.Open();
                        cadena = "UPDATE ALQUILERES SET RENT_EXPIRING = '" + alquiler.GetFechaExpiring().AddDays(days) + "' WHERE MOV_ID = '" + pelicula + "'";
                        comando = new SqlCommand(cadena, conexion);
                        comando.ExecuteNonQuery();
                        conexion.Close();

                        Console.WriteLine("Cambio introducido correctamente. ¿Qué desea hacer ahora? ");
                        break;

                }
            } while (option != EXIT);
        }

        public static void Devolution()
        {
            Console.WriteLine("¿Qué película desea devolver? ");
            int idPelicula = Int32.Parse(Console.ReadLine());
            conexion.Open();
            cadena = "INSERT INTO ALQUILERES (DATE_DEV) VALUES ('" + DateTime.Now + "') WHERE MOV_ID = '" + idPelicula + "'";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();

            conexion.Open();
            cadena = "UPDATE PELICULAS SET ESTADO = 'LIBRE' WHERE MOVIE_ID = '" + idPelicula + "'";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public static void PeliculaADevolver()
        {

        }
    }
}
