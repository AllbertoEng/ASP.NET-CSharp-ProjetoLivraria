<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GerenciamentoCategorias.aspx.cs" Inherits="ProjetoLivraria.Livraria.GerenciamentoCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row" style="text-align: left;">
        <h2>Cadastro de nova Categoria</h2>
        <table>
            <tr style="display: grid;">  
                    <!--Titulo-->
                    <td>
                        <asp:Label ID="lblCadastroCategoria" runat="server" Font-Size="16pt" Text="Nome da categoria: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxCadastroCategoria" runat="server" CssClass="form-control" Height="35px" Width="400px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxCadastroCategoria"
                            Style="color: red;" ErrorMessage="* Digite o nome da categoria."></asp:RequiredFieldValidator>
                    </td>
                     <td>
                        <asp:Button ID="btnNovoLivro" runat="server" CssClass="btn btn-sucess" Style="margin-top: 10px" Text="Salvar" OnClick="btnNovoLivro_Click"/>
                    </td>
             </tr>
        </table>        
     </div>

    <div class="row">
            <h2 style="text-align: center;">Lista de categorias cadastradas</h2>
             <asp:GridView ID="gvGerenciamentoCategorias" runat="server" Width="100%" AutoGenerateColumns="false" GridLines="None" Font-Size="14px" CellPadding="4"
            ForeColor="#333333" OnRowCancelingEdit="gvGerenciamentoCategorias_RowCancelingEdit" OnRowEditing="gvGerenciamentoCategorias_RowEditing"
            OnRowUpdating ="gvGerenciamentoCategorias_RowUpdating" OnRowDeleting="gvGerenciamentoCategorias_RowDeleting" >
            <Columns>
                <asp:TemplateField Visible="false">
                    <EditItemTemplate>
                        <asp:Label ID="lblEditIdCategoria" runat="server" Text='<%# Eval("til_id_tipo_livro") %>'></asp:Label>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoIdCategoria" runat="server" Style="width: 100%" Text="ID Categoria"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblIdCategoria" runat="server" Style="text-align: center;" Text='<%# Eval("til_id_tipo_livro") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditDsCategoria" runat="server" Text='<%# Eval("til_ds_descricao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoDsCategoria" runat="server" Style="width: 100%" Text="Categoria"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDsCategoria" runat="server" Style="text-align: center;" Text='<%# Eval("til_ds_descricao") %>'></asp:Label>
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
