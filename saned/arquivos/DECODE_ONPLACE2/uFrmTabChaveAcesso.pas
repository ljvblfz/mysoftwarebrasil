unit uFrmTabChaveAcesso;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClientTabela, DBTables, DB, StdCtrls, DBCtrls, ComCtrls;

type
  TfrmTabChaveAcesso = class(TfrmBaseClientTabela)
    tbPai: TTable;
    DSPai: TDataSource;
    tbPrincipalca_chave: TStringField;
    tbPrincipalca_id: TIntegerField;
    tbPrincipalca_status: TBooleanField;
    tbPaich_chave: TStringField;
    tbPaich_senha: TStringField;
    tbPaich_nome: TStringField;
    tbPaich_status: TBooleanField;
    Label1: TLabel;
    DBEdit1: TDBEdit;
    Label2: TLabel;
    DBEdit2: TDBEdit;
    DBCheckBox1: TDBCheckBox;
    PageControl: TPageControl;
    qryAcesso: TQuery;
    qryAcessoac_id: TIntegerField;
    qryAcessoac_ordem: TIntegerField;
    qryAcessoac_name: TStringField;
    qryAcessoac_caption: TStringField;
    qryAcessoac_nivel: TIntegerField;
    qryAcessoac_onclick: TBooleanField;
    chbTotal: TCheckBox;
    procedure chbTotalClick(Sender: TObject);
    procedure sbtnConfirmaClick(Sender: TObject);
    procedure DSPaiDataChange(Sender: TObject; Field: TField);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmTabChaveAcesso: TfrmTabChaveAcesso;

implementation

{$R *.DFM}

procedure TfrmTabChaveAcesso.chbTotalClick(Sender: TObject);
begin
// Address $5D1058
end;

procedure TfrmTabChaveAcesso.sbtnConfirmaClick(Sender: TObject);
begin
// Address $5D1028
end;

procedure TfrmTabChaveAcesso.DSPaiDataChange(Sender: TObject; Field: TField);
begin
// Address $5D1148
end;

end.
