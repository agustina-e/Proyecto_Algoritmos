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
    public partial class frmPrincipalGeneral : Form
    {
        public frmPrincipalGeneral()
        {
            InitializeComponent();
        }

        private void frmPrincipalGeneral_Load(object sender, EventArgs e)
        {
            EstiloUI.AplicarBaseFormulario(this);
            EstiloUI.EstilizarTextoDestacado(lblBienvenida);
            EstiloUI.EstilizarBotonSecundario(btnCerrarSesion);
            EstiloUI.EstilizarBotonSecundario(btnEditarPerfil);

            EstiloUI.EstilizarEtiqueta(lblNombreEquipo);
            EstiloUI.EstilizarEtiqueta(lblCategoria);
            EstiloUI.EstilizarEtiqueta(lblCantidadJugadores);
            EstiloUI.EstilizarTextBox(txtNombreEquipo);
            EstiloUI.EstilizarBotonPrimario(btnInscribirme);
            EstiloUI.EstilizarBotonPrimario(btnGuardarEquipo);
            EstiloUI.EstilizarGrilla(dgvJugadores);
            EstiloUI.EstilizarLabelError(lblEstado);

            lblBienvenida.Text = "¡Hola, " + DatosGlobales.usuarioActual + "!";
            lblEstado.Text = "";

            // Cargamos categorías (fijas, de prueba)
            cboCategoria.Items.Clear();
            cboCategoria.Items.AddRange(new string[] { "Sub-15", "Sub-17", "Libre" });

            // Cargamos cantidades permitidas de jugadores
            cboCantidadJugadores.Items.Clear();
            cboCantidadJugadores.Items.AddRange(new string[] { "5", "7", "9", "11" });

            // Configuramos las columnas de la grilla una sola vez
            dgvJugadores.Columns.Clear();
            dgvJugadores.Columns.Add("colNombre", "Nombre");
            dgvJugadores.Columns.Add("colApellido", "Apellido");
            dgvJugadores.Columns.Add("colEdad", "Edad");
            dgvJugadores.Columns.Add("colDni", "DNI");

            dgvJugadores.Enabled = false; // se habilita recién al hacer clic en "Inscribirme"
            btnGuardarEquipo.Enabled = false;
        }

        private void btnInscribirme_Click(object sender, EventArgs e)
        {
            lblEstado.Text = "";

            // Validaciones antes de habilitar la carga de jugadores
            if (string.IsNullOrWhiteSpace(txtNombreEquipo.Text))
            {
                lblEstado.Text = "Debe ingresar el nombre del equipo.";
                return;
            }

            if (cboCategoria.SelectedItem == null)
            {
                lblEstado.Text = "Debe seleccionar una categoría.";
                return;
            }

            if (cboCantidadJugadores.SelectedItem == null)
            {
                lblEstado.Text = "Debe seleccionar la cantidad de jugadores.";
                return;
            }

            int cantidad = int.Parse(cboCantidadJugadores.SelectedItem.ToString());

            // Limpiamos la grilla por si ya se había inscripto antes en esta sesión
            dgvJugadores.Rows.Clear();
            dgvJugadores.Rows.Add(cantidad);

            dgvJugadores.Enabled = true;
            btnGuardarEquipo.Enabled = true;

            // Bloqueamos los datos del torneo para que no cambien mientras carga jugadores
            txtNombreEquipo.Enabled = false;
            cboCategoria.Enabled = false;
            cboCantidadJugadores.Enabled = false;
            btnInscribirme.Enabled = false;

            lblEstado.Text = "Cargá los datos de cada jugador y presioná \"Guardar equipo\".";
        }

        private void btnGuardarEquipo_Click(object sender, EventArgs e)
        {
            lblEstado.Text = "";

            List<string[]> jugadoresValidados = new List<string[]>();
            List<string> dnisEnEsteEquipo = new List<string>();

            for (int i = 0; i < dgvJugadores.Rows.Count; i++)
            {
                DataGridViewRow fila = dgvJugadores.Rows[i];

                string nombre = fila.Cells["colNombre"].Value?.ToString().Trim() ?? "";
                string apellido = fila.Cells["colApellido"].Value?.ToString().Trim() ?? "";
                string edadTexto = fila.Cells["colEdad"].Value?.ToString().Trim() ?? "";
                string dni = fila.Cells["colDni"].Value?.ToString().Trim() ?? "";

                int numeroFila = i + 1;

                // Campos obligatorios
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                    string.IsNullOrEmpty(edadTexto) || string.IsNullOrEmpty(dni))
                {
                    lblEstado.Text = "Fila " + numeroFila + ": debe completar todos los campos.";
                    return;
                }

                // Nombre y apellido: solo letras y espacios
                if (!Validaciones.SoloLetras(nombre))
                {
                    lblEstado.Text = "Fila " + numeroFila + ": el nombre solo puede contener letras.";
                    return;
                }

                if (!Validaciones.SoloLetras(apellido))
                {
                    lblEstado.Text = "Fila " + numeroFila + ": el apellido solo puede contener letras.";
                    return;
                }

                // Edad: numérica y dentro de un rango razonable
                int edad;
                if (!int.TryParse(edadTexto, out edad) || edad < 5 || edad > 60)
                {
                    lblEstado.Text = "Fila " + numeroFila + ": la edad debe ser un número entre 5 y 60.";
                    return;
                }

                // DNI: exactamente 8 dígitos numéricos
                if (dni.Length != 8 || !Validaciones.SoloNumeros(dni))
                {
                    lblEstado.Text = "Fila " + numeroFila + ": el DNI debe tener 8 dígitos numéricos.";
                    return;
                }

                // DNI único dentro del propio equipo
                if (dnisEnEsteEquipo.Contains(dni))
                {
                    lblEstado.Text = "Fila " + numeroFila + ": hay un DNI repetido en el equipo.";
                    return;
                }

                dnisEnEsteEquipo.Add(dni);
                jugadoresValidados.Add(new string[] { nombre, apellido, edad.ToString(), dni });
            }

            // Si llegamos hasta acá, todas las filas son válidas: guardamos el equipo
            DatosGlobales.equiposNombre.Add(txtNombreEquipo.Text.Trim());
            DatosGlobales.equiposCategoria.Add(cboCategoria.SelectedItem.ToString());
            DatosGlobales.equiposCantidadJugadores.Add(jugadoresValidados.Count);
            DatosGlobales.equiposJugadores.Add(jugadoresValidados);

            MessageBox.Show("Equipo \"" + txtNombreEquipo.Text.Trim() + "\" registrado correctamente con " +
                jugadoresValidados.Count + " jugadores.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            ReiniciarFormulario();
        }

        private void ReiniciarFormulario()
        {
            txtNombreEquipo.Text = "";
            txtNombreEquipo.Enabled = true;

            cboCategoria.SelectedIndex = -1;
            cboCategoria.Enabled = true;

            cboCantidadJugadores.SelectedIndex = -1;
            cboCantidadJugadores.Enabled = true;

            btnInscribirme.Enabled = true;

            dgvJugadores.Rows.Clear();
            dgvJugadores.Enabled = false;
            btnGuardarEquipo.Enabled = false;

            lblEstado.Text = "";
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DatosGlobales.usuarioActual = "";
            DatosGlobales.rolActual = "";

            frmLogin frm = new frmLogin();
            frm.Show();
            this.Close();
        }

        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            frmEditarPerfil frm = new frmEditarPerfil();
            frm.Show();
            this.Close();
        }

    }
}
