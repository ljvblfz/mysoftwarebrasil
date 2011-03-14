<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<script runat="server">
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<%--    <script language="javascript" type="text/javascript" src="../Script/jquery-1.4.2.min.js" ></script>
    <script language="javascript" type="text/javascript" src="../Script/jquery.msgbox.min.js" ></script>
    <script language="javascript" type="text/javascript" src="../Script/messagem.js" ></script>--%>
    <script language="javascript" type="text/javascript" src="../Script/comum.js" ></script>
    <script language="javascript" type="text/javascript">

        function confirmaInsert() {
            return confirm("Deseja inserir o registro?");
        }

        function confirmaExcluir() {

            return confirm("Deseja excluir o registro?");
        }
        
        function confirmaAtualizar() {

            return confirm("Deseja alterar o registro?");
        }

    </script>
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" Runat="Server">Categoria</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server" culture="pt-BR" uiCulture="pt-BR" >

    <script language="javascript" type="text/javascript" src="../Script/wz_tooltip.js" ></script>
    
    <div class="siteMap">
        <span id="ctl00_ContentPlaceHolder1_Label1">Cadastro &gt;</span>
        <span class="destaqueSiteMap" id="ctl00_ContentPlaceHolder1_Label2">Categoria</span>
    </div>
    <div class="topConteudo">
    </div>
    <div class="bgConteudo">
        <div class="txtPagina">
            <span id="ctl00_ContentPlaceHolder1_Label4"></span>
            <div class="fioTxt">
                <asp:Label ID="LabelDescricaoErro" runat="server" Text="" style="display:none"></asp:Label>
            </div>
            <div class="divTabela">  
            <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" 
            InsertItemPosition="LastItem" DataKeyNames="seq_categoria">
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                        CssClass="btNovo" Onmouseover="Tip('Inserir')" Onmouseout="UnTip()" ValidationGroup="inserir" OnClientClick="return confirmaInsert();" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel"  
                        CssClass="btApagar" Onmouseover="Tip('Limpar')" Onmouseout="UnTip()"/>
                    </td>
                    <td>
                        <asp:TextBox ID="seq_categoriaTextBox" runat="server" 
                        Text='<%# Bind("seq_categoria") %>' MaxLength="3" Onkeypress="return OnlyNumber(event);" ValidationGroup="insert" />
                        <asp:RequiredFieldValidator ID="seq_categoriaValidator" runat="server" ControlToValidate="seq_categoriaTextBox"
                           ErrorMessage="<div>A categoria não pode estar vazia.</div>" SetFocusOnError="true"
                            Display="Dynamic" ValidationGroup="inserir" />  
                    </td>
                    <td>
                        <asp:TextBox ID="des_categoriaTextBox" runat="server" 
                        Text='<%# Bind("des_categoria") %>' MaxLength="30" />
                        <asp:RequiredFieldValidator ID="des_categoriaValidator1" runat="server" ControlToValidate="des_categoriaTextBox"
                           ErrorMessage="<div>A descrição da categoria não pode estar vazia.</div>" SetFocusOnError="true"
                            Display="Dynamic" ValidationGroup="inserir" />
                    </td>
                </tr>
            </InsertItemTemplate>
            <LayoutTemplate>
                <table id="Table1" runat="server" style="width:100%">
                    <tr id="Tr1" runat="server">
                        <td id="Td1" runat="server">
                            <table ID="itemPlaceholderContainer" runat="server" border="0" class="gridView" style="width:100%">
                                <tr id="Tr2" runat="server">
                                    <th id="Th1" runat="server" style="width:10%"></th>
                                    <th id="Th2" runat="server" style="width:30%">Código</th>
                                    <th id="Th3" runat="server" style="width:60%">Descrição</th>
                                </tr>
                                <tr ID="itemPlaceholder" runat="server"></tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="Tr3" runat="server" class="paginacao">
                        <td id="Td2" runat="server">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NumericPagerField />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()"  OnClientClick="return confirmaExcluir();"  />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()"  />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="seq_categoriaLabel" runat="server" Text='<%# Eval("seq_categoria") %>' />
                    </td>
                    <td>
                        <asp:Label ID="des_categoriaLabel" runat="server" Text='<%# Eval("des_categoria") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
                        <td>
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()" OnClientClick="return confirmaExcluir();" />
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />
                        </td>
                    <td style="text-align:center">
                        <asp:Label ID="seq_categoriaLabel" runat="server" 
                            Text='<%# Eval("seq_categoria") %>' />
                    </td>
                    <td>
                        <asp:Label ID="des_categoriaLabel" runat="server" 
                            Text='<%# Eval("des_categoria") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EmptyDataTemplate>
                <table id="Table2" runat="server" 
                    style="">
                    <tr>
                        <td>
                            Nenhum dado foi retornado.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" CssClass="btSalvar" Onmouseover="Tip('Salvar')" Onmouseout="UnTip()" ValidationGroup="editar"   OnClientClick="return confirmaAtualizar();" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" CssClass="btVoltar" Onmouseover="Tip('Cancelar')" Onmouseout="UnTip()" />
                    </td>
                    <td class="center">
                        <asp:Label ID="seq_categoriaLabel" runat="server" Text='<%# Eval("seq_categoria") %>' />
                        <%--<asp:TextBox ID="seq_categoriaTextBox" runat="server" Text='<%# Bind("seq_categoria") %>' ReadOnly="true" CssClass="RO"/>--%>
                    </td>
                    <td>
                        <asp:TextBox ID="des_categoriaTextBox" runat="server" Text='<%# Bind("des_categoria") %>' CssClass="" MaxLength="30"/>
                        <asp:RequiredFieldValidator ID="des_categoriaValidator2" runat="server" ControlToValidate="des_categoriaTextBox"
                           ErrorMessage="<div>A descrição da categoria não pode estar vazia.</div>" SetFocusOnError="true"
                            Display="Dynamic" ValidationGroup="editar" />
                    </td>
                </tr>
            </EditItemTemplate>
            <SelectedItemTemplate>
                <tr>
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()"  OnClientClick="return confirmaExcluir();"  />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />
                    </td>
                    <td>
                        <asp:Label ID="seq_categoriaLabel" runat="server" 
                            Text='<%# Eval("seq_categoria") %>' />
                    </td>
                    <td>
                        <asp:Label ID="des_categoriaLabel" runat="server" 
                            Text='<%# Eval("des_categoria") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            DataObjectTypeName="Data.Model.CategoriaONP" DeleteMethod="DeleteCategoria" 
            InsertMethod="InsertCategoria" SelectMethod="Select" 
            TypeName="Data.DAL.CategoriaDAO" UpdateMethod="UpdateCategoria">
        </asp:ObjectDataSource>
            </div>   
        </div>
    </div>
    <div class="bottomConteudo">
    </div>
    <div class="bottomPagina">
        <span id="ctl00_ContentPlaceHolder1_Label3">Sistema de Gestão de Saneamento</span>
    </div>
</asp:Content>
    