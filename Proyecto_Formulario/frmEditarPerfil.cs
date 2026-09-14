using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; 

namespace Proyecto_Formulario
{
    public partial class frmEditarPerfil : Form
    {
        private int indiceUsuarioActual = -1;
        public frmEditarPerfil()
        {
            InitializeComponent();
        }

        private void frmEditarPerfil_Load(object sender, EventArgs e)
        {
            EstiloUI.AplicarBaseFormulario(this);
            EstiloUI.EstilizarTextoDestacado(lblTitulo);
            EstiloUI.EstilizarTextoDestacado(lblNombreUsuario);

            EstiloUI.EstilizarTextBox(txtNombre);
            EstiloUI.EstilizarTextBox(txtApellido);
            EstiloUI.EstilizarTextBox(txtDni);
            EstiloUI.EstilizarTextBox(txtTelefono);
            EstiloUI.EstilizarTextBox(txtEmail);

            EstiloUI.EstilizarBotonPrimario(btnGuardarCambios);
            EstiloUI.EstilizarBotonSecundario(btnCambiarContrasena);
            EstiloUI.EstilizarBotonSecundario(btnVolver);
            EstiloUI.EstilizarLabelError(lblError);

            lblError.Text = "";

            cboGenero.Items.Clear();
            cboGenero.Items.AddRange(new string[] { "Masculino", "Femenino", "Otro" });

            cboTipoUsuario.Items.Clear();
            cboTipoUsuario.Items.AddRange(new string[] { "Administrador", "General" });

            // Precarga de datos desde SQL Server usando usuarioActual
            string query = "SELECT Nombre, Apellido, Dni, Telefono, Email, Genero, Rol FROM Usuarios WHERE Usuario = @Usuario";

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", DatosGlobales.usuarioActual);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblNombreUsuario.Text = DatosGlobales.usuarioActual;
                                txtNombre.Text = reader["Nombre"].ToString();
                                txtApellido.Text = reader["Apellido"].ToString();
                                txtDni.Text = reader["Dni"].ToString();
                                txtTelefono.Text = reader["Telefono"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                                cboGenero.SelectedItem = reader["Genero"].ToString();
                                cboTipoUsuario.SelectedItem = reader["Rol"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo identificar al usuario actual.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el perfil: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // DNI y Tipo de usuario nunca son editables sobre el perfio propio (tabla 4.6 de la consigna)
            txtDni.Enabled = false;
            cboTipoUsuario.Enabled = false;
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(email) ||
                cboGenero.SelectedItem == null)
            {
                lblError.Text = "Debe completar todos los campos obligatorios.";
                return;
            }

            if (!Validaciones.SoloLetras(nombre))
            {
                lblError.Text = "El nombre solo puede contener letras.";
                return;
            }

            if (!Validaciones.SoloLetras(apellido))
            {
                lblError.Text = "El apellido solo puede contener letras.";
                return;
            }

            if (telefono.Length != 10 || !Validaciones.SoloNumeros(telefono))
            {
                lblError.Text = "El teléfono debe contener 10 dígitos numéricos.";
                return;
            }

            if (!Validaciones.EmailValido(email))
            {
                lblError.Text = "Ingrese un email con formato válido.";
                return;
            }

            if (dtpFechaNacimiento.Value.Date > DateTime.Now.Date)
            {
                lblError.Text = "La fecha de nacimiento no puede ser futura.";
                return;
            }

            // Actualización de datos personales en SQL Server
            string genero = cboGenero.SelectedItem.ToString();
            string updateQuery = @"UPDATE Usuarios 
                                 SET Nombre = @Nombre, Apellido = @Apellido, Telefono = @Telefono, Email = @Email, Genero = @Genero 
                                 WHERE Usuario = @Usuario";

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Apellido", apellido);
                        cmd.Parameters.AddWithValue("@Telefono", telefono);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Genero", genero);
                        cmd.Parameters.AddWithValue("@Usuario", DatosGlobales.usuarioActual);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al actualizar en la base de datos: " + ex.Message;
                return;
            }

            MessageBox.Show("Datos actualizados correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            frmRecuperarContrasena frm = new frmRecuperarContrasena();
            frm.Show();
            this.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
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
