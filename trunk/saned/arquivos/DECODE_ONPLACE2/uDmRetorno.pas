unit uDmRetorno;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  DBTables;

type
  TdmRetorno = class(TDataModule)
    qryInsere: TQuery;
    qryDesfazer: TQuery;
    qryGeral: TQuery;
    qryAtualiza: TQuery;
    procedure DataModuleCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  dmRetorno: TdmRetorno;

implementation

{$R *.DFM}

procedure TdmRetorno.DataModuleCreate(Sender: TObject);
begin
// Address $5966E8
end;

end.
