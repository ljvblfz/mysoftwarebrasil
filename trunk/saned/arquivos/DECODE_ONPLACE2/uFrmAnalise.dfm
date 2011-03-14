inherited frmAnalise: TfrmAnalise
  Caption = 'frmAnalise'
  ClientHeight = 444
  ClientWidth = 777
  ExplicitWidth = 783
  ExplicitHeight = 476
  PixelsPerInch = 96
  TextHeight = 13
  inherited pTop: TPanel
    Width = 777
    ExplicitWidth = 777
    inherited lVersion: TLabel
      Left = 702
      Height = 26
      ExplicitLeft = 702
    end
  end
  inherited pBottom: TPanel
    Left = 487
    Top = 400
    Width = 289
    Align = alNone
    ExplicitLeft = 487
    ExplicitTop = 400
    ExplicitWidth = 289
    inherited sbtnSair: TSpeedButton
      Left = 170
      Width = 90
      ExplicitLeft = 156
      ExplicitWidth = 90
    end
    object sbtnCalcular: TSpeedButton
      Left = 43
      Top = 8
      Width = 90
      Height = 25
      Anchors = [akTop, akRight, akBottom]
      Caption = 'Cal&cular'
      Enabled = False
      Flat = True
      Glyph.Data = {
        76010000424D7601000000000000760000002800000020000000100000000100
        04000000000000010000120B0000120B00001000000000000000000000000000
        800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00337000000000
        73333337777777773F333308888888880333337F3F3F3FFF7F33330808089998
        0333337F737377737F333308888888880333337F3F3F3F3F7F33330808080808
        0333337F737373737F333308888888880333337F3F3F3F3F7F33330808080808
        0333337F737373737F333308888888880333337F3F3F3F3F7F33330808080808
        0333337F737373737F333308888888880333337F3FFFFFFF7F33330800000008
        0333337F7777777F7F333308000E0E080333337F7FFFFF7F7F33330800000008
        0333337F777777737F333308888888880333337F333333337F33330888888888
        03333373FFFFFFFF733333700000000073333337777777773333}
      NumGlyphs = 2
      OnClick = sbtnCalcularClick
      ExplicitLeft = 29
    end
    object btCalcular: TButton
      Left = 10
      Top = 7
      Width = 27
      Height = 25
      Caption = 'x'
      Enabled = False
      TabOrder = 0
      Visible = False
      OnClick = btCalcularClick
    end
  end
  object PSelecao: TPanel
    Left = 0
    Top = 40
    Width = 201
    Height = 172
    BevelInner = bvRaised
    BevelOuter = bvNone
    BorderStyle = bsSingle
    TabOrder = 2
    object Shape1: TShape
      Left = 1
      Top = 1
      Width = 195
      Height = 166
      Align = alClient
      Brush.Color = clBtnFace
      Pen.Width = 2
      ExplicitLeft = 32
      ExplicitTop = 0
      ExplicitWidth = 183
      ExplicitHeight = 173
    end
    object Label1: TLabel
      Left = 16
      Top = 16
      Width = 33
      Height = 13
      Caption = 'Grupo:'
    end
    object Label2: TLabel
      Left = 16
      Top = 36
      Width = 27
      Height = 13
      Caption = 'Rota:'
    end
    object LInf: TLabel
      Left = 16
      Top = 83
      Width = 164
      Height = 15
      Alignment = taRightJustify
      AutoSize = False
    end
    object Label3: TLabel
      Left = 16
      Top = 98
      Width = 53
      Height = 13
      Caption = 'Sequ'#234'ncia:'
    end
    object Label4: TLabel
      Left = 101
      Top = 98
      Width = 25
      Height = 13
      Caption = 'CDC:'
    end
    object DBTTipoLigacao: TDBText
      Left = 16
      Top = 142
      Width = 166
      Height = 17
      Alignment = taCenter
      DataField = 'tb_descricao'
      DataSource = dmAnalise.dsAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object cmbGrupo: TComboBox
      Left = 77
      Top = 10
      Width = 105
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      Sorted = True
      TabOrder = 0
      OnDropDown = cmbGrupoDropDown
    end
    object cmbRota: TComboBox
      Left = 77
      Top = 33
      Width = 105
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      Sorted = True
      TabOrder = 1
      OnChange = cmbRotaChange
      OnDropDown = cmbRotaDropDown
    end
    object DBNavigador: TDBNavigator
      Left = 16
      Top = 55
      Width = 164
      Height = 25
      DataSource = dmAnalise.dsAnalise
      VisibleButtons = [nbFirst, nbPrior, nbNext, nbLast]
      Hints.Strings = (
        'Primeiro registro'
        'Registro anterior'
        'Pr'#243'ximo registro'
        #218'ltimo registro'
        'Inserir registro'
        'Apagar registro'
        'Editar registro'
        'Salvar edi'#231#227'o'
        'Cancelar edi'#231#227'o'
        'Atualizar')
      ParentShowHint = False
      ShowHint = True
      TabOrder = 2
    end
    object EdSequencia: TEdit
      Left = 16
      Top = 115
      Width = 79
      Height = 21
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 3
      OnExit = DBESequenciaExit
      OnKeyPress = EdSequenciaKeyPress
    end
    object EdMatricula: TEdit
      Left = 101
      Top = 115
      Width = 81
      Height = 21
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 4
      OnExit = DBESequenciaExit
      OnKeyPress = EdMatriculaKeyPress
    end
  end
  object GroupBox1: TGroupBox
    Left = 1
    Top = 214
    Width = 200
    Height = 226
    Caption = 'CDC'#39's Relacionados'
    TabOrder = 3
    object DBTNome: TDBText
      Left = 15
      Top = 120
      Width = 166
      Height = 15
      DataField = 'cg_nome'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -9
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object DBTEndereco: TDBText
      Left = 15
      Top = 135
      Width = 166
      Height = 15
      DataField = 'endereco'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -9
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object DBTComplemento: TDBText
      Left = 15
      Top = 150
      Width = 166
      Height = 15
      DataField = 'cg_complemento'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -9
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object DBTStatus: TDBText
      Left = 15
      Top = 206
      Width = 166
      Height = 17
      DataField = 'descricao_status'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object DBTCategoria: TDBText
      Left = 15
      Top = 165
      Width = 166
      Height = 15
      DataField = 'descricao_categoria'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -9
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object DBTNatureza: TDBText
      Left = 15
      Top = 180
      Width = 166
      Height = 15
      DataField = 'descricao_natureza_ligacao'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -9
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object DBGrid1: TDBGrid
      Left = 15
      Top = 18
      Width = 166
      Height = 96
      DataSource = DSCliAnalise
      Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgRowSelect, dgAlwaysShowSelection, dgConfirmDelete, dgCancelOnExit]
      TabOrder = 0
      TitleFont.Charset = DEFAULT_CHARSET
      TitleFont.Color = clWindowText
      TitleFont.Height = -11
      TitleFont.Name = 'Tahoma'
      TitleFont.Style = []
      Columns = <
        item
          Alignment = taCenter
          Expanded = False
          FieldName = 'cg_matricula'
          ReadOnly = True
          Title.Alignment = taCenter
          Title.Caption = 'CDC'
          Width = 131
          Visible = True
        end>
    end
  end
  object v: TGroupBox
    Left = 207
    Top = 40
    Width = 274
    Height = 400
    Caption = 'Dados do CDC Selecionado'
    TabOrder = 4
    object Label5: TLabel
      Left = 16
      Top = 258
      Width = 57
      Height = 13
      Caption = 'Hidr'#244'metro:'
    end
    object Shape3: TShape
      Left = 3
      Top = 151
      Width = 268
      Height = 1
      Brush.Color = clBtnFace
    end
    object Label6: TLabel
      Left = 24
      Top = 158
      Width = 22
      Height = 13
      Caption = 'Res.'
    end
    object Label7: TLabel
      Left = 153
      Top = 158
      Width = 25
      Height = 13
      Caption = 'Com.'
    end
    object Label8: TLabel
      Left = 115
      Top = 158
      Width = 20
      Height = 13
      Caption = 'Ind.'
    end
    object Label9: TLabel
      Left = 199
      Top = 158
      Width = 22
      Height = 13
      Caption = 'P'#250'b.'
    end
    object Label10: TLabel
      Left = 70
      Top = 158
      Width = 21
      Height = 13
      Caption = 'Soc.'
    end
    object Label11: TLabel
      Left = 231
      Top = 158
      Width = 32
      Height = 13
      Caption = 'Assist.'
    end
    object Shape4: TShape
      Left = 3
      Top = 201
      Width = 268
      Height = 1
      Brush.Color = clBtnFace
    end
    object Shape5: TShape
      Left = 3
      Top = 250
      Width = 268
      Height = 1
      Brush.Color = clBtnFace
    end
    object Label12: TLabel
      Left = 16
      Top = 208
      Width = 32
      Height = 13
      Caption = 'M'#233'dia:'
    end
    object Label13: TLabel
      Left = 96
      Top = 208
      Width = 78
      Height = 13
      Caption = 'Leitura anterior:'
    end
    object Label14: TLabel
      Left = 185
      Top = 208
      Width = 27
      Height = 13
      Caption = 'Data:'
    end
    object Label15: TLabel
      Left = 16
      Top = 285
      Width = 54
      Height = 13
      Caption = 'Instala'#231#227'o:'
    end
    object Label17: TLabel
      Left = 167
      Top = 354
      Width = 28
      Height = 13
      Caption = 'atual:'
    end
    object Label18: TLabel
      Left = 215
      Top = 354
      Width = 42
      Height = 13
      Caption = 'anterior:'
    end
    object Label23: TLabel
      Left = 167
      Top = 338
      Width = 92
      Height = 13
      Caption = 'Dias Bloqueio tarifa'
    end
    object Label24: TLabel
      Left = 8
      Top = 352
      Width = 40
      Height = 13
      Caption = 'Bloqueio'
    end
    object Label25: TLabel
      Left = 86
      Top = 352
      Width = 58
      Height = 13
      Caption = 'Desbloqueio'
    end
    object DBGrid2: TDBGrid
      Left = 0
      Top = 14
      Width = 262
      Height = 131
      DataSource = dmAnalise.DSHistoricoConsumo
      Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgConfirmDelete, dgCancelOnExit]
      TabOrder = 0
      TitleFont.Charset = DEFAULT_CHARSET
      TitleFont.Color = clWindowText
      TitleFont.Height = -11
      TitleFont.Name = 'Tahoma'
      TitleFont.Style = []
      Columns = <
        item
          Alignment = taCenter
          Expanded = False
          FieldName = 'hc_ref_historico'
          Title.Alignment = taCenter
          Title.Caption = 'Refer'#234'ncia'
          Width = 59
          Visible = True
        end
        item
          Expanded = False
          FieldName = 'hc_consumo'
          Title.Alignment = taCenter
          Title.Caption = 'Consumo'
          Width = 50
          Visible = True
        end
        item
          Alignment = taCenter
          Expanded = False
          FieldName = 'hc_ocorrencia_leitura'
          Title.Alignment = taCenter
          Title.Caption = ' '
          Width = 23
          Visible = True
        end
        item
          Expanded = False
          FieldName = 'hc_leitura'
          Title.Alignment = taCenter
          Title.Caption = 'Ajustada'
          Width = 47
          Visible = True
        end
        item
          Expanded = False
          FieldName = 'hc_leitura_real'
          Title.Alignment = taCenter
          Title.Caption = 'Real'
          Width = 47
          Visible = True
        end>
    end
    object DBEHidrometro: TDBEdit
      Left = 85
      Top = 255
      Width = 124
      Height = 21
      DataField = 'cg_numero_hd'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
    end
    object DBEDigitoHD: TDBEdit
      Left = 217
      Top = 255
      Width = 43
      Height = 21
      DataField = 'cg_capacidade_hidrometro'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 2
    end
    object DBEEcoRes: TDBEdit
      Left = 8
      Top = 174
      Width = 38
      Height = 21
      DataField = 'cg_economia_res'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 3
    end
    object DBEEcoCom: TDBEdit
      Left = 140
      Top = 174
      Width = 38
      Height = 21
      DataField = 'cg_economia_com'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 4
    end
    object DBEEcoInd: TDBEdit
      Left = 97
      Top = 174
      Width = 38
      Height = 21
      DataField = 'cg_economia_ind'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 5
    end
    object DBEEcoPub: TDBEdit
      Left = 183
      Top = 174
      Width = 38
      Height = 21
      DataField = 'cg_economia_pub'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 6
    end
    object DBEEcoSoc: TDBEdit
      Left = 53
      Top = 174
      Width = 38
      Height = 21
      DataField = 'cg_economia_soc'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 7
    end
    object DBEEcoEA: TDBEdit
      Left = 225
      Top = 174
      Width = 38
      Height = 21
      DataField = 'cg_economia_ea'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 8
    end
    object DBEConsumoMedio: TDBEdit
      Left = 8
      Top = 225
      Width = 75
      Height = 21
      DataField = 'cg_consumo_medio'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 9
    end
    object DBELeituraAnt: TDBEdit
      Left = 96
      Top = 225
      Width = 75
      Height = 21
      DataField = 'cg_leitura_ant'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 10
    end
    object DBEDataLeituraAnt: TDBEdit
      Left = 184
      Top = 225
      Width = 76
      Height = 21
      DataField = 'cg_data_leit_ant'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 11
    end
    object DBEDataInstalacao: TDBEdit
      Left = 85
      Top = 282
      Width = 84
      Height = 21
      DataField = 'cg_data_instalacao_hd'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 12
    end
    object DBELeituraInst: TDBEdit
      Left = 175
      Top = 282
      Width = 85
      Height = 21
      DataField = 'cg_leitura_inicial'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 13
    end
    object DBEDiasBloqueioAtual: TDBEdit
      Left = 167
      Top = 371
      Width = 45
      Height = 21
      DataField = 'cg_dias_bloqueio_tarifa_atual'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 14
    end
    object DBEDiasBloqueioAnt: TDBEdit
      Left = 215
      Top = 371
      Width = 45
      Height = 21
      DataField = 'cg_dias_bloqueio_tarifa_ant'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 15
    end
    object DBEBoqueado: TDBEdit
      Left = 8
      Top = 313
      Width = 252
      Height = 21
      DataField = 'desc_bloqueado'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 16
    end
    object DBEDataBloqueio: TDBEdit
      Left = 8
      Top = 371
      Width = 75
      Height = 21
      DataField = 'cg_data_bloqueio'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 17
    end
    object DBEDataDesbloqueio: TDBEdit
      Left = 86
      Top = 371
      Width = 75
      Height = 21
      DataField = 'cg_data_desbloqueio'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 18
    end
  end
  object GroupBox2: TGroupBox
    Left = 487
    Top = 39
    Width = 289
    Height = 186
    Caption = 'Dados para c'#225'lculo'
    TabOrder = 5
    object Label16: TLabel
      Left = 12
      Top = 41
      Width = 78
      Height = 13
      Caption = 'Data da Leitura:'
    end
    object Label19: TLabel
      Left = 12
      Top = 95
      Width = 65
      Height = 13
      Caption = 'Leitura Atual:'
    end
    object Label20: TLabel
      Left = 12
      Top = 68
      Width = 71
      Height = 13
      Caption = 'Dias Consumo:'
    end
    object DBTDescOcorrencia: TDBText
      Left = 12
      Top = 116
      Width = 261
      Height = 15
      DataField = 'oc_descricao'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -9
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Label21: TLabel
      Left = 12
      Top = 140
      Width = 85
      Height = 13
      Caption = 'Consumo Medido:'
    end
    object Label22: TLabel
      Left = 12
      Top = 164
      Width = 94
      Height = 13
      Caption = 'Consumo Ajustado:'
    end
    object DBEDataLeitura: TDBEdit
      Left = 128
      Top = 39
      Width = 89
      Height = 21
      HelpType = htKeyword
      DataField = 'dg_data_leitura'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 0
    end
    object DBELeituraAtual: TDBEdit
      Left = 128
      Top = 93
      Width = 89
      Height = 21
      DataField = 'dg_leitura_real'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 1
    end
    object DBEOcorrencia: TDBEdit
      Left = 223
      Top = 93
      Width = 50
      Height = 21
      DataField = 'dg_ocorrencia'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 2
    end
    object EdVariacao: TEdit
      Left = 8
      Top = 14
      Width = 265
      Height = 21
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clRed
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      ReadOnly = True
      TabOrder = 3
    end
    object DBEDiasConsumo: TDBEdit
      Left = 128
      Top = 66
      Width = 89
      Height = 21
      DataField = 'dg_dias_consumo'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 4
    end
    object DBEConsumoMedido: TDBEdit
      Left = 128
      Top = 138
      Width = 88
      Height = 21
      DataField = 'dg_consumo_medido'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 5
    end
    object DBEConsumoAjustado: TDBEdit
      Left = 128
      Top = 162
      Width = 88
      Height = 21
      DataField = 'dg_consumo_ajustado'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 6
    end
    object ckbAjustar: TCheckBox
      Left = 223
      Top = 70
      Width = 58
      Height = 17
      Caption = 'Ajustar'
      Checked = True
      State = cbChecked
      TabOrder = 7
    end
  end
  object PCalcular: TPanel
    Left = 487
    Top = 231
    Width = 289
    Height = 163
    BevelInner = bvLowered
    BevelOuter = bvNone
    BorderStyle = bsSingle
    Enabled = False
    TabOrder = 6
    object Shape2: TShape
      Left = 1
      Top = 1
      Width = 283
      Height = 157
      Align = alClient
      Brush.Color = clBtnFace
      Pen.Width = 2
      ExplicitLeft = -3
      ExplicitTop = 0
    end
    object Shape6: TShape
      Left = 7
      Top = 104
      Width = 271
      Height = 1
      Brush.Color = clBtnFace
    end
    object Label26: TLabel
      Left = 23
      Top = 111
      Width = 48
      Height = 13
      Caption = 'Consumo:'
    end
    object Label27: TLabel
      Left = 143
      Top = 111
      Width = 47
      Height = 13
      Caption = 'Ajustado:'
    end
    object EdAnormalidade: TEdit
      Left = 191
      Top = 111
      Width = 74
      Height = 21
      ReadOnly = True
      TabOrder = 12
      Visible = False
    end
    object EdLeituraAjustada: TEdit
      Left = 167
      Top = 122
      Width = 90
      Height = 21
      ReadOnly = True
      TabOrder = 11
      Visible = False
    end
    object EdLeituraReal: TEdit
      Left = 47
      Top = 122
      Width = 90
      Height = 21
      ReadOnly = True
      TabOrder = 10
      Visible = False
    end
    object rbtConfirma: TRadioButton
      Left = 16
      Top = 16
      Width = 105
      Height = 17
      Caption = 'Confirmar Leitura'
      TabOrder = 0
      OnClick = rbtAnormalidadeClick
    end
    object rbtNovaLeitura: TRadioButton
      Left = 16
      Top = 39
      Width = 105
      Height = 17
      Caption = 'Nova Leitura'
      TabOrder = 1
      OnClick = rbtAnormalidadeClick
    end
    object rbtAnormalidade: TRadioButton
      Left = 16
      Top = 62
      Width = 105
      Height = 17
      Caption = 'Anormalidade'
      TabOrder = 2
      OnClick = rbtAnormalidadeClick
    end
    object chbSemSolucao: TCheckBox
      Left = 16
      Top = 85
      Width = 97
      Height = 17
      Caption = 'N'#227'o Faturar'
      TabOrder = 3
    end
    object chbManterLeitura: TCheckBox
      Left = 127
      Top = 85
      Width = 97
      Height = 17
      Caption = 'Manter leitura'
      TabOrder = 4
      OnClick = chbManterLeituraClick
    end
    object EdNovaLeitura: TEdit
      Left = 127
      Top = 35
      Width = 90
      Height = 21
      TabOrder = 6
      OnExit = EdNovaLeituraExit
      OnKeyPress = EdNovaLeituraKeyPress
    end
    object DBELeituraRealConfirmada: TDBEdit
      Left = 127
      Top = 12
      Width = 90
      Height = 21
      DataField = 'dg_leitura_real'
      DataSource = DSCliAnalise
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 5
    end
    object cmbAnormalidade: TComboBox
      Left = 127
      Top = 58
      Width = 145
      Height = 21
      ItemHeight = 13
      TabOrder = 7
      OnChange = EdNovaLeituraExit
    end
    object EdConsumo: TEdit
      Left = 23
      Top = 130
      Width = 90
      Height = 21
      ReadOnly = True
      TabOrder = 8
    end
    object EdConsumoAjustado: TEdit
      Left = 143
      Top = 130
      Width = 90
      Height = 21
      ReadOnly = True
      TabOrder = 9
    end
  end
  object DSCliAnalise: TDataSource
    DataSet = dmAnalise.qryCDCAnalise
    OnDataChange = DSCliAnaliseDataChange
    Left = 216
    Top = 144
  end
  object DSAnalise: TDataSource
    DataSet = dmAnalise.qryAnalise
    OnDataChange = DSAnaliseDataChange
    Left = 216
    Top = 104
  end
end
