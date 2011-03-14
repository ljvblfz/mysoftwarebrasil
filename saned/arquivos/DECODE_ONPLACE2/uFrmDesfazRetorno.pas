unit uFrmDesfazRetorno;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, StdCtrls, Buttons, ComCtrls;

type
  TfrmDesfazRetorno = class(TfrmBaseClient)
    ListBox: TListBox;
    sbtnConfirmar: TSpeedButton;
    ProgressBar: TProgressBar;
    procedure sbtnConfirmarClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmDesfazRetorno: TfrmDesfazRetorno;

implementation

{$R *.DFM}

procedure TfrmDesfazRetorno.sbtnConfirmarClick(Sender: TObject);
begin
// Address $5A8614
end;

end.
