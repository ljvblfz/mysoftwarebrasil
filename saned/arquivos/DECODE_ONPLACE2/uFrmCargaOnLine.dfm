object frmCargaOnLine: TfrmCargaOnLine
  Left = 0
  Top = 0
  Caption = ' '
  ClientHeight = 341
  ClientWidth = 588
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  FormStyle = fsMDIChild
  OldCreateOrder = False
  Position = poScreenCenter
  Visible = True
  OnClose = FormClose
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object MemoArq: TMemo
    Left = 272
    Top = 95
    Width = 185
    Height = 89
    Lines.Strings = (
      'MemoArq')
    TabOrder = 3
  end
  object FileListBox: TFileListBox
    Left = 67
    Top = 55
    Width = 390
    Height = 129
    ItemHeight = 13
    Mask = 'C:\onplace\Saned\On-line\loader*.log'
    TabOrder = 4
  end
  object GroupBox1: TGroupBox
    Left = 0
    Top = 40
    Width = 588
    Height = 258
    Align = alTop
    TabOrder = 1
    object LGrupo: TLabel
      Left = 44
      Top = 48
      Width = 33
      Height = 13
      Caption = 'Grupo:'
    end
    object LRota: TLabel
      Left = 44
      Top = 80
      Width = 27
      Height = 13
      Caption = 'Rota:'
    end
    object cmbGrupo: TComboBox
      Left = 100
      Top = 45
      Width = 89
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      TabOrder = 0
      OnDropDown = cmbGrupoDropDown
    end
    object cmbRota: TComboBox
      Left = 100
      Top = 77
      Width = 89
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      TabOrder = 1
      OnDropDown = cmbRotaDropDown
    end
    object ckbTodos: TCheckBox
      Left = 100
      Top = 104
      Width = 173
      Height = 17
      Caption = 'Todos as rotas'
      TabOrder = 2
      OnClick = ckbTodosClick
    end
    object chbJaGerados: TCheckBox
      Left = 208
      Top = 47
      Width = 233
      Height = 17
      Caption = 'Gerar apenas os arquivos na m'#225'quina local'
      TabOrder = 3
      OnClick = chbJaGeradosClick
    end
    object grbProcessamento: TGroupBox
      Left = 2
      Top = 127
      Width = 584
      Height = 129
      Align = alBottom
      Caption = 'Processamento'
      TabOrder = 4
      object LMens01: TLabel
        Left = 13
        Top = 49
        Width = 383
        Height = 13
        AutoSize = False
        Caption = '       '
      end
      object LMens02: TLabel
        Left = 13
        Top = 97
        Width = 564
        Height = 13
        AutoSize = False
        Caption = '       '
      end
      object ProgressBar: TProgressBar
        Left = 13
        Top = 26
        Width = 383
        Height = 17
        TabOrder = 0
      end
      object ProgressBar2: TProgressBar
        Left = 13
        Top = 74
        Width = 383
        Height = 17
        TabOrder = 1
      end
      object PTempo: TPanel
        Left = 402
        Top = 23
        Width = 175
        Height = 68
        TabOrder = 2
        Visible = False
        object LInicio: TLabel
          Left = 16
          Top = 11
          Width = 76
          Height = 13
          Caption = 'In'#237'cio: 14:00:00'
        end
        object LTempo: TLabel
          Left = 16
          Top = 30
          Width = 67
          Height = 13
          Caption = 'Tempo: 17:00'
        end
        object LTermino: TLabel
          Left = 16
          Top = 49
          Width = 89
          Height = 13
          Caption = 'T'#233'rmino: 14:00:00'
        end
      end
    end
  end
  object pTop: TPanel
    Left = 0
    Top = 0
    Width = 588
    Height = 40
    Align = alTop
    BevelInner = bvRaised
    BorderStyle = bsSingle
    Caption = 'Carga On-Line'
    Color = clNavy
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWhite
    Font.Height = -15
    Font.Name = 'Comic Sans MS'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 0
    object lVersion: TLabel
      AlignWithMargins = True
      Left = 513
      Top = 5
      Width = 66
      Height = 26
      Align = alRight
      Alignment = taRightJustify
      Caption = 'Caption Vers'#227'o'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWhite
      Font.Height = -9
      Font.Name = 'Comic Sans MS'
      Font.Style = [fsBold]
      ParentFont = False
      Layout = tlCenter
      ExplicitHeight = 13
    end
  end
  object pBottom: TPanel
    Left = 0
    Top = 301
    Width = 588
    Height = 40
    Align = alBottom
    Ctl3D = False
    ParentCtl3D = False
    TabOrder = 2
    DesignSize = (
      588
      40)
    object sbtnSair: TSpeedButton
      Left = 502
      Top = 8
      Width = 80
      Height = 25
      Anchors = [akTop, akRight, akBottom]
      Caption = 'Sai&r'
      Flat = True
      Glyph.Data = {
        76010000424D7601000000000000760000002800000020000000100000000100
        04000000000000010000120B0000120B00001000000000000000000000000000
        800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00330000000000
        03333377777777777F333301BBBBBBBB033333773F3333337F3333011BBBBBBB
        0333337F73F333337F33330111BBBBBB0333337F373F33337F333301110BBBBB
        0333337F337F33337F333301110BBBBB0333337F337F33337F333301110BBBBB
        0333337F337F33337F333301110BBBBB0333337F337F33337F333301110BBBBB
        0333337F337F33337F333301110BBBBB0333337F337FF3337F33330111B0BBBB
        0333337F337733337F333301110BBBBB0333337F337F33337F333301110BBBBB
        0333337F3F7F33337F333301E10BBBBB0333337F7F7F33337F333301EE0BBBBB
        0333337F777FFFFF7F3333000000000003333377777777777333}
      NumGlyphs = 2
      OnClick = sbtnSairClick
      ExplicitLeft = 288
    end
    object sbtnConfirmar: TSpeedButton
      Left = 10
      Top = 6
      Width = 80
      Height = 25
      Anchors = [akLeft, akTop, akBottom]
      Caption = '&Processar'
      Flat = True
      Glyph.Data = {
        76010000424D7601000000000000760000002800000020000000100000000100
        04000000000000010000120B0000120B00001000000000000000000000000000
        800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00555555555555
        555555555555555555555555555555555555555555FF55555555555559055555
        55555555577FF5555555555599905555555555557777F5555555555599905555
        555555557777FF5555555559999905555555555777777F555555559999990555
        5555557777777FF5555557990599905555555777757777F55555790555599055
        55557775555777FF5555555555599905555555555557777F5555555555559905
        555555555555777FF5555555555559905555555555555777FF55555555555579
        05555555555555777FF5555555555557905555555555555777FF555555555555
        5990555555555555577755555555555555555555555555555555}
      NumGlyphs = 2
      OnClick = sbtnConfirmarClick
    end
    object LMensagem: TLabel
      Left = 100
      Top = 16
      Width = 387
      Height = 13
      Alignment = taCenter
      AutoSize = False
      Caption = 'T'#201'RMINO DO PROCESSAMENTO !!!'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clRed
      Font.Height = -13
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
    end
  end
  object qryGeral: TQuery
    DatabaseName = 'dbMain'
    Left = 24
    Top = 48
  end
  object qryAtualiza: TQuery
    DatabaseName = 'dbMain'
    Left = 56
    Top = 48
  end
  object qryBuscaServFaturado: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select  '#9'sr_matricula as matricula,'
      #9'sr_grupo as grupo,'
      #9'sr_referencia as referencia, '
      #9'convert(char(7), sr_referencia, 102) as refBusca,'
      
        #9'convert(numeric, '#39'1'#39'+OnPlaceSANED.dbo.fc_completa_zeros(cg_grup' +
        'o, 3)+OnPlaceSANED.dbo.fc_completa_zeros(cg_rota,3)) as roteiro,' +
        ' '
      
        #9'OnPlaceSANED_Movimento.dbo.fc_busca_servico(ltrim(rtrim(sr_desc' +
        'ricao))) as Servico, case when sr_ind_credito = '#39'S'#39' then -1 else' +
        ' 1 end * sr_valor as Valor'
      'from    OnPlaceSANED..servicos, OnPlaceSANED..carga'
      'where'#9'cg_matricula = sr_matricula'
      'and'#9'cg_referencia = sr_referencia'
      'and'#9'cg_grupo = sr_grupo'
      'and'#9'cg_grupo = :parGrupo'
      'and'#9'sr_valor > 0')
    Left = 200
    Top = 48
    ParamData = <
      item
        DataType = ftInteger
        Name = 'parGrupo'
        ParamType = ptUnknown
      end>
    object qryBuscaServFaturadomatricula: TIntegerField
      FieldName = 'matricula'
    end
    object qryBuscaServFaturadogrupo: TIntegerField
      FieldName = 'grupo'
    end
    object qryBuscaServFaturadoreferencia: TDateTimeField
      FieldName = 'referencia'
    end
    object qryBuscaServFaturadorefBusca: TStringField
      FieldName = 'refBusca'
      FixedChar = True
      Size = 7
    end
    object qryBuscaServFaturadoroteiro: TFloatField
      FieldName = 'roteiro'
    end
    object qryBuscaServFaturadoServico: TIntegerField
      FieldName = 'Servico'
    end
    object qryBuscaServFaturadoValor: TFloatField
      FieldName = 'Valor'
    end
  end
  object QryBuscaLogradouro: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select '#9'distinct ltrim(rtrim(cg_endereco)) as Texto'
      'from    '#9'OnPlaceSANED..carga'
      'where'#9'cg_grupo = :parGrupo'
      'and'#9'not exists '
      #9'(select 1 '
      #9'from '#9'OnPlaceSANED_movimento..ACQ_LOGRADOURO'
      
        #9'where'#9'ltrim(rtrim(cg_endereco)) = ltrim(rtrim(des_logradouro)))' +
        ' ')
    Left = 104
    Top = 48
    ParamData = <
      item
        DataType = ftInteger
        Name = 'parGrupo'
        ParamType = ptUnknown
      end>
    object QryBuscaLogradouroTexto: TStringField
      FieldName = 'Texto'
      Size = 48
    end
  end
  object QryBuscaServico: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select  distinct ltrim(rtrim(sr_descricao)) as Servico'
      'from    OnPlaceSANED..servicos')
    Left = 136
    Top = 48
    object QryBuscaServicoServico: TStringField
      FieldName = 'Servico'
      Size = 35
    end
  end
  object qryBuscaMovimento: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      #9#9'select'#9'cg_matricula, '
      
        #9#9#9'convert(numeric, '#39'1'#39' + OnPlaceSANED.dbo.fc_completa_zeros(cg_' +
        'grupo, 3) + OnPlaceSANED.dbo.fc_completa_zeros(cg_rota,3)) as ro' +
        'teiro, '
      #9#9#9'cg_referencia, '
      #9#9#9'cg_categoria, '
      #9#9#9'cg_economia_res, '
      #9#9#9'cg_economia_com, '
      #9#9#9'cg_economia_ind, '
      #9#9#9'cg_economia_pub, '
      #9#9#9'cg_economia_soc, '
      #9#9#9'cg_economia_ea, '
      #9#9#9'case '#9'when isnull(cg_bloqueado, '#39'L'#39') not in ('#39'L'#39', '#39#39') then'
      #9#9#9#9#9'case '#9'when cg_natureza_ligacao in (1, 2) then 3 '
      #9#9#9#9#9#9'else 4 '
      #9#9#9#9#9'end'
      #9#9#9#9'when cg_natureza_ligacao in (1, 2) then 1 '
      #9#9#9#9'else 4 '
      #9#9#9'end as ct_lig_agua, '
      #9#9#9'case '#9'when isnull(cg_bloqueado, '#39'L'#39') not in ('#39'L'#39', '#39#39') then'
      #9#9#9#9#9'case '#9'when cg_natureza_ligacao in (2, 3) then 3 '
      #9#9#9#9#9#9'else 4 '
      #9#9#9#9#9'end'
      #9#9#9#9'when cg_natureza_ligacao in (2, 3) then 1 '
      #9#9#9#9'else 4 '
      #9#9#9'end as ct_lig_esg,'
      #9#9#9'case '#9'when ltrim(rtrim(isnull(cg_numero_hd,'#39#39'))) = '#39#39' then'
      #9#9#9' '#9'10'
      #9#9#9#9'else null'
      #9#9#9'end as ct_consumo_fixo   '
      #9#9'from'#9'OnPlaceSANED..carga'
      #9#9'left'#9'outer join OnPlaceSANED_movimento..ACQ_CATEGORIA'
      #9#9'on'#9'cg_categoria = seq_categoria'
      #9#9'where'#9'cg_grupo = :parGrupo')
    Left = 168
    Top = 48
    ParamData = <
      item
        DataType = ftInteger
        Name = 'parGrupo'
        ParamType = ptUnknown
      end>
    object qryBuscaMovimentocg_matricula: TIntegerField
      FieldName = 'cg_matricula'
    end
    object qryBuscaMovimentoroteiro: TFloatField
      FieldName = 'roteiro'
    end
    object qryBuscaMovimentocg_referencia: TDateTimeField
      FieldName = 'cg_referencia'
    end
    object qryBuscaMovimentocg_categoria: TIntegerField
      FieldName = 'cg_categoria'
    end
    object qryBuscaMovimentocg_economia_res: TIntegerField
      FieldName = 'cg_economia_res'
    end
    object qryBuscaMovimentocg_economia_com: TIntegerField
      FieldName = 'cg_economia_com'
    end
    object qryBuscaMovimentocg_economia_ind: TIntegerField
      FieldName = 'cg_economia_ind'
    end
    object qryBuscaMovimentocg_economia_pub: TIntegerField
      FieldName = 'cg_economia_pub'
    end
    object qryBuscaMovimentocg_economia_soc: TIntegerField
      FieldName = 'cg_economia_soc'
    end
    object qryBuscaMovimentocg_economia_ea: TIntegerField
      FieldName = 'cg_economia_ea'
    end
    object qryBuscaMovimentoct_lig_agua: TIntegerField
      FieldName = 'ct_lig_agua'
    end
    object qryBuscaMovimentoct_lig_esg: TIntegerField
      FieldName = 'ct_lig_esg'
    end
    object qryBuscaMovimentoct_consumo_fixo: TIntegerField
      FieldName = 'ct_consumo_fixo'
    end
  end
  object qryProximoMovimentoItem: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select  isnull(max(isnull(seq_item_servico,0)),0)+1 as Valor'
      'from    OnPlaceSANED_movimento..ACQ_MOVIMENTO_SERVICO'
      'where  cod_referencia = :sReferencia'
      'and    seq_roteiro    = :nRoteiro'
      'and    seq_matricula  = :nMatricula')
    Left = 504
    Top = 112
    ParamData = <
      item
        DataType = ftString
        Name = 'sReferencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nRoteiro'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nMatricula'
        ParamType = ptUnknown
      end>
    object qryProximoMovimentoItemValor: TFloatField
      FieldName = 'Valor'
    end
  end
  object qryProximoServicoParcela: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      
        'select'#9'isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1 ' +
        'as Valor'
      'from'#9'OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA'
      'where'#9'seq_matricula = :nMatricula')
    Left = 472
    Top = 112
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nMatricula'
        ParamType = ptUnknown
      end>
    object qryProximoServicoParcelaValor: TFloatField
      FieldName = 'Valor'
    end
  end
  object qryInsMatServParcela: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      
        'INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCEL' +
        'A'
      
        #9#9'( seq_matricula, seq_matricula_servico_parcela, seq_item_servi' +
        'co_fatura, '
      #9#9'  seq_servico_fatura, cod_referencia, seq_roteiro, '
      #9#9'  val_valor_parcela, ind_status, ind_documento_origem)'
      'values'#9'(:nMatricula, :nSeqServParcela, :nInd,'
      #9#9' :nServico, :sReferencia, :nRoteiro,'
      #9#9' :nValor, '#39'A'#39', '#39'01'#39')')
    Left = 440
    Top = 48
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nMatricula'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nSeqServParcela'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nInd'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nServico'
        ParamType = ptUnknown
      end
      item
        DataType = ftString
        Name = 'sReferencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nRoteiro'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nValor'
        ParamType = ptUnknown
      end>
  end
  object qryInsMovimentoServico: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_SERVICO'
      
        #9'(seq_matricula, seq_matricula_servico_parcela, seq_item_servico' +
        ', '
      
        #9' cod_referencia, seq_roteiro, ind_documento_origem, val_valor_s' +
        'ervico )'
      'values'#9'(:nMatricula, :nSeqServParcela, :nSeqItemServico,'
      '    '#9' :sReferencia, :nRoteiro, '#39'01'#39', :nValor)')
    Left = 472
    Top = 48
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nMatricula'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nSeqServParcela'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nSeqItemServico'
        ParamType = ptUnknown
      end
      item
        DataType = ftString
        Name = 'sReferencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nRoteiro'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nValor'
        ParamType = ptUnknown
      end>
  end
  object qryBuscaAviso: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select  db_matricula, db_grupo, db_referencia, '
      #9#9'db_data_vencimento, db_qtde_debitos, db_valor_total, '
      
        #9#9'convert(numeric, '#39'1'#39'+OnPlaceSANED.dbo.fc_completa_zeros(cg_gru' +
        'po, 3)+OnPlaceSANED.dbo.fc_completa_zeros(cg_rota,3)) as roteiro' +
        ' ,'
      #9#9'db_codigo_barras,'
      
        #9#9'OnPlaceSANED_Movimento.dbo.FC_CODIGO_BARRAS_CONTROLE(db_codigo' +
        '_barras) as BarraLinha,'
      #9#9'isnull(db_tipo,'#39'N'#39') as Tipo,'
      
        #9#9'OnPlaceSANED_movimento.dbo.fc_busca_servico('#39'NOTIFICACAO DE DE' +
        'BITO'#39') as Servico'
      'FROM '#9'OnPlaceSANED.dbo.debitos, OnPlaceSANED..carga'
      'where'#9'cg_matricula = db_matricula '
      'and'#9#9'cg_referencia = db_referencia'
      'and'#9#9'cg_grupo = db_grupo'
      'and'#9#9'cg_grupo = :parGrupo'
      'order'#9'by db_matricula, db_data_vencimento ')
    Left = 232
    Top = 48
    ParamData = <
      item
        DataType = ftInteger
        Name = 'parGrupo'
        ParamType = ptUnknown
      end>
    object qryBuscaAvisodb_matricula: TIntegerField
      FieldName = 'db_matricula'
    end
    object qryBuscaAvisodb_grupo: TIntegerField
      FieldName = 'db_grupo'
    end
    object qryBuscaAvisodb_referencia: TDateTimeField
      FieldName = 'db_referencia'
    end
    object qryBuscaAvisodb_data_vencimento: TDateTimeField
      FieldName = 'db_data_vencimento'
    end
    object qryBuscaAvisodb_qtde_debitos: TIntegerField
      FieldName = 'db_qtde_debitos'
    end
    object qryBuscaAvisodb_valor_total: TFloatField
      FieldName = 'db_valor_total'
    end
    object qryBuscaAvisoroteiro: TFloatField
      FieldName = 'roteiro'
    end
    object qryBuscaAvisodb_codigo_barras: TStringField
      FieldName = 'db_codigo_barras'
      Size = 48
    end
    object qryBuscaAvisoBarraLinha: TStringField
      FieldName = 'BarraLinha'
      Size = 50
    end
    object qryBuscaAvisoTipo: TStringField
      FieldName = 'Tipo'
      Size = 1
    end
    object qryBuscaAvisoServico: TIntegerField
      FieldName = 'Servico'
    end
  end
  object qryBuscaAvisoItem: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select '#9'di_referencia_debito, di_valor'
      'FROM '#9'OnPlaceSANED.dbo.debitos_itens'
      'where '#9'di_grupo = :nGrupo'
      'and '#9'di_matricula = :nMatricula'
      'and '#9'di_referencia = :dtReferencia'
      'and'#9'di_referencia_debito is not null'
      'and'#9'di_valor > 0'
      'order'#9'by di_sequencia')
    Left = 264
    Top = 48
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nMatricula'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'dtReferencia'
        ParamType = ptUnknown
      end>
    object qryBuscaAvisoItemdi_referencia_debito: TDateTimeField
      FieldName = 'di_referencia_debito'
    end
    object qryBuscaAvisoItemdi_valor: TFloatField
      FieldName = 'di_valor'
    end
  end
  object qryBuscaProcCorte: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'#9'isnull(max(seq_processo_corte),0)+1 as Valor'
      'from'#9'OnPlaceSANED_movimento..ACQ_PROCESSO_CORTE')
    Left = 296
    Top = 48
    object qryBuscaProcCorteValor: TFloatField
      FieldName = 'Valor'
    end
  end
  object qryBuscaProxAviso: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'exec OnPlaceSANED_movimento..sp_incrementa_controle_contador 2')
    Left = 472
    Top = 144
    object qryBuscaProxAvisoProximo: TFloatField
      FieldName = 'Proximo'
    end
  end
  object qryBuscaProxFatura: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'exec OnPlaceSANED_movimento..sp_incrementa_controle_contador 1')
    Left = 504
    Top = 144
    object qryBuscaProxFaturaProximo: TFloatField
      FieldName = 'Proximo'
    end
  end
  object qryInsFaturaAviso: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA'
      
        #9'(dat_leitura, cod_referencia, dat_vencimento, val_valor_faturad' +
        'o, '
      #9'seq_fatura, seq_roteiro,'
      #9'seq_matricula, ind_fatura_emitida, ind_status, '
      #9'des_codigo_barras, des_linha_digitavel,'
      #9'ind_tipo_documento_origem, des_documento_origem )'
      
        'values'#9'(convert(datetime, '#39'19740506'#39'), convert(char(7), convert(' +
        'datetime, '#39'19740506'#39'), 102), :dtVencimento, :nValorTotal, '
      #9':nSeq_Fatura, :nRoteiro,'
      #9':nMatricula, '#39'N'#39', '#39'RE'#39',  '
      #9':sCodigoBarras , :sBarrasLinha,'
      #9'4, convert(varchar, :nSeq_Aviso) )')
    Left = 536
    Top = 48
    ParamData = <
      item
        DataType = ftDateTime
        Name = 'dtVencimento'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nValorTotal'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nSeq_Fatura'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nRoteiro'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nMatricula'
        ParamType = ptUnknown
      end
      item
        DataType = ftString
        Name = 'sCodigoBarras'
        ParamType = ptUnknown
      end
      item
        DataType = ftString
        Name = 'sBarrasLinha'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nSeq_Aviso'
        ParamType = ptUnknown
      end>
  end
  object qryInsAviso: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'INSERT INTO OnPlaceSANED_movimento..ACQ_AVISO'
      
        #9#9'(seq_aviso, seq_matricula, seq_politica_corte, seq_processo_co' +
        'rte,'
      #9#9'seq_fatura, dat_geracao_aviso, '
      #9#9'val_quantidade_debito, val_valor_debito, ind_confirma_entrega,'
      #9#9'ind_documento)'
      'values'#9'(:nSeq_Aviso, :nMatricula, 1, :nProcessoCorte,'
      
        #9#9':nSeq_Fatura, convert(datetime, convert(char(8), getdate(), 11' +
        '2)), '
      #9#9':nQtdeDebito, :nValorTotal, '#39'N'#39', '
      #9#9':sTipo)')
    Left = 472
    Top = 80
    ParamData = <
      item
        DataType = ftFloat
        Name = 'nSeq_Aviso'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nMatricula'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nProcessoCorte'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nSeq_Fatura'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nQtdeDebito'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nValorTotal'
        ParamType = ptUnknown
      end
      item
        DataType = ftString
        Name = 'sTipo'
        ParamType = ptUnknown
      end>
  end
  object qryInsFaturaAvisoItem: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA'
      
        #9'(dat_leitura, cod_referencia, dat_vencimento, val_valor_faturad' +
        'o, '
      #9'seq_fatura, seq_roteiro,'
      #9'seq_matricula, ind_fatura_emitida, ind_status )'
      
        'values'#9'(:dtReferencia, convert(char(7), :dtReferencia, 102), :dt' +
        'Vencimento, :nValorTotal, '
      #9':nSeq_Fatura, :nRoteiro,'
      #9':nMatricula, '#39'N'#39', '#39'RE'#39')')
    Left = 504
    Top = 48
    ParamData = <
      item
        DataType = ftDateTime
        Name = 'dtReferencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'dtReferencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'dtVencimento'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nValorTotal'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nSeq_Fatura'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nRoteiro'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nMatricula'
        ParamType = ptUnknown
      end>
  end
  object qryBuscaFaturaServico: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'#9'isnull(max(isnull(seq_item_servico,0)),0)+1 as Valor'
      'from'#9'OnPlaceSANED_movimento..ACQ_FATURA_SERVICO'
      'where'#9'seq_fatura = :nSeq_Fatura')
    Left = 328
    Top = 48
    ParamData = <
      item
        DataType = ftFloat
        Name = 'nSeq_Fatura'
        ParamType = ptUnknown
      end>
    object qryBuscaFaturaServicoValor: TFloatField
      FieldName = 'Valor'
    end
  end
  object qryInsFaturaServico: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_SERVICO'
      
        #9#9'(seq_fatura, seq_matricula_servico_parcela, seq_item_servico, ' +
        'seq_parcela, ind_documento_origem, val_valor_servico)'
      
        'Values'#9'(:nSeq_Fatura, :nSeqServicoParcela, :SeqItemServico, 1, '#39 +
        '01'#39', :nValorItem)')
    Left = 504
    Top = 80
    ParamData = <
      item
        DataType = ftFloat
        Name = 'nSeq_Fatura'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nSeqServicoParcela'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'SeqItemServico'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nValorItem'
        ParamType = ptUnknown
      end>
  end
  object qryBuscaSegundaVias: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select  sv_matricula , sv_referencia , sv_data_vencimento ,'
      #9'sv_grupo , '
      
        #9'convert(numeric, '#39'1'#39'+OnPlaceSANED.dbo.fc_completa_zeros(cg_grup' +
        'o, 3)+OnPlaceSANED.dbo.fc_completa_zeros(cg_rota,3)) as roteiro,' +
        ' '
      #9'sv_referencia_seg_via ,'
      #9'sv_leitura_anterior , sv_leitura_atual,'
      #9'sv_data_leitura_anterior, sv_data_leitura,'
      #9'sv_consumo_faturado, sv_media, cg_categoria, '
      #9'cg_economia_res, cg_economia_com, cg_economia_ind, '
      #9'cg_economia_pub, cg_economia_soc, cg_economia_ea, '
      #9'case when ('#9'case when cg_economia_res > 0 then 1 else 0 end +'
      #9#9#9'case when cg_economia_com > 0 then 1 else 0 end +'
      #9#9#9'case when cg_economia_ind > 0 then 1 else 0 end +'
      #9#9#9'case when cg_economia_pub > 0 then 1 else 0 end +'
      #9#9#9'case when cg_economia_soc > 0 then 1 else 0 end +'
      #9#9#9'case when cg_economia_ea > 0 then 1 else 0 end) >= 2'
      #9#9'then 1 else 0 end as sv_ind_mista,'
      #9'sv_servico_01 , sv_valor_01 ,'
      #9'sv_servico_02 , sv_valor_02 ,'
      #9'sv_servico_03 , sv_valor_03 ,'
      #9'sv_servico_04 , sv_valor_04 ,'
      #9'sv_servico_05 , sv_valor_05 ,'
      #9'sv_servico_06 , sv_valor_06 ,'
      #9'sv_servico_07 , sv_valor_07 ,'
      #9'sv_servico_08 , sv_valor_08 ,'
      #9'sv_servico_09 , sv_valor_09 ,'
      #9'sv_ref_cons_1 , sv_cons_1 ,'
      #9'sv_ref_cons_2 , sv_Cons_2 ,'
      #9'sv_ref_cons_3 , sv_Cons_3 ,'
      #9'sv_ref_cons_4 , sv_Cons_4 ,'
      #9'sv_ref_cons_5 , sv_Cons_5 ,'
      #9'sv_ref_cons_6 , sv_Cons_6 ,'
      #9'sv_valor_total,'
      #9'sv_codigo_barras,'
      
        #9'OnPlaceSANED_Movimento.dbo.FC_CODIGO_BARRAS_CONTROLE(sv_codigo_' +
        'barras) as BarraLinha,'
      #9'cg_numero_hd'
      'FROM '#9'OnPlaceSANED..segundas_vias, OnPlaceSANED..carga'
      'where'#9'cg_matricula = sv_matricula'
      'and'#9'cg_referencia = sv_referencia'
      'and'#9'cg_grupo = sv_grupo'
      'and'#9'cg_grupo = :parGrupo')
    Left = 360
    Top = 48
    ParamData = <
      item
        DataType = ftInteger
        Name = 'parGrupo'
        ParamType = ptUnknown
      end>
    object qryBuscaSegundaViassv_matricula: TIntegerField
      FieldName = 'sv_matricula'
    end
    object qryBuscaSegundaViassv_referencia: TDateTimeField
      FieldName = 'sv_referencia'
    end
    object qryBuscaSegundaViassv_data_vencimento: TDateTimeField
      FieldName = 'sv_data_vencimento'
    end
    object qryBuscaSegundaViassv_grupo: TIntegerField
      FieldName = 'sv_grupo'
    end
    object qryBuscaSegundaViasroteiro: TFloatField
      FieldName = 'roteiro'
    end
    object qryBuscaSegundaViassv_referencia_seg_via: TDateTimeField
      FieldName = 'sv_referencia_seg_via'
    end
    object qryBuscaSegundaViassv_leitura_anterior: TIntegerField
      FieldName = 'sv_leitura_anterior'
    end
    object qryBuscaSegundaViassv_leitura_atual: TIntegerField
      FieldName = 'sv_leitura_atual'
    end
    object qryBuscaSegundaViassv_data_leitura_anterior: TDateTimeField
      FieldName = 'sv_data_leitura_anterior'
    end
    object qryBuscaSegundaViassv_data_leitura: TDateTimeField
      FieldName = 'sv_data_leitura'
    end
    object qryBuscaSegundaViassv_consumo_faturado: TIntegerField
      FieldName = 'sv_consumo_faturado'
    end
    object qryBuscaSegundaViassv_media: TIntegerField
      FieldName = 'sv_media'
    end
    object qryBuscaSegundaViascg_categoria: TIntegerField
      FieldName = 'cg_categoria'
    end
    object qryBuscaSegundaViascg_economia_res: TIntegerField
      FieldName = 'cg_economia_res'
    end
    object qryBuscaSegundaViascg_economia_com: TIntegerField
      FieldName = 'cg_economia_com'
    end
    object qryBuscaSegundaViascg_economia_ind: TIntegerField
      FieldName = 'cg_economia_ind'
    end
    object qryBuscaSegundaViascg_economia_pub: TIntegerField
      FieldName = 'cg_economia_pub'
    end
    object qryBuscaSegundaViascg_economia_soc: TIntegerField
      FieldName = 'cg_economia_soc'
    end
    object qryBuscaSegundaViascg_economia_ea: TIntegerField
      FieldName = 'cg_economia_ea'
    end
    object qryBuscaSegundaViassv_ind_mista: TIntegerField
      FieldName = 'sv_ind_mista'
    end
    object qryBuscaSegundaViassv_servico_01: TStringField
      FieldName = 'sv_servico_01'
      Size = 35
    end
    object qryBuscaSegundaViassv_valor_01: TFloatField
      FieldName = 'sv_valor_01'
    end
    object qryBuscaSegundaViassv_servico_02: TStringField
      FieldName = 'sv_servico_02'
      Size = 35
    end
    object qryBuscaSegundaViassv_valor_02: TFloatField
      FieldName = 'sv_valor_02'
    end
    object qryBuscaSegundaViassv_servico_03: TStringField
      FieldName = 'sv_servico_03'
      Size = 35
    end
    object qryBuscaSegundaViassv_valor_03: TFloatField
      FieldName = 'sv_valor_03'
    end
    object qryBuscaSegundaViassv_servico_04: TStringField
      FieldName = 'sv_servico_04'
      Size = 35
    end
    object qryBuscaSegundaViassv_valor_04: TFloatField
      FieldName = 'sv_valor_04'
    end
    object qryBuscaSegundaViassv_servico_05: TStringField
      FieldName = 'sv_servico_05'
      Size = 35
    end
    object qryBuscaSegundaViassv_valor_05: TFloatField
      FieldName = 'sv_valor_05'
    end
    object qryBuscaSegundaViassv_servico_06: TStringField
      FieldName = 'sv_servico_06'
      Size = 35
    end
    object qryBuscaSegundaViassv_valor_06: TFloatField
      FieldName = 'sv_valor_06'
    end
    object qryBuscaSegundaViassv_servico_07: TStringField
      FieldName = 'sv_servico_07'
      Size = 35
    end
    object qryBuscaSegundaViassv_valor_07: TFloatField
      FieldName = 'sv_valor_07'
    end
    object qryBuscaSegundaViassv_servico_08: TStringField
      FieldName = 'sv_servico_08'
      Size = 35
    end
    object qryBuscaSegundaViassv_valor_08: TFloatField
      FieldName = 'sv_valor_08'
    end
    object qryBuscaSegundaViassv_servico_09: TStringField
      FieldName = 'sv_servico_09'
      Size = 35
    end
    object qryBuscaSegundaViassv_valor_09: TFloatField
      FieldName = 'sv_valor_09'
    end
    object qryBuscaSegundaViassv_ref_cons_1: TDateTimeField
      FieldName = 'sv_ref_cons_1'
    end
    object qryBuscaSegundaViassv_cons_1: TIntegerField
      FieldName = 'sv_cons_1'
    end
    object qryBuscaSegundaViassv_ref_cons_2: TDateTimeField
      FieldName = 'sv_ref_cons_2'
    end
    object qryBuscaSegundaViassv_Cons_2: TIntegerField
      FieldName = 'sv_Cons_2'
    end
    object qryBuscaSegundaViassv_ref_cons_3: TDateTimeField
      FieldName = 'sv_ref_cons_3'
    end
    object qryBuscaSegundaViassv_Cons_3: TIntegerField
      FieldName = 'sv_Cons_3'
    end
    object qryBuscaSegundaViassv_ref_cons_4: TDateTimeField
      FieldName = 'sv_ref_cons_4'
    end
    object qryBuscaSegundaViassv_Cons_4: TIntegerField
      FieldName = 'sv_Cons_4'
    end
    object qryBuscaSegundaViassv_ref_cons_5: TDateTimeField
      FieldName = 'sv_ref_cons_5'
    end
    object qryBuscaSegundaViassv_Cons_5: TIntegerField
      FieldName = 'sv_Cons_5'
    end
    object qryBuscaSegundaViassv_ref_cons_6: TDateTimeField
      FieldName = 'sv_ref_cons_6'
    end
    object qryBuscaSegundaViassv_Cons_6: TIntegerField
      FieldName = 'sv_Cons_6'
    end
    object qryBuscaSegundaViassv_valor_total: TFloatField
      FieldName = 'sv_valor_total'
    end
    object qryBuscaSegundaViassv_codigo_barras: TStringField
      FieldName = 'sv_codigo_barras'
      Size = 48
    end
    object qryBuscaSegundaViasBarraLinha: TStringField
      FieldName = 'BarraLinha'
      Size = 50
    end
    object qryBuscaSegundaViascg_numero_hd: TStringField
      FieldName = 'cg_numero_hd'
      Size = 11
    end
  end
  object qryInsFaturaSV: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA'
      #9'(dat_leitura, dat_leitura_proxima, '
      #9' cod_referencia, dat_vencimento, val_valor_faturado, '
      #9' seq_fatura, seq_roteiro,'
      #9' seq_matricula, ind_fatura_emitida, ind_status,'
      #9' dat_leitura_anterior, '
      #9' val_leitura_real, val_leitura_anterior, '
      #9' val_consumo_medido, val_consumo_medio,'
      #9' seq_tipo_entrega, des_codigo_barras, des_linha_digitavel )'
      'values'#9'(:dtLeitura, :dtProximaLeit,'
      
        #9' convert(char(7), :dtRef_2via, 102), :dtVencimento, :nValorTota' +
        'l, '
      #9' :nSeq_Fatura, :nRoteiro,'
      #9' :nMatricula, '#39'N'#39', '#39'PE'#39','
      #9' :dtLeituraAnterior , '
      #9' :nLeituraAtual, :nLeituraAnt, '
      #9' :nConsumo, :nMedia, '
      #9' null,  :sCodigoBarras , :sBarrasLinha )')
    Left = 536
    Top = 80
    ParamData = <
      item
        DataType = ftDateTime
        Name = 'dtLeitura'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'dtProximaLeit'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'dtRef_2via'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'dtVencimento'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nValorTotal'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nSeq_Fatura'
        ParamType = ptUnknown
      end
      item
        DataType = ftFloat
        Name = 'nRoteiro'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nMatricula'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'dtLeituraAnterior'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nLeituraAtual'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nLeituraAnt'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nConsumo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nMedia'
        ParamType = ptUnknown
      end
      item
        DataType = ftString
        Name = 'sCodigoBarras'
        ParamType = ptUnknown
      end
      item
        DataType = ftString
        Name = 'sBarrasLinha'
        ParamType = ptUnknown
      end>
  end
  object qryBuscaCodServico: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      
        'exec '#9'OnPlaceSANED_movimento..sp_atualiza_servico :sDescricaoTex' +
        'to'
      #9
      
        'select'#9'OnPlaceSANED_movimento.dbo.fc_busca_servico(:sDescricaoTe' +
        'xto) as Valor')
    Left = 400
    Top = 48
    ParamData = <
      item
        DataType = ftString
        Name = 'sDescricaoTexto'
        ParamType = ptUnknown
      end
      item
        DataType = ftString
        Name = 'sDescricaoTexto'
        ParamType = ptUnknown
      end>
    object qryBuscaCodServicoValor: TIntegerField
      FieldName = 'Valor'
    end
  end
end
