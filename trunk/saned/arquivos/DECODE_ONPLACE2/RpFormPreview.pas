unit RpFormPreview;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  ActnList, Menus, ComCtrls, StdCtrls, ExtCtrls;

type
  TRavePreviewForm = class(TForm)
    ScrollBox1: TScrollBox;
    ActionList1: TActionList;
    MainMenu1: TMainMenu;
    PopupMenu1: TPopupMenu;
    actnFile_Print: TAction;
    actnFile_Save: TAction;
    actnFile_Exit: TAction;
    actnFile_Open: TAction;
    sbarMain: TStatusBar;
    actnPage_First: TAction;
    actnPage_Next: TAction;
    actnPage_Previous: TAction;
    actnPage_Last: TAction;
    actnZoom_In: TAction;
    actnZoom_Out: TAction;
    actnZoom_PageWidth: TAction;
    actnZoom_Page: TAction;
    Page1: TMenuItem;
    Zoom1: TMenuItem;
    First1: TMenuItem;
    Next1: TMenuItem;
    Previous1: TMenuItem;
    Last1: TMenuItem;
    N2: TMenuItem;
    GotoPage1: TMenuItem;
    In1: TMenuItem;
    Out1: TMenuItem;
    N3: TMenuItem;
    Page2: TMenuItem;
    PageWidth1: TMenuItem;
    In2: TMenuItem;
    Out2: TMenuItem;
    ilstActions: TImageList;
    ToolBar1: TToolBar;
    ToolButton1: TToolButton;
    ToolButton2: TToolButton;
    ToolButton3: TToolButton;
    ToolButton4: TToolButton;
    ToolButton5: TToolButton;
    ToolButton6: TToolButton;
    ToolButton7: TToolButton;
    ToolButton8: TToolButton;
    ToolButton10: TToolButton;
    ToolButton11: TToolButton;
    ToolButton12: TToolButton;
    ToolButton13: TToolButton;
    ToolButton14: TToolButton;
    dlogOpen: TOpenDialog;
    dlogSave: TSaveDialog;
    File1: TMenuItem;
    Open1: TMenuItem;
    SaveAs1: TMenuItem;
    Print1: TMenuItem;
    N1: TMenuItem;
    Exit1: TMenuItem;
    ZoomEdit: TEdit;
    PageEdit: TEdit;
    PageLabel: TPanel;
    Panel1: TPanel;
    Panel2: TPanel;
    ToolButton9: TToolButton;
    ToolButton15: TToolButton;
    Panel3: TPanel;
    PreviewTimer: TTimer;
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure NDRPreviewPageChange;
    procedure NDRPreviewZoomChange;
    procedure FormKeyDown(Sender: TObject; var Key: Word; Shift: TShiftState);
    procedure FormKeyPress(Sender: TObject; var Key: Char);
    procedure actnFile_ExitExecute(Sender: TObject);
    procedure actnPage_GotoPageExecute(Sender: TObject);
    procedure actnZoom_InExecute(Sender: TObject);
    procedure actnZoom_OutExecute(Sender: TObject);
    procedure actnPage_PreviousExecute(Sender: TObject);
    procedure actnPage_NextExecute(Sender: TObject);
    procedure actnZoom_PageWidthExecute(Sender: TObject);
    procedure actnZoom_PageExecute(Sender: TObject);
    procedure actnFile_PrintExecute(Sender: TObject);
    procedure actnPage_FirstExecute(Sender: TObject);
    procedure actnPage_LastExecute(Sender: TObject);
    procedure actnPage_FirstUpdate(Sender: TObject);
    procedure actnPage_PreviousUpdate(Sender: TObject);
    procedure actnPage_NextUpdate(Sender: TObject);
    procedure actnPage_LastUpdate(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure actnFile_SaveExecute(Sender: TObject);
    procedure actnFile_OpenExecute(Sender: TObject);
    procedure actnFile_PrintUpdate(Sender: TObject);
    procedure actnFile_SaveUpdate(Sender: TObject);
    procedure actnZoom_InUpdate(Sender: TObject);
    procedure actnZoom_OutUpdate(Sender: TObject);
    procedure actnZoom_PageWidthUpdate(Sender: TObject);
    procedure actnZoom_PageUpdate(Sender: TObject);
    procedure ZoomEditKeyPress(Sender: TObject; var Key: Char);
    procedure ZoomEditExit(Sender: TObject);
    procedure PageEditExit(Sender: TObject);
    procedure PageEditKeyPress(Sender: TObject; var Key: Char);
    procedure PreviewTimerTimer(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure FormShow(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  RavePreviewForm: TRavePreviewForm;

implementation

{$R *.DFM}

procedure TRavePreviewForm.FormClose(Sender: TObject; var Action: TCloseAction);
begin
// Address $50043C
end;

procedure TRavePreviewForm.NDRPreviewPageChange;
begin
// Address $500444
end;

procedure TRavePreviewForm.NDRPreviewZoomChange;
begin
// Address $5005DC
end;

procedure TRavePreviewForm.FormKeyDown(Sender: TObject; var Key: Word; Shift: TShiftState);
begin
// Address $500690
end;

procedure TRavePreviewForm.FormKeyPress(Sender: TObject; var Key: Char);
begin
// Address $500A50
end;

procedure TRavePreviewForm.actnFile_ExitExecute(Sender: TObject);
begin
// Address $500D9C
end;

procedure TRavePreviewForm.actnPage_GotoPageExecute(Sender: TObject);
begin
// Address $500DA4
end;

procedure TRavePreviewForm.actnZoom_InExecute(Sender: TObject);
begin
// Address $500EA4
end;

procedure TRavePreviewForm.actnZoom_OutExecute(Sender: TObject);
begin
// Address $500EBC
end;

procedure TRavePreviewForm.actnPage_PreviousExecute(Sender: TObject);
begin
// Address $500ED4
end;

procedure TRavePreviewForm.actnPage_NextExecute(Sender: TObject);
begin
// Address $500EEC
end;

procedure TRavePreviewForm.actnZoom_PageWidthExecute(Sender: TObject);
begin
// Address $500F04
end;

procedure TRavePreviewForm.actnZoom_PageExecute(Sender: TObject);
begin
// Address $500F30
end;

procedure TRavePreviewForm.actnFile_PrintExecute(Sender: TObject);
begin
// Address $500F5C
end;

procedure TRavePreviewForm.actnPage_FirstExecute(Sender: TObject);
begin
// Address $5010FC
end;

procedure TRavePreviewForm.actnPage_LastExecute(Sender: TObject);
begin
// Address $50111C
end;

procedure TRavePreviewForm.actnPage_FirstUpdate(Sender: TObject);
begin
// Address $501144
end;

procedure TRavePreviewForm.actnPage_PreviousUpdate(Sender: TObject);
begin
// Address $501160
end;

procedure TRavePreviewForm.actnPage_NextUpdate(Sender: TObject);
begin
// Address $50117C
end;

procedure TRavePreviewForm.actnPage_LastUpdate(Sender: TObject);
begin
// Address $5011A4
end;

procedure TRavePreviewForm.FormCreate(Sender: TObject);
begin
// Address $5011CC
end;

procedure TRavePreviewForm.actnFile_SaveExecute(Sender: TObject);
begin
// Address $501348
end;

procedure TRavePreviewForm.actnFile_OpenExecute(Sender: TObject);
begin
// Address $50158C
end;

procedure TRavePreviewForm.actnFile_PrintUpdate(Sender: TObject);
begin
// Address $5015F4
end;

procedure TRavePreviewForm.actnFile_SaveUpdate(Sender: TObject);
begin
// Address $501610
end;

procedure TRavePreviewForm.actnZoom_InUpdate(Sender: TObject);
begin
// Address $50162C
end;

procedure TRavePreviewForm.actnZoom_OutUpdate(Sender: TObject);
begin
// Address $50163C
end;

procedure TRavePreviewForm.actnZoom_PageWidthUpdate(Sender: TObject);
begin
// Address $50164C
end;

procedure TRavePreviewForm.actnZoom_PageUpdate(Sender: TObject);
begin
// Address $50165C
end;

procedure TRavePreviewForm.ZoomEditKeyPress(Sender: TObject; var Key: Char);
begin
// Address $5016D0
end;

procedure TRavePreviewForm.ZoomEditExit(Sender: TObject);
begin
// Address $50181C
end;

procedure TRavePreviewForm.PageEditExit(Sender: TObject);
begin
// Address $5018A4
end;

procedure TRavePreviewForm.PageEditKeyPress(Sender: TObject; var Key: Char);
begin
// Address $501924
end;

procedure TRavePreviewForm.PreviewTimerTimer(Sender: TObject);
begin
// Address $501A8C
end;

procedure TRavePreviewForm.FormDestroy(Sender: TObject);
begin
// Address $501A9C
end;

procedure TRavePreviewForm.FormShow(Sender: TObject);
begin
// Address $501BCC
end;

end.
