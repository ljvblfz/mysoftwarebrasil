unit uFrmMain;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uSMainMenu, DBTables, ExtCtrls, ComCtrls, DBClient, DB;

type
  TfrmMain = class(TForm)
    SMMain: TSMainMenu;
    qryMenu: TQuery;
    Timer1: TTimer;
    StatusBar1: TStatusBar;
    CSMenu: TClientDataSet;
    QrParametros: TQuery;
    QrExecSysConfig: TQuery;
    QrExisteSysConfig: TQuery;
    QrExisteSysConfigExiste: TIntegerField;
    QrDadosSysCoonfig: TQuery;
    QrDadosSysCoonfigsy_client: TStringField;
    QrDadosSysCoonfigsy_cnpj: TStringField;
    QrDadosSysCoonfigsy_chave: TStringField;
    QrDadosSysCoonfigsy_date: TDateTimeField;
    QrDadosSysCoonfigDataAtual: TDateTimeField;
    QrParametrosNATUREZA: TStringField;
    QrParametrosEMPRESA: TStringField;
    QrParametrosDIRETORIO: TStringField;
    procedure FormCreate(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure FormShow(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmMain: TfrmMain;

implementation

{$R *.DFM}

procedure TfrmMain.FormCreate(Sender: TObject);
begin
// Address $62EB54
end;

procedure TfrmMain.Timer1Timer(Sender: TObject);
begin
// Address $63036C
end;

procedure TfrmMain.FormClose(Sender: TObject; var Action: TCloseAction);
begin
// Address $62EB44
end;

procedure TfrmMain.FormShow(Sender: TObject);
begin
// Address $62EEDC
end;

end.
