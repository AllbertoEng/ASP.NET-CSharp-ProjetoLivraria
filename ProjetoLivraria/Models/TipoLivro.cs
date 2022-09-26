using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLivraria.Models
{
    [Serializable]
    public class TipoLivro
    {
        public decimal til_id_tipo_livro{ get; set; }
        public string til_ds_descricao{ get; set; }

        public TipoLivro(decimal tilIdTipoLivro, string tilDsDescricao)
        {
            this.til_id_tipo_livro = tilIdTipoLivro;
            this.til_ds_descricao = tilDsDescricao;
        }

        public override string ToString()
        {
            return til_ds_descricao;
        }
    }
}