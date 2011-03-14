unit uFrmLogin;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  DBTables, DB, Buttons, StdCtrls, ExtCtrls;

type
  TfrmLogin = class(TForm)
    TbChave: TTable;
    DataSource1: TDataSource;
    TbChavech_chave: TStringField;
    TbChavech_senha: TStringField;
    TbChavech_nome: TStringField;
    TbChavech_status: TBooleanField;
    BitBtSair: TBitBtn;
    BitBtEnter: TBitBtn;
    edNovaSenha: TEdit;
    Label4: TLabel;
    edSenha: TEdit;
    Label3: TLabel;
    edChave: TEdit;
    Label2: TLabel;
    Image1: TImage;
    procedure BitBtEnterClick(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure BitBtSairClick(Sender: TObject);
    procedure ExtractDiskSerial;
    procedure edSenhaChange(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmLogin: TfrmLogin;

implementation

{$R *.DFM}

procedure TfrmLogin.BitBtEnterClick(Sender: TObject);
begin
// Address $57BAE4
end;

procedure TfrmLogin.FormShow(Sender: TObject);
begin
// Address $57C164
end;

procedure TfrmLogin.BitBtSairClick(Sender: TObject);
begin
// Address $57C334
end;

procedure TfrmLogin.ExtractDiskSerial;
begin
// Address $57C348
end;

procedure TfrmLogin.edSenhaChange(Sender: TObject);
begin
// Address $57C6C0
end;

end.
