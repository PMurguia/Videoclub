using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoclub
{

    class Cliente
    {
        private string nombre;
        private string apellido;
        private DateTime fechaNac;
        private string username;
        private string password;
        private string email;
        private int telephone;

        public Cliente()
        {

        }

        public Cliente(string nombre, string apellido, DateTime fechaNac, string username, string password, string email, int telephone)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNac = fechaNac;
            this.username = username;
            this.password = password;
            this.email = email;
            this.telephone = telephone;

        }

        public void GetNombre()
        {
            return nombre;
        }
        public void GetApellido()
        {
            return apellido;
        }
        public void GetFechaNac()
        {
            return fechaNac;
        }
        public void GetUsername()
        {
            return username;
        }
        public void GetPassword()
        {
            return password;
        }
        public void GetEmail()
        {
            return email;
        }
        public void GetTelephone()
        {
            return telephone;
        }

        public string SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public string SetApellido(string apellido)
        {
            this.apellido = apellido;
        }
        public DateTime SetFechaNac(DateTime fechaNac)
        {
            this.fechaNac = fechaNac;
        }
        public string SetUsername(string username)
        {
            this.username = username;
        }
        public string SetPassword(string password)
        {
            this.password = password;
        }
        public string SetEmail(string email)
        {
            this.email = email;
        }
        public int telephone(int telephone)
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
            DateTime newDateTime = new DateTime(yearNac, mesNac, diaNac);
            Console.WriteLine("Nombre de usuario: ");
            string username = Console.ReadLine();
            Console.WriteLine("Contraseña: ");
            string password = Console.ReadLine();
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Teléfono: ");
            long telephone = Int64.Parse(Console.ReadLine());

            Cliente c1 = new Cliente(nombre, apellido, newDateTime, username, password, email, telephone);
            conexion.Open();

            cadena = "INSERT INTO CLIENTE VALUES ('" + nombre + "','" + apellido + "','" + newDateTime + "','" + username + "','" + password + "','" + email + "','" + telephone + "')";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            registros.Close();
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
            cadena = "SELECT DNI FROM CLIENTES WHERE nombre_usuario LIKE '" + username + "' AND PASSWORD LIKE '" + password + "'";
            comando = new SqlCommand(cadena, conexion);
            registros = comando.ExecuteReader();

            if (!registros.Read())
            {
                Console.WriteLine("Usuario o contraseña incorrectos. Por favor, introduzca una contraseña o nombre de usuario válidos. ");
            }
         
            }
        }
       

        //public bool ComprobarUsername(string username)
        //{
        //    conexion.Open();
        //    cadena = "SELECT NOMBRE_USUARIO FROM CLIENTE";
        //    comando = new SqlCommand(cadena, conexion);
        //    registros = comando.ExecuteReader();
        //    while (registros.Read())
        //    {

        //        if (!registros.Read())
        //        {
        //            return true;
        //            registros.Close();
        //            conexion.Close();
        //        }
        //        else
        //        {
        //            return false;
        //            registros.Close();
        //            conexion.Close();
        //        }
        //    }
        //}

    }
}
