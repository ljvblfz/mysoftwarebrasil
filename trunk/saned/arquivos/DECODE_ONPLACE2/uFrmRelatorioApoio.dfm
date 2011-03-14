inherited frmRelatorioApoio: TfrmRelatorioApoio
  Caption = 'frmRelatorioApoio'
  ClientHeight = 222
  ClientWidth = 400
  Visible = False
  ExplicitWidth = 406
  ExplicitHeight = 254
  PixelsPerInch = 96
  TextHeight = 13
  inherited pTop: TPanel
    Width = 400
    ExplicitWidth = 400
    inherited lVersion: TLabel
      Left = 325
      Height = 26
      ExplicitLeft = 325
    end
  end
  inherited pBottom: TPanel
    Top = 182
    Width = 400
    ExplicitTop = 182
    ExplicitWidth = 400
    inherited sbtnSair: TSpeedButton
      Left = 280
      Width = 111
      ExplicitLeft = 280
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
    object sbtnArquivo: TSpeedButton
      Left = 126
      Top = 8
      Width = 111
      Height = 25
      Caption = 'Arquivo'
      Flat = True
      Glyph.Data = {
        76010000424D7601000000000000760000002800000020000000100000000100
        04000000000000010000130B0000130B00001000000000000000000000000000
        800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00333333330070
        7700333333337777777733333333008088003333333377F73377333333330088
        88003333333377FFFF7733333333000000003FFFFFFF77777777000000000000
        000077777777777777770FFFFFFF0FFFFFF07F3333337F3333370FFFFFFF0FFF
        FFF07F3FF3FF7FFFFFF70F00F0080CCC9CC07F773773777777770FFFFFFFF039
        99337F3FFFF3F7F777F30F0000F0F09999937F7777373777777F0FFFFFFFF999
        99997F3FF3FFF77777770F00F000003999337F773777773777F30FFFF0FF0339
        99337F3FF7F3733777F30F08F0F0337999337F7737F73F7777330FFFF0039999
        93337FFFF7737777733300000033333333337777773333333333}
      NumGlyphs = 2
      OnClick = sbtnArquivoClick
    end
  end
  object GroupBox1: TGroupBox
    Left = 0
    Top = 40
    Width = 400
    Height = 137
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
    object cmbGrupo: TComboBox
      Left = 148
      Top = 37
      Width = 89
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      TabOrder = 0
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
      OnDropDown = cmbRotaDropDown
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
      OnDropDown = cmbRotaFimDropDown
    end
  end
  object qryGrupo: TQuery
    DatabaseName = 'dbMain'
    Left = 332
    Top = 62
  end
  object qryRota: TQuery
    DatabaseName = 'dbMain'
    Left = 332
    Top = 94
  end
  object SaveDialog: TSaveDialog
    DefaultExt = '*.txt'
    Filter = 'Texto (*.txt)|*.txt'
    InitialDir = 'C:\OnPlace'
    Title = 'Arquivo Texto'
    Left = 296
    Top = 64
  end
end
