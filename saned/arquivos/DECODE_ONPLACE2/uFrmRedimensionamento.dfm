inherited frmRedimensionamento: TfrmRedimensionamento
  Caption = 'frmRedimensionamento'
  ClientHeight = 402
  ClientWidth = 705
  ExplicitWidth = 711
  ExplicitHeight = 434
  PixelsPerInch = 96
  TextHeight = 13
  inherited pTop: TPanel
    Width = 705
    ExplicitWidth = 705
    inherited lVersion: TLabel
      Left = 630
      Height = 26
      ExplicitLeft = 630
    end
  end
  inherited pBottom: TPanel
    Top = 362
    Width = 705
    ExplicitTop = 362
    ExplicitWidth = 705
    inherited sbtnSair: TSpeedButton
      Left = 589
      Top = 6
      Width = 110
      ExplicitLeft = 589
      ExplicitTop = 6
      ExplicitWidth = 110
    end
    object sbtnValidar: TSpeedButton
      Left = 9
      Top = 6
      Width = 124
      Height = 25
      Anchors = [akLeft, akTop, akBottom]
      Caption = 'Validar'
      Flat = True
      Glyph.Data = {
        76010000424D7601000000000000760000002800000020000000100000000100
        04000000000000010000130B0000130B00001000000000000000000000000000
        800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00333333333333
        33033333333333333F7F3333333333333000333333333333F777333333333333
        000333333333333F777333333333333000333333333333F77733333333333300
        033333333FFF3F777333333700073B703333333F7773F77733333307777700B3
        33333377333777733333307F8F8F7033333337F333F337F3333377F8F9F8F773
        3333373337F3373F3333078F898F870333337F33F7FFF37F333307F99999F703
        33337F377777337F3333078F898F8703333373F337F33373333377F8F9F8F773
        333337F3373337F33333307F8F8F70333333373FF333F7333333330777770333
        333333773FF77333333333370007333333333333777333333333}
      NumGlyphs = 2
      OnClick = sbtnValidarClick
    end
    object sbtnImprimir: TSpeedButton
      Left = 459
      Top = 6
      Width = 124
      Height = 25
      Caption = 'Imprimir'
      Flat = True
      Glyph.Data = {
        76010000424D7601000000000000760000002800000020000000100000000100
        04000000000000010000120B0000120B00001000000000000000000000000000
        800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00300000000000
        0003377777777777777308888888888888807F33333333333337088888888888
        88807FFFFFFFFFFFFFF7000000000000000077777777777777770F8F8F8F8F8F
        8F807F333333333333F708F8F8F8F8F8F9F07F333333333337370F8F8F8F8F8F
        8F807FFFFFFFFFFFFFF7000000000000000077777777777777773330FFFFFFFF
        03333337F3FFFF3F7F333330F0000F0F03333337F77773737F333330FFFFFFFF
        03333337F3FF3FFF7F333330F00F000003333337F773777773333330FFFF0FF0
        33333337F3F37F3733333330F08F0F0333333337F7337F7333333330FFFF0033
        33333337FFFF7733333333300000033333333337777773333333}
      NumGlyphs = 2
      OnClick = sbtnImprimirClick
    end
    object sbtnAgentes: TSpeedButton
      Left = 139
      Top = 6
      Width = 124
      Height = 25
      Anchors = [akLeft, akTop, akBottom]
      Caption = 'Incluir Agentes'
      Flat = True
      Glyph.Data = {
        76010000424D7601000000000000760000002800000020000000100000000100
        04000000000000010000120B0000120B00001000000000000000000000000000
        800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF0033BBBBBBBBBB
        BB33337777777777777F33BB00BBBBBBBB33337F77333333F37F33BB0BBBBBB0
        BB33337F73F33337FF7F33BBB0BBBB000B33337F37FF3377737F33BBB00BB00B
        BB33337F377F3773337F33BBBB0B00BBBB33337F337F7733337F33BBBB000BBB
        BB33337F33777F33337F33EEEE000EEEEE33337F3F777FFF337F33EE0E80000E
        EE33337F73F77773337F33EEE0800EEEEE33337F37377F33337F33EEEE000EEE
        EE33337F33777F33337F33EEEEE00EEEEE33337F33377FF3337F33EEEEEE00EE
        EE33337F333377F3337F33EEEEEE00EEEE33337F33337733337F33EEEEEEEEEE
        EE33337FFFFFFFFFFF7F33EEEEEEEEEEEE333377777777777773}
      NumGlyphs = 2
      OnClick = sbtnAgentesClick
    end
  end
  object GroupBox1: TGroupBox
    Left = 0
    Top = 40
    Width = 705
    Height = 322
    Align = alClient
    TabOrder = 2
    object Label1: TLabel
      Left = 76
      Top = 19
      Width = 33
      Height = 13
      Caption = 'Grupo:'
    end
    object Bevel1: TBevel
      Left = 3
      Top = 43
      Width = 696
      Height = 2
    end
    object Bevel2: TBevel
      Left = 3
      Top = 245
      Width = 696
      Height = 7
    end
    object Label2: TLabel
      Left = 10
      Top = 261
      Width = 39
      Height = 13
      Caption = 'Agente:'
    end
    object Label3: TLabel
      Left = 10
      Top = 288
      Width = 36
      Height = 13
      Caption = 'Maleta:'
    end
    object Label4: TLabel
      Left = 151
      Top = 288
      Width = 56
      Height = 13
      Caption = 'Seq. Inicial:'
    end
    object Label5: TLabel
      Left = 311
      Top = 288
      Width = 51
      Height = 13
      Caption = 'Seq. Final:'
    end
    object sbtIncluir: TSpeedButton
      Left = 505
      Top = 283
      Width = 97
      Height = 22
      Caption = 'Alterar'
      Enabled = False
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
      OnClick = sbtIncluirClick
    end
    object Bevel3: TBevel
      Left = 3
      Top = 101
      Width = 696
      Height = 2
    end
    object Label6: TLabel
      Left = 10
      Top = 67
      Width = 99
      Height = 13
      Caption = 'Redimensionar para:'
    end
    object Label7: TLabel
      Left = 197
      Top = 67
      Width = 33
      Height = 13
      Caption = 'rota(s)'
    end
    object sbtnRedimensionar: TSpeedButton
      Left = 236
      Top = 63
      Width = 98
      Height = 22
      Caption = 'Redimensionar'
      Enabled = False
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
      OnClick = sbtnRedimensionarClick
    end
    object Bevel4: TBevel
      Left = 340
      Top = 46
      Width = 2
      Height = 53
    end
    object Label8: TLabel
      Left = 348
      Top = 67
      Width = 84
      Height = 13
      Caption = 'Quebrar rota em:'
    end
    object Label9: TLabel
      Left = 514
      Top = 67
      Width = 33
      Height = 13
      Caption = 'rota(s)'
    end
    object sbtnDividir: TSpeedButton
      Left = 553
      Top = 63
      Width = 98
      Height = 22
      Caption = 'Dividir'
      Enabled = False
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
      OnClick = sbtnDividirClick
    end
    object cmbGrupo: TComboBox
      Left = 115
      Top = 16
      Width = 90
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      TabOrder = 0
      OnChange = cmbGrupoChange
      OnDropDown = cmbGrupoDropDown
    end
    object DBGrRota: TDBGrid
      Left = 9
      Top = 109
      Width = 693
      Height = 130
      DataSource = DSRoteiro
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
          FieldName = 'rt_rota'
          Title.Alignment = taCenter
          Title.Caption = 'Rota'
          Width = 60
          Visible = True
        end
        item
          Alignment = taCenter
          Expanded = False
          FieldName = 'rt_maleta'
          Title.Alignment = taCenter
          Title.Caption = 'Maleta'
          Width = 65
          Visible = True
        end
        item
          Alignment = taCenter
          Expanded = False
          FieldName = 'rt_agente'
          Title.Alignment = taCenter
          Title.Caption = 'Agente'
          Width = 65
          Visible = True
        end
        item
          Expanded = False
          FieldName = 'ag_nome'
          Title.Alignment = taCenter
          Title.Caption = 'Nome'
          Width = 140
          Visible = True
        end
        item
          Alignment = taCenter
          Expanded = False
          FieldName = 'rt_ind_chuva'
          Title.Alignment = taCenter
          Title.Caption = 'Chuva'
          Width = 50
          Visible = True
        end
        item
          Expanded = False
          FieldName = 'rt_ordem_inicial'
          Title.Alignment = taCenter
          Title.Caption = 'Seq Inicial'
          Width = 70
          Visible = True
        end
        item
          Expanded = False
          FieldName = 'rt_ordem_final'
          Title.Alignment = taCenter
          Title.Caption = 'Seq Final'
          Width = 70
          Visible = True
        end
        item
          Expanded = False
          FieldName = 'qtde_lig'
          Title.Alignment = taCenter
          Title.Caption = 'Liga'#231#245'es'
          Width = 65
          Visible = True
        end
        item
          Alignment = taCenter
          Expanded = False
          FieldName = 'Qtde_Divergencia'
          Title.Alignment = taCenter
          Title.Caption = 'Divergencia'
          Width = 65
          Visible = True
        end>
    end
    object cmbAgente: TComboBox
      Left = 55
      Top = 258
      Width = 400
      Height = 21
      ItemHeight = 13
      Sorted = True
      TabOrder = 2
      OnChange = cmbAgenteChange
    end
    object EdMaleta: TEdit
      Left = 55
      Top = 285
      Width = 79
      Height = 21
      TabOrder = 3
      OnChange = cmbAgenteChange
    end
    object chbChuva: TCheckBox
      Left = 505
      Top = 260
      Width = 65
      Height = 17
      Caption = 'Chuva'
      TabOrder = 4
    end
    object EdSeqInicial: TEdit
      Left = 213
      Top = 285
      Width = 82
      Height = 21
      ReadOnly = True
      TabOrder = 5
      OnChange = cmbAgenteChange
    end
    object EdSeqFinal: TEdit
      Left = 373
      Top = 285
      Width = 82
      Height = 21
      TabOrder = 6
      OnChange = cmbAgenteChange
    end
    object EdRoteiros: TEdit
      Left = 115
      Top = 64
      Width = 70
      Height = 21
      TabOrder = 7
      OnChange = cmbAgenteChange
    end
    object EdDividir: TEdit
      Left = 438
      Top = 64
      Width = 70
      Height = 21
      TabOrder = 8
      OnChange = cmbAgenteChange
    end
  end
  object DSRoteiro: TDataSource
    DataSet = DMRedimensionamento.qryRoteiro
    OnDataChange = DSRoteiroDataChange
    Left = 408
    Top = 56
  end
end
