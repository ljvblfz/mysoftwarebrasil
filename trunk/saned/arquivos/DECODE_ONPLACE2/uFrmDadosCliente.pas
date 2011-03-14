unit uFrmDadosCliente;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, StdCtrls, ExtCtrls, DBCtrls, Buttons, DBTables, DBGrids,
  DB, ComCtrls;

type
  TfrmDadosCliente = class(TfrmBaseClient)
    GroupBox1: TGroupBox;
    PSelecao: TPanel;
    Shape1: TShape;
    Label1: TLabel;
    Label2: TLabel;
    Label4: TLabel;
    cmbGrupo: TComboBox;
    cmbRota: TComboBox;
    DBNavigador: TDBNavigator;
    EdMatricula: TEdit;
    EdSequencia: TEdit;
    Label3: TLabel;
    sbtPesquisa: TSpeedButton;
    qryGrupo: TQuery;
    qryRoteiro: TQuery;
    GroupBox3: TGroupBox;
    DBGrid1: TDBGrid;
    qryPrincipal: TQuery;
    qryCDC: TQuery;
    DSPrincipal: TDataSource;
    DSCDC: TDataSource;
    qryHistorico: TQuery;
    DSHistorico: TDataSource;
    qryHistoricohc_ref_historico: TDateTimeField;
    qryHistoricohc_consumo: TIntegerField;
    qryHistoricohc_leitura: TIntegerField;
    qryHistoricohc_ocorrencia_leitura: TStringField;
    qryHistoricohc_dias_consumo: TIntegerField;
    qryHistoricohc_data_leitura: TDateTimeField;
    PCMatricula: TPageControl;
    tbsDados: TTabSheet;
    tbsHistorico: TTabSheet;
    tbsServico: TTabSheet;
    GroupBox2: TGroupBox;
    Label15: TLabel;
    DBTConsumoMedio: TDBText;
    DBGrid2: TDBGrid;
    GroupBox4: TGroupBox;
    DBTNome: TDBText;
    DBTEndereco: TDBText;
    DBTComplemento: TDBText;
    DBTCategoria: TDBText;
    DBTIdentificar: TDBText;
    DBTNatureza: TDBText;
    Label5: TLabel;
    DBTGrupo: TDBText;
    Label6: TLabel;
    DBTRota: TDBText;
    Label7: TLabel;
    DBTSequencia: TDBText;
    DBTHidrometro: TDBText;
    DBTCapacidadeHD: TDBText;
    Label8: TLabel;
    DBTInscricao: TDBText;
    Label9: TLabel;
    DBTEcoRes: TDBText;
    DBTEcoSoc: TDBText;
    Label12: TLabel;
    Label10: TLabel;
    DBTEcoInd: TDBText;
    DBTEcoCom: TDBText;
    Label11: TLabel;
    Label13: TLabel;
    DBTEcoPub: TDBText;
    DBTEcoEA: TDBText;
    Label14: TLabel;
    Bevel1: TBevel;
    Label16: TLabel;
    DBTReferencia: TDBText;
    Bevel2: TBevel;
    qryServico: TQuery;
    DSServico: TDataSource;
    GroupBox5: TGroupBox;
    DBGrid3: TDBGrid;
    qryServicosr_matricula: TIntegerField;
    qryServicosr_sequencia: TIntegerField;
    qryServicosr_descricao: TStringField;
    qryServicosr_valor: TFloatField;
    qryServicooperador: TStringField;
    qryServicototal_credito: TFloatField;
    qryServicototal_debito: TFloatField;
    Label17: TLabel;
    DBTTotalDebito: TDBText;
    Label18: TLabel;
    DBTTotalCredito: TDBText;
    Label19: TLabel;
    DBTSetor: TDBText;
    GroupBox7: TGroupBox;
    DBTDescBloqueio: TDBText;
    Label25: TLabel;
    DBTDataBloqueio: TDBText;
    Label26: TLabel;
    DBTDataDesbloqueio: TDBText;
    Label24: TLabel;
    Label27: TLabel;
    Label28: TLabel;
    Bevel3: TBevel;
    DBTDiasBloqAnt: TDBText;
    DBTDiasBloqAtual: TDBText;
    Label29: TLabel;
    DBText1: TDBText;
    qryDocumentos: TQuery;
    DSDocumentos: TDataSource;
    tbsDocumento: TTabSheet;
    GroupBox9: TGroupBox;
    DBGrid4: TDBGrid;
    qryDocumentosDocumento: TStringField;
    qryDocumentosTexto: TStringField;
    qryDocumentosData_Vencimento: TDateTimeField;
    qryDocumentosValor_Total: TFloatField;
    qryDescarga: TQuery;
    DSDescarga: TDataSource;
    tbsDescarga: TTabSheet;
    GroupBox10: TGroupBox;
    tbsValores: TTabSheet;
    tbsAdicional: TTabSheet;
    GroupBox8: TGroupBox;
    Bevel4: TBevel;
    Label23: TLabel;
    DBTVencimento: TDBText;
    Label30: TLabel;
    DBTFlagTroca: TDBText;
    Label31: TLabel;
    DBTLeituraInicial: TDBText;
    DBTDataInstHD: TDBText;
    Label32: TLabel;
    Label33: TLabel;
    DBText2: TDBText;
    Label34: TLabel;
    DBText3: TDBText;
    Label35: TLabel;
    DBText4: TDBText;
    Label36: TLabel;
    DBTDescDesconto: TDBText;
    Label37: TLabel;
    DBTLimite: TDBText;
    Label38: TLabel;
    DBTPercDesc: TDBText;
    Label39: TLabel;
    Label40: TLabel;
    Label41: TLabel;
    Label42: TLabel;
    DBText6: TDBText;
    DBText7: TDBText;
    DBText8: TDBText;
    GroupBox6: TGroupBox;
    Label20: TLabel;
    DBTEnderecoAlternativo: TDBText;
    Label21: TLabel;
    DBTBanco: TDBText;
    Label22: TLabel;
    DBTAgencia: TDBText;
    Label43: TLabel;
    DBTDataLeit: TDBText;
    Label45: TLabel;
    DBTLeituraReal: TDBText;
    Label46: TLabel;
    DBTOcorrencia: TDBText;
    GroupBox11: TGroupBox;
    Label44: TLabel;
    DBTDataLeitAnt: TDBText;
    Label47: TLabel;
    DBTLeituraAnt: TDBText;
    Label48: TLabel;
    DBTOcorrenciaAnt: TDBText;
    Label49: TLabel;
    DBTDiasConsumo: TDBText;
    DBTOcorrenciaDesc: TDBText;
    Label50: TLabel;
    DBTLeituraAjustada: TDBText;
    GroupBox12: TGroupBox;
    Label51: TLabel;
    Label53: TLabel;
    Label54: TLabel;
    Label52: TLabel;
    Label55: TLabel;
    DBText5: TDBText;
    DBText9: TDBText;
    DBText10: TDBText;
    DBText11: TDBText;
    DBText12: TDBText;
    DBText13: TDBText;
    Label56: TLabel;
    DBText14: TDBText;
    DBText15: TDBText;
    Label57: TLabel;
    DBText16: TDBText;
    DBText17: TDBText;
    Label58: TLabel;
    DBText18: TDBText;
    DBText19: TDBText;
    Label60: TLabel;
    DBText21: TDBText;
    Label61: TLabel;
    DBText22: TDBText;
    DBText23: TDBText;
    GroupBox13: TGroupBox;
    Label62: TLabel;
    DBText24: TDBText;
    DBText25: TDBText;
    Label63: TLabel;
    Label64: TLabel;
    DBText26: TDBText;
    DBText27: TDBText;
    Label65: TLabel;
    Label66: TLabel;
    DBText28: TDBText;
    Label67: TLabel;
    Bevel5: TBevel;
    Bevel6: TBevel;
    Label68: TLabel;
    Label69: TLabel;
    DBText30: TDBText;
    DBText31: TDBText;
    DBText32: TDBText;
    Label70: TLabel;
    Label71: TLabel;
    DBText33: TDBText;
    Label72: TLabel;
    DBText34: TDBText;
    Label73: TLabel;
    DBText35: TDBText;
    Label74: TLabel;
    DBText36: TDBText;
    Bevel7: TBevel;
    Label75: TLabel;
    Label76: TLabel;
    DBText37: TDBText;
    Label77: TLabel;
    DBText38: TDBText;
    DBText29: TDBText;
    DBText39: TDBText;
    DBText40: TDBText;
    DBText41: TDBText;
    DBText42: TDBText;
    DBText43: TDBText;
    DBText44: TDBText;
    Label78: TLabel;
    Label79: TLabel;
    Label80: TLabel;
    Label81: TLabel;
    EdCodigoBarras: TEdit;
    qryParametros: TQuery;
    qryParametrosNATUREZA: TStringField;
    qryParametrosEMPRESA: TStringField;
    qryParametrosDIRETORIO: TStringField;
    qryDescargadg_data_leitura: TDateTimeField;
    qryDescargadg_dias_consumo: TIntegerField;
    qryDescargadg_ocorrencia: TIntegerField;
    qryDescargaoc_descricao: TStringField;
    qryDescargadg_forma_entrega: TIntegerField;
    qryDescargadesc_forma_entrega: TStringField;
    qryDescargadg_leitura_real: TIntegerField;
    qryDescargadg_leitura_ajustada: TIntegerField;
    qryDescargadg_consumo_medido: TIntegerField;
    qryDescargadg_consumo_ajustado: TIntegerField;
    qryDescargadg_consumo_rateado: TIntegerField;
    qryDescargadg_consumo_medido_esg: TIntegerField;
    qryDescargadg_consumo_ajustado_esg: TIntegerField;
    qryDescargadg_consumo_rateado_esg: TIntegerField;
    qryDescargadg_agente: TIntegerField;
    qryDescargaag_nome: TStringField;
    qryDescargadg_leitura_agente: TIntegerField;
    qryDescargadesc_leitura_agente: TStringField;
    qryDescargadg_motivo_nao_faturamento: TIntegerField;
    qryDescargadesc_motivo_nao_faturamento: TStringField;
    qryDescargadg_status: TIntegerField;
    qryDescargadesc_status: TStringField;
    qryDescargadg_consumo_faturado_res: TIntegerField;
    qryDescargadg_consumo_faturado_com: TIntegerField;
    qryDescargadg_consumo_faturado_ind: TIntegerField;
    qryDescargadg_consumo_faturado_pub: TIntegerField;
    qryDescargadg_consumo_faturado_soc: TIntegerField;
    qryDescargadg_consumo_faturado_ea: TIntegerField;
    qryDescargadg_consumo_faturado_esg_res: TIntegerField;
    qryDescargadg_consumo_faturado_esg_com: TIntegerField;
    qryDescargadg_consumo_faturado_esg_ind: TIntegerField;
    qryDescargadg_consumo_faturado_esg_pub: TIntegerField;
    qryDescargadg_consumo_faturado_esg_soc: TIntegerField;
    qryDescargadg_consumo_faturado_esg_ea: TIntegerField;
    qryDescargadg_valor_agua: TFloatField;
    qryDescargadg_valor_esgoto: TFloatField;
    qryDescargadg_valor_servico: TFloatField;
    qryDescargadg_valor_credito: TFloatField;
    qryDescargadg_valor_devolucao: TFloatField;
    qryDescargadg_valor_imposto: TFloatField;
    qryDescargadg_valor_saldo_debito: TFloatField;
    qryDescargadg_valor_saldo_credito: TFloatField;
    qryDescargadg_valor_total: TFloatField;
    qryDescargadg_flag_fraude: TStringField;
    qryCDCcg_matricula: TIntegerField;
    qryCDCcg_matricula_pai: TIntegerField;
    qryCDCcg_sequencia: TIntegerField;
    qryCDCdesc_tipo_cdc: TStringField;
    qryCDCendereco: TStringField;
    qryCDCcg_endereco: TStringField;
    qryCDCcg_num_imovel: TStringField;
    qryCDCcg_complemento: TStringField;
    qryCDCcg_inscricao: TStringField;
    qryCDCcg_nome: TStringField;
    qryCDCcg_grupo: TIntegerField;
    qryCDCcg_rota: TIntegerField;
    qryCDCcg_setor: TIntegerField;
    qryCDCcg_qtde_debito_ant: TIntegerField;
    qryCDCcg_numero_hd: TStringField;
    qryCDCcg_capacidade_hidrometro: TIntegerField;
    qryCDCcg_consumo_medio: TIntegerField;
    qryCDCcg_economia_res: TIntegerField;
    qryCDCcg_economia_com: TIntegerField;
    qryCDCcg_economia_ind: TIntegerField;
    qryCDCcg_economia_pub: TIntegerField;
    qryCDCcg_economia_soc: TIntegerField;
    qryCDCcg_economia_ea: TIntegerField;
    qryCDCcg_categoria: TIntegerField;
    qryCDCdescricao_categoria: TStringField;
    qryCDCcg_data_vencto: TDateTimeField;
    qryCDCcg_referencia: TDateTimeField;
    qryCDCcg_codigo_banco: TIntegerField;
    qryCDCcg_agencia: TIntegerField;
    qryCDCcg_flag_troca: TStringField;
    qryCDCcg_leitura_inicial: TIntegerField;
    qryCDCcg_data_instalacao_hd: TDateTimeField;
    qryCDCcg_natureza_ligacao: TIntegerField;
    qryCDCdescricao_natureza_ligacao: TStringField;
    qryCDCcg_bloqueado: TStringField;
    qryCDCdesc_bloqueado: TStringField;
    qryCDCcg_desconto: TIntegerField;
    qryCDCde_percentual: TFloatField;
    qryCDCde_limite_inicial: TIntegerField;
    qryCDCde_tipo_desconto: TIntegerField;
    qryCDCdesc_tipo_desconto: TStringField;
    qryCDCcg_ident_consumidor: TIntegerField;
    qryCDCdescricao_ident_consumidor: TStringField;
    qryCDCcg_flag_emite_conta: TStringField;
    qryCDCcg_flag_calcula_imposto: TStringField;
    qryCDCcg_entrega_alternativa: TStringField;
    qryCDCcg_flag_calcula_conta: TStringField;
    qryCDCcg_dias_bloqueio_tarifa_ant: TIntegerField;
    qryCDCcg_dias_bloqueio_tarifa_atual: TIntegerField;
    qryCDCcg_virtual: TStringField;
    qryCDCcg_data_bloqueio: TDateTimeField;
    qryCDCcg_data_desbloqueio: TDateTimeField;
    qryCDCcg_cachorro: TStringField;
    qryCDCcg_qtde_registros_fraude: TIntegerField;
    qryCDCcg_flag_cortar: TStringField;
    qryCDCcg_leitura_ant: TIntegerField;
    qryCDCcg_ocorrencia_ant: TIntegerField;
    qryCDCcg_data_leit_ant: TDateTimeField;
    qryCDCcg_consumo_anterior: TIntegerField;
    Label59: TLabel;
    DBText20: TDBText;
    qryDescargadg_flag_lido: TStringField;
    qryDescargadg_flag_faturado: TStringField;
    Label82: TLabel;
    DBText45: TDBText;
    Label83: TLabel;
    DBText46: TDBText;
    DBText47: TDBText;
    qryDescargadg_vias: TIntegerField;
    qryDescargadesc_vias: TStringField;
    qryHistoricohc_leitura_real: TIntegerField;
    DBText48: TDBText;
    Label84: TLabel;
    DBText49: TDBText;
    DBText50: TDBText;
    qryDescargadg_flag_emitida: TStringField;
    qryDescargadesc_flag_emitida: TStringField;
    DBTOcorrencia2: TDBText;
    DBText51: TDBText;
    qryDescargaOcorrencia2: TIntegerField;
    qryDescargaDesc_Ocorrencia2: TStringField;
    Label85: TLabel;
    DBText52: TDBText;
    procedure EdMatriculaKeyPress(Sender: TObject; var Key: Char);
    procedure cmbGrupoChange(Sender: TObject);
    procedure EdCodigoBarrasChange(Sender: TObject);
    procedure DSCDCDataChange(Sender: TObject; Field: TField);
    procedure cmbRotaChange(Sender: TObject);
    procedure EdMatriculaChange(Sender: TObject);
    procedure EdSequenciaChange(Sender: TObject);
    procedure DSPrincipalDataChange(Sender: TObject; Field: TField);
    procedure sbtPesquisaClick(Sender: TObject);
    procedure cmbRotaDropDown(Sender: TObject);
    procedure cmbGrupoDropDown(Sender: TObject);
    procedure FormActivate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmDadosCliente: TfrmDadosCliente;

implementation

{$R *.DFM}

procedure TfrmDadosCliente.EdMatriculaKeyPress(Sender: TObject; var Key: Char);
begin
// Address $5DAAE8
end;

procedure TfrmDadosCliente.cmbGrupoChange(Sender: TObject);
begin
// Address $5DA218
end;

procedure TfrmDadosCliente.EdCodigoBarrasChange(Sender: TObject);
begin
// Address $5DAA48
end;

procedure TfrmDadosCliente.DSCDCDataChange(Sender: TObject; Field: TField);
begin
// Address $5DA4F8
end;

procedure TfrmDadosCliente.cmbRotaChange(Sender: TObject);
begin
// Address $5DA340
end;

procedure TfrmDadosCliente.EdMatriculaChange(Sender: TObject);
begin
// Address $5DAAB0
end;

procedure TfrmDadosCliente.EdSequenciaChange(Sender: TObject);
begin
// Address $5DAAF4
end;

procedure TfrmDadosCliente.DSPrincipalDataChange(Sender: TObject; Field: TField);
begin
// Address $5DA930
end;

procedure TfrmDadosCliente.sbtPesquisaClick(Sender: TObject);
begin
// Address $5DABC8
end;

procedure TfrmDadosCliente.cmbRotaDropDown(Sender: TObject);
begin
// Address $5DA378
end;

procedure TfrmDadosCliente.cmbGrupoDropDown(Sender: TObject);
begin
// Address $5DA250
end;

procedure TfrmDadosCliente.FormActivate(Sender: TObject);
begin
// Address $5DAB2C
end;

end.
