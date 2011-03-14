<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=4" />   <!-- IE5 mode -->
    <meta http-equiv="X-UA-Compatible" content="IE=7.5" /> <!-- IE7 mode -->
    <meta http-equiv="X-UA-Compatible" content="IE=100" /> <!-- IE8 mode -->
    <meta http-equiv="X-UA-Compatible" content="IE=a" />   <!-- IE5 mode --> 

    <title></title>
    <link id="Link1"  runat="server" href="style/saned.css" rel="stylesheet" type="text/css" />
    <script  type="text/javascript">
    
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
        
    </script>
</head>
<body>
<script language="javascript" type="text/javascript" src="../Script/wz_tooltip.js" ></script>
<center>
    <div class="fioLateral">
            <div class="top">
                <div class="logo">
                </div>
                <div class="foto">
                </div>
            </div>
     </div>
    <div class="fioLateralInterno">
        <div class="topConteudo">
        </div>
        <div class="bgConteudo">
            <form id="form2" runat="server">
                <div class="txtPagina">
                     <div class="divTabela">
                         <div class="fieldLinha">
                            <h3 class="titForm" style="width:850px;">Login</h3>   
                         </div>
                         <div class="fieldLinha" style="margin-left:43%;width:40%">
                             <div class="fieldLinha">
                                <asp:Label ID="LabelUsuario" runat="server" Text="Usuario"></asp:Label>
                             </div>
                             <div class="fieldLinha">
                                <asp:TextBox ID="TxtUsuario" runat="server" MaxLength="10" onkeyup="this.value=this.value.toUpperCase();" style="text-transform:uppercase;"></asp:TextBox>
                             </div>
                         </div>
                         <div class="fieldLinha" style="margin-left:43%;width:40%">
                             <div class="fieldLinha">
                                <asp:Label ID="LabelPassword" runat="server" Text="Senha"></asp:Label>
                             </div>
                             <div class="fieldLinha">
                                <asp:TextBox ID="TxtPassword" TextMode="password" runat="server" maxlength="6" onkeypress="checar_caps_lock(event)"  ></asp:TextBox>
                                <span id="aviso_caps_lock" style="display:none;color:Red;">"Parece que a tecla CAPS LOCK está ativa"</span>
                             </div>
                         </div>
                         <div class="fieldLinha" style="margin-left:43%;width:0%">
                             <asp:Button ID="Button1" runat="server" Text="Entrar"  
                                 style="margin:0 0 0 35px;" onclick="Button1_Click"/>
                         </div>
                         <div class="fieldLinha" style="text-align:center;">
                                <span>Para uma melhor visualização utilize navegadores:</span><br />
                                <span>Monzilla Firefox ou Internet Explore 8</span><br />
                                <asp:Label ID="lbVersao" runat="server" Text=""></asp:Label>
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
</center>     
</body>
</html>


