unit uFrmSimulacao;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, ComCtrls, StdCtrls, DBTables, Mask, Buttons;

type
  TfrmSimulacao = class(TfrmBaseClient)
    PageControl: TPageControl;
    tabPesquisar: TTabSheet;
    tbsResultado: TTabSheet;
    GroupBox1: TGroupBox;
    GroupBox2: TGroupBox;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    Label7: TLabel;
    Label8: TLabel;
    Label9: TLabel;
    cmbGrupo: TComboBox;
    EdDiasConsumo: TEdit;
    EdVolume: TEdit;
    EdEcoRes: TEdit;
    EdEcoSoc: TEdit;
    EdEcoInd: TEdit;
    EdEcoCom: TEdit;
    EdEcoPub: TEdit;
    EdEcoEA: TEdit;
    qryGrupo: TQuery;
    ckbGrandeConsumidor: TCheckBox;
    meDataLeitura: TMaskEdit;
    Label10: TLabel;
    GroupBox3: TGroupBox;
    ckbBloqueada: TCheckBox;
    Label11: TLabel;
    EdBloqAnt: TEdit;
    Label12: TLabel;
    EdBloqAtual: TEdit;
    sbtnCalcular: TSpeedButton;
    Label13: TLabel;
    cmbLigacao: TComboBox;
    qryReferencia: TQuery;
    Label14: TLabel;
    Label15: TLabel;
    Label16: TLabel;
    Label17: TLabel;
    Label18: TLabel;
    Label19: TLabel;
    Label20: TLabel;
    Label21: TLabel;
    Label22: TLabel;
    Label23: TLabel;
    Label24: TLabel;
    Label25: TLabel;
    Label26: TLabel;
    EdVolAgRes: TEdit;
    EdVolAgSoc: TEdit;
    EdVolAgInd: TEdit;
    EdVolAgCom: TEdit;
    EdVolAgPub: TEdit;
    EdVolAgEA: TEdit;
    EdVolAgGC: TEdit;
    EdVolAg: TEdit;
    EdVolEsg: TEdit;
    EdVolEsgGC: TEdit;
    EdVolEsgEA: TEdit;
    EdVolEsgPub: TEdit;
    EdVolEsgCom: TEdit;
    EdVolEsgInd: TEdit;
    EdVolEsgSoc: TEdit;
    EdVolEsgRes: TEdit;
    EdValorAg: TEdit;
    EdValorAgGC: TEdit;
    EdValorAgEA: TEdit;
    EdValorAgPub: TEdit;
    EdValorAgCom: TEdit;
    EdValorAgInd: TEdit;
    EdValorAgSoc: TEdit;
    EdValorAgRes: TEdit;
    EdValorEsg: TEdit;
    EdValorEsgGC: TEdit;
    EdValorEsgEA: TEdit;
    EdValorEsgPub: TEdit;
    EdValorEsgCom: TEdit;
    EdValorEsgInd: TEdit;
    EdValorEsgSoc: TEdit;
    EdValorEsgRes: TEdit;
    EdValorTotal: TEdit;
    EdValorTotalGC: TEdit;
    EdValorTotalEA: TEdit;
    EdValorTotalPub: TEdit;
    EdValorTotalCom: TEdit;
    EdValorTotalInd: TEdit;
    EdValorTotalSoc: TEdit;
    EdValorTotalRes: TEdit;
    Label27: TLabel;
    cmbDesconto: TComboBox;
    qryDesconto: TQuery;
    EdValorDesconto: TEdit;
    EdTotal: TEdit;
    Label28: TLabel;
    Label29: TLabel;
    procedure cmbGrupoChange(Sender: TObject);
    procedure cmbLigacaoChange(Sender: TObject);
    procedure ckbGrandeConsumidorClick(Sender: TObject);
    procedure EdDiasConsumoKeyPress(Sender: TObject; var Key: Char);
    procedure ckbBloqueadaClick(Sender: TObject);
    procedure sbtnCalcularClick(Sender: TObject);
    procedure cmbGrupoDropDown(Sender: TObject);
    procedure FormShow(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmSimulacao: TfrmSimulacao;

implementation

{$R *.DFM}

procedure TfrmSimulacao.cmbGrupoChange(Sender: TObject);
begin
// Address $60D740
end;

procedure TfrmSimulacao.cmbLigacaoChange(Sender: TObject);
begin
// Address $60D810
end;

procedure TfrmSimulacao.ckbGrandeConsumidorClick(Sender: TObject);
begin
// Address $60D738
end;

procedure TfrmSimulacao.EdDiasConsumoKeyPress(Sender: TObject; var Key: Char);
begin
// Address $60D818
end;

procedure TfrmSimulacao.ckbBloqueadaClick(Sender: TObject);
begin
// Address $60D6C8
end;

procedure TfrmSimulacao.sbtnCalcularClick(Sender: TObject);
begin
// Address $60DA68
end;

procedure TfrmSimulacao.cmbGrupoDropDown(Sender: TObject);
begin
// Address $60D748
end;

procedure TfrmSimulacao.FormShow(Sender: TObject);
begin
// Address $60D820
end;

end.
