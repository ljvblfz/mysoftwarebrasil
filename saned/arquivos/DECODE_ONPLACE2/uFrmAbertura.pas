unit uFrmAbertura;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  ExtCtrls;

type
  TfrmAbertura = class(TForm)
    Image1: TImage;
    Timer1: TTimer;
    procedure Timer1Timer;
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmAbertura: TfrmAbertura;

implementation

{$R *.DFM}

procedure TfrmAbertura.Timer1Timer;
begin
// Address $6333D4
end;

end.
