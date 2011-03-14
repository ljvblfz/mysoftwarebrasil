inherited frmTabUsuarios: TfrmTabUsuarios
  Caption = 'frmTabUsuarios'
  ClientHeight = 344
  ExplicitHeight = 376
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel [0]
    Left = 56
    Top = 227
    Width = 31
    Height = 13
    Caption = 'Chave'
  end
  object Label2: TLabel [1]
    Left = 56
    Top = 254
    Width = 27
    Height = 13
    Caption = 'Nome'
  end
  inherited pTop: TPanel
    inherited lVersion: TLabel
      Height = 26
    end
  end
  inherited pBottom: TPanel
    Top = 304
    ExplicitTop = 304
    inherited DBNavigator: TDBNavigator
      Hints.Strings = ()
    end
  end
  inherited DBGrid: TDBGrid
    Height = 169
  end
  object DBEChave: TDBEdit [5]
    Left = 126
    Top = 224
    Width = 121
    Height = 21
    CharCase = ecUpperCase
    DataField = 'ch_chave'
    DataSource = DSPrincipal
    TabOrder = 3
  end
  object DBENome: TDBEdit [6]
    Left = 126
    Top = 251
    Width = 293
    Height = 21
    DataField = 'ch_nome'
    DataSource = DSPrincipal
    TabOrder = 4
  end
  object DBCBStatus: TDBCheckBox [7]
    Left = 126
    Top = 278
    Width = 91
    Height = 17
    Caption = 'Ativo'
    DataField = 'ch_status'
    DataSource = DSPrincipal
    TabOrder = 5
    ValueChecked = 'True'
    ValueUnchecked = 'False'
  end
  inherited tbPrincipal: TTable
    TableName = 'dbo.chave'
    object tbPrincipalch_chave: TStringField
      FieldName = 'ch_chave'
      Required = True
      Size = 15
    end
    object tbPrincipalch_nome: TStringField
      FieldName = 'ch_nome'
      Size = 30
    end
    object tbPrincipalch_status: TBooleanField
      FieldName = 'ch_status'
    end
    object tbPrincipalch_senha: TStringField
      FieldName = 'ch_senha'
      Required = True
      Size = 15
    end
  end
  object qryLimpaChaveAcesso: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'delete from chave_acesso'
      'where ca_chave not in (select ch_chave from chave)')
    Left = 80
    Top = 8
  end
  object qryInsereChaveAcesso: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'insert into chave_acesso'
      'select'
      '  :usuario,'
      '  ac_id,'
      '  0'
      'from acesso'
      'go'
      'update chave_acesso'
      'set ca_status = 1'
      'where ca_id'
      'in (select ac_id'
      '    from acesso'
      '    where ac_nivel = 0)'
      '')
    Left = 112
    Top = 8
    ParamData = <
      item
        DataType = ftString
        Name = 'usuario'
        ParamType = ptUnknown
      end>
  end
end
