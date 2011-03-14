unit uFrmDesfazTransmissao;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, StdCtrls, Buttons, ComCtrls;

type
  TFrmDesfazTransmissao = class(TfrmBaseClient)
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
  FrmDesfazTransmissao: TFrmDesfazTransmissao;

implementation

{$R *.DFM}

procedure TFrmDesfazTransmissao.sbtnConfirmarClick(Sender: TObject);
begin
// Address $5A957C
end;

end.
