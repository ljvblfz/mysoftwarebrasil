unit ufrmDesfazCarga;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, StdCtrls, Buttons, ComCtrls;

type
  TfrmDesfazCarga = class(TfrmBaseClient)
    ListBox: TListBox;
    sbtnConfirmar: TSpeedButton;
    ProgressBar: TProgressBar;
    ProgressBarTotal: TProgressBar;
    procedure sbtnConfirmarClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmDesfazCarga: TfrmDesfazCarga;

implementation

{$R *.DFM}

procedure TfrmDesfazCarga.sbtnConfirmarClick(Sender: TObject);
begin
// Address $59A880
end;

end.
