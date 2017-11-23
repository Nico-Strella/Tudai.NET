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

                if (!string.IsNullOrEmpty(Request.QueryString.Get("edit")) && (Request.QueryString.Get("edit").Equals("true")))
                {
                    int id = (int) Session["idNoticia"];

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
                }
            }
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
                Titulo = txt_titulo.Text,
                Cuerpo = txt_cuerpo.Text,
                Fecha = date_fecha.SelectedDate,
                Autor = txt_autor.Text,
                IdCategoria = string.IsNullOrEmpty(ddl_categorias.SelectedValue) ? -1 : int.Parse(ddl_categorias.SelectedValue),
            };
            using (NoticiaBusiness n = new NoticiaBusiness())
            {
                n.InsertNoticia(oNoticia);
            }
            lbl_resultado.Text = "Noticia publicada correctamente";            
            
        }
    }
}