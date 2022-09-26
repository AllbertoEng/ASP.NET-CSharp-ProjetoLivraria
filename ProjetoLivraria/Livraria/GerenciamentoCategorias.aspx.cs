using System;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ProjetoLivraria.DAO;
using ProjetoLivraria.Models;

namespace ProjetoLivraria.Livraria
{
    public partial class GerenciamentoCategorias : System.Web.UI.Page
    {
        TipoLivroDAO ioTipoLivroDAO = new TipoLivroDAO();
        LivrosDAO ioLivrosDAO = new LivrosDAO();
        public BindingList<TipoLivro> listaCategorias
        {
            get
            {
                if ((BindingList<TipoLivro>)ViewState["ViewStatelistaCategorias"] == null)
                {
                    this.CarregarDados();
                }
                return (BindingList<TipoLivro>)ViewState["ViewStatelistaCategorias"];
            }
            set
            {
                ViewState["ViewStatelistaCategorias"] = value;
            }
        }
        protected void CarregarDados()
        {
            try
            {
                this.listaCategorias = ioTipoLivroDAO.BuscaTipoLivro();
                this.gvGerenciamentoCategorias.DataSource = this.listaCategorias.OrderBy(categoria => categoria.til_ds_descricao);
                this.gvGerenciamentoCategorias.DataBind();
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Erro ao recuperar lista de categorias')</script>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.CarregarDados();
            }            
        }
        protected void btnNovoLivro_Click(object sender, EventArgs e)
        {
            try
            {
                decimal tilIdTipoLivro = this.listaCategorias.OrderByDescending(categoria => categoria.til_id_tipo_livro).FirstOrDefault().til_id_tipo_livro + 1;
                string tilDsDescricao = this.tbxCadastroCategoria.Text;

                TipoLivro novaCategoria = new TipoLivro(tilIdTipoLivro, tilDsDescricao);

                this.ioTipoLivroDAO.InsereTipoLivro(novaCategoria);
                this.CarregarDados();

                HttpContext.Current.Response.Write("<script>alert('Categoria cadastrada com sucesso!')</script>");
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Erro ao adicionar categoria')</script>");
            }

            this.tbxCadastroCategoria.Text = string.Empty;
        }

        protected void gvGerenciamentoCategorias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gvGerenciamentoCategorias.EditIndex = -1;
            this.CarregarDados();
        }
        protected void gvGerenciamentoCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvGerenciamentoCategorias.EditIndex = e.NewEditIndex;
            this.CarregarDados();
        }
        protected void gvGerenciamentoCategorias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                decimal liaIdCategoria = Convert.ToDecimal((this.gvGerenciamentoCategorias.Rows[e.RowIndex].FindControl("lblEditIdCategoria") as Label).Text);
                string liaDsCategoria = (this.gvGerenciamentoCategorias.Rows[e.RowIndex].FindControl("tbxEditDsCategoria") as TextBox).Text;

                if (string.IsNullOrWhiteSpace(liaDsCategoria))
                {
                    HttpContext.Current.Response.Write("<script>alert('Digite a categoria!')</script>");
                }
                else
                {
                    TipoLivro categoria = new TipoLivro(liaIdCategoria, liaDsCategoria);

                    ioTipoLivroDAO.AtualizaTipoLivro(categoria);
                    this.gvGerenciamentoCategorias.EditIndex = -1;
                    this.CarregarDados();

                    HttpContext.Current.Response.Write("<script>alert('Categoria atualizada com sucesso.')</script>");
                }                
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Erro ao atualizar categoria.')</script>");
            }
        }
        protected void gvGerenciamentoCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                decimal liaIdCategoria = Convert.ToDecimal((this.gvGerenciamentoCategorias.Rows[e.RowIndex].FindControl("lblIdCategoria") as Label).Text);
                string liaDsCategoria = (this.gvGerenciamentoCategorias.Rows[e.RowIndex].FindControl("lblDsCategoria") as Label).Text;

                TipoLivro categoria = new TipoLivro(liaIdCategoria, liaDsCategoria);

                if(categoria != null)
                {
                    if (ioLivrosDAO.FindLivrosByCategoria(categoria).Count != 0)
                    {
                        HttpContext.Current.Response.Write("<script>alert('Não é possível remover categoria pois existem livros associadas a ela.')</script>");
                    }
                    else
                    {
                        ioTipoLivroDAO.RemoverTipoLivro(categoria);
                        this.CarregarDados();
                        HttpContext.Current.Response.Write("<script>alert('Categoria removida com sucesso!')</script>");
                    }
                }
                
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Ocorreu um erro ao tentar remover categoria.')</script>");
            }
        }

    }
}