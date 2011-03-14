unit uDMAnalise;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  DBTables, DB;

type
  TdmAnalise = class(TDataModule)
    qryGeral: TQuery;
    qryGrupoAnaliste: TQuery;
    qryRotaAnaliste: TQuery;
    qryAnalise: TQuery;
    dsAnalise: TDataSource;
    qryCDCAnalise: TQuery;
    qryHistoricoConsumo: TQuery;
    DSHistoricoConsumo: TDataSource;
    qryAnormalidade: TQuery;
    qryHistoricoConsumohc_ref_historico: TDateTimeField;
    qryHistoricoConsumohc_data_leitura: TDateTimeField;
    qryHistoricoConsumohc_leitura: TIntegerField;
    qryHistoricoConsumohc_consumo: TIntegerField;
    qryHistoricoConsumohc_dias_consumo: TIntegerField;
    qryHistoricoConsumohc_ocorrencia_leitura: TStringField;
    qryHistoricoConsumooc_descricao: TStringField;
    qryHistoricoConsumohc_leitura_real: TIntegerField;
    procedure dsAnaliseDataChange(Sender: TObject; Field: TField);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  dmAnalise: TdmAnalise;

implementation

{$R *.DFM}

procedure TdmAnalise.dsAnaliseDataChange(Sender: TObject; Field: TField);
begin
// Address $584FB0
end;

end.
