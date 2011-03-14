object dmTransmissao: TdmTransmissao
  OldCreateOrder = False
  Height = 335
  Width = 468
  object qryLogAtendimento: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'insert into DIADEMA_IV.dbo.VOLTA_LOG_ATENDIMENTO ('
      #9'grupo,'
      #9'CDC,'
      #9'Tipo,'
      #9'Referencia,'
      #9'Data_Emissao,'
      '  Operador'
      ')'
      '('
      #9'select'
      #9'ds_grupo,'
      #9'ds_matricula,'
      #9#39'S'#39','
      #9'ds_referencia_seg_via,'
      #9'ds_data_emissao  ,'
      '  dg_agente'
      #9'from descarga_seg_vias, descarga'
      #9'where ds_grupo = :grupo'
      #9'and ds_rota = :rota'
      '  and ds_grupo = dg_grupo'
      '  and ds_rota = dg_rota'
      '  and ds_matricula = dg_matricula'
      ')'
      ''
      'insert into DIADEMA_IV.dbo.VOLTA_LOG_ATENDIMENTO ('
      #9'grupo,'
      #9'CDC,'
      #9'Tipo,'
      #9'Referencia,'
      #9'Data_Emissao ,'
      '  Operador'
      ')'
      '('
      #9'select'
      #9'dg_grupo,'
      #9'dg_matricula,'
      #9#39'N'#39','
      #9'dg_referencia,'
      #9'dg_data_leitura ,'
      '  dg_agente'
      #9'from descarga, debitos'
      #9'where dg_flag_aviso = '#39'S'#39
      #9'and db_matricula = dg_matricula'
      #9'and db_rota = dg_rota'
      #9'and db_grupo = dg_rota'
      #9'and db_tipo = '#39'N'#39
      #9'and db_grupo = :grupo'
      #9'and db_rota = :rota'
      ')'
      ''
      'insert into DIADEMA_IV.dbo.VOLTA_LOG_ATENDIMENTO ('
      #9'grupo,'
      #9'CDC,'
      #9'Tipo,'
      #9'Referencia,'
      #9'Data_Emissao ,'
      '  Operador'
      ')'
      '('
      #9'select'
      #9'dg_grupo,'
      #9'dg_matricula,'
      #9#39'A'#39','
      #9'dg_referencia,'
      #9'dg_data_leitura ,'
      '  dg_agente'
      #9'from descarga, debitos'
      #9'where dg_flag_aviso = '#39'S'#39
      #9'and db_matricula = dg_matricula'
      #9'and db_rota = dg_rota'
      #9'and db_grupo = dg_rota'
      #9'and db_tipo = '#39'A'#39
      #9'and db_grupo = :grupo'
      #9'and db_rota = :rota'
      ')'
      '')
    Left = 104
    Top = 56
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'rota'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'rota'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'rota'
        ParamType = ptUnknown
      end>
  end
  object qryRoteiro: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'insert into DIADEMA_IV.dbo.volta_roteiro'
      '('
      #9'Referencia,'
      #9'Grupo,'
      #9'Rota,'
      #9'Data_Inicial,'
      #9'Data_Final,'
      #9'Data_Envio,'
      #9'Aparelho,'
      #9'Data_Problema,'
      #9'Chuva'
      ')'
      '('
      'select'
      #9'rt_referencia,'
      #9'rt_grupo,'
      #9'rt_rota,'
      
        #9'(select min( dg_data_leitura ) from descarga where dg_grupo = R' +
        '.rt_grupo and dg_rota = R.rt_rota and dg_data_leitura is not nul' +
        'l),'
      
        #9'(select max( dg_data_leitura ) from descarga where dg_grupo = R' +
        '.rt_grupo and dg_rota = R.rt_rota and dg_data_leitura is not nul' +
        'l),'
      #9'getdate(),'
      #9'isnull(rt_maleta,0),'
      
        #9'(select min(pe_data)  from problema_equipamento where pe_grupo ' +
        '= rt_grupo and pe_rota = rt_rota and pe_data between'
      
        '    (select min( dg_data_leitura ) from descarga where dg_grupo ' +
        '= R.rt_grupo and dg_rota = R.rt_rota and dg_data_leitura is not ' +
        'null)'
      '    and'
      
        #9'  (select max( dg_data_leitura ) from descarga where dg_grupo =' +
        ' R.rt_grupo and dg_rota = R.rt_rota and dg_data_leitura is not n' +
        'ull)'
      #9'),'
      #9'rt_ind_chuva'
      'from roteiros R'
      'where rt_grupo = :grupo'
      'and rt_rota = :rota'
      ')')
    Left = 104
    Top = 112
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'rota'
        ParamType = ptUnknown
      end>
  end
  object qryLeitura: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'insert into DIADEMA_IV.dbo.VOLTA_LEITURA'
      '('
      #9'Grupo,'
      #9'Setor,'
      #9'Rota,'
      #9'CDC,'
      #9'Leitura_Ajustada,'
      #9'Leitura_Real,'
      #9'Data_Leitura,'
      #9'Consumo_Ajustado,'
      #9'consumo_rateado,'
      #9'Esgoto_Ajustado,'
      #9'Dias_Consumo,'
      #9'Ocorrencia,'
      #9'Ocorrencia2,'
      #9'Ident_fraude,'
      #9'Indic_cortado,'
      #9'Operador,'
      #9'Flag_Calculo,'
      #9'Flag_Emissao,'
      #9'Referencia,'
      #9'Data_Emissao,'
      #9'Vencimento,'
      #9'Valor_Agua,'
      #9'Valor_Esgoto,'
      #9'valor_saldo_debito,'
      #9'Valor_Credito,'
      #9'Valor_Reducao,'
      #9'Valor_IR,'
      #9'Valor_CSLL,'
      #9'Valor_PIS,'
      #9'Valor_COFINS,'
      #9'Categoria,'
      #9'Eco_Res,'
      #9'Eco_Com,'
      #9'Eco_Ind,'
      #9'Eco_Pub,'
      #9'Eco_Soc,'
      #9'Flag_Lido, '
      #9'Flag_Faturado'
      ')'
      '('
      'select'
      #9'dg_grupo,'
      
        #9'(select max(cg_setor) from carga where D.dg_matricula = cg_matr' +
        'icula and D.dg_grupo = cg_grupo),'
      #9'dg_rota,'
      #9'dg_matricula,'
      #9'dg_leitura_ajustada,'
      #9'dg_leitura_real,'
      #9'dg_data_leitura,'
      #9'dg_consumo_ajustado,'
      #9'dg_consumo_rateado,'
      #9'CASE'
      
        #9#9'WHEN (select max(cg_natureza_ligacao) from carga where D.dg_ma' +
        'tricula = cg_matricula and D.dg_grupo = cg_grupo) = 2 or'
      
        #9#9#9'  (select max(cg_natureza_ligacao) from carga where D.dg_matr' +
        'icula = cg_matricula and D.dg_grupo = cg_grupo) = 3'
      #9#9#9'THEN dg_consumo_ajustado'
      #9#9'ELSE 0'
      #9'END,'
      #9'dg_dias_consumo,'
      #9'dg_ocorrencia,'
      #9'dg_ocorrencia2,'
      #9'dg_flag_fraude,'
      #9'dg_flag_cortado,'
      #9'dg_agente,'
      #9'dg_flag_calculada,'
      #9'dg_flag_emitida,'
      #9'dg_referencia,'
      #9'dg_data_leitura,'
      
        #9'(select max(cg_data_vencto) from carga where D.dg_matricula = c' +
        'g_matricula and D.dg_grupo = cg_grupo),'
      #9'dg_valor_agua,'
      #9'dg_valor_esgoto,'
      #9'dg_valor_saldo_debito,'
      
        #9'isnull((select sum(sr_valor)-dg_valor_saldo_credito from servic' +
        'os where sr_matricula = dg_matricula and sr_grupo = dg_grupo and' +
        ' sr_ind_credito = '#39'S'#39' and sr_descricao = '#39'CR'#201'DITO'#39'),0) as valor_' +
        'credito,'
      '  dg_valor_devolucao,'
      #9'dg_valor_ir,'
      #9'dg_valor_csll,'
      #9'dg_valor_pis,'
      #9'dg_valor_cofins,'
      
        #9'(select max(cg_categoria) from carga where D.dg_matricula = cg_' +
        'matricula and D.dg_grupo = cg_grupo),'
      
        #9'(select max(cg_economia_res+cg_economia_ea) from carga where D.' +
        'dg_matricula = cg_matricula and D.dg_grupo = cg_grupo),'
      
        #9'(select max(cg_economia_com) from carga where D.dg_matricula = ' +
        'cg_matricula and D.dg_grupo = cg_grupo),'
      
        #9'(select max(cg_economia_ind) from carga where D.dg_matricula = ' +
        'cg_matricula and D.dg_grupo = cg_grupo),'
      
        #9'(select max(cg_economia_pub) from carga where D.dg_matricula = ' +
        'cg_matricula and D.dg_grupo = cg_grupo),'
      
        #9'(select max(cg_economia_soc) from carga where D.dg_matricula = ' +
        'cg_matricula and D.dg_grupo = cg_grupo),'
      #9'dg_flag_lido,'
      #9'dg_flag_faturado'
      'from descarga D'
      'where dg_grupo = :grupo'
      'and dg_rota = :rota'
      ')')
    Left = 104
    Top = 168
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'rota'
        ParamType = ptUnknown
      end>
  end
  object qryDesfazer: TQuery
    DatabaseName = 'dbMain'
    Left = 256
    Top = 112
  end
  object qryGeral: TQuery
    DatabaseName = 'dbMain'
    Left = 256
    Top = 56
  end
  object qryInserirMedicao: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'delete '#9'from medicao'
      'from'#9'roteiros'
      'where'#9'md_grupo = :nGrupo'
      'and'#9'md_rota = :nRota'
      'and'#9'md_grupo = rt_grupo'
      'and'#9'md_rota = rt_rota'
      'and'#9'md_referencia = rt_referencia'
      ''
      'insert into medicao'
      #9'(md_grupo, md_rota, md_referencia, md_agente, md_data_leitura,'
      #9'md_hora_inicio, md_hora_fim,'
      #9'md_ligacoes, md_leitura_campo, md_analise,'
      #9'md_faturado_normal, md_faturado_media, md_faturado_minima,'
      #9'md_emitidas, md_emitidas_2_vezes, md_nao_emitidas,'
      #9'md_emitidas_aviso, md_entrega_mao, md_entrega_visinho,'
      
        #9'md_entrega_porta, md_entraga_correio, md_entrega_recusado, md_e' +
        'ntrega_outro,'
      #9'md_nao_exec, md_fraude, md_para_corte, md_cortado,'
      #9'md_consumo_medido, md_consumo_medido_esg,'
      #9'md_consumo_faturado_res, md_consumo_faturado_res_esg,'
      #9'md_consumo_faturado_com, md_consumo_faturado_com_esg,'
      #9'md_consumo_faturado_ind, md_consumo_faturado_ind_esg,'
      #9'md_consumo_faturado_pub, md_consumo_faturado_pub_esg,'
      #9'md_consumo_faturado_soc, md_consumo_faturado_soc_esg,'
      #9'md_consumo_faturado_ea, md_consumo_faturado_ea_esg,'
      #9'md_valor_agua, md_valor_esgoto,'
      #9'md_valor_servico, md_valor_credito,'
      #9'md_valor_devolucao, md_valor_ir,'
      #9'md_valor_csll, md_valor_pis,'
      #9'md_valor_cofins, md_valor_saldo_debito,'
      #9'md_valor_saldo_credito, md_emitidas_2_vias,'
      #9'md_alteracoes_cadastro, md_inclusao_cadastro,'
      #9'md_leituras_real)'
      
        'select'#9'dg_grupo, dg_rota, dg_referencia, isnull(dg_agente,0), co' +
        'nvert( datetime, convert(char(10), dg_data_leitura, 112)), '
      #9'min(dg_data_leitura), max(dg_data_leitura),'
      #9'count(*), '
      
        #9'sum(case when isnull(dg_vias,1) != 3 then 1 else 0 end), sum(ca' +
        'se when isnull(dg_vias,1)  = 3 then 1 else 0 end),'
      
        #9'sum(case when IsNull(oc_calculo,6) = 6 then 1 else 0 end), sum(' +
        'case when IsNull(oc_calculo,6) in (2, 7) then 1 else 0 end), sum' +
        '(case when IsNull(oc_calculo,6) = 8 then 1 else 0 end), '
      #9'sum(case when isnull(dg_vias,1) = 1 then 1 else 0 end),'
      #9'sum(case when isnull(dg_vias,1) = 2 then 1 else 0 end),'
      
        #9'sum(case when isnull(dg_vias,1) not in (1, 2) then 1 else 0 end' +
        '),'
      
        #9'sum(case when isnull(dg_flag_aviso,'#39'N'#39') in ('#39'S'#39', '#39'1'#39') then 1 el' +
        'se 0 end),'
      
        #9'sum(case when isnull(dg_forma_entrega,7) = 1 then 1 else 0 end)' +
        ','
      
        #9'sum(case when isnull(dg_forma_entrega,7) = 2 then 1 else 0 end)' +
        ','
      
        #9'sum(case when isnull(dg_forma_entrega,7) = 3 then 1 else 0 end)' +
        ','
      
        #9'sum(case when isnull(dg_forma_entrega,7) = 4 then 1 else 0 end)' +
        ','
      
        #9'sum(case when isnull(dg_forma_entrega,7) = 5 then 1 else 0 end)' +
        ','
      
        #9'sum(case when isnull(dg_forma_entrega,7) = 6 then 1 else 0 end)' +
        ','
      
        #9'sum(case when isnull(dg_forma_entrega,7) = 7 then 1 else 0 end)' +
        ','
      
        #9'sum(case when isnull(dg_flag_fraude,'#39'N'#39')  = '#39'S'#39' then 1 else 0 e' +
        'nd),'
      
        #9'sum(case when isnull(cg_flag_cortar,'#39'S'#39')  = '#39'S'#39' then 1 else 0 e' +
        'nd),'
      
        #9'sum(case when isnull(dg_flag_cortado,'#39'N'#39') = '#39'S'#39' then 1 else 0 e' +
        'nd),'
      #9'sum( isnull(dg_consumo_medido,0) ),'
      #9'sum( isnull(dg_consumo_medido_esg,0) ),'
      #9'sum( isnull(dg_consumo_faturado_res,0) ),'
      #9'sum( isnull(dg_consumo_faturado_esg_res,0) ),'
      #9'sum( isnull(dg_consumo_faturado_com,0) ),'
      #9'sum( isnull(dg_consumo_faturado_esg_com,0) ),'
      #9'sum( isnull(dg_consumo_faturado_ind,0) ),'
      #9'sum( isnull(dg_consumo_faturado_esg_ind,0) ),'
      #9'sum( isnull(dg_consumo_faturado_pub,0) ),'
      #9'sum( isnull(dg_consumo_faturado_esg_pub,0) ),'
      #9'sum( isnull(dg_consumo_faturado_soc,0) ),'
      #9'sum( isnull(dg_consumo_faturado_esg_soc,0) ),'
      #9'sum( isnull(dg_consumo_faturado_ea,0) ),'
      #9'sum( isnull(dg_consumo_faturado_esg_ea,0) ),'
      #9'sum( isnull(dg_valor_agua,0) ),'
      #9'sum( isnull(dg_valor_esgoto,0) ),'
      #9'sum( isnull(dg_valor_servico,0) ),'
      #9'sum( isnull(dg_valor_credito,0) ),'
      #9'sum( isnull(dg_valor_devolucao,0) ),'
      #9'sum( isnull(dg_valor_ir,0) ),'
      #9'sum( isnull(dg_valor_csll,0) ),'
      #9'sum( isnull(dg_valor_pis,0) ),'
      #9'sum( isnull(dg_valor_cofins,0) ),'
      #9'sum( isnull(dg_valor_saldo_debito,0) ),'
      #9'sum( isnull(dg_valor_saldo_credito,0) ),'
      #9'0, 0, 0,'
      
        #9'sum( case when isnull(dg_ocorrencia,0) in (71) then 1 else 0 en' +
        'd )'
      'from '#9'descarga'
      'left'#9'outer join carga'
      'on'#9'cg_grupo = dg_grupo'
      'and'#9'cg_rota = dg_rota'
      'and'#9'cg_matricula = dg_matricula'
      'and'#9'cg_referencia = dg_referencia'
      'left'#9'outer join ocorrencias'
      'on'#9'dg_ocorrencia = oc_codigo'
      'and'#9'dg_grupo = oc_grupo'
      'and'#9'dg_referencia = oc_referencia'
      'where'#9'dg_grupo = :nGrupo'
      'and'#9'dg_rota = :nRota'
      
        'group by dg_grupo, dg_rota, dg_referencia, isnull(dg_agente,0), ' +
        'convert( datetime, convert(char(10), dg_data_leitura, 112))'
      ''
      'update '#9'medicao'
      'set'#9'md_emitidas_2_vias = '
      #9#9'(select '#9'count(*) '
      #9#9'from '#9'descarga_seg_vias'
      #9#9'where'#9'ds_grupo = dg_grupo'
      #9#9'and'#9'ds_rota = dg_grupo'
      #9#9'and'#9'ds_referencia = dg_referencia'
      #9#9'and'#9'ds_matricula = dg_matricula)'
      'from'#9'descarga'
      'where'#9'dg_grupo = :nGrupo'
      'and'#9'dg_rota = :nRota'
      'and'#9'dg_grupo = md_grupo'
      'and'#9'dg_rota = md_rota'
      'and'#9'dg_referencia = md_referencia'
      'and'#9'dg_agente = md_agente'
      
        'and'#9'convert( datetime, convert(char(10), dg_data_leitura, 112)) ' +
        '= md_data_leitura'
      ''
      'update '#9'medicao'
      'set'#9'md_alteracoes_cadastro = '
      #9#9'(select '#9'count(*) '
      #9#9'from '#9'descarga_alteracoes'
      #9#9'where'#9'al_grupo = dg_grupo'
      #9#9'and'#9'al_rota = dg_grupo'
      #9#9'and'#9'al_referencia = dg_referencia'
      #9#9'and'#9'al_matricula = dg_matricula'
      #9#9'and'#9'al_matricula > 0'
      #9#9'and'#9'al_agente = md_agente'
      
        #9#9'and'#9'convert( datetime, convert(char(10), al_datahora, 112)) = ' +
        'md_data_leitura)'
      'from'#9'descarga'
      'where'#9'dg_grupo = :nGrupo'
      'and'#9'dg_rota = :nRota'
      'and'#9'dg_grupo = md_grupo'
      'and'#9'dg_rota = md_rota'
      'and'#9'dg_referencia = md_referencia'
      'and'#9'dg_agente = md_agente'
      
        'and'#9'convert( datetime, convert(char(10), dg_data_leitura, 112)) ' +
        '= md_data_leitura'
      ''
      'update '#9'medicao'
      'set'#9'md_inclusao_cadastro = '
      #9#9'(select '#9'count(distinct al_matricula) '
      #9#9'from '#9'descarga_alteracoes'
      #9#9'where'#9'al_grupo = md_grupo'
      #9#9'and'#9'al_rota = md_grupo'
      #9#9'and'#9'al_referencia = md_referencia'
      #9#9'and'#9'al_matricula < 0'
      #9#9'and'#9'al_agente = md_agente'
      
        #9#9'and'#9'convert( datetime, convert(char(10), al_datahora, 112)) = ' +
        'md_data_leitura)'
      'from'#9'roteiros'
      'where'#9'md_grupo = :nGrupo'
      'and'#9'md_rota = :nRota'
      'and'#9'md_grupo = rt_grupo'
      'and'#9'md_rota = rt_rota'
      'and'#9'md_referencia = rt_referencia')
    Left = 104
    Top = 232
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
  object qryDescargaAlteracoes: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'insert into DIADEMA_IV.dbo.VOLTA_ALTERACAO'
      '('
      'Grupo,'
      'CDC,'
      'referencia,'
      'Numero_Imovel,--tipo 2'
      'Complemento,--tipo 4'
      'Medidor,--tipo 1'
      'Nome_Consumidor,--tipo 7'
      'observacao--tipo 8'
      ')'
      '('
      'select distinct'
      #9'D.al_grupo,'
      #9'D.al_matricula,'
      '  D.al_referencia,'
      #9'cast((select top 1 al_descricao '
      #9#9'from descarga_alteracoes I '
      #9#9'where D.al_grupo = I.al_grupo '
      #9#9'and D.al_matricula = I.al_matricula'
      #9#9'and I.al_tipo = 2) as integer) as numero_imovel,'
      #9'cast((select top 1 al_descricao '
      #9#9'from descarga_alteracoes I '
      #9#9'where D.al_grupo = I.al_grupo '
      #9#9'and D.al_matricula = I.al_matricula'
      #9#9'and I.al_tipo = 4) as varchar(10)) as complemento,'
      #9'cast( (select top 1 al_descricao '
      #9#9'from descarga_alteracoes I '
      #9#9'where D.al_grupo = I.al_grupo '
      #9#9'and D.al_matricula = I.al_matricula'
      #9#9'and I.al_tipo = 1) as varchar(11)) as medidor,'
      #9'cast((select top 1 al_descricao '
      #9#9'from descarga_alteracoes I '
      #9#9'where D.al_grupo = I.al_grupo '
      #9#9'and D.al_matricula = I.al_matricula'
      #9#9'and I.al_tipo = 7) as varchar(35)) as nome_consumidor,'
      #9'cast((select top 1 al_descricao '
      #9#9'from descarga_alteracoes I '
      #9#9'where D.al_grupo = I.al_grupo '
      #9#9'and D.al_matricula = I.al_matricula'
      #9#9'and I.al_tipo = 8) as varchar(30)) as observacao'
      #9'from descarga_alteracoes D'
      #9'where D.al_matricula > 0'
      #9'and D.al_grupo = :grupo'
      #9'and D.al_rota = :rota'
      ')'
      ''
      'insert into DIADEMA_IV.dbo.VOLTA_NOVO_REGISTRO'
      '('
      'Grupo,'
      'Rota,'
      'referencia,'
      'Logradouro,--tipo 3'
      'Numero,--tipo 2'
      'Complemento,--tipo 4'
      'Medidor,-- tipo 1'
      'Nome,--tipo 7'
      'OBS--tipo 8'
      ')'
      '('
      'select distinct'
      #9'D.al_grupo,'
      #9'D.al_rota,'
      '  D.al_referencia,'
      #9'cast((select top 1 al_descricao '
      #9#9'from descarga_alteracoes I '
      #9#9'where D.al_grupo = I.al_grupo '
      #9#9'and D.al_matricula = I.al_matricula'
      '    and D.al_rota = I.al_rota'
      #9#9'and I.al_tipo = 3) as varchar(48)) as logradouro,'
      #9'cast((select top 1 al_descricao'
      #9#9'from descarga_alteracoes I'
      #9#9'where D.al_grupo = I.al_grupo'
      #9#9'and D.al_matricula = I.al_matricula'
      '    and D.al_rota = I.al_rota'
      #9#9'and I.al_tipo = 2) as integer) as numero_imovel,'
      #9'cast((select top 1 al_descricao'
      #9#9'from descarga_alteracoes I'
      #9#9'where D.al_grupo = I.al_grupo'
      #9#9'and D.al_matricula = I.al_matricula'
      '    and D.al_rota = I.al_rota'
      #9#9'and I.al_tipo = 4) as varchar(10)) as complemento,'
      #9'cast((select top 1 al_descricao'
      #9#9'from descarga_alteracoes I'
      #9#9'where D.al_grupo = I.al_grupo'
      #9#9'and D.al_matricula = I.al_matricula'
      '    and D.al_rota = I.al_rota'
      #9#9'and I.al_tipo = 1) as varchar(11)) as medidor,'
      #9'cast((select top 1 al_descricao'
      #9#9'from descarga_alteracoes I'
      #9#9'where D.al_grupo = I.al_grupo'
      #9#9'and D.al_matricula = I.al_matricula'
      '    and D.al_rota = I.al_rota'
      #9#9'and I.al_tipo = 7) as varchar(35)) as nome_consumidor,'
      #9'cast((select top 1 al_descricao'
      #9#9'from descarga_alteracoes I'
      #9#9'where D.al_grupo = I.al_grupo'
      #9#9'and D.al_matricula = I.al_matricula'
      '    and D.al_rota = I.al_rota'
      #9#9'and I.al_tipo = 8) as varchar(30)) as observacao'
      #9'from descarga_alteracoes D'
      #9'where'
      #9'D.al_matricula < 0'
      #9'and D.al_grupo = :grupo'
      #9'and D.al_rota = :rota'
      ')'
      '')
    Left = 256
    Top = 168
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'rota'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'rota'
        ParamType = ptUnknown
      end>
  end
  object qryDataLeitura: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'update'#9'descarga'
      'set'#9'dg_data_leitura = '
      
        #9'(select convert( datetime, convert( varchar, isnull( max( isnul' +
        'l(dg_data_leitura, getdate()) ), getdate() ), 112 ) )'
      #9'from '#9'descarga '
      #9'where '#9'dg_grupo = :grupo'
      #9'and'#9'dg_rota = :rota)'
      'where'#9'dg_grupo = :grupo'
      'and'#9'dg_rota = :rota'
      'and'#9'dg_data_leitura is null')
    Left = 208
    Top = 240
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'rota'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'rota'
        ParamType = ptUnknown
      end>
  end
  object qryDiasConsumo: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'update '#9'descarga '
      
        'set '#9'dg_dias_consumo = datediff(d, cg_data_leit_ant, dg_data_lei' +
        'tura ) '
      'from '#9'carga'
      'where '#9'dg_grupo = :grupo'
      'and'#9'dg_rota  = :rota'
      'and'#9'cg_grupo = dg_grupo'
      'and'#9'cg_matricula = dg_matricula'
      'and'#9'dg_dias_consumo is null')
    Left = 304
    Top = 240
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'rota'
        ParamType = ptUnknown
      end>
  end
  object qryOcorrencia: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'update '#9'descarga '
      'set '#9'dg_ocorrencia = '
      #9'case when cg_natureza_ligacao = 3 then 5'
      #9'else isnull( dg_ocorrencia, 0) end'
      'from'#9'carga'
      'where '#9'dg_grupo = :grupo'
      'and'#9'dg_rota  = :rota'
      'and'#9'dg_grupo = cg_grupo'
      'and'#9'dg_matricula = cg_matricula')
    Left = 392
    Top = 240
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'rota'
        ParamType = ptUnknown
      end>
  end
end
