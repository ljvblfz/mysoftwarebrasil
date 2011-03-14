inherited frmRetorno: TfrmRetorno
  Caption = ''
  ClientHeight = 367
  ClientWidth = 334
  ExplicitWidth = 340
  ExplicitHeight = 399
  PixelsPerInch = 96
  TextHeight = 13
  object LInformacao: TLabel [0]
    Left = 55
    Top = 46
    Width = 218
    Height = 13
    AutoSize = False
    Caption = 'LInformacao'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clRed
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = [fsBold]
    ParentFont = False
  end
  inherited pTop: TPanel
    Width = 334
    ExplicitWidth = 334
    inherited lVersion: TLabel
      Left = 259
      Height = 26
      ExplicitLeft = 259
    end
  end
  inherited pBottom: TPanel
    Top = 327
    Width = 334
    ExplicitTop = 327
    ExplicitWidth = 334
    inherited sbtnSair: TSpeedButton
      Left = 178
      ExplicitLeft = 178
    end
    object sbtnConfirmar: TSpeedButton
      Left = 76
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
    Top = 65
    Width = 218
    Height = 232
    ItemHeight = 13
    TabOrder = 2
  end
  object ProgressBar: TProgressBar
    Left = 55
    Top = 303
    Width = 218
    Height = 17
    TabOrder = 3
  end
end
