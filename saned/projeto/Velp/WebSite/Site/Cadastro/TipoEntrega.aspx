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

        function confirmaDelete() {

            return confirm("Deseja excluir o registro?");
        }

        function confirmaUpdate() {

            return confirm("Deseja alterar o registro?");
        }

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Title" Runat="Server">Tipo entrega</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    
    <script language="javascript" type="text/javascript" src="../Script/wz_tooltip.js" ></script>
    
    <div class="siteMap">
        <span id="ctl00_ContentPlaceHolder1_Label1">Cadastro</span>
        <span class="destaqueSiteMap" id="ctl00_ContentPlaceHolder1_Label2">Tipo de entrega</span>
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
                <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource"
                    InsertItemPosition="LastItem" DataKeyNames="seq_tipo_entrega">
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
                                <asp:TextBox ID="seq_tipo_entregaTextBox" runat="server" Text='<%# Bind("seq_tipo_entrega") %>' MaxLength="10" CssClass="" />				    
                            
                                <asp:RequiredFieldValidator ID="seq_tipo_entregaValidator" runat="server" ControlToValidate="seq_tipo_entregaTextBox"
		                           ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                            Display="Dynamic" ValidationGroup="inserir" />
                            </td>
                            <td>
                                <asp:TextBox ID="des_tipo_entregaTextBox" runat="server" Text='<%# Bind("des_tipo_entrega") %>' MaxLength="30" CssClass="" />
        				    
                                <asp:RequiredFieldValidator ID="des_tipo_entregaValidator" runat="server" ControlToValidate="des_tipo_entregaTextBox"
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
					                        <th id="Thseq_tipo_entrega" runat="server">Código</th>
					                        <th id="Thdes_tipo_entrega" runat="server">Descrição</th>
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
                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
                                CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()" OnClientClick="return confirmaDelete();"/>
                                
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />
                            </td>
        					
                            <td style="text-align:center">
                                <asp:Label ID="seq_tipo_entregaLabel" runat="server" Text='<%# Eval("seq_tipo_entrega") %>' />
                            </td>
                            <td>
                                <asp:Label ID="des_tipo_entregaLabel" runat="server" Text='<%# Eval("des_tipo_entrega") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                      <AlternatingItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
                                CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()" OnClientClick="return confirmaDelete();"/>
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />
                            </td>
        					
                            <td style="text-align:center">
                                <asp:Label ID="seq_tipo_entregaLabel" runat="server" Text='<%# Eval("seq_tipo_entrega") %>' />
                            </td>
                            <td>
                                <asp:Label ID="des_tipo_entregaLabel" runat="server" Text='<%# Eval("des_tipo_entrega") %>' />
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
                        <tr>
                            <td>
                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update"
						        CssClass="btSalvar" Onmouseover="Tip('Salvar')" Onmouseout="UnTip()" ValidationGroup="edit" OnClientClick="return confirmaUpdater();" />

                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel"
						        CssClass="btVoltar" Onmouseover="Tip('Cancelar')" Onmouseout="UnTip()" />
                            </td>
					        <td class="center">
					             <asp:Label ID="seq_tipo_entregaLabel" runat="server" Text='<%# Eval("seq_tipo_entrega") %>' />
<%--                                <asp:TextBox ID="seq_tipo_entregaTextBox" runat="server" Text='<%# Bind("seq_tipo_entrega") %>' ReadOnly="true" CssClass="RO"/>
        				    
                                <asp:RequiredFieldValidator ID="seq_tipo_entregaValidator" runat="server" ControlToValidate="seq_tipo_entregaTextBox"
		                           ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                            Display="Dynamic" ValidationGroup="edit" />--%>
                            </td>
                            <td>
                                <asp:TextBox ID="des_tipo_entregaTextBox" runat="server" Text='<%# Bind("des_tipo_entrega") %>' MaxLength="30" CssClass="" />
        				    
                                <asp:RequiredFieldValidator ID="des_tipo_entregaValidator" runat="server" ControlToValidate="des_tipo_entregaTextBox"
		                           ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                            Display="Dynamic" ValidationGroup="edit" />
                            </td>
                        </tr>
                    </EditItemTemplate>
                      <SelectedItemTemplate>
                        <tr>
                            <td>
                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete"
						        CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()"
						        ValidationGroup="edit" OnClientClick="return confirmaDelete();" />

                                <asp:Button ID="EditButton" runat="server" CommandName="Edit"
						        CssClass="btAtualizar"  Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />

                            </td>
        					
                            <td  style="text-align:center">
                                <asp:Label ID="seq_tipo_entregaLabel" runat="server" Text='<%# Eval("seq_tipo_entrega") %>' />
                            </td>
                            <td>
                                <asp:Label ID="des_tipo_entregaLabel" runat="server" Text='<%# Eval("des_tipo_entrega") %>' />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>
                <asp:ObjectDataSource ID="ObjectDataSource" runat="server" 
                    DataObjectTypeName="Data.Model.TipoEntregaONP" DeleteMethod="DeleteTipoEntrega" 
                    InsertMethod="InsertTipoEntrega" SelectMethod="Select" 
                    TypeName="Data.DAL.TipoEntregaDAO" UpdateMethod="UpdateTipoEntrega">
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
    