unit uFrmConsultaMovimento;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics,
  Controls, Forms, Dialogs, StdCtrls
type
  TfrmConsultaMovimento=class(TForm)
    Panel3: TPanel;
    lVersion: TLabel;
    DatabaseOnLine: TDatabase;
    Panel2: TPanel;
    Sair: TSpeedButton;
    Label12: TLabel;
    SBPesquisar: TSpeedButton;
    Label72: TLabel;
    Label73: TLabel;
    EdMat: TEdit;
    cmbLogradouro: TComboBox;
    EdNumero: TEdit;
    QrLogradouro: TQuery;
    QrLogradouroLogradouro: TStringField;
    PageControl: TPageControl;
    TSDadosRetorno: TTabSheet;
    QrBusca: TQuery;
    QrReferencia: TQuery;
    Label1: TLabel;
    cmbReferencia: TComboBox;
    QrReferenciacod_referencia: TStringField;
    Label2: TLabel;
    cmbRoteiro: TComboBox;
    QrRoteiro: TQuery;
    DsBusca: TDataSource;
    DBGrid1: TDBGrid;
    QrBuscacod_referencia: TStringField;
    QrBuscaseq_rota: TFloatField;
    QrBuscaseq_roteiro: TFloatField;
    QrBuscaseq_leitura: TFloatField;
    QrBuscades_inscricao_imobiliaria: TStringField;
    QrBuscaMatricula: TFloatField;
    QrBuscaNome: TStringField;
    QrBuscaTelefone: TStringField;
    QrBuscaCodLogradouro: TFloatField;
    QrBuscaEndereco: TStringField;
    QrBuscaNumeroImovel: TFloatField;
    QrBuscaComplemento: TStringField;
    QrBuscaQtdeMoradores: TFloatField;
    QrBuscaind_entrega_especial: TStringField;
    QrBuscacod_hidrometro: TStringField;
    QrBuscaval_consumo_medio: TFloatField;
    QrBuscadat_vencimento: TDateTimeField;
    QrBuscadat_leitura_anterior: TDateTimeField;
    QrBuscadat_leitura: TDateTimeField;
    QrBuscaval_leitura_anterior: TFloatField;
    QrBuscaval_leitura_real: TFloatField;
    QrBuscaval_consumo_medido: TFloatField;
    QrBuscaval_consumo_atribuido: TFloatField;
    QrBuscaval_consumo_estimado: TFloatField;
    QrBuscaval_consumo_troca: TFloatField;
    QrBuscadat_troca: TDateTimeField;
    QrBuscaval_leitura_atribuida: TFloatField;
    QrBuscaind_leitura_divergente: TStringField;
    QrBuscaval_numero_leituras: TFloatField;
    QrBuscacod_agente: TFloatField;
    QrBuscanom_agente: TStringField;
    QrBuscades_banco_debito: TStringField;
    QrBuscaseq_tipo_entrega: TFloatField;
    QrBuscades_tipo_entrega: TStringField;
    QrBuscaDiasConsumo: TIntegerField;
    TSServico: TTabSheet;
    QrServicoVenda: TQuery;
    DsServicoVenda: TDataSource;
    QrServicoVendaseq_servico: TFloatField;
    QrServicoVendades_servico_fatura: TStringField;
    QrServicoVendaSolicitante: TStringField;
    DBGrid2: TDBGrid;
    DBEdit1: TDBEdit;
    Label3: TLabel;
    DBEdit2: TDBEdit;
    TSAlteracao: TTabSheet;
    Label4: TLabel;
    DBEdit3: TDBEdit;
    DBEdit4: TDBEdit;
    DBGrid3: TDBGrid;
    QrCadastro: TQuery;
    DSCadastro: TDataSource;
    QrCadastroseq_item: TFloatField;
    QrCadastroTipo: TStringField;
    QrCadastrodes_conteudo_anterior: TStringField;
    QrCadastrodes_conteudo_novo: TStringField;
    QrFatura: TQuery;
    DsFatura: TDataSource;
    TSFatura: TTabSheet;
    Label5: TLabel;
    DBEdit5: TDBEdit;
    DBEdit6: TDBEdit;
    DBGrid4: TDBGrid;
    Label6: TLabel;
    Label7: TLabel;
    DBGrid5: TDBGrid;
    QrServicoFaturado: TQuery;
    DsServicoFaturado: TDataSource;
    TSDados: TTabSheet;
    QrDados: TQuery;
    DSDados: TDataSource;
    QrDadoscod_referencia: TStringField;
    QrDadosseq_rota: TFloatField;
    QrDadosseq_roteiro: TFloatField;
    QrDadosseq_leitura: TFloatField;
    QrDadosdes_inscricao_imobiliaria: TStringField;
    QrDadosMatricula: TFloatField;
    QrDadosNome: TStringField;
    QrDadosTelefone: TStringField;
    QrDadosCodLogradouro: TFloatField;
    QrDadosEndereco: TStringField;
    QrDadosNumeroImovel: TFloatField;
    QrDadosComplemento: TStringField;
    QrDadosQtdeMoradores: TFloatField;
    QrDadoscod_hidrometro: TStringField;
    QrDadosval_numero_digitos: TFloatField;
    QrDadosval_consumo_medio: TFloatField;
    QrDadosdat_vencimento: TDateTimeField;
    QrDadosdat_leitura_anterior: TDateTimeField;
    QrDadosval_leitura_anterior: TFloatField;
    QrDadosval_consumo_troca: TFloatField;
    QrDadosdat_troca: TDateTimeField;
    QrDadoscod_agente: TFloatField;
    QrDadosnom_agente: TStringField;
    QrDadoscod_banco: TFloatField;
    QrDadoscod_banco_agencia: TFloatField;
    DBGrid6: TDBGrid;
    QrServicoFaturadodes_servico: TStringField;
    QrServicoFaturadovalor: TFloatField;
    QrGrupo: TQuery;
    QrGrupoGrupo: TStringField;
    Label8: TLabel;
    cmbGrupo: TComboBox;
    QrRoteiroseq_roteiro: TStringField;
    QrFaturades_categoria: TStringField;
    QrFaturaval_numero_economia: TFloatField;
    QrFaturaval_consumo_faturado: TFloatField;
    QrFaturades_taxa: TStringField;
    QrFaturaval_valor_faturado: TFloatField;
    QrFaturaseq_fatura: TFloatField;
    DBNavigator2: TDBNavigator;
    DBNavigator3: TDBNavigator;
    DBNavigator4: TDBNavigator;
    QrFaturacod_referencia: TStringField;
    QrFaturaseq_matricula: TFloatField;
    QrFaturaseq_roteiro: TFloatField;
    TSFotos: TTabSheet;
    DBFotos: TDBGrid;
    Image: TImage;
    Label9: TLabel;
    DBEdit7: TDBEdit;
    DBEdit8: TDBEdit;
    DBNavigator1: TDBNavigator;
    QrFotos: TQuery;
    DsFotos: TDataSource;
    QrFotoscod_referencia: TStringField;
    QrFotosseq_roteiro: TFloatField;
    QrFotosseq_matricula: TFloatField;
    QrFotosseq_foto: TFloatField;
    QrFotosarq_foto: TBlobField;
    QrFotosdes_caminho: TStringField;
    FileListBox: TFileListBox;
    LQtdeCarga: TLabel;
    LQtdeDescarga: TLabel;
    procedure FormShow(Sender : TObject);
    procedure FormClose(Sender : TObject);
    procedure SairClick(Sender : TObject);
    procedure cmbRoteiroDropDown(Sender : TObject);
    procedure cmbReferenciaChange(Sender : TObject);
    procedure SBPesquisarClick(Sender : TObject);
    procedure DsBuscaDataChange(Sender : TObject);
    procedure cmbGrupoDropDown(Sender : TObject);
    procedure DsFaturaDataChange(Sender : TObject);
    procedure DsFotosDataChange(Sender : TObject);
    procedure EdMatKeyPress(Sender : TObject);
    procedure cmbGrupoChange(Sender : TObject);
    procedure _PROC_0062B2E4(Sender : TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end ;

var
  frmConsultaMovimento: TfrmConsultaMovimento;

{This file is generated by DeDe Ver 3.50.04 Copyright (c) 1999-2002 DaFixer}

implementation

{$R *.DFM}

procedure TfrmConsultaMovimento.FormShow(Sender : TObject);
begin
(*
0062A77C   55                     push    ebp
0062A77D   8BEC                   mov     ebp, esp
0062A77F   6A00                   push    $00
0062A781   6A00                   push    $00
0062A783   6A00                   push    $00
0062A785   53                     push    ebx
0062A786   56                     push    esi
0062A787   57                     push    edi
0062A788   8945FC                 mov     [ebp-$04], eax
0062A78B   33C0                   xor     eax, eax
0062A78D   55                     push    ebp
0062A78E   6873A96200             push    $0062A973

***** TRY
|
0062A793   64FF30                 push    dword ptr fs:[eax]
0062A796   648920                 mov     fs:[eax], esp
0062A799   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.lVersion : TLabel
|
0062A79C   8B8064030000           mov     eax, [eax+$0364]

* Possible String Reference to: 'Versão 8.0.0'
|
0062A7A2   BA8CA96200             mov     edx, $0062A98C

|
0062A7A7   E88453E3FF             call    0045FB30
0062A7AC   33C0                   xor     eax, eax
0062A7AE   55                     push    ebp

* Possible String Reference to: 'éª¤Ýÿj'
|
0062A7AF   6831A96200             push    $0062A931

***** TRY
|
0062A7B4   64FF30                 push    dword ptr fs:[eax]
0062A7B7   648920                 mov     fs:[eax], esp
0062A7BA   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.DatabaseOnLine : TDatabase
|
0062A7BD   8B8068030000           mov     eax, [eax+$0368]
0062A7C3   B201                   mov     dl, $01
0062A7C5   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TDatabase.OFFS_48
|
0062A7C7   FF5148                 call    dword ptr [ecx+$48]
0062A7CA   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.cmbReferencia : TComboBox
|
0062A7CD   8B80AC030000           mov     eax, [eax+$03AC]
0062A7D3   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
0062A7D5   FF92E8000000           call    dword ptr [edx+$00E8]
0062A7DB   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.QrReferencia : TQuery
|
0062A7DE   8B80A4030000           mov     eax, [eax+$03A4]

|
0062A7E4   E8273DE7FF             call    0049E510
0062A7E9   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.QrReferencia : TQuery
|
0062A7EC   8B80A4030000           mov     eax, [eax+$03A4]

|
0062A7F2   E8053DE7FF             call    0049E4FC
0062A7F7   EB36                   jmp     0062A82F
0062A7F9   8D55F8                 lea     edx, [ebp-$08]
0062A7FC   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.QrReferenciacod_referencia : TStringField
|
0062A7FF   8B80B0030000           mov     eax, [eax+$03B0]
0062A805   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TStringField.OFFS_60
|
0062A807   FF5160                 call    dword ptr [ecx+$60]
0062A80A   8B55F8                 mov     edx, [ebp-$08]
0062A80D   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.cmbReferencia : TComboBox
|
0062A810   8B80AC030000           mov     eax, [eax+$03AC]

* Reference to field TComboBox.OFFS_0284
|
0062A816   8B8084020000           mov     eax, [eax+$0284]
0062A81C   8B08                   mov     ecx, [eax]
0062A81E   FF5138                 call    dword ptr [ecx+$38]
0062A821   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.QrReferencia : TQuery
|
0062A824   8B80A4030000           mov     eax, [eax+$03A4]

|
0062A82A   E8F167E7FF             call    004A1020
0062A82F   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.QrReferencia : TQuery
|
0062A832   8B80A4030000           mov     eax, [eax+$03A4]

* Reference to field TQuery.OFFS_00A1
|
0062A838   80B8A100000000         cmp     byte ptr [eax+$00A1], $00
0062A83F   74B8                   jz      0062A7F9
0062A841   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.QrReferencia : TQuery
|
0062A844   8B80A4030000           mov     eax, [eax+$03A4]

|
0062A84A   E8C13CE7FF             call    0049E510
0062A84F   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.cmbReferencia : TComboBox
|
0062A852   8B80AC030000           mov     eax, [eax+$03AC]
0062A858   33D2                   xor     edx, edx
0062A85A   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E0
|
0062A85C   FF91E0000000           call    dword ptr [ecx+$00E0]
0062A862   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.cmbLogradouro : TComboBox
|
0062A865   8B8088030000           mov     eax, [eax+$0388]
0062A86B   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
0062A86D   FF92E8000000           call    dword ptr [edx+$00E8]
0062A873   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.cmbLogradouro : TComboBox
|
0062A876   8B8088030000           mov     eax, [eax+$0388]

* Reference to field TComboBox.OFFS_0284
|
0062A87C   8B8084020000           mov     eax, [eax+$0284]
0062A882   33D2                   xor     edx, edx
0062A884   8B08                   mov     ecx, [eax]
0062A886   FF5138                 call    dword ptr [ecx+$38]
0062A889   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.cmbLogradouro : TComboBox
|
0062A88C   8B8088030000           mov     eax, [eax+$0388]
0062A892   33D2                   xor     edx, edx
0062A894   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E0
|
0062A896   FF91E0000000           call    dword ptr [ecx+$00E0]
0062A89C   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.QrLogradouro : TQuery
|
0062A89F   8B8090030000           mov     eax, [eax+$0390]

|
0062A8A5   E8663CE7FF             call    0049E510
0062A8AA   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.QrLogradouro : TQuery
|
0062A8AD   8B8090030000           mov     eax, [eax+$0390]

|
0062A8B3   E8443CE7FF             call    0049E4FC
0062A8B8   EB36                   jmp     0062A8F0
0062A8BA   8D55F4                 lea     edx, [ebp-$0C]
0062A8BD   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.QrLogradouroLogradouro : TStringField
|
0062A8C0   8B8094030000           mov     eax, [eax+$0394]
0062A8C6   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TStringField.OFFS_60
|
0062A8C8   FF5160                 call    dword ptr [ecx+$60]
0062A8CB   8B55F4                 mov     edx, [ebp-$0C]
0062A8CE   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.cmbLogradouro : TComboBox
|
0062A8D1   8B8088030000           mov     eax, [eax+$0388]

* Reference to field TComboBox.OFFS_0284
|
0062A8D7   8B8084020000           mov     eax, [eax+$0284]
0062A8DD   8B08                   mov     ecx, [eax]
0062A8DF   FF5138                 call    dword ptr [ecx+$38]
0062A8E2   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.QrLogradouro : TQuery
|
0062A8E5   8B8090030000           mov     eax, [eax+$0390]

|
0062A8EB   E83067E7FF             call    004A1020
0062A8F0   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.QrLogradouro : TQuery
|
0062A8F3   8B8090030000           mov     eax, [eax+$0390]

* Reference to field TQuery.OFFS_00A1
|
0062A8F9   80B8A100000000         cmp     byte ptr [eax+$00A1], $00
0062A900   74B8                   jz      0062A8BA
0062A902   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.QrLogradouro : TQuery
|
0062A905   8B8090030000           mov     eax, [eax+$0390]

|
0062A90B   E8003CE7FF             call    0049E510
0062A910   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.TSDados : TTabSheet
|
0062A913   8B90D8040000           mov     edx, [eax+$04D8]
0062A919   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.PageControl : TPageControl
|
0062A91C   8B8098030000           mov     eax, [eax+$0398]

* Reference to : TTabStrings._PROC_004C7994()
|
0062A922   E86DD0E9FF             call    004C7994
0062A927   33C0                   xor     eax, eax
0062A929   5A                     pop     edx
0062A92A   59                     pop     ecx
0062A92B   59                     pop     ecx
0062A92C   648910                 mov     fs:[eax], edx
0062A92F   EB27                   jmp     0062A958

|
0062A931   E9AAA4DDFF             jmp     00404DE0
0062A936   6A00                   push    $00
0062A938   0FB70D9CA96200         movzx   ecx, word ptr [$0062A99C]
0062A93F   B202                   mov     dl, $02

* Possible String Reference to: 'Atenção!Não foi possível conectar a
|                                o banco de dado SCaetanoMovimento.C
|                                onfigurar o ODBC.'
|
0062A941   B8A8A96200             mov     eax, $0062A9A8

|
0062A946   E85D62E2FF             call    00450BA8
0062A94B   8B45FC                 mov     eax, [ebp-$04]

* Reference to : TApplication._PROC_0047A1C8()
|
0062A94E   E875F8E4FF             call    0047A1C8

|
0062A953   E85CA9DDFF             call    004052B4

****** END
|
0062A958   33C0                   xor     eax, eax
0062A95A   5A                     pop     edx
0062A95B   59                     pop     ecx
0062A95C   59                     pop     ecx
0062A95D   648910                 mov     fs:[eax], edx

****** FINALLY
|

* Possible String Reference to: '_^[‹å]Ã'
|
0062A960   687AA96200             push    $0062A97A
0062A965   8D45F4                 lea     eax, [ebp-$0C]
0062A968   BA02000000             mov     edx, $00000002

|
0062A96D   E856AFDDFF             call    004058C8
0062A972   C3                     ret


|
0062A973   E91CA7DDFF             jmp     00405094
0062A978   EBEB                   jmp     0062A965

****** END
|
0062A97A   5F                     pop     edi
0062A97B   5E                     pop     esi
0062A97C   5B                     pop     ebx
0062A97D   8BE5                   mov     esp, ebp
0062A97F   5D                     pop     ebp
0062A980   C3                     ret

*)
end;

procedure TfrmConsultaMovimento.FormClose(Sender : TObject);
begin
(*
0062AA04   53                     push    ebx
0062AA05   56                     push    esi
0062AA06   8BF1                   mov     esi, ecx
0062AA08   8BD8                   mov     ebx, eax
0062AA0A   8BC3                   mov     eax, ebx

|
0062AA0C   E807FCFFFF             call    0062A618
0062AA11   A13CF86300             mov     eax, dword ptr [$0063F83C]
0062AA16   8B00                   mov     eax, [eax]
0062AA18   8B8060030000           mov     eax, [eax+$0360]
0062AA1E   8B4034                 mov     eax, [eax+$34]
0062AA21   50                     push    eax
0062AA22   A13CF86300             mov     eax, dword ptr [$0063F83C]
0062AA27   8B00                   mov     eax, [eax]
0062AA29   B101                   mov     cl, $01

* Reference to field TfrmConsultaMovimento.OFFS_0008
|
0062AA2B   8B5308                 mov     edx, [ebx+$08]

|
0062AA2E   E855400000             call    0062EA88
0062AA33   C60602                 mov     byte ptr [esi], $02
0062AA36   5E                     pop     esi
0062AA37   5B                     pop     ebx
0062AA38   C3                     ret

*)
end;

procedure TfrmConsultaMovimento.SairClick(Sender : TObject);
begin
(*

* Reference to : TApplication._PROC_0047A1C8()
|
0062AA3C   E887F7E4FF             call    0047A1C8
0062AA41   C3                     ret

*)
end;

procedure TfrmConsultaMovimento.cmbRoteiroDropDown(Sender : TObject);
begin
(*
0062AA44   55                     push    ebp
0062AA45   8BEC                   mov     ebp, esp
0062AA47   6A00                   push    $00
0062AA49   6A00                   push    $00
0062AA4B   6A00                   push    $00
0062AA4D   53                     push    ebx
0062AA4E   8BD8                   mov     ebx, eax
0062AA50   33C0                   xor     eax, eax
0062AA52   55                     push    ebp

* Possible String Reference to: 'éQ¥Ýÿëã[‹å]Ã'
|
0062AA53   683EAB6200             push    $0062AB3E

***** TRY
|
0062AA58   64FF30                 push    dword ptr fs:[eax]
0062AA5B   648920                 mov     fs:[eax], esp

* Reference to control TfrmConsultaMovimento.cmbRoteiro : TComboBox
|
0062AA5E   8B83B8030000           mov     eax, [ebx+$03B8]
0062AA64   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
0062AA66   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmConsultaMovimento.QrRoteiro : TQuery
|
0062AA6C   8B83BC030000           mov     eax, [ebx+$03BC]

|
0062AA72   E8993AE7FF             call    0049E510
0062AA77   8D55FC                 lea     edx, [ebp-$04]

* Reference to control TfrmConsultaMovimento.cmbReferencia : TComboBox
|
0062AA7A   8B83AC030000           mov     eax, [ebx+$03AC]

|
0062AA80   E87B50E3FF             call    0045FB00
0062AA85   8B45FC                 mov     eax, [ebp-$04]
0062AA88   50                     push    eax

* Possible String Reference to: 'sReferencia'
|
0062AA89   BA54AB6200             mov     edx, $0062AB54

* Reference to control TfrmConsultaMovimento.QrRoteiro : TQuery
|
0062AA8E   8B83BC030000           mov     eax, [ebx+$03BC]

|
0062AA94   E8E7FEE8FF             call    004BA980
0062AA99   5A                     pop     edx

|
0062AA9A   E87D2DE7FF             call    0049D81C
0062AA9F   8D55F8                 lea     edx, [ebp-$08]

* Reference to control TfrmConsultaMovimento.cmbGrupo : TComboBox
|
0062AAA2   8B8360050000           mov     eax, [ebx+$0560]

|
0062AAA8   E85350E3FF             call    0045FB00
0062AAAD   8B45F8                 mov     eax, [ebp-$08]
0062AAB0   50                     push    eax

* Possible String Reference to: 'sGrupo'
|
0062AAB1   BA68AB6200             mov     edx, $0062AB68

* Reference to control TfrmConsultaMovimento.QrRoteiro : TQuery
|
0062AAB6   8B83BC030000           mov     eax, [ebx+$03BC]

|
0062AABC   E8BFFEE8FF             call    004BA980
0062AAC1   5A                     pop     edx

|
0062AAC2   E8552DE7FF             call    0049D81C

* Reference to control TfrmConsultaMovimento.QrRoteiro : TQuery
|
0062AAC7   8B83BC030000           mov     eax, [ebx+$03BC]

|
0062AACD   E82A3AE7FF             call    0049E4FC
0062AAD2   EB2D                   jmp     0062AB01
0062AAD4   8D55F4                 lea     edx, [ebp-$0C]

* Reference to control TfrmConsultaMovimento.QrRoteiroseq_roteiro : TStringField
|
0062AAD7   8B8364050000           mov     eax, [ebx+$0564]

|
0062AADD   E8128AE6FF             call    004934F4
0062AAE2   8B55F4                 mov     edx, [ebp-$0C]

* Reference to control TfrmConsultaMovimento.cmbRoteiro : TComboBox
|
0062AAE5   8B83B8030000           mov     eax, [ebx+$03B8]

* Reference to field TComboBox.OFFS_0284
|
0062AAEB   8B8084020000           mov     eax, [eax+$0284]
0062AAF1   8B08                   mov     ecx, [eax]
0062AAF3   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmConsultaMovimento.QrRoteiro : TQuery
|
0062AAF6   8B83BC030000           mov     eax, [ebx+$03BC]

|
0062AAFC   E81F65E7FF             call    004A1020

* Reference to control TfrmConsultaMovimento.QrRoteiro : TQuery
|
0062AB01   8B83BC030000           mov     eax, [ebx+$03BC]

* Reference to field TQuery.OFFS_00A1
|
0062AB07   80B8A100000000         cmp     byte ptr [eax+$00A1], $00
0062AB0E   74C4                   jz      0062AAD4

* Reference to control TfrmConsultaMovimento.QrRoteiro : TQuery
|
0062AB10   8B83BC030000           mov     eax, [ebx+$03BC]

|
0062AB16   E8F539E7FF             call    0049E510
0062AB1B   33C0                   xor     eax, eax
0062AB1D   5A                     pop     edx
0062AB1E   59                     pop     ecx
0062AB1F   59                     pop     ecx
0062AB20   648910                 mov     fs:[eax], edx

****** FINALLY
|

* Possible String Reference to: '[‹å]Ã'
|
0062AB23   6845AB6200             push    $0062AB45
0062AB28   8D45F4                 lea     eax, [ebp-$0C]

|
0062AB2B   E874ADDDFF             call    004058A4
0062AB30   8D45F8                 lea     eax, [ebp-$08]
0062AB33   BA02000000             mov     edx, $00000002

|
0062AB38   E88BADDDFF             call    004058C8
0062AB3D   C3                     ret


|
0062AB3E   E951A5DDFF             jmp     00405094
0062AB43   EBE3                   jmp     0062AB28

****** END
|
0062AB45   5B                     pop     ebx
0062AB46   8BE5                   mov     esp, ebp
0062AB48   5D                     pop     ebp
0062AB49   C3                     ret

*)
end;

procedure TfrmConsultaMovimento.cmbReferenciaChange(Sender : TObject);
begin
(*
0062AB70   53                     push    ebx
0062AB71   8BD8                   mov     ebx, eax

* Reference to control TfrmConsultaMovimento.cmbRoteiro : TComboBox
|
0062AB73   8B83B8030000           mov     eax, [ebx+$03B8]
0062AB79   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
0062AB7B   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmConsultaMovimento.QrDados : TQuery
|
0062AB81   8B83DC040000           mov     eax, [ebx+$04DC]

|
0062AB87   E88439E7FF             call    0049E510

* Reference to control TfrmConsultaMovimento.QrBusca : TQuery
|
0062AB8C   8B83A0030000           mov     eax, [ebx+$03A0]

|
0062AB92   E87939E7FF             call    0049E510
0062AB97   5B                     pop     ebx
0062AB98   C3                     ret

*)
end;

procedure TfrmConsultaMovimento.SBPesquisarClick(Sender : TObject);
begin
(*
0062AB9C   55                     push    ebp
0062AB9D   8BEC                   mov     ebp, esp
0062AB9F   B908000000             mov     ecx, $00000008
0062ABA4   6A00                   push    $00
0062ABA6   6A00                   push    $00
0062ABA8   49                     dec     ecx
0062ABA9   75F9                   jnz     0062ABA4
0062ABAB   53                     push    ebx
0062ABAC   8BD8                   mov     ebx, eax
0062ABAE   33C0                   xor     eax, eax
0062ABB0   55                     push    ebp

* Possible String Reference to: 'éò¡Ýÿë¼[‹å]Ã'
|
0062ABB1   689DAE6200             push    $0062AE9D

***** TRY
|
0062ABB6   64FF30                 push    dword ptr fs:[eax]
0062ABB9   648920                 mov     fs:[eax], esp
0062ABBC   8D55F8                 lea     edx, [ebp-$08]

* Reference to control TfrmConsultaMovimento.cmbReferencia : TComboBox
|
0062ABBF   8B83AC030000           mov     eax, [ebx+$03AC]

|
0062ABC5   E8364FE3FF             call    0045FB00
0062ABCA   837DF800               cmp     dword ptr [ebp-$08], +$00
0062ABCE   7428                   jz      0062ABF8
0062ABD0   8D55F4                 lea     edx, [ebp-$0C]

* Reference to control TfrmConsultaMovimento.cmbGrupo : TComboBox
|
0062ABD3   8B8360050000           mov     eax, [ebx+$0560]

|
0062ABD9   E8224FE3FF             call    0045FB00
0062ABDE   837DF400               cmp     dword ptr [ebp-$0C], +$00
0062ABE2   7414                   jz      0062ABF8
0062ABE4   8D55F0                 lea     edx, [ebp-$10]

* Reference to control TfrmConsultaMovimento.cmbRoteiro : TComboBox
|
0062ABE7   8B83B8030000           mov     eax, [ebx+$03B8]

|
0062ABED   E80E4FE3FF             call    0045FB00
0062ABF2   837DF000               cmp     dword ptr [ebp-$10], +$00
0062ABF6   7528                   jnz     0062AC20
0062ABF8   6A00                   push    $00
0062ABFA   0FB70DACAE6200         movzx   ecx, word ptr [$0062AEAC]
0062AC01   B201                   mov     dl, $01

* Possible String Reference to: 'Devem ser informados a Referência, 
|                                Grupo e o Roteiro obriatoriamente !'
|
0062AC03   B8B8AE6200             mov     eax, $0062AEB8

|
0062AC08   E89B5FE2FF             call    00450BA8

* Reference to control TfrmConsultaMovimento.cmbReferencia : TComboBox
|
0062AC0D   8B83AC030000           mov     eax, [ebx+$03AC]
0062AC13   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00D4
|
0062AC15   FF92D4000000           call    dword ptr [edx+$00D4]
0062AC1B   E933020000             jmp     0062AE53
0062AC20   6808AF6200             push    $0062AF08
0062AC25   8D55EC                 lea     edx, [ebp-$14]

* Reference to control TfrmConsultaMovimento.cmbGrupo : TComboBox
|
0062AC28   8B8360050000           mov     eax, [ebx+$0560]

|
0062AC2E   E8CD4EE3FF             call    0045FB00
0062AC33   FF75EC                 push    dword ptr [ebp-$14]
0062AC36   8D55E8                 lea     edx, [ebp-$18]

* Reference to control TfrmConsultaMovimento.cmbRoteiro : TComboBox
|
0062AC39   8B83B8030000           mov     eax, [ebx+$03B8]

|
0062AC3F   E8BC4EE3FF             call    0045FB00
0062AC44   FF75E8                 push    dword ptr [ebp-$18]
0062AC47   8D45FC                 lea     eax, [ebp-$04]
0062AC4A   BA03000000             mov     edx, $00000003

|
0062AC4F   E8D4AFDDFF             call    00405C28

* Reference to control TfrmConsultaMovimento.QrDados : TQuery
|
0062AC54   8B83DC040000           mov     eax, [ebx+$04DC]

|
0062AC5A   E8B138E7FF             call    0049E510

* Reference to control TfrmConsultaMovimento.QrBusca : TQuery
|
0062AC5F   8B83A0030000           mov     eax, [ebx+$03A0]

|
0062AC65   E8A638E7FF             call    0049E510

* Reference to control TfrmConsultaMovimento.QrServicoFaturado : TQuery
|
0062AC6A   8B83D0040000           mov     eax, [ebx+$04D0]

|
0062AC70   E89B38E7FF             call    0049E510

* Reference to control TfrmConsultaMovimento.QrServicoVenda : TQuery
|
0062AC75   8B8358040000           mov     eax, [ebx+$0458]

|
0062AC7B   E89038E7FF             call    0049E510

* Reference to control TfrmConsultaMovimento.QrCadastro : TQuery
|
0062AC80   8B8390040000           mov     eax, [ebx+$0490]

|
0062AC86   E88538E7FF             call    0049E510
0062AC8B   8D55E4                 lea     edx, [ebp-$1C]

* Reference to control TfrmConsultaMovimento.cmbReferencia : TComboBox
|
0062AC8E   8B83AC030000           mov     eax, [ebx+$03AC]

|
0062AC94   E8674EE3FF             call    0045FB00
0062AC99   8B45E4                 mov     eax, [ebp-$1C]
0062AC9C   50                     push    eax

* Possible String Reference to: 'sReferencia'
|
0062AC9D   BA14AF6200             mov     edx, $0062AF14

* Reference to control TfrmConsultaMovimento.QrDados : TQuery
|
0062ACA2   8B83DC040000           mov     eax, [ebx+$04DC]

|
0062ACA8   E8D3FCE8FF             call    004BA980
0062ACAD   5A                     pop     edx

|
0062ACAE   E8692BE7FF             call    0049D81C
0062ACB3   33D2                   xor     edx, edx
0062ACB5   8B45FC                 mov     eax, [ebp-$04]

|
0062ACB8   E8C305DEFF             call    0040B280
0062ACBD   50                     push    eax

* Possible String Reference to: 'nRoteiro'
|
0062ACBE   BA28AF6200             mov     edx, $0062AF28

* Reference to control TfrmConsultaMovimento.QrDados : TQuery
|
0062ACC3   8B83DC040000           mov     eax, [ebx+$04DC]

|
0062ACC9   E8B2FCE8FF             call    004BA980
0062ACCE   5A                     pop     edx

|
0062ACCF   E8182AE7FF             call    0049D6EC
0062ACD4   8D55E0                 lea     edx, [ebp-$20]

* Reference to control TfrmConsultaMovimento.EdMat : TEdit
|
0062ACD7   8B8384030000           mov     eax, [ebx+$0384]

|
0062ACDD   E81E4EE3FF             call    0045FB00
0062ACE2   8B45E0                 mov     eax, [ebp-$20]
0062ACE5   33D2                   xor     edx, edx

|
0062ACE7   E89405DEFF             call    0040B280
0062ACEC   50                     push    eax

* Possible String Reference to: 'nMatricula'
|
0062ACED   BA3CAF6200             mov     edx, $0062AF3C

* Reference to control TfrmConsultaMovimento.QrDados : TQuery
|
0062ACF2   8B83DC040000           mov     eax, [ebx+$04DC]

|
0062ACF8   E883FCE8FF             call    004BA980
0062ACFD   5A                     pop     edx

|
0062ACFE   E8E929E7FF             call    0049D6EC
0062AD03   8D55DC                 lea     edx, [ebp-$24]

* Reference to control TfrmConsultaMovimento.cmbLogradouro : TComboBox
|
0062AD06   8B8388030000           mov     eax, [ebx+$0388]

|
0062AD0C   E8EF4DE3FF             call    0045FB00
0062AD11   8B45DC                 mov     eax, [ebp-$24]

|
0062AD14   E82FCCF4FF             call    00577948
0062AD19   50                     push    eax

* Possible String Reference to: 'nLogradouro'
|
0062AD1A   BA50AF6200             mov     edx, $0062AF50

* Reference to control TfrmConsultaMovimento.QrDados : TQuery
|
0062AD1F   8B83DC040000           mov     eax, [ebx+$04DC]

|
0062AD25   E856FCE8FF             call    004BA980
0062AD2A   5A                     pop     edx

|
0062AD2B   E8BC29E7FF             call    0049D6EC

* Reference to control TfrmConsultaMovimento.QrDados : TQuery
|
0062AD30   8B83DC040000           mov     eax, [ebx+$04DC]

|
0062AD36   E8C137E7FF             call    0049E4FC

* Reference to control TfrmConsultaMovimento.QrDados : TQuery
|
0062AD3B   8B83DC040000           mov     eax, [ebx+$04DC]
0062AD41   8B10                   mov     edx, [eax]

* Possible reference to virtual method TQuery.OFFS_016C
|
0062AD43   FF926C010000           call    dword ptr [edx+$016C]
0062AD49   8D55D4                 lea     edx, [ebp-$2C]

|
0062AD4C   E8A302DEFF             call    0040AFF4
0062AD51   8B4DD4                 mov     ecx, [ebp-$2C]
0062AD54   8D45D8                 lea     eax, [ebp-$28]

* Possible String Reference to: 'Carga: '
|
0062AD57   BA64AF6200             mov     edx, $0062AF64

|
0062AD5C   E853AEDDFF             call    00405BB4
0062AD61   8B55D8                 mov     edx, [ebp-$28]

* Reference to control TfrmConsultaMovimento.LQtdeCarga : TLabel
|
0062AD64   8B83D8050000           mov     eax, [ebx+$05D8]

|
0062AD6A   E8C14DE3FF             call    0045FB30
0062AD6F   8D55D0                 lea     edx, [ebp-$30]

* Reference to control TfrmConsultaMovimento.cmbReferencia : TComboBox
|
0062AD72   8B83AC030000           mov     eax, [ebx+$03AC]

|
0062AD78   E8834DE3FF             call    0045FB00
0062AD7D   8B45D0                 mov     eax, [ebp-$30]
0062AD80   50                     push    eax

* Possible String Reference to: 'sReferencia'
|
0062AD81   BA14AF6200             mov     edx, $0062AF14

* Reference to control TfrmConsultaMovimento.QrBusca : TQuery
|
0062AD86   8B83A0030000           mov     eax, [ebx+$03A0]

|
0062AD8C   E8EFFBE8FF             call    004BA980
0062AD91   5A                     pop     edx

|
0062AD92   E8852AE7FF             call    0049D81C
0062AD97   33D2                   xor     edx, edx
0062AD99   8B45FC                 mov     eax, [ebp-$04]

|
0062AD9C   E8DF04DEFF             call    0040B280
0062ADA1   50                     push    eax

* Possible String Reference to: 'nRoteiro'
|
0062ADA2   BA28AF6200             mov     edx, $0062AF28

* Reference to control TfrmConsultaMovimento.QrBusca : TQuery
|
0062ADA7   8B83A0030000           mov     eax, [ebx+$03A0]

|
0062ADAD   E8CEFBE8FF             call    004BA980
0062ADB2   5A                     pop     edx

|
0062ADB3   E83429E7FF             call    0049D6EC
0062ADB8   8D55CC                 lea     edx, [ebp-$34]

* Reference to control TfrmConsultaMovimento.EdMat : TEdit
|
0062ADBB   8B8384030000           mov     eax, [ebx+$0384]

|
0062ADC1   E83A4DE3FF             call    0045FB00
0062ADC6   8B45CC                 mov     eax, [ebp-$34]
0062ADC9   33D2                   xor     edx, edx

|
0062ADCB   E8B004DEFF             call    0040B280
0062ADD0   50                     push    eax

* Possible String Reference to: 'nMatricula'
|
0062ADD1   BA3CAF6200             mov     edx, $0062AF3C

* Reference to control TfrmConsultaMovimento.QrBusca : TQuery
|
0062ADD6   8B83A0030000           mov     eax, [ebx+$03A0]

|
0062ADDC   E89FFBE8FF             call    004BA980
0062ADE1   5A                     pop     edx

|
0062ADE2   E80529E7FF             call    0049D6EC
0062ADE7   8D55C8                 lea     edx, [ebp-$38]

* Reference to control TfrmConsultaMovimento.cmbLogradouro : TComboBox
|
0062ADEA   8B8388030000           mov     eax, [ebx+$0388]

|
0062ADF0   E80B4DE3FF             call    0045FB00
0062ADF5   8B45C8                 mov     eax, [ebp-$38]

|
0062ADF8   E84BCBF4FF             call    00577948
0062ADFD   50                     push    eax

* Possible String Reference to: 'nLogradouro'
|
0062ADFE   BA50AF6200             mov     edx, $0062AF50

* Reference to control TfrmConsultaMovimento.QrBusca : TQuery
|
0062AE03   8B83A0030000           mov     eax, [ebx+$03A0]

|
0062AE09   E872FBE8FF             call    004BA980
0062AE0E   5A                     pop     edx

|
0062AE0F   E8D828E7FF             call    0049D6EC

* Reference to control TfrmConsultaMovimento.QrBusca : TQuery
|
0062AE14   8B83A0030000           mov     eax, [ebx+$03A0]

|
0062AE1A   E8DD36E7FF             call    0049E4FC

* Reference to control TfrmConsultaMovimento.QrBusca : TQuery
|
0062AE1F   8B83A0030000           mov     eax, [ebx+$03A0]
0062AE25   8B10                   mov     edx, [eax]

* Possible reference to virtual method TQuery.OFFS_016C
|
0062AE27   FF926C010000           call    dword ptr [edx+$016C]
0062AE2D   8D55C0                 lea     edx, [ebp-$40]

|
0062AE30   E8BF01DEFF             call    0040AFF4
0062AE35   8B4DC0                 mov     ecx, [ebp-$40]
0062AE38   8D45C4                 lea     eax, [ebp-$3C]

* Possible String Reference to: 'Descarga: '
|
0062AE3B   BA74AF6200             mov     edx, $0062AF74

|
0062AE40   E86FADDDFF             call    00405BB4
0062AE45   8B55C4                 mov     edx, [ebp-$3C]

* Reference to control TfrmConsultaMovimento.LQtdeDescarga : TLabel
|
0062AE48   8B83DC050000           mov     eax, [ebx+$05DC]

|
0062AE4E   E8DD4CE3FF             call    0045FB30
0062AE53   33C0                   xor     eax, eax
0062AE55   5A                     pop     edx
0062AE56   59                     pop     ecx
0062AE57   59                     pop     ecx
0062AE58   648910                 mov     fs:[eax], edx

****** FINALLY
|

* Possible String Reference to: '[‹å]Ã'
|
0062AE5B   68A4AE6200             push    $0062AEA4
0062AE60   8D45C0                 lea     eax, [ebp-$40]
0062AE63   BA02000000             mov     edx, $00000002

|
0062AE68   E85BAADDFF             call    004058C8
0062AE6D   8D45C8                 lea     eax, [ebp-$38]
0062AE70   BA03000000             mov     edx, $00000003

|
0062AE75   E84EAADDFF             call    004058C8
0062AE7A   8D45D4                 lea     eax, [ebp-$2C]
0062AE7D   BA02000000             mov     edx, $00000002

|
0062AE82   E841AADDFF             call    004058C8
0062AE87   8D45DC                 lea     eax, [ebp-$24]
0062AE8A   BA08000000             mov     edx, $00000008

|
0062AE8F   E834AADDFF             call    004058C8
0062AE94   8D45FC                 lea     eax, [ebp-$04]

|
0062AE97   E808AADDFF             call    004058A4
0062AE9C   C3                     ret


|
0062AE9D   E9F2A1DDFF             jmp     00405094
0062AEA2   EBBC                   jmp     0062AE60

****** END
|
0062AEA4   5B                     pop     ebx
0062AEA5   8BE5                   mov     esp, ebp
0062AEA7   5D                     pop     ebp
0062AEA8   C3                     ret

*)
end;

procedure TfrmConsultaMovimento.DsBuscaDataChange(Sender : TObject);
begin
(*
0062AF80   53                     push    ebx
0062AF81   8BD8                   mov     ebx, eax

* Reference to control TfrmConsultaMovimento.QrServicoFaturado : TQuery
|
0062AF83   8B83D0040000           mov     eax, [ebx+$04D0]

|
0062AF89   E88235E7FF             call    0049E510

* Reference to control TfrmConsultaMovimento.QrFatura : TQuery
|
0062AF8E   8B83A8040000           mov     eax, [ebx+$04A8]

|
0062AF94   E87735E7FF             call    0049E510

* Reference to control TfrmConsultaMovimento.QrFatura : TQuery
|
0062AF99   8B83A8040000           mov     eax, [ebx+$04A8]

|
0062AF9F   E85835E7FF             call    0049E4FC

* Reference to control TfrmConsultaMovimento.QrServicoVenda : TQuery
|
0062AFA4   8B8358040000           mov     eax, [ebx+$0458]

|
0062AFAA   E86135E7FF             call    0049E510

* Reference to control TfrmConsultaMovimento.QrServicoVenda : TQuery
|
0062AFAF   8B8358040000           mov     eax, [ebx+$0458]

|
0062AFB5   E84235E7FF             call    0049E4FC

* Reference to control TfrmConsultaMovimento.QrCadastro : TQuery
|
0062AFBA   8B8390040000           mov     eax, [ebx+$0490]

|
0062AFC0   E84B35E7FF             call    0049E510

* Reference to control TfrmConsultaMovimento.QrCadastro : TQuery
|
0062AFC5   8B8390040000           mov     eax, [ebx+$0490]

|
0062AFCB   E82C35E7FF             call    0049E4FC

* Reference to control TfrmConsultaMovimento.QrFotos : TQuery
|
0062AFD0   8B83B4050000           mov     eax, [ebx+$05B4]

|
0062AFD6   E83535E7FF             call    0049E510

* Reference to control TfrmConsultaMovimento.QrFotos : TQuery
|
0062AFDB   8B83B4050000           mov     eax, [ebx+$05B4]

|
0062AFE1   E81635E7FF             call    0049E4FC
0062AFE6   5B                     pop     ebx
0062AFE7   C3                     ret

*)
end;

procedure TfrmConsultaMovimento.cmbGrupoDropDown(Sender : TObject);
begin
(*
0062AFE8   55                     push    ebp
0062AFE9   8BEC                   mov     ebp, esp
0062AFEB   6A00                   push    $00
0062AFED   6A00                   push    $00
0062AFEF   53                     push    ebx
0062AFF0   8BD8                   mov     ebx, eax
0062AFF2   33C0                   xor     eax, eax
0062AFF4   55                     push    ebp

* Possible String Reference to: 'éÜŸÝÿëè[YY]Ã'
|
0062AFF5   68B3B06200             push    $0062B0B3

***** TRY
|
0062AFFA   64FF30                 push    dword ptr fs:[eax]
0062AFFD   648920                 mov     fs:[eax], esp

* Reference to control TfrmConsultaMovimento.cmbGrupo : TComboBox
|
0062B000   8B8360050000           mov     eax, [ebx+$0560]
0062B006   8B10                   mov     edx, [eax]

* Possible reference to virtual method TComboBox.OFFS_00E8
|
0062B008   FF92E8000000           call    dword ptr [edx+$00E8]

* Reference to control TfrmConsultaMovimento.QrGrupo : TQuery
|
0062B00E   8B8354050000           mov     eax, [ebx+$0554]

|
0062B014   E8F734E7FF             call    0049E510
0062B019   8D55FC                 lea     edx, [ebp-$04]

* Reference to control TfrmConsultaMovimento.cmbReferencia : TComboBox
|
0062B01C   8B83AC030000           mov     eax, [ebx+$03AC]

|
0062B022   E8D94AE3FF             call    0045FB00
0062B027   8B45FC                 mov     eax, [ebp-$04]
0062B02A   50                     push    eax

* Possible String Reference to: 'sReferencia'
|
0062B02B   BAC8B06200             mov     edx, $0062B0C8

* Reference to control TfrmConsultaMovimento.QrGrupo : TQuery
|
0062B030   8B8354050000           mov     eax, [ebx+$0554]

|
0062B036   E845F9E8FF             call    004BA980
0062B03B   5A                     pop     edx

|
0062B03C   E8DB27E7FF             call    0049D81C

* Reference to control TfrmConsultaMovimento.QrGrupo : TQuery
|
0062B041   8B8354050000           mov     eax, [ebx+$0554]

|
0062B047   E8B034E7FF             call    0049E4FC
0062B04C   EB2D                   jmp     0062B07B
0062B04E   8D55F8                 lea     edx, [ebp-$08]

* Reference to control TfrmConsultaMovimento.QrGrupoGrupo : TStringField
|
0062B051   8B8358050000           mov     eax, [ebx+$0558]

|
0062B057   E89884E6FF             call    004934F4
0062B05C   8B55F8                 mov     edx, [ebp-$08]

* Reference to control TfrmConsultaMovimento.cmbGrupo : TComboBox
|
0062B05F   8B8360050000           mov     eax, [ebx+$0560]

* Reference to field TComboBox.OFFS_0284
|
0062B065   8B8084020000           mov     eax, [eax+$0284]
0062B06B   8B08                   mov     ecx, [eax]
0062B06D   FF5138                 call    dword ptr [ecx+$38]

* Reference to control TfrmConsultaMovimento.QrGrupo : TQuery
|
0062B070   8B8354050000           mov     eax, [ebx+$0554]

|
0062B076   E8A55FE7FF             call    004A1020

* Reference to control TfrmConsultaMovimento.QrGrupo : TQuery
|
0062B07B   8B8354050000           mov     eax, [ebx+$0554]

* Reference to field TQuery.OFFS_00A1
|
0062B081   80B8A100000000         cmp     byte ptr [eax+$00A1], $00
0062B088   74C4                   jz      0062B04E

* Reference to control TfrmConsultaMovimento.QrGrupo : TQuery
|
0062B08A   8B8354050000           mov     eax, [ebx+$0554]

|
0062B090   E87B34E7FF             call    0049E510
0062B095   33C0                   xor     eax, eax
0062B097   5A                     pop     edx
0062B098   59                     pop     ecx
0062B099   59                     pop     ecx
0062B09A   648910                 mov     fs:[eax], edx

****** FINALLY
|

* Possible String Reference to: '[YY]Ã'
|
0062B09D   68BAB06200             push    $0062B0BA
0062B0A2   8D45F8                 lea     eax, [ebp-$08]

|
0062B0A5   E8FAA7DDFF             call    004058A4
0062B0AA   8D45FC                 lea     eax, [ebp-$04]

|
0062B0AD   E8F2A7DDFF             call    004058A4
0062B0B2   C3                     ret


|
0062B0B3   E9DC9FDDFF             jmp     00405094
0062B0B8   EBE8                   jmp     0062B0A2

****** END
|
0062B0BA   5B                     pop     ebx
0062B0BB   59                     pop     ecx
0062B0BC   59                     pop     ecx
0062B0BD   5D                     pop     ebp
0062B0BE   C3                     ret

*)
end;

procedure TfrmConsultaMovimento.DsFaturaDataChange(Sender : TObject);
begin
(*
0062B0D4   53                     push    ebx
0062B0D5   8BD8                   mov     ebx, eax

* Reference to control TfrmConsultaMovimento.QrServicoFaturado : TQuery
|
0062B0D7   8B83D0040000           mov     eax, [ebx+$04D0]

|
0062B0DD   E82E34E7FF             call    0049E510

* Reference to control TfrmConsultaMovimento.QrServicoFaturado : TQuery
|
0062B0E2   8B83D0040000           mov     eax, [ebx+$04D0]

|
0062B0E8   E80F34E7FF             call    0049E4FC
0062B0ED   5B                     pop     ebx
0062B0EE   C3                     ret

*)
end;

procedure TfrmConsultaMovimento.DsFotosDataChange(Sender : TObject);
begin
(*
0062B0F0   55                     push    ebp
0062B0F1   8BEC                   mov     ebp, esp
0062B0F3   6A00                   push    $00
0062B0F5   6A00                   push    $00
0062B0F7   6A00                   push    $00
0062B0F9   6A00                   push    $00
0062B0FB   53                     push    ebx
0062B0FC   56                     push    esi
0062B0FD   57                     push    edi
0062B0FE   8945FC                 mov     [ebp-$04], eax
0062B101   33C0                   xor     eax, eax
0062B103   55                     push    ebp
0062B104   687DB26200             push    $0062B27D

***** TRY
|
0062B109   64FF30                 push    dword ptr fs:[eax]
0062B10C   648920                 mov     fs:[eax], esp
0062B10F   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.Image : TImage
|
0062B112   8B80A0050000           mov     eax, [eax+$05A0]
0062B118   33D2                   xor     edx, edx

|
0062B11A   E80149E3FF             call    0045FA20
0062B11F   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.QrFotosseq_matricula : TFloatField
|
0062B122   8B80C4050000           mov     eax, [eax+$05C4]
0062B128   8B10                   mov     edx, [eax]

* Possible reference to virtual method TFloatField.OFFS_54
|
0062B12A   FF5254                 call    dword ptr [edx+$54]
0062B12D   D81D8CB26200           fcomp   dword ptr [$0062B28C]
0062B133   9B                     wait
0062B134   DFE0                   fstsw   ax
0062B136   9E                     sahf
0062B137   0F8625010000           jbe     0062B262
0062B13D   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.QrFotosseq_foto : TFloatField
|
0062B140   8B80C8050000           mov     eax, [eax+$05C8]
0062B146   8B10                   mov     edx, [eax]

* Possible reference to virtual method TFloatField.OFFS_54
|
0062B148   FF5254                 call    dword ptr [edx+$54]
0062B14B   D81D8CB26200           fcomp   dword ptr [$0062B28C]
0062B151   9B                     wait
0062B152   DFE0                   fstsw   ax
0062B154   9E                     sahf
0062B155   0F8607010000           jbe     0062B262
0062B15B   33C0                   xor     eax, eax
0062B15D   55                     push    ebp
0062B15E   6848B26200             push    $0062B248

***** TRY
|
0062B163   64FF30                 push    dword ptr fs:[eax]
0062B166   648920                 mov     fs:[eax], esp
0062B169   8B45FC                 mov     eax, [ebp-$04]

* Reference to field TfrmConsultaMovimento.OFFS_05E0
|
0062B16C   83B8E005000000         cmp     dword ptr [eax+$05E0], +$00
0062B173   7414                   jz      0062B189
0062B175   8B45FC                 mov     eax, [ebp-$04]

* Reference to field TfrmConsultaMovimento.OFFS_05E0
|
0062B178   8B80E0050000           mov     eax, [eax+$05E0]

|
0062B17E   E8E5ABDDFF             call    00405D68
0062B183   50                     push    eax

* Reference to: kernel32.DeleteFileA()
|
0062B184   E83BD1DDFF             call    004082C4
0062B189   8D55F8                 lea     edx, [ebp-$08]
0062B18C   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.QrFotosarq_foto : TBlobField
|
0062B18F   8B80CC050000           mov     eax, [eax+$05CC]
0062B195   8B08                   mov     ecx, [eax]

* Possible reference to virtual method TBlobField.OFFS_60
|
0062B197   FF5160                 call    dword ptr [ecx+$60]
0062B19A   837DF800               cmp     dword ptr [ebp-$08], +$00
0062B19E   0F849A000000           jz      0062B23E

* Possible String Reference to: 'C:\OnPlace\Fotos\FT'
|
0062B1A4   6898B26200             push    $0062B298
0062B1A9   8D55F4                 lea     edx, [ebp-$0C]
0062B1AC   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.QrFotosseq_matricula : TFloatField
|
0062B1AF   8B80C4050000           mov     eax, [eax+$05C4]

|
0062B1B5   E83A83E6FF             call    004934F4
0062B1BA   FF75F4                 push    dword ptr [ebp-$0C]
0062B1BD   8D55F0                 lea     edx, [ebp-$10]
0062B1C0   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.QrFotosseq_foto : TFloatField
|
0062B1C3   8B80C8050000           mov     eax, [eax+$05C8]

|
0062B1C9   E82683E6FF             call    004934F4
0062B1CE   FF75F0                 push    dword ptr [ebp-$10]

* Possible String Reference to: '.JPG'
|
0062B1D1   68B4B26200             push    $0062B2B4
0062B1D6   8B45FC                 mov     eax, [ebp-$04]
0062B1D9   05E0050000             add     eax, +$000005E0
0062B1DE   BA04000000             mov     edx, $00000004

|
0062B1E3   E840AADDFF             call    00405C28
0062B1E8   8B45FC                 mov     eax, [ebp-$04]

* Reference to field TfrmConsultaMovimento.OFFS_05E0
|
0062B1EB   8B90E0050000           mov     edx, [eax+$05E0]
0062B1F1   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.QrFotosarq_foto : TBlobField
|
0062B1F4   8B80CC050000           mov     eax, [eax+$05CC]

|
0062B1FA   E861D6E6FF             call    00498860
0062B1FF   8B45FC                 mov     eax, [ebp-$04]

* Reference to field TfrmConsultaMovimento.OFFS_05E0
|
0062B202   8B80E0050000           mov     eax, [eax+$05E0]

|
0062B208   E86304DEFF             call    0040B670
0062B20D   84C0                   test    al, al
0062B20F   742D                   jz      0062B23E
0062B211   8B45FC                 mov     eax, [ebp-$04]

* Reference to field TfrmConsultaMovimento.OFFS_05E0
|
0062B214   8B90E0050000           mov     edx, [eax+$05E0]
0062B21A   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.Image : TImage
|
0062B21D   8B80A0050000           mov     eax, [eax+$05A0]

* Reference to field TImage.OFFS_0198
|
0062B223   8B8098010000           mov     eax, [eax+$0198]

|
0062B229   E8DEA3E0FF             call    0043560C
0062B22E   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.Image : TImage
|
0062B231   8B80A0050000           mov     eax, [eax+$05A0]
0062B237   B201                   mov     dl, $01

|
0062B239   E8E247E3FF             call    0045FA20
0062B23E   33C0                   xor     eax, eax
0062B240   5A                     pop     edx
0062B241   59                     pop     ecx
0062B242   59                     pop     ecx
0062B243   648910                 mov     fs:[eax], edx
0062B246   EB1A                   jmp     0062B262

|
0062B248   E9939BDDFF             jmp     00404DE0
0062B24D   8B45FC                 mov     eax, [ebp-$04]

* Reference to control TfrmConsultaMovimento.Image : TImage
|
0062B250   8B80A0050000           mov     eax, [eax+$05A0]
0062B256   33D2                   xor     edx, edx

|
0062B258   E8C347E3FF             call    0045FA20

|
0062B25D   E852A0DDFF             call    004052B4

****** END
|
0062B262   33C0                   xor     eax, eax
0062B264   5A                     pop     edx
0062B265   59                     pop     ecx
0062B266   59                     pop     ecx
0062B267   648910                 mov     fs:[eax], edx

****** FINALLY
|

* Possible String Reference to: '_^[‹å]Ã'
|
0062B26A   6884B26200             push    $0062B284
0062B26F   8D45F0                 lea     eax, [ebp-$10]
0062B272   BA03000000             mov     edx, $00000003

|
0062B277   E84CA6DDFF             call    004058C8
0062B27C   C3                     ret


|
0062B27D   E9129EDDFF             jmp     00405094
0062B282   EBEB                   jmp     0062B26F

****** END
|
0062B284   5F                     pop     edi
0062B285   5E                     pop     esi
0062B286   5B                     pop     ebx
0062B287   8BE5                   mov     esp, ebp
0062B289   5D                     pop     ebp
0062B28A   C3                     ret

*)
end;

procedure TfrmConsultaMovimento.EdMatKeyPress(Sender : TObject);
begin
(*
0062B2BC   80390D                 cmp     byte ptr [ecx], $0D
0062B2BF   7505                   jnz     0062B2C6

* Reference to : TfrmConsultaMovimento.SBPesquisarClick()
|
0062B2C1   E8D6F8FFFF             call    0062AB9C
0062B2C6   C3                     ret

*)
end;

procedure TfrmConsultaMovimento.cmbGrupoChange(Sender : TObject);
begin
(*
0062B2C8   53                     push    ebx
0062B2C9   8BD8                   mov     ebx, eax

* Reference to control TfrmConsultaMovimento.QrDados : TQuery
|
0062B2CB   8B83DC040000           mov     eax, [ebx+$04DC]

|
0062B2D1   E83A32E7FF             call    0049E510

* Reference to control TfrmConsultaMovimento.QrBusca : TQuery
|
0062B2D6   8B83A0030000           mov     eax, [ebx+$03A0]

|
0062B2DC   E82F32E7FF             call    0049E510
0062B2E1   5B                     pop     ebx
0062B2E2   C3                     ret

*)
end;

procedure TfrmConsultaMovimento._PROC_0062B2E4(Sender : TObject);
begin
(*
0062B2E4   E8B2620003             call    0363159B
0062B2E9   0A544761               or      dl, byte ptr [edi+eax*2+$61]
0062B2ED   7567                   jnz     0062B356
0062B2EF   654B                   dec     ebx
0062B2F1   696E6401000000         imul    ebp, [esi+$64], $00000001
0062B2F8   000400                 add     [eax+eax], al
0062B2FB   0000                   add     [eax], al

0062B2FD   E4B2                   in      al, $B2
0062B2FF   6200                   bound   eax, qword ptr [eax]
0062B301   06                     push    es
0062B302   676B546578             imul    edx, [si+$65], $78
0062B307   740F                   jz      0062B318
0062B309   676B486F72             imul    ecx, [bx+si+$6F], $72
0062B30E   697A6F6E74616C         imul    edi, [edx+$6F], $6C61746E
0062B315   42                     inc     edx
0062B316   61                     popa
0062B317   720D                   jb      0062B326
0062B319   676B566572             imul    edx, [bp+$65], $72
0062B31E   7469                   jz      0062B389
0062B320   63616C                 arpl    [ecx+$6C], sp
0062B323   42                     inc     edx
0062B324   61                     popa
0062B325   7205                   jb      0062B32C
0062B327   676B506965             imul    edx, [bx+si+$69], $65
0062B32C   08676B                 or      [edi+$6B], ah
0062B32F   4E                     dec     esi
0062B330   6565646C               insb
0062B334   6506                   push    es
0062B336   47                     inc     edi
0062B337   61                     popa
0062B338   7567                   jnz     0062B3A1
0062B33A   657388                 jnb     0062B2C5
0062B33D   B362                   mov     bl, $62
0062B33F   0000                   add     [eax], al

0062B341   0000                   add     [eax], al

0062B343   0000                   add     [eax], al

0062B345   0000                   add     [eax], al

0062B347   0000                   add     [eax], al

0062B349   0000                   add     [eax], al

0062B34B   0028                   add     [eax], ch
0062B34D   B462                   mov     ah, $62
0062B34F   0000                   add     [eax], al

0062B351   0000                   add     [eax], al

0062B353   0000                   add     [eax], al

0062B355   0000                   add     [eax], al

0062B357   0000                   add     [eax], al

0062B359   0000                   add     [eax], al

0062B35B   001CB4                 add     [esp+esi*4], bl
0062B35E   6200                   bound   eax, qword ptr [eax]
0062B360   B001                   mov     al, $01
0062B362   0000                   add     [eax], al

0062B364   44                     inc     esp
0062B365   B745                   mov     bh, $45
0062B367   007CC542               add     [ebp+eax*8+$42], bh
0062B36B   00144B                 add     [ebx+ecx*2], dl
0062B36E   40                     inc     eax
0062B36F   00B8BE42001C           add     [eax+$1C0042BE], bh
0062B375   4B                     dec     ebx
0062B376   40                     inc     eax
0062B377   00B41146005848         add     [ecx+edx+$48580046], dh
0062B37E   40                     inc     eax
0062B37F   00744840               add     [eax+ecx*2+$40], dh
0062B383   00B88E4600A8           add     [eax+$A800468E], bh
0062B389   224600                 and     al, byte ptr [esi+$00]
0062B38C   B014                   mov     al, $14
0062B38E   46                     inc     esi
0062B38F   000C31                 add     [ecx+esi], cl
0062B392   42                     inc     edx
0062B393   007022                 add     [eax+$22], dh
0062B396   46                     inc     esi
0062B397   00F4                   add     ah, dh
0062B399   ED                     in      eax, dx
0062B39A   45                     inc     ebp
0062B39B   0060ED                 add     [eax-$13], ah
0062B39E   45                     inc     ebp
0062B39F   00E8                   add     al, ch
0062B3A1   F8                     clc
0062B3A2   45                     inc     ebp
0062B3A3   0094C5420078C2         add     [ebp+eax*8+$C2780042], dl
0062B3AA   42                     inc     edx
0062B3AB   0070C2                 add     [eax-$3E], dh
0062B3AE   42                     inc     edx
0062B3AF   009CC54200F8B8         add     [ebp+eax*8+$B8F80042], bl
0062B3B6   6200                   bound   eax, qword ptr [eax]
0062B3B8   D80B                   fmul    dword ptr [ebx]
0062B3BA   46                     inc     esi
0062B3BB   00D4                   add     ah, dl
0062B3BD   0B4600                 or      eax, [esi+$00]
0062B3C0   A4                     movsb
0062B3C1   0C46                   or      al, $46
0062B3C3   00B0EB4500F0           add     [eax+$F00045EB], dh
0062B3C9   F4                     hlt
0062B3CA   45                     inc     ebp
0062B3CB   0054F445               add     [esp+esi*8+$45], dl
0062B3CF   0020                   add     [eax], ah
0062B3D1   FE4500                 inc     byte ptr [ebp+$00]
0062B3D4   F0                     lock
0062B3D5   EA4500F4EA             jmp     $EAF40045
0062B3DA   45                     inc     ebp
0062B3DB   004024                 add     [eax+$24], al
0062B3DE   46                     inc     esi
0062B3DF   006C2446               add     [esp+$46], ch
0062B3E3   0030                   add     [eax], dh
0062B3E5   ED                     in      eax, dx
0062B3E6   45                     inc     ebp
0062B3E7   00CC                   add     ah, cl
0062B3E9   F8                     clc
0062B3EA   45                     inc     ebp
0062B3EB   002CED450058FA         add     [$FA580045+ebp*8], ch
0062B3F2   45                     inc     ebp
0062B3F3   00D4                   add     ah, dl
0062B3F5   F9                     stc
0062B3F6   45                     inc     ebp
0062B3F7   00E8                   add     al, ch
0062B3F9   FC                     cld
0062B3FA   45                     inc     ebp
0062B3FB   0094FB4500E40E         add     [ebx+edi*8+$EE40045], dl
0062B402   46                     inc     esi
0062B403   00F0                   add     al, dh
0062B405   2446                   and     al, $46
0062B407   00E0                   add     al, ah
0062B409   FF4500                 inc     dword ptr [ebp+$00]
0062B40C   0C01                   or      al, $01
0062B40E   46                     inc     esi
0062B40F   0034EF                 add     [edi+ebp*8], dh
0062B412   45                     inc     ebp
0062B413   00EC                   add     ah, ch
0062B415   004600                 add     [esi+$00], al
0062B418   BCB9620006             mov     esp, $060062B9
0062B41D   54                     push    esp
0062B41E   47                     inc     edi
0062B41F   61                     popa
0062B420   7567                   jnz     0062B489
0062B422   6590                   nop
0062B424   28B46200070654         sub     [edx+$54060700], dh
0062B42B   47                     inc     edi
0062B42C   61                     popa
0062B42D   7567                   jnz     0062B496
0062B42F   6588B362003CB8         mov     gs:[ebx+$B83C0062], dh
0062B436   45                     inc     ebp
0062B437   0021                   add     [ecx], ah
0062B439   0006                   add     [esi], al
0062B43B   47                     inc     edi
0062B43C   61                     popa
0062B43D   7567                   jnz     0062B4A6
0062B43F   657314                 jnb     0062B456
0062B442   001496                 add     [esi+edx*4], dl
0062B445   45                     inc     ebp
0062B446   005B00                 add     [ebx+$00], bl
0062B449   00FF                   add     bh, bh
0062B44B   4C                     dec     esp
0062B44C   EE                     out     dx, al
0062B44D   45                     inc     ebp
0062B44E   0001                   add     [ecx], al
0062B450   0000                   add     [eax], al

0062B452   0000                   add     [eax], al

0062B454   0000                   add     [eax], al

0062B456   800000                 add     byte ptr [eax], $00
0062B459   0000                   add     [eax], al

0062B45B   0D0005416C             or      eax, $6C410500
0062B460   69676EB49E4500         imul    esp, [edi+$6E], $00459EB4
0062B467   61                     popa
0062B468   0000                   add     [eax], al

0062B46A   FFC0                   inc     eax
0062B46C   EB45                   jmp     0062B4B3
0062B46E   00DC                   add     ah, bl
0062B470   EC                     in      al, dx
0062B471   45                     inc     ebp
0062B472   0000                   add     [eax], al

0062B474   0000                   add     [eax], al

0062B476   800300                 add     byte ptr [ebx], $00
0062B479   0000                   add     [eax], al

0062B47B   0E                     push    cs
0062B47C   0007                   add     [edi], al
0062B47E   41                     inc     ecx
0062B47F   6E                     outsb
0062B480   63686F                 arpl    [eax+$6F], bp
0062B483   7273                   jb      0062B4F8
0062B485   94                     xchg    eax, esp
0062B486   FD                     std
0062B487   42                     inc     edx
0062B488   00AC0100FFA8C1         add     [ecx+eax+$C1A8FF00], ch
0062B48F   6200                   bound   eax, qword ptr [eax]
0062B491   0100                   add     [eax], eax
0062B493   0000                   add     [eax], al

0062B495   0000                   add     [eax], al

0062B497   0080FFFFFF00           add     [eax+$FFFFFF], al
0062B49D   0F0009                 str     word ptr [ecx]
0062B4A0   42                     inc     edx
0062B4A1   61                     popa
0062B4A2   636B43                 arpl    [ebx+$43], bp
0062B4A5   6F                     outsd
0062B4A6   6C                     insb
0062B4A7   6F                     outsd
0062B4A8   7264                   jb      0062B50E
0062B4AA   124700                 adc     al, byte ptr [edi+$00]
0062B4AD   A6                     cmpsb
0062B4AE   0100                   add     [eax], eax
0062B4B0   FF80C1620001           inc     dword ptr [eax+$10062C1]
0062B4B6   0000                   add     [eax], al

0062B4B8   0000                   add     [eax], al

0062B4BA   0000                   add     [eax], al

0062B4BC   800100                 add     byte ptr [ecx], $00
0062B4BF   0000                   add     [eax], al

0062B4C1   1000                   adc     [eax], al
0062B4C3   0B426F                 or      eax, [edx+$6F]
0062B4C6   7264                   jb      0062B52C
0062B4C8   657253                 jb      0062B51E
0062B4CB   7479                   jz      0062B546
0062B4CD   6C                     insb
0062B4CE   6594                   xchg    eax, esp
0062B4D0   FD                     std
0062B4D1   42                     inc     edx
0062B4D2   007000                 add     [eax+$00], dh
0062B4D5   00FF                   add     bh, bh
0062B4D7   A0FC4500BC             mov     al, byte ptr [$BC0045FC]
0062B4DC   FC                     cld
0062B4DD   45                     inc     ebp
0062B4DE   0000                   add     [eax], al

0062B4E0   0000                   add     [eax], al

0062B4E2   80050000FF1100         add     byte ptr [$11FF0000], $00
0062B4E9   05436F6C6F             add     eax, +$6F6C6F43
0062B4EE   725C                   jb      0062B54C
0062B4F0   9F                     lahf
0062B4F1   45                     inc     ebp
0062B4F2   00740000               add     [eax+eax+$00], dh
0062B4F6   FFA826460001           jmp     [eax+$1004626]
0062B4FC   0000                   add     [eax], al

0062B4FE   0000                   add     [eax], al

0062B500   0000                   add     [eax], al

0062B502   800000                 add     byte ptr [eax], $00
0062B505   008012000B43           add     [eax+$430B0012], al
0062B50B   6F                     outsd
0062B50C   6E                     outsb
0062B50D   7374                   jnb     0062B583
0062B50F   7261                   jb      0062B572
0062B511   696E7473001040         imul    ebp, [esi+$74], $40100073
0062B518   005000                 add     [eax+$00], dl
0062B51B   00FE                   add     dh, bh
0062B51D   680000FED0             push    $D0FE0000
0062B522   214600                 and     [esi+$00], eax
0062B525   0000                   add     [eax], al

0062B527   008001000000           add     [eax+$0001], al
0062B52D   1300                   adc     eax, [eax]
0062B52F   07                     pop     es
0062B530   45                     inc     ebp
0062B531   6E                     outsb
0062B532   61                     popa
0062B533   626C6564               bound   ebp, qword ptr [ebp+$64]
0062B537   94                     xchg    eax, esp
0062B538   FD                     std
0062B539   42                     inc     edx
0062B53A   00A80100FF94           add     [eax+$94FF0001], ch
0062B540   C1620001               shl     dword ptr [edx+$00], $01
0062B544   0000                   add     [eax], al

0062B546   0000                   add     [eax], al

0062B548   0000                   add     [eax], al

0062B54A   800000                 add     byte ptr [eax], $00
0062B54D   0000                   add     [eax], al

0062B54F   1400                   adc     al, $00
0062B551   09466F                 or      [esi+$6F], eax
0062B554   7265                   jb      0062B5BB
0062B556   43                     inc     ebx
0062B557   6F                     outsd
0062B558   6C                     insb
0062B559   6F                     outsd
0062B55A   724C                   jb      0062B5A8
0062B55C   024300                 add     al, byte ptr [ebx+$00]
0062B55F   680000FFF4             push    $F4FF0000
0062B564   FB                     sti
0062B565   45                     inc     ebp
0062B566   0004FC                 add     [esp+edi*8], al
0062B569   45                     inc     ebp
0062B56A   0000                   add     [eax], al

0062B56C   0000                   add     [eax], al

0062B56E   800000                 add     byte ptr [eax], $00
0062B571   008015000446           add     [eax+$46040015], al
0062B577   6F                     outsd
0062B578   6E                     outsb
0062B579   74E4                   jz      0062B55F
0062B57B   B262                   mov     dl, $62
0062B57D   00A40100FF58C1         add     [ecx+eax+$C158FF00], ah
0062B584   6200                   bound   eax, qword ptr [eax]
0062B586   0100                   add     [eax], eax
0062B588   0000                   add     [eax], al

0062B58A   0000                   add     [eax], al

0062B58C   008001000000           add     [eax+$0001], al
0062B592   16                     push    ss
0062B593   00044B                 add     [ebx+ecx*2], al
0062B596   696E6454104000         imul    ebp, [esi+$64], $00401054
0062B59D   98                     cwde 
0062B59E   0100                   add     [eax], eax
0062B5A0   FFBC                   DB  $FF, $BC  //      
0062B5A2   C1620001               shl     dword ptr [edx+$00], $01
0062B5A6   0000                   add     [eax], al

0062B5A8   0000                   add     [eax], al

0062B5AA   0000                   add     [eax], al

0062B5AC   800000                 add     byte ptr [eax], $00
0062B5AF   0000                   add     [eax], al

0062B5B1   17                     pop     ss
0062B5B2   0008                   add     [eax], cl
0062B5B4   4D                     dec     ebp
0062B5B5   696E56616C7565         imul    ebp, [esi+$56], $65756C61
0062B5BC   54                     push    esp
0062B5BD   104000                 adc     [eax+$00], al
0062B5C0   9C                     pushf   
0062B5C1   0100                   add     [eax], eax
0062B5C3   FF6CC262               jmp     [edx+eax*8+$62]
0062B5C7   0001                   add     [ecx], al
0062B5C9   0000                   add     [eax], al

*)
end;

end.