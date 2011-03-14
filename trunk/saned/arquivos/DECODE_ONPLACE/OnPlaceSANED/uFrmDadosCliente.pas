unit uFrmDadosCliente;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics,
  Controls, Forms, Dialogs, StdCtrls
type
  TfrmDadosCliente=class(TForm)
    GroupBox1: TGroupBox;
    PSelecao: TPanel;
    Shape1: TShape;
    Label1: TLabel;
    Label2: TLabel;
    Label4: TLabel;
    cmbGrupo: TComboBox;
    cmbRota: TComboBox;
    DBNavigador: TDBNavigator;
    EdMatricula: TEdit;
    EdSequencia: TEdit;
    Label3: TLabel;
    sbtPesquisa: TSpeedButton;
    qryGrupo: TQuery;
    qryRoteiro: TQuery;
    GroupBox3: TGroupBox;
    DBGrid1: TDBGrid;
    qryPrincipal: TQuery;
    qryCDC: TQuery;
    DSPrincipal: TDataSource;
    DSCDC: TDataSource;
    qryHistorico: TQuery;
    DSHistorico: TDataSource;
    qryHistoricohc_ref_historico: TDateTimeField;
    qryHistoricohc_consumo: TIntegerField;
    qryHistoricohc_leitura: TIntegerField;
    qryHistoricohc_ocorrencia_leitura: TStringField;
    qryHistoricohc_dias_consumo: TIntegerField;
    qryHistoricohc_data_leitura: TDateTimeField;
    PCMatricula: TPageControl;
    tbsDados: TTabSheet;
    tbsHistorico: TTabSheet;
    tbsServico: TTabSheet;
    GroupBox2: TGroupBox;
    Label15: TLabel;
    DBTConsumoMedio: TDBText;
    DBGrid2: TDBGrid;
    GroupBox4: TGroupBox;
    DBTNome: TDBText;
    DBTEndereco: TDBText;
    DBTComplemento: TDBText;
    DBTCategoria: TDBText;
    DBTIdentificar: TDBText;
    DBTNatureza: TDBText;
    Label5: TLabel;
    DBTGrupo: TDBText;
    Label6: TLabel;
    DBTRota: TDBText;
    Label7: TLabel;
    DBTSequencia: TDBText;
    DBTHidrometro: TDBText;
    DBTCapacidadeHD: TDBText;
    Label8: TLabel;
    DBTInscricao: TDBText;
    Label9: TLabel;
    DBTEcoRes: TDBText;
    DBTEcoSoc: TDBText;
    Label12: TLabel;
    Label10: TLabel;
    DBTEcoInd: TDBText;
    DBTEcoCom: TDBText;
    Label11: TLabel;
    Label13: TLabel;
    DBTEcoPub: TDBText;
    DBTEcoEA: TDBText;
    Label14: TLabel;
    Bevel1: TBevel;
    Label16: TLabel;
    DBTReferencia: TDBText;
    Bevel2: TBevel;
    qryServico: TQuery;
    DSServico: TDataSource;
    GroupBox5: TGroupBox;
    DBGrid3: TDBGrid;
    qryServicosr_matricula: TIntegerField;
    qryServicosr_sequencia: TIntegerField;
    qryServicosr_descricao: TStringField;
    qryServicosr_valor: TFloatField;
    qryServicooperador: TStringField;
    qryServicototal_credito: TFloatField;
    qryServicototal_debito: TFloatField;
    Label17: TLabel;
    DBTTotalDebito: TDBText;
    Label18: TLabel;
    DBTTotalCredito: TDBText;
    Label19: TLabel;
    DBTSetor: TDBText;
    GroupBox7: TGroupBox;
    DBTDescBloqueio: TDBText;
    Label25: TLabel;
    DBTDataBloqueio: TDBText;
    Label26: TLabel;
    DBTDataDesbloqueio: TDBText;
    Label24: TLabel;
    Label27: TLabel;
    Label28: TLabel;
    Bevel3: TBevel;
    DBTDiasBloqAnt: TDBText;
    DBTDiasBloqAtual: TDBText;
    Label29: TLabel [0];
    DBText1: TDBText [1];
    qryDocumentos: TQuery;
    DSDocumentos: TDataSource;
    tbsDocumento: TTabSheet;
    GroupBox9: TGroupBox;
    DBGrid4: TDBGrid;
    qryDocumentosDocumento: TStringField;
    qryDocumentosTexto: TStringField;
    qryDocumentosData_Vencimento: TDateTimeField;
    qryDocumentosValor_Total: TFloatField;
    qryDescarga: TQuery;
    DSDescarga: TDataSource;
    tbsDescarga: TTabSheet;
    GroupBox10: TGroupBox;
    tbsValores: TTabSheet;
    tbsAdicional: TTabSheet;
    GroupBox8: TGroupBox;
    Bevel4: TBevel;
    Label23: TLabel;
    DBTVencimento: TDBText;
    Label30: TLabel;
    DBTFlagTroca: TDBText;
    Label31: TLabel;
    DBTLeituraInicial: TDBText;
    DBTDataInstHD: TDBText;
    Label32: TLabel;
    Label33: TLabel;
    DBText2: TDBText;
    Label34: TLabel;
    DBText3: TDBText;
    Label35: TLabel;
    DBText4: TDBText;
    Label36: TLabel;
    DBTDescDesconto: TDBText;
    Label37: TLabel;
    DBTLimite: TDBText;
    Label38: TLabel;
    DBTPercDesc: TDBText;
    Label39: TLabel;
    Label40: TLabel;
    Label41: TLabel;
    Label42: TLabel;
    DBText6: TDBText;
    DBText7: TDBText;
    DBText8: TDBText;
    GroupBox6: TGroupBox;
    Label20: TLabel;
    DBTEnderecoAlternativo: TDBText;
    Label21: TLabel;
    DBTBanco: TDBText;
    Label22: TLabel;
    DBTAgencia: TDBText;
    Label43: TLabel;
    DBTDataLeit: TDBText;
    Label45: TLabel;
    DBTLeituraReal: TDBText;
    Label46: TLabel;
    DBTOcorrencia: TDBText;
    GroupBox11: TGroupBox;
    Label44: TLabel;
    DBTDataLeitAnt: TDBText;
    Label47: TLabel;
    DBTLeituraAnt: TDBText;
    Label48: TLabel;
    DBTOcorrenciaAnt: TDBText;
    Label49: TLabel;
    DBTDiasConsumo: TDBText;
    DBTOcorrenciaDesc: TDBText;
    Label50: TLabel;
    DBTLeituraAjustada: TDBText;
    GroupBox12: TGroupBox;
    Label51: TLabel;
    Label53: TLabel;
    Label54: TLabel;
    Label52: TLabel;
    Label55: TLabel;
    DBText5: TDBText;
    DBText9: TDBText;
    DBText10: TDBText;
    DBText11: TDBText;
    DBText12: TDBText;
    DBText13: TDBText;
    Label56: TLabel;
    DBText14: TDBText;
    DBText15: TDBText;
    Label57: TLabel;
    DBText16: TDBText;
    DBText17: TDBText;
    Label58: TLabel;
    DBText18: TDBText;
    DBText19: TDBText;
    Label60: TLabel;
    DBText21: TDBText;
    Label61: TLabel;
    DBText22: TDBText;
    DBText23: TDBText;
    GroupBox13: TGroupBox;
    Label62: TLabel;
    DBText24: TDBText;
    DBText25: TDBText;
    Label63: TLabel;
    Label64: TLabel;
    DBText26: TDBText;
    DBText27: TDBText;
    Label65: TLabel;
    Label66: TLabel;
    DBText28: TDBText;
    Label67: TLabel;
    Bevel5: TBevel;
    Bevel6: TBevel;
    Label68: TLabel;
    Label69: TLabel;
    DBText30: TDBText;
    DBText31: TDBText;
    DBText32: TDBText;
    Label70: TLabel;
    Label71: TLabel;
    DBText33: TDBText;
    Label72: TLabel;
    DBText34: TDBText;
    Label73: TLabel;
    DBText35: TDBText;
    Label74: TLabel;
    DBText36: TDBText;
    Bevel7: TBevel;
    Label75: TLabel;
    Label76: TLabel;
    DBText37: TDBText;
    Label77: TLabel;
    DBText38: TDBText;
    DBText29: TDBText;
    DBText39: TDBText;
    DBText40: TDBText;
    DBText41: TDBText;
    DBText42: TDBText;
    DBText43: TDBText;
    DBText44: TDBText;
    Label78: TLabel;
    Label79: TLabel;
    Label80: TLabel;
    Label81: TLabel;
    EdCodigoBarras: TEdit;
    qryParametros: TQuery;
    qryParametrosNATUREZA: TStringField;
    qryParametrosEMPRESA: TStringField;
    qryParametrosDIRETORIO: TStringField;
    qryDescargadg_data_leitura: TDateTimeField;
    qryDescargadg_dias_consumo: TIntegerField;
    qryDescargadg_ocorrencia: TIntegerField;
    qryDescargaoc_descricao: TStringField;
    qryDescargadg_forma_entrega: TIntegerField;
    qryDescargadesc_forma_entrega: TStringField;
    qryDescargadg_leitura_real: TIntegerField;
    qryDescargadg_leitura_ajustada: TIntegerField;
    qryDescargadg_consumo_medido: TIntegerField;
    qryDescargadg_consumo_ajustado: TIntegerField;
    qryDescargadg_consumo_rateado: TIntegerField;
    qryDescargadg_consumo_medido_esg: TIntegerField;
    qryDescargadg_consumo_ajustado_esg: TIntegerField;
    qryDescargadg_consumo_rateado_esg: TIntegerField;
    qryDescargadg_agente: TIntegerField;
    qryDescargaag_nome: TStringField;
    qryDescargadg_leitura_agente: TIntegerField;
    qryDescargadesc_leitura_agente: TStringField;
    qryDescargadg_motivo_nao_faturamento: TIntegerField;
    qryDescargadesc_motivo_nao_faturamento: TStringField;
    qryDescargadg_status: TIntegerField;
    qryDescargadesc_status: TStringField;
    qryDescargadg_consumo_faturado_res: TIntegerField;
    qryDescargadg_consumo_faturado_com: TIntegerField;
    qryDescargadg_consumo_faturado_ind: TIntegerField;
    qryDescargadg_consumo_faturado_pub: TIntegerField;
    qryDescargadg_consumo_faturado_soc: TIntegerField;
    qryDescargadg_consumo_faturado_ea: TIntegerField;
    qryDescargadg_consumo_faturado_esg_res: TIntegerField;
    qryDescargadg_consumo_faturado_esg_com: TIntegerField;
    qryDescargadg_consumo_faturado_esg_ind: TIntegerField;
    qryDescargadg_consumo_faturado_esg_pub: TIntegerField;
    qryDescargadg_consumo_faturado_esg_soc: TIntegerField;
    qryDescargadg_consumo_faturado_esg_ea: TIntegerField;
    qryDescargadg_valor_agua: TFloatField;
    qryDescargadg_valor_esgoto: TFloatField;
    qryDescargadg_valor_servico: TFloatField;
    qryDescargadg_valor_credito: TFloatField;
    qryDescargadg_valor_devolucao: TFloatField;
    qryDescargadg_valor_imposto: TFloatField;
    qryDescargadg_valor_saldo_debito: TFloatField;
    qryDescargadg_valor_saldo_credito: TFloatField;
    qryDescargadg_valor_total: TFloatField;
    qryDescargadg_flag_fraude: TStringField;
    qryCDCcg_matricula: TIntegerField;
    qryCDCcg_matricula_pai: TIntegerField;
    qryCDCcg_sequencia: TIntegerField;
    qryCDCdesc_tipo_cdc: TStringField;
    qryCDCendereco: TStringField;
    qryCDCcg_endereco: TStringField;
    qryCDCcg_num_imovel: TStringField;
    qryCDCcg_complemento: TStringField;
    qryCDCcg_inscricao: TStringField;
    qryCDCcg_nome: TStringField;
    qryCDCcg_grupo: TIntegerField;
    qryCDCcg_rota: TIntegerField;
    qryCDCcg_setor: TIntegerField;
    qryCDCcg_qtde_debito_ant: TIntegerField;
    qryCDCcg_numero_hd: TStringField;
    qryCDCcg_capacidade_hidrometro: TIntegerField;
    qryCDCcg_consumo_medio: TIntegerField;
    qryCDCcg_economia_res: TIntegerField;
    qryCDCcg_economia_com: TIntegerField;
    qryCDCcg_economia_ind: TIntegerField;
    qryCDCcg_economia_pub: TIntegerField;
    qryCDCcg_economia_soc: TIntegerField;
    qryCDCcg_economia_ea: TIntegerField;
    qryCDCcg_categoria: TIntegerField;
    qryCDCdescricao_categoria: TStringField;
    qryCDCcg_data_vencto: TDateTimeField;
    qryCDCcg_referencia: TDateTimeField;
    qryCDCcg_codigo_banco: TIntegerField;
    qryCDCcg_agencia: TIntegerField;
    qryCDCcg_flag_troca: TStringField;
    qryCDCcg_leitura_inicial: TIntegerField;
    qryCDCcg_data_instalacao_hd: TDateTimeField;
    qryCDCcg_natureza_ligacao: TIntegerField;
    qryCDCdescricao_natureza_ligacao: TStringField;
    qryCDCcg_bloqueado: TStringField;
    qryCDCdesc_bloqueado: TStringField;
    qryCDCcg_desconto: TIntegerField;
    qryCDCde_percentual: TFloatField;
    qryCDCde_limite_inicial: TIntegerField;
    qryCDCde_tipo_desconto: TIntegerField;
    qryCDCdesc_tipo_desconto: TStringField;
    qryCDCcg_ident_consumidor: TIntegerField;
    qryCDCdescricao_ident_consumidor: TStringField;
    qryCDCcg_flag_emite_conta: TStringField;
    qryCDCcg_flag_calcula_imposto: TStringField;
    qryCDCcg_entrega_alternativa: TStringField;
    qryCDCcg_flag_calcula_conta: TStringField;
    qryCDCcg_dias_bloqueio_tarifa_ant: TIntegerField;
    qryCDCcg_dias_bloqueio_tarifa_atual: TIntegerField;
    qryCDCcg_virtual: TStringField;
    qryCDCcg_data_bloqueio: TDateTimeField;
    qryCDCcg_data_desbloqueio: TDateTimeField;
    qryCDCcg_cachorro: TStringField;
    qryCDCcg_qtde_registros_fraude: TIntegerField;
    qryCDCcg_flag_cortar: TStringField;
    qryCDCcg_leitura_ant: TIntegerField;
    qryCDCcg_ocorrencia_ant: TIntegerField;
    qryCDCcg_data_leit_ant: TDateTimeField;
    qryCDCcg_consumo_anterior: TIntegerField;
    Label59: TLabel;
    DBText20: TDBText;
    qryDescargadg_flag_lido: TStringField;
    qryDescargadg_flag_faturado: TStringField;
    Label82: TLabel;
    DBText45: TDBText;
    Label83: TLabel;
    DBText46: TDBText;
    DBText47: TDBText;
    qryDescargadg_vias: TIntegerField;
    qryDescargadesc_vias: TStringField;
    qryHistoricohc_leitura_real: TIntegerField;
    DBText48: TDBText;
    Label84: TLabel;
    DBText49: TDBText;
    DBText50: TDBText;
    qryDescargadg_flag_emitida: TStringField;
    qryDescargadesc_flag_emitida: TStringField;
    DBTOcorrencia2: TDBText;
    DBText51: TDBText;
    qryDescargaOcorrencia2: TIntegerField;
    qryDescargaDesc_Ocorrencia2: TStringField;
    Label85: TLabel;
    DBText52: TDBText;
    OFFS_0954: N.A.;
    OFFS_0955: N.A.;
    OFFS_0956: N.A.;
    procedure EdMatriculaKeyPress(Sender : TObject);
    procedure cmbGrupoChange(Sender : TObject);
    procedure EdCodigoBarrasChange(Sender : TObject);
    procedure DSCDCDataChange(Sender : TObject);
    procedure cmbRotaChange(Sender : TObject);
    procedure EdMatriculaChange(Sender : TObject);
    procedure EdSequenciaChange(Sender : TObject);
    procedure DSPrincipalDataChange(Sender : TObject);
    procedure sbtPesquisaClick(Sender : TObject);
    procedure cmbRotaDropDown(Sender : TObject);
    procedure cmbGrupoDropDown(Sender : TObject);
    procedure FormActivate(Sender : TObject);
    procedure _PROC_005DA327(Sender : TObject);
    procedure _PROC_005DA9CF(Sender : TObject);
    procedure _PROC_005DAB44(Sender : TObject);
    procedure _PROC_005DB832(Sender : TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end ;

var
  frmDadosCliente: TfrmDadosCliente;

{This file is generated by DeDe Ver 3.50.04 Copyright (c) 1999-2002 DaFixer}

implementation

{$R *.DFM}

procedure TfrmDadosCliente.EdMatriculaKeyPress(Sender : TObject);
begin
(*
005DAAE8   80390D                 cmp     byte ptr [ecx], $0D
005DAAEB   7505                   jnz     005DAAF2

* Reference to : TfrmDadosCliente.sbtPesquisaClick()
|
005DAAED   E8D6000000             call    005DABC8
005DAAF2   C3                     ret

*)
end;

procedure TfrmDadosCliente.cmbGrupoChange(Sender : TObject);
begin
(*
005DA218   53                     push    ebx
005DA219   8BD8                   mov     ebx, eax

* Reference to field TfrmDadosCliente.OFFS_0954 : Byte
|
005DA21B   80BB5409000000         cmp     byte ptr [ebx+$0954], $00
005DA222   7529                   jnz     005DA24D

* Reference to field TfrmDadosCliente.OFFS_0954 : Byte
|
005DA224   C6835409000000         mov     byte ptr [ebx+$0954], $00

* Reference to field TfrmDadosCliente.OFFS_0955 : Byte
|
005DA22B   C6835509000001         mov     byte ptr [ebx+$0955], $01
005DA232   33D2                   xor     edx, edx

* Reference to control TfrmDadosCliente.EdCodigoBarras : TEdit
|
005DA234   8B8344070000           mov     eax, [ebx+$0744]

|
005DA23A   E8F158E8FF             call    0045FB30
005DA23F   8BC3                   mov     eax, ebx

|
005DA241   E81AFFFFFF             call    005DA160

* Reference to field TfrmDadosCliente.OFFS_0955 : Byte
|
005DA246   C6835509000000         mov     byte ptr [ebx+$0955], $00
005DA24D   5B                     pop     ebx
005DA24E   C3                     ret

*)
end;

procedure TfrmDadosCliente.EdCodigoBarrasChange(Sender : TObject);
begin
(*
005DAA48   53                     push    ebx
005DAA49   8BD8                   mov     ebx, eax

* Reference to field TfrmDadosCliente.OFFS_0955 : Byte
|
005DAA4B   80BB5509000000         cmp     byte ptr [ebx+$0955], $00
005DAA52   7558                   jnz     005DAAAC

* Reference to field TfrmDadosCliente.OFFS_0954 : Byte
|
005DAA54   C6835409000001         mov     byte ptr [ebx+$0954], $01

* Reference to field TfrmDadosCliente.OFFS_0955 : Byte
|
005DAA5B   C6835509000000         mov     byte ptr [ebx+$0955], $00
005DAA62   83CAFF                 or      edx, -$01

* Reference to control TfrmDadosCliente.cmbGrupo : TComboBox
|
005DAA65   8B8398030000           mov     eax, [ebx+$0398]
005DAA6B   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E0
|
005DAA6D   FF91E0000000           call    dword ptr [ecx+$00E0]
005DAA73   83CAFF                 or      edx, -$01

* Reference to control TfrmDadosCliente.cmbRota : TComboBox
|
005DAA76   8B839C030000           mov     eax, [ebx+$039C]
005DAA7C   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E0
|
005DAA7E   FF91E0000000           call    dword ptr [ecx+$00E0]
005DAA84   33D2                   xor     edx, edx

* Reference to control TfrmDadosCliente.EdMatricula : TEdit
|
005DAA86   8B83A4030000           mov     eax, [ebx+$03A4]

|
005DAA8C   E89F50E8FF             call    0045FB30
005DAA91   33D2                   xor     edx, edx

* Reference to control TfrmDadosCliente.EdSequencia : TEdit
|
005DAA93   8B83A8030000           mov     eax, [ebx+$03A8]

|
005DAA99   E89250E8FF             call    0045FB30
005DAA9E   8BC3                   mov     eax, ebx

|
005DAAA0   E8BBF6FFFF             call    005DA160

* Reference to field TfrmDadosCliente.OFFS_0954 : Byte
|
005DAAA5   C6835409000000         mov     byte ptr [ebx+$0954], $00
005DAAAC   5B                     pop     ebx
005DAAAD   C3                     ret

*)
end;

procedure TfrmDadosCliente.DSCDCDataChange(Sender : TObject);
begin
(*
005DA4F8   53                     push    ebx
005DA4F9   56                     push    esi
005DA4FA   8BF0                   mov     esi, eax

* Reference to control TfrmDadosCliente.qryCDC : TQuery
|
005DA4FC   8B86C8030000           mov     eax, [esi+$03C8]

|
005DA502   E89541ECFF             call    0049E69C
005DA507   84C0                   test    al, al
005DA509   0F84CB020000           jz      005DA7DA
005DA50F   B301                   mov     bl, $01

* Reference to field TfrmDadosCliente.OFFS_0956 : Byte
|
005DA511   80BE5609000000         cmp     byte ptr [esi+$0956], $00
005DA518   743B                   jz      005DA555
005DA51A   BAE4A75D00             mov     edx, $005DA7E4

* Reference to control TfrmDadosCliente.qryCDC : TQuery
|
005DA51F   8B86C8030000           mov     eax, [esi+$03C8]

|
005DA525   E80E53ECFF             call    0049F838
005DA52A   8B10                   mov     edx, [eax]

* Possible reference to virtual method TQuery.OFFS_50
|
005DA52C   FF5250                 call    dword ptr [edx+$50]
005DA52F   DC9E60090000           fcomp   qword ptr [esi+$0960]
005DA535   9B                     wait
005DA536   DFE0                   fstsw   ax
005DA538   9E                     sahf
005DA539   0F95C3                 setnz   bl
005DA53C   84DB                   test    bl, bl
005DA53E   7515                   jnz     005DA555
005DA540   6A00                   push    $00
005DA542   0FB70D00A85D00         movzx   ecx, word ptr [$005DA800]
005DA549   B202                   mov     dl, $02

* Possible String Reference to: 'A referência do código de barras é 
|                                diferente da referência atual.Náo s
|                                erão apresentados os dados referent
|                                es a Histórico, Serviços, Documento
|                                , Leituras e Valores.'
|
005DA54B   B80CA85D00             mov     eax, $005DA80C

|
005DA550   E85366E7FF             call    00450BA8
005DA555   84DB                   test    bl, bl
005DA557   0F847D020000           jz      005DA7DA
005DA55D   8BD3                   mov     edx, ebx

* Reference to control TfrmDadosCliente.tbsHistorico : TTabSheet
|
005DA55F   8B86FC030000           mov     eax, [esi+$03FC]

* Reference to : TTabStrings._PROC_004C6FB0()
|
005DA565   E846CAEEFF             call    004C6FB0
005DA56A   8BD3                   mov     edx, ebx

* Reference to control TfrmDadosCliente.tbsServico : TTabSheet
|
005DA56C   8B8600040000           mov     eax, [esi+$0400]

* Reference to : TTabStrings._PROC_004C6FB0()
|
005DA572   E839CAEEFF             call    004C6FB0
005DA577   8BD3                   mov     edx, ebx

* Reference to control TfrmDadosCliente.tbsDocumento : TTabSheet
|
005DA579   8B861C050000           mov     eax, [esi+$051C]

* Reference to : TTabStrings._PROC_004C6FB0()
|
005DA57F   E82CCAEEFF             call    004C6FB0
005DA584   8BD3                   mov     edx, ebx

* Reference to control TfrmDadosCliente.tbsDescarga : TTabSheet
|
005DA586   8B8640050000           mov     eax, [esi+$0540]

* Reference to : TTabStrings._PROC_004C6FB0()
|
005DA58C   E81FCAEEFF             call    004C6FB0
005DA591   8BD3                   mov     edx, ebx

* Reference to control TfrmDadosCliente.tbsValores : TTabSheet
|
005DA593   8B8648050000           mov     eax, [esi+$0548]

* Reference to : TTabStrings._PROC_004C6FB0()
|
005DA599   E812CAEEFF             call    004C6FB0

* Reference to control TfrmDadosCliente.qryHistorico : TQuery
|
005DA59E   8B86D4030000           mov     eax, [esi+$03D4]

|
005DA5A4   E8673FECFF             call    0049E510
005DA5A9   BAB4A85D00             mov     edx, $005DA8B4

* Reference to control TfrmDadosCliente.qryCDC : TQuery
|
005DA5AE   8B86C8030000           mov     eax, [esi+$03C8]

|
005DA5B4   E87F52ECFF             call    0049F838
005DA5B9   8B10                   mov     edx, [eax]

* Possible reference to virtual method TQuery.OFFS_58
|
005DA5BB   FF5258                 call    dword ptr [edx+$58]
005DA5BE   50                     push    eax

* Possible String Reference to: 'nGrupo'
|
005DA5BF   BAD0A85D00             mov     edx, $005DA8D0

* Reference to control TfrmDadosCliente.qryHistorico : TQuery
|
005DA5C4   8B86D4030000           mov     eax, [esi+$03D4]

|
005DA5CA   E8B103EEFF             call    004BA980
005DA5CF   5A                     pop     edx

|
005DA5D0   E81731ECFF             call    0049D6EC
005DA5D5   BADCA85D00             mov     edx, $005DA8DC

* Reference to control TfrmDadosCliente.qryCDC : TQuery
|
005DA5DA   8B86C8030000           mov     eax, [esi+$03C8]

|
005DA5E0   E85352ECFF             call    0049F838
005DA5E5   8B10                   mov     edx, [eax]

* Possible reference to virtual method TQuery.OFFS_58
|
005DA5E7   FF5258                 call    dword ptr [edx+$58]
005DA5EA   50                     push    eax

* Possible String Reference to: 'nMatricula'
|
005DA5EB   BA00A95D00             mov     edx, $005DA900

* Reference to control TfrmDadosCliente.qryHistorico : TQuery
|
005DA5F0   8B86D4030000           mov     eax, [esi+$03D4]

|
005DA5F6   E88503EEFF             call    004BA980
005DA5FB   5A                     pop     edx

|
005DA5FC   E8EB30ECFF             call    0049D6EC

* Reference to control TfrmDadosCliente.qryHistorico : TQuery
|
005DA601   8B86D4030000           mov     eax, [esi+$03D4]

|
005DA607   E8F03EECFF             call    0049E4FC

* Reference to control TfrmDadosCliente.qryServico : TQuery
|
005DA60C   8B8698040000           mov     eax, [esi+$0498]

|
005DA612   E8F93EECFF             call    0049E510
005DA617   BAB4A85D00             mov     edx, $005DA8B4

* Reference to control TfrmDadosCliente.qryCDC : TQuery
|
005DA61C   8B86C8030000           mov     eax, [esi+$03C8]

|
005DA622   E81152ECFF             call    0049F838
005DA627   8B10                   mov     edx, [eax]

* Possible reference to virtual method TQuery.OFFS_58
|
005DA629   FF5258                 call    dword ptr [edx+$58]
005DA62C   50                     push    eax

* Possible String Reference to: 'nGrupo'
|
005DA62D   BAD0A85D00             mov     edx, $005DA8D0

* Reference to control TfrmDadosCliente.qryServico : TQuery
|
005DA632   8B8698040000           mov     eax, [esi+$0498]

|
005DA638   E84303EEFF             call    004BA980
005DA63D   5A                     pop     edx

|
005DA63E   E8A930ECFF             call    0049D6EC
005DA643   BA10A95D00             mov     edx, $005DA910

* Reference to control TfrmDadosCliente.qryCDC : TQuery
|
005DA648   8B86C8030000           mov     eax, [esi+$03C8]

|
005DA64E   E8E551ECFF             call    0049F838
005DA653   8B10                   mov     edx, [eax]

* Possible reference to virtual method TQuery.OFFS_58
|
005DA655   FF5258                 call    dword ptr [edx+$58]
005DA658   50                     push    eax

* Possible String Reference to: 'nRota'
|
005DA659   BA28A95D00             mov     edx, $005DA928

* Reference to control TfrmDadosCliente.qryServico : TQuery
|
005DA65E   8B8698040000           mov     eax, [esi+$0498]

|
005DA664   E81703EEFF             call    004BA980
005DA669   5A                     pop     edx

|
005DA66A   E87D30ECFF             call    0049D6EC
005DA66F   BADCA85D00             mov     edx, $005DA8DC

* Reference to control TfrmDadosCliente.qryCDC : TQuery
|
005DA674   8B86C8030000           mov     eax, [esi+$03C8]

|
005DA67A   E8B951ECFF             call    0049F838
005DA67F   8B10                   mov     edx, [eax]

* Possible reference to virtual method TQuery.OFFS_58
|
005DA681   FF5258                 call    dword ptr [edx+$58]
005DA684   50                     push    eax

* Possible String Reference to: 'nMatricula'
|
005DA685   BA00A95D00             mov     edx, $005DA900

* Reference to control TfrmDadosCliente.qryServico : TQuery
|
005DA68A   8B8698040000           mov     eax, [esi+$0498]

|
005DA690   E8EB02EEFF             call    004BA980
005DA695   5A                     pop     edx

|
005DA696   E85130ECFF             call    0049D6EC

* Reference to control TfrmDadosCliente.qryServico : TQuery
|
005DA69B   8B8698040000           mov     eax, [esi+$0498]

|
005DA6A1   E8563EECFF             call    0049E4FC

* Reference to control TfrmDadosCliente.qryDocumentos : TQuery
|
005DA6A6   8B8614050000           mov     eax, [esi+$0514]

|
005DA6AC   E85F3EECFF             call    0049E510
005DA6B1   BAB4A85D00             mov     edx, $005DA8B4

* Reference to control TfrmDadosCliente.qryCDC : TQuery
|
005DA6B6   8B86C8030000           mov     eax, [esi+$03C8]

|
005DA6BC   E87751ECFF             call    0049F838
005DA6C1   8B10                   mov     edx, [eax]

* Possible reference to virtual method TQuery.OFFS_58
|
005DA6C3   FF5258                 call    dword ptr [edx+$58]
005DA6C6   50                     push    eax

* Possible String Reference to: 'nGrupo'
|
005DA6C7   BAD0A85D00             mov     edx, $005DA8D0

* Reference to control TfrmDadosCliente.qryDocumentos : TQuery
|
005DA6CC   8B8614050000           mov     eax, [esi+$0514]

|
005DA6D2   E8A902EEFF             call    004BA980
005DA6D7   5A                     pop     edx

|
005DA6D8   E80F30ECFF             call    0049D6EC
005DA6DD   BA10A95D00             mov     edx, $005DA910

* Reference to control TfrmDadosCliente.qryCDC : TQuery
|
005DA6E2   8B86C8030000           mov     eax, [esi+$03C8]

|
005DA6E8   E84B51ECFF             call    0049F838
005DA6ED   8B10                   mov     edx, [eax]

* Possible reference to virtual method TQuery.OFFS_58
|
005DA6EF   FF5258                 call    dword ptr [edx+$58]
005DA6F2   50                     push    eax

* Possible String Reference to: 'nRota'
|
005DA6F3   BA28A95D00             mov     edx, $005DA928

* Reference to control TfrmDadosCliente.qryDocumentos : TQuery
|
005DA6F8   8B8614050000           mov     eax, [esi+$0514]

|
005DA6FE   E87D02EEFF             call    004BA980
005DA703   5A                     pop     edx

|
005DA704   E8E32FECFF             call    0049D6EC
005DA709   BADCA85D00             mov     edx, $005DA8DC

* Reference to control TfrmDadosCliente.qryCDC : TQuery
|
005DA70E   8B86C8030000           mov     eax, [esi+$03C8]

|
005DA714   E81F51ECFF             call    0049F838
005DA719   8B10                   mov     edx, [eax]

* Possible reference to virtual method TQuery.OFFS_58
|
005DA71B   FF5258                 call    dword ptr [edx+$58]
005DA71E   50                     push    eax

* Possible String Reference to: 'nMatricula'
|
005DA71F   BA00A95D00             mov     edx, $005DA900

* Reference to control TfrmDadosCliente.qryDocumentos : TQuery
|
005DA724   8B8614050000           mov     eax, [esi+$0514]

|
005DA72A   E85102EEFF             call    004BA980
005DA72F   5A                     pop     edx

|
005DA730   E8B72FECFF             call    0049D6EC

* Reference to control TfrmDadosCliente.qryDocumentos : TQuery
|
005DA735   8B8614050000           mov     eax, [esi+$0514]

|
005DA73B   E8BC3DECFF             call    0049E4FC

* Reference to control TfrmDadosCliente.qryDescarga : TQuery
|
005DA740   8B8638050000           mov     eax, [esi+$0538]

|
005DA746   E8C53DECFF             call    0049E510
005DA74B   BAB4A85D00             mov     edx, $005DA8B4

* Reference to control TfrmDadosCliente.qryCDC : TQuery
|
005DA750   8B86C8030000           mov     eax, [esi+$03C8]

|
005DA756   E8DD50ECFF             call    0049F838
005DA75B   8B10                   mov     edx, [eax]

* Possible reference to virtual method TQuery.OFFS_58
|
005DA75D   FF5258                 call    dword ptr [edx+$58]
005DA760   50                     push    eax

* Possible String Reference to: 'nGrupo'
|
005DA761   BAD0A85D00             mov     edx, $005DA8D0

* Reference to control TfrmDadosCliente.qryDescarga : TQuery
|
005DA766   8B8638050000           mov     eax, [esi+$0538]

|
005DA76C   E80F02EEFF             call    004BA980
005DA771   5A                     pop     edx

|
005DA772   E8752FECFF             call    0049D6EC
005DA777   BA10A95D00             mov     edx, $005DA910

* Reference to control TfrmDadosCliente.qryCDC : TQuery
|
005DA77C   8B86C8030000           mov     eax, [esi+$03C8]

|
005DA782   E8B150ECFF             call    0049F838
005DA787   8B10                   mov     edx, [eax]

* Possible reference to virtual method TQuery.OFFS_58
|
005DA789   FF5258                 call    dword ptr [edx+$58]
005DA78C   50                     push    eax

* Possible String Reference to: 'nRota'
|
005DA78D   BA28A95D00             mov     edx, $005DA928

* Reference to control TfrmDadosCliente.qryDescarga : TQuery
|
005DA792   8B8638050000           mov     eax, [esi+$0538]

|
005DA798   E8E301EEFF             call    004BA980
005DA79D   5A                     pop     edx

|
005DA79E   E8492FECFF             call    0049D6EC
005DA7A3   BADCA85D00             mov     edx, $005DA8DC

* Reference to control TfrmDadosCliente.qryCDC : TQuery
|
005DA7A8   8B86C8030000           mov     eax, [esi+$03C8]

|
005DA7AE   E88550ECFF             call    0049F838
005DA7B3   8B10                   mov     edx, [eax]

* Possible reference to virtual method TQuery.OFFS_58
|
005DA7B5   FF5258                 call    dword ptr [edx+$58]
005DA7B8   50                     push    eax

* Possible String Reference to: 'nMatricula'
|
005DA7B9   BA00A95D00             mov     edx, $005DA900

* Reference to control TfrmDadosCliente.qryDescarga : TQuery
|
005DA7BE   8B8638050000           mov     eax, [esi+$0538]

|
005DA7C4   E8B701EEFF             call    004BA980
005DA7C9   5A                     pop     edx

|
005DA7CA   E81D2FECFF             call    0049D6EC

* Reference to control TfrmDadosCliente.qryDescarga : TQuery
|
005DA7CF   8B8638050000           mov     eax, [esi+$0538]

|
005DA7D5   E8223DECFF             call    0049E4FC
005DA7DA   5E                     pop     esi
005DA7DB   5B                     pop     ebx
005DA7DC   C3                     ret

*)
end;

procedure TfrmDadosCliente.cmbRotaChange(Sender : TObject);
begin
(*
005DA340   53                     push    ebx
005DA341   8BD8                   mov     ebx, eax

* Reference to field TfrmDadosCliente.OFFS_0954 : Byte
|
005DA343   80BB5409000000         cmp     byte ptr [ebx+$0954], $00
005DA34A   7529                   jnz     005DA375

* Reference to field TfrmDadosCliente.OFFS_0954 : Byte
|
005DA34C   C6835409000000         mov     byte ptr [ebx+$0954], $00

* Reference to field TfrmDadosCliente.OFFS_0955 : Byte
|
005DA353   C6835509000001         mov     byte ptr [ebx+$0955], $01
005DA35A   33D2                   xor     edx, edx

* Reference to control TfrmDadosCliente.EdCodigoBarras : TEdit
|
005DA35C   8B8344070000           mov     eax, [ebx+$0744]

|
005DA362   E8C957E8FF             call    0045FB30
005DA367   8BC3                   mov     eax, ebx

|
005DA369   E8F2FDFFFF             call    005DA160

* Reference to field TfrmDadosCliente.OFFS_0955 : Byte
|
005DA36E   C6835509000000         mov     byte ptr [ebx+$0955], $00
005DA375   5B                     pop     ebx
005DA376   C3                     ret

*)
end;

procedure TfrmDadosCliente.EdMatriculaChange(Sender : TObject);
begin
(*
005DAAB0   53                     push    ebx
005DAAB1   8BD8                   mov     ebx, eax

* Reference to field TfrmDadosCliente.OFFS_0954 : Byte
|
005DAAB3   80BB5409000000         cmp     byte ptr [ebx+$0954], $00
005DAABA   7529                   jnz     005DAAE5

* Reference to field TfrmDadosCliente.OFFS_0954 : Byte
|
005DAABC   C6835409000000         mov     byte ptr [ebx+$0954], $00

* Reference to field TfrmDadosCliente.OFFS_0955 : Byte
|
005DAAC3   C6835509000001         mov     byte ptr [ebx+$0955], $01
005DAACA   33D2                   xor     edx, edx

* Reference to control TfrmDadosCliente.EdCodigoBarras : TEdit
|
005DAACC   8B8344070000           mov     eax, [ebx+$0744]

|
005DAAD2   E85950E8FF             call    0045FB30
005DAAD7   8BC3                   mov     eax, ebx

|
005DAAD9   E882F6FFFF             call    005DA160

* Reference to field TfrmDadosCliente.OFFS_0955 : Byte
|
005DAADE   C6835509000000         mov     byte ptr [ebx+$0955], $00
005DAAE5   5B                     pop     ebx
005DAAE6   C3                     ret

*)
end;

procedure TfrmDadosCliente.EdSequenciaChange(Sender : TObject);
begin
(*
005DAAF4   53                     push    ebx
005DAAF5   8BD8                   mov     ebx, eax

* Reference to field TfrmDadosCliente.OFFS_0954 : Byte
|
005DAAF7   80BB5409000000         cmp     byte ptr [ebx+$0954], $00
005DAAFE   7529                   jnz     005DAB29

* Reference to field TfrmDadosCliente.OFFS_0954 : Byte
|
005DAB00   C6835409000000         mov     byte ptr [ebx+$0954], $00

* Reference to field TfrmDadosCliente.OFFS_0955 : Byte
|
005DAB07   C6835509000001         mov     byte ptr [ebx+$0955], $01
005DAB0E   33D2                   xor     edx, edx

* Reference to control TfrmDadosCliente.EdCodigoBarras : TEdit
|
005DAB10   8B8344070000           mov     eax, [ebx+$0744]

|
005DAB16   E81550E8FF             call    0045FB30
005DAB1B   8BC3                   mov     eax, ebx

|
005DAB1D   E83EF6FFFF             call    005DA160

* Reference to field TfrmDadosCliente.OFFS_0955 : Byte
|
005DAB22   C6835509000000         mov     byte ptr [ebx+$0955], $00
005DAB29   5B                     pop     ebx
005DAB2A   C3                     ret

*)
end;

procedure TfrmDadosCliente.DSPrincipalDataChange(Sender : TObject);
begin
(*
005DA930   53                     push    ebx
005DA931   8BD8                   mov     ebx, eax

* Reference to control TfrmDadosCliente.qryCDC : TQuery
|
005DA933   8B83C8030000           mov     eax, [ebx+$03C8]

|
005DA939   E8D23BECFF             call    0049E510
005DA93E   BAD4A95D00             mov     edx, $005DA9D4

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DA943   8B83C4030000           mov     eax, [ebx+$03C4]

|
005DA949   E8EA4EECFF             call    0049F838
005DA94E   8B10                   mov     edx, [eax]

* Possible reference to virtual method TQuery.OFFS_58
|
005DA950   FF5258                 call    dword ptr [edx+$58]
005DA953   50                     push    eax

* Possible String Reference to: 'nGrupo'
|
005DA954   BAF0A95D00             mov     edx, $005DA9F0

* Reference to control TfrmDadosCliente.qryCDC : TQuery
|
005DA959   8B83C8030000           mov     eax, [ebx+$03C8]

|
005DA95F   E81C00EEFF             call    004BA980
005DA964   5A                     pop     edx

|
005DA965   E8822DECFF             call    0049D6EC
005DA96A   BAFCA95D00             mov     edx, $005DA9FC

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DA96F   8B83C4030000           mov     eax, [ebx+$03C4]

|
005DA975   E8BE4EECFF             call    0049F838
005DA97A   8B10                   mov     edx, [eax]

* Possible reference to virtual method TQuery.OFFS_58
|
005DA97C   FF5258                 call    dword ptr [edx+$58]
005DA97F   50                     push    eax

* Possible String Reference to: 'nRota'
|
005DA980   BA14AA5D00             mov     edx, $005DAA14

* Reference to control TfrmDadosCliente.qryCDC : TQuery
|
005DA985   8B83C8030000           mov     eax, [ebx+$03C8]

|
005DA98B   E8F0FFEDFF             call    004BA980
005DA990   5A                     pop     edx

|
005DA991   E8562DECFF             call    0049D6EC
005DA996   BA20AA5D00             mov     edx, $005DAA20

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DA99B   8B83C4030000           mov     eax, [ebx+$03C4]

|
005DA9A1   E8924EECFF             call    0049F838
005DA9A6   8B10                   mov     edx, [eax]

* Possible reference to virtual method TQuery.OFFS_58
|
005DA9A8   FF5258                 call    dword ptr [edx+$58]
005DA9AB   50                     push    eax

* Possible String Reference to: 'nMatricula'
|
005DA9AC   BA3CAA5D00             mov     edx, $005DAA3C

* Reference to control TfrmDadosCliente.qryCDC : TQuery
|
005DA9B1   8B83C8030000           mov     eax, [ebx+$03C8]

|
005DA9B7   E8C4FFEDFF             call    004BA980
005DA9BC   5A                     pop     edx

|
005DA9BD   E82A2DECFF             call    0049D6EC

* Reference to control TfrmDadosCliente.qryCDC : TQuery
|
005DA9C2   8B83C8030000           mov     eax, [ebx+$03C8]

|
005DA9C8   E82F3BECFF             call    0049E4FC
005DA9CD   5B                     pop     ebx
005DA9CE   C3                     ret

*)
end;

procedure TfrmDadosCliente.sbtPesquisaClick(Sender : TObject);
begin
(*
005DABC8   55                     push    ebp
005DABC9   8BEC                   mov     ebp, esp
005DABCB   B914000000             mov     ecx, $00000014
005DABD0   6A00                   push    $00
005DABD2   6A00                   push    $00
005DABD4   49                     dec     ecx
005DABD5   75F9                   jnz     005DABD0
005DABD7   51                     push    ecx
005DABD8   53                     push    ebx
005DABD9   56                     push    esi
005DABDA   8BD8                   mov     ebx, eax
005DABDC   33C0                   xor     eax, eax
005DABDE   55                     push    ebp
005DABDF   68B5B35D00             push    $005DB3B5

***** TRY
|
005DABE4   64FF30                 push    dword ptr fs:[eax]
005DABE7   648920                 mov     fs:[eax], esp
005DABEA   8D55F0                 lea     edx, [ebp-$10]

* Reference to control TfrmDadosCliente.EdMatricula : TEdit
|
005DABED   8BB3A4030000           mov     esi, [ebx+$03A4]
005DABF3   8BC6                   mov     eax, esi

|
005DABF5   E8064FE8FF             call    0045FB00
005DABFA   8B45F0                 mov     eax, [ebp-$10]
005DABFD   8D55F4                 lea     edx, [ebp-$0C]

|
005DAC00   E84FFDE2FF             call    0040A954
005DAC05   8B55F4                 mov     edx, [ebp-$0C]
005DAC08   8BC6                   mov     eax, esi

|
005DAC0A   E8214FE8FF             call    0045FB30
005DAC0F   8BC3                   mov     eax, ebx

|
005DAC11   E84AF5FFFF             call    005DA160
005DAC16   8D55E8                 lea     edx, [ebp-$18]

* Reference to control TfrmDadosCliente.cmbGrupo : TComboBox
|
005DAC19   8B8398030000           mov     eax, [ebx+$0398]

|
005DAC1F   E8DC4EE8FF             call    0045FB00
005DAC24   8B45E8                 mov     eax, [ebp-$18]
005DAC27   8D55EC                 lea     edx, [ebp-$14]

|
005DAC2A   E825FDE2FF             call    0040A954
005DAC2F   837DEC00               cmp     dword ptr [ebp-$14], +$00
005DAC33   7555                   jnz     005DAC8A
005DAC35   8D55E4                 lea     edx, [ebp-$1C]

* Reference to control TfrmDadosCliente.EdMatricula : TEdit
|
005DAC38   8B83A4030000           mov     eax, [ebx+$03A4]

|
005DAC3E   E8BD4EE8FF             call    0045FB00
005DAC43   8B45E4                 mov     eax, [ebp-$1C]
005DAC46   33D2                   xor     edx, edx

|
005DAC48   E83306E3FF             call    0040B280
005DAC4D   85C0                   test    eax, eax
005DAC4F   7F39                   jnle    005DAC8A
005DAC51   8D55DC                 lea     edx, [ebp-$24]

* Reference to control TfrmDadosCliente.EdCodigoBarras : TEdit
|
005DAC54   8B8344070000           mov     eax, [ebx+$0744]

|
005DAC5A   E8A14EE8FF             call    0045FB00
005DAC5F   8B45DC                 mov     eax, [ebp-$24]
005DAC62   8D55E0                 lea     edx, [ebp-$20]

|
005DAC65   E8EAFCE2FF             call    0040A954
005DAC6A   837DE000               cmp     dword ptr [ebp-$20], +$00
005DAC6E   751A                   jnz     005DAC8A
005DAC70   6A00                   push    $00
005DAC72   0FB70DC8B35D00         movzx   ecx, word ptr [$005DB3C8]
005DAC79   B202                   mov     dl, $02

* Possible String Reference to: 'Selecionar o grupo e/ou informar o 
|                                CDC ou o código de barras.'
|
005DAC7B   B8D4B35D00             mov     eax, $005DB3D4

|
005DAC80   E8235FE7FF             call    00450BA8
005DAC85   E946060000             jmp     005DB2D0
005DAC8A   8D55D4                 lea     edx, [ebp-$2C]

* Reference to control TfrmDadosCliente.EdCodigoBarras : TEdit
|
005DAC8D   8B8344070000           mov     eax, [ebx+$0744]

|
005DAC93   E8684EE8FF             call    0045FB00
005DAC98   8B45D4                 mov     eax, [ebp-$2C]
005DAC9B   8D55D8                 lea     edx, [ebp-$28]

|
005DAC9E   E8B1FCE2FF             call    0040A954
005DACA3   837DD800               cmp     dword ptr [ebp-$28], +$00
005DACA7   0F8418020000           jz      005DAEC5
005DACAD   8D55D0                 lea     edx, [ebp-$30]

* Reference to control TfrmDadosCliente.EdCodigoBarras : TEdit
|
005DACB0   8B8344070000           mov     eax, [ebx+$0744]

|
005DACB6   E8454EE8FF             call    0045FB00
005DACBB   8B45D0                 mov     eax, [ebp-$30]
005DACBE   8D55FC                 lea     edx, [ebp-$04]

|
005DACC1   E88EFCE2FF             call    0040A954
005DACC6   8B45FC                 mov     eax, [ebp-$04]
005DACC9   85C0                   test    eax, eax
005DACCB   7405                   jz      005DACD2
005DACCD   83E804                 sub     eax, +$04
005DACD0   8B00                   mov     eax, [eax]
005DACD2   83F830                 cmp     eax, +$30
005DACD5   7571                   jnz     005DAD48
005DACD7   8D45CC                 lea     eax, [ebp-$34]
005DACDA   50                     push    eax
005DACDB   B90B000000             mov     ecx, $0000000B
005DACE0   BA01000000             mov     edx, $00000001
005DACE5   8B45FC                 mov     eax, [ebp-$04]

|
005DACE8   E8DBB0E2FF             call    00405DC8
005DACED   FF75CC                 push    dword ptr [ebp-$34]
005DACF0   8D45C8                 lea     eax, [ebp-$38]
005DACF3   50                     push    eax
005DACF4   B90B000000             mov     ecx, $0000000B
005DACF9   BA0D000000             mov     edx, $0000000D
005DACFE   8B45FC                 mov     eax, [ebp-$04]

|
005DAD01   E8C2B0E2FF             call    00405DC8
005DAD06   FF75C8                 push    dword ptr [ebp-$38]
005DAD09   8D45C4                 lea     eax, [ebp-$3C]
005DAD0C   50                     push    eax
005DAD0D   B90B000000             mov     ecx, $0000000B
005DAD12   BA19000000             mov     edx, $00000019
005DAD17   8B45FC                 mov     eax, [ebp-$04]

|
005DAD1A   E8A9B0E2FF             call    00405DC8
005DAD1F   FF75C4                 push    dword ptr [ebp-$3C]
005DAD22   8D45C0                 lea     eax, [ebp-$40]
005DAD25   50                     push    eax
005DAD26   B90B000000             mov     ecx, $0000000B
005DAD2B   BA25000000             mov     edx, $00000025
005DAD30   8B45FC                 mov     eax, [ebp-$04]

|
005DAD33   E890B0E2FF             call    00405DC8
005DAD38   FF75C0                 push    dword ptr [ebp-$40]
005DAD3B   8D45FC                 lea     eax, [ebp-$04]
005DAD3E   BA04000000             mov     edx, $00000004

|
005DAD43   E8E0AEE2FF             call    00405C28
005DAD48   8B45FC                 mov     eax, [ebp-$04]
005DAD4B   85C0                   test    eax, eax
005DAD4D   7405                   jz      005DAD54
005DAD4F   83E804                 sub     eax, +$04
005DAD52   8B00                   mov     eax, [eax]
005DAD54   83F82C                 cmp     eax, +$2C
005DAD57   741A                   jz      005DAD73
005DAD59   6A00                   push    $00
005DAD5B   0FB70DC8B35D00         movzx   ecx, word ptr [$005DB3C8]
005DAD62   B202                   mov     dl, $02

* Possible String Reference to: 'Tamanho do código de barras inválid
|                                o.'
|
005DAD64   B81CB45D00             mov     eax, $005DB41C

|
005DAD69   E83A5EE7FF             call    00450BA8
005DAD6E   E95D050000             jmp     005DB2D0
005DAD73   8D45BC                 lea     eax, [ebp-$44]
005DAD76   50                     push    eax
005DAD77   B92C000000             mov     ecx, $0000002C
005DAD7C   BA05000000             mov     edx, $00000005
005DAD81   8B45FC                 mov     eax, [ebp-$04]

|
005DAD84   E83FB0E2FF             call    00405DC8
005DAD89   8B45BC                 mov     eax, [ebp-$44]
005DAD8C   50                     push    eax
005DAD8D   8D45B8                 lea     eax, [ebp-$48]
005DAD90   50                     push    eax
005DAD91   B903000000             mov     ecx, $00000003
005DAD96   BA01000000             mov     edx, $00000001
005DAD9B   8B45FC                 mov     eax, [ebp-$04]

|
005DAD9E   E825B0E2FF             call    00405DC8
005DADA3   8B55B8                 mov     edx, [ebp-$48]
005DADA6   8D45F8                 lea     eax, [ebp-$08]
005DADA9   59                     pop     ecx

|
005DADAA   E805AEE2FF             call    00405BB4
005DADAF   8D45B4                 lea     eax, [ebp-$4C]
005DADB2   50                     push    eax
005DADB3   B901000000             mov     ecx, $00000001
005DADB8   BA04000000             mov     edx, $00000004
005DADBD   8B45FC                 mov     eax, [ebp-$04]

|
005DADC0   E803B0E2FF             call    00405DC8
005DADC5   8B45B4                 mov     eax, [ebp-$4C]
005DADC8   83CAFF                 or      edx, -$01

|
005DADCB   E8B004E3FF             call    0040B280
005DADD0   8BF0                   mov     esi, eax
005DADD2   8B45F8                 mov     eax, [ebp-$08]

|
005DADD5   E87E0CF9FF             call    0056BA58
005DADDA   3BF0                   cmp     esi, eax
005DADDC   741A                   jz      005DADF8
005DADDE   6A00                   push    $00
005DADE0   0FB70DC8B35D00         movzx   ecx, word ptr [$005DB3C8]
005DADE7   B202                   mov     dl, $02

* Possible String Reference to: 'Código de barras inválido. Dígito v
|                                erificador inconsistente.'
|
005DADE9   B84CB45D00             mov     eax, $005DB44C

|
005DADEE   E8B55DE7FF             call    00450BA8
005DADF3   E9D8040000             jmp     005DB2D0

* Reference to field TfrmDadosCliente.OFFS_0958
|
005DADF8   8D8358090000           lea     eax, [ebx+$0958]
005DADFE   50                     push    eax
005DADFF   B904000000             mov     ecx, $00000004
005DAE04   BA10000000             mov     edx, $00000010
005DAE09   8B45FC                 mov     eax, [ebp-$04]

|
005DAE0C   E8B7AFE2FF             call    00405DC8

* Reference to control TfrmDadosCliente.qryParametros : TQuery
|
005DAE11   8B8348070000           mov     eax, [ebx+$0748]

|
005DAE17   E8F436ECFF             call    0049E510

* Reference to control TfrmDadosCliente.qryParametros : TQuery
|
005DAE1C   8B8348070000           mov     eax, [ebx+$0748]

|
005DAE22   E8D536ECFF             call    0049E4FC
005DAE27   BA90B45D00             mov     edx, $005DB490

* Reference to control TfrmDadosCliente.qryParametros : TQuery
|
005DAE2C   8B8348070000           mov     eax, [ebx+$0748]

|
005DAE32   E8014AECFF             call    0049F838
005DAE37   8D55B0                 lea     edx, [ebp-$50]
005DAE3A   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TQuery.OFFS_60
|
005DAE3C   FF5160                 call    dword ptr [ecx+$60]
005DAE3F   8B55B0                 mov     edx, [ebp-$50]

* Reference to field TfrmDadosCliente.OFFS_0958
|
005DAE42   8B8358090000           mov     eax, [ebx+$0958]

|
005DAE48   E867AEE2FF             call    00405CB4
005DAE4D   741A                   jz      005DAE69
005DAE4F   6A00                   push    $00
005DAE51   0FB70DC8B35D00         movzx   ecx, word ptr [$005DB3C8]
005DAE58   B202                   mov     dl, $02

* Possible String Reference to: 'Empresa do código de barras inválid
|                                a.'
|
005DAE5A   B8A8B45D00             mov     eax, $005DB4A8

|
005DAE5F   E8445DE7FF             call    00450BA8
005DAE64   E967040000             jmp     005DB2D0
005DAE69   8D45AC                 lea     eax, [ebp-$54]
005DAE6C   50                     push    eax
005DAE6D   B902000000             mov     ecx, $00000002
005DAE72   BA1D000000             mov     edx, $0000001D
005DAE77   8B45FC                 mov     eax, [ebp-$04]

|
005DAE7A   E849AFE2FF             call    00405DC8
005DAE7F   8B45AC                 mov     eax, [ebp-$54]
005DAE82   BA01000000             mov     edx, $00000001

|
005DAE87   E8F403E3FF             call    0040B280
005DAE8C   50                     push    eax
005DAE8D   8D45A8                 lea     eax, [ebp-$58]
005DAE90   50                     push    eax
005DAE91   B904000000             mov     ecx, $00000004
005DAE96   BA1F000000             mov     edx, $0000001F
005DAE9B   8B45FC                 mov     eax, [ebp-$04]

|
005DAE9E   E825AFE2FF             call    00405DC8
005DAEA3   8B45A8                 mov     eax, [ebp-$58]
005DAEA6   33D2                   xor     edx, edx

|
005DAEA8   E8D303E3FF             call    0040B280
005DAEAD   66B90100               mov     cx, $0001
005DAEB1   5A                     pop     edx

|
005DAEB2   E8A931E3FF             call    0040E060
005DAEB7   DD9B60090000           fstp    qword ptr [ebx+$0960]
005DAEBD   9B                     wait

* Reference to field TfrmDadosCliente.OFFS_0956 : Byte
|
005DAEBE   C6835609000001         mov     byte ptr [ebx+$0956], $01

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DAEC5   8B83C4030000           mov     eax, [ebx+$03C4]

|
005DAECB   E84036ECFF             call    0049E510

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DAED0   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DAED6   8B8048020000           mov     eax, [eax+$0248]
005DAEDC   8B10                   mov     edx, [eax]
005DAEDE   FF5244                 call    dword ptr [edx+$44]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DAEE1   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DAEE7   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'select cg_grupo,'
|
005DAEED   BAD8B45D00             mov     edx, $005DB4D8
005DAEF2   8B08                   mov     ecx, [eax]
005DAEF4   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DAEF7   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DAEFD   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       cg_rota,'
|
005DAF03   BAF4B45D00             mov     edx, $005DB4F4
005DAF08   8B08                   mov     ecx, [eax]
005DAF0A   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DAF0D   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DAF13   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       cg_referencia,'
|
005DAF19   BA0CB55D00             mov     edx, $005DB50C
005DAF1E   8B08                   mov     ecx, [eax]
005DAF20   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DAF23   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DAF29   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       case when cg_matricula_pai =
|                                 0'
|
005DAF2F   BA2CB55D00             mov     edx, $005DB52C
005DAF34   8B08                   mov     ecx, [eax]
005DAF36   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DAF39   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DAF3F   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '            then cg_matricula'
|
005DAF45   BA5CB55D00             mov     edx, $005DB55C
005DAF4A   8B08                   mov     ecx, [eax]
005DAF4C   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DAF4F   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DAF55   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '            else cg_matricula_pai'
|
005DAF5B   BA84B55D00             mov     edx, $005DB584
005DAF60   8B08                   mov     ecx, [eax]
005DAF62   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DAF65   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DAF6B   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       end  as matricula,'
|
005DAF71   BAB0B55D00             mov     edx, $005DB5B0
005DAF76   8B08                   mov     ecx, [eax]
005DAF78   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DAF7B   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DAF81   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       min(cg_sequencia) as cg_sequ
|                                encia'
|
005DAF87   BAD4B55D00             mov     edx, $005DB5D4
005DAF8C   8B08                   mov     ecx, [eax]
005DAF8E   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DAF91   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DAF97   8B8048020000           mov     eax, [eax+$0248]
005DAF9D   BA08B65D00             mov     edx, $005DB608
005DAFA2   8B08                   mov     ecx, [eax]
005DAFA4   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DAFA7   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DAFAD   8B8048020000           mov     eax, [eax+$0248]
005DAFB3   BA1CB65D00             mov     edx, $005DB61C
005DAFB8   8B08                   mov     ecx, [eax]
005DAFBA   FF5138                 call    dword ptr [ecx+$38]

* Reference to field TfrmDadosCliente.OFFS_0956 : Byte
|
005DAFBD   80BB5609000000         cmp     byte ptr [ebx+$0956], $00
005DAFC4   0F8488000000           jz      005DB052

* Reference to control TfrmDadosCliente.cmbGrupo : TComboBox
|
005DAFCA   8B8398030000           mov     eax, [ebx+$0398]
005DAFD0   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
005DAFD2   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmDadosCliente.cmbRota : TComboBox
|
005DAFD8   8B839C030000           mov     eax, [ebx+$039C]
005DAFDE   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
005DAFE0   FF92E8000000           call    dword ptr [edx+$00E8]
005DAFE6   33D2                   xor     edx, edx

* Reference to control TfrmDadosCliente.EdMatricula : TEdit
|
005DAFE8   8B83A4030000           mov     eax, [ebx+$03A4]

|
005DAFEE   E83D4BE8FF             call    0045FB30
005DAFF3   8B55FC                 mov     edx, [ebp-$04]

* Reference to control TfrmDadosCliente.EdCodigoBarras : TEdit
|
005DAFF6   8B8344070000           mov     eax, [ebx+$0744]

|
005DAFFC   E82F4BE8FF             call    0045FB30
005DB001   8D459C                 lea     eax, [ebp-$64]
005DB004   50                     push    eax
005DB005   B906000000             mov     ecx, $00000006
005DB00A   BA17000000             mov     edx, $00000017
005DB00F   8B45FC                 mov     eax, [ebp-$04]

|
005DB012   E8B1ADE2FF             call    00405DC8
005DB017   8B459C                 mov     eax, [ebp-$64]
005DB01A   33D2                   xor     edx, edx

|
005DB01C   E85F02E3FF             call    0040B280
005DB021   8D55A0                 lea     edx, [ebp-$60]

|
005DB024   E8CBFFE2FF             call    0040AFF4
005DB029   8B4DA0                 mov     ecx, [ebp-$60]
005DB02C   8D45A4                 lea     eax, [ebp-$5C]

* Possible String Reference to: 'and cg_matricula = '
|
005DB02F   BA44B65D00             mov     edx, $005DB644

|
005DB034   E87BABE2FF             call    00405BB4
005DB039   8B55A4                 mov     edx, [ebp-$5C]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DB03C   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DB042   8B8048020000           mov     eax, [eax+$0248]
005DB048   8B08                   mov     ecx, [eax]
005DB04A   FF5138                 call    dword ptr [ecx+$38]
005DB04D   E99F010000             jmp     005DB1F1
005DB052   8D5594                 lea     edx, [ebp-$6C]

* Reference to control TfrmDadosCliente.cmbGrupo : TComboBox
|
005DB055   8B8398030000           mov     eax, [ebx+$0398]

|
005DB05B   E8A04AE8FF             call    0045FB00
005DB060   8B4594                 mov     eax, [ebp-$6C]
005DB063   8D5598                 lea     edx, [ebp-$68]

|
005DB066   E8E9F8E2FF             call    0040A954
005DB06B   837D9800               cmp     dword ptr [ebp-$68], +$00
005DB06F   0F8403010000           jz      005DB178
005DB075   8D558C                 lea     edx, [ebp-$74]

* Reference to control TfrmDadosCliente.cmbGrupo : TComboBox
|
005DB078   8B8398030000           mov     eax, [ebx+$0398]

|
005DB07E   E87D4AE8FF             call    0045FB00
005DB083   8B4D8C                 mov     ecx, [ebp-$74]
005DB086   8D4590                 lea     eax, [ebp-$70]

* Possible String Reference to: 'and cg_grupo = '
|
005DB089   BA60B65D00             mov     edx, $005DB660

|
005DB08E   E821ABE2FF             call    00405BB4
005DB093   8B5590                 mov     edx, [ebp-$70]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DB096   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DB09C   8B8048020000           mov     eax, [eax+$0248]
005DB0A2   8B08                   mov     ecx, [eax]
005DB0A4   FF5138                 call    dword ptr [ecx+$38]
005DB0A7   8D5584                 lea     edx, [ebp-$7C]

* Reference to control TfrmDadosCliente.cmbRota : TComboBox
|
005DB0AA   8B839C030000           mov     eax, [ebx+$039C]

|
005DB0B0   E84B4AE8FF             call    0045FB00
005DB0B5   8B4584                 mov     eax, [ebp-$7C]
005DB0B8   8D5588                 lea     edx, [ebp-$78]

|
005DB0BB   E894F8E2FF             call    0040A954
005DB0C0   837D8800               cmp     dword ptr [ebp-$78], +$00
005DB0C4   7438                   jz      005DB0FE
005DB0C6   8D957CFFFFFF           lea     edx, [ebp+$FFFFFF7C]

* Reference to control TfrmDadosCliente.cmbRota : TComboBox
|
005DB0CC   8B839C030000           mov     eax, [ebx+$039C]

|
005DB0D2   E8294AE8FF             call    0045FB00
005DB0D7   8B8D7CFFFFFF           mov     ecx, [ebp+$FFFFFF7C]
005DB0DD   8D4580                 lea     eax, [ebp-$80]

* Possible String Reference to: 'and cg_rota = '
|
005DB0E0   BA78B65D00             mov     edx, $005DB678

|
005DB0E5   E8CAAAE2FF             call    00405BB4
005DB0EA   8B5580                 mov     edx, [ebp-$80]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DB0ED   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DB0F3   8B8048020000           mov     eax, [eax+$0248]
005DB0F9   8B08                   mov     ecx, [eax]
005DB0FB   FF5138                 call    dword ptr [ecx+$38]
005DB0FE   8D9578FFFFFF           lea     edx, [ebp+$FFFFFF78]

* Reference to control TfrmDadosCliente.EdSequencia : TEdit
|
005DB104   8B83A8030000           mov     eax, [ebx+$03A8]

|
005DB10A   E8F149E8FF             call    0045FB00
005DB10F   8B8578FFFFFF           mov     eax, [ebp+$FFFFFF78]
005DB115   83CAFF                 or      edx, -$01

|
005DB118   E86301E3FF             call    0040B280
005DB11D   85C0                   test    eax, eax
005DB11F   7C57                   jl      005DB178
005DB121   8D956CFFFFFF           lea     edx, [ebp+$FFFFFF6C]

* Reference to control TfrmDadosCliente.EdSequencia : TEdit
|
005DB127   8B83A8030000           mov     eax, [ebx+$03A8]

|
005DB12D   E8CE49E8FF             call    0045FB00
005DB132   8B856CFFFFFF           mov     eax, [ebp+$FFFFFF6C]
005DB138   83CAFF                 or      edx, -$01

|
005DB13B   E84001E3FF             call    0040B280
005DB140   8D9570FFFFFF           lea     edx, [ebp+$FFFFFF70]

|
005DB146   E8A9FEE2FF             call    0040AFF4
005DB14B   8B8D70FFFFFF           mov     ecx, [ebp+$FFFFFF70]
005DB151   8D8574FFFFFF           lea     eax, [ebp+$FFFFFF74]

* Possible String Reference to: 'and cg_sequencia = '
|
005DB157   BA90B65D00             mov     edx, $005DB690

|
005DB15C   E853AAE2FF             call    00405BB4
005DB161   8B9574FFFFFF           mov     edx, [ebp+$FFFFFF74]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DB167   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DB16D   8B8048020000           mov     eax, [eax+$0248]
005DB173   8B08                   mov     ecx, [eax]
005DB175   FF5138                 call    dword ptr [ecx+$38]
005DB178   8D9568FFFFFF           lea     edx, [ebp+$FFFFFF68]

* Reference to control TfrmDadosCliente.EdMatricula : TEdit
|
005DB17E   8B83A4030000           mov     eax, [ebx+$03A4]

|
005DB184   E87749E8FF             call    0045FB00
005DB189   8B8568FFFFFF           mov     eax, [ebp+$FFFFFF68]
005DB18F   33D2                   xor     edx, edx

|
005DB191   E8EA00E3FF             call    0040B280
005DB196   85C0                   test    eax, eax
005DB198   7E57                   jle     005DB1F1
005DB19A   8D955CFFFFFF           lea     edx, [ebp+$FFFFFF5C]

* Reference to control TfrmDadosCliente.EdMatricula : TEdit
|
005DB1A0   8B83A4030000           mov     eax, [ebx+$03A4]

|
005DB1A6   E85549E8FF             call    0045FB00
005DB1AB   8B855CFFFFFF           mov     eax, [ebp+$FFFFFF5C]
005DB1B1   83CAFF                 or      edx, -$01

|
005DB1B4   E8C700E3FF             call    0040B280
005DB1B9   8D9560FFFFFF           lea     edx, [ebp+$FFFFFF60]

|
005DB1BF   E830FEE2FF             call    0040AFF4
005DB1C4   8B8D60FFFFFF           mov     ecx, [ebp+$FFFFFF60]
005DB1CA   8D8564FFFFFF           lea     eax, [ebp+$FFFFFF64]

* Possible String Reference to: 'and cg_matricula = '
|
005DB1D0   BA44B65D00             mov     edx, $005DB644

|
005DB1D5   E8DAA9E2FF             call    00405BB4
005DB1DA   8B9564FFFFFF           mov     edx, [ebp+$FFFFFF64]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DB1E0   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DB1E6   8B8048020000           mov     eax, [eax+$0248]
005DB1EC   8B08                   mov     ecx, [eax]
005DB1EE   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DB1F1   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DB1F7   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'group by cg_grupo,'
|
005DB1FD   BAACB65D00             mov     edx, $005DB6AC
005DB202   8B08                   mov     ecx, [eax]
005DB204   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DB207   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DB20D   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '         cg_rota,'
|
005DB213   BAC8B65D00             mov     edx, $005DB6C8
005DB218   8B08                   mov     ecx, [eax]
005DB21A   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DB21D   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DB223   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '         cg_referencia,'
|
005DB229   BAE4B65D00             mov     edx, $005DB6E4
005DB22E   8B08                   mov     ecx, [eax]
005DB230   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DB233   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DB239   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '         case when cg_matricula_pai
|                                 = 0'
|
005DB23F   BA04B75D00             mov     edx, $005DB704
005DB244   8B08                   mov     ecx, [eax]
005DB246   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DB249   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DB24F   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '              then cg_matricula'
|
005DB255   BA34B75D00             mov     edx, $005DB734
005DB25A   8B08                   mov     ecx, [eax]
005DB25C   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DB25F   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DB265   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '              else cg_matricula_pai'
|
005DB26B   BA5CB75D00             mov     edx, $005DB75C
005DB270   8B08                   mov     ecx, [eax]
005DB272   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DB275   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DB27B   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '         end'
|
005DB281   BA88B75D00             mov     edx, $005DB788
005DB286   8B08                   mov     ecx, [eax]
005DB288   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DB28B   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_0248
|
005DB291   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'order by cg_sequencia'
|
005DB297   BAA0B75D00             mov     edx, $005DB7A0
005DB29C   8B08                   mov     ecx, [eax]
005DB29E   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DB2A1   8B83C4030000           mov     eax, [ebx+$03C4]

|
005DB2A7   E85032ECFF             call    0049E4FC

* Reference to control TfrmDadosCliente.qryPrincipal : TQuery
|
005DB2AC   8B83C4030000           mov     eax, [ebx+$03C4]

* Reference to field TQuery.OFFS_00A1
|
005DB2B2   80B8A100000000         cmp     byte ptr [eax+$00A1], $00
005DB2B9   7415                   jz      005DB2D0
005DB2BB   6A00                   push    $00
005DB2BD   0FB70DC8B35D00         movzx   ecx, word ptr [$005DB3C8]
005DB2C4   B202                   mov     dl, $02

* Possible String Reference to: 'Não foram encontrados os dados para
|                                 o perfil selecionado.'
|
005DB2C6   B8C0B75D00             mov     eax, $005DB7C0

|
005DB2CB   E8D858E7FF             call    00450BA8
005DB2D0   33C0                   xor     eax, eax
005DB2D2   5A                     pop     edx
005DB2D3   59                     pop     ecx
005DB2D4   59                     pop     ecx
005DB2D5   648910                 mov     fs:[eax], edx

****** FINALLY
|

* Possible String Reference to: '^[‹å]Ã'
|
005DB2D8   68BFB35D00             push    $005DB3BF
005DB2DD   8D855CFFFFFF           lea     eax, [ebp+$FFFFFF5C]

|
005DB2E3   E8BCA5E2FF             call    004058A4
005DB2E8   8D8560FFFFFF           lea     eax, [ebp+$FFFFFF60]
005DB2EE   BA02000000             mov     edx, $00000002

|
005DB2F3   E8D0A5E2FF             call    004058C8
005DB2F8   8D8568FFFFFF           lea     eax, [ebp+$FFFFFF68]
005DB2FE   BA02000000             mov     edx, $00000002

|
005DB303   E8C0A5E2FF             call    004058C8
005DB308   8D8570FFFFFF           lea     eax, [ebp+$FFFFFF70]
005DB30E   BA02000000             mov     edx, $00000002

|
005DB313   E8B0A5E2FF             call    004058C8
005DB318   8D8578FFFFFF           lea     eax, [ebp+$FFFFFF78]
005DB31E   BA02000000             mov     edx, $00000002

|
005DB323   E8A0A5E2FF             call    004058C8
005DB328   8D4580                 lea     eax, [ebp-$80]

|
005DB32B   E874A5E2FF             call    004058A4
005DB330   8D4584                 lea     eax, [ebp-$7C]

|
005DB333   E86CA5E2FF             call    004058A4
005DB338   8D4588                 lea     eax, [ebp-$78]

|
005DB33B   E864A5E2FF             call    004058A4
005DB340   8D458C                 lea     eax, [ebp-$74]

|
005DB343   E85CA5E2FF             call    004058A4
005DB348   8D4590                 lea     eax, [ebp-$70]

|
005DB34B   E854A5E2FF             call    004058A4
005DB350   8D4594                 lea     eax, [ebp-$6C]

|
005DB353   E84CA5E2FF             call    004058A4
005DB358   8D4598                 lea     eax, [ebp-$68]
005DB35B   BA0E000000             mov     edx, $0000000E

|
005DB360   E863A5E2FF             call    004058C8
005DB365   8D45D0                 lea     eax, [ebp-$30]
005DB368   BA02000000             mov     edx, $00000002

|
005DB36D   E856A5E2FF             call    004058C8
005DB372   8D45D8                 lea     eax, [ebp-$28]

|
005DB375   E82AA5E2FF             call    004058A4
005DB37A   8D45DC                 lea     eax, [ebp-$24]

|
005DB37D   E822A5E2FF             call    004058A4
005DB382   8D45E0                 lea     eax, [ebp-$20]

|
005DB385   E81AA5E2FF             call    004058A4
005DB38A   8D45E4                 lea     eax, [ebp-$1C]
005DB38D   BA02000000             mov     edx, $00000002

|
005DB392   E831A5E2FF             call    004058C8
005DB397   8D45EC                 lea     eax, [ebp-$14]

|
005DB39A   E805A5E2FF             call    004058A4
005DB39F   8D45F0                 lea     eax, [ebp-$10]

|
005DB3A2   E8FDA4E2FF             call    004058A4
005DB3A7   8D45F4                 lea     eax, [ebp-$0C]
005DB3AA   BA03000000             mov     edx, $00000003

|
005DB3AF   E814A5E2FF             call    004058C8
005DB3B4   C3                     ret


|
005DB3B5   E9DA9CE2FF             jmp     00405094
005DB3BA   E91EFFFFFF             jmp     005DB2DD

****** END
|
005DB3BF   5E                     pop     esi
005DB3C0   5B                     pop     ebx
005DB3C1   8BE5                   mov     esp, ebp
005DB3C3   5D                     pop     ebp
005DB3C4   C3                     ret

*)
end;

procedure TfrmDadosCliente.cmbRotaDropDown(Sender : TObject);
begin
(*
005DA378   55                     push    ebp
005DA379   8BEC                   mov     ebp, esp
005DA37B   33C9                   xor     ecx, ecx
005DA37D   51                     push    ecx
005DA37E   51                     push    ecx
005DA37F   51                     push    ecx
005DA380   51                     push    ecx
005DA381   53                     push    ebx
005DA382   56                     push    esi
005DA383   8BD8                   mov     ebx, eax
005DA385   33C0                   xor     eax, eax
005DA387   55                     push    ebp

* Possible String Reference to: 'éî«âÿëÛ^[‹å]Ã'
|
005DA388   68A1A45D00             push    $005DA4A1

***** TRY
|
005DA38D   64FF30                 push    dword ptr fs:[eax]
005DA390   648920                 mov     fs:[eax], esp

* Reference to control TfrmDadosCliente.cmbRota : TComboBox
|
005DA393   8B839C030000           mov     eax, [ebx+$039C]
005DA399   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
005DA39B   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmDadosCliente.cmbRota : TComboBox
|
005DA3A1   8B839C030000           mov     eax, [ebx+$039C]

* Reference to field TComboBox.OFFS_0284
|
005DA3A7   8B8084020000           mov     eax, [eax+$0284]
005DA3AD   33D2                   xor     edx, edx
005DA3AF   8B08                   mov     ecx, [eax]
005DA3B1   FF5138                 call    dword ptr [ecx+$38]
005DA3B4   8D55F8                 lea     edx, [ebp-$08]

* Reference to control TfrmDadosCliente.cmbGrupo : TComboBox
|
005DA3B7   8B8398030000           mov     eax, [ebx+$0398]

|
005DA3BD   E83E57E8FF             call    0045FB00
005DA3C2   8B45F8                 mov     eax, [ebp-$08]
005DA3C5   8D55FC                 lea     edx, [ebp-$04]

|
005DA3C8   E88705E3FF             call    0040A954
005DA3CD   837DFC00               cmp     dword ptr [ebp-$04], +$00
005DA3D1   751A                   jnz     005DA3ED
005DA3D3   6A00                   push    $00
005DA3D5   0FB70DB0A45D00         movzx   ecx, word ptr [$005DA4B0]
005DA3DC   B202                   mov     dl, $02

* Possible String Reference to: 'Selecionar um grupo.'
|
005DA3DE   B8BCA45D00             mov     eax, $005DA4BC

|
005DA3E3   E8C067E7FF             call    00450BA8
005DA3E8   E989000000             jmp     005DA476

* Reference to control TfrmDadosCliente.qryRoteiro : TQuery
|
005DA3ED   8B83B8030000           mov     eax, [ebx+$03B8]

|
005DA3F3   E81841ECFF             call    0049E510
005DA3F8   8D55F4                 lea     edx, [ebp-$0C]

* Reference to control TfrmDadosCliente.cmbGrupo : TComboBox
|
005DA3FB   8B8398030000           mov     eax, [ebx+$0398]

|
005DA401   E8FA56E8FF             call    0045FB00
005DA406   8B45F4                 mov     eax, [ebp-$0C]
005DA409   33D2                   xor     edx, edx

|
005DA40B   E8700EE3FF             call    0040B280
005DA410   50                     push    eax

* Possible String Reference to: 'nGrupo'
|
005DA411   BADCA45D00             mov     edx, $005DA4DC

* Reference to control TfrmDadosCliente.qryRoteiro : TQuery
|
005DA416   8B83B8030000           mov     eax, [ebx+$03B8]

|
005DA41C   E85F05EEFF             call    004BA980
005DA421   5A                     pop     edx

|
005DA422   E8C532ECFF             call    0049D6EC

* Reference to control TfrmDadosCliente.qryRoteiro : TQuery
|
005DA427   8B83B8030000           mov     eax, [ebx+$03B8]

|
005DA42D   E8CA40ECFF             call    0049E4FC
005DA432   EB33                   jmp     005DA467
005DA434   BAE8A45D00             mov     edx, $005DA4E8
005DA439   8BC6                   mov     eax, esi

|
005DA43B   E8F853ECFF             call    0049F838
005DA440   8D55F0                 lea     edx, [ebp-$10]
005DA443   8B08                   mov     ecx, [eax]
005DA445   FF5160                 call    dword ptr [ecx+$60]
005DA448   8B55F0                 mov     edx, [ebp-$10]

* Reference to control TfrmDadosCliente.cmbRota : TComboBox
|
005DA44B   8B839C030000           mov     eax, [ebx+$039C]

* Reference to field TComboBox.OFFS_0284
|
005DA451   8B8084020000           mov     eax, [eax+$0284]
005DA457   8B08                   mov     ecx, [eax]
005DA459   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryRoteiro : TQuery
|
005DA45C   8B83B8030000           mov     eax, [ebx+$03B8]

|
005DA462   E8B96BECFF             call    004A1020

* Reference to control TfrmDadosCliente.qryRoteiro : TQuery
|
005DA467   8BB3B8030000           mov     esi, [ebx+$03B8]

* Reference to field TQuery.OFFS_00A1
|
005DA46D   80BEA100000000         cmp     byte ptr [esi+$00A1], $00
005DA474   74BE                   jz      005DA434
005DA476   33C0                   xor     eax, eax
005DA478   5A                     pop     edx
005DA479   59                     pop     ecx
005DA47A   59                     pop     ecx
005DA47B   648910                 mov     fs:[eax], edx

****** FINALLY
|

* Possible String Reference to: '^[‹å]Ã'
|
005DA47E   68A8A45D00             push    $005DA4A8
005DA483   8D45F0                 lea     eax, [ebp-$10]

|
005DA486   E819B4E2FF             call    004058A4
005DA48B   8D45F4                 lea     eax, [ebp-$0C]
005DA48E   BA02000000             mov     edx, $00000002

|
005DA493   E830B4E2FF             call    004058C8
005DA498   8D45FC                 lea     eax, [ebp-$04]

|
005DA49B   E804B4E2FF             call    004058A4
005DA4A0   C3                     ret


|
005DA4A1   E9EEABE2FF             jmp     00405094
005DA4A6   EBDB                   jmp     005DA483

****** END
|
005DA4A8   5E                     pop     esi
005DA4A9   5B                     pop     ebx
005DA4AA   8BE5                   mov     esp, ebp
005DA4AC   5D                     pop     ebp
005DA4AD   C3                     ret

*)
end;

procedure TfrmDadosCliente.cmbGrupoDropDown(Sender : TObject);
begin
(*
005DA250   55                     push    ebp
005DA251   8BEC                   mov     ebp, esp
005DA253   6A00                   push    $00
005DA255   53                     push    ebx
005DA256   56                     push    esi
005DA257   8BD8                   mov     ebx, eax
005DA259   33C0                   xor     eax, eax
005DA25B   55                     push    ebp

* Possible String Reference to: 'ét­âÿëð^[Y]Ã'
|
005DA25C   681BA35D00             push    $005DA31B

***** TRY
|
005DA261   64FF30                 push    dword ptr fs:[eax]
005DA264   648920                 mov     fs:[eax], esp
005DA267   8BC3                   mov     eax, ebx

|
005DA269   E8F2FEFFFF             call    005DA160

* Reference to control TfrmDadosCliente.cmbGrupo : TComboBox
|
005DA26E   8B8398030000           mov     eax, [ebx+$0398]
005DA274   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
005DA276   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmDadosCliente.cmbRota : TComboBox
|
005DA27C   8B839C030000           mov     eax, [ebx+$039C]
005DA282   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
005DA284   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmDadosCliente.cmbGrupo : TComboBox
|
005DA28A   8B8398030000           mov     eax, [ebx+$0398]
005DA290   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
005DA292   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmDadosCliente.cmbGrupo : TComboBox
|
005DA298   8B8398030000           mov     eax, [ebx+$0398]

* Reference to field TComboBox.OFFS_0284
|
005DA29E   8B8084020000           mov     eax, [eax+$0284]
005DA2A4   33D2                   xor     edx, edx
005DA2A6   8B08                   mov     ecx, [eax]
005DA2A8   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryGrupo : TQuery
|
005DA2AB   8B83B4030000           mov     eax, [ebx+$03B4]

|
005DA2B1   E85A42ECFF             call    0049E510

* Reference to control TfrmDadosCliente.qryGrupo : TQuery
|
005DA2B6   8B83B4030000           mov     eax, [ebx+$03B4]

|
005DA2BC   E83B42ECFF             call    0049E4FC
005DA2C1   EB33                   jmp     005DA2F6
005DA2C3   BA2CA35D00             mov     edx, $005DA32C
005DA2C8   8BC6                   mov     eax, esi

|
005DA2CA   E86955ECFF             call    0049F838
005DA2CF   8D55FC                 lea     edx, [ebp-$04]
005DA2D2   8B08                   mov     ecx, [eax]
005DA2D4   FF5160                 call    dword ptr [ecx+$60]
005DA2D7   8B55FC                 mov     edx, [ebp-$04]

* Reference to control TfrmDadosCliente.cmbGrupo : TComboBox
|
005DA2DA   8B8398030000           mov     eax, [ebx+$0398]

* Reference to field TComboBox.OFFS_0284
|
005DA2E0   8B8084020000           mov     eax, [eax+$0284]
005DA2E6   8B08                   mov     ecx, [eax]
005DA2E8   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmDadosCliente.qryGrupo : TQuery
|
005DA2EB   8B83B4030000           mov     eax, [ebx+$03B4]

|
005DA2F1   E82A6DECFF             call    004A1020

* Reference to control TfrmDadosCliente.qryGrupo : TQuery
|
005DA2F6   8BB3B4030000           mov     esi, [ebx+$03B4]

* Reference to field TQuery.OFFS_00A1
|
005DA2FC   80BEA100000000         cmp     byte ptr [esi+$00A1], $00
005DA303   74BE                   jz      005DA2C3
005DA305   33C0                   xor     eax, eax
005DA307   5A                     pop     edx
005DA308   59                     pop     ecx
005DA309   59                     pop     ecx
005DA30A   648910                 mov     fs:[eax], edx

****** FINALLY
|

* Possible String Reference to: '^[Y]Ã'
|
005DA30D   6822A35D00             push    $005DA322
005DA312   8D45FC                 lea     eax, [ebp-$04]

|
005DA315   E88AB5E2FF             call    004058A4
005DA31A   C3                     ret


|
005DA31B   E974ADE2FF             jmp     00405094
005DA320   EBF0                   jmp     005DA312

****** END
|
005DA322   5E                     pop     esi
005DA323   5B                     pop     ebx
005DA324   59                     pop     ecx
005DA325   5D                     pop     ebp
005DA326   C3                     ret

*)
end;

procedure TfrmDadosCliente.FormActivate(Sender : TObject);
begin
(*
005DAB2C   53                     push    ebx
005DAB2D   8BD8                   mov     ebx, eax
005DAB2F   8BC3                   mov     eax, ebx

* Reference to : TfrmBaseClient.FormActivate()
|
005DAB31   E80202F9FF             call    0056AD38
005DAB36   BA01000000             mov     edx, $00000001
005DAB3B   8BC3                   mov     eax, ebx

* Reference to : TApplication._PROC_0047AD84()
|
005DAB3D   E84202EAFF             call    0047AD84
005DAB42   5B                     pop     ebx
005DAB43   C3                     ret

*)
end;

procedure TfrmDadosCliente._PROC_005DA327(Sender : TObject);
begin
(*
005DA327   0010                   add     [eax], dl
005DA329   0000                   add     [eax], al

*)
end;

procedure TfrmDadosCliente._PROC_005DA9CF(Sender : TObject);
begin
(*
005DA9CF   0010                   add     [eax], dl
005DA9D1   0000                   add     [eax], al

*)
end;

procedure TfrmDadosCliente._PROC_005DAB44(Sender : TObject);
begin
(*
005DAB44   53                     push    ebx
005DAB45   56                     push    esi
005DAB46   8BF0                   mov     esi, eax

* Reference to field TfrmDadosCliente.OFFS_0374
|
005DAB48   8D8674030000           lea     eax, [esi+$0374]

* Possible String Reference to: 'Dados do Cliente'
|
005DAB4E   BAA0AB5D00             mov     edx, $005DABA0

|
005DAB53   E8A0ADE2FF             call    004058F8

* Reference to field TfrmDadosCliente.OFFS_0378
|
005DAB58   8D8678030000           lea     eax, [esi+$0378]

* Possible String Reference to: 'Versão 8.3'
|
005DAB5E   BABCAB5D00             mov     edx, $005DABBC

|
005DAB63   E890ADE2FF             call    004058F8

* Reference to control TfrmDadosCliente.tbsDados : TTabSheet
|
005DAB68   8B96F8030000           mov     edx, [esi+$03F8]

* Reference to control TfrmDadosCliente.PCMatricula : TPageControl
|
005DAB6E   8B86F4030000           mov     eax, [esi+$03F4]

* Reference to : TTabStrings._PROC_004C7994()
|
005DAB74   E81BCEEEFF             call    004C7994
005DAB79   B301                   mov     bl, $01

* Reference to field TfrmDadosCliente.OFFS_0954 : Byte
|
005DAB7B   C6865409000000         mov     byte ptr [esi+$0954], $00

* Reference to field TfrmDadosCliente.OFFS_0955 : Byte
|
005DAB82   C6865509000000         mov     byte ptr [esi+$0955], $00
005DAB89   8BC6                   mov     eax, esi

|
005DAB8B   E83801F9FF             call    0056ACC8
005DAB90   8BC3                   mov     eax, ebx
005DAB92   5E                     pop     esi
005DAB93   5B                     pop     ebx
005DAB94   C3                     ret

*)
end;

procedure TfrmDadosCliente._PROC_005DB832(Sender : TObject);
begin
(*
005DB832   47                     inc     edi
005DB833   001C4B                 add     [ebx+ecx*2], bl
005DB836   40                     inc     eax
005DB837   000C8547005848         add     [$48580047+eax*4], cl
005DB83E   40                     inc     eax
005DB83F   00744840               add     [eax+ecx*2+$40], dh
005DB843   00905547008C           add     [eax+$8C004755], dl
005DB849   844600                 test    [esi+$00], al
005DB84C   845B47                 test    [ebx+$47], bl
005DB84F   000C31                 add     [ecx+esi], cl
005DB852   42                     inc     edx
005DB853   006C5747               add     [edi+edx*2+$47], ch
005DB857   00B8574700F4           add     [eax+$F4004757], bh
005DB85D   58                     pop     eax
005DB85E   47                     inc     edi
005DB85F   00E8                   add     al, ch
005DB861   F8                     clc
005DB862   45                     inc     ebp
005DB863   0094C542008462         add     [ebp+eax*8+$62840042], dl
005DB86A   47                     inc     edi
005DB86B   0070C2                 add     [eax-$3E], dh
005DB86E   42                     inc     edx
005DB86F   0070AB                 add     [eax-$55], dh
005DB872   47                     inc     edi
005DB873   00E0                   add     al, ah
005DB875   51                     push    ecx
005DB876   47                     inc     edi
005DB877   00B07E4600BC           add     [eax+$BC00467E], dh
005DB87D   844600                 test    [esi+$00], al
005DB880   08844600B0EB45         or      [esi+eax*2+$45EBB000], al
005DB887   002C79                 add     [ecx+edi*2], ch
005DB88A   46                     inc     esi
005DB88B   00B85E4700B8           add     [eax+$B800475E], bh
005DB891   7546                   jnz     005DB8D9
005DB893   00F0                   add     al, dh
005DB895   EA4500F4EA             jmp     $EAF40045
005DB89A   45                     inc     ebp
005DB89B   00AC5F47006C24         add     [edi+ebx*2+$246C0047], ch
005DB8A2   46                     inc     esi
005DB8A3   003CA8                 add     [eax+ebp*4], bh
005DB8A6   47                     inc     edi
005DB8A7   00CC                   add     ah, cl
005DB8A9   F8                     clc
005DB8AA   45                     inc     ebp
005DB8AB   002CED450058FA         add     [$FA580045+ebp*8], ch
005DB8B2   45                     inc     ebp
005DB8B3   00C8                   add     al, cl
005DB8B5   61                     popa
005DB8B6   47                     inc     edi
005DB8B7   008460470094FB         add     [eax+$FB940047], al
005DB8BE   45                     inc     ebp
005DB8BF   00C4                   add     ah, al
005DB8C1   624700                 bound   eax, qword ptr [edi+$00]
005DB8C4   F0                     lock
005DB8C5   2446                   and     al, $46
005DB8C7   000C76                 add     [esi+esi*2], cl
005DB8CA   46                     inc     esi
005DB8CB   00CC                   add     ah, cl
005DB8CD   7646                   jbe     005DB915
005DB8CF   00C0                   add     al, al
005DB8D1   7146                   jno     005DB919
005DB8D3   00B0764600C8           add     [eax+$C8004676], dh
005DB8D9   4F                     dec     edi
005DB8DA   47                     inc     edi
005DB8DB   0008                   add     [eax], cl
005DB8DD   6A47                   push    $47
005DB8DF   00A042460034           add     [eax+$34004642], ah
005DB8E5   7D47                   jnl     005DB92E
005DB8E7   004882                 add     [eax-$7E], cl
005DB8EA   47                     inc     edi
005DB8EB   00748047               add     [eax+eax*4+$47], dh
005DB8EF   0038                   add     [eax], bh
005DB8F1   43                     inc     ebx
005DB8F2   46                     inc     esi
005DB8F3   005C4346               add     [ebx+eax*2+$46], bl
005DB8F7   00C4                   add     ah, al
005DB8F9   834700C8               add     dword ptr [edi+$00], -$38
005DB8FD   844700                 test    [edi+$00], al
005DB900   94                     xchg    eax, esp
005DB901   41                     inc     ecx
005DB902   46                     inc     esi
005DB903   00A08C4600F8           add     [eax+$F800468C], ah
005DB909   7746                   jnbe    005DB951
005DB90B   0000                   add     [eax], al

005DB90D   8C4700                 mov     word ptr [edi+$00], es
005DB910   148C                   adc     al, $8C
005DB912   46                     inc     esi
005DB913   006874                 add     [eax+$74], ch
005DB916   46                     inc     esi
005DB917   00648D46               add     [ebp+ecx*4+$46], ah
005DB91B   0088A34700A8           add     [eax+$A80047A3], cl
005DB921   49                     dec     ecx
005DB922   47                     inc     edi
005DB923   00584C                 add     [eax+$4C], bl
005DB926   47                     inc     edi
005DB927   004093                 add     [eax-$6D], al
005DB92A   47                     inc     edi
005DB92B   00905647000C           add     [eax+$C004756], dl
005DB931   57                     push    edi
005DB932   47                     inc     edi
005DB933   00D4                   add     ah, dl
005DB935   A7                     cmpsd
005DB936   47                     inc     edi
005DB937   00A45347006CA2         add     [ebx+edx*2+$A26C0047], ah
005DB93E   47                     inc     edi
005DB93F   009C86470060A4         add     [esi+eax*4+$A4600047], bl
005DB946   47                     inc     edi
005DB947   00C4                   add     ah, al
005DB949   61                     popa
005DB94A   47                     inc     edi
005DB94B   0010                   add     [eax], dl
005DB94D   BB5D000D00             mov     ebx, $000D005D
005DB952   BABA5D0080             mov     edx, $80005DBA
005DB957   0300                   add     eax, [eax]
005DB959   0000                   add     [eax], al

*)
end;

end.