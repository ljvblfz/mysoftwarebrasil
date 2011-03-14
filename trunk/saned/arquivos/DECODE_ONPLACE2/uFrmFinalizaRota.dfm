inherited frmFinalizaRota: TfrmFinalizaRota
  Caption = ''
  ClientHeight = 209
  ClientWidth = 374
  ExplicitWidth = 380
  ExplicitHeight = 241
  PixelsPerInch = 96
  TextHeight = 13
  inherited pTop: TPanel
    Width = 374
    ExplicitWidth = 374
    inherited lVersion: TLabel
      Left = 299
      Height = 26
      ExplicitLeft = 299
    end
  end
  inherited pBottom: TPanel
    Top = 169
    Width = 374
    ExplicitTop = 174
    ExplicitWidth = 374
    inherited sbtnSair: TSpeedButton
      Left = 288
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
  end
  object GroupBox1: TGroupBox
    Left = 0
    Top = 40
    Width = 374
    Height = 128
    Align = alTop
    TabOrder = 2
    object LGrupo: TLabel
      Left = 68
      Top = 40
      Width = 33
      Height = 13
      Caption = 'Grupo:'
    end
    object LRota: TLabel
      Left = 68
      Top = 72
      Width = 27
      Height = 13
      Caption = 'Rota:'
    end
    object cmbGrupo: TComboBox
      Left = 124
      Top = 37
      Width = 89
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      TabOrder = 0
      OnDropDown = cmbGrupoDropDown
    end
    object cmbRota: TComboBox
      Left = 124
      Top = 69
      Width = 89
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      TabOrder = 1
      OnDropDown = cmbRotaDropDown
    end
    object ckbTodos: TCheckBox
      Left = 124
      Top = 96
      Width = 173
      Height = 17
      Caption = 'Todos as rotas'
      TabOrder = 2
      OnClick = ckbTodosClick
    end
    object ckbCarga: TCheckBox
      Left = 68
      Top = 14
      Width = 273
      Height = 17
      Caption = 'Rotas que foram gerada a carga e n'#227'o ir'#225' a campo.'
      TabOrder = 3
      OnClick = ckbCargaClick
    end
  end
  object qryGeral: TQuery
    DatabaseName = 'dbMain'
    Left = 24
    Top = 48
  end
  object qryInsere: TQuery
    DatabaseName = 'dbMain'
    Left = 24
    Top = 80
  end
end
