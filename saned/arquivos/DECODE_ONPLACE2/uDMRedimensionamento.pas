unit uDMRedimensionamento;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  DBTables, RpRave, RpConDS, RpRenderPDF, DB;

type
  TDMRedimensionamento = class(TDataModule)
    qryGeral: TQuery;
    qryGrupo: TQuery;
    qryRoteiro: TQuery;
    qryAgente: TQuery;
    qryAtualizar: TQuery;
    RvPrjRedimensionamento: TRvProject;
    RvDSCRedimensionamento: TRvDataSetConnection;
    RvRenderPDF: TRvRenderPDF;
    qryRoteirort_grupo: TIntegerField;
    qryRoteirort_rota: TIntegerField;
    qryRoteirort_maleta: TIntegerField;
    qryRoteirort_referencia: TDateTimeField;
    qryRoteirort_agente: TIntegerField;
    qryRoteiroag_nome: TStringField;
    qryRoteiroqtde_lig: TIntegerField;
    qryRoteirort_ind_chuva: TStringField;
    qryRoteirort_ordem_inicial: TIntegerField;
    qryRoteirort_ordem_final: TIntegerField;
    qryRoteiroind_grupo: TIntegerField;
    qryRoteiroQtde_Divergencia: TIntegerField;
    qryRoteiroQtde_Lidas: TIntegerField;
    qryRoteiroQtde_Ocorrencias: TIntegerField;
    qryRedimensionamento: TQuery;
    qryRedimensionamentort_grupo: TIntegerField;
    qryRedimensionamentort_rota: TIntegerField;
    qryRedimensionamentort_maleta: TIntegerField;
    qryRedimensionamentort_referencia: TDateTimeField;
    qryRedimensionamentort_agente: TIntegerField;
    qryRedimensionamentoag_nome: TStringField;
    qryRedimensionamentort_ind_chuva: TStringField;
    qryRedimensionamentoqtde_lig: TIntegerField;
    qryRedimensionamentoseq_inicial: TIntegerField;
    qryRedimensionamentoseq_final: TIntegerField;
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  DMRedimensionamento: TDMRedimensionamento;

implementation

{$R *.DFM}

end.
