<?php

/**
 *
 *
 * @name Gerador.php
 * @author Alexis Moura 14/08/2010 20:10:36
 * @package Model
 * @version $Id$
 */
class Gerador
{

	protected $Model;
	protected $Dao;
	protected $Bfl;
	protected $AppConfig;
	protected $Assembly;
	protected $Project;
	protected $Cadastros;
	protected $masterPage;
	protected $masterPagecs;
	protected $webConfigWEB;
	protected $DefaultWEB;

	public function GeraFonte($Dados,$projetos)
	{
		$this->GetProjeto($Dados);
		$this->GetModel($Dados);
		$this->GetDao($Dados);
		$this->GetBfl($Dados);
		$this->GetAppConfig($Dados);
		$this->GetAssembly($Dados);

		$retorno["Project"] = $this->Project;
		$retorno["Assembly"] = $this->Assembly;
		$retorno["AppConfig"] = $this->AppConfig;
		$retorno["BFL"] = $this->Bfl;
		$retorno["DAO"] = $this->Dao;
		$retorno["Model"] = $this->Model;

		if($projetos["web"]==1)
		{
			$this->getCadastroWEB($Dados);
			$this->getMasterPageWEB($Dados);
			$this->getMasterPagecsWEB($Dados);
			$this->getWebConfigWEB($Dados);
			$this->getDefaultWEB($Dados);

			$retorno["WEB"]["cadastros"] = $this->Cadastros;
			$retorno["WEB"]["masterpage"] = $this->masterPage;
			$retorno["WEB"]["masterpagecs"] = $this->masterPagecs;
			$retorno["WEB"]["webConfig"] = $this->webConfigWEB;
			$retorno["WEB"]["default"] = $this->DefaultWEB;
		}

		return $retorno;
	}

	protected function GetModel($Dados){

		$variavel="";
		$metodo="";
		$primaria="";
		$insert = "";
		foreach($Dados["tabela"] as $key => $value){

			$variavel="";
			$metodo="";
			$primaria="";
			$insertCampo="";
			$insertCampo2="";
			$insertFormat="";
			$cont = 0;
			$separador = "";
			foreach($value as $campo){

				//$variavel.="private ".$campo["tipo"]."  _".$campo["nome"].";\n";

				if($campo["primaria"]){
					$metodo.='[PersistenceProperty("'.$campo["nome"].'", PersistenceParameterType.Key)]'."\n";
				}else{
					$metodo.='[PersistenceProperty("'.$campo["nome"].'")]'."\n";
				}
				$metodo.="public ".$campo["tipo"]." ".$campo["nome"]."
	{get;set;}
	";
	
				$insertCampo.= $separador.$campo["nome"].'
				';
				
				$insertCampo2.= $separador.'('.$campo["nome"].' != null ? (String.IsNullOrEmpty('.$campo["nome"].'.ToString()) ? "\'\'" : '.$campo["nome"].'.ToString()) : "\'\'")
				';
				
				if($campo["tipo"] == 'DateTime?' || $campo["tipo"] == 'DateTime' || $campo["tipo"] == 'string')
				{
					$insertFormat.= $separador.'\'{'.$cont.'}\'
					';
				}
				else
				{
					$insertFormat.= $separador.'{'.$cont.'}
					';
				}
				$separador=',';
				$cont++;
			
			}
			
			$insert = '        
        public string __ToSQL
        {
            get
            {
                return String.Format(@"
                                        INSERT INTO '.$key.'
										(
												'.$insertCampo.'
										)
                                        VALUES
										(
												'.$insertFormat.'
										)"
												,'.$insertCampo2.'
										
									);
            }
        }
';
			
			$this->Model[$Dados["classe"][$key].".cs"] = <<<XML
using System;
using GDA;
using System.Runtime.Serialization;
using {$Dados["projeto"]}_DATA.DAL;

namespace {$Dados["projeto"]}_DATA.Model
{
    /// <summary>
    /// Classe que representa a tabela {$key}.
    /// </summary>
    [PersistenceClass("{$key}")]
    [PersistenceBaseDAO(typeof({$Dados["classe"][$key]}DAO))]
    [Serializable]
    public class {$Dados["classe"][$key]} : Persistent
    {
		#region Metodos
		{$metodo}
		#endregion
		
		#region Query Importacao
		{$insert}
		#endregion
    }
}
XML;
		}

	}

	protected function GetDao($Dados){

		$where = "";
		$updater = "";
		$updaterCampos = "";
		foreach($Dados["tabela"] as $key => $value){

			$where = "";
			$updater = "";
			$updaterCampos = "";
			foreach($value as $campo){

			  $where.= " {$campo['nome']} = '\"+ obj{$Dados['classe'][$key]}.{$campo['nome']}+@\"' AND \n";
			  $updaterCampos.= "{$campo['nome']} = '\" + obj{$Dados['classe'][$key]}.{$campo['nome']} + @\"' , \n";
			  	if($campo["primaria"]){

					$updater.= "{$campo['nome']} = '\" + obj{$Dados['classe'][$key]}.{$campo['nome']} + @\"' AND \n";
				}
			}
			$where = rtrim($where," AND \n");
			$updater = rtrim($updater," AND \n");
			$updaterCampos = rtrim($updaterCampos," , \n");


		$this->Dao[$Dados["classe"][$key]."DAO.cs"] = <<<DAO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using {$Dados["projeto"]}_DATA.Model;

namespace {$Dados["projeto"]}_DATA.DAL
{
    public class {$Dados["classe"][$key]}DAO : BaseDAO<{$Dados["classe"][$key]}>
    {
        public List<{$Dados["classe"][$key]}> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM {$key}
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }
		
		public List<{$Dados["classe"][$key]}> Importar(int grupo,int rotaIni,int rotaFim)
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM {$key}
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

    }
}
DAO;
		}
	}

	protected function GetBfl($Dados){

		foreach($Dados["tabela"] as $key => $value){


		$this->Bfl[$Dados["classe"][$key]."Flow.cs"] = <<<BFL
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using GDA;
using {$Dados["projeto"]}_DATA.DAL;
using {$Dados["projeto"]}_DATA.Model;

namespace {$Dados["projeto"]}_DATA.BFL
{
    public class {$Dados["classe"][$key]}Flow
    {
        /// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static List<{$Dados["classe"][$key]}> Lista()
        {
            {$Dados["classe"][$key]}DAO {$Dados["classe"][$key]} = new {$Dados["classe"][$key]}DAO();
            return {$Dados["classe"][$key]}.Lista();
        }

        /// <summary>
        /// Metodo que insere um registro na tabela
        /// </summary>
        /// <returns></returns>
        public static void Insert(List<{$Dados["classe"][$key]}> List{$Dados["classe"][$key]})
        {
            {$Dados["classe"][$key]}DAO {$Dados["classe"][$key]} = new {$Dados["classe"][$key]}DAO();

            try
            {
                foreach({$Dados["classe"][$key]} Item{$Dados["classe"][$key]} in List{$Dados["classe"][$key]})
                    {$Dados["classe"][$key]}.Insert(Item{$Dados["classe"][$key]});
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
		
		/// <summary>
        ///  Metodo que retorna todos os dados
        /// </summary>
        /// <returns></returns>
        public static string getImpotacao(int grupo,int rotaIni,int rotaFim)
        {
            string result = "";
            {$Dados["classe"][$key]}DAO {$Dados["classe"][$key]} = new {$Dados["classe"][$key]}DAO();
            List<{$Dados["classe"][$key]}> lista = {$Dados["classe"][$key]}.Importar(grupo,rotaIni,rotaFim);
            foreach({$Dados["classe"][$key]} item in lista)
            {
                result+=item.__ToSQL;
            }
            return result;
        }
    }
}
BFL;
		}

	}

	protected function GetAppConfig($Dados){

		$this->AppConfig = <<<STRING
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="gda" type="GDA.Common.Configuration.Handlers.GDASectionHandler, GDA"/>
  </configSections>
    <gda>
      <GDA>
        <DefaultProvider name="conexao"/>
        <Debug trace="true"/>
        <!--STRING DE CONFIGURCAO DO BANCO DE DADOS-->
        <ProvidersConfiguration>
          <Info name="conexao" providerName="MsSql" connectionString="Data Source={$Dados["host"]};Initial Catalog={$Dados["banco"]};Persist Security Info=True;User ID={$Dados["usuario"]};Password={$Dados["senha"]}; Connect Timeout=60"/>
        </ProvidersConfiguration>
        <Providers>
          <Provider name="MsSql" classNamespace="GDA.Provider.MsSql" assembly="GDA" />
        </Providers>
        <ModelsNamespace>
          <Namespace assembly="*" name="Saned_DATA.Model"/>
        </ModelsNamespace>
      </GDA>
    </gda>
    <appSettings/>
  <connectionStrings/>
</configuration>

STRING;
	}

	protected function GetAssembly($Dados){

		$this->Assembly = <<<XML
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("{$Dados["projeto"]}_DATA")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Velp Soluções em Tecnologia")]
[assembly: AssemblyProduct("{$Dados["projeto"]}_DATA")]
[assembly: AssemblyCopyright("Copyright © Velp Soluções em Tecnologia 2010")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("5f11d2b7-4394-4407-a901-7caa3d44819f")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
XML;

	}

	protected function GetProjeto($Dados){

		$includeBFL = "";
		$includeDAL = "";
		$includeModel = "";
		foreach($Dados["tabela"] as $key => $value){

			$includeBFL.='<Compile Include="BFL\\'.$Dados["classe"][$key].'Flow.cs" />';
			$includeDAL.='<Compile Include="DAL\\'.$Dados["classe"][$key].'DAO.cs" />';
			$includeModel.='<Compile Include="Model\\'.$Dados["classe"][$key].'.cs" />';
		}

		$this->Project = <<<XML
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="3.5" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProductVersion>9.0.30729</ProductVersion>
    <SchemaVersion>2.0</SchemaVersion>
    <ProjectGuid>{DF38D694-3A81-4398-BC68-A22C47E92893}</ProjectGuid>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>{$Dados["projeto"]}_DATA</RootNamespace>
    <AssemblyName>{$Dados["projeto"]}_DATA</AssemblyName>
    <TargetFrameworkVersion>v3.5</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\/Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="GDA, Version=1.2.7.17086, Culture=neutral, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>Contribuicoes\GDA.dll</HintPath>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.Core">
      <RequiredTargetFramework>3.5</RequiredTargetFramework>
    </Reference>
    <Reference Include="System.Xml.Linq">
      <RequiredTargetFramework>3.5</RequiredTargetFramework>
    </Reference>
    <Reference Include="System.Data.DataSetExtensions">
      <RequiredTargetFramework>3.5</RequiredTargetFramework>
    </Reference>
    <Reference Include="System.Data" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <ItemGroup>
	{$includeBFL}
	{$includeDAL}
	{$includeModel}
    <Compile Include="Properties\AssemblyInfo.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="app.config" />
  </ItemGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it.
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>
XML;
	}



	public function getCadastroWEB($Dados)
	{
		$DataKeyName = "";
		$InsertItemTemplate = "";
		$LayoutTemplate = "";
		$ItemTemplate = "";
		$AlternatingItemTemplate = "";
		$EditItemTemplate = "";
		$SelectedItemTemplate = "";
		$DataObjectTypeName = "";
		$TypeName = "";
		$UpdateParameters = "";
		$InsertParameters = "";

		foreach($Dados["tabela"] as $key => $value){

			$DataKeyName = "";
			$InsertItemTemplate = "";
			$LayoutTemplate = "";
			$ItemTemplate = "";
			$AlternatingItemTemplate = "";
			$EditItemTemplate = "";
			$SelectedItemTemplate = "";
			$DataObjectTypeName = "";
			$TypeName = "";
			$UpdateParameters = "";
			$InsertParameters = "";

			foreach($value as $campo){

			  	if($campo["primaria"] && $DataKeyName == ""){
					$DataKeyName = $campo["nome"];
				}

				if(is_null($campo["tamanho"]))
				{
					$campo["tamanho"] = 10;
				}
				$InsertItemTemplate.=
<<<HTML

                    <td>
                        <asp:TextBox ID="{$campo["nome"]}TextBox" runat="server" Text='<%# Bind("{$campo["nome"]}") %>' MaxLength="{$campo["tamanho"]}" />
                    </td>
HTML;
				$LayoutTemplate.=
<<<HTML

					<th id="Th{$campo["nome"]}" runat="server">{$campo["nome"]}</th>
HTML;
				$ItemTemplate.=
<<<HTML

                    <td>
                        <asp:Label ID="{$campo["nome"]}Label" runat="server" Text='<%# Eval("{$campo["nome"]}") %>' />
                    </td>
HTML;

				$AlternatingItemTemplate.=
<<<HTML

                    <td>
                        <asp:Label ID="{$campo["nome"]}Label2" runat="server" Text='<%# Eval("{$campo["nome"]}") %>' />
                    </td>
HTML;
				if($campo["primaria"]){
				$EditItemTemplate.=
<<<HTML
                    <td>
                        <asp:TextBox ID="{$campo["nome"]}TextBox2" runat="server" Text='<%# Bind("{$campo["nome"]}") %>' ReadOnly="true" CssClass="medTxtAreaRO"/>
                    </td>
HTML;
				}else{

				$EditItemTemplate.=
<<<HTML

                    <td>
                        <asp:TextBox ID="{$campo["nome"]}TextBox2" runat="server" Text='<%# Bind("{$campo["nome"]}") %>' MaxLength="{$campo["tamanho"]}" />
                    </td>
HTML;
				}
				$SelectedItemTemplate.=
<<<HTML

                    <td>
                        <asp:Label ID="{$campo["nome"]}Label3" runat="server" Text='<%# Eval("{$campo["nome"]}") %>' />
                    </td>
HTML;
				$tipo = str_replace("?","" ,$campo["tipo"]);
				$UpdateParameters.=
<<<HTML
        <UpdateParameters>
            <asp:Parameter DbType="{$tipo}" Name="{$campo["nome"]}" Size="{$campo["tamanho"]}" />
        </UpdateParameters>
HTML;


			}

			$DataObjectTypeName = $Dados["projeto"]."_DATA.Model.".$Dados["classe"][$key];
			$TypeName = $Dados["projeto"]."_DATA.DAL.".$Dados["classe"][$key]."DAO";

		$this->Cadastros[$Dados["classe"][$key].".aspx"] =
<<<ASP
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>
<script runat="server">
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Title" Runat="Server">{$Dados["classe"][$key]}</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <h2>{$Dados["classe"][$key]}</h2>
    <div>
        <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1"
            InsertItemPosition="LastItem" DataKeyNames="{$DataKeyName}">
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert"  CssClass="bottonInserir" Onmouseover="Tip('Inserir')" Onmouseout="UnTip()" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel"  CssClass="bottonLimpar" Onmouseover="Tip('Limpar')" Onmouseout="UnTip()" />
                    </td>
					{$InsertItemTemplate}
                </tr>
            </InsertItemTemplate>
            <LayoutTemplate>
                <table id="Table1" runat="server">
                    <tr id="Tr1" runat="server">
                        <td id="Td1" runat="server">
                            <table ID="itemPlaceholderContainer" runat="server" border="0">
                                <tr id="Tr2" runat="server">
                                    <th id="Th1" runat="server" style="width:80px"></th>
									{$LayoutTemplate}
                                </tr>
                                <tr ID="itemPlaceholder" runat="server"></tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="Tr3" runat="server">
                        <td id="Td2" runat="server">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" CssClass="bottonExcluir" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" CssClass="bottonEditar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />
                    </td>
					{$ItemTemplate}
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" CssClass="bottonExcluir" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" CssClass="bottonEditar" Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />
                    </td>
					{$AlternatingItemTemplate}
                </tr>
            </AlternatingItemTemplate>
            <EmptyDataTemplate>
                <table id="Table2" runat="server"
                    style="">
                    <tr>
                        <td>
                            Nenhum dado foi retornado.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" CssClass="bottonEditarSalvar" Onmouseover="Tip('Salvar')" Onmouseout="UnTip()" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" CssClass="bottonCancelar" Onmouseover="Tip('Cancelar')" Onmouseout="UnTip()" />
                    </td>
					{$EditItemTemplate}
                </tr>
            </EditItemTemplate>
            <SelectedItemTemplate>
                <tr>
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" CssClass="bottonExcluir" Onmouseover="Tip('Excluir')" Onmouseout="UnTip()" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" CssClass="bottonEditar"  Onmouseover="Tip('Editar')" Onmouseout="UnTip()" />
                    </td>
					{$SelectedItemTemplate}
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
            DataObjectTypeName="{$DataObjectTypeName}" DeleteMethod="Delete"
            InsertMethod="Insert" SelectMethod="Select"
            TypeName="{$TypeName}" UpdateMethod="Update">
        </asp:ObjectDataSource>
    </div>
</asp:Content>
ASP;
		}

	}


	public function getMasterPageWEB($Dados)
	{
		$menu="";
		$contador = 1;
		foreach($Dados["tabela"] as $key => $value){

			$menu.=
<<<HTML
                        <b class="rtop2">
                            <b class="r1"></b> <b class="r2"></b> <b class="r3"></b> <b class="r4"></b>
                        </b>
                            <li><div><asp:HyperLink ID="HyperLink{$contador}" runat="server" NavigateUrl="~/Cadastros/{$Dados["classe"][$key]}.aspx">{$Dados["classe"][$key]}</asp:HyperLink></div></li>
                        <b class="rbottom">
                            <b class="r4"></b> <b class="r3"></b> <b class="r2"></b> <b class="r1"></b>
                        </b>
HTML;
			$contador++;
		}

		$this->masterPage =
<<<HTML
<%@ Master Language="C#" AutoEventWireup="true" CodeFile="MasterPage.master.cs" Inherits="MasterPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><asp:ContentPlaceHolder ID="Title" runat="server" /></title>
    <link  runat="server" href="Style/Global.css" rel="stylesheet" type="text/css" />
    <asp:ContentPlaceHolder id="head" runat="server">
    </asp:ContentPlaceHolder>
</head>
<body>
    <div id="header" class="top">
        <div id="topfoto" class="topfoto"></div>
        <div id="logo" class="logo"></div>
    </div>
    <div class="page">
        <div id="menu">
            <ul>
                <b class="rtop2">
                    <b class="r1"></b> <b class="r2"></b> <b class="r3"></b> <b class="r4"></b>
                </b>
                <li><a href="#">Cadastro</a>
                <b class="rbottom">
                    <b class="r4"></b> <b class="r3"></b> <b class="r2"></b> <b class="r1"></b>
                </b>
                    <ul>
						{$menu}
                    </ul>
                </li>
            </ul>
        </div>
        <div id="topConteudo" class="topConteudo"></div>
        <div id="main" class="conteudo">
            <b class="rtop">
			  <b class="r1"></b> <b class="r2"></b> <b class="r3"></b> <b class="r4"></b>
			</b>
                <form id="form1" runat="server">
                    <asp:ScriptManager ID="ScriptManager2" runat="server" />
                    <asp:ContentPlaceHolder id="ContentPlaceHolder2" runat="server" />
                </form>
            <b class="rbottom">
			  <b class="r4"></b> <b class="r3"></b> <b class="r2"></b> <b class="r1"></b>
			</b>
        </div>
    </div>
    <div id="footer">
        <address>2010 - Copyright © Velp Soluções em Tecnologia   -  <a href="http://www.velp.com.br/" title="VELP" rel="following">www.velp.com.br</a></address>
    </div>
</body>
</html>


HTML;
	}


	public function getWebConfigWEB($Dados)
	{

		$this->webConfigWEB =
<<<XML
<?xml version="1.0"?>
<configuration>
	<configSections>
    <section name="gda" type="GDA.Common.Configuration.Handlers.GDASectionHandler, GDA"/>
    <sectionGroup name="system.web.extensions" type="System.Web.Configuration.SystemWebExtensionsSectionGroup, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35">
			<sectionGroup name="scripting" type="System.Web.Configuration.ScriptingSectionGroup, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35">
				<section name="scriptResourceHandler" type="System.Web.Configuration.ScriptingScriptResourceHandlerSection, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" requirePermission="false" allowDefinition="MachineToApplication"/>
				<sectionGroup name="webServices" type="System.Web.Configuration.ScriptingWebServicesSectionGroup, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35">
					<section name="jsonSerialization" type="System.Web.Configuration.ScriptingJsonSerializationSection, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" requirePermission="false" allowDefinition="Everywhere"/>
					<section name="profileService" type="System.Web.Configuration.ScriptingProfileServiceSection, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" requirePermission="false" allowDefinition="MachineToApplication"/>
					<section name="authenticationService" type="System.Web.Configuration.ScriptingAuthenticationServiceSection, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" requirePermission="false" allowDefinition="MachineToApplication"/>
					<section name="roleService" type="System.Web.Configuration.ScriptingRoleServiceSection, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" requirePermission="false" allowDefinition="MachineToApplication"/>
				</sectionGroup>
			</sectionGroup>
		</sectionGroup>
  </configSections>
  <gda>
    <GDA>
      <DefaultProvider name="conexao"/>
      <Debug trace="true"/>
      <!--STRING DE CONFIGURCAO DO BANCO DE DADOS-->
      <ProvidersConfiguration>
          <Info name="conexao" providerName="MsSql" connectionString="Data Source={$Dados["host"]};Initial Catalog={$Dados["banco"]};Persist Security Info=True;User ID={$Dados["usuario"]};Password={$Dados["senha"]}; Connect Timeout=60"/>
      </ProvidersConfiguration>
      <Providers>
        <Provider name="MsSql" classNamespace="GDA.Provider.MsSql" assembly="GDA" />
      </Providers>
      <ModelsNamespace>
        <Namespace assembly="*" name="Saned_DATA.Model"/>
      </ModelsNamespace>
    </GDA>
  </gda>
  <appSettings/>
  <system.web>
		<!--
            Set compilation debug="true" to insert debugging
            symbols into the compiled page. Because this
            affects performance, set this value to true only
            during development.
        -->
		<compilation debug="true">
			<assemblies>
				<add assembly="System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"/>
				<add assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
				<add assembly="System.Data.DataSetExtensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"/>
				<add assembly="System.Xml.Linq, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"/>
			</assemblies>
		</compilation>
		<!--
            The <authentication> section enables configuration
            of the security authentication mode used by
            ASP.NET to identify an incoming user.
        -->
		<authentication mode="Windows"/>
		<!--
            The <customErrors> section enables configuration
            of what to do if/when an unhandled error occurs
            during the execution of a request. Specifically,
            it enables developers to configure html error pages
            to be displayed in place of a error stack trace.

        <customErrors mode="RemoteOnly" defaultRedirect="GenericErrorPage.htm">
            <error statusCode="403" redirect="NoAccess.htm" />
            <error statusCode="404" redirect="FileNotFound.htm" />
        </customErrors>
        -->
		<pages>
			<controls>
				<add tagPrefix="asp" namespace="System.Web.UI" assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
				<add tagPrefix="asp" namespace="System.Web.UI.WebControls" assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
			</controls>
		</pages>
		<httpHandlers>
			<remove verb="*" path="*.asmx"/>
			<add verb="*" path="*.asmx" validate="false" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
			<add verb="*" path="*_AppService.axd" validate="false" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
			<add verb="GET,HEAD" path="ScriptResource.axd" type="System.Web.Handlers.ScriptResourceHandler, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" validate="false"/>
		</httpHandlers>
		<httpModules>
			<add name="ScriptModule" type="System.Web.Handlers.ScriptModule, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
		</httpModules>
	</system.web>
	<system.codedom>
		<compilers>
			<compiler language="c#;cs;csharp" extension=".cs" warningLevel="4" type="Microsoft.CSharp.CSharpCodeProvider, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
				<providerOption name="CompilerVersion" value="v3.5"/>
				<providerOption name="WarnAsError" value="false"/>
			</compiler>
			<compiler language="vb;vbs;visualbasic;vbscript" extension=".vb" warningLevel="4" type="Microsoft.VisualBasic.VBCodeProvider, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
				<providerOption name="CompilerVersion" value="v3.5"/>
				<providerOption name="OptionInfer" value="true"/>
				<providerOption name="WarnAsError" value="false"/>
			</compiler>
		</compilers>
	</system.codedom>
	<!--
        The system.webServer section is required for running ASP.NET AJAX under Internet
        Information Services 7.0.  It is not necessary for previous version of IIS.
    -->
	<system.webServer>
		<validation validateIntegratedModeConfiguration="false"/>
		<modules>
			<remove name="ScriptModule"/>
			<add name="ScriptModule" preCondition="managedHandler" type="System.Web.Handlers.ScriptModule, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
		</modules>
		<handlers>
			<remove name="WebServiceHandlerFactory-Integrated"/>
			<remove name="ScriptHandlerFactory"/>
			<remove name="ScriptHandlerFactoryAppServices"/>
			<remove name="ScriptResource"/>
			<add name="ScriptHandlerFactory" verb="*" path="*.asmx" preCondition="integratedMode" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
			<add name="ScriptHandlerFactoryAppServices" verb="*" path="*_AppService.axd" preCondition="integratedMode" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
			<add name="ScriptResource" preCondition="integratedMode" verb="GET,HEAD" path="ScriptResource.axd" type="System.Web.Handlers.ScriptResourceHandler, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
		</handlers>
	</system.webServer>
	<runtime>
		<assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
			<dependentAssembly>
				<assemblyIdentity name="System.Web.Extensions" publicKeyToken="31bf3856ad364e35"/>
				<bindingRedirect oldVersion="1.0.0.0-1.1.0.0" newVersion="3.5.0.0"/>
			</dependentAssembly>
			<dependentAssembly>
				<assemblyIdentity name="System.Web.Extensions.Design" publicKeyToken="31bf3856ad364e35"/>
				<bindingRedirect oldVersion="1.0.0.0-1.1.0.0" newVersion="3.5.0.0"/>
			</dependentAssembly>
		</assemblyBinding>
	</runtime>
</configuration>


XML;


	}


	public function getMasterPagecsWEB($Dados)
	{

		$this->masterPagecs =
<<<ASP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}

ASP;

	}

	public function getDefaultWEB()
	{
		$this->DefaultWEB = '<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>';
	}

}//fim class