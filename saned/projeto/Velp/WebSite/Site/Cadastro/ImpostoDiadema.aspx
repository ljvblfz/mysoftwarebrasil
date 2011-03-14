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
        
            return confirm("Deseja insertir o registro?");
        }

        function confirmaEdit(valor) {
        
            var valorAux = parseFloat(valor);
            if (valorAux > 100 || valor < 0) {

                return false;
                
            } else {
                return confirm("Deseja alterar o registro?");
            }
        }


        function confirmaExcluir() {
            
           return confirm("Deseja excluir o registro?");
        }


        function validaPorcentagem(valor, action) {
        
            var valorAux = parseFloat(valor);
            if (valorAux > 100 || valor < 0) {

                if (action == "insert") {
                    document.getElementById('val_porcentagemValidator_insert').style.display = '';
                } else {
                    document.getElementById('val_porcentagemValidator_edit').style.display = '';
                }
            } else {
                if (action == "insert") {
                    document.getElementById('val_porcentagemValidator_insert').style.display = "none";
                } else {
                    document.getElementById('val_porcentagemValidator_edit').style.display = 'none';
                }
            }
            //valor = formataMilhar(valor,2);
            return valor;
        }
        
    </script>
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" Runat="Server">Categoria</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    
    <script language="javascript" type="text/javascript" src="../Script/wz_tooltip.js" ></script>
    <div class="siteMap">
        <span id="ctl00_ContentPlaceHolder1_Label1">Cadastro &gt;</span>
        <span class="destaqueSiteMap" id="ctl00_ContentPlaceHolder1_Label2">Imposto diadema</span>
    </div>
    <div class="topConteudo">
    </div>
    <div class="bgConteudo">
        <div class="txtPagina">
            <span id="ctl00_ContentPlaceHolder1_Label4"></span>
            <div class="fioTxt">
                <asp:Label ID="LabelDescricaoErro" runat="server" Text="" style="display:none"></asp:Label>
            </div>  
            <div class="divTabela" style="height:auto">
                <asp:ListView ID="ListView1" runat="server" 
                DataSourceID="ObjectDataSource1" InsertItemPosition="LastItem" DataKeyNames="cod_imposto">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Button ID="DeleteButton" runat="server" 
                                    CommandName="Delete" CssClass="btApagar" Onmouseover="Tip('Excluir')" 
                                    Onmouseout="UnTip()" OnClientClick="return confirmaExcluir();" 
                                 />
                                
                                <asp:Button ID="EditButton" runat="server" 
                                    CommandName="Edit" CssClass="btAtualizar" Onmouseover="Tip('Editar')" 
                                    Onmouseout="UnTip()" 
                                />   
                            </td>
                            <td>
                                <asp:Label ID="cod_impostoLabel" runat="server" 
                                    Text='<%# Eval("cod_imposto") %>' />
                            </td>
                            <td>
                                <asp:Label ID="val_porcentagemLabel" runat="server" 
                                    Text='<%# Eval("val_porcentagem") %>' />
                            </td>

                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
                                    CssClass="btApagar" ToolTip="Excluir" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()" OnClientClick="return confirmaExcluir();" />
                                    
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                    CssClass="btAtualizar" ToolTip="Editar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />
                            </td>
                            <td>
                                <asp:Label ID="cod_impostoLabel" runat="server" 
                                    Text='<%# Eval("cod_imposto") %>' />
                            </td>
                            <td>
                                <asp:Label ID="val_porcentagemLabel" runat="server" 
                                    Text='<%# Eval("val_porcentagem") %>' />
                            </td>

                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        <table runat="server" style="">
                            <tr>
                                <td>
                                    Nenhum dado foi retornado.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                        <tr>
                        
                            <td>
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                                CssClass="btNovo" Onmouseover="Tip('Inserir')" Onmouseout="UnTip()" ValidationGroup="inserir" OnClientClick="return confirmaInsert();" />
                                
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel"  
                                CssClass="btApagar" Onmouseover="Tip('Limpar')" Onmouseout="UnTip()"/>
                            </td>
                            <td>
                                <asp:TextBox ID="cod_impostoTextBox" runat="server" 
                                    Text='<%# Bind("cod_imposto") %>' CssClass="" MaxLength="16" />
                                
                                <asp:RequiredFieldValidator ID="cod_impostoValidator" runat="server" ControlToValidate="cod_impostoTextBox"
                                   ErrorMessage="<br>A categoria não pode estar vazia." SetFocusOnError="true"
                                    Display="Dynamic" ValidationGroup="inserir" />
                                    
                            </td>
                            <td>
                            
                                <asp:TextBox ID="val_porcentagemTextBox" runat="server" 
                                    Text='<%# Bind("val_porcentagem") %>' 
                                    CssClass="" MaxLength="7" OnChange = "this.value = validaPorcentagem(this.value,'insert');" />
                                
                                <asp:RequiredFieldValidator ID="val_porcentagemValidator" runat="server" ControlToValidate="val_porcentagemTextBox"
                                   ErrorMessage="<br>A categoria não pode estar vazia." SetFocusOnError="true"
                                    Display="Dynamic" ValidationGroup="inserir" />
                                <span id="val_porcentagemValidator_insert" style= " color: Red; display:none;"><br />O valor deve estar entre 0 e 100.</span>  
                            </td>
                        </tr>
                    </InsertItemTemplate>
                    <LayoutTemplate>
                        <table runat="server" style="width:100%">
                            <tr runat="server">
                                <td runat="server">
                                    <table ID="itemPlaceholderContainer" runat="server" border="0" class="gridView">
                                        <tr runat="server" style="">
                                            <th runat="server" style="width:10%"></th>
                                            <th runat="server" style="width:50%">Imposto</th>
                                            <th runat="server" style="width:40%">Porcentagem</th>
                                        </tr>
                                        <tr ID="itemPlaceholder" runat="server"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server" class="paginacao">
                                <td runat="server">
                                    <asp:DataPager ID="DataPager1" runat="server">
                                        <Fields>
                                            <asp:NumericPagerField />
                                        </Fields>
                                    </asp:DataPager>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <EditItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                                    CssClass="btSalvar" ToolTip="Salvar" 
                                    Onmouseover="Tip('Salvar')" Onmouseout="UnTip()" OnClientClick="return confirmaEdit(document.getElementById('ctl00_ContentPlaceHolder2_ListView1_ctrl4_val_porcentagemTextBox').value);" />
                                    
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                    CssClass="btVoltar" ToolTip="Cancelar" 
                                    Onmouseover="Tip('Cancelar')" Onmouseout="UnTip()" />
                            </td>
                            <td>
<%--                                <asp:TextBox ID="cod_impostoTextBox" runat="server" 
                                    Text='<%# Bind("cod_imposto") %>' ReadOnly="true" 
                                    CssClass="RO" />--%>
                                   <asp:Label ID="cod_impostoLabel" runat="server" 
                                    Text='<%# Eval("cod_imposto") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="val_porcentagemTextBox" runat="server" 
                                    Text='<%# Bind("val_porcentagem") %>' MaxLength="7" 
                                    CssClass="" OnChange = "this.value = validaPorcentagem(this.value,'edit');" />
                                                        
                                <asp:RequiredFieldValidator ID="val_porcentagemValidator2" runat="server" ControlToValidate="val_porcentagemTextBox"
                                   ErrorMessage="<br>A categoria não pode estar vazia." SetFocusOnError="true"
                                    Display="Dynamic" ValidationGroup="inserir"  />
                                 <span id="val_porcentagemValidator_edit" style= " color: Red; display:none;"><br />O valor deve estar entre 0 e 100.</span>  
         
                            </td>

                        </tr>
                    </EditItemTemplate>
                    <SelectedItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
                                CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()" OnClientClick="return confirmaExcluir();" />
                                    
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />
                            </td>
                            <td>
                                <asp:Label ID="cod_impostoLabel" runat="server" 
                                    Text='<%# Eval("cod_imposto") %>' />
                            </td>
                            <td>
                                <asp:Label ID="val_porcentagemLabel" runat="server" 
                                    Text='<%# Eval("val_porcentagem") %>' />
                            </td>

                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    DeleteMethod="DeleteImposto" InsertMethod="InsertImposto" SelectMethod="Select" 
                    TypeName="Data.DAL.ImpostoDiademaDAO" UpdateMethod="UpdateImposto" 
                DataObjectTypeName="Data.Model.ImpostoDiademaONP" ConvertNullToDBNull="True">
                    <UpdateParameters>
                        <asp:FormParameter DbType="Decimal" DefaultValue="0" 
                            FormField="val_porcentagemTextBox" Name="val_porcentagem" Size="7" 
                            Type="Empty" />
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

