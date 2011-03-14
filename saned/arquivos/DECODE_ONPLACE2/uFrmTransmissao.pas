unit uFrmTransmissao;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, StdCtrls, Buttons, ComCtrls;

type
  TfrmTransmissao = class(TfrmBaseClient)
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
  frmTransmissao: TfrmTransmissao;

implementation

{$R *.DFM}

procedure TfrmTransmissao.sbtnConfirmarClick(Sender: TObject);
begin
// Address $5A8E54
end;

end.
