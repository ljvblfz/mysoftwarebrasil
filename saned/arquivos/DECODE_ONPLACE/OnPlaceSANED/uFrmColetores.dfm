�
 TFRMCOLETORES 0�
  TPF0�TfrmColetoresfrmColetoresCaption    ClientHeighttExplicitHeight�PixelsPerInch`
TextHeight � TLabelLabel1Left0Top� Width'HeightCaptionAgente:  �TLabelLabel3Left0TopWidth$HeightCaptionMaleta:FocusControl
DBEdMaleta  �TLabelLabel4Left0TopWidth!HeightCaptionGrupo:FocusControl	DBEdGrupo  �TLabelLabel5Left� TopWidthHeightCaptionRota:FocusControlDBEdRota  �TLabelLabel6Left� Top� WidthHeightCaptionData:FocusControlDBEdData  �TLabelLabel7Left0Top4Width2HeightCaption   Descrição:FocusControl	DBEdTexto  �TPanelpTop �TLabellVersionHeight   �TPanelpBottomTopLExplicitTopL �TSpeedButtonsbtnSairExplicitLeft�  �TDBNavigatorDBNavigatorHints.Strings    �TDBGridDBGridHeight� OptionsdgTitlesdgIndicatordgColumnResize
dgColLines
dgRowLinesdgRowSelectdgAlwaysShowSelectiondgConfirmDeletedgCancelOnExit   �	TDBEdit
DBEdMaletaLeftpTop� WidthIHeight	DataField	pe_maleta
DataSourceDSPrincipalTabOrder  �
TDBEdit	DBEdGrupoLeftpTopWidthIHeight	DataFieldpe_grupo
DataSourceDSPrincipalTabOrder  �TDBEditDBEdRotaLeft� TopWidthAHeight	DataFieldpe_rota
DataSourceDSPrincipalTabOrder  �TDBEditDBEdDataLeft� Top� Width� Height	DataFieldpe_data
DataSourceDSPrincipalTabOrder  �TDBEdit	DBEdTextoLeftpTop1Width�Height	DataFieldpe_descricao
DataSourceDSPrincipalTabOrder  �TDBLookupComboBoxDBLCmbAgenteLeftpTop� Width�Height	DataField	pe_agente
DataSourceDSPrincipalKeyField	ag_codigo	ListFieldagente
ListSourceDSAgenteTabOrder  �TTabletbPrincipal	TableNamedbo.vw_problema_equipamento TStringFieldtbPrincipalpe_nome_agente	FieldNamepe_nome_agenteSize  TIntegerFieldtbPrincipalpe_agente	FieldName	pe_agenteRequired	  TIntegerFieldtbPrincipalpe_maleta	FieldName	pe_maletaRequired	  TIntegerFieldtbPrincipalpe_grupo	FieldNamepe_grupoRequired	  TIntegerFieldtbPrincipalpe_rota	FieldNamepe_rotaRequired	  TDateTimeFieldtbPrincipalpe_data	FieldNamepe_dataRequired	DisplayFormatdd/mm/yyyy hh:nnEditMask00/00/0000 00:00  TStringFieldtbPrincipalpe_descricao	FieldNamepe_descricaoSized   TQuery	qryAgenteDatabaseNamedbMainSQL.StringsW   select ag_codigo, ag_nome, rtrim(convert(char, ag_codigo)) + ' · ' + ag_nome as agentefrom agentes LeftpTop TIntegerFieldqryAgenteag_codigo	FieldName	ag_codigo  TStringFieldqryAgenteag_nome	FieldNameag_nomeSize  TStringFieldqryAgenteagente	FieldNameagenteSize?   TDataSourceDSAgenteDataSet	qryAgenteLeftpTop0     