inherited frmDesfazCarga: TfrmDesfazCarga
  Caption = 'frmDesfazCarga'
  ClientHeight = 339
  ClientWidth = 254
  ExplicitWidth = 260
  ExplicitHeight = 371
  PixelsPerInch = 96
  TextHeight = 13
  inherited pTop: TPanel
    Width = 254
    ExplicitWidth = 254
    inherited lVersion: TLabel
      Left = 179
      Height = 26
      ExplicitLeft = 179
    end
  end
  inherited pBottom: TPanel
    Top = 299
    Width = 254
    ExplicitTop = 299
    ExplicitWidth = 254
    inherited sbtnSair: TSpeedButton
      Left = 138
      ExplicitLeft = 138
    end
    object sbtnConfirmar: TSpeedButton
      Left = 36
      Top = 7
      Width = 80
      Height = 25
      Anchors = [akTop, akRight, akBottom]
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
  object ListBox: TListBox
    Left = 55
    Top = 54
    Width = 150
    Height = 171
    ItemHeight = 13
    TabOrder = 2
  end
  object ProgressBar: TProgressBar
    Left = 55
    Top = 231
    Width = 150
    Height = 17
    TabOrder = 3
  end
  object ProgressBarTotal: TProgressBar
    Left = 55
    Top = 254
    Width = 150
    Height = 17
    TabOrder = 4
  end
end
