using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Formulario
{

    public static class Validaciones
    {
        public static bool SoloLetras(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }
            return true;
        }

        public static bool SoloNumeros(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public static bool EmailValido(string email)
        {
            if (!email.Contains("@")) return false;

            int posicionArroba = email.IndexOf("@");
            string parteAntes = email.Substring(0, posicionArroba);
            string parteDespues = email.Substring(posicionArroba + 1);

            if (string.IsNullOrEmpty(parteAntes)) return false;
            if (!parteDespues.Contains(".")) return false;
            if (parteDespues.StartsWith(".") || parteDespues.EndsWith(".")) return false;

            return true;
        }
    }
}
