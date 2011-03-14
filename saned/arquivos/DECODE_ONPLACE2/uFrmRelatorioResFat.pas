unit uFrmRelatorioResFat;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  uFrmBaseClient, ComCtrls, StdCtrls, Buttons, DBTables, DB, DBGrids,
  DBCtrls, Chart, Series;

type
  TfrmRelatorioResFat = class(TfrmBaseClient)
    PageControl: TPageControl;
    tbsPesquisa: TTabSheet;
    GroupBox1: TGroupBox;
    rbtGeral: TRadioButton;
    rbtGrupo: TRadioButton;
    rbtRota: TRadioButton;
    Label1: TLabel;
    Label2: TLabel;
    cmbGrupo: TComboBox;
    cmbReferencia: TComboBox;
    sbtnPesquisar: TSpeedButton;
    qryReferencia: TQuery;
    qryGrupo: TQuery;
    qryPesqGeral: TQuery;
    tbsGeral: TTabSheet;
    GroupBox2: TGroupBox;
    dsPesqGeral: TDataSource;
    DBGridGeral: TDBGrid;
    qryPesqGeralmd_referencia: TDateTimeField;
    qryPesqGeralmd_ligacoes: TIntegerField;
    qryPesqGeralmd_consumo_medido: TIntegerField;
    qryPesqGeralmd_consumo_medido_esg: TIntegerField;
    qryPesqGeralmd_consumo_faturado_res: TIntegerField;
    qryPesqGeralmd_consumo_faturado_res_esg: TIntegerField;
    qryPesqGeralmd_consumo_faturado_com: TIntegerField;
    qryPesqGeralmd_consumo_faturado_com_esg: TIntegerField;
    qryPesqGeralmd_consumo_faturado_ind: TIntegerField;
    qryPesqGeralmd_consumo_faturado_ind_esg: TIntegerField;
    qryPesqGeralmd_consumo_faturado_pub: TIntegerField;
    qryPesqGeralmd_consumo_faturado_pub_esg: TIntegerField;
    qryPesqGeralmd_consumo_faturado_soc: TIntegerField;
    qryPesqGeralmd_consumo_faturado_soc_esg: TIntegerField;
    qryPesqGeralmd_consumo_faturado_ea: TIntegerField;
    qryPesqGeralmd_consumo_faturado_ea_esg: TIntegerField;
    qryPesqGeralmd_valor_agua: TFloatField;
    qryPesqGeralmd_valor_esgoto: TFloatField;
    qryPesqGeralmd_valor_servico: TFloatField;
    qryPesqGeralmd_valor_credito: TFloatField;
    qryPesqGeralmd_valor_devolucao: TFloatField;
    qryPesqGeralmd_valor_importo: TFloatField;
    qryPesqGeralmd_valor_saldo_debito: TFloatField;
    qryPesqGeralmd_valor_total: TFloatField;
    qryPesqGrupo: TQuery;
    dsPesqGrupo: TDataSource;
    qryPesqGrupomd_referencia: TDateTimeField;
    qryPesqGrupomd_grupo: TIntegerField;
    qryPesqGrupomd_ligacoes: TIntegerField;
    qryPesqGrupomd_consumo_medido: TIntegerField;
    qryPesqGrupomd_consumo_medido_esg: TIntegerField;
    qryPesqGrupomd_consumo_faturado_res: TIntegerField;
    qryPesqGrupomd_consumo_faturado_res_esg: TIntegerField;
    qryPesqGrupomd_consumo_faturado_com: TIntegerField;
    qryPesqGrupomd_consumo_faturado_com_esg: TIntegerField;
    qryPesqGrupomd_consumo_faturado_ind: TIntegerField;
    qryPesqGrupomd_consumo_faturado_ind_esg: TIntegerField;
    qryPesqGrupomd_consumo_faturado_pub: TIntegerField;
    qryPesqGrupomd_consumo_faturado_pub_esg: TIntegerField;
    qryPesqGrupomd_consumo_faturado_soc: TIntegerField;
    qryPesqGrupomd_consumo_faturado_soc_esg: TIntegerField;
    qryPesqGrupomd_consumo_faturado_ea: TIntegerField;
    qryPesqGrupomd_consumo_faturado_ea_esg: TIntegerField;
    qryPesqGrupomd_valor_agua: TFloatField;
    qryPesqGrupomd_valor_esgoto: TFloatField;
    qryPesqGrupomd_valor_servico: TFloatField;
    qryPesqGrupomd_valor_credito: TFloatField;
    qryPesqGrupomd_valor_devolucao: TFloatField;
    qryPesqGrupomd_valor_importo: TFloatField;
    qryPesqGrupomd_valor_saldo_debito: TFloatField;
    qryPesqGrupomd_valor_total: TFloatField;
    tbsGrupo: TTabSheet;
    GroupBox3: TGroupBox;
    DBGrid2: TDBGrid;
    Label3: TLabel;
    DBEdGrupo: TDBEdit;
    tbsRota: TTabSheet;
    GroupBox4: TGroupBox;
    Label4: TLabel;
    DBGrid3: TDBGrid;
    DBEdGrupoRota: TDBEdit;
    Label5: TLabel;
    DBEdReferencia: TDBEdit;
    qryPesqRota: TQuery;
    dsPesqRota: TDataSource;
    qryPesqRotamd_referencia: TDateTimeField;
    qryPesqRotamd_grupo: TIntegerField;
    qryPesqRotamd_rota: TIntegerField;
    qryPesqRotamd_ligacoes: TIntegerField;
    qryPesqRotamd_consumo_medido: TIntegerField;
    qryPesqRotamd_consumo_medido_esg: TIntegerField;
    qryPesqRotamd_consumo_faturado_res: TIntegerField;
    qryPesqRotamd_consumo_faturado_res_esg: TIntegerField;
    qryPesqRotamd_consumo_faturado_com: TIntegerField;
    qryPesqRotamd_consumo_faturado_com_esg: TIntegerField;
    qryPesqRotamd_consumo_faturado_ind: TIntegerField;
    qryPesqRotamd_consumo_faturado_ind_esg: TIntegerField;
    qryPesqRotamd_consumo_faturado_pub: TIntegerField;
    qryPesqRotamd_consumo_faturado_pub_esg: TIntegerField;
    qryPesqRotamd_consumo_faturado_soc: TIntegerField;
    qryPesqRotamd_consumo_faturado_soc_esg: TIntegerField;
    qryPesqRotamd_consumo_faturado_ea: TIntegerField;
    qryPesqRotamd_consumo_faturado_ea_esg: TIntegerField;
    qryPesqRotamd_valor_agua: TFloatField;
    qryPesqRotamd_valor_esgoto: TFloatField;
    qryPesqRotamd_valor_servico: TFloatField;
    qryPesqRotamd_valor_credito: TFloatField;
    qryPesqRotamd_valor_devolucao: TFloatField;
    qryPesqRotamd_valor_importo: TFloatField;
    qryPesqRotamd_valor_saldo_debito: TFloatField;
    qryPesqRotamd_valor_total: TFloatField;
    CBGrafico: TCheckBox;
    cmbGraficoGeral: TComboBox;
    ChGraficoGeralLig: TChart;
    Series1: TBarSeries;
    ChGraficoGeralVol: TChart;
    BarSeries1: TBarSeries;
    Series2: TBarSeries;
    ChGraficoGeralVal: TChart;
    BarSeries2: TBarSeries;
    BarSeries3: TBarSeries;
    Series3: TBarSeries;
    procedure CBGraficoClick(Sender: TObject);
    procedure sbtnPesquisarClick(Sender: TObject);
    procedure cmbGrupoDropDown(Sender: TObject);
    procedure cmbReferenciaDropDown(Sender: TObject);
    procedure rbtGeralClick(Sender: TObject);
    procedure FormActivate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmRelatorioResFat: TfrmRelatorioResFat;

implementation

{$R *.DFM}

procedure TfrmRelatorioResFat.CBGraficoClick(Sender: TObject);
begin
// Address $603BE4
end;

procedure TfrmRelatorioResFat.sbtnPesquisarClick(Sender: TObject);
begin
// Address $604084
end;

procedure TfrmRelatorioResFat.cmbGrupoDropDown(Sender: TObject);
begin
// Address $603CC4
end;

procedure TfrmRelatorioResFat.cmbReferenciaDropDown(Sender: TObject);
begin
// Address $603DA8
end;

procedure TfrmRelatorioResFat.rbtGeralClick(Sender: TObject);
begin
// Address $603FA8
end;

procedure TfrmRelatorioResFat.FormActivate(Sender: TObject);
begin
// Address $603EEC
end;

end.
