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
        public void SetTelephone(int telephone)
        {
            this.telephone = telephone;
        }

        public void Insert()
        {
            conexion.Open();
            cadena = "INSERT INTO CLIENTE VALUES ('" + nombre + "','" + apellido + "','" + fechaNac + "','" + username + "','" + password + "','" + email + "','" + telephone + "')";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}

    
