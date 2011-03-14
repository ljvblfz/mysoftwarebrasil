unit uFrmFinalizaRota;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, StdCtrls, Buttons, DBTables;

type
  TfrmFinalizaRota = class(TfrmBaseClient)
    GroupBox1: TGroupBox;
    LGrupo: TLabel;
    LRota: TLabel;
    cmbGrupo: TComboBox;
    cmbRota: TComboBox;
    ckbTodos: TCheckBox;
    sbtnConfirmar: TSpeedButton;
    qryGeral: TQuery;
    qryInsere: TQuery;
    ckbCarga: TCheckBox;
    procedure ckbCargaClick(Sender: TObject);
    procedure sbtnConfirmarClick(Sender: TObject);
    procedure ckbTodosClick(Sender: TObject);
    procedure cmbRotaDropDown(Sender: TObject);
    procedure cmbGrupoDropDown(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmFinalizaRota: TfrmFinalizaRota;

implementation

{$R *.DFM}

procedure TfrmFinalizaRota.ckbCargaClick(Sender: TObject);
begin
// Address $60C1CC
end;

procedure TfrmFinalizaRota.sbtnConfirmarClick(Sender: TObject);
begin
// Address $60C758
end;

procedure TfrmFinalizaRota.ckbTodosClick(Sender: TObject);
begin
// Address $60C200
end;

procedure TfrmFinalizaRota.cmbRotaDropDown(Sender: TObject);
begin
// Address $60C448
end;

procedure TfrmFinalizaRota.cmbGrupoDropDown(Sender: TObject);
begin
// Address $60C234
end;

end.
