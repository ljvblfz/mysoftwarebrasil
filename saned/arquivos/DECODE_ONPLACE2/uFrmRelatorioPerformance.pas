unit uFrmRelatorioPerformance;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, ComCtrls, StdCtrls, Buttons, DBTables, DB, DBGrids,
  DBCtrls, RpRenderPDF, RpRave, RpConDS;

type
  TfrmRelatorioPerformance = class(TfrmBaseClient)
    PageControl: TPageControl;
    tbsPesquisa: TTabSheet;
    GroupBox1: TGroupBox;
    rbtReferencia: TRadioButton;
    rbtRota: TRadioButton;
    rbtAgente: TRadioButton;
    Label1: TLabel;
    cmbGrupo: TComboBox;
    Label2: TLabel;
    cmbReferencia: TComboBox;
    sbtnPesquisar: TSpeedButton;
    Label3: TLabel;
    cmbRota: TComboBox;
    Label4: TLabel;
    cmbAgente: TComboBox;
    qryReferencia: TQuery;
    qryAgente: TQuery;
    qryPesquisa: TQuery;
    qryMedicao: TQuery;
    qryMedicaomd_referencia: TDateTimeField;
    qryMedicaomd_grupo: TIntegerField;
    qryMedicaomd_rota: TIntegerField;
    qryMedicaoagente: TStringField;
    qryMedicaomd_data_leitura: TDateTimeField;
    qryMedicaomd_hora_inicio: TDateTimeField;
    qryMedicaomd_hora_fim: TDateTimeField;
    qryMedicaomd_ligacoes: TIntegerField;
    qryMedicaomd_leitura_campo: TIntegerField;
    qryMedicaomd_analise: TIntegerField;
    qryMedicaomd_faturado_normal: TIntegerField;
    qryMedicaomd_faturado_media: TIntegerField;
    qryMedicaomd_faturado_minima: TIntegerField;
    qryMedicaomd_emitidas: TIntegerField;
    qryMedicaomd_emitidas_2_vezes: TIntegerField;
    qryMedicaomd_nao_emitidas: TIntegerField;
    qryMedicaomd_entrega_mao: TIntegerField;
    qryMedicaomd_entrega_visinho: TIntegerField;
    qryMedicaomd_entrega_porta: TIntegerField;
    qryMedicaomd_entraga_correio: TIntegerField;
    qryMedicaomd_entrega_recusado: TIntegerField;
    qryMedicaomd_entrega_outro: TIntegerField;
    qryMedicaomd_nao_exec: TIntegerField;
    qryMedicaomd_fraude: TIntegerField;
    qryMedicaomd_para_corte: TIntegerField;
    qryMedicaomd_cortado: TIntegerField;
    qryMedicaomd_emitidas_aviso: TIntegerField;
    qryMedicaomd_emitidas_2_vias: TIntegerField;
    tbsReferencia: TTabSheet;
    GroupBox2: TGroupBox;
    DBGridReferencia: TDBGrid;
    dsMedicao: TDataSource;
    Label5: TLabel;
    DBEdGrupoRota: TDBEdit;
    Label6: TLabel;
    DBEdReferencia: TDBEdit;
    cmbVerReferencia: TComboBox;
    Label7: TLabel;
    qryMedicaomd_alteracoes_cadastro: TIntegerField;
    qryMedicaomd_inclusao_cadastro: TIntegerField;
    tbsRota: TTabSheet;
    GroupBox3: TGroupBox;
    Label8: TLabel;
    Label9: TLabel;
    Label10: TLabel;
    DBEdit1: TDBEdit;
    DBEdit2: TDBEdit;
    cmbVerRota: TComboBox;
    tbsAgente: TTabSheet;
    GroupBox4: TGroupBox;
    Label11: TLabel;
    Label13: TLabel;
    DBEdit3: TDBEdit;
    cmbVerAgente: TComboBox;
    rbtHorario: TRadioButton;
    tbsEmissao: TTabSheet;
    qryHorario: TQuery;
    dsDescarga: TDataSource;
    GroupBox5: TGroupBox;
    Label12: TLabel;
    Label14: TLabel;
    DBGrid1: TDBGrid;
    DBEdit4: TDBEdit;
    DBEdit5: TDBEdit;
    Label15: TLabel;
    DBEdit6: TDBEdit;
    qryHorariodg_grupo: TIntegerField;
    qryHorariodg_rota: TIntegerField;
    qryHorariodg_referencia: TDateTimeField;
    qryHorariodg_data_leitura: TDateTimeField;
    qryHorarioData_Prox_Leitura: TDateTimeField;
    qryHorarioTempo: TDateTimeField;
    qryHorariodg_matricula: TIntegerField;
    qryHorariodg_leitura_real: TIntegerField;
    qryHorariodg_ocorrencia: TIntegerField;
    qryHorariodg_flag_calculada: TStringField;
    qryHorariodg_flag_emitida: TStringField;
    qryHorariodg_flag_aviso: TStringField;
    qryHorariodg_flag_fraude: TStringField;
    qryHorariodg_flag_faturado: TStringField;
    qryHorariodg_flag_lido: TStringField;
    qryHorariodg_leitura_agente: TIntegerField;
    qryHorariodg_forma_entrega: TIntegerField;
    qryHorariodg_vias: TIntegerField;
    qryHorariodg_agente: TIntegerField;
    qryHorarioag_nome: TStringField;
    sbtnImprimir: TSpeedButton;
    RvRenderPDF: TRvRenderPDF;
    RvPrjHorario: TRvProject;
    RvDSCHorario: TRvDataSetConnection;
    qryMedicaomd_leituras_real: TIntegerField;
    qryMedicaomd_leituras_nao_real: TIntegerField;
    qryMedicaoperc_leituras_real: TIntegerField;
    qryMedicaoperc_leituras_nao_real: TIntegerField;
    DBGridRota: TDBGrid;
    DBGridAgente: TDBGrid;
    RvPrjPerformRef: TRvProject;
    RvDSCPerformance: TRvDataSetConnection;
    qryMedicaotitulo1: TStringField;
    qryMedicaotitulo2: TStringField;
    RvPrjPerformRota: TRvProject;
    RvPrjPerformAgente: TRvProject;
    tbsReferenciaRecepcao: TTabSheet;
    GroupBox6: TGroupBox;
    Label16: TLabel;
    Label17: TLabel;
    Label18: TLabel;
    DBEdit7: TDBEdit;
    DBEdit8: TDBEdit;
    cmbVerRefRecepcao: TComboBox;
    DBGridRefRecepcao: TDBGrid;
    QrMedRecepcao: TQuery;
    DSMedRecepcao: TDataSource;
    rbtReferenciaRecepcao: TRadioButton;
    QrMedRecepcaomd_grupo: TIntegerField;
    QrMedRecepcaomd_rota: TIntegerField;
    QrMedRecepcaomd_referencia: TDateTimeField;
    QrMedRecepcaoagente: TStringField;
    QrMedRecepcaomd_data_leitura: TDateTimeField;
    QrMedRecepcaomd_hora_inicio: TDateTimeField;
    QrMedRecepcaomd_hora_fim: TDateTimeField;
    QrMedRecepcaomd_ligacoes: TIntegerField;
    QrMedRecepcaomd_leituras_real: TIntegerField;
    QrMedRecepcaomd_leitura_campo: TIntegerField;
    QrMedRecepcaomd_analise: TIntegerField;
    QrMedRecepcaomd_faturado_normal: TIntegerField;
    QrMedRecepcaomd_faturado_media: TIntegerField;
    QrMedRecepcaomd_faturado_minima: TIntegerField;
    QrMedRecepcaomd_emitidas: TIntegerField;
    QrMedRecepcaomd_emitidas_2_vezes: TIntegerField;
    QrMedRecepcaomd_nao_emitidas: TIntegerField;
    QrMedRecepcaomd_emitidas_aviso: TIntegerField;
    QrMedRecepcaomd_entrega_mao: TIntegerField;
    QrMedRecepcaomd_entrega_visinho: TIntegerField;
    QrMedRecepcaomd_entrega_porta: TIntegerField;
    QrMedRecepcaomd_entraga_correio: TIntegerField;
    QrMedRecepcaomd_entrega_recusado: TIntegerField;
    QrMedRecepcaomd_entrega_outro: TIntegerField;
    QrMedRecepcaomd_nao_exec: TIntegerField;
    QrMedRecepcaomd_fraude: TIntegerField;
    QrMedRecepcaomd_para_corte: TIntegerField;
    QrMedRecepcaomd_cortado: TIntegerField;
    QrMedRecepcaomd_consumo_medido: TIntegerField;
    QrMedRecepcaomd_consumo_medido_esg: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_res: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_res_esg: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_com: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_com_esg: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_ind: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_ind_esg: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_pub: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_pub_esg: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_soc: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_soc_esg: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_ea: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_ea_esg: TIntegerField;
    QrMedRecepcaomd_valor_agua: TFloatField;
    QrMedRecepcaomd_valor_esgoto: TFloatField;
    QrMedRecepcaomd_valor_servico: TFloatField;
    QrMedRecepcaomd_valor_credito: TFloatField;
    QrMedRecepcaomd_valor_devolucao: TFloatField;
    QrMedRecepcaomd_valor_ir: TFloatField;
    QrMedRecepcaomd_valor_csll: TFloatField;
    QrMedRecepcaomd_valor_pis: TFloatField;
    QrMedRecepcaomd_valor_cofins: TFloatField;
    QrMedRecepcaomd_valor_saldo_debito: TFloatField;
    QrMedRecepcaomd_valor_saldo_credito: TFloatField;
    QrMedRecepcaomd_leituras_nao_real: TIntegerField;
    QrMedRecepcaoperc_leituras_real: TIntegerField;
    QrMedRecepcaoperc_leituras_nao_real: TIntegerField;
    RvPrjPerformRefRecepcao: TRvProject;
    RvDSCPerfRecepcao: TRvDataSetConnection;
    QrMedRecepcaotitulo1: TStringField;
    QrMedRecepcaotitulo2: TStringField;
    procedure QrMedRecepcaoCalcFields(DataSet: TDataSet);
    procedure cmbVerRefRecepcaoChange(Sender: TObject);
    procedure sbtnImprimirClick(Sender: TObject);
    procedure cmbVerAgenteChange(Sender: TObject);
    procedure cmbVerRotaChange(Sender: TObject);
    procedure cmbVerReferenciaChange(Sender: TObject);
    procedure sbtnPesquisarClick(Sender: TObject);
    procedure cmbRotaDropDown(Sender: TObject);
    procedure cmbGrupoDropDown(Sender: TObject);
    procedure cmbAgenteDropDown(Sender: TObject);
    procedure cmbReferenciaDropDown(Sender: TObject);
    procedure rbtReferenciaClick(Sender: TObject);
    procedure FormActivate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmRelatorioPerformance: TfrmRelatorioPerformance;

implementation

{$R *.DFM}

procedure TfrmRelatorioPerformance.QrMedRecepcaoCalcFields(DataSet: TDataSet);
begin
// Address $60792C
end;

procedure TfrmRelatorioPerformance.cmbVerRefRecepcaoChange(Sender: TObject);
begin
// Address $606F58
end;

procedure TfrmRelatorioPerformance.sbtnImprimirClick(Sender: TObject);
begin
// Address $607C48
end;

procedure TfrmRelatorioPerformance.cmbVerAgenteChange(Sender: TObject);
begin
// Address $6065D8
end;

procedure TfrmRelatorioPerformance.cmbVerRotaChange(Sender: TObject);
begin
// Address $607398
end;

procedure TfrmRelatorioPerformance.cmbVerReferenciaChange(Sender: TObject);
begin
// Address $606A98
end;

procedure TfrmRelatorioPerformance.sbtnPesquisarClick(Sender: TObject);
begin
// Address $607CE8
end;

procedure TfrmRelatorioPerformance.cmbRotaDropDown(Sender: TObject);
begin
// Address $606214
end;

procedure TfrmRelatorioPerformance.cmbGrupoDropDown(Sender: TObject);
begin
// Address $605C78
end;

procedure TfrmRelatorioPerformance.cmbAgenteDropDown(Sender: TObject);
begin
// Address $605BB0
end;

procedure TfrmRelatorioPerformance.cmbReferenciaDropDown(Sender: TObject);
begin
// Address $6060FC
end;

procedure TfrmRelatorioPerformance.rbtReferenciaClick(Sender: TObject);
begin
// Address $607AF0
end;

procedure TfrmRelatorioPerformance.FormActivate(Sender: TObject);
begin
// Address $607858
end;

end.
