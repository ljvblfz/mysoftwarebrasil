<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CriarDistribuicao.aspx.cs" Inherits="Gestao_CriarDistribuicao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">

        function VoltarPagina() {
            var referencia = document.getElementById('ctl00_ContentPlaceHolder2_TextBoxReferencia').value;
            location.href = 'Distribuicao.aspx?Referencia=' + referencia;
        }

        function LiberarDistribuicao(rota) {
            var referencia = document.getElementById('<%=TextBoxReferencia.ClientID %>').value;
            var grupo = document.getElementById('<%=TextBoxGrupo.ClientID %>').value;
            location.href = 'CriarDistribuicao.aspx?Referencia=' + referencia + '&rota=' + rota + '&grupo=' + grupo + '&liberarDistribuicao=1';
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
            <h3 class="titForm" style="width:873px;" id="titulo" >Distribuição do grupo</h3>
            <br />
            <%--<span id="ctl00_ContentPlaceHolder1_Label4">Preencha os campos abaixo, para iniciar a pesquisa.</span>--%>
            <div class="fioTxt">
                <asp:Label ID="LabelDescricaoErro" runat="server" Text="" style="display:none"></asp:Label>
                <asp:TextBox ID="Liberar" runat="server" style="display:none;" ></asp:TextBox>
            </div>
            <div id="label">
            </div>
            <div class="divTabela"> 
                <asp:ListView ID="ListView1" runat="server">
                    <LayoutTemplate>
                        <table id="Table1" runat="server" style="width:100%">
                            <tr id="Tr1" runat="server">
                                <td id="Td1" runat="server">
                                    <table ID="itemPlaceholderContainer" runat="server" border="0" class="gridView" style="text-align:center">
                                        <tr id="Tr2" runat="server" style="">
                                            <th id="Th1" runat="server" style="width:10%;">
                                                Roteiro</th>
                                            <th id="Th2" runat="server" style="width:20%;">
                                                Quant matriculas</th>
                                            <th id="Th3" runat="server" style="width:20%;;display:none;">
                                                Data carga</th>
                                            <th id="Th4" runat="server" style="width:20%;;display:none;">
                                                Data Descarga</th>
                                            <th id="Th5" runat="server" style="width:15%;">
                                                Agente</th>
                                            <th id="Th6" runat="server" style="width:15%;">
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
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="text-align:center">
                                <asp:Label ID="LabelRota" runat="server" 
                                    Text='<%# Eval("Rota") %>' />
                            </td>
                            <td style="text-align:center;">
                                <asp:Label ID="LabelQuant_Matricula" runat="server" 
                                    Text='<%# Eval("Quant_Matricula") %>' />
                            </td>
                            <td style="text-align:center;display:none;">
                                <asp:Label ID="LabelData_Carga" runat="server" 
                                    Text='<%# Eval("Data_Carga") %>' />
                            </td>
                            <td style="text-align:center;display:none;">
                                <asp:Label ID="LabelData_Descarga" runat="server" 
                                    Text='<%# Eval("Data_Descarga") %>' />
                            </td>
                            <td style="text-align:center">
                                <asp:DropDownList 
                                    ID="DropDownList1" runat="server" AutoPostBack="false" 
                                    DataSourceID="ObjectDataSource1" DataTextField="nom_agente" 
                                    DataValueField="cod_agente" SelectedValue='<%# Eval("Agente") %>' style="display:block;" >
                                </asp:DropDownList>
                            </td>
                            <td style="text-align:center;" >
<%--                                <input type="button" id="ButonCritica" value="Liberar" onclick="LiberarDistribuicao(<%# Eval("Rota") %>);" 
                                onmouseover="Tip('Liberar distribuição da rota <%# Eval("Rota") %>.')" onmouseout="UnTip()"/>--%>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                <%--<asp:HiddenField ID="hdSituacao" runat="server" Value='<%# Eval("Situacao") %>' />--%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    SelectMethod="ListaAgenteSelect" TypeName="Data.BFL.AgenteFlow">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="grupo" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                
                <asp:TextBox ID="TextBoxReferencia" runat="server" style="display:none" ></asp:TextBox>
                <asp:TextBox ID="TextBoxGrupo" runat="server" style="display:none" ></asp:TextBox>
               
                <div class="fieldLinha3">
                    <asp:Button ID="Button1" runat="server" Text="Atribuir" onclick="Button1_Click" CssClass="btAtualizar" />
                </div>
                <div class="fieldLinha3">
                    <input type="button" onclick="javascript:VoltarPagina();" class="btVoltar" value="Voltar"/>
                </div>
            </div>   
        </div>
    </div>
    <div class="bottomConteudo">
    </div>
    <div class="bottomPagina">
        <span id="ctl00_ContentPlaceHolder1_Label3">Sistema de Gestão de Saneamento</span>
    </div>
</asp:Content>

