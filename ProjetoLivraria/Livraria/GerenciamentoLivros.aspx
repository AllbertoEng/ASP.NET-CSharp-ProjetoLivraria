<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GerenciamentoLivros.aspx.cs" Inherits="ProjetoLivraria.Livraria.GerenciamentoLivros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="text-align: left;">
        <h2>Cadastro de novo livro</h2>
        <table>
            <tr style="display: grid;">  
                <!--Titulo-->
                <td>
                    <asp:Label ID="lblCadastroNomeLivro" runat="server" Font-Size="16pt" Text="Nome do livro: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbxCadastroNomeLivro" runat="server" CssClass="form-control" Height="35px" Width="400px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxCadastroNomeLivro"
                        Style="color: red;" ErrorMessage="* Digite o nome do Livro."></asp:RequiredFieldValidator>
                </td>

                <!--Resumo-->
                <td>
                    <asp:Label ID="lblCadastroDsResumo" runat="server" Font-Size="16pt" Text="Resumo do livro: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbxCadastroDsResumo" runat="server" CssClass="form-control" Height="35px" Width="400px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbxCadastroDsResumo"
                        Style="color: red;" ErrorMessage="* Digite o resumo do Livro."></asp:RequiredFieldValidator>
                </td>

                <!--Autor-->
                <td>
                    <asp:Label ID="lblSelecaoAutor" runat="server" Font-Size="16pt" Text="Autor: "></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddListAutores" runat="server" CssClass="form-control" Height="35px" Width="400px"></asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddListAutores"
                        Style="color: red;" ErrorMessage="* Selecione o autor."></asp:RequiredFieldValidator>
                </td>

                <!--Categoria-->
                <td>
                    <asp:Label ID="lblSelecaoTipoLivro" runat="server" Font-Size="16pt" Text="Categoria: "></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddListaCategorias" runat="server" CssClass="form-control" Height="35px" Width="400px"></asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddListaCategorias"
                        Style="color: red;" ErrorMessage="* Selecione a categoria."></asp:RequiredFieldValidator>
                </td>

                <!--Editor-->
                <td>
                    <asp:Label ID="lblSelecaoEditor" runat="server" Font-Size="16pt" Text="Editora: "></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddListaEditor" runat="server" CssClass="form-control" Height="35px" Width="400px"></asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddListaEditor"
                        Style="color: red;" ErrorMessage="* Selecione a editora."></asp:RequiredFieldValidator>
                </td>

                <!--Valor-->
                <td>
                    <asp:Label ID="lblCadastroValor" runat="server" Font-Size="16pt" Text="Valor do livro: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbxCadastroValor" runat="server" CssClass="form-control" Height="35px" Width="400px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbxCadastroValor"
                        Style="color: red;" ErrorMessage="* Digite o valor do Livro."></asp:RequiredFieldValidator>
                </td>

                <!--Royalty-->
                <td>
                    <asp:Label ID="lblCadastroRoyalty" runat="server" Font-Size="16pt" Text="Royalty: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbxCadastroRoyalty" runat="server" CssClass="form-control" Height="35px" Width="400px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbxCadastroRoyalty"
                        Style="color: red;" ErrorMessage="* Digite o royalty do Livro."></asp:RequiredFieldValidator>
                </td>

                <!--Edicao-->
                <td>
                    <asp:Label ID="lblCadastroEdicao" runat="server" Font-Size="16pt" Text="Edicao do livro: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbxCadastroEdicao" runat="server" CssClass="form-control" Height="35px" Width="400px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbxCadastroEdicao"
                        Style="color: red;" ErrorMessage="* Digite a edicao do Livro."></asp:RequiredFieldValidator>
                </td>

                <td>
                    <asp:Button ID="btnNovoLivro" runat="server" CssClass="btn btn-sucess" Style="margin-top: 10px" Text="Salvar" OnClick="btnNovoLivro_Click"/>
                </td>
            </tr>
        </table>   
    </div>    

    <div class="row">
            <h2 style="text-align: center;">Lista de livros cadastrados</h2>
             <asp:GridView ID="gvGerenciamentoLivros" runat="server" Width="100%" AutoGenerateColumns="false" GridLines="None" Font-Size="14px" CellPadding="4"
            ForeColor="#333333" OnRowCancelingEdit="gvGerenciamentoLivros_RowCancelingEdit" OnRowEditing="gvGerenciamentoLivros_RowEditing"
            OnRowUpdating ="gvGerenciamentoLivros_RowUpdating" OnRowDeleting="gvGerenciamentoLivros_RowDeleting" >
            <Columns>
                <asp:TemplateField Visible="false">
                    <EditItemTemplate>
                        <asp:Label ID="lblEditIdLivro" runat="server" Text='<%# Eval("liv_id_livro") %>'></asp:Label>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoIdLivro" runat="server" Style="width: 100%" Text="ID Livro"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblIdLivro" runat="server" Style="text-align: center;" Text='<%# Eval("liv_id_livro") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField Visible="false">
                    <EditItemTemplate>
                        <asp:Label ID="tbxEditIdTipoLivro" runat="server" Text='<%# Eval("liv_id_tipo_livro") %>'></asp:Label>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoTipoLivro" runat="server" Style="width: 100%" Text="ID Tipo Livro"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTipoLivro" runat="server" Style="text-align: center;" Text='<%# Eval("liv_id_tipo_livro") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <asp:TemplateField Visible="false">
                    <EditItemTemplate>
                        <asp:Label ID="tbxEditIdEditor" runat="server" Text='<%# Eval("liv_id_editor") %>'></asp:Label>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoIdEditor" runat="server" Style="width: 100%" Text="ID Editor"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblIdEditor" runat="server" Style="text-align: center;" Text='<%# Eval("liv_id_editor") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditNomeLivro" runat="server" Text='<%# Eval("liv_nm_titulo") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoNomeLivro" runat="server" Style="width: 100%" Text="Titulo"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNomeLivro" runat="server" Style="text-align: center;" Text='<%# Eval("liv_nm_titulo") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditValor" runat="server" Text='<%# Eval("liv_vl_preco") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoValor" runat="server" Style="width: 100%" Text="Valor"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNomeValor" runat="server" Style="text-align: center;" Text='<%# Eval("liv_vl_preco") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditRoyalty" runat="server" Text='<%# Eval("liv_pc_royalty") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoRoyalty" runat="server" Style="width: 100%" Text="Royalty"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblRoyalty" runat="server" Style="text-align: center;" Text='<%# Eval("liv_pc_royalty") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditDsResumo" runat="server" Text='<%# Eval("liv_ds_resumo") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoDsResumo" runat="server" Style="width: 100%" Text="Resumo"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDsResumo" runat="server" Style="text-align: center;" Text='<%# Eval("liv_ds_resumo") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditEdicao" runat="server" Text='<%# Eval("liv_nu_edicao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoEdicao" runat="server" Style="width: 100%" Text="Edicao"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblEdicao" runat="server" Style="text-align: center;" Text='<%# Eval("liv_nu_edicao") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" CommandName="Update" CssClass="btn btn-sucess" Text="Atualizar" CausesValidation="false" />&nbsp;
                        <asp:Button ID="btnCancelar" runat="server" CommandName="Cancel" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="false" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnEditarLivro" runat="server" CommandName="Edit" CssClass="btn btn-sucess" Text="Editar" CausesValidation="false" />
                        <asp:Button ID="btnDeletarLivro" runat="server" CommandName="Delete" CssClass="btn btn-danger" Text="Deletar" CausesValidation="false" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="250px" />
                </asp:TemplateField>

            </Columns>
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" Font-Size="14px" />
                 <FooterStyle BackColor="#507CD1" Font-Bold="true" ForeColor="White" />
                 <HeaderStyle HorizontalAlign="Center" Wrap="true" BackColor="#507CD1" Font-Bold="true" ForeColor="White" />
                 <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                 <RowStyle HorizontalAlign="Center" BackColor="#F5F7FB" />
                 <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="true" ForeColor="#333333" Font-Size="14px" />
                 <SortedAscendingCellStyle BackColor="#F5F7FB" />
                 <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                 <SortedDescendingCellStyle BackColor="#E9EBEF" />
                 <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </div>
</asp:Content>
