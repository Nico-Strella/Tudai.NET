using System;
using DAL;

namespace TUDAI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvNoticias.DataSource = new NoticiaBusiness().GetNoticias();
            gvNoticias.DataBind();
        }

        protected void gvNoticias_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

            int id = (int) this.gvNoticias.DataKeys[Convert.ToInt32(e.CommandArgument)].Value;

            Session.Add("idNoticia", id);

            switch (e.CommandName)
            {
                case "editar":
                    Response.Redirect("alta_noticia.aspx?edit=true", false);
                    break;
                case "mostrar":
                    Response.Redirect("alta_noticia.aspx?mostrar=true", false);
                    break;
                default:
                    break;
            }
        }
    }
}