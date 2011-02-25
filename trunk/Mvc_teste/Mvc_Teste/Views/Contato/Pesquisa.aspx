<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Contato>>" %>

<asp:Content ID="Content0" ContentPlaceHolderID="ContentPlaceHead" runat="server">
	<script type="text/javascript">
	    $(function() {
	        $("#myTable")[2]
			        .tablesorter({widthFixed: true, widgets: ['zebra']})
			        .tablesorterPager({container: $("#pager")});
	    });
	</script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Pesquisa
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Pesquisa</h2>

    
        <%=ViewData["pesquisa"]%>
        <p>
            <input type="submit" value="Pesquisar" />
            <input type="button" value="Novo"  onclick="location.href='Create'"/>
        </p>       


</asp:Content>

