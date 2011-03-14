unit uFrmColetores;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClientTabela, StdCtrls, DBCtrls, DBTables, DB;

type
  TfrmColetores = class(TfrmBaseClientTabela)
    Label1: TLabel;
    Label3: TLabel;
    DBEdMaleta: TDBEdit;
    Label4: TLabel;
    DBEdGrupo: TDBEdit;
    Label5: TLabel;
    DBEdRota: TDBEdit;
    Label6: TLabel;
    DBEdData: TDBEdit;
    Label7: TLabel;
    DBEdTexto: TDBEdit;
    DBLCmbAgente: TDBLookupComboBox;
    qryAgente: TQuery;
    DSAgente: TDataSource;
    tbPrincipalpe_nome_agente: TStringField;
    tbPrincipalpe_agente: TIntegerField;
    tbPrincipalpe_maleta: TIntegerField;
    tbPrincipalpe_grupo: TIntegerField;
    tbPrincipalpe_rota: TIntegerField;
    tbPrincipalpe_data: TDateTimeField;
    tbPrincipalpe_descricao: TStringField;
    qryAgenteag_codigo: TIntegerField;
    qryAgenteag_nome: TStringField;
    qryAgenteagente: TStringField;
    procedure sbtnConfirmaClick(Sender: TObject);
    procedure sbtnIncluirClick(Sender: TObject);
    procedure sbtnExcluirClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmColetores: TfrmColetores;

implementation

{$R *.DFM}

procedure TfrmColetores.sbtnConfirmaClick(Sender: TObject);
begin
// Address $609E74
end;

procedure TfrmColetores.sbtnIncluirClick(Sender: TObject);
begin
// Address $60A088
end;

procedure TfrmColetores.sbtnExcluirClick(Sender: TObject);
begin
// Address $609E98
end;

end.
