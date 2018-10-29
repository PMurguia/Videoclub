using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Videoclub
{
    class Menu
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["ConexionVIDEOCLUB"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;
        static SqlDataReader registros;

        public static void FirstMenu()
        {
            int option=0;
            const int LOGIN = 1, REGISTER = 2, SALIR = 3;
            do
            {
                Console.WriteLine("\t\t\t\t -----Bienvenido al BootClub----- ");
                Console.WriteLine("opciones :\n1. Login\n2. Registrarse\n3. Salir\n");
                try
                {
                option = Int32.Parse(Console.ReadLine());

                }
                catch (SystemException)
                {
                    Console.WriteLine("Opción no reconocida. Por favor, introduza una opción válida. ");

                }

                if (option > 0 && option < 4)
                {
                    switch (option)
                    {
                        case LOGIN:
                            Cliente.Login();
                            break;
                        case REGISTER:
                            Cliente.Register();
                            break;
                        case SALIR:
                            Console.WriteLine("Gracias por visitarnos");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Eso n o es una opción válida.");
                }
            } while (option != SALIR);
        }

    }
}