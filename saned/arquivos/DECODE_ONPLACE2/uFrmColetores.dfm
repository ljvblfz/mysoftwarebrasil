inherited frmColetores: TfrmColetores
  Caption = ''
  ClientHeight = 372
  ExplicitHeight = 404
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel [0]
    Left = 48
    Top = 226
    Width = 39
    Height = 13
    Caption = 'Agente:'
  end
  object Label3: TLabel [1]
    Left = 48
    Top = 257
    Width = 36
    Height = 13
    Caption = 'Maleta:'
    FocusControl = DBEdMaleta
  end
  object Label4: TLabel [2]
    Left = 48
    Top = 284
    Width = 33
    Height = 13
    Caption = 'Grupo:'
    FocusControl = DBEdGrupo
  end
  object Label5: TLabel [3]
    Left = 215
    Top = 281
    Width = 27
    Height = 13
    Caption = 'Rota:'
    FocusControl = DBEdRota
  end
  object Label6: TLabel [4]
    Left = 215
    Top = 254
    Width = 27
    Height = 13
    Caption = 'Data:'
    FocusControl = DBEdData
  end
  object Label7: TLabel [5]
    Left = 48
    Top = 308
    Width = 50
    Height = 13
    Caption = 'Descri'#231#227'o:'
    FocusControl = DBEdTexto
  end
  inherited pTop: TPanel
    inherited lVersion: TLabel
      Height = 26
    end
  end
  inherited pBottom: TPanel
    Top = 332
    ExplicitTop = 332
    inherited sbtnSair: TSpeedButton
      ExplicitLeft = 511
    end
    inherited DBNavigator: TDBNavigator
      Hints.Strings = ()
    end
  end
  inherited DBGrid: TDBGrid
    Height = 166
    Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgRowSelect, dgAlwaysShowSelection, dgConfirmDelete, dgCancelOnExit]
  end
  object DBEdMaleta: TDBEdit [9]
    Left = 112
    Top = 251
    Width = 73
    Height = 21
    DataField = 'pe_maleta'
    DataSource = DSPrincipal
    TabOrder = 3
  end
  object DBEdGrupo: TDBEdit [10]
    Left = 112
    Top = 278
    Width = 73
    Height = 21
    DataField = 'pe_grupo'
    DataSource = DSPrincipal
    TabOrder = 4
  end
  object DBEdRota: TDBEdit [11]
    Left = 248
    Top = 278
    Width = 65
    Height = 21
    DataField = 'pe_rota'
    DataSource = DSPrincipal
    TabOrder = 5
  end
  object DBEdData: TDBEdit [12]
    Left = 248
    Top = 251
    Width = 129
    Height = 21
    DataField = 'pe_data'
    DataSource = DSPrincipal
    TabOrder = 6
  end
  object DBEdTexto: TDBEdit [13]
    Left = 112
    Top = 305
    Width = 425
    Height = 21
    DataField = 'pe_descricao'
    DataSource = DSPrincipal
    TabOrder = 7
  end
  object DBLCmbAgente: TDBLookupComboBox [14]
    Left = 112
    Top = 223
    Width = 425
    Height = 21
    DataField = 'pe_agente'
    DataSource = DSPrincipal
    KeyField = 'ag_codigo'
    ListField = 'agente'
    ListSource = DSAgente
    TabOrder = 8
  end
  inherited tbPrincipal: TTable
    TableName = 'dbo.vw_problema_equipamento'
    object tbPrincipalpe_nome_agente: TStringField
      FieldName = 'pe_nome_agente'
      Size = 30
    end
    object tbPrincipalpe_agente: TIntegerField
      FieldName = 'pe_agente'
      Required = True
    end
    object tbPrincipalpe_maleta: TIntegerField
      FieldName = 'pe_maleta'
      Required = True
    end
    object tbPrincipalpe_grupo: TIntegerField
      FieldName = 'pe_grupo'
      Required = True
    end
    object tbPrincipalpe_rota: TIntegerField
      FieldName = 'pe_rota'
      Required = True
    end
    object tbPrincipalpe_data: TDateTimeField
      FieldName = 'pe_data'
      Required = True
      DisplayFormat = 'dd/mm/yyyy hh:nn'
      EditMask = '00/00/0000 00:00'
    end
    object tbPrincipalpe_descricao: TStringField
      FieldName = 'pe_descricao'
      Size = 100
    end
  end
  object qryAgente: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      
        'select ag_codigo, ag_nome, rtrim(convert(char, ag_codigo)) + '#39' '#183 +
        ' '#39' + ag_nome as agente'
      'from agentes')
    Left = 112
    Top = 8
    object qryAgenteag_codigo: TIntegerField
      FieldName = 'ag_codigo'
    end
    object qryAgenteag_nome: TStringField
      FieldName = 'ag_nome'
      Size = 30
    end
    object qryAgenteagente: TStringField
      FieldName = 'agente'
      Size = 63
    end
  end
  object DSAgente: TDataSource
    DataSet = qryAgente
    Left = 112
    Top = 48
  end
end
