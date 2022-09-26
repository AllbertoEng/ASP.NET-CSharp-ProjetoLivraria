using System;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ProjetoLivraria.DAO;
using ProjetoLivraria.Models;

namespace ProjetoLivraria.Livraria
{
    public partial class GerenciamentoEditores : System.Web.UI.Page
    {
        EditoresDAO ioEditoresDAO = new EditoresDAO();
        LivrosDAO ioLivrosDAO = new LivrosDAO();

        public BindingList<Editores> listaEditores
        {
            get
            {
                if ((BindingList<Editores>)ViewState["ViewStateListaEditores"] == null)
                {
                    this.CarregarDados();
                }
                return (BindingList<Editores>)ViewState["ViewStateListaEditores"];
            }
            set
            {
                ViewState["ViewStateListaEditores"] = value;
            }
        }

        private void CarregarDados()
        {
            try
            {
                listaEditores = ioEditoresDAO.BuscaEditores();
                gvGerenciamentoEditores.DataSource = listaEditores.OrderBy(editor => editor.edi_nm_editor);
                gvGerenciamentoEditores.DataBind();
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alet('Erro ao carregar lista de editores')</script>");
            }            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.CarregarDados();
            }
        }

        protected void btnNovoEditor_Click(object sender, EventArgs e)
        {
            try
            {
                decimal ediIdEditor = this.listaEditores.OrderByDescending(editor => editor.edi_id_editor).FirstOrDefault().edi_id_editor +1;
                string ediNmEditor = tbxCadastroEditor.Text;
                string ediDsEmail = tbxCadastroEmail.Text;
                string ediDsUrl = tbxCadastroUrl.Text;

                Editores novoEditor = new Editores(ediIdEditor, ediNmEditor, ediDsEmail, ediDsUrl);

                ioEditoresDAO.InsereEditor(novoEditor);
                this.CarregarDados();
                HttpContext.Current.Response.Write("<script>alert('Editor cadastrado com sucesso.')</script>");
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Erro ao cadastrar editor.')</script>");
            }

            this.tbxCadastroEditor.Text = string.Empty;
            this.tbxCadastroEmail.Text = string.Empty;
            this.tbxCadastroUrl.Text = string.Empty;
        }

        protected void gvGerenciamentoEditores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gvGerenciamentoEditores.EditIndex = -1;
            this.CarregarDados();
        }
        protected void gvGerenciamentoEditores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvGerenciamentoEditores.EditIndex = e.NewEditIndex;
            this.CarregarDados();
        }
        protected void gvGerenciamentoEditores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                decimal ediIdEditor = Convert.ToDecimal((this.gvGerenciamentoEditores.Rows[e.RowIndex].FindControl("lblEditIdEditor") as Label).Text);
                string ediNmEditor = (this.gvGerenciamentoEditores.Rows[e.RowIndex].FindControl("tbxEditNomeEditor") as TextBox).Text;
                string ediDsEmail = (this.gvGerenciamentoEditores.Rows[e.RowIndex].FindControl("tbxEditEmailEditor") as TextBox).Text;
                string ediDsUrl = (this.gvGerenciamentoEditores.Rows[e.RowIndex].FindControl("tbxEditUrlEditor") as TextBox).Text;

                if (string.IsNullOrWhiteSpace(ediNmEditor))
                {
                    HttpContext.Current.Response.Write("<script>alert('Digite o nome do editor')</script>");
                }
                else if (string.IsNullOrWhiteSpace(ediDsEmail))
                {
                    HttpContext.Current.Response.Write("<script>alert('Digite a E-mail do editor!')</script>");
                }
                else if (string.IsNullOrWhiteSpace(ediDsUrl))
                {
                    HttpContext.Current.Response.Write("<script>alert('Digite a Url do editor!')</script>");
                }
                else
                {
                    Editores editor = new Editores(ediIdEditor, ediNmEditor, ediDsEmail, ediDsUrl);

                    ioEditoresDAO.AtualizaEditor(editor);
                    this.gvGerenciamentoEditores.EditIndex = -1;
                    this.CarregarDados();
                    HttpContext.Current.Response.Write("<script>alert('Editor atualizado com sucesso')</script>");
                }                
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Erro ao atualizar editor')</script>");
            }
        }
        protected void gvGerenciamentoEditores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                decimal ediIdEditor = Convert.ToDecimal((this.gvGerenciamentoEditores.Rows[e.RowIndex].FindControl("lblIdEditor") as Label).Text);
                string ediNmEditor = (this.gvGerenciamentoEditores.Rows[e.RowIndex].FindControl("lblNomeEditor") as Label).Text;
                string ediDsEmail = (this.gvGerenciamentoEditores.Rows[e.RowIndex].FindControl("lblEmailEditor") as Label).Text;
                string ediDsUrl = (this.gvGerenciamentoEditores.Rows[e.RowIndex].FindControl("lblUrlEditor") as Label).Text;

                Editores editor = new Editores(ediIdEditor, ediNmEditor, ediDsEmail, ediDsUrl);

                if (ioLivrosDAO.FindLivrosByEditor(editor).Count != 0)
                {
                    HttpContext.Current.Response.Write("<script>alert('Editor não pode ser removido pois possue livros associados.')</script>");
                }
                else
                {
                    ioEditoresDAO.RemoverEditor(editor);
                    this.CarregarDados();
                    HttpContext.Current.Response.Write("<script>alert('Editor removido com sucesso!')</script>");
                }
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Erro ao remover editor')</script>");
            }            
        }
    }
}