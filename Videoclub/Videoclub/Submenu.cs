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

        public static void LoginOptions()
        {
            conexion.Close();

            int option;
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
                            Catalog();
                            break;
                    }
                }
            } while (option != LOGOUT);

        }

        public static void Catalog()
        {
            conexion.Open();
            cadena = "SELECT * FROM PELICULAS";
            comando = new SqlCommand(cadena, conexion);
            registros = comando.ExecuteReader();
            while(registros.Read())
            {
            Console.WriteLine(registros["NOMBRE"].ToString() + registros["DIRECTOR"].ToString());
            } 
        }



    }
}
