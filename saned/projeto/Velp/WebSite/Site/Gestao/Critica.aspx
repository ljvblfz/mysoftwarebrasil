<%@ Page Language="C#" AutoEventWireup="true" enableEventValidation="false" CodeFile="Critica.aspx.cs" Inherits="Critica_Default"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="X-UA-Compatible" content="IE=4" />   <!-- IE5 mode -->
    <meta http-equiv="X-UA-Compatible" content="IE=7.5" /> <!-- IE7 mode -->
    <meta http-equiv="X-UA-Compatible" content="IE=100" /> <!-- IE8 mode -->
    <meta http-equiv="X-UA-Compatible" content="IE=a" />   <!-- IE5 mode --> 
    
    <meta http-equiv="Pragma" content="no-cache"/>
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE"/>
    <meta http-equiv="Expires" content="-1"/>

    <title>..:: Sistema de Gestão de Saneamento ::..
                            Critica
   </title>
    <link id="Link1"  runat="server" href="~/Style/saned.css" rel="stylesheet" type="text/css" />
    <script id="script1" src="../Script/jquery-1.4.2.min.js" type="text/javascript"></script>
<%--    <script id="script2" src="../Script/jquery.msgbox.min.js" type="text/javascript"></script>--%>
    <script language="javascript" type="text/javascript" src="../Script/comum.js" ></script>
<%--    <script language="javascript" type="text/javascript" src="../Script/messagem.js" ></script>--%>
    <script language="javascript" type="text/javascript" >
        
        /*
        * Ajax para atualizar os dados de ocorrencia
        * (OBSOLETA)
        * @Param valor da ocorrencia
        */
//        function atualizaOcorrencia(valorOcorrencia) {
//            try {
//                document.getElementById('TextOcorrencia').value = valorOcorrencia;

//                // Requsição ajax jquery
//                $.ajax({
//                    type: "POST",
//                    url: "Critica.aspx/RetornaOcorrencia",
//                    data: JSON.stringify({ codOcorrencia: valorOcorrencia }),
//                    contentType: "application/json; charset=utf-8",
//                    dataType: "json",
//                    success: function(response) {

//                        // Convert o retorno para um objeto json
//                        if (response.d != "") {
//                            document.getElementById('LabelOcorrencia').innerHTML = response.d;
//                        }
//                    }
//                });
//            }
//            catch (e) {
//                document.write(e);
//            }
//        }

        /*
        * Ajax para para salvar os dados
        *
        * @Param valor do projeto
        */
        function Salvar() {

            var resposta = confirm("Deseja salvar o registro?");

            if (resposta) {
                try {
                    // Valida os dados
                    var leituraAtual = document.getElementById('TextBoxLeituraAtual').value;
                    if (leituraAtual == "")
                        leituraAtual = 0;

                    var consumoAjustado = document.getElementById('TextConsumoAjustado').value
                    if (consumoAjustado == "")
                        consumoAjustado = 0;

                    var cdc = document.getElementById('TextCDC').value;
                    if (cdc == "")
                        cdc = 0;

                    var ocorrencia = document.getElementById('TextOcorrencia').value;
                    if (ocorrencia == "")
                        ocorrencia = 0;

                    var leituraAnterior = document.getElementById('TextLeituraAnterior').value;
                    if (leituraAnterior == "")
                        leituraAnterior = 0;

                    var historicoDataLeitura = document.getElementById('TextData').value;
                    var dataLeitura = document.getElementById('TextDataLeitura').value;
                    var faturado = document.getElementById('CheckBoxFatuar').checked;
                    var repasse = document.getElementById('CheckBoxRepasse').checked;

                    document.getElementById('preload').style.display = 'block';

                    // Requsição ajax jquery
                    $.ajax({
                        type: "POST",
                        url: "Critica.aspx/Salvar",
                        data: "{leituraAtual:" + leituraAtual + ",historicoDataLeitura:'" + historicoDataLeitura + "',leituraAnterior:" + leituraAnterior + ",repasse:" + repasse + ",faturado:" + faturado + ",consumoAjustado:" + consumoAjustado + ",dataLeituraString:'" + dataLeitura + "',CDC:" + cdc + ",ocorrencia:" + ocorrencia + "}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function(response) {

                            document.getElementById('preload').style.display = 'none';

                            // Convert o retorno para um objeto json
                            if (response.d == true) {
                                alert("Dados atualizados.");
                            }
                            else {
                                alert(response.d);
                            }
                        },
                        error: function(response) {
                            var mesns = response.responseText;
                            alert(mesns);
                            document.getElementById('preload').style.display = 'none';
                        }

                    });
                }
                catch (e) {
                    document.write(e);
                }
            }
        }


        /*
        * Função que abilita campos
        *
        */
        function CalculaLeitura(objeto) {
            try {
                var leturaAnterior = document.getElementById('TextLeituraAnterior').value;

                if (leturaAnterior == "") {
                    alert("Leitura anterior inexistente, selecione uma no historico.");
                }
                else {

                    var consumo = Math.abs(parseFloat(document.getElementById('TextBoxLeituraAtual').value) - parseFloat(leturaAnterior));
                    if (document.getElementById('TextDiasConsumo').value == 0 || document.getElementById('TextDiasConsumo').value == "")
                        document.getElementById('TextDiasConsumo').value = 31;
                        
                    document.getElementById('TextBoxLeituraAtual').value = document.getElementById('TextBoxLeituraAtual').value;
                    document.getElementById('TextConsumoMedido').value = consumo;
                    document.getElementById('TextConsumoAjustado').value = consumo;
                    document.getElementById('HiddenFieldConsumoAjustado').value = consumo;
                    document.getElementById('HiddenFieldConsumoMedido').value = consumo;
                }
            }
            catch (e) {
                document.write(e);
            }
        }

        function carregaCritica() {
            try {
                var grupo = document.getElementById('DropDownList_GRUPO').value;
                var rota = document.getElementById('DropDownList_ROTA').value;
                location.href = "Critica.aspx?Grupo=" + grupo + "&Rota=" + rota;
            }
            catch (e) {
                document.write(e);
            }
        }
        
        function sair() {

            window.close();
        }

        function marcaTabela() {
            try {
                var leituraProcurada = document.getElementById('TextLeituraAnterior').value;
                var dataParam = document.getElementById('TextData').value;
                var barras = dataParam.split("/");
                var meses = parseFloat(barras[1]);
                var mesesAnterior = parseFloat(barras[1]) - 1;
                if (meses < 10)
                    meses = "0" + meses;
                if (mesesAnterior < 10)
                    mesesAnterior = "0" + mesesAnterior;
                var referenciaProcurada = "01/" + meses + "/" + barras[2];
                var referenciaProcuradaMesAnterior = "01/" + mesesAnterior + "/" + barras[2];
                var numeroLinhas = document.getElementsByTagName('table')[3].rows.length;
                for (var i = 0; i < numeroLinhas; i++) {
                    if (i > 0) {
                        var table = document.getElementsByTagName('table');
                        if (table != null) {
                            if (table.length >= 4) {
                                var rows = document.getElementsByTagName('table')[3].rows;
                                if (rows != null && i <= rows.length) {
                                    var cells = document.getElementsByTagName('table')[3].rows[i].cells;
                                    if (cells != null && cells.length >= 4) {
                                        var span = document.getElementsByTagName('table')[3].rows[i].cells[4].getElementsByTagName('span');
                                        if (span != null) {
                                            var valorLeitura = document.getElementsByTagName('table')[3].rows[i].cells[4].getElementsByTagName('span')[0].innerHTML;
                                            var valorReferencia = document.getElementsByTagName('table')[3].rows[i].cells[1].getElementsByTagName('span')[0].innerHTML;
                                            if (valorLeitura == leituraProcurada && (valorReferencia == referenciaProcurada || valorReferencia == referenciaProcuradaMesAnterior)) {
                                                //if (valorLeitura == leituraProcurada && (valorReferencia == referenciaProcurada)) {
                                                document.getElementsByTagName('table')[3].rows[i].cells[0].style.backgroundImage = "url('../images/btSequenciar.gif')"
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (e) {
                document.write(e);
            }
        }

        function checkRadioLoad() {
            try {
                if (document.getElementById('RadioButton1').checked) {

                    checkRadio('RadioButton1');

                } else if (document.getElementById('RadioButton2').checked) {

                    checkRadio('RadioButton2');

                } else {
                    checkRadio('RadioButton3');
                }
            }
            catch (e) { }
        }

        function desbloquear() {
            try {
                document.getElementById('preload').style.display = 'none';
                document.getElementById('ButtonPrimeiro').disabled = false;
                document.getElementById('ButtonAnterior').disabled = false;
                document.getElementById('ButtonProximo').disabled = false;
                document.getElementById('ButtonUltimo').disabled = false;
                document.getElementById('ButtonSalvar').disabled = false;
                document.getElementById('ButtonSair').disabled = false;
            }
            catch (e) { }
        }

        function bloquear() {
            try {
                document.getElementById('preload').style.display = 'block';
                document.getElementById('ButtonPrimeiro').disabled = true;
                document.getElementById('ButtonAnterior').disabled = true;
                document.getElementById('ButtonProximo').disabled = true;
                document.getElementById('ButtonUltimo').disabled = true;
                document.getElementById('ButtonSalvar').disabled = true;
                document.getElementById('ButtonSair').disabled = true;
            }
            catch (e) { }
        }

    </script>   
    <style type="text/css">
        fieldset
        {
            float:left;
            margin-left:1px;
            font-size:10px;
            font-weight: bold;
            margin-top: 1px;
            margin-right: 1px;
        }
        .divTabela
        {
            font-family:Verdana;
            font-size:10px;
            margin-left:27px;
            width:auto;
        }
        .tabelaCritica
        {
            height:130px;
            overflow:auto;
            white-space:nowrap;
        }
        .fieldLinha6
        {
            float:left;
            margin:5px 0;
            width:16%;
        }
        .fieldLinha4a
        {
            float:left;
            margin:5px 0 5px 2px;
            text-align:center;
            width:23%;
        }
        
        .fieldLinha4
        {
            float:left;
            margin:5px 0 5px 2px;
            text-align:center;
            width:27%;
        }
        
        .fieldLinha2
        {
            float:left;
            margin:5px 0;
            width:50%;
        }
        .fieldLinha
        {
            clear:both;
            margin:5px 0;
            text-align:left;
            width:100%;
        }
        .fieldLinha2 {
            float:left;
            margin:5px 0;
            width:49%;
        }
        .fieldLinha3
        {
            float:left;
            margin:5px 0;
            width:33%;
        }
        label
        {
            font-size:8px;
            /*Style="width:70%;float:right;margin-right:17px;"*/
            /*Style="margin-left:13px;float:left;width:18%;"*/
        }
        /*#ListView1_itemPlaceholderContainer*/
        table
        {
            font-size:9px;
            width:98%; 
            margin:1px;
        }
        .fioLateralInterno 
        {
            width:1000px;
        }
        .txtPagina {
            width:940px;
        }
        legend
        {
            background-color:#FFFFFF;
            color:#666666;
            font-family:Verdana;
            font-size:8pt;
            font-weight:normal;
            padding:2px 10px 5px 0;
        }
        
        .txtPagina span 
        {
            background-color:Transparent;
            color:#666666;
            font-family:Verdana;
            font-size:8pt;
            font-weight:normal;
            padding:0 0 0;
        }
    </style>
    <style type="text/css">
        #preload {
            display:none;
            position:fixed;
            _position:absolute;
            z-index:100;
            top:50%;
            left:50%;
            margin-top: -4%;
            margin-left: -4%;
        }
    </style>
    <div id="preload">
        <div style="position:fixed;">
            <img src="../images/loading.gif" alt="Carregando" name="imgcarregando" id="imgcarregando" title="O conte&uacute;do est&aacute; sendo carregado."/>
        </div>
        <div style="position:fixed;">
            <h3>Carregando</h3>
        </div>
    </div>
    
    <input type="hidden" id="refreshed" value="no">
    <script type="text/javascript">
        onload = function() {
            try {
                var e = document.getElementById("refreshed");
                if (e.value == "no") e.value = "yes";
                else { e.value = "no"; location.reload(); }
            }
            catch (e) { }
        }
    </script>

</head>
<body>

    <script language="javascript" type="text/javascript" src="../Script/wz_tooltip.js" ></script>
    
        <div class="fioLateralInterno">
            <div class="topConteudo">
            </div>
            <div class="bgConteudo">
                <form id="form1" runat="server">
                    <div class="txtPagina">
                        <asp:TextBox ID="Referencia" runat="server" style="display:none;" ReadOnly="true"></asp:TextBox>
                        <div class="divTabela">
                            <h2 class="titForm" >Critica</h2>
                            <%--PRIMEIRA COLUNA--%>        
                            <fieldset style="width:27%;height:452px;">
                                <legend>Seleção</legend>
                                <fieldset style="width:93%;">
                                    <div class="fieldLinha">
                                        <div class="fieldLinha2">
                                            <asp:Label ID="LabelGrupo" runat="server" Text="Grupo"></asp:Label>
                                            
                                            <asp:DropDownList ID="DropDownList_GRUPO" runat="server" disabled="disabled"
                                                DataSourceID="ObjectDataSource_GRUPO" DataTextField="Grupo" 
                                                DataValueField="Grupo" onchange="carregaCritica();">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource_GRUPO" runat="server" 
                                                SelectMethod="ListaGrupo" TypeName="Data.BFL.GrupoFlow">
                                            </asp:ObjectDataSource>
                                        </div>
                                        
                                        <div class="fieldLinha2">
                                            <asp:Label ID="LabelRota" runat="server" Text="Rota" ></asp:Label>
                                            <asp:DropDownList ID="DropDownList_ROTA" runat="server" disabled="disabled"
                                                DataTextField="Rota" DataValueField="Rota" 
                                                DataSourceID="ObjectDataSource_ROTA" onchange="carregaCritica();" >
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource_ROTA" runat="server" 
                                                SelectMethod="RetornaRotas" TypeName="Data.BFL.LigacoesFlow">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="0" Name="Grupo" Type="Int32" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </div> 
                                    </div>
                                    
                                    <div class="fieldLinha" style="text-align:center;">
                                        <asp:Label ID="LabelAnalize1" runat="server" Text="Para análise" ></asp:Label>
                                        <asp:Label ID="LabelAnalizeValor1" runat="server" Text=""></asp:Label>
                                    </div>
                                    
                                   <div class="fieldLinha">
                                        <asp:Label ID="LabelSequencia" runat="server" Text="Sequência:"></asp:Label><br />
                                        <asp:TextBox ID="TextSequencia" runat="server" style="width:90%" ReadOnly="true"></asp:TextBox>
                                   </div>
                                   
                                    <div class="fieldLinha">
                                        <asp:Label ID="LabelCDC" runat="server" Text="CDC:"></asp:Label><br />
                                        <asp:TextBox ID="TextCDC" runat="server" style="width:90%" ReadOnly="true"></asp:TextBox>
                                   </div>
                                                                       
                                    <div class="fieldLinha">
                                    
                                        <div class="fieldLinha4a"> 
                                            <span id="LabelPrimeiro">Primeiro</span><br />
                                            <asp:Button ID="ButtonPrimeiro" runat="server" Text="" onclick="Primeiro_Click" OnClientClick="document.getElementById('preload').style.display = 'block';" CssClass="btRR" onmouseover="Tip('Primeiro');this.style.backgroundColor = '#CCCCCC';" onmouseout="UnTip();this.style.backgroundColor = '#FFFFFF';" disabled="disabled" />
                                        </div>
                                        <div class="fieldLinha4a">
                                            <span id="Span1">Anterior</span><br />
                                            <asp:Button ID="ButtonAnterior" runat="server" Text="" onclick="Anterior_Click" OnClientClick="document.getElementById('preload').style.display = 'block';" CssClass="btR" onmouseover="Tip('Anterior');this.style.backgroundColor = '#CCCCCC';" onmouseout="UnTip();this.style.backgroundColor = '#FFFFFF';" disabled="disabled"  />
                                        </div>
                                        <div class="fieldLinha4a">
                                            <span id="Span2">Proximo</span><br />
                                            <asp:Button ID="ButtonProximo" runat="server" Text="" onclick="Proximo_Click" OnClientClick="document.getElementById('preload').style.display = 'block';" CssClass="btF" onmouseover="Tip('Próximo');this.style.backgroundColor = '#CCCCCC';" onmouseout="UnTip();this.style.backgroundColor = '#FFFFFF';" disabled="disabled"  />
                                        </div>
                                        <div class="fieldLinha4a">
                                            <span id="Span3">Último</span><br />
                                            <asp:Button ID="ButtonUltimo" runat="server" Text="" onclick="Ultimo_Click" OnClientClick="document.getElementById('preload').style.display = 'block';" CssClass="btFF" onmouseover="Tip('Ultimo');this.style.backgroundColor = '#CCCCCC';" onmouseout="UnTip();this.style.backgroundColor = '#FFFFFF';" disabled="disabled" />
                                        </div>
                                        
                                    </div>
                                    
                                </fieldset>
                                
                                <fieldset style="width:93%;">
                                    <legend>CDC's Relacionados</legend>
                                    <div class="tabelaCritica">
                                        <asp:ListView ID="ListView2" runat="server" 
                                            DataSourceID="ObjectDataSource_LIGACOES">
                                            <ItemTemplate>
                                                <tr style="background-color:#FFFFFF">
                                                    <td>
                                                        <asp:Label ID="Codigo_LogradouroLabel" runat="server" 
                                                            Text='<%# Eval("CDC") %>' />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr style="background-color:#F4F4F4">
                                                    <td>
                                                        <asp:Label ID="Codigo_LogradouroLabel" runat="server" 
                                                            Text='<%# Eval("CDC") %>' />
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
                                                <tr style="">
                                                    <td>
                                                        <asp:TextBox ID="Codigo_LogradouroTextBox" runat="server" 
                                                            Text='<%# Bind("CDC") %>' />
                                                    </td>
                                                </tr>
                                            </InsertItemTemplate>
                                            <LayoutTemplate>
                                                <table runat="server" class="table">
                                                    <tr runat="server">
                                                        <td runat="server">
                                                            <table ID="itemPlaceholderContainer" runat="server" border="0" style="">
                                                                <tr runat="server" style="background-color:#F4F4F4">
                                                                    <th runat="server">CDC</th>
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
                                                <tr style="">
                                                    <td>
                                                        <asp:TextBox ID="Codigo_LogradouroTextBox" runat="server" 
                                                            Text='<%# Bind("CDC") %>' />
                                                    </td>
                                                </tr>
                                            </EditItemTemplate>
                                            <SelectedItemTemplate>
                                                <tr style="">
                                                    <td>
                                                        <asp:Label ID="Codigo_LogradouroLabel" runat="server" 
                                                            Text='<%# Eval("CDC") %>' />
                                                    </td>
                                                </tr>
                                            </SelectedItemTemplate>
                                        </asp:ListView>
                                        <asp:ObjectDataSource ID="ObjectDataSource_LIGACOES" runat="server" 
                                            SelectMethod="RetornaCDCrelacionadas" TypeName="Data.BFL.LigacoesFlow">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="99999999" Name="CDC" Type="Int32" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </div>
                                    
                                    <div class="fieldLinha">
                                        <asp:Label ID="TextNome" runat="server" Text="" style="width:98%;"></asp:Label>
                                    </div>
                                    
                                    <div class="fieldLinha">
                                        <asp:Label ID="TextEndereco" runat="server" Text="" style="width:98%;"></asp:Label>
                                    </div>
                                    
                                    <div class="fieldLinha">
                                        <asp:Label ID="TextCategoria" runat="server" Text="" style="width:98%;color:Red;"></asp:Label>
                                    </div>
                                    
                                    <div class="fieldLinha">
                                        <asp:Label ID="TextNatureza" runat="server" Text="" style="width:98%;color:Red;"></asp:Label>
                                    </div>
                                    
                                    <div class="fieldLinha">
                                        <asp:Label ID="TextStatus" runat="server" Text="" style="width:98%;color:Red;"></asp:Label>
                                    </div>
                                </fieldset>
                            </fieldset>
                            
                            <%--SEGUNDA COLUNA--%>
                            <fieldset style="width:31%;height:452px;">
                                <legend>Dados do CDC Selecionado</legend>
                                    <fieldset style="height:145px;width:94%;">
                                        <asp:ListView ID="ListView1" runat="server"
                                            DataSourceID="ObjectDataSource_HISTORICO">
                                            <ItemTemplate>
                                                <tr style="background-color:#FFFFFF" >
                                                    <td id="colunaSelecao"></td>
                                                    <td style="width:14%" >
                                                        <asp:Label ID="ReferenciaLabel" runat="server" 
                                                            Text='<%# Eval("Referencia","{0:dd/MM/yyyy}") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:Label ID="Dias_ConsumoLabel" runat="server" 
                                                            Text='<%# Eval("Dias_Consumo") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:Label ID="OcorrenciaLabel" runat="server" 
                                                            Text='<%# Eval("Ocorrencia") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:Label ID="LeituraLabel" runat="server" Text='<%# Eval("Leitura") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:Label ID="Leitura_RealLabel" runat="server" 
                                                            Text='<%# Eval("Leitura_Real") %>' />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr style="background-color:#F4F4F4" >
                                                    <td id="colunaSelecao"></td>
                                                    <td style="width:14%" >
                                                        <asp:Label ID="ReferenciaLabel" runat="server" 
                                                            Text='<%# Eval("Referencia","{0:dd/MM/yyyy}") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:Label ID="Dias_ConsumoLabel" runat="server" 
                                                            Text='<%# Eval("Dias_Consumo") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:Label ID="OcorrenciaLabel" runat="server" 
                                                            Text='<%# Eval("Ocorrencia") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:Label ID="LeituraLabel" runat="server" Text='<%# Eval("Leitura") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:Label ID="Leitura_RealLabel" runat="server" 
                                                            Text='<%# Eval("Leitura_Real") %>' />
                                                    </td>
                                                </tr>
                                            </AlternatingItemTemplate>
                                            <EmptyDataTemplate>
                                                <table id="Table2" runat="server" class = "table" style="font-size:10px;width:93%;margin:1px;">
                                                    <tr>
                                                        <td>
                                                            Nenhum dado foi retornado.</td>
                                                    </tr>
                                                </table>
                                            </EmptyDataTemplate>
                                            <InsertItemTemplate>
                                                <tr style="">
                                                    <td style="width:14%" >
                                                        <asp:TextBox ID="ReferenciaTextBox" runat="server" 
                                                            Text='<%# Bind("Referencia","{0:dd/MM/yyyy}") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:TextBox ID="Dias_ConsumoTextBox" runat="server" 
                                                            Text='<%# Bind("Dias_Consumo") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:TextBox ID="OcorrenciaTextBox" runat="server" 
                                                            Text='<%# Bind("Ocorrencia") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:TextBox ID="LeituraTextBox" runat="server" Text='<%# Bind("Leitura") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:TextBox ID="Leitura_RealTextBox" runat="server" 
                                                            Text='<%# Bind("Leitura_Real") %>' />
                                                    </td>
                                                </tr>
                                            </InsertItemTemplate>
                                            <LayoutTemplate>
                                                <table id="Table3" runat="server" style="font-size:10px;width:93%;margin:1px;" class="table">
                                                    <tr id="Tr1" runat="server">
                                                        <td id="Td1" runat="server">
                                                            <table ID="itemPlaceholderContainer" runat="server" border="0">
                                                                <tr id="Tr2" runat="server" style="background-color:#F4F4F4">
                                                                    <th id="Th0" runat="server" style="width:7%"></th>
                                                                    <th id="Th1" runat="server" style="width:13%" >
                                                                        Referencia</th>
                                                                    <th id="Th5" runat="server" style="width:13%" >
                                                                        Consumo</th>
                                                                    <th id="Th6" runat="server" style="width:5%" ></th>
                                                                    <th id="Th2" runat="server" style="width:13%" >
                                                                        Ajustada</th>
                                                                    <th id="Th7" runat="server" style="width:13%" >
                                                                        Real</th>
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
                                            <EditItemTemplate>
                                                <tr style="">
                                                    <td style="width:14%" >
                                                        <asp:TextBox ID="ReferenciaTextBox" runat="server" 
                                                            Text='<%# Bind("Referencia","{0:dd/MM/yyyy}") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:TextBox ID="Dias_ConsumoTextBox" runat="server" 
                                                            Text='<%# Bind("Dias_Consumo") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:TextBox ID="OcorrenciaTextBox" runat="server" 
                                                            Text='<%# Bind("Ocorrencia") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:TextBox ID="LeituraTextBox" runat="server" Text='<%# Bind("Leitura") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:TextBox ID="Leitura_RealTextBox" runat="server" 
                                                            Text='<%# Bind("Leitura_Real") %>' />
                                                    </td>
                                                </tr>
                                            </EditItemTemplate>
                                            <SelectedItemTemplate>
                                                <tr style="">
                                                    <td style="width:14%" >
                                                        <asp:Label ID="ReferenciaLabel" runat="server" 
                                                            Text='<%# Eval("Referencia","{0:dd/MM/yyyy}") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:Label ID="Dias_ConsumoLabel" runat="server" 
                                                            Text='<%# Eval("Dias_Consumo") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:Label ID="OcorrenciaLabel" runat="server" 
                                                            Text='<%# Eval("Ocorrencia") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:Label ID="LeituraLabel" runat="server" Text='<%# Eval("Leitura") %>' />
                                                    </td>
                                                    <td style="width:14%" >
                                                        <asp:Label ID="Leitura_RealLabel" runat="server" 
                                                            Text='<%# Eval("Leitura_Real") %>' />
                                                    </td>
                                                </tr>
                                            </SelectedItemTemplate>
                                        </asp:ListView>            
                                        <asp:ObjectDataSource ID="ObjectDataSource_HISTORICO" runat="server" 
                                            SelectMethod="Lista" TypeName="Data.BFL.HistoricoConsumoIDAFlow">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="0" Name="CDC" Type="Int32" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </fieldset>
                                    <fieldset style="width:94%;" >
                                        <div class="fieldLinha6" >
                                            <asp:Label ID="LabelRes" runat="server" Text="Res."></asp:Label><br />
                                            <asp:TextBox ID="TextRes" ReadOnly="true" runat="server" style="width:80%"></asp:TextBox>
                                        </div>
                                        <div class="fieldLinha6" >
                                            <asp:Label ID="LabelSoc" runat="server" Text="Soc."></asp:Label><br />
                                            <asp:TextBox ID="TextSoc" ReadOnly="true" runat="server" style="width:80%"></asp:TextBox>
                                        </div>
                                        <div class="fieldLinha6" >
                                            <asp:Label ID="LabelInd" runat="server" Text="Ind."></asp:Label><br />
                                            <asp:TextBox ID="TextInd" ReadOnly="true" runat="server" style="width:80%"></asp:TextBox>
                                        </div>
                                        <div class="fieldLinha6" >
                                            <asp:Label ID="LabelCom" runat="server" Text="Com."></asp:Label><br />
                                            <asp:TextBox ID="TextCom" ReadOnly="true" runat="server" style="width:80%"></asp:TextBox>
                                        </div>
                                        <div class="fieldLinha6" >
                                            <asp:Label ID="LabelPub" runat="server" Text="Pub."></asp:Label><br />
                                            <asp:TextBox ID="TextPub" ReadOnly="true" runat="server" style="width:80%"></asp:TextBox>
                                        </div>
                                        <div class="fieldLinha6" >
                                            <asp:Label ID="LabelAssist" runat="server" Text="Assist"></asp:Label><br />
                                            <asp:TextBox ID="TextAssist" ReadOnly="true" runat="server" style="width:80%"></asp:TextBox>
                                        </div>
                                    </fieldset>
                                    <fieldset style="width:94%;" >
                                        <div class="fieldLinha3">
                                            <asp:Label ID="Label1Media" runat="server" Text="Média:"></asp:Label><br />
                                            <asp:TextBox ID="TextMedia" ReadOnly="true" runat="server" style="width:80%"></asp:TextBox>
                                        </div>
                                        <div class="fieldLinha3">
                                            <asp:Label ID="LabelLeituraAnterior" runat="server" Text="Leitura anter:"></asp:Label><br />
                                            <asp:TextBox ID="TextLeituraAnterior" runat="server" style="width:80%;background-color:#FFFFDD;" Onchange="javascript:CalculaLeitura(this);" onKeyUp="this.style.border = '1px solid #CCCCCC';"></asp:TextBox>
                                        </div>
                                        <div class="fieldLinha3">
                                            <asp:Label ID="LabelData" runat="server" Text="Data:"></asp:Label><br />
                                            <asp:TextBox ID="TextData" ReadOnly="true" runat="server" style="width:80%"></asp:TextBox>
                                        </div>
                                    </fieldset>
                                    <fieldset style="width:94%;">
                                        <div class="fieldLinha">
                                            <asp:Label ID="LabelHidrometro" runat="server" Text="Hidrômetro:" style="width:30%;"></asp:Label>
                                            <asp:TextBox ID="TextHidrometro" ReadOnly="true" runat="server" style="width:50%;"></asp:TextBox>
                                            <asp:TextBox ID="TextNumeroPonteiros" ReadOnly="true" runat="server" style="width:10%;"></asp:TextBox>
                                        </div>
                                        <div class="fieldLinha">
                                            <asp:Label ID="LabelInstalacao" runat="server" Text="Instalação:" style="width:30%;"></asp:Label>
                                            <asp:TextBox ID="TextInstalacao" ReadOnly="true" runat="server" style="width:35%;"></asp:TextBox>
                                            <asp:TextBox ID="TextInstalacaoIn" ReadOnly="true" runat="server" style="width:20%;"></asp:TextBox>
                                        </div>
                                        <div class="fieldLinha">
                                            <asp:TextBox ID="TextBox20" ReadOnly="true" runat="server" style="width:98%;"></asp:TextBox>
                                        </div>
                                    </fieldset>
                                    <fieldset style="width:94%;">
                                        <legend>Dias Bloqueio Tarifa</legend>
                                                  
                                        <div class="fieldLinha4">
                                            <asp:Label ID="LabeBloqueio" runat="server" Text="Bloqueio:" style="width:30%;"></asp:Label><br />
                                            <asp:TextBox ID="TextBloqueio" ReadOnly="true" runat="server" style="width:91%;"></asp:TextBox>
                                        </div>
                                        <div class="fieldLinha4">
                                            <asp:Label ID="LabeDesbloqueio" runat="server" Text="Desbloqueio:" style="width:30%;"></asp:Label><br />
                                            <asp:TextBox ID="TextDesbloqueio" ReadOnly="true" runat="server" style="width:91%;"></asp:TextBox>
                                        </div>
                                        <div class="fieldLinha4" style="width:20%;">
                                            <asp:Label ID="LabeAtual" runat="server" Text="Atual:" style="width:30%;"></asp:Label><br />
                                            <asp:TextBox ID="TextAtual" ReadOnly="true" runat="server" style="width:91%;"></asp:TextBox>
                                        </div>
                                        <div class="fieldLinha4" style="width:20%;">
                                            <asp:Label ID="LabeAnterior" runat="server" Text="Anterior:" style="width:30%;"></asp:Label><br />
                                            <asp:TextBox ID="TextAnterior" ReadOnly="true" runat="server" style="width:91%;"></asp:TextBox>
                                        </div>
                                    </fieldset>
                            </fieldset>
                            
                            <%--TERCEIRA COLUNA--%>
                            <fieldset style="width:31%;height:452px;">
                                <legend>Dados para cálculo</legend>
                                <fieldset style="height: 415px">

                                        <div class="fieldLinha">
                                            <asp:Label ID="TextBox3" runat="server" style="width:90%;color:Red;font-weight: bold;"></asp:Label>
                                        </div>
                                        
                                        <div class="fieldLinha">
                                            <div class="fieldLinha3">
                                                <asp:Label ID="LabelDataLeitura" runat="server" Text="Data leitura"></asp:Label>
                                            </div>
                                            <div class="fieldLinha3">
                                                <asp:TextBox ID="TextDataLeitura" runat="server" style="width:90%;background-color:#FFFFDD;" onChange="VerificaData(this.value);" onKeyUp="mascara(this,event,'##/##/####',null,null);this.style.border = '1px solid #CCCCCC';"></asp:TextBox>
                                            </div>
                                        </div>
                                        
                                        <div class="fieldLinha">
                                            <div class="fieldLinha3">
                                                <asp:Label ID="LabelDiasConsumo" runat="server" Text="Dias consumo"></asp:Label>
                                            </div>
                                            <div class="fieldLinha3">
                                                <asp:TextBox ID="TextDiasConsumo" ReadOnly="true" runat="server" style="width:90%;"></asp:TextBox>
                                            </div>
                                            <div class="fieldLinha3" style="display:none;">
                                                <asp:CheckBox ID="CheckBoxAjustar" runat="server" />
                                                <asp:Label ID="LabeAjustar" runat="server" Text="Ajustar"></asp:Label>
                                            </div>
                                        </div>
                                        
                                        <div class="fieldLinha">
                                            <div class="fieldLinha3">
                                                <asp:Label ID="LabelLeituraAtual" runat="server" Text="Leitura atual"></asp:Label>
                                            </div>
                                            <div class="fieldLinha3">
                                                <asp:TextBox ID="TextBoxLeituraAtual" runat="server" style="width:90%;background-color:#FFFFDD;" Onchange="javascript:CalculaLeitura(this);" onKeyUp="this.style.border = '1px solid #CCCCCC';"></asp:TextBox>
                                            </div>
                                            <div class="fieldLinha3">
                                                <asp:TextBox ID="TextOcorrencia" ReadOnly="true" runat="server" style="width:50%; display:none;"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="fieldLinha">
                                            <asp:Label ID="LabelAnormalidade" runat="server" Text="Anormalidade"></asp:Label><br />
                                            <asp:DropDownList ID="DropDownList_Anormalidade" runat="server" 
                                                DataSourceID="ObjectDataSource2" DataTextField="des_ocorrencia" onchange="this.style.border = '1px solid #CCCCCC';"
                                                DataValueField="cod_ocorrencia" style="margin-left:0px;width:100%;background-color:#FFFFDD;">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                                SelectMethod="ListaDropDown" TypeName="Data.BFL.OcorrenciaFlow">
                                            </asp:ObjectDataSource>
                                        </div>
                                        <div class="fieldLinha" style="text-align:center">
                                            <asp:Label ID="LabelOcorrencia" runat="server" Text="" style="display:none;"></asp:Label>
                                        </div>
                                        
                                        <div class="fieldLinha">
                                            <div class="fieldLinha2">
                                                <asp:Label ID="LabelConsumoMedido" runat="server" Text="Consumo medido"></asp:Label>
                                            </div>
                                            <div class="fieldLinha2">
                                                <asp:TextBox ID="TextConsumoMedido" ReadOnly="true" runat="server" style="width:90%;"></asp:TextBox>
                                                <asp:HiddenField ID="HiddenFieldConsumoMedido" runat="server" />
                                            </div>
                                        </div>
                                        
                                        <div class="fieldLinha">
                                            <div class="fieldLinha2">
                                                <asp:Label ID="LabelConsumoAjustado" runat="server" Text="Consumo ajustado"></asp:Label>
                                            </div>
                                            <div class="fieldLinha2">
                                                <asp:TextBox ID="TextConsumoAjustado" ReadOnly="true" runat="server" style="width:90%;"></asp:TextBox>
                                                <asp:HiddenField ID="HiddenFieldConsumoAjustado" runat="server" />
                                            </div>
                                        </div>
                                    
                                    <div class="fieldLinha">
                                        <asp:CheckBox ID="CheckBoxFatuar" runat="server" />
                                        <asp:Label ID="Label29" runat="server" Text="Não faturar" style="margin-left:-14px;"></asp:Label>
                                    </div>
                                    
                                    <div class="fieldLinha">
                                        <asp:CheckBox ID="CheckBoxRepasse" runat="server" />
                                        <asp:Label ID="Label1" runat="server" Text="Repasse" style="margin-left:-14px;"></asp:Label>
                                    </div>
                                    
                                    <div class="fieldLinha">
                                        <div class="fieldLinha2" style="text-align:center;">
                                            <%--<input type="button" value="Salvar" id="ButtonSalvar" class="btSalvar" onclick="Salvar();" onmouseover="Tip('Salvar as alterações.')" onmouseout="UnTip()" />--%>
                                            <asp:Button ID="ButtonSalvar" runat="server" Text="Salvar" CssClass="btSalvar" 
                                                onmouseover="Tip('Salvar as alterações.')" onmouseout="UnTip()" 
                                                onclick="ButtonSalvar_Click" />
                                            <asp:TextBox ID="TextReferencia" runat="server" style="display:none;"></asp:TextBox>
                                            <asp:TextBox ID="TextGrupo" runat="server" style="display:none;"></asp:TextBox>
                                            <asp:TextBox ID="TextRota" runat="server" style="display:none;"></asp:TextBox>
                                            <asp:TextBox ID="TextIndex" runat="server" style="display:none;"></asp:TextBox>
                                        </div>
                                        <div class="fieldLinha2" style="text-align:center;">
                                            <input type="button" value="Sair" id="ButtonSair" class="btSair" onclick="sair();" onmouseover="Tip('Sair da tela sem salvar as alterações.')" onmouseout="UnTip()" />
                                        </div>
                                    </div>
                                    
                                </fieldset>
                            </fieldset>
                         </div>                        
                    </div>
                </form>
            </div>
            <div class="bottomConteudo">
            </div>
            <div class="bottomPagina">
                <span id="ctl00_ContentPlaceHolder1_Label3">Sistema de Gestão de Saneamento</span>
            </div>
		</div>   
</body>
<script type="text/javascript">

    var contador = 1;
    function domRead() {
        if (document.readyState == "complete") 
        {
            marcaTabela();
            //document.getElementById('DropDownList_GRUPO').disabled = true;
            //document.getElementById('DropDownList_ROTA').disabled = true;
            desbloquear();
            CalculaLeitura(document.getElementById('LabelLeituraAnterior'));
        } else {
            contador++;
            setTimeout("domRead()", 1000);
        }
    }
    domRead();
    
</script>
</html>
