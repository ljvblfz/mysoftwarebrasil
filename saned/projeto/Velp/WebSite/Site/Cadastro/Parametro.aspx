<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" culture="pt-BR" uiCulture="pt-BR" %>
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
<asp:Content ID="Content3" ContentPlaceHolderID="Title" Runat="Server">Parametro</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <script language="javascript" type="text/javascript" src="../Script/wz_tooltip.js" ></script>
    
    
    <div class="siteMap">
        <span id="ctl00_ContentPlaceHolder1_Label1">Cadastro</span>
        <span class="destaqueSiteMap" id="ctl00_ContentPlaceHolder1_Label2">Parametro</span>
    </div>
    <div class="topConteudo">
    </div>
    <div class="bgConteudo">
        <div class="txtPagina">
            <span id="ctl00_ContentPlaceHolder1_Label4"></span>
             <div class="divTabela">
                <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource"
            InsertItemPosition="LastItem" DataKeyNames="des_nome">
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert"
						CssClass="btNovo" Onmouseover="Tip('Inserir')" Onmouseout="UnTip()"
						ValidationGroup="inserir" OnClientClick="return confirmaInsert();" />

                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel"
						CssClass="btApagar" Onmouseover="Tip('Limpar')" Onmouseout="UnTip()" />
                    </td>
					
                    <td>
                        <asp:TextBox ID="des_nomeTextBox" runat="server" Text='<%# Bind("des_nome") %>' MaxLength="40" CssClass="RO" />
                    
                        <asp:RequiredFieldValidator ID="des_nomeValidator" runat="server" ControlToValidate="des_nomeTextBox"
		                   ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                    Display="Dynamic" ValidationGroup="inserir" />
                    </td>				    

                    <td>
                        <asp:TextBox ID="des_valorTextBox" runat="server" Text='<%# Bind("des_valor") %>' MaxLength="150" CssClass="RO" />
                    
                        <asp:RequiredFieldValidator ID="des_valorValidator" runat="server" ControlToValidate="des_valorTextBox"
		                   ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                    Display="Dynamic" ValidationGroup="inserir" />
                    </td>				    
                </tr>
            </InsertItemTemplate>
            <LayoutTemplate>
                <table id="Table1" runat="server" style="width:100%">
                    <tr id="Tr1" runat="server">
                        <td id="Td1" runat="server">
                            <table ID="itemPlaceholderContainer" runat="server" border="0" class="gridView">
                                <tr id="Tr2" runat="server">
                                    <th id="Th1" runat="server" style="width:80px"></th>
					                <th id="Thdes_nome" runat="server">Nome da versão</th>
					                <th id="Thdes_valor" runat="server">Numero da versão</th>
                                </tr>
                                <tr ID="itemPlaceholder" runat="server"></tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="Tr3" runat="server">
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
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()" OnClientClick="return confirmaExcluir();" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />
                    </td>
                    <td>
                        <asp:Label ID="des_nomeLabel" runat="server" Text='<%# Eval("des_nome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="des_valorLabel" runat="server" Text='<%# Eval("des_valor") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()" OnClientClick="return confirmaExcluir();" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />
                    </td>
                    <td>
                        <asp:Label ID="des_nomeLabel" runat="server" Text='<%# Eval("des_nome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="des_valorLabel" runat="server" Text='<%# Eval("des_valor") %>' />
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
                    <td>
                        <asp:Label ID="des_nomeLabel" runat="server" Text='<%# Eval("des_nome") %>' />
                        <%--<asp:TextBox ID="des_nomeTextBox" runat="server" Text='<%# Bind("des_nome") %>' ReadOnly="true" CssClass="RO"/>--%>
                    </td>				    
                    <td>
                        <asp:TextBox ID="des_valorTextBox" runat="server" Text='<%# Bind("des_valor") %>' MaxLength="150" CssClass="" />
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
                        <asp:Label ID="des_nomeLabel" runat="server" Text='<%# Eval("des_nome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="des_valorLabel" runat="server" Text='<%# Eval("des_valor") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
                <asp:ObjectDataSource ID="ObjectDataSource" runat="server" 
            DataObjectTypeName="Data.Model.ParametroONP" DeleteMethod="DeleteParametro" 
            InsertMethod="InsertParametro" SelectMethod="Select" 
            TypeName="Data.DAL.ParametroDAO" UpdateMethod="UpdateParametro">
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
    