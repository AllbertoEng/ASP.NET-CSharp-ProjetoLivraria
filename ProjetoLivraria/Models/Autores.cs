using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLivraria.Models
{
    [Serializable]
    public class Autores
    {
        public decimal aut_id_autor { get; set; }
        public string aut_nm_nome { get; set; }
        public string aut_nm_sobrenome { get; set; }
        public string aut_ds_email { get; set; }

        public Autores(decimal autIdAutor, string autNmNome, string autNmSobrenome, string autDsEmail)
        {
            this.aut_id_autor = autIdAutor;
            this.aut_nm_nome = autNmNome;
            this.aut_nm_sobrenome = autNmSobrenome;
            this.aut_ds_email = autDsEmail;
        }

        public override string ToString()
        {
            return this.aut_nm_nome + " " + this.aut_nm_sobrenome;
        }
    }
}