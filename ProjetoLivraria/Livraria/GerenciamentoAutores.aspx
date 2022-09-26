<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GerenciamentoAutores.aspx.cs" Inherits="ProjetoLivraria.Livraria.GerenciamentoAutores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="text-align: left;">
        <h2>Cadastro de novo autor</h2>
        <table>
            <tr style="display: grid;">                
                <td>
                    <asp:Label ID="lblCadastroNomeAutor" runat="server" Font-Size="16pt" Text="Nome: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbxCadastroNomeAutor" runat="server" CssClass="form-control" Height="35px" Width="400px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxCadastroNomeAutor"
                        Style="color: red;" ErrorMessage="* Digite o nome do autor."></asp:RequiredFieldValidator>
                </td>


                <td>
                    <asp:Label ID="lblCadastroSobrenomeAutor" runat="server" Font-Size="16pt" Text="Sobrenome: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbxCadastroSobrenomeAutor" runat="server" CssClass="form-control" Height="35px" Width="400px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxCadastroSobrenomeAutor"
                        Style="color: red;" ErrorMessage="* Digite o sobrenome do autor."></asp:RequiredFieldValidator>
                </td>


                <td>
                    <asp:Label ID="lblCadastroEmailAutor" runat="server" Font-Size="16pt" Text="Email: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbxCadastroEmailAutor" runat="server" CssClass="form-control" Height="35px" Width="400px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbxCadastroEmailAutor"
                        Style="color: red;" ErrorMessage="* Digite o E-mail do autor."></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Button ID="btnNovoAutor" runat="server" CssClass="btn btn-sucess" Style="margin-top: 10px" Text="Salvar"
                        OnClick="BtnNovoAutor_Click" />
                </td>
            </tr>
        </table>     
    </div>

    <div class="row">
            <h2 style="text-align: center;">Lista de autores cadastrados</h2>
             <asp:GridView ID="gvGerenciamentoAutores" runat="server" Width="100%" AutoGenerateColumns="false" GridLines="None" Font-Size="14px" CellPadding="4"
            ForeColor="#333333" OnRowCancelingEdit="gvGerenciamentoAutores_RowCancelingEdit" OnRowEditing="gvGerenciamentoAutores_RowEditing"
            OnRowUpdating ="gvGerenciamentoAutores_RowUpdating" OnRowDeleting="gvGerenciamentoAutores_RowDeleting" 
            OnRowCommand="gvGerenciamentoAutores_RowCommand">
            <Columns>
                <asp:TemplateField Visible="false">
                    <EditItemTemplate>
                        <asp:Label ID="lblEditIdAutor" runat="server" Text='<%# Eval("aut_id_autor") %>'></asp:Label>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoIdAutor" runat="server" Style="width: 100%" Text="ID"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblIdAutor" runat="server" Style="text-align: center;" Text='<%# Eval("aut_id_autor") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditNomeAutor" runat="server" Text='<%# Eval("aut_nm_nome") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoNomeAutor" runat="server" Style="width: 100%" Text="Nome"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNomeAutor" runat="server" Style="text-align: center;" Text='<%# Eval("aut_nm_nome") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditSobrenomeAutor" runat="server" Text='<%# Eval("aut_nm_sobrenome") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoSobrenomeAutor" runat="server" Style="width: 100%" Text="Sobrenome"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblSobrenomeAutor" runat="server" Style="text-align: center;" Text='<%# Eval("aut_nm_sobrenome") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditEmailAutor" runat="server" Text='<%# Eval("aut_ds_email") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoEmailAutor" runat="server" Style="width: 100%" Text="Email"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblEmailAutor" runat="server" Style="text-align: center;" Text='<%# Eval("aut_ds_email") %>'></asp:Label>
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
                        <asp:Button ID="btnEditarAutor" runat="server" CommandName="Edit" CssClass="btn btn-sucess" Text="Editar" CausesValidation="false" />
                        <asp:Button ID="btnDeletarAutor" runat="server" CommandName="Delete" CssClass="btn btn-danger" Text="Deletar" CausesValidation="false" />
                        <asp:Button ID="btnCarregaLivrosAutor" runat="server" CommandName="CarregaLivrosAutor" CssClass="btn btn-primary" 
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Livros" CausesValidation="false" />&nbsp;
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
