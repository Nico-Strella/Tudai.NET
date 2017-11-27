using System;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace TUDAI
{
    public partial class AltaNoticia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDdls();

                this.mostrar(true);

                if (!string.IsNullOrEmpty(Request.QueryString.Get("edit")))
                {
                    int id = (int)Session["idNoticia"];

                    Noticia oNoticia = new Noticia();
                    oNoticia.Id = id;

                    using (NoticiaBusiness oNoticiaBusiness = new NoticiaBusiness())
                    {
                        oNoticia = Noticia.getFromDataRow(oNoticiaBusiness.GetNoticiaById(oNoticia).Tables[0].Rows[0]);
                    }

                    this.txt_titulo.Text = oNoticia.Titulo;
                    this.date_fecha.SelectedDate = oNoticia.Fecha;
                    this.txt_cuerpo.Text = oNoticia.Cuerpo;
                    this.txt_autor.Text = oNoticia.Autor;
                    this.ddl_categorias.SelectedIndex = (int) oNoticia.IdCategoria;

                    if (Request.QueryString.Get("edit").Equals("false"))
                    {
                        this.mostrar(false);
                    }
                }
            }
        }

        private void mostrar(Boolean val)
        {
            this.txt_cuerpo.Enabled = val;
            this.txt_titulo.Enabled = val;
            this.ddl_categorias.Enabled = val;
            this.date_fecha.Enabled = val;
            this.txt_autor.Enabled = val;

            this.btn_submit.Visible = val;
        }

        private void CargarDdls()
        {
            ddl_categorias.DataSource = new CategoriaBusiness().GetCategorias();            
            ddl_categorias.DataBind();   
        }

        protected void Publicar_Noticia(object sender, EventArgs e)
        {

            var oNoticia = new Noticia()
            {
                Id = (int)Session["idNoticia"],
                Titulo = txt_titulo.Text,
                Cuerpo = txt_cuerpo.Text,
                Fecha = date_fecha.SelectedDate,
                Autor = txt_autor.Text,
                IdCategoria = string.IsNullOrEmpty(ddl_categorias.SelectedValue) ? -1 : int.Parse(ddl_categorias.SelectedValue),
            };

            if (!string.IsNullOrEmpty(Request.QueryString.Get("edit")) && (Request.QueryString.Get("edit").Equals("true")))
            {
                using (NoticiaBusiness n = new NoticiaBusiness())
                {
                    n.updateNoticia(oNoticia);
                }

                lbl_resultado.Text = "Noticia editada correctamente";
            }
            else
            {
                using (NoticiaBusiness n = new NoticiaBusiness())
                {
                    n.InsertNoticia(oNoticia);
                }

                lbl_resultado.Text = "Noticia publicada correctamente";
            }       
        }
    }
}