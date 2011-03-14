unit ufrmDesfazRecepcao;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, StdCtrls, Buttons, ComCtrls;

type
  TfrmDesfazRecepcao = class(TfrmBaseClient)
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
  frmDesfazRecepcao: TfrmDesfazRecepcao;

implementation

{$R *.DFM}

procedure TfrmDesfazRecepcao.sbtnConfirmarClick(Sender: TObject);
begin
// Address $599054
end;

end.
