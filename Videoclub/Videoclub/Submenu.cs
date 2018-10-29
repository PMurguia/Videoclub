using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Videoclub
{
    class Submenu
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["ConexionVIDEOCLUB"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;
        static SqlDataReader registros;

        public static void LoginOptions(Cliente cliente)
        {
            conexion.Close();

            int option;
            cliente.Edad();
            const int CATALOG = 1, RENT = 2, MYRENTINGS = 3, LOGOUT = 4;

            do
            {
                Console.WriteLine("¿Qué desea hacer?\n1. Ver películas disponibles\n2. Alquilar una película\n3. Mis alquileres\n4. Logout");
                option = Int32.Parse(Console.ReadLine());

                if (option > 0 && option < 5)
                {
                    switch (option)
                    {
                        case CATALOG:
                            Catalog(cliente);
                            break;

                        case RENT:
                            Alquiler.Rent(cliente);
                            break;

                        case MYRENTINGS:
                            Alquiler.MyRentings(cliente);
                            break;

                        case LOGOUT:
                            Console.WriteLine("Hasta la próxima.");
                            break;
                    }
                }
            } while (option != LOGOUT);
        }

        public static void Catalog(Cliente cliente)
        {

            conexion.Open();


            cadena = "SELECT * FROM PELICULAS WHERE PUBLICO <= '" + cliente.Edad() + "'";
            comando = new SqlCommand(cadena, conexion);
            registros = comando.ExecuteReader();
            Console.WriteLine("----Película----");
            Console.WriteLine();
            while (registros.Read())
            {
                if (registros["ESTADO"].ToString() == "ALQUILADA")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(registros["MOVIE_ID"].ToString() + "\t" + registros["TITULO"].ToString());
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(registros["MOVIE_ID"].ToString() + "\t" + registros["TITULO"].ToString());
                }
           
            }
            conexion.Close();
            Console.WriteLine();
        }



    }
}
