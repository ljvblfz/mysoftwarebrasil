inherited frmDadosCliente: TfrmDadosCliente
  Caption = 'frmDadosCliente'
  ClientHeight = 463
  ClientWidth = 640
  ExplicitWidth = 646
  ExplicitHeight = 495
  PixelsPerInch = 96
  TextHeight = 13
  object Label29: TLabel [0]
    Left = 15
    Top = 16
    Width = 59
    Height = 13
    Caption = 'Vencimento:'
  end
  object DBText1: TDBText [1]
    Left = 101
    Top = 18
    Width = 81
    Height = 14
    DataField = 'cg_data_vencto'
    DataSource = DSCDC
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -9
    Font.Name = 'Tahoma'
    Font.Style = [fsBold]
    ParentFont = False
  end
  inherited pTop: TPanel
    Width = 640
    ExplicitWidth = 640
    inherited lVersion: TLabel
      Left = 565
      Height = 26
      ExplicitLeft = 565
    end
  end
  inherited pBottom: TPanel
    Top = 423
    Width = 640
    ExplicitTop = 423
    ExplicitWidth = 640
    inherited sbtnSair: TSpeedButton
      Left = 554
      ExplicitLeft = 664
    end
  end
  object GroupBox1: TGroupBox
    Left = 0
    Top = 40
    Width = 640
    Height = 383
    Align = alClient
    TabOrder = 2
    object PSelecao: TPanel
      Left = 0
      Top = 6
      Width = 249
      Height = 183
      BevelInner = bvRaised
      BevelOuter = bvNone
      BorderStyle = bsSingle
      TabOrder = 0
      object Shape1: TShape
        Left = 1
        Top = 1
        Width = 243
        Height = 177
        Align = alClient
        Brush.Color = clBtnFace
        Pen.Width = 2
        ExplicitLeft = 0
        ExplicitTop = -34
        ExplicitWidth = 195
        ExplicitHeight = 166
      end
      object Label1: TLabel
        Left = 16
        Top = 15
        Width = 33
        Height = 13
        Caption = 'Grupo:'
      end
      object Label2: TLabel
        Left = 16
        Top = 40
        Width = 27
        Height = 13
        Caption = 'Rota:'
      end
      object Label4: TLabel
        Left = 18
        Top = 65
        Width = 25
        Height = 13
        Caption = 'CDC:'
      end
      object Label3: TLabel
        Left = 16
        Top = 90
        Width = 53
        Height = 13
        Caption = 'Sequ'#234'ncia:'
      end
      object sbtPesquisa: TSpeedButton
        Left = 197
        Top = 12
        Width = 33
        Height = 121
        Flat = True
        Glyph.Data = {
          76010000424D7601000000000000760000002800000020000000100000000100
          04000000000000010000130B0000130B00001000000000000000000000000000
          800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
          FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00333333333333
          333333333333333333FF33333333333330003FF3FFFFF3333777003000003333
          300077F777773F333777E00BFBFB033333337773333F7F33333FE0BFBF000333
          330077F3337773F33377E0FBFBFBF033330077F3333FF7FFF377E0BFBF000000
          333377F3337777773F3FE0FBFBFBFBFB039977F33FFFFFFF7377E0BF00000000
          339977FF777777773377000BFB03333333337773FF733333333F333000333333
          3300333777333333337733333333333333003333333333333377333333333333
          333333333333333333FF33333333333330003333333333333777333333333333
          3000333333333333377733333333333333333333333333333333}
        NumGlyphs = 2
        OnClick = sbtPesquisaClick
      end
      object Label81: TLabel
        Left = 16
        Top = 115
        Width = 61
        Height = 13
        Caption = 'C'#243'd. Barras:'
      end
      object cmbGrupo: TComboBox
        Left = 80
        Top = 12
        Width = 105
        Height = 21
        Style = csDropDownList
        ItemHeight = 13
        Sorted = True
        TabOrder = 0
        OnChange = cmbGrupoChange
        OnDropDown = cmbGrupoDropDown
      end
      object cmbRota: TComboBox
        Left = 80
        Top = 37
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
        Left = 80
        Top = 139
        Width = 104
        Height = 25
        DataSource = DSPrincipal
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
      object EdMatricula: TEdit
        Left = 80
        Top = 62
        Width = 105
        Height = 21
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'Tahoma'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 3
        OnChange = EdMatriculaChange
        OnKeyPress = EdMatriculaKeyPress
      end
      object EdSequencia: TEdit
        Left = 80
        Top = 87
        Width = 105
        Height = 21
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'Tahoma'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 4
        OnChange = EdSequenciaChange
        OnKeyPress = EdMatriculaKeyPress
      end
      object EdCodigoBarras: TEdit
        Left = 80
        Top = 112
        Width = 105
        Height = 21
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'Tahoma'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 5
        OnChange = EdCodigoBarrasChange
        OnKeyPress = EdMatriculaKeyPress
      end
    end
    object GroupBox3: TGroupBox
      Left = 3
      Top = 191
      Width = 246
      Height = 183
      Caption = 'CDC'#39's Relacionados'
      TabOrder = 1
      object DBGrid1: TDBGrid
        Left = 15
        Top = 21
        Width = 212
        Height = 151
        DataSource = DSCDC
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
            Width = 90
            Visible = True
          end
          item
            Alignment = taCenter
            Expanded = False
            FieldName = 'desc_tipo_cdc'
            Title.Alignment = taCenter
            Title.Caption = ' '
            Width = 84
            Visible = True
          end>
      end
    end
    object PCMatricula: TPageControl
      Left = 250
      Top = 6
      Width = 385
      Height = 368
      ActivePage = tbsAdicional
      MultiLine = True
      TabOrder = 2
      object tbsDados: TTabSheet
        Caption = 'Dados'
        object GroupBox4: TGroupBox
          Left = 0
          Top = 0
          Width = 377
          Height = 322
          Align = alClient
          TabOrder = 0
          object Bevel2: TBevel
            Left = 3
            Top = 170
            Width = 335
            Height = 34
          end
          object Bevel1: TBevel
            Left = 3
            Top = 11
            Width = 335
            Height = 65
          end
          object DBTNome: TDBText
            Left = 12
            Top = 82
            Width = 318
            Height = 15
            DataField = 'cg_nome'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBTEndereco: TDBText
            Left = 12
            Top = 98
            Width = 318
            Height = 15
            DataField = 'endereco'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBTComplemento: TDBText
            Left = 12
            Top = 113
            Width = 170
            Height = 15
            DataField = 'cg_complemento'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBTCategoria: TDBText
            Left = 12
            Top = 129
            Width = 170
            Height = 15
            DataField = 'descricao_categoria'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBTIdentificar: TDBText
            Left = 169
            Top = 113
            Width = 166
            Height = 15
            DataField = 'descricao_ident_consumidor'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBTNatureza: TDBText
            Left = 169
            Top = 129
            Width = 166
            Height = 15
            DataField = 'descricao_natureza_ligacao'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label5: TLabel
            Left = 12
            Top = 19
            Width = 33
            Height = 13
            Caption = 'Grupo:'
          end
          object DBTGrupo: TDBText
            Left = 51
            Top = 21
            Width = 30
            Height = 15
            DataField = 'cg_grupo'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label6: TLabel
            Left = 87
            Top = 19
            Width = 27
            Height = 13
            Caption = 'Rota:'
          end
          object DBTRota: TDBText
            Left = 120
            Top = 21
            Width = 49
            Height = 15
            DataField = 'cg_rota'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label7: TLabel
            Left = 169
            Top = 19
            Width = 53
            Height = 13
            Caption = 'Seq'#252#234'ncia:'
          end
          object DBTSequencia: TDBText
            Left = 225
            Top = 21
            Width = 110
            Height = 15
            DataField = 'cg_sequencia'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBTHidrometro: TDBText
            Left = 12
            Top = 145
            Width = 115
            Height = 15
            DataField = 'cg_numero_hd'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBTCapacidadeHD: TDBText
            Left = 133
            Top = 145
            Width = 30
            Height = 15
            DataField = 'cg_capacidade_hidrometro'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label8: TLabel
            Left = 12
            Top = 57
            Width = 47
            Height = 13
            Caption = 'Inscri'#231#227'o:'
          end
          object DBTInscricao: TDBText
            Left = 87
            Top = 60
            Width = 234
            Height = 15
            DataField = 'cg_inscricao'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label9: TLabel
            Left = 31
            Top = 172
            Width = 40
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'Res.'
          end
          object DBTEcoRes: TDBText
            Left = 31
            Top = 188
            Width = 40
            Height = 15
            Alignment = taRightJustify
            DataField = 'cg_economia_res'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBTEcoSoc: TDBText
            Left = 77
            Top = 188
            Width = 40
            Height = 15
            Alignment = taRightJustify
            DataField = 'cg_economia_soc'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label12: TLabel
            Left = 77
            Top = 172
            Width = 40
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'Soc.'
          end
          object Label10: TLabel
            Left = 123
            Top = 172
            Width = 40
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'Ind.'
          end
          object DBTEcoInd: TDBText
            Left = 123
            Top = 188
            Width = 40
            Height = 15
            Alignment = taRightJustify
            DataField = 'cg_economia_ind'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBTEcoCom: TDBText
            Left = 169
            Top = 188
            Width = 40
            Height = 15
            Alignment = taRightJustify
            DataField = 'cg_economia_com'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label11: TLabel
            Left = 169
            Top = 172
            Width = 40
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'Com.'
          end
          object Label13: TLabel
            Left = 213
            Top = 172
            Width = 40
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'P'#250'b.'
          end
          object DBTEcoPub: TDBText
            Left = 213
            Top = 188
            Width = 40
            Height = 15
            Alignment = taRightJustify
            DataField = 'cg_economia_pub'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBTEcoEA: TDBText
            Left = 259
            Top = 188
            Width = 40
            Height = 15
            Alignment = taRightJustify
            DataField = 'cg_economia_ea'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label14: TLabel
            Left = 259
            Top = 172
            Width = 40
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'Assist.'
          end
          object Label16: TLabel
            Left = 12
            Top = 38
            Width = 56
            Height = 13
            Caption = 'Refer'#234'ncia:'
          end
          object DBTReferencia: TDBText
            Left = 87
            Top = 40
            Width = 76
            Height = 14
            DataField = 'cg_referencia'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label19: TLabel
            Left = 169
            Top = 38
            Width = 30
            Height = 13
            Caption = 'Setor:'
          end
          object DBTSetor: TDBText
            Left = 225
            Top = 40
            Width = 110
            Height = 15
            DataField = 'cg_setor'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object GroupBox7: TGroupBox
            Left = 3
            Top = 216
            Width = 335
            Height = 77
            Caption = 'Bloqueio'
            TabOrder = 0
            object Bevel3: TBevel
              Left = 176
              Top = 12
              Width = 154
              Height = 60
            end
            object DBTDescBloqueio: TDBText
              Left = 9
              Top = 19
              Width = 154
              Height = 15
              DataField = 'desc_bloqueado'
              DataSource = DSCDC
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -9
              Font.Name = 'Tahoma'
              Font.Style = [fsBold]
              ParentFont = False
            end
            object Label25: TLabel
              Left = 9
              Top = 38
              Width = 44
              Height = 13
              Caption = 'Bloqueio:'
            end
            object DBTDataBloqueio: TDBText
              Left = 77
              Top = 40
              Width = 86
              Height = 15
              DataField = 'cg_data_bloqueio'
              DataSource = DSCDC
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -9
              Font.Name = 'Tahoma'
              Font.Style = [fsBold]
              ParentFont = False
            end
            object Label26: TLabel
              Left = 185
              Top = 38
              Width = 49
              Height = 13
              Caption = '- anterior:'
            end
            object DBTDataDesbloqueio: TDBText
              Left = 77
              Top = 59
              Width = 86
              Height = 15
              DataField = 'cg_data_desbloqueio'
              DataSource = DSCDC
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -9
              Font.Name = 'Tahoma'
              Font.Style = [fsBold]
              ParentFont = False
            end
            object Label24: TLabel
              Left = 9
              Top = 57
              Width = 62
              Height = 13
              Caption = 'Desbloqueio:'
            end
            object Label27: TLabel
              Left = 185
              Top = 57
              Width = 35
              Height = 13
              Caption = '- atual:'
            end
            object Label28: TLabel
              Left = 185
              Top = 19
              Width = 126
              Height = 13
              Caption = 'Dias de Bloqueio na tarifa:'
            end
            object DBTDiasBloqAnt: TDBText
              Left = 243
              Top = 40
              Width = 40
              Height = 15
              Alignment = taRightJustify
              DataField = 'cg_dias_bloqueio_tarifa_ant'
              DataSource = DSCDC
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -9
              Font.Name = 'Tahoma'
              Font.Style = [fsBold]
              ParentFont = False
            end
            object DBTDiasBloqAtual: TDBText
              Left = 243
              Top = 59
              Width = 40
              Height = 12
              Alignment = taRightJustify
              DataField = 'cg_dias_bloqueio_tarifa_atual'
              DataSource = DSCDC
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -9
              Font.Name = 'Tahoma'
              Font.Style = [fsBold]
              ParentFont = False
            end
          end
        end
      end
      object tbsAdicional: TTabSheet
        Caption = 'Dados Adicionais'
        ImageIndex = 6
        object GroupBox8: TGroupBox
          Left = 0
          Top = 0
          Width = 377
          Height = 169
          Align = alTop
          Caption = 'Dados para faturamento'
          TabOrder = 0
          object Bevel4: TBevel
            Left = 8
            Top = 109
            Width = 326
            Height = 42
          end
          object Label23: TLabel
            Left = 15
            Top = 16
            Width = 59
            Height = 13
            Caption = 'Vencimento:'
          end
          object DBTVencimento: TDBText
            Left = 90
            Top = 18
            Width = 81
            Height = 14
            DataField = 'cg_data_vencto'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label30: TLabel
            Left = 15
            Top = 35
            Width = 48
            Height = 13
            Caption = 'Troca HD:'
          end
          object DBTFlagTroca: TDBText
            Left = 90
            Top = 37
            Width = 20
            Height = 14
            DataField = 'cg_flag_troca'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label31: TLabel
            Left = 216
            Top = 35
            Width = 37
            Height = 13
            Caption = 'Leitura:'
          end
          object DBTLeituraInicial: TDBText
            Left = 259
            Top = 37
            Width = 68
            Height = 14
            DataField = 'cg_leitura_inicial'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBTDataInstHD: TDBText
            Left = 138
            Top = 37
            Width = 68
            Height = 14
            DataField = 'cg_data_instalacao_hd'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label32: TLabel
            Left = 115
            Top = 35
            Width = 18
            Height = 13
            Caption = 'Em:'
          end
          object Label33: TLabel
            Left = 15
            Top = 54
            Width = 60
            Height = 13
            Caption = 'Emite conta:'
          end
          object DBText2: TDBText
            Left = 90
            Top = 56
            Width = 20
            Height = 14
            DataField = 'cg_flag_emite_conta'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label34: TLabel
            Left = 15
            Top = 73
            Width = 68
            Height = 13
            Caption = 'Calcula conta:'
          end
          object DBText3: TDBText
            Left = 90
            Top = 75
            Width = 20
            Height = 14
            DataField = 'cg_flag_calcula_conta'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label35: TLabel
            Left = 15
            Top = 93
            Width = 70
            Height = 13
            Caption = 'Emite imposto:'
          end
          object DBText4: TDBText
            Left = 90
            Top = 95
            Width = 20
            Height = 14
            DataField = 'cg_flag_calcula_imposto'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label36: TLabel
            Left = 15
            Top = 114
            Width = 49
            Height = 13
            Caption = 'Desconto:'
          end
          object DBTDescDesconto: TDBText
            Left = 90
            Top = 116
            Width = 20
            Height = 14
            DataField = 'cg_desconto'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label37: TLabel
            Left = 15
            Top = 133
            Width = 61
            Height = 13
            Caption = 'Limite Inicial:'
          end
          object DBTLimite: TDBText
            Left = 90
            Top = 135
            Width = 79
            Height = 14
            DataField = 'de_limite_inicial'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label38: TLabel
            Left = 175
            Top = 133
            Width = 49
            Height = 13
            Caption = 'Desconto:'
          end
          object DBTPercDesc: TDBText
            Left = 232
            Top = 135
            Width = 58
            Height = 14
            Alignment = taRightJustify
            DataField = 'de_percentual'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label39: TLabel
            Left = 296
            Top = 133
            Width = 11
            Height = 13
            Caption = '%'
          end
          object Label40: TLabel
            Left = 138
            Top = 93
            Width = 101
            Height = 13
            Caption = 'Registros de Fraude:'
          end
          object Label41: TLabel
            Left = 138
            Top = 73
            Width = 77
            Height = 13
            Caption = 'Executar Corte:'
          end
          object Label42: TLabel
            Left = 138
            Top = 54
            Width = 78
            Height = 13
            Caption = 'Existe cachorro:'
          end
          object DBText6: TDBText
            Left = 259
            Top = 56
            Width = 20
            Height = 14
            DataField = 'cg_cachorro'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText7: TDBText
            Left = 259
            Top = 75
            Width = 20
            Height = 14
            DataField = 'cg_flag_cortar'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText8: TDBText
            Left = 259
            Top = 95
            Width = 20
            Height = 14
            DataField = 'cg_qtde_registros_fraude'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText48: TDBText
            Left = 138
            Top = 116
            Width = 119
            Height = 14
            DataField = 'desc_tipo_desconto'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
        end
        object GroupBox6: TGroupBox
          Left = 0
          Top = 169
          Width = 377
          Height = 55
          Align = alTop
          Caption = 'Entrega Alternativa'
          TabOrder = 1
          object Label20: TLabel
            Left = 9
            Top = 16
            Width = 49
            Height = 13
            Caption = 'Endere'#231'o:'
          end
          object DBTEnderecoAlternativo: TDBText
            Left = 64
            Top = 18
            Width = 268
            Height = 15
            DataField = 'cg_entrega_alternativa'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label21: TLabel
            Left = 9
            Top = 35
            Width = 33
            Height = 13
            Caption = 'Banco:'
          end
          object DBTBanco: TDBText
            Left = 64
            Top = 37
            Width = 49
            Height = 15
            DataField = 'cg_codigo_banco'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label22: TLabel
            Left = 137
            Top = 35
            Width = 42
            Height = 13
            Caption = 'Ag'#234'ncia:'
          end
          object DBTAgencia: TDBText
            Left = 200
            Top = 37
            Width = 49
            Height = 15
            DataField = 'cg_agencia'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
        end
      end
      object tbsHistorico: TTabSheet
        Caption = 'Hist'#243'ricos'
        ImageIndex = 1
        object GroupBox2: TGroupBox
          Left = 0
          Top = 0
          Width = 377
          Height = 322
          Align = alClient
          Caption = 'Hist'#243'rico de Consumo'
          TabOrder = 0
          object Label15: TLabel
            Left = 10
            Top = 188
            Width = 79
            Height = 13
            Caption = 'M'#233'dia Consumo:'
          end
          object DBTConsumoMedio: TDBText
            Left = 96
            Top = 190
            Width = 123
            Height = 14
            DataField = 'cg_consumo_medio'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBGrid2: TDBGrid
            Left = 10
            Top = 20
            Width = 321
            Height = 147
            DataSource = DSHistorico
            Options = [dgTitles, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgRowSelect, dgAlwaysShowSelection, dgConfirmDelete, dgCancelOnExit]
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
                Width = 65
                Visible = True
              end
              item
                Alignment = taCenter
                Expanded = False
                FieldName = 'hc_data_leitura'
                Title.Alignment = taCenter
                Title.Caption = 'Data Leitura'
                Width = 75
                Visible = True
              end
              item
                Expanded = False
                FieldName = 'hc_consumo'
                Title.Alignment = taCenter
                Title.Caption = 'Consumo'
                Width = 65
                Visible = True
              end
              item
                Alignment = taCenter
                Expanded = False
                FieldName = 'hc_ocorrencia_leitura'
                Title.Alignment = taCenter
                Title.Caption = ' '
                Width = 25
                Visible = True
              end
              item
                Expanded = False
                FieldName = 'hc_leitura'
                Title.Alignment = taCenter
                Title.Caption = 'Leitura'
                Width = 65
                Visible = True
              end
              item
                Expanded = False
                FieldName = 'hc_leitura_real'
                Title.Alignment = taCenter
                Title.Caption = 'Leitura Real'
                Width = 65
                Visible = True
              end>
          end
        end
      end
      object tbsServico: TTabSheet
        Caption = 'Servi'#231'o'
        ImageIndex = 2
        object GroupBox5: TGroupBox
          Left = 0
          Top = 0
          Width = 377
          Height = 322
          Align = alClient
          Caption = 'Servi'#231'os a Faturar'
          TabOrder = 0
          object Label17: TLabel
            Left = 15
            Top = 273
            Width = 125
            Height = 13
            Caption = 'Total de Servi'#231'os D'#233'bitos:'
          end
          object DBTTotalDebito: TDBText
            Left = 165
            Top = 275
            Width = 123
            Height = 14
            DataField = 'total_debito'
            DataSource = DSServico
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label18: TLabel
            Left = 15
            Top = 292
            Width = 124
            Height = 13
            Caption = 'Total de Servi'#231'os Cr'#233'dito:'
          end
          object DBTTotalCredito: TDBText
            Left = 165
            Top = 294
            Width = 123
            Height = 14
            DataField = 'total_credito'
            DataSource = DSServico
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBGrid3: TDBGrid
            Left = 10
            Top = 19
            Width = 324
            Height = 238
            DataSource = DSServico
            Options = [dgTitles, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgRowSelect, dgAlwaysShowSelection, dgConfirmDelete, dgCancelOnExit]
            TabOrder = 0
            TitleFont.Charset = DEFAULT_CHARSET
            TitleFont.Color = clWindowText
            TitleFont.Height = -11
            TitleFont.Name = 'Tahoma'
            TitleFont.Style = []
            Columns = <
              item
                Expanded = False
                FieldName = 'sr_sequencia'
                Title.Alignment = taCenter
                Title.Caption = ' '
                Width = 25
                Visible = True
              end
              item
                Expanded = False
                FieldName = 'sr_descricao'
                Title.Alignment = taCenter
                Title.Caption = 'Descri'#231#227'o'
                Width = 165
                Visible = True
              end
              item
                Alignment = taCenter
                Expanded = False
                FieldName = 'operador'
                Title.Alignment = taCenter
                Title.Caption = ' '
                Width = 20
                Visible = True
              end
              item
                Expanded = False
                FieldName = 'sr_valor'
                Title.Alignment = taCenter
                Title.Caption = 'Valor'
                Width = 90
                Visible = True
              end>
          end
        end
      end
      object tbsDocumento: TTabSheet
        Caption = 'Documentos'
        ImageIndex = 3
        object GroupBox9: TGroupBox
          Left = 0
          Top = 0
          Width = 377
          Height = 322
          Align = alClient
          TabOrder = 0
          object DBGrid4: TDBGrid
            Left = 8
            Top = 10
            Width = 324
            Height = 297
            DataSource = DSDocumentos
            Options = [dgTitles, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgRowSelect, dgAlwaysShowSelection, dgConfirmDelete, dgCancelOnExit]
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
                FieldName = 'Documento'
                Title.Alignment = taCenter
                Visible = True
              end
              item
                Alignment = taCenter
                Expanded = False
                FieldName = 'Texto'
                Title.Alignment = taCenter
                Title.Caption = 'Referente'
                Width = 85
                Visible = True
              end
              item
                Alignment = taCenter
                Expanded = False
                FieldName = 'Data_Vencimento'
                Title.Alignment = taCenter
                Title.Caption = 'Vencimento'
                Width = 65
                Visible = True
              end
              item
                Expanded = False
                FieldName = 'Valor_Total'
                Title.Alignment = taCenter
                Title.Caption = 'Valor'
                Width = 80
                Visible = True
              end>
          end
        end
      end
      object tbsDescarga: TTabSheet
        Caption = 'Leituras'
        ImageIndex = 4
        object GroupBox10: TGroupBox
          Left = 0
          Top = 61
          Width = 377
          Height = 260
          Align = alTop
          Caption = 'Leitura Atual'
          TabOrder = 0
          object Label43: TLabel
            Left = 12
            Top = 18
            Width = 63
            Height = 13
            Caption = 'Data Leitura:'
          end
          object DBTDataLeit: TDBText
            Left = 79
            Top = 19
            Width = 111
            Height = 15
            DataField = 'dg_data_leitura'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label45: TLabel
            Left = 12
            Top = 63
            Width = 58
            Height = 13
            Caption = 'Leitura real:'
          end
          object DBTLeituraReal: TDBText
            Left = 79
            Top = 65
            Width = 76
            Height = 14
            DataField = 'dg_leitura_real'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label46: TLabel
            Left = 12
            Top = 34
            Width = 61
            Height = 13
            Caption = 'Ocorr'#234'ncias:'
          end
          object DBTOcorrencia: TDBText
            Left = 79
            Top = 36
            Width = 32
            Height = 15
            DataField = 'dg_ocorrencia'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label49: TLabel
            Left = 195
            Top = 18
            Width = 69
            Height = 13
            Caption = 'Dias consumo:'
          end
          object DBTDiasConsumo: TDBText
            Left = 270
            Top = 19
            Width = 90
            Height = 15
            DataField = 'dg_dias_consumo'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBTOcorrenciaDesc: TDBText
            Left = 115
            Top = 36
            Width = 245
            Height = 15
            DataField = 'oc_descricao'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label50: TLabel
            Left = 195
            Top = 63
            Width = 47
            Height = 13
            Caption = 'Ajustada:'
          end
          object DBTLeituraAjustada: TDBText
            Left = 270
            Top = 65
            Width = 90
            Height = 14
            DataField = 'dg_leitura_ajustada'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label56: TLabel
            Left = 12
            Top = 207
            Width = 48
            Height = 13
            Caption = 'Leiturista:'
          end
          object DBText14: TDBText
            Left = 104
            Top = 209
            Width = 32
            Height = 15
            DataField = 'dg_agente'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText15: TDBText
            Left = 140
            Top = 209
            Width = 211
            Height = 15
            DataField = 'ag_nome'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label57: TLabel
            Left = 12
            Top = 156
            Width = 84
            Height = 13
            Caption = 'Execu'#231#227'o campo:'
          end
          object DBText16: TDBText
            Left = 104
            Top = 158
            Width = 32
            Height = 13
            DataField = 'dg_leitura_agente'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText17: TDBText
            Left = 140
            Top = 158
            Width = 211
            Height = 15
            DataField = 'desc_leitura_agente'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label58: TLabel
            Left = 12
            Top = 190
            Width = 76
            Height = 13
            Caption = 'Entrega campo:'
          end
          object DBText18: TDBText
            Left = 104
            Top = 192
            Width = 32
            Height = 13
            DataField = 'dg_forma_entrega'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText19: TDBText
            Left = 140
            Top = 192
            Width = 211
            Height = 13
            DataField = 'desc_forma_entrega'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label60: TLabel
            Left = 12
            Top = 241
            Width = 38
            Height = 13
            Caption = 'Fraude:'
          end
          object DBText21: TDBText
            Left = 104
            Top = 243
            Width = 32
            Height = 15
            DataField = 'dg_flag_fraude'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label61: TLabel
            Left = 12
            Top = 224
            Width = 35
            Height = 13
            Caption = 'Status:'
          end
          object DBText22: TDBText
            Left = 104
            Top = 226
            Width = 32
            Height = 15
            DataField = 'dg_status'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText23: TDBText
            Left = 140
            Top = 226
            Width = 211
            Height = 15
            DataField = 'desc_status'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label59: TLabel
            Left = 140
            Top = 241
            Width = 23
            Height = 13
            Caption = 'Lido:'
          end
          object DBText20: TDBText
            Left = 173
            Top = 243
            Width = 32
            Height = 15
            DataField = 'dg_flag_lido'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label82: TLabel
            Left = 220
            Top = 241
            Width = 48
            Height = 13
            Caption = 'Faturado:'
          end
          object DBText45: TDBText
            Left = 270
            Top = 243
            Width = 32
            Height = 15
            DataField = 'dg_flag_faturado'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label83: TLabel
            Left = 12
            Top = 173
            Width = 76
            Height = 13
            Caption = 'Emiss'#227'o campo:'
          end
          object DBText46: TDBText
            Left = 104
            Top = 175
            Width = 32
            Height = 15
            DataField = 'dg_vias'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText47: TDBText
            Left = 140
            Top = 175
            Width = 211
            Height = 15
            DataField = 'desc_vias'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label84: TLabel
            Left = 12
            Top = 139
            Width = 72
            Height = 13
            Caption = 'Emiss'#227'o conta:'
          end
          object DBText49: TDBText
            Left = 104
            Top = 141
            Width = 32
            Height = 15
            DataField = 'dg_flag_emitida'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText50: TDBText
            Left = 140
            Top = 141
            Width = 211
            Height = 15
            DataField = 'desc_flag_emitida'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBTOcorrencia2: TDBText
            Left = 79
            Top = 50
            Width = 32
            Height = 15
            DataField = 'Ocorrencia2'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText51: TDBText
            Left = 115
            Top = 50
            Width = 245
            Height = 14
            DataField = 'Desc_Ocorrencia2'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object GroupBox12: TGroupBox
            Left = 12
            Top = 82
            Width = 353
            Height = 55
            Caption = 'Consumos'
            TabOrder = 0
            object Label51: TLabel
              Left = 64
              Top = 8
              Width = 38
              Height = 13
              Caption = 'Medido:'
            end
            object Label53: TLabel
              Left = 148
              Top = 8
              Width = 47
              Height = 13
              Caption = 'Ajustado:'
            end
            object Label54: TLabel
              Left = 233
              Top = 8
              Width = 45
              Height = 13
              Caption = 'Rateado:'
            end
            object Label52: TLabel
              Left = 11
              Top = 20
              Width = 29
              Height = 13
              Caption = #193'gua:'
            end
            object Label55: TLabel
              Left = 11
              Top = 36
              Width = 37
              Height = 13
              Caption = 'Esgoto:'
            end
            object DBText5: TDBText
              Left = 64
              Top = 23
              Width = 81
              Height = 14
              DataField = 'dg_consumo_medido'
              DataSource = DSDescarga
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -9
              Font.Name = 'Tahoma'
              Font.Style = [fsBold]
              ParentFont = False
            end
            object DBText9: TDBText
              Left = 233
              Top = 23
              Width = 81
              Height = 14
              DataField = 'dg_consumo_rateado'
              DataSource = DSDescarga
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -9
              Font.Name = 'Tahoma'
              Font.Style = [fsBold]
              ParentFont = False
            end
            object DBText10: TDBText
              Left = 148
              Top = 23
              Width = 81
              Height = 14
              DataField = 'dg_consumo_ajustado'
              DataSource = DSDescarga
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -9
              Font.Name = 'Tahoma'
              Font.Style = [fsBold]
              ParentFont = False
            end
            object DBText11: TDBText
              Left = 64
              Top = 38
              Width = 81
              Height = 14
              DataField = 'dg_consumo_medido_esg'
              DataSource = DSDescarga
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -9
              Font.Name = 'Tahoma'
              Font.Style = [fsBold]
              ParentFont = False
            end
            object DBText12: TDBText
              Left = 148
              Top = 38
              Width = 81
              Height = 14
              DataField = 'dg_consumo_ajustado_esg'
              DataSource = DSDescarga
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -9
              Font.Name = 'Tahoma'
              Font.Style = [fsBold]
              ParentFont = False
            end
            object DBText13: TDBText
              Left = 233
              Top = 38
              Width = 81
              Height = 14
              DataField = 'dg_consumo_rateado_esg'
              DataSource = DSDescarga
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -9
              Font.Name = 'Tahoma'
              Font.Style = [fsBold]
              ParentFont = False
            end
          end
        end
        object GroupBox11: TGroupBox
          Left = 0
          Top = 0
          Width = 377
          Height = 61
          Align = alTop
          Caption = 'Leitura Anterior'
          TabOrder = 1
          object Label44: TLabel
            Left = 12
            Top = 19
            Width = 63
            Height = 13
            Caption = 'Data Leitura:'
          end
          object DBTDataLeitAnt: TDBText
            Left = 79
            Top = 21
            Width = 96
            Height = 15
            DataField = 'cg_data_leit_ant'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label47: TLabel
            Left = 12
            Top = 38
            Width = 37
            Height = 13
            Caption = 'Leitura:'
          end
          object DBTLeituraAnt: TDBText
            Left = 79
            Top = 40
            Width = 76
            Height = 14
            DataField = 'cg_leitura_ant'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label48: TLabel
            Left = 195
            Top = 38
            Width = 56
            Height = 13
            Caption = 'Ocorr'#234'ncia:'
          end
          object DBTOcorrenciaAnt: TDBText
            Left = 270
            Top = 40
            Width = 81
            Height = 15
            DataField = 'cg_ocorrencia_ant'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label85: TLabel
            Left = 195
            Top = 19
            Width = 32
            Height = 13
            Caption = 'M'#233'dia:'
          end
          object DBText52: TDBText
            Left = 270
            Top = 21
            Width = 81
            Height = 15
            DataField = 'cg_consumo_medio'
            DataSource = DSCDC
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
        end
      end
      object tbsValores: TTabSheet
        Caption = 'Valores'
        ImageIndex = 5
        object GroupBox13: TGroupBox
          Left = 0
          Top = 0
          Width = 377
          Height = 322
          Align = alClient
          TabOrder = 0
          object Bevel5: TBevel
            Left = 5
            Top = 11
            Width = 331
            Height = 142
          end
          object Label62: TLabel
            Left = 11
            Top = 36
            Width = 95
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'Residencial:'
          end
          object DBText24: TDBText
            Left = 112
            Top = 38
            Width = 81
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_consumo_faturado_res'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText25: TDBText
            Left = 112
            Top = 57
            Width = 81
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_consumo_faturado_soc'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label63: TLabel
            Left = 11
            Top = 55
            Width = 95
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'Social:'
          end
          object Label64: TLabel
            Left = 11
            Top = 74
            Width = 95
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'Industrial:'
          end
          object DBText26: TDBText
            Left = 112
            Top = 74
            Width = 81
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_consumo_faturado_ind'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText27: TDBText
            Left = 112
            Top = 95
            Width = 81
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_consumo_faturado_com'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label65: TLabel
            Left = 11
            Top = 93
            Width = 95
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'Comercial:'
          end
          object Label66: TLabel
            Left = 11
            Top = 112
            Width = 95
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'P'#250'blica:'
          end
          object DBText28: TDBText
            Left = 112
            Top = 114
            Width = 81
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_consumo_faturado_pub'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label67: TLabel
            Left = 11
            Top = 131
            Width = 95
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'Entidade Assist.:'
          end
          object Bevel6: TBevel
            Left = 5
            Top = 159
            Width = 206
            Height = 149
          end
          object Label68: TLabel
            Left = 11
            Top = 174
            Width = 95
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'Valor '#193'gua:'
          end
          object Label69: TLabel
            Left = 11
            Top = 193
            Width = 95
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'Valor Esgoto:'
          end
          object DBText30: TDBText
            Left = 112
            Top = 176
            Width = 90
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_valor_agua'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText31: TDBText
            Left = 112
            Top = 195
            Width = 90
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_valor_esgoto'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText32: TDBText
            Left = 112
            Top = 214
            Width = 90
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_valor_devolucao'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label70: TLabel
            Left = 11
            Top = 212
            Width = 95
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'Valor Redu'#231#227'o:'
          end
          object Label71: TLabel
            Left = 11
            Top = 231
            Width = 95
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'Valor Cr'#233'ditos:'
          end
          object DBText33: TDBText
            Left = 112
            Top = 233
            Width = 90
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_valor_credito'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label72: TLabel
            Left = 11
            Top = 250
            Width = 95
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'Valor Impostos:'
          end
          object DBText34: TDBText
            Left = 112
            Top = 252
            Width = 90
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_valor_imposto'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label73: TLabel
            Left = 11
            Top = 269
            Width = 95
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'Valor Servi'#231'os:'
          end
          object DBText35: TDBText
            Left = 112
            Top = 271
            Width = 90
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_valor_servico'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label74: TLabel
            Left = 11
            Top = 288
            Width = 95
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'VALOR TOTAL:'
          end
          object DBText36: TDBText
            Left = 112
            Top = 290
            Width = 90
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_valor_total'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Bevel7: TBevel
            Left = 214
            Top = 159
            Width = 120
            Height = 149
          end
          object Label75: TLabel
            Left = 224
            Top = 198
            Width = 108
            Height = 13
            AutoSize = False
            Caption = 'SALDOS A FATURAR'
          end
          object Label76: TLabel
            Left = 224
            Top = 263
            Width = 95
            Height = 13
            AutoSize = False
            Caption = 'Cr'#233'ditos:'
          end
          object DBText37: TDBText
            Left = 233
            Top = 278
            Width = 90
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_valor_saldo_credito'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label77: TLabel
            Left = 224
            Top = 223
            Width = 95
            Height = 13
            AutoSize = False
            Caption = 'D'#233'bitos:'
          end
          object DBText38: TDBText
            Left = 233
            Top = 242
            Width = 90
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_valor_saldo_debito'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText29: TDBText
            Left = 112
            Top = 133
            Width = 81
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_consumo_faturado_ea'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText39: TDBText
            Left = 200
            Top = 38
            Width = 81
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_consumo_faturado_esg_res'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText40: TDBText
            Left = 199
            Top = 57
            Width = 81
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_consumo_faturado_esg_soc'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText41: TDBText
            Left = 200
            Top = 74
            Width = 81
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_consumo_faturado_esg_ind'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText42: TDBText
            Left = 200
            Top = 95
            Width = 81
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_consumo_faturado_esg_com'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText43: TDBText
            Left = 200
            Top = 114
            Width = 81
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_consumo_faturado_esg_pub'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object DBText44: TDBText
            Left = 200
            Top = 133
            Width = 81
            Height = 15
            Alignment = taRightJustify
            DataField = 'dg_consumo_faturado_esg_ea'
            DataSource = DSDescarga
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -9
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
          end
          object Label78: TLabel
            Left = 11
            Top = 18
            Width = 95
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'Consumo Faturado'
          end
          object Label79: TLabel
            Left = 112
            Top = 18
            Width = 81
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = #193'gua'
          end
          object Label80: TLabel
            Left = 200
            Top = 18
            Width = 81
            Height = 13
            Alignment = taRightJustify
            AutoSize = False
            Caption = 'Esgoto'
          end
        end
      end
    end
  end
  object qryGrupo: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'#9'rt_grupo'
      'from'#9'roteiros'
      'group by '#9'rt_grupo'
      'order by'#9'rt_grupo')
    Left = 40
    Top = 296
  end
  object qryRoteiro: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'#9'rt_rota'
      'from'#9'roteiros'
      'where'#9'rt_grupo = :nGrupo'
      'order by'#9'rt_rota')
    Left = 40
    Top = 328
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end>
  end
  object qryPrincipal: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'#9'cg_grupo,'
      #9'cg_rota,'
      #9'cg_referencia,'
      #9'case '#9'when '#9'cg_matricula_pai = 0 '
      #9#9'then '#9'cg_matricula '
      #9#9'else '#9'cg_matricula_pai '
      #9'end '#9'as matricula,'
      #9'min(cg_sequencia) as cg_sequencia'
      'from'#9'carga'
      'group by cg_grupo,'
      #9'cg_rota,'
      #9'cg_referencia,'
      #9'case '#9'when '#9'cg_matricula_pai = 0 '
      #9#9'then '#9'cg_matricula '
      #9#9'else '#9'cg_matricula_pai '
      #9'end'
      'order by cg_sequencia')
    Left = 88
    Top = 296
  end
  object qryCDC: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select '#9'cg_matricula, cg_matricula_pai, cg_sequencia, '
      #9'case '#9'when cg_matricula_pai = cg_matricula then '#39'Principal'#39' '
      #9#9'when cg_matricula_pai = 0 then '#39'Principal'#39' '
      #9#9'else '#39'Filho'#39' '
      #9'end '#9'as desc_tipo_cdc,'
      #9'rtrim(cg_endereco) + '#39', '#39' + rtrim(cg_num_imovel) as endereco, '
      #9'cg_endereco, cg_num_imovel, cg_complemento, '
      
        #9'cg_inscricao, cg_nome, cg_grupo, cg_rota, cg_setor, cg_qtde_deb' +
        'ito_ant,'
      #9'cg_numero_hd, cg_capacidade_hidrometro, '
      #9'cg_consumo_medio, '
      #9'cg_economia_res, cg_economia_com, cg_economia_ind, '
      #9'cg_economia_pub, cg_economia_soc, cg_economia_ea,'
      #9'cg_categoria, t2.tb_descricao as descricao_categoria,'
      #9'cg_data_vencto, cg_referencia,'
      #9'cg_codigo_banco, cg_agencia, cg_flag_troca, '
      
        #9'cg_leitura_inicial, convert(datetime, convert(char(8), cg_data_' +
        'instalacao_hd, 112) ) as cg_data_instalacao_hd, '
      
        #9'cg_natureza_ligacao, t3.tb_descricao as descricao_natureza_liga' +
        'cao,'
      #9'cg_bloqueado, '
      
        #9'case '#9'when cg_bloqueado = '#39'S'#39' then '#39'Corte com retirada de ramal' +
        #39
      #9#9'when cg_bloqueado = '#39'N'#39' then '#39'Corte sem retirada de ramal'#39
      #9#9'when cg_bloqueado = '#39'L'#39' then '#39'Liga'#231#227'o liberada'#39
      #9#9'else '#39#39
      #9'end as desc_bloqueado,'
      
        #9'cg_desconto, de_percentual, de_limite_inicial, de_tipo_desconto' +
        ','
      #9'case '#9'when de_tipo_desconto = '#39'2'#39' then '#39'Sobre o Total Faturado'#39
      #9#9'when de_tipo_desconto = '#39'1'#39' then '#39'Sobre o Excedente'#39
      #9#9'else '#39'N'#227'o Aplica'#39
      #9'end as desc_tipo_desconto,'
      
        #9'cg_ident_consumidor, t1.tb_descricao as descricao_ident_consumi' +
        'dor,'
      #9'cg_flag_emite_conta, cg_flag_calcula_imposto, '
      #9'cg_entrega_alternativa, cg_flag_calcula_conta, '
      #9'cg_dias_bloqueio_tarifa_ant, cg_dias_bloqueio_tarifa_atual,'
      #9'cg_virtual, cg_data_bloqueio, cg_data_desbloqueio,'
      #9'cg_cachorro, cg_qtde_registros_fraude, cg_flag_cortar ,'
      
        #9'cg_leitura_ant, cg_ocorrencia_ant, cg_data_leit_ant, cg_consumo' +
        '_anterior'
      'from '#9'carga'
      'left'#9'outer join descontos'
      'on'#9'cg_grupo = de_grupo'
      'and'#9'cg_referencia = de_referencia'
      'and'#9'cg_desconto = de_codigo'
      'left'#9'outer join tabelas t1'
      'on '#9't1.tb_tabela = '#39'carga'#39
      'and '#9't1.tb_campo  = '#39'cg_ident_consumidor'#39
      'and '#9't1.tb_valor  = cg_ident_consumidor'
      'left'#9'outer join tabelas t2'
      'on '#9't2.tb_tabela = '#39'carga'#39
      'and '#9't2.tb_campo  = '#39'cg_categoria'#39
      'and '#9't2.tb_valor  = cg_categoria'
      'left'#9'outer join tabelas t3'
      'on '#9't3.tb_tabela = '#39'carga'#39
      'and '#9't3.tb_campo  = '#39'cg_natureza_ligacao'#39
      'and '#9't3.tb_valor  = cg_natureza_ligacao'
      'where '#9'cg_grupo = :nGrupo'
      'and'#9'cg_rota = :nRota'
      
        'and'#9'(cg_matricula = :nMatricula or cg_matricula_pai = :nMatricul' +
        'a)'
      'order '#9'by 4 desc, cg_matricula')
    Left = 88
    Top = 328
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nRota'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nMatricula'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nMatricula'
        ParamType = ptUnknown
      end>
    object qryCDCcg_matricula: TIntegerField
      FieldName = 'cg_matricula'
    end
    object qryCDCcg_matricula_pai: TIntegerField
      FieldName = 'cg_matricula_pai'
    end
    object qryCDCcg_sequencia: TIntegerField
      FieldName = 'cg_sequencia'
    end
    object qryCDCdesc_tipo_cdc: TStringField
      FieldName = 'desc_tipo_cdc'
      Size = 9
    end
    object qryCDCendereco: TStringField
      FieldName = 'endereco'
      Size = 57
    end
    object qryCDCcg_endereco: TStringField
      FieldName = 'cg_endereco'
      Size = 48
    end
    object qryCDCcg_num_imovel: TStringField
      FieldName = 'cg_num_imovel'
      Size = 7
    end
    object qryCDCcg_complemento: TStringField
      FieldName = 'cg_complemento'
      Size = 10
    end
    object qryCDCcg_inscricao: TStringField
      FieldName = 'cg_inscricao'
      Size = 16
    end
    object qryCDCcg_nome: TStringField
      FieldName = 'cg_nome'
      Size = 40
    end
    object qryCDCcg_grupo: TIntegerField
      FieldName = 'cg_grupo'
    end
    object qryCDCcg_rota: TIntegerField
      FieldName = 'cg_rota'
    end
    object qryCDCcg_setor: TIntegerField
      FieldName = 'cg_setor'
    end
    object qryCDCcg_qtde_debito_ant: TIntegerField
      FieldName = 'cg_qtde_debito_ant'
    end
    object qryCDCcg_numero_hd: TStringField
      FieldName = 'cg_numero_hd'
      Size = 11
    end
    object qryCDCcg_capacidade_hidrometro: TIntegerField
      FieldName = 'cg_capacidade_hidrometro'
    end
    object qryCDCcg_consumo_medio: TIntegerField
      FieldName = 'cg_consumo_medio'
    end
    object qryCDCcg_economia_res: TIntegerField
      FieldName = 'cg_economia_res'
    end
    object qryCDCcg_economia_com: TIntegerField
      FieldName = 'cg_economia_com'
    end
    object qryCDCcg_economia_ind: TIntegerField
      FieldName = 'cg_economia_ind'
    end
    object qryCDCcg_economia_pub: TIntegerField
      FieldName = 'cg_economia_pub'
    end
    object qryCDCcg_economia_soc: TIntegerField
      FieldName = 'cg_economia_soc'
    end
    object qryCDCcg_economia_ea: TIntegerField
      FieldName = 'cg_economia_ea'
    end
    object qryCDCcg_categoria: TIntegerField
      FieldName = 'cg_categoria'
    end
    object qryCDCdescricao_categoria: TStringField
      FieldName = 'descricao_categoria'
      Size = 100
    end
    object qryCDCcg_data_vencto: TDateTimeField
      FieldName = 'cg_data_vencto'
    end
    object qryCDCcg_referencia: TDateTimeField
      FieldName = 'cg_referencia'
    end
    object qryCDCcg_codigo_banco: TIntegerField
      FieldName = 'cg_codigo_banco'
    end
    object qryCDCcg_agencia: TIntegerField
      FieldName = 'cg_agencia'
    end
    object qryCDCcg_flag_troca: TStringField
      FieldName = 'cg_flag_troca'
      FixedChar = True
      Size = 1
    end
    object qryCDCcg_leitura_inicial: TIntegerField
      FieldName = 'cg_leitura_inicial'
    end
    object qryCDCcg_data_instalacao_hd: TDateTimeField
      FieldName = 'cg_data_instalacao_hd'
    end
    object qryCDCcg_natureza_ligacao: TIntegerField
      FieldName = 'cg_natureza_ligacao'
    end
    object qryCDCdescricao_natureza_ligacao: TStringField
      FieldName = 'descricao_natureza_ligacao'
      Size = 100
    end
    object qryCDCcg_bloqueado: TStringField
      FieldName = 'cg_bloqueado'
      Size = 1
    end
    object qryCDCdesc_bloqueado: TStringField
      FieldName = 'desc_bloqueado'
      Size = 27
    end
    object qryCDCcg_desconto: TIntegerField
      FieldName = 'cg_desconto'
    end
    object qryCDCde_percentual: TFloatField
      FieldName = 'de_percentual'
    end
    object qryCDCde_limite_inicial: TIntegerField
      FieldName = 'de_limite_inicial'
    end
    object qryCDCde_tipo_desconto: TIntegerField
      FieldName = 'de_tipo_desconto'
    end
    object qryCDCdesc_tipo_desconto: TStringField
      FieldName = 'desc_tipo_desconto'
      Size = 22
    end
    object qryCDCcg_ident_consumidor: TIntegerField
      FieldName = 'cg_ident_consumidor'
    end
    object qryCDCdescricao_ident_consumidor: TStringField
      FieldName = 'descricao_ident_consumidor'
      Size = 100
    end
    object qryCDCcg_flag_emite_conta: TStringField
      FieldName = 'cg_flag_emite_conta'
      FixedChar = True
      Size = 1
    end
    object qryCDCcg_flag_calcula_imposto: TStringField
      FieldName = 'cg_flag_calcula_imposto'
      FixedChar = True
      Size = 1
    end
    object qryCDCcg_entrega_alternativa: TStringField
      FieldName = 'cg_entrega_alternativa'
      Size = 60
    end
    object qryCDCcg_flag_calcula_conta: TStringField
      FieldName = 'cg_flag_calcula_conta'
      FixedChar = True
      Size = 1
    end
    object qryCDCcg_dias_bloqueio_tarifa_ant: TIntegerField
      FieldName = 'cg_dias_bloqueio_tarifa_ant'
    end
    object qryCDCcg_dias_bloqueio_tarifa_atual: TIntegerField
      FieldName = 'cg_dias_bloqueio_tarifa_atual'
    end
    object qryCDCcg_virtual: TStringField
      FieldName = 'cg_virtual'
      Size = 1
    end
    object qryCDCcg_data_bloqueio: TDateTimeField
      FieldName = 'cg_data_bloqueio'
    end
    object qryCDCcg_data_desbloqueio: TDateTimeField
      FieldName = 'cg_data_desbloqueio'
    end
    object qryCDCcg_cachorro: TStringField
      FieldName = 'cg_cachorro'
      Size = 1
    end
    object qryCDCcg_qtde_registros_fraude: TIntegerField
      FieldName = 'cg_qtde_registros_fraude'
    end
    object qryCDCcg_flag_cortar: TStringField
      FieldName = 'cg_flag_cortar'
      FixedChar = True
      Size = 1
    end
    object qryCDCcg_leitura_ant: TIntegerField
      FieldName = 'cg_leitura_ant'
    end
    object qryCDCcg_ocorrencia_ant: TIntegerField
      FieldName = 'cg_ocorrencia_ant'
    end
    object qryCDCcg_data_leit_ant: TDateTimeField
      FieldName = 'cg_data_leit_ant'
      DisplayFormat = 'DD/MM/YYYY'
    end
    object qryCDCcg_consumo_anterior: TIntegerField
      FieldName = 'cg_consumo_anterior'
    end
  end
  object DSPrincipal: TDataSource
    DataSet = qryPrincipal
    OnDataChange = DSPrincipalDataChange
    Left = 120
    Top = 296
  end
  object DSCDC: TDataSource
    DataSet = qryCDC
    OnDataChange = DSCDCDataChange
    Left = 120
    Top = 328
  end
  object qryHistorico: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      
        'select '#9'hc_ref_historico, hc_consumo, hc_leitura, hc_ocorrencia_' +
        'leitura, hc_dias_consumo, hc_data_leitura, hc_leitura_real'
      'from '#9'historico_consumo'
      'where'#9'hc_grupo = :nGrupo'
      'and'#9'hc_matricula = :nMatricula '
      'order '#9'by hc_ref_historico desc')
    Left = 88
    Top = 360
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
        Value = '1'
      end
      item
        DataType = ftInteger
        Name = 'nMatricula'
        ParamType = ptUnknown
        Value = '1404'
      end>
    object qryHistoricohc_ref_historico: TDateTimeField
      FieldName = 'hc_ref_historico'
      Origin = 'DBMAIN.historico_consumo.hc_ref_historico'
      DisplayFormat = 'MM/yyyy'
    end
    object qryHistoricohc_consumo: TIntegerField
      FieldName = 'hc_consumo'
      Origin = 'DBMAIN.historico_consumo.hc_consumo'
    end
    object qryHistoricohc_leitura: TIntegerField
      FieldName = 'hc_leitura'
      Origin = 'DBMAIN.historico_consumo.hc_leitura'
    end
    object qryHistoricohc_ocorrencia_leitura: TStringField
      FieldName = 'hc_ocorrencia_leitura'
      Origin = 'DBMAIN.historico_consumo.hc_ocorrencia_leitura'
      FixedChar = True
      Size = 2
    end
    object qryHistoricohc_dias_consumo: TIntegerField
      FieldName = 'hc_dias_consumo'
      Origin = 'DBMAIN.historico_consumo.hc_dias_consumo'
    end
    object qryHistoricohc_data_leitura: TDateTimeField
      FieldName = 'hc_data_leitura'
      Origin = 'DBMAIN.historico_consumo.hc_data_leitura'
      DisplayFormat = 'dd/MM/yyyy'
    end
    object qryHistoricohc_leitura_real: TIntegerField
      FieldName = 'hc_leitura_real'
      Origin = 'DBMAIN.historico_consumo.hc_leitura_real'
    end
  end
  object DSHistorico: TDataSource
    DataSet = qryHistorico
    Left = 120
    Top = 360
  end
  object qryServico: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select '#9'sr_matricula, sr_sequencia,'
      #9'sr_descricao,'
      #9'sr_valor,'
      #9'case '#9'when sr_ind_credito = '#39'S'#39' then '#39'-'#39
      #9#9'else '#39'+'#39
      #9'end '#9'as operador,'
      
        #9'(select '#9'sum(case when IsNull(sr_ind_credito,'#39'N'#39') = '#39'S'#39' then is' +
        'null(sr_valor,0) else 0 end)'
      #9'from'#9'servicos'
      #9'where'#9'sr_grupo = :nGrupo'
      #9'and'#9'sr_rota = :nRota'
      #9'and'#9'sr_matricula = :nMatricula) as total_credito,'
      
        #9'(select '#9'sum(case when IsNull(sr_ind_credito,'#39'N'#39') <> '#39'S'#39' then i' +
        'snull(sr_valor,0) else 0 end)'
      #9'from'#9'servicos'
      #9'where'#9'sr_grupo = :nGrupo'
      #9'and'#9'sr_rota = :nRota'
      #9'and'#9'sr_matricula = :nMatricula) as total_debito'
      'from '#9'servicos'
      'where'#9'sr_grupo = :nGrupo'
      'and'#9'sr_rota = :nRota'
      'and'#9'sr_matricula = :nMatricula '
      'order by sr_sequencia')
    Left = 152
    Top = 296
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nRota'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nMatricula'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nRota'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nMatricula'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nRota'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nMatricula'
        ParamType = ptUnknown
      end>
    object qryServicosr_matricula: TIntegerField
      FieldName = 'sr_matricula'
    end
    object qryServicosr_sequencia: TIntegerField
      FieldName = 'sr_sequencia'
    end
    object qryServicosr_descricao: TStringField
      FieldName = 'sr_descricao'
      Size = 35
    end
    object qryServicosr_valor: TFloatField
      FieldName = 'sr_valor'
      DisplayFormat = '#,##0.00'
    end
    object qryServicooperador: TStringField
      FieldName = 'operador'
      Size = 1
    end
    object qryServicototal_credito: TFloatField
      FieldName = 'total_credito'
      DisplayFormat = '#,##0.00'
    end
    object qryServicototal_debito: TFloatField
      FieldName = 'total_debito'
      DisplayFormat = '#,##0.00'
    end
  end
  object DSServico: TDataSource
    DataSet = qryServico
    Left = 184
    Top = 296
  end
  object qryDocumentos: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select '#9#39'2'#170' Via'#39' as Documento,'
      
        #9'substring(convert(char(7),sv_referencia_seg_via,102),6,2) + '#39'/'#39 +
        '+'
      
        #9'substring(convert(char(7),sv_referencia_seg_via,102),1,4) as Te' +
        'xto,'
      #9'sv_data_vencimento as Data_Vencimento,'
      #9'sv_valor_total as Valor_Total '
      'from '#9'segundas_vias'
      'where'#9'sv_grupo = :nGrupo'
      'and'#9'sv_rota = :nRota'
      'and'#9'sv_matricula = :nMatricula '
      'union'
      'select '#9'case '#9'when db_tipo = '#39'A'#39' then '#39'Aviso'#39
      #9#9'when db_tipo = '#39'N'#39' then '#39'Notifica'#231#227'o'#39
      #9'else '#39#39
      #9'end as Documento,'
      #9'rtrim(convert(char, db_qtde_debitos)) + '#39' d'#233'bito(s)'#39' as Texto,'
      #9'db_data_vencimento as Data_Vencimento,'
      #9'db_valor_total as Valor_Total'
      'from '#9'debitos'
      'where'#9'db_grupo = :nGrupo'
      'and'#9'db_rota = :nRota'
      'and'#9'db_matricula = :nMatricula ')
    Left = 152
    Top = 328
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nRota'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nMatricula'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nRota'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nMatricula'
        ParamType = ptUnknown
      end>
    object qryDocumentosDocumento: TStringField
      FieldName = 'Documento'
      Size = 11
    end
    object qryDocumentosTexto: TStringField
      FieldName = 'Texto'
      Size = 40
    end
    object qryDocumentosData_Vencimento: TDateTimeField
      FieldName = 'Data_Vencimento'
    end
    object qryDocumentosValor_Total: TFloatField
      FieldName = 'Valor_Total'
      DisplayFormat = '#,##0.00'
    end
  end
  object DSDocumentos: TDataSource
    DataSet = qryDocumentos
    Left = 184
    Top = 328
  end
  object qryDescarga: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select '#9'dg_data_leitura, dg_dias_consumo, '
      #9'dg_ocorrencia, oc1.oc_descricao,'
      #9'dg_forma_entrega, tb1.tb_descricao as desc_forma_entrega,'
      #9'dg_leitura_real, dg_leitura_ajustada,'
      #9'dg_consumo_medido, dg_consumo_ajustado, dg_consumo_rateado,'
      
        #9'dg_consumo_medido_esg, dg_consumo_ajustado_esg, dg_consumo_rate' +
        'ado_esg,'
      #9'dg_agente, ag_nome,'
      #9'dg_leitura_agente, tb2.tb_descricao as desc_leitura_agente,'
      
        #9'dg_motivo_nao_faturamento, tb3.tb_descricao as desc_motivo_nao_' +
        'faturamento,'
      #9'dg_status, tb4.tb_descricao as desc_status,'
      #9'dg_consumo_faturado_res, dg_consumo_faturado_com,'
      #9'dg_consumo_faturado_ind, dg_consumo_faturado_pub,'
      #9'dg_consumo_faturado_soc, dg_consumo_faturado_ea,'
      #9'dg_consumo_faturado_esg_res, dg_consumo_faturado_esg_com,'
      #9'dg_consumo_faturado_esg_ind, dg_consumo_faturado_esg_pub,'
      #9'dg_consumo_faturado_esg_soc, dg_consumo_faturado_esg_ea,'
      #9'dg_valor_agua, dg_valor_esgoto, '
      #9'dg_valor_servico, dg_valor_credito, '
      #9'dg_valor_devolucao,'
      
        #9'dg_valor_ir + dg_valor_csll + dg_valor_pis + dg_valor_cofins as' +
        ' dg_valor_imposto,'
      #9'dg_valor_saldo_debito, dg_valor_saldo_credito,'
      #9'(dg_valor_agua+dg_valor_esgoto+dg_valor_servico) -'
      #9'(dg_valor_saldo_debito+dg_valor_credito+dg_valor_devolucao+'
      
        #9'dg_valor_ir+dg_valor_csll+dg_valor_pis+dg_valor_cofins) as dg_v' +
        'alor_total,'
      #9'dg_flag_fraude, dg_flag_lido, dg_flag_faturado,'
      #9'dg_vias, tb5.tb_descricao as desc_vias,'
      #9'dg_flag_emitida, '
      #9'case '#9'when dg_flag_emitida = '#39'S'#39' then '#39'Em campo'#39' '
      #9#9'when dg_flag_emitida = '#39'O'#39' then '#39'Pelo OnPlace'#39
      #9#9'when dg_flag_emitida = '#39'N'#39' then '#39'N'#227'o Emitido'#39
      #9'else '#39#39' end as desc_flag_emitida,'
      
        #9'oc2.oc_codigo as Ocorrencia2, oc2.oc_descricao as Desc_Ocorrenc' +
        'ia2'
      'from '#9'descarga'
      'left'#9'outer join agentes'
      'on'#9'ag_grupo = dg_grupo'
      'and'#9'ag_codigo = dg_agente '
      'left'#9'outer join ocorrencias oc1'
      'on'#9'dg_grupo = oc1.oc_grupo'
      'and'#9'dg_ocorrencia = oc1.oc_codigo'
      'left'#9'outer join ocorrencias oc2'
      'on'#9'dg_grupo = oc2.oc_grupo'
      'and'#9'dg_ocorrencia2 = oc2.oc_codigo'
      'left'#9'outer join tabelas tb1'
      'on '#9'tb1.tb_tabela = '#39'descarga'#39
      'and'#9'tb1.tb_campo = '#39'dg_forma_entrega'#39
      'and'#9'tb1.tb_valor = dg_forma_entrega'
      'left'#9'outer join tabelas tb2'
      'on '#9'tb2.tb_tabela = '#39'descarga'#39
      'and'#9'tb2.tb_campo = '#39'dg_leitura_agente'#39
      'and'#9'tb2.tb_valor = dg_leitura_agente'
      'left'#9'outer join tabelas tb3'
      'on '#9'tb3.tb_tabela = '#39'descarga'#39
      'and'#9'tb3.tb_campo = '#39'dg_motivo_nao_faturamento'#39
      'and'#9'tb3.tb_valor = dg_motivo_nao_faturamento'
      'left'#9'outer join tabelas tb4'
      'on '#9'tb4.tb_tabela = '#39'descarga'#39
      'and'#9'tb4.tb_campo = '#39'dg_status'#39
      'and'#9'tb4.tb_valor = dg_status  '
      'left'#9'outer join tabelas tb5'
      'on '#9'tb5.tb_tabela = '#39'descarga'#39
      'and'#9'tb5.tb_campo = '#39'dg_vias'#39
      'and'#9'tb5.tb_valor = dg_vias'
      'where'#9'dg_grupo = :nGrupo'
      'and'#9'dg_rota = :nRota'
      'and'#9'dg_matricula = :nMatricula ')
    Left = 152
    Top = 360
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nRota'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nMatricula'
        ParamType = ptUnknown
      end>
    object qryDescargadg_data_leitura: TDateTimeField
      FieldName = 'dg_data_leitura'
      DisplayFormat = 'DD/MM/YYYY HH:nn'
    end
    object qryDescargadg_dias_consumo: TIntegerField
      FieldName = 'dg_dias_consumo'
    end
    object qryDescargadg_ocorrencia: TIntegerField
      FieldName = 'dg_ocorrencia'
    end
    object qryDescargaoc_descricao: TStringField
      FieldName = 'oc_descricao'
      Size = 40
    end
    object qryDescargadg_forma_entrega: TIntegerField
      FieldName = 'dg_forma_entrega'
    end
    object qryDescargadesc_forma_entrega: TStringField
      FieldName = 'desc_forma_entrega'
      Size = 100
    end
    object qryDescargadg_leitura_real: TIntegerField
      FieldName = 'dg_leitura_real'
    end
    object qryDescargadg_leitura_ajustada: TIntegerField
      FieldName = 'dg_leitura_ajustada'
    end
    object qryDescargadg_consumo_medido: TIntegerField
      FieldName = 'dg_consumo_medido'
      DisplayFormat = '#,##0'
    end
    object qryDescargadg_consumo_ajustado: TIntegerField
      FieldName = 'dg_consumo_ajustado'
      DisplayFormat = '#,##0'
    end
    object qryDescargadg_consumo_rateado: TIntegerField
      FieldName = 'dg_consumo_rateado'
      DisplayFormat = '#,##0'
    end
    object qryDescargadg_consumo_medido_esg: TIntegerField
      FieldName = 'dg_consumo_medido_esg'
      DisplayFormat = '#,##0'
    end
    object qryDescargadg_consumo_ajustado_esg: TIntegerField
      FieldName = 'dg_consumo_ajustado_esg'
      DisplayFormat = '#,##0'
    end
    object qryDescargadg_consumo_rateado_esg: TIntegerField
      FieldName = 'dg_consumo_rateado_esg'
      DisplayFormat = '#,##0'
    end
    object qryDescargadg_agente: TIntegerField
      FieldName = 'dg_agente'
    end
    object qryDescargaag_nome: TStringField
      FieldName = 'ag_nome'
      Size = 30
    end
    object qryDescargadg_leitura_agente: TIntegerField
      FieldName = 'dg_leitura_agente'
    end
    object qryDescargadesc_leitura_agente: TStringField
      FieldName = 'desc_leitura_agente'
      Size = 100
    end
    object qryDescargadg_motivo_nao_faturamento: TIntegerField
      FieldName = 'dg_motivo_nao_faturamento'
    end
    object qryDescargadesc_motivo_nao_faturamento: TStringField
      FieldName = 'desc_motivo_nao_faturamento'
      Size = 100
    end
    object qryDescargadg_status: TIntegerField
      FieldName = 'dg_status'
    end
    object qryDescargadesc_status: TStringField
      FieldName = 'desc_status'
      Size = 100
    end
    object qryDescargadg_consumo_faturado_res: TIntegerField
      FieldName = 'dg_consumo_faturado_res'
      DisplayFormat = '#,##0'
    end
    object qryDescargadg_consumo_faturado_com: TIntegerField
      FieldName = 'dg_consumo_faturado_com'
      DisplayFormat = '#,##0'
    end
    object qryDescargadg_consumo_faturado_ind: TIntegerField
      FieldName = 'dg_consumo_faturado_ind'
      DisplayFormat = '#,##0'
    end
    object qryDescargadg_consumo_faturado_pub: TIntegerField
      FieldName = 'dg_consumo_faturado_pub'
      DisplayFormat = '#,##0'
    end
    object qryDescargadg_consumo_faturado_soc: TIntegerField
      FieldName = 'dg_consumo_faturado_soc'
      DisplayFormat = '#,##0'
    end
    object qryDescargadg_consumo_faturado_ea: TIntegerField
      FieldName = 'dg_consumo_faturado_ea'
      DisplayFormat = '#,##0'
    end
    object qryDescargadg_consumo_faturado_esg_res: TIntegerField
      FieldName = 'dg_consumo_faturado_esg_res'
      DisplayFormat = '#,##0'
    end
    object qryDescargadg_consumo_faturado_esg_com: TIntegerField
      FieldName = 'dg_consumo_faturado_esg_com'
      DisplayFormat = '#,##0'
    end
    object qryDescargadg_consumo_faturado_esg_ind: TIntegerField
      FieldName = 'dg_consumo_faturado_esg_ind'
      DisplayFormat = '#,##0'
    end
    object qryDescargadg_consumo_faturado_esg_pub: TIntegerField
      FieldName = 'dg_consumo_faturado_esg_pub'
      DisplayFormat = '#,##0'
    end
    object qryDescargadg_consumo_faturado_esg_soc: TIntegerField
      FieldName = 'dg_consumo_faturado_esg_soc'
      DisplayFormat = '#,##0'
    end
    object qryDescargadg_consumo_faturado_esg_ea: TIntegerField
      FieldName = 'dg_consumo_faturado_esg_ea'
      DisplayFormat = '#,##0'
    end
    object qryDescargadg_valor_agua: TFloatField
      FieldName = 'dg_valor_agua'
      DisplayFormat = '#,##0.00'
    end
    object qryDescargadg_valor_esgoto: TFloatField
      FieldName = 'dg_valor_esgoto'
      DisplayFormat = '#,##0.00'
    end
    object qryDescargadg_valor_servico: TFloatField
      FieldName = 'dg_valor_servico'
      DisplayFormat = '#,##0.00'
    end
    object qryDescargadg_valor_credito: TFloatField
      FieldName = 'dg_valor_credito'
      DisplayFormat = '#,##0.00'
    end
    object qryDescargadg_valor_devolucao: TFloatField
      FieldName = 'dg_valor_devolucao'
      DisplayFormat = '#,##0.00'
    end
    object qryDescargadg_valor_imposto: TFloatField
      FieldName = 'dg_valor_imposto'
      DisplayFormat = '#,##0.00'
    end
    object qryDescargadg_valor_saldo_debito: TFloatField
      FieldName = 'dg_valor_saldo_debito'
      DisplayFormat = '#,##0.00'
    end
    object qryDescargadg_valor_saldo_credito: TFloatField
      FieldName = 'dg_valor_saldo_credito'
      DisplayFormat = '#,##0.00'
    end
    object qryDescargadg_valor_total: TFloatField
      FieldName = 'dg_valor_total'
      DisplayFormat = '#,##0.00'
    end
    object qryDescargadg_flag_fraude: TStringField
      FieldName = 'dg_flag_fraude'
      FixedChar = True
      Size = 1
    end
    object qryDescargadg_flag_lido: TStringField
      FieldName = 'dg_flag_lido'
      FixedChar = True
      Size = 1
    end
    object qryDescargadg_flag_faturado: TStringField
      FieldName = 'dg_flag_faturado'
      FixedChar = True
      Size = 1
    end
    object qryDescargadg_vias: TIntegerField
      FieldName = 'dg_vias'
    end
    object qryDescargadesc_vias: TStringField
      FieldName = 'desc_vias'
      Size = 100
    end
    object qryDescargadg_flag_emitida: TStringField
      FieldName = 'dg_flag_emitida'
      Size = 1
    end
    object qryDescargadesc_flag_emitida: TStringField
      FieldName = 'desc_flag_emitida'
      Size = 12
    end
    object qryDescargaOcorrencia2: TIntegerField
      FieldName = 'Ocorrencia2'
    end
    object qryDescargaDesc_Ocorrencia2: TStringField
      FieldName = 'Desc_Ocorrencia2'
      Size = 40
    end
  end
  object DSDescarga: TDataSource
    DataSet = qryDescarga
    Left = 184
    Top = 360
  end
  object qryParametros: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'#9'*'
      'from '#9'dbo.parametros')
    Left = 40
    Top = 360
    object qryParametrosNATUREZA: TStringField
      FieldName = 'NATUREZA'
      Origin = 'DBMAIN.parametros.NATUREZA'
      Size = 3
    end
    object qryParametrosEMPRESA: TStringField
      FieldName = 'EMPRESA'
      Origin = 'DBMAIN.parametros.EMPRESA'
      Size = 4
    end
    object qryParametrosDIRETORIO: TStringField
      FieldName = 'DIRETORIO'
      Origin = 'DBMAIN.parametros.DIRETORIO'
      Size = 50
    end
  end
end
