inherited frmRelatorioOcorrencia: TfrmRelatorioOcorrencia
  Caption = ''
  ClientWidth = 450
  ExplicitWidth = 456
  ExplicitHeight = 295
  PixelsPerInch = 96
  TextHeight = 13
  inherited pTop: TPanel
    Width = 450
    ExplicitWidth = 450
    inherited lVersion: TLabel
      Left = 375
      Height = 26
      ExplicitLeft = 375
    end
  end
  inherited pBottom: TPanel
    Width = 450
    ExplicitWidth = 450
    inherited sbtnSair: TSpeedButton
      Left = 333
      Width = 108
      ExplicitLeft = 309
      ExplicitWidth = 108
    end
    object sbtnImprimir: TSpeedButton
      Left = 8
      Top = 8
      Width = 111
      Height = 25
      Caption = 'Imprimir'
      Flat = True
      Glyph.Data = {
        76010000424D7601000000000000760000002800000020000000100000000100
        04000000000000010000120B0000120B00001000000000000000000000000000
        800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00300000000000
        0003377777777777777308888888888888807F33333333333337088888888888
        88807FFFFFFFFFFFFFF7000000000000000077777777777777770F8F8F8F8F8F
        8F807F333333333333F708F8F8F8F8F8F9F07F333333333337370F8F8F8F8F8F
        8F807FFFFFFFFFFFFFF7000000000000000077777777777777773330FFFFFFFF
        03333337F3FFFF3F7F333330F0000F0F03333337F77773737F333330FFFFFFFF
        03333337F3FF3FFF7F333330F00F000003333337F773777773333330FFFF0FF0
        33333337F3F37F3733333330F08F0F0333333337F7337F7333333330FFFF0033
        33333337FFFF7733333333300000033333333337777773333333}
      NumGlyphs = 2
      OnClick = sbtnImprimirClick
    end
  end
  object GroupBox1: TGroupBox
    Left = 0
    Top = 40
    Width = 450
    Height = 177
    Align = alTop
    TabOrder = 2
    object LGrupo: TLabel
      Left = 37
      Top = 40
      Width = 33
      Height = 13
      Caption = 'Grupo:'
    end
    object LRota: TLabel
      Left = 37
      Top = 72
      Width = 27
      Height = 13
      Caption = 'Rota:'
    end
    object Label1: TLabel
      Left = 204
      Top = 72
      Width = 16
      Height = 13
      Caption = 'at'#233
    end
    object Label2: TLabel
      Left = 37
      Top = 122
      Width = 56
      Height = 13
      Caption = 'Ocorr'#234'ncia:'
    end
    object cmbGrupo: TComboBox
      Left = 100
      Top = 37
      Width = 89
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      TabOrder = 0
      OnChange = cmbGrupoChange
      OnDropDown = cmbGrupoDropDown
    end
    object cmbRota: TComboBox
      Left = 100
      Top = 69
      Width = 89
      Height = 21
      Style = csDropDownList
      Enabled = False
      ItemHeight = 13
      TabOrder = 1
    end
    object ckbTodos: TCheckBox
      Left = 100
      Top = 96
      Width = 173
      Height = 17
      Caption = 'Todos as rotas'
      Checked = True
      State = cbChecked
      TabOrder = 2
      OnClick = ckbTodosClick
    end
    object cmbRotaFim: TComboBox
      Left = 232
      Top = 69
      Width = 89
      Height = 21
      Style = csDropDownList
      Enabled = False
      ItemHeight = 13
      TabOrder = 3
    end
    object cmbOcorrencia: TComboBox
      Left = 99
      Top = 119
      Width = 318
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      TabOrder = 4
    end
  end
  object qryGrupo: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'#9'rt_grupo as grupo'
      'from'#9'roteiros'
      'where'#9'rt_ind_leitura >= 3'
      'group by'#9'rt_grupo')
    Left = 380
    Top = 78
  end
  object qryRota: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'#9'rt_rota as rota'
      'from'#9'roteiros'
      'where'#9'rt_grupo = :nGrupo'
      'and '#9'rt_ind_leitura >= 3'
      'group by'#9'rt_rota')
    Left = 380
    Top = 110
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end>
  end
  object qryOcorrencia: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      
        'select '#9'rtrim(oc_descricao) + '#39' '#183' '#39' + rtrim(convert(char, oc_cod' +
        'igo)) as Descricao'
      'from '#9'ocorrencias'
      
        'group by '#9'rtrim(oc_descricao) + '#39' '#183' '#39' + rtrim(convert(char, oc_c' +
        'odigo))'
      'order by 1')
    Left = 380
    Top = 142
  end
end
