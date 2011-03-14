unit uFrmRelatorioPerformance;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics,
  Controls, Forms, Dialogs, StdCtrls
type
  TfrmRelatorioPerformance=class(TForm)
    PageControl: TPageControl;
    tbsPesquisa: TTabSheet;
    GroupBox1: TGroupBox;
    rbtReferencia: TRadioButton;
    rbtRota: TRadioButton;
    rbtAgente: TRadioButton;
    Label1: TLabel;
    cmbGrupo: TComboBox;
    Label2: TLabel;
    cmbReferencia: TComboBox;
    sbtnPesquisar: TSpeedButton;
    Label3: TLabel;
    cmbRota: TComboBox;
    Label4: TLabel;
    cmbAgente: TComboBox;
    qryReferencia: TQuery;
    qryAgente: TQuery;
    qryPesquisa: TQuery;
    qryMedicao: TQuery;
    qryMedicaomd_referencia: TDateTimeField;
    qryMedicaomd_grupo: TIntegerField;
    qryMedicaomd_rota: TIntegerField;
    qryMedicaoagente: TStringField;
    qryMedicaomd_data_leitura: TDateTimeField;
    qryMedicaomd_hora_inicio: TDateTimeField;
    qryMedicaomd_hora_fim: TDateTimeField;
    qryMedicaomd_ligacoes: TIntegerField;
    qryMedicaomd_leitura_campo: TIntegerField;
    qryMedicaomd_analise: TIntegerField;
    qryMedicaomd_faturado_normal: TIntegerField;
    qryMedicaomd_faturado_media: TIntegerField;
    qryMedicaomd_faturado_minima: TIntegerField;
    qryMedicaomd_emitidas: TIntegerField;
    qryMedicaomd_emitidas_2_vezes: TIntegerField;
    qryMedicaomd_nao_emitidas: TIntegerField;
    qryMedicaomd_entrega_mao: TIntegerField;
    qryMedicaomd_entrega_visinho: TIntegerField;
    qryMedicaomd_entrega_porta: TIntegerField;
    qryMedicaomd_entraga_correio: TIntegerField;
    qryMedicaomd_entrega_recusado: TIntegerField;
    qryMedicaomd_entrega_outro: TIntegerField;
    qryMedicaomd_nao_exec: TIntegerField;
    qryMedicaomd_fraude: TIntegerField;
    qryMedicaomd_para_corte: TIntegerField;
    qryMedicaomd_cortado: TIntegerField;
    qryMedicaomd_emitidas_aviso: TIntegerField;
    qryMedicaomd_emitidas_2_vias: TIntegerField;
    tbsReferencia: TTabSheet;
    GroupBox2: TGroupBox;
    DBGridReferencia: TDBGrid;
    dsMedicao: TDataSource;
    Label5: TLabel;
    DBEdGrupoRota: TDBEdit;
    Label6: TLabel;
    DBEdReferencia: TDBEdit;
    cmbVerReferencia: TComboBox;
    Label7: TLabel;
    qryMedicaomd_alteracoes_cadastro: TIntegerField;
    qryMedicaomd_inclusao_cadastro: TIntegerField;
    tbsRota: TTabSheet;
    GroupBox3: TGroupBox;
    Label8: TLabel;
    Label9: TLabel;
    Label10: TLabel;
    DBEdit1: TDBEdit;
    DBEdit2: TDBEdit;
    cmbVerRota: TComboBox;
    tbsAgente: TTabSheet;
    GroupBox4: TGroupBox;
    Label11: TLabel;
    Label13: TLabel;
    DBEdit3: TDBEdit;
    cmbVerAgente: TComboBox;
    rbtHorario: TRadioButton;
    tbsEmissao: TTabSheet;
    qryHorario: TQuery;
    dsDescarga: TDataSource;
    GroupBox5: TGroupBox;
    Label12: TLabel;
    Label14: TLabel;
    DBGrid1: TDBGrid;
    DBEdit4: TDBEdit;
    DBEdit5: TDBEdit;
    Label15: TLabel;
    DBEdit6: TDBEdit;
    qryHorariodg_grupo: TIntegerField;
    qryHorariodg_rota: TIntegerField;
    qryHorariodg_referencia: TDateTimeField;
    qryHorariodg_data_leitura: TDateTimeField;
    qryHorarioData_Prox_Leitura: TDateTimeField;
    qryHorarioTempo: TDateTimeField;
    qryHorariodg_matricula: TIntegerField;
    qryHorariodg_leitura_real: TIntegerField;
    qryHorariodg_ocorrencia: TIntegerField;
    qryHorariodg_flag_calculada: TStringField;
    qryHorariodg_flag_emitida: TStringField;
    qryHorariodg_flag_aviso: TStringField;
    qryHorariodg_flag_fraude: TStringField;
    qryHorariodg_flag_faturado: TStringField;
    qryHorariodg_flag_lido: TStringField;
    qryHorariodg_leitura_agente: TIntegerField;
    qryHorariodg_forma_entrega: TIntegerField;
    qryHorariodg_vias: TIntegerField;
    qryHorariodg_agente: TIntegerField;
    qryHorarioag_nome: TStringField;
    sbtnImprimir: TSpeedButton;
    RvRenderPDF: TRvRenderPDF;
    RvPrjHorario: TRvProject;
    RvDSCHorario: TRvDataSetConnection;
    qryMedicaomd_leituras_real: TIntegerField;
    qryMedicaomd_leituras_nao_real: TIntegerField;
    qryMedicaoperc_leituras_real: TIntegerField;
    qryMedicaoperc_leituras_nao_real: TIntegerField;
    DBGridRota: TDBGrid;
    DBGridAgente: TDBGrid;
    RvPrjPerformRef: TRvProject;
    RvDSCPerformance: TRvDataSetConnection;
    qryMedicaotitulo1: TStringField;
    qryMedicaotitulo2: TStringField;
    RvPrjPerformRota: TRvProject;
    RvPrjPerformAgente: TRvProject;
    tbsReferenciaRecepcao: TTabSheet;
    GroupBox6: TGroupBox;
    Label16: TLabel;
    Label17: TLabel;
    Label18: TLabel;
    DBEdit7: TDBEdit;
    DBEdit8: TDBEdit;
    cmbVerRefRecepcao: TComboBox;
    DBGridRefRecepcao: TDBGrid;
    QrMedRecepcao: TQuery;
    DSMedRecepcao: TDataSource;
    rbtReferenciaRecepcao: TRadioButton;
    QrMedRecepcaomd_grupo: TIntegerField;
    QrMedRecepcaomd_rota: TIntegerField;
    QrMedRecepcaomd_referencia: TDateTimeField;
    QrMedRecepcaoagente: TStringField;
    QrMedRecepcaomd_data_leitura: TDateTimeField;
    QrMedRecepcaomd_hora_inicio: TDateTimeField;
    QrMedRecepcaomd_hora_fim: TDateTimeField;
    QrMedRecepcaomd_ligacoes: TIntegerField;
    QrMedRecepcaomd_leituras_real: TIntegerField;
    QrMedRecepcaomd_leitura_campo: TIntegerField;
    QrMedRecepcaomd_analise: TIntegerField;
    QrMedRecepcaomd_faturado_normal: TIntegerField;
    QrMedRecepcaomd_faturado_media: TIntegerField;
    QrMedRecepcaomd_faturado_minima: TIntegerField;
    QrMedRecepcaomd_emitidas: TIntegerField;
    QrMedRecepcaomd_emitidas_2_vezes: TIntegerField;
    QrMedRecepcaomd_nao_emitidas: TIntegerField;
    QrMedRecepcaomd_emitidas_aviso: TIntegerField;
    QrMedRecepcaomd_entrega_mao: TIntegerField;
    QrMedRecepcaomd_entrega_visinho: TIntegerField;
    QrMedRecepcaomd_entrega_porta: TIntegerField;
    QrMedRecepcaomd_entraga_correio: TIntegerField;
    QrMedRecepcaomd_entrega_recusado: TIntegerField;
    QrMedRecepcaomd_entrega_outro: TIntegerField;
    QrMedRecepcaomd_nao_exec: TIntegerField;
    QrMedRecepcaomd_fraude: TIntegerField;
    QrMedRecepcaomd_para_corte: TIntegerField;
    QrMedRecepcaomd_cortado: TIntegerField;
    QrMedRecepcaomd_consumo_medido: TIntegerField;
    QrMedRecepcaomd_consumo_medido_esg: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_res: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_res_esg: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_com: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_com_esg: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_ind: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_ind_esg: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_pub: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_pub_esg: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_soc: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_soc_esg: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_ea: TIntegerField;
    QrMedRecepcaomd_consumo_faturado_ea_esg: TIntegerField;
    QrMedRecepcaomd_valor_agua: TFloatField;
    QrMedRecepcaomd_valor_esgoto: TFloatField;
    QrMedRecepcaomd_valor_servico: TFloatField;
    QrMedRecepcaomd_valor_credito: TFloatField;
    QrMedRecepcaomd_valor_devolucao: TFloatField;
    QrMedRecepcaomd_valor_ir: TFloatField;
    QrMedRecepcaomd_valor_csll: TFloatField;
    QrMedRecepcaomd_valor_pis: TFloatField;
    QrMedRecepcaomd_valor_cofins: TFloatField;
    QrMedRecepcaomd_valor_saldo_debito: TFloatField;
    QrMedRecepcaomd_valor_saldo_credito: TFloatField;
    QrMedRecepcaomd_leituras_nao_real: TIntegerField;
    QrMedRecepcaoperc_leituras_real: TIntegerField;
    QrMedRecepcaoperc_leituras_nao_real: TIntegerField;
    RvPrjPerformRefRecepcao: TRvProject;
    RvDSCPerfRecepcao: TRvDataSetConnection;
    QrMedRecepcaotitulo1: TStringField;
    QrMedRecepcaotitulo2: TStringField;
    procedure QrMedRecepcaoCalcFields(Sender : TObject);
    procedure cmbVerRefRecepcaoChange(Sender : TObject);
    procedure sbtnImprimirClick(Sender : TObject);
    procedure cmbVerAgenteChange(Sender : TObject);
    procedure cmbVerRotaChange(Sender : TObject);
    procedure cmbVerReferenciaChange(Sender : TObject);
    procedure sbtnPesquisarClick(Sender : TObject);
    procedure cmbRotaDropDown(Sender : TObject);
    procedure cmbGrupoDropDown(Sender : TObject);
    procedure cmbAgenteDropDown(Sender : TObject);
    procedure cmbReferenciaDropDown(Sender : TObject);
    procedure rbtReferenciaClick(Sender : TObject);
    procedure FormActivate(Sender : TObject);
    procedure _PROC_006061E8(Sender : TObject);
    procedure _PROC_00606490(Sender : TObject);
    procedure _PROC_00607890(Sender : TObject);
    procedure _PROC_006094C6(Sender : TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end ;

var
  frmRelatorioPerformance: TfrmRelatorioPerformance;

{This file is generated by DeDe Ver 3.50.04 Copyright (c) 1999-2002 DaFixer}

implementation

{$R *.DFM}

procedure TfrmRelatorioPerformance.QrMedRecepcaoCalcFields(Sender : TObject);
begin
(*
0060792C   55                     push    ebp
0060792D   8BEC                   mov     ebp, esp
0060792F   83C4E4                 add     esp, -$1C
00607932   53                     push    ebx
00607933   56                     push    esi
00607934   33C9                   xor     ecx, ecx
00607936   894DE8                 mov     [ebp-$18], ecx
00607939   894DE4                 mov     [ebp-$1C], ecx
0060793C   8BD8                   mov     ebx, eax
0060793E   33C0                   xor     eax, eax
00607940   55                     push    ebp

* Possible String Reference to: 'Èˇ’ﬂˇÎÎ^[ãÂ]√'
|
00607941   68907A6000             push    $00607A90

***** TRY
|
00607946   64FF30                 push    dword ptr fs:[eax]
00607949   648920                 mov     fs:[eax], esp

* Reference to control TfrmRelatorioPerformance.QrMedRecepcaomd_leitura_campo : TIntegerField
|
0060794C   8B83B8050000           mov     eax, [ebx+$05B8]
00607952   8B10                   mov     edx, [eax]

* Possible reference to virtual method TIntegerField.OFFS_58
|
00607954   FF5258                 call    dword ptr [edx+$58]
00607957   8BF0                   mov     esi, eax

* Reference to control TfrmRelatorioPerformance.QrMedRecepcaomd_analise : TIntegerField
|
00607959   8B83BC050000           mov     eax, [ebx+$05BC]
0060795F   8B10                   mov     edx, [eax]

* Possible reference to virtual method TIntegerField.OFFS_58
|
00607961   FF5258                 call    dword ptr [edx+$58]
00607964   03F0                   add     esi, eax

* Reference to control TfrmRelatorioPerformance.QrMedRecepcaomd_leituras_real : TIntegerField
|
00607966   8B83B4050000           mov     eax, [ebx+$05B4]
0060796C   8B10                   mov     edx, [eax]

* Possible reference to virtual method TIntegerField.OFFS_58
|
0060796E   FF5258                 call    dword ptr [edx+$58]
00607971   8BD6                   mov     edx, esi
00607973   2BD0                   sub     edx, eax

* Reference to control TfrmRelatorioPerformance.QrMedRecepcaomd_leituras_nao_real : TIntegerField
|
00607975   8B8368060000           mov     eax, [ebx+$0668]
0060797B   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TIntegerField.OFFS_00B0
|
0060797D   FF91B0000000           call    dword ptr [ecx+$00B0]
00607983   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioPerformance.QrMedRecepcaoperc_leituras_real : TIntegerField
|
00607985   8B836C060000           mov     eax, [ebx+$066C]
0060798B   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TIntegerField.OFFS_00B0
|
0060798D   FF91B0000000           call    dword ptr [ecx+$00B0]
00607993   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioPerformance.QrMedRecepcaoperc_leituras_nao_real : TIntegerField
|
00607995   8B8370060000           mov     eax, [ebx+$0670]
0060799B   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TIntegerField.OFFS_00B0
|
0060799D   FF91B0000000           call    dword ptr [ecx+$00B0]

* Reference to control TfrmRelatorioPerformance.QrMedRecepcaomd_leitura_campo : TIntegerField
|
006079A3   8B83B8050000           mov     eax, [ebx+$05B8]
006079A9   8B10                   mov     edx, [eax]

* Possible reference to virtual method TIntegerField.OFFS_58
|
006079AB   FF5258                 call    dword ptr [edx+$58]
006079AE   8BF0                   mov     esi, eax

* Reference to control TfrmRelatorioPerformance.QrMedRecepcaomd_analise : TIntegerField
|
006079B0   8B83BC050000           mov     eax, [ebx+$05BC]
006079B6   8B10                   mov     edx, [eax]

* Possible reference to virtual method TIntegerField.OFFS_58
|
006079B8   FF5258                 call    dword ptr [edx+$58]
006079BB   03F0                   add     esi, eax
006079BD   85F6                   test    esi, esi
006079BF   7E72                   jle     00607A33

* Reference to control TfrmRelatorioPerformance.QrMedRecepcaomd_leitura_campo : TIntegerField
|
006079C1   8B83B8050000           mov     eax, [ebx+$05B8]
006079C7   8B10                   mov     edx, [eax]

* Possible reference to virtual method TIntegerField.OFFS_58
|
006079C9   FF5258                 call    dword ptr [edx+$58]
006079CC   8BF0                   mov     esi, eax

* Reference to control TfrmRelatorioPerformance.QrMedRecepcaomd_analise : TIntegerField
|
006079CE   8B83BC050000           mov     eax, [ebx+$05BC]
006079D4   8B10                   mov     edx, [eax]

* Possible reference to virtual method TIntegerField.OFFS_58
|
006079D6   FF5258                 call    dword ptr [edx+$58]
006079D9   03F0                   add     esi, eax
006079DB   8975FC                 mov     [ebp-$04], esi
006079DE   DB45FC                 fild    dword ptr [ebp-$04]
006079E1   DB7DF0                 fstp    tbyte ptr [ebp-$10]
006079E4   9B                     wait

* Reference to control TfrmRelatorioPerformance.QrMedRecepcaomd_leituras_real : TIntegerField
|
006079E5   8B83B4050000           mov     eax, [ebx+$05B4]
006079EB   8B10                   mov     edx, [eax]

* Possible reference to virtual method TIntegerField.OFFS_58
|
006079ED   FF5258                 call    dword ptr [edx+$58]
006079F0   6BC064                 imul    eax, eax, $64
006079F3   8945EC                 mov     [ebp-$14], eax
006079F6   DB45EC                 fild    dword ptr [ebp-$14]
006079F9   DB6DF0                 fld     tbyte ptr [ebp-$10]
006079FC   DEF9                   fdivp   st(1), st(0)

|
006079FE   E855BADFFF             call    00403458
00607A03   8BD0                   mov     edx, eax

* Reference to control TfrmRelatorioPerformance.QrMedRecepcaoperc_leituras_real : TIntegerField
|
00607A05   8B836C060000           mov     eax, [ebx+$066C]
00607A0B   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TIntegerField.OFFS_00B0
|
00607A0D   FF91B0000000           call    dword ptr [ecx+$00B0]

* Reference to control TfrmRelatorioPerformance.QrMedRecepcaoperc_leituras_real : TIntegerField
|
00607A13   8B836C060000           mov     eax, [ebx+$066C]
00607A19   8B10                   mov     edx, [eax]

* Possible reference to virtual method TIntegerField.OFFS_58
|
00607A1B   FF5258                 call    dword ptr [edx+$58]
00607A1E   BA64000000             mov     edx, $00000064
00607A23   2BD0                   sub     edx, eax

* Reference to control TfrmRelatorioPerformance.QrMedRecepcaoperc_leituras_nao_real : TIntegerField
|
00607A25   8B8370060000           mov     eax, [ebx+$0670]
00607A2B   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TIntegerField.OFFS_00B0
|
00607A2D   FF91B0000000           call    dword ptr [ecx+$00B0]

* Possible String Reference to: 'Performace dos Agentes na ReferÍnci
|                                a (ApÛs RecepÁ„o)'
|
00607A33   BAA87A6000             mov     edx, $00607AA8

* Reference to control TfrmRelatorioPerformance.QrMedRecepcaotitulo1 : TStringField
|
00607A38   8B837C060000           mov     eax, [ebx+$067C]
00607A3E   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TStringField.OFFS_00B8
|
00607A40   FF91B8000000           call    dword ptr [ecx+$00B8]
00607A46   8D55E4                 lea     edx, [ebp-$1C]

* Reference to control TfrmRelatorioPerformance.QrMedRecepcaomd_grupo : TIntegerField
|
00607A49   8B8394050000           mov     eax, [ebx+$0594]

|
00607A4F   E8A0BAE8FF             call    004934F4
00607A54   8B4DE4                 mov     ecx, [ebp-$1C]
00607A57   8D45E8                 lea     eax, [ebp-$18]

* Possible String Reference to: 'Grupo: '
|
00607A5A   BAE87A6000             mov     edx, $00607AE8

|
00607A5F   E850E1DFFF             call    00405BB4
00607A64   8B55E8                 mov     edx, [ebp-$18]

* Reference to control TfrmRelatorioPerformance.QrMedRecepcaotitulo2 : TStringField
|
00607A67   8B8380060000           mov     eax, [ebx+$0680]
00607A6D   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TStringField.OFFS_00B8
|
00607A6F   FF91B8000000           call    dword ptr [ecx+$00B8]
00607A75   33C0                   xor     eax, eax
00607A77   5A                     pop     edx
00607A78   59                     pop     ecx
00607A79   59                     pop     ecx
00607A7A   648910                 mov     fs:[eax], edx

****** FINALLY
|

* Possible String Reference to: '^[ãÂ]√'
|
00607A7D   68977A6000             push    $00607A97
00607A82   8D45E4                 lea     eax, [ebp-$1C]
00607A85   BA02000000             mov     edx, $00000002

|
00607A8A   E839DEDFFF             call    004058C8
00607A8F   C3                     ret


|
00607A90   E9FFD5DFFF             jmp     00405094
00607A95   EBEB                   jmp     00607A82

****** END
|
00607A97   5E                     pop     esi
00607A98   5B                     pop     ebx
00607A99   8BE5                   mov     esp, ebp
00607A9B   5D                     pop     ebp
00607A9C   C3                     ret

*)
end;

procedure TfrmRelatorioPerformance.cmbVerRefRecepcaoChange(Sender : TObject);
begin
(*
00606F58   55                     push    ebp
00606F59   8BEC                   mov     ebp, esp
00606F5B   6A00                   push    $00
00606F5D   53                     push    ebx
00606F5E   56                     push    esi
00606F5F   8BF0                   mov     esi, eax
00606F61   33C0                   xor     eax, eax
00606F63   55                     push    ebp
00606F64   6889736000             push    $00607389

***** TRY
|
00606F69   64FF30                 push    dword ptr fs:[eax]
00606F6C   648920                 mov     fs:[eax], esp
00606F6F   8D55FC                 lea     edx, [ebp-$04]

* Reference to control TfrmRelatorioPerformance.cmbVerRefRecepcao : TComboBox
|
00606F72   8B8680050000           mov     eax, [esi+$0580]

|
00606F78   E8838BE5FF             call    0045FB00
00606F7D   8B45FC                 mov     eax, [ebp-$04]

|
00606F80   E8D707F7FF             call    0057775C
00606F85   8BD8                   mov     ebx, eax

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
00606F87   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
00606F8D   8B802C030000           mov     eax, [eax+$032C]
00606F93   BA05000000             mov     edx, $00000005

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606F98   E87BBDFBFF             call    005C2D18
00606F9D   83FB01                 cmp     ebx, +$01
00606FA0   740E                   jz      00606FB0
00606FA2   83FB02                 cmp     ebx, +$02
00606FA5   7409                   jz      00606FB0
00606FA7   83FB07                 cmp     ebx, +$07
00606FAA   7404                   jz      00606FB0
00606FAC   33D2                   xor     edx, edx
00606FAE   EB02                   jmp     00606FB2
00606FB0   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606FB2   E831BCFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
00606FB7   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
00606FBD   8B802C030000           mov     eax, [eax+$032C]
00606FC3   BA06000000             mov     edx, $00000006

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606FC8   E84BBDFBFF             call    005C2D18
00606FCD   83FB01                 cmp     ebx, +$01
00606FD0   740E                   jz      00606FE0
00606FD2   83FB02                 cmp     ebx, +$02
00606FD5   7409                   jz      00606FE0
00606FD7   83FB07                 cmp     ebx, +$07
00606FDA   7404                   jz      00606FE0
00606FDC   33D2                   xor     edx, edx
00606FDE   EB02                   jmp     00606FE2
00606FE0   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606FE2   E801BCFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
00606FE7   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
00606FED   8B802C030000           mov     eax, [eax+$032C]
00606FF3   BA07000000             mov     edx, $00000007

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606FF8   E81BBDFBFF             call    005C2D18
00606FFD   83FB01                 cmp     ebx, +$01
00607000   740E                   jz      00607010
00607002   83FB02                 cmp     ebx, +$02
00607005   7409                   jz      00607010
00607007   83FB07                 cmp     ebx, +$07
0060700A   7404                   jz      00607010
0060700C   33D2                   xor     edx, edx
0060700E   EB02                   jmp     00607012
00607010   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607012   E8D1BBFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
00607017   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
0060701D   8B802C030000           mov     eax, [eax+$032C]
00607023   BA08000000             mov     edx, $00000008

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607028   E8EBBCFBFF             call    005C2D18
0060702D   83FB01                 cmp     ebx, +$01
00607030   7409                   jz      0060703B
00607032   83FB03                 cmp     ebx, +$03
00607035   7404                   jz      0060703B
00607037   33D2                   xor     edx, edx
00607039   EB02                   jmp     0060703D
0060703B   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
0060703D   E8A6BBFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
00607042   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
00607048   8B802C030000           mov     eax, [eax+$032C]
0060704E   BA09000000             mov     edx, $00000009

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607053   E8C0BCFBFF             call    005C2D18
00607058   83FB01                 cmp     ebx, +$01
0060705B   7409                   jz      00607066
0060705D   83FB03                 cmp     ebx, +$03
00607060   7404                   jz      00607066
00607062   33D2                   xor     edx, edx
00607064   EB02                   jmp     00607068
00607066   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607068   E87BBBFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
0060706D   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
00607073   8B802C030000           mov     eax, [eax+$032C]
00607079   BA0A000000             mov     edx, $0000000A

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
0060707E   E895BCFBFF             call    005C2D18
00607083   83FB01                 cmp     ebx, +$01
00607086   7409                   jz      00607091
00607088   83FB03                 cmp     ebx, +$03
0060708B   7404                   jz      00607091
0060708D   33D2                   xor     edx, edx
0060708F   EB02                   jmp     00607093
00607091   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607093   E850BBFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
00607098   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
0060709E   8B802C030000           mov     eax, [eax+$032C]
006070A4   BA0B000000             mov     edx, $0000000B

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006070A9   E86ABCFBFF             call    005C2D18
006070AE   83FB01                 cmp     ebx, +$01
006070B1   7409                   jz      006070BC
006070B3   83FB04                 cmp     ebx, +$04
006070B6   7404                   jz      006070BC
006070B8   33D2                   xor     edx, edx
006070BA   EB02                   jmp     006070BE
006070BC   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006070BE   E825BBFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
006070C3   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
006070C9   8B802C030000           mov     eax, [eax+$032C]
006070CF   BA0C000000             mov     edx, $0000000C

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006070D4   E83FBCFBFF             call    005C2D18
006070D9   83FB01                 cmp     ebx, +$01
006070DC   7409                   jz      006070E7
006070DE   83FB04                 cmp     ebx, +$04
006070E1   7404                   jz      006070E7
006070E3   33D2                   xor     edx, edx
006070E5   EB02                   jmp     006070E9
006070E7   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006070E9   E8FABAFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
006070EE   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
006070F4   8B802C030000           mov     eax, [eax+$032C]
006070FA   BA0D000000             mov     edx, $0000000D

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006070FF   E814BCFBFF             call    005C2D18
00607104   83FB01                 cmp     ebx, +$01
00607107   7409                   jz      00607112
00607109   83FB04                 cmp     ebx, +$04
0060710C   7404                   jz      00607112
0060710E   33D2                   xor     edx, edx
00607110   EB02                   jmp     00607114
00607112   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607114   E8CFBAFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
00607119   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
0060711F   8B802C030000           mov     eax, [eax+$032C]
00607125   BA0E000000             mov     edx, $0000000E

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
0060712A   E8E9BBFBFF             call    005C2D18
0060712F   83FB01                 cmp     ebx, +$01
00607132   7409                   jz      0060713D
00607134   83FB04                 cmp     ebx, +$04
00607137   7404                   jz      0060713D
00607139   33D2                   xor     edx, edx
0060713B   EB02                   jmp     0060713F
0060713D   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
0060713F   E8A4BAFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
00607144   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
0060714A   8B802C030000           mov     eax, [eax+$032C]
00607150   BA0F000000             mov     edx, $0000000F

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607155   E8BEBBFBFF             call    005C2D18
0060715A   83FB01                 cmp     ebx, +$01
0060715D   7409                   jz      00607168
0060715F   83FB05                 cmp     ebx, +$05
00607162   7404                   jz      00607168
00607164   33D2                   xor     edx, edx
00607166   EB02                   jmp     0060716A
00607168   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
0060716A   E879BAFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
0060716F   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
00607175   8B802C030000           mov     eax, [eax+$032C]
0060717B   BA10000000             mov     edx, $00000010

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607180   E893BBFBFF             call    005C2D18
00607185   83FB01                 cmp     ebx, +$01
00607188   7409                   jz      00607193
0060718A   83FB05                 cmp     ebx, +$05
0060718D   7404                   jz      00607193
0060718F   33D2                   xor     edx, edx
00607191   EB02                   jmp     00607195
00607193   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607195   E84EBAFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
0060719A   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
006071A0   8B802C030000           mov     eax, [eax+$032C]
006071A6   BA11000000             mov     edx, $00000011

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006071AB   E868BBFBFF             call    005C2D18
006071B0   83FB01                 cmp     ebx, +$01
006071B3   7409                   jz      006071BE
006071B5   83FB05                 cmp     ebx, +$05
006071B8   7404                   jz      006071BE
006071BA   33D2                   xor     edx, edx
006071BC   EB02                   jmp     006071C0
006071BE   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006071C0   E823BAFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
006071C5   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
006071CB   8B802C030000           mov     eax, [eax+$032C]
006071D1   BA12000000             mov     edx, $00000012

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006071D6   E83DBBFBFF             call    005C2D18
006071DB   83FB01                 cmp     ebx, +$01
006071DE   7409                   jz      006071E9
006071E0   83FB06                 cmp     ebx, +$06
006071E3   7404                   jz      006071E9
006071E5   33D2                   xor     edx, edx
006071E7   EB02                   jmp     006071EB
006071E9   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006071EB   E8F8B9FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
006071F0   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
006071F6   8B802C030000           mov     eax, [eax+$032C]
006071FC   BA13000000             mov     edx, $00000013

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607201   E812BBFBFF             call    005C2D18
00607206   83FB01                 cmp     ebx, +$01
00607209   7409                   jz      00607214
0060720B   83FB06                 cmp     ebx, +$06
0060720E   7404                   jz      00607214
00607210   33D2                   xor     edx, edx
00607212   EB02                   jmp     00607216
00607214   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607216   E8CDB9FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
0060721B   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
00607221   8B802C030000           mov     eax, [eax+$032C]
00607227   BA14000000             mov     edx, $00000014

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
0060722C   E8E7BAFBFF             call    005C2D18
00607231   83FB01                 cmp     ebx, +$01
00607234   7409                   jz      0060723F
00607236   83FB06                 cmp     ebx, +$06
00607239   7404                   jz      0060723F
0060723B   33D2                   xor     edx, edx
0060723D   EB02                   jmp     00607241
0060723F   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607241   E8A2B9FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
00607246   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
0060724C   8B802C030000           mov     eax, [eax+$032C]
00607252   BA15000000             mov     edx, $00000015

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607257   E8BCBAFBFF             call    005C2D18
0060725C   83FB01                 cmp     ebx, +$01
0060725F   7409                   jz      0060726A
00607261   83FB06                 cmp     ebx, +$06
00607264   7404                   jz      0060726A
00607266   33D2                   xor     edx, edx
00607268   EB02                   jmp     0060726C
0060726A   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
0060726C   E877B9FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
00607271   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
00607277   8B802C030000           mov     eax, [eax+$032C]
0060727D   BA16000000             mov     edx, $00000016

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607282   E891BAFBFF             call    005C2D18
00607287   83FB01                 cmp     ebx, +$01
0060728A   7409                   jz      00607295
0060728C   83FB06                 cmp     ebx, +$06
0060728F   7404                   jz      00607295
00607291   33D2                   xor     edx, edx
00607293   EB02                   jmp     00607297
00607295   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607297   E84CB9FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
0060729C   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
006072A2   8B802C030000           mov     eax, [eax+$032C]
006072A8   BA17000000             mov     edx, $00000017

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006072AD   E866BAFBFF             call    005C2D18
006072B2   83FB01                 cmp     ebx, +$01
006072B5   7409                   jz      006072C0
006072B7   83FB06                 cmp     ebx, +$06
006072BA   7404                   jz      006072C0
006072BC   33D2                   xor     edx, edx
006072BE   EB02                   jmp     006072C2
006072C0   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006072C2   E821B9FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
006072C7   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
006072CD   8B802C030000           mov     eax, [eax+$032C]
006072D3   BA18000000             mov     edx, $00000018

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006072D8   E83BBAFBFF             call    005C2D18
006072DD   83FB01                 cmp     ebx, +$01
006072E0   7409                   jz      006072EB
006072E2   83FB07                 cmp     ebx, +$07
006072E5   7404                   jz      006072EB
006072E7   33D2                   xor     edx, edx
006072E9   EB02                   jmp     006072ED
006072EB   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006072ED   E8F6B8FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
006072F2   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
006072F8   8B802C030000           mov     eax, [eax+$032C]
006072FE   BA19000000             mov     edx, $00000019

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607303   E810BAFBFF             call    005C2D18
00607308   83FB01                 cmp     ebx, +$01
0060730B   7409                   jz      00607316
0060730D   83FB07                 cmp     ebx, +$07
00607310   7404                   jz      00607316
00607312   33D2                   xor     edx, edx
00607314   EB02                   jmp     00607318
00607316   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607318   E8CBB8FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
0060731D   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
00607323   8B802C030000           mov     eax, [eax+$032C]
00607329   BA1A000000             mov     edx, $0000001A

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
0060732E   E8E5B9FBFF             call    005C2D18
00607333   83FB01                 cmp     ebx, +$01
00607336   7409                   jz      00607341
00607338   83FB07                 cmp     ebx, +$07
0060733B   7404                   jz      00607341
0060733D   33D2                   xor     edx, edx
0060733F   EB02                   jmp     00607343
00607341   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607343   E8A0B8FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRefRecepcao : TDBGrid
|
00607348   8B8684050000           mov     eax, [esi+$0584]

* Reference to field TDBGrid.OFFS_032C
|
0060734E   8B802C030000           mov     eax, [eax+$032C]
00607354   BA1B000000             mov     edx, $0000001B

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607359   E8BAB9FBFF             call    005C2D18
0060735E   83FB01                 cmp     ebx, +$01
00607361   7409                   jz      0060736C
00607363   83FB07                 cmp     ebx, +$07
00607366   7404                   jz      0060736C
00607368   33D2                   xor     edx, edx
0060736A   EB02                   jmp     0060736E
0060736C   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
0060736E   E875B8FBFF             call    005C2BE8
00607373   33C0                   xor     eax, eax
00607375   5A                     pop     edx
00607376   59                     pop     ecx
00607377   59                     pop     ecx
00607378   648910                 mov     fs:[eax], edx

****** FINALLY
|

* Possible String Reference to: '^[Y]√ç@'
|
0060737B   6890736000             push    $00607390
00607380   8D45FC                 lea     eax, [ebp-$04]

|
00607383   E81CE5DFFF             call    004058A4
00607388   C3                     ret


|
00607389   E906DDDFFF             jmp     00405094
0060738E   EBF0                   jmp     00607380

****** END
|
00607390   5E                     pop     esi
00607391   5B                     pop     ebx
00607392   59                     pop     ecx
00607393   5D                     pop     ebp
00607394   C3                     ret

*)
end;

procedure TfrmRelatorioPerformance.sbtnImprimirClick(Sender : TObject);
begin
(*
00607C48   53                     push    ebx
00607C49   8BD8                   mov     ebx, eax

* Reference to control TfrmRelatorioPerformance.rbtHorario : TRadioButton
|
00607C4B   8B83A4040000           mov     eax, [ebx+$04A4]
00607C51   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00607C53   FF92D8000000           call    dword ptr [edx+$00D8]
00607C59   84C0                   test    al, al
00607C5B   740D                   jz      00607C6A

* Reference to control TfrmRelatorioPerformance.RvPrjHorario : TRvProject
|
00607C5D   8B832C050000           mov     eax, [ebx+$052C]

|
00607C63   E8BC1BF4FF             call    00549824
00607C68   5B                     pop     ebx
00607C69   C3                     ret


* Reference to control Bevel1 : N.A.
|
00607C6A   8B838C030000           mov     eax, [ebx+$038C]
00607C70   8B10                   mov     edx, [eax]

* Possible reference to virtual method TN.A..OFFS_00D8
|
00607C72   FF92D8000000           call    dword ptr [edx+$00D8]
00607C78   84C0                   test    al, al
00607C7A   740D                   jz      00607C89
00607C7C   8B834C050000           mov     eax, [ebx+$054C]

|
00607C82   E89D1BF4FF             call    00549824
00607C87   EB5B                   jmp     00607CE4

* Reference to control qryGrupo : N.A.
|
00607C89   8B8390030000           mov     eax, [ebx+$0390]
00607C8F   8B10                   mov     edx, [eax]

* Possible reference to virtual method TN.A..OFFS_00D8
|
00607C91   FF92D8000000           call    dword ptr [edx+$00D8]
00607C97   84C0                   test    al, al
00607C99   740D                   jz      00607CA8
00607C9B   8B835C050000           mov     eax, [ebx+$055C]

|
00607CA1   E87E1BF4FF             call    00549824
00607CA6   EB3C                   jmp     00607CE4

* Reference to control qryRoteiro : N.A.
|
00607CA8   8B8394030000           mov     eax, [ebx+$0394]
00607CAE   8B10                   mov     edx, [eax]

* Possible reference to virtual method TN.A..OFFS_00D8
|
00607CB0   FF92D8000000           call    dword ptr [edx+$00D8]
00607CB6   84C0                   test    al, al
00607CB8   740D                   jz      00607CC7
00607CBA   8B8360050000           mov     eax, [ebx+$0560]

|
00607CC0   E85F1BF4FF             call    00549824
00607CC5   EB1D                   jmp     00607CE4
00607CC7   8B8390050000           mov     eax, [ebx+$0590]
00607CCD   8B10                   mov     edx, [eax]
00607CCF   FF92D8000000           call    dword ptr [edx+$00D8]
00607CD5   84C0                   test    al, al
00607CD7   740B                   jz      00607CE4
00607CD9   8B8374060000           mov     eax, [ebx+$0674]

|
00607CDF   E8401BF4FF             call    00549824
00607CE4   5B                     pop     ebx
00607CE5   C3                     ret

*)
end;

procedure TfrmRelatorioPerformance.cmbVerAgenteChange(Sender : TObject);
begin
(*
006065D8   55                     push    ebp
006065D9   8BEC                   mov     ebp, esp
006065DB   6A00                   push    $00
006065DD   53                     push    ebx
006065DE   56                     push    esi
006065DF   8BF0                   mov     esi, eax
006065E1   33C0                   xor     eax, eax
006065E3   55                     push    ebp
006065E4   688A6A6000             push    $00606A8A

***** TRY
|
006065E9   64FF30                 push    dword ptr fs:[eax]
006065EC   648920                 mov     fs:[eax], esp
006065EF   8D55FC                 lea     edx, [ebp-$04]

* Reference to control TfrmRelatorioPerformance.cmbVerAgente : TComboBox
|
006065F2   8B86A0040000           mov     eax, [esi+$04A0]

|
006065F8   E80395E5FF             call    0045FB00
006065FD   8B45FC                 mov     eax, [ebp-$04]

|
00606600   E85711F7FF             call    0057775C
00606605   8BD8                   mov     ebx, eax

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
00606607   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
0060660D   8B802C030000           mov     eax, [eax+$032C]
00606613   BA06000000             mov     edx, $00000006

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606618   E8FBC6FBFF             call    005C2D18
0060661D   83FB01                 cmp     ebx, +$01
00606620   740E                   jz      00606630
00606622   83FB02                 cmp     ebx, +$02
00606625   7409                   jz      00606630
00606627   83FB07                 cmp     ebx, +$07
0060662A   7404                   jz      00606630
0060662C   33D2                   xor     edx, edx
0060662E   EB02                   jmp     00606632
00606630   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606632   E8B1C5FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
00606637   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
0060663D   8B802C030000           mov     eax, [eax+$032C]
00606643   BA07000000             mov     edx, $00000007

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606648   E8CBC6FBFF             call    005C2D18
0060664D   83FB01                 cmp     ebx, +$01
00606650   740E                   jz      00606660
00606652   83FB02                 cmp     ebx, +$02
00606655   7409                   jz      00606660
00606657   83FB07                 cmp     ebx, +$07
0060665A   7404                   jz      00606660
0060665C   33D2                   xor     edx, edx
0060665E   EB02                   jmp     00606662
00606660   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606662   E881C5FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
00606667   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
0060666D   8B802C030000           mov     eax, [eax+$032C]
00606673   BA08000000             mov     edx, $00000008

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606678   E89BC6FBFF             call    005C2D18
0060667D   83FB01                 cmp     ebx, +$01
00606680   740E                   jz      00606690
00606682   83FB02                 cmp     ebx, +$02
00606685   7409                   jz      00606690
00606687   83FB07                 cmp     ebx, +$07
0060668A   7404                   jz      00606690
0060668C   33D2                   xor     edx, edx
0060668E   EB02                   jmp     00606692
00606690   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606692   E851C5FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
00606697   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
0060669D   8B802C030000           mov     eax, [eax+$032C]
006066A3   BA09000000             mov     edx, $00000009

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006066A8   E86BC6FBFF             call    005C2D18
006066AD   83FB01                 cmp     ebx, +$01
006066B0   7409                   jz      006066BB
006066B2   83FB03                 cmp     ebx, +$03
006066B5   7404                   jz      006066BB
006066B7   33D2                   xor     edx, edx
006066B9   EB02                   jmp     006066BD
006066BB   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006066BD   E826C5FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
006066C2   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
006066C8   8B802C030000           mov     eax, [eax+$032C]
006066CE   BA0A000000             mov     edx, $0000000A

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006066D3   E840C6FBFF             call    005C2D18
006066D8   83FB01                 cmp     ebx, +$01
006066DB   7409                   jz      006066E6
006066DD   83FB03                 cmp     ebx, +$03
006066E0   7404                   jz      006066E6
006066E2   33D2                   xor     edx, edx
006066E4   EB02                   jmp     006066E8
006066E6   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006066E8   E8FBC4FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
006066ED   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
006066F3   8B802C030000           mov     eax, [eax+$032C]
006066F9   BA0B000000             mov     edx, $0000000B

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006066FE   E815C6FBFF             call    005C2D18
00606703   83FB01                 cmp     ebx, +$01
00606706   7409                   jz      00606711
00606708   83FB03                 cmp     ebx, +$03
0060670B   7404                   jz      00606711
0060670D   33D2                   xor     edx, edx
0060670F   EB02                   jmp     00606713
00606711   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606713   E8D0C4FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
00606718   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
0060671E   8B802C030000           mov     eax, [eax+$032C]
00606724   BA0C000000             mov     edx, $0000000C

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606729   E8EAC5FBFF             call    005C2D18
0060672E   83FB01                 cmp     ebx, +$01
00606731   7409                   jz      0060673C
00606733   83FB04                 cmp     ebx, +$04
00606736   7404                   jz      0060673C
00606738   33D2                   xor     edx, edx
0060673A   EB02                   jmp     0060673E
0060673C   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
0060673E   E8A5C4FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
00606743   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
00606749   8B802C030000           mov     eax, [eax+$032C]
0060674F   BA0D000000             mov     edx, $0000000D

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606754   E8BFC5FBFF             call    005C2D18
00606759   83FB01                 cmp     ebx, +$01
0060675C   7409                   jz      00606767
0060675E   83FB04                 cmp     ebx, +$04
00606761   7404                   jz      00606767
00606763   33D2                   xor     edx, edx
00606765   EB02                   jmp     00606769
00606767   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606769   E87AC4FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
0060676E   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
00606774   8B802C030000           mov     eax, [eax+$032C]
0060677A   BA0E000000             mov     edx, $0000000E

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
0060677F   E894C5FBFF             call    005C2D18
00606784   83FB01                 cmp     ebx, +$01
00606787   7409                   jz      00606792
00606789   83FB04                 cmp     ebx, +$04
0060678C   7404                   jz      00606792
0060678E   33D2                   xor     edx, edx
00606790   EB02                   jmp     00606794
00606792   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606794   E84FC4FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
00606799   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
0060679F   8B802C030000           mov     eax, [eax+$032C]
006067A5   BA0F000000             mov     edx, $0000000F

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006067AA   E869C5FBFF             call    005C2D18
006067AF   83FB01                 cmp     ebx, +$01
006067B2   7409                   jz      006067BD
006067B4   83FB04                 cmp     ebx, +$04
006067B7   7404                   jz      006067BD
006067B9   33D2                   xor     edx, edx
006067BB   EB02                   jmp     006067BF
006067BD   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006067BF   E824C4FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
006067C4   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
006067CA   8B802C030000           mov     eax, [eax+$032C]
006067D0   BA10000000             mov     edx, $00000010

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006067D5   E83EC5FBFF             call    005C2D18
006067DA   83FB01                 cmp     ebx, +$01
006067DD   7409                   jz      006067E8
006067DF   83FB04                 cmp     ebx, +$04
006067E2   7404                   jz      006067E8
006067E4   33D2                   xor     edx, edx
006067E6   EB02                   jmp     006067EA
006067E8   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006067EA   E8F9C3FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
006067EF   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
006067F5   8B802C030000           mov     eax, [eax+$032C]
006067FB   BA11000000             mov     edx, $00000011

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606800   E813C5FBFF             call    005C2D18
00606805   83FB01                 cmp     ebx, +$01
00606808   7409                   jz      00606813
0060680A   83FB05                 cmp     ebx, +$05
0060680D   7404                   jz      00606813
0060680F   33D2                   xor     edx, edx
00606811   EB02                   jmp     00606815
00606813   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606815   E8CEC3FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
0060681A   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
00606820   8B802C030000           mov     eax, [eax+$032C]
00606826   BA12000000             mov     edx, $00000012

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
0060682B   E8E8C4FBFF             call    005C2D18
00606830   83FB01                 cmp     ebx, +$01
00606833   7409                   jz      0060683E
00606835   83FB05                 cmp     ebx, +$05
00606838   7404                   jz      0060683E
0060683A   33D2                   xor     edx, edx
0060683C   EB02                   jmp     00606840
0060683E   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606840   E8A3C3FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
00606845   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
0060684B   8B802C030000           mov     eax, [eax+$032C]
00606851   BA13000000             mov     edx, $00000013

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606856   E8BDC4FBFF             call    005C2D18
0060685B   83FB01                 cmp     ebx, +$01
0060685E   7409                   jz      00606869
00606860   83FB05                 cmp     ebx, +$05
00606863   7404                   jz      00606869
00606865   33D2                   xor     edx, edx
00606867   EB02                   jmp     0060686B
00606869   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
0060686B   E878C3FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
00606870   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
00606876   8B802C030000           mov     eax, [eax+$032C]
0060687C   BA14000000             mov     edx, $00000014

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606881   E892C4FBFF             call    005C2D18
00606886   83FB01                 cmp     ebx, +$01
00606889   7409                   jz      00606894
0060688B   83FB05                 cmp     ebx, +$05
0060688E   7404                   jz      00606894
00606890   33D2                   xor     edx, edx
00606892   EB02                   jmp     00606896
00606894   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606896   E84DC3FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
0060689B   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
006068A1   8B802C030000           mov     eax, [eax+$032C]
006068A7   BA15000000             mov     edx, $00000015

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006068AC   E867C4FBFF             call    005C2D18
006068B1   83FB01                 cmp     ebx, +$01
006068B4   7409                   jz      006068BF
006068B6   83FB05                 cmp     ebx, +$05
006068B9   7404                   jz      006068BF
006068BB   33D2                   xor     edx, edx
006068BD   EB02                   jmp     006068C1
006068BF   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006068C1   E822C3FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
006068C6   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
006068CC   8B802C030000           mov     eax, [eax+$032C]
006068D2   BA16000000             mov     edx, $00000016

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006068D7   E83CC4FBFF             call    005C2D18
006068DC   83FB01                 cmp     ebx, +$01
006068DF   7409                   jz      006068EA
006068E1   83FB06                 cmp     ebx, +$06
006068E4   7404                   jz      006068EA
006068E6   33D2                   xor     edx, edx
006068E8   EB02                   jmp     006068EC
006068EA   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006068EC   E8F7C2FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
006068F1   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
006068F7   8B802C030000           mov     eax, [eax+$032C]
006068FD   BA17000000             mov     edx, $00000017

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606902   E811C4FBFF             call    005C2D18
00606907   83FB01                 cmp     ebx, +$01
0060690A   7409                   jz      00606915
0060690C   83FB06                 cmp     ebx, +$06
0060690F   7404                   jz      00606915
00606911   33D2                   xor     edx, edx
00606913   EB02                   jmp     00606917
00606915   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606917   E8CCC2FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
0060691C   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
00606922   8B802C030000           mov     eax, [eax+$032C]
00606928   BA18000000             mov     edx, $00000018

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
0060692D   E8E6C3FBFF             call    005C2D18
00606932   83FB01                 cmp     ebx, +$01
00606935   7409                   jz      00606940
00606937   83FB06                 cmp     ebx, +$06
0060693A   7404                   jz      00606940
0060693C   33D2                   xor     edx, edx
0060693E   EB02                   jmp     00606942
00606940   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606942   E8A1C2FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
00606947   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
0060694D   8B802C030000           mov     eax, [eax+$032C]
00606953   BA19000000             mov     edx, $00000019

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606958   E8BBC3FBFF             call    005C2D18
0060695D   83FB01                 cmp     ebx, +$01
00606960   7409                   jz      0060696B
00606962   83FB06                 cmp     ebx, +$06
00606965   7404                   jz      0060696B
00606967   33D2                   xor     edx, edx
00606969   EB02                   jmp     0060696D
0060696B   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
0060696D   E876C2FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
00606972   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
00606978   8B802C030000           mov     eax, [eax+$032C]
0060697E   BA1A000000             mov     edx, $0000001A

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606983   E890C3FBFF             call    005C2D18
00606988   83FB01                 cmp     ebx, +$01
0060698B   7409                   jz      00606996
0060698D   83FB06                 cmp     ebx, +$06
00606990   7404                   jz      00606996
00606992   33D2                   xor     edx, edx
00606994   EB02                   jmp     00606998
00606996   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606998   E84BC2FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
0060699D   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
006069A3   8B802C030000           mov     eax, [eax+$032C]
006069A9   BA1B000000             mov     edx, $0000001B

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006069AE   E865C3FBFF             call    005C2D18
006069B3   83FB01                 cmp     ebx, +$01
006069B6   7409                   jz      006069C1
006069B8   83FB06                 cmp     ebx, +$06
006069BB   7404                   jz      006069C1
006069BD   33D2                   xor     edx, edx
006069BF   EB02                   jmp     006069C3
006069C1   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006069C3   E820C2FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
006069C8   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
006069CE   8B802C030000           mov     eax, [eax+$032C]
006069D4   BA1C000000             mov     edx, $0000001C

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006069D9   E83AC3FBFF             call    005C2D18
006069DE   83FB01                 cmp     ebx, +$01
006069E1   7409                   jz      006069EC
006069E3   83FB07                 cmp     ebx, +$07
006069E6   7404                   jz      006069EC
006069E8   33D2                   xor     edx, edx
006069EA   EB02                   jmp     006069EE
006069EC   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006069EE   E8F5C1FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
006069F3   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
006069F9   8B802C030000           mov     eax, [eax+$032C]
006069FF   BA1D000000             mov     edx, $0000001D

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606A04   E80FC3FBFF             call    005C2D18
00606A09   83FB01                 cmp     ebx, +$01
00606A0C   7409                   jz      00606A17
00606A0E   83FB07                 cmp     ebx, +$07
00606A11   7404                   jz      00606A17
00606A13   33D2                   xor     edx, edx
00606A15   EB02                   jmp     00606A19
00606A17   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606A19   E8CAC1FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
00606A1E   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
00606A24   8B802C030000           mov     eax, [eax+$032C]
00606A2A   BA1E000000             mov     edx, $0000001E

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606A2F   E8E4C2FBFF             call    005C2D18
00606A34   83FB01                 cmp     ebx, +$01
00606A37   7409                   jz      00606A42
00606A39   83FB07                 cmp     ebx, +$07
00606A3C   7404                   jz      00606A42
00606A3E   33D2                   xor     edx, edx
00606A40   EB02                   jmp     00606A44
00606A42   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606A44   E89FC1FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridAgente : TDBGrid
|
00606A49   8B8648050000           mov     eax, [esi+$0548]

* Reference to field TDBGrid.OFFS_032C
|
00606A4F   8B802C030000           mov     eax, [eax+$032C]
00606A55   BA1F000000             mov     edx, $0000001F

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606A5A   E8B9C2FBFF             call    005C2D18
00606A5F   83FB01                 cmp     ebx, +$01
00606A62   7409                   jz      00606A6D
00606A64   83FB07                 cmp     ebx, +$07
00606A67   7404                   jz      00606A6D
00606A69   33D2                   xor     edx, edx
00606A6B   EB02                   jmp     00606A6F
00606A6D   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606A6F   E874C1FBFF             call    005C2BE8
00606A74   33C0                   xor     eax, eax
00606A76   5A                     pop     edx
00606A77   59                     pop     ecx
00606A78   59                     pop     ecx
00606A79   648910                 mov     fs:[eax], edx

****** FINALLY
|

* Possible String Reference to: '^[Y]√ã¿UãÏj'
|
00606A7C   68916A6000             push    $00606A91
00606A81   8D45FC                 lea     eax, [ebp-$04]

|
00606A84   E81BEEDFFF             call    004058A4
00606A89   C3                     ret


|
00606A8A   E905E6DFFF             jmp     00405094
00606A8F   EBF0                   jmp     00606A81

****** END
|
00606A91   5E                     pop     esi
00606A92   5B                     pop     ebx
00606A93   59                     pop     ecx
00606A94   5D                     pop     ebp
00606A95   C3                     ret

*)
end;

procedure TfrmRelatorioPerformance.cmbVerRotaChange(Sender : TObject);
begin
(*
00607398   55                     push    ebp
00607399   8BEC                   mov     ebp, esp
0060739B   6A00                   push    $00
0060739D   53                     push    ebx
0060739E   56                     push    esi
0060739F   8BF0                   mov     esi, eax
006073A1   33C0                   xor     eax, eax
006073A3   55                     push    ebp
006073A4   684A786000             push    $0060784A

***** TRY
|
006073A9   64FF30                 push    dword ptr fs:[eax]
006073AC   648920                 mov     fs:[eax], esp
006073AF   8D55FC                 lea     edx, [ebp-$04]

* Reference to control TfrmRelatorioPerformance.cmbVerRota : TComboBox
|
006073B2   8B8688040000           mov     eax, [esi+$0488]

|
006073B8   E84387E5FF             call    0045FB00
006073BD   8B45FC                 mov     eax, [ebp-$04]

|
006073C0   E89703F7FF             call    0057775C
006073C5   8BD8                   mov     ebx, eax

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
006073C7   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
006073CD   8B802C030000           mov     eax, [eax+$032C]
006073D3   BA05000000             mov     edx, $00000005

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006073D8   E83BB9FBFF             call    005C2D18
006073DD   83FB01                 cmp     ebx, +$01
006073E0   740E                   jz      006073F0
006073E2   83FB02                 cmp     ebx, +$02
006073E5   7409                   jz      006073F0
006073E7   83FB07                 cmp     ebx, +$07
006073EA   7404                   jz      006073F0
006073EC   33D2                   xor     edx, edx
006073EE   EB02                   jmp     006073F2
006073F0   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006073F2   E8F1B7FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
006073F7   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
006073FD   8B802C030000           mov     eax, [eax+$032C]
00607403   BA06000000             mov     edx, $00000006

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607408   E80BB9FBFF             call    005C2D18
0060740D   83FB01                 cmp     ebx, +$01
00607410   740E                   jz      00607420
00607412   83FB02                 cmp     ebx, +$02
00607415   7409                   jz      00607420
00607417   83FB07                 cmp     ebx, +$07
0060741A   7404                   jz      00607420
0060741C   33D2                   xor     edx, edx
0060741E   EB02                   jmp     00607422
00607420   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607422   E8C1B7FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
00607427   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
0060742D   8B802C030000           mov     eax, [eax+$032C]
00607433   BA07000000             mov     edx, $00000007

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607438   E8DBB8FBFF             call    005C2D18
0060743D   83FB01                 cmp     ebx, +$01
00607440   740E                   jz      00607450
00607442   83FB02                 cmp     ebx, +$02
00607445   7409                   jz      00607450
00607447   83FB07                 cmp     ebx, +$07
0060744A   7404                   jz      00607450
0060744C   33D2                   xor     edx, edx
0060744E   EB02                   jmp     00607452
00607450   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607452   E891B7FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
00607457   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
0060745D   8B802C030000           mov     eax, [eax+$032C]
00607463   BA08000000             mov     edx, $00000008

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607468   E8ABB8FBFF             call    005C2D18
0060746D   83FB01                 cmp     ebx, +$01
00607470   7409                   jz      0060747B
00607472   83FB03                 cmp     ebx, +$03
00607475   7404                   jz      0060747B
00607477   33D2                   xor     edx, edx
00607479   EB02                   jmp     0060747D
0060747B   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
0060747D   E866B7FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
00607482   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
00607488   8B802C030000           mov     eax, [eax+$032C]
0060748E   BA09000000             mov     edx, $00000009

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607493   E880B8FBFF             call    005C2D18
00607498   83FB01                 cmp     ebx, +$01
0060749B   7409                   jz      006074A6
0060749D   83FB03                 cmp     ebx, +$03
006074A0   7404                   jz      006074A6
006074A2   33D2                   xor     edx, edx
006074A4   EB02                   jmp     006074A8
006074A6   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006074A8   E83BB7FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
006074AD   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
006074B3   8B802C030000           mov     eax, [eax+$032C]
006074B9   BA0A000000             mov     edx, $0000000A

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006074BE   E855B8FBFF             call    005C2D18
006074C3   83FB01                 cmp     ebx, +$01
006074C6   7409                   jz      006074D1
006074C8   83FB03                 cmp     ebx, +$03
006074CB   7404                   jz      006074D1
006074CD   33D2                   xor     edx, edx
006074CF   EB02                   jmp     006074D3
006074D1   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006074D3   E810B7FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
006074D8   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
006074DE   8B802C030000           mov     eax, [eax+$032C]
006074E4   BA0B000000             mov     edx, $0000000B

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006074E9   E82AB8FBFF             call    005C2D18
006074EE   83FB01                 cmp     ebx, +$01
006074F1   7409                   jz      006074FC
006074F3   83FB04                 cmp     ebx, +$04
006074F6   7404                   jz      006074FC
006074F8   33D2                   xor     edx, edx
006074FA   EB02                   jmp     006074FE
006074FC   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006074FE   E8E5B6FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
00607503   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
00607509   8B802C030000           mov     eax, [eax+$032C]
0060750F   BA0C000000             mov     edx, $0000000C

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607514   E8FFB7FBFF             call    005C2D18
00607519   83FB01                 cmp     ebx, +$01
0060751C   7409                   jz      00607527
0060751E   83FB04                 cmp     ebx, +$04
00607521   7404                   jz      00607527
00607523   33D2                   xor     edx, edx
00607525   EB02                   jmp     00607529
00607527   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607529   E8BAB6FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
0060752E   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
00607534   8B802C030000           mov     eax, [eax+$032C]
0060753A   BA0D000000             mov     edx, $0000000D

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
0060753F   E8D4B7FBFF             call    005C2D18
00607544   83FB01                 cmp     ebx, +$01
00607547   7409                   jz      00607552
00607549   83FB04                 cmp     ebx, +$04
0060754C   7404                   jz      00607552
0060754E   33D2                   xor     edx, edx
00607550   EB02                   jmp     00607554
00607552   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607554   E88FB6FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
00607559   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
0060755F   8B802C030000           mov     eax, [eax+$032C]
00607565   BA0E000000             mov     edx, $0000000E

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
0060756A   E8A9B7FBFF             call    005C2D18
0060756F   83FB01                 cmp     ebx, +$01
00607572   7409                   jz      0060757D
00607574   83FB04                 cmp     ebx, +$04
00607577   7404                   jz      0060757D
00607579   33D2                   xor     edx, edx
0060757B   EB02                   jmp     0060757F
0060757D   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
0060757F   E864B6FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
00607584   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
0060758A   8B802C030000           mov     eax, [eax+$032C]
00607590   BA0F000000             mov     edx, $0000000F

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607595   E87EB7FBFF             call    005C2D18
0060759A   83FB01                 cmp     ebx, +$01
0060759D   7409                   jz      006075A8
0060759F   83FB04                 cmp     ebx, +$04
006075A2   7404                   jz      006075A8
006075A4   33D2                   xor     edx, edx
006075A6   EB02                   jmp     006075AA
006075A8   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006075AA   E839B6FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
006075AF   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
006075B5   8B802C030000           mov     eax, [eax+$032C]
006075BB   BA10000000             mov     edx, $00000010

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006075C0   E853B7FBFF             call    005C2D18
006075C5   83FB01                 cmp     ebx, +$01
006075C8   7409                   jz      006075D3
006075CA   83FB05                 cmp     ebx, +$05
006075CD   7404                   jz      006075D3
006075CF   33D2                   xor     edx, edx
006075D1   EB02                   jmp     006075D5
006075D3   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006075D5   E80EB6FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
006075DA   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
006075E0   8B802C030000           mov     eax, [eax+$032C]
006075E6   BA11000000             mov     edx, $00000011

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006075EB   E828B7FBFF             call    005C2D18
006075F0   83FB01                 cmp     ebx, +$01
006075F3   7409                   jz      006075FE
006075F5   83FB05                 cmp     ebx, +$05
006075F8   7404                   jz      006075FE
006075FA   33D2                   xor     edx, edx
006075FC   EB02                   jmp     00607600
006075FE   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607600   E8E3B5FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
00607605   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
0060760B   8B802C030000           mov     eax, [eax+$032C]
00607611   BA12000000             mov     edx, $00000012

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607616   E8FDB6FBFF             call    005C2D18
0060761B   83FB01                 cmp     ebx, +$01
0060761E   7409                   jz      00607629
00607620   83FB05                 cmp     ebx, +$05
00607623   7404                   jz      00607629
00607625   33D2                   xor     edx, edx
00607627   EB02                   jmp     0060762B
00607629   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
0060762B   E8B8B5FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
00607630   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
00607636   8B802C030000           mov     eax, [eax+$032C]
0060763C   BA13000000             mov     edx, $00000013

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607641   E8D2B6FBFF             call    005C2D18
00607646   83FB01                 cmp     ebx, +$01
00607649   7409                   jz      00607654
0060764B   83FB05                 cmp     ebx, +$05
0060764E   7404                   jz      00607654
00607650   33D2                   xor     edx, edx
00607652   EB02                   jmp     00607656
00607654   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607656   E88DB5FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
0060765B   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
00607661   8B802C030000           mov     eax, [eax+$032C]
00607667   BA14000000             mov     edx, $00000014

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
0060766C   E8A7B6FBFF             call    005C2D18
00607671   83FB01                 cmp     ebx, +$01
00607674   7409                   jz      0060767F
00607676   83FB05                 cmp     ebx, +$05
00607679   7404                   jz      0060767F
0060767B   33D2                   xor     edx, edx
0060767D   EB02                   jmp     00607681
0060767F   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607681   E862B5FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
00607686   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
0060768C   8B802C030000           mov     eax, [eax+$032C]
00607692   BA15000000             mov     edx, $00000015

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607697   E87CB6FBFF             call    005C2D18
0060769C   83FB01                 cmp     ebx, +$01
0060769F   7409                   jz      006076AA
006076A1   83FB06                 cmp     ebx, +$06
006076A4   7404                   jz      006076AA
006076A6   33D2                   xor     edx, edx
006076A8   EB02                   jmp     006076AC
006076AA   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006076AC   E837B5FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
006076B1   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
006076B7   8B802C030000           mov     eax, [eax+$032C]
006076BD   BA16000000             mov     edx, $00000016

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006076C2   E851B6FBFF             call    005C2D18
006076C7   83FB01                 cmp     ebx, +$01
006076CA   7409                   jz      006076D5
006076CC   83FB06                 cmp     ebx, +$06
006076CF   7404                   jz      006076D5
006076D1   33D2                   xor     edx, edx
006076D3   EB02                   jmp     006076D7
006076D5   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006076D7   E80CB5FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
006076DC   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
006076E2   8B802C030000           mov     eax, [eax+$032C]
006076E8   BA17000000             mov     edx, $00000017

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006076ED   E826B6FBFF             call    005C2D18
006076F2   83FB01                 cmp     ebx, +$01
006076F5   7409                   jz      00607700
006076F7   83FB06                 cmp     ebx, +$06
006076FA   7404                   jz      00607700
006076FC   33D2                   xor     edx, edx
006076FE   EB02                   jmp     00607702
00607700   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607702   E8E1B4FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
00607707   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
0060770D   8B802C030000           mov     eax, [eax+$032C]
00607713   BA18000000             mov     edx, $00000018

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607718   E8FBB5FBFF             call    005C2D18
0060771D   83FB01                 cmp     ebx, +$01
00607720   7409                   jz      0060772B
00607722   83FB06                 cmp     ebx, +$06
00607725   7404                   jz      0060772B
00607727   33D2                   xor     edx, edx
00607729   EB02                   jmp     0060772D
0060772B   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
0060772D   E8B6B4FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
00607732   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
00607738   8B802C030000           mov     eax, [eax+$032C]
0060773E   BA19000000             mov     edx, $00000019

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607743   E8D0B5FBFF             call    005C2D18
00607748   83FB01                 cmp     ebx, +$01
0060774B   7409                   jz      00607756
0060774D   83FB06                 cmp     ebx, +$06
00607750   7404                   jz      00607756
00607752   33D2                   xor     edx, edx
00607754   EB02                   jmp     00607758
00607756   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607758   E88BB4FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
0060775D   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
00607763   8B802C030000           mov     eax, [eax+$032C]
00607769   BA1A000000             mov     edx, $0000001A

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
0060776E   E8A5B5FBFF             call    005C2D18
00607773   83FB01                 cmp     ebx, +$01
00607776   7409                   jz      00607781
00607778   83FB06                 cmp     ebx, +$06
0060777B   7404                   jz      00607781
0060777D   33D2                   xor     edx, edx
0060777F   EB02                   jmp     00607783
00607781   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607783   E860B4FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
00607788   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
0060778E   8B802C030000           mov     eax, [eax+$032C]
00607794   BA1B000000             mov     edx, $0000001B

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00607799   E87AB5FBFF             call    005C2D18
0060779E   83FB01                 cmp     ebx, +$01
006077A1   7409                   jz      006077AC
006077A3   83FB07                 cmp     ebx, +$07
006077A6   7404                   jz      006077AC
006077A8   33D2                   xor     edx, edx
006077AA   EB02                   jmp     006077AE
006077AC   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006077AE   E835B4FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
006077B3   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
006077B9   8B802C030000           mov     eax, [eax+$032C]
006077BF   BA1C000000             mov     edx, $0000001C

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006077C4   E84FB5FBFF             call    005C2D18
006077C9   83FB01                 cmp     ebx, +$01
006077CC   7409                   jz      006077D7
006077CE   83FB07                 cmp     ebx, +$07
006077D1   7404                   jz      006077D7
006077D3   33D2                   xor     edx, edx
006077D5   EB02                   jmp     006077D9
006077D7   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
006077D9   E80AB4FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
006077DE   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
006077E4   8B802C030000           mov     eax, [eax+$032C]
006077EA   BA1D000000             mov     edx, $0000001D

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
006077EF   E824B5FBFF             call    005C2D18
006077F4   83FB01                 cmp     ebx, +$01
006077F7   7409                   jz      00607802
006077F9   83FB07                 cmp     ebx, +$07
006077FC   7404                   jz      00607802
006077FE   33D2                   xor     edx, edx
00607800   EB02                   jmp     00607804
00607802   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00607804   E8DFB3FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridRota : TDBGrid
|
00607809   8B8644050000           mov     eax, [esi+$0544]

* Reference to field TDBGrid.OFFS_032C
|
0060780F   8B802C030000           mov     eax, [eax+$032C]
00607815   BA1E000000             mov     edx, $0000001E

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
0060781A   E8F9B4FBFF             call    005C2D18
0060781F   83FB01                 cmp     ebx, +$01
00607822   7409                   jz      0060782D
00607824   83FB07                 cmp     ebx, +$07
00607827   7404                   jz      0060782D
00607829   33D2                   xor     edx, edx
0060782B   EB02                   jmp     0060782F
0060782D   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
0060782F   E8B4B3FBFF             call    005C2BE8
00607834   33C0                   xor     eax, eax
00607836   5A                     pop     edx
00607837   59                     pop     ecx
00607838   59                     pop     ecx
00607839   648910                 mov     fs:[eax], edx

****** FINALLY
|
0060783C   6851786000             push    $00607851
00607841   8D45FC                 lea     eax, [ebp-$04]

|
00607844   E85BE0DFFF             call    004058A4
00607849   C3                     ret


|
0060784A   E945D8DFFF             jmp     00405094
0060784F   EBF0                   jmp     00607841

****** END
|
00607851   5E                     pop     esi
00607852   5B                     pop     ebx
00607853   59                     pop     ecx
00607854   5D                     pop     ebp
00607855   C3                     ret

*)
end;

procedure TfrmRelatorioPerformance.cmbVerReferenciaChange(Sender : TObject);
begin
(*
00606A98   55                     push    ebp
00606A99   8BEC                   mov     ebp, esp
00606A9B   6A00                   push    $00
00606A9D   53                     push    ebx
00606A9E   56                     push    esi
00606A9F   8BF0                   mov     esi, eax
00606AA1   33C0                   xor     eax, eax
00606AA3   55                     push    ebp

* Possible String Reference to: 'ÈE·ﬂˇÎ^[Y]√ã¿UãÏj'
|
00606AA4   684A6F6000             push    $00606F4A

***** TRY
|
00606AA9   64FF30                 push    dword ptr fs:[eax]
00606AAC   648920                 mov     fs:[eax], esp
00606AAF   8D55FC                 lea     edx, [ebp-$04]

* Reference to control TfrmRelatorioPerformance.cmbVerReferencia : TComboBox
|
00606AB2   8B865C040000           mov     eax, [esi+$045C]

|
00606AB8   E84390E5FF             call    0045FB00
00606ABD   8B45FC                 mov     eax, [ebp-$04]

|
00606AC0   E8970CF7FF             call    0057775C
00606AC5   8BD8                   mov     ebx, eax

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606AC7   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606ACD   8B802C030000           mov     eax, [eax+$032C]
00606AD3   BA05000000             mov     edx, $00000005

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606AD8   E83BC2FBFF             call    005C2D18
00606ADD   83FB01                 cmp     ebx, +$01
00606AE0   740E                   jz      00606AF0
00606AE2   83FB02                 cmp     ebx, +$02
00606AE5   7409                   jz      00606AF0
00606AE7   83FB07                 cmp     ebx, +$07
00606AEA   7404                   jz      00606AF0
00606AEC   33D2                   xor     edx, edx
00606AEE   EB02                   jmp     00606AF2
00606AF0   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606AF2   E8F1C0FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606AF7   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606AFD   8B802C030000           mov     eax, [eax+$032C]
00606B03   BA06000000             mov     edx, $00000006

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606B08   E80BC2FBFF             call    005C2D18
00606B0D   83FB01                 cmp     ebx, +$01
00606B10   740E                   jz      00606B20
00606B12   83FB02                 cmp     ebx, +$02
00606B15   7409                   jz      00606B20
00606B17   83FB07                 cmp     ebx, +$07
00606B1A   7404                   jz      00606B20
00606B1C   33D2                   xor     edx, edx
00606B1E   EB02                   jmp     00606B22
00606B20   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606B22   E8C1C0FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606B27   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606B2D   8B802C030000           mov     eax, [eax+$032C]
00606B33   BA07000000             mov     edx, $00000007

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606B38   E8DBC1FBFF             call    005C2D18
00606B3D   83FB01                 cmp     ebx, +$01
00606B40   740E                   jz      00606B50
00606B42   83FB02                 cmp     ebx, +$02
00606B45   7409                   jz      00606B50
00606B47   83FB07                 cmp     ebx, +$07
00606B4A   7404                   jz      00606B50
00606B4C   33D2                   xor     edx, edx
00606B4E   EB02                   jmp     00606B52
00606B50   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606B52   E891C0FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606B57   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606B5D   8B802C030000           mov     eax, [eax+$032C]
00606B63   BA08000000             mov     edx, $00000008

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606B68   E8ABC1FBFF             call    005C2D18
00606B6D   83FB01                 cmp     ebx, +$01
00606B70   7409                   jz      00606B7B
00606B72   83FB03                 cmp     ebx, +$03
00606B75   7404                   jz      00606B7B
00606B77   33D2                   xor     edx, edx
00606B79   EB02                   jmp     00606B7D
00606B7B   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606B7D   E866C0FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606B82   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606B88   8B802C030000           mov     eax, [eax+$032C]
00606B8E   BA09000000             mov     edx, $00000009

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606B93   E880C1FBFF             call    005C2D18
00606B98   83FB01                 cmp     ebx, +$01
00606B9B   7409                   jz      00606BA6
00606B9D   83FB03                 cmp     ebx, +$03
00606BA0   7404                   jz      00606BA6
00606BA2   33D2                   xor     edx, edx
00606BA4   EB02                   jmp     00606BA8
00606BA6   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606BA8   E83BC0FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606BAD   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606BB3   8B802C030000           mov     eax, [eax+$032C]
00606BB9   BA0A000000             mov     edx, $0000000A

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606BBE   E855C1FBFF             call    005C2D18
00606BC3   83FB01                 cmp     ebx, +$01
00606BC6   7409                   jz      00606BD1
00606BC8   83FB03                 cmp     ebx, +$03
00606BCB   7404                   jz      00606BD1
00606BCD   33D2                   xor     edx, edx
00606BCF   EB02                   jmp     00606BD3
00606BD1   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606BD3   E810C0FBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606BD8   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606BDE   8B802C030000           mov     eax, [eax+$032C]
00606BE4   BA0B000000             mov     edx, $0000000B

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606BE9   E82AC1FBFF             call    005C2D18
00606BEE   83FB01                 cmp     ebx, +$01
00606BF1   7409                   jz      00606BFC
00606BF3   83FB04                 cmp     ebx, +$04
00606BF6   7404                   jz      00606BFC
00606BF8   33D2                   xor     edx, edx
00606BFA   EB02                   jmp     00606BFE
00606BFC   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606BFE   E8E5BFFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606C03   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606C09   8B802C030000           mov     eax, [eax+$032C]
00606C0F   BA0C000000             mov     edx, $0000000C

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606C14   E8FFC0FBFF             call    005C2D18
00606C19   83FB01                 cmp     ebx, +$01
00606C1C   7409                   jz      00606C27
00606C1E   83FB04                 cmp     ebx, +$04
00606C21   7404                   jz      00606C27
00606C23   33D2                   xor     edx, edx
00606C25   EB02                   jmp     00606C29
00606C27   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606C29   E8BABFFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606C2E   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606C34   8B802C030000           mov     eax, [eax+$032C]
00606C3A   BA0D000000             mov     edx, $0000000D

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606C3F   E8D4C0FBFF             call    005C2D18
00606C44   83FB01                 cmp     ebx, +$01
00606C47   7409                   jz      00606C52
00606C49   83FB04                 cmp     ebx, +$04
00606C4C   7404                   jz      00606C52
00606C4E   33D2                   xor     edx, edx
00606C50   EB02                   jmp     00606C54
00606C52   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606C54   E88FBFFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606C59   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606C5F   8B802C030000           mov     eax, [eax+$032C]
00606C65   BA0E000000             mov     edx, $0000000E

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606C6A   E8A9C0FBFF             call    005C2D18
00606C6F   83FB01                 cmp     ebx, +$01
00606C72   7409                   jz      00606C7D
00606C74   83FB04                 cmp     ebx, +$04
00606C77   7404                   jz      00606C7D
00606C79   33D2                   xor     edx, edx
00606C7B   EB02                   jmp     00606C7F
00606C7D   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606C7F   E864BFFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606C84   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606C8A   8B802C030000           mov     eax, [eax+$032C]
00606C90   BA0F000000             mov     edx, $0000000F

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606C95   E87EC0FBFF             call    005C2D18
00606C9A   83FB01                 cmp     ebx, +$01
00606C9D   7409                   jz      00606CA8
00606C9F   83FB04                 cmp     ebx, +$04
00606CA2   7404                   jz      00606CA8
00606CA4   33D2                   xor     edx, edx
00606CA6   EB02                   jmp     00606CAA
00606CA8   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606CAA   E839BFFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606CAF   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606CB5   8B802C030000           mov     eax, [eax+$032C]
00606CBB   BA10000000             mov     edx, $00000010

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606CC0   E853C0FBFF             call    005C2D18
00606CC5   83FB01                 cmp     ebx, +$01
00606CC8   7409                   jz      00606CD3
00606CCA   83FB05                 cmp     ebx, +$05
00606CCD   7404                   jz      00606CD3
00606CCF   33D2                   xor     edx, edx
00606CD1   EB02                   jmp     00606CD5
00606CD3   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606CD5   E80EBFFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606CDA   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606CE0   8B802C030000           mov     eax, [eax+$032C]
00606CE6   BA11000000             mov     edx, $00000011

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606CEB   E828C0FBFF             call    005C2D18
00606CF0   83FB01                 cmp     ebx, +$01
00606CF3   7409                   jz      00606CFE
00606CF5   83FB05                 cmp     ebx, +$05
00606CF8   7404                   jz      00606CFE
00606CFA   33D2                   xor     edx, edx
00606CFC   EB02                   jmp     00606D00
00606CFE   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606D00   E8E3BEFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606D05   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606D0B   8B802C030000           mov     eax, [eax+$032C]
00606D11   BA12000000             mov     edx, $00000012

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606D16   E8FDBFFBFF             call    005C2D18
00606D1B   83FB01                 cmp     ebx, +$01
00606D1E   7409                   jz      00606D29
00606D20   83FB05                 cmp     ebx, +$05
00606D23   7404                   jz      00606D29
00606D25   33D2                   xor     edx, edx
00606D27   EB02                   jmp     00606D2B
00606D29   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606D2B   E8B8BEFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606D30   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606D36   8B802C030000           mov     eax, [eax+$032C]
00606D3C   BA13000000             mov     edx, $00000013

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606D41   E8D2BFFBFF             call    005C2D18
00606D46   83FB01                 cmp     ebx, +$01
00606D49   7409                   jz      00606D54
00606D4B   83FB05                 cmp     ebx, +$05
00606D4E   7404                   jz      00606D54
00606D50   33D2                   xor     edx, edx
00606D52   EB02                   jmp     00606D56
00606D54   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606D56   E88DBEFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606D5B   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606D61   8B802C030000           mov     eax, [eax+$032C]
00606D67   BA14000000             mov     edx, $00000014

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606D6C   E8A7BFFBFF             call    005C2D18
00606D71   83FB01                 cmp     ebx, +$01
00606D74   7409                   jz      00606D7F
00606D76   83FB05                 cmp     ebx, +$05
00606D79   7404                   jz      00606D7F
00606D7B   33D2                   xor     edx, edx
00606D7D   EB02                   jmp     00606D81
00606D7F   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606D81   E862BEFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606D86   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606D8C   8B802C030000           mov     eax, [eax+$032C]
00606D92   BA15000000             mov     edx, $00000015

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606D97   E87CBFFBFF             call    005C2D18
00606D9C   83FB01                 cmp     ebx, +$01
00606D9F   7409                   jz      00606DAA
00606DA1   83FB06                 cmp     ebx, +$06
00606DA4   7404                   jz      00606DAA
00606DA6   33D2                   xor     edx, edx
00606DA8   EB02                   jmp     00606DAC
00606DAA   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606DAC   E837BEFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606DB1   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606DB7   8B802C030000           mov     eax, [eax+$032C]
00606DBD   BA16000000             mov     edx, $00000016

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606DC2   E851BFFBFF             call    005C2D18
00606DC7   83FB01                 cmp     ebx, +$01
00606DCA   7409                   jz      00606DD5
00606DCC   83FB06                 cmp     ebx, +$06
00606DCF   7404                   jz      00606DD5
00606DD1   33D2                   xor     edx, edx
00606DD3   EB02                   jmp     00606DD7
00606DD5   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606DD7   E80CBEFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606DDC   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606DE2   8B802C030000           mov     eax, [eax+$032C]
00606DE8   BA17000000             mov     edx, $00000017

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606DED   E826BFFBFF             call    005C2D18
00606DF2   83FB01                 cmp     ebx, +$01
00606DF5   7409                   jz      00606E00
00606DF7   83FB06                 cmp     ebx, +$06
00606DFA   7404                   jz      00606E00
00606DFC   33D2                   xor     edx, edx
00606DFE   EB02                   jmp     00606E02
00606E00   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606E02   E8E1BDFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606E07   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606E0D   8B802C030000           mov     eax, [eax+$032C]
00606E13   BA18000000             mov     edx, $00000018

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606E18   E8FBBEFBFF             call    005C2D18
00606E1D   83FB01                 cmp     ebx, +$01
00606E20   7409                   jz      00606E2B
00606E22   83FB06                 cmp     ebx, +$06
00606E25   7404                   jz      00606E2B
00606E27   33D2                   xor     edx, edx
00606E29   EB02                   jmp     00606E2D
00606E2B   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606E2D   E8B6BDFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606E32   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606E38   8B802C030000           mov     eax, [eax+$032C]
00606E3E   BA19000000             mov     edx, $00000019

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606E43   E8D0BEFBFF             call    005C2D18
00606E48   83FB01                 cmp     ebx, +$01
00606E4B   7409                   jz      00606E56
00606E4D   83FB06                 cmp     ebx, +$06
00606E50   7404                   jz      00606E56
00606E52   33D2                   xor     edx, edx
00606E54   EB02                   jmp     00606E58
00606E56   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606E58   E88BBDFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606E5D   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606E63   8B802C030000           mov     eax, [eax+$032C]
00606E69   BA1A000000             mov     edx, $0000001A

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606E6E   E8A5BEFBFF             call    005C2D18
00606E73   83FB01                 cmp     ebx, +$01
00606E76   7409                   jz      00606E81
00606E78   83FB06                 cmp     ebx, +$06
00606E7B   7404                   jz      00606E81
00606E7D   33D2                   xor     edx, edx
00606E7F   EB02                   jmp     00606E83
00606E81   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606E83   E860BDFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606E88   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606E8E   8B802C030000           mov     eax, [eax+$032C]
00606E94   BA1B000000             mov     edx, $0000001B

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606E99   E87ABEFBFF             call    005C2D18
00606E9E   83FB01                 cmp     ebx, +$01
00606EA1   7409                   jz      00606EAC
00606EA3   83FB07                 cmp     ebx, +$07
00606EA6   7404                   jz      00606EAC
00606EA8   33D2                   xor     edx, edx
00606EAA   EB02                   jmp     00606EAE
00606EAC   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606EAE   E835BDFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606EB3   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606EB9   8B802C030000           mov     eax, [eax+$032C]
00606EBF   BA1C000000             mov     edx, $0000001C

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606EC4   E84FBEFBFF             call    005C2D18
00606EC9   83FB01                 cmp     ebx, +$01
00606ECC   7409                   jz      00606ED7
00606ECE   83FB07                 cmp     ebx, +$07
00606ED1   7404                   jz      00606ED7
00606ED3   33D2                   xor     edx, edx
00606ED5   EB02                   jmp     00606ED9
00606ED7   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606ED9   E80ABDFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606EDE   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606EE4   8B802C030000           mov     eax, [eax+$032C]
00606EEA   BA1D000000             mov     edx, $0000001D

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606EEF   E824BEFBFF             call    005C2D18
00606EF4   83FB01                 cmp     ebx, +$01
00606EF7   7409                   jz      00606F02
00606EF9   83FB07                 cmp     ebx, +$07
00606EFC   7404                   jz      00606F02
00606EFE   33D2                   xor     edx, edx
00606F00   EB02                   jmp     00606F04
00606F02   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606F04   E8DFBCFBFF             call    005C2BE8

* Reference to control TfrmRelatorioPerformance.DBGridReferencia : TDBGrid
|
00606F09   8B8644040000           mov     eax, [esi+$0444]

* Reference to field TDBGrid.OFFS_032C
|
00606F0F   8B802C030000           mov     eax, [eax+$032C]
00606F15   BA1E000000             mov     edx, $0000001E

* Reference to : TDBGridInplaceEdit._PROC_005C2D18()
|
00606F1A   E8F9BDFBFF             call    005C2D18
00606F1F   83FB01                 cmp     ebx, +$01
00606F22   7409                   jz      00606F2D
00606F24   83FB07                 cmp     ebx, +$07
00606F27   7404                   jz      00606F2D
00606F29   33D2                   xor     edx, edx
00606F2B   EB02                   jmp     00606F2F
00606F2D   B201                   mov     dl, $01

* Reference to : TDBGridInplaceEdit._PROC_005C2BE8()
|
00606F2F   E8B4BCFBFF             call    005C2BE8
00606F34   33C0                   xor     eax, eax
00606F36   5A                     pop     edx
00606F37   59                     pop     ecx
00606F38   59                     pop     ecx
00606F39   648910                 mov     fs:[eax], edx

****** FINALLY
|

* Possible String Reference to: '^[Y]√ã¿UãÏj'
|
00606F3C   68516F6000             push    $00606F51
00606F41   8D45FC                 lea     eax, [ebp-$04]

|
00606F44   E85BE9DFFF             call    004058A4
00606F49   C3                     ret


|
00606F4A   E945E1DFFF             jmp     00405094
00606F4F   EBF0                   jmp     00606F41

****** END
|
00606F51   5E                     pop     esi
00606F52   5B                     pop     ebx
00606F53   59                     pop     ecx
00606F54   5D                     pop     ebp
00606F55   C3                     ret

*)
end;

procedure TfrmRelatorioPerformance.sbtnPesquisarClick(Sender : TObject);
begin
(*
00607CE8   55                     push    ebp
00607CE9   8BEC                   mov     ebp, esp
00607CEB   B917000000             mov     ecx, $00000017
00607CF0   6A00                   push    $00
00607CF2   6A00                   push    $00
00607CF4   49                     dec     ecx
00607CF5   75F9                   jnz     00607CF0
00607CF7   53                     push    ebx
00607CF8   56                     push    esi
00607CF9   57                     push    edi
00607CFA   8BFA                   mov     edi, edx
00607CFC   8BF0                   mov     esi, eax
00607CFE   33C0                   xor     eax, eax
00607D00   55                     push    ebp
00607D01   68EB896000             push    $006089EB

***** TRY
|
00607D06   64FF30                 push    dword ptr fs:[eax]
00607D09   648920                 mov     fs:[eax], esp
00607D0C   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioPerformance.sbtnImprimir : TSpeedButton
|
00607D0E   8B8624050000           mov     eax, [esi+$0524]

|
00607D14   E8077DE5FF             call    0045FA20

* Reference to control TfrmRelatorioPerformance.rbtHorario : TRadioButton
|
00607D19   8B86A4040000           mov     eax, [esi+$04A4]
00607D1F   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00607D21   FF92D8000000           call    dword ptr [edx+$00D8]
00607D27   84C0                   test    al, al
00607D29   0F8535040000           jnz     00608164

* Reference to control TfrmRelatorioPerformance.rbtReferenciaRecepcao : TRadioButton
|
00607D2F   8B8690050000           mov     eax, [esi+$0590]
00607D35   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00607D37   FF92D8000000           call    dword ptr [edx+$00D8]
00607D3D   84C0                   test    al, al
00607D3F   0F851F040000           jnz     00608164
00607D45   8D45FC                 lea     eax, [ebp-$04]

* Possible String Reference to: 'Performace dos Agentes'
|
00607D48   BA048A6000             mov     edx, $00608A04

|
00607D4D   E8EADBDFFF             call    0040593C
00607D52   8D45F8                 lea     eax, [ebp-$08]

|
00607D55   E84ADBDFFF             call    004058A4

* Reference to control TfrmRelatorioPerformance.rbtReferencia : TRadioButton
|
00607D5A   8B868C030000           mov     eax, [esi+$038C]
00607D60   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00607D62   FF92D8000000           call    dword ptr [edx+$00D8]
00607D68   84C0                   test    al, al
00607D6A   744B                   jz      00607DB7
00607D6C   8D45FC                 lea     eax, [ebp-$04]

* Possible String Reference to: 'Performace dos Agentes na ReferÍnci
|                                a'
|
00607D6F   BA248A6000             mov     edx, $00608A24

|
00607D74   E8C3DBDFFF             call    0040593C

* Possible String Reference to: 'ReferÍncia: '
|
00607D79   68548A6000             push    $00608A54
00607D7E   8D55E4                 lea     edx, [ebp-$1C]

* Reference to control TfrmRelatorioPerformance.cmbReferencia : TComboBox
|
00607D81   8B86A4030000           mov     eax, [esi+$03A4]

|
00607D87   E8747DE5FF             call    0045FB00
00607D8C   FF75E4                 push    dword ptr [ebp-$1C]

* Possible String Reference to: ' - Grupo: '
|
00607D8F   686C8A6000             push    $00608A6C
00607D94   8D55E0                 lea     edx, [ebp-$20]

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
00607D97   8B869C030000           mov     eax, [esi+$039C]

|
00607D9D   E85E7DE5FF             call    0045FB00
00607DA2   FF75E0                 push    dword ptr [ebp-$20]
00607DA5   8D45F8                 lea     eax, [ebp-$08]
00607DA8   BA04000000             mov     edx, $00000004

|
00607DAD   E876DEDFFF             call    00405C28
00607DB2   E997000000             jmp     00607E4E

* Reference to control TfrmRelatorioPerformance.rbtRota : TRadioButton
|
00607DB7   8B8690030000           mov     eax, [esi+$0390]
00607DBD   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00607DBF   FF92D8000000           call    dword ptr [edx+$00D8]
00607DC5   84C0                   test    al, al
00607DC7   7448                   jz      00607E11
00607DC9   8D45FC                 lea     eax, [ebp-$04]

* Possible String Reference to: 'Performace dos Agentes - HistÛrico 
|                                da Rota nos ˙ltimos 06 meses'
|
00607DCC   BA808A6000             mov     edx, $00608A80

|
00607DD1   E866DBDFFF             call    0040593C

* Possible String Reference to: 'Grupo: '
|
00607DD6   68C88A6000             push    $00608AC8
00607DDB   8D55DC                 lea     edx, [ebp-$24]

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
00607DDE   8B869C030000           mov     eax, [esi+$039C]

|
00607DE4   E8177DE5FF             call    0045FB00
00607DE9   FF75DC                 push    dword ptr [ebp-$24]

* Possible String Reference to: ' - Rota: '
|
00607DEC   68D88A6000             push    $00608AD8
00607DF1   8D55D8                 lea     edx, [ebp-$28]

* Reference to control TfrmRelatorioPerformance.cmbRota : TComboBox
|
00607DF4   8B86B0030000           mov     eax, [esi+$03B0]

|
00607DFA   E8017DE5FF             call    0045FB00
00607DFF   FF75D8                 push    dword ptr [ebp-$28]
00607E02   8D45F8                 lea     eax, [ebp-$08]
00607E05   BA04000000             mov     edx, $00000004

|
00607E0A   E819DEDFFF             call    00405C28
00607E0F   EB3D                   jmp     00607E4E

* Reference to control TfrmRelatorioPerformance.rbtAgente : TRadioButton
|
00607E11   8B8694030000           mov     eax, [esi+$0394]
00607E17   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00607E19   FF92D8000000           call    dword ptr [edx+$00D8]
00607E1F   84C0                   test    al, al
00607E21   742B                   jz      00607E4E
00607E23   8D45FC                 lea     eax, [ebp-$04]

* Possible String Reference to: 'Performace dos Agentes - HistÛrico 
|                                do Agente nos ˙ltimos 06 meses'
|
00607E26   BAEC8A6000             mov     edx, $00608AEC

|
00607E2B   E80CDBDFFF             call    0040593C
00607E30   8D55D4                 lea     edx, [ebp-$2C]

* Reference to control TfrmRelatorioPerformance.cmbAgente : TComboBox
|
00607E33   8B86B8030000           mov     eax, [esi+$03B8]

|
00607E39   E8C27CE5FF             call    0045FB00
00607E3E   8B4DD4                 mov     ecx, [ebp-$2C]
00607E41   8D45F8                 lea     eax, [ebp-$08]

* Possible String Reference to: 'Agente comercial: '
|
00607E44   BA388B6000             mov     edx, $00608B38

|
00607E49   E866DDDFFF             call    00405BB4

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607E4E   8B86C8030000           mov     eax, [esi+$03C8]

|
00607E54   E8B766E9FF             call    0049E510

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607E59   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607E5F   8B8048020000           mov     eax, [eax+$0248]
00607E65   8B10                   mov     edx, [eax]
00607E67   FF5244                 call    dword ptr [edx+$44]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607E6A   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607E70   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'select md_referencia, md_grupo, md_
|                                rota, '
|
00607E76   BA548B6000             mov     edx, $00608B54
00607E7B   8B08                   mov     ecx, [eax]
00607E7D   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607E80   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607E86   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       case  when md_agente < 10 th
|                                en '00' '
|
00607E8C   BA888B6000             mov     edx, $00608B88
00607E91   8B08                   mov     ecx, [eax]
00607E93   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607E96   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607E9C   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '             when md_agente < 100 t
|                                hen '0' '
|
00607EA2   BABC8B6000             mov     edx, $00608BBC
00607EA7   8B08                   mov     ecx, [eax]
00607EA9   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607EAC   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607EB2   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '             else '' '
|
00607EB8   BAF08B6000             mov     edx, $00608BF0
00607EBD   8B08                   mov     ecx, [eax]
00607EBF   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607EC2   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607EC8   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       end + rtrim( convert( char, 
|                                md_agente) ) + ' ∑ ' + ag_nome as a
|                                gente, '
|
00607ECE   BA108C6000             mov     edx, $00608C10
00607ED3   8B08                   mov     ecx, [eax]
00607ED5   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607ED8   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607EDE   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       md_data_leitura,  '
|
00607EE4   BA688C6000             mov     edx, $00608C68
00607EE9   8B08                   mov     ecx, [eax]
00607EEB   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607EEE   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607EF4   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       md_hora_inicio, md_hora_fim,
|                                  '
|
00607EFA   BA8C8C6000             mov     edx, $00608C8C
00607EFF   8B08                   mov     ecx, [eax]
00607F01   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607F04   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607F0A   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       md_ligacoes, md_leitura_camp
|                                o, md_analise,  '
|
00607F10   BABC8C6000             mov     edx, $00608CBC
00607F15   8B08                   mov     ecx, [eax]
00607F17   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607F1A   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607F20   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       md_faturado_normal, md_fatur
|                                ado_media, md_faturado_minima,  '
|
00607F26   BAF88C6000             mov     edx, $00608CF8
00607F2B   8B08                   mov     ecx, [eax]
00607F2D   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607F30   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607F36   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       md_emitidas, md_emitidas_2_v
|                                ezes, md_nao_emitidas,  '
|
00607F3C   BA448D6000             mov     edx, $00608D44
00607F41   8B08                   mov     ecx, [eax]
00607F43   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607F46   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607F4C   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       md_entrega_mao, md_entrega_v
|                                isinho, md_entrega_porta,  '
|
00607F52   BA888D6000             mov     edx, $00608D88
00607F57   8B08                   mov     ecx, [eax]
00607F59   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607F5C   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607F62   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       md_entraga_correio, md_entre
|                                ga_recusado, md_entrega_outro, '
|
00607F68   BAD08D6000             mov     edx, $00608DD0
00607F6D   8B08                   mov     ecx, [eax]
00607F6F   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607F72   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607F78   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       md_nao_exec, md_fraude, '
|
00607F7E   BA1C8E6000             mov     edx, $00608E1C
00607F83   8B08                   mov     ecx, [eax]
00607F85   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607F88   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607F8E   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       md_para_corte, md_cortado, '
|
00607F94   BA448E6000             mov     edx, $00608E44
00607F99   8B08                   mov     ecx, [eax]
00607F9B   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607F9E   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607FA4   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       md_emitidas_aviso, md_emitid
|                                as_2_vias, '
|
00607FAA   BA708E6000             mov     edx, $00608E70
00607FAF   8B08                   mov     ecx, [eax]
00607FB1   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607FB4   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607FBA   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       md_alteracoes_cadastro, md_i
|                                nclusao_cadastro, '
|
00607FC0   BAA88E6000             mov     edx, $00608EA8
00607FC5   8B08                   mov     ecx, [eax]
00607FC7   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607FCA   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607FD0   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       md_leituras_real,  '
|
00607FD6   BAE88E6000             mov     edx, $00608EE8
00607FDB   8B08                   mov     ecx, [eax]
00607FDD   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607FE0   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607FE6   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       (md_leitura_campo+md_analise
|                                -md_leituras_real) as md_leituras_n
|                                ao_real,  '
|
00607FEC   BA0C8F6000             mov     edx, $00608F0C
00607FF1   8B08                   mov     ecx, [eax]
00607FF3   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607FF6   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00607FFC   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       case   when (md_leitura_camp
|                                o+md_analise) > 0  '
|
00608002   BA688F6000             mov     edx, $00608F68
00608007   8B08                   mov     ecx, [eax]
00608009   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
0060800C   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00608012   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '              then (md_leituras_rea
|                                l*100/(md_leitura_campo+md_analise)
|                                )  '
|
00608018   BAA88F6000             mov     edx, $00608FA8
0060801D   8B08                   mov     ecx, [eax]
0060801F   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00608022   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00608028   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '              else 0  '
|
0060802E   BAFC8F6000             mov     edx, $00608FFC
00608033   8B08                   mov     ecx, [eax]
00608035   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00608038   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
0060803E   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       end as perc_leituras_real,  '
|
00608044   BA1C906000             mov     edx, $0060901C
00608049   8B08                   mov     ecx, [eax]
0060804B   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
0060804E   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00608054   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '       100 - (case when (md_leitura
|                                _campo+md_analise) > 0  '
|
0060805A   BA48906000             mov     edx, $00609048
0060805F   8B08                   mov     ecx, [eax]
00608061   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00608064   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
0060806A   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '                   then (md_leitura
|                                s_real*100/(md_leitura_campo+md_ana
|                                lise))  '
|
00608070   BA8C906000             mov     edx, $0060908C
00608075   8B08                   mov     ecx, [eax]
00608077   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
0060807A   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00608080   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '                   else 0  '
|
00608086   BAE4906000             mov     edx, $006090E4
0060808B   8B08                   mov     ecx, [eax]
0060808D   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00608090   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00608096   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '              end) as perc_leituras
|                                _nao_real,  '
|
0060809C   BA08916000             mov     edx, $00609108
006080A1   8B08                   mov     ecx, [eax]
006080A3   FF5138                 call    dword ptr [ecx+$38]

* Possible String Reference to: '       convert(char(100), ''
|
006080A6   6840916000             push    $00609140
006080AB   FF75FC                 push    dword ptr [ebp-$04]
006080AE   6864916000             push    $00609164

* Possible String Reference to: ') as titulo1, '
|
006080B3   6870916000             push    $00609170
006080B8   8D45D0                 lea     eax, [ebp-$30]
006080BB   BA04000000             mov     edx, $00000004

|
006080C0   E863DBDFFF             call    00405C28
006080C5   8B55D0                 mov     edx, [ebp-$30]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
006080C8   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
006080CE   8B8048020000           mov     eax, [eax+$0248]
006080D4   8B08                   mov     ecx, [eax]
006080D6   FF5138                 call    dword ptr [ecx+$38]

* Possible String Reference to: '       convert(char(100), ''
|
006080D9   6840916000             push    $00609140
006080DE   FF75F8                 push    dword ptr [ebp-$08]
006080E1   6864916000             push    $00609164

* Possible String Reference to: ') as titulo2  '
|
006080E6   6888916000             push    $00609188
006080EB   8D45CC                 lea     eax, [ebp-$34]
006080EE   BA04000000             mov     edx, $00000004

|
006080F3   E830DBDFFF             call    00405C28
006080F8   8B55CC                 mov     edx, [ebp-$34]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
006080FB   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00608101   8B8048020000           mov     eax, [eax+$0248]
00608107   8B08                   mov     ecx, [eax]
00608109   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
0060810C   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00608112   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'from   medicao '
|
00608118   BAA0916000             mov     edx, $006091A0
0060811D   8B08                   mov     ecx, [eax]
0060811F   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00608122   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00608128   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'left   outer join agentes '
|
0060812E   BAB8916000             mov     edx, $006091B8
00608133   8B08                   mov     ecx, [eax]
00608135   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00608138   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
0060813E   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'on     ag_codigo = md_agente '
|
00608144   BADC916000             mov     edx, $006091DC
00608149   8B08                   mov     ecx, [eax]
0060814B   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
0060814E   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00608154   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'and    ag_grupo = md_grupo '
|
0060815A   BA04926000             mov     edx, $00609204
0060815F   8B08                   mov     ecx, [eax]
00608161   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.rbtReferenciaRecepcao : TRadioButton
|
00608164   8B8690050000           mov     eax, [esi+$0590]
0060816A   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
0060816C   FF92D8000000           call    dword ptr [edx+$00D8]
00608172   84C0                   test    al, al
00608174   0F84D5000000           jz      0060824F
0060817A   8D55C4                 lea     edx, [ebp-$3C]

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
0060817D   8B869C030000           mov     eax, [esi+$039C]

|
00608183   E87879E5FF             call    0045FB00
00608188   8B45C4                 mov     eax, [ebp-$3C]
0060818B   8D55C8                 lea     edx, [ebp-$38]

|
0060818E   E8C127E0FF             call    0040A954
00608193   837DC800               cmp     dword ptr [ebp-$38], +$00
00608197   7528                   jnz     006081C1
00608199   6A00                   push    $00
0060819B   0FB70D20926000         movzx   ecx, word ptr [$00609220]
006081A2   B202                   mov     dl, $02

* Possible String Reference to: 'Selecionar o grupo.'
|
006081A4   B82C926000             mov     eax, $0060922C

|
006081A9   E8FA89E4FF             call    00450BA8

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
006081AE   8B869C030000           mov     eax, [esi+$039C]
006081B4   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00D4
|
006081B6   FF92D4000000           call    dword ptr [edx+$00D4]
006081BC   E914070000             jmp     006088D5
006081C1   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioPerformance.cmbVerRefRecepcao : TComboBox
|
006081C3   8B8680050000           mov     eax, [esi+$0580]
006081C9   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E0
|
006081CB   FF91E0000000           call    dword ptr [ecx+$00E0]
006081D1   8BD7                   mov     edx, edi
006081D3   8BC6                   mov     eax, esi

* Reference to : TfrmRelatorioPerformance.cmbVerRefRecepcaoChange()
|
006081D5   E87EEDFFFF             call    00606F58

* Reference to control TfrmRelatorioPerformance.QrMedRecepcao : TQuery
|
006081DA   8B8688050000           mov     eax, [esi+$0588]

|
006081E0   E82B63E9FF             call    0049E510
006081E5   8D55C0                 lea     edx, [ebp-$40]

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
006081E8   8B869C030000           mov     eax, [esi+$039C]

|
006081EE   E80D79E5FF             call    0045FB00
006081F3   8B45C0                 mov     eax, [ebp-$40]
006081F6   33D2                   xor     edx, edx

|
006081F8   E88330E0FF             call    0040B280
006081FD   50                     push    eax

* Possible String Reference to: 'nGrupo'
|
006081FE   BA48926000             mov     edx, $00609248

* Reference to control TfrmRelatorioPerformance.QrMedRecepcao : TQuery
|
00608203   8B8688050000           mov     eax, [esi+$0588]

|
00608209   E87227EBFF             call    004BA980
0060820E   5A                     pop     edx

|
0060820F   E8D854E9FF             call    0049D6EC

* Reference to control TfrmRelatorioPerformance.QrMedRecepcao : TQuery
|
00608214   8B8688050000           mov     eax, [esi+$0588]

|
0060821A   E8DD62E9FF             call    0049E4FC
0060821F   B201                   mov     dl, $01

* Reference to control TfrmRelatorioPerformance.tbsReferenciaRecepcao : TTabSheet
|
00608221   8B8664050000           mov     eax, [esi+$0564]

* Reference to : TTabStrings._PROC_004C6FB0()
|
00608227   E884EDEBFF             call    004C6FB0

* Reference to control TfrmRelatorioPerformance.tbsReferenciaRecepcao : TTabSheet
|
0060822C   8B9664050000           mov     edx, [esi+$0564]

* Reference to control TfrmRelatorioPerformance.PageControl : TPageControl
|
00608232   8B8680030000           mov     eax, [esi+$0380]

* Reference to : TTabStrings._PROC_004C7994()
|
00608238   E857F7EBFF             call    004C7994
0060823D   B201                   mov     dl, $01

* Reference to control TfrmRelatorioPerformance.sbtnImprimir : TSpeedButton
|
0060823F   8B8624050000           mov     eax, [esi+$0524]

|
00608245   E8D677E5FF             call    0045FA20
0060824A   E969060000             jmp     006088B8

* Reference to control TfrmRelatorioPerformance.rbtReferencia : TRadioButton
|
0060824F   8B868C030000           mov     eax, [esi+$038C]
00608255   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00608257   FF92D8000000           call    dword ptr [edx+$00D8]
0060825D   84C0                   test    al, al
0060825F   0F84CF010000           jz      00608434
00608265   8D55B8                 lea     edx, [ebp-$48]

* Reference to control TfrmRelatorioPerformance.cmbReferencia : TComboBox
|
00608268   8B86A4030000           mov     eax, [esi+$03A4]

|
0060826E   E88D78E5FF             call    0045FB00
00608273   8B45B8                 mov     eax, [ebp-$48]
00608276   8D55BC                 lea     edx, [ebp-$44]

|
00608279   E8D626E0FF             call    0040A954
0060827E   837DBC00               cmp     dword ptr [ebp-$44], +$00
00608282   7528                   jnz     006082AC
00608284   6A00                   push    $00
00608286   0FB70D20926000         movzx   ecx, word ptr [$00609220]
0060828D   B202                   mov     dl, $02

* Possible String Reference to: 'Selecionar a referÍncia.'
|
0060828F   B858926000             mov     eax, $00609258

|
00608294   E80F89E4FF             call    00450BA8

* Reference to control TfrmRelatorioPerformance.cmbReferencia : TComboBox
|
00608299   8B86A4030000           mov     eax, [esi+$03A4]
0060829F   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00D4
|
006082A1   FF92D4000000           call    dword ptr [edx+$00D4]
006082A7   E929060000             jmp     006088D5
006082AC   8D55B0                 lea     edx, [ebp-$50]

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
006082AF   8B869C030000           mov     eax, [esi+$039C]

|
006082B5   E84678E5FF             call    0045FB00
006082BA   8B45B0                 mov     eax, [ebp-$50]
006082BD   8D55B4                 lea     edx, [ebp-$4C]

|
006082C0   E88F26E0FF             call    0040A954
006082C5   837DB400               cmp     dword ptr [ebp-$4C], +$00
006082C9   7528                   jnz     006082F3
006082CB   6A00                   push    $00
006082CD   0FB70D20926000         movzx   ecx, word ptr [$00609220]
006082D4   B202                   mov     dl, $02

* Possible String Reference to: 'Selecionar o grupo.'
|
006082D6   B82C926000             mov     eax, $0060922C

|
006082DB   E8C888E4FF             call    00450BA8

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
006082E0   8B869C030000           mov     eax, [esi+$039C]
006082E6   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00D4
|
006082E8   FF92D4000000           call    dword ptr [edx+$00D4]
006082EE   E9E2050000             jmp     006088D5
006082F3   8D45AC                 lea     eax, [ebp-$54]
006082F6   50                     push    eax
006082F7   8D55A8                 lea     edx, [ebp-$58]

* Reference to control TfrmRelatorioPerformance.cmbReferencia : TComboBox
|
006082FA   8B86A4030000           mov     eax, [esi+$03A4]

|
00608300   E8FB77E5FF             call    0045FB00
00608305   8B45A8                 mov     eax, [ebp-$58]
00608308   B904000000             mov     ecx, $00000004
0060830D   BA04000000             mov     edx, $00000004

|
00608312   E8B1DADFFF             call    00405DC8
00608317   8B45AC                 mov     eax, [ebp-$54]
0060831A   33D2                   xor     edx, edx

|
0060831C   E85F2FE0FF             call    0040B280
00608321   8BD8                   mov     ebx, eax
00608323   8D45A4                 lea     eax, [ebp-$5C]
00608326   50                     push    eax
00608327   8D55A0                 lea     edx, [ebp-$60]

* Reference to control TfrmRelatorioPerformance.cmbReferencia : TComboBox
|
0060832A   8B86A4030000           mov     eax, [esi+$03A4]

|
00608330   E8CB77E5FF             call    0045FB00
00608335   8B45A0                 mov     eax, [ebp-$60]
00608338   B902000000             mov     ecx, $00000002
0060833D   BA01000000             mov     edx, $00000001

|
00608342   E881DADFFF             call    00405DC8
00608347   8B45A4                 mov     eax, [ebp-$5C]
0060834A   33D2                   xor     edx, edx

|
0060834C   E82F2FE0FF             call    0040B280
00608351   66B90100               mov     cx, $0001
00608355   8BD0                   mov     edx, eax
00608357   8BC3                   mov     eax, ebx

|
00608359   E8025DE0FF             call    0040E060
0060835E   DD5DE8                 fstp    qword ptr [ebp-$18]
00608361   9B                     wait
00608362   8D5598                 lea     edx, [ebp-$68]

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
00608365   8B869C030000           mov     eax, [esi+$039C]

|
0060836B   E89077E5FF             call    0045FB00
00608370   8B4D98                 mov     ecx, [ebp-$68]
00608373   8D459C                 lea     eax, [ebp-$64]

* Possible String Reference to: 'where  md_grupo      = '
|
00608376   BA7C926000             mov     edx, $0060927C

|
0060837B   E834D8DFFF             call    00405BB4
00608380   8B559C                 mov     edx, [ebp-$64]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00608383   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00608389   8B8048020000           mov     eax, [eax+$0248]
0060838F   8B08                   mov     ecx, [eax]
00608391   FF5138                 call    dword ptr [ecx+$38]
00608394   FF75EC                 push    dword ptr [ebp-$14]
00608397   FF75E8                 push    dword ptr [ebp-$18]
0060839A   8D45F4                 lea     eax, [ebp-$0C]

* Possible String Reference to: 'yyyyMMdd'
|
0060839D   BA9C926000             mov     edx, $0060929C

|
006083A2   E8DD6AE0FF             call    0040EE84

* Possible String Reference to: 'and    md_referencia = ''
|
006083A7   68B0926000             push    $006092B0
006083AC   FF75F4                 push    dword ptr [ebp-$0C]
006083AF   6864916000             push    $00609164
006083B4   8D4594                 lea     eax, [ebp-$6C]
006083B7   BA03000000             mov     edx, $00000003

|
006083BC   E867D8DFFF             call    00405C28
006083C1   8B5594                 mov     edx, [ebp-$6C]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
006083C4   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
006083CA   8B8048020000           mov     eax, [eax+$0248]
006083D0   8B08                   mov     ecx, [eax]
006083D2   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
006083D5   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
006083DB   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'order  by md_rota'
|
006083E1   BAD4926000             mov     edx, $006092D4
006083E6   8B08                   mov     ecx, [eax]
006083E8   FF5138                 call    dword ptr [ecx+$38]
006083EB   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioPerformance.cmbVerReferencia : TComboBox
|
006083ED   8B865C040000           mov     eax, [esi+$045C]
006083F3   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E0
|
006083F5   FF91E0000000           call    dword ptr [ecx+$00E0]
006083FB   8BD7                   mov     edx, edi
006083FD   8BC6                   mov     eax, esi

* Reference to : TfrmRelatorioPerformance.cmbVerReferenciaChange()
|
006083FF   E894E6FFFF             call    00606A98
00608404   B201                   mov     dl, $01

* Reference to control TfrmRelatorioPerformance.tbsReferencia : TTabSheet
|
00608406   8B863C040000           mov     eax, [esi+$043C]

* Reference to : TTabStrings._PROC_004C6FB0()
|
0060840C   E89FEBEBFF             call    004C6FB0

* Reference to control TfrmRelatorioPerformance.tbsReferencia : TTabSheet
|
00608411   8B963C040000           mov     edx, [esi+$043C]

* Reference to control TfrmRelatorioPerformance.PageControl : TPageControl
|
00608417   8B8680030000           mov     eax, [esi+$0380]

* Reference to : TTabStrings._PROC_004C7994()
|
0060841D   E872F5EBFF             call    004C7994
00608422   B201                   mov     dl, $01

* Reference to control TfrmRelatorioPerformance.sbtnImprimir : TSpeedButton
|
00608424   8B8624050000           mov     eax, [esi+$0524]

|
0060842A   E8F175E5FF             call    0045FA20
0060842F   E984040000             jmp     006088B8

* Reference to control TfrmRelatorioPerformance.rbtRota : TRadioButton
|
00608434   8B8690030000           mov     eax, [esi+$0390]
0060843A   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
0060843C   FF92D8000000           call    dword ptr [edx+$00D8]
00608442   84C0                   test    al, al
00608444   0F84A5010000           jz      006085EF
0060844A   8D558C                 lea     edx, [ebp-$74]

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
0060844D   8B869C030000           mov     eax, [esi+$039C]

|
00608453   E8A876E5FF             call    0045FB00
00608458   8B458C                 mov     eax, [ebp-$74]
0060845B   8D5590                 lea     edx, [ebp-$70]

|
0060845E   E8F124E0FF             call    0040A954
00608463   837D9000               cmp     dword ptr [ebp-$70], +$00
00608467   7528                   jnz     00608491
00608469   6A00                   push    $00
0060846B   0FB70D20926000         movzx   ecx, word ptr [$00609220]
00608472   B202                   mov     dl, $02

* Possible String Reference to: 'Selecionar o grupo.'
|
00608474   B82C926000             mov     eax, $0060922C

|
00608479   E82A87E4FF             call    00450BA8

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
0060847E   8B869C030000           mov     eax, [esi+$039C]
00608484   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00D4
|
00608486   FF92D4000000           call    dword ptr [edx+$00D4]
0060848C   E944040000             jmp     006088D5
00608491   8D5584                 lea     edx, [ebp-$7C]

* Reference to control TfrmRelatorioPerformance.cmbRota : TComboBox
|
00608494   8B86B0030000           mov     eax, [esi+$03B0]

|
0060849A   E86176E5FF             call    0045FB00
0060849F   8B4584                 mov     eax, [ebp-$7C]
006084A2   8D5588                 lea     edx, [ebp-$78]

|
006084A5   E8AA24E0FF             call    0040A954
006084AA   837D8800               cmp     dword ptr [ebp-$78], +$00
006084AE   7528                   jnz     006084D8
006084B0   6A00                   push    $00
006084B2   0FB70D20926000         movzx   ecx, word ptr [$00609220]
006084B9   B202                   mov     dl, $02

* Possible String Reference to: 'Selecionar a rota.'
|
006084BB   B8F0926000             mov     eax, $006092F0

|
006084C0   E8E386E4FF             call    00450BA8

* Reference to control TfrmRelatorioPerformance.cmbRota : TComboBox
|
006084C5   8B86B0030000           mov     eax, [esi+$03B0]
006084CB   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00D4
|
006084CD   FF92D4000000           call    dword ptr [edx+$00D4]
006084D3   E9FD030000             jmp     006088D5
006084D8   8D957CFFFFFF           lea     edx, [ebp+$FFFFFF7C]

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
006084DE   8B869C030000           mov     eax, [esi+$039C]

|
006084E4   E81776E5FF             call    0045FB00
006084E9   8B8D7CFFFFFF           mov     ecx, [ebp+$FFFFFF7C]
006084EF   8D4580                 lea     eax, [ebp-$80]

* Possible String Reference to: 'where  md_grupo      = '
|
006084F2   BA7C926000             mov     edx, $0060927C

|
006084F7   E8B8D6DFFF             call    00405BB4
006084FC   8B5580                 mov     edx, [ebp-$80]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
006084FF   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00608505   8B8048020000           mov     eax, [eax+$0248]
0060850B   8B08                   mov     ecx, [eax]
0060850D   FF5138                 call    dword ptr [ecx+$38]
00608510   8D9574FFFFFF           lea     edx, [ebp+$FFFFFF74]

* Reference to control TfrmRelatorioPerformance.cmbRota : TComboBox
|
00608516   8B86B0030000           mov     eax, [esi+$03B0]

|
0060851C   E8DF75E5FF             call    0045FB00
00608521   8B8D74FFFFFF           mov     ecx, [ebp+$FFFFFF74]
00608527   8D8578FFFFFF           lea     eax, [ebp+$FFFFFF78]

* Possible String Reference to: 'and    md_rota       = '
|
0060852D   BA0C936000             mov     edx, $0060930C

|
00608532   E87DD6DFFF             call    00405BB4
00608537   8B9578FFFFFF           mov     edx, [ebp+$FFFFFF78]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
0060853D   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00608543   8B8048020000           mov     eax, [eax+$0248]
00608549   8B08                   mov     ecx, [eax]
0060854B   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
0060854E   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00608554   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'and    md_referencia >= '
|
0060855A   BA2C936000             mov     edx, $0060932C
0060855F   8B08                   mov     ecx, [eax]
00608561   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00608564   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
0060856A   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '         (select convert(datetime, 
|                                convert( char(06), max(md_referenci
|                                a) - 190, 112 ) + '01') '
|
00608570   BA50936000             mov     edx, $00609350
00608575   8B08                   mov     ecx, [eax]
00608577   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
0060857A   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00608580   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '          from   medicao)   '
|
00608586   BAB8936000             mov     edx, $006093B8
0060858B   8B08                   mov     ecx, [eax]
0060858D   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00608590   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
00608596   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'order  by md_referencia desc'
|
0060859C   BAE0936000             mov     edx, $006093E0
006085A1   8B08                   mov     ecx, [eax]
006085A3   FF5138                 call    dword ptr [ecx+$38]
006085A6   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioPerformance.cmbVerRota : TComboBox
|
006085A8   8B8688040000           mov     eax, [esi+$0488]
006085AE   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E0
|
006085B0   FF91E0000000           call    dword ptr [ecx+$00E0]
006085B6   8BD7                   mov     edx, edi
006085B8   8BC6                   mov     eax, esi

* Reference to : TfrmRelatorioPerformance.cmbVerRotaChange()
|
006085BA   E8D9EDFFFF             call    00607398
006085BF   B201                   mov     dl, $01

* Reference to control TfrmRelatorioPerformance.tbsRota : TTabSheet
|
006085C1   8B866C040000           mov     eax, [esi+$046C]

* Reference to : TTabStrings._PROC_004C6FB0()
|
006085C7   E8E4E9EBFF             call    004C6FB0

* Reference to control TfrmRelatorioPerformance.tbsRota : TTabSheet
|
006085CC   8B966C040000           mov     edx, [esi+$046C]

* Reference to control TfrmRelatorioPerformance.PageControl : TPageControl
|
006085D2   8B8680030000           mov     eax, [esi+$0380]

* Reference to : TTabStrings._PROC_004C7994()
|
006085D8   E8B7F3EBFF             call    004C7994
006085DD   B201                   mov     dl, $01

* Reference to control TfrmRelatorioPerformance.sbtnImprimir : TSpeedButton
|
006085DF   8B8624050000           mov     eax, [esi+$0524]

|
006085E5   E83674E5FF             call    0045FA20
006085EA   E9C9020000             jmp     006088B8

* Reference to control TfrmRelatorioPerformance.rbtAgente : TRadioButton
|
006085EF   8B8694030000           mov     eax, [esi+$0394]
006085F5   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
006085F7   FF92D8000000           call    dword ptr [edx+$00D8]
006085FD   84C0                   test    al, al
006085FF   0F844C010000           jz      00608751
00608605   8D956CFFFFFF           lea     edx, [ebp+$FFFFFF6C]

* Reference to control TfrmRelatorioPerformance.cmbAgente : TComboBox
|
0060860B   8B86B8030000           mov     eax, [esi+$03B8]

|
00608611   E8EA74E5FF             call    0045FB00
00608616   8B856CFFFFFF           mov     eax, [ebp+$FFFFFF6C]
0060861C   8D9570FFFFFF           lea     edx, [ebp+$FFFFFF70]

|
00608622   E82D23E0FF             call    0040A954
00608627   83BD70FFFFFF00         cmp     dword ptr [ebp+$FFFFFF70], +$00
0060862E   7528                   jnz     00608658
00608630   6A00                   push    $00
00608632   0FB70D20926000         movzx   ecx, word ptr [$00609220]
00608639   B202                   mov     dl, $02

* Possible String Reference to: 'Selecionar o agente comercial.'
|
0060863B   B808946000             mov     eax, $00609408

|
00608640   E86385E4FF             call    00450BA8

* Reference to control TfrmRelatorioPerformance.cmbAgente : TComboBox
|
00608645   8B86B8030000           mov     eax, [esi+$03B8]
0060864B   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00D4
|
0060864D   FF92D4000000           call    dword ptr [edx+$00D4]
00608653   E97D020000             jmp     006088D5
00608658   8D9568FFFFFF           lea     edx, [ebp+$FFFFFF68]

* Reference to control TfrmRelatorioPerformance.cmbAgente : TComboBox
|
0060865E   8B86B8030000           mov     eax, [esi+$03B8]

|
00608664   E89774E5FF             call    0045FB00
00608669   8B8568FFFFFF           mov     eax, [ebp+$FFFFFF68]

|
0060866F   E8E8F0F6FF             call    0057775C
00608674   8BD8                   mov     ebx, eax
00608676   8D9560FFFFFF           lea     edx, [ebp+$FFFFFF60]
0060867C   8BC3                   mov     eax, ebx

|
0060867E   E87129E0FF             call    0040AFF4
00608683   8B8D60FFFFFF           mov     ecx, [ebp+$FFFFFF60]
00608689   8D8564FFFFFF           lea     eax, [ebp+$FFFFFF64]

* Possible String Reference to: 'where  md_agente     = '
|
0060868F   BA30946000             mov     edx, $00609430

|
00608694   E81BD5DFFF             call    00405BB4
00608699   8B9564FFFFFF           mov     edx, [ebp+$FFFFFF64]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
0060869F   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
006086A5   8B8048020000           mov     eax, [eax+$0248]
006086AB   8B08                   mov     ecx, [eax]
006086AD   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
006086B0   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
006086B6   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'and    md_referencia >= '
|
006086BC   BA2C936000             mov     edx, $0060932C
006086C1   8B08                   mov     ecx, [eax]
006086C3   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
006086C6   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
006086CC   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '         (select convert(datetime, 
|                                convert( char(06), max(md_referenci
|                                a) - 190, 112 ) + '01') '
|
006086D2   BA50936000             mov     edx, $00609350
006086D7   8B08                   mov     ecx, [eax]
006086D9   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
006086DC   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
006086E2   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: '          from   medicao)   '
|
006086E8   BAB8936000             mov     edx, $006093B8
006086ED   8B08                   mov     ecx, [eax]
006086EF   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
006086F2   8B86C8030000           mov     eax, [esi+$03C8]

* Reference to field TQuery.OFFS_0248
|
006086F8   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'order  by md_referencia desc, md_gr
|                                upo, md_rota'
|
006086FE   BA50946000             mov     edx, $00609450
00608703   8B08                   mov     ecx, [eax]
00608705   FF5138                 call    dword ptr [ecx+$38]
00608708   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioPerformance.cmbVerAgente : TComboBox
|
0060870A   8B86A0040000           mov     eax, [esi+$04A0]
00608710   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E0
|
00608712   FF91E0000000           call    dword ptr [ecx+$00E0]
00608718   8BD7                   mov     edx, edi
0060871A   8BC6                   mov     eax, esi

* Reference to : TfrmRelatorioPerformance.cmbVerAgenteChange()
|
0060871C   E8B7DEFFFF             call    006065D8
00608721   B201                   mov     dl, $01

* Reference to control TfrmRelatorioPerformance.tbsAgente : TTabSheet
|
00608723   8B868C040000           mov     eax, [esi+$048C]

* Reference to : TTabStrings._PROC_004C6FB0()
|
00608729   E882E8EBFF             call    004C6FB0

* Reference to control TfrmRelatorioPerformance.tbsAgente : TTabSheet
|
0060872E   8B968C040000           mov     edx, [esi+$048C]

* Reference to control TfrmRelatorioPerformance.PageControl : TPageControl
|
00608734   8B8680030000           mov     eax, [esi+$0380]

* Reference to : TTabStrings._PROC_004C7994()
|
0060873A   E855F2EBFF             call    004C7994
0060873F   B201                   mov     dl, $01

* Reference to control TfrmRelatorioPerformance.sbtnImprimir : TSpeedButton
|
00608741   8B8624050000           mov     eax, [esi+$0524]

|
00608747   E8D472E5FF             call    0045FA20
0060874C   E967010000             jmp     006088B8

* Reference to control TfrmRelatorioPerformance.rbtHorario : TRadioButton
|
00608751   8B86A4040000           mov     eax, [esi+$04A4]
00608757   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00608759   FF92D8000000           call    dword ptr [edx+$00D8]
0060875F   84C0                   test    al, al
00608761   0F8451010000           jz      006088B8
00608767   8D9558FFFFFF           lea     edx, [ebp+$FFFFFF58]

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
0060876D   8B869C030000           mov     eax, [esi+$039C]

|
00608773   E88873E5FF             call    0045FB00
00608778   8B8558FFFFFF           mov     eax, [ebp+$FFFFFF58]
0060877E   8D955CFFFFFF           lea     edx, [ebp+$FFFFFF5C]

|
00608784   E8CB21E0FF             call    0040A954
00608789   83BD5CFFFFFF00         cmp     dword ptr [ebp+$FFFFFF5C], +$00
00608790   7528                   jnz     006087BA
00608792   6A00                   push    $00
00608794   0FB70D20926000         movzx   ecx, word ptr [$00609220]
0060879B   B202                   mov     dl, $02

* Possible String Reference to: 'Selecionar o grupo.'
|
0060879D   B82C926000             mov     eax, $0060922C

|
006087A2   E80184E4FF             call    00450BA8

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
006087A7   8B869C030000           mov     eax, [esi+$039C]
006087AD   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00D4
|
006087AF   FF92D4000000           call    dword ptr [edx+$00D4]
006087B5   E91B010000             jmp     006088D5
006087BA   8D9550FFFFFF           lea     edx, [ebp+$FFFFFF50]

* Reference to control TfrmRelatorioPerformance.cmbRota : TComboBox
|
006087C0   8B86B0030000           mov     eax, [esi+$03B0]

|
006087C6   E83573E5FF             call    0045FB00
006087CB   8B8550FFFFFF           mov     eax, [ebp+$FFFFFF50]
006087D1   8D9554FFFFFF           lea     edx, [ebp+$FFFFFF54]

|
006087D7   E87821E0FF             call    0040A954
006087DC   83BD54FFFFFF00         cmp     dword ptr [ebp+$FFFFFF54], +$00
006087E3   7528                   jnz     0060880D
006087E5   6A00                   push    $00
006087E7   0FB70D20926000         movzx   ecx, word ptr [$00609220]
006087EE   B202                   mov     dl, $02

* Possible String Reference to: 'Selecionar a rota.'
|
006087F0   B8F0926000             mov     eax, $006092F0

|
006087F5   E8AE83E4FF             call    00450BA8

* Reference to control TfrmRelatorioPerformance.cmbRota : TComboBox
|
006087FA   8B86B0030000           mov     eax, [esi+$03B0]
00608800   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00D4
|
00608802   FF92D4000000           call    dword ptr [edx+$00D4]
00608808   E9C8000000             jmp     006088D5

* Reference to control TfrmRelatorioPerformance.qryHorario : TQuery
|
0060880D   8B86AC040000           mov     eax, [esi+$04AC]

|
00608813   E8F85CE9FF             call    0049E510
00608818   8D954CFFFFFF           lea     edx, [ebp+$FFFFFF4C]

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
0060881E   8B869C030000           mov     eax, [esi+$039C]

|
00608824   E8D772E5FF             call    0045FB00
00608829   8B854CFFFFFF           mov     eax, [ebp+$FFFFFF4C]
0060882F   33D2                   xor     edx, edx

|
00608831   E84A2AE0FF             call    0040B280
00608836   50                     push    eax

* Possible String Reference to: 'nGrupo'
|
00608837   BA48926000             mov     edx, $00609248

* Reference to control TfrmRelatorioPerformance.qryHorario : TQuery
|
0060883C   8B86AC040000           mov     eax, [esi+$04AC]

|
00608842   E83921EBFF             call    004BA980
00608847   5A                     pop     edx

|
00608848   E89F4EE9FF             call    0049D6EC
0060884D   8D9548FFFFFF           lea     edx, [ebp+$FFFFFF48]

* Reference to control TfrmRelatorioPerformance.cmbRota : TComboBox
|
00608853   8B86B0030000           mov     eax, [esi+$03B0]

|
00608859   E8A272E5FF             call    0045FB00
0060885E   8B8548FFFFFF           mov     eax, [ebp+$FFFFFF48]
00608864   33D2                   xor     edx, edx

|
00608866   E8152AE0FF             call    0040B280
0060886B   50                     push    eax

* Possible String Reference to: 'nRota'
|
0060886C   BA88946000             mov     edx, $00609488

* Reference to control TfrmRelatorioPerformance.qryHorario : TQuery
|
00608871   8B86AC040000           mov     eax, [esi+$04AC]

|
00608877   E80421EBFF             call    004BA980
0060887C   5A                     pop     edx

|
0060887D   E86A4EE9FF             call    0049D6EC

* Reference to control TfrmRelatorioPerformance.qryHorario : TQuery
|
00608882   8B86AC040000           mov     eax, [esi+$04AC]

|
00608888   E86F5CE9FF             call    0049E4FC
0060888D   B201                   mov     dl, $01

* Reference to control TfrmRelatorioPerformance.tbsEmissao : TTabSheet
|
0060888F   8B86A8040000           mov     eax, [esi+$04A8]

* Reference to : TTabStrings._PROC_004C6FB0()
|
00608895   E816E7EBFF             call    004C6FB0

* Reference to control TfrmRelatorioPerformance.tbsEmissao : TTabSheet
|
0060889A   8B96A8040000           mov     edx, [esi+$04A8]

* Reference to control TfrmRelatorioPerformance.PageControl : TPageControl
|
006088A0   8B8680030000           mov     eax, [esi+$0380]

* Reference to : TTabStrings._PROC_004C7994()
|
006088A6   E8E9F0EBFF             call    004C7994
006088AB   B201                   mov     dl, $01

* Reference to control TfrmRelatorioPerformance.sbtnImprimir : TSpeedButton
|
006088AD   8B8624050000           mov     eax, [esi+$0524]

|
006088B3   E86871E5FF             call    0045FA20

* Reference to control TfrmRelatorioPerformance.rbtHorario : TRadioButton
|
006088B8   8B86A4040000           mov     eax, [esi+$04A4]
006088BE   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
006088C0   FF92D8000000           call    dword ptr [edx+$00D8]
006088C6   84C0                   test    al, al
006088C8   750B                   jnz     006088D5

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
006088CA   8B86C8030000           mov     eax, [esi+$03C8]

|
006088D0   E8275CE9FF             call    0049E4FC
006088D5   33C0                   xor     eax, eax
006088D7   5A                     pop     edx
006088D8   59                     pop     ecx
006088D9   59                     pop     ecx
006088DA   648910                 mov     fs:[eax], edx

****** FINALLY
|
006088DD   68F5896000             push    $006089F5
006088E2   8D8548FFFFFF           lea     eax, [ebp+$FFFFFF48]
006088E8   BA03000000             mov     edx, $00000003

|
006088ED   E8D6CFDFFF             call    004058C8
006088F2   8D8554FFFFFF           lea     eax, [ebp+$FFFFFF54]

|
006088F8   E8A7CFDFFF             call    004058A4
006088FD   8D8558FFFFFF           lea     eax, [ebp+$FFFFFF58]

|
00608903   E89CCFDFFF             call    004058A4
00608908   8D855CFFFFFF           lea     eax, [ebp+$FFFFFF5C]
0060890E   BA03000000             mov     edx, $00000003

|
00608913   E8B0CFDFFF             call    004058C8
00608918   8D8568FFFFFF           lea     eax, [ebp+$FFFFFF68]
0060891E   BA02000000             mov     edx, $00000002

|
00608923   E8A0CFDFFF             call    004058C8
00608928   8D8570FFFFFF           lea     eax, [ebp+$FFFFFF70]

|
0060892E   E871CFDFFF             call    004058A4
00608933   8D8574FFFFFF           lea     eax, [ebp+$FFFFFF74]

|
00608939   E866CFDFFF             call    004058A4
0060893E   8D8578FFFFFF           lea     eax, [ebp+$FFFFFF78]

|
00608944   E85BCFDFFF             call    004058A4
00608949   8D857CFFFFFF           lea     eax, [ebp+$FFFFFF7C]

|
0060894F   E850CFDFFF             call    004058A4
00608954   8D4580                 lea     eax, [ebp-$80]

|
00608957   E848CFDFFF             call    004058A4
0060895C   8D4584                 lea     eax, [ebp-$7C]

|
0060895F   E840CFDFFF             call    004058A4
00608964   8D4588                 lea     eax, [ebp-$78]

|
00608967   E838CFDFFF             call    004058A4
0060896C   8D458C                 lea     eax, [ebp-$74]

|
0060896F   E830CFDFFF             call    004058A4
00608974   8D4590                 lea     eax, [ebp-$70]
00608977   BA02000000             mov     edx, $00000002

|
0060897C   E847CFDFFF             call    004058C8
00608981   8D4598                 lea     eax, [ebp-$68]

|
00608984   E81BCFDFFF             call    004058A4
00608989   8D459C                 lea     eax, [ebp-$64]

|
0060898C   E813CFDFFF             call    004058A4
00608991   8D45A0                 lea     eax, [ebp-$60]
00608994   BA05000000             mov     edx, $00000005

|
00608999   E82ACFDFFF             call    004058C8
0060899E   8D45B4                 lea     eax, [ebp-$4C]

|
006089A1   E8FECEDFFF             call    004058A4
006089A6   8D45B8                 lea     eax, [ebp-$48]

|
006089A9   E8F6CEDFFF             call    004058A4
006089AE   8D45BC                 lea     eax, [ebp-$44]

|
006089B1   E8EECEDFFF             call    004058A4
006089B6   8D45C0                 lea     eax, [ebp-$40]
006089B9   BA02000000             mov     edx, $00000002

|
006089BE   E805CFDFFF             call    004058C8
006089C3   8D45C8                 lea     eax, [ebp-$38]
006089C6   BA03000000             mov     edx, $00000003

|
006089CB   E8F8CEDFFF             call    004058C8
006089D0   8D45D4                 lea     eax, [ebp-$2C]
006089D3   BA05000000             mov     edx, $00000005

|
006089D8   E8EBCEDFFF             call    004058C8
006089DD   8D45F4                 lea     eax, [ebp-$0C]
006089E0   BA03000000             mov     edx, $00000003

|
006089E5   E8DECEDFFF             call    004058C8
006089EA   C3                     ret


|
006089EB   E9A4C6DFFF             jmp     00405094
006089F0   E9EDFEFFFF             jmp     006088E2

****** END
|
006089F5   5F                     pop     edi
006089F6   5E                     pop     esi
006089F7   5B                     pop     ebx
006089F8   8BE5                   mov     esp, ebp
006089FA   5D                     pop     ebp
006089FB   C3                     ret

*)
end;

procedure TfrmRelatorioPerformance.cmbRotaDropDown(Sender : TObject);
begin
(*
00606214   55                     push    ebp
00606215   8BEC                   mov     ebp, esp
00606217   33C9                   xor     ecx, ecx
00606219   51                     push    ecx
0060621A   51                     push    ecx
0060621B   51                     push    ecx
0060621C   51                     push    ecx
0060621D   51                     push    ecx
0060621E   51                     push    ecx
0060621F   51                     push    ecx
00606220   53                     push    ebx
00606221   56                     push    esi
00606222   8BF0                   mov     esi, eax
00606224   33C0                   xor     eax, eax
00606226   55                     push    ebp
00606227   6883646000             push    $00606483

***** TRY
|
0060622C   64FF30                 push    dword ptr fs:[eax]
0060622F   648920                 mov     fs:[eax], esp

* Reference to control TfrmRelatorioPerformance.cmbRota : TComboBox
|
00606232   8B86B0030000           mov     eax, [esi+$03B0]
00606238   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
0060623A   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmRelatorioPerformance.cmbRota : TComboBox
|
00606240   8B86B0030000           mov     eax, [esi+$03B0]

* Reference to field TComboBox.OFFS_0284
|
00606246   8B8084020000           mov     eax, [eax+$0284]
0060624C   8B10                   mov     edx, [eax]
0060624E   FF5244                 call    dword ptr [edx+$44]
00606251   8D55F8                 lea     edx, [ebp-$08]

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
00606254   8B869C030000           mov     eax, [esi+$039C]

|
0060625A   E8A198E5FF             call    0045FB00
0060625F   8B45F8                 mov     eax, [ebp-$08]
00606262   8D55FC                 lea     edx, [ebp-$04]

|
00606265   E8EA46E0FF             call    0040A954
0060626A   837DFC00               cmp     dword ptr [ebp-$04], +$00
0060626E   7528                   jnz     00606298
00606270   6A00                   push    $00
00606272   0FB70D90646000         movzx   ecx, word ptr [$00606490]
00606279   B202                   mov     dl, $02

* Possible String Reference to: 'Selecionar o grupo.'
|
0060627B   B89C646000             mov     eax, $0060649C

|
00606280   E823A9E4FF             call    00450BA8

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
00606285   8B869C030000           mov     eax, [esi+$039C]
0060628B   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00D4
|
0060628D   FF92D4000000           call    dword ptr [edx+$00D4]
00606293   E9A5010000             jmp     0060643D

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00606298   8B86C4030000           mov     eax, [esi+$03C4]

|
0060629E   E86D82E9FF             call    0049E510

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
006062A3   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
006062A9   8B8048020000           mov     eax, [eax+$0248]
006062AF   8B10                   mov     edx, [eax]
006062B1   FF5244                 call    dword ptr [edx+$44]

* Reference to control TfrmRelatorioPerformance.rbtHorario : TRadioButton
|
006062B4   8B86A4040000           mov     eax, [esi+$04A4]
006062BA   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
006062BC   FF92D8000000           call    dword ptr [edx+$00D8]
006062C2   84C0                   test    al, al
006062C4   0F848F000000           jz      00606359

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
006062CA   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
006062D0   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'select dg_rota as rota'
|
006062D6   BAB8646000             mov     edx, $006064B8
006062DB   8B08                   mov     ecx, [eax]
006062DD   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
006062E0   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
006062E6   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'from descarga'
|
006062EC   BAD8646000             mov     edx, $006064D8
006062F1   8B08                   mov     ecx, [eax]
006062F3   FF5138                 call    dword ptr [ecx+$38]
006062F6   8D55F0                 lea     edx, [ebp-$10]

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
006062F9   8B869C030000           mov     eax, [esi+$039C]

|
006062FF   E8FC97E5FF             call    0045FB00
00606304   8B4DF0                 mov     ecx, [ebp-$10]
00606307   8D45F4                 lea     eax, [ebp-$0C]

* Possible String Reference to: 'where dg_grupo = '
|
0060630A   BAF0646000             mov     edx, $006064F0

|
0060630F   E8A0F8DFFF             call    00405BB4
00606314   8B55F4                 mov     edx, [ebp-$0C]

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00606317   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
0060631D   8B8048020000           mov     eax, [eax+$0248]
00606323   8B08                   mov     ecx, [eax]
00606325   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00606328   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
0060632E   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'group by dg_rota'
|
00606334   BA0C656000             mov     edx, $0060650C
00606339   8B08                   mov     ecx, [eax]
0060633B   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
0060633E   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
00606344   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'order by dg_rota'
|
0060634A   BA28656000             mov     edx, $00606528
0060634F   8B08                   mov     ecx, [eax]
00606351   FF5138                 call    dword ptr [ecx+$38]
00606354   E98A000000             jmp     006063E3

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00606359   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
0060635F   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'select md_rota as rota'
|
00606365   BA44656000             mov     edx, $00606544
0060636A   8B08                   mov     ecx, [eax]
0060636C   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
0060636F   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
00606375   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'from medicao'
|
0060637B   BA64656000             mov     edx, $00606564
00606380   8B08                   mov     ecx, [eax]
00606382   FF5138                 call    dword ptr [ecx+$38]
00606385   8D55E8                 lea     edx, [ebp-$18]

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
00606388   8B869C030000           mov     eax, [esi+$039C]

|
0060638E   E86D97E5FF             call    0045FB00
00606393   8B4DE8                 mov     ecx, [ebp-$18]
00606396   8D45EC                 lea     eax, [ebp-$14]

* Possible String Reference to: 'where md_grupo = '
|
00606399   BA7C656000             mov     edx, $0060657C

|
0060639E   E811F8DFFF             call    00405BB4
006063A3   8B55EC                 mov     edx, [ebp-$14]

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
006063A6   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
006063AC   8B8048020000           mov     eax, [eax+$0248]
006063B2   8B08                   mov     ecx, [eax]
006063B4   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
006063B7   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
006063BD   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'group by md_rota'
|
006063C3   BA98656000             mov     edx, $00606598
006063C8   8B08                   mov     ecx, [eax]
006063CA   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
006063CD   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
006063D3   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'order by md_rota'
|
006063D9   BAB4656000             mov     edx, $006065B4
006063DE   8B08                   mov     ecx, [eax]
006063E0   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
006063E3   8B86C4030000           mov     eax, [esi+$03C4]

|
006063E9   E80E81E9FF             call    0049E4FC
006063EE   EB33                   jmp     00606423
006063F0   BACC656000             mov     edx, $006065CC
006063F5   8BC3                   mov     eax, ebx

|
006063F7   E83C94E9FF             call    0049F838
006063FC   8D55E4                 lea     edx, [ebp-$1C]
006063FF   8B08                   mov     ecx, [eax]
00606401   FF5160                 call    dword ptr [ecx+$60]
00606404   8B55E4                 mov     edx, [ebp-$1C]

* Reference to control TfrmRelatorioPerformance.cmbRota : TComboBox
|
00606407   8B86B0030000           mov     eax, [esi+$03B0]

* Reference to field TComboBox.OFFS_0284
|
0060640D   8B8084020000           mov     eax, [eax+$0284]
00606413   8B08                   mov     ecx, [eax]
00606415   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00606418   8B86C4030000           mov     eax, [esi+$03C4]

|
0060641E   E8FDABE9FF             call    004A1020

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00606423   8B9EC4030000           mov     ebx, [esi+$03C4]

* Reference to field TQuery.OFFS_00A1
|
00606429   80BBA100000000         cmp     byte ptr [ebx+$00A1], $00
00606430   74BE                   jz      006063F0

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00606432   8B86C4030000           mov     eax, [esi+$03C4]

|
00606438   E8D380E9FF             call    0049E510
0060643D   33C0                   xor     eax, eax
0060643F   5A                     pop     edx
00606440   59                     pop     ecx
00606441   59                     pop     ecx
00606442   648910                 mov     fs:[eax], edx

****** FINALLY
|
00606445   688A646000             push    $0060648A
0060644A   8D45E4                 lea     eax, [ebp-$1C]

|
0060644D   E852F4DFFF             call    004058A4
00606452   8D45E8                 lea     eax, [ebp-$18]

|
00606455   E84AF4DFFF             call    004058A4
0060645A   8D45EC                 lea     eax, [ebp-$14]

|
0060645D   E842F4DFFF             call    004058A4
00606462   8D45F0                 lea     eax, [ebp-$10]

|
00606465   E83AF4DFFF             call    004058A4
0060646A   8D45F4                 lea     eax, [ebp-$0C]

|
0060646D   E832F4DFFF             call    004058A4
00606472   8D45F8                 lea     eax, [ebp-$08]

|
00606475   E82AF4DFFF             call    004058A4
0060647A   8D45FC                 lea     eax, [ebp-$04]

|
0060647D   E822F4DFFF             call    004058A4
00606482   C3                     ret


|
00606483   E90CECDFFF             jmp     00405094
00606488   EBC0                   jmp     0060644A

****** END
|
0060648A   5E                     pop     esi
0060648B   5B                     pop     ebx
0060648C   8BE5                   mov     esp, ebp
0060648E   5D                     pop     ebp
0060648F   C3                     ret

*)
end;

procedure TfrmRelatorioPerformance.cmbGrupoDropDown(Sender : TObject);
begin
(*
00605C78   55                     push    ebp
00605C79   8BEC                   mov     ebp, esp
00605C7B   B906000000             mov     ecx, $00000006
00605C80   6A00                   push    $00
00605C82   6A00                   push    $00
00605C84   49                     dec     ecx
00605C85   75F9                   jnz     00605C80
00605C87   53                     push    ebx
00605C88   56                     push    esi
00605C89   8BF0                   mov     esi, eax
00605C8B   33C0                   xor     eax, eax
00605C8D   55                     push    ebp
00605C8E   688E5F6000             push    $00605F8E

***** TRY
|
00605C93   64FF30                 push    dword ptr fs:[eax]
00605C96   648920                 mov     fs:[eax], esp

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
00605C99   8B869C030000           mov     eax, [esi+$039C]
00605C9F   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
00605CA1   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
00605CA7   8B869C030000           mov     eax, [esi+$039C]

* Reference to field TComboBox.OFFS_0284
|
00605CAD   8B8084020000           mov     eax, [eax+$0284]
00605CB3   8B10                   mov     edx, [eax]
00605CB5   FF5244                 call    dword ptr [edx+$44]

* Reference to control TfrmRelatorioPerformance.cmbRota : TComboBox
|
00605CB8   8B86B0030000           mov     eax, [esi+$03B0]
00605CBE   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
00605CC0   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmRelatorioPerformance.cmbRota : TComboBox
|
00605CC6   8B86B0030000           mov     eax, [esi+$03B0]

* Reference to field TComboBox.OFFS_0284
|
00605CCC   8B8084020000           mov     eax, [eax+$0284]
00605CD2   8B10                   mov     edx, [eax]
00605CD4   FF5244                 call    dword ptr [edx+$44]

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00605CD7   8B86C4030000           mov     eax, [esi+$03C4]

|
00605CDD   E82E88E9FF             call    0049E510

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00605CE2   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
00605CE8   8B8048020000           mov     eax, [eax+$0248]
00605CEE   8B10                   mov     edx, [eax]
00605CF0   FF5244                 call    dword ptr [edx+$44]

* Reference to control TfrmRelatorioPerformance.rbtHorario : TRadioButton
|
00605CF3   8B86A4040000           mov     eax, [esi+$04A4]
00605CF9   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00605CFB   FF92D8000000           call    dword ptr [edx+$00D8]
00605D01   84C0                   test    al, al
00605D03   7512                   jnz     00605D17

* Reference to control TfrmRelatorioPerformance.rbtReferenciaRecepcao : TRadioButton
|
00605D05   8B8690050000           mov     eax, [esi+$0590]
00605D0B   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00605D0D   FF92D8000000           call    dword ptr [edx+$00D8]
00605D13   84C0                   test    al, al
00605D15   742E                   jz      00605D45

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00605D17   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
00605D1D   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'select dg_grupo as grupo'
|
00605D23   BAA45F6000             mov     edx, $00605FA4
00605D28   8B08                   mov     ecx, [eax]
00605D2A   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00605D2D   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
00605D33   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'from   descarga'
|
00605D39   BAC85F6000             mov     edx, $00605FC8
00605D3E   8B08                   mov     ecx, [eax]
00605D40   FF5138                 call    dword ptr [ecx+$38]
00605D43   EB2C                   jmp     00605D71

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00605D45   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
00605D4B   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'select md_grupo as grupo'
|
00605D51   BAE05F6000             mov     edx, $00605FE0
00605D56   8B08                   mov     ecx, [eax]
00605D58   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00605D5B   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
00605D61   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'from medicao'
|
00605D67   BA04606000             mov     edx, $00606004
00605D6C   8B08                   mov     ecx, [eax]
00605D6E   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.rbtReferencia : TRadioButton
|
00605D71   8B868C030000           mov     eax, [esi+$038C]
00605D77   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00605D79   FF92D8000000           call    dword ptr [edx+$00D8]
00605D7F   84C0                   test    al, al
00605D81   0F84F7000000           jz      00605E7E
00605D87   8D55E8                 lea     edx, [ebp-$18]

* Reference to control TfrmRelatorioPerformance.cmbReferencia : TComboBox
|
00605D8A   8B86A4030000           mov     eax, [esi+$03A4]

|
00605D90   E86B9DE5FF             call    0045FB00
00605D95   8B45E8                 mov     eax, [ebp-$18]
00605D98   8D55EC                 lea     edx, [ebp-$14]

|
00605D9B   E8B44BE0FF             call    0040A954
00605DA0   837DEC00               cmp     dword ptr [ebp-$14], +$00
00605DA4   7528                   jnz     00605DCE
00605DA6   6A00                   push    $00
00605DA8   0FB70D14606000         movzx   ecx, word ptr [$00606014]
00605DAF   B202                   mov     dl, $02

* Possible String Reference to: 'Selecionar a referÍncia.'
|
00605DB1   B820606000             mov     eax, $00606020

|
00605DB6   E8EDADE4FF             call    00450BA8

* Reference to control TfrmRelatorioPerformance.cmbReferencia : TComboBox
|
00605DBB   8B86A4030000           mov     eax, [esi+$03A4]
00605DC1   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00D4
|
00605DC3   FF92D4000000           call    dword ptr [edx+$00D4]
00605DC9   E988010000             jmp     00605F56
00605DCE   8D45E4                 lea     eax, [ebp-$1C]
00605DD1   50                     push    eax
00605DD2   8D55E0                 lea     edx, [ebp-$20]

* Reference to control TfrmRelatorioPerformance.cmbReferencia : TComboBox
|
00605DD5   8B86A4030000           mov     eax, [esi+$03A4]

|
00605DDB   E8209DE5FF             call    0045FB00
00605DE0   8B45E0                 mov     eax, [ebp-$20]
00605DE3   B904000000             mov     ecx, $00000004
00605DE8   BA04000000             mov     edx, $00000004

|
00605DED   E8D6FFDFFF             call    00405DC8
00605DF2   8B45E4                 mov     eax, [ebp-$1C]
00605DF5   33D2                   xor     edx, edx

|
00605DF7   E88454E0FF             call    0040B280
00605DFC   8BD8                   mov     ebx, eax
00605DFE   8D45DC                 lea     eax, [ebp-$24]
00605E01   50                     push    eax
00605E02   8D55D8                 lea     edx, [ebp-$28]

* Reference to control TfrmRelatorioPerformance.cmbReferencia : TComboBox
|
00605E05   8B86A4030000           mov     eax, [esi+$03A4]

|
00605E0B   E8F09CE5FF             call    0045FB00
00605E10   8B45D8                 mov     eax, [ebp-$28]
00605E13   B902000000             mov     ecx, $00000002
00605E18   BA01000000             mov     edx, $00000001

|
00605E1D   E8A6FFDFFF             call    00405DC8
00605E22   8B45DC                 mov     eax, [ebp-$24]
00605E25   33D2                   xor     edx, edx

|
00605E27   E85454E0FF             call    0040B280
00605E2C   66B90100               mov     cx, $0001
00605E30   8BD0                   mov     edx, eax
00605E32   8BC3                   mov     eax, ebx

|
00605E34   E82782E0FF             call    0040E060
00605E39   DD5DF0                 fstp    qword ptr [ebp-$10]
00605E3C   9B                     wait
00605E3D   FF75F4                 push    dword ptr [ebp-$0C]
00605E40   FF75F0                 push    dword ptr [ebp-$10]
00605E43   8D45FC                 lea     eax, [ebp-$04]

* Possible String Reference to: 'yyyyMMdd'
|
00605E46   BA44606000             mov     edx, $00606044

|
00605E4B   E83490E0FF             call    0040EE84

* Possible String Reference to: 'where md_referencia = ''
|
00605E50   6858606000             push    $00606058
00605E55   FF75FC                 push    dword ptr [ebp-$04]
00605E58   6878606000             push    $00606078
00605E5D   8D45D4                 lea     eax, [ebp-$2C]
00605E60   BA03000000             mov     edx, $00000003

|
00605E65   E8BEFDDFFF             call    00405C28
00605E6A   8B55D4                 mov     edx, [ebp-$2C]

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00605E6D   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
00605E73   8B8048020000           mov     eax, [eax+$0248]
00605E79   8B08                   mov     ecx, [eax]
00605E7B   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.rbtHorario : TRadioButton
|
00605E7E   8B86A4040000           mov     eax, [esi+$04A4]
00605E84   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00605E86   FF92D8000000           call    dword ptr [edx+$00D8]
00605E8C   84C0                   test    al, al
00605E8E   7512                   jnz     00605EA2

* Reference to control TfrmRelatorioPerformance.rbtReferenciaRecepcao : TRadioButton
|
00605E90   8B8690050000           mov     eax, [esi+$0590]
00605E96   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00605E98   FF92D8000000           call    dword ptr [edx+$00D8]
00605E9E   84C0                   test    al, al
00605EA0   742E                   jz      00605ED0

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00605EA2   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
00605EA8   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'group by dg_grupo'
|
00605EAE   BA84606000             mov     edx, $00606084
00605EB3   8B08                   mov     ecx, [eax]
00605EB5   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00605EB8   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
00605EBE   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'order by dg_grupo'
|
00605EC4   BAA0606000             mov     edx, $006060A0
00605EC9   8B08                   mov     ecx, [eax]
00605ECB   FF5138                 call    dword ptr [ecx+$38]
00605ECE   EB2C                   jmp     00605EFC

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00605ED0   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
00605ED6   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'group by md_grupo'
|
00605EDC   BABC606000             mov     edx, $006060BC
00605EE1   8B08                   mov     ecx, [eax]
00605EE3   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00605EE6   8B86C4030000           mov     eax, [esi+$03C4]

* Reference to field TQuery.OFFS_0248
|
00605EEC   8B8048020000           mov     eax, [eax+$0248]

* Possible String Reference to: 'order by md_grupo'
|
00605EF2   BAD8606000             mov     edx, $006060D8
00605EF7   8B08                   mov     ecx, [eax]
00605EF9   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00605EFC   8B86C4030000           mov     eax, [esi+$03C4]

|
00605F02   E8F585E9FF             call    0049E4FC
00605F07   EB33                   jmp     00605F3C
00605F09   BAF0606000             mov     edx, $006060F0
00605F0E   8BC3                   mov     eax, ebx

|
00605F10   E82399E9FF             call    0049F838
00605F15   8D55D0                 lea     edx, [ebp-$30]
00605F18   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TComboBox.OFFS_60
|
00605F1A   FF5160                 call    dword ptr [ecx+$60]
00605F1D   8B55D0                 mov     edx, [ebp-$30]

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
00605F20   8B869C030000           mov     eax, [esi+$039C]

* Reference to field TComboBox.OFFS_0284
|
00605F26   8B8084020000           mov     eax, [eax+$0284]
00605F2C   8B08                   mov     ecx, [eax]
00605F2E   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00605F31   8B86C4030000           mov     eax, [esi+$03C4]

|
00605F37   E8E4B0E9FF             call    004A1020

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00605F3C   8B9EC4030000           mov     ebx, [esi+$03C4]

* Reference to field TQuery.OFFS_00A1
|
00605F42   80BBA100000000         cmp     byte ptr [ebx+$00A1], $00
00605F49   74BE                   jz      00605F09

* Reference to control TfrmRelatorioPerformance.qryPesquisa : TQuery
|
00605F4B   8B86C4030000           mov     eax, [esi+$03C4]

|
00605F51   E8BA85E9FF             call    0049E510
00605F56   33C0                   xor     eax, eax
00605F58   5A                     pop     edx
00605F59   59                     pop     ecx
00605F5A   59                     pop     ecx
00605F5B   648910                 mov     fs:[eax], edx

****** FINALLY
|

* Possible String Reference to: '^[ãÂ]√'
|
00605F5E   68955F6000             push    $00605F95
00605F63   8D45D0                 lea     eax, [ebp-$30]
00605F66   BA02000000             mov     edx, $00000002

|
00605F6B   E858F9DFFF             call    004058C8
00605F70   8D45D8                 lea     eax, [ebp-$28]
00605F73   BA05000000             mov     edx, $00000005

|
00605F78   E84BF9DFFF             call    004058C8
00605F7D   8D45EC                 lea     eax, [ebp-$14]

|
00605F80   E81FF9DFFF             call    004058A4
00605F85   8D45FC                 lea     eax, [ebp-$04]

|
00605F88   E817F9DFFF             call    004058A4
00605F8D   C3                     ret


|
00605F8E   E901F1DFFF             jmp     00405094
00605F93   EBCE                   jmp     00605F63

****** END
|
00605F95   5E                     pop     esi
00605F96   5B                     pop     ebx
00605F97   8BE5                   mov     esp, ebp
00605F99   5D                     pop     ebp
00605F9A   C3                     ret

*)
end;

procedure TfrmRelatorioPerformance.cmbAgenteDropDown(Sender : TObject);
begin
(*
00605BB0   55                     push    ebp
00605BB1   8BEC                   mov     ebp, esp
00605BB3   6A00                   push    $00
00605BB5   53                     push    ebx
00605BB6   56                     push    esi
00605BB7   8BD8                   mov     ebx, eax
00605BB9   33C0                   xor     eax, eax
00605BBB   55                     push    ebp

* Possible String Reference to: 'È9ÙﬂˇÎ^[Y]√'
|
00605BBC   68565C6000             push    $00605C56

***** TRY
|
00605BC1   64FF30                 push    dword ptr fs:[eax]
00605BC4   648920                 mov     fs:[eax], esp

* Reference to control TfrmRelatorioPerformance.cmbAgente : TComboBox
|
00605BC7   8B83B8030000           mov     eax, [ebx+$03B8]
00605BCD   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
00605BCF   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmRelatorioPerformance.cmbAgente : TComboBox
|
00605BD5   8B83B8030000           mov     eax, [ebx+$03B8]

* Reference to field TComboBox.OFFS_0284
|
00605BDB   8B8084020000           mov     eax, [eax+$0284]
00605BE1   8B10                   mov     edx, [eax]
00605BE3   FF5244                 call    dword ptr [edx+$44]

* Reference to control TfrmRelatorioPerformance.qryAgente : TQuery
|
00605BE6   8B83C0030000           mov     eax, [ebx+$03C0]

|
00605BEC   E81F89E9FF             call    0049E510

* Reference to control TfrmRelatorioPerformance.qryAgente : TQuery
|
00605BF1   8B83C0030000           mov     eax, [ebx+$03C0]

|
00605BF7   E80089E9FF             call    0049E4FC
00605BFC   EB33                   jmp     00605C31
00605BFE   BA685C6000             mov     edx, $00605C68
00605C03   8BC6                   mov     eax, esi

|
00605C05   E82E9CE9FF             call    0049F838
00605C0A   8D55FC                 lea     edx, [ebp-$04]
00605C0D   8B08                   mov     ecx, [eax]
00605C0F   FF5160                 call    dword ptr [ecx+$60]
00605C12   8B55FC                 mov     edx, [ebp-$04]

* Reference to control TfrmRelatorioPerformance.cmbAgente : TComboBox
|
00605C15   8B83B8030000           mov     eax, [ebx+$03B8]

* Reference to field TComboBox.OFFS_0284
|
00605C1B   8B8084020000           mov     eax, [eax+$0284]
00605C21   8B08                   mov     ecx, [eax]
00605C23   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryAgente : TQuery
|
00605C26   8B83C0030000           mov     eax, [ebx+$03C0]

|
00605C2C   E8EFB3E9FF             call    004A1020

* Reference to control TfrmRelatorioPerformance.qryAgente : TQuery
|
00605C31   8BB3C0030000           mov     esi, [ebx+$03C0]

* Reference to field TQuery.OFFS_00A1
|
00605C37   80BEA100000000         cmp     byte ptr [esi+$00A1], $00
00605C3E   74BE                   jz      00605BFE
00605C40   33C0                   xor     eax, eax
00605C42   5A                     pop     edx
00605C43   59                     pop     ecx
00605C44   59                     pop     ecx
00605C45   648910                 mov     fs:[eax], edx

****** FINALLY
|

* Possible String Reference to: '^[Y]√'
|
00605C48   685D5C6000             push    $00605C5D
00605C4D   8D45FC                 lea     eax, [ebp-$04]

|
00605C50   E84FFCDFFF             call    004058A4
00605C55   C3                     ret


|
00605C56   E939F4DFFF             jmp     00405094
00605C5B   EBF0                   jmp     00605C4D

****** END
|
00605C5D   5E                     pop     esi
00605C5E   5B                     pop     ebx
00605C5F   59                     pop     ecx
00605C60   5D                     pop     ebp
00605C61   C3                     ret

*)
end;

procedure TfrmRelatorioPerformance.cmbReferenciaDropDown(Sender : TObject);
begin
(*
006060FC   55                     push    ebp
006060FD   8BEC                   mov     ebp, esp
006060FF   83C4F0                 add     esp, -$10
00606102   53                     push    ebx
00606103   56                     push    esi
00606104   33C9                   xor     ecx, ecx
00606106   894DFC                 mov     [ebp-$04], ecx
00606109   8BD8                   mov     ebx, eax
0060610B   33C0                   xor     eax, eax
0060610D   55                     push    ebp
0060610E   68DB616000             push    $006061DB

***** TRY
|
00606113   64FF30                 push    dword ptr fs:[eax]
00606116   648920                 mov     fs:[eax], esp

* Reference to control TfrmRelatorioPerformance.cmbReferencia : TComboBox
|
00606119   8B83A4030000           mov     eax, [ebx+$03A4]
0060611F   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
00606121   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmRelatorioPerformance.cmbReferencia : TComboBox
|
00606127   8B83A4030000           mov     eax, [ebx+$03A4]

* Reference to field TComboBox.OFFS_0284
|
0060612D   8B8084020000           mov     eax, [eax+$0284]
00606133   8B10                   mov     edx, [eax]
00606135   FF5244                 call    dword ptr [edx+$44]

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
00606138   8B839C030000           mov     eax, [ebx+$039C]
0060613E   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
00606140   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
00606146   8B839C030000           mov     eax, [ebx+$039C]

* Reference to field TComboBox.OFFS_0284
|
0060614C   8B8084020000           mov     eax, [eax+$0284]
00606152   8B10                   mov     edx, [eax]
00606154   FF5244                 call    dword ptr [edx+$44]

* Reference to control TfrmRelatorioPerformance.qryReferencia : TQuery
|
00606157   8B83BC030000           mov     eax, [ebx+$03BC]

|
0060615D   E8AE83E9FF             call    0049E510

* Reference to control TfrmRelatorioPerformance.qryReferencia : TQuery
|
00606162   8B83BC030000           mov     eax, [ebx+$03BC]

|
00606168   E88F83E9FF             call    0049E4FC
0060616D   EB47                   jmp     006061B6
0060616F   BAEC616000             mov     edx, $006061EC
00606174   8BC6                   mov     eax, esi

|
00606176   E8BD96E9FF             call    0049F838
0060617B   8B10                   mov     edx, [eax]
0060617D   FF5250                 call    dword ptr [edx+$50]
00606180   DD5DF0                 fstp    qword ptr [ebp-$10]
00606183   9B                     wait
00606184   FF75F4                 push    dword ptr [ebp-$0C]
00606187   FF75F0                 push    dword ptr [ebp-$10]
0060618A   8D45FC                 lea     eax, [ebp-$04]

* Possible String Reference to: 'MM/yyyy'
|
0060618D   BA0C626000             mov     edx, $0060620C

|
00606192   E8ED8CE0FF             call    0040EE84

* Reference to control TfrmRelatorioPerformance.cmbReferencia : TComboBox
|
00606197   8B83A4030000           mov     eax, [ebx+$03A4]

* Reference to field TComboBox.OFFS_0284
|
0060619D   8B8084020000           mov     eax, [eax+$0284]
006061A3   8B55FC                 mov     edx, [ebp-$04]
006061A6   8B08                   mov     ecx, [eax]
006061A8   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioPerformance.qryReferencia : TQuery
|
006061AB   8B83BC030000           mov     eax, [ebx+$03BC]

|
006061B1   E86AAEE9FF             call    004A1020

* Reference to control TfrmRelatorioPerformance.qryReferencia : TQuery
|
006061B6   8BB3BC030000           mov     esi, [ebx+$03BC]

* Reference to field TQuery.OFFS_00A1
|
006061BC   80BEA100000000         cmp     byte ptr [esi+$00A1], $00
006061C3   74AA                   jz      0060616F
006061C5   33C0                   xor     eax, eax
006061C7   5A                     pop     edx
006061C8   59                     pop     ecx
006061C9   59                     pop     ecx
006061CA   648910                 mov     fs:[eax], edx

****** FINALLY
|
006061CD   68E2616000             push    $006061E2
006061D2   8D45FC                 lea     eax, [ebp-$04]

|
006061D5   E8CAF6DFFF             call    004058A4
006061DA   C3                     ret


|
006061DB   E9B4EEDFFF             jmp     00405094
006061E0   EBF0                   jmp     006061D2

****** END
|
006061E2   5E                     pop     esi
006061E3   5B                     pop     ebx
006061E4   8BE5                   mov     esp, ebp
006061E6   5D                     pop     ebp
006061E7   C3                     ret

*)
end;

procedure TfrmRelatorioPerformance.rbtReferenciaClick(Sender : TObject);
begin
(*
00607AF0   53                     push    ebx
00607AF1   8BD8                   mov     ebx, eax
00607AF3   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioPerformance.sbtnImprimir : TSpeedButton
|
00607AF5   8B8324050000           mov     eax, [ebx+$0524]

|
00607AFB   E8207FE5FF             call    0045FA20

* Reference to control TfrmRelatorioPerformance.cmbReferencia : TComboBox
|
00607B00   8B83A4030000           mov     eax, [ebx+$03A4]
00607B06   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
00607B08   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmRelatorioPerformance.cmbReferencia : TComboBox
|
00607B0E   8B83A4030000           mov     eax, [ebx+$03A4]

* Reference to field TComboBox.OFFS_0284
|
00607B14   8B8084020000           mov     eax, [eax+$0284]
00607B1A   8B10                   mov     edx, [eax]
00607B1C   FF5244                 call    dword ptr [edx+$44]

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
00607B1F   8B839C030000           mov     eax, [ebx+$039C]
00607B25   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
00607B27   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
00607B2D   8B839C030000           mov     eax, [ebx+$039C]

* Reference to field TComboBox.OFFS_0284
|
00607B33   8B8084020000           mov     eax, [eax+$0284]
00607B39   8B10                   mov     edx, [eax]
00607B3B   FF5244                 call    dword ptr [edx+$44]

* Reference to control TfrmRelatorioPerformance.cmbRota : TComboBox
|
00607B3E   8B83B0030000           mov     eax, [ebx+$03B0]
00607B44   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
00607B46   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmRelatorioPerformance.cmbRota : TComboBox
|
00607B4C   8B83B0030000           mov     eax, [ebx+$03B0]

* Reference to field TComboBox.OFFS_0284
|
00607B52   8B8084020000           mov     eax, [eax+$0284]
00607B58   8B10                   mov     edx, [eax]
00607B5A   FF5244                 call    dword ptr [edx+$44]

* Reference to control TfrmRelatorioPerformance.cmbAgente : TComboBox
|
00607B5D   8B83B8030000           mov     eax, [ebx+$03B8]
00607B63   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
00607B65   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmRelatorioPerformance.cmbAgente : TComboBox
|
00607B6B   8B83B8030000           mov     eax, [ebx+$03B8]

* Reference to field TComboBox.OFFS_0284
|
00607B71   8B8084020000           mov     eax, [eax+$0284]
00607B77   8B10                   mov     edx, [eax]
00607B79   FF5244                 call    dword ptr [edx+$44]

* Reference to control TfrmRelatorioPerformance.qryMedicao : TQuery
|
00607B7C   8B83C8030000           mov     eax, [ebx+$03C8]

|
00607B82   E88969E9FF             call    0049E510
00607B87   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioPerformance.tbsReferencia : TTabSheet
|
00607B89   8B833C040000           mov     eax, [ebx+$043C]

* Reference to : TTabStrings._PROC_004C6FB0()
|
00607B8F   E81CF4EBFF             call    004C6FB0
00607B94   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioPerformance.tbsRota : TTabSheet
|
00607B96   8B836C040000           mov     eax, [ebx+$046C]

* Reference to : TTabStrings._PROC_004C6FB0()
|
00607B9C   E80FF4EBFF             call    004C6FB0
00607BA1   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioPerformance.tbsAgente : TTabSheet
|
00607BA3   8B838C040000           mov     eax, [ebx+$048C]

* Reference to : TTabStrings._PROC_004C6FB0()
|
00607BA9   E802F4EBFF             call    004C6FB0
00607BAE   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioPerformance.tbsEmissao : TTabSheet
|
00607BB0   8B83A8040000           mov     eax, [ebx+$04A8]

* Reference to : TTabStrings._PROC_004C6FB0()
|
00607BB6   E8F5F3EBFF             call    004C6FB0

* Reference to control TfrmRelatorioPerformance.rbtReferencia : TRadioButton
|
00607BBB   8B838C030000           mov     eax, [ebx+$038C]
00607BC1   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00607BC3   FF92D8000000           call    dword ptr [edx+$00D8]
00607BC9   8BD0                   mov     edx, eax

* Reference to control TfrmRelatorioPerformance.cmbReferencia : TComboBox
|
00607BCB   8B83A4030000           mov     eax, [ebx+$03A4]
00607BD1   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TComboBox.OFFS_68
|
00607BD3   FF5168                 call    dword ptr [ecx+$68]

* Reference to control TfrmRelatorioPerformance.rbtAgente : TRadioButton
|
00607BD6   8B8394030000           mov     eax, [ebx+$0394]
00607BDC   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00607BDE   FF92D8000000           call    dword ptr [edx+$00D8]
00607BE4   8BD0                   mov     edx, eax
00607BE6   80F201                 xor     dl, $01

* Reference to control TfrmRelatorioPerformance.cmbGrupo : TComboBox
|
00607BE9   8B839C030000           mov     eax, [ebx+$039C]
00607BEF   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TComboBox.OFFS_68
|
00607BF1   FF5168                 call    dword ptr [ecx+$68]

* Reference to control TfrmRelatorioPerformance.rbtRota : TRadioButton
|
00607BF4   8B8390030000           mov     eax, [ebx+$0390]
00607BFA   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00607BFC   FF92D8000000           call    dword ptr [edx+$00D8]
00607C02   84C0                   test    al, al
00607C04   7516                   jnz     00607C1C

* Reference to control TfrmRelatorioPerformance.rbtHorario : TRadioButton
|
00607C06   8B83A4040000           mov     eax, [ebx+$04A4]
00607C0C   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00607C0E   FF92D8000000           call    dword ptr [edx+$00D8]
00607C14   84C0                   test    al, al
00607C16   7504                   jnz     00607C1C
00607C18   33D2                   xor     edx, edx
00607C1A   EB02                   jmp     00607C1E
00607C1C   B201                   mov     dl, $01

* Reference to control TfrmRelatorioPerformance.cmbRota : TComboBox
|
00607C1E   8B83B0030000           mov     eax, [ebx+$03B0]
00607C24   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TComboBox.OFFS_68
|
00607C26   FF5168                 call    dword ptr [ecx+$68]

* Reference to control TfrmRelatorioPerformance.rbtAgente : TRadioButton
|
00607C29   8B8394030000           mov     eax, [ebx+$0394]
00607C2F   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00607C31   FF92D8000000           call    dword ptr [edx+$00D8]
00607C37   8BD0                   mov     edx, eax

* Reference to control TfrmRelatorioPerformance.cmbAgente : TComboBox
|
00607C39   8B83B8030000           mov     eax, [ebx+$03B8]
00607C3F   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TComboBox.OFFS_68
|
00607C41   FF5168                 call    dword ptr [ecx+$68]
00607C44   5B                     pop     ebx
00607C45   C3                     ret

*)
end;

procedure TfrmRelatorioPerformance.FormActivate(Sender : TObject);
begin
(*
00607858   53                     push    ebx
00607859   56                     push    esi
0060785A   8BF2                   mov     esi, edx
0060785C   8BD8                   mov     ebx, eax
0060785E   8BD6                   mov     edx, esi
00607860   8BC3                   mov     eax, ebx

* Reference to : TfrmBaseClient.FormActivate()
|
00607862   E8D134F6FF             call    0056AD38
00607867   BA01000000             mov     edx, $00000001
0060786C   8BC3                   mov     eax, ebx

* Reference to : TApplication._PROC_0047AD84()
|
0060786E   E81135E7FF             call    0047AD84

* Reference to control TfrmRelatorioPerformance.tbsPesquisa : TTabSheet
|
00607873   8B9384030000           mov     edx, [ebx+$0384]

* Reference to control TfrmRelatorioPerformance.PageControl : TPageControl
|
00607879   8B8380030000           mov     eax, [ebx+$0380]

* Reference to : TTabStrings._PROC_004C7994()
|
0060787F   E81001ECFF             call    004C7994
00607884   8BD6                   mov     edx, esi
00607886   8BC3                   mov     eax, ebx

* Reference to : TfrmRelatorioPerformance.rbtReferenciaClick()
|
00607888   E863020000             call    00607AF0
0060788D   5E                     pop     esi
0060788E   5B                     pop     ebx
0060788F   C3                     ret

*)
end;

procedure TfrmRelatorioPerformance._PROC_006061E8(Sender : TObject);
begin
(*
006061E8   1400                   adc     al, $00
006061EA   0000                   add     [eax], al

*)
end;

procedure TfrmRelatorioPerformance._PROC_00606490(Sender : TObject);
begin
(*
00606490   0400                   add     al, +$00
00606492   0000                   add     [eax], al

*)
end;

procedure TfrmRelatorioPerformance._PROC_00607890(Sender : TObject);
begin
(*
00607890   53                     push    ebx
00607891   56                     push    esi
00607892   8BF0                   mov     esi, eax

* Reference to field TfrmRelatorioPerformance.OFFS_0374
|
00607894   8D8674030000           lea     eax, [esi+$0374]

* Possible String Reference to: 'Performance'
|
0060789A   BA0C796000             mov     edx, $0060790C

|
0060789F   E854E0DFFF             call    004058F8

* Reference to field TfrmRelatorioPerformance.OFFS_0378
|
006078A4   8D8678030000           lea     eax, [esi+$0378]

* Possible String Reference to: 'Vers„o 8.1'
|
006078AA   BA20796000             mov     edx, $00607920

|
006078AF   E844E0DFFF             call    004058F8
006078B4   B301                   mov     bl, $01
006078B6   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioPerformance.tbsReferenciaRecepcao : TTabSheet
|
006078B8   8B8664050000           mov     eax, [esi+$0564]

* Reference to : TTabStrings._PROC_004C6FB0()
|
006078BE   E8EDF6EBFF             call    004C6FB0
006078C3   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioPerformance.tbsReferencia : TTabSheet
|
006078C5   8B863C040000           mov     eax, [esi+$043C]

* Reference to : TTabStrings._PROC_004C6FB0()
|
006078CB   E8E0F6EBFF             call    004C6FB0
006078D0   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioPerformance.tbsRota : TTabSheet
|
006078D2   8B866C040000           mov     eax, [esi+$046C]

* Reference to : TTabStrings._PROC_004C6FB0()
|
006078D8   E8D3F6EBFF             call    004C6FB0
006078DD   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioPerformance.tbsAgente : TTabSheet
|
006078DF   8B868C040000           mov     eax, [esi+$048C]

* Reference to : TTabStrings._PROC_004C6FB0()
|
006078E5   E8C6F6EBFF             call    004C6FB0
006078EA   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioPerformance.tbsEmissao : TTabSheet
|
006078EC   8B86A8040000           mov     eax, [esi+$04A8]

* Reference to : TTabStrings._PROC_004C6FB0()
|
006078F2   E8B9F6EBFF             call    004C6FB0
006078F7   8BC6                   mov     eax, esi

|
006078F9   E8CA33F6FF             call    0056ACC8
006078FE   8BC3                   mov     eax, ebx
00607900   5E                     pop     esi
00607901   5B                     pop     ebx
00607902   C3                     ret

*)
end;

procedure TfrmRelatorioPerformance._PROC_006094C6(Sender : TObject);
begin
(*
006094C6   47                     inc     edi
006094C7   001C4B                 add     [ebx+ecx*2], bl
006094CA   40                     inc     eax
006094CB   000C8547005848         add     [$48580047+eax*4], cl
006094D2   40                     inc     eax
006094D3   00744840               add     [eax+ecx*2+$40], dh
006094D7   00905547008C           add     [eax+$8C004755], dl
006094DD   844600                 test    [esi+$00], al
006094E0   845B47                 test    [ebx+$47], bl
006094E3   000C31                 add     [ecx+esi], cl
006094E6   42                     inc     edx
006094E7   006C5747               add     [edi+edx*2+$47], ch
006094EB   00B8574700F4           add     [eax+$F4004757], bh
006094F1   58                     pop     eax
006094F2   47                     inc     edi
006094F3   00E8                   add     al, ch
006094F5   F8                     clc
006094F6   45                     inc     ebp
006094F7   0094C542008462         add     [ebp+eax*8+$62840042], dl
006094FE   47                     inc     edi
006094FF   0070C2                 add     [eax-$3E], dh
00609502   42                     inc     edx
00609503   0070AB                 add     [eax-$55], dh
00609506   47                     inc     edi
00609507   00E0                   add     al, ah
00609509   51                     push    ecx
0060950A   47                     inc     edi
0060950B   00B07E4600BC           add     [eax+$BC00467E], dh
00609511   844600                 test    [esi+$00], al
00609514   08844600B0EB45         or      [esi+eax*2+$45EBB000], al
0060951B   002C79                 add     [ecx+edi*2], ch
0060951E   46                     inc     esi
0060951F   00B85E4700B8           add     [eax+$B800475E], bh
00609525   7546                   jnz     0060956D
00609527   00F0                   add     al, dh
00609529   EA4500F4EA             jmp     $EAF40045
0060952E   45                     inc     ebp
0060952F   00AC5F47006C24         add     [edi+ebx*2+$246C0047], ch
00609536   46                     inc     esi
00609537   003CA8                 add     [eax+ebp*4], bh
0060953A   47                     inc     edi
0060953B   00CC                   add     ah, cl
0060953D   F8                     clc
0060953E   45                     inc     ebp
0060953F   002CED450058FA         add     [$FA580045+ebp*8], ch
00609546   45                     inc     ebp
00609547   00C8                   add     al, cl
00609549   61                     popa
0060954A   47                     inc     edi
0060954B   008460470094FB         add     [eax+$FB940047], al
00609552   45                     inc     ebp
00609553   00C4                   add     ah, al
00609555   624700                 bound   eax, qword ptr [edi+$00]
00609558   F0                     lock
00609559   2446                   and     al, $46
0060955B   000C76                 add     [esi+esi*2], cl
0060955E   46                     inc     esi
0060955F   00CC                   add     ah, cl
00609561   7646                   jbe     006095A9
00609563   00C0                   add     al, al
00609565   7146                   jno     006095AD
00609567   00B0764600C8           add     [eax+$C8004676], dh
0060956D   4F                     dec     edi
0060956E   47                     inc     edi
0060956F   0008                   add     [eax], cl
00609571   6A47                   push    $47
00609573   00A042460034           add     [eax+$34004642], ah
00609579   7D47                   jnl     006095C2
0060957B   004882                 add     [eax-$7E], cl
0060957E   47                     inc     edi
0060957F   00748047               add     [eax+eax*4+$47], dh
00609583   0038                   add     [eax], bh
00609585   43                     inc     ebx
00609586   46                     inc     esi
00609587   005C4346               add     [ebx+eax*2+$46], bl
0060958B   00C4                   add     ah, al
0060958D   834700C8               add     dword ptr [edi+$00], -$38
00609591   844700                 test    [edi+$00], al
00609594   94                     xchg    eax, esp
00609595   41                     inc     ecx
00609596   46                     inc     esi
00609597   00A08C4600F8           add     [eax+$F800468C], ah
0060959D   7746                   jnbe    006095E5
0060959F   0000                   add     [eax], al

006095A1   8C4700                 mov     word ptr [edi+$00], es
006095A4   148C                   adc     al, $8C
006095A6   46                     inc     esi
006095A7   006874                 add     [eax+$74], ch
006095AA   46                     inc     esi
006095AB   00648D46               add     [ebp+ecx*4+$46], ah
006095AF   0088A34700A8           add     [eax+$A80047A3], cl
006095B5   49                     dec     ecx
006095B6   47                     inc     edi
006095B7   00584C                 add     [eax+$4C], bl
006095BA   47                     inc     edi
006095BB   004093                 add     [eax-$6D], al
006095BE   47                     inc     edi
006095BF   00905647000C           add     [eax+$C004756], dl
006095C5   57                     push    edi
006095C6   47                     inc     edi
006095C7   00D4                   add     ah, dl
006095C9   A7                     cmpsd
006095CA   47                     inc     edi
006095CB   00A45347006CA2         add     [ebx+edx*2+$A26C0047], ah
006095D2   47                     inc     edi
006095D3   009C86470060A4         add     [esi+eax*4+$A4600047], bl
006095DA   47                     inc     edi
006095DB   00C4                   add     ah, al
006095DD   61                     popa
006095DE   47                     inc     edi
006095DF   005C9A60               add     [edx+ebx*4+$60], bl
006095E3   007098                 add     [eax-$68], dh
006095E6   60                     pusha
006095E7   00A4915C001800         add     [ecx+edx*4+$18005C], ah
006095EE   1D986000C0             sbb     eax, $C0006098
006095F3   0300                   add     eax, [eax]
006095F5   0000                   add     [eax], al

*)
end;

end.