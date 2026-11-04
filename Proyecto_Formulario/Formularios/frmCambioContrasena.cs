using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proyecto_Formulario
{
    public partial class frmCambioContrasena : Form
    {
        #region Estado del cambio de contraseña

        private bool cambioCompletado = false;

        #endregion

        #region Inicialización del formulario

        // Inicializar los controles del formulario
        public frmCambioContrasena()
        {
            InitializeComponent();
        }

        #endregion

        #region Validación y actualización de contraseña

        // Validar los datos y guardar la nueva contraseña
        private void btnConfirmar_Click_1(object? sender, EventArgs e)
        {
            lblError.Text = "";

            string nueva = txtNuevaContrasena.Text;
            string confirmar = txtConfirmarContrasena.Text;

            if (string.IsNullOrWhiteSpace(nueva) ||
                string.IsNullOrWhiteSpace(confirmar))
            {
                lblError.Text = "Debe completar ambos campos.";
                return;
            }

            if (nueva.Length < 8)
            {
                lblError.Text = "La contraseña debe tener al menos 8 caracteres.";
                return;
            }

            if (nueva.Length > 100)
            {
                lblError.Text = "La contraseña no puede superar los 50 caracteres.";
                return;
            }

            if (nueva != confirmar)
            {
                lblError.Text = "Las contraseñas no coinciden.";
                return;
            }

            string updateQuery = @"
                UPDATE Usuarios
                SET Contrasena = @Contrasena, PrimerIngreso = 0
                WHERE Usuario = @Usuario";

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Contrasena", nueva);
                        cmd.Parameters.AddWithValue("@Usuario", DatosGlobales.usuarioActual);

                        int filas = cmd.ExecuteNonQuery();

                        if (filas == 0)
                        {
                            lblError.Text = "No se pudo actualizar la contraseña.";
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {
                lblError.Text = "No se pudo actualizar la contraseña. Intente nuevamente.";
                return;
            }

            cambioCompletado = true;

            MessageBox.Show(
                "Contraseña actualizada correctamente.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            if (DatosGlobales.rolActual == "Administrador")
            {
                frmPrincipalAdmin frm = new frmPrincipalAdmin();
                Program.MostrarFormulario(frm);
            }
            else
            {
                frmPrincipalGeneral frm = new frmPrincipalGeneral();
                Program.MostrarFormulario(frm);
            }

            this.Close();
        }

        #endregion

        #region Configuración del formulario

        // Configurar los estilos y límites de los campos
        private void frmCambioContrasena_Load(object? sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            txtNuevaContrasena.MaxLength = 100;
            txtConfirmarContrasena.MaxLength = 100;

            EstiloUI.AplicarBaseFormulario(this);
            EstiloUI.EstilizarTextoDestacado(lblInfo);
            EstiloUI.EstilizarEtiqueta(lblNueva);
            EstiloUI.EstilizarEtiqueta(lblConfirmar);
            EstiloUI.EstilizarTextBox(txtNuevaContrasena);
            EstiloUI.EstilizarTextBox(txtConfirmarContrasena);
            EstiloUI.EstilizarBotonPrimario(btnConfirmar);
            EstiloUI.EstilizarLabelError(lblError);
        }

        #endregion

        #region Control del cierre

        // Impedir el cierre hasta completar el cambio obligatorio
        private void frmCambioContrasena_FormClosing(
            object? sender,
            FormClosingEventArgs e)
        {
            if (!cambioCompletado)
            {
                e.Cancel = true;

                MessageBox.Show(
                    "Debe cambiar su contraseña para poder continuar.",
                    "Cambio obligatorio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        #endregion

    }
}