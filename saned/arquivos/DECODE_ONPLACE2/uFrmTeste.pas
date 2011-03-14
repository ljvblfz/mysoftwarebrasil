unit uFrmTeste;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, StdCtrls, ComCtrls, DBTables;

type
  TfrmTeste = class(TfrmBaseClient)
    Label1: TLabel;
    Label3: TLabel;
    PATH: TLabel;
    LStatus: TLabel;
    Label2: TLabel;
    Egrupo: TEdit;
    ERota: TEdit;
    btnGerar: TButton;
    EPath: TEdit;
    Button1: TButton;
    Button2: TButton;
    ProgressBar: TProgressBar;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Button7: TButton;
    Button8: TButton;
    btnStatus: TButton;
    EArquivo: TEdit;
    qryGeral: TQuery;
    Button9: TButton;
    procedure Button9Click(Sender: TObject);
    procedure btnStatusClick(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure Button8Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure btnGerarClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmTeste: TfrmTeste;

implementation

{$R *.DFM}

procedure TfrmTeste.Button9Click(Sender: TObject);
begin
// Address $597C90
end;

procedure TfrmTeste.btnStatusClick(Sender: TObject);
begin
// Address $597CEC
end;

procedure TfrmTeste.Button4Click(Sender: TObject);
begin
// Address $597AC8
end;

procedure TfrmTeste.Button6Click(Sender: TObject);
begin
// Address $598168
end;

procedure TfrmTeste.Button7Click(Sender: TObject);
begin
// Address $59825C
end;

procedure TfrmTeste.Button8Click(Sender: TObject);
begin
// Address $597BA8
end;

procedure TfrmTeste.Button5Click(Sender: TObject);
begin
// Address $598048
end;

procedure TfrmTeste.Button3Click(Sender: TObject);
begin
// Address $5979E0
end;

procedure TfrmTeste.Button2Click(Sender: TObject);
begin
// Address $597904
end;

procedure TfrmTeste.Button1Click(Sender: TObject);
begin
// Address $59782C
end;

procedure TfrmTeste.btnGerarClick(Sender: TObject);
begin
// Address $597724
end;

end.
