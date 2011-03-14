unit uFrmRetorno;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, StdCtrls, Buttons, ComCtrls;

type
  TfrmRetorno = class(TfrmBaseClient)
    ListBox: TListBox;
    sbtnConfirmar: TSpeedButton;
    ProgressBar: TProgressBar;
    LInformacao: TLabel;
    procedure sbtnConfirmarClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmRetorno: TfrmRetorno;

implementation

{$R *.DFM}

procedure TfrmRetorno.sbtnConfirmarClick(Sender: TObject);
begin
// Address $5A7910
end;

end.
