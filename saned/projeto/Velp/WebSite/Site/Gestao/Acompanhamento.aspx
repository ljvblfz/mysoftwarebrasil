<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Acompanhamento.aspx.cs" Inherits="Gestao_Acompanhamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/comum.js" ></script>
        <script language="javascript" type="text/javascript" >

            /*
            * Ajax para atualizar os dados
            *
            * @Param valor da ocorrencia
            */
            function atualizarTela(grupo) {
                try {
                    document.getElementById('preload').style.display = 'block';
                    document.getElementById('btnVoltar').focus()
                    document.getElementById('btnAtualizarTela').disabled = true;
                    valorGrupo = grupo.value;
                    $.ajax({
                        type: "POST",
                        url: "Acompanhamento.aspx/atualizarTela",
                        data: "{ codGrupo: "+valorGrupo+" }",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function(response) {
                            if (response.d != "") {
                                document.getElementById('divTabelaAcompanhamento').innerHTML = response.d;
                            } else {
                                alert('Falha na atualização.');
                            }
                        },
                        error: function(xhr, textStatus, errorThrown) {
                            if (xhr.status == 401) {
                                location.reload(true);
                            }
                        }
                    });

                    document.getElementById('preloadAconpanhamento').style.display = "block";
                    setTimeout('document.getElementById(\'preloadAconpanhamento\').style.display = \'none\'', 10000);
                    setTimeout('document.getElementById(\'btnAtualizarTela\').disabled = false', 10000);
                    document.getElementById('preload').style.display = 'none';
                }
                catch (e) {
                    document.write(e);
                }
            }

</script>
<style type="text/css">
    #preloadAconpanhamento {
        display:none;
        position:absolute;
        z-index:100;
        margin-left:55px;
        margin-top:-20px;
    }

</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<script id="Script1" language="javascript" type="text/javascript" src="../Script/wz_tooltip.js" ></script>   
    <div class="siteMap">
        <span id="Label1">Distribuição &gt;</span>
        <span class="destaqueSiteMap" id="Label2">Acompanhamento</span>
    </div>
    <div class="topConteudo">
    </div>
    <div class="bgConteudo">
        <div class="txtPagina">
            <h3 class="titForm" style="width:873px;">Acompanhamento online</h3>
            <div id="label">
                <div class="fieldLinha3">
                    <asp:Label ID="lbGrupo" runat="server" Text="" ></asp:Label>
                    <asp:TextBox ID="txtGrupo" runat="server" style="display:none;"></asp:TextBox>
                </div>
                <div class="fieldLinha3" id="cronometro">
                    <span>Faltam</span>
                    <asp:Label ID="lbCronometro" runat="server" Text="00:20:00"></asp:Label>
                    <span>para a proxima atualização.</span>
                </div>
                <div class="fieldLinha3">
                    <input id="btnAtualizarTela" class="btAtualizar" type="button" onclick="javaScript:atualizarTela(document.getElementById('<%=txtGrupo.ClientID %>'));" value="Atualizar Agora"/>   
                    <div id="preloadAconpanhamento">
                        <img src="../images/loading.gif" alt="carregando" style="width:30px;" name="imgcarregando" id="imgcarregando" title="O conte&uacute;do est&aacute; sendo carregado." />
                    </div>
                </div>
            </div>
            <div class="divTabela" id ="divTabelaAcompanhamento"> 

            </div>
            <div>
                <input id="btnVoltar" name="" type="button" class="btn" value="Voltar" onclick="javascript:window.history.back();"/>
            </div>   
        </div>
    </div>
    <div class="bottomConteudo">
    </div>
    <div class="bottomPagina">
        <span id="Label3">Sistema de Gestão de Saneamento</span>
    </div>
    <script type="text/javascript">
    
        try {
            document.getElementById('divTabelaAcompanhamento').innerHTML = codigoTabela;
        }
        catch (e) {
            document.write(e);
        }
        
        var tempoTotal = null;
        function Regressivo(LabelExibe) {
            try {
                var LabelObj = document.getElementById(LabelExibe);
                if (tempoTotal == null) {
                    tempoTotal = LabelObj.innerHTML;
                }
                var iHoras = LabelObj.innerHTML.substr(0, 2);
                var iMinutos = LabelObj.innerHTML.substr(3, 2);
                var iSegundos = LabelObj.innerHTML.substr(6, 2);
                if (iHoras == 0 && iMinutos == 0 && iSegundos == 0) {
                    atualizarTela(document.getElementById('<%=txtGrupo.ClientID %>'));
                    LabelObj.innerHTML = tempoTotal;
                    iHoras = LabelObj.innerHTML.substr(0, 2);
                    iMinutos = LabelObj.innerHTML.substr(3, 2);
                    iSegundos = LabelObj.innerHTML.substr(6, 2);
                }
                if (iSegundos > 0) {
                    iSegundos -= 1;
                }
                else {
                    iSegundos = 59;
                    if (iMinutos > 0) {
                        iMinutos -= 1;
                    }
                    else {
                        iMinutos = 59;
                        if (iHoras > 0) {
                            iHoras -= 1;
                        }
                    }
                }
                var sHora = "";
                var sMinuto = "";
                var sSegundo = "";
                if (iHoras.toString().length < 2) {
                    sHora = "0" + iHoras.toString();
                }
                else {
                    sHora = iHoras.toString();
                }
                if (iMinutos.toString().length < 2) {
                    sMinuto = ":0" + iMinutos.toString();
                }
                else {
                    sMinuto = ":" + iMinutos.toString();
                }
                if (iSegundos.toString().length < 2) {
                    sSegundo = ":0" + iSegundos.toString();
                }
                else {
                    sSegundo = ":" + iSegundos.toString();
                }
                LabelObj.innerHTML = sHora + sMinuto + sSegundo;
                setTimeout('Regressivo(\'<%=lbCronometro.ClientID %>\');', 1000);
            }
            catch (e) {
                document.write(e);
            }
        }
        Regressivo('<%=lbCronometro.ClientID %>');
    </script>
</asp:Content>

