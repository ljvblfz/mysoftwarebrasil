﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Contato>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Pesquisa
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Pesquisa</h2>
    <% using (Html.BeginForm()) {%>
    
        <%=ViewData["pesquisa"]%>
        <p>
            <input type="submit" value="Pesquisar" />
            <input type="button" value="Novo"  onclick="location.href='Create'"/>
        </p>       
    <% } %>

</asp:Content>

