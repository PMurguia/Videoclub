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
                            Login();
                            break;
                        case REGISTER:
                            Register();
                            break;
                        case SALIR:
                            Console.WriteLine("Gracias por visitarnos");
                            break;
                    }
                }
            } while (option != SALIR);
        }
        public static void Register()
        {
            Console.WriteLine("Bienvenido al registro de nuevo usuario. Por favor, introduce los siguientes datos: ");
            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Apellido: ");
            string apellido = Console.ReadLine();
            Console.WriteLine("Día de nacimiento: ");
            int diaNac = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Mes de nacimiento: ");
            int mesNac = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Año de nacimiento: ");
            int yearNac = Int32.Parse(Console.ReadLine());
            DateTime fechaNac = new DateTime(yearNac, mesNac, diaNac);
            Console.WriteLine("Nombre de usuario: ");
            string username = Console.ReadLine();
            Console.WriteLine("Contraseña: ");
            string password = Console.ReadLine();
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Teléfono: ");
            long telephone =Int32.Parse(Console.ReadLine());

            //Esto es el objeto cliente
            Cliente c = new Cliente(nombre, apellido, fechaNac, username, password, email, telephone);
            c.Insert();
        }
        public static void Login()
        {
            string username, password;

            Console.WriteLine("Introduce el nombre de usuario: ");
            username = Console.ReadLine();
            Console.WriteLine("Introduce la contraseña: ");
            password = Console.ReadLine();

            conexion.Open();
            cadena = "SELECT NOMBRE_USUARIO FROM CLIENTE WHERE nombre_usuario LIKE '" + username + "' AND CONTRASENIA LIKE '" + password + "'";
            comando = new SqlCommand(cadena, conexion);
            registros = comando.ExecuteReader();

            if (!registros.Read())
            {
                Console.WriteLine("Usuario o contraseña incorrectos. Por favor, introduzca una contraseña o nombre de usuario válidos. ");
            }
            else
            {
                Submenu.LoginOptions();
            }
        }
    }
}
