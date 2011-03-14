unit uFrmRelatorioOcorrencia;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, StdCtrls, Buttons, DBTables;

type
  TfrmRelatorioOcorrencia = class(TfrmBaseClient)
    GroupBox1: TGroupBox;
    LGrupo: TLabel;
    LRota: TLabel;
    Label1: TLabel;
    cmbGrupo: TComboBox;
    cmbRota: TComboBox;
    ckbTodos: TCheckBox;
    cmbRotaFim: TComboBox;
    sbtnImprimir: TSpeedButton;
    Label2: TLabel;
    cmbOcorrencia: TComboBox;
    qryGrupo: TQuery;
    qryRota: TQuery;
    qryOcorrencia: TQuery;
    procedure sbtnImprimirClick(Sender: TObject);
    procedure cmbGrupoChange(Sender: TObject);
    procedure cmbGrupoDropDown(Sender: TObject);
    procedure ckbTodosClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmRelatorioOcorrencia: TfrmRelatorioOcorrencia;

implementation

{$R *.DFM}

procedure TfrmRelatorioOcorrencia.sbtnImprimirClick(Sender: TObject);
begin
// Address $5DE0C4
end;

procedure TfrmRelatorioOcorrencia.cmbGrupoChange(Sender: TObject);
begin
// Address $5DDBFC
end;

procedure TfrmRelatorioOcorrencia.cmbGrupoDropDown(Sender: TObject);
begin
// Address $5DDDD0
end;

procedure TfrmRelatorioOcorrencia.ckbTodosClick(Sender: TObject);
begin
// Address $5DDB98
end;

end.
