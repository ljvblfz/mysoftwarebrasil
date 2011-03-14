unit uFrmRelatorioMedicao;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, StdCtrls, Buttons, DBTables;

type
  TfrmRelatorioMedicao = class(TfrmBaseClient)
    GroupBox1: TGroupBox;
    LGrupo: TLabel;
    cmbReferencia: TComboBox;
    sbtnImprimir: TSpeedButton;
    qryReferencia: TQuery;
    procedure sbtnImprimirClick(Sender: TObject);
    procedure cmbReferenciaDropDown(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmRelatorioMedicao: TfrmRelatorioMedicao;

implementation

{$R *.DFM}

procedure TfrmRelatorioMedicao.sbtnImprimirClick(Sender: TObject);
begin
// Address $5DF600
end;

procedure TfrmRelatorioMedicao.cmbReferenciaDropDown(Sender: TObject);
begin
// Address $5DF4AC
end;

end.
