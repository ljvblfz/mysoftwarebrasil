unit RpFormSetup;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, Buttons, ComCtrls;

type
  TRPSetupForm = class(TForm)
    DestGB: TGroupBox;
    PrinterRB: TRadioButton;
    PreviewRB: TRadioButton;
    FileRB: TRadioButton;
    editFileName: TEdit;
    bbtnOK: TButton;
    CancelBB: TButton;
    SetupBB: TButton;
    RangeGB: TGroupBox;
    FileNameSB: TSpeedButton;
    dlogSave: TSaveDialog;
    AllRB: TRadioButton;
    SelectionRB: TRadioButton;
    PagesRB: TRadioButton;
    FromLabel: TLabel;
    FromED: TEdit;
    ToLabel: TLabel;
    ToED: TEdit;
    SelectionLabel: TLabel;
    SelectionED: TEdit;
    GroupBox1: TGroupBox;
    PrinterLabel: TLabel;
    GroupBox2: TGroupBox;
    CopiesED: TEdit;
    CopiesLabel: TLabel;
    CollateCK: TCheckBox;
    DuplexCK: TCheckBox;
    PageControl1: TPageControl;
    TabSheet1: TTabSheet;
    TabSheet2: TTabSheet;
    cboxFormat: TComboBox;
    Label1: TLabel;
    procedure SetupBBClick(Sender: TObject);
    procedure FileNameSBClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure PagesRBClick(Sender: TObject);
    procedure SelectionRBClick(Sender: TObject);
    procedure AllRBClick(Sender: TObject);
    procedure PrinterRBClick(Sender: TObject);
    procedure FileRBClick(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure bbtnOKClick(Sender: TObject);
    procedure editFileNameChange(Sender: TObject);
    procedure FormKeyPress(Sender: TObject; var Key: Char);
    procedure SelectionEDKeyPress(Sender: TObject; var Key: Char);
    procedure cboxFormatChange(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  RPSetupForm: TRPSetupForm;

implementation

{$R *.DFM}

procedure TRPSetupForm.SetupBBClick(Sender: TObject);
begin
// Address $4FEBF8
end;

procedure TRPSetupForm.FileNameSBClick(Sender: TObject);
begin
// Address $4FEC80
end;

procedure TRPSetupForm.FormCreate(Sender: TObject);
begin
// Address $4FED00
end;

procedure TRPSetupForm.PagesRBClick(Sender: TObject);
begin
// Address $4FED74
end;

procedure TRPSetupForm.SelectionRBClick(Sender: TObject);
begin
// Address $4FEE10
end;

procedure TRPSetupForm.AllRBClick(Sender: TObject);
begin
// Address $4FEE94
end;

procedure TRPSetupForm.PrinterRBClick(Sender: TObject);
begin
// Address $4FEEE8
end;

procedure TRPSetupForm.FileRBClick(Sender: TObject);
begin
// Address $4FEF70
end;

procedure TRPSetupForm.FormShow(Sender: TObject);
begin
// Address $4FF014
end;

procedure TRPSetupForm.bbtnOKClick(Sender: TObject);
begin
// Address $4FF338
end;

procedure TRPSetupForm.editFileNameChange(Sender: TObject);
begin
// Address $4FF8C4
end;

procedure TRPSetupForm.FormKeyPress(Sender: TObject; var Key: Char);
begin
// Address $4FF934
end;

procedure TRPSetupForm.SelectionEDKeyPress(Sender: TObject; var Key: Char);
begin
// Address $4FF9C4
end;

procedure TRPSetupForm.cboxFormatChange(Sender: TObject);
begin
// Address $4FFA58
end;

end.
