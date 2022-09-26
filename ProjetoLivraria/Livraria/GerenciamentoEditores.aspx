<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GerenciamentoEditores.aspx.cs" Inherits="ProjetoLivraria.Livraria.GerenciamentoEditores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="text-align: left;">
        <h2>Cadastro de novo Editor</h2>
        <table>
            <tr style="display: grid;">  
                    <td>
                        <asp:Label ID="lblNomeEditor" runat="server" Font-Size="16pt" Text="Nome do editor: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxCadastroEditor" runat="server" CssClass="form-control" Height="35px" Width="400px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxCadastroEditor"
                            Style="color: red;" ErrorMessage="* Digite o nome da categoria."></asp:RequiredFieldValidator>
                    </td>

                    <td>
                        <asp:Label ID="lblCadastroEmail" runat="server" Font-Size="16pt" Text="E-mail: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxCadastroEmail" runat="server" CssClass="form-control" Height="35px" Width="400px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxCadastroEmail"
                            Style="color: red;" ErrorMessage="* Digite o E-mail."></asp:RequiredFieldValidator>
                    </td>

                    <td>
                        <asp:Label ID="lblCadastroUrl" runat="server" Font-Size="16pt" Text="Url: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxCadastroUrl" runat="server" CssClass="form-control" Height="35px" Width="400px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbxCadastroUrl"
                            Style="color: red;" ErrorMessage="* Digite a Url."></asp:RequiredFieldValidator>
                    </td>

                     <td>
                        <asp:Button ID="btnNovoEditor" runat="server" CssClass="btn btn-sucess" Style="margin-top: 10px" Text="Salvar" OnClick="btnNovoEditor_Click"/>
                    </td>
             </tr>
        </table>        
     </div>

    <div class="row">
            <h2 style="text-align: center;">Lista de editores cadastrados</h2>
             <asp:GridView ID="gvGerenciamentoEditores" runat="server" Width="100%" AutoGenerateColumns="false" GridLines="None" Font-Size="14px" CellPadding="4"
            ForeColor="#333333" OnRowCancelingEdit="gvGerenciamentoEditores_RowCancelingEdit" OnRowEditing="gvGerenciamentoEditores_RowEditing"
            OnRowUpdating ="gvGerenciamentoEditores_RowUpdating" OnRowDeleting="gvGerenciamentoEditores_RowDeleting" >
            <Columns>
                <asp:TemplateField Visible="false">
                    <EditItemTemplate>
                        <asp:Label ID="lblEditIdEditor" runat="server" Text='<%# Eval("edi_id_editor") %>'></asp:Label>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoIdEditor" runat="server" Style="width: 100%" Text="ID Editor"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblIdEditor" runat="server" Style="text-align: center;" Text='<%# Eval("edi_id_editor") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditNomeEditor" runat="server" Text='<%# Eval("edi_nm_editor") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoNomeEditor" runat="server" Style="width: 100%" Text="Editor"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNomeEditor" runat="server" Style="text-align: center;" Text='<%# Eval("edi_nm_editor") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditEmailEditor" runat="server" Text='<%# Eval("edi_ds_email") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoEmailEditor" runat="server" Style="width: 100%" Text="E-mail"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblEmailEditor" runat="server" Style="text-align: center;" Text='<%# Eval("edi_ds_email") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxEditUrlEditor" runat="server" Text='<%# Eval("edi_ds_url") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblTextoUrlEditor" runat="server" Style="width: 100%" Text="Url"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblUrlEditor" runat="server" Style="text-align: center;" Text='<%# Eval("edi_ds_url") %>'></asp:Label>
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
