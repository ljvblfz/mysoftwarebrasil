unit uFrmSobre;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, ExtCtrls, StdCtrls;

type
  TfrmSobre = class(TfrmBaseClient)
    Image1: TImage;
    Shape1: TShape;
    Label2: TLabel;
    LSite: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    Label7: TLabel;
    Shape2: TShape;
    LVersao: TLabel;
    procedure LSiteClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmSobre: TfrmSobre;

implementation

{$R *.DFM}

procedure TfrmSobre.LSiteClick(Sender: TObject);
begin
// Address $5A9BAC
end;

end.
