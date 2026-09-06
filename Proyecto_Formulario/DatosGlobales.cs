using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Formulario
{
    public static class DatosGlobales
    {
        public static List<string> usuarios = new List<string> { "admin001", "jperez123" };
        public static List<string> contrasenas = new List<string> { "admin123", "1234" };
        public static List<string> roles = new List<string> { "Administrador", "General" };
        public static List<bool> primerIngreso = new List<bool> { false, true };

        //Datos personales de cada usuario, mismo índice que las listas de arriba
        public static List<string> nombres = new List<string>();
        public static List<string> apellidos = new List<string>();
        public static List<string> dnis = new List<string>();
        public static List<string> telefonos = new List<string>();
        public static List<string> emails = new List<string>();
        public static List<string> generos = new List<string>();

        public static string usuarioActual = "";
        public static string rolActual = "";

        public static List<string> equiposNombre = new List<string>();
        public static List<string> equiposCategoria = new List<string>();
        public static List<int> equiposCantidadJugadores = new List<int>();
        public static List<List<string[]>> equiposJugadores = new List<List<string[]>>();


        static DatosGlobales()
        {
            nombres.Add("Ana"); apellidos.Add("Administrador"); dnis.Add("11111111");
            telefonos.Add("1111111111"); emails.Add("admin@liga.com"); generos.Add("Femenino");

            nombres.Add("Juan"); apellidos.Add("Perez"); dnis.Add("22222222");
            telefonos.Add("2222222222"); emails.Add("jperez@liga.com"); generos.Add("Masculino");
        }
    }
}

