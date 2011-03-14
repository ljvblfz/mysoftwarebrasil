unit uFrmVencimentoGrupo;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, StdCtrls, ExtCtrls, DBTables, DB, DBGrids;

type
  TfrmVencimentoGrupo = class(TfrmBaseClient)
    GroupBox1: TGroupBox;
    Label1: TLabel;
    cmbGrupo: TComboBox;
    Bevel1: TBevel;
    qryGrupo: TQuery;
    qryRoteiro: TQuery;
    DataSource1: TDataSource;
    DBGrRota: TDBGrid;
    Label2: TLabel;
    EdReferencia: TEdit;
    procedure DataSource1DataChange(Sender: TObject; Field: TField);
    procedure cmbGrupoChange(Sender: TObject);
    procedure cmbGrupoDropDown(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmVencimentoGrupo: TfrmVencimentoGrupo;

implementation

{$R *.DFM}

procedure TfrmVencimentoGrupo.DataSource1DataChange(Sender: TObject; Field: TField);
begin
// Address $5D7DC4
end;

procedure TfrmVencimentoGrupo.cmbGrupoChange(Sender: TObject);
begin
// Address $5D7BEC
end;

procedure TfrmVencimentoGrupo.cmbGrupoDropDown(Sender: TObject);
begin
// Address $5D7CCC
end;

end.
