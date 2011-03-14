inherited frmRelatorioMedicao: TfrmRelatorioMedicao
  Caption = ''
  ClientHeight = 191
  ClientWidth = 364
  ExplicitWidth = 370
  ExplicitHeight = 223
  PixelsPerInch = 96
  TextHeight = 13
  inherited pTop: TPanel
    Width = 364
    ExplicitWidth = 364
    inherited lVersion: TLabel
      Left = 289
      Height = 26
      ExplicitLeft = 289
    end
  end
  inherited pBottom: TPanel
    Top = 151
    Width = 364
    ExplicitTop = 151
    ExplicitWidth = 364
    inherited sbtnSair: TSpeedButton
      Left = 247
      Width = 111
      ExplicitLeft = 247
      ExplicitWidth = 111
    end
    object sbtnImprimir: TSpeedButton
      Left = 7
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
    Width = 364
    Height = 105
    Align = alTop
    TabOrder = 2
    object LGrupo: TLabel
      Left = 76
      Top = 40
      Width = 56
      Height = 13
      Caption = 'Refer'#234'ncia:'
    end
    object cmbReferencia: TComboBox
      Left = 148
      Top = 37
      Width = 89
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      TabOrder = 0
      OnDropDown = cmbReferenciaDropDown
    end
  end
  object qryReferencia: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'#9'md_referencia as referencia'
      'from '#9'medicao'
      'group by '#9'md_referencia'
      'order by '#9'md_referencia desc')
    Left = 244
    Top = 70
  end
end
