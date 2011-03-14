inherited frmTabChaveAcesso: TfrmTabChaveAcesso
  Caption = 'frmTabChaveAcesso'
  ClientHeight = 435
  ClientWidth = 584
  ExplicitTop = -42
  ExplicitWidth = 590
  ExplicitHeight = 467
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel [0]
    Left = 16
    Top = 60
    Width = 31
    Height = 13
    Caption = 'Chave'
    FocusControl = DBEdit1
  end
  object Label2: TLabel [1]
    Left = 16
    Top = 85
    Width = 31
    Height = 13
    Caption = 'Nome:'
    FocusControl = DBEdit2
  end
  inherited pTop: TPanel
    Width = 584
    ExplicitWidth = 584
    inherited lVersion: TLabel
      Left = 509
      Height = 26
      ExplicitLeft = 509
    end
  end
  inherited pBottom: TPanel
    Top = 395
    Width = 584
    ExplicitTop = 395
    ExplicitWidth = 584
    inherited sbtnSair: TSpeedButton
      Left = 498
      ExplicitLeft = 490
    end
    inherited sbtnLegenda: TSpeedButton
      Left = 412
      ExplicitLeft = 404
    end
    inherited DBNavigator: TDBNavigator
      DataSource = DSPai
      Hints.Strings = ()
    end
    inherited pAction: TPanel
      Left = 154
      ExplicitLeft = 154
      inherited sbtnIncluir: TSpeedButton
        Visible = False
      end
      inherited sbtnExcluir: TSpeedButton
        Visible = False
      end
    end
    inherited pOkCancel: TPanel
      Left = 154
      ExplicitLeft = 154
      object chbTotal: TCheckBox
        Left = 0
        Top = 12
        Width = 80
        Height = 17
        Caption = 'Acesso total'
        TabOrder = 0
        Visible = False
        OnClick = chbTotalClick
      end
    end
  end
  inherited DBGrid: TDBGrid
    Width = 584
    Height = 9
    Visible = False
  end
  object DBEdit1: TDBEdit [5]
    Left = 56
    Top = 55
    Width = 433
    Height = 21
    DataField = 'ch_chave'
    DataSource = DSPai
    ReadOnly = True
    TabOrder = 3
  end
  object DBEdit2: TDBEdit [6]
    Left = 56
    Top = 82
    Width = 505
    Height = 21
    DataField = 'ch_nome'
    DataSource = DSPai
    ReadOnly = True
    TabOrder = 4
  end
  object DBCheckBox1: TDBCheckBox [7]
    Left = 516
    Top = 59
    Width = 45
    Height = 17
    Caption = 'Ativo'
    DataField = 'ch_status'
    DataSource = DSPai
    ReadOnly = True
    TabOrder = 5
    ValueChecked = 'True'
    ValueUnchecked = 'False'
  end
  object PageControl: TPageControl [8]
    Left = 16
    Top = 109
    Width = 545
    Height = 280
    TabOrder = 6
  end
  inherited tbPrincipal: TTable
    IndexFieldNames = 'ca_chave'
    MasterFields = 'ch_chave'
    MasterSource = DSPai
    TableName = 'dbo.chave_acesso'
    object tbPrincipalca_chave: TStringField
      FieldName = 'ca_chave'
      Required = True
      Size = 16
    end
    object tbPrincipalca_id: TIntegerField
      FieldName = 'ca_id'
      Required = True
    end
    object tbPrincipalca_status: TBooleanField
      FieldName = 'ca_status'
      Required = True
    end
  end
  object tbPai: TTable
    DatabaseName = 'dbMain'
    TableName = 'dbo.chave'
    Left = 136
    Top = 8
    object tbPaich_chave: TStringField
      FieldName = 'ch_chave'
      Required = True
      Size = 15
    end
    object tbPaich_senha: TStringField
      FieldName = 'ch_senha'
      Required = True
      Size = 15
    end
    object tbPaich_nome: TStringField
      FieldName = 'ch_nome'
      Size = 30
    end
    object tbPaich_status: TBooleanField
      FieldName = 'ch_status'
    end
  end
  object DSPai: TDataSource
    DataSet = tbPai
    OnDataChange = DSPaiDataChange
    Left = 168
    Top = 8
  end
  object qryAcesso: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select * from acesso'
      'order by ac_ordem')
    Left = 256
    Top = 8
    object qryAcessoac_id: TIntegerField
      FieldName = 'ac_id'
      Origin = 'DBMAIN.acesso.ac_id'
    end
    object qryAcessoac_ordem: TIntegerField
      FieldName = 'ac_ordem'
      Origin = 'DBMAIN.acesso.ac_ordem'
    end
    object qryAcessoac_name: TStringField
      FieldName = 'ac_name'
      Origin = 'DBMAIN.acesso.ac_name'
      Size = 50
    end
    object qryAcessoac_caption: TStringField
      FieldName = 'ac_caption'
      Origin = 'DBMAIN.acesso.ac_caption'
      Size = 50
    end
    object qryAcessoac_nivel: TIntegerField
      FieldName = 'ac_nivel'
      Origin = 'DBMAIN.acesso.ac_nivel'
    end
    object qryAcessoac_onclick: TBooleanField
      FieldName = 'ac_onclick'
      Origin = 'DBMAIN.acesso.ac_onclick'
    end
  end
end
