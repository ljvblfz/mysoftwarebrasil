inherited frmTeste: TfrmTeste
  Caption = 'frmTeste'
  ClientHeight = 502
  ClientWidth = 396
  OldCreateOrder = True
  ExplicitWidth = 402
  ExplicitHeight = 535
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel [0]
    Left = 40
    Top = 112
    Width = 35
    Height = 13
    Caption = 'GRUPO'
  end
  object Label3: TLabel [1]
    Left = 40
    Top = 152
    Width = 28
    Height = 13
    Caption = 'ROTA'
  end
  object PATH: TLabel [2]
    Left = 40
    Top = 192
    Width = 26
    Height = 13
    Caption = 'PATH'
  end
  object LStatus: TLabel [3]
    Left = 125
    Top = 68
    Width = 4
    Height = 16
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object Label2: TLabel [4]
    Left = 40
    Top = 232
    Width = 47
    Height = 13
    Caption = 'ARQUIVO'
  end
  inherited pTop: TPanel
    Width = 396
    TabOrder = 15
    ExplicitWidth = 396
    inherited lVersion: TLabel
      Left = 321
      Height = 26
      ExplicitLeft = 321
    end
  end
  inherited pBottom: TPanel
    Top = 462
    Width = 396
    TabOrder = 16
    ExplicitTop = 462
    ExplicitWidth = 396
    inherited sbtnSair: TSpeedButton
      Left = 307
      ExplicitLeft = 307
    end
  end
  object Egrupo: TEdit
    Left = 104
    Top = 109
    Width = 254
    Height = 21
    TabOrder = 0
    Text = 'EGrupo'
  end
  object ERota: TEdit
    Left = 104
    Top = 149
    Width = 254
    Height = 21
    TabOrder = 1
    Text = 'ERota'
  end
  object btnGerar: TButton
    Left = 121
    Top = 272
    Width = 75
    Height = 25
    Caption = 'Gerar Carga'
    TabOrder = 2
    OnClick = btnGerarClick
  end
  object EPath: TEdit
    Left = 104
    Top = 189
    Width = 254
    Height = 21
    TabOrder = 3
    Text = 'EPath'
  end
  object Button1: TButton
    Left = 40
    Top = 272
    Width = 75
    Height = 25
    Caption = 'Recep'#231#227'o'
    TabOrder = 4
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 40
    Top = 303
    Width = 75
    Height = 25
    Caption = 'Desfazer'
    TabOrder = 5
    OnClick = Button2Click
  end
  object ProgressBar: TProgressBar
    Left = 41
    Top = 368
    Width = 317
    Height = 17
    TabOrder = 6
  end
  object Button3: TButton
    Left = 121
    Top = 303
    Width = 75
    Height = 25
    Caption = 'Desfazer'
    TabOrder = 7
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 202
    Top = 303
    Width = 75
    Height = 25
    Caption = 'Finalizar'
    TabOrder = 8
    OnClick = Button4Click
  end
  object Button5: TButton
    Left = 202
    Top = 272
    Width = 75
    Height = 25
    Caption = ' Descarga'
    TabOrder = 9
    OnClick = Button5Click
  end
  object Button6: TButton
    Left = 283
    Top = 303
    Width = 75
    Height = 25
    Caption = 'Desfazer'
    TabOrder = 10
    OnClick = Button6Click
  end
  object Button7: TButton
    Left = 283
    Top = 272
    Width = 75
    Height = 25
    Caption = 'Transmiss'#227'o'
    TabOrder = 11
    OnClick = Button7Click
  end
  object Button8: TButton
    Left = 202
    Top = 334
    Width = 75
    Height = 25
    Caption = 'Desfazer'
    TabOrder = 12
    OnClick = Button8Click
  end
  object btnStatus: TButton
    Left = 40
    Top = 64
    Width = 75
    Height = 25
    Caption = 'Status'
    TabOrder = 13
    OnClick = btnStatusClick
  end
  object EArquivo: TEdit
    Left = 104
    Top = 229
    Width = 254
    Height = 21
    TabOrder = 14
    Text = 'EArquivo'
  end
  object Button9: TButton
    Left = 40
    Top = 408
    Width = 75
    Height = 25
    Caption = 'LimparBanco'
    TabOrder = 17
    OnClick = Button9Click
  end
  object qryGeral: TQuery
    DatabaseName = 'dbMain'
    Left = 324
    Top = 64
  end
end
