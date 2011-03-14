inherited frmSimulacao: TfrmSimulacao
  Caption = ''
  ClientHeight = 374
  ClientWidth = 622
  ExplicitWidth = 628
  ExplicitHeight = 406
  PixelsPerInch = 96
  TextHeight = 13
  inherited pTop: TPanel
    Width = 622
    ExplicitWidth = 622
    inherited lVersion: TLabel
      Left = 547
      Height = 26
      ExplicitLeft = 547
    end
  end
  inherited pBottom: TPanel
    Top = 334
    Width = 622
    ExplicitTop = 334
    ExplicitWidth = 622
    inherited sbtnSair: TSpeedButton
      Left = 488
      Width = 128
      ExplicitLeft = 488
      ExplicitWidth = 128
    end
    object sbtnCalcular: TSpeedButton
      Left = 4
      Top = 8
      Width = 128
      Height = 25
      Anchors = [akTop, akRight, akBottom]
      Caption = 'Cal&cular'
      Flat = True
      Glyph.Data = {
        76010000424D7601000000000000760000002800000020000000100000000100
        04000000000000010000120B0000120B00001000000000000000000000000000
        800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00337000000000
        73333337777777773F333308888888880333337F3F3F3FFF7F33330808089998
        0333337F737377737F333308888888880333337F3F3F3F3F7F33330808080808
        0333337F737373737F333308888888880333337F3F3F3F3F7F33330808080808
        0333337F737373737F333308888888880333337F3F3F3F3F7F33330808080808
        0333337F737373737F333308888888880333337F3FFFFFFF7F33330800000008
        0333337F7777777F7F333308000E0E080333337F7FFFFF7F7F33330800000008
        0333337F777777737F333308888888880333337F333333337F33330888888888
        03333373FFFFFFFF733333700000000073333337777777773333}
      NumGlyphs = 2
      OnClick = sbtnCalcularClick
    end
  end
  object PageControl: TPageControl
    Left = 0
    Top = 40
    Width = 622
    Height = 294
    ActivePage = tabPesquisar
    Align = alClient
    TabOrder = 2
    object tabPesquisar: TTabSheet
      Caption = 'Pesquisar'
      object GroupBox1: TGroupBox
        Left = 0
        Top = 0
        Width = 614
        Height = 266
        Align = alClient
        TabOrder = 0
        object Label1: TLabel
          Left = 24
          Top = 24
          Width = 33
          Height = 13
          Caption = 'Grupo:'
        end
        object Label2: TLabel
          Left = 24
          Top = 78
          Width = 71
          Height = 13
          Caption = 'Dias Consumo:'
        end
        object Label3: TLabel
          Left = 24
          Top = 51
          Width = 75
          Height = 13
          Caption = 'Volume Medido:'
        end
        object Label4: TLabel
          Left = 312
          Top = 23
          Width = 81
          Height = 13
          Caption = 'Eco. Residencial:'
        end
        object Label5: TLabel
          Left = 312
          Top = 77
          Width = 73
          Height = 13
          Caption = 'Eco. Industrial:'
        end
        object Label6: TLabel
          Left = 312
          Top = 50
          Width = 55
          Height = 13
          Caption = 'Eco. Social:'
        end
        object Label7: TLabel
          Left = 312
          Top = 104
          Width = 74
          Height = 13
          Caption = 'Eco. Comercial:'
        end
        object Label8: TLabel
          Left = 312
          Top = 131
          Width = 61
          Height = 13
          Caption = 'Eco. P'#250'blica:'
        end
        object Label9: TLabel
          Left = 312
          Top = 158
          Width = 79
          Height = 13
          Caption = 'Eco. Ent. Assist:'
        end
        object Label10: TLabel
          Left = 24
          Top = 105
          Width = 63
          Height = 13
          Caption = 'Data Leitura:'
        end
        object Label13: TLabel
          Left = 24
          Top = 134
          Width = 40
          Height = 13
          Caption = 'Liga'#231#227'o:'
        end
        object Label27: TLabel
          Left = 312
          Top = 208
          Width = 22
          Height = 13
          Caption = 'Sita:'
        end
        object cmbGrupo: TComboBox
          Left = 112
          Top = 21
          Width = 81
          Height = 21
          Style = csDropDownList
          ItemHeight = 13
          TabOrder = 0
          OnChange = cmbGrupoChange
          OnDropDown = cmbGrupoDropDown
        end
        object EdDiasConsumo: TEdit
          Left = 112
          Top = 75
          Width = 81
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          TabOrder = 2
          Text = '30'
          OnKeyPress = EdDiasConsumoKeyPress
        end
        object EdVolume: TEdit
          Left = 112
          Top = 48
          Width = 81
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          TabOrder = 1
          OnKeyPress = EdDiasConsumoKeyPress
        end
        object EdEcoRes: TEdit
          Left = 416
          Top = 20
          Width = 65
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          TabOrder = 3
          Text = '0'
          OnKeyPress = EdDiasConsumoKeyPress
        end
        object EdEcoSoc: TEdit
          Left = 416
          Top = 47
          Width = 65
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          TabOrder = 4
          Text = '0'
          OnKeyPress = EdDiasConsumoKeyPress
        end
        object EdEcoInd: TEdit
          Left = 416
          Top = 74
          Width = 65
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          TabOrder = 5
          Text = '0'
          OnKeyPress = EdDiasConsumoKeyPress
        end
        object EdEcoCom: TEdit
          Left = 416
          Top = 101
          Width = 65
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          TabOrder = 6
          Text = '0'
          OnKeyPress = EdDiasConsumoKeyPress
        end
        object EdEcoPub: TEdit
          Left = 416
          Top = 128
          Width = 65
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          TabOrder = 7
          Text = '0'
          OnKeyPress = EdDiasConsumoKeyPress
        end
        object EdEcoEA: TEdit
          Left = 416
          Top = 155
          Width = 65
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          TabOrder = 8
          Text = '0'
          OnKeyPress = EdDiasConsumoKeyPress
        end
        object ckbGrandeConsumidor: TCheckBox
          Left = 416
          Top = 182
          Width = 169
          Height = 17
          Caption = 'Grande Consumidor'
          TabOrder = 10
          OnClick = ckbGrandeConsumidorClick
        end
        object meDataLeitura: TMaskEdit
          Left = 112
          Top = 102
          Width = 81
          Height = 21
          EditMask = '!99/99/0000;1;_'
          MaxLength = 10
          TabOrder = 11
          Text = '  /  /    '
          OnKeyPress = EdDiasConsumoKeyPress
        end
        object GroupBox3: TGroupBox
          Left = 24
          Top = 153
          Width = 233
          Height = 104
          Caption = 'Bloqueada'
          TabOrder = 12
          object Label11: TLabel
            Left = 16
            Top = 50
            Width = 98
            Height = 13
            Caption = 'Dias Bloq Tarifa Ant:'
          end
          object Label12: TLabel
            Left = 16
            Top = 76
            Width = 104
            Height = 13
            Caption = 'Dias Bloq Tarifa Atua:'
          end
          object ckbBloqueada: TCheckBox
            Left = 16
            Top = 20
            Width = 121
            Height = 17
            Caption = 'Conta Bloqueada'
            TabOrder = 0
            OnClick = ckbBloqueadaClick
          end
          object EdBloqAnt: TEdit
            Left = 151
            Top = 46
            Width = 58
            Height = 21
            BiDiMode = bdRightToLeft
            Enabled = False
            ParentBiDiMode = False
            TabOrder = 1
            Text = '0'
            OnKeyPress = EdDiasConsumoKeyPress
          end
          object EdBloqAtual: TEdit
            Left = 151
            Top = 73
            Width = 58
            Height = 21
            BiDiMode = bdRightToLeft
            Enabled = False
            ParentBiDiMode = False
            TabOrder = 2
            Text = '0'
            OnKeyPress = EdDiasConsumoKeyPress
          end
        end
        object cmbLigacao: TComboBox
          Left = 112
          Top = 129
          Width = 145
          Height = 21
          Style = csDropDownList
          ItemHeight = 13
          ItemIndex = 1
          TabOrder = 9
          Text = '2 '#183' '#193'gua e Esgoto'
          OnChange = cmbLigacaoChange
          Items.Strings = (
            '1 '#183' '#193'gua'
            '2 '#183' '#193'gua e Esgoto'
            '3 '#183' Esgoto')
        end
        object cmbDesconto: TComboBox
          Left = 416
          Top = 205
          Width = 65
          Height = 21
          Style = csDropDownList
          ItemHeight = 13
          TabOrder = 13
          OnChange = cmbGrupoChange
        end
      end
    end
    object tbsResultado: TTabSheet
      Caption = 'Resultado'
      ImageIndex = 1
      object GroupBox2: TGroupBox
        Left = 0
        Top = 0
        Width = 614
        Height = 266
        Align = alClient
        TabOrder = 0
        object Label14: TLabel
          Left = 16
          Top = 30
          Width = 57
          Height = 13
          Caption = 'Residencial:'
        end
        object Label15: TLabel
          Left = 16
          Top = 53
          Width = 31
          Height = 13
          Caption = 'Social:'
        end
        object Label16: TLabel
          Left = 16
          Top = 75
          Width = 49
          Height = 13
          Caption = 'Industrial:'
        end
        object Label17: TLabel
          Left = 16
          Top = 97
          Width = 50
          Height = 13
          Caption = 'Comercial:'
        end
        object Label18: TLabel
          Left = 16
          Top = 119
          Width = 37
          Height = 13
          Caption = 'P'#250'blica:'
        end
        object Label19: TLabel
          Left = 16
          Top = 142
          Width = 55
          Height = 13
          Caption = 'Ent. Assist:'
        end
        object Label20: TLabel
          Left = 16
          Top = 165
          Width = 70
          Height = 13
          Caption = 'Grande Cons.:'
        end
        object Label21: TLabel
          Left = 110
          Top = 10
          Width = 62
          Height = 13
          Caption = 'Volume '#193'gua'
        end
        object Label22: TLabel
          Left = 194
          Top = 10
          Width = 70
          Height = 13
          Caption = 'Volume Esgoto'
        end
        object Label23: TLabel
          Left = 422
          Top = 10
          Width = 60
          Height = 13
          Caption = 'Valor Esgoto'
        end
        object Label24: TLabel
          Left = 324
          Top = 10
          Width = 52
          Height = 13
          Caption = 'Valor '#193'gua'
        end
        object Label25: TLabel
          Left = 564
          Top = 10
          Width = 24
          Height = 13
          Caption = 'Total'
        end
        object Label26: TLabel
          Left = 16
          Top = 188
          Width = 33
          Height = 13
          Caption = 'Totais:'
        end
        object Label28: TLabel
          Left = 382
          Top = 212
          Width = 46
          Height = 13
          Caption = 'Redu'#231#227'o:'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clRed
          Font.Height = -11
          Font.Name = 'Tahoma'
          Font.Style = []
          ParentFont = False
        end
        object Label29: TLabel
          Left = 382
          Top = 238
          Width = 55
          Height = 13
          Caption = 'Valor Total:'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clNavy
          Font.Height = -11
          Font.Name = 'Tahoma'
          Font.Style = []
          ParentFont = False
        end
        object EdVolAgRes: TEdit
          Left = 92
          Top = 27
          Width = 80
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 0
          Text = '0'
        end
        object EdVolAgSoc: TEdit
          Left = 92
          Top = 50
          Width = 80
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 1
          Text = '0'
        end
        object EdVolAgInd: TEdit
          Left = 92
          Top = 72
          Width = 80
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 2
          Text = '0'
        end
        object EdVolAgCom: TEdit
          Left = 92
          Top = 94
          Width = 80
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 3
          Text = '0'
        end
        object EdVolAgPub: TEdit
          Left = 92
          Top = 116
          Width = 80
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 4
          Text = '0'
        end
        object EdVolAgEA: TEdit
          Left = 92
          Top = 139
          Width = 80
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 5
          Text = '0'
        end
        object EdVolAgGC: TEdit
          Left = 92
          Top = 162
          Width = 80
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 6
          Text = '0'
        end
        object EdVolAg: TEdit
          Left = 92
          Top = 185
          Width = 80
          Height = 21
          BiDiMode = bdRightToLeft
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'Tahoma'
          Font.Style = [fsBold]
          ParentBiDiMode = False
          ParentFont = False
          ReadOnly = True
          TabOrder = 7
          Text = '0'
        end
        object EdVolEsg: TEdit
          Left = 184
          Top = 185
          Width = 80
          Height = 21
          BiDiMode = bdRightToLeft
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'Tahoma'
          Font.Style = [fsBold]
          ParentBiDiMode = False
          ParentFont = False
          ReadOnly = True
          TabOrder = 8
          Text = '0'
        end
        object EdVolEsgGC: TEdit
          Left = 184
          Top = 162
          Width = 80
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 9
          Text = '0'
        end
        object EdVolEsgEA: TEdit
          Left = 184
          Top = 139
          Width = 80
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 10
          Text = '0'
        end
        object EdVolEsgPub: TEdit
          Left = 184
          Top = 116
          Width = 80
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 11
          Text = '0'
        end
        object EdVolEsgCom: TEdit
          Left = 184
          Top = 94
          Width = 80
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 12
          Text = '0'
        end
        object EdVolEsgInd: TEdit
          Left = 184
          Top = 72
          Width = 80
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 13
          Text = '0'
        end
        object EdVolEsgSoc: TEdit
          Left = 184
          Top = 50
          Width = 80
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 14
          Text = '0'
        end
        object EdVolEsgRes: TEdit
          Left = 184
          Top = 27
          Width = 80
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 15
          Text = '0'
        end
        object EdValorAg: TEdit
          Left = 276
          Top = 185
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'Tahoma'
          Font.Style = [fsBold]
          ParentBiDiMode = False
          ParentFont = False
          ReadOnly = True
          TabOrder = 16
          Text = '0'
        end
        object EdValorAgGC: TEdit
          Left = 276
          Top = 162
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 17
          Text = '0'
        end
        object EdValorAgEA: TEdit
          Left = 276
          Top = 139
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 18
          Text = '0'
        end
        object EdValorAgPub: TEdit
          Left = 276
          Top = 116
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 19
          Text = '0'
        end
        object EdValorAgCom: TEdit
          Left = 276
          Top = 94
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 20
          Text = '0'
        end
        object EdValorAgInd: TEdit
          Left = 276
          Top = 72
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 21
          Text = '0'
        end
        object EdValorAgSoc: TEdit
          Left = 276
          Top = 50
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 22
          Text = '0'
        end
        object EdValorAgRes: TEdit
          Left = 276
          Top = 27
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 23
          Text = '0'
        end
        object EdValorEsg: TEdit
          Left = 382
          Top = 185
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'Tahoma'
          Font.Style = [fsBold]
          ParentBiDiMode = False
          ParentFont = False
          ReadOnly = True
          TabOrder = 24
          Text = '0'
        end
        object EdValorEsgGC: TEdit
          Left = 382
          Top = 162
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 25
          Text = '0'
        end
        object EdValorEsgEA: TEdit
          Left = 382
          Top = 139
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 26
          Text = '0'
        end
        object EdValorEsgPub: TEdit
          Left = 382
          Top = 116
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 27
          Text = '0'
        end
        object EdValorEsgCom: TEdit
          Left = 382
          Top = 94
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 28
          Text = '0'
        end
        object EdValorEsgInd: TEdit
          Left = 382
          Top = 72
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 29
          Text = '0'
        end
        object EdValorEsgSoc: TEdit
          Left = 382
          Top = 50
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 30
          Text = '0'
        end
        object EdValorEsgRes: TEdit
          Left = 382
          Top = 27
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          ParentBiDiMode = False
          ReadOnly = True
          TabOrder = 31
          Text = '0'
        end
        object EdValorTotal: TEdit
          Left = 488
          Top = 185
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'Tahoma'
          Font.Style = [fsBold]
          ParentBiDiMode = False
          ParentFont = False
          ReadOnly = True
          TabOrder = 32
          Text = '0'
        end
        object EdValorTotalGC: TEdit
          Left = 488
          Top = 162
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'Tahoma'
          Font.Style = [fsBold]
          ParentBiDiMode = False
          ParentFont = False
          ReadOnly = True
          TabOrder = 33
          Text = '0'
        end
        object EdValorTotalEA: TEdit
          Left = 488
          Top = 139
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'Tahoma'
          Font.Style = [fsBold]
          ParentBiDiMode = False
          ParentFont = False
          ReadOnly = True
          TabOrder = 34
          Text = '0'
        end
        object EdValorTotalPub: TEdit
          Left = 488
          Top = 116
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'Tahoma'
          Font.Style = [fsBold]
          ParentBiDiMode = False
          ParentFont = False
          ReadOnly = True
          TabOrder = 35
          Text = '0'
        end
        object EdValorTotalCom: TEdit
          Left = 488
          Top = 94
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'Tahoma'
          Font.Style = [fsBold]
          ParentBiDiMode = False
          ParentFont = False
          ReadOnly = True
          TabOrder = 36
          Text = '0'
        end
        object EdValorTotalInd: TEdit
          Left = 488
          Top = 72
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'Tahoma'
          Font.Style = [fsBold]
          ParentBiDiMode = False
          ParentFont = False
          ReadOnly = True
          TabOrder = 37
          Text = '0'
        end
        object EdValorTotalSoc: TEdit
          Left = 488
          Top = 50
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'Tahoma'
          Font.Style = [fsBold]
          ParentBiDiMode = False
          ParentFont = False
          ReadOnly = True
          TabOrder = 38
          Text = '0'
        end
        object EdValorTotalRes: TEdit
          Left = 488
          Top = 27
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'Tahoma'
          Font.Style = [fsBold]
          ParentBiDiMode = False
          ParentFont = False
          ReadOnly = True
          TabOrder = 39
          Text = '0'
        end
        object EdValorDesconto: TEdit
          Left = 488
          Top = 209
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clRed
          Font.Height = -11
          Font.Name = 'Tahoma'
          Font.Style = [fsBold]
          ParentBiDiMode = False
          ParentFont = False
          ReadOnly = True
          TabOrder = 40
          Text = '0'
        end
        object EdTotal: TEdit
          Left = 488
          Top = 235
          Width = 100
          Height = 21
          BiDiMode = bdRightToLeft
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clNavy
          Font.Height = -11
          Font.Name = 'Tahoma'
          Font.Style = [fsBold]
          ParentBiDiMode = False
          ParentFont = False
          ReadOnly = True
          TabOrder = 41
          Text = '0'
        end
      end
    end
  end
  object qryGrupo: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'#9'rt_grupo'
      'from'#9'roteiros'
      'group by '#9'rt_grupo'
      'order by'#9'rt_grupo')
    Left = 136
    Top = 32
  end
  object qryReferencia: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'#9'max(rt_referencia) as referencia'
      'from'#9'roteiros'
      'where '#9'rt_grupo = :nGrupo')
    Left = 168
    Top = 32
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end>
  end
  object qryDesconto: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select '#9'distinct de_codigo '
      'from '#9'descontos'
      'order'#9'by 1')
    Left = 200
    Top = 32
  end
end
