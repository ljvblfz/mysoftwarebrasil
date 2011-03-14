unit uDmRecepcao;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  DBTables;

type
  TdmRecepcao = class(TDataModule)
    qryCarga: TQuery;
    qryDebitos: TQuery;
    qryDebitosItens: TQuery;
    qryDescontos: TQuery;
    qryHistoricoConsumo: TQuery;
    qryImpostos: TQuery;
    qryAgentes: TQuery;
    qryMensagens: TQuery;
    qryOcorrencias: TQuery;
    qryRoteiros: TQuery;
    qrySegundasVias: TQuery;
    qryServicos: TQuery;
    qryTarifas: TQuery;
    qryQualidadeAgua: TQuery;
    qryGeral: TQuery;
    qryDesfazer: TQuery;
    qryValida: TQuery;
    qryValidaRegistro: TQuery;
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  dmRecepcao: TdmRecepcao;

implementation

{$R *.DFM}

end.
