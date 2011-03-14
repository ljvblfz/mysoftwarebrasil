unit uFrmConsultaMovimento;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  ExtCtrls, StdCtrls, DBTables, Buttons, DB, ComCtrls, DBGrids, DBCtrls,
  FileCtrl;

type
  TfrmConsultaMovimento = class(TForm)
    Panel3: TPanel;
    lVersion: TLabel;
    DatabaseOnLine: TDatabase;
    Panel2: TPanel;
    Sair: TSpeedButton;
    Label12: TLabel;
    SBPesquisar: TSpeedButton;
    Label72: TLabel;
    Label73: TLabel;
    EdMat: TEdit;
    cmbLogradouro: TComboBox;
    EdNumero: TEdit;
    QrLogradouro: TQuery;
    QrLogradouroLogradouro: TStringField;
    PageControl: TPageControl;
    TSDadosRetorno: TTabSheet;
    QrBusca: TQuery;
    QrReferencia: TQuery;
    Label1: TLabel;
    cmbReferencia: TComboBox;
    QrReferenciacod_referencia: TStringField;
    Label2: TLabel;
    cmbRoteiro: TComboBox;
    QrRoteiro: TQuery;
    DsBusca: TDataSource;
    DBGrid1: TDBGrid;
    QrBuscacod_referencia: TStringField;
    QrBuscaseq_rota: TFloatField;
    QrBuscaseq_roteiro: TFloatField;
    QrBuscaseq_leitura: TFloatField;
    QrBuscades_inscricao_imobiliaria: TStringField;
    QrBuscaMatricula: TFloatField;
    QrBuscaNome: TStringField;
    QrBuscaTelefone: TStringField;
    QrBuscaCodLogradouro: TFloatField;
    QrBuscaEndereco: TStringField;
    QrBuscaNumeroImovel: TFloatField;
    QrBuscaComplemento: TStringField;
    QrBuscaQtdeMoradores: TFloatField;
    QrBuscaind_entrega_especial: TStringField;
    QrBuscacod_hidrometro: TStringField;
    QrBuscaval_consumo_medio: TFloatField;
    QrBuscadat_vencimento: TDateTimeField;
    QrBuscadat_leitura_anterior: TDateTimeField;
    QrBuscadat_leitura: TDateTimeField;
    QrBuscaval_leitura_anterior: TFloatField;
    QrBuscaval_leitura_real: TFloatField;
    QrBuscaval_consumo_medido: TFloatField;
    QrBuscaval_consumo_atribuido: TFloatField;
    QrBuscaval_consumo_estimado: TFloatField;
    QrBuscaval_consumo_troca: TFloatField;
    QrBuscadat_troca: TDateTimeField;
    QrBuscaval_leitura_atribuida: TFloatField;
    QrBuscaind_leitura_divergente: TStringField;
    QrBuscaval_numero_leituras: TFloatField;
    QrBuscacod_agente: TFloatField;
    QrBuscanom_agente: TStringField;
    QrBuscades_banco_debito: TStringField;
    QrBuscaseq_tipo_entrega: TFloatField;
    QrBuscades_tipo_entrega: TStringField;
    QrBuscaDiasConsumo: TIntegerField;
    TSServico: TTabSheet;
    QrServicoVenda: TQuery;
    DsServicoVenda: TDataSource;
    QrServicoVendaseq_servico: TFloatField;
    QrServicoVendades_servico_fatura: TStringField;
    QrServicoVendaSolicitante: TStringField;
    DBGrid2: TDBGrid;
    DBEdit1: TDBEdit;
    Label3: TLabel;
    DBEdit2: TDBEdit;
    TSAlteracao: TTabSheet;
    Label4: TLabel;
    DBEdit3: TDBEdit;
    DBEdit4: TDBEdit;
    DBGrid3: TDBGrid;
    QrCadastro: TQuery;
    DSCadastro: TDataSource;
    QrCadastroseq_item: TFloatField;
    QrCadastroTipo: TStringField;
    QrCadastrodes_conteudo_anterior: TStringField;
    QrCadastrodes_conteudo_novo: TStringField;
    QrFatura: TQuery;
    DsFatura: TDataSource;
    TSFatura: TTabSheet;
    Label5: TLabel;
    DBEdit5: TDBEdit;
    DBEdit6: TDBEdit;
    DBGrid4: TDBGrid;
    Label6: TLabel;
    Label7: TLabel;
    DBGrid5: TDBGrid;
    QrServicoFaturado: TQuery;
    DsServicoFaturado: TDataSource;
    TSDados: TTabSheet;
    QrDados: TQuery;
    DSDados: TDataSource;
    QrDadoscod_referencia: TStringField;
    QrDadosseq_rota: TFloatField;
    QrDadosseq_roteiro: TFloatField;
    QrDadosseq_leitura: TFloatField;
    QrDadosdes_inscricao_imobiliaria: TStringField;
    QrDadosMatricula: TFloatField;
    QrDadosNome: TStringField;
    QrDadosTelefone: TStringField;
    QrDadosCodLogradouro: TFloatField;
    QrDadosEndereco: TStringField;
    QrDadosNumeroImovel: TFloatField;
    QrDadosComplemento: TStringField;
    QrDadosQtdeMoradores: TFloatField;
    QrDadoscod_hidrometro: TStringField;
    QrDadosval_numero_digitos: TFloatField;
    QrDadosval_consumo_medio: TFloatField;
    QrDadosdat_vencimento: TDateTimeField;
    QrDadosdat_leitura_anterior: TDateTimeField;
    QrDadosval_leitura_anterior: TFloatField;
    QrDadosval_consumo_troca: TFloatField;
    QrDadosdat_troca: TDateTimeField;
    QrDadoscod_agente: TFloatField;
    QrDadosnom_agente: TStringField;
    QrDadoscod_banco: TFloatField;
    QrDadoscod_banco_agencia: TFloatField;
    DBGrid6: TDBGrid;
    QrServicoFaturadodes_servico: TStringField;
    QrServicoFaturadovalor: TFloatField;
    QrGrupo: TQuery;
    QrGrupoGrupo: TStringField;
    Label8: TLabel;
    cmbGrupo: TComboBox;
    QrRoteiroseq_roteiro: TStringField;
    QrFaturades_categoria: TStringField;
    QrFaturaval_numero_economia: TFloatField;
    QrFaturaval_consumo_faturado: TFloatField;
    QrFaturades_taxa: TStringField;
    QrFaturaval_valor_faturado: TFloatField;
    QrFaturaseq_fatura: TFloatField;
    DBNavigator2: TDBNavigator;
    DBNavigator3: TDBNavigator;
    DBNavigator4: TDBNavigator;
    QrFaturacod_referencia: TStringField;
    QrFaturaseq_matricula: TFloatField;
    QrFaturaseq_roteiro: TFloatField;
    TSFotos: TTabSheet;
    DBFotos: TDBGrid;
    Image: TImage;
    Label9: TLabel;
    DBEdit7: TDBEdit;
    DBEdit8: TDBEdit;
    DBNavigator1: TDBNavigator;
    QrFotos: TQuery;
    DsFotos: TDataSource;
    QrFotoscod_referencia: TStringField;
    QrFotosseq_roteiro: TFloatField;
    QrFotosseq_matricula: TFloatField;
    QrFotosseq_foto: TFloatField;
    QrFotosarq_foto: TBlobField;
    QrFotosdes_caminho: TStringField;
    FileListBox: TFileListBox;
    LQtdeCarga: TLabel;
    LQtdeDescarga: TLabel;
    procedure FormShow(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure SairClick(Sender: TObject);
    procedure cmbRoteiroDropDown(Sender: TObject);
    procedure cmbReferenciaChange(Sender: TObject);
    procedure SBPesquisarClick(Sender: TObject);
    procedure DsBuscaDataChange(Sender: TObject; Field: TField);
    procedure cmbGrupoDropDown(Sender: TObject);
    procedure DsFaturaDataChange(Sender: TObject; Field: TField);
    procedure DsFotosDataChange(Sender: TObject; Field: TField);
    procedure EdMatKeyPress(Sender: TObject; var Key: Char);
    procedure cmbGrupoChange(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmConsultaMovimento: TfrmConsultaMovimento;

implementation

{$R *.DFM}

procedure TfrmConsultaMovimento.FormShow(Sender: TObject);
begin
// Address $62A77C
end;

procedure TfrmConsultaMovimento.FormClose(Sender: TObject; var Action: TCloseAction);
begin
// Address $62AA04
end;

procedure TfrmConsultaMovimento.SairClick(Sender: TObject);
begin
// Address $62AA3C
end;

procedure TfrmConsultaMovimento.cmbRoteiroDropDown(Sender: TObject);
begin
// Address $62AA44
end;

procedure TfrmConsultaMovimento.cmbReferenciaChange(Sender: TObject);
begin
// Address $62AB70
end;

procedure TfrmConsultaMovimento.SBPesquisarClick(Sender: TObject);
begin
// Address $62AB9C
end;

procedure TfrmConsultaMovimento.DsBuscaDataChange(Sender: TObject; Field: TField);
begin
// Address $62AF80
end;

procedure TfrmConsultaMovimento.cmbGrupoDropDown(Sender: TObject);
begin
// Address $62AFE8
end;

procedure TfrmConsultaMovimento.DsFaturaDataChange(Sender: TObject; Field: TField);
begin
// Address $62B0D4
end;

procedure TfrmConsultaMovimento.DsFotosDataChange(Sender: TObject; Field: TField);
begin
// Address $62B0F0
end;

procedure TfrmConsultaMovimento.EdMatKeyPress(Sender: TObject; var Key: Char);
begin
// Address $62B2BC
end;

procedure TfrmConsultaMovimento.cmbGrupoChange(Sender: TObject);
begin
// Address $62B2C8
end;

end.
