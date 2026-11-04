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
        #region Inicialización y carga del perfil

        // Inicializar los controles del formulario
        public frmEditarPerfil()
        {
            InitializeComponent();
        }

        // Configurar la interfaz y cargar los datos del usuario actual
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

            // Precargar los datos del usuario actual desde SQL Server
            string query = "SELECT Nombre, Apellido, Dni, Telefono, Email, Genero, Rol, FechaNacimiento FROM Usuarios WHERE Usuario = @Usuario";

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
                                if (reader["FechaNacimiento"] != DBNull.Value)
                                {
                                    dtpFechaNacimiento.Value = Convert.ToDateTime(reader["FechaNacimiento"]);
                                }
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

            // Mantener el DNI y el tipo de usuario sin posibilidad de edición según la consigna
            txtDni.Enabled = false;
            cboTipoUsuario.Enabled = false;
        }

        #endregion

        #region Validación y guardado de cambios

        // Validar y actualizar los datos personales del usuario
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

            // Actualizar los datos personales del usuario en SQL Server
            string genero = cboGenero.SelectedItem?.ToString() ?? string.Empty;
            string updateQuery = @"UPDATE Usuarios 
                                 SET Nombre = @Nombre, Apellido = @Apellido, Telefono = @Telefono, Email = @Email, Genero = @Genero, FechaNacimiento = @FechaNacimiento
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
                        cmd.Parameters.AddWithValue("@FechaNacimiento", dtpFechaNacimiento.Value.Date);

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

        #endregion

        #region Navegación del perfil

        // Abrir el proceso de recuperación de contraseña
        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            frmRecuperarContrasena frm = new frmRecuperarContrasena(this);

            Program.MostrarFormulario(frm);

            this.Hide();
        }

        // Volver al panel correspondiente según el rol del usuario
        private void btnVolver_Click(object sender, EventArgs e)
        {
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

    }
}
