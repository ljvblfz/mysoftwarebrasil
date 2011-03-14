<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Erro.aspx.cs" Inherits="Erro" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <style>
        
        .b1 
        {
            height:1px;
            font-size:1px;
            background:#aaa;
            margin:0 5px;
        }
        .b2 
        {
            height:1px;
            font-size:1px;
            background:#EEEEE0;
            border-right:2px solid #aaa;
            border-left:2px solid #aaa;
            margin:0 3px;
        }
        .b3 
        {
            height:1px;
            font-size:1px;
            background:#EEEEE0;
            border-right:1px solid #aaa;
            border-left:1px solid #aaa;
            margin:0 2px;
        }
        .b4 
        {
            height:2px;
            font-size:1px;
            background:#EEEEE0;
            border-right:1px solid #aaa;
            border-left:1px solid #aaa;
            margin:0 1px;
        }
        .b5 
        {
            border-left:1px solid #aaa;
            border-right:1px solid #aaa;
            display:block;
        }
        
        .tituloGrid 
        {
            border-bottom:1px dotted #828177;
            border-top:1px dotted #828177;
            color:#828177;
            font-family:Verdana,Courier,mono;
            font-size:13pt;
            font-weight:bold;
            margin:0 0 5px;
            padding:2px 2px 2px 5px;
            text-align:left;
        }
        
        .fieldLinhaDentro 
        {
            clear:both;
            margin:13px 0 0 10px;
            text-align:left;
            width:100%;
        }
        
        .centro
        {
          width:500px;
        }
        
        .centro {
            float:left;
            margin-left:18%;
            margin-top:19%;
            width:500px;
        }
        
        .erro {
            color: #666666;
            font-family: Verdana;
            font-size: 8pt;
            font-weight: normal;
            padding: 2px 10px 5px 0;
            background: none repeat scroll 0 0 transparent;
        }
        
        .messagem {
            color: #666666;
            font-family: Verdana;
            font-size: 11pt;
            font-weight: normal;
            padding: 2px 10px 5px 0;
            background: none repeat scroll 0 0 transparent;
        }
        
        #fioLateralInterno {
            background-image: url("../images/bgFio.gif");
            background-position: 0 0;
            background-repeat: repeat-y;
            border: 0 none;
            margin: 0;
            padding: 0;
            width: 800px;
        }

    </style>
    <script type="text/javascript" language="javascript">

        function ocultarDetalhes() {
            document.getElementById('ver').style.display = 'block';
            document.getElementById('ocultar').style.display = 'none'; 
            document.getElementById('detalhes').style.display = 'none';
        }

        function verDetalhes() {
            document.getElementById('ver').style.display = 'none';
            document.getElementById('ocultar').style.display = 'block'; 
            document.getElementById('detalhes').style.display = 'block';
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
        <div id="fioLateralInterno">
            <div class="b1"></div>
            <div class="b2"></div>
            <div class="b3"></div>
            <div class="b4"></div>
                <div class="b5">
                    <div style="border-top:0px;background:#EEEEE0;">
                        <div class="tituloGrid">
                            <div class="fieldLinha">
                                <img src="images/modal_erro.jpg" class="" alt="Erro"/>
                                Ocorreu um erro na aplicação.
                            </div>
                        </div>
                        <div class="fieldLinhaDentro">
                            <asp:Label ID="LabelMenssagem" runat="server" Text="Label" CssClass="messagem"></asp:Label><br /><br />
                            <a id="ver" onclick="verDetalhes();" class="btResenquenciar" style="display:block;width: 100px;">Ver detalhes</a>
                            <a id="ocultar" onclick="ocultarDetalhes();" class="btResenquenciar" style="display:none;width: 100px;">Ocultar detalhes</a>
                            <div id="detalhes" style="display:none;">
                                <asp:Label ID="LabelDetalhes" runat="server" Text="Label" CssClass="erro" style="background: none repeat scroll 0 0 transparent;" ></asp:Label><br /><br />
                                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Enviar Relatorio" CssClass="btResenquenciar/>
                            </div>
                        </div>
                        <div>
                            <input id="Button1" type="button" class="btVoltar" value="Voltar" onclick="javascript:window.history.back();"/>
                        </div>
                    </div>
                </div>
            <div class="b4"></div>
            <div class="b3"></div>
            <div class="b2"></div>
            <div class="b1"></div>
        </div>
</asp:Content>

