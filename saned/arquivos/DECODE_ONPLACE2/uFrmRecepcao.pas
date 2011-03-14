unit uFrmRecepcao;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, StdCtrls, Buttons, ComCtrls;

type
  TfrmRecepcao = class(TfrmBaseClient)
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
  frmRecepcao: TfrmRecepcao;

implementation

{$R *.DFM}

procedure TfrmRecepcao.sbtnConfirmarClick(Sender: TObject);
begin
// Address $598794
end;

end.
