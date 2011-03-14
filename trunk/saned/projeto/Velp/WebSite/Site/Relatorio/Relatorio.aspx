<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<script runat="server">
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<%--    <script language="javascript" type="text/javascript" src="../Script/jquery-1.4.2.min.js" ></script>
    <script language="javascript" type="text/javascript" src="../Script/jquery.msgbox.min.js" ></script>
    <script language="javascript" type="text/javascript" src="../Script/messagem.js" ></script>--%>
    <script language="javascript" type="text/javascript" src="../Script/comum.js" ></script>
    <script language="javascript" type="text/javascript">
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" Runat="Server">Relatorios</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server" culture="pt-BR" uiCulture="pt-BR" >

    <script language="javascript" type="text/javascript" src="../Script/wz_tooltip.js" ></script>
    
    <h2>Relatorios</h2>
    
    <div class="divTabela">
        
        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Relatorio/Critica/Index.aspx"><p class="paragrafo">Relatorio de contas para critica</p></asp:HyperLink>
        
    </div>
</asp:Content>
    