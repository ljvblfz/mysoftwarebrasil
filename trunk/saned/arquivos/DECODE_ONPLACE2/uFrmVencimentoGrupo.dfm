inherited frmVencimentoGrupo: TfrmVencimentoGrupo
  Caption = 'frmVencimentoGrupo'
  ClientHeight = 367
  ClientWidth = 359
  ExplicitWidth = 365
  ExplicitHeight = 399
  PixelsPerInch = 96
  TextHeight = 13
  inherited pTop: TPanel
    Width = 359
    inherited lVersion: TLabel
      Left = 284
      Height = 26
    end
  end
  inherited pBottom: TPanel
    Top = 327
    Width = 359
    inherited sbtnSair: TSpeedButton
      Left = 273
    end
  end
  object GroupBox1: TGroupBox
    Left = 0
    Top = 40
    Width = 359
    Height = 287
    Align = alClient
    TabOrder = 2
    ExplicitLeft = 200
    ExplicitTop = 208
    ExplicitWidth = 185
    ExplicitHeight = 105
    object Label1: TLabel
      Left = 10
      Top = 23
      Width = 33
      Height = 13
      Caption = 'Grupo:'
    end
    object Bevel1: TBevel
      Left = 3
      Top = 47
      Width = 417
      Height = 2
    end
    object Label2: TLabel
      Left = 10
      Top = 55
      Width = 56
      Height = 13
      Caption = 'Refer'#234'ncia:'
    end
    object cmbGrupo: TComboBox
      Left = 87
      Top = 20
      Width = 90
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      TabOrder = 0
      OnChange = cmbGrupoChange
      OnDropDown = cmbGrupoDropDown
    end
    object DBGrRota: TDBGrid
      Left = 87
      Top = 79
      Width = 266
      Height = 202
      DataSource = DataSource1
      Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgRowSelect, dgAlwaysShowSelection, dgConfirmDelete, dgCancelOnExit]
      TabOrder = 1
      TitleFont.Charset = DEFAULT_CHARSET
      TitleFont.Color = clWindowText
      TitleFont.Height = -11
      TitleFont.Name = 'Tahoma'
      TitleFont.Style = []
      Columns = <
        item
          Alignment = taCenter
          Expanded = False
          FieldName = 'cg_rota'
          Title.Alignment = taCenter
          Title.Caption = 'Rota'
          Width = 70
          Visible = True
        end
        item
          Alignment = taCenter
          Expanded = False
          FieldName = 'cg_data_vencto'
          Title.Alignment = taCenter
          Title.Caption = 'Vencimento'
          Width = 80
          Visible = True
        end
        item
          Alignment = taCenter
          Expanded = False
          FieldName = 'Ligacoes'
          Title.Alignment = taCenter
          Title.Caption = 'Liga'#231#245'es'
          Width = 80
          Visible = True
        end>
    end
    object EdReferencia: TEdit
      Left = 87
      Top = 52
      Width = 90
      Height = 21
      ReadOnly = True
      TabOrder = 2
    end
  end
  object qryGrupo: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select '#9'rt_grupo'
      'from'#9'roteiros'
      'group '#9'by rt_grupo'
      'order'#9'by rt_grupo'
      '')
    Left = 152
    Top = 48
  end
  object qryRoteiro: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      
        'select '#9'cg_rota, cg_referencia, cg_data_vencto, count(*) as Liga' +
        'coes'
      'from '#9'carga'
      'where'#9'cg_grupo = :nGrupo'
      'group'#9'by cg_rota, cg_referencia, cg_data_vencto'
      'order'#9'by cg_rota, cg_data_vencto')
    Left = 192
    Top = 48
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end>
  end
  object DataSource1: TDataSource
    DataSet = qryRoteiro
    OnDataChange = DataSource1DataChange
    Left = 224
    Top = 48
  end
end
