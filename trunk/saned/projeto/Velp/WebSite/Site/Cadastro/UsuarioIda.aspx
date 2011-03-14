<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>
<script runat="server">
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%--    <script language="javascript" type="text/javascript" src="../Script/jquery-1.4.2.min.js" ></script>
    <script language="javascript" type="text/javascript" src="../Script/jquery.msgbox.min.js" ></script>
    <script language="javascript" type="text/javascript" src="../Script/messagem.js" ></script>--%>
    <script language="javascript" type="text/javascript" src="../Script/comum.js" ></script>
    <script language="javascript" type="text/javascript">

        function confirmaInsert() {
            document.getElementById('ctl00_ContentPlaceHolder2_ListView1_ctrl2_SenhaTextBox').value = document.getElementById('Password1').value;
            return confirm("Deseja inserir o registro?");
        }

        function confirmaDelete() {

            return confirm("Deseja excluir o registro?");
        }

        function confirmaUpdate() {

            return confirm("Deseja alterar o registro?");
        }

        function checar_caps_lock(ev) {
            var e = ev || window.event;
            codigo_tecla = e.keyCode ? e.keyCode : e.which;
            tecla_shift = e.shiftKey ? e.shiftKey : ((codigo_tecla == 16) ? true : false);
            if (((codigo_tecla >= 65 && codigo_tecla <= 90) && !tecla_shift) || ((codigo_tecla >= 97 && codigo_tecla <= 122) && tecla_shift)) {
                document.getElementById('aviso_caps_lock').style.display = 'block';
            }
            else {
                document.getElementById('aviso_caps_lock').style.display = 'none';
            }
        }

        /*
        * Função que abre uma pop up
        */
        function openPopup(cod) {
            window.open('AlterarSenha.aspx?Codigo=' + cod, 'janela', 'width=980, height=300,scrollbars=no');
        }

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Title" Runat="Server">Usuario</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
 <script language="javascript" type="text/javascript" src="../Script/wz_tooltip.js" ></script>
    
    <div class="siteMap">
        <span id="ctl00_ContentPlaceHolder1_Label1">Cadastro</span>
        <span class="destaqueSiteMap" id="ctl00_ContentPlaceHolder1_Label2">Usuario</span>
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
                    InsertItemPosition="LastItem" DataKeyNames="Codigo">
                    <InsertItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert"  
                                CssClass="btNovo" Onmouseover="Tip('Inserir')" Onmouseout="UnTip()" OnClientClick="return confirmaInsert();"/>
                                
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel"  
                                CssClass="btApagar" Onmouseover="Tip('Limpar')" Onmouseout="UnTip()" />
                            </td>
                            <td>
                                <asp:TextBox ID="CodigoTextBox" runat="server" Text='<%# Bind("Codigo") %>' MaxLength="10" style = "display:none;"/>
                                <asp:TextBox ID="NomeTextBox" runat="server" Text='<%# Bind("Nome") %>' MaxLength="30" />
                            </td>
                            <td>
                                <asp:TextBox ID="LoginTextBox" runat="server" Text='<%# Bind("Login") %>' MaxLength="10" />
                            </td>
                            <td>
                                <asp:TextBox ID="SenhaTextBox" TextMode="password" runat="server" Text='<%# Bind("Senha") %>' MaxLength="6" onkeypress="checar_caps_lock(event)" />
                                <span id="aviso_caps_lock" style="display:none;color:Red;">"Parece que a tecla CAPS LOCK está ativa"</span>
                                
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
        									<th id="ThNome" runat="server">Nome</th>
					                        <th id="ThLogin" runat="server">Login</th>
					                        <th id="ThSenha" runat="server">Alterar senha</th>
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
        					<td>
                                <asp:Label ID="CodigoLabel" runat="server" Text='<%# Eval("Codigo") %>' style="display:none" />
                                <asp:Label ID="NomeLabel" runat="server" Text='<%# Eval("Nome") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LoginLabel" runat="server" Text='<%# Eval("Login") %>' />
                            </td>
                            <td>
                                <input type="button" id="AlterarSenha" class="btResenquenciar" onclick="openPopup(<%# Eval("Codigo") %>);" onmouseover="Tip('Alterar senha.')" onmouseout="UnTip()" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
                                CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()" OnClientClick="return confirmaDelete();" />
                                
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />                            </td>
        					
                            <td>
                                <asp:Label ID="CodigoLabel2" runat="server" Text='<%# Eval("Codigo") %>' style="display:none" />
                                <asp:Label ID="NomeLabel2" runat="server" Text='<%# Eval("Nome") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LoginLabel2" runat="server" Text='<%# Eval("Login") %>' />
                            </td>
                            <td>
                                <input type="button" id="AlterarSenha" class="btResenquenciar" onclick="openPopup(<%# Eval("Codigo") %>);" onmouseover="Tip('Alterar senha.')" onmouseout="UnTip()" />
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
                                CssClass="btSalvar" Onmouseover="Tip('Salvar')" Onmouseout="UnTip()" ValidationGroup="edit" OnClientClick="return confirmaUpdater();" />
                                
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                CssClass="btVoltar" Onmouseover="Tip('Cancelar')" Onmouseout="UnTip()" />
                            </td>
        					
                            <td>
                                <asp:TextBox ID="CodigoTextBox2" runat="server" Text='<%# Bind("Codigo") %>' MaxLength="10"  style="display:none" ReadOnly="true"/>
                                <asp:TextBox ID="NomeTextBox2" runat="server" Text='<%# Bind("Nome") %>' MaxLength="30" />
                            </td>
                            <td>
                                <asp:TextBox ID="LoginTextBox2" runat="server" Text='<%# Bind("Login") %>' MaxLength="10" />
                            </td>
                            <td>
                                <input type="button" id="AlterarSenha" class="btResenquenciar" onclick="openPopup(<%# Eval("Codigo") %>);" onmouseover="Tip('Alterar senha.')" onmouseout="UnTip()" />
                            </td>
                        </tr>
                    </EditItemTemplate>
                    <SelectedItemTemplate>
                        <tr>
                            <td>
                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
                                CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()" OnClientClick="return confirmaDelete();" />
                                
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />                            </td>
        					
                            <td>
                                <asp:Label ID="CodigoLabel3" runat="server" Text='<%# Eval("Codigo") %>' style="display:none" />
                                <asp:Label ID="NomeLabel3" runat="server" Text='<%# Eval("Nome") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LoginLabel3" runat="server" Text='<%# Eval("Login") %>' />
                            </td>
                            <td>
                                <input type="button" id="AlterarSenha" class="btResenquenciar" onclick="openPopup(<%# Eval("Codigo") %>);" onmouseover="Tip('Alterar senha.')" onmouseout="UnTip()" />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
                    DataObjectTypeName="Data.Model.UsuarioIda" DeleteMethod="Delete"
                    InsertMethod="InsertUsuario" SelectMethod="Select"
                    TypeName="Data.DAL.UsuarioIdaDAO" UpdateMethod="Update">
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