unit uFrmRelatorioResFat;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics,
  Controls, Forms, Dialogs, StdCtrls
type
  TfrmRelatorioResFat=class(TForm)
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
    procedure CBGraficoClick(Sender : TObject);
    procedure sbtnPesquisarClick(Sender : TObject);
    procedure cmbGrupoDropDown(Sender : TObject);
    procedure cmbReferenciaDropDown(Sender : TObject);
    procedure rbtGeralClick(Sender : TObject);
    procedure FormActivate(Sender : TObject);
    procedure _PROC_00603F18(Sender : TObject);
    procedure _PROC_0060439C(Sender : TObject);
    procedure _PROC_0060443E(Sender : TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end ;

var
  frmRelatorioResFat: TfrmRelatorioResFat;

{This file is generated by DeDe Ver 3.50.04 Copyright (c) 1999-2002 DaFixer}

implementation

{$R *.DFM}

procedure TfrmRelatorioResFat.CBGraficoClick(Sender : TObject);
begin
(*
00603BE4   53                     push    ebx
00603BE5   8BD8                   mov     ebx, eax

* Reference to control TfrmRelatorioResFat.CBGrafico : TCheckBox
|
00603BE7   8B8334050000           mov     eax, [ebx+$0534]
00603BED   8B10                   mov     edx, [eax]

* Possible reference to virtual method TCheckBox.OFFS_00D8
|
00603BEF   FF92D8000000           call    dword ptr [edx+$00D8]
00603BF5   8BD0                   mov     edx, eax
00603BF7   80F201                 xor     dl, $01

* Reference to control TfrmRelatorioResFat.DBGridGeral : TDBGrid
|
00603BFA   8B83C4030000           mov     eax, [ebx+$03C4]

|
00603C00   E81BBEE5FF             call    0045FA20

* Reference to control TfrmRelatorioResFat.CBGrafico : TCheckBox
|
00603C05   8B8334050000           mov     eax, [ebx+$0534]
00603C0B   8B10                   mov     edx, [eax]

* Possible reference to virtual method TCheckBox.OFFS_00D8
|
00603C0D   FF92D8000000           call    dword ptr [edx+$00D8]
00603C13   8BD0                   mov     edx, eax

* Reference to control TfrmRelatorioResFat.cmbGraficoGeral : TComboBox
|
00603C15   8B8338050000           mov     eax, [ebx+$0538]

|
00603C1B   E800BEE5FF             call    0045FA20

* Reference to control TfrmRelatorioResFat.CBGrafico : TCheckBox
|
00603C20   8B8334050000           mov     eax, [ebx+$0534]
00603C26   8B10                   mov     edx, [eax]

* Possible reference to virtual method TCheckBox.OFFS_00D8
|
00603C28   FF92D8000000           call    dword ptr [edx+$00D8]
00603C2E   84C0                   test    al, al
00603C30   7412                   jz      00603C44

* Reference to control TfrmRelatorioResFat.cmbGraficoGeral : TComboBox
|
00603C32   8B8338050000           mov     eax, [ebx+$0538]
00603C38   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00DC
|
00603C3A   FF92DC000000           call    dword ptr [edx+$00DC]
00603C40   85C0                   test    eax, eax
00603C42   7404                   jz      00603C48
00603C44   33D2                   xor     edx, edx
00603C46   EB02                   jmp     00603C4A
00603C48   B201                   mov     dl, $01

* Reference to control TfrmRelatorioResFat.ChGraficoGeralLig : TChart
|
00603C4A   8B833C050000           mov     eax, [ebx+$053C]

|
00603C50   E8CBBDE5FF             call    0045FA20

* Reference to control TfrmRelatorioResFat.CBGrafico : TCheckBox
|
00603C55   8B8334050000           mov     eax, [ebx+$0534]
00603C5B   8B10                   mov     edx, [eax]

* Possible reference to virtual method TCheckBox.OFFS_00D8
|
00603C5D   FF92D8000000           call    dword ptr [edx+$00D8]
00603C63   84C0                   test    al, al
00603C65   7411                   jz      00603C78

* Reference to control TfrmRelatorioResFat.cmbGraficoGeral : TComboBox
|
00603C67   8B8338050000           mov     eax, [ebx+$0538]
00603C6D   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00DC
|
00603C6F   FF92DC000000           call    dword ptr [edx+$00DC]
00603C75   48                     dec     eax
00603C76   7404                   jz      00603C7C
00603C78   33D2                   xor     edx, edx
00603C7A   EB02                   jmp     00603C7E
00603C7C   B201                   mov     dl, $01

* Reference to control TfrmRelatorioResFat.ChGraficoGeralVol : TChart
|
00603C7E   8B8344050000           mov     eax, [ebx+$0544]

|
00603C84   E897BDE5FF             call    0045FA20

* Reference to control TfrmRelatorioResFat.CBGrafico : TCheckBox
|
00603C89   8B8334050000           mov     eax, [ebx+$0534]
00603C8F   8B10                   mov     edx, [eax]

* Possible reference to virtual method TCheckBox.OFFS_00D8
|
00603C91   FF92D8000000           call    dword ptr [edx+$00D8]
00603C97   84C0                   test    al, al
00603C99   7413                   jz      00603CAE

* Reference to control TfrmRelatorioResFat.cmbGraficoGeral : TComboBox
|
00603C9B   8B8338050000           mov     eax, [ebx+$0538]
00603CA1   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00DC
|
00603CA3   FF92DC000000           call    dword ptr [edx+$00DC]
00603CA9   83F802                 cmp     eax, +$02
00603CAC   7404                   jz      00603CB2
00603CAE   33D2                   xor     edx, edx
00603CB0   EB02                   jmp     00603CB4
00603CB2   B201                   mov     dl, $01

* Reference to control TfrmRelatorioResFat.ChGraficoGeralVal : TChart
|
00603CB4   8B8350050000           mov     eax, [ebx+$0550]

|
00603CBA   E861BDE5FF             call    0045FA20
00603CBF   5B                     pop     ebx
00603CC0   C3                     ret

*)
end;

procedure TfrmRelatorioResFat.sbtnPesquisarClick(Sender : TObject);
begin
(*
00604084   55                     push    ebp
00604085   8BEC                   mov     ebp, esp
00604087   B906000000             mov     ecx, $00000006
0060408C   6A00                   push    $00
0060408E   6A00                   push    $00
00604090   49                     dec     ecx
00604091   75F9                   jnz     0060408C
00604093   53                     push    ebx
00604094   56                     push    esi
00604095   8BF2                   mov     esi, edx
00604097   8BD8                   mov     ebx, eax
00604099   33C0                   xor     eax, eax
0060409B   55                     push    ebp
0060409C   688F436000             push    $0060438F

***** TRY
|
006040A1   64FF30                 push    dword ptr fs:[eax]
006040A4   648920                 mov     fs:[eax], esp

* Reference to control TfrmRelatorioResFat.rbtGrupo : TRadioButton
|
006040A7   8B8390030000           mov     eax, [ebx+$0390]
006040AD   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
006040AF   FF92D8000000           call    dword ptr [edx+$00D8]
006040B5   84C0                   test    al, al
006040B7   7516                   jnz     006040CF

* Reference to control TfrmRelatorioResFat.rbtRota : TRadioButton
|
006040B9   8B8394030000           mov     eax, [ebx+$0394]
006040BF   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
006040C1   FF92D8000000           call    dword ptr [edx+$00D8]
006040C7   84C0                   test    al, al
006040C9   0F84A0000000           jz      0060416F
006040CF   8D55F0                 lea     edx, [ebp-$10]

* Reference to control TfrmRelatorioResFat.cmbGrupo : TComboBox
|
006040D2   8B83A0030000           mov     eax, [ebx+$03A0]

|
006040D8   E823BAE5FF             call    0045FB00
006040DD   8B45F0                 mov     eax, [ebp-$10]
006040E0   8D55F4                 lea     edx, [ebp-$0C]

|
006040E3   E86C68E0FF             call    0040A954
006040E8   837DF400               cmp     dword ptr [ebp-$0C], +$00
006040EC   7528                   jnz     00604116
006040EE   6A00                   push    $00
006040F0   0FB70D9C436000         movzx   ecx, word ptr [$0060439C]
006040F7   B202                   mov     dl, $02

* Possible String Reference to: 'Selecionar o grupo.'
|
006040F9   B8A8436000             mov     eax, $006043A8

|
006040FE   E8A5CAE4FF             call    00450BA8

* Reference to control TfrmRelatorioResFat.cmbGrupo : TComboBox
|
00604103   8B83A0030000           mov     eax, [ebx+$03A0]
00604109   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00D4
|
0060410B   FF92D4000000           call    dword ptr [edx+$00D4]
00604111   E946020000             jmp     0060435C
00604116   8D55E8                 lea     edx, [ebp-$18]

* Reference to control TfrmRelatorioResFat.cmbReferencia : TComboBox
|
00604119   8B83A4030000           mov     eax, [ebx+$03A4]

|
0060411F   E8DCB9E5FF             call    0045FB00
00604124   8B45E8                 mov     eax, [ebp-$18]
00604127   8D55EC                 lea     edx, [ebp-$14]

|
0060412A   E82568E0FF             call    0040A954
0060412F   837DEC00               cmp     dword ptr [ebp-$14], +$00
00604133   753A                   jnz     0060416F

* Reference to control TfrmRelatorioResFat.rbtRota : TRadioButton
|
00604135   8B8394030000           mov     eax, [ebx+$0394]
0060413B   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
0060413D   FF92D8000000           call    dword ptr [edx+$00D8]
00604143   84C0                   test    al, al
00604145   7428                   jz      0060416F
00604147   6A00                   push    $00
00604149   0FB70D9C436000         movzx   ecx, word ptr [$0060439C]
00604150   B202                   mov     dl, $02

* Possible String Reference to: 'Selecionar a referência.'
|
00604152   B8C4436000             mov     eax, $006043C4

|
00604157   E84CCAE4FF             call    00450BA8

* Reference to control TfrmRelatorioResFat.cmbReferencia : TComboBox
|
0060415C   8B83A4030000           mov     eax, [ebx+$03A4]
00604162   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00D4
|
00604164   FF92D4000000           call    dword ptr [edx+$00D4]
0060416A   E9ED010000             jmp     0060435C

* Reference to control TfrmRelatorioResFat.rbtGeral : TRadioButton
|
0060416F   8B838C030000           mov     eax, [ebx+$038C]
00604175   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00604177   FF92D8000000           call    dword ptr [edx+$00D8]
0060417D   84C0                   test    al, al
0060417F   745E                   jz      006041DF

* Reference to control TfrmRelatorioResFat.qryPesqGeral : TQuery
|
00604181   8B83B4030000           mov     eax, [ebx+$03B4]

|
00604187   E884A3E9FF             call    0049E510

* Reference to control TfrmRelatorioResFat.qryPesqGeral : TQuery
|
0060418C   8B83B4030000           mov     eax, [ebx+$03B4]

|
00604192   E865A3E9FF             call    0049E4FC
00604197   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioResFat.CBGrafico : TCheckBox
|
00604199   8B8334050000           mov     eax, [ebx+$0534]
0060419F   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TCheckBox.OFFS_00DC
|
006041A1   FF91DC000000           call    dword ptr [ecx+$00DC]
006041A7   8BD6                   mov     edx, esi
006041A9   8BC3                   mov     eax, ebx

* Reference to : TfrmRelatorioResFat.CBGraficoClick()
|
006041AB   E834FAFFFF             call    00603BE4
006041B0   B201                   mov     dl, $01

* Reference to control TfrmRelatorioResFat.tbsGeral : TTabSheet
|
006041B2   8B83B8030000           mov     eax, [ebx+$03B8]

* Reference to : TTabStrings._PROC_004C6FB0()
|
006041B8   E8F32DECFF             call    004C6FB0

* Reference to control TfrmRelatorioResFat.tbsGeral : TTabSheet
|
006041BD   8B93B8030000           mov     edx, [ebx+$03B8]

* Reference to control TfrmRelatorioResFat.PageControl : TPageControl
|
006041C3   8B8380030000           mov     eax, [ebx+$0380]

* Reference to : TTabStrings._PROC_004C7994()
|
006041C9   E8C637ECFF             call    004C7994
006041CE   BA01000000             mov     edx, $00000001
006041D3   8BC3                   mov     eax, ebx

|
006041D5   E8F2F0FFFF             call    006032CC
006041DA   E97D010000             jmp     0060435C

* Reference to control TfrmRelatorioResFat.rbtGrupo : TRadioButton
|
006041DF   8B8390030000           mov     eax, [ebx+$0390]
006041E5   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
006041E7   FF92D8000000           call    dword ptr [edx+$00D8]
006041ED   84C0                   test    al, al
006041EF   7468                   jz      00604259

* Reference to control TfrmRelatorioResFat.qryPesqGrupo : TQuery
|
006041F1   8B8328040000           mov     eax, [ebx+$0428]

|
006041F7   E814A3E9FF             call    0049E510
006041FC   8D55E4                 lea     edx, [ebp-$1C]

* Reference to control TfrmRelatorioResFat.cmbGrupo : TComboBox
|
006041FF   8B83A0030000           mov     eax, [ebx+$03A0]

|
00604205   E8F6B8E5FF             call    0045FB00
0060420A   8B45E4                 mov     eax, [ebp-$1C]
0060420D   33D2                   xor     edx, edx

|
0060420F   E86C70E0FF             call    0040B280
00604214   50                     push    eax

* Possible String Reference to: 'nGrupo'
|
00604215   BAE8436000             mov     edx, $006043E8

* Reference to control TfrmRelatorioResFat.qryPesqGrupo : TQuery
|
0060421A   8B8328040000           mov     eax, [ebx+$0428]

|
00604220   E85B67EBFF             call    004BA980
00604225   5A                     pop     edx

|
00604226   E8C194E9FF             call    0049D6EC

* Reference to control TfrmRelatorioResFat.qryPesqGrupo : TQuery
|
0060422B   8B8328040000           mov     eax, [ebx+$0428]

|
00604231   E8C6A2E9FF             call    0049E4FC
00604236   B201                   mov     dl, $01

* Reference to control TfrmRelatorioResFat.tbsGrupo : TTabSheet
|
00604238   8B8394040000           mov     eax, [ebx+$0494]

* Reference to : TTabStrings._PROC_004C6FB0()
|
0060423E   E86D2DECFF             call    004C6FB0

* Reference to control TfrmRelatorioResFat.tbsGrupo : TTabSheet
|
00604243   8B9394040000           mov     edx, [ebx+$0494]

* Reference to control TfrmRelatorioResFat.PageControl : TPageControl
|
00604249   8B8380030000           mov     eax, [ebx+$0380]

* Reference to : TTabStrings._PROC_004C7994()
|
0060424F   E84037ECFF             call    004C7994
00604254   E903010000             jmp     0060435C

* Reference to control TfrmRelatorioResFat.rbtRota : TRadioButton
|
00604259   8B8394030000           mov     eax, [ebx+$0394]
0060425F   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00604261   FF92D8000000           call    dword ptr [edx+$00D8]
00604267   84C0                   test    al, al
00604269   0F84ED000000           jz      0060435C
0060426F   8D45E0                 lea     eax, [ebp-$20]
00604272   50                     push    eax
00604273   8D55DC                 lea     edx, [ebp-$24]

* Reference to control TfrmRelatorioResFat.cmbReferencia : TComboBox
|
00604276   8B83A4030000           mov     eax, [ebx+$03A4]

|
0060427C   E87FB8E5FF             call    0045FB00
00604281   8B45DC                 mov     eax, [ebp-$24]
00604284   B904000000             mov     ecx, $00000004
00604289   BA04000000             mov     edx, $00000004

|
0060428E   E8351BE0FF             call    00405DC8
00604293   8B45E0                 mov     eax, [ebp-$20]
00604296   33D2                   xor     edx, edx

|
00604298   E8E36FE0FF             call    0040B280
0060429D   8BF0                   mov     esi, eax
0060429F   8D45D8                 lea     eax, [ebp-$28]
006042A2   50                     push    eax
006042A3   8D55D4                 lea     edx, [ebp-$2C]

* Reference to control TfrmRelatorioResFat.cmbReferencia : TComboBox
|
006042A6   8B83A4030000           mov     eax, [ebx+$03A4]

|
006042AC   E84FB8E5FF             call    0045FB00
006042B1   8B45D4                 mov     eax, [ebp-$2C]
006042B4   B902000000             mov     ecx, $00000002
006042B9   BA01000000             mov     edx, $00000001

|
006042BE   E8051BE0FF             call    00405DC8
006042C3   8B45D8                 mov     eax, [ebp-$28]
006042C6   33D2                   xor     edx, edx

|
006042C8   E8B36FE0FF             call    0040B280
006042CD   66B90100               mov     cx, $0001
006042D1   8BD0                   mov     edx, eax
006042D3   8BC6                   mov     eax, esi

|
006042D5   E8869DE0FF             call    0040E060
006042DA   DD5DF8                 fstp    qword ptr [ebp-$08]
006042DD   9B                     wait

* Reference to control TfrmRelatorioResFat.qryPesqRota : TQuery
|
006042DE   8B83C4040000           mov     eax, [ebx+$04C4]

|
006042E4   E827A2E9FF             call    0049E510
006042E9   FF75FC                 push    dword ptr [ebp-$04]
006042EC   FF75F8                 push    dword ptr [ebp-$08]

* Possible String Reference to: 'dtReferencia'
|
006042EF   BAF8436000             mov     edx, $006043F8

* Reference to control TfrmRelatorioResFat.qryPesqRota : TQuery
|
006042F4   8B83C4040000           mov     eax, [ebx+$04C4]

|
006042FA   E88166EBFF             call    004BA980

|
006042FF   E83097E9FF             call    0049DA34
00604304   8D55D0                 lea     edx, [ebp-$30]

* Reference to control TfrmRelatorioResFat.cmbGrupo : TComboBox
|
00604307   8B83A0030000           mov     eax, [ebx+$03A0]

|
0060430D   E8EEB7E5FF             call    0045FB00
00604312   8B45D0                 mov     eax, [ebp-$30]
00604315   33D2                   xor     edx, edx

|
00604317   E8646FE0FF             call    0040B280
0060431C   50                     push    eax

* Possible String Reference to: 'nGrupo'
|
0060431D   BAE8436000             mov     edx, $006043E8

* Reference to control TfrmRelatorioResFat.qryPesqRota : TQuery
|
00604322   8B83C4040000           mov     eax, [ebx+$04C4]

|
00604328   E85366EBFF             call    004BA980
0060432D   5A                     pop     edx

|
0060432E   E8B993E9FF             call    0049D6EC

* Reference to control TfrmRelatorioResFat.qryPesqRota : TQuery
|
00604333   8B83C4040000           mov     eax, [ebx+$04C4]

|
00604339   E8BEA1E9FF             call    0049E4FC
0060433E   B201                   mov     dl, $01

* Reference to control TfrmRelatorioResFat.tbsRota : TTabSheet
|
00604340   8B83A8040000           mov     eax, [ebx+$04A8]

* Reference to : TTabStrings._PROC_004C6FB0()
|
00604346   E8652CECFF             call    004C6FB0

* Reference to control TfrmRelatorioResFat.tbsRota : TTabSheet
|
0060434B   8B93A8040000           mov     edx, [ebx+$04A8]

* Reference to control TfrmRelatorioResFat.PageControl : TPageControl
|
00604351   8B8380030000           mov     eax, [ebx+$0380]

* Reference to : TTabStrings._PROC_004C7994()
|
00604357   E83836ECFF             call    004C7994
0060435C   33C0                   xor     eax, eax
0060435E   5A                     pop     edx
0060435F   59                     pop     ecx
00604360   59                     pop     ecx
00604361   648910                 mov     fs:[eax], edx

****** FINALLY
|
00604364   6896436000             push    $00604396
00604369   8D45D0                 lea     eax, [ebp-$30]
0060436C   BA07000000             mov     edx, $00000007

|
00604371   E85215E0FF             call    004058C8
00604376   8D45EC                 lea     eax, [ebp-$14]

|
00604379   E82615E0FF             call    004058A4
0060437E   8D45F0                 lea     eax, [ebp-$10]

|
00604381   E81E15E0FF             call    004058A4
00604386   8D45F4                 lea     eax, [ebp-$0C]

|
00604389   E81615E0FF             call    004058A4
0060438E   C3                     ret


|
0060438F   E9000DE0FF             jmp     00405094
00604394   EBD3                   jmp     00604369

****** END
|
00604396   5E                     pop     esi
00604397   5B                     pop     ebx
00604398   8BE5                   mov     esp, ebp
0060439A   5D                     pop     ebp
0060439B   C3                     ret

*)
end;

procedure TfrmRelatorioResFat.cmbGrupoDropDown(Sender : TObject);
begin
(*
00603CC4   55                     push    ebp
00603CC5   8BEC                   mov     ebp, esp
00603CC7   6A00                   push    $00
00603CC9   53                     push    ebx
00603CCA   56                     push    esi
00603CCB   8BD8                   mov     ebx, eax
00603CCD   33C0                   xor     eax, eax
00603CCF   55                     push    ebp
00603CD0   68893D6000             push    $00603D89

***** TRY
|
00603CD5   64FF30                 push    dword ptr fs:[eax]
00603CD8   648920                 mov     fs:[eax], esp

* Reference to control TfrmRelatorioResFat.cmbGrupo : TComboBox
|
00603CDB   8B83A0030000           mov     eax, [ebx+$03A0]
00603CE1   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
00603CE3   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmRelatorioResFat.cmbGrupo : TComboBox
|
00603CE9   8B83A0030000           mov     eax, [ebx+$03A0]

* Reference to field TComboBox.OFFS_0284
|
00603CEF   8B8084020000           mov     eax, [eax+$0284]
00603CF5   8B10                   mov     edx, [eax]
00603CF7   FF5244                 call    dword ptr [edx+$44]

* Reference to control TfrmRelatorioResFat.cmbReferencia : TComboBox
|
00603CFA   8B83A4030000           mov     eax, [ebx+$03A4]
00603D00   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
00603D02   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmRelatorioResFat.cmbReferencia : TComboBox
|
00603D08   8B83A4030000           mov     eax, [ebx+$03A4]

* Reference to field TComboBox.OFFS_0284
|
00603D0E   8B8084020000           mov     eax, [eax+$0284]
00603D14   8B10                   mov     edx, [eax]
00603D16   FF5244                 call    dword ptr [edx+$44]

* Reference to control TfrmRelatorioResFat.qryGrupo : TQuery
|
00603D19   8B83B0030000           mov     eax, [ebx+$03B0]

|
00603D1F   E8ECA7E9FF             call    0049E510

* Reference to control TfrmRelatorioResFat.qryGrupo : TQuery
|
00603D24   8B83B0030000           mov     eax, [ebx+$03B0]

|
00603D2A   E8CDA7E9FF             call    0049E4FC
00603D2F   EB33                   jmp     00603D64
00603D31   BA9C3D6000             mov     edx, $00603D9C
00603D36   8BC6                   mov     eax, esi

|
00603D38   E8FBBAE9FF             call    0049F838
00603D3D   8D55FC                 lea     edx, [ebp-$04]
00603D40   8B08                   mov     ecx, [eax]
00603D42   FF5160                 call    dword ptr [ecx+$60]
00603D45   8B55FC                 mov     edx, [ebp-$04]

* Reference to control TfrmRelatorioResFat.cmbGrupo : TComboBox
|
00603D48   8B83A0030000           mov     eax, [ebx+$03A0]

* Reference to field TComboBox.OFFS_0284
|
00603D4E   8B8084020000           mov     eax, [eax+$0284]
00603D54   8B08                   mov     ecx, [eax]
00603D56   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioResFat.qryGrupo : TQuery
|
00603D59   8B83B0030000           mov     eax, [ebx+$03B0]

|
00603D5F   E8BCD2E9FF             call    004A1020

* Reference to control TfrmRelatorioResFat.qryGrupo : TQuery
|
00603D64   8BB3B0030000           mov     esi, [ebx+$03B0]

* Reference to field TQuery.OFFS_00A1
|
00603D6A   80BEA100000000         cmp     byte ptr [esi+$00A1], $00
00603D71   74BE                   jz      00603D31
00603D73   33C0                   xor     eax, eax
00603D75   5A                     pop     edx
00603D76   59                     pop     ecx
00603D77   59                     pop     ecx
00603D78   648910                 mov     fs:[eax], edx

****** FINALLY
|

* Possible String Reference to: '^[Y]Ã'
|
00603D7B   68903D6000             push    $00603D90
00603D80   8D45FC                 lea     eax, [ebp-$04]

|
00603D83   E81C1BE0FF             call    004058A4
00603D88   C3                     ret


|
00603D89   E90613E0FF             jmp     00405094
00603D8E   EBF0                   jmp     00603D80

****** END
|
00603D90   5E                     pop     esi
00603D91   5B                     pop     ebx
00603D92   59                     pop     ecx
00603D93   5D                     pop     ebp
00603D94   C3                     ret

*)
end;

procedure TfrmRelatorioResFat.cmbReferenciaDropDown(Sender : TObject);
begin
(*
00603DA8   55                     push    ebp
00603DA9   8BEC                   mov     ebp, esp
00603DAB   83C4EC                 add     esp, -$14
00603DAE   53                     push    ebx
00603DAF   56                     push    esi
00603DB0   33C9                   xor     ecx, ecx
00603DB2   894DEC                 mov     [ebp-$14], ecx
00603DB5   894DFC                 mov     [ebp-$04], ecx
00603DB8   8BD8                   mov     ebx, eax
00603DBA   33C0                   xor     eax, eax
00603DBC   55                     push    ebp
00603DBD   68A23E6000             push    $00603EA2

***** TRY
|
00603DC2   64FF30                 push    dword ptr fs:[eax]
00603DC5   648920                 mov     fs:[eax], esp

* Reference to control TfrmRelatorioResFat.cmbReferencia : TComboBox
|
00603DC8   8B83A4030000           mov     eax, [ebx+$03A4]
00603DCE   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
00603DD0   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmRelatorioResFat.cmbReferencia : TComboBox
|
00603DD6   8B83A4030000           mov     eax, [ebx+$03A4]

* Reference to field TComboBox.OFFS_0284
|
00603DDC   8B8084020000           mov     eax, [eax+$0284]
00603DE2   8B10                   mov     edx, [eax]
00603DE4   FF5244                 call    dword ptr [edx+$44]

* Reference to control TfrmRelatorioResFat.qryReferencia : TQuery
|
00603DE7   8B83AC030000           mov     eax, [ebx+$03AC]

|
00603DED   E81EA7E9FF             call    0049E510
00603DF2   8D55EC                 lea     edx, [ebp-$14]

* Reference to control TfrmRelatorioResFat.cmbGrupo : TComboBox
|
00603DF5   8B83A0030000           mov     eax, [ebx+$03A0]

|
00603DFB   E800BDE5FF             call    0045FB00
00603E00   8B45EC                 mov     eax, [ebp-$14]
00603E03   33D2                   xor     edx, edx

|
00603E05   E87674E0FF             call    0040B280
00603E0A   50                     push    eax

* Possible String Reference to: 'nGrupo'
|
00603E0B   BAB83E6000             mov     edx, $00603EB8

* Reference to control TfrmRelatorioResFat.qryReferencia : TQuery
|
00603E10   8B83AC030000           mov     eax, [ebx+$03AC]

|
00603E16   E8656BEBFF             call    004BA980
00603E1B   5A                     pop     edx

|
00603E1C   E8CB98E9FF             call    0049D6EC

* Reference to control TfrmRelatorioResFat.qryReferencia : TQuery
|
00603E21   8B83AC030000           mov     eax, [ebx+$03AC]

|
00603E27   E8D0A6E9FF             call    0049E4FC
00603E2C   EB47                   jmp     00603E75
00603E2E   BAC43E6000             mov     edx, $00603EC4
00603E33   8BC6                   mov     eax, esi

|
00603E35   E8FEB9E9FF             call    0049F838
00603E3A   8B10                   mov     edx, [eax]
00603E3C   FF5250                 call    dword ptr [edx+$50]
00603E3F   DD5DF0                 fstp    qword ptr [ebp-$10]
00603E42   9B                     wait
00603E43   FF75F4                 push    dword ptr [ebp-$0C]
00603E46   FF75F0                 push    dword ptr [ebp-$10]
00603E49   8D45FC                 lea     eax, [ebp-$04]

* Possible String Reference to: 'MM/yyyy'
|
00603E4C   BAE43E6000             mov     edx, $00603EE4

|
00603E51   E82EB0E0FF             call    0040EE84

* Reference to control TfrmRelatorioResFat.cmbReferencia : TComboBox
|
00603E56   8B83A4030000           mov     eax, [ebx+$03A4]

* Reference to field TComboBox.OFFS_0284
|
00603E5C   8B8084020000           mov     eax, [eax+$0284]
00603E62   8B55FC                 mov     edx, [ebp-$04]
00603E65   8B08                   mov     ecx, [eax]
00603E67   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmRelatorioResFat.qryReferencia : TQuery
|
00603E6A   8B83AC030000           mov     eax, [ebx+$03AC]

|
00603E70   E8ABD1E9FF             call    004A1020

* Reference to control TfrmRelatorioResFat.qryReferencia : TQuery
|
00603E75   8BB3AC030000           mov     esi, [ebx+$03AC]

* Reference to field TQuery.OFFS_00A1
|
00603E7B   80BEA100000000         cmp     byte ptr [esi+$00A1], $00
00603E82   74AA                   jz      00603E2E
00603E84   33C0                   xor     eax, eax
00603E86   5A                     pop     edx
00603E87   59                     pop     ecx
00603E88   59                     pop     ecx
00603E89   648910                 mov     fs:[eax], edx

****** FINALLY
|

* Possible String Reference to: '^[‹å]Ã'
|
00603E8C   68A93E6000             push    $00603EA9
00603E91   8D45EC                 lea     eax, [ebp-$14]

|
00603E94   E80B1AE0FF             call    004058A4
00603E99   8D45FC                 lea     eax, [ebp-$04]

|
00603E9C   E8031AE0FF             call    004058A4
00603EA1   C3                     ret


|
00603EA2   E9ED11E0FF             jmp     00405094
00603EA7   EBE8                   jmp     00603E91

****** END
|
00603EA9   5E                     pop     esi
00603EAA   5B                     pop     ebx
00603EAB   8BE5                   mov     esp, ebp
00603EAD   5D                     pop     ebp
00603EAE   C3                     ret

*)
end;

procedure TfrmRelatorioResFat.rbtGeralClick(Sender : TObject);
begin
(*
00603FA8   53                     push    ebx
00603FA9   8BD8                   mov     ebx, eax

* Reference to control TfrmRelatorioResFat.cmbGrupo : TComboBox
|
00603FAB   8B83A0030000           mov     eax, [ebx+$03A0]
00603FB1   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
00603FB3   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmRelatorioResFat.cmbGrupo : TComboBox
|
00603FB9   8B83A0030000           mov     eax, [ebx+$03A0]

* Reference to field TComboBox.OFFS_0284
|
00603FBF   8B8084020000           mov     eax, [eax+$0284]
00603FC5   8B10                   mov     edx, [eax]
00603FC7   FF5244                 call    dword ptr [edx+$44]

* Reference to control TfrmRelatorioResFat.cmbReferencia : TComboBox
|
00603FCA   8B83A4030000           mov     eax, [ebx+$03A4]
00603FD0   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
00603FD2   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmRelatorioResFat.cmbReferencia : TComboBox
|
00603FD8   8B83A4030000           mov     eax, [ebx+$03A4]

* Reference to field TComboBox.OFFS_0284
|
00603FDE   8B8084020000           mov     eax, [eax+$0284]
00603FE4   8B10                   mov     edx, [eax]
00603FE6   FF5244                 call    dword ptr [edx+$44]
00603FE9   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioResFat.tbsGeral : TTabSheet
|
00603FEB   8B83B8030000           mov     eax, [ebx+$03B8]

* Reference to : TTabStrings._PROC_004C6FB0()
|
00603FF1   E8BA2FECFF             call    004C6FB0
00603FF6   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioResFat.tbsGrupo : TTabSheet
|
00603FF8   8B8394040000           mov     eax, [ebx+$0494]

* Reference to : TTabStrings._PROC_004C6FB0()
|
00603FFE   E8AD2FECFF             call    004C6FB0
00604003   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioResFat.tbsRota : TTabSheet
|
00604005   8B83A8040000           mov     eax, [ebx+$04A8]

* Reference to : TTabStrings._PROC_004C6FB0()
|
0060400B   E8A02FECFF             call    004C6FB0

* Reference to control TfrmRelatorioResFat.qryPesqGeral : TQuery
|
00604010   8B83B4030000           mov     eax, [ebx+$03B4]

|
00604016   E8F5A4E9FF             call    0049E510

* Reference to control TfrmRelatorioResFat.qryPesqGrupo : TQuery
|
0060401B   8B8328040000           mov     eax, [ebx+$0428]

|
00604021   E8EAA4E9FF             call    0049E510

* Reference to control TfrmRelatorioResFat.qryPesqRota : TQuery
|
00604026   8B83C4040000           mov     eax, [ebx+$04C4]

|
0060402C   E8DFA4E9FF             call    0049E510

* Reference to control TfrmRelatorioResFat.rbtGrupo : TRadioButton
|
00604031   8B8390030000           mov     eax, [ebx+$0390]
00604037   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
00604039   FF92D8000000           call    dword ptr [edx+$00D8]
0060403F   84C0                   test    al, al
00604041   7516                   jnz     00604059

* Reference to control TfrmRelatorioResFat.rbtRota : TRadioButton
|
00604043   8B8394030000           mov     eax, [ebx+$0394]
00604049   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
0060404B   FF92D8000000           call    dword ptr [edx+$00D8]
00604051   84C0                   test    al, al
00604053   7504                   jnz     00604059
00604055   33D2                   xor     edx, edx
00604057   EB02                   jmp     0060405B
00604059   B201                   mov     dl, $01

* Reference to control TfrmRelatorioResFat.cmbGrupo : TComboBox
|
0060405B   8B83A0030000           mov     eax, [ebx+$03A0]
00604061   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TComboBox.OFFS_68
|
00604063   FF5168                 call    dword ptr [ecx+$68]

* Reference to control TfrmRelatorioResFat.rbtRota : TRadioButton
|
00604066   8B8394030000           mov     eax, [ebx+$0394]
0060406C   8B10                   mov     edx, [eax]

* Possible reference to virtual method TRadioButton.OFFS_00D8
|
0060406E   FF92D8000000           call    dword ptr [edx+$00D8]
00604074   8BD0                   mov     edx, eax

* Reference to control TfrmRelatorioResFat.cmbReferencia : TComboBox
|
00604076   8B83A4030000           mov     eax, [ebx+$03A4]
0060407C   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TComboBox.OFFS_68
|
0060407E   FF5168                 call    dword ptr [ecx+$68]
00604081   5B                     pop     ebx
00604082   C3                     ret

*)
end;

procedure TfrmRelatorioResFat.FormActivate(Sender : TObject);
begin
(*
00603EEC   53                     push    ebx
00603EED   8BD8                   mov     ebx, eax
00603EEF   8BC3                   mov     eax, ebx

* Reference to : TfrmBaseClient.FormActivate()
|
00603EF1   E8426EF6FF             call    0056AD38
00603EF6   BA01000000             mov     edx, $00000001
00603EFB   8BC3                   mov     eax, ebx

* Reference to : TApplication._PROC_0047AD84()
|
00603EFD   E8826EE7FF             call    0047AD84

* Reference to control TfrmRelatorioResFat.tbsPesquisa : TTabSheet
|
00603F02   8B9384030000           mov     edx, [ebx+$0384]

* Reference to control TfrmRelatorioResFat.PageControl : TPageControl
|
00603F08   8B8380030000           mov     eax, [ebx+$0380]

* Reference to : TTabStrings._PROC_004C7994()
|
00603F0E   E8813AECFF             call    004C7994
00603F13   5B                     pop     ebx
00603F14   C3                     ret

*)
end;

procedure TfrmRelatorioResFat._PROC_00603F18(Sender : TObject);
begin
(*
00603F18   53                     push    ebx
00603F19   56                     push    esi
00603F1A   8BF0                   mov     esi, eax

* Reference to field TfrmRelatorioResFat.OFFS_0374
|
00603F1C   8D8674030000           lea     eax, [esi+$0374]

* Possible String Reference to: 'Resumo do Faturamento'
|
00603F22   BA7C3F6000             mov     edx, $00603F7C

|
00603F27   E8CC19E0FF             call    004058F8

* Reference to field TfrmRelatorioResFat.OFFS_0378
|
00603F2C   8D8678030000           lea     eax, [esi+$0378]

* Possible String Reference to: 'Versão 8.0'
|
00603F32   BA9C3F6000             mov     edx, $00603F9C

|
00603F37   E8BC19E0FF             call    004058F8
00603F3C   B301                   mov     bl, $01
00603F3E   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioResFat.tbsGeral : TTabSheet
|
00603F40   8B86B8030000           mov     eax, [esi+$03B8]

* Reference to : TTabStrings._PROC_004C6FB0()
|
00603F46   E86530ECFF             call    004C6FB0
00603F4B   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioResFat.tbsGrupo : TTabSheet
|
00603F4D   8B8694040000           mov     eax, [esi+$0494]

* Reference to : TTabStrings._PROC_004C6FB0()
|
00603F53   E85830ECFF             call    004C6FB0
00603F58   33D2                   xor     edx, edx

* Reference to control TfrmRelatorioResFat.tbsRota : TTabSheet
|
00603F5A   8B86A8040000           mov     eax, [esi+$04A8]

* Reference to : TTabStrings._PROC_004C6FB0()
|
00603F60   E84B30ECFF             call    004C6FB0
00603F65   8BC6                   mov     eax, esi

|
00603F67   E85C6DF6FF             call    0056ACC8
00603F6C   8BC3                   mov     eax, ebx
00603F6E   5E                     pop     esi
00603F6F   5B                     pop     ebx
00603F70   C3                     ret

*)
end;

procedure TfrmRelatorioResFat._PROC_0060439C(Sender : TObject);
begin
(*
0060439C   0400                   add     al, +$00
0060439E   0000                   add     [eax], al

*)
end;

procedure TfrmRelatorioResFat._PROC_0060443E(Sender : TObject);
begin
(*
0060443E   47                     inc     edi
0060443F   001C4B                 add     [ebx+ecx*2], bl
00604442   40                     inc     eax
00604443   000C8547005848         add     [$48580047+eax*4], cl
0060444A   40                     inc     eax
0060444B   00744840               add     [eax+ecx*2+$40], dh
0060444F   00905547008C           add     [eax+$8C004755], dl
00604455   844600                 test    [esi+$00], al
00604458   845B47                 test    [ebx+$47], bl
0060445B   000C31                 add     [ecx+esi], cl
0060445E   42                     inc     edx
0060445F   006C5747               add     [edi+edx*2+$47], ch
00604463   00B8574700F4           add     [eax+$F4004757], bh
00604469   58                     pop     eax
0060446A   47                     inc     edi
0060446B   00E8                   add     al, ch
0060446D   F8                     clc
0060446E   45                     inc     ebp
0060446F   0094C542008462         add     [ebp+eax*8+$62840042], dl
00604476   47                     inc     edi
00604477   0070C2                 add     [eax-$3E], dh
0060447A   42                     inc     edx
0060447B   0070AB                 add     [eax-$55], dh
0060447E   47                     inc     edi
0060447F   00E0                   add     al, ah
00604481   51                     push    ecx
00604482   47                     inc     edi
00604483   00B07E4600BC           add     [eax+$BC00467E], dh
00604489   844600                 test    [esi+$00], al
0060448C   08844600B0EB45         or      [esi+eax*2+$45EBB000], al
00604493   002C79                 add     [ecx+edi*2], ch
00604496   46                     inc     esi
00604497   00B85E4700B8           add     [eax+$B800475E], bh
0060449D   7546                   jnz     006044E5
0060449F   00F0                   add     al, dh
006044A1   EA4500F4EA             jmp     $EAF40045
006044A6   45                     inc     ebp
006044A7   00AC5F47006C24         add     [edi+ebx*2+$246C0047], ch
006044AE   46                     inc     esi
006044AF   003CA8                 add     [eax+ebp*4], bh
006044B2   47                     inc     edi
006044B3   00CC                   add     ah, cl
006044B5   F8                     clc
006044B6   45                     inc     ebp
006044B7   002CED450058FA         add     [$FA580045+ebp*8], ch
006044BE   45                     inc     ebp
006044BF   00C8                   add     al, cl
006044C1   61                     popa
006044C2   47                     inc     edi
006044C3   008460470094FB         add     [eax+$FB940047], al
006044CA   45                     inc     ebp
006044CB   00C4                   add     ah, al
006044CD   624700                 bound   eax, qword ptr [edi+$00]
006044D0   F0                     lock
006044D1   2446                   and     al, $46
006044D3   000C76                 add     [esi+esi*2], cl
006044D6   46                     inc     esi
006044D7   00CC                   add     ah, cl
006044D9   7646                   jbe     00604521
006044DB   00C0                   add     al, al
006044DD   7146                   jno     00604525
006044DF   00B0764600C8           add     [eax+$C8004676], dh
006044E5   4F                     dec     edi
006044E6   47                     inc     edi
006044E7   0008                   add     [eax], cl
006044E9   6A47                   push    $47
006044EB   00A042460034           add     [eax+$34004642], ah
006044F1   7D47                   jnl     0060453A
006044F3   004882                 add     [eax-$7E], cl
006044F6   47                     inc     edi
006044F7   00748047               add     [eax+eax*4+$47], dh
006044FB   0038                   add     [eax], bh
006044FD   43                     inc     ebx
006044FE   46                     inc     esi
006044FF   005C4346               add     [ebx+eax*2+$46], bl
00604503   00C4                   add     ah, al
00604505   834700C8               add     dword ptr [edi+$00], -$38
00604509   844700                 test    [edi+$00], al
0060450C   94                     xchg    eax, esp
0060450D   41                     inc     ecx
0060450E   46                     inc     esi
0060450F   00A08C4600F8           add     [eax+$F800468C], ah
00604515   7746                   jnbe    0060455D
00604517   0000                   add     [eax], al

00604519   8C4700                 mov     word ptr [edi+$00], es
0060451C   148C                   adc     al, $8C
0060451E   46                     inc     esi
0060451F   006874                 add     [eax+$74], ch
00604522   46                     inc     esi
00604523   00648D46               add     [ebp+ecx*4+$46], ah
00604527   0088A34700A8           add     [eax+$A80047A3], cl
0060452D   49                     dec     ecx
0060452E   47                     inc     edi
0060452F   00584C                 add     [eax+$4C], bl
00604532   47                     inc     edi
00604533   004093                 add     [eax-$6D], al
00604536   47                     inc     edi
00604537   00905647000C           add     [eax+$C004756], dl
0060453D   57                     push    edi
0060453E   47                     inc     edi
0060453F   00D4                   add     ah, dl
00604541   A7                     cmpsd
00604542   47                     inc     edi
00604543   00A45347006CA2         add     [ebx+edx*2+$A26C0047], ah
0060454A   47                     inc     edi
0060454B   009C86470060A4         add     [esi+eax*4+$A4600047], bl
00604552   47                     inc     edi
00604553   00C4                   add     ah, al
00604555   61                     popa
00604556   47                     inc     edi
00604557   0090786000C1           add     [eax+$C1006078], dl
0060455D   0022                   add     [edx], ah
0060455F   5B                     pop     ebx
00604560   60                     pusha
00604561   008003000000           add     [eax+$0003], al
00604567   000B                   add     [ebx], cl
00604569   50                     push    eax
0060456A   61                     popa
0060456B   676543                 inc     ebx
0060456E   6F                     outsd
0060456F   6E                     outsb
00604570   7472                   jz      006045E4
00604572   6F                     outsd
00604573   6C                     insb
00604574   8403                   test    [ebx], al
00604576   0000                   add     [eax], al

00604578   0100                   add     [eax], eax
0060457A   0B746273               or      esi, [edx+$73]
0060457E   50                     push    eax
0060457F   657371                 jnb     006045F3
00604582   7569                   jnz     006045ED
00604584   7361                   jnb     006045E7
00604586   8803                   mov     [ebx], al
00604588   0000                   add     [eax], al

0060458A   0200                   add     al, byte ptr [eax]
0060458C   094772                 or      [edi+$72], eax
0060458F   6F                     outsd
00604590   7570                   jnz     00604602
00604592   42                     inc     edx
00604593   6F                     outsd
00604594   7831                   js      006045C7
00604596   8C03                   mov     word ptr [ebx], es
00604598   0000                   add     [eax], al

0060459A   0300                   add     eax, [eax]
0060459C   0D72627452             or      eax, $52746272
006045A1   6566657265             jb      0060460B
006045A6   6E                     outsb
006045A7   636961                 arpl    [ecx+$61], bp
006045AA   90                     nop
006045AB   0300                   add     eax, [eax]
006045AD   0003                   add     [ebx], al
006045AF   0007                   add     [edi], al
006045B1   7262                   jb      00604615
006045B3   7452                   jz      00604607
006045B5   6F                     outsd
006045B6   7461                   jz      00604619
006045B8   94                     xchg    eax, esp
006045B9   0300                   add     eax, [eax]
006045BB   0003                   add     [ebx], al
006045BD   0009                   add     [ecx], cl
006045BF   7262                   jb      00604623
006045C1   7441                   jz      00604604
006045C3   67656E                 outsb
006045C6   7465                   jz      0060462D
006045C8   98                     cwde 
006045C9   0300                   add     eax, [eax]
006045CB   000400                 add     [eax+eax], al
006045CE   06                     push    es
006045CF   4C                     dec     esp
006045D0   61                     popa
006045D1   62656C                 bound   esp, qword ptr [ebp+$6C]
006045D4   319C0300000500         xor     [ebx+eax+$50000], ebx
006045DB   08636D                 or      [ebx+$6D], ah
006045DE   624772                 bound   eax, qword ptr [edi+$72]
006045E1   7570                   jnz     00604653
006045E3   6F                     outsd
006045E4   A003000004             mov     al, byte ptr [$04000003]
006045E9   0006                   add     [esi], al
006045EB   4C                     dec     esp
006045EC   61                     popa
006045ED   62656C                 bound   esp, qword ptr [ebp+$6C]
006045F0   32A40300000500         xor     ah, byte ptr [ebx+eax+$50000]
006045F7   0D636D6252             or      eax, $52626D63
006045FC   6566657265             jb      00604666
00604601   6E                     outsb
00604602   636961                 arpl    [ecx+$61], bp
00604605   A803                   test    al, $03
00604607   0000                   add     [eax], al

00604609   06                     push    es
0060460A   000D7362746E           add     [$6E746273], cl
00604610   50                     push    eax
00604611   657371                 jnb     00604685
00604614   7569                   jnz     0060467F
00604616   7361                   jnb     00604679
00604618   72AC                   jb      006045C6
0060461A   0300                   add     eax, [eax]
0060461C   000400                 add     [eax+eax], al
0060461F   06                     push    es
00604620   4C                     dec     esp
00604621   61                     popa
00604622   62656C                 bound   esp, qword ptr [ebp+$6C]
00604625   33B003000005           xor     esi, [eax+$5000003]
0060462B   0007                   add     [edi], al
0060462D   636D62                 arpl    [ebp+$62], bp
00604630   52                     push    edx
00604631   6F                     outsd
00604632   7461                   jz      00604695
00604634   B403                   mov     ah, $03
00604636   0000                   add     [eax], al

00604638   0400                   add     al, +$00
0060463A   06                     push    es
0060463B   4C                     dec     esp
0060463C   61                     popa
0060463D   62656C                 bound   esp, qword ptr [ebp+$6C]
00604640   34B8                   xor     al, $B8
00604642   0300                   add     eax, [eax]
00604644   00050009636D           add     [$6D630900], al
0060464A   624167                 bound   eax, qword ptr [ecx+$67]
0060464D   656E                   outsb
0060464F   7465                   jz      006046B6
00604651   BC03000007             mov     esp, $07000003
00604656   000D71727952           add     [$52797271], cl
0060465C   6566657265             jb      006046C6
00604661   6E                     outsb
00604662   636961                 arpl    [ecx+$61], bp
00604665   C00300                 rol     byte ptr [ebx], $00
00604668   0007                   add     [edi], al
0060466A   0009                   add     [ecx], cl
0060466C   7172                   jno     006046E0
0060466E   7941                   jns     006046B1
00604670   67656E                 outsb
00604673   7465                   jz      006046DA
00604675   C403                   les     eax, [ebx]
00604677   0000                   add     [eax], al

00604679   07                     pop     es
0060467A   000B                   add     [ebx], cl
0060467C   7172                   jno     006046F0
0060467E   7950                   jns     006046D0
00604680   657371                 jnb     006046F4
00604683   7569                   jnz     006046EE
00604685   7361                   jnb     006046E8
00604687   C803                   enter   , $03
00604689   0000                   add     [eax], al

0060468B   07                     pop     es
0060468C   000A                   add     [edx], cl
0060468E   7172                   jno     00604702
00604690   794D                   jns     006046DF
00604692   65646963616FCC0300     imul    esp, fs:[ebx+$61], $0003CC6F
0060469B   0008                   add     [eax], cl
0060469D   0017                   add     [edi], dl
0060469F   7172                   jno     00604713
006046A1   794D                   jns     006046F0
006046A3   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
006046AC   7265                   jb      00604713
006046AE   66657265               jb      00604717
006046B2   6E                     outsb
006046B3   636961                 arpl    [ecx+$61], bp
006046B6   D003                   rol     byte ptr [ebx], 1
006046B8   0000                   add     [eax], al

006046BA   0900                   or      [eax], eax
006046BC   127172                 adc     dh, byte ptr [ecx+$72]
006046BF   794D                   jns     0060470E
006046C1   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
006046CA   677275                 jb      00604742
006046CD   706F                   jo      0060473E
006046CF   D4                     aam
006046D0   0300                   add     eax, [eax]
006046D2   0009                   add     [ecx], cl
006046D4   0011                   add     [ecx], dl
006046D6   7172                   jno     0060474A
006046D8   794D                   jns     00604727
006046DA   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
006046E3   726F                   jb      00604754
006046E5   7461                   jz      00604748
006046E7   D803                   fadd    dword ptr [ebx]
006046E9   0000                   add     [eax], al

006046EB   0A00                   or      al, byte ptr [eax]
006046ED   107172                 adc     [ecx+$72], dh
006046F0   794D                   jns     0060473F
006046F2   65646963616F616765     imul    esp, fs:[ebx+$61], $6567616F
006046FB   6E                     outsb
006046FC   7465                   jz      00604763
006046FE   DC03                   fadd    qword ptr [ebx]
00604700   0000                   add     [eax], al

00604702   0800                   or      [eax], al
00604704   197172                 sbb     [ecx+$72], esi
00604707   794D                   jns     00604756
00604709   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
00604712   6461                   popa
00604714   7461                   jz      00604777
00604716   5F                     pop     edi
00604717   6C                     insb
00604718   656974757261E00300     imul    esi, gs:[ebp+esi*2+$72], $0003E061
00604721   0008                   add     [eax], cl
00604723   0018                   add     [eax], bl
00604725   7172                   jno     00604799
00604727   794D                   jns     00604776
00604729   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
00604732   686F72615F             push    $5F61726F
00604737   696E6963696FE4         imul    ebp, [esi+$69], $E46F6963
0060473E   0300                   add     eax, [eax]
00604740   0008                   add     [eax], cl
00604742   00157172794D           add     [$4D797271], dl
00604748   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
00604751   686F72615F             push    $5F61726F
00604756   66696DE80300           imul    bp, word ptr [ebp-$18], $0003
0060475C   0009                   add     [ecx], cl
0060475E   00157172794D           add     [$4D797271], dl
00604764   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
0060476D   6C                     insb
0060476E   696761636F6573         imul    esp, [edi+$61], $73656F63
00604775   EC                     in      al, dx
00604776   0300                   add     eax, [eax]
00604778   0009                   add     [ecx], cl
0060477A   001A                   add     [edx], bl
0060477C   7172                   jno     006047F0
0060477E   794D                   jns     006047CD
00604780   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
00604789   6C                     insb
0060478A   6569747572615F6361     imul    esi, gs:[ebp+esi*2+$72], $61635F61
00604793   6D                     insd
00604794   706F                   jo      00604805
00604796   F0                     lock
00604797   0300                   add     eax, [eax]
00604799   0009                   add     [ecx], cl
0060479B   001471                 add     [ecx+esi*2], dl
0060479E   7279                   jb      00604819
006047A0   4D                     dec     ebp
006047A1   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
006047AA   61                     popa
006047AB   6E                     outsb
006047AC   61                     popa
006047AD   6C                     insb
006047AE   697365F4030000         imul    esi, [ebx+$65], $000003F4
006047B5   0900                   or      [eax], eax
006047B7   1C71                   sbb     al, $71
006047B9   7279                   jb      00604834
006047BB   4D                     dec     ebp
006047BC   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
006047C5   6661                   popa
006047C7   7475                   jz      0060483E
006047C9   7261                   jb      0060482C
006047CB   646F                   outsd
006047CD   5F                     pop     edi
006047CE   6E                     outsb
006047CF   6F                     outsd
006047D0   726D                   jb      0060483F
006047D2   61                     popa
006047D3   6C                     insb
006047D4   F8                     clc
006047D5   0300                   add     eax, [eax]
006047D7   0009                   add     [ecx], cl
006047D9   001B                   add     [ebx], bl
006047DB   7172                   jno     0060484F
006047DD   794D                   jns     0060482C
006047DF   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
006047E8   6661                   popa
006047EA   7475                   jz      00604861
006047EC   7261                   jb      0060484F
006047EE   646F                   outsd
006047F0   5F                     pop     edi
006047F1   6D                     insd
006047F2   65646961FC03000009     imul    esp, fs:[ecx-$04], $09000003
006047FB   001C71                 add     [ecx+esi*2], bl
006047FE   7279                   jb      00604879
00604800   4D                     dec     ebp
00604801   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
0060480A   6661                   popa
0060480C   7475                   jz      00604883
0060480E   7261                   jb      00604871
00604810   646F                   outsd
00604812   5F                     pop     edi
00604813   6D                     insd
00604814   696E696D610004         imul    ebp, [esi+$69], $0400616D
0060481B   0000                   add     [eax], al

0060481D   0900                   or      [eax], eax
0060481F   157172794D             adc     eax, $4D797271
00604824   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
0060482D   656D                   insd
0060482F   6974696461730404       imul    esi, [ecx+ebp*2+$64], $04047361
00604837   0000                   add     [eax], al

00604839   0900                   or      [eax], eax
0060483B   1D7172794D             sbb     eax, $4D797271
00604840   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
00604849   656D                   insd
0060484B   6974696461735F32       imul    esi, [ecx+ebp*2+$64], $325F7361
00604853   5F                     pop     edi
00604854   7665                   jbe     006048BB
00604856   7A65                   jp      006048BD
00604858   7308                   jnb     00604862
0060485A   0400                   add     al, +$00
0060485C   0009                   add     [ecx], cl
0060485E   0019                   add     [ecx], bl
00604860   7172                   jno     006048D4
00604862   794D                   jns     006048B1
00604864   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
0060486D   6E                     outsb
0060486E   61                     popa
0060486F   6F                     outsd
00604870   5F                     pop     edi
00604871   656D                   insd
00604873   6974696461730C04       imul    esi, [ecx+ebp*2+$64], $040C7361
0060487B   0000                   add     [eax], al

0060487D   0900                   or      [eax], eax
0060487F   187172                 sbb     [ecx+$72], dh
00604882   794D                   jns     006048D1
00604884   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
0060488D   656E                   outsb
0060488F   7472                   jz      00604903
00604891   656761                 popa
00604894   5F                     pop     edi
00604895   6D                     insd
00604896   61                     popa
00604897   6F                     outsd
00604898   100400                 adc     [eax+eax], al
0060489B   0009                   add     [ecx], cl
0060489D   001C71                 add     [ecx+esi*2], bl
006048A0   7279                   jb      0060491B
006048A2   4D                     dec     ebp
006048A3   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
006048AC   656E                   outsb
006048AE   7472                   jz      00604922
006048B0   656761                 popa
006048B3   5F                     pop     edi
006048B4   7669                   jbe     0060491F
006048B6   7369                   jnb     00604921
006048B8   6E                     outsb
006048B9   686F140400             push    $0004146F
006048BE   0009                   add     [ecx], cl
006048C0   001A                   add     [edx], bl
006048C2   7172                   jno     00604936
006048C4   794D                   jns     00604913
006048C6   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
006048CF   656E                   outsb
006048D1   7472                   jz      00604945
006048D3   656761                 popa
006048D6   5F                     pop     edi
006048D7   706F                   jo      00604948
006048D9   7274                   jb      0060494F
006048DB   61                     popa
006048DC   180400                 sbb     [eax+eax], al
006048DF   0009                   add     [ecx], cl
006048E1   001C71                 add     [ecx+esi*2], bl
006048E4   7279                   jb      0060495F
006048E6   4D                     dec     ebp
006048E7   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
006048F0   656E                   outsb
006048F2   7472                   jz      00604966
006048F4   61                     popa
006048F5   6761                   popa
006048F7   5F                     pop     edi
006048F8   636F72                 arpl    [edi+$72], bp
006048FB   7265                   jb      00604962
006048FD   696F1C04000009         imul    ebp, [edi+$1C], $09000004
00604904   001D7172794D           add     [$4D797271], bl
0060490A   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
00604913   656E                   outsb
00604915   7472                   jz      00604989
00604917   656761                 popa
0060491A   5F                     pop     edi
0060491B   7265                   jb      00604982
0060491D   637573                 arpl    [ebp+$73], si
00604920   61                     popa
00604921   646F                   outsd
00604923   200400                 and     [eax+eax], al
00604926   0009                   add     [ecx], cl
00604928   001A                   add     [edx], bl
0060492A   7172                   jno     0060499E
0060492C   794D                   jns     0060497B
0060492E   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
00604937   656E                   outsb
00604939   7472                   jz      006049AD
0060493B   656761                 popa
0060493E   5F                     pop     edi
0060493F   6F                     outsd
00604940   7574                   jnz     006049B6
00604942   726F                   jb      006049B3
00604944   2404                   and     al, $04
00604946   0000                   add     [eax], al

00604948   0900                   or      [eax], eax
0060494A   157172794D             adc     eax, $4D797271
0060494F   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
00604958   6E                     outsb
00604959   61                     popa
0060495A   6F                     outsd
0060495B   5F                     pop     edi
0060495C   657865                 js      006049C4
0060495F   6328                   arpl    [eax], bp
00604961   0400                   add     al, +$00
00604963   0009                   add     [ecx], cl
00604965   0013                   add     [ebx], dl
00604967   7172                   jno     006049DB
00604969   794D                   jns     006049B8
0060496B   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
00604974   667261                 jb      006049D8
00604977   7564                   jnz     006049DD
00604979   652C04                 sub     al, $04
0060497C   0000                   add     [eax], al

0060497E   0900                   or      [eax], eax
00604980   17                     pop     ss
00604981   7172                   jno     006049F5
00604983   794D                   jns     006049D2
00604985   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
0060498E   7061                   jo      006049F1
00604990   7261                   jb      006049F3
00604992   5F                     pop     edi
00604993   636F72                 arpl    [edi+$72], bp
00604996   7465                   jz      006049FD
00604998   300400                 xor     [eax+eax], al
0060499B   0009                   add     [ecx], cl
0060499D   001471                 add     [ecx+esi*2], dl
006049A0   7279                   jb      00604A1B
006049A2   4D                     dec     ebp
006049A3   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
006049AC   636F72                 arpl    [edi+$72], bp
006049AF   7461                   jz      00604A12
006049B1   646F                   outsd
006049B3   3404                   xor     al, $04
006049B5   0000                   add     [eax], al

006049B7   0900                   or      [eax], eax
006049B9   1B7172                 sbb     esi, [ecx+$72]
006049BC   794D                   jns     00604A0B
006049BE   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
006049C7   656D                   insd
006049C9   6974696461735F61       imul    esi, [ecx+ebp*2+$64], $615F7361
006049D1   7669                   jbe     00604A3C
006049D3   736F                   jnb     00604A44
006049D5   380400                 cmp     [eax+eax], al
006049D8   0009                   add     [ecx], cl
006049DA   001C71                 add     [ecx+esi*2], bl
006049DD   7279                   jb      00604A58
006049DF   4D                     dec     ebp
006049E0   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
006049E9   656D                   insd
006049EB   6974696461735F32       imul    esi, [ecx+ebp*2+$64], $325F7361
006049F3   5F                     pop     edi
006049F4   7669                   jbe     00604A5F
006049F6   61                     popa
006049F7   733C                   jnb     00604A35
006049F9   0400                   add     al, +$00
006049FB   0001                   add     [ecx], al
006049FD   000D74627352           add     [$52736274], cl
00604A03   6566657265             jb      00604A6D
00604A08   6E                     outsb
00604A09   636961                 arpl    [ecx+$61], bp
00604A0C   40                     inc     eax
00604A0D   0400                   add     al, +$00
00604A0F   0002                   add     [edx], al
00604A11   0009                   add     [ecx], cl
00604A13   47                     inc     edi
00604A14   726F                   jb      00604A85
00604A16   7570                   jnz     00604A88
00604A18   42                     inc     edx
00604A19   6F                     outsd
00604A1A   7832                   js      00604A4E
00604A1C   44                     inc     esp
00604A1D   0400                   add     al, +$00
00604A1F   000B                   add     [ebx], cl
00604A21   0010                   add     [eax], dl
00604A23   44                     inc     esp
00604A24   42                     inc     edx
00604A25   47                     inc     edi
00604A26   7269                   jb      00604A91
00604A28   6452                   push    edx
00604A2A   6566657265             jb      00604A94
00604A2F   6E                     outsb
00604A30   636961                 arpl    [ecx+$61], bp
00604A33   48                     dec     eax
00604A34   0400                   add     al, +$00
00604A36   000C00                 add     [eax+eax], cl
00604A39   0964734D               or      [ebx+esi*2+$4D], esp
00604A3D   65646963616F4C0400     imul    esp, fs:[ebx+$61], $00044C6F
00604A46   000400                 add     [eax+eax], al
00604A49   06                     push    es
00604A4A   4C                     dec     esp
00604A4B   61                     popa
00604A4C   62656C                 bound   esp, qword ptr [ebp+$6C]
00604A4F   3550040000             xor     eax, $00000450
00604A54   0D000D4442             or      eax, $42440D00
00604A59   45                     inc     ebp
00604A5A   6447                   inc     edi
00604A5C   7275                   jb      00604AD3
00604A5E   706F                   jo      00604ACF
00604A60   52                     push    edx
00604A61   6F                     outsd
00604A62   7461                   jz      00604AC5
00604A64   54                     push    esp
00604A65   0400                   add     al, +$00
00604A67   000400                 add     [eax+eax], al
00604A6A   06                     push    es
00604A6B   4C                     dec     esp
00604A6C   61                     popa
00604A6D   62656C                 bound   esp, qword ptr [ebp+$6C]
00604A70   3658                   pop     eax
00604A72   0400                   add     al, +$00
00604A74   000D000E4442           add     [$42440E00], cl
00604A7A   45                     inc     ebp
00604A7B   6452                   push    edx
00604A7D   6566657265             jb      00604AE7
00604A82   6E                     outsb
00604A83   636961                 arpl    [ecx+$61], bp
00604A86   5C                     pop     esp
00604A87   0400                   add     al, +$00
00604A89   00050010636D           add     [$6D631000], al
00604A8F   625665                 bound   edx, qword ptr [esi+$65]
00604A92   7252                   jb      00604AE6
00604A94   6566657265             jb      00604AFE
00604A99   6E                     outsb
00604A9A   636961                 arpl    [ecx+$61], bp
00604A9D   60                     pusha
00604A9E   0400                   add     al, +$00
00604AA0   000400                 add     [eax+eax], al
00604AA3   06                     push    es
00604AA4   4C                     dec     esp
00604AA5   61                     popa
00604AA6   62656C                 bound   esp, qword ptr [ebp+$6C]
00604AA9   37                     aaa
00604AAA   640400                 add     al, +$00
00604AAD   0009                   add     [ecx], cl
00604AAF   0020                   add     [eax], ah
00604AB1   7172                   jno     00604B25
00604AB3   794D                   jns     00604B02
00604AB5   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
00604ABE   61                     popa
00604ABF   6C                     insb
00604AC0   7465                   jz      00604B27
00604AC2   7261                   jb      00604B25
00604AC4   636F65                 arpl    [edi+$65], bp
00604AC7   735F                   jnb     00604B28
00604AC9   636164                 arpl    [ecx+$64], sp
00604ACC   61                     popa
00604ACD   7374                   jnb     00604B43
00604ACF   726F                   jb      00604B40
00604AD1   6804000009             push    $09000004
00604AD6   001E                   add     [esi], bl
00604AD8   7172                   jno     00604B4C
00604ADA   794D                   jns     00604B29
00604ADC   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
00604AE5   696E636C757361         imul    ebp, [esi+$63], $6173756C
00604AEC   6F                     outsd
00604AED   5F                     pop     edi
00604AEE   636164                 arpl    [ecx+$64], sp
00604AF1   61                     popa
00604AF2   7374                   jnb     00604B68
00604AF4   726F                   jb      00604B65
00604AF6   6C                     insb
00604AF7   0400                   add     al, +$00
00604AF9   0001                   add     [ecx], al
00604AFB   0007                   add     [edi], al
00604AFD   7462                   jz      00604B61
00604AFF   7352                   jnb     00604B53
00604B01   6F                     outsd
00604B02   7461                   jz      00604B65
00604B04   7004                   jo      00604B0A
00604B06   0000                   add     [eax], al

00604B08   0200                   add     al, byte ptr [eax]
00604B0A   094772                 or      [edi+$72], eax
00604B0D   6F                     outsd
00604B0E   7570                   jnz     00604B80
00604B10   42                     inc     edx
00604B11   6F                     outsd
00604B12   7833                   js      00604B47
00604B14   7404                   jz      00604B1A
00604B16   0000                   add     [eax], al

00604B18   0400                   add     al, +$00
00604B1A   06                     push    es
00604B1B   4C                     dec     esp
00604B1C   61                     popa
00604B1D   62656C                 bound   esp, qword ptr [ebp+$6C]
00604B20   387804                 cmp     [eax+$04], bh
00604B23   0000                   add     [eax], al

00604B25   0400                   add     al, +$00
00604B27   06                     push    es
00604B28   4C                     dec     esp
00604B29   61                     popa
00604B2A   62656C                 bound   esp, qword ptr [ebp+$6C]
00604B2D   397C0400               cmp     [esp+eax+$00], edi
00604B31   000400                 add     [eax+eax], al
00604B34   07                     pop     es
00604B35   4C                     dec     esp
00604B36   61                     popa
00604B37   62656C                 bound   esp, qword ptr [ebp+$6C]
00604B3A   3130                   xor     [eax], esi
00604B3C   80040000               add     byte ptr [eax+eax], $00
00604B40   0D00074442             or      eax, $42440700
00604B45   45                     inc     ebp
00604B46   64697431840400000D     imul    esi, fs:[ecx+esi-$7C], $0D000004
00604B4F   0007                   add     [edi], al
00604B51   44                     inc     esp
00604B52   42                     inc     edx
00604B53   45                     inc     ebp
00604B54   646974328804000005     imul    esi, fs:[edx+esi-$78], $05000004
00604B5D   000A                   add     [edx], cl
00604B5F   636D62                 arpl    [ebp+$62], bp
00604B62   56                     push    esi
00604B63   657252                 jb      00604BB8
00604B66   6F                     outsd
00604B67   7461                   jz      00604BCA
00604B69   8C0400                 mov     word ptr [eax+eax], es
00604B6C   0001                   add     [ecx], al
00604B6E   0009                   add     [ecx], cl
00604B70   7462                   jz      00604BD4
00604B72   7341                   jnb     00604BB5
00604B74   67656E                 outsb
00604B77   7465                   jz      00604BDE
00604B79   90                     nop
00604B7A   0400                   add     al, +$00
00604B7C   0002                   add     [edx], al
00604B7E   0009                   add     [ecx], cl
00604B80   47                     inc     edi
00604B81   726F                   jb      00604BF2
00604B83   7570                   jnz     00604BF5
00604B85   42                     inc     edx
00604B86   6F                     outsd
00604B87   7834                   js      00604BBD
00604B89   94                     xchg    eax, esp
00604B8A   0400                   add     al, +$00
00604B8C   000400                 add     [eax+eax], al
00604B8F   07                     pop     es
00604B90   4C                     dec     esp
00604B91   61                     popa
00604B92   62656C                 bound   esp, qword ptr [ebp+$6C]
00604B95   3131                   xor     [ecx], esi
00604B97   98                     cwde 
00604B98   0400                   add     al, +$00
00604B9A   000400                 add     [eax+eax], al
00604B9D   07                     pop     es
00604B9E   4C                     dec     esp
00604B9F   61                     popa
00604BA0   62656C                 bound   esp, qword ptr [ebp+$6C]
00604BA3   3133                   xor     [ebx], esi
00604BA5   9C                     pushf   
00604BA6   0400                   add     al, +$00
00604BA8   000D00074442           add     [$42440700], cl
00604BAE   45                     inc     ebp
00604BAF   64697433A004000005     imul    esi, fs:[ebx+esi-$60], $05000004
00604BB8   000C63                 add     [ebx], cl
00604BBB   6D                     insd
00604BBC   625665                 bound   edx, qword ptr [esi+$65]
00604BBF   7241                   jb      00604C02
00604BC1   67656E                 outsb
00604BC4   7465                   jz      00604C2B
00604BC6   A4                     movsb
00604BC7   0400                   add     al, +$00
00604BC9   0003                   add     [ebx], al
00604BCB   000A                   add     [edx], cl
00604BCD   7262                   jb      00604C31
00604BCF   7448                   jz      00604C19
00604BD1   6F                     outsd
00604BD2   7261                   jb      00604C35
00604BD4   7269                   jb      00604C3F
00604BD6   6F                     outsd
00604BD7   A804                   test    al, $04
00604BD9   0000                   add     [eax], al

00604BDB   0100                   add     [eax], eax
00604BDD   0A746273               or      dh, byte ptr [edx+$73]
00604BE1   45                     inc     ebp
00604BE2   6D                     insd
00604BE3   697373616FAC04         imul    esi, [ebx+$73], $04AC6F61
00604BEA   0000                   add     [eax], al

00604BEC   07                     pop     es
00604BED   000A                   add     [edx], cl
00604BEF   7172                   jno     00604C63
00604BF1   7948                   jns     00604C3B
00604BF3   6F                     outsd
00604BF4   7261                   jb      00604C57
00604BF6   7269                   jb      00604C61
00604BF8   6F                     outsd
00604BF9   B004                   mov     al, $04
00604BFB   0000                   add     [eax], al

00604BFD   0C00                   or      al, $00
00604BFF   0A647344               or      ah, byte ptr [ebx+esi*2+$44]
00604C03   657363                 jnb     00604C69
00604C06   61                     popa
00604C07   7267                   jb      00604C70
00604C09   61                     popa
00604C0A   B404                   mov     ah, $04
00604C0C   0000                   add     [eax], al

00604C0E   0200                   add     al, byte ptr [eax]
00604C10   094772                 or      [edi+$72], eax
00604C13   6F                     outsd
00604C14   7570                   jnz     00604C86
00604C16   42                     inc     edx
00604C17   6F                     outsd
00604C18   7835                   js      00604C4F
00604C1A   B804000004             mov     eax, $04000004
00604C1F   0007                   add     [edi], al
00604C21   4C                     dec     esp
00604C22   61                     popa
00604C23   62656C                 bound   esp, qword ptr [ebp+$6C]
00604C26   3132                   xor     [edx], esi
00604C28   BC04000004             mov     esp, $04000004
00604C2D   0007                   add     [edi], al
00604C2F   4C                     dec     esp
00604C30   61                     popa
00604C31   62656C                 bound   esp, qword ptr [ebp+$6C]
00604C34   3134C0                 xor     [eax+eax*8], esi
00604C37   0400                   add     al, +$00
00604C39   000B                   add     [ebx], cl
00604C3B   0007                   add     [edi], al
00604C3D   44                     inc     esp
00604C3E   42                     inc     edx
00604C3F   47                     inc     edi
00604C40   7269                   jb      00604CAB
00604C42   6431C4                 xor     esp, eax
00604C45   0400                   add     al, +$00
00604C47   000D00074442           add     [$42440700], cl
00604C4D   45                     inc     ebp
00604C4E   64697434C80400000D     imul    esi, fs:[esp+esi-$38], $0D000004
00604C57   0007                   add     [edi], al
00604C59   44                     inc     esp
00604C5A   42                     inc     edx
00604C5B   45                     inc     ebp
00604C5C   64697435CC04000004     imul    esi, fs:[ebp+esi-$34], $04000004
00604C65   0007                   add     [edi], al
00604C67   4C                     dec     esp
00604C68   61                     popa
00604C69   62656C                 bound   esp, qword ptr [ebp+$6C]
00604C6C   3135D0040000           xor     [$000004D0], esi
00604C72   0D00074442             or      eax, $42440700
00604C77   45                     inc     ebp
00604C78   64697436D404000009     imul    esi, fs:[esi+esi-$2C], $09000004
00604C81   0012                   add     [edx], dl
00604C83   7172                   jno     00604CF7
00604C85   7948                   jns     00604CCF
00604C87   6F                     outsd
00604C88   7261                   jb      00604CEB
00604C8A   7269                   jb      00604CF5
00604C8C   6F                     outsd
00604C8D   64675F                 pop     edi
00604C90   677275                 jb      00604D08
00604C93   706F                   jo      00604D04
00604C95   D80400                 fadd    dword ptr [eax+eax]
00604C98   0009                   add     [ecx], cl
00604C9A   0011                   add     [ecx], dl
00604C9C   7172                   jno     00604D10
00604C9E   7948                   jns     00604CE8
00604CA0   6F                     outsd
00604CA1   7261                   jb      00604D04
00604CA3   7269                   jb      00604D0E
00604CA5   6F                     outsd
00604CA6   64675F                 pop     edi
00604CA9   726F                   jb      00604D1A
00604CAB   7461                   jz      00604D0E
00604CAD   DC0400                 fadd    qword ptr [eax+eax]
00604CB0   0008                   add     [eax], cl
00604CB2   0017                   add     [edi], dl
00604CB4   7172                   jno     00604D28
00604CB6   7948                   jns     00604D00
00604CB8   6F                     outsd
00604CB9   7261                   jb      00604D1C
00604CBB   7269                   jb      00604D26
00604CBD   6F                     outsd
00604CBE   64675F                 pop     edi
00604CC1   7265                   jb      00604D28
00604CC3   66657265               jb      00604D2C
00604CC7   6E                     outsb
00604CC8   636961                 arpl    [ecx+$61], bp
00604CCB   E004                   loopn   +$04
00604CCD   0000                   add     [eax], al

00604CCF   0800                   or      [eax], al
00604CD1   197172                 sbb     [ecx+$72], esi
00604CD4   7948                   jns     00604D1E
00604CD6   6F                     outsd
00604CD7   7261                   jb      00604D3A
00604CD9   7269                   jb      00604D44
00604CDB   6F                     outsd
00604CDC   64675F                 pop     edi
00604CDF   6461                   popa
00604CE1   7461                   jz      00604D44
00604CE3   5F                     pop     edi
00604CE4   6C                     insb
00604CE5   656974757261E40400     imul    esi, gs:[ebp+esi*2+$72], $0004E461
00604CEE   0008                   add     [eax], cl
00604CF0   001B                   add     [ebx], bl
00604CF2   7172                   jno     00604D66
00604CF4   7948                   jns     00604D3E
00604CF6   6F                     outsd
00604CF7   7261                   jb      00604D5A
00604CF9   7269                   jb      00604D64
00604CFB   6F                     outsd
00604CFC   44                     inc     esp
00604CFD   61                     popa
00604CFE   7461                   jz      00604D61
00604D00   5F                     pop     edi
00604D01   50                     push    eax
00604D02   726F                   jb      00604D73
00604D04   785F                   js      00604D65
00604D06   4C                     dec     esp
00604D07   656974757261E80400     imul    esi, gs:[ebp+esi*2+$72], $0004E861
00604D10   0008                   add     [eax], cl
00604D12   000F                   add     [edi], cl
00604D14   7172                   jno     00604D88
00604D16   7948                   jns     00604D60
00604D18   6F                     outsd
00604D19   7261                   jb      00604D7C
00604D1B   7269                   jb      00604D86
00604D1D   6F                     outsd
00604D1E   54                     push    esp
00604D1F   656D                   insd
00604D21   706F                   jo      00604D92
00604D23   EC                     in      al, dx
00604D24   0400                   add     al, +$00
00604D26   0009                   add     [ecx], cl
00604D28   0016                   add     [esi], dl
00604D2A   7172                   jno     00604D9E
00604D2C   7948                   jns     00604D76
00604D2E   6F                     outsd
00604D2F   7261                   jb      00604D92
00604D31   7269                   jb      00604D9C
00604D33   6F                     outsd
00604D34   64675F                 pop     edi
00604D37   6D                     insd
00604D38   61                     popa
00604D39   7472                   jz      00604DAD
00604D3B   6963756C61F004         imul    esp, [ebx+$75], $04F0616C
00604D42   0000                   add     [eax], al

00604D44   0900                   or      [eax], eax
00604D46   197172                 sbb     [ecx+$72], esi
00604D49   7948                   jns     00604D93
00604D4B   6F                     outsd
00604D4C   7261                   jb      00604DAF
00604D4E   7269                   jb      00604DB9
00604D50   6F                     outsd
00604D51   64675F                 pop     edi
00604D54   6C                     insb
00604D55   6569747572615F7265     imul    esi, gs:[ebp+esi*2+$72], $65725F61
00604D5E   61                     popa
00604D5F   6C                     insb
00604D60   F4                     hlt
00604D61   0400                   add     al, +$00
00604D63   0009                   add     [ecx], cl
00604D65   0017                   add     [edi], dl
00604D67   7172                   jno     00604DDB
00604D69   7948                   jns     00604DB3
00604D6B   6F                     outsd
00604D6C   7261                   jb      00604DCF
00604D6E   7269                   jb      00604DD9
00604D70   6F                     outsd
00604D71   64675F                 pop     edi
00604D74   6F                     outsd
00604D75   636F72                 arpl    [edi+$72], bp
00604D78   7265                   jb      00604DDF
00604D7A   6E                     outsb
00604D7B   636961                 arpl    [ecx+$61], bp
00604D7E   F8                     clc
00604D7F   0400                   add     al, +$00
00604D81   000A                   add     [edx], cl
00604D83   001B                   add     [ebx], bl
00604D85   7172                   jno     00604DF9
00604D87   7948                   jns     00604DD1
00604D89   6F                     outsd
00604D8A   7261                   jb      00604DED
00604D8C   7269                   jb      00604DF7
00604D8E   6F                     outsd
00604D8F   64675F                 pop     edi
00604D92   666C                   insb
00604D94   61                     popa
00604D95   675F                   pop     edi
00604D97   63616C                 arpl    [ecx+$6C], sp
00604D9A   63756C                 arpl    [ebp+$6C], si
00604D9D   61                     popa
00604D9E   6461                   popa
00604DA0   FC                     cld
00604DA1   0400                   add     al, +$00
00604DA3   000A                   add     [edx], cl
00604DA5   0019                   add     [ecx], bl
00604DA7   7172                   jno     00604E1B
00604DA9   7948                   jns     00604DF3
00604DAB   6F                     outsd
00604DAC   7261                   jb      00604E0F
00604DAE   7269                   jb      00604E19
00604DB0   6F                     outsd
00604DB1   64675F                 pop     edi
00604DB4   666C                   insb
00604DB6   61                     popa
00604DB7   675F                   pop     edi
00604DB9   656D                   insd
00604DBB   6974696461000500       imul    esi, [ecx+ebp*2+$64], $00050061
00604DC3   000A                   add     [edx], cl
00604DC5   0017                   add     [edi], dl
00604DC7   7172                   jno     00604E3B
00604DC9   7948                   jns     00604E13
00604DCB   6F                     outsd
00604DCC   7261                   jb      00604E2F
00604DCE   7269                   jb      00604E39
00604DD0   6F                     outsd
00604DD1   64675F                 pop     edi
00604DD4   666C                   insb
00604DD6   61                     popa
00604DD7   675F                   pop     edi
00604DD9   61                     popa
00604DDA   7669                   jbe     00604E45
00604DDC   736F                   jnb     00604E4D
00604DDE   0405                   add     al, +$05
00604DE0   0000                   add     [eax], al

00604DE2   0A00                   or      al, byte ptr [eax]
00604DE4   187172                 sbb     [ecx+$72], dh
00604DE7   7948                   jns     00604E31
00604DE9   6F                     outsd
00604DEA   7261                   jb      00604E4D
00604DEC   7269                   jb      00604E57
00604DEE   6F                     outsd
00604DEF   64675F                 pop     edi
00604DF2   666C                   insb
00604DF4   61                     popa
00604DF5   675F                   pop     edi
00604DF7   667261                 jb      00604E5B
00604DFA   7564                   jnz     00604E60
00604DFC   65080500000A00         or      gs:[$000A0000], al
00604E03   1A7172                 sbb     dh, byte ptr [ecx+$72]
00604E06   7948                   jns     00604E50
00604E08   6F                     outsd
00604E09   7261                   jb      00604E6C
00604E0B   7269                   jb      00604E76
00604E0D   6F                     outsd
00604E0E   64675F                 pop     edi
00604E11   666C                   insb
00604E13   61                     popa
00604E14   675F                   pop     edi
00604E16   6661                   popa
00604E18   7475                   jz      00604E8F
00604E1A   7261                   jb      00604E7D
00604E1C   646F                   outsd
00604E1E   0C05                   or      al, $05
00604E20   0000                   add     [eax], al

00604E22   0A00                   or      al, byte ptr [eax]
00604E24   16                     push    ss
00604E25   7172                   jno     00604E99
00604E27   7948                   jns     00604E71
00604E29   6F                     outsd
00604E2A   7261                   jb      00604E8D
00604E2C   7269                   jb      00604E97
00604E2E   6F                     outsd
00604E2F   64675F                 pop     edi
00604E32   666C                   insb
00604E34   61                     popa
00604E35   675F                   pop     edi
00604E37   6C                     insb
00604E38   69646F1005000009       imul    esp, [edi+ebp*2+$10], $09000005
00604E40   001B                   add     [ebx], bl
00604E42   7172                   jno     00604EB6
00604E44   7948                   jns     00604E8E
00604E46   6F                     outsd
00604E47   7261                   jb      00604EAA
00604E49   7269                   jb      00604EB4
00604E4B   6F                     outsd
00604E4C   64675F                 pop     edi
00604E4F   6C                     insb
00604E50   6569747572615F6167     imul    esi, gs:[ebp+esi*2+$72], $67615F61
00604E59   656E                   outsb
00604E5B   7465                   jz      00604EC2
00604E5D   1405                   adc     al, $05
00604E5F   0000                   add     [eax], al

00604E61   0900                   or      [eax], eax
00604E63   1A7172                 sbb     dh, byte ptr [ecx+$72]
00604E66   7948                   jns     00604EB0
00604E68   6F                     outsd
00604E69   7261                   jb      00604ECC
00604E6B   7269                   jb      00604ED6
00604E6D   6F                     outsd
00604E6E   64675F                 pop     edi
00604E71   666F                   outsw
00604E73   726D                   jb      00604EE2
00604E75   61                     popa
00604E76   5F                     pop     edi
00604E77   656E                   outsb
00604E79   7472                   jz      00604EED
00604E7B   656761                 popa
00604E7E   180500000900           sbb     [$00090000], al
00604E84   117172                 adc     [ecx+$72], esi
00604E87   7948                   jns     00604ED1
00604E89   6F                     outsd
00604E8A   7261                   jb      00604EED
00604E8C   7269                   jb      00604EF7
00604E8E   6F                     outsd
00604E8F   64675F                 pop     edi
00604E92   7669                   jbe     00604EFD
00604E94   61                     popa
00604E95   731C                   jnb     00604EB3
00604E97   0500000900             add     eax, +$00090000
00604E9C   137172                 adc     esi, [ecx+$72]
00604E9F   7948                   jns     00604EE9
00604EA1   6F                     outsd
00604EA2   7261                   jb      00604F05
00604EA4   7269                   jb      00604F0F
00604EA6   6F                     outsd
00604EA7   64675F                 pop     edi
00604EAA   61                     popa
00604EAB   67656E                 outsb
00604EAE   7465                   jz      00604F15
00604EB0   200500000A00           and     [$000A0000], al
00604EB6   117172                 adc     [ecx+$72], esi
00604EB9   7948                   jns     00604F03
00604EBB   6F                     outsd
00604EBC   7261                   jb      00604F1F
00604EBE   7269                   jb      00604F29
00604EC0   6F                     outsd
00604EC1   61                     popa
00604EC2   675F                   pop     edi
00604EC4   6E                     outsb
00604EC5   6F                     outsd
00604EC6   6D                     insd
00604EC7   652405                 and     al, $05
00604ECA   0000                   add     [eax], al

00604ECC   06                     push    es
00604ECD   000C73                 add     [ebx+esi*2], cl
00604ED0   62746E49               bound   esi, qword ptr [esi+ebp*2+$49]
00604ED4   6D                     insd
00604ED5   7072                   jo      00604F49
00604ED7   696D6972280500         imul    ebp, [ebp+$69], $00052872
00604EDE   000E                   add     [esi], cl
00604EE0   000B                   add     [ebx], cl
00604EE2   52                     push    edx
00604EE3   7652                   jbe     00604F37
00604EE5   656E                   outsb
00604EE7   64657250               jb      00604F3B
00604EEB   44                     inc     esp
00604EEC   46                     inc     esi
00604EED   2C05                   sub     al, $05
00604EEF   0000                   add     [eax], al

00604EF1   0F000C52               str     word ptr [edx+edx*2]
00604EF5   7650                   jbe     00604F47
00604EF7   726A                   jb      00604F63
00604EF9   48                     dec     eax
00604EFA   6F                     outsd
00604EFB   7261                   jb      00604F5E
00604EFD   7269                   jb      00604F68
00604EFF   6F                     outsd
00604F00   300500001000           xor     [$00100000], al
00604F06   0C52                   or      al, $52
00604F08   7644                   jbe     00604F4E
00604F0A   53                     push    ebx
00604F0B   43                     inc     ebx
00604F0C   48                     dec     eax
00604F0D   6F                     outsd
00604F0E   7261                   jb      00604F71
00604F10   7269                   jb      00604F7B
00604F12   6F                     outsd
00604F13   3405                   xor     al, $05
00604F15   0000                   add     [eax], al

00604F17   0900                   or      [eax], eax
00604F19   1A7172                 sbb     dh, byte ptr [ecx+$72]
00604F1C   794D                   jns     00604F6B
00604F1E   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
00604F27   6C                     insb
00604F28   656974757261735F72     imul    esi, gs:[ebp+esi*2+$72], $725F7361
00604F31   6561                   popa
00604F33   6C                     insb
00604F34   380500000900           cmp     [$00090000], al
00604F3A   1E                     push    ds
00604F3B   7172                   jno     00604FAF
00604F3D   794D                   jns     00604F8C
00604F3F   65646963616F6D645F     imul    esp, fs:[ebx+$61], $5F646D6F
00604F48   6C                     insb
00604F49   656974757261735F6E     imul    esi, gs:[ebp+esi*2+$72], $6E5F7361
00604F52   61                     popa
00604F53   6F                     outsd
00604F54   5F                     pop     edi
00604F55   7265                   jb      00604FBC
00604F57   61                     popa
00604F58   6C                     insb
00604F59   3C05                   cmp     al, $05
00604F5B   0000                   add     [eax], al

00604F5D   0900                   or      [eax], eax
00604F5F   1C71                   sbb     al, $71
00604F61   7279                   jb      00604FDC
00604F63   4D                     dec     ebp
00604F64   65646963616F706572     imul    esp, fs:[ebx+$61], $7265706F
00604F6D   635F6C                 arpl    [edi+$6C], bx
00604F70   656974757261735F72     imul    esi, gs:[ebp+esi*2+$72], $725F7361
00604F79   6561                   popa
00604F7B   6C                     insb
00604F7C   40                     inc     eax
00604F7D   0500000900             add     eax, +$00090000
00604F82   207172                 and     [ecx+$72], dh
00604F85   794D                   jns     00604FD4
00604F87   65646963616F706572     imul    esp, fs:[ebx+$61], $7265706F
00604F90   635F6C                 arpl    [edi+$6C], bx
00604F93   656974757261735F6E     imul    esi, gs:[ebp+esi*2+$72], $6E5F7361
00604F9C   61                     popa
00604F9D   6F                     outsd
00604F9E   5F                     pop     edi
00604F9F   7265                   jb      00605006
00604FA1   61                     popa
00604FA2   6C                     insb
00604FA3   44                     inc     esp
00604FA4   0500000B00             add     eax, +$000B0000
00604FA9   0A444247               or      al, byte ptr [edx+eax*2+$47]
00604FAD   7269                   jb      00605018
00604FAF   6452                   push    edx
00604FB1   6F                     outsd
00604FB2   7461                   jz      00605015
00604FB4   48                     dec     eax
00604FB5   0500000B00             add     eax, +$000B0000
00604FBA   0C44                   or      al, $44
00604FBC   42                     inc     edx
00604FBD   47                     inc     edi
00604FBE   7269                   jb      00605029
00604FC0   6441                   inc     ecx
00604FC2   67656E                 outsb
00604FC5   7465                   jz      0060502C
00604FC7   4C                     dec     esp
00604FC8   0500000F00             add     eax, +$000F0000
00604FCD   0F52                   DB  $0F, $52  //
00604FCF   7650                   jbe     00605021
00604FD1   726A                   jb      0060503D
00604FD3   50                     push    eax
00604FD4   657266                 jb      0060503D
00604FD7   6F                     outsd
00604FD8   726D                   jb      00605047
00604FDA   52                     push    edx
00604FDB   656650                 push    ax
00604FDE   0500001000             add     eax, +$00100000
00604FE3   105276                 adc     [edx+$76], dl
00604FE6   44                     inc     esp
00604FE7   53                     push    ebx
00604FE8   43                     inc     ebx
00604FE9   50                     push    eax
00604FEA   657266                 jb      00605053
00604FED   6F                     outsd
00604FEE   726D                   jb      0060505D
00604FF0   61                     popa
00604FF1   6E                     outsb
00604FF2   636554                 arpl    [ebp+$54], sp
00604FF5   0500000A00             add     eax, +$000A0000
00604FFA   117172                 adc     [ecx+$72], esi
00604FFD   794D                   jns     0060504C
00604FFF   65646963616F746974     imul    esp, fs:[ebx+$61], $7469746F
00605008   756C                   jnz     00605076
0060500A   6F                     outsd
0060500B   315805                 xor     [eax+$05], ebx
0060500E   0000                   add     [eax], al

00605010   0A00                   or      al, byte ptr [eax]
00605012   117172                 adc     [ecx+$72], esi
00605015   794D                   jns     00605064
00605017   65646963616F746974     imul    esp, fs:[ebx+$61], $7469746F
00605020   756C                   jnz     0060508E
00605022   6F                     outsd
00605023   325C0500               xor     bl, byte ptr [ebp+eax+$00]
00605027   000F                   add     [edi], cl
00605029   0010                   add     [eax], dl
0060502B   52                     push    edx
0060502C   7650                   jbe     0060507E
0060502E   726A                   jb      0060509A
00605030   50                     push    eax
00605031   657266                 jb      0060509A
00605034   6F                     outsd
00605035   726D                   jb      006050A4
00605037   52                     push    edx
00605038   6F                     outsd
00605039   7461                   jz      0060509C
0060503B   60                     pusha
0060503C   0500000F00             add     eax, +$000F0000
00605041   125276                 adc     dl, byte ptr [edx+$76]
00605044   50                     push    eax
00605045   726A                   jb      006050B1
00605047   50                     push    eax
00605048   657266                 jb      006050B1
0060504B   6F                     outsd
0060504C   726D                   jb      006050BB
0060504E   41                     inc     ecx
0060504F   67656E                 outsb
00605052   7465                   jz      006050B9
00605054   640500000100           add     eax, +$00010000
0060505A   1574627352             adc     eax, $52736274
0060505F   6566657265             jb      006050C9
00605064   6E                     outsb
00605065   636961                 arpl    [ecx+$61], bp
00605068   52                     push    edx
00605069   65636570               arpl    gs:[ebp+$70], sp
0060506D   63616F                 arpl    [ecx+$6F], sp
00605070   6805000002             push    $02000005
00605075   0009                   add     [ecx], cl
00605077   47                     inc     edi
00605078   726F                   jb      006050E9
0060507A   7570                   jnz     006050EC
0060507C   42                     inc     edx
0060507D   6F                     outsd
0060507E   7836                   js      006050B6
00605080   6C                     insb
00605081   0500000400             add     eax, +$00040000
00605086   07                     pop     es
00605087   4C                     dec     esp
00605088   61                     popa
00605089   62656C                 bound   esp, qword ptr [ebp+$6C]
0060508C   3136                   xor     [esi], esi
0060508E   7005                   jo      00605095
00605090   0000                   add     [eax], al

00605092   0400                   add     al, +$00
00605094   07                     pop     es
00605095   4C                     dec     esp
00605096   61                     popa
00605097   62656C                 bound   esp, qword ptr [ebp+$6C]
0060509A   3137                   xor     [edi], esi
0060509C   7405                   jz      006050A3
0060509E   0000                   add     [eax], al

006050A0   0400                   add     al, +$00
006050A2   07                     pop     es
006050A3   4C                     dec     esp
006050A4   61                     popa
006050A5   62656C                 bound   esp, qword ptr [ebp+$6C]
006050A8   3138                   xor     [eax], edi
006050AA   7805                   js      006050B1
006050AC   0000                   add     [eax], al

006050AE   0D00074442             or      eax, $42440700
006050B3   45                     inc     ebp
006050B4   646974377C0500000D     imul    esi, fs:[edi+esi+$7C], $0D000005
006050BD   0007                   add     [edi], al
006050BF   44                     inc     esp
006050C0   42                     inc     edx
006050C1   45                     inc     ebp
006050C2   646974388005000005     imul    esi, fs:[eax+edi-$80], $05000005
006050CB   0011                   add     [ecx], dl
006050CD   636D62                 arpl    [ebp+$62], bp
006050D0   56                     push    esi
006050D1   657252                 jb      00605126
006050D4   656652                 push    dx
006050D7   65636570               arpl    gs:[ebp+$70], sp
006050DB   63616F                 arpl    [ecx+$6F], sp
006050DE   840500000B00           test    [$000B0000], al
006050E4   11444247               adc     [edx+eax*2+$47], eax
006050E8   7269                   jb      00605153
006050EA   6452                   push    edx
006050EC   656652                 push    dx
006050EF   65636570               arpl    gs:[ebp+$70], sp
006050F3   63616F                 arpl    [ecx+$6F], sp
006050F6   880500000700           mov     [$00070000], al
006050FC   0D51724D65             or      eax, $654D7251
00605101   6452                   push    edx
00605103   65636570               arpl    gs:[ebp+$70], sp
00605107   63616F                 arpl    [ecx+$6F], sp
0060510A   8C0500000C00           mov     word ptr [$000C0000], es
00605110   0D44534D65             or      eax, $654D5344
00605115   6452                   push    edx
00605117   65636570               arpl    gs:[ebp+$70], sp
0060511B   63616F                 arpl    [ecx+$6F], sp
0060511E   90                     nop
0060511F   0500000300             add     eax, +$00030000
00605124   1572627452             adc     eax, $52746272
00605129   6566657265             jb      00605193
0060512E   6E                     outsb
0060512F   636961                 arpl    [ecx+$61], bp
00605132   52                     push    edx
00605133   65636570               arpl    gs:[ebp+$70], sp
00605137   63616F                 arpl    [ecx+$6F], sp
0060513A   94                     xchg    eax, esp
0060513B   0500000900             add     eax, +$00090000
00605140   1551724D65             adc     eax, $654D7251
00605145   6452                   push    edx
00605147   65636570               arpl    gs:[ebp+$70], sp
0060514B   63616F                 arpl    [ecx+$6F], sp
0060514E   6D                     insd
0060514F   645F                   pop     edi
00605151   677275                 jb      006051C9
00605154   706F                   jo      006051C5
00605156   98                     cwde 
00605157   0500000900             add     eax, +$00090000
0060515C   1451                   adc     al, $51
0060515E   724D                   jb      006051AD
00605160   656452                 push    edx
00605163   65636570               arpl    gs:[ebp+$70], sp
00605167   63616F                 arpl    [ecx+$6F], sp
0060516A   6D                     insd
0060516B   645F                   pop     edi
0060516D   726F                   jb      006051DE
0060516F   7461                   jz      006051D2
00605171   9C                     pushf   
00605172   0500000800             add     eax, +$00080000
00605177   1A5172                 sbb     dl, byte ptr [ecx+$72]
0060517A   4D                     dec     ebp
0060517B   656452                 push    edx
0060517E   65636570               arpl    gs:[ebp+$70], sp
00605182   63616F                 arpl    [ecx+$6F], sp
00605185   6D                     insd
00605186   645F                   pop     edi
00605188   7265                   jb      006051EF
0060518A   66657265               jb      006051F3
0060518E   6E                     outsb
0060518F   636961                 arpl    [ecx+$61], bp
00605192   A00500000A             mov     al, byte ptr [$0A000005]
00605197   0013                   add     [ebx], dl
00605199   51                     push    ecx
0060519A   724D                   jb      006051E9
0060519C   656452                 push    edx
0060519F   65636570               arpl    gs:[ebp+$70], sp
006051A3   63616F                 arpl    [ecx+$6F], sp
006051A6   61                     popa
006051A7   67656E                 outsb
006051AA   7465                   jz      00605211
006051AC   A4                     movsb
006051AD   0500000800             add     eax, +$00080000
006051B2   1C51                   sbb     al, $51
006051B4   724D                   jb      00605203
006051B6   656452                 push    edx
006051B9   65636570               arpl    gs:[ebp+$70], sp
006051BD   63616F                 arpl    [ecx+$6F], sp
006051C0   6D                     insd
006051C1   645F                   pop     edi
006051C3   6461                   popa
006051C5   7461                   jz      00605228
006051C7   5F                     pop     edi
006051C8   6C                     insb
006051C9   656974757261A80500     imul    esi, gs:[ebp+esi*2+$72], $0005A861
006051D2   0008                   add     [eax], cl
006051D4   001B                   add     [ebx], bl
006051D6   51                     push    ecx
006051D7   724D                   jb      00605226
006051D9   656452                 push    edx
006051DC   65636570               arpl    gs:[ebp+$70], sp
006051E0   63616F                 arpl    [ecx+$6F], sp
006051E3   6D                     insd
006051E4   645F                   pop     edi
006051E6   686F72615F             push    $5F61726F
006051EB   696E6963696FAC         imul    ebp, [esi+$69], $AC6F6963
006051F2   0500000800             add     eax, +$00080000
006051F7   185172                 sbb     [ecx+$72], dl
006051FA   4D                     dec     ebp
006051FB   656452                 push    edx
006051FE   65636570               arpl    gs:[ebp+$70], sp
00605202   63616F                 arpl    [ecx+$6F], sp
00605205   6D                     insd
00605206   645F                   pop     edi
00605208   686F72615F             push    $5F61726F
0060520D   66696DB00500           imul    bp, word ptr [ebp-$50], $0005
00605213   0009                   add     [ecx], cl
00605215   0018                   add     [eax], bl
00605217   51                     push    ecx
00605218   724D                   jb      00605267
0060521A   656452                 push    edx
0060521D   65636570               arpl    gs:[ebp+$70], sp
00605221   63616F                 arpl    [ecx+$6F], sp
00605224   6D                     insd
00605225   645F                   pop     edi
00605227   6C                     insb
00605228   696761636F6573         imul    esp, [edi+$61], $73656F63
0060522F   B405                   mov     ah, $05
00605231   0000                   add     [eax], al

00605233   0900                   or      [eax], eax
00605235   1D51724D65             sbb     eax, $654D7251
0060523A   6452                   push    edx
0060523C   65636570               arpl    gs:[ebp+$70], sp
00605240   63616F                 arpl    [ecx+$6F], sp
00605243   6D                     insd
00605244   645F                   pop     edi
00605246   6C                     insb
00605247   656974757261735F72     imul    esi, gs:[ebp+esi*2+$72], $725F7361
00605250   6561                   popa
00605252   6C                     insb
00605253   B805000009             mov     eax, $09000005
00605258   001D51724D65           add     [$654D7251], bl
0060525E   6452                   push    edx
00605260   65636570               arpl    gs:[ebp+$70], sp
00605264   63616F                 arpl    [ecx+$6F], sp
00605267   6D                     insd
00605268   645F                   pop     edi
0060526A   6C                     insb
0060526B   6569747572615F6361     imul    esi, gs:[ebp+esi*2+$72], $61635F61
00605274   6D                     insd
00605275   706F                   jo      006052E6
00605277   BC05000009             mov     esp, $09000005
0060527C   0017                   add     [edi], dl
0060527E   51                     push    ecx
0060527F   724D                   jb      006052CE
00605281   656452                 push    edx
00605284   65636570               arpl    gs:[ebp+$70], sp
00605288   63616F                 arpl    [ecx+$6F], sp
0060528B   6D                     insd
0060528C   645F                   pop     edi
0060528E   61                     popa
0060528F   6E                     outsb
00605290   61                     popa
00605291   6C                     insb
00605292   697365C0050000         imul    esi, [ebx+$65], $000005C0
00605299   0900                   or      [eax], eax
0060529B   1F                     pop     ds
0060529C   51                     push    ecx
0060529D   724D                   jb      006052EC
0060529F   656452                 push    edx
006052A2   65636570               arpl    gs:[ebp+$70], sp
006052A6   63616F                 arpl    [ecx+$6F], sp
006052A9   6D                     insd
006052AA   645F                   pop     edi
006052AC   6661                   popa
006052AE   7475                   jz      00605325
006052B0   7261                   jb      00605313
006052B2   646F                   outsd
006052B4   5F                     pop     edi
006052B5   6E                     outsb
006052B6   6F                     outsd
006052B7   726D                   jb      00605326
006052B9   61                     popa
006052BA   6C                     insb
006052BB   C40500000900           les     eax, [$00090000]
006052C1   1E                     push    ds
006052C2   51                     push    ecx
006052C3   724D                   jb      00605312
006052C5   656452                 push    edx
006052C8   65636570               arpl    gs:[ebp+$70], sp
006052CC   63616F                 arpl    [ecx+$6F], sp
006052CF   6D                     insd
006052D0   645F                   pop     edi
006052D2   6661                   popa
006052D4   7475                   jz      0060534B
006052D6   7261                   jb      00605339
006052D8   646F                   outsd
006052DA   5F                     pop     edi
006052DB   6D                     insd
006052DC   65646961C805000009     imul    esp, fs:[ecx-$38], $09000005
006052E5   001F                   add     [edi], bl
006052E7   51                     push    ecx
006052E8   724D                   jb      00605337
006052EA   656452                 push    edx
006052ED   65636570               arpl    gs:[ebp+$70], sp
006052F1   63616F                 arpl    [ecx+$6F], sp
006052F4   6D                     insd
006052F5   645F                   pop     edi
006052F7   6661                   popa
006052F9   7475                   jz      00605370
006052FB   7261                   jb      0060535E
006052FD   646F                   outsd
006052FF   5F                     pop     edi
00605300   6D                     insd
00605301   696E696D61CC05         imul    ebp, [esi+$69], $05CC616D
00605308   0000                   add     [eax], al

0060530A   0900                   or      [eax], eax
0060530C   185172                 sbb     [ecx+$72], dl
0060530F   4D                     dec     ebp
00605310   656452                 push    edx
00605313   65636570               arpl    gs:[ebp+$70], sp
00605317   63616F                 arpl    [ecx+$6F], sp
0060531A   6D                     insd
0060531B   645F                   pop     edi
0060531D   656D                   insd
0060531F   697469646173D005       imul    esi, [ecx+ebp*2+$64], $05D07361
00605327   0000                   add     [eax], al

00605329   0900                   or      [eax], eax
0060532B   205172                 and     [ecx+$72], dl
0060532E   4D                     dec     ebp
0060532F   656452                 push    edx
00605332   65636570               arpl    gs:[ebp+$70], sp
00605336   63616F                 arpl    [ecx+$6F], sp
00605339   6D                     insd
0060533A   645F                   pop     edi
0060533C   656D                   insd
0060533E   6974696461735F32       imul    esi, [ecx+ebp*2+$64], $325F7361
00605346   5F                     pop     edi
00605347   7665                   jbe     006053AE
00605349   7A65                   jp      006053B0
0060534B   73D4                   jnb     00605321
0060534D   0500000900             add     eax, +$00090000
00605352   1C51                   sbb     al, $51
00605354   724D                   jb      006053A3
00605356   656452                 push    edx
00605359   65636570               arpl    gs:[ebp+$70], sp
0060535D   63616F                 arpl    [ecx+$6F], sp
00605360   6D                     insd
00605361   645F                   pop     edi
00605363   6E                     outsb
00605364   61                     popa
00605365   6F                     outsd
00605366   5F                     pop     edi
00605367   656D                   insd
00605369   697469646173D805       imul    esi, [ecx+ebp*2+$64], $05D87361
00605371   0000                   add     [eax], al

00605373   0900                   or      [eax], eax
00605375   1E                     push    ds
00605376   51                     push    ecx
00605377   724D                   jb      006053C6
00605379   656452                 push    edx
0060537C   65636570               arpl    gs:[ebp+$70], sp
00605380   63616F                 arpl    [ecx+$6F], sp
00605383   6D                     insd
00605384   645F                   pop     edi
00605386   656D                   insd
00605388   6974696461735F61       imul    esi, [ecx+ebp*2+$64], $615F7361
00605390   7669                   jbe     006053FB
00605392   736F                   jnb     00605403
00605394   DC0500000900           fadd    qword ptr [$00090000]
0060539A   1B5172                 sbb     edx, [ecx+$72]
0060539D   4D                     dec     ebp
0060539E   656452                 push    edx
006053A1   65636570               arpl    gs:[ebp+$70], sp
006053A5   63616F                 arpl    [ecx+$6F], sp
006053A8   6D                     insd
006053A9   645F                   pop     edi
006053AB   656E                   outsb
006053AD   7472                   jz      00605421
006053AF   656761                 popa
006053B2   5F                     pop     edi
006053B3   6D                     insd
006053B4   61                     popa
006053B5   6F                     outsd
006053B6   E005                   loopn   +$05
006053B8   0000                   add     [eax], al

006053BA   0900                   or      [eax], eax
006053BC   1F                     pop     ds
006053BD   51                     push    ecx
006053BE   724D                   jb      0060540D
006053C0   656452                 push    edx
006053C3   65636570               arpl    gs:[ebp+$70], sp
006053C7   63616F                 arpl    [ecx+$6F], sp
006053CA   6D                     insd
006053CB   645F                   pop     edi
006053CD   656E                   outsb
006053CF   7472                   jz      00605443
006053D1   656761                 popa
006053D4   5F                     pop     edi
006053D5   7669                   jbe     00605440
006053D7   7369                   jnb     00605442
006053D9   6E                     outsb
006053DA   686FE40500             push    $0005E46F
006053DF   0009                   add     [ecx], cl
006053E1   001D51724D65           add     [$654D7251], bl
006053E7   6452                   push    edx
006053E9   65636570               arpl    gs:[ebp+$70], sp
006053ED   63616F                 arpl    [ecx+$6F], sp
006053F0   6D                     insd
006053F1   645F                   pop     edi
006053F3   656E                   outsb
006053F5   7472                   jz      00605469
006053F7   656761                 popa
006053FA   5F                     pop     edi
006053FB   706F                   jo      0060546C
006053FD   7274                   jb      00605473
006053FF   61                     popa
00605400   E805000009             call    0960540A
00605405   001F                   add     [edi], bl
00605407   51                     push    ecx
00605408   724D                   jb      00605457
0060540A   656452                 push    edx
0060540D   65636570               arpl    gs:[ebp+$70], sp
00605411   63616F                 arpl    [ecx+$6F], sp
00605414   6D                     insd
00605415   645F                   pop     edi
00605417   656E                   outsb
00605419   7472                   jz      0060548D
0060541B   61                     popa
0060541C   6761                   popa
0060541E   5F                     pop     edi
0060541F   636F72                 arpl    [edi+$72], bp
00605422   7265                   jb      00605489
00605424   696FEC05000009         imul    ebp, [edi-$14], $09000005
0060542B   0020                   add     [eax], ah
0060542D   51                     push    ecx
0060542E   724D                   jb      0060547D
00605430   656452                 push    edx
00605433   65636570               arpl    gs:[ebp+$70], sp
00605437   63616F                 arpl    [ecx+$6F], sp
0060543A   6D                     insd
0060543B   645F                   pop     edi
0060543D   656E                   outsb
0060543F   7472                   jz      006054B3
00605441   656761                 popa
00605444   5F                     pop     edi
00605445   7265                   jb      006054AC
00605447   637573                 arpl    [ebp+$73], si
0060544A   61                     popa
0060544B   646F                   outsd
0060544D   F0                     lock
0060544E   0500000900             add     eax, +$00090000
00605453   1D51724D65             sbb     eax, $654D7251
00605458   6452                   push    edx
0060545A   65636570               arpl    gs:[ebp+$70], sp
0060545E   63616F                 arpl    [ecx+$6F], sp
00605461   6D                     insd
00605462   645F                   pop     edi
00605464   656E                   outsb
00605466   7472                   jz      006054DA
00605468   656761                 popa
0060546B   5F                     pop     edi
0060546C   6F                     outsd
0060546D   7574                   jnz     006054E3
0060546F   726F                   jb      006054E0
00605471   F4                     hlt
00605472   0500000900             add     eax, +$00090000
00605477   185172                 sbb     [ecx+$72], dl
0060547A   4D                     dec     ebp
0060547B   656452                 push    edx
0060547E   65636570               arpl    gs:[ebp+$70], sp
00605482   63616F                 arpl    [ecx+$6F], sp
00605485   6D                     insd
00605486   645F                   pop     edi
00605488   6E                     outsb
00605489   61                     popa
0060548A   6F                     outsd
0060548B   5F                     pop     edi
0060548C   657865                 js      006054F4
0060548F   63F8                   arpl    ax, di
00605491   0500000900             add     eax, +$00090000
00605496   16                     push    ss
00605497   51                     push    ecx
00605498   724D                   jb      006054E7
0060549A   656452                 push    edx
0060549D   65636570               arpl    gs:[ebp+$70], sp
006054A1   63616F                 arpl    [ecx+$6F], sp
006054A4   6D                     insd
006054A5   645F                   pop     edi
006054A7   667261                 jb      0060550B
006054AA   7564                   jnz     00605510
006054AC   65FC                   cld
006054AE   0500000900             add     eax, +$00090000
006054B3   1A5172                 sbb     dl, byte ptr [ecx+$72]
006054B6   4D                     dec     ebp
006054B7   656452                 push    edx
006054BA   65636570               arpl    gs:[ebp+$70], sp
006054BE   63616F                 arpl    [ecx+$6F], sp
006054C1   6D                     insd
006054C2   645F                   pop     edi
006054C4   7061                   jo      00605527
006054C6   7261                   jb      00605529
006054C8   5F                     pop     edi
006054C9   636F72                 arpl    [edi+$72], bp
006054CC   7465                   jz      00605533
006054CE   0006                   add     [esi], al
006054D0   0000                   add     [eax], al

006054D2   0900                   or      [eax], eax
006054D4   17                     pop     ss
006054D5   51                     push    ecx
006054D6   724D                   jb      00605525
006054D8   656452                 push    edx
006054DB   65636570               arpl    gs:[ebp+$70], sp
006054DF   63616F                 arpl    [ecx+$6F], sp
006054E2   6D                     insd
006054E3   645F                   pop     edi
006054E5   636F72                 arpl    [edi+$72], bp
006054E8   7461                   jz      0060554B
006054EA   646F                   outsd
006054EC   0406                   add     al, +$06
006054EE   0000                   add     [eax], al

006054F0   0900                   or      [eax], eax
006054F2   1E                     push    ds
006054F3   51                     push    ecx
006054F4   724D                   jb      00605543
006054F6   656452                 push    edx
006054F9   65636570               arpl    gs:[ebp+$70], sp
006054FD   63616F                 arpl    [ecx+$6F], sp
00605500   6D                     insd
00605501   645F                   pop     edi
00605503   636F6E                 arpl    [edi+$6E], bp
00605506   7375                   jnb     0060557D
00605508   6D                     insd
00605509   6F                     outsd
0060550A   5F                     pop     edi
0060550B   6D                     insd
0060550C   656469646F0806000009   imul    esp, fs:[edi+ebp*2+$08], $09000006
00605516   0022                   add     [edx], ah
00605518   51                     push    ecx
00605519   724D                   jb      00605568
0060551B   656452                 push    edx
0060551E   65636570               arpl    gs:[ebp+$70], sp
00605522   63616F                 arpl    [ecx+$6F], sp
00605525   6D                     insd
00605526   645F                   pop     edi
00605528   636F6E                 arpl    [edi+$6E], bp
0060552B   7375                   jnb     006055A2
0060552D   6D                     insd
0060552E   6F                     outsd
0060552F   5F                     pop     edi
00605530   6D                     insd
00605531   656469646F5F6573670C   imul    esp, fs:[edi+ebp*2+$5F], $0C677365
0060553B   06                     push    es
0060553C   0000                   add     [eax], al

0060553E   0900                   or      [eax], eax
00605540   2451                   and     al, $51
00605542   724D                   jb      00605591
00605544   656452                 push    edx
00605547   65636570               arpl    gs:[ebp+$70], sp
0060554B   63616F                 arpl    [ecx+$6F], sp
0060554E   6D                     insd
0060554F   645F                   pop     edi
00605551   636F6E                 arpl    [edi+$6E], bp
00605554   7375                   jnb     006055CB
00605556   6D                     insd
00605557   6F                     outsd
00605558   5F                     pop     edi
00605559   6661                   popa
0060555B   7475                   jz      006055D2
0060555D   7261                   jb      006055C0
0060555F   646F                   outsd
00605561   5F                     pop     edi
00605562   7265                   jb      006055C9
00605564   7310                   jnb     00605576
00605566   06                     push    es
00605567   0000                   add     [eax], al

00605569   0900                   or      [eax], eax
0060556B   285172                 sub     [ecx+$72], dl
0060556E   4D                     dec     ebp
0060556F   656452                 push    edx
00605572   65636570               arpl    gs:[ebp+$70], sp
00605576   63616F                 arpl    [ecx+$6F], sp
00605579   6D                     insd
0060557A   645F                   pop     edi
0060557C   636F6E                 arpl    [edi+$6E], bp
0060557F   7375                   jnb     006055F6
00605581   6D                     insd
00605582   6F                     outsd
00605583   5F                     pop     edi
00605584   6661                   popa
00605586   7475                   jz      006055FD
00605588   7261                   jb      006055EB
0060558A   646F                   outsd
0060558C   5F                     pop     edi
0060558D   7265                   jb      006055F4
0060558F   735F                   jnb     006055F0
00605591   657367                 jnb     006055FB
00605594   1406                   adc     al, $06
00605596   0000                   add     [eax], al

00605598   0900                   or      [eax], eax
0060559A   2451                   and     al, $51
0060559C   724D                   jb      006055EB
0060559E   656452                 push    edx
006055A1   65636570               arpl    gs:[ebp+$70], sp
006055A5   63616F                 arpl    [ecx+$6F], sp
006055A8   6D                     insd
006055A9   645F                   pop     edi
006055AB   636F6E                 arpl    [edi+$6E], bp
006055AE   7375                   jnb     00605625
006055B0   6D                     insd
006055B1   6F                     outsd
006055B2   5F                     pop     edi
006055B3   6661                   popa
006055B5   7475                   jz      0060562C
006055B7   7261                   jb      0060561A
006055B9   646F                   outsd
006055BB   5F                     pop     edi
006055BC   636F6D                 arpl    [edi+$6D], bp
006055BF   1806                   sbb     [esi], al
006055C1   0000                   add     [eax], al

006055C3   0900                   or      [eax], eax
006055C5   285172                 sub     [ecx+$72], dl
006055C8   4D                     dec     ebp
006055C9   656452                 push    edx
006055CC   65636570               arpl    gs:[ebp+$70], sp
006055D0   63616F                 arpl    [ecx+$6F], sp
006055D3   6D                     insd
006055D4   645F                   pop     edi
006055D6   636F6E                 arpl    [edi+$6E], bp
006055D9   7375                   jnb     00605650
006055DB   6D                     insd
006055DC   6F                     outsd
006055DD   5F                     pop     edi
006055DE   6661                   popa
006055E0   7475                   jz      00605657
006055E2   7261                   jb      00605645
006055E4   646F                   outsd
006055E6   5F                     pop     edi
006055E7   636F6D                 arpl    [edi+$6D], bp
006055EA   5F                     pop     edi
006055EB   657367                 jnb     00605655
006055EE   1C06                   sbb     al, $06
006055F0   0000                   add     [eax], al

006055F2   0900                   or      [eax], eax
006055F4   2451                   and     al, $51
006055F6   724D                   jb      00605645
006055F8   656452                 push    edx
006055FB   65636570               arpl    gs:[ebp+$70], sp
006055FF   63616F                 arpl    [ecx+$6F], sp
00605602   6D                     insd
00605603   645F                   pop     edi
00605605   636F6E                 arpl    [edi+$6E], bp
00605608   7375                   jnb     0060567F
0060560A   6D                     insd
0060560B   6F                     outsd
0060560C   5F                     pop     edi
0060560D   6661                   popa
0060560F   7475                   jz      00605686
00605611   7261                   jb      00605674
00605613   646F                   outsd
00605615   5F                     pop     edi
00605616   696E6420060000         imul    ebp, [esi+$64], $00000620
0060561D   0900                   or      [eax], eax
0060561F   285172                 sub     [ecx+$72], dl
00605622   4D                     dec     ebp
00605623   656452                 push    edx
00605626   65636570               arpl    gs:[ebp+$70], sp
0060562A   63616F                 arpl    [ecx+$6F], sp
0060562D   6D                     insd
0060562E   645F                   pop     edi
00605630   636F6E                 arpl    [edi+$6E], bp
00605633   7375                   jnb     006056AA
00605635   6D                     insd
00605636   6F                     outsd
00605637   5F                     pop     edi
00605638   6661                   popa
0060563A   7475                   jz      006056B1
0060563C   7261                   jb      0060569F
0060563E   646F                   outsd
00605640   5F                     pop     edi
00605641   696E645F657367         imul    ebp, [esi+$64], $6773655F
00605648   2406                   and     al, $06
0060564A   0000                   add     [eax], al

0060564C   0900                   or      [eax], eax
0060564E   2451                   and     al, $51
00605650   724D                   jb      0060569F
00605652   656452                 push    edx
00605655   65636570               arpl    gs:[ebp+$70], sp
00605659   63616F                 arpl    [ecx+$6F], sp
0060565C   6D                     insd
0060565D   645F                   pop     edi
0060565F   636F6E                 arpl    [edi+$6E], bp
00605662   7375                   jnb     006056D9
00605664   6D                     insd
00605665   6F                     outsd
00605666   5F                     pop     edi
00605667   6661                   popa
00605669   7475                   jz      006056E0
0060566B   7261                   jb      006056CE
0060566D   646F                   outsd
0060566F   5F                     pop     edi
00605670   7075                   jo      006056E7
00605672   6228                   bound   ebp, qword ptr [eax]
00605674   06                     push    es
00605675   0000                   add     [eax], al

00605677   0900                   or      [eax], eax
00605679   285172                 sub     [ecx+$72], dl
0060567C   4D                     dec     ebp
0060567D   656452                 push    edx
00605680   65636570               arpl    gs:[ebp+$70], sp
00605684   63616F                 arpl    [ecx+$6F], sp
00605687   6D                     insd
00605688   645F                   pop     edi
0060568A   636F6E                 arpl    [edi+$6E], bp
0060568D   7375                   jnb     00605704
0060568F   6D                     insd
00605690   6F                     outsd
00605691   5F                     pop     edi
00605692   6661                   popa
00605694   7475                   jz      0060570B
00605696   7261                   jb      006056F9
00605698   646F                   outsd
0060569A   5F                     pop     edi
0060569B   7075                   jo      00605712
0060569D   625F65                 bound   ebx, qword ptr [edi+$65]
006056A0   7367                   jnb     00605709
006056A2   2C06                   sub     al, $06
006056A4   0000                   add     [eax], al

006056A6   0900                   or      [eax], eax
006056A8   2451                   and     al, $51
006056AA   724D                   jb      006056F9
006056AC   656452                 push    edx
006056AF   65636570               arpl    gs:[ebp+$70], sp
006056B3   63616F                 arpl    [ecx+$6F], sp
006056B6   6D                     insd
006056B7   645F                   pop     edi
006056B9   636F6E                 arpl    [edi+$6E], bp
006056BC   7375                   jnb     00605733
006056BE   6D                     insd
006056BF   6F                     outsd
006056C0   5F                     pop     edi
006056C1   6661                   popa
006056C3   7475                   jz      0060573A
006056C5   7261                   jb      00605728
006056C7   646F                   outsd
006056C9   5F                     pop     edi
006056CA   736F                   jnb     0060573B
006056CC   6330                   arpl    [eax], si
006056CE   06                     push    es
006056CF   0000                   add     [eax], al

006056D1   0900                   or      [eax], eax
006056D3   285172                 sub     [ecx+$72], dl
006056D6   4D                     dec     ebp
006056D7   656452                 push    edx
006056DA   65636570               arpl    gs:[ebp+$70], sp
006056DE   63616F                 arpl    [ecx+$6F], sp
006056E1   6D                     insd
006056E2   645F                   pop     edi
006056E4   636F6E                 arpl    [edi+$6E], bp
006056E7   7375                   jnb     0060575E
006056E9   6D                     insd
006056EA   6F                     outsd
006056EB   5F                     pop     edi
006056EC   6661                   popa
006056EE   7475                   jz      00605765
006056F0   7261                   jb      00605753
006056F2   646F                   outsd
006056F4   5F                     pop     edi
006056F5   736F                   jnb     00605766
006056F7   635F65                 arpl    [edi+$65], bx
006056FA   7367                   jnb     00605763
006056FC   3406                   xor     al, $06
006056FE   0000                   add     [eax], al

00605700   0900                   or      [eax], eax
00605702   235172                 and     edx, [ecx+$72]
00605705   4D                     dec     ebp
00605706   656452                 push    edx
00605709   65636570               arpl    gs:[ebp+$70], sp
0060570D   63616F                 arpl    [ecx+$6F], sp
00605710   6D                     insd
00605711   645F                   pop     edi
00605713   636F6E                 arpl    [edi+$6E], bp
00605716   7375                   jnb     0060578D
00605718   6D                     insd
00605719   6F                     outsd
0060571A   5F                     pop     edi
0060571B   6661                   popa
0060571D   7475                   jz      00605794
0060571F   7261                   jb      00605782
00605721   646F                   outsd
00605723   5F                     pop     edi
00605724   6561                   popa
00605726   3806                   cmp     [esi], al
00605728   0000                   add     [eax], al

0060572A   0900                   or      [eax], eax
0060572C   27                     daa
0060572D   51                     push    ecx
0060572E   724D                   jb      0060577D
00605730   656452                 push    edx
00605733   65636570               arpl    gs:[ebp+$70], sp
00605737   63616F                 arpl    [ecx+$6F], sp
0060573A   6D                     insd
0060573B   645F                   pop     edi
0060573D   636F6E                 arpl    [edi+$6E], bp
00605740   7375                   jnb     006057B7
00605742   6D                     insd
00605743   6F                     outsd
00605744   5F                     pop     edi
00605745   6661                   popa
00605747   7475                   jz      006057BE
00605749   7261                   jb      006057AC
0060574B   646F                   outsd
0060574D   5F                     pop     edi
0060574E   6561                   popa
00605750   5F                     pop     edi
00605751   657367                 jnb     006057BB
00605754   3C06                   cmp     al, $06
00605756   0000                   add     [eax], al

00605758   1100                   adc     [eax], eax
0060575A   1A5172                 sbb     dl, byte ptr [ecx+$72]
0060575D   4D                     dec     ebp
0060575E   656452                 push    edx
00605761   65636570               arpl    gs:[ebp+$70], sp
00605765   63616F                 arpl    [ecx+$6F], sp
00605768   6D                     insd
00605769   645F                   pop     edi
0060576B   7661                   jbe     006057CE
0060576D   6C                     insb
0060576E   6F                     outsd
0060576F   725F                   jb      006057D0
00605771   61                     popa
00605772   677561                 jnz     006057D6
00605775   40                     inc     eax
00605776   06                     push    es
00605777   0000                   add     [eax], al

00605779   1100                   adc     [eax], eax
0060577B   1C51                   sbb     al, $51
0060577D   724D                   jb      006057CC
0060577F   656452                 push    edx
00605782   65636570               arpl    gs:[ebp+$70], sp
00605786   63616F                 arpl    [ecx+$6F], sp
00605789   6D                     insd
0060578A   645F                   pop     edi
0060578C   7661                   jbe     006057EF
0060578E   6C                     insb
0060578F   6F                     outsd
00605790   725F                   jb      006057F1
00605792   657367                 jnb     006057FC
00605795   6F                     outsd
00605796   746F                   jz      00605807
00605798   44                     inc     esp
00605799   06                     push    es
0060579A   0000                   add     [eax], al

0060579C   1100                   adc     [eax], eax
0060579E   1D51724D65             sbb     eax, $654D7251
006057A3   6452                   push    edx
006057A5   65636570               arpl    gs:[ebp+$70], sp
006057A9   63616F                 arpl    [ecx+$6F], sp
006057AC   6D                     insd
006057AD   645F                   pop     edi
006057AF   7661                   jbe     00605812
006057B1   6C                     insb
006057B2   6F                     outsd
006057B3   725F                   jb      00605814
006057B5   7365                   jnb     0060581C
006057B7   7276                   jb      0060582F
006057B9   69636F48060000         imul    esp, [ebx+$6F], $00000648
006057C0   1100                   adc     [eax], eax
006057C2   1D51724D65             sbb     eax, $654D7251
006057C7   6452                   push    edx
006057C9   65636570               arpl    gs:[ebp+$70], sp
006057CD   63616F                 arpl    [ecx+$6F], sp
006057D0   6D                     insd
006057D1   645F                   pop     edi
006057D3   7661                   jbe     00605836
006057D5   6C                     insb
006057D6   6F                     outsd
006057D7   725F                   jb      00605838
006057D9   637265                 arpl    [edx+$65], si
006057DC   6469746F4C06000011     imul    esi, fs:[edi+ebp*2+$4C], $11000006
006057E5   001F                   add     [edi], bl
006057E7   51                     push    ecx
006057E8   724D                   jb      00605837
006057EA   656452                 push    edx
006057ED   65636570               arpl    gs:[ebp+$70], sp
006057F1   63616F                 arpl    [ecx+$6F], sp
006057F4   6D                     insd
006057F5   645F                   pop     edi
006057F7   7661                   jbe     0060585A
006057F9   6C                     insb
006057FA   6F                     outsd
006057FB   725F                   jb      0060585C
006057FD   6465766F               jbe     00605870
00605801   6C                     insb
00605802   7563                   jnz     00605867
00605804   61                     popa
00605805   6F                     outsd
00605806   50                     push    eax
00605807   06                     push    es
00605808   0000                   add     [eax], al

0060580A   1100                   adc     [eax], eax
0060580C   185172                 sbb     [ecx+$72], dl
0060580F   4D                     dec     ebp
00605810   656452                 push    edx
00605813   65636570               arpl    gs:[ebp+$70], sp
00605817   63616F                 arpl    [ecx+$6F], sp
0060581A   6D                     insd
0060581B   645F                   pop     edi
0060581D   7661                   jbe     00605880
0060581F   6C                     insb
00605820   6F                     outsd
00605821   725F                   jb      00605882
00605823   69725406000011         imul    esi, [edx+$54], $11000006
0060582A   001A                   add     [edx], bl
0060582C   51                     push    ecx
0060582D   724D                   jb      0060587C
0060582F   656452                 push    edx
00605832   65636570               arpl    gs:[ebp+$70], sp
00605836   63616F                 arpl    [ecx+$6F], sp
00605839   6D                     insd
0060583A   645F                   pop     edi
0060583C   7661                   jbe     0060589F
0060583E   6C                     insb
0060583F   6F                     outsd
00605840   725F                   jb      006058A1
00605842   63736C                 arpl    [ebx+$6C], si
00605845   6C                     insb
00605846   58                     pop     eax
00605847   06                     push    es
00605848   0000                   add     [eax], al

0060584A   1100                   adc     [eax], eax
0060584C   195172                 sbb     [ecx+$72], edx
0060584F   4D                     dec     ebp
00605850   656452                 push    edx
00605853   65636570               arpl    gs:[ebp+$70], sp
00605857   63616F                 arpl    [ecx+$6F], sp
0060585A   6D                     insd
0060585B   645F                   pop     edi
0060585D   7661                   jbe     006058C0
0060585F   6C                     insb
00605860   6F                     outsd
00605861   725F                   jb      006058C2
00605863   7069                   jo      006058CE
00605865   735C                   jnb     006058C3
00605867   06                     push    es
00605868   0000                   add     [eax], al

0060586A   1100                   adc     [eax], eax
0060586C   1C51                   sbb     al, $51
0060586E   724D                   jb      006058BD
00605870   656452                 push    edx
00605873   65636570               arpl    gs:[ebp+$70], sp
00605877   63616F                 arpl    [ecx+$6F], sp
0060587A   6D                     insd
0060587B   645F                   pop     edi
0060587D   7661                   jbe     006058E0
0060587F   6C                     insb
00605880   6F                     outsd
00605881   725F                   jb      006058E2
00605883   636F66                 arpl    [edi+$66], bp
00605886   696E7360060000         imul    ebp, [esi+$73], $00000660
0060588D   1100                   adc     [eax], eax
0060588F   225172                 and     dl, byte ptr [ecx+$72]
00605892   4D                     dec     ebp
00605893   656452                 push    edx
00605896   65636570               arpl    gs:[ebp+$70], sp
0060589A   63616F                 arpl    [ecx+$6F], sp
0060589D   6D                     insd
0060589E   645F                   pop     edi
006058A0   7661                   jbe     00605903
006058A2   6C                     insb
006058A3   6F                     outsd
006058A4   725F                   jb      00605905
006058A6   7361                   jnb     00605909
006058A8   6C                     insb
006058A9   646F                   outsd
006058AB   5F                     pop     edi
006058AC   6465626974             bound   ebp, qword ptr gs:[ecx+$74]
006058B1   6F                     outsd
006058B2   6406                   push    es
006058B4   0000                   add     [eax], al

006058B6   1100                   adc     [eax], eax
006058B8   235172                 and     edx, [ecx+$72]
006058BB   4D                     dec     ebp
006058BC   656452                 push    edx
006058BF   65636570               arpl    gs:[ebp+$70], sp
006058C3   63616F                 arpl    [ecx+$6F], sp
006058C6   6D                     insd
006058C7   645F                   pop     edi
006058C9   7661                   jbe     0060592C
006058CB   6C                     insb
006058CC   6F                     outsd
006058CD   725F                   jb      0060592E
006058CF   7361                   jnb     00605932
006058D1   6C                     insb
006058D2   646F                   outsd
006058D4   5F                     pop     edi
006058D5   637265                 arpl    [edx+$65], si
006058D8   6469746F6806000009     imul    esi, fs:[edi+ebp*2+$68], $09000006
006058E1   0021                   add     [ecx], ah
006058E3   51                     push    ecx
006058E4   724D                   jb      00605933
006058E6   656452                 push    edx
006058E9   65636570               arpl    gs:[ebp+$70], sp
006058ED   63616F                 arpl    [ecx+$6F], sp
006058F0   6D                     insd
006058F1   645F                   pop     edi
006058F3   6C                     insb
006058F4   656974757261735F6E     imul    esi, gs:[ebp+esi*2+$72], $6E5F7361
006058FD   61                     popa
006058FE   6F                     outsd
006058FF   5F                     pop     edi
00605900   7265                   jb      00605967
00605902   61                     popa
00605903   6C                     insb
00605904   6C                     insb
00605905   06                     push    es
00605906   0000                   add     [eax], al

00605908   0900                   or      [eax], eax
0060590A   1F                     pop     ds
0060590B   51                     push    ecx
0060590C   724D                   jb      0060595B
0060590E   656452                 push    edx
00605911   65636570               arpl    gs:[ebp+$70], sp
00605915   63616F                 arpl    [ecx+$6F], sp
00605918   7065                   jo      0060597F
0060591A   7263                   jb      0060597F
0060591C   5F                     pop     edi
0060591D   6C                     insb
0060591E   656974757261735F72     imul    esi, gs:[ebp+esi*2+$72], $725F7361
00605927   6561                   popa
00605929   6C                     insb
0060592A   7006                   jo      00605932
0060592C   0000                   add     [eax], al

0060592E   0900                   or      [eax], eax
00605930   235172                 and     edx, [ecx+$72]
00605933   4D                     dec     ebp
00605934   656452                 push    edx
00605937   65636570               arpl    gs:[ebp+$70], sp
0060593B   63616F                 arpl    [ecx+$6F], sp
0060593E   7065                   jo      006059A5
00605940   7263                   jb      006059A5
00605942   5F                     pop     edi
00605943   6C                     insb
00605944   656974757261735F6E     imul    esi, gs:[ebp+esi*2+$72], $6E5F7361
0060594D   61                     popa
0060594E   6F                     outsd
0060594F   5F                     pop     edi
00605950   7265                   jb      006059B7
00605952   61                     popa
00605953   6C                     insb
00605954   7406                   jz      0060595C
00605956   0000                   add     [eax], al

00605958   0F0017                 lldt    word ptr [edi]
0060595B   52                     push    edx
0060595C   7650                   jbe     006059AE
0060595E   726A                   jb      006059CA
00605960   50                     push    eax
00605961   657266                 jb      006059CA
00605964   6F                     outsd
00605965   726D                   jb      006059D4
00605967   52                     push    edx
00605968   656652                 push    dx
0060596B   65636570               arpl    gs:[ebp+$70], sp
0060596F   63616F                 arpl    [ecx+$6F], sp
00605972   7806                   js      0060597A
00605974   0000                   add     [eax], al

00605976   1000                   adc     [eax], al
00605978   115276                 adc     [edx+$76], edx
0060597B   44                     inc     esp
0060597C   53                     push    ebx
0060597D   43                     inc     ebx
0060597E   50                     push    eax
0060597F   657266                 jb      006059E8
00605982   52                     push    edx
00605983   65636570               arpl    gs:[ebp+$70], sp
00605987   63616F                 arpl    [ecx+$6F], sp
0060598A   7C06                   jl      00605992
0060598C   0000                   add     [eax], al

0060598E   0A00                   or      al, byte ptr [eax]
00605990   1451                   adc     al, $51
00605992   724D                   jb      006059E1
00605994   656452                 push    edx
00605997   65636570               arpl    gs:[ebp+$70], sp
0060599B   63616F                 arpl    [ecx+$6F], sp
0060599E   7469                   jz      00605A09
006059A0   7475                   jz      00605A17
006059A2   6C                     insb
006059A3   6F                     outsd
006059A4   31800600000A           xor     [eax+$A000006], eax
006059AA   001451                 add     [ecx+edx*2], dl
006059AD   724D                   jb      006059FC
006059AF   656452                 push    edx
006059B2   65636570               arpl    gs:[ebp+$70], sp
006059B6   63616F                 arpl    [ecx+$6F], sp
006059B9   7469                   jz      00605A24
006059BB   7475                   jz      00605A32
006059BD   6C                     insb
006059BE   6F                     outsd
006059BF   320D001E002C           xor     cl, byte ptr [$2C001E00]
006059C5   7960                   jns     00605A27
006059C7   0017                   add     [edi], dl
006059C9   51                     push    ecx
006059CA   724D                   jb      00605A19
006059CC   656452                 push    edx
006059CF   65636570               arpl    gs:[ebp+$70], sp
006059D3   63616F                 arpl    [ecx+$6F], sp
006059D6   43                     inc     ebx
006059D7   61                     popa
006059D8   6C                     insb
006059D9   634669                 arpl    [esi+$69], ax
006059DC   656C                   insb
006059DE   64731E                 jnb     006059FF
006059E1   00586F                 add     [eax+$6F], bl
006059E4   60                     pusha
006059E5   0017                   add     [edi], dl
006059E7   636D62                 arpl    [ebp+$62], bp
006059EA   56                     push    esi
006059EB   657252                 jb      00605A40
006059EE   656652                 push    dx
006059F1   65636570               arpl    gs:[ebp+$70], sp
006059F5   63616F                 arpl    [ecx+$6F], sp
006059F8   43                     inc     ebx
006059F9   68616E6765             push    $65676E61
006059FE   1800                   sbb     [eax], al
00605A00   48                     dec     eax
00605A01   7C60                   jl      00605A63
00605A03   0011                   add     [ecx], dl
00605A05   7362                   jnb     00605A69
00605A07   746E                   jz      00605A77
00605A09   49                     dec     ecx
00605A0A   6D                     insd
00605A0B   7072                   jo      00605A7F
00605A0D   696D6972436C69         imul    ebp, [ebp+$69], $696C4372
00605A14   636B19                 arpl    [ebx+$19], bp
00605A17   00D8                   add     al, bl
00605A19   6560                   pusha
00605A1B   0012                   add     [edx], dl
00605A1D   636D62                 arpl    [ebp+$62], bp
00605A20   56                     push    esi
00605A21   657241                 jb      00605A65
00605A24   67656E                 outsb
00605A27   7465                   jz      00605A8E
00605A29   43                     inc     ebx
00605A2A   68616E6765             push    $65676E61
00605A2F   17                     pop     ss
00605A30   009873600010           add     [eax+$10006073], bl
00605A36   636D62                 arpl    [ebp+$62], bp
00605A39   56                     push    esi
00605A3A   657252                 jb      00605A8F
00605A3D   6F                     outsd
00605A3E   7461                   jz      00605AA1
00605A40   43                     inc     ebx
00605A41   68616E6765             push    $65676E61
00605A46   1D00986A60             sbb     eax, $606A9800
00605A4B   0016                   add     [esi], dl
00605A4D   636D62                 arpl    [ebp+$62], bp
00605A50   56                     push    esi
00605A51   657252                 jb      00605AA6
00605A54   6566657265             jb      00605ABE
00605A59   6E                     outsb
00605A5A   636961                 arpl    [ecx+$61], bp
00605A5D   43                     inc     ebx
00605A5E   68616E6765             push    $65676E61
00605A63   1900                   sbb     [eax], eax
00605A65   E87C600012             call    1260BAE6
00605A6A   7362                   jnb     00605ACE
00605A6C   746E                   jz      00605ADC
00605A6E   50                     push    eax
00605A6F   657371                 jnb     00605AE3
00605A72   7569                   jnz     00605ADD
00605A74   7361                   jnb     00605AD7
00605A76   7243                   jb      00605ABB
00605A78   6C                     insb
00605A79   69636B16001462         imul    esp, [ebx+$6B], $62140016
00605A80   60                     pusha
00605A81   000F                   add     [edi], cl
00605A83   636D62                 arpl    [ebp+$62], bp
00605A86   52                     push    edx
00605A87   6F                     outsd
00605A88   7461                   jz      00605AEB
00605A8A   44                     inc     esp
00605A8B   726F                   jb      00605AFC
00605A8D   7044                   jo      00605AD3
00605A8F   6F                     outsd
00605A90   776E                   jnbe    00605B00
00605A92   17                     pop     ss
00605A93   00785C                 add     [eax+$5C], bh
00605A96   60                     pusha
00605A97   0010                   add     [eax], dl
00605A99   636D62                 arpl    [ebp+$62], bp
00605A9C   47                     inc     edi
00605A9D   7275                   jb      00605B14
00605A9F   706F                   jo      00605B10
00605AA1   44                     inc     esp
00605AA2   726F                   jb      00605B13
00605AA4   7044                   jo      00605AEA
00605AA6   6F                     outsd
00605AA7   776E                   jnbe    00605B17
00605AA9   1800                   sbb     [eax], al
00605AAB   B05B                   mov     al, $5B
00605AAD   60                     pusha
00605AAE   0011                   add     [ecx], dl
00605AB0   636D62                 arpl    [ebp+$62], bp
00605AB3   41                     inc     ecx
00605AB4   67656E                 outsb
00605AB7   7465                   jz      00605B1E
00605AB9   44                     inc     esp
00605ABA   726F                   jb      00605B2B
00605ABC   7044                   jo      00605B02
00605ABE   6F                     outsd
00605ABF   776E                   jnbe    00605B2F
00605AC1   1C00                   sbb     al, $00
00605AC3   FC                     cld
00605AC4   60                     pusha
00605AC5   60                     pusha
00605AC6   0015636D6252           add     [$52626D63], dl
00605ACC   6566657265             jb      00605B36
00605AD1   6E                     outsb
00605AD2   636961                 arpl    [ecx+$61], bp
00605AD5   44                     inc     esp
00605AD6   726F                   jb      00605B47
00605AD8   7044                   jo      00605B1E
00605ADA   6F                     outsd
00605ADB   776E                   jnbe    00605B4B
00605ADD   1900                   sbb     [eax], eax
00605ADF   F0                     lock
00605AE0   7A60                   jp      00605B42
00605AE2   0012                   add     [edx], dl
00605AE4   7262                   jb      00605B48
00605AE6   7452                   jz      00605B3A
00605AE8   6566657265             jb      00605B52
00605AED   6E                     outsb
00605AEE   636961                 arpl    [ecx+$61], bp
00605AF1   43                     inc     ebx
00605AF2   6C                     insb
00605AF3   69636B13005878         imul    esp, [ebx+$6B], $78580013
00605AFA   60                     pusha
00605AFB   000C46                 add     [esi+eax*2], cl
00605AFE   6F                     outsd
00605AFF   726D                   jb      00605B6E
00605B01   41                     inc     ecx
00605B02   63746976               arpl    [ecx+ebp*2+$76], si
00605B06   61                     popa
00605B07   7465                   jz      00605B6E
00605B09   18546672               sbb     [esi+$72], dl
00605B0D   6D                     insd
00605B0E   52                     push    edx
00605B0F   656C                   insb
00605B11   61                     popa
00605B12   746F                   jz      00605B83
00605B14   7269                   jb      00605B7F
00605B16   6F                     outsd
00605B17   50                     push    eax
00605B18   657266                 jb      00605B81
00605B1B   6F                     outsd
00605B1C   726D                   jb      00605B8B
00605B1E   61                     popa
00605B1F   6E                     outsb
00605B20   636512                 arpl    [ebp+$12], sp
00605B23   00680E                 add     [eax+$0E], ch
00605B26   4C                     dec     esp
00605B27   0008                   add     [eax], cl
00605B29   084C00D0               or      [eax+eax-$30], cl
00605B2D   AB                     stosd
00605B2E   43                     inc     ebx
00605B2F   0008                   add     [eax], cl
00605B31   F9                     stc
00605B32   43                     inc     ebx
00605B33   00E4                   add     ah, ah
00605B35   B543                   mov     ch, $43
00605B37   00B0DA430064           add     [eax+$640043DA], dh
00605B3D   C54B00                 lds     ecx, [ebx+$00]
00605B40   0CD1                   or      al, $D1
00605B42   4A                     dec     edx
00605B43   0030                   add     [eax], dh

* Possible String Reference to: 'tºH'
|
00605B45   C7480028BA4800         mov     dword ptr [eax+$00], $0048BA28
00605B4C   BCB4480070             mov     esp, $700048B4
00605B51   005C009C               add     [eax+eax-$64], bl
00605B55   F0                     lock
00605B56   48                     dec     eax
00605B57   0080D55A00F0           add     [eax+$F0005AD5], al
00605B5D   D85500                 fcom    dword ptr [ebp+$00]
00605B60   308E54009044           xor     [esi+$44900054], cl
00605B66   4E                     dec     esi
00605B67   00DC                   add     ah, bl
00605B69   C1480070               ror     dword ptr [eax+$00], $70
00605B6D   5B                     pop     ebx
00605B6E   60                     pusha
00605B6F   0007                   add     [edi], al
00605B71   18546672               sbb     [esi+$72], dl
00605B75   6D                     insd
00605B76   52                     push    edx
00605B77   656C                   insb
00605B79   61                     popa
00605B7A   746F                   jz      00605BEB
00605B7C   7269                   jb      00605BE7
00605B7E   6F                     outsd
00605B7F   50                     push    eax
00605B80   657266                 jb      00605BE9
00605B83   6F                     outsd
00605B84   726D                   jb      00605BF3
00605B86   61                     popa
00605B87   6E                     outsb
00605B88   636554                 arpl    [ebp+$54], sp
00605B8B   44                     inc     esp
00605B8C   60                     pusha
00605B8D   00C0                   add     al, al
00605B8F   AA                     stosb
00605B90   56                     push    esi
00605B91   006B00                 add     [ebx+$00], ch
00605B94   187546                 sbb     [ebp+$46], dh
00605B97   726D                   jb      00605C06
00605B99   52                     push    edx
00605B9A   656C                   insb
00605B9C   61                     popa
00605B9D   746F                   jz      00605C0E
00605B9F   7269                   jb      00605C0A
00605BA1   6F                     outsd
00605BA2   50                     push    eax
00605BA3   657266                 jb      00605C0C
00605BA6   6F                     outsd
00605BA7   726D                   jb      00605C16
00605BA9   61                     popa
00605BAA   6E                     outsb
00605BAB   636500                 arpl    [ebp+$00], sp
00605BAE   0090558BEC6A           add     [eax+$6AEC8B55], dl
00605BB4   005356                 add     [ebx+$56], dl
00605BB7   8BD8                   mov     ebx, eax
00605BB9   33C0                   xor     eax, eax
00605BBB   55                     push    ebp

* Possible String Reference to: 'é9ôßÿëð^[Y]Ã'
|
00605BBC   68565C6000             push    $00605C56

***** TRY
|
00605BC1   64FF30                 push    dword ptr fs:[eax]
00605BC4   648920                 mov     fs:[eax], esp
00605BC7   8B83B8030000           mov     eax, [ebx+$03B8]
00605BCD   8B10                   mov     edx, [eax]
00605BCF   FF92E8000000           call    dword ptr [edx+$00E8]
00605BD5   8B83B8030000           mov     eax, [ebx+$03B8]
00605BDB   8B8084020000           mov     eax, [eax+$0284]
00605BE1   8B10                   mov     edx, [eax]
00605BE3   FF5244                 call    dword ptr [edx+$44]
00605BE6   8B83C0030000           mov     eax, [ebx+$03C0]

|
00605BEC   E81F89E9FF             call    0049E510
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
00605C15   8B83B8030000           mov     eax, [ebx+$03B8]
00605C1B   8B8084020000           mov     eax, [eax+$0284]
00605C21   8B08                   mov     ecx, [eax]
00605C23   FF5138                 call    dword ptr [ecx+$38]
00605C26   8B83C0030000           mov     eax, [ebx+$03C0]

|
00605C2C   E8EFB3E9FF             call    004A1020
00605C31   8BB3C0030000           mov     esi, [ebx+$03C0]
00605C37   80BEA100000000         cmp     byte ptr [esi+$00A1], $00
00605C3E   74BE                   jz      00605BFE
00605C40   33C0                   xor     eax, eax
00605C42   5A                     pop     edx
00605C43   59                     pop     ecx
00605C44   59                     pop     ecx
00605C45   648910                 mov     fs:[eax], edx

****** FINALLY
|

* Possible String Reference to: '^[Y]Ã'
|
00605C48   685D5C6000             push    $00605C5D
00605C4D   8D45FC                 lea     eax, [ebp-$04]

|
00605C50   E84FFCDFFF             call    004058A4
00605C55   C3                     ret

*)
end;

end.