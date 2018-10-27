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
            int option;
            const int LOGIN = 1, REGISTER = 2, SALIR = 3;
            do
            {
                Console.WriteLine("opciones :\n1. Login\n2. Registrarse\n3. Salir\n");
                option = Int32.Parse(Console.ReadLine());
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
            } while (option != SALIR);
        }
      
        public static int Edad(string username)
        {
            
            conexion.Open();
            cadena = "SELECT FECHA_NACIMIENTO FROM CLIENTE WHERE USERNAME = '" + username + "'";
            comando = new SqlCommand(cadena, conexion);
            registros = comando.ExecuteReader();
        }

    
    }
}
