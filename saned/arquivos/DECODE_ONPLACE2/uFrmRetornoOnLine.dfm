object frmRetornoOnLine: TfrmRetornoOnLine
  Left = 0
  Top = 0
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  ClientHeight = 394
  ClientWidth = 618
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
  object GroupBox1: TGroupBox
    Left = 0
    Top = 49
    Width = 185
    Height = 306
    Align = alLeft
    Caption = 'Selecionar'
    TabOrder = 0
    object Label3: TLabel
      Left = 10
      Top = 80
      Width = 33
      Height = 13
      Caption = 'Grupo:'
    end
    object Label4: TLabel
      Left = 10
      Top = 110
      Width = 56
      Height = 13
      Caption = 'Refer'#234'ncia:'
    end
    object CBGrupo: TComboBox
      Left = 75
      Top = 80
      Width = 96
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      TabOrder = 0
      OnClick = CBGrupoClick
      OnDropDown = CBGrupoDropDown
    end
    object MEReferencia: TMaskEdit
      Left = 75
      Top = 110
      Width = 61
      Height = 21
      Enabled = False
      EditMask = '99/0000;1;_'
      MaxLength = 7
      TabOrder = 1
      Text = '  /    '
    end
  end
  object Panel2: TPanel
    Left = 0
    Top = 355
    Width = 618
    Height = 39
    Align = alBottom
    TabOrder = 1
    object BitBtImportar: TSpeedButton
      Left = 20
      Top = 6
      Width = 145
      Height = 25
      Caption = '&Importar os arquivos'
      Enabled = False
      Flat = True
      Glyph.Data = {
        76010000424D7601000000000000760000002800000020000000100000000100
        04000000000000010000130B0000130B00001000000000000000000000000000
        800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00333333333303
        333333333333337FF3333333333333903333333333333377FF33333333333399
        03333FFFFFFFFF777FF3000000999999903377777777777777FF0FFFF0999999
        99037F3337777777777F0FFFF099999999907F3FF777777777770F00F0999999
        99037F773777777777730FFFF099999990337F3FF777777777330F00FFFFF099
        03337F773333377773330FFFFFFFF09033337F3FF3FFF77733330F00F0000003
        33337F773777777333330FFFF0FF033333337F3FF7F3733333330F08F0F03333
        33337F7737F7333333330FFFF003333333337FFFF77333333333000000333333
        3333777777333333333333333333333333333333333333333333}
      NumGlyphs = 2
      OnClick = BitBtImportarClick
    end
    object BitBtProcessar: TSpeedButton
      Left = 20
      Top = 6
      Width = 91
      Height = 25
      Caption = '&Processar'
      Enabled = False
      Flat = True
      Glyph.Data = {
        76010000424D7601000000000000760000002800000020000000100000000100
        0400000000000001000000000000000000001000000010000000000000000000
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
      OnClick = BitBtProcessarClick
    end
    object BitBtSair: TSpeedButton
      Left = 512
      Top = 6
      Width = 91
      Height = 25
      Caption = 'Sai&r'
      Flat = True
      Glyph.Data = {
        F6000000424DF600000000000000760000002800000010000000100000000100
        0400000000008000000000000000000000001000000010000000000000000000
        80000080000000808000800000008000800080800000C0C0C000808080000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00770000000000
        07777701BBBBBBBB077777011BBBBBBB0777770111BBBBBB07777701110BBBBB
        07777701110BBBBB07777701110BBBBB07777701110BBBBB07777701110BBBBB
        07777701110BBBBB0777770111B0BBBB07777701110BBBBB07777701110BBBBB
        07777701E10BBBBB07777701EE0BBBBB07777700000000000777}
      OnClick = BitBtSairClick
    end
    object chbImportarEAtualizar: TCheckBox
      Left = 171
      Top = 12
      Width = 294
      Height = 17
      Caption = 'Processa o retorno simultaneamente com a importa'#231#227'o.'
      TabOrder = 0
    end
  end
  object pTop: TPanel
    Left = 0
    Top = 0
    Width = 618
    Height = 49
    Align = alTop
    BevelInner = bvRaised
    BorderStyle = bsSingle
    Caption = 'RETORNO ON-LINE'
    Color = clNavy
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWhite
    Font.Height = -15
    Font.Name = 'Comic Sans MS'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 2
    object lVersion: TLabel
      Left = 466
      Top = 18
      Width = 137
      Height = 21
      Alignment = taRightJustify
      AutoSize = False
      Caption = 'Vers'#227'o 8.x'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWhite
      Font.Height = -12
      Font.Name = 'Comic Sans MS'
      Font.Style = [fsBold]
      ParentFont = False
    end
  end
  object PCDescarga: TPageControl
    Left = 191
    Top = 49
    Width = 427
    Height = 306
    ActivePage = TSArquivos
    Align = alRight
    TabOrder = 3
    OnChange = PCDescargaChange
    object TSOnLine: TTabSheet
      Caption = 'On-Line'
      object GBRoteiros: TGroupBox
        Left = 0
        Top = 0
        Width = 419
        Height = 201
        Align = alTop
        Caption = 'Roteiros'
        TabOrder = 0
        object sbAtualizaRoteiro: TSpeedButton
          Left = 238
          Top = 160
          Width = 32
          Height = 27
          Flat = True
          Glyph.Data = {
            36040000424D3604000000000000360000002800000010000000100000000100
            2000000000000004000000000000000000000000000000000000FF00FF00FF00
            FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00
            FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00
            FF00FF00FF00FF00FF00FF00FF000000FF000000FF000000FF000000FF000000
            FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00
            FF00FF00FF000000FF000000FF000000FF000000FF000000FF000000FF000000
            FF000000FF000000FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00
            FF000000FF000000FF000000FF00FF00FF007B7B7B00000000007B7B7B00FF00
            FF000000FF000000FF000000FF00FF00FF00FF00FF00FF00FF00FF00FF000000
            FF000000FF000000FF00FF00FF00FF00FF00000000000000000000000000FF00
            FF00FF00FF000000FF000000FF000000FF00FF00FF00FF00FF00FF00FF000000
            FF000000FF00FF00FF00FF00FF00FF00FF007B7B7B00000000007B7B7B00FF00
            FF00FF00FF00FF00FF000000FF000000FF00FF00FF00FF00FF000000FF000000
            FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00
            FF00FF00FF00FF00FF00FF00FF000000FF000000FF00FF00FF000000FF000000
            FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF0000000000FF00FF00FF00
            FF00FF00FF00FF00FF00FF00FF000000FF000000FF00FF00FF000000FF000000
            FF00FF00FF00FF00FF00FF00FF00FF00FF007B7B7B00000000007B7B7B00FF00
            FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF000000FF000000
            FF00FF00FF00FF00FF00FF00FF00FF00FF00000084000000000000008400FF00
            FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF000000FF000000
            FF00FF00FF00FF00FF00FF00FF00FF00FF00000000000000000000000000FF00
            FF000000FF000000FF000000FF000000FF000000FF00FF00FF00FF00FF000000
            FF000000FF00FF00FF00FF00FF00FF00FF00000000000000000000000000FF00
            FF00FF00FF000000FF000000FF000000FF000000FF00FF00FF00FF00FF000000
            FF000000FF000000FF00FF00FF00FF00FF00000000000000000000000000FF00
            FF00FF00FF00FF00FF000000FF000000FF000000FF00FF00FF00FF00FF00FF00
            FF000000FF000000FF000000FF00FF00FF007B7B7B00000000007B7B7B00FF00
            FF000000FF000000FF000000FF000000FF000000FF00FF00FF00FF00FF00FF00
            FF00FF00FF000000FF000000FF000000FF000000FF000000FF000000FF000000
            FF000000FF000000FF00FF00FF00FF00FF000000FF00FF00FF00FF00FF00FF00
            FF00FF00FF00FF00FF00FF00FF000000FF000000FF000000FF000000FF000000
            FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00}
        end
        object DBGRoteiros: TDBGrid
          Left = 11
          Top = 20
          Width = 221
          Height = 166
          DataSource = DsGrupoMovimento
          Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgRowSelect, dgAlwaysShowSelection]
          TabOrder = 0
          TitleFont.Charset = DEFAULT_CHARSET
          TitleFont.Color = clWindowText
          TitleFont.Height = -11
          TitleFont.Name = 'Tahoma'
          TitleFont.Style = []
          Columns = <
            item
              Alignment = taCenter
              Expanded = False
              FieldName = 'Roteiro'
              Title.Alignment = taCenter
              Width = 61
              Visible = True
            end
            item
              Alignment = taCenter
              Expanded = False
              FieldName = 'ind_obtido'
              Title.Alignment = taCenter
              Title.Caption = 'Retorno'
              Width = 61
              Visible = True
            end
            item
              Alignment = taCenter
              Expanded = False
              FieldName = 'ind_validado'
              Title.Alignment = taCenter
              Title.Caption = 'Validado'
              Width = 61
              Visible = True
            end>
        end
      end
      object PProcessamento: TPanel
        Left = 0
        Top = 206
        Width = 419
        Height = 72
        Align = alBottom
        TabOrder = 1
        Visible = False
        object LDescProc: TLabel
          Left = 11
          Top = 6
          Width = 397
          Height = 14
          AutoSize = False
          Caption = '     '
        end
        object ProgressBar1: TGauge
          Left = 11
          Top = 27
          Width = 397
          Height = 20
          ForeColor = clNavy
          Progress = 0
        end
        object LLinhaProc: TLabel
          Left = 11
          Top = 54
          Width = 288
          Height = 13
          Caption = 
            '                                                                ' +
            '                                '
        end
      end
    end
    object TSArquivos: TTabSheet
      Caption = 'Arquivos OnPlace.sdf'
      ImageIndex = 1
      object GroupBox2: TGroupBox
        Left = 0
        Top = 0
        Width = 419
        Height = 201
        Align = alTop
        Caption = 'Roteiros'
        TabOrder = 0
        object sbBuscaArquivos: TSpeedButton
          Left = 13
          Top = 168
          Width = 32
          Height = 27
          Flat = True
          Glyph.Data = {
            36040000424D3604000000000000360000002800000010000000100000000100
            2000000000000004000000000000000000000000000000000000FF00FF00FF00
            FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00
            FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00
            FF00FF00FF00FF00FF00FF00FF000000FF000000FF000000FF000000FF000000
            FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00
            FF00FF00FF000000FF000000FF000000FF000000FF000000FF000000FF000000
            FF000000FF000000FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00
            FF000000FF000000FF000000FF00FF00FF007B7B7B00000000007B7B7B00FF00
            FF000000FF000000FF000000FF00FF00FF00FF00FF00FF00FF00FF00FF000000
            FF000000FF000000FF00FF00FF00FF00FF00000000000000000000000000FF00
            FF00FF00FF000000FF000000FF000000FF00FF00FF00FF00FF00FF00FF000000
            FF000000FF00FF00FF00FF00FF00FF00FF007B7B7B00000000007B7B7B00FF00
            FF00FF00FF00FF00FF000000FF000000FF00FF00FF00FF00FF000000FF000000
            FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00
            FF00FF00FF00FF00FF00FF00FF000000FF000000FF00FF00FF000000FF000000
            FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF0000000000FF00FF00FF00
            FF00FF00FF00FF00FF00FF00FF000000FF000000FF00FF00FF000000FF000000
            FF00FF00FF00FF00FF00FF00FF00FF00FF007B7B7B00000000007B7B7B00FF00
            FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF000000FF000000
            FF00FF00FF00FF00FF00FF00FF00FF00FF00000084000000000000008400FF00
            FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF000000FF000000
            FF00FF00FF00FF00FF00FF00FF00FF00FF00000000000000000000000000FF00
            FF000000FF000000FF000000FF000000FF000000FF00FF00FF00FF00FF000000
            FF000000FF00FF00FF00FF00FF00FF00FF00000000000000000000000000FF00
            FF00FF00FF000000FF000000FF000000FF000000FF00FF00FF00FF00FF000000
            FF000000FF000000FF00FF00FF00FF00FF00000000000000000000000000FF00
            FF00FF00FF00FF00FF000000FF000000FF000000FF00FF00FF00FF00FF00FF00
            FF000000FF000000FF000000FF00FF00FF007B7B7B00000000007B7B7B00FF00
            FF000000FF000000FF000000FF000000FF000000FF00FF00FF00FF00FF00FF00
            FF00FF00FF000000FF000000FF000000FF000000FF000000FF000000FF000000
            FF000000FF000000FF00FF00FF00FF00FF000000FF00FF00FF00FF00FF00FF00
            FF00FF00FF00FF00FF00FF00FF000000FF000000FF000000FF000000FF000000
            FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00FF00}
          OnClick = sbBuscaArquivosClick
        end
        object LblOnLine: TLabel
          Left = 65
          Top = 167
          Width = 312
          Height = 14
          AutoSize = False
          Caption = 'Local: '
        end
        object LblArquivo: TLabel
          Left = 65
          Top = 182
          Width = 312
          Height = 14
          AutoSize = False
          Caption = 'Arquivo descarga: '
        end
        object ListArquivos: TListBox
          Left = 11
          Top = 16
          Width = 397
          Height = 146
          ItemHeight = 13
          TabOrder = 0
        end
      end
      object PProcessamento2: TPanel
        Left = 0
        Top = 206
        Width = 419
        Height = 72
        Align = alBottom
        TabOrder = 1
        Visible = False
        object LDescProc2: TLabel
          Left = 11
          Top = 6
          Width = 397
          Height = 14
          AutoSize = False
          Caption = '     '
        end
        object ProgressBar2: TGauge
          Left = 11
          Top = 27
          Width = 397
          Height = 20
          ForeColor = clNavy
          Progress = 0
        end
        object LLinhaProc2: TLabel
          Left = 11
          Top = 54
          Width = 288
          Height = 13
          Caption = 
            '                                                                ' +
            '                                '
        end
      end
    end
  end
  object QrGrupos: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'#9'RT_GRUPO'
      'from'#9'ROTEIROS'
      'where'#9'RT_IND_LEITURA = 2'
      'group by '#9'RT_GRUPO'
      'order by '#9'RT_GRUPO'
      '')
    Left = 48
    Top = 80
    object QrGruposRT_GRUPO: TIntegerField
      FieldName = 'RT_GRUPO'
    end
  end
  object QrReferencia: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select '#9'max( rt_referencia ) as referencia'
      'from'#9'roteiros'
      'where'#9'rt_grupo = :nGrupo'
      'and'#9'rt_ind_leitura = 2'
      '')
    Left = 16
    Top = 80
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end>
    object QrReferenciareferencia: TDateTimeField
      FieldName = 'referencia'
      Origin = 'roteiro.rt_referencia'
    end
  end
  object QrGrupoMovimento: TQuery
    DatabaseName = 'dbMainMovimento'
    SQL.Strings = (
      'select '#9'distinct fc.seq_roteiro, '
      #9'FC.ind_obtido, FC.ind_validado, FC.ind_processado,'
      #9'substring(convert(varchar, fc.seq_roteiro), 5, 3) as Roteiro'
      'from '#9'OnPlaceSaned_Movimento..ACQ_GRUPO_FATURA_CRONOGRAMA FC,'
      #9'OnPlaceSaned_Movimento..ACQ_GRUPO_REFERENCIA FT'
      'where'#9'FT.seq_grupo_fatura = :nGrupo'
      'and'#9'FT.cod_referencia = convert(char(7), :dtReferencia, 102)'
      'and'#9'FT.seq_roteiro = FC.seq_roteiro'
      'and'#9'FT.cod_referencia = FC.cod_referencia'
      'and'#9'FC.ind_obtido = '#39'S'#39
      'and'#9'FC.ind_validado  = '#39'N'#39)
    Left = 80
    Top = 80
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
        Value = 1
      end
      item
        DataType = ftDateTime
        Name = 'dtReferencia'
        ParamType = ptUnknown
        Value = 39356d
      end>
    object QrGrupoMovimentoseq_roteiro: TFloatField
      FieldName = 'seq_roteiro'
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
  object DsGrupoMovimento: TDataSource
    AutoEdit = False
    DataSet = QrGrupoMovimento
    Left = 112
    Top = 80
  end
  object QrRoteirosSDF: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      
        'select '#9#39'R_'#39' + OnPlaceSANED.dbo.fc_completa_zeros(rt_rota, 3) as' +
        ' RotaAgente,'
      #9'convert(varchar(7), rt_referencia, 102 ) as Referencia, '
      
        #9'convert(numeric, '#39'1'#39'+OnPlaceSANED.dbo.fc_completa_zeros(rt_grup' +
        'o, 3)+OnPlaceSANED.dbo.fc_completa_zeros(rt_rota,3)) as Roteiro,'
      #9'rt_rota, '
      
        #9#39'Grupo_'#39' + OnPlaceSANED.dbo.fc_completa_zeros(rt_grupo, 3) as G' +
        'rupo,'
      
        #9#39'OnPlace-'#39' + OnPlaceSANED.dbo.FC_COMPLETA_ZEROS(rt_grupo, 3) + ' +
        #39'-'#39' + '
      #9#9'    OnPlaceSANED.dbo.FC_COMPLETA_ZEROS(rt_rota, 3) + '#39'-'#39' + '
      
        #9#9'    convert(char(7), rt_referencia, 102) + '#39'.sdf'#39' as arquivo_c' +
        'opia'
      'from '#9'roteiros'
      'where '#9'rt_ind_leitura = 2'
      'and'#9'rt_grupo = :nGrupo'
      'order by rt_rota')
    Left = 16
    Top = 192
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end>
    object QrRoteirosSDFRotaAgente: TMemoField
      FieldName = 'RotaAgente'
      BlobType = ftMemo
      Size = 1
    end
    object QrRoteirosSDFReferencia: TStringField
      FieldName = 'Referencia'
      Size = 7
    end
    object QrRoteirosSDFRoteiro: TFloatField
      FieldName = 'Roteiro'
    end
    object QrRoteirosSDFrt_rota: TIntegerField
      FieldName = 'rt_rota'
    end
    object QrRoteirosSDFGrupo: TMemoField
      FieldName = 'Grupo'
      BlobType = ftMemo
      Size = 1
    end
    object QrRoteirosSDFarquivo_copia: TMemoField
      FieldName = 'arquivo_copia'
      BlobType = ftMemo
      Size = 1
    end
  end
end
