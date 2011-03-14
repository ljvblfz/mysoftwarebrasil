unit uFrmAnalise;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, ExtCtrls, StdCtrls, DBCtrls, DBGrids, DB, Buttons;

type
  TfrmAnalise = class(TfrmBaseClient)
    PSelecao: TPanel;
    Shape1: TShape;
    Label1: TLabel;
    cmbGrupo: TComboBox;
    Label2: TLabel;
    cmbRota: TComboBox;
    DBNavigador: TDBNavigator;
    LInf: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    DBTTipoLigacao: TDBText;
    GroupBox1: TGroupBox;
    DBGrid1: TDBGrid;
    DBTNome: TDBText;
    DBTEndereco: TDBText;
    DBTComplemento: TDBText;
    DBTStatus: TDBText;
    DBTCategoria: TDBText;
    DBTNatureza: TDBText;
    DSCliAnalise: TDataSource;
    sbtnCalcular: TSpeedButton;
    v: TGroupBox;
    DBGrid2: TDBGrid;
    Label5: TLabel;
    DBEHidrometro: TDBEdit;
    DBEDigitoHD: TDBEdit;
    Shape3: TShape;
    DBEEcoRes: TDBEdit;
    DBEEcoCom: TDBEdit;
    DBEEcoInd: TDBEdit;
    DBEEcoPub: TDBEdit;
    DBEEcoSoc: TDBEdit;
    DBEEcoEA: TDBEdit;
    Label6: TLabel;
    Label7: TLabel;
    Label8: TLabel;
    Label9: TLabel;
    Label10: TLabel;
    Label11: TLabel;
    Shape4: TShape;
    Shape5: TShape;
    Label12: TLabel;
    Label13: TLabel;
    DBEConsumoMedio: TDBEdit;
    DBELeituraAnt: TDBEdit;
    DBEDataLeituraAnt: TDBEdit;
    Label14: TLabel;
    Label15: TLabel;
    DBEDataInstalacao: TDBEdit;
    DBELeituraInst: TDBEdit;
    DBEDiasBloqueioAtual: TDBEdit;
    Label17: TLabel;
    Label18: TLabel;
    DBEDiasBloqueioAnt: TDBEdit;
    DBEBoqueado: TDBEdit;
    EdSequencia: TEdit;
    EdMatricula: TEdit;
    DSAnalise: TDataSource;
    GroupBox2: TGroupBox;
    Label16: TLabel;
    DBEDataLeitura: TDBEdit;
    Label19: TLabel;
    DBELeituraAtual: TDBEdit;
    DBEOcorrencia: TDBEdit;
    EdVariacao: TEdit;
    Label20: TLabel;
    DBEDiasConsumo: TDBEdit;
    DBTDescOcorrencia: TDBText;
    Label21: TLabel;
    DBEConsumoMedido: TDBEdit;
    Label22: TLabel;
    DBEConsumoAjustado: TDBEdit;
    PCalcular: TPanel;
    Shape2: TShape;
    Label23: TLabel;
    Label24: TLabel;
    Label25: TLabel;
    DBEDataBloqueio: TDBEdit;
    DBEDataDesbloqueio: TDBEdit;
    rbtConfirma: TRadioButton;
    rbtNovaLeitura: TRadioButton;
    rbtAnormalidade: TRadioButton;
    chbSemSolucao: TCheckBox;
    chbManterLeitura: TCheckBox;
    EdNovaLeitura: TEdit;
    DBELeituraRealConfirmada: TDBEdit;
    cmbAnormalidade: TComboBox;
    Shape6: TShape;
    Label26: TLabel;
    Label27: TLabel;
    EdConsumo: TEdit;
    EdConsumoAjustado: TEdit;
    EdLeituraReal: TEdit;
    EdLeituraAjustada: TEdit;
    EdAnormalidade: TEdit;
    ckbAjustar: TCheckBox;
    btCalcular: TButton;
    procedure FormShow(Sender: TObject);
    procedure btCalcularClick(Sender: TObject);
    procedure chbManterLeituraClick(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure sbtnCalcularClick(Sender: TObject);
    procedure EdNovaLeituraKeyPress(Sender: TObject; var Key: Char);
    procedure EdNovaLeituraExit(Sender: TObject);
    procedure rbtAnormalidadeClick(Sender: TObject);
    procedure DBESequenciaExit(Sender: TObject);
    procedure EdMatriculaKeyPress(Sender: TObject; var Key: Char);
    procedure EdSequenciaKeyPress(Sender: TObject; var Key: Char);
    procedure DSAnaliseDataChange(Sender: TObject; Field: TField);
    procedure DSCliAnaliseDataChange(Sender: TObject; Field: TField);
    procedure FormActivate(Sender: TObject);
    procedure cmbRotaChange(Sender: TObject);
    procedure cmbRotaDropDown(Sender: TObject);
    procedure cmbGrupoDropDown(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmAnalise: TfrmAnalise;

implementation

{$R *.DFM}

procedure TfrmAnalise.FormShow(Sender: TObject);
begin
// Address $5CC9BC
end;

procedure TfrmAnalise.btCalcularClick(Sender: TObject);
begin
// Address $5CCA48
end;

procedure TfrmAnalise.chbManterLeituraClick(Sender: TObject);
begin
// Address $5CCDDC
end;

procedure TfrmAnalise.FormClose(Sender: TObject; var Action: TCloseAction);
begin
// Address $5CC99C
end;

procedure TfrmAnalise.sbtnCalcularClick(Sender: TObject);
begin
// Address $5CA738
end;

procedure TfrmAnalise.EdNovaLeituraKeyPress(Sender: TObject; var Key: Char);
begin
// Address $5CC71C
end;

procedure TfrmAnalise.EdNovaLeituraExit(Sender: TObject);
begin
// Address $5CC714
end;

procedure TfrmAnalise.rbtAnormalidadeClick(Sender: TObject);
begin
// Address $5CA658
end;

procedure TfrmAnalise.DBESequenciaExit(Sender: TObject);
begin
// Address $5CBB7C
end;

procedure TfrmAnalise.EdMatriculaKeyPress(Sender: TObject; var Key: Char);
begin
// Address $5CC4DC
end;

procedure TfrmAnalise.EdSequenciaKeyPress(Sender: TObject; var Key: Char);
begin
// Address $5CC728
end;

procedure TfrmAnalise.DSAnaliseDataChange(Sender: TObject; Field: TField);
begin
// Address $5CBC64
end;

procedure TfrmAnalise.DSCliAnaliseDataChange(Sender: TObject; Field: TField);
begin
// Address $5CC1A4
end;

procedure TfrmAnalise.FormActivate(Sender: TObject);
begin
// Address $5CC964
end;

procedure TfrmAnalise.cmbRotaChange(Sender: TObject);
begin
// Address $5CB87C
end;

procedure TfrmAnalise.cmbRotaDropDown(Sender: TObject);
begin
// Address $5CB918
end;

procedure TfrmAnalise.cmbGrupoDropDown(Sender: TObject);
begin
// Address $5CA4D8
end;

end.
