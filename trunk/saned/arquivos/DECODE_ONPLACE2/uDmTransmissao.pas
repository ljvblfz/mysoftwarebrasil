unit uDmTransmissao;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  DBTables;

type
  TdmTransmissao = class(TDataModule)
    qryLogAtendimento: TQuery;
    qryRoteiro: TQuery;
    qryLeitura: TQuery;
    qryDesfazer: TQuery;
    qryGeral: TQuery;
    qryInserirMedicao: TQuery;
    qryDescargaAlteracoes: TQuery;
    qryDataLeitura: TQuery;
    qryDiasConsumo: TQuery;
    qryOcorrencia: TQuery;
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  dmTransmissao: TdmTransmissao;

implementation

{$R *.DFM}

end.
