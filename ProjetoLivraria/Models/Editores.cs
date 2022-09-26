using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLivraria.Models
{
    [Serializable]
    public class Editores
    {
        public decimal edi_id_editor { get; set; }
        public string edi_nm_editor { get; set; }
        public string edi_ds_email { get; set; }
        public string edi_ds_url{ get; set; }

        public Editores(decimal ediIdEditor, string ediNmEditor, string ediDsEmail, string ediDsUrl)
        {
            this.edi_id_editor = ediIdEditor;
            this.edi_nm_editor = ediNmEditor;
            this.edi_ds_email = ediDsEmail;
            this.edi_ds_url = ediDsUrl;
        }

        public override string ToString()
        {
            return edi_nm_editor;
        }
    }
}