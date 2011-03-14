unit ufrmCarga;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, StdCtrls, Buttons, ComCtrls;

type
  TfrmCarga = class(TfrmBaseClient)
    ListBox: TListBox;
    sbtnConfirmar: TSpeedButton;
    ProgressBar: TProgressBar;
    ProgressBarTotal: TProgressBar;
    cbColeta: TCheckBox;
    procedure sbtnConfirmarClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmCarga: TfrmCarga;

implementation

{$R *.DFM}

procedure TfrmCarga.sbtnConfirmarClick(Sender: TObject);
begin
// Address $5997BC
end;

end.
