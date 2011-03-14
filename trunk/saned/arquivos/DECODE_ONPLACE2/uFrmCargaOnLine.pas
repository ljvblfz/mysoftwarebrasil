unit uFrmCargaOnLine;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  ExtCtrls, StdCtrls, Buttons, DBTables, ComCtrls, FileCtrl, DB;

type
  TfrmCargaOnLine = class(TForm)
    pTop: TPanel;
    lVersion: TLabel;
    GroupBox1: TGroupBox;
    LGrupo: TLabel;
    LRota: TLabel;
    cmbGrupo: TComboBox;
    cmbRota: TComboBox;
    ckbTodos: TCheckBox;
    pBottom: TPanel;
    sbtnSair: TSpeedButton;
    sbtnConfirmar: TSpeedButton;
    qryGeral: TQuery;
    chbJaGerados: TCheckBox;
    grbProcessamento: TGroupBox;
    ProgressBar: TProgressBar;
    MemoArq: TMemo;
    qryAtualiza: TQuery;
    FileListBox: TFileListBox;
    LMens01: TLabel;
    ProgressBar2: TProgressBar;
    LMens02: TLabel;
    qryBuscaServFaturado: TQuery;
    QryBuscaLogradouro: TQuery;
    QryBuscaServico: TQuery;
    QryBuscaServicoServico: TStringField;
    QryBuscaLogradouroTexto: TStringField;
    qryBuscaMovimento: TQuery;
    qryBuscaMovimentocg_matricula: TIntegerField;
    qryBuscaMovimentoroteiro: TFloatField;
    qryBuscaMovimentocg_referencia: TDateTimeField;
    qryBuscaMovimentocg_categoria: TIntegerField;
    qryBuscaMovimentocg_economia_res: TIntegerField;
    qryBuscaMovimentocg_economia_com: TIntegerField;
    qryBuscaMovimentocg_economia_ind: TIntegerField;
    qryBuscaMovimentocg_economia_pub: TIntegerField;
    qryBuscaMovimentocg_economia_soc: TIntegerField;
    qryBuscaMovimentocg_economia_ea: TIntegerField;
    qryBuscaMovimentoct_lig_agua: TIntegerField;
    qryBuscaMovimentoct_lig_esg: TIntegerField;
    qryProximoMovimentoItem: TQuery;
    qryProximoServicoParcela: TQuery;
    qryProximoServicoParcelaValor: TFloatField;
    qryBuscaServFaturadomatricula: TIntegerField;
    qryBuscaServFaturadogrupo: TIntegerField;
    qryBuscaServFaturadoreferencia: TDateTimeField;
    qryBuscaServFaturadorefBusca: TStringField;
    qryBuscaServFaturadoroteiro: TFloatField;
    qryBuscaServFaturadoServico: TIntegerField;
    qryBuscaServFaturadoValor: TFloatField;
    qryProximoMovimentoItemValor: TFloatField;
    qryInsMatServParcela: TQuery;
    qryInsMovimentoServico: TQuery;
    qryBuscaAviso: TQuery;
    qryBuscaAvisoItem: TQuery;
    qryBuscaProcCorte: TQuery;
    qryBuscaProcCorteValor: TFloatField;
    qryBuscaProxAviso: TQuery;
    qryBuscaProxFatura: TQuery;
    qryInsFaturaAviso: TQuery;
    qryInsAviso: TQuery;
    qryInsFaturaAvisoItem: TQuery;
    qryBuscaAvisodb_matricula: TIntegerField;
    qryBuscaAvisodb_grupo: TIntegerField;
    qryBuscaAvisodb_referencia: TDateTimeField;
    qryBuscaAvisodb_data_vencimento: TDateTimeField;
    qryBuscaAvisodb_qtde_debitos: TIntegerField;
    qryBuscaAvisodb_valor_total: TFloatField;
    qryBuscaAvisoroteiro: TFloatField;
    qryBuscaAvisodb_codigo_barras: TStringField;
    qryBuscaAvisoBarraLinha: TStringField;
    qryBuscaAvisoTipo: TStringField;
    qryBuscaAvisoServico: TIntegerField;
    qryBuscaFaturaServico: TQuery;
    qryBuscaFaturaServicoValor: TFloatField;
    qryInsFaturaServico: TQuery;
    qryBuscaAvisoItemdi_referencia_debito: TDateTimeField;
    qryBuscaAvisoItemdi_valor: TFloatField;
    qryBuscaSegundaVias: TQuery;
    qryInsFaturaSV: TQuery;
    qryBuscaCodServico: TQuery;
    qryBuscaSegundaViassv_matricula: TIntegerField;
    qryBuscaSegundaViassv_referencia: TDateTimeField;
    qryBuscaSegundaViassv_data_vencimento: TDateTimeField;
    qryBuscaSegundaViassv_grupo: TIntegerField;
    qryBuscaSegundaViasroteiro: TFloatField;
    qryBuscaSegundaViassv_referencia_seg_via: TDateTimeField;
    qryBuscaSegundaViassv_leitura_anterior: TIntegerField;
    qryBuscaSegundaViassv_leitura_atual: TIntegerField;
    qryBuscaSegundaViassv_data_leitura_anterior: TDateTimeField;
    qryBuscaSegundaViassv_data_leitura: TDateTimeField;
    qryBuscaSegundaViassv_consumo_faturado: TIntegerField;
    qryBuscaSegundaViassv_media: TIntegerField;
    qryBuscaSegundaViascg_categoria: TIntegerField;
    qryBuscaSegundaViascg_economia_res: TIntegerField;
    qryBuscaSegundaViascg_economia_com: TIntegerField;
    qryBuscaSegundaViascg_economia_ind: TIntegerField;
    qryBuscaSegundaViascg_economia_pub: TIntegerField;
    qryBuscaSegundaViascg_economia_soc: TIntegerField;
    qryBuscaSegundaViascg_economia_ea: TIntegerField;
    qryBuscaSegundaViassv_ind_mista: TIntegerField;
    qryBuscaSegundaViassv_servico_01: TStringField;
    qryBuscaSegundaViassv_valor_01: TFloatField;
    qryBuscaSegundaViassv_servico_02: TStringField;
    qryBuscaSegundaViassv_valor_02: TFloatField;
    qryBuscaSegundaViassv_servico_03: TStringField;
    qryBuscaSegundaViassv_valor_03: TFloatField;
    qryBuscaSegundaViassv_servico_04: TStringField;
    qryBuscaSegundaViassv_valor_04: TFloatField;
    qryBuscaSegundaViassv_servico_05: TStringField;
    qryBuscaSegundaViassv_valor_05: TFloatField;
    qryBuscaSegundaViassv_servico_06: TStringField;
    qryBuscaSegundaViassv_valor_06: TFloatField;
    qryBuscaSegundaViassv_servico_07: TStringField;
    qryBuscaSegundaViassv_valor_07: TFloatField;
    qryBuscaSegundaViassv_servico_08: TStringField;
    qryBuscaSegundaViassv_valor_08: TFloatField;
    qryBuscaSegundaViassv_servico_09: TStringField;
    qryBuscaSegundaViassv_valor_09: TFloatField;
    qryBuscaSegundaViassv_ref_cons_1: TDateTimeField;
    qryBuscaSegundaViassv_cons_1: TIntegerField;
    qryBuscaSegundaViassv_ref_cons_2: TDateTimeField;
    qryBuscaSegundaViassv_Cons_2: TIntegerField;
    qryBuscaSegundaViassv_ref_cons_3: TDateTimeField;
    qryBuscaSegundaViassv_Cons_3: TIntegerField;
    qryBuscaSegundaViassv_ref_cons_4: TDateTimeField;
    qryBuscaSegundaViassv_Cons_4: TIntegerField;
    qryBuscaSegundaViassv_ref_cons_5: TDateTimeField;
    qryBuscaSegundaViassv_Cons_5: TIntegerField;
    qryBuscaSegundaViassv_ref_cons_6: TDateTimeField;
    qryBuscaSegundaViassv_Cons_6: TIntegerField;
    qryBuscaSegundaViassv_valor_total: TFloatField;
    qryBuscaSegundaViassv_codigo_barras: TStringField;
    qryBuscaSegundaViasBarraLinha: TStringField;
    qryBuscaSegundaViascg_numero_hd: TStringField;
    qryBuscaCodServicoValor: TIntegerField;
    PTempo: TPanel;
    LInicio: TLabel;
    LTempo: TLabel;
    LTermino: TLabel;
    qryBuscaMovimentoct_consumo_fixo: TIntegerField;
    LMensagem: TLabel;
    qryBuscaProxFaturaProximo: TFloatField;
    qryBuscaProxAvisoProximo: TFloatField;
    procedure chbJaGeradosClick(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure sbtnConfirmarClick(Sender: TObject);
    procedure ckbTodosClick(Sender: TObject);
    procedure cmbRotaDropDown(Sender: TObject);
    procedure cmbGrupoDropDown(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure sbtnSairClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmCargaOnLine: TfrmCargaOnLine;

implementation

{$R *.DFM}

procedure TfrmCargaOnLine.chbJaGeradosClick(Sender: TObject);
begin
// Address $6260D4
end;

procedure TfrmCargaOnLine.FormShow(Sender: TObject);
begin
// Address $626744
end;

procedure TfrmCargaOnLine.sbtnConfirmarClick(Sender: TObject);
begin
// Address $626ABC
end;

procedure TfrmCargaOnLine.ckbTodosClick(Sender: TObject);
begin
// Address $6260E4
end;

procedure TfrmCargaOnLine.cmbRotaDropDown(Sender: TObject);
begin
// Address $6263D4
end;

procedure TfrmCargaOnLine.cmbGrupoDropDown(Sender: TObject);
begin
// Address $626124
end;

procedure TfrmCargaOnLine.FormClose(Sender: TObject; var Action: TCloseAction);
begin
// Address $626714
end;

procedure TfrmCargaOnLine.sbtnSairClick(Sender: TObject);
begin
// Address $628D08
end;

end.
