<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<script language="javascript" type="text/javascript" src="../Script/wz_tooltip.js" ></script>
    <div class="siteMap">
        <span id="ctl00_ContentPlaceHolder1_Label1">Inicial</span>
<%--        <span class="destaqueSiteMap" id="ctl00_ContentPlaceHolder1_Label2">Parametro</span>--%>
    </div>
    <div class="topConteudo">
    </div>
    <div class="bgConteudo">
        <div class="txtPagina">
            <span id="ctl00_ContentPlaceHolder1_Label4"></span>
            <h3 class="titForm">Home</h3>
             <div class="divTabela">      
             </div>
        </div>
    </div>
    <div class="bottomConteudo">
    </div>
    <div class="bottomPagina">
        <span id="ctl00_ContentPlaceHolder1_Label3">Sistema de Gestão de Saneamento</span>
    </div>
</asp:Content>

