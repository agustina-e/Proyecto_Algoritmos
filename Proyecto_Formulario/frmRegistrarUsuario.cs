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
    public partial class frmRegistrarUsuario : Form
    {
        public frmRegistrarUsuario()
        {
            InitializeComponent();
        }

        private void cboGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmRegistrarUsuario_Load(object sender, EventArgs e)
        {
            EstiloUI.AplicarBaseFormulario(this);

            EstiloUI.EstilizarTextBox(txtNombre);
            EstiloUI.EstilizarTextBox(txtApellido);
            EstiloUI.EstilizarTextBox(txtDni);
            EstiloUI.EstilizarTextBox(txtTelefono);
            EstiloUI.EstilizarTextBox(txtEmail);

            EstiloUI.EstilizarBotonPrimario(btnRegistrar);
            EstiloUI.EstilizarBotonSecundario(btnVolver);
            EstiloUI.EstilizarLabelError(lblError);

            cboGenero.Items.Clear();
            cboGenero.Items.AddRange(new string[] { "Masculino", "Femenino", "Otro" });

            cboTipoUsuario.Items.Clear();
            cboTipoUsuario.Items.AddRange(new string[] { "Administrador", "General" });

            lblError.Text = "";
        }

        private string GenerarNombreUsuario(string nombre, string apellido, string dni)
        {
            string inicial = nombre.Substring(0, 1).ToLower();
            string apellidoMinuscula = apellido.ToLower().Replace(" ", "");
            string ultimosTresDni = dni.Substring(dni.Length - 3);

            string usuarioBase = inicial + apellidoMinuscula + ultimosTresDni;
            string usuarioFinal = usuarioBase;

            int sufijo = 2;
            while (DatosGlobales.usuarios.Contains(usuarioFinal))
            {
                usuarioFinal = usuarioBase + "_" + sufijo;
                sufijo++;
            }

            return usuarioFinal;
        }

        private string GenerarContrasenaAleatoria()
        {
            const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] contrasena = new char[10];

            for (int i = 0; i < contrasena.Length; i++)
            {
                int indiceAleatorio = random.Next(caracteresPermitidos.Length);
                contrasena[i] = caracteresPermitidos[indiceAleatorio];
            }

            return new string(contrasena);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string dni = txtDni.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Campos obligatorios
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(telefono) ||
                string.IsNullOrEmpty(email) || cboGenero.SelectedItem == null ||
                cboTipoUsuario.SelectedItem == null)
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

            if (dni.Length != 8 || !Validaciones.SoloNumeros(dni))
            {
                lblError.Text = "El DNI debe contener 8 dígitos numéricos.";
                return;
            }

            if (DatosGlobales.dnis.Contains(dni))
            {
                lblError.Text = "Ya existe un usuario registrado con ese DNI.";
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

            // Todo válido: generamos usuario y contraseña
            string nuevoUsuario = GenerarNombreUsuario(nombre, apellido, dni);
            string nuevaContrasena = GenerarContrasenaAleatoria();
            string tipoUsuario = cboTipoUsuario.SelectedItem.ToString();

            DatosGlobales.usuarios.Add(nuevoUsuario);
            DatosGlobales.contrasenas.Add(nuevaContrasena);
            DatosGlobales.roles.Add(tipoUsuario);
            DatosGlobales.primerIngreso.Add(true);
            DatosGlobales.nombres.Add(nombre);
            DatosGlobales.apellidos.Add(apellido);
            DatosGlobales.dnis.Add(dni);
            DatosGlobales.telefonos.Add(telefono);
            DatosGlobales.emails.Add(email);
            DatosGlobales.generos.Add(cboGenero.SelectedItem.ToString());

            MessageBox.Show(
                "Se enviaron las credenciales al email " + email + ":\n\n" +
                "Usuario: " + nuevoUsuario + "\n" +
                "Contraseña: " + nuevaContrasena,
                "Simulación de envío de email",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            MessageBox.Show(
                "Usuario \"" + nuevoUsuario + "\" registrado correctamente.",
                "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            cboGenero.SelectedIndex = -1;
            cboTipoUsuario.SelectedIndex = -1;
            dtpFechaNacimiento.Value = DateTime.Now;
            lblError.Text = "";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPrincipalAdmin frm = new frmPrincipalAdmin();
            frm.Show();
            this.Close();
        }
    }
}
