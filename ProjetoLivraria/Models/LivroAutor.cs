using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLivraria.Models
{
    public class LivroAutor
    {
        public decimal lia_id_autor{ get; set; }
        public decimal lia_id_livro{ get; set; }
        public decimal lia_pc_royalty{ get; set; }

        public LivroAutor(decimal liaIdAutor, decimal liaIdLivro, decimal liaPcRoyalty)
        {
            this.lia_id_autor = liaIdAutor;
            this.lia_id_livro = liaIdLivro;
            this.lia_pc_royalty = liaPcRoyalty;
        }
    }
}