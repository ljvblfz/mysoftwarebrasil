unit DBPWDlg;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls;

type
  TPasswordDialog = class(TForm)
    GroupBox1: TGroupBox;
    Edit: TEdit;
    AddButton: TButton;
    RemoveButton: TButton;
    RemoveAllButton: TButton;
    OKButton: TButton;
    CancelButton: TButton;
    procedure EditChange(Sender: TObject);
    procedure AddButtonClick(Sender: TObject);
    procedure RemoveButtonClick(Sender: TObject);
    procedure RemoveAllButtonClick(Sender: TObject);
    procedure OKButtonClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  PasswordDialog: TPasswordDialog;

implementation

{$R *.DFM}

procedure TPasswordDialog.EditChange(Sender: TObject);
begin
// Address $5ACB24
end;

procedure TPasswordDialog.AddButtonClick(Sender: TObject);
begin
// Address $5ACBAC
end;

procedure TPasswordDialog.RemoveButtonClick(Sender: TObject);
begin
// Address $5ACC24
end;

procedure TPasswordDialog.RemoveAllButtonClick(Sender: TObject);
begin
// Address $5ACC94
end;

procedure TPasswordDialog.OKButtonClick(Sender: TObject);
begin
// Address $5ACCB4
end;

end.
