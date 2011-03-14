unit uDmCarga;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  DBTables, DB;

type
  TdmCarga = class(TDataModule)
    qryRegistroT: TQuery;
    qryRegistroI: TQuery;
    qryRegistroIlinha: TStringField;
    qryRegistroQ: TQuery;
    qryRegistro2: TQuery;
    qryRegistro4: TQuery;
    qryRegistroD: TQuery;
    qryRegistro5: TQuery;
    qryRegistro7: TQuery;
    qryRegistro1: TQuery;
    qryRegistro9: TQuery;
    qryRegistro9linha: TStringField;
    qryGeral: TQuery;
    qryRegistroL: TQuery;
    qryRegistroTtr_data_inicial: TDateTimeField;
    qryRegistroTtr_categoria: TIntegerField;
    qryRegistroTlinha: TMemoField;
    DSRegistro2: TDataSource;
    qryRegistroDmatricula: TIntegerField;
    qryRegistroDlinha: TMemoField;
    qryRegistro4matricula: TIntegerField;
    qryRegistro4linha: TMemoField;
    qryRegistroR: TQuery;
    qryRegistroQlinha: TStringField;
    qryRegistro2matricula: TIntegerField;
    qryRegistro2referencia: TDateTimeField;
    qryRegistro2grupo: TIntegerField;
    qryRegistro5matricula: TIntegerField;
    qryRegistro5linha: TMemoField;
    qryRegistro1total: TIntegerField;
    qryRegistro1linha: TStringField;
    qryRegistro2Ant: TQuery;
    qryRegistro2Antmatricula: TIntegerField;
    qryRegistro2Antreferencia: TDateTimeField;
    qryRegistro2Antgrupo: TIntegerField;
    qryRegistro2Antsequencia: TIntegerField;
    qryRegistro2Antemite_conta: TStringField;
    qryRegistro2Antbusca_dados: TIntegerField;
    qryRegistro2Antlinha: TMemoField;
    qryRegistro2sequencia: TIntegerField;
    qryRegistro2emite_conta: TStringField;
    qryRegistro2busca_dados: TIntegerField;
    qryRegistro2linha: TMemoField;
    qryRegistro7linha: TStringField;
    qryRegistroLlinha: TStringField;
    qryRegistroRlinha: TStringField;
    procedure DataModuleCreate(Sender: TObject);
    procedure DSRegistro2DataChange(Sender: TObject; Field: TField);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  dmCarga: TdmCarga;

implementation

{$R *.DFM}

procedure TdmCarga.DataModuleCreate(Sender: TObject);
begin
// Address $57EF24
end;

procedure TdmCarga.DSRegistro2DataChange(Sender: TObject; Field: TField);
begin
// Address $57D664
end;

end.
