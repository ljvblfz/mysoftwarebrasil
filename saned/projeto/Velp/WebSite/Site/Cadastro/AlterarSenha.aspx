<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlterarSenha.aspx.cs" Inherits="Cadastro_AlterarSenha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>..:: Sistema de Gestão de Saneamento ::..</title>
    <link id="Link1"  runat="server" href="~/Style/saned.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../Script/comum.js" ></script>
    <script type="text/javascript">
    
        function sair() {

            window.close();
        }
    </script>
    <style type="text/css">
    
        .table
        {
            border:0 none;
            margin:5px 513px 5px 33px;
            padding:0;
            width:700px;
        }
        .titForm
        {
            width:874px;
        }
        .bgConteudo {
            height:132px;
        }
    </style>
</head>
<body>

    <script language="javascript" type="text/javascript" src="../Script/wz_tooltip.js" ></script>
    
        <div class="fioLateralInterno">
            <div class="topConteudo">
            </div>
            <div class="bgConteudo">
                <form id="form1" runat="server">
                    <div class="txtPagina">
                        <div class="table">
                            <h2 class="titForm" >Alterar senha</h2>
                            <div class="fieldLinha">
                                <asp:Label ID="LabelSenhaAntiga" runat="server" Text="Senha antiga:"></asp:Label><br />
                                <asp:TextBox ID="TextBoxCodigo" ReadOnly="true" runat="server" style="display:none;"></asp:TextBox>
                                <asp:TextBox ID="TextBoxSenhaAntiga" TextMode="password" runat="server" CssClass="medTxtArea" MaxLength="6" ></asp:TextBox>
                            </div>
                            <div class="fieldLinha">
                                <asp:Label ID="LabelSenhaNova" runat="server" Text="Senha nova:"></asp:Label><br />
                                <asp:TextBox ID="TextBoxSenhaNova" TextMode="password" runat="server" CssClass="medTxtArea" MaxLength="6"></asp:TextBox>
                            </div>
                            <div class="fieldLinha">
                                <div class="fieldLinha2" style="text-align:center;">
                                    <asp:Button ID="ButtonSalvar" runat="server" Text="Salvar" CssClass="btSalvar" 
                                        onmouseover="Tip('Salvar as alterações.')" onmouseout="UnTip()" 
                                        onclick="ButtonSalvar_Click" />
                                </div>
                                <div class="fieldLinha2" style="text-align:center;">
                                    <input type="button" value="Sair" id="ButtonSair" class="btSair" onclick="sair();" onmouseover="Tip('Sair da tela sem salvar as alterações.')" onmouseout="UnTip()" />
                                </div>
                            </div>
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
</html>
