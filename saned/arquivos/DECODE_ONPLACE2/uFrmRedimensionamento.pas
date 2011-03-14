unit uFrmRedimensionamento;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, StdCtrls, ExtCtrls, DB, DBGrids, Buttons;

type
  TfrmRedimensionamento = class(TfrmBaseClient)
    GroupBox1: TGroupBox;
    Label1: TLabel;
    cmbGrupo: TComboBox;
    Bevel1: TBevel;
    DSRoteiro: TDataSource;
    DBGrRota: TDBGrid;
    Bevel2: TBevel;
    Label2: TLabel;
    cmbAgente: TComboBox;
    Label3: TLabel;
    EdMaleta: TEdit;
    chbChuva: TCheckBox;
    Label4: TLabel;
    EdSeqInicial: TEdit;
    Label5: TLabel;
    EdSeqFinal: TEdit;
    sbtIncluir: TSpeedButton;
    Bevel3: TBevel;
    Label6: TLabel;
    Label7: TLabel;
    sbtnRedimensionar: TSpeedButton;
    EdRoteiros: TEdit;
    sbtnValidar: TSpeedButton;
    sbtnImprimir: TSpeedButton;
    Bevel4: TBevel;
    Label8: TLabel;
    EdDividir: TEdit;
    Label9: TLabel;
    sbtnDividir: TSpeedButton;
    sbtnAgentes: TSpeedButton;
    procedure sbtnAgentesClick(Sender: TObject);
    procedure sbtnDividirClick(Sender: TObject);
    procedure sbtnImprimirClick(Sender: TObject);
    procedure sbtnValidarClick(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure sbtnRedimensionarClick(Sender: TObject);
    procedure sbtIncluirClick(Sender: TObject);
    procedure cmbAgenteChange(Sender: TObject);
    procedure DSRoteiroDataChange(Sender: TObject; Field: TField);
    procedure cmbGrupoChange(Sender: TObject);
    procedure cmbGrupoDropDown(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmRedimensionamento: TfrmRedimensionamento;

implementation

{$R *.DFM}

procedure TfrmRedimensionamento.sbtnAgentesClick(Sender: TObject);
begin
// Address $5D3E4C
end;

procedure TfrmRedimensionamento.sbtnDividirClick(Sender: TObject);
begin
// Address $5D4304
end;

procedure TfrmRedimensionamento.sbtnImprimirClick(Sender: TObject);
begin
// Address $5D57E8
end;

procedure TfrmRedimensionamento.sbtnValidarClick(Sender: TObject);
begin
// Address $5D6C94
end;

procedure TfrmRedimensionamento.FormShow(Sender: TObject);
begin
// Address $5D2AEC
end;

procedure TfrmRedimensionamento.sbtnRedimensionarClick(Sender: TObject);
begin
// Address $5D5928
end;

procedure TfrmRedimensionamento.sbtIncluirClick(Sender: TObject);
begin
// Address $5D2BE0
end;

procedure TfrmRedimensionamento.cmbAgenteChange(Sender: TObject);
begin
// Address $5D22C4
end;

procedure TfrmRedimensionamento.DSRoteiroDataChange(Sender: TObject; Field: TField);
begin
// Address $5D2764
end;

procedure TfrmRedimensionamento.cmbGrupoChange(Sender: TObject);
begin
// Address $5D234C
end;

procedure TfrmRedimensionamento.cmbGrupoDropDown(Sender: TObject);
begin
// Address $5D2654
end;

end.
