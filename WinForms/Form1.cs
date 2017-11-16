using DAL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            CargarCategorias();
            base.OnLoad(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Se validan los campos requeridos
            if (string.IsNullOrEmpty(txtTituloNoticia.Text) || string.IsNullOrEmpty(txtCuerpo.Text)
                || dateTimeFecha.Value == null || cmbCategoria.SelectedValue == null)
            {
                lblNotificacion.Text = "Todos los campos son requeridos";
                lblNotificacion.ForeColor = Color.Red;
            }
            else
            {

                //Se inserta la noticia en la BD
                string titulo = txtTituloNoticia.Text;
                DateTime fecha = dateTimeFecha.Value;
                string cuerpo = txtCuerpo.Text;
                int idCategoria = (int)cmbCategoria.SelectedValue;
                string autor = txtAutor.Text;
                Publicar_Noticia(titulo, fecha, cuerpo, idCategoria, autor);

                //Se notifica al usuario
                lblNotificacion.Text = "La noticia se ha publicado correctamente!";
                lblNotificacion.ForeColor = Color.Green;
            }
        }

        public void CargarCategorias()
        {
            //Cargar estáticamente los combos
            //cmbCategoria.DataSource = new ComboItem[] {
            //    new ComboItem{ ID = 1, Text = "Policiales" },
            //    new ComboItem{ ID = 2, Text = "Cine" },
            //    new ComboItem{ ID = 3, Text = "Deportes" }
            //};

            //Cargar consultando la tabla "categoria"
            cmbCategoria.ValueMember = "id";
            cmbCategoria.DisplayMember = "nombre";

            CategoriaBusiness oCategoriaBusiness = new CategoriaBusiness();
            cmbCategoria.DataSource = oCategoriaBusiness.GetCategorias().Tables[0];
        }
        public void Publicar_Noticia(string titulo, DateTime fecha, string cuerpo, int idCat, string autor) {
            var oNoticia = new Noticia()
            {
                Titulo = titulo,
                Cuerpo = cuerpo,
                Fecha = fecha,
                Autor = autor,
                IdCategoria = idCat,
            };
            using (NoticiaBusiness n = new NoticiaBusiness())
            {
                n.InsertNoticia(oNoticia);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
