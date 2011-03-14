<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="Index.aspx.cs" Inherits="Relatorio_Critica_Default"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%--    <script language="javascript" type="text/javascript" src="../Script/jquery-1.4.2.min.js" ></script>
    <script language="javascript" type="text/javascript" src="../Script/jquery.msgbox.min.js" ></script>
    <script language="javascript" type="text/javascript" src="../Script/messagem.js" ></script>--%>
    <script language="javascript" type="text/javascript" src="../../Script/comum.js" ></script>
    <script language="javascript" type="text/javascript">
        
        /*
        * Função que abre uma pop up
        */
        function openPopup(cod, referencia,grupo,rota)
        {
            window.open('../../Gestao/Critica.aspx?CDC=' + cod + '&Referencia=' + referencia + '&Rota=' + rota + '&Grupo=' + grupo + '&Entrada=true', 'janela', 'width=1024, height=650,scrollbars=yes,top=10,left=10');
            //location.href = '../../Gestao/Critica.aspx?CDC=' + cod + '&Referencia=' + referencia + '&Rota=' + rota + '&Grupo=' + grupo + '&Entrada=true', 'janela', 'width=1024, height=650,scrollbars=yes,top=10,left=10'; 
        }
        
    </script>
    <style type="text/css">
        .celula1 {
         width: 100px;
         padding:10px;
         _width: 255px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Title" Runat="Server">Contas para critica</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/wz_tooltip.js" ></script> 
    <div class="siteMap">
        <span id="ctl00_ContentPlaceHolder1_Label1">Contas para critica &gt;</span>
        <%--<span class="destaqueSiteMap" id="ctl00_ContentPlaceHolder1_Label2">Tarifa</span>--%>
    </div>
    <div class="topConteudo">
    </div>
    <div class="bgConteudo">
        <div class="txtPagina">
            <span id="ctl00_ContentPlaceHolder1_Label4">Preencha os campos abaixo, para iniciar a pesquisa.</span>
            <div class="fioTxt">
                <asp:Label ID="LabelDescricaoErro" runat="server" Text="" style="display:none"></asp:Label>
            </div>
            <div id="label">
                <div class="fieldLinha4" style="margin-left:0px;">
                    <div class="fieldLinha3">
                        <asp:Label ID="Labelgrupo" runat="server" Text="Grupo"></asp:Label>
                    </div>
                    <div class="fieldLinha3">
                        <asp:TextBox ID="grupo" runat="server" style="width:50px;" CssClass="center" onkeypress="return OnlyNumber(event);"></asp:TextBox>
                    </div>
                    <div class="fieldLinha3">
                        <asp:Label ID="LabelErroGrupo" runat="server" Text="*" style="display:none"></asp:Label>
                    </div>
                </div>
                <div class="fieldLinha4" style="margin-left:0px;">
                    <div class="fieldLinha3">
                        <asp:Label ID="Label2" runat="server" Text="Rota"></asp:Label>
                    </div>
                    <div class="fieldLinha3">
                        <asp:TextBox ID="Rota" runat="server" style="width:50px;" CssClass="center" onkeypress="return OnlyNumber(event);"></asp:TextBox>
                    </div>
                    <div class="fieldLinha3">
                        <asp:Label ID="LabeErroRota" runat="server" Text="*" style="display:none"></asp:Label>
                    </div>
                </div>
                <div class="fieldLinha4" style="margin-left:-49px">
                    <div class="fieldLinha3">
                        <asp:Label ID="Labelreferencia" runat="server" Text="Referencia"></asp:Label>
                    </div>
<%--                    <div class="fieldLinha3">
                        <select id="referenciaAux" name="referenciaAux" style="display:block" onchange="javascript:document.getElementById('ctl00_ContentPlaceHolder2_Referencia').value = this.value;">
	                        <option value="<%Response.Write(DateTime.Now.Month-3 + "/" + DateTime.Now.Year);%>"><%Response.Write(DateTime.Now.Month-3 + "/" + DateTime.Now.Year);%></option>
	                        <option value="<%Response.Write(DateTime.Now.Month-2 + "/" + DateTime.Now.Year);%>"><%Response.Write(DateTime.Now.Month-2 + "/" + DateTime.Now.Year);%></option>
	                        <option value="<%Response.Write(DateTime.Now.Month-1 + "/" + DateTime.Now.Year);%>"><%Response.Write(DateTime.Now.Month-1 + "/" + DateTime.Now.Year);%></option>
                            <option value="<%Response.Write(DateTime.Now.Month + "/" + DateTime.Now.Year);%>" selected="selected"><%Response.Write(DateTime.Now.Month + "/" + DateTime.Now.Year);%></option>
	                        <option value="" selected="selected">Selecione</option>
	                    </select>
                     </div>--%>
                     <div class="fieldLinha3">
                        <asp:TextBox ID="Referencia" runat="server" CssClass="center" Onkeyup="return mascara(this,event,'##/####');" onkeypress="return OnlyNumber(event);" style="width:80px"></asp:TextBox>
                        <asp:Label ID="LabelErroReferencia" runat="server" Text="*" style="display:none"></asp:Label>
                    </div>
                </div>
                <div class="fieldLinha4" style="margin-left:-48px;">
                    <div class="fieldLinha3">
                        <asp:Label ID="Label1" runat="server" Text="CDC"></asp:Label>
                    </div>
                    <div class="fieldLinha3">
                        <asp:TextBox ID="CDC" MaxLength="11" runat="server" style="width:80px;" CssClass="center" onkeypress="return OnlyNumber(event);"></asp:TextBox>
                    </div>
                    <div class="fieldLinha3">
                        <asp:Label ID="LabelErroCDC" runat="server" Text="*" style="display:none"></asp:Label>
                    </div>
                </div>
                <div class="fieldLinha">
                    <asp:Button ID="Button2" runat="server" Text="Pesquisar" onclick="Button2_Click" CssClass="btPesquisar"/>
                    <asp:Button ID="Button1" runat="server" Text="Gerar Relatorio" onclick="Button1_Click" CssClass="btGerar"/>    
                </div>
            </div>            
            <div class="divTabela" style="height:300px;" >
                <asp:ListView ID="ListView1" runat="server" DataKeyNames="CDC">
                    <LayoutTemplate>
                        <table id="Table1" runat="server" class="gridView" style="margin:0 0 -15px;">
                            <tr id="Tr1" runat="server">
                                <td id="Td1" runat="server">
                                    <table ID="itemPlaceholderContainer" runat="server" border="0">
                                        <tr id="Tr2" runat="server">								
					                        <th style="width:10%" id="ThCDC" runat="server">CDC</th>
					                        <th style="width:20%" id="ThNome" runat="server">Nome</th>
					                        <th style="width:20%" id="ThSetor" runat="server">Endereço</th>
					                        <th style="width:20%" id="ThMedia" runat="server">Media</th>
					                        <th style="width:20%" id="ThData_Vencimento" runat="server">Data vencimento</th>
					                        <th style="width:20%" id="ThTipo" runat="server">Tipo</th>
					                        <th style="width:10%" id="ThCritica">Alterar</th>
					                    </tr>
                                        <tr ID="itemPlaceholder" runat="server" style="background-color:Blue;">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr style="background-color:#FFFFFF" onmouseover="this.style.background = '#CCC'" onmouseout="this.style.background = '#FFFFFF'" >
                            <td class="center">
                                <asp:Label ID="CDC" runat="server" Text='<%# Eval("CDC") %>'/>
                            </td>
                            <td>
                                <asp:Label ID="Nome" runat="server" Text='<%# Eval("Nome") %>' />
                            </td>
                            <td class="celula1">
                                <asp:Label ID="Complemento" runat="server" Text='<%# Eval("Complemento") %>' />
                            </td>
                            <td class="center">
                                <asp:Label ID="Media" runat="server" Text='<%# Eval("Media") %>' />
                            </td>
                            <td class="center">
                                <asp:Label ID="Data_Vencimento" runat="server" Text='<%# Eval("Data_Vencimento","{0:dd/MM/yyyy}") %>' />
                            </td>
                            <td class="center">
                                <asp:Label ID="Tipo" runat="server" Text='<%# Eval("Tipo") %>' />
                            </td>
                            <td>
                                <input type="button" id="ButonCritica" class="btOK" onclick="openPopup(<%# Eval("CDC") %>,document.getElementById('<%=Referencia.ClientID%>').value,document.getElementById('<%=grupo.ClientID%>').value,document.getElementById('<%=Rota.ClientID%>').value);" onmouseover="Tip('Entrar na tela de critica.')" onmouseout="UnTip()"/>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style="background-color:#F4F4F4" OnMouseOver="this.style.background = '#CCC'" OnMouseOut="this.style.background = '#F4F4F4'" >
                            <td class="center">
                                <asp:Label ID="CDC" runat="server" Text='<%# Eval("CDC") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Nome" runat="server" Text='<%# Eval("Nome") %>' />
                            </td>
                            <td class="celula1">
                                <asp:Label ID="Complemento" runat="server" Text='<%# Eval("Complemento") %>' />
                            </td>
                            <td class="center">
                                <asp:Label ID="Media" runat="server" Text='<%# Eval("Media") %>' />
                            </td>
                            <td class="center">
                                <asp:Label ID="Data_Vencimento" runat="server" Text='<%# Eval("Data_Vencimento","{0:dd/MM/yyyy}") %>' />
                            </td>
                            <td class="center">
                                <asp:Label ID="Tipo" runat="server" Text='<%# Eval("Tipo") %>' />
                            </td>
                            <td>
                                <input type="button" id="ButonCritica" class="btOK" onclick="openPopup(<%# Eval("CDC") %>,document.getElementById('<%=Referencia.ClientID%>').value,document.getElementById('<%=grupo.ClientID%>').value,document.getElementById('<%=Rota.ClientID%>').value);" onmouseover="Tip('Entrar na tela de critica.')" onmouseout="UnTip()" />
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        <table id="Table2" runat="server" class="gridView">
                            <tr id="Tr2" runat="server">								
		                        <th style="width:10%" id="ThCDC" runat="server">CDC</th><th style="width:20%" id="ThNome" runat="server">Nome</th><th style="width:20%" id="ThSetor" runat="server">Setor</th><th style="width:20%" id="ThMedia" runat="server">Media</th><th style="width:20%" id="ThData_Vencimento" runat="server">Data vencimento</th><th style="width:10%" id="ThCritica"></th>
		                    </tr>
                            <tr>
                                <td class="center">
                                    <asp:Label ID="CDC" runat="server" Text='' />
                                </td>
                                <td>
                                    <asp:Label ID="Nome" runat="server" Text='' />
                                </td>
                                <td class="center">
                                    <asp:Label ID="Setor" runat="server" Text='' />
                                </td>
                                <td class="center">
                                    <asp:Label ID="Media" runat="server" Text='' />
                                </td>
                                <td class="center">
                                    <asp:Label ID="Data_Vencimento" runat="server" Text='' />
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>         
                </asp:ListView>
<%--                <table class="gridView">
                    <tr id="Tr3" runat="server" class="paginacao">
                        <td id="Td2" runat="server" style="text-align:right;">
                            <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="10">
                                <Fields>
                                    <asp:NumericPagerField />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>--%>
            </div>
           
            <asp:ObjectDataSource ID="ObjectDataSource" runat="server" 
                SelectMethod="RetornaLigacoes" TypeName="Data.BFL.LigacoesFlow">
                <SelectParameters>
                    <asp:Parameter DefaultValue="CDC = 0" 
                        Name="where" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
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
    
            } else {
                domRead();
            }
        }
        setTimeout(domRead, 1000);
    </script>
</asp:Content>


