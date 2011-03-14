inherited frmRelatorioResFat: TfrmRelatorioResFat
  Caption = ''
  ClientHeight = 458
  ClientWidth = 672
  Visible = False
  ExplicitWidth = 678
  ExplicitHeight = 490
  PixelsPerInch = 96
  TextHeight = 13
  inherited pTop: TPanel
    Width = 672
    ExplicitWidth = 672
    inherited lVersion: TLabel
      Left = 597
      Height = 26
      ExplicitLeft = 597
    end
  end
  inherited pBottom: TPanel
    Top = 418
    Width = 672
    ExplicitTop = 418
    ExplicitWidth = 672
    inherited sbtnSair: TSpeedButton
      Left = 553
      Width = 111
      ExplicitLeft = 408
      ExplicitWidth = 111
    end
  end
  object PageControl: TPageControl
    Left = 0
    Top = 40
    Width = 672
    Height = 377
    ActivePage = tbsGeral
    Align = alTop
    TabOrder = 2
    object tbsPesquisa: TTabSheet
      Caption = 'Pesquisa'
      object GroupBox1: TGroupBox
        Left = 0
        Top = 0
        Width = 664
        Height = 349
        Align = alClient
        TabOrder = 0
        object Label1: TLabel
          Left = 48
          Top = 176
          Width = 33
          Height = 13
          Caption = 'Grupo:'
        end
        object Label2: TLabel
          Left = 48
          Top = 203
          Width = 56
          Height = 13
          Caption = 'Refer'#234'ncia:'
        end
        object sbtnPesquisar: TSpeedButton
          Left = 136
          Top = 227
          Width = 105
          Height = 22
          Caption = 'Pesquisar'
          Flat = True
          Glyph.Data = {
            76010000424D7601000000000000760000002800000020000000100000000100
            04000000000000010000120B0000120B00001000000000000000000000000000
            800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
            FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00555555555555
            555555555555555555555555555555555555555555FF55555555555559055555
            55555555577FF5555555555599905555555555557777F5555555555599905555
            555555557777FF5555555559999905555555555777777F555555559999990555
            5555557777777FF5555557990599905555555777757777F55555790555599055
            55557775555777FF5555555555599905555555555557777F5555555555559905
            555555555555777FF5555555555559905555555555555777FF55555555555579
            05555555555555777FF5555555555557905555555555555777FF555555555555
            5990555555555555577755555555555555555555555555555555}
          NumGlyphs = 2
          OnClick = sbtnPesquisarClick
        end
        object rbtGeral: TRadioButton
          Left = 32
          Top = 56
          Width = 225
          Height = 17
          Caption = 'Geral total das '#250'ltimas 12 refer'#234'ncias'
          Checked = True
          TabOrder = 0
          TabStop = True
          OnClick = rbtGeralClick
        end
        object rbtGrupo: TRadioButton
          Left = 32
          Top = 88
          Width = 225
          Height = 17
          Caption = 'Grupo total das '#250'ltimas 12 refer'#234'ncias'
          TabOrder = 1
          OnClick = rbtGeralClick
        end
        object rbtRota: TRadioButton
          Left = 32
          Top = 120
          Width = 225
          Height = 17
          Caption = 'Por grupo e rota em uma refer'#234'ncia'
          TabOrder = 2
          OnClick = rbtGeralClick
        end
        object cmbGrupo: TComboBox
          Left = 136
          Top = 173
          Width = 105
          Height = 21
          Style = csDropDownList
          Enabled = False
          ItemHeight = 13
          TabOrder = 3
          OnDropDown = cmbGrupoDropDown
        end
        object cmbReferencia: TComboBox
          Left = 136
          Top = 200
          Width = 105
          Height = 21
          Style = csDropDownList
          Enabled = False
          ItemHeight = 13
          TabOrder = 4
          OnDropDown = cmbReferenciaDropDown
        end
      end
    end
    object tbsGeral: TTabSheet
      Caption = 'Hist'#243'rico de Faturamento Geral'
      ImageIndex = 1
      object GroupBox2: TGroupBox
        Left = 0
        Top = 0
        Width = 664
        Height = 349
        Align = alClient
        TabOrder = 0
        object DBGridGeral: TDBGrid
          Left = 7
          Top = 40
          Width = 640
          Height = 298
          DataSource = dsPesqGeral
          Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgRowSelect, dgConfirmDelete, dgCancelOnExit]
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
              FieldName = 'md_referencia'
              Title.Alignment = taCenter
              Title.Caption = 'Refer'#234'ncia'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_ligacoes'
              Title.Alignment = taCenter
              Title.Caption = 'Liga'#231#245'es'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_agua'
              Title.Alignment = taCenter
              Title.Caption = 'Valor '#193'gua'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_esgoto'
              Title.Alignment = taCenter
              Title.Caption = 'Valor Esgoto'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_servico'
              Title.Alignment = taCenter
              Title.Caption = 'Valor Servi'#231'o'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_credito'
              Title.Alignment = taCenter
              Title.Caption = 'Valor Cr'#233'dito'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_devolucao'
              Title.Alignment = taCenter
              Title.Caption = 'Valor Redu'#231#227'o'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_imposto'
              Title.Alignment = taCenter
              Title.Caption = 'Retens'#227'o Imposto'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_total'
              Title.Alignment = taCenter
              Title.Caption = 'Valor Total'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_saldo_debito'
              Title.Alignment = taCenter
              Title.Caption = 'Saldo a Faturar'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_consumo_medido'
              Title.Alignment = taCenter
              Title.Caption = 'Volume '#193'gua'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_consumo_medido_esg'
              Title.Alignment = taCenter
              Title.Caption = 'Volume Esgoto'
              Width = 100
              Visible = True
            end>
        end
        object CBGrafico: TCheckBox
          Left = 7
          Top = 17
          Width = 106
          Height = 17
          Caption = 'VIsualizar Gr'#225'fico'
          TabOrder = 1
          OnClick = CBGraficoClick
        end
        object cmbGraficoGeral: TComboBox
          Left = 119
          Top = 15
          Width = 145
          Height = 21
          Style = csDropDownList
          ItemHeight = 13
          ItemIndex = 0
          TabOrder = 2
          Text = 'Liga'#231#245'es'
          OnChange = CBGraficoClick
          OnClick = CBGraficoClick
          Items.Strings = (
            'Liga'#231#245'es'
            'Volumes'
            'Valores')
        end
        object ChGraficoGeralLig: TChart
          Left = 1
          Top = 43
          Width = 646
          Height = 304
          BackWall.Brush.Color = clWhite
          BackWall.Brush.Style = bsClear
          Title.Text.Strings = (
            'Liga'#231#245'es')
          TabOrder = 3
          object Series1: TBarSeries
            Marks.ArrowLength = 20
            Marks.Style = smsValue
            Marks.Visible = True
            SeriesColor = clRed
            XValues.DateTime = False
            XValues.Name = 'X'
            XValues.Multiplier = 1.000000000000000000
            XValues.Order = loAscending
            YValues.DateTime = False
            YValues.Name = 'Bar'
            YValues.Multiplier = 1.000000000000000000
            YValues.Order = loNone
          end
        end
        object ChGraficoGeralVol: TChart
          Left = 1
          Top = 43
          Width = 646
          Height = 304
          BackWall.Brush.Color = clWhite
          BackWall.Brush.Style = bsClear
          Title.Text.Strings = (
            'Volumes')
          TabOrder = 4
          object BarSeries1: TBarSeries
            Marks.ArrowLength = 20
            Marks.Style = smsValue
            Marks.Visible = True
            SeriesColor = clRed
            Title = 'Series1'
            XValues.DateTime = False
            XValues.Name = 'X'
            XValues.Multiplier = 1.000000000000000000
            XValues.Order = loAscending
            YValues.DateTime = False
            YValues.Name = 'Bar'
            YValues.Multiplier = 1.000000000000000000
            YValues.Order = loNone
          end
          object Series2: TBarSeries
            Marks.ArrowLength = 20
            Marks.Style = smsValue
            Marks.Visible = True
            SeriesColor = clGreen
            XValues.DateTime = False
            XValues.Name = 'X'
            XValues.Multiplier = 1.000000000000000000
            XValues.Order = loAscending
            YValues.DateTime = False
            YValues.Name = 'Bar'
            YValues.Multiplier = 1.000000000000000000
            YValues.Order = loNone
          end
        end
        object ChGraficoGeralVal: TChart
          Left = 9
          Top = 43
          Width = 646
          Height = 304
          BackWall.Brush.Color = clWhite
          BackWall.Brush.Style = bsClear
          Title.Text.Strings = (
            'Valores')
          TabOrder = 5
          object BarSeries2: TBarSeries
            Marks.ArrowLength = 20
            Marks.Style = smsValue
            Marks.Visible = True
            SeriesColor = clRed
            Title = 'Series1'
            MultiBar = mbStacked
            XValues.DateTime = False
            XValues.Name = 'X'
            XValues.Multiplier = 1.000000000000000000
            XValues.Order = loAscending
            YValues.DateTime = False
            YValues.Name = 'Bar'
            YValues.Multiplier = 1.000000000000000000
            YValues.Order = loNone
          end
          object BarSeries3: TBarSeries
            Marks.ArrowLength = 20
            Marks.Style = smsValue
            Marks.Visible = True
            SeriesColor = clGreen
            MultiBar = mbStacked
            XValues.DateTime = False
            XValues.Name = 'X'
            XValues.Multiplier = 1.000000000000000000
            XValues.Order = loAscending
            YValues.DateTime = False
            YValues.Name = 'Bar'
            YValues.Multiplier = 1.000000000000000000
            YValues.Order = loNone
          end
          object Series3: TBarSeries
            Marks.ArrowLength = 20
            Marks.Style = smsValue
            Marks.Visible = True
            SeriesColor = clYellow
            MultiBar = mbStacked
            XValues.DateTime = False
            XValues.Name = 'X'
            XValues.Multiplier = 1.000000000000000000
            XValues.Order = loAscending
            YValues.DateTime = False
            YValues.Name = 'Bar'
            YValues.Multiplier = 1.000000000000000000
            YValues.Order = loNone
          end
        end
      end
    end
    object tbsGrupo: TTabSheet
      Caption = 'Hist'#243'rico de Faturamento do Grupo'
      ImageIndex = 2
      object GroupBox3: TGroupBox
        Left = 0
        Top = 0
        Width = 664
        Height = 349
        Align = alClient
        TabOrder = 0
        object Label3: TLabel
          Left = 22
          Top = 20
          Width = 33
          Height = 13
          Caption = 'Grupo:'
        end
        object DBGrid2: TDBGrid
          Left = 7
          Top = 48
          Width = 640
          Height = 290
          DataSource = dsPesqGrupo
          Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgRowSelect, dgConfirmDelete, dgCancelOnExit]
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
              FieldName = 'md_referencia'
              Title.Alignment = taCenter
              Title.Caption = 'Refer'#234'ncia'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_ligacoes'
              Title.Alignment = taCenter
              Title.Caption = 'Liga'#231#245'es'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_agua'
              Title.Alignment = taCenter
              Title.Caption = 'Valor '#193'gua'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_esgoto'
              Title.Alignment = taCenter
              Title.Caption = 'Valor Esgoto'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_servico'
              Title.Alignment = taCenter
              Title.Caption = 'Valor Servi'#231'o'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_credito'
              Title.Alignment = taCenter
              Title.Caption = 'Valor Cr'#233'dito'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_devolucao'
              Title.Alignment = taCenter
              Title.Caption = 'Valor Redu'#231#227'o'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_imposto'
              Title.Alignment = taCenter
              Title.Caption = 'Retens'#227'o Imposto'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_total'
              Title.Alignment = taCenter
              Title.Caption = 'Valor Total'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_saldo_debito'
              Title.Alignment = taCenter
              Title.Caption = 'Saldo a Faturar'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_consumo_medido'
              Title.Alignment = taCenter
              Title.Caption = 'Volume '#193'gua'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_consumo_medido_esg'
              Title.Alignment = taCenter
              Title.Caption = 'Volume Esgoto'
              Width = 100
              Visible = True
            end>
        end
        object DBEdGrupo: TDBEdit
          Left = 65
          Top = 17
          Width = 57
          Height = 21
          DataField = 'md_grupo'
          DataSource = dsPesqGrupo
          TabOrder = 1
        end
      end
    end
    object tbsRota: TTabSheet
      Caption = 'Faturamento por Rota na Refer'#234'ncia'
      ImageIndex = 3
      object GroupBox4: TGroupBox
        Left = 0
        Top = 0
        Width = 664
        Height = 349
        Align = alClient
        TabOrder = 0
        object Label4: TLabel
          Left = 22
          Top = 20
          Width = 33
          Height = 13
          Caption = 'Grupo:'
        end
        object Label5: TLabel
          Left = 150
          Top = 20
          Width = 56
          Height = 13
          Caption = 'Refer'#234'ncia:'
        end
        object DBGrid3: TDBGrid
          Left = 7
          Top = 48
          Width = 640
          Height = 290
          DataSource = dsPesqRota
          Options = [dgTitles, dgIndicator, dgColumnResize, dgColLines, dgRowLines, dgRowSelect, dgConfirmDelete, dgCancelOnExit]
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
              FieldName = 'md_rota'
              Title.Alignment = taCenter
              Title.Caption = 'Rota'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_ligacoes'
              Title.Alignment = taCenter
              Title.Caption = 'Liga'#231#245'es'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_agua'
              Title.Alignment = taCenter
              Title.Caption = 'Valor '#193'gua'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_esgoto'
              Title.Alignment = taCenter
              Title.Caption = 'Valor Esgoto'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_servico'
              Title.Alignment = taCenter
              Title.Caption = 'Valor Servi'#231'o'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_credito'
              Title.Alignment = taCenter
              Title.Caption = 'Valor Cr'#233'dito'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_devolucao'
              Title.Alignment = taCenter
              Title.Caption = 'Valor Redu'#231#227'o'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_imposto'
              Title.Alignment = taCenter
              Title.Caption = 'Retens'#227'o Imposto'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_total'
              Title.Alignment = taCenter
              Title.Caption = 'Valor Total'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_valor_saldo_debito'
              Title.Alignment = taCenter
              Title.Caption = 'Saldo a Faturar'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_consumo_medido'
              Title.Alignment = taCenter
              Title.Caption = 'Volume '#193'gua'
              Width = 100
              Visible = True
            end
            item
              Expanded = False
              FieldName = 'md_consumo_medido_esg'
              Title.Alignment = taCenter
              Title.Caption = 'Volume Esgoto'
              Width = 100
              Visible = True
            end>
        end
        object DBEdGrupoRota: TDBEdit
          Left = 65
          Top = 17
          Width = 57
          Height = 21
          DataField = 'md_grupo'
          DataSource = dsPesqRota
          TabOrder = 1
        end
        object DBEdReferencia: TDBEdit
          Left = 225
          Top = 17
          Width = 72
          Height = 21
          DataField = 'md_referencia'
          DataSource = dsPesqRota
          TabOrder = 2
        end
      end
    end
  end
  object qryReferencia: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'#9'md_referencia as referencia'
      'from '#9'medicao'
      'where'#9'md_grupo = :nGrupo'
      'group by '#9'md_referencia'
      'order by '#9'md_referencia desc')
    Left = 364
    Top = 38
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end>
  end
  object qryGrupo: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'#9'md_grupo as grupo'
      'from '#9'medicao'
      'group by '#9'md_grupo'
      'order by '#9'md_grupo desc')
    Left = 332
    Top = 38
  end
  object qryPesqGeral: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      
        'select '#9'md_referencia, sum(isnull(md_ligacoes,0)) as md_ligacoes' +
        ', '
      #9'sum(isnull(md_consumo_medido,0)) as md_consumo_medido, '
      #9'sum(isnull(md_consumo_medido_esg,0)) as md_consumo_medido_esg,'
      
        #9'sum(isnull(md_consumo_faturado_res,0)) as md_consumo_faturado_r' +
        'es,'
      
        #9'sum(isnull(md_consumo_faturado_res_esg,0)) as md_consumo_fatura' +
        'do_res_esg,'
      
        #9'sum(isnull(md_consumo_faturado_com,0)) as md_consumo_faturado_c' +
        'om, '
      
        #9'sum(isnull(md_consumo_faturado_com_esg,0)) as md_consumo_fatura' +
        'do_com_esg,'
      
        #9'sum(isnull(md_consumo_faturado_ind,0)) as md_consumo_faturado_i' +
        'nd, '
      
        #9'sum(isnull(md_consumo_faturado_ind_esg,0)) as md_consumo_fatura' +
        'do_ind_esg,'
      
        #9'sum(isnull(md_consumo_faturado_pub,0)) as md_consumo_faturado_p' +
        'ub, '
      
        #9'sum(isnull(md_consumo_faturado_pub_esg,0)) as md_consumo_fatura' +
        'do_pub_esg,'
      
        #9'sum(isnull(md_consumo_faturado_soc,0)) as md_consumo_faturado_s' +
        'oc, '
      
        #9'sum(isnull(md_consumo_faturado_soc_esg,0)) as md_consumo_fatura' +
        'do_soc_esg,'
      
        #9'sum(isnull(md_consumo_faturado_ea,0)) as md_consumo_faturado_ea' +
        ', '
      
        #9'sum(isnull(md_consumo_faturado_ea_esg,0)) as md_consumo_faturad' +
        'o_ea_esg,'
      #9'sum(isnull(md_valor_agua,0)) as md_valor_agua, '
      #9'sum(isnull(md_valor_esgoto,0)) as md_valor_esgoto,'
      #9'sum(isnull(md_valor_servico,0)) as md_valor_servico, '
      #9'sum(isnull(md_valor_credito,0)) as md_valor_credito,'
      #9'sum(isnull(md_valor_devolucao,0)) as md_valor_devolucao, '
      #9'(sum(isnull(md_valor_ir,0)) + sum(isnull(md_valor_csll,0)) +'
      
        #9'sum(isnull(md_valor_pis,0)) + sum(isnull(md_valor_cofins,0))) a' +
        's md_valor_importo, '
      ' '#9'sum(isnull(md_valor_saldo_debito,0)) as md_valor_saldo_debito,'
      #9'(sum(isnull(md_valor_agua,0)) +'
      #9'sum(isnull(md_valor_esgoto,0)) +'
      #9'sum(isnull(md_valor_servico,0)) - '
      #9'sum(isnull(md_valor_credito,0)) - '
      #9'sum(isnull(md_valor_devolucao,0)) -'
      #9'sum(isnull(md_valor_ir,0)) - sum(isnull(md_valor_csll,0)) -'
      
        #9'sum(isnull(md_valor_pis,0)) - sum(isnull(md_valor_cofins,0))) a' +
        's md_valor_total'
      'from '#9'medicao'
      'where'#9'md_referencia >= '
      
        #9'(select convert(datetime, convert( char(06), max(md_referencia)' +
        ' - 390, 112 ) + '#39'01'#39')'
      #9'from medicao)'
      'group by '#9'md_referencia'
      'order by '#9'md_referencia desc')
    Left = 396
    Top = 38
    object qryPesqGeralmd_referencia: TDateTimeField
      FieldName = 'md_referencia'
      DisplayFormat = 'MM/yyyy'
    end
    object qryPesqGeralmd_ligacoes: TIntegerField
      FieldName = 'md_ligacoes'
      DisplayFormat = '#,##0'
    end
    object qryPesqGeralmd_consumo_medido: TIntegerField
      FieldName = 'md_consumo_medido'
      DisplayFormat = '#,##0'
    end
    object qryPesqGeralmd_consumo_medido_esg: TIntegerField
      FieldName = 'md_consumo_medido_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqGeralmd_consumo_faturado_res: TIntegerField
      FieldName = 'md_consumo_faturado_res'
      DisplayFormat = '#,##0'
    end
    object qryPesqGeralmd_consumo_faturado_res_esg: TIntegerField
      FieldName = 'md_consumo_faturado_res_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqGeralmd_consumo_faturado_com: TIntegerField
      FieldName = 'md_consumo_faturado_com'
      DisplayFormat = '#,##0'
    end
    object qryPesqGeralmd_consumo_faturado_com_esg: TIntegerField
      FieldName = 'md_consumo_faturado_com_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqGeralmd_consumo_faturado_ind: TIntegerField
      FieldName = 'md_consumo_faturado_ind'
      DisplayFormat = '#,##0'
    end
    object qryPesqGeralmd_consumo_faturado_ind_esg: TIntegerField
      FieldName = 'md_consumo_faturado_ind_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqGeralmd_consumo_faturado_pub: TIntegerField
      FieldName = 'md_consumo_faturado_pub'
      DisplayFormat = '#,##0'
    end
    object qryPesqGeralmd_consumo_faturado_pub_esg: TIntegerField
      FieldName = 'md_consumo_faturado_pub_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqGeralmd_consumo_faturado_soc: TIntegerField
      FieldName = 'md_consumo_faturado_soc'
      DisplayFormat = '#,##0'
    end
    object qryPesqGeralmd_consumo_faturado_soc_esg: TIntegerField
      FieldName = 'md_consumo_faturado_soc_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqGeralmd_consumo_faturado_ea: TIntegerField
      FieldName = 'md_consumo_faturado_ea'
      DisplayFormat = '#,##0'
    end
    object qryPesqGeralmd_consumo_faturado_ea_esg: TIntegerField
      FieldName = 'md_consumo_faturado_ea_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqGeralmd_valor_agua: TFloatField
      FieldName = 'md_valor_agua'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqGeralmd_valor_esgoto: TFloatField
      FieldName = 'md_valor_esgoto'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqGeralmd_valor_servico: TFloatField
      FieldName = 'md_valor_servico'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqGeralmd_valor_credito: TFloatField
      FieldName = 'md_valor_credito'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqGeralmd_valor_devolucao: TFloatField
      FieldName = 'md_valor_devolucao'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqGeralmd_valor_importo: TFloatField
      FieldName = 'md_valor_importo'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqGeralmd_valor_saldo_debito: TFloatField
      FieldName = 'md_valor_saldo_debito'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqGeralmd_valor_total: TFloatField
      FieldName = 'md_valor_total'
      DisplayFormat = '#,##0.00'
    end
  end
  object dsPesqGeral: TDataSource
    DataSet = qryPesqGeral
    Left = 396
    Top = 72
  end
  object qryPesqGrupo: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      
        'select '#9'md_referencia, md_grupo, sum(isnull(md_ligacoes,0)) as m' +
        'd_ligacoes, '
      #9'sum(isnull(md_consumo_medido,0)) as md_consumo_medido, '
      #9'sum(isnull(md_consumo_medido_esg,0)) as md_consumo_medido_esg,'
      
        #9'sum(isnull(md_consumo_faturado_res,0)) as md_consumo_faturado_r' +
        'es,'
      
        #9'sum(isnull(md_consumo_faturado_res_esg,0)) as md_consumo_fatura' +
        'do_res_esg,'
      
        #9'sum(isnull(md_consumo_faturado_com,0)) as md_consumo_faturado_c' +
        'om, '
      
        #9'sum(isnull(md_consumo_faturado_com_esg,0)) as md_consumo_fatura' +
        'do_com_esg,'
      
        #9'sum(isnull(md_consumo_faturado_ind,0)) as md_consumo_faturado_i' +
        'nd, '
      
        #9'sum(isnull(md_consumo_faturado_ind_esg,0)) as md_consumo_fatura' +
        'do_ind_esg,'
      
        #9'sum(isnull(md_consumo_faturado_pub,0)) as md_consumo_faturado_p' +
        'ub, '
      
        #9'sum(isnull(md_consumo_faturado_pub_esg,0)) as md_consumo_fatura' +
        'do_pub_esg,'
      
        #9'sum(isnull(md_consumo_faturado_soc,0)) as md_consumo_faturado_s' +
        'oc, '
      
        #9'sum(isnull(md_consumo_faturado_soc_esg,0)) as md_consumo_fatura' +
        'do_soc_esg,'
      
        #9'sum(isnull(md_consumo_faturado_ea,0)) as md_consumo_faturado_ea' +
        ', '
      
        #9'sum(isnull(md_consumo_faturado_ea_esg,0)) as md_consumo_faturad' +
        'o_ea_esg,'
      #9'sum(isnull(md_valor_agua,0)) as md_valor_agua, '
      #9'sum(isnull(md_valor_esgoto,0)) as md_valor_esgoto,'
      #9'sum(isnull(md_valor_servico,0)) as md_valor_servico, '
      #9'sum(isnull(md_valor_credito,0)) as md_valor_credito,'
      #9'sum(isnull(md_valor_devolucao,0)) as md_valor_devolucao, '
      #9'(sum(isnull(md_valor_ir,0)) + sum(isnull(md_valor_csll,0)) +'
      
        #9'sum(isnull(md_valor_pis,0)) + sum(isnull(md_valor_cofins,0))) a' +
        's md_valor_importo, '
      ' '#9'sum(isnull(md_valor_saldo_debito,0)) as md_valor_saldo_debito,'
      #9'(sum(isnull(md_valor_agua,0)) +'
      #9'sum(isnull(md_valor_esgoto,0)) +'
      #9'sum(isnull(md_valor_servico,0)) - '
      #9'sum(isnull(md_valor_credito,0)) - '
      #9'sum(isnull(md_valor_devolucao,0)) -'
      #9'sum(isnull(md_valor_ir,0)) - sum(isnull(md_valor_csll,0)) -'
      
        #9'sum(isnull(md_valor_pis,0)) - sum(isnull(md_valor_cofins,0))) a' +
        's md_valor_total'
      'from '#9'medicao'
      'where'#9'md_referencia >= '
      
        #9'(select convert(datetime, convert( char(06), max(md_referencia)' +
        ' - 390, 112 ) + '#39'01'#39')'
      #9'from medicao)'
      'and'#9'md_grupo = :nGrupo'
      'group by '#9'md_referencia, md_grupo'
      'order by '#9'md_referencia desc, md_grupo')
    Left = 428
    Top = 38
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end>
    object qryPesqGrupomd_referencia: TDateTimeField
      FieldName = 'md_referencia'
      DisplayFormat = 'MM/yyyy'
    end
    object qryPesqGrupomd_grupo: TIntegerField
      FieldName = 'md_grupo'
    end
    object qryPesqGrupomd_ligacoes: TIntegerField
      FieldName = 'md_ligacoes'
      DisplayFormat = '#,##0'
    end
    object qryPesqGrupomd_consumo_medido: TIntegerField
      FieldName = 'md_consumo_medido'
      DisplayFormat = '#,##0'
    end
    object qryPesqGrupomd_consumo_medido_esg: TIntegerField
      FieldName = 'md_consumo_medido_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqGrupomd_consumo_faturado_res: TIntegerField
      FieldName = 'md_consumo_faturado_res'
      DisplayFormat = '#,##0'
    end
    object qryPesqGrupomd_consumo_faturado_res_esg: TIntegerField
      FieldName = 'md_consumo_faturado_res_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqGrupomd_consumo_faturado_com: TIntegerField
      FieldName = 'md_consumo_faturado_com'
      DisplayFormat = '#,##0'
    end
    object qryPesqGrupomd_consumo_faturado_com_esg: TIntegerField
      FieldName = 'md_consumo_faturado_com_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqGrupomd_consumo_faturado_ind: TIntegerField
      FieldName = 'md_consumo_faturado_ind'
      DisplayFormat = '#,##0'
    end
    object qryPesqGrupomd_consumo_faturado_ind_esg: TIntegerField
      FieldName = 'md_consumo_faturado_ind_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqGrupomd_consumo_faturado_pub: TIntegerField
      FieldName = 'md_consumo_faturado_pub'
      DisplayFormat = '#,##0'
    end
    object qryPesqGrupomd_consumo_faturado_pub_esg: TIntegerField
      FieldName = 'md_consumo_faturado_pub_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqGrupomd_consumo_faturado_soc: TIntegerField
      FieldName = 'md_consumo_faturado_soc'
      DisplayFormat = '#,##0'
    end
    object qryPesqGrupomd_consumo_faturado_soc_esg: TIntegerField
      FieldName = 'md_consumo_faturado_soc_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqGrupomd_consumo_faturado_ea: TIntegerField
      FieldName = 'md_consumo_faturado_ea'
      DisplayFormat = '#,##0'
    end
    object qryPesqGrupomd_consumo_faturado_ea_esg: TIntegerField
      FieldName = 'md_consumo_faturado_ea_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqGrupomd_valor_agua: TFloatField
      FieldName = 'md_valor_agua'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqGrupomd_valor_esgoto: TFloatField
      FieldName = 'md_valor_esgoto'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqGrupomd_valor_servico: TFloatField
      FieldName = 'md_valor_servico'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqGrupomd_valor_credito: TFloatField
      FieldName = 'md_valor_credito'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqGrupomd_valor_devolucao: TFloatField
      FieldName = 'md_valor_devolucao'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqGrupomd_valor_importo: TFloatField
      FieldName = 'md_valor_importo'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqGrupomd_valor_saldo_debito: TFloatField
      FieldName = 'md_valor_saldo_debito'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqGrupomd_valor_total: TFloatField
      FieldName = 'md_valor_total'
      DisplayFormat = '#,##0.00'
    end
  end
  object dsPesqGrupo: TDataSource
    DataSet = qryPesqGrupo
    Left = 428
    Top = 72
  end
  object qryPesqRota: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select '#9'md_referencia, md_grupo, md_rota, '
      #9'sum(isnull(md_ligacoes,0)) as md_ligacoes, '
      #9'sum(isnull(md_consumo_medido,0)) as md_consumo_medido, '
      #9'sum(isnull(md_consumo_medido_esg,0)) as md_consumo_medido_esg,'
      
        #9'sum(isnull(md_consumo_faturado_res,0)) as md_consumo_faturado_r' +
        'es,'
      
        #9'sum(isnull(md_consumo_faturado_res_esg,0)) as md_consumo_fatura' +
        'do_res_esg,'
      
        #9'sum(isnull(md_consumo_faturado_com,0)) as md_consumo_faturado_c' +
        'om, '
      
        #9'sum(isnull(md_consumo_faturado_com_esg,0)) as md_consumo_fatura' +
        'do_com_esg,'
      
        #9'sum(isnull(md_consumo_faturado_ind,0)) as md_consumo_faturado_i' +
        'nd, '
      
        #9'sum(isnull(md_consumo_faturado_ind_esg,0)) as md_consumo_fatura' +
        'do_ind_esg,'
      
        #9'sum(isnull(md_consumo_faturado_pub,0)) as md_consumo_faturado_p' +
        'ub, '
      
        #9'sum(isnull(md_consumo_faturado_pub_esg,0)) as md_consumo_fatura' +
        'do_pub_esg,'
      
        #9'sum(isnull(md_consumo_faturado_soc,0)) as md_consumo_faturado_s' +
        'oc, '
      
        #9'sum(isnull(md_consumo_faturado_soc_esg,0)) as md_consumo_fatura' +
        'do_soc_esg,'
      
        #9'sum(isnull(md_consumo_faturado_ea,0)) as md_consumo_faturado_ea' +
        ', '
      
        #9'sum(isnull(md_consumo_faturado_ea_esg,0)) as md_consumo_faturad' +
        'o_ea_esg,'
      #9'sum(isnull(md_valor_agua,0)) as md_valor_agua, '
      #9'sum(isnull(md_valor_esgoto,0)) as md_valor_esgoto,'
      #9'sum(isnull(md_valor_servico,0)) as md_valor_servico, '
      #9'sum(isnull(md_valor_credito,0)) as md_valor_credito,'
      #9'sum(isnull(md_valor_devolucao,0)) as md_valor_devolucao, '
      #9'(sum(isnull(md_valor_ir,0)) + sum(isnull(md_valor_csll,0)) +'
      
        #9'sum(isnull(md_valor_pis,0)) + sum(isnull(md_valor_cofins,0))) a' +
        's md_valor_importo, '
      ' '#9'sum(isnull(md_valor_saldo_debito,0)) as md_valor_saldo_debito,'
      #9'(sum(isnull(md_valor_agua,0)) +'
      #9'sum(isnull(md_valor_esgoto,0)) +'
      #9'sum(isnull(md_valor_servico,0)) - '
      #9'sum(isnull(md_valor_credito,0)) - '
      #9'sum(isnull(md_valor_devolucao,0)) -'
      #9'sum(isnull(md_valor_ir,0)) - sum(isnull(md_valor_csll,0)) -'
      
        #9'sum(isnull(md_valor_pis,0)) - sum(isnull(md_valor_cofins,0))) a' +
        's md_valor_total'
      'from '#9'medicao'
      'where'#9'md_referencia = :dtReferencia'
      'and'#9'md_grupo = :nGrupo'
      'group by '#9'md_referencia, md_grupo, md_rota'
      'order by '#9'md_referencia, md_grupo, md_rota')
    Left = 460
    Top = 38
    ParamData = <
      item
        DataType = ftDateTime
        Name = 'dtReferencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end>
    object qryPesqRotamd_referencia: TDateTimeField
      FieldName = 'md_referencia'
      DisplayFormat = 'MM/yyyy'
    end
    object qryPesqRotamd_grupo: TIntegerField
      FieldName = 'md_grupo'
    end
    object qryPesqRotamd_rota: TIntegerField
      FieldName = 'md_rota'
    end
    object qryPesqRotamd_ligacoes: TIntegerField
      FieldName = 'md_ligacoes'
      DisplayFormat = '#,##0'
    end
    object qryPesqRotamd_consumo_medido: TIntegerField
      FieldName = 'md_consumo_medido'
      DisplayFormat = '#,##0'
    end
    object qryPesqRotamd_consumo_medido_esg: TIntegerField
      FieldName = 'md_consumo_medido_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqRotamd_consumo_faturado_res: TIntegerField
      FieldName = 'md_consumo_faturado_res'
      DisplayFormat = '#,##0'
    end
    object qryPesqRotamd_consumo_faturado_res_esg: TIntegerField
      FieldName = 'md_consumo_faturado_res_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqRotamd_consumo_faturado_com: TIntegerField
      FieldName = 'md_consumo_faturado_com'
      DisplayFormat = '#,##0'
    end
    object qryPesqRotamd_consumo_faturado_com_esg: TIntegerField
      FieldName = 'md_consumo_faturado_com_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqRotamd_consumo_faturado_ind: TIntegerField
      FieldName = 'md_consumo_faturado_ind'
      DisplayFormat = '#,##0'
    end
    object qryPesqRotamd_consumo_faturado_ind_esg: TIntegerField
      FieldName = 'md_consumo_faturado_ind_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqRotamd_consumo_faturado_pub: TIntegerField
      FieldName = 'md_consumo_faturado_pub'
      DisplayFormat = '#,##0'
    end
    object qryPesqRotamd_consumo_faturado_pub_esg: TIntegerField
      FieldName = 'md_consumo_faturado_pub_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqRotamd_consumo_faturado_soc: TIntegerField
      FieldName = 'md_consumo_faturado_soc'
      DisplayFormat = '#,##0'
    end
    object qryPesqRotamd_consumo_faturado_soc_esg: TIntegerField
      FieldName = 'md_consumo_faturado_soc_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqRotamd_consumo_faturado_ea: TIntegerField
      FieldName = 'md_consumo_faturado_ea'
      DisplayFormat = '#,##0'
    end
    object qryPesqRotamd_consumo_faturado_ea_esg: TIntegerField
      FieldName = 'md_consumo_faturado_ea_esg'
      DisplayFormat = '#,##0'
    end
    object qryPesqRotamd_valor_agua: TFloatField
      FieldName = 'md_valor_agua'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqRotamd_valor_esgoto: TFloatField
      FieldName = 'md_valor_esgoto'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqRotamd_valor_servico: TFloatField
      FieldName = 'md_valor_servico'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqRotamd_valor_credito: TFloatField
      FieldName = 'md_valor_credito'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqRotamd_valor_devolucao: TFloatField
      FieldName = 'md_valor_devolucao'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqRotamd_valor_importo: TFloatField
      FieldName = 'md_valor_importo'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqRotamd_valor_saldo_debito: TFloatField
      FieldName = 'md_valor_saldo_debito'
      DisplayFormat = '#,##0.00'
    end
    object qryPesqRotamd_valor_total: TFloatField
      FieldName = 'md_valor_total'
      DisplayFormat = '#,##0.00'
    end
  end
  object dsPesqRota: TDataSource
    DataSet = qryPesqRota
    Left = 460
    Top = 72
  end
end
