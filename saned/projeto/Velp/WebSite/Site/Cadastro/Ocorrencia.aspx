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
    <style>
        
        input
        {
            width:50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Title" Runat="Server">Ocorrencia</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <script language="javascript" type="text/javascript" src="../Script/wz_tooltip.js" ></script>

<div class="siteMap">
    <span id="ctl00_ContentPlaceHolder1_Label1">Cadastro &gt;</span>
    <span class="destaqueSiteMap" id="ctl00_ContentPlaceHolder1_Label2">Ocorrencia</span>
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
                InsertItemPosition="LastItem" DataKeyNames="cod_ocorrencia">                
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
                            <asp:TextBox ID="cod_ocorrenciaTextBox" runat="server" Text='<%# Bind("cod_ocorrencia") %>' MaxLength="10" CssClass="" />
                        
                            <asp:RequiredFieldValidator ID="cod_ocorrenciaValidator" runat="server" ControlToValidate="cod_ocorrenciaTextBox"
		                       ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                        Display="Dynamic" ValidationGroup="inserir" />
                        </td>				    

                        <td>
                            <asp:TextBox ID="des_ocorrenciaTextBox" runat="server" Text='<%# Bind("des_ocorrencia") %>' MaxLength="40" CssClass="" />
                        
                            <asp:RequiredFieldValidator ID="des_ocorrenciaValidator" runat="server" ControlToValidate="des_ocorrenciaTextBox"
		                       ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                        Display="Dynamic" ValidationGroup="inserir" />
                        </td>				    

                        <td>
                            <asp:TextBox ID="des_mensagemTextBox" runat="server" Text='<%# Bind("des_mensagem") %>' MaxLength="40" CssClass="" />
                        
                            <asp:RequiredFieldValidator ID="des_mensagemValidator" runat="server" ControlToValidate="des_mensagemTextBox"
		                       ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                        Display="Dynamic" ValidationGroup="inserir" />
                        </td>				    

                        <td>
                            <asp:TextBox ID="ind_grupoTextBox" runat="server" Text='<%# Bind("ind_grupo") %>' MaxLength="1" CssClass="" />
                        
                            <asp:RequiredFieldValidator ID="ind_grupoValidator" runat="server" ControlToValidate="ind_grupoTextBox"
		                       ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                        Display="Dynamic" ValidationGroup="inserir" />
                        </td>				    

                        <td>
                            <asp:TextBox ID="ind_leituraTextBox" runat="server" Text='<%# Bind("ind_leitura") %>' MaxLength="1" CssClass="" />
                        
                            <asp:RequiredFieldValidator ID="ind_leituraValidator" runat="server" ControlToValidate="ind_leituraTextBox"
		                       ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                        Display="Dynamic" ValidationGroup="inserir" />
                        </td>				    

                        <td>
                            <asp:TextBox ID="ind_consumoTextBox" runat="server" Text='<%# Bind("ind_consumo") %>' MaxLength="2" CssClass="" />
                        
                            <asp:RequiredFieldValidator ID="ind_consumoValidator" runat="server" ControlToValidate="ind_consumoTextBox"
		                       ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                        Display="Dynamic" ValidationGroup="inserir" />
                        </td>				    

                        <td>
                            <asp:TextBox ID="ind_emiteTextBox" runat="server" Text='<%# Bind("ind_emite") %>' MaxLength="1" CssClass="" />
                        
                            <asp:RequiredFieldValidator ID="ind_emiteValidator" runat="server" ControlToValidate="ind_emiteTextBox"
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
                                        <th id="Th1" runat="server" style="width:10%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>	
					                    <th id="Thcod_ocorrencia" runat="server" style="width:10%">Código</th>
					                    <th id="Thdes_ocorrencia" runat="server" style="width:20%">Descrição</th>
					                    <th id="Thdes_mensagem" runat="server" style="width:20%">Mensagem</th>
					                    <th id="Thind_grupo" runat="server" style="width:10%">IND grupo</th>
					                    <th id="Thind_leitura" runat="server" style="width:10%">IND leitura</th>
					                    <th id="Thind_consumo" runat="server" style="width:10%">IND consumo</th>
					                    <th id="Thind_emite" runat="server" style="width:10%">IND emite</th>
                                    </tr>
                                    <tr ID="itemPlaceholder" runat="server"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="Tr3" runat="server" class="paginacao" style="margin-left:95px;">
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
                            CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()"  OnClientClick="return confirmaExcluir();" />
                            
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                            CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />
                        </td>
    					
                        <td style="text-align:center">
                            <asp:Label ID="cod_ocorrenciaLabel" runat="server" Text='<%# Eval("cod_ocorrencia") %>' />
                        </td>
                        <td>
                            <asp:Label ID="des_ocorrenciaLabel" runat="server" Text='<%# Eval("des_ocorrencia") %>' />
                        </td>
                        <td>
                            <asp:Label ID="des_mensagemLabel" runat="server" Text='<%# Eval("des_mensagem") %>' />
                        </td>
                        <td style="text-align:center">
                            <asp:Label ID="ind_grupoLabel" runat="server" Text='<%# Eval("ind_grupo") %>' />
                        </td>
                        <td style="text-align:center">
                            <asp:Label ID="ind_leituraLabel" runat="server" Text='<%# Eval("ind_leitura") %>' />
                        </td>
                        <td style="text-align:center">
                            <asp:Label ID="ind_consumoLabel" runat="server" Text='<%# Eval("ind_consumo") %>' />
                        </td>
                        <td style="text-align:center">
                            <asp:Label ID="ind_emiteLabel" runat="server" Text='<%# Eval("ind_emite") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
                            CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()"  OnClientClick="return confirmaExcluir();" />
                            
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                            CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />
                        </td>
    					
                        <td style="text-align:center">
                            <asp:Label ID="cod_ocorrenciaLabel" runat="server" Text='<%# Eval("cod_ocorrencia") %>' />
                        </td>
                        <td>
                            <asp:Label ID="des_ocorrenciaLabel" runat="server" Text='<%# Eval("des_ocorrencia") %>' />
                        </td>
                        <td>
                            <asp:Label ID="des_mensagemLabel" runat="server" Text='<%# Eval("des_mensagem") %>' />
                        </td>
                        <td style="text-align:center">
                            <asp:Label ID="ind_grupoLabel" runat="server" Text='<%# Eval("ind_grupo") %>' />
                        </td>
                        <td style="text-align:center">
                            <asp:Label ID="ind_leituraLabel" runat="server" Text='<%# Eval("ind_leitura") %>' />
                        </td>
                        <td style="text-align:center">
                            <asp:Label ID="ind_consumoLabel" runat="server" Text='<%# Eval("ind_consumo") %>' />
                        </td>
                        <td style="text-align:center">
                            <asp:Label ID="ind_emiteLabel" runat="server" Text='<%# Eval("ind_emite") %>' />
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
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update"
						    CssClass="btSalvar" Onmouseover="Tip('Salvar')" Onmouseout="UnTip()" 
						    ValidationGroup="edit"   OnClientClick="return confirmaAtualizar();" />

                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel"
						    CssClass="btVoltar" Onmouseover="Tip('Cancelar')" Onmouseout="UnTip()" />
                        </td>
					    <td style="text-align:center">
                            <%--<asp:TextBox ID="cod_ocorrenciaTextBox" runat="server" Text='<%# Bind("cod_ocorrencia") %>' ReadOnly="true" CssClass="RO"/>
                            --%>
                            <asp:Label ID="cod_ocorrenciaLabel" runat="server" Text='<%# Eval("cod_ocorrencia") %>' />
                            <%--<asp:RequiredFieldValidator ID="cod_ocorrenciaValidator" runat="server" ControlToValidate="cod_ocorrenciaTextBox"
		                       ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                        Display="Dynamic" ValidationGroup="edit" />--%>
                        </td>				    

                        <td>
                            <asp:TextBox ID="des_ocorrenciaTextBox" runat="server" Text='<%# Bind("des_ocorrencia") %>' MaxLength="40" CssClass="med3TxtArea" />
                        
                            <asp:RequiredFieldValidator ID="des_ocorrenciaValidator" runat="server" ControlToValidate="des_ocorrenciaTextBox"
		                       ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                        Display="Dynamic" ValidationGroup="edit" />
                        </td>				    

                        <td>
                            <asp:TextBox ID="des_mensagemTextBox" runat="server" Text='<%# Bind("des_mensagem") %>' MaxLength="40" CssClass="med2TxtArea" />
                        
                            <asp:RequiredFieldValidator ID="des_mensagemValidator" runat="server" ControlToValidate="des_mensagemTextBox"
		                       ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                        Display="Dynamic" ValidationGroup="edit" />
                        </td>				    

                        <td style="text-align:center">
                            <asp:TextBox ID="ind_grupoTextBox" runat="server" Text='<%# Bind("ind_grupo") %>' MaxLength="1" style="text-align:center;" />
                        
                            <asp:RequiredFieldValidator ID="ind_grupoValidator" runat="server" ControlToValidate="ind_grupoTextBox"
		                       ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                        Display="Dynamic" ValidationGroup="edit" />
                        </td>				    

                        <td style="text-align:center">
                            <asp:TextBox ID="ind_leituraTextBox" runat="server" Text='<%# Bind("ind_leitura") %>' MaxLength="1" style="text-align:center;" />
                        
                            <asp:RequiredFieldValidator ID="ind_leituraValidator" runat="server" ControlToValidate="ind_leituraTextBox"
		                       ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                        Display="Dynamic" ValidationGroup="edit" />
                        </td>				    
                        
                        <td style="text-align:center">
                            <asp:TextBox ID="ind_consumoTextBox" runat="server" Text='<%# Bind("ind_consumo") %>' MaxLength="2" style="text-align:center;" />
                            
                            <asp:RequiredFieldValidator ID="ind_consumoValidator" runat="server" ControlToValidate="ind_consumoTextBox"
		                       ErrorMessage="<div>o campo não pode estar vazio.</div>" SetFocusOnError="true"
		                        Display="Dynamic" ValidationGroup="edit" />
                        </td>				    
                        
                        <td style="text-align:center">
                            <asp:TextBox ID="ind_emiteTextBox" runat="server" Text='<%# Bind("ind_emite") %>' MaxLength="1" style="text-align:center;" />
                        
                            <asp:RequiredFieldValidator ID="ind_emiteValidator" runat="server" ControlToValidate="ind_emiteTextBox"
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
						    ValidationGroup="edit"   OnClientClick="return confirmaExcluir();"  />

                            <asp:Button ID="EditButton" runat="server" CommandName="Edit"
						    CssClass="btAtualizar"  Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />

                        </td>
    					
                        <td style="text-align:center">
                            <asp:Label ID="cod_ocorrenciaLabel" runat="server" Text='<%# Eval("cod_ocorrencia") %>' />
                        </td>
                        <td>
                            <asp:Label ID="des_ocorrenciaLabel" runat="server" Text='<%# Eval("des_ocorrencia") %>' />
                        </td>
                        <td>
                            <asp:Label ID="des_mensagemLabel" runat="server" Text='<%# Eval("des_mensagem") %>' />
                        </td>
                        <td style="text-align:center">
                            <asp:Label ID="ind_grupoLabel" runat="server" Text='<%# Eval("ind_grupo") %>' />
                        </td>
                        <td style="text-align:center">
                            <asp:Label ID="ind_leituraLabel" runat="server" Text='<%# Eval("ind_leitura") %>' />
                        </td>
                        <td style="text-align:center">
                            <asp:Label ID="ind_consumoLabel" runat="server" Text='<%# Eval("ind_consumo") %>' />
                        </td>
                        <td style="text-align:center">
                            <asp:Label ID="ind_emiteLabel" runat="server" Text='<%# Eval("ind_emite") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>             
            </asp:ListView>
            <asp:ObjectDataSource ID="ObjectDataSource" runat="server" 
                DataObjectTypeName="Data.Model.OcorrenciaTONP" DeleteMethod="DeleteOcorrencia" 
                InsertMethod="InsertOcorrencia" SelectMethod="Select" 
                TypeName="Data.DAL.OcorrenciaTDAO" UpdateMethod="UpdateOcorrencia">
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
    