unit uFrmRetornoOnLine;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, Mask, ExtCtrls, Buttons, DBTables, DB, ComCtrls, DBGrids,
  Gauges;

type
  TfrmRetornoOnLine = class(TForm)
    GroupBox1: TGroupBox;
    Label3: TLabel;
    Label4: TLabel;
    CBGrupo: TComboBox;
    MEReferencia: TMaskEdit;
    Panel2: TPanel;
    BitBtProcessar: TSpeedButton;
    BitBtSair: TSpeedButton;
    pTop: TPanel;
    lVersion: TLabel;
    QrGrupos: TQuery;
    QrGruposRT_GRUPO: TIntegerField;
    QrReferencia: TQuery;
    QrReferenciareferencia: TDateTimeField;
    QrGrupoMovimento: TQuery;
    QrGrupoMovimentoseq_roteiro: TFloatField;
    QrGrupoMovimentoind_obtido: TStringField;
    QrGrupoMovimentoind_validado: TStringField;
    QrGrupoMovimentoind_processado: TStringField;
    QrGrupoMovimentoRoteiro: TStringField;
    DsGrupoMovimento: TDataSource;
    PCDescarga: TPageControl;
    TSOnLine: TTabSheet;
    GBRoteiros: TGroupBox;
    sbAtualizaRoteiro: TSpeedButton;
    DBGRoteiros: TDBGrid;
    PProcessamento: TPanel;
    LDescProc: TLabel;
    ProgressBar1: TGauge;
    LLinhaProc: TLabel;
    TSArquivos: TTabSheet;
    QrRoteirosSDF: TQuery;
    GroupBox2: TGroupBox;
    sbBuscaArquivos: TSpeedButton;
    PProcessamento2: TPanel;
    LDescProc2: TLabel;
    ProgressBar2: TGauge;
    LLinhaProc2: TLabel;
    ListArquivos: TListBox;
    LblOnLine: TLabel;
    BitBtImportar: TSpeedButton;
    LblArquivo: TLabel;
    chbImportarEAtualizar: TCheckBox;
    QrRoteirosSDFRotaAgente: TMemoField;
    QrRoteirosSDFReferencia: TStringField;
    QrRoteirosSDFRoteiro: TFloatField;
    QrRoteirosSDFrt_rota: TIntegerField;
    QrRoteirosSDFGrupo: TMemoField;
    QrRoteirosSDFarquivo_copia: TMemoField;
    procedure BitBtImportarClick(Sender: TObject);
    procedure PCDescargaChange(Sender: TObject);
    procedure sbBuscaArquivosClick(Sender: TObject);
    procedure BitBtProcessarClick(Sender: TObject);
    procedure CBGrupoClick(Sender: TObject);
    procedure CBGrupoDropDown(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure BitBtSairClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmRetornoOnLine: TfrmRetornoOnLine;

implementation

{$R *.DFM}

procedure TfrmRetornoOnLine.BitBtImportarClick(Sender: TObject);
begin
// Address $62D2B0
end;

procedure TfrmRetornoOnLine.PCDescargaChange(Sender: TObject);
begin
// Address $62CA68
end;

procedure TfrmRetornoOnLine.sbBuscaArquivosClick(Sender: TObject);
begin
// Address $62CD98
end;

procedure TfrmRetornoOnLine.BitBtProcessarClick(Sender: TObject);
begin
// Address $62DBFC
end;

procedure TfrmRetornoOnLine.CBGrupoClick(Sender: TObject);
begin
// Address $62DD2C
end;

procedure TfrmRetornoOnLine.CBGrupoDropDown(Sender: TObject);
begin
// Address $62DF24
end;

procedure TfrmRetornoOnLine.FormShow(Sender: TObject);
begin
// Address $62E020
end;

procedure TfrmRetornoOnLine.FormClose(Sender: TObject; var Action: TCloseAction);
begin
// Address $62DFF0
end;

procedure TfrmRetornoOnLine.BitBtSairClick(Sender: TObject);
begin
// Address $62D2A8
end;

end.
