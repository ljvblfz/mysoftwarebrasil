unit DBLogDlg;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  ExtCtrls, StdCtrls;

type
  TLoginDialog = class(TForm)
    Panel: TPanel;
    Bevel: TBevel;
    DatabaseName: TLabel;
    OKButton: TButton;
    CancelButton: TButton;
    Panel1: TPanel;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Password: TEdit;
    UserName: TEdit;
    procedure FormShow(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  LoginDialog: TLoginDialog;

implementation

{$R *.DFM}

procedure TLoginDialog.FormShow(Sender: TObject);
begin
// Address $5AD3A0
end;

end.
