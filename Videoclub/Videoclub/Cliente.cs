using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Videoclub
{

    class Cliente
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["ConexionVIDEOCLUB"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;
        static SqlDataReader registros;

        private string nombre;
        private string apellido;
        private DateTime fechaNac;
        private string username;
        private string password;
        private string email;
        private long telephone;

        public Cliente()
        {
        }
        public Cliente(string nombre, string apellido, DateTime fechaNac, string username, string password, string email, long telephone)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNac = fechaNac;
            this.username = username;
            this.password = password;
            this.email = email;
            this.telephone = telephone;

        }
        public string GetNombre()
        {
            return nombre;
        }
        public string GetApellido()
        {
            return apellido;
        }
        public DateTime GetFechaNac()
        {
            return fechaNac;
        }
        public string GetUsername()
        {
            return username;
        }
        public string GetPassword()
        {
            return password;
        }
        public string GetEmail()
        {
            return email;
        }
        public long GetTelephone()
        {
            return telephone;
        }

        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public void SetApellido(string apellido)
        {
            this.apellido = apellido;
        }
        public void SetFechaNac(DateTime fechaNac)
        {
            this.fechaNac = fechaNac;
        }
        public void SetUsername(string username)
        {
            this.username = username;
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }
        public void SetTelephone(long telephone)
        {
            this.telephone = telephone;
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
            long telephone = Int32.Parse(Console.ReadLine());

            //Esto es el objeto cliente
            Cliente c = new Cliente(nombre, apellido, fechaNac, username, password, email, telephone);
            c.Insert();
            


        }

        public void Insert()
        {
            conexion.Open();
            cadena = "INSERT INTO CLIENTE VALUES ('" + nombre + "','" + apellido + "','" + fechaNac + "','" + username + "','" + password + "','" + email + "','" + telephone + "')";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();

        }

        public static void Login()
        {
            
            string username, password;

            Console.WriteLine("Introduce el nombre de usuario: ");
            username = Console.ReadLine();
            Console.WriteLine("Introduce la contraseña: ");
            password = Console.ReadLine();

            conexion.Open();
            cadena = "SELECT * FROM CLIENTE WHERE nombre_usuario LIKE '" + username + "' AND CONTRASENIA LIKE '" + password + "'";
            comando = new SqlCommand(cadena, conexion);
            registros = comando.ExecuteReader();

            if (!registros.Read())
            {
                Console.WriteLine("Usuario o contraseña incorrectos. Por favor, introduzca una contraseña o nombre de usuario válidos. ");
            }
            else
            {
                Cliente c = new Cliente();
                Submenu.LoginOptions();
            }
        }

        public int Edad()
        {

            int years;
            DateTime bDate = fechaNac;
            DateTime today = DateTime.Now;
            TimeSpan dAlive = today - bDate;
            return years = dAlive.Days / 365;
        }
    }
}

    
