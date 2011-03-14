unit uFrmTabUsuarios;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClientTabela, DBCtrls, StdCtrls, DB, DBTables;

type
  TfrmTabUsuarios = class(TfrmBaseClientTabela)
    DBEChave: TDBEdit;
    DBENome: TDBEdit;
    Label1: TLabel;
    Label2: TLabel;
    tbPrincipalch_chave: TStringField;
    tbPrincipalch_nome: TStringField;
    tbPrincipalch_status: TBooleanField;
    DBCBStatus: TDBCheckBox;
    qryLimpaChaveAcesso: TQuery;
    qryInsereChaveAcesso: TQuery;
    tbPrincipalch_senha: TStringField;
    procedure sbtnExcluirClick(Sender: TObject);
    procedure sbtnConfirmaClick(Sender: TObject);
    procedure sbtnIncluirClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmTabUsuarios: TfrmTabUsuarios;

implementation

{$R *.DFM}

procedure TfrmTabUsuarios.sbtnExcluirClick(Sender: TObject);
begin
// Address $5D0654
end;

procedure TfrmTabUsuarios.sbtnConfirmaClick(Sender: TObject);
begin
// Address $5D04B8
end;

procedure TfrmTabUsuarios.sbtnIncluirClick(Sender: TObject);
begin
// Address $5D066C
end;

end.
