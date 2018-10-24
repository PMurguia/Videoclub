using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Videoclub
{
    class Program
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["ConexionVIDEOCLUB"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;
        static SqlDataReader registros;

        static void Main(string[] args)
        {
            Menu();     
        }

        public static void Menu()
        {
            const int LOGIN = 1, REGISTER = 2, EXIT = 3;
            int option;
            do
            {
                Console.WriteLine("Elija una opción: ");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Registrarse");
                Console.WriteLine("3. Salir");
                option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case LOGIN:
                        break;

                    case REGISTER:
                        Register();
                        
                        break;
                }
            } while (option != EXIT);
        }
        

        
    }
}
