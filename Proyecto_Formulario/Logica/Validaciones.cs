using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Formulario
{

    public static class Validaciones
    {
        #region Validaciones de entrada

        // Comprobar que el texto contenga solamente letras y espacios
        public static bool SoloLetras(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }
            return true;
        }

        // Comprobar que el texto contenga solamente números
        public static bool SoloNumeros(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        // Comprobar que el correo tenga una estructura válida
        public static bool EmailValido(string email)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return System.Text.RegularExpressions.Regex.IsMatch(email, patron);
        }
        #endregion

    }
}
