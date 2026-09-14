using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proyecto_Formulario
{
    public partial class frmCambioContrasena : Form
    {
        private bool cambioCompletado = false;

        public frmCambioContrasena()
        {
            InitializeComponent();

            // Evitar ejecutar lógica de runtime en el diseñador
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                btnConfirmar.Click += BtnConfirmar_Click;
                this.FormClosing += frmCambioContrasena_FormClosing;
                this.Load += frmCambioContrasena_Load;
            }
        }

        private void BtnConfirmar_Click(object? sender, EventArgs e)
        {
            // Usar controles creados por el diseñador: textBox1 y txtConfirmarContrasena
            if (string.IsNullOrWhiteSpace(txtNuevaContrasena.Text))
            {
                lblError.Text = "Ingrese la nueva contraseña.";
                return;
            }
            if (txtNuevaContrasena.Text != txtConfirmarContrasena.Text)
            {
                lblError.Text = "Las contraseñas no coinciden.";
                return;
            }

            string updateQuery = "UPDATE Usuarios SET Contrasena = @Contrasena, PrimerIngreso = 0 WHERE Usuario = @Usuario";
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Contrasena", txtNuevaContrasena.Text);
                        cmd.Parameters.AddWithValue("@Usuario", DatosGlobales.usuarioActual);
                        int filas = cmd.ExecuteNonQuery();
                        if (filas == 0)
                        {
                            lblError.Text = "Usuario no encontrado.";
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error en la base de datos: " + ex.Message;
                return;
            }

            cambioCompletado = true;

            // Redirigir
           
            if (DatosGlobales.rolActual == "Administrador")
                new frmPrincipalAdmin().Show();
            else
                new frmPrincipalGeneral().Show();

            this.Close();
        }

        private void frmCambioContrasena_Load(object? sender, EventArgs e)
        {
            // Inicialización si hace falta
            lblError.Text = string.Empty;

            EstiloUI.AplicarBaseFormulario(this);
            EstiloUI.EstilizarTextoDestacado(lblInfo);
            EstiloUI.EstilizarEtiqueta(lblNueva);
            EstiloUI.EstilizarEtiqueta(lblConfirmar);
            EstiloUI.EstilizarTextBox(txtNuevaContrasena);
            EstiloUI.EstilizarTextBox(txtConfirmarContrasena);
            EstiloUI.EstilizarBotonPrimario(btnConfirmar);
            EstiloUI.EstilizarLabelError(lblError);

            lblError.Text = string.Empty;
        }

        private void frmCambioContrasena_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime && !cambioCompletado)
            {
                var res = MessageBox.Show("Aún no completaste el cambio de contraseña. ¿Desea salir?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            lblError.Text = "";

            string nueva = txtNuevaContrasena.Text;
            string confirmar = txtConfirmarContrasena.Text;

            // Validación de campos completos
            if (string.IsNullOrEmpty(nueva) || string.IsNullOrEmpty(confirmar))
            {
                lblError.Text = "Debe completar ambos campos.";
                return;
            }

            // Validación de largo mínimo
            if (nueva.Length < 8)
            {
                lblError.Text = "La contraseña debe tener al menos 8 caracteres.";
                return;
            }

            // Validación de coincidencia
            if (nueva != confirmar)
            {
                lblError.Text = "Las contraseñas no coinciden.";
                return;
            }

            string updateQuery = "UPDATE Usuarios SET Contrasena = @Contrasena, PrimerIngreso = 0 WHERE Usuario = @Usuario";
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Contrasena", nueva);
                        cmd.Parameters.AddWithValue("@Usuario", DatosGlobales.usuarioActual);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al actualizar la contraseña: " + ex.Message;
                return;
            }

            MessageBox.Show("Contraseña actualizada correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            cambioCompletado = true; // ahora sí se puede cerrar este formulario

            // Redirección según el rol
            if (DatosGlobales.rolActual == "Administrador")
            {
                frmPrincipalAdmin frm = new frmPrincipalAdmin();
                frm.Show();
            }
            else
            {
                frmPrincipalGeneral frm = new frmPrincipalGeneral();
                frm.Show();
            }

            this.Close();
        }
    }
}
