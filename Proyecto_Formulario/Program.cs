using System;
using System.Windows.Forms;

namespace Proyecto_Formulario
{
    internal static class Program
    {
        #region Inicio de la aplicación

        // Conservar la instancia principal del formulario de inicio de sesión
        public static frmLogin LoginPrincipal { get; private set; } = null!;

        // Inicializar la aplicación y abrir el formulario principal
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            LoginPrincipal = new frmLogin();

            Application.Run(LoginPrincipal);
        }

        #endregion

        #region Navegación entre formularios

        // Mostrar un formulario y recuperar el login si no quedan ventanas visibles
        public static void MostrarFormulario(Form formulario)
        {
            formulario.FormClosed += (sender, e) =>
            {
                if (LoginPrincipal.IsDisposed || LoginPrincipal.Visible)
                    return;

                // Comprobar si queda otro formulario visible
                foreach (Form abierto in Application.OpenForms)
                {
                    if (abierto != LoginPrincipal && abierto.Visible)
                        return;
                }

                // Recuperar el login cuando no queden formularios visibles
                VolverAlLogin();
            };

            formulario.Show();
        }

        // Limpiar los datos de sesión y volver al formulario de inicio de sesión
        public static void VolverAlLogin()
        {
            DatosGlobales.usuarioActual = "";
            DatosGlobales.rolActual = "";

            LoginPrincipal.PrepararParaNuevoInicio();
        }
        #endregion

    }
}