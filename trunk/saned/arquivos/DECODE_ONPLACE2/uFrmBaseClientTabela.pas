unit uFrmBaseClientTabela;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, DBCtrls, ExtCtrls, Buttons, DBTables, DB, DBGrids;

type
  TfrmBaseClientTabela = class(TfrmBaseClient)
    DBNavigator: TDBNavigator;
    pAction: TPanel;
    sbtnIncluir: TSpeedButton;
    sbtnExcluir: TSpeedButton;
    sbtnAlterar: TSpeedButton;
    pOkCancel: TPanel;
    sbtnConfirma: TSpeedButton;
    sbtnCancela: TSpeedButton;
    tbPrincipal: TTable;
    DSPrincipal: TDataSource;
    DBGrid: TDBGrid;
    sbtnLegenda: TSpeedButton;
    procedure sbtnLegendaClick(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure sbtnIncluirClick(Sender: TObject);
    procedure sbtnExcluirClick(Sender: TObject);
    procedure sbtnCancelaClick(Sender: TObject);
    procedure sbtnConfirmaClick(Sender: TObject);
    procedure sbtnAlterarClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmBaseClientTabela: TfrmBaseClientTabela;

implementation

{$R *.DFM}

procedure TfrmBaseClientTabela.sbtnLegendaClick(Sender: TObject);
begin
// Address $5C93F0
end;

procedure TfrmBaseClientTabela.FormClose(Sender: TObject; var Action: TCloseAction);
begin
// Address $5C9130
end;

procedure TfrmBaseClientTabela.sbtnIncluirClick(Sender: TObject);
begin
// Address $5C93C4
end;

procedure TfrmBaseClientTabela.sbtnExcluirClick(Sender: TObject);
begin
// Address $5C933C
end;

procedure TfrmBaseClientTabela.sbtnCancelaClick(Sender: TObject);
begin
// Address $5C94B8
end;

procedure TfrmBaseClientTabela.sbtnConfirmaClick(Sender: TObject);
begin
// Address $5C94EC
end;

procedure TfrmBaseClientTabela.sbtnAlterarClick(Sender: TObject);
begin
// Address $5C9314
end;

end.
