using System;
using System.Data;

namespace DAL
{
    [Serializable]
    public class Noticia
    {
        #region Properties

        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string Cuerpo { get; set; }
        public int? IdCategoria { get; set; }
        public string Autor { get; set; }

        #endregion

        #region Constructor

        public Noticia()
            : base()
        {
        }

        public static Noticia getFromDataRow(DataRow row)
        {
            Noticia oNoticia = new Noticia()
            {
                Id = Convert.ToInt32(row["id"]),
                Titulo = Convert.ToString(row["titulo"]),
                Fecha = Convert.ToDateTime(row["fecha"]),
                Cuerpo = Convert.ToString(row["cuerpo"]),
                Autor = Convert.ToString(row["autor"])
            };

            return oNoticia;
        }

        #endregion
    }
}