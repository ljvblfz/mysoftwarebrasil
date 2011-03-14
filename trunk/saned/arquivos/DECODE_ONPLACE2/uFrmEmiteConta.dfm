inherited frmEmiteConta: TfrmEmiteConta
  Caption = ''
  ClientHeight = 296
  Visible = False
  ExplicitHeight = 329
  PixelsPerInch = 96
  TextHeight = 13
  inherited pBottom: TPanel
    Top = 256
    ExplicitTop = 256
    inherited sbtnSair: TSpeedButton
      Left = 304
      Width = 111
      ExplicitLeft = 304
      ExplicitWidth = 111
    end
    object sbtnImprimir: TSpeedButton
      Left = 8
      Top = 8
      Width = 111
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
  end
  object GroupBox1: TGroupBox
    Left = 0
    Top = 40
    Width = 426
    Height = 216
    Align = alTop
    TabOrder = 2
    object LGrupo: TLabel
      Left = 92
      Top = 40
      Width = 33
      Height = 13
      Caption = 'Grupo:'
    end
    object LRota: TLabel
      Left = 92
      Top = 72
      Width = 27
      Height = 13
      Caption = 'Rota:'
    end
    object Label1: TLabel
      Left = 252
      Top = 72
      Width = 16
      Height = 13
      Caption = 'at'#233
    end
    object Label2: TLabel
      Left = 92
      Top = 122
      Width = 25
      Height = 13
      Caption = 'CDC:'
    end
    object grbEmissao: TGroupBox
      Left = 8
      Top = 146
      Width = 407
      Height = 54
      Caption = 'Emiss'#227'o'
      TabOrder = 5
      object rdbAviso: TRadioButton
        Left = 16
        Top = 24
        Width = 137
        Height = 17
        Caption = 'Aviso de D'#233'bitos'
        Checked = True
        TabOrder = 0
        TabStop = True
      end
      object rdbNotificacao: TRadioButton
        Left = 224
        Top = 24
        Width = 137
        Height = 17
        Caption = 'Notifica'#231#245'es de d'#233'bitos'
        TabOrder = 1
      end
    end
    object grbFatura: TGroupBox
      Left = 8
      Top = 146
      Width = 407
      Height = 54
      Caption = 'Emiss'#227'o de Fatura'
      TabOrder = 6
      object rdbTodas: TRadioButton
        Left = 16
        Top = 24
        Width = 137
        Height = 17
        Caption = 'Todas'
        Checked = True
        TabOrder = 0
        TabStop = True
      end
      object rdbRetidas: TRadioButton
        Left = 272
        Top = 24
        Width = 113
        Height = 17
        Caption = 'Contas Retidas'
        TabOrder = 1
      end
      object rdbColetadas: TRadioButton
        Left = 140
        Top = 24
        Width = 113
        Height = 17
        Caption = 'Contas Coletadas'
        TabOrder = 2
      end
    end
    object cmbGrupo: TComboBox
      Left = 148
      Top = 37
      Width = 89
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      TabOrder = 0
      OnChange = cmbGrupoChange
      OnDropDown = cmbGrupoDropDown
    end
    object cmbRota: TComboBox
      Left = 148
      Top = 69
      Width = 89
      Height = 21
      Style = csDropDownList
      Enabled = False
      ItemHeight = 13
      TabOrder = 1
    end
    object ckbTodos: TCheckBox
      Left = 148
      Top = 96
      Width = 173
      Height = 17
      Caption = 'Todos as rotas'
      Checked = True
      State = cbChecked
      TabOrder = 2
      OnClick = ckbTodosClick
    end
    object cmbRotaFim: TComboBox
      Left = 280
      Top = 69
      Width = 89
      Height = 21
      Style = csDropDownList
      Enabled = False
      ItemHeight = 13
      TabOrder = 3
    end
    object EdCDC: TEdit
      Left = 148
      Top = 119
      Width = 89
      Height = 21
      TabOrder = 4
    end
  end
  object qryGrupo: TQuery
    DatabaseName = 'dbMain'
    Left = 284
    Top = 70
  end
  object qryRota: TQuery
    DatabaseName = 'dbMain'
    Left = 316
    Top = 70
  end
end
