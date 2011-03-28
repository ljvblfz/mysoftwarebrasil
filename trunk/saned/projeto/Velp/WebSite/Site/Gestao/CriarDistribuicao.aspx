<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CriarDistribuicao.aspx.cs" Inherits="Gestao_CriarDistribuicao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
	<style>
		body { font-size: 62.5%; }
		label, input { display:block; }
		input.text { margin-bottom:12px; width:95%; padding: .4em; }
		fieldset { padding:0; border:0; margin-top:25px; }
		h1 { font-size: 1.2em; margin: .6em 0; }
		div#users-contain { width: 350px; margin: 20px 0; }
		div#users-contain table { margin: 1em 0; border-collapse: collapse; width: 100%; }
		div#users-contain table td, div#users-contain table th { border: 1px solid #eee; padding: .6em 10px; text-align: left; }
		.ui-dialog .ui-state-error { padding: .3em; }
		.validateTips { border: 1px solid transparent; padding: 0.3em; }
	</style>
	<script>
	    $(function() {
	        // a workaround for a flaw in the demo system (http://dev.jqueryui.com/ticket/4375), ignore!
	        $("#dialog:ui-dialog").dialog("destroy");

	        var name = $("#name"),
			email = $("#email"),
			password = $("#password"),
			allFields = $([]).add(name).add(email).add(password),
			tips = $(".validateTips");

	        function updateTips(t) {
	            tips
				.text(t)
				.addClass("ui-state-highlight");
	            setTimeout(function() {
	                tips.removeClass("ui-state-highlight", 1500);
	            }, 500);
	        }

	        function checkLength(o, n, min, max) {
	            if (o.val().length > max || o.val().length < min) {
	                o.addClass("ui-state-error");
	                updateTips("Length of " + n + " must be between " +
					min + " and " + max + ".");
	                return false;
	            } else {
	                return true;
	            }
	        }

	        function checkRegexp(o, regexp, n) {
	            if (!(regexp.test(o.val()))) {
	                o.addClass("ui-state-error");
	                updateTips(n);
	                return false;
	            } else {
	                return true;
	            }
	        }

	        $("#dialog-form").dialog({
	            autoOpen: false,
	            height: 300,
	            width: 350,
	            modal: true,
	            buttons: {
	                "Create an account": function() {
	                    var bValid = true;
	                    allFields.removeClass("ui-state-error");

	                    bValid = bValid && checkLength(name, "username", 3, 16);
	                    bValid = bValid && checkLength(email, "email", 6, 80);
	                    bValid = bValid && checkLength(password, "password", 5, 16);

	                    bValid = bValid && checkRegexp(name, /^[a-z]([0-9a-z_])+$/i, "Username may consist of a-z, 0-9, underscores, begin with a letter.");
	                    // From jquery.validate.js (by joern), contributed by Scott Gonzalez: http://projects.scottsplayground.com/email_address_validation/
	                    bValid = bValid && checkRegexp(email, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "eg. ui@jquery.com");
	                    bValid = bValid && checkRegexp(password, /^([0-9a-zA-Z])+$/, "Password field only allow : a-z 0-9");

	                    if (bValid) {
	                        $("#users tbody").append("<tr>" +
							"<td>" + name.val() + "</td>" +
							"<td>" + email.val() + "</td>" +
							"<td>" + password.val() + "</td>" +
						"</tr>");
	                        $(this).dialog("close");
	                    }
	                },
	                Cancel: function() {
	                    $(this).dialog("close");
	                }
	            },
	            close: function() {
	                allFields.val("").removeClass("ui-state-error");
	            }
	        });

	        $("#create-user")
			.button()
			.click(function() {
			    $("#dialog-form").dialog("open");
			});
	    });
	</script>
    <script type="text/javascript">

        function VoltarPagina() {
            var referencia = document.getElementById('<%=TextBoxReferencia.ClientID %>').value;
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

    <link  rel="stylesheet" type="text/css" href="../Style/jquery.ui.all.css"/>
    <script language="javascript" type="text/javascript" src="../Script/jquery-1.5.1.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/jquery.bgiframe-2.1.2.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/jquery.ui.core.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/jquery.ui.widget.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/jquery.ui.mouse.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/jquery.ui.button.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/jquery.ui.draggable.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/jquery.ui.position.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/jquery.ui.resizable.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/jquery.ui.dialog.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/jquery.effects.core.js"></script>
    <link  rel="stylesheet" type="text/css" href="../Style/demos.css"/>
    <script id="Script1" language="javascript" type="text/javascript" src="../Script/wz_tooltip.js" ></script>
    
    <div id="dialog-form" title="Create new user">
	<p class="validateTips">All form fields are required.</p>
	    <form>
	    <fieldset>
		    <label for="name">Name</label>
		    <input type="text" name="name" id="name" class="text ui-widget-content ui-corner-all" />
		    <label for="email">Email</label>
		    <input type="text" name="email" id="email" value="" class="text ui-widget-content ui-corner-all" />
		    <label for="password">Password</label>
		    <input type="password" name="password" id="password" value="" class="text ui-widget-content ui-corner-all" />
	    </fieldset>
	    </form>
    </div>
       
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
                    <button id="create-user">Create new user</button>
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

