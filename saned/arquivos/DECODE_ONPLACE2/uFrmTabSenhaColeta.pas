unit uFrmTabSenhaColeta;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClientTabela, StdCtrls, DBCtrls, DB;

type
  TfrmTabSenhaColeta = class(TfrmBaseClientTabela)
    Label1: TLabel;
    DBEVigencia: TDBEdit;
    Label2: TLabel;
    DBESenha: TDBEdit;
    tbPrincipalsc_data_vigencia: TDateTimeField;
    tbPrincipalsc_senha: TStringField;
    tbPrincipalsc_chave: TStringField;
    tbPrincipalsc_data_atualiz: TDateTimeField;
    procedure sbtnConfirmaClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmTabSenhaColeta: TfrmTabSenhaColeta;

implementation

{$R *.DFM}

procedure TfrmTabSenhaColeta.sbtnConfirmaClick(Sender: TObject);
begin
// Address $61026C
end;

end.
