unit uFrmLegenda;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, ComCtrls, DBTables;

type
  TfrmLegenda = class(TfrmBaseClient)
    RETexto: TRichEdit;
    qryGeral: TQuery;
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmLegenda: TfrmLegenda;

implementation

{$R *.DFM}

end.
