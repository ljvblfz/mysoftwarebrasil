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
<asp:Content ID="Content3" ContentPlaceHolderID="Title" Runat="Server">Coletor</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/wz_tooltip.js" ></script>
    <div class="siteMap">
        <span id="ctl00_ContentPlaceHolder1_Label1">Cadastro &gt;</span>
        <span class="destaqueSiteMap" id="ctl00_ContentPlaceHolder1_Label2">Coletor</span>
    </div>
    <div class="topConteudo">
    </div>
    <div class="bgConteudo">
        <div class="txtPagina">
            <span id="ctl00_ContentPlaceHolder1_Label4"></span>
            <div class="fioTxt">
                <asp:Label ID="LabelDescricaoErro" runat="server" Text="" style="display:none"></asp:Label>
            </div>
            <div class="divTabela" style="height: 300px;"> 
                <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1"
                    InsertItemPosition="LastItem" DataKeyNames="id">
                    <InsertItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                                CssClass="btNovo" Onmouseover="Tip('Inserir')" Onmouseout="UnTip()" ValidationGroup="inserir" OnClientClick="return confirmaInsert();" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel"  
                                CssClass="btApagar" Onmouseover="Tip('Limpar')" Onmouseout="UnTip()"/>                    
                            </td>	
                            <td class="center">
                                <asp:TextBox ID="idTextBox" style="width: 120px;" runat="server" Text='<%# Bind("id") %>' MaxLength="255" />
                            </td>
                            <td class="center">
                                <asp:TextBox ID="modeloTextBox" style="width: 120px;" runat="server" Text='<%# Bind("modelo") %>' MaxLength="255" />
                            </td>
                            <td class="center">
                                <asp:TextBox ID="fabricanteTextBox" style="width: 97px;" runat="server" Text='<%# Bind("fabricante") %>' MaxLength="255" />
                            </td>
                            <td class="center">
                                <asp:TextBox ID="num_serieTextBox" style="width: 97px;" runat="server" Text='<%# Bind("NumSerie") %>' MaxLength="255" />
                            </td>
                            <td class="center">
                                <asp:TextBox ID="codigoTextBox" style="width: 97px;" runat="server" Onkeypress="return OnlyNumber(event);" Text='<%# Bind("codigo") %>' MaxLength="10" />
                            </td>
                        </tr>
                    </InsertItemTemplate>
                    <LayoutTemplate>
                        <table id="Table1" runat="server" style="width:50%;">
                            <tr id="Tr1" runat="server">
                                <td id="Td1" runat="server">
                                    <table ID="itemPlaceholderContainer" runat="server" border="0" class="gridView" style="width:100%">
                                        <tr id="Tr2" runat="server">
                                            <th id="Th1" runat="server" style="width:80px"></th>
                                            <th id="Thcodigo" runat="server">Código interno</th>		
					                        <th id="Thid" runat="server">Identificador</th>
					                        <th id="Thmodelo" runat="server">Modelo</th>
					                        <th id="Thfabricante" runat="server">Fabricante</th>
					                        <th id="Thnum_serie" runat="server">Nº de série</th>
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
                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()"  OnClientClick="return confirmaExcluir();"  />
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()"  />
                            </td>
        					
                            <td class="center">
                                <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                            </td>
                            <td class="center">
                                <asp:Label ID="codigoLabel" runat="server" Text='<%# Eval("codigo") %>' />
                            </td>
                            <td class="center">
                                <asp:Label ID="modeloLabel" runat="server" Text='<%# Eval("modelo") %>' />
                            </td>
                            <td class="center">
                                <asp:Label ID="fabricanteLabel" runat="server" Text='<%# Eval("fabricante") %>' />
                            </td>
                            <td class="center">
                                <asp:Label ID="num_serieLabel" runat="server" Text='<%# Eval("NumSerie") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr>
                            <td>
                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()"  OnClientClick="return confirmaExcluir();"  />
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()"  />
                            </td>
        					
                            <td class="center">
                                <asp:Label ID="idLabel2" runat="server" Text='<%# Eval("id") %>' />
                            </td>
                            <td class="center">
                                <asp:Label ID="codigoLabel2" runat="server" Text='<%# Eval("codigo") %>' />
                            </td>
                            <td class="center">
                                <asp:Label ID="modeloLabel2" runat="server" Text='<%# Eval("modelo") %>' />
                            </td>
                            <td class="center">
                                <asp:Label ID="fabricanteLabel2" runat="server" Text='<%# Eval("fabricante") %>' />
                            </td>
                            <td class="center">
                                <asp:Label ID="num_serieLabel2" runat="server" Text='<%# Eval("NumSerie") %>' />
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
                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" CssClass="btSalvar" Onmouseover="Tip('Salvar')" Onmouseout="UnTip()" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" CssClass="btVoltar" Onmouseover="Tip('Cancelar')" Onmouseout="UnTip()" />
                            </td>	
                            <td class="center">
                                <asp:Label ID="idTextBox" runat="server" Text='<%# Eval("id") %>' />
                            </td>
                            <td class="center">
                                <asp:TextBox ID="codigoTextBox" style="width: 97px;" runat="server" Text='<%# Bind("codigo") %>' MaxLength="10" />
                            </td>
                            <td class="center">
                                <asp:TextBox ID="modeloTextBox" style="width: 120px;" runat="server" Text='<%# Bind("modelo") %>' MaxLength="255" />
                            </td>
                            <td class="center">
                                <asp:TextBox ID="fabricanteTextBox" style="width: 97px;" runat="server" Text='<%# Bind("fabricante") %>' MaxLength="255" />
                            </td>
                            <td class="center">
                                <asp:TextBox ID="num_serieTextBox" style="width: 97px;" runat="server" Text='<%# Bind("NumSerie") %>' MaxLength="255" />
                            </td>
                        </tr>
                    </EditItemTemplate>
                    <SelectedItemTemplate>
                        <tr>
                            <td>
                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" CssClass="btApagar" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()"  OnClientClick="return confirmaExcluir();"  />
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" CssClass="btAtualizar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />
                            </td>
                            <td class="center">
                                <asp:Label ID="idLabel3" runat="server" Text='<%# Eval("id") %>' />
                            </td>
                            <td class="center">
                                <asp:Label ID="codigoLabel3" runat="server" Text='<%# Eval("codigo") %>' />
                            </td>
                            <td class="center">
                                <asp:Label ID="modeloLabel3" runat="server" Text='<%# Eval("modelo") %>' />
                            </td>
                            <td class="center">
                                <asp:Label ID="fabricanteLabel3" runat="server" Text='<%# Eval("fabricante") %>' />
                            </td>
                            <td class="center">
                                <asp:Label ID="num_serieLabel3" runat="server" Text='<%# Eval("NumSerie") %>' />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
                    DataObjectTypeName="SANED_DATA.Model.Coletor" DeleteMethod="Delete"
                    InsertMethod="Insert" SelectMethod="Select"
                    TypeName="SANED_DATA.DAL.ColetorDAO" UpdateMethod="Update">
                </asp:ObjectDataSource>
            </div>   
        </div>
    </div>
    <div class="bottomConteudo">
    </div>
    <div class="bottomPagina">
        <span id="ctl00_ContentPlaceHolder1_Label3">Sistema de Gestão de Saneamento</span>
    </div>
    </div>
</asp:Content>