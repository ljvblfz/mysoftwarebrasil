using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("SANEDWebService")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("SANEDWebService")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2010")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("3d5900ae-111a-45be-96b3-d9e4606ca793")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion("1.0.1.4")]
[assembly: AssemblyFileVersion("1.0.1.4")]
/*
  Correção na distribuição conforme abaixo
 
    Tabela ONP_FATURA	valores arredondados
    campo des_linha_digitavel sem os digitos verificadores
    Tabela ONP_FATURA_AVISOS	vazia
    Tabela ONP_HIDROMETRO	matriculas não são da rota
    Tabela ONP_MATRICULA	campo seq_leitura errado deve pegar a sequencia de leitura da tabela IDA_LIGACOES
    Tabela ONP_MENSAGEM_MOVIMENTO	vazia
    Tabela ONP_MOVIMENTO	campo dat_troca deve pegar da tabela IDA_LIGACOES campo data de instalação
        cod_agente coloquei o agente 19 e está trazendo agente 1
        campo val_numero_leituras errado
    Tabela ONP_PARAMETRO_RETENCAO	Dados errados, faltou o registro 1
    Tabela ONP_QUALIDADE_AGUA	campo val_media arredondando
    Tabela ONP_REFERENCIA_PENDENTE	vazia
    Tabela ONP_ROTEIRO	vazia
    Tabela ONP_SERVICO_FATURA	vazia, pegar da tabela IDA_SERVICOS
    Tabela ONP_TABELAS_CARGA	vazia
    Tabela ONP_TAXA_TARIFA_FAIXA	arredondando os campos de valores
    Tabela ONP_UTILIZACAO_LIGACAO	vazia
 */

