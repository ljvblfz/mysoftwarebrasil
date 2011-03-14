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

        function validaDesconto(valor) {

            if (valor > 999.999) {
                document.getElementById("erro_val_valor_desconto").style.display = "block";
            } else {
                document.getElementById("erro_val_valor_desconto").style.display = "none";
            }
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Title" Runat="Server">Desconto Diadema</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <script language="javascript" type="text/javascript" src="../Script/wz_tooltip.js" ></script>
    
     <div class="siteMap">
        <span id="ctl00_ContentPlaceHolder1_Label1">Cadastro &gt;</span>
        <span class="destaqueSiteMap" id="ctl00_ContentPlaceHolder1_Label2">Desconto diadema</span>
    </div>
    <div class="topConteudo">
    </div>
    <div class="bgConteudo">
        <div class="txtPagina">
            <span id="ctl00_ContentPlaceHolder1_Label4"></span>
            <div class="fioTxt">
                <asp:Label ID="LabelDescricaoErro" runat="server" Text="" style="display:none"></asp:Label>
            </div>
            <div id="label"></div>  
            <div class="divTabela" style="height:auto">
                <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" 
                    InsertItemPosition="LastItem" ItemContainerID="layoutTemplate" 
                    DataKeyNames="seq_desconto">
                    <InsertItemTemplate>
                        <tr>
                            <td>
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                                CssClass="btNovo" Onmouseover="Tip('Inserir')" Onmouseout="UnTip()" 
                                ValidationGroup="inserir" OnClientClick="return confirmaInsert();" />
                                
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel"  
                                CssClass="btApagar" Onmouseover="Tip('Limpar')" Onmouseout="UnTip()"/>
                            </td>
                            <td  style="text-align:center">
                                <asp:TextBox ID="seq_descontoTextBox" runat="server" CssClass="center"
                                    Text='<%# Bind("seq_desconto") %>'  
                                    MaxLength="3"  Onkeypress="return OnlyNumber(event);" ValidationGroup="insert" />
                                    
                                <asp:RequiredFieldValidator ID="seq_descontoValidator" runat="server" 
                                    ControlToValidate="seq_descontoTextBox"
                                    ErrorMessage="<div>A categoria não pode estar vazia.</div>" SetFocusOnError="true"
                                    Display="Dynamic" ValidationGroup="inserir" /> 
                            </td>
                            <td  style="text-align:center">
                                <asp:DropDownList ID="DropDownListTipo" runat="server">
                                </asp:DropDownList>
                                <asp:TextBox ID="ind_tipo_descontoTextBox" runat="server" 
                                    Text='<%# Bind("ind_tipo_desconto") %>' 
                                    MaxLength="1"  Onkeypress="return OnlyNumber(event);" />
                            </td>
                            <td>
                                <asp:TextBox ID="val_limite_inicialTextBox" runat="server" 
                                    Text='<%# Bind("val_limite_inicial") %>' CssClass="center"
                                    MaxLength="7"  Onkeypress="return OnlyNumber(event);" />
                            </td>
                            <td>
                                <asp:TextBox ID="val_valor_descontoTextBox" runat="server" 
                                    Text='<%# Bind("val_valor_desconto") %>' CssClass=""
                                    MaxLength="9"  Onkeypress="return OnlyNumber(event);" />
                            </td>

                        </tr>
                    </InsertItemTemplate>
                    <LayoutTemplate>
                        <table id="Table1" runat="server" style="width:100%">
                            <tr id="Tr1" runat="server">
                                <td id="Td1" runat="server">
                                    <table ID="itemPlaceholderContainer" runat="server" border="0" class="gridView">
                                        <tr id="Tr2" runat="server" style="">
                                            <th id="Th1" runat="server" style="width:10%">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                            <th id="Th2" runat="server" style="width:10%">
                                                Código</th>
                                            <th id="Th3" runat="server" style="width:30%">
                                                Tipo desconto</th>
                                            <th id="Th4" runat="server" style="width:20%">
                                                Limite inicial</th>
                                            <th id="Th5" runat="server" style="width:30%">
                                                Valor desconto</th>

                                        </tr>
                                        <tr ID="itemPlaceholder" runat="server">
                                        </tr>
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
                                CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()"  OnClientClick="return confirmaExcluir();" />
                                
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit"  
                                CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />
                            </td>
                            <td style="text-align:center">
                                <asp:Label ID="Código" runat="server" 
                                    Text='<%# Eval("seq_desconto") %>' />
                            </td>
                            <td style="text-align:center">
                                <asp:Label ID="ind_tipo_descontoLabel" runat="server" 
                                    Text='<%# Eval("ind_tipo_desconto") %>' />
                            </td>
                            <td  style="text-align:center">
                                <asp:Label ID="val_limite_inicialLabel" runat="server" 
                                    Text='<%# Eval("val_limite_inicial") %>' />
                            </td>
                            <td>
                                <asp:Label ID="val_valor_descontoLabel" runat="server" 
                                    Text='<%# Eval("val_valor_desconto") %>' />
                            </td>

                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr>
                            <td>
                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
                                CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()" OnClientClick="return confirmaExcluir();"  />
                                
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />
                            </td>
                            <td  style="text-align:center">
                                <asp:Label ID="seq_descontoLabel" runat="server" 
                                    Text='<%# Eval("seq_desconto") %>' />
                            </td>
                            <td style="text-align:center">
                                <asp:Label ID="ind_tipo_descontoLabel" runat="server" 
                                    Text='<%# Eval("ind_tipo_desconto") %>' />
                            </td>
                            <td  style="text-align:center">
                                <asp:Label ID="val_limite_inicialLabel" runat="server" 
                                    Text='<%# Eval("val_limite_inicial") %>' />
                            </td>
                            <td>
                                <asp:Label ID="val_valor_descontoLabel" runat="server" 
                                    Text='<%# Eval("val_valor_desconto") %>' />
                            </td>

                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        <table id="Table1" runat="server">
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
                                CssClass="btSalvar" Onmouseover="Tip('Salvar')" Onmouseout="UnTip()"  OnClientClick="return confirmaAtualizacao();" />
                                
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                CssClass="btVoltar" Onmouseover="Tip('Cancelar')" Onmouseout="UnTip()" />
                            </td>
                            <td  style="text-align:center">
                            
                                <asp:Label ID="seq_descontoLabel" runat="server" 
                                    Text='<%# Eval("seq_desconto") %>' />
                                    
<%--                                <asp:TextBox ID="seq_descontoTextBox" runat="server" 
                                    Text='<%# Bind("seq_desconto") %>' CssClass="" 
                                    ReadOnly="true" />--%>
                            </td>
                            <td style="text-align:center">
                                <asp:TextBox ID="ind_tipo_descontoTextBox" runat="server" 
                                    Text='<%# Bind("ind_tipo_desconto") %>' CssClass="" 
                                    MaxLength="1"  Onkeypress="return OnlyNumber(event);"  />
                            </td>
                            <td  style="text-align:center">
                                <asp:TextBox ID="val_limite_inicialTextBox" runat="server" 
                                    Text='<%# Bind("val_limite_inicial") %>' CssClass="" 
                                    MaxLength="7"  Onkeypress="return OnlyNumber(event);"  />
                            </td>
                            <td>
                                <asp:TextBox ID="val_valor_descontoTextBox" runat="server" 
                                    Text='<%# Bind("val_valor_desconto") %>' MaxLength="9"  
                                    Onkeypress="return OnlyNumber(event);" onchange="validaDesconto(this.value);" />
                                    
                                <span id="erro_val_valor_desconto" style="display:none;color:Red;">Valor ultrapasa o limite.</span>
                            </td>

                        </tr>
                    </EditItemTemplate>
                    <SelectedItemTemplate>
                        <tr>
                            <td>
                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
                                CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()" OnClientClick="return confirmaExcluir();" />
                                
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()"/>
                            </td>
                            <td  style="text-align:center">
                                <asp:Label ID="seq_descontoLabel" runat="server" 
                                    Text='<%# Eval("seq_desconto") %>' />
                            </td>
                            <td>
                                <asp:Label ID="ind_tipo_descontoLabel" runat="server" 
                                    Text='<%# Eval("ind_tipo_desconto")%>' />
                            </td>
                            <td  style="text-align:center">
                                <asp:Label ID="val_limite_inicialLabel" runat="server" 
                                    Text='<%# Eval("val_limite_inicial") %>' />
                            </td>
                            <td>
                                <asp:Label ID="val_valor_descontoLabel" runat="server" 
                                    Text='<%# Eval("val_valor_desconto") %>' />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    DataObjectTypeName="Data.Model.DescontoDiademaONP" DeleteMethod="DeleteDesconto" 
                    InsertMethod="InsertDesconto" SelectMethod="Select" 
                    TypeName="Data.DAL.DescontoDiademaDAO" UpdateMethod="UpdateDesconto" 
                    ConvertNullToDBNull="True">
                    <UpdateParameters>
                        <asp:Parameter DbType="Decimal" Name="val_valor_desconto" Size="9" />
                    </UpdateParameters>
                </asp:ObjectDataSource>  
            </div>
        </div>
    </div>
    <div class="bottomConteudo"></div>
    <div class="bottomPagina">
        <span id="ctl00_ContentPlaceHolder1_Label3">Sistema de Gestão de Saneamento</span>
    </div>

</asp:Content>

