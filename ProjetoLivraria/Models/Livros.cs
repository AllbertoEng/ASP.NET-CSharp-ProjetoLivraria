using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLivraria.Models
{
    [Serializable]
    public class Livros
    {
        public decimal liv_id_livro { get; set; }
        public decimal liv_id_tipo_livro { get; set; }
        public decimal liv_id_editor { get; set; }
        public string liv_nm_titulo { get; set; }
        public decimal liv_vl_preco { get; set; }
        public decimal liv_pc_royalty { get; set; }
        public string liv_ds_resumo { get; set; }
        public int liv_nu_edicao { get; set; }

        public Livros(decimal livIdLivro, decimal livIdTipoLivro, decimal livIdEditor, string livNmTitulo,
            decimal livVlPreco, decimal livPcRoyalty, string livDsResumo, int livNuEdicao)
        {
            this.liv_id_livro = livIdLivro;
            this.liv_id_tipo_livro = livIdTipoLivro;
            this.liv_id_editor = livIdEditor;
            this.liv_nm_titulo = livNmTitulo;
            this.liv_vl_preco = livVlPreco;
            this.liv_pc_royalty = livPcRoyalty;
            this.liv_ds_resumo = livDsResumo;
            this.liv_nu_edicao = livNuEdicao;
        }
    }
}