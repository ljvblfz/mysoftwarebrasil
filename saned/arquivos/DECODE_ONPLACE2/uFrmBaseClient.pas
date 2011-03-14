unit uFrmBaseClient;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  ExtCtrls, StdCtrls, Buttons;

type
  TfrmBaseClient = class(TForm)
    pTop: TPanel;
    lVersion: TLabel;
    pBottom: TPanel;
    sbtnSair: TSpeedButton;
    procedure FormActivate(Sender: TObject);
    procedure sbtnSairClick(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmBaseClient: TfrmBaseClient;

implementation

{$R *.DFM}

procedure TfrmBaseClient.FormActivate(Sender: TObject);
begin
// Address $56AD38
end;

procedure TfrmBaseClient.sbtnSairClick(Sender: TObject);
begin
// Address $56AD30
end;

procedure TfrmBaseClient.FormShow(Sender: TObject);
begin
// Address $56ACAC
end;

procedure TfrmBaseClient.FormClose(Sender: TObject; var Action: TCloseAction);
begin
// Address $56AD48
end;

end.
