using System;
using DAL;
using System.Data;

namespace TUDAI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvNoticias.DataSource = new NoticiaBusiness().GetNoticias();
                gvNoticias.DataBind();

                ddl_categorias.DataSource = new CategoriaBusiness().GetCategorias();
                ddl_categorias.DataBind();
            }
            
        }

        protected void gvNoticias_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

            int id = (int)this.gvNoticias.DataKeys[Convert.ToInt32(e.CommandArgument)].Value;

            Session.Add("idNoticia", id);

            Noticia oNoticia = new Noticia();
            oNoticia.Id = id;

            switch (e.CommandName)
            {
                case "editar":
                    Response.Redirect("alta_noticia.aspx?edit=true", false);
                    break;
                case "mostrar":
                    Response.Redirect("alta_noticia.aspx?edit=false", false);
                    break;
                default:
                    break;
            }
        }

        protected void Filtrar(object sender, EventArgs e)
        {
            var oNoticia = new Noticia()
            {
                Autor = txt_autor.Text,
                IdCategoria = string.IsNullOrEmpty(ddl_categorias.SelectedValue) ? -1 : int.Parse(ddl_categorias.SelectedValue),
            };

            DataSet ds;

            using (NoticiaBusiness n = new NoticiaBusiness())
            {
                ds = n.Filtrar(oNoticia);
            }

            gvNoticias.DataSource = ds;
            gvNoticias.DataBind();
        }
    }
}