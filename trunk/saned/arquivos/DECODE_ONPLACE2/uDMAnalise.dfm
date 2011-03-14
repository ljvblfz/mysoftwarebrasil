object dmAnalise: TdmAnalise
  OldCreateOrder = False
  Height = 397
  Width = 448
  object qryGeral: TQuery
    DatabaseName = 'dbMain'
    Left = 144
    Top = 24
  end
  object qryGrupoAnaliste: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select '#9'rt_grupo'
      'from '#9'roteiros, descarga'
      'where'#9'rt_ind_leitura = 3'
      'and'#9'rt_grupo = dg_grupo'
      'and'#9'rt_rota = dg_rota'
      'and  '#9'dg_status = 4'
      'group'#9'by rt_grupo'
      'order '#9'by rt_grupo')
    Left = 40
    Top = 24
  end
  object qryRotaAnaliste: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select '#9'rt_rota'
      'from '#9'roteiros, descarga'
      'where'#9'rt_ind_leitura = 3'
      'and'#9'rt_grupo = :nGrupo'
      'and'#9'rt_grupo = dg_grupo'
      'and'#9'rt_rota = dg_rota'
      'and  '#9'dg_status = 4'
      'group'#9'by rt_rota'
      'order '#9'by rt_rota')
    Left = 40
    Top = 80
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end>
  end
  object qryAnalise: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'#9'cg_grupo, cg_rota,'
      #9'cg_matricula, cg_sequencia, cg_nome, '
      
        #9'rtrim(cg_endereco) + '#39', '#39' + rtrim(cg_num_imovel) as endereco, c' +
        'g_complemento, '
      #9'cg_numero_hd, cg_capacidade_hidrometro, '
      #9'cg_ident_consumidor, tb_descricao'
      'from '#9'carga'
      'left'#9'outer join tabelas'
      'on '#9'tb_tabela = '#39'carga'#39
      'and '#9'tb_campo  ='#39'cg_ident_consumidor'#39
      'and '#9'tb_valor = cg_ident_consumidor'
      'where '#9'cg_grupo = :nGrupo'
      'and'#9'cg_rota = :nRota'
      'and'#9'cg_matricula in'
      
        #9'(select'#9'case when cg_matricula_pai = 0 then cg_matricula else c' +
        'g_matricula_pai end'
      #9'from'#9'carga, descarga'
      #9'where '#9'cg_grupo = :nGrupo'
      #9'and'#9'cg_rota = :nRota'
      #9'and '#9'dg_grupo = cg_grupo'
      #9'and'#9'dg_rota = cg_rota'
      #9'and'#9'dg_matricula = cg_matricula'
      #9'and'#9'dg_status = 4)'
      'order '#9'by cg_sequencia')
    Left = 40
    Top = 144
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
        Name = 'nGrupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nRota'
        ParamType = ptUnknown
      end>
  end
  object dsAnalise: TDataSource
    DataSet = qryAnalise
    OnDataChange = dsAnaliseDataChange
    Left = 144
    Top = 144
  end
  object qryCDCAnalise: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select '#9'cg_matricula, cg_matricula_pai, cg_sequencia, '
      
        #9'case when cg_matricula = cg_matricula_pai then '#39'CDC Principal'#39' ' +
        'else '#39#39' end as desc_tipo_cdc,'
      #9'rtrim(cg_endereco) + '#39', '#39' + rtrim(cg_num_imovel) as endereco, '
      #9'cg_endereco, cg_num_imovel, cg_complemento, '
      #9'cg_inscricao, cg_nome, cg_grupo,'
      #9'cg_numero_hd, cg_capacidade_hidrometro, '
      #9'cg_leitura_ant, cg_ocorrencia_ant, cg_consumo_anterior,'
      
        #9'convert(datetime, convert(char(8), cg_data_leit_ant, 112) ) as ' +
        'cg_data_leit_ant, '
      #9'cg_consumo_medio, '
      #9'cg_economia_res, cg_economia_com, cg_economia_ind, '
      #9'cg_economia_pub, cg_economia_soc, cg_economia_ea,'
      #9'cg_categoria, t2.tb_descricao as descricao_categoria,'
      #9'cg_data_vencto, '
      #9'cg_codigo_banco, cg_agencia, cg_flag_troca, '
      
        #9'cg_leitura_inicial, convert(datetime, convert(char(8), cg_data_' +
        'instalacao_hd, 112) ) as cg_data_instalacao_hd, '
      
        #9'cg_natureza_ligacao, t4.tb_descricao as descricao_natureza_liga' +
        'cao,'
      #9'cg_bloqueado, '
      
        #9'case '#9'when cg_bloqueado = '#39'S'#39' then '#39'Corte com retirada de ramal' +
        #39
      #9#9'when cg_bloqueado = '#39'N'#39' then '#39'Corte sem retirada de ramal'#39
      #9#9'when cg_bloqueado = '#39'L'#39' then '#39'Liga'#231#227'o liberada'#39
      #9#9'else '#39#39
      #9'end as desc_bloqueado,'
      #9'cg_desconto, '
      
        #9'cg_ident_consumidor, t1.tb_descricao as descricao_ident_consumi' +
        'dor,'
      #9'cg_flag_emite_conta, cg_flag_calcula_imposto, '
      #9'cg_entrega_alternativa, cg_flag_calcula_conta, '
      #9'cg_dias_bloqueio_tarifa_ant, cg_dias_bloqueio_tarifa_atual,'
      #9'cg_virtual, cg_data_bloqueio, cg_data_desbloqueio,'
      #9'dg_referencia, dg_matricula, '
      #9'dg_leitura_ajustada, dg_leitura_real, '
      #9'dg_consumo_ajustado, dg_consumo_rateado, dg_consumo_medido, '
      
        #9'dg_consumo_ajustado_esg, dg_consumo_rateado_esg, dg_consumo_med' +
        'ido_esg, '
      #9'dg_situacao_consumo, dg_dias_consumo, '
      #9'dg_ocorrencia, oc_descricao, oc_calculo, oc_mensagem,'
      ' '#9'dg_flag_calculada, cg_flag_troca,'
      #9'dg_flag_cortado, dg_flag_aviso, '
      #9'dg_valor_agua, dg_valor_esgoto, dg_valor_servico, '
      #9'dg_valor_saldo_credito, dg_valor_devolucao, '
      #9'dg_valor_saldo_debito, dg_valor_ir, dg_valor_csll, '
      #9'dg_valor_pis, dg_valor_cofins, '
      
        #9'dg_leitura_agente, convert(datetime, convert(char(8), dg_data_l' +
        'eitura, 112) ) as dg_data_leitura, '
      #9'dg_vias, dg_motivo_nao_faturamento, dg_agente, '
      #9'dg_status, t3.tb_descricao as descricao_status, dg_flag_lido'
      
        'from '#9'carga, tabelas t1, tabelas t2, tabelas t3, tabelas t4, des' +
        'carga'
      'left'#9'outer join ocorrencias'
      'on'#9'dg_ocorrencia = oc_codigo'
      'and'#9'dg_grupo = oc_grupo'
      'and'#9'dg_referencia = oc_referencia'
      'where '#9'dg_grupo = :nGrupo'
      'and'#9'dg_rota = :nRota'
      
        'and'#9'(cg_matricula = :nMatricula or cg_matricula_pai = :nMatricul' +
        'a)'
      'and '#9'dg_grupo = cg_grupo'
      'and'#9'dg_rota = cg_rota'
      'and'#9'dg_matricula = cg_matricula'
      'and '#9't1.tb_tabela = '#39'carga'#39
      'and '#9't1.tb_campo  = '#39'cg_ident_consumidor'#39
      'and '#9't1.tb_valor  = cg_ident_consumidor'
      'and '#9't2.tb_tabela = '#39'carga'#39
      'and '#9't2.tb_campo  = '#39'cg_categoria'#39
      'and '#9't2.tb_valor  = cg_categoria'
      'and '#9't4.tb_tabela = '#39'carga'#39
      'and '#9't4.tb_campo  = '#39'cg_natureza_ligacao'#39
      'and '#9't4.tb_valor  = cg_natureza_ligacao'
      'and '#9't3.tb_tabela = '#39'descarga'#39
      'and '#9't3.tb_campo  = '#39'dg_status'#39
      'and '#9't3.tb_valor  = dg_status'
      'order '#9'by 4 desc, cg_matricula')
    Left = 40
    Top = 208
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
  end
  object qryHistoricoConsumo: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      
        'select '#9'hc_ref_historico, hc_data_leitura, hc_leitura, hc_consum' +
        'o, hc_dias_consumo,'
      #9'hc_ocorrencia_leitura, oc_descricao, hc_leitura_real'
      'from '#9'historico_consumo'
      'left'#9'outer join ocorrencias'
      'on'#9'oc_codigo = hc_ocorrencia_leitura'
      'and'#9'oc_grupo = hc_grupo'
      'and'#9'oc_referencia = hc_referencia'
      'where '#9'hc_grupo = :nGrupo'
      'and'#9'hc_matricula = :nMatricula'
      'order by hc_ref_historico desc ')
    Left = 40
    Top = 280
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'nMatricula'
        ParamType = ptUnknown
      end>
    object qryHistoricoConsumohc_ref_historico: TDateTimeField
      FieldName = 'hc_ref_historico'
      Origin = 'DBMAIN.historico_consumo.hc_ref_historico'
    end
    object qryHistoricoConsumohc_data_leitura: TDateTimeField
      FieldName = 'hc_data_leitura'
      Origin = 'DBMAIN.historico_consumo.hc_data_leitura'
    end
    object qryHistoricoConsumohc_leitura: TIntegerField
      FieldName = 'hc_leitura'
      Origin = 'DBMAIN.historico_consumo.hc_leitura'
    end
    object qryHistoricoConsumohc_consumo: TIntegerField
      FieldName = 'hc_consumo'
      Origin = 'DBMAIN.historico_consumo.hc_consumo'
    end
    object qryHistoricoConsumohc_dias_consumo: TIntegerField
      FieldName = 'hc_dias_consumo'
      Origin = 'DBMAIN.historico_consumo.hc_dias_consumo'
    end
    object qryHistoricoConsumohc_ocorrencia_leitura: TStringField
      FieldName = 'hc_ocorrencia_leitura'
      Origin = 'DBMAIN.historico_consumo.hc_ocorrencia_leitura'
      FixedChar = True
      Size = 2
    end
    object qryHistoricoConsumooc_descricao: TStringField
      FieldName = 'oc_descricao'
      Origin = 'DBMAIN.ocorrencias.oc_descricao'
      Size = 40
    end
    object qryHistoricoConsumohc_leitura_real: TIntegerField
      FieldName = 'hc_leitura_real'
      Origin = 'DBMAIN.historico_consumo.hc_leitura_real'
    end
  end
  object DSHistoricoConsumo: TDataSource
    DataSet = qryHistoricoConsumo
    Left = 144
    Top = 272
  end
  object qryAnormalidade: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      
        'select '#9'rtrim(convert(char, oc_codigo)) + '#39' '#183' '#39' + oc_descricao +' +
        ' '#39' '#183' '#39' + rtrim(convert(char, oc_calculo)) as anormalidade '
      'from '#9'ocorrencias'
      'where'#9'oc_grupo = :nGrupo'
      'and'#9'oc_calculo in (2, 7, 8)'
      'order '#9'by 1')
    Left = 144
    Top = 80
    ParamData = <
      item
        DataType = ftInteger
        Name = 'nGrupo'
        ParamType = ptUnknown
      end>
  end
end
