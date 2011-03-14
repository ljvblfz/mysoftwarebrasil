unit uFrmAlteraMovimento;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  ExtCtrls, StdCtrls, DBGrids, Buttons, DBTables, DB;

type
  TfrmAlteraMovimento = class(TForm)
    pTop: TPanel;
    lVersion: TLabel;
    DBGRoteiros: TDBGrid;
    GroupBox2: TGroupBox;
    Label16: TLabel;
    EdVariacao: TEdit;
    GroupBox1: TGroupBox;
    rbtEnviadoPsion: TRadioButton;
    rbtNaoEnviadoPsion: TRadioButton;
    RetornoPsion: TRadioGroup;
    rbtRetornoPsion: TRadioButton;
    rbtNaoRetornoPsion: TRadioButton;
    GroupBox3: TGroupBox;
    rbtValidado: TRadioButton;
    rbtNaoValidado: TRadioButton;
    RadioGroup1: TRadioGroup;
    rbtProcessado: TRadioButton;
    rbtNaoProcessado: TRadioButton;
    pBottom: TPanel;
    sbtnSair: TSpeedButton;
    QrGrupos: TQuery;
    QrGrupoMovimento: TQuery;
    Tabelas: TTable;
    DSGrupoMoviemento: TDataSource;
    DSTabelas: TDataSource;
    grbRoteiro: TGroupBox;
    grbSelecao: TGroupBox;
    CBGrupo: TComboBox;
    Label1: TLabel;
    QrGruposRT_GRUPO: TIntegerField;
    QrGrupoMovimentoseq_roteiro: TFloatField;
    QrGrupoMovimentocod_referencia: TStringField;
    QrGrupoMovimentoind_enviado: TStringField;
    QrGrupoMovimentoind_obtido: TStringField;
    QrGrupoMovimentoind_validado: TStringField;
    QrGrupoMovimentoind_processado: TStringField;
    QrGrupoMovimentoRoteiro: TStringField;
    sbtnAlterar: TSpeedButton;
    sbtnConfirma: TSpeedButton;
    sbtnCancela: TSpeedButton;
    procedure FormShow(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure CBGrupoDropDown(Sender: TObject);
    procedure sbtnSairClick(Sender: TObject);
    procedure sbtnCancelaClick(Sender: TObject);
    procedure sbtnConfirmaClick(Sender: TObject);
    procedure sbtnAlterarClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmAlteraMovimento: TfrmAlteraMovimento;

implementation

{$R *.DFM}

procedure TfrmAlteraMovimento.FormShow(Sender: TObject);
begin
// Address $629488
end;

procedure TfrmAlteraMovimento.FormClose(Sender: TObject; var Action: TCloseAction);
begin
// Address $629458
end;

procedure TfrmAlteraMovimento.CBGrupoDropDown(Sender: TObject);
begin
// Address $6292CC
end;

procedure TfrmAlteraMovimento.sbtnSairClick(Sender: TObject);
begin
// Address $6294F0
end;

procedure TfrmAlteraMovimento.sbtnCancelaClick(Sender: TObject);
begin
// Address $6293C8
end;

procedure TfrmAlteraMovimento.sbtnConfirmaClick(Sender: TObject);
begin
// Address $629404
end;

procedure TfrmAlteraMovimento.sbtnAlterarClick(Sender: TObject);
begin
// Address $6294B4
end;

end.
