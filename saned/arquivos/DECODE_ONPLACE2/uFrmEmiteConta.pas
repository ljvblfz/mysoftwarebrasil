unit uFrmEmiteConta;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, StdCtrls, Buttons, DBTables;

type
  TfrmEmiteConta = class(TfrmBaseClient)
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
    EdCDC: TEdit;
    grbEmissao: TGroupBox;
    rdbAviso: TRadioButton;
    rdbNotificacao: TRadioButton;
    qryGrupo: TQuery;
    qryRota: TQuery;
    grbFatura: TGroupBox;
    rdbTodas: TRadioButton;
    rdbRetidas: TRadioButton;
    rdbColetadas: TRadioButton;
    procedure sbtnImprimirClick(Sender: TObject);
    procedure ckbTodosClick(Sender: TObject);
    procedure cmbGrupoChange(Sender: TObject);
    procedure cmbGrupoDropDown(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmEmiteConta: TfrmEmiteConta;

implementation

{$R *.DFM}

procedure TfrmEmiteConta.sbtnImprimirClick(Sender: TObject);
begin
// Address $5DE74C
end;

procedure TfrmEmiteConta.ckbTodosClick(Sender: TObject);
begin
// Address $5DEB88
end;

procedure TfrmEmiteConta.cmbGrupoChange(Sender: TObject);
begin
// Address $5DEBEC
end;

procedure TfrmEmiteConta.cmbGrupoDropDown(Sender: TObject);
begin
// Address $5DEDC0
end;

end.
