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
    public partial class frmPrincipalAdmin : Form
    {
        public frmPrincipalAdmin()
        {
            InitializeComponent();
        }

        private void frmPrincipalAdmin_Load(object sender, EventArgs e)
        {
            EstiloUI.AplicarBaseFormulario(this);
            EstiloUI.EstilizarTextoDestacado(lblBienvenida);
            EstiloUI.EstilizarBotonSecundario(btnCerrarSesion);
            EstiloUI.EstilizarBotonSecundario(btnEditarPerfil);
            EstiloUI.EstilizarBotonPrimario(btnRegistrarUsuario);
            EstiloUI.EstilizarGrilla(dgvEquipos);
            EstiloUI.EstilizarLabelError(lblEstado);

            lblBienvenida.Text = "¡Hola, " + DatosGlobales.usuarioActual + "!";
            lblEstado.Text = "";

            dgvEquipos.Columns.Clear();

            dgvEquipos.Columns.Add("colNombreEquipo", "Equipo");
            dgvEquipos.Columns.Add("colCategoria", "Categoría");
            dgvEquipos.Columns.Add("colCantidadJugadores", "Jugadores");

            DataGridViewButtonColumn colEliminar = new DataGridViewButtonColumn();
            colEliminar.Name = "colEliminar";
            colEliminar.HeaderText = "";
            colEliminar.Text = "Eliminar";
            colEliminar.UseColumnTextForButtonValue = true; // todos los botones muestran "Eliminar"
            dgvEquipos.Columns.Add(colEliminar);

            // Las columnas de datos no se editan a mano; solo el botón es interactivo
            dgvEquipos.Columns["colNombreEquipo"].ReadOnly = true;
            dgvEquipos.Columns["colCategoria"].ReadOnly = true;
            dgvEquipos.Columns["colCantidadJugadores"].ReadOnly = true;

            CargarEquipos();
        }

        private void CargarEquipos()
        {
            dgvEquipos.Rows.Clear();

            for (int i = 0; i < DatosGlobales.equiposNombre.Count; i++)
            {
                dgvEquipos.Rows.Add(
                    DatosGlobales.equiposNombre[i],
                    DatosGlobales.equiposCategoria[i],
                    DatosGlobales.equiposCantidadJugadores[i]
                // la 4ta columna (botón) no necesita valor: UseColumnTextForButtonValue ya la completa
                );
            }

            if (DatosGlobales.equiposNombre.Count == 0)
            {
                lblEstado.Text = "Todavía no hay equipos registrados.";
            }
            else
            {
                lblEstado.Text = "";
            }
        }

        private void dgvEquipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignoramos clics en encabezados (RowIndex = -1) o en columnas que no son el botón
            if (e.RowIndex < 0) return;
            if (dgvEquipos.Columns[e.ColumnIndex].Name != "colEliminar") return;

            string nombreEquipo = DatosGlobales.equiposNombre[e.RowIndex];

            DialogResult confirmacion = MessageBox.Show(
                "¿Eliminar el equipo \"" + nombreEquipo + "\"? Esta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes) return;

            // Eliminamos de las 4 listas a la vez, respetando el mismo índice
            DatosGlobales.equiposNombre.RemoveAt(e.RowIndex);
            DatosGlobales.equiposCategoria.RemoveAt(e.RowIndex);
            DatosGlobales.equiposCantidadJugadores.RemoveAt(e.RowIndex);
            DatosGlobales.equiposJugadores.RemoveAt(e.RowIndex);

            CargarEquipos();

            MessageBox.Show("Equipo eliminado correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            frmRegistrarUsuario frm = new frmRegistrarUsuario();
            frm.Show();
            this.Close();
        }
    }
}
