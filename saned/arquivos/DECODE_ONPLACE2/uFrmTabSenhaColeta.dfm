inherited frmTabSenhaColeta: TfrmTabSenhaColeta
  Caption = ''
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel [0]
    Left = 120
    Top = 235
    Width = 48
    Height = 13
    Caption = 'VIG'#202'NCIA'
  end
  object Label2: TLabel [1]
    Left = 120
    Top = 262
    Width = 33
    Height = 13
    Caption = 'SENHA'
  end
  inherited pTop: TPanel
    inherited lVersion: TLabel
      Height = 26
    end
  end
  inherited pBottom: TPanel
    inherited DBNavigator: TDBNavigator
      Hints.Strings = ()
    end
  end
  inherited DBGrid: TDBGrid
    Height = 169
  end
  object DBEVigencia: TDBEdit [5]
    Left = 190
    Top = 232
    Width = 121
    Height = 21
    CharCase = ecUpperCase
    DataField = 'sc_data_vigencia'
    DataSource = DSPrincipal
    TabOrder = 3
  end
  object DBESenha: TDBEdit [6]
    Left = 190
    Top = 259
    Width = 121
    Height = 21
    CharCase = ecUpperCase
    DataField = 'sc_senha'
    DataSource = DSPrincipal
    TabOrder = 4
  end
  inherited tbPrincipal: TTable
    TableName = 'dbo.senha_coleta'
    object tbPrincipalsc_data_vigencia: TDateTimeField
      FieldName = 'sc_data_vigencia'
      Required = True
      DisplayFormat = 'DD/MM/YYYY'
      EditMask = '!99/99/0099;1;_'
    end
    object tbPrincipalsc_senha: TStringField
      FieldName = 'sc_senha'
      Required = True
      Size = 10
    end
    object tbPrincipalsc_chave: TStringField
      FieldName = 'sc_chave'
      Size = 15
    end
    object tbPrincipalsc_data_atualiz: TDateTimeField
      FieldName = 'sc_data_atualiz'
    end
  end
end
