using System;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ProjetoLivraria.DAO;
using ProjetoLivraria.Models;

namespace ProjetoLivraria.Livraria
{
    public partial class GerenciamentoLivros : System.Web.UI.Page
    {
        LivrosDAO ioLivrosDAO = new LivrosDAO();
        AutoresDAO ioAutoresDAO = new AutoresDAO();
        TipoLivroDAO ioTipoLivroDAO = new TipoLivroDAO();
        EditoresDAO ioEditoresDAO = new EditoresDAO();
        LivroAutorDAO ioLivroAutorDAO = new LivroAutorDAO();
        public Autores AutorSessao
        {
            get { return (Autores)Session["SessionAutorSelectionado"]; }
            set { Session["SessionAutorSelectionado"] = value; }
        }

        public BindingList<Editores> ListaEditores
        {
            get
            {
                if((BindingList<Editores>)ViewState["ViewStateListaEditores"] == null)
                {
                    this.CarregaDropdownEditores();
                }
                return (BindingList<Editores>)ViewState["ViewStateListaEditores"];
            }
            set
            {
                ViewState["ViewStateListaEditores"] = value;
            }
        }


        public BindingList<Livros> ListaLivros
        {
            get
            {
                if((BindingList<Livros>)ViewState["ViewStateListaLivros"] == null)
                {
                    this.CarregaDados();
                }
                return (BindingList<Livros>)ViewState["ViewStateListaLivros"];
            }
            set
            {
                ViewState["ViewStateListaLivros"] = value;
            }
        }

        public BindingList<Autores> ListaAutores
        {
            get
            {
                if ((BindingList<Autores>)ViewState["ViewStateListaAutores"] == null)
                {
                    this.CarregarDropdownAutores();
                }
                return (BindingList<Autores>)ViewState["ViewStateListaAutores"];
            }
            set
            {
                ViewState["ViewStateListaAutores"] = value;
            }
        }

        public BindingList<TipoLivro> ListaTipoLivro
        {
            get
            {
                if ((BindingList<TipoLivro>)ViewState["ViewStateListaTipoLivro"] == null)
                {
                    this.CarregarDropdownCategoria();
                }
                return (BindingList<TipoLivro>)ViewState["ViewStateListaTipoLivro"];
            }
            set
            {
                ViewState["ViewStateListaTipoLivro"] = value;
            }
        }

        private void CarregaDados(decimal? liaIdAutor = null)
        {
            try
            {
                if(liaIdAutor == null)
                {
                    this.ListaLivros = this.ioLivrosDAO.BuscaLivros();                    
                }
                else
                {
                    this.ListaLivros = this.ioLivrosDAO.BuscaLivros(null, liaIdAutor);
                }
                this.gvGerenciamentoLivros.DataSource = this.ListaLivros.OrderBy(loLivro => loLivro.liv_nm_titulo);
                this.gvGerenciamentoLivros.DataBind();

            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Falha ao tentar carregar Livros.');</script>");
            }

        }

        private void CarregaDropdownEditores()
        {
            try
            {
                this.ListaEditores = ioEditoresDAO.BuscaEditores();

                this.ddListaEditor.Items.Insert(0, new ListItem(string.Empty, string.Empty));

                foreach (Editores editor in ListaEditores)
                {
                    this.ddListaEditor.Items.Add(new ListItem(editor.ToString(), editor.edi_id_editor.ToString()));
                }

                this.ddListaEditor.SelectedIndex = 0;
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Falha ao tentar recuperar Editores.');</script>");
            }            
        }

        private void CarregarDropdownCategoria()
        {
            try
            {
                this.ListaTipoLivro = ioTipoLivroDAO.BuscaTipoLivro();

                this.ddListaCategorias.Items.Insert(0, new ListItem(string.Empty, string.Empty));

                foreach (TipoLivro categoria in ListaTipoLivro)
                {
                    this.ddListaCategorias.Items.Add(new ListItem(categoria.ToString(), categoria.til_id_tipo_livro.ToString()));
                }

                this.ddListaCategorias.SelectedIndex = 0;

            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Falha ao tentar recuperar Categorias.');</script>");
            }            
        }

        private void CarregarDropdownAutores()
        {
            try
            {
                this.ListaAutores = ioAutoresDAO.BuscaAutores();

                this.ddListAutores.Items.Insert(0, new ListItem(string.Empty, string.Empty));

                foreach (Autores autor in ListaAutores)
                {
                    this.ddListAutores.Items.Add(new ListItem(autor.ToString(), autor.aut_id_autor.ToString()));
                }

                this.ddListAutores.SelectedIndex = 0;
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Falha ao tentar recuperar Autores.');</script>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if(AutorSessao == null)
                {
                    this.CarregarDropdownAutores();
                    this.CarregarDropdownCategoria();
                    this.CarregaDropdownEditores();
                    this.CarregaDados();
                }
                else
                {                    
                    this.CarregarDropdownAutores();
                    this.CarregarDropdownCategoria();
                    this.CarregaDropdownEditores();
                    this.CarregaDados(AutorSessao.aut_id_autor);
                    this.AutorSessao = null;
                }
                
            }            
        }

        protected void btnNovoLivro_Click(object sender, EventArgs e)
        {
            try
            {
                decimal livIdLivro = this.ListaLivros.OrderByDescending(livro => livro.liv_id_livro).First().liv_id_livro + 1;
                decimal liaIdAutor = Convert.ToDecimal(this.ddListAutores.SelectedItem.Value);
                decimal livIdTipoLivro = Convert.ToDecimal(this.ddListaCategorias.SelectedItem.Value); 
                decimal livIdEditor = Convert.ToDecimal(this.ddListaEditor.SelectedItem.Value);
                string livNmTitulo = this.tbxCadastroNomeLivro.Text;
                decimal livValor = Convert.ToDecimal(this.tbxCadastroValor.Text);
                decimal livRoyalty = Convert.ToDecimal(this.tbxCadastroRoyalty.Text);
                string livDsResumo = this.tbxCadastroDsResumo.Text;
                int livEdicao = Convert.ToInt32(this.tbxCadastroEdicao.Text);

                Livros novoLivro = new Livros(livIdLivro, livIdTipoLivro, livIdEditor, livNmTitulo, livValor, livRoyalty, livDsResumo, livEdicao);                
                LivroAutor novoLivroAutor = new LivroAutor(liaIdAutor, livIdLivro, livRoyalty);

                ioLivrosDAO.InsereLivro(novoLivro);
                ioLivroAutorDAO.InsereLivroAutor(novoLivroAutor);
                this.CarregaDados();

                HttpContext.Current.Response.Write("<script>alert('Livro cadastrado com sucesso!');</script>");
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Erro ao cadastrar livro');</script>");
            }

            this.ddListAutores.SelectedIndex = 0;
            this.ddListaCategorias.SelectedIndex = 0;
            this.ddListaEditor.SelectedIndex = 0;
            this.tbxCadastroNomeLivro.Text = string.Empty;
            this.tbxCadastroValor.Text = string.Empty;
            this.tbxCadastroRoyalty.Text = string.Empty;
            this.tbxCadastroDsResumo.Text = string.Empty;
            this.tbxCadastroEdicao.Text = string.Empty;

        }

        protected void gvGerenciamentoLivros_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gvGerenciamentoLivros.EditIndex = -1;
            this.CarregaDados();
        }
        protected void gvGerenciamentoLivros_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvGerenciamentoLivros.EditIndex = e.NewEditIndex;
            this.CarregaDados();
        }
        protected void gvGerenciamentoLivros_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                decimal livIdLivro = Convert.ToDecimal((this.gvGerenciamentoLivros.Rows[e.RowIndex].FindControl("lblEditIdLivro") as Label).Text);
                decimal livIdTipoLivro = Convert.ToDecimal((this.gvGerenciamentoLivros.Rows[e.RowIndex].FindControl("tbxEditIdTipoLivro") as Label).Text);
                decimal livIdEditor = Convert.ToDecimal((this.gvGerenciamentoLivros.Rows[e.RowIndex].FindControl("tbxEditIdEditor") as Label).Text);
                string livNmTitulo = (this.gvGerenciamentoLivros.Rows[e.RowIndex].FindControl("tbxEditNomeLivro") as TextBox).Text;
                decimal livValor = Convert.ToDecimal((this.gvGerenciamentoLivros.Rows[e.RowIndex].FindControl("tbxEditValor") as TextBox).Text);
                decimal livRoyalty = Convert.ToDecimal((this.gvGerenciamentoLivros.Rows[e.RowIndex].FindControl("tbxEditRoyalty") as TextBox).Text);
                string livDsResumo = (this.gvGerenciamentoLivros.Rows[e.RowIndex].FindControl("tbxEditDsResumo") as TextBox).Text;
                int livEdicao = Convert.ToInt32((this.gvGerenciamentoLivros.Rows[e.RowIndex].FindControl("tbxEditEdicao") as TextBox).Text);

                if (string.IsNullOrWhiteSpace(livNmTitulo))
                {
                    HttpContext.Current.Response.Write("<script>alert('Digite o nome do Livro');</script>");
                }
                else if (string.IsNullOrWhiteSpace(livValor.ToString()))
                {
                    HttpContext.Current.Response.Write("<script>alert('Digite o valor do Livro');</script>");
                } 
                else if (string.IsNullOrWhiteSpace(livRoyalty.ToString()))
                {
                    HttpContext.Current.Response.Write("<script>alert('Digite o royalty do Livro');</script>");
                }
                else if (string.IsNullOrWhiteSpace(livDsResumo))
                {
                    HttpContext.Current.Response.Write("<script>alert('Digite o resumo do Livro');</script>");
                }
                else if (string.IsNullOrWhiteSpace(livEdicao.ToString()))
                {
                    HttpContext.Current.Response.Write("<script>alert('Digite a edicao do Livro');</script>");
                }
                else
                {
                    Livros livroAtualizado = new Livros(livIdLivro, livIdTipoLivro, livIdEditor, livNmTitulo, livValor, livRoyalty, livDsResumo, livEdicao);
                    ioLivrosDAO.AtualizaLivro(livroAtualizado);
                    this.gvGerenciamentoLivros.EditIndex = -1;
                    this.CarregaDados();

                    HttpContext.Current.Response.Write("<script>alert('Livro atualizado com sucesso');</script>");
                }
                
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Nao foi possivel atualizar livro');</script>");
            }
        }
        protected void gvGerenciamentoLivros_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //GridViewRow loRGridViewRow = this.gvGerenciamentoLivros.Rows[e.RowIndex];
                decimal livIdLivro = Convert.ToDecimal((this.gvGerenciamentoLivros.Rows[e.RowIndex].FindControl("lblIdLivro") as Label).Text);
                Livros livro = ioLivrosDAO.BuscaLivros(livIdLivro).FirstOrDefault();
                LivroAutor livroAutor = ioLivroAutorDAO.BuscaLivroAutor(livIdLivro).FirstOrDefault();

                if(livro != null && livroAutor != null)
                {
                    ioLivrosDAO.RemoverLivro(livro);
                    ioLivroAutorDAO.RemoverLivroAutor(livroAutor);

                    HttpContext.Current.Response.Write("<script>alert('Livro removido com sucesso');</script>");
                }
                else if(livro != null)
                {
                    ioLivrosDAO.RemoverLivro(livro);
                    HttpContext.Current.Response.Write("<script>alert('Livro removido com sucesso: livro sem referencia em LIA_LIVRO_AUTOR');</script>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>alert('Houve um erro ao remover livro: livro ou referencia do livro ao autor/editor é nula.');</script>");
                }


                this.CarregaDados();
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Erro ao remover livro.');</script>");
            }
        }
    }
}