inherited frmLegenda: TfrmLegenda
  Caption = 'frmLegenda'
  ClientHeight = 385
  ClientWidth = 474
  Visible = False
  ExplicitWidth = 480
  ExplicitHeight = 417
  PixelsPerInch = 96
  TextHeight = 13
  inherited pTop: TPanel
    Width = 474
    ExplicitWidth = 474
    inherited lVersion: TLabel
      Left = 399
      Height = 26
      ExplicitLeft = 399
    end
  end
  inherited pBottom: TPanel
    Top = 345
    Width = 474
    ExplicitTop = 345
    ExplicitWidth = 474
    inherited sbtnSair: TSpeedButton
      Left = 388
      ExplicitLeft = 388
    end
  end
  object RETexto: TRichEdit
    Left = 8
    Top = 46
    Width = 458
    Height = 293
    Lines.Strings = (
      'RETexto')
    TabOrder = 2
  end
  object qryGeral: TQuery
    DatabaseName = 'dbMain'
    Left = 8
    Top = 8
  end
end
