unit uFrmRelatorioApoio;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, StdCtrls, Buttons, DBTables;

type
  TfrmRelatorioApoio = class(TfrmBaseClient)
    GroupBox1: TGroupBox;
    cmbGrupo: TComboBox;
    LGrupo: TLabel;
    LRota: TLabel;
    cmbRota: TComboBox;
    sbtnImprimir: TSpeedButton;
    qryGrupo: TQuery;
    qryRota: TQuery;
    ckbTodos: TCheckBox;
    Label1: TLabel;
    cmbRotaFim: TComboBox;
    sbtnArquivo: TSpeedButton;
    SaveDialog: TSaveDialog;
    procedure sbtnArquivoClick(Sender: TObject);
    procedure cmbRotaFimDropDown(Sender: TObject);
    procedure sbtnImprimirClick(Sender: TObject);
    procedure ckbTodosClick(Sender: TObject);
    procedure cmbRotaDropDown(Sender: TObject);
    procedure cmbGrupoDropDown(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmRelatorioApoio: TfrmRelatorioApoio;

implementation

{$R *.DFM}

procedure TfrmRelatorioApoio.sbtnArquivoClick(Sender: TObject);
begin
// Address $5DBB54
end;

procedure TfrmRelatorioApoio.cmbRotaFimDropDown(Sender: TObject);
begin
// Address $5DC9B4
end;

procedure TfrmRelatorioApoio.sbtnImprimirClick(Sender: TObject);
begin
// Address $5DC3AC
end;

procedure TfrmRelatorioApoio.ckbTodosClick(Sender: TObject);
begin
// Address $5DC6D8
end;

procedure TfrmRelatorioApoio.cmbRotaDropDown(Sender: TObject);
begin
// Address $5DC830
end;

procedure TfrmRelatorioApoio.cmbGrupoDropDown(Sender: TObject);
begin
// Address $5DC738
end;

end.
