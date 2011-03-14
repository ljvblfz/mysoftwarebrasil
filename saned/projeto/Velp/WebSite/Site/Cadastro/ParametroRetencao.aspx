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
    <style>
        input
        {
            width:60px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Title" Runat="Server">Parametro retencao</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <script language="javascript" type="text/javascript" src="../Script/wz_tooltip.js" ></script>
    
<div class="siteMap">
    <span id="ctl00_ContentPlaceHolder1_Label1">Cadastro &gt;</span>
    <span class="destaqueSiteMap" id="ctl00_ContentPlaceHolder1_Label2">Parametro de retenção</span>
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
                    InsertItemPosition="LastItem" DataKeyNames="ind_retencao,seq_faixa">
                    <InsertItemTemplate>
                        <tr>
                            <td>
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert"
						        CssClass="btNovo" Onmouseover="Tip('Inserir')" Onmouseout="UnTip()"
						        ValidationGroup="inserir" OnClientClick="return confirmaInsert();" />

                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel"
						        CssClass="btApagar" Onmouseover="Tip('Limpar')" Onmouseout="UnTip()" />
                            </td>
        					
                            <td class="center">
                                <asp:TextBox ID="ind_retencaoTextBox" runat="server" Text='<%# Bind("ind_retencao") %>' MaxLength="1" CssClass=""  Onkeypress="return OnlyAlpha(this.value);"  style="text-align:center" />
                            
                                <asp:RequiredFieldValidator ID="ind_retencaoValidator" runat="server" ControlToValidate="ind_retencaoTextBox"
		                           ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                            Display="Dynamic" ValidationGroup="inserir" />
                            </td>				    

                            <td class="center">
                                <asp:TextBox ID="seq_faixaTextBox" runat="server" Text='<%# Bind("seq_faixa") %>' MaxLength="10" CssClass=""  Onkeypress="return OnlyNumber(event);"  style="text-align:center" />
                            
                                <asp:RequiredFieldValidator ID="seq_faixaValidator" runat="server" ControlToValidate="seq_faixaTextBox"
		                           ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                            Display="Dynamic" ValidationGroup="inserir" />
                            </td>				    

                            <td class="center">
                                <asp:TextBox ID="val_media_inicialTextBox" runat="server" Text='<%# Bind("val_media_inicial") %>' MaxLength="10" CssClass=""  Onkeypress="return OnlyNumber(event);"  style="text-align:center" />
                            
                                <asp:RequiredFieldValidator ID="val_media_inicialValidator" runat="server" ControlToValidate="val_media_inicialTextBox"
		                           ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                            Display="Dynamic" ValidationGroup="inserir" />
                            </td>				    
                            
                            <td class="center">
                                <asp:TextBox ID="val_media_finalTextBox" runat="server" Text='<%# Bind("val_media_final") %>' MaxLength="10" CssClass=""  Onkeypress="return OnlyNumber(event);"  style="text-align:center" />
                            
                                <asp:RequiredFieldValidator ID="val_media_finalValidator" runat="server" ControlToValidate="val_media_finalTextBox"
		                           ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                            Display="Dynamic" ValidationGroup="inserir" />
                            </td>				    

                            <td class="center">
                                <asp:TextBox ID="val_variacao_avisoTextBox" runat="server" Text='<%# Bind("val_variacao_aviso") %>' MaxLength="10" CssClass=""  Onkeypress="return OnlyNumber(event);"  style="text-align:center" />
                            
                                <asp:RequiredFieldValidator ID="val_variacao_avisoValidator" runat="server" ControlToValidate="val_variacao_avisoTextBox"
		                           ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                            Display="Dynamic" ValidationGroup="inserir" />
                            </td>				    

                            <td class="center">
                                <asp:TextBox ID="val_variacao_retencaoTextBox" runat="server" Text='<%# Bind("val_variacao_retencao") %>' MaxLength="10" CssClass=""  Onkeypress="return OnlyNumber(event);"  style="text-align:center" />
                            
                                <asp:RequiredFieldValidator ID="val_variacao_retencaoValidator" runat="server" ControlToValidate="val_variacao_retencaoTextBox"
		                           ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                            Display="Dynamic" ValidationGroup="inserir" />
                            </td>				    

                            <td class="center">
                                <asp:TextBox ID="ind_unidade_variacaoTextBox" runat="server" Text='<%# Bind("ind_unidade_variacao") %>' MaxLength="1" CssClass=""  style="text-align:center" />
                            
                                <asp:RequiredFieldValidator ID="ind_unidade_variacaoValidator" runat="server" ControlToValidate="ind_unidade_variacaoTextBox"
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
                                            <th scope="col" id="Th1" runat="server" style="width:1%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>	
					                        <th scope="col" id="Thind_retencao" runat="server" style="width:7%">IND retencao</th>
					                        <th scope="col" id="Thseq_faixa" runat="server" style="width:7%">Faixa</th>
					                        <th scope="col" id="Thval_media_inicial" runat="server" style="width:7%">Media inicial</th>
					                        <th scope="col" id="Thval_media_final" runat="server" style="width:7%">Media final</th>
					                        <th scope="col" id="Thval_variacao_aviso" runat="server" style="width:7%">Variacao aviso</th>
					                        <th scope="col" id="Thval_variacao_retencao" runat="server" style="width:7%">Variacao retencao</th>
					                        <th scope="col" id="Thind_unidade_variacao" runat="server" style="width:7%">Unidade variacao</th>
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
                                CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()" OnClientClick="return confirmaDelete();" />
                                
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />
                            </td>
        					
                            <td style="text-align:center">
                                <asp:Label ID="ind_retencaoLabel" runat="server" Text='<%# Eval("ind_retencao") %>' />
                            </td>
                            <td style="text-align:center">
                                <asp:Label ID="seq_faixaLabel" runat="server" Text='<%# Eval("seq_faixa") %>' />
                            </td>
                            <td>
                                <asp:Label ID="val_media_inicialLabel" runat="server" Text='<%# Eval("val_media_inicial") %>' />
                            </td>
                            <td>
                                <asp:Label ID="val_media_finalLabel" runat="server" Text='<%# Eval("val_media_final") %>' />
                            </td>
                            <td>
                                <asp:Label ID="val_variacao_avisoLabel" runat="server" Text='<%# Eval("val_variacao_aviso") %>' />
                            </td>
                            <td>
                                <asp:Label ID="val_variacao_retencaoLabel" runat="server" Text='<%# Eval("val_variacao_retencao") %>' />
                            </td>
                            <td style="text-align:center">
                                <asp:Label ID="ind_unidade_variacaoLabel" runat="server" Text='<%# Eval("ind_unidade_variacao") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
                                CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()" OnClientClick="return confirmaDelete();" />
                                
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />
                            </td>
        					
                            <td  style="text-align:center">
                                <asp:Label ID="ind_retencaoLabel" runat="server" Text='<%# Eval("ind_retencao") %>' />
                            </td>
                            <td style="text-align:center">
                                <asp:Label ID="seq_faixaLabel" runat="server" Text='<%# Eval("seq_faixa") %>' />
                            </td>
                            <td>
                                <asp:Label ID="val_media_inicialLabel" runat="server" Text='<%# Eval("val_media_inicial") %>' />
                            </td>
                            <td>
                                <asp:Label ID="val_media_finalLabel" runat="server" Text='<%# Eval("val_media_final") %>' />
                            </td>
                            <td>
                                <asp:Label ID="val_variacao_avisoLabel" runat="server" Text='<%# Eval("val_variacao_aviso") %>' />
                            </td>
                            <td>
                                <asp:Label ID="val_variacao_retencaoLabel" runat="server" Text='<%# Eval("val_variacao_retencao") %>' />
                            </td>
                            <td style="text-align:center">
                                <asp:Label ID="ind_unidade_variacaoLabel" runat="server" Text='<%# Eval("ind_unidade_variacao") %>' />
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
						        CssClass="btSalvar" Onmouseover="Tip('Salvar')" Onmouseout="UnTip()" ValidationGroup="edit" OnClientClick="return confirmaUpdate();"/>

                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel"
						        CssClass="btVoltar" Onmouseover="Tip('Cancelar')" Onmouseout="UnTip()" />
                            </td>
					        <td class="center">
                                <%--<asp:TextBox ID="ind_retencaoTextBox" runat="server" Text='<%# Bind("ind_retencao") %>' ReadOnly="true" CssClass="RO"/>
                            	--%>
                            	<asp:Label ID="ind_retencaoLabel" runat="server" Text='<%# Eval("ind_retencao") %>' style="text-align:center" />			    
<%--                                <asp:RequiredFieldValidator ID="ind_retencaoValidator" runat="server" ControlToValidate="ind_retencaoTextBox"
		                           ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                            Display="Dynamic" ValidationGroup="edit" />--%>
                            </td>                    
		                    <td class="center">
                                <asp:TextBox ID="seq_faixaTextBox" runat="server" Text='<%# Bind("seq_faixa") %>' CssClass="RO"  style="text-align:center"/>
                            			    
                                <asp:RequiredFieldValidator ID="seq_faixaValidator" runat="server" ControlToValidate="seq_faixaTextBox"
		                           ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                            Display="Dynamic" ValidationGroup="edit" />
                            </td>
                            <td class="center">
                                <asp:TextBox ID="val_media_inicialTextBox" runat="server" Text='<%# Bind("val_media_inicial") %>' MaxLength="10" style="text-align:center" />
                            		    
                                <asp:RequiredFieldValidator ID="val_media_inicialValidator" runat="server" ControlToValidate="val_media_inicialTextBox"
		                           ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                            Display="Dynamic" ValidationGroup="edit" />
                            </td>
                            <td class="center">
                                <asp:TextBox ID="val_media_finalTextBox" runat="server" Text='<%# Bind("val_media_final") %>' MaxLength="10" style="text-align:center" />
                            			    
                                <asp:RequiredFieldValidator ID="val_media_finalValidator" runat="server" ControlToValidate="val_media_finalTextBox"
		                           ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                            Display="Dynamic" ValidationGroup="edit" />
                            </td>
                            <td class="center">
                                <asp:TextBox ID="val_variacao_avisoTextBox" runat="server" Text='<%# Bind("val_variacao_aviso") %>' MaxLength="10" style="text-align:center" />
                            			    
                                <asp:RequiredFieldValidator ID="val_variacao_avisoValidator" runat="server" ControlToValidate="val_variacao_avisoTextBox"
		                           ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                            Display="Dynamic" ValidationGroup="edit" />
                            </td>
                            <td class="center">
                                <asp:TextBox ID="val_variacao_retencaoTextBox" runat="server" Text='<%# Bind("val_variacao_retencao") %>' MaxLength="10" style="text-align:center" />
        				    
                                <asp:RequiredFieldValidator ID="val_variacao_retencaoValidator" runat="server" ControlToValidate="val_variacao_retencaoTextBox"
		                           ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                            Display="Dynamic" ValidationGroup="edit" />
                            </td>
                            <td class="center">
                                <asp:TextBox ID="ind_unidade_variacaoTextBox" runat="server" Text='<%# Bind("ind_unidade_variacao") %>' MaxLength="1" style="text-align:center" />
        			    
                                <asp:RequiredFieldValidator ID="ind_unidade_variacaoValidator" runat="server" ControlToValidate="ind_unidade_variacaoTextBox"
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
        					
                            <td style="text-align:center">
                                <asp:Label ID="ind_retencaoLabel" runat="server" Text='<%# Eval("ind_retencao") %>' />
                            </td>
                            <td style="text-align:center">
                                <asp:Label ID="seq_faixaLabel" runat="server" Text='<%# Eval("seq_faixa") %>' />
                            </td>
                            <td>
                                <asp:Label ID="val_media_inicialLabel" runat="server" Text='<%# Eval("val_media_inicial") %>' />
                            </td>
                            <td>
                                <asp:Label ID="val_media_finalLabel" runat="server" Text='<%# Eval("val_media_final") %>' />
                            </td>
                            <td>
                                <asp:Label ID="val_variacao_avisoLabel" runat="server" Text='<%# Eval("val_variacao_aviso") %>' />
                            </td>
                            <td>
                                <asp:Label ID="val_variacao_retencaoLabel" runat="server" Text='<%# Eval("val_variacao_retencao") %>' />
                            </td>
                            <td style="text-align:center">
                                <asp:Label ID="ind_unidade_variacaoLabel" runat="server" Text='<%# Eval("ind_unidade_variacao") %>' />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>
                <asp:ObjectDataSource ID="ObjectDataSource" runat="server" 
                    DataObjectTypeName="Data.Model.ParametroRentencaoONP" DeleteMethod="DeleteParametroRetencao" 
                    InsertMethod="InsertParametroRetencao" SelectMethod="Select" 
                    TypeName="Data.DAL.ParametroRentencaoDAO" UpdateMethod="UpdateParametroRetencao">
                    <UpdateParameters>
                        <asp:FormParameter DbType="Decimal" DefaultValue="0" 
                        FormField="val_variacao_avisoTextBox" Name="val_variacao_aviso" Size="7" 
                        Type="Empty" />
                    </UpdateParameters>
                    <UpdateParameters>
                        <asp:FormParameter DbType="Decimal" DefaultValue="0" 
                        FormField="val_variacao_retencaoTextBox" Name="val_variacao_retencao" Size="7" 
                        Type="Empty" />
                    </UpdateParameters>
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
    