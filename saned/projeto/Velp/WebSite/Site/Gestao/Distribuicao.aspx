<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Distribuicao.aspx.cs" Inherits="Gestao_Distribuicao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/comum.js" ></script>
    <script type="text/javascript">

        function CriarDistribuicao(grupo, distribuicaoLiberada) {
            try {
                var referencia = document.getElementById('ctl00_ContentPlaceHolder2_referencia').value;
                location.href = 'CriarDistribuicao.aspx?Grupo=' + grupo + '&Referencia=' + referencia + "&Liberar=" + distribuicaoLiberada;
            }
            catch (e) {
            }
        }

        function LiberarDistribuicao(grupo, distribuicaoLiberada) {
            try {
                var isValid = ValidaLiberacao(grupo);

                if (isValid && distribuicaoLiberada != "Liberada") {
                    var referencia = document.getElementById('ctl00_ContentPlaceHolder2_referencia').value;
                    location.href = 'Distribuicao.aspx?Grupo=' + grupo + '&Liberar=true&Referencia=' + referencia;
                } else {
                    alert('Não e possivel liberar distribuição.');
                }
            }
            catch (e) {
            }
        }

        function ValidaLiberacao(grupo) {
            var retorno = true;
            try {

                var quantidade_roteiro = document.getElementById('ctl00_ContentPlaceHolder2_ListView1_ctrl' + (grupo - 1) + '_Quantidade_RoteiroLabel').innerHTML;
                var quantidade_distribuido = document.getElementById('ctl00_ContentPlaceHolder2_ListView1_ctrl' + (grupo - 1) + '_Quantidade_DistribuidoLabel').innerHTML;
                if (quantidade_roteiro != quantidade_distribuido) {

                    retorno = false;
                }
            }
            catch (e) {
            }
            return retorno;
        }

        function Acompanhamento(grupo) {
            try {
                var referencia = document.getElementById('<%=referencia.ClientID %>').value;
                location.href = 'Acompanhamento.aspx?Grupo=' + grupo + '&Referencia=' + referencia;
            }
            catch (e) {
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<script id="Script1" language="javascript" type="text/javascript" src="../Script/wz_tooltip.js" ></script>   
    <div class="siteMap">
        <span id="ctl00_ContentPlaceHolder1_Label1">Distribuição &gt;</span>
<%--        <span class="destaqueSiteMap" id="ctl00_ContentPlaceHolder1_Label2">Categoria</span>--%>
    </div>
    <div class="topConteudo">
    </div>
    <div class="bgConteudo">
        <div class="txtPagina">
            <h3 class="titForm" style="width:873px;">Distribuição</h3>
            <br />
            <span id="ctl00_ContentPlaceHolder1_Label4">Preencha os campos abaixo, para iniciar a pesquisa.</span>
            <div class="fioTxt">
                <asp:Label ID="LabelDescricaoErro" runat="server" Text="" style="display:none"></asp:Label>
            </div>
            <div id="label">
  
                <div class="fieldLinha3">
                    <div class="fieldLinha3">
                        <asp:Label ID="Labelreferencia" runat="server" Text="Referencia"></asp:Label>
                    </div>
<%--                     <div class="fieldLinha3">
                        <select id="referenciaAux" name="referenciaAux" style="display:block" onchange="javascript:document.getElementById('<%=referencia.ClientID %>').value = this.value;">
	                        <option value="<%Response.Write(DateTime.Now.Month-3 + "/" + DateTime.Now.Year);%>"><%Response.Write(DateTime.Now.Month-3 + "/" + DateTime.Now.Year);%></option>
	                        <option value="<%Response.Write(DateTime.Now.Month-2 + "/" + DateTime.Now.Year);%>"><%Response.Write(DateTime.Now.Month-2 + "/" + DateTime.Now.Year);%></option>
	                        <option value="<%Response.Write(DateTime.Now.Month-1 + "/" + DateTime.Now.Year);%>"><%Response.Write(DateTime.Now.Month-1 + "/" + DateTime.Now.Year);%></option>
                            <option value="<%Response.Write(DateTime.Now.Month + "/" + DateTime.Now.Year);%>" selected="selected"><%Response.Write(DateTime.Now.Month + "/" + DateTime.Now.Year);%></option>
	                        <option value="" selected="selected">Selecione</option>
	                    </select>
                     </div>--%>
                     <div class="fieldLinha3" style="display:block;">
                        <asp:Label ID="LabelErroReferencia" runat="server" Text="*" style="display:none;color:Red;"></asp:Label>
                        <asp:TextBox ID="referencia" runat="server" CssClass="center" style="width: 80px;" Onkeyup="return mascara(this,event,'##/####');" onkeypress="return OnlyNumber(event);" ></asp:TextBox>
                    </div>
                </div>
                <div class="fieldLinha3">
                    <asp:Button ID="Button2" runat="server" Text="Pesquisar" onclick="Button2_Click" CssClass="btPesquisar"/>   
                </div>
                <div id="divMensagem" class="fieldLinha" style="display:none;text-align:center; margin: 1px 0 1px 0;border: 1px dotted #FF0000;height: 24px;">
                        <span id="mensagem" style="color:#FF0000;top:25%;position: relative;font-weight: bold;"></span>
                </div>
            </div>
            <div class="divTabela"> 
                <asp:ListView ID="ListView1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align:center">
                                <asp:Label ID="GrupoLabel" runat="server" Text='<%# Eval("Grupo") %>' />
                            </td>
                            
                            <td style="text-align:center">
                                <asp:Label ID="Quantidade_RoteiroLabel" runat="server" 
                                    Text='<%# Eval("Quantidade_Roteiro") %>' />
                            </td>
                            
                            <td style="text-align:center">
                                <asp:Label ID="Quantidade_DescargaLabel" runat="server" 
                                    Text='<%# Eval("Quantidade_Descarga") %>' />
                            </td>
                            
                            <td style="text-align:center">
                                <asp:Label ID="Quantidade_DistribuidoLabel" runat="server" 
                                    Text='<%# Eval("Quantidade_Distribuido") %>' />
                            </td>
                            <td style="text-align:center">
                                <input type="button" id="Button1" class="btSinc2" onclick="Acompanhamento(<%# Eval("Grupo") %>);" 
                                onmouseover="Tip('Abrir tela de acompanhamento do grupo: <%# Eval("Grupo") %>.')" onmouseout="UnTip()"/>
                            </td>
                            <td style="text-align:center">
                                <input type="button" id="Button3" class="btOK" onclick="CriarDistribuicao(<%# Eval("Grupo") %>,'<%# Eval("Situacao") %>');" 
                                onmouseover="Tip('Criar distribuição para o grupo <%# Eval("Grupo") %>.')" onmouseout="UnTip()"/>
                            </td>
                            <td style="text-align:center;display:none;" >
                                <input type="button" id="ButonCritica" class="btBloquear" value="" onclick="LiberarDistribuicao(<%# Eval("Grupo") %>,'<%# Eval("Situacao") %>');" 
                                onmouseover="Tip('Liberar distribuição do grupo <%# Eval("Grupo") %>.')" onmouseout="UnTip()"/>
                                <input type="text" id="situacao" style="display:none;" value="<%# Eval("Situacao") %>" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr>
                            <td style="text-align:center">
                                <asp:Label ID="GrupoLabel" runat="server" Text='<%# Eval("Grupo") %>' />
                            </td>
                            
                            <td style="text-align:center">
                                <asp:Label ID="Quantidade_RoteiroLabel" runat="server" 
                                    Text='<%# Eval("Quantidade_Roteiro") %>' />
                            </td>
                            
                            <td style="text-align:center">
                                <asp:Label ID="Quantidade_DescargaLabel" runat="server" 
                                    Text='<%# Eval("Quantidade_Descarga") %>' />
                            </td>
                            
                            <td style="text-align:center">
                                <asp:Label ID="Quantidade_DistribuidoLabel" runat="server" 
                                    Text='<%# Eval("Quantidade_Distribuido") %>' />
                            </td>
                            <td style="text-align:center">
                                <input type="button" id="Button1" class="btSinc2" onclick="Acompanhamento(<%# Eval("Grupo") %>);" 
                                onmouseover="Tip('Abrir tela de acompanhamento do grupo: <%# Eval("Grupo") %>.')" onmouseout="UnTip()"/>
                            </td>
                            <td style="text-align:center">
                                <input type="button" id="Button3" class="btOK" onclick="CriarDistribuicao(<%# Eval("Grupo") %>,'<%# Eval("Situacao") %>');" 
                                onmouseover="Tip('Criar distribuição para o grupo <%# Eval("Grupo") %>.')" onmouseout="UnTip()"/>
                            </td>
                            <td style="text-align:center;display:none;" >
                                <input type="button" id="ButonCritica" class="btBloquear" value="" onclick="LiberarDistribuicao(<%# Eval("Grupo") %>,'<%# Eval("Situacao") %>');" 
                                onmouseover="Tip('Liberar distribuição do grupo <%# Eval("Grupo") %>.')" onmouseout="UnTip()"/>
                                <input type="text" id="situacao" style="display:none;" value="<%# Eval("Situacao") %>" />
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        <table id="Table1" runat="server" style="width:100%">
                            <tr id="Tr1" runat="server">
                                <td id="Td1" runat="server">
                                    <table ID="itemPlaceholderContainer" runat="server" border="0" class="gridView" style="text-align:center">
                                        <tr id="Tr2" runat="server" style="">
                                            <th id="Th1" runat="server" style="width:10%;">
                                                Grupo</th>
                                            <th id="Th2" runat="server" style="width:20%;">
                                                Quant Roteiro</th>
                                            <th id="Th3" runat="server" style="width:20%;">
                                                Quant Descarga</th>
                                            <th id="Th4" runat="server" style="width:20%;">
                                                Quant Distribuido</th>
                                            <th id="Th7" runat="server" style="width:15%;">
                                                Acompanhamento</th>
                                            <th id="Th5" runat="server" style="width:15%;">
                                                Distribuir</th>
                                            <th id="Th6" runat="server" style="width:15%;display:none;" >
                                                Liberar</th>
                                        </tr>
                                        <tr ID="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr3" runat="server">
                                <td id="Td2" runat="server" style="">
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                        <tr>
                            <td style="text-align:center">
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                                    Text="Inserir" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                    Text="Limpar" />
                            </td>
                            
                            <td style="text-align:center">
                                <asp:TextBox ID="GrupoTextBox" runat="server" Text='<%# Bind("Grupo") %>' />
                            </td>
                            
                            <td style="text-align:center">
                                <asp:TextBox ID="Quantidade_RoteiroTextBox" runat="server" 
                                    Text='<%# Bind("Quantidade_Roteiro") %>' />
                            </td>
                            
                            <td style="text-align:center">
                                <asp:TextBox ID="Quantidade_DescargaTextBox" runat="server" 
                                    Text='<%# Bind("Quantidade_Descarga") %>' />
                            </td>
                            
                            <td style="text-align:center">
                                <asp:TextBox ID="Quantidade_DistribuidoTextBox" runat="server" 
                                    Text='<%# Bind("Quantidade_Distribuido") %>' />
                            </td>
                        </tr>
                    </InsertItemTemplate>
                    <LayoutTemplate>
                        <table runat="server" style="width:100%">
                            <tr runat="server">
                                <td runat="server">
                                    <table ID="itemPlaceholderContainer" runat="server" border="0" class="gridView" style="text-align:center">
                                        <tr runat="server" style="">
                                            <th id="Th1" runat="server" style="width:10%;">
                                                Grupo</th>
                                            <th id="Th2" runat="server" style="width:20%;">
                                                Quant Roteiro</th>
                                            <th id="Th3" runat="server" style="width:20%;">
                                                Quant Descarga</th>
                                            <th id="Th4" runat="server" style="width:20%;">
                                                Quant Distribuido</th>
                                            <th id="Th7" runat="server" style="width:15%;">
                                                Acompanhamento</th>
                                            <th id="Th5" runat="server" style="width:15%;">
                                                Distribuir</th>
                                            <th id="Th6" runat="server" style="width:15%;display:none;" >
                                                Liberar</th>
                                        </tr>
                                        <tr ID="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" style="">
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <EditItemTemplate>
                        <tr>
                            <td style="text-align:center">
                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                                    Text="Atualizar" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                    Text="Cancelar" />
                            </td>
                            
                            <td style="text-align:center">
                                <asp:TextBox ID="GrupoTextBox" runat="server" Text='<%# Bind("Grupo") %>' />
                            </td>
                            
                            <td style="text-align:center">
                                <asp:TextBox ID="Quantidade_RoteiroTextBox" runat="server" 
                                    Text='<%# Bind("Quantidade_Roteiro") %>' />
                            </td>
                            
                            <td style="text-align:center">
                                <asp:TextBox ID="Quantidade_DescargaTextBox" runat="server" 
                                    Text='<%# Bind("Quantidade_Descarga") %>' />
                            </td>
                            
                            <td style="text-align:center">
                                <asp:TextBox ID="Quantidade_DistribuidoTextBox" runat="server" 
                                    Text='<%# Bind("Quantidade_Distribuido") %>' />
                            </td>
                        </tr>
                    </EditItemTemplate>
                    <SelectedItemTemplate>
                        <tr>
                            <td style="text-align:center">
                                <asp:Label ID="GrupoLabel" runat="server" Text='<%# Eval("Grupo") %>' />
                            </td>
                            
                            <td style="text-align:center">
                                <asp:Label ID="Quantidade_RoteiroLabel" runat="server" 
                                    Text='<%# Eval("Quantidade_Roteiro") %>' />
                            </td>
                            
                            <td style="text-align:center">
                                <asp:Label ID="Quantidade_DescargaLabel" runat="server" 
                                    Text='<%# Eval("Quantidade_Descarga") %>' />
                            </td>
                            
                            <td style="text-align:center">
                                <asp:Label ID="Quantidade_DistribuidoLabel" runat="server" 
                                    Text='<%# Eval("Quantidade_Distribuido") %>' />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>
<%--                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    SelectMethod="Lista" TypeName="Data.BFL.DistribuicaoGridFlow">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1/1/1800" Name="Referencia" Type="DateTime" />
                    </SelectParameters>
                </asp:ObjectDataSource>--%>
            </div>   
        </div>
    </div>
    <div class="bottomConteudo">
    </div>
    <div class="bottomPagina">
        <span id="ctl00_ContentPlaceHolder1_Label3">Sistema de Gestão de Saneamento</span>
    </div>
    <script type="text/javascript">

            function domRead() {

                if (document.readyState == "complete") {
                    try {
                        var rows = document.getElementById('ctl00_ContentPlaceHolder2_ListView1_itemPlaceholderContainer').getElementsByTagName('tr');
                        var numeroLinhas = rows.length;
                        for (var i = 0; i < numeroLinhas; i++) {
                            if (i > 0) {
                                var obj = rows[i].getElementsByTagName('td');
                                if (obj.length >= 6) {
                                    var input = obj[6].getElementsByTagName('input');
                                    var input2 = obj[4].getElementsByTagName('input');
                                    if (input != null && input.length >= 1) {
                                        if (input[1].value != "Bloqueada") {
                                            //input[0].disabled = true;
                                        }
                                        else {
                                            input[0].className = "btLiberar";
                                        }
                                        if (input2 != null) {
                                            if (input[1].value == "Carregada" || input[1].value == "Descarregada") {
                                                input2[0].className = "btSinc";
                                            }
                                        }
                                    }
                                }
                            }
                        } 
                    }
                    catch (e) {
                    }
                } else {
                    domRead();
                }
            }
            
            try {
                setTimeout(domRead, 1000);
            }
            catch (e) {
            }
    </script>
</asp:Content>

