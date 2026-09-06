using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Proyecto_Formulario
{
    public static class EstiloUI
    {
        // Paleta de colores
        public static readonly Color VerdeOscuro = ColorTranslator.FromHtml("#173404");
        public static readonly Color VerdeAccion = ColorTranslator.FromHtml("#639922");
        public static readonly Color VerdeClaro = ColorTranslator.FromHtml("#EAF3DE");
        public static readonly Color FondoFormulario = ColorTranslator.FromHtml("#F1EFE8");
        public static readonly Color FondoCard = Color.White;
        public static readonly Color TextoSobreVerdeOscuro = ColorTranslator.FromHtml("#EAF3DE");
        public static readonly Color TextoSobreVerdeClaro = VerdeOscuro;
        public static readonly Color TextoError = ColorTranslator.FromHtml("#A32D2D");
        public static readonly Color BordeInput = ColorTranslator.FromHtml("#D3D1C7");
        public static readonly Color BordeCard = ColorTranslator.FromHtml("#D3D1C7");

        // Fuentes más grandes en general
        public static readonly Font FuenteTitulo = new Font("Segoe UI Semibold", 18f, FontStyle.Bold);
        public static readonly Font FuenteSubtitulo = new Font("Segoe UI Semibold", 13f, FontStyle.Bold);
        public static readonly Font FuenteEtiqueta = new Font("Segoe UI", 11f, FontStyle.Regular);
        public static readonly Font FuenteNormal = new Font("Segoe UI", 11f, FontStyle.Regular);
        public static readonly Font FuenteBoton = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);

        public static void AplicarBaseFormulario(Form form)
        {
            form.BackColor = FondoFormulario;
            form.Font = FuenteNormal;
        }

        public static void EstilizarEncabezado(Label lblTitulo)
        {
            lblTitulo.BackColor = VerdeOscuro;
            lblTitulo.ForeColor = TextoSobreVerdeOscuro;
            lblTitulo.Font = FuenteTitulo;
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 70;
            lblTitulo.Padding = new Padding(24, 0, 0, 0);
        }

        // Convierte un Panel en una "card" tipo bootstrap: fondo blanco, borde suave, esquinas redondeadas
        public static void EstilizarCard(Panel panel)
        {
            panel.BackColor = FondoCard;
            AplicarBordeRedondeado(panel, 12);

            panel.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(BordeCard, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
                }
            };
        }

        // Redondea las esquinas de cualquier control (Panel, Button, etc.)
        public static void AplicarBordeRedondeado(Control control, int radio)
        {
            control.Region = null;
            control.Resize += (s, e) => AplicarRegionRedondeada(control, radio);
            AplicarRegionRedondeada(control, radio);
        }

        private static void AplicarRegionRedondeada(Control control, int radio)
        {
            if (control.Width <= 0 || control.Height <= 0) return;

            GraphicsPath ruta = new GraphicsPath();
            int diametro = radio * 2;
            Rectangle rect = new Rectangle(0, 0, control.Width, control.Height);

            ruta.AddArc(rect.X, rect.Y, diametro, diametro, 180, 90);
            ruta.AddArc(rect.Right - diametro, rect.Y, diametro, diametro, 270, 90);
            ruta.AddArc(rect.Right - diametro, rect.Bottom - diametro, diametro, diametro, 0, 90);
            ruta.AddArc(rect.X, rect.Bottom - diametro, diametro, diametro, 90, 90);
            ruta.CloseFigure();

            control.Region = new Region(ruta);
        }

        public static void EstilizarTextoDestacado(Label lbl)
        {
            lbl.Font = FuenteSubtitulo;
            lbl.ForeColor = VerdeOscuro;
        }

        public static void EstilizarEtiqueta(Label lbl)
        {
            lbl.Font = FuenteEtiqueta;
            lbl.ForeColor = ColorTranslator.FromHtml("#444441");
        }

        public static void EstilizarBotonPrimario(Button btn)
        {
            btn.BackColor = VerdeAccion;
            btn.ForeColor = Color.White;
            btn.Font = FuenteBoton;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3B6D11");
            btn.Cursor = Cursors.Hand;
            btn.Height = 42;
            AplicarBordeRedondeado(btn, 8);
        }

        public static void EstilizarBotonSecundario(Button btn)
        {
            btn.BackColor = Color.White;
            btn.ForeColor = VerdeOscuro;
            btn.Font = FuenteNormal;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = VerdeOscuro;
            btn.FlatAppearance.BorderSize = 1;
            btn.Cursor = Cursors.Hand;
            btn.Height = 38;
            AplicarBordeRedondeado(btn, 8);
        }

        public static void EstilizarTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = FuenteNormal;
            txt.Height = 32;
        }

        public static void EstilizarGrilla(DataGridView grilla)
        {
            grilla.EnableHeadersVisualStyles = false;
            grilla.ColumnHeadersDefaultCellStyle.BackColor = VerdeClaro;
            grilla.ColumnHeadersDefaultCellStyle.ForeColor = TextoSobreVerdeClaro;
            grilla.ColumnHeadersDefaultCellStyle.Font = FuenteSubtitulo;
            grilla.ColumnHeadersHeight = 38;
            grilla.RowTemplate.Height = 32;
            grilla.BackgroundColor = Color.White;
            grilla.BorderStyle = BorderStyle.None;
            grilla.RowHeadersVisible = false;
            grilla.GridColor = BordeInput;
            grilla.DefaultCellStyle.Font = FuenteNormal;
            grilla.DefaultCellStyle.SelectionBackColor = VerdeClaro;
            grilla.DefaultCellStyle.SelectionForeColor = TextoSobreVerdeClaro;
        }

        public static void EstilizarLabelError(Label lbl)
        {
            lbl.ForeColor = TextoError;
            lbl.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
        }
    }    
}
