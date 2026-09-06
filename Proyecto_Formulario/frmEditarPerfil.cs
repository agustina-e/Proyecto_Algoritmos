using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            indiceUsuarioActual = DatosGlobales.usuarios.IndexOf(DatosGlobales.usuarioActual);

            if (indiceUsuarioActual == -1)
            {
                MessageBox.Show("No se pudo identificar al usuario actual.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Precarga de datos actuales
            lblNombreUsuario.Text = DatosGlobales.usuarios[indiceUsuarioActual];
            txtNombre.Text = DatosGlobales.nombres[indiceUsuarioActual];
            txtApellido.Text = DatosGlobales.apellidos[indiceUsuarioActual];
            txtDni.Text = DatosGlobales.dnis[indiceUsuarioActual];
            txtTelefono.Text = DatosGlobales.telefonos[indiceUsuarioActual];
            txtEmail.Text = DatosGlobales.emails[indiceUsuarioActual];
            cboGenero.SelectedItem = DatosGlobales.generos[indiceUsuarioActual];
            cboTipoUsuario.SelectedItem = DatosGlobales.roles[indiceUsuarioActual];

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

            // DNI y tipo de usuario no se tocan: quedan igual que estaban
            DatosGlobales.nombres[indiceUsuarioActual] = nombre;
            DatosGlobales.apellidos[indiceUsuarioActual] = apellido;
            DatosGlobales.telefonos[indiceUsuarioActual] = telefono;
            DatosGlobales.emails[indiceUsuarioActual] = email;
            DatosGlobales.generos[indiceUsuarioActual] = cboGenero.SelectedItem.ToString();

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
