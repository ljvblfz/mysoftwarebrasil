object frmAlteraMovimento: TfrmAlteraMovimento
  Left = 0
  Top = 0
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  ClientHeight = 418
  ClientWidth = 680
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  FormStyle = fsMDIChild
  OldCreateOrder = False
  Position = poDesktopCenter
  Visible = True
  OnClose = FormClose
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object grbRoteiro: TGroupBox
    Left = 8
    Top = 94
    Width = 417
    Height = 275
    Caption = 'Roteiros'
    TabOrder = 4
  end
  object pTop: TPanel
    Left = 0
    Top = 0
    Width = 680
    Height = 40
    Align = alTop
    BevelInner = bvRaised
    BorderStyle = bsSingle
    Caption = 'Indicativos de Movimenta'#231#227'o on-line'
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
      Left = 605
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
  object DBGRoteiros: TDBGrid
    Left = 21
    Top = 111
    Width = 393
    Height = 251
    Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgRowSelect, dgAlwaysShowSelection, dgConfirmDelete, dgCancelOnExit]
    TabOrder = 1
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    Columns = <
      item
        Alignment = taCenter
        Expanded = False
        FieldName = ' roteiro'
        ReadOnly = True
        Title.Alignment = taCenter
        Title.Caption = 'Roteiro'
        Width = 90
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'ind_enviado'
        Title.Alignment = taCenter
        Title.Caption = 'Enviado'
        Width = 75
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'ind_obtido'
        Title.Alignment = taCenter
        Title.Caption = 'Retorno'
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'ind_validado'
        Title.Alignment = taCenter
        Title.Caption = 'Validado'
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'ind_processado'
        Title.Alignment = taCenter
        Title.Caption = 'Processado'
        Visible = True
      end>
  end
  object GroupBox2: TGroupBox
    Left = 431
    Top = 95
    Width = 242
    Height = 274
    Caption = 'Edi'#231#227'o'
    TabOrder = 2
    object Label16: TLabel
      Left = 21
      Top = 17
      Width = 39
      Height = 13
      Caption = 'Roteiro:'
    end
    object EdVariacao: TEdit
      Left = 105
      Top = 14
      Width = 89
      Height = 21
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clRed
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      ReadOnly = True
      TabOrder = 0
    end
    object GroupBox1: TGroupBox
      Left = 10
      Top = 41
      Width = 215
      Height = 45
      Caption = 'Enviado ao Psion'
      TabOrder = 1
      object rbtEnviadoPsion: TRadioButton
        Left = 16
        Top = 19
        Width = 49
        Height = 17
        Caption = 'Sim'
        TabOrder = 0
      end
      object rbtNaoEnviadoPsion: TRadioButton
        Left = 112
        Top = 19
        Width = 49
        Height = 17
        Caption = 'N'#227'o'
        TabOrder = 1
      end
    end
    object RetornoPsion: TRadioGroup
      Left = 10
      Top = 93
      Width = 215
      Height = 45
      Caption = 'Retorno do Psion'
      TabOrder = 2
    end
    object rbtRetornoPsion: TRadioButton
      Left = 30
      Top = 112
      Width = 48
      Height = 17
      Caption = 'Sim '
      TabOrder = 3
    end
    object rbtNaoRetornoPsion: TRadioButton
      Left = 122
      Top = 112
      Width = 49
      Height = 17
      Caption = 'N'#227'o'
      TabOrder = 4
    end
    object GroupBox3: TGroupBox
      Left = 10
      Top = 144
      Width = 215
      Height = 45
      Caption = 'Valida'#231#227'o'
      TabOrder = 5
      object rbtValidado: TRadioButton
        Left = 16
        Top = 19
        Width = 49
        Height = 17
        Caption = 'Sim'
        TabOrder = 0
      end
      object rbtNaoValidado: TRadioButton
        Left = 112
        Top = 19
        Width = 49
        Height = 17
        Caption = 'N'#227'o'
        TabOrder = 1
      end
    end
    object RadioGroup1: TRadioGroup
      Left = 10
      Top = 205
      Width = 215
      Height = 45
      Caption = 'Processamento'
      TabOrder = 6
    end
    object rbtProcessado: TRadioButton
      Left = 30
      Top = 220
      Width = 51
      Height = 17
      Caption = 'Sim'
      TabOrder = 7
    end
    object rbtNaoProcessado: TRadioButton
      Left = 122
      Top = 220
      Width = 80
      Height = 17
      Caption = 'N'#227'o'
      TabOrder = 8
    end
  end
  object pBottom: TPanel
    Left = 0
    Top = 378
    Width = 680
    Height = 40
    Align = alBottom
    Ctl3D = False
    ParentCtl3D = False
    TabOrder = 3
    DesignSize = (
      680
      40)
    object sbtnSair: TSpeedButton
      Left = 594
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
      ExplicitLeft = 437
    end
    object sbtnAlterar: TSpeedButton
      Left = 12
      Top = 7
      Width = 80
      Height = 25
      Anchors = [akTop, akRight, akBottom]
      Caption = '&Altera'
      Flat = True
      Glyph.Data = {
        76010000424D7601000000000000760000002800000020000000100000000100
        0400000000000001000000000000000000001000000010000000000000000000
        800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00333333000000
        000033333377777777773333330FFFFFFFF03FF3FF7FF33F3FF700300000FF0F
        00F077F777773F737737E00BFBFB0FFFFFF07773333F7F3333F7E0BFBF000FFF
        F0F077F3337773F3F737E0FBFBFBF0F00FF077F3333FF7F77F37E0BFBF00000B
        0FF077F3337777737337E0FBFBFBFBF0FFF077F33FFFFFF73337E0BF0000000F
        FFF077FF777777733FF7000BFB00B0FF00F07773FF77373377373330000B0FFF
        FFF03337777373333FF7333330B0FFFF00003333373733FF777733330B0FF00F
        0FF03333737F37737F373330B00FFFFF0F033337F77F33337F733309030FFFFF
        00333377737FFFFF773333303300000003333337337777777333}
      NumGlyphs = 2
      Visible = False
      OnClick = sbtnAlterarClick
      ExplicitLeft = 10
    end
    object sbtnConfirma: TSpeedButton
      Left = 98
      Top = 6
      Width = 80
      Height = 25
      Anchors = [akTop, akRight, akBottom]
      Caption = '&Confirma'
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
      Visible = False
      OnClick = sbtnConfirmaClick
      ExplicitLeft = 96
    end
    object sbtnCancela: TSpeedButton
      Left = 184
      Top = 7
      Width = 80
      Height = 25
      Anchors = [akTop, akRight, akBottom]
      Caption = 'C&ancela'
      Flat = True
      Glyph.Data = {
        76010000424D7601000000000000760000002800000020000000100000000100
        04000000000000010000130B0000130B00001000000000000000000000000000
        800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00333333333333
        3333333333FFFFF3333333333999993333333333F77777FFF333333999999999
        3333333777333777FF3333993333339993333377FF3333377FF3399993333339
        993337777FF3333377F3393999333333993337F777FF333337FF993399933333
        399377F3777FF333377F993339993333399377F33777FF33377F993333999333
        399377F333777FF3377F993333399933399377F3333777FF377F993333339993
        399377FF3333777FF7733993333339993933373FF3333777F7F3399933333399
        99333773FF3333777733339993333339933333773FFFFFF77333333999999999
        3333333777333777333333333999993333333333377777333333}
      NumGlyphs = 2
      Visible = False
      OnClick = sbtnCancelaClick
      ExplicitLeft = 182
    end
  end
  object grbSelecao: TGroupBox
    Left = 8
    Top = 40
    Width = 665
    Height = 52
    Caption = 'Selecionar'
    TabOrder = 5
    object Label1: TLabel
      Left = 17
      Top = 24
      Width = 33
      Height = 13
      Caption = 'Grupo:'
    end
    object CBGrupo: TComboBox
      Left = 72
      Top = 21
      Width = 121
      Height = 21
      ItemHeight = 13
      TabOrder = 0
      OnDropDown = CBGrupoDropDown
    end
  end
  object QrGrupos: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'#9#9'RT_GRUPO'
      'from'#9#9'ROTEIROS'
      'where'#9#9'RT_IND_LEITURA in (2, 3, 4)'
      'group by '#9'RT_GRUPO'
      'order by '#9'RT_GRUPO')
    Left = 256
    Top = 53
    object QrGruposRT_GRUPO: TIntegerField
      FieldName = 'RT_GRUPO'
    end
  end
  object QrGrupoMovimento: TQuery
    DatabaseName = 'dbMainMovimento'
    SQL.Strings = (
      'select '#9'distinct fc.seq_roteiro, fc.cod_referencia,'
      #9'FC.ind_enviado,'
      #9'FC.ind_obtido, '
      #9'FC.ind_validado, '
      #9'FC.ind_processado,'
      #9'substring(convert(varchar, fc.seq_roteiro), 5, 3) as Roteiro'
      'from '#9'OnPlaceSaned_movimento..ACQ_GRUPO_FATURA_CRONOGRAMA FC,'
      #9'OnPlaceSaned_movimento..ACQ_GRUPO_REFERENCIA FT'
      'where'#9'FT.seq_grupo_fatura = :nGrupo'
      'and'#9'FT.cod_referencia = '
      #9'(select'#9'max(cod_referencia)'
      #9'from'#9'scs_movimento..ACQ_GRUPO_REFERENCIA'
      #9'where'#9'seq_grupo_fatura = :nGrupo)'
      'and'#9'FT.seq_roteiro = FC.seq_roteiro'
      'and'#9'FT.cod_referencia = FC.cod_referencia')
    Left = 320
    Top = 53
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end>
    object QrGrupoMovimentoseq_roteiro: TFloatField
      FieldName = 'seq_roteiro'
    end
    object QrGrupoMovimentocod_referencia: TStringField
      FieldName = 'cod_referencia'
      Size = 7
    end
    object QrGrupoMovimentoind_enviado: TStringField
      FieldName = 'ind_enviado'
      Size = 1
    end
    object QrGrupoMovimentoind_obtido: TStringField
      FieldName = 'ind_obtido'
      Size = 1
    end
    object QrGrupoMovimentoind_validado: TStringField
      FieldName = 'ind_validado'
      Size = 1
    end
    object QrGrupoMovimentoind_processado: TStringField
      FieldName = 'ind_processado'
      Size = 1
    end
    object QrGrupoMovimentoRoteiro: TStringField
      FieldName = 'Roteiro'
      Size = 3
    end
  end
  object Tabelas: TTable
    DatabaseName = 'dbMainMovimento'
    MasterSource = DSGrupoMoviemento
    TableName = 'OnPlaceSaned_movimento.dbo.ACQ_GRUPO_FATURA_CRONOGRAMA'
    Left = 392
    Top = 53
  end
  object DSGrupoMoviemento: TDataSource
    DataSet = QrGrupoMovimento
    Left = 352
    Top = 53
  end
  object DSTabelas: TDataSource
    DataSet = QrGrupoMovimento
    Left = 424
    Top = 53
  end
end
