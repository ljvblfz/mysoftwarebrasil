object dmRecepcao: TdmRecepcao
  OldCreateOrder = False
  Height = 465
  Width = 551
  object qryCarga: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'INSERT INTO Carga'
      '('
      #9'cg_matricula,'
      #9'cg_matricula_pai,'
      #9'cg_referencia,'
      #9'cg_grupo,'
      #9'cg_setor,'
      #9'cg_rota,'
      #9'cg_sequencia,'
      #9'cg_endereco,'
      #9'cg_num_imovel,'
      #9'cg_complemento,'
      #9'cg_inscricao,'
      #9'cg_nome,'
      #9'cg_numero_hd,'#9
      #9'cg_capacidade_hidrometro,'
      #9'cg_leitura_ant,'
      #9'cg_ocorrencia_ant,'
      #9'cg_data_leit_ant,'
      #9'cg_consumo_medio,'
      #9'cg_economia_res,'
      #9'cg_economia_com,'
      #9'cg_economia_ind,'
      #9'cg_economia_pub,'
      #9'cg_economia_soc,'
      #9'cg_economia_ea,'
      #9'cg_categoria,'
      #9'cg_qtde_debito_ant,'
      #9'cg_data_vencto,'
      #9'cg_mensagem1,'
      #9'cg_mensagem2,'
      #9'cg_codigo_banco,'
      #9'cg_agencia,'
      #9'cg_flag_troca,'
      #9'cg_leitura_inicial,'
      #9'cg_data_instalacao_hd,'
      #9'cg_consumo_anterior,'
      #9'cg_cachorro,'
      #9'cg_natureza_ligacao,'
      #9'cg_bloqueado,'
      #9'cg_qtde_registros_fraude,'
      #9'cg_desconto,'
      #9'cg_ident_consumidor,'
      #9'cg_ident_calculo,'
      #9'cg_flag_emite_conta,'
      #9'cg_flag_cortar,'
      #9'cg_flag_calcula_imposto,'
      #9'cg_entrega_alternativa,'
      #9'cg_flag_calcula_conta,'
      #9'cg_dias_bloqueio_tarifa_ant,'
      #9'cg_dias_bloqueio_tarifa_atual,'
      #9'cg_virtual,'
      '  cg_cod_logradouro,'
      '  cg_data_bloqueio,'
      '  cg_proxima_leitura'
      ')'
      '('
      #9'select'
      #9#9'L.cdc,'
      #9#9'isnull(L.cdc_pai,0),'
      #9#9'G.referencia,'
      #9#9'L.grupo,'
      #9#9'L.setor,'
      #9#9'L.rota,'
      #9#9'L.sequencia,'
      #9#9'E.nome,'
      #9#9'L.numero_imovel,'
      #9#9'L.complemento,'
      #9#9'L.inscricao,'
      #9#9'L.nome,'
      #9#9'L.medidor,'
      #9#9'L.qtde_ponteiros,'
      
        #9#9'case when H.data_leitura is null then isnull(L.leitura_inicial' +
        '_hd,0) else isnull(H.leitura,0) end,'
      
        #9#9'case when H.data_leitura is null then 71 else H.ocorrencia end' +
        ','
      
        #9#9'case when H.data_leitura is null then IsNull(L.Data_Inst_HD, (' +
        'G.data_leitura-30)) else H.data_leitura end,'
      #9#9'L.media,'
      #9#9'CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_res END,'
      #9#9'CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_com END,'
      #9#9'CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_ind END,'
      #9#9'CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_pub END,'
      #9#9'CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_soc END,'
      #9#9'CASE L.categoria_imovel '
      
        #9#9#9'WHEN 8 THEN (L.eco_res + L.eco_com + L.eco_ind + L.eco_pub + ' +
        'L.eco_soc)'
      #9#9#9'ELSE 0'
      #9#9'END,'
      #9#9'L.categoria_imovel,'
      #9#9'isnull(L.qtde_debitos,0),'
      #9#9'L.data_vencimento,'
      #9#9'isnull(L.mensagem1,'#39#39') as cg_mensagem1,'
      #9#9'isnull(L.mensagem2,'#39#39') as cg_mensagem2,'
      #9#9'L.banco,'
      #9#9'L.agencia,'
      #9#9'CASE '
      
        #9#9#9'WHEN ((L.Data_Inst_HD > isnull(H.data_leitura,getdate())) and' +
        ' (IsNull(Ident_Ligacao_Nova,'#39'N'#39') != '#39'S'#39'))'
      '      THEN '#39'S'#39
      #9#9#9'ELSE '#39'N'#39
      #9#9'END as cg_flag_troca,'
      #9#9'L.leitura_inicial_hd,'
      #9#9'CASE'
      
        #9#9#9'WHEN ((L.Data_Inst_HD > isnull(H.data_leitura,getdate())) and' +
        ' (IsNull(Ident_Ligacao_Nova,'#39'N'#39') != '#39'S'#39'))'
      '      THEN L.data_inst_hd'
      #9#9#9'ELSE null'
      #9#9'END as cg_data_instalacao_hd,'
      #9#9'IsNull(H.consumo,0),'
      #9#9'L.cachorro,'
      #9#9'L.natureza_ligacao,'
      #9#9'L.bloqueado,'
      #9#9'isnull(L.qtde_registros_fraude,0) as cg_qtde_registros_fraude,'
      
        #9#9'case when (L.clas_imovel in (4, 64)) and (isnull(L.cdc_pai,0) ' +
        '= 0) then 0 else L.clas_imovel end,'
      '    /*EMITE_CONTA*/'
      
        #9#9'case when (isnull(L.cdc_pai,0) = 0) and (L.ident_consumidor = ' +
        '3) then 1 else L.ident_consumidor end,'
      #9#9'L.ident_calculo,'
      #9#9'CASE /*EMITE_CONTA*/'
      #9#9#9'WHEN (L.ident_consumidor = 1)'
      #9#9#9#9'THEN L.emite_conta'
      #9#9#9'WHEN (L.ident_consumidor = 2) and (L.cdc <> L.cdc_pai)'
      #9#9#9#9'THEN L.emite_conta'
      #9#9#9'WHEN (L.ident_consumidor = 3) and (L.cdc = L.cdc_pai)'
      #9#9#9#9'THEN L.emite_conta'
      #9#9#9'WHEN (L.ident_consumidor = 4) and (L.cdc = L.cdc_pai)'
      #9#9#9#9'THEN L.emite_conta'
      #9#9#9'WHEN (L.ident_consumidor = 5) and (L.cdc = L.cdc_pai)'
      #9#9#9#9'THEN L.emite_conta'
      #9#9#9'WHEN (L.ident_consumidor = 6) and (L.cdc = L.cdc_pai)'
      #9#9#9#9'THEN L.emite_conta'
      #9#9#9'WHEN (L.ident_consumidor = 7) and (L.cdc = L.cdc_pai)'
      #9#9#9#9'THEN L.emite_conta'
      #9#9#9'WHEN (L.ident_consumidor = 8) and (L.cdc = L.cdc_pai)'
      #9#9#9#9'THEN L.emite_conta'
      #9#9#9'WHEN (L.ident_consumidor = 9) and (L.cdc <> L.cdc_pai)'
      #9#9#9#9'THEN L.emite_conta'
      #9#9#9'WHEN (L.ident_consumidor = 10) and (L.cdc = L.cdc_pai)'
      #9#9#9#9'THEN L.emite_conta'
      #9#9#9'ELSE'
      #9#9#9#9#39'N'#39
      #9#9'END,'
      #9#9'CASE'
      '      WHEN isnull(L.cortar,'#39#39') = '#39#39
      '        THEN '#39'N'#39
      '      ELSE'
      '        L.cortar'
      '    END,'
      #9#9'L.calcula_imposto,'
      #9#9'isnull(L.endereco_entrega, '#39#39') as cg_entrega_alternativa,'
      #9#9'CASE /*CALCULA_CONTA*/'
      #9#9#9'WHEN (L.ident_consumidor = 1)'
      #9#9#9#9'THEN L.calcula_conta'
      #9#9#9'WHEN (L.ident_consumidor = 2) and (L.cdc <> L.cdc_pai)'
      #9#9#9#9'THEN L.calcula_conta'
      #9#9#9'WHEN (L.ident_consumidor = 3) and (L.cdc = L.cdc_pai)'
      #9#9#9#9'THEN L.calcula_conta'
      #9#9#9'WHEN (L.ident_consumidor = 4) and (L.cdc = L.cdc_pai)'
      #9#9#9#9'THEN L.calcula_conta'
      #9#9#9'WHEN (L.ident_consumidor = 5) and (L.cdc = L.cdc_pai)'
      #9#9#9#9'THEN L.calcula_conta'
      #9#9#9'WHEN (L.ident_consumidor = 6) and (L.cdc = L.cdc_pai)'
      #9#9#9#9'THEN L.calcula_conta'
      #9#9#9'WHEN (L.ident_consumidor = 7) and (L.cdc = L.cdc_pai)'
      #9#9#9#9'THEN L.calcula_conta'
      #9#9#9'WHEN (L.ident_consumidor = 8) and (L.cdc = L.cdc_pai)'
      #9#9#9#9'THEN L.calcula_conta'
      #9#9#9'WHEN (L.ident_consumidor = 9) and (L.cdc <> L.cdc_pai)'
      #9#9#9#9'THEN L.calcula_conta'
      #9#9#9'WHEN (L.ident_consumidor = 10) and (L.cdc = L.cdc_pai)'
      #9#9#9#9'THEN L.calcula_conta'
      #9#9#9'ELSE'
      #9#9#9#9#39'N'#39
      #9#9'END,'
      #9#9'dias_bloqueio_tarifa_ant,'
      #9#9'dias_bloqueio_tarifa_atual,'
      #9#9'CASE  /*VIRTUAL*/'
      #9#9#9'WHEN (L.ident_consumidor = 1) '
      #9#9#9#9'THEN '#39'N'#39
      #9#9#9'WHEN (L.ident_consumidor = 2) and (L.cdc = L.cdc_pai) '
      #9#9#9#9'THEN '#39'N'#39
      #9#9#9'WHEN (L.ident_consumidor = 9) '
      #9#9#9#9'THEN '#39'N'#39
      #9#9#9'WHEN (L.ident_consumidor <> 1) and '
      #9#9#9#9#9'(L.ident_consumidor <> 2) and'
      #9#9#9#9#9'(L.ident_consumidor <> 9) and'
      #9#9#9#9#9'(L.cdc <> L.cdc_pai)'
      #9#9#9#9'THEN '#39'N'#39
      #9#9#9'ELSE'
      #9#9#9#9#39'S'#39
      #9#9'END,'
      '    L.codigo_logradouro,'
      '    CASE'
      '      WHEN L.bloqueado <> '#39'L'#39
      '        THEN L.data_bloqueio'
      '      ELSE'
      '        null'
      '    END,'
      '    G.data_proxima_leitura'
      #9'from '#9'DIADEMA_IV.dbo.IDA_GRUPOS G, '
      #9#9'DIADEMA_IV.dbo.IDA_LOGRADOUROS E, '
      #9#9'DIADEMA_IV.dbo.IDA_LIGACOES L'
      #9'LEFT'#9'OUTER JOIN DIADEMA_IV.dbo.IDA_HISTORICOS_CONSUMO H'
      #9#9'ON L.cdc = H.cdc'
      ' '#9#9'and L.grupo = H.grupo'
      #9#9'and H.referencia = (select MAX(referencia)'
      #9#9#9#9'from DIADEMA_IV.dbo.IDA_HISTORICOS_CONSUMO H2'
      #9#9#9#9'where '#9'H2.GRUPO = L.GRUPO'
      #9#9#9#9'AND'#9'H2.cdc = L.cdc)'
      #9'where L.grupo = :Grupo'
      #9'AND'#9'L.grupo = G.grupo'
      '        and E.grupo = L.grupo'
      #9'and L.codigo_logradouro = E.codigo'
      #9#9'and G.Data_Processamento is null'
      ')')
    Left = 72
    Top = 24
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
  end
  object qryDebitos: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'insert into debitos'
      '('
      #9'db_matricula,'
      #9'db_grupo,'
      '  db_rota,'
      #9'db_referencia,'
      #9'db_tipo,'
      #9'db_qtde_debitos,'
      #9'db_valor_total,'
      #9'db_data_vencimento,'
      #9'db_codigo_barras'
      ')'
      '('
      #9'select'
      #9#9'D.cdc,'
      #9#9'L.grupo,'
      '    L.rota,'
      #9#9'(select referencia'
      '      from DIADEMA_IV.dbo.IDA_GRUPOS'
      '      where grupo = L.grupo'
      '      and data_processamento is null),'
      #9#9'D.tipo,'
      #9#9'D.qtde_debitos,'
      #9#9'D.valor_total,'
      #9#9'D.data_vencimento,'
      #9#9'D.codigo_barras'
      #9'from'
      #9#9'DIADEMA_IV.dbo.IDA_LIGACOES L,'
      #9#9'DIADEMA_IV.dbo.IDA_DEBITOS D'
      #9'where L.cdc = D.cdc'
      #9#9#9'and L.grupo = :grupo'
      '      and D.grupo = :grupo'
      ')')
    Left = 72
    Top = 72
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
  end
  object qryDebitosItens: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'insert into debitos_itens'
      '('
      #9'di_matricula,'
      #9'di_grupo,'
      #9'di_referencia,'
      #9'di_referencia_debito,'
      #9'di_valor,'
      #9'di_sequencia'
      ')'
      '('
      #9'select'
      #9#9'DI.cdc,'
      #9#9':grupo,'
      #9#9'(select referencia'
      '      from DIADEMA_IV.dbo.IDA_GRUPOS'
      '      where grupo = :grupo'
      '      and data_processamento is null),'
      #9#9'DI.referencia,'
      #9#9'DI.valor,'
      #9#9'(select count(*) + 1'
      #9#9#9'from DIADEMA_IV.dbo.IDA_DEBITOS_ITENS DI2'
      #9#9#9'where DI.cdc = DI2.cdc'
      '      and DI.grupo = DI2.grupo'
      #9#9#9'and DI2.referencia < DI.referencia) as sequencia'
      #9'from'
      #9#9'DIADEMA_IV.dbo.IDA_DEBITOS_ITENS DI'
      '  where'
      '    DI.grupo = :grupo'
      ')')
    Left = 72
    Top = 120
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
  end
  object qryDescontos: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'insert into descontos'
      '('
      #9'de_grupo,'
      #9'de_referencia,'
      #9'de_codigo,'
      #9'de_percentual,'
      #9'de_limite_inicial,'
      #9'de_tipo_desconto'
      ')'
      '('
      #9'select'
      #9#9'grupo,'
      #9#9'(select referencia'
      '      from DIADEMA_IV.dbo.IDA_GRUPOS'
      '      where grupo = :grupo'
      '      and data_processamento is null),'
      #9#9'codigo,'
      #9#9'percentual,'
      #9#9'limite_inicial,'
      #9#9'indicativo_desconto'
      #9'from'
      #9#9'DIADEMA_IV.dbo.IDA_CLASSIFICACAO_IMOVEIS'
      '  where grupo = :grupo'
      ')')
    Left = 72
    Top = 168
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
  end
  object qryHistoricoConsumo: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'insert into HISTORICO_CONSUMO'
      '('
      #9'hc_matricula,'
      #9'hc_grupo,'
      #9'hc_referencia,'
      #9'hc_setor_leitura,'
      #9'hc_consumo,'
      #9'hc_ocorrencia_leitura,'
      #9'hc_dias_consumo,'
      #9'hc_ref_historico,'
      #9'hc_leitura,'
      #9'hc_data_leitura,'
      '  hc_leitura_real,'
      '  hc_sequencia'
      ''
      ')'
      '('
      #9'select'
      #9#9'H.cdc,'
      #9#9'L.grupo,'
      #9#9'G.referencia,'
      #9#9'L.setor,'
      #9#9'H.consumo,'
      #9#9'H.ocorrencia,'
      #9#9'H.dias_consumo,'
      #9#9'H.referencia,'
      #9#9'H.leitura,'
      #9#9'H.data_leitura,'
      '    H.leitura_real,'
      #9#9'(select count(*) + 1 '
      #9#9#9'from  DIADEMA_IV.dbo.IDA_HISTORICOS_CONSUMO H2 '
      #9#9#9'where H2.cdc = H.cdc'
      '        and H2.grupo = H.grupo'
      #9#9#9#9'and H2.referencia < H.referencia) as sequencia'
      #9'from'
      #9#9'DIADEMA_IV.dbo.IDA_HISTORICOS_CONSUMO H,'
      '    DIADEMA_IV.dbo.IDA_LIGACOES L,'
      '    DIADEMA_IV.dbo.IDA_GRUPOS G'
      #9'where'
      #9#9'L.cdc = H.cdc'
      #9#9'and L.grupo = G.grupo'
      '    and G.data_processamento is null'
      #9#9'and L.grupo = :grupo'
      '    and H.grupo = :grupo'
      ')'
      '')
    Left = 72
    Top = 216
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
  end
  object qryImpostos: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'insert into impostos'
      '('
      #9'ip_grupo,'
      #9'ip_referencia,'
      #9'ip_data_inicial,'
      #9'ip_ir,'
      #9'ip_csll,'
      #9'ip_pis,'
      #9'ip_cofins'
      ''
      ')'
      '('
      #9'select'
      #9#9'grupo,'
      #9#9'(select referencia'
      '      from DIADEMA_IV.dbo.IDA_GRUPOS'
      '      where grupo = :grupo'
      '      and data_processamento is null),'
      #9#9'data_inicial,'
      #9#9'ir,'
      #9#9'csll,'
      #9#9'pis,'
      #9#9'cofins'
      #9'from'
      #9#9'DIADEMA_IV.dbo.IDA_IMPOSTOS I'
      '  where'
      '    I.grupo = :grupo'
      ')'
      ''
      '')
    Left = 72
    Top = 264
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
  end
  object qryAgentes: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'insert into agentes'
      '('
      #9'ag_grupo,'
      #9'ag_referencia,'
      #9'ag_codigo,'
      #9'ag_nome,'
      #9'ag_senha'
      ')'
      '('
      #9'select'
      #9#9'grupo,'
      #9#9'(select referencia'
      '      from DIADEMA_IV.dbo.IDA_GRUPOS'
      '      where grupo = :grupo'
      '      and data_processamento is null),'
      #9#9'codigo,'
      #9#9'nome,'
      #9#9'senha'
      #9'from'
      #9#9'DIADEMA_IV.dbo.IDA_AGENTES'
      '  where'
      '    grupo = :grupo'
      ')')
    Left = 72
    Top = 312
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
  end
  object qryMensagens: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'insert into mensagens'
      '('
      #9'mg_grupo,'
      #9'mg_referencia,'
      #9'mg_data_inicial,'
      #9'mg_descricao1,'
      #9'mg_descricao2,'
      #9'mg_descricao3'
      ''
      ')'
      '('
      #9'select'
      #9#9'grupo,'
      #9#9'(select referencia'
      '      from DIADEMA_IV.dbo.IDA_GRUPOS'
      '      where grupo = :grupo'
      '      and data_processamento is null),'
      #9#9'M.data_inicial,'
      #9#9'M.mensagem1,'
      #9#9'M.mensagem2,'
      #9#9'M.mensagem3'
      #9'from'
      #9#9'DIADEMA_IV.dbo.IDA_MENSAGENS M'
      '  where'
      '    M.grupo = :grupo'
      ')')
    Left = 72
    Top = 360
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
  end
  object qryOcorrencias: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'insert into ocorrencias'
      '('
      #9'oc_grupo,'
      #9'oc_referencia,'
      #9'oc_codigo,'
      #9'oc_descricao,'
      #9'oc_calculo,'
      #9'oc_mensagem,'
      #9'oc_acesso'
      ')'
      '('
      #9'select'
      #9#9'grupo,'
      #9#9'(select referencia'
      '      from DIADEMA_IV.dbo.IDA_GRUPOS'
      '      where grupo = :grupo'
      '      and data_processamento is null),'
      #9#9'codigo,'
      #9#9'descricao,'
      #9#9'calculo,'
      #9#9'mensagem,'
      #9#9'acesso'
      #9'from'
      #9#9'DIADEMA_IV.dbo.IDA_OCORRENCIAS'
      '  where'
      '    grupo = :grupo'
      ')'
      ''
      ''
      '')
    Left = 224
    Top = 24
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
  end
  object qryRoteiros: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'insert into roteiros'
      '(                               '
      #9'rt_grupo,'
      #9'rt_rota,'
      #9'rt_referencia,'
      #9'rt_data_vencto,'
      '  rt_data_recepcao,'
      #9'rt_ordem_inicial,'
      #9'rt_ordem_final,'
      #9'rt_ind_leitura,'
      #9'rt_leitura_prev,'
      #9'rt_maleta,'
      #9'rt_data_carga,'
      #9'rt_data_descarga,'
      #9'rt_data_transmissao,'
      '  rt_data_prox_leitura'
      ')'
      '('
      #9'select distinct'
      #9#9'L.grupo,'
      #9#9'L.rota,'
      #9#9'G.referencia,'
      #9#9'(select MIN(data_vencimento) from'
      #9#9#9'(select COUNT(*) as total, data_vencimento'
      #9#9#9'from DIADEMA_IV.dbo.IDA_LIGACOES'
      '      where grupo = :grupo'
      #9#9#9'group by data_vencimento) as totais) as data_vencimento,'
      #9#9'G.data_envio,'
      #9#9'(select MIN(sequencia)'
      #9#9#9'from DIADEMA_IV.dbo.IDA_LIGACOES L2'
      #9#9#9'where L2.grupo = L.grupo'
      #9#9#9'and L2.rota = L.rota) as sequencia_inicial,'
      #9#9'(select MAX(sequencia)'
      #9#9#9'from DIADEMA_IV.dbo.IDA_LIGACOES L2'
      #9#9#9'where L2.grupo = L.grupo'
      #9#9#9'and L2.rota = L.rota) as sequencia_final,'
      #9#9'1 ,'
      #9#9'G.data_leitura,'
      #9#9'null ,'
      #9#9'null ,'
      #9#9'null ,'
      '    null ,'
      '    G.data_proxima_leitura'
      #9'from'
      #9#9'DIADEMA_IV.dbo.IDA_GRUPOS G,'
      '    DIADEMA_IV.dbo.IDA_LIGACOES L'
      #9'where'
      #9#9'L.grupo = G.grupo'
      #9#9'and L.grupo = :grupo'
      ')')
    Left = 224
    Top = 72
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
  end
  object qrySegundasVias: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'insert into segundas_vias'
      '('
      #9'sv_matricula,'
      #9'sv_grupo,'
      '  sv_rota,'
      #9'sv_referencia,'
      #9'sv_referencia_seg_via,'
      #9'sv_data_vencimento,'
      #9'sv_data_leitura,'
      #9'sv_data_leitura_anterior,'
      #9'sv_leitura_atual,'
      #9'sv_leitura_anterior,'
      #9'sv_dias_consumo,'
      #9'sv_consumo_faturado,'
      #9'sv_media,'
      #9'sv_ref_cons_1,'
      #9'sv_cons_1,'
      #9'sv_ref_cons_2,'
      #9'sv_cons_2,'
      #9'sv_ref_cons_3,'
      #9'sv_cons_3,'
      #9'sv_ref_cons_4,'
      #9'sv_cons_4,'
      #9'sv_ref_cons_5,'
      #9'sv_cons_5,'
      #9'sv_ref_cons_6,'
      #9'sv_cons_6,'
      #9'sv_servico_01,'
      #9'sv_valor_01,'
      #9'sv_servico_02,'
      #9'sv_valor_02,'
      #9'sv_servico_03,'
      #9'sv_valor_03,'
      #9'sv_servico_04,'
      #9'sv_valor_04,'
      #9'sv_servico_05,'
      #9'sv_valor_05,'
      #9'sv_servico_06,'
      #9'sv_valor_06,'
      #9'sv_servico_07,'
      #9'sv_valor_07,'
      #9'sv_servico_08,'
      #9'sv_valor_08,'
      #9'sv_servico_09,'
      #9'sv_valor_09,'
      #9'sv_valor_total,'
      #9'sv_codigo_barras,'
      #9'sv_ocorrencia'
      ''
      ')'
      ''
      '('
      #9'select'
      #9#9'SV.cdc,'
      #9#9'L.grupo,'
      '    L.rota,'
      #9#9'(select referencia'
      '    from DIADEMA_IV.dbo.IDA_GRUPOS'
      '    where grupo = L.grupo'
      '    and data_processamento is null),'
      #9#9'SV.referencia,'
      #9#9'SV.data_vencimento,'
      #9#9'SV.data_leitura,'
      #9#9'SV.data_leitura_anterior,'
      #9#9'SV.leitura_atual,'
      #9#9'SV.leitura_anterior,'
      #9#9'SV.dias_consumo,'
      #9#9'SV.consumo_faturado,'
      #9#9'SV.media,'
      #9#9'isnull(SV.ref_cons_1,getdate()),'
      #9#9'isnull(SV.cons_1,0),'
      #9#9'isnull(SV.ref_cons_2,getdate()),'
      #9#9'isnull(SV.cons_2,0),'
      #9#9'isnull(SV.ref_cons_3,getdate()),'
      #9#9'isnull(SV.cons_3,0),'
      #9#9'isnull(SV.ref_cons_4,getdate()),'
      #9#9'isnull(SV.cons_4,0),'
      #9#9'isnull(SV.ref_cons_5,getdate()),'
      #9#9'isnull(SV.cons_5,0),'
      #9#9'isnull(SV.ref_cons_6,getdate()),'
      #9#9'isnull(SV.cons_6,0),'
      #9#9'isnull(SV.servico_01,'#39#39'),'
      #9#9'isnull(SV.valor_01,0),'
      #9#9'isnull(SV.servico_02,'#39#39'),'
      #9#9'isnull(SV.valor_02,0),'
      #9#9'isnull(SV.servico_03,'#39#39'),'
      #9#9'isnull(SV.valor_03,0),'
      #9#9'isnull(SV.servico_04,'#39#39'),'
      #9#9'isnull(SV.valor_04,0),'
      #9#9'isnull(SV.servico_05,'#39#39'),'
      #9#9'isnull(SV.valor_05,0),'
      #9#9'isnull(SV.servico_06,'#39#39'),'
      #9#9'isnull(SV.valor_06,0),'
      #9#9'isnull(SV.servico_07,'#39#39'),'
      #9#9'isnull(SV.valor_07,0),'
      #9#9'isnull(SV.servico_08,'#39#39'),'
      #9#9'isnull(SV.valor_08,0),'
      #9#9'isnull(SV.servico_09,'#39#39'),'
      #9#9'isnull(SV.valor_09,0),'
      #9#9'isnull(SV.valor_total,0),'
      
        #9#9'isnull(SV.codigo_barras,'#39'0000000000000000000000000000000000000' +
        '0000000'#39'),'
      #9#9'isnull(SV.ocorrencia,0)'
      #9'from'
      #9#9'DIADEMA_IV.dbo.IDA_LIGACOES L, '
      #9#9'DIADEMA_IV.dbo.IDA_SEGUNDAS_VIAS SV'
      #9'where L.cdc = SV.cdc'
      #9#9#9'and L.grupo = :grupo'
      '      and SV.grupo = :grupo'
      ''
      ')')
    Left = 224
    Top = 120
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
  end
  object qryServicos: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'insert into servicos'
      '('
      #9'sr_matricula,'
      #9'sr_grupo,'
      '  sr_rota,'
      #9'sr_referencia,'
      #9'sr_sequencia,'
      #9'sr_descricao,'
      #9'sr_valor,'
      #9'sr_ind_credito'
      ')'
      '('
      #9'select'
      #9#9'C.cdc,'
      #9#9'G.grupo,'
      '    L.rota,'
      #9#9'G.referencia,'
      #9#9'isnull('
      '            (select MAX(sr_sequencia) + 1'
      '            from servicos'
      '            where sr_matricula = C.cdc)'
      '            ,1) as sequencia,'
      #9#9#39'CR'#201'DITO'#39','
      '    CASE'
      '      WHEN C.valor >= 0 THEN C.valor'
      '      ELSE ( -1 *(C.valor))'
      '    END,'
      '    '#39'S'#39
      #9'from DIADEMA_IV.dbo.IDA_CREDITOS C,'
      '    DIADEMA_IV.dbo.IDA_LIGACOES L,'
      '    DIADEMA_IV.dbo.IDA_GRUPOS G'
      #9'where C.cdc = L.cdc'
      #9#9#9'and L.grupo = G.grupo'
      #9#9#9'and L.grupo = :grupo'
      '      and G.data_processamento is null'
      '      and C.grupo = :grupo'
      ''
      ')'
      ''
      ''
      'insert into servicos'
      '('
      #9'sr_matricula,'
      #9'sr_grupo,'
      '  sr_rota,'
      #9'sr_referencia,'
      #9'sr_sequencia,'
      #9'sr_descricao,'
      #9'sr_valor,'
      #9'sr_ind_credito'
      ')'
      '('
      #9'select'
      #9#9'S.cdc,'
      #9#9'L.grupo,'
      '    L.rota,'
      #9#9'G.referencia,'
      #9#9'CASE'
      
        #9#9#9'WHEN EXISTS (select sr_sequencia from servicos where sr_matri' +
        'cula = S.cdc)'
      #9#9#9'THEN S.sequencia + 1'
      #9#9#9'ELSE S.sequencia'
      #9#9'END,'
      #9#9'S.descricao,'
      '    CASE'
      '      WHEN S.valor >= 0 THEN S.valor'
      '      ELSE ( -1 *(S.valor))'
      '    END,'
      '    CASE'
      '      WHEN S.valor >= 0 THEN '#39'N'#39
      '      ELSE '#39'S'#39
      '    END'
      #9'from'
      #9#9'DIADEMA_IV.dbo.IDA_SERVICOS S,'
      '    DIADEMA_IV.dbo.IDA_LIGACOES L,'
      '    DIADEMA_IV.dbo.IDA_GRUPOS G'
      #9'where'
      #9#9'L.grupo *= G.grupo'
      #9#9'and S.cdc = L.cdc'
      #9#9'and L.grupo = :grupo'
      '    and G.data_processamento is null'
      '    and S.grupo = :grupo'
      ''
      ''
      ')'
      ''
      ''
      '/*'
      'select * from DIADEMA_IV.dbo.IDA_CREDITOS'
      '*/')
    Left = 224
    Top = 168
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
  end
  object qryTarifas: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'insert into tarifas'
      '('
      #9'tr_grupo,'
      #9'tr_referencia,'
      #9'tr_categoria,'
      #9'tr_data_inicial,'
      #9'tr_faixa_inicial,'
      #9'tr_faixa_final,'
      #9'tr_agua,'
      #9'tr_esgoto,'
      #9'tr_sequencia'
      ')'
      '('
      #9'select'
      #9#9'grupo,'
      #9#9'(select referencia'
      '      from DIADEMA_IV.dbo.IDA_GRUPOS'
      '      where grupo = :grupo'
      #9#9'and data_processamento is null'
      #9#9'and data_retorno is null),'
      #9#9'T.categoria,'
      #9#9'T.data_vigencia,'
      #9#9'CASE'
      #9#9#9'WHEN ('
      #9#9#9#9'select count(*) '
      #9#9#9#9'from DIADEMA_IV.dbo.IDA_TARIFAS T2 '
      #9#9#9#9'where T2.data_vigencia = T.data_vigencia'
      #9#9#9#9'and T2.categoria = T.categoria'
      '        and T2.data_vigencia = T.data_vigencia'
      #9#9#9#9'and T2.limite_consumo < T.limite_consumo'
      '        and T2.grupo = T.grupo'
      #9#9#9') = 0'
      #9#9#9'THEN 0'
      #9#9#9'ELSE'
      #9#9#9#9'('
      #9#9#9#9'select TOP 1 T2.limite_consumo + 1'
      #9#9#9#9'from DIADEMA_IV.dbo.IDA_TARIFAS T2'
      #9#9#9#9'where T2.data_vigencia = T.data_vigencia'
      #9#9#9#9'and T2.categoria = T.categoria'
      '        and T2.data_vigencia = T.data_vigencia'
      #9#9#9#9'and T2.limite_consumo < T.limite_consumo'
      '        and T2.grupo = T.grupo'
      #9#9#9#9'order by limite_consumo desc'
      #9#9#9')'
      #9#9'END,'
      #9#9'T.limite_consumo,'
      #9#9'T.agua,'
      #9#9'T.esgoto,'
      #9#9'(select count(*) + 1'
      #9#9#9'from  DIADEMA_IV.dbo.IDA_TARIFAS T2'
      #9#9#9'where T2.categoria = T.categoria'
      '        and T2.data_vigencia = T.data_vigencia'
      #9#9#9#9'and T2.limite_consumo < T.limite_consumo'
      '        and T2.data_vigencia = T.data_vigencia'
      '        and T2.grupo = T.grupo) as sequencia'
      #9'from'
      #9#9'DIADEMA_IV.dbo.IDA_TARIFAS T'
      '  where T.grupo = :grupo'
      ''
      ')'
      ''
      '')
    Left = 224
    Top = 224
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
  end
  object qryQualidadeAgua: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'insert into qualidades_agua'
      '('
      #9'qa_grupo,'
      #9'qa_referencia,'
      #9'qa_data,'
      #9'qa_turbidez,'
      #9'qa_cloro,'
      #9'qa_coliformes_totais,'
      #9'qa_coliformes_termotolerantes,'
      #9'qa_ph,'
      #9'qa_cor,'
      #9'qa_fluoreto,'
      #9'qa_turbidez_Amostras,'
      #9'qa_turbidez_Nao_Conformes,'
      #9'qa_cloro_Amostras,'
      #9'qa_cloro_Nao_Conformes,'
      #9'qa_coliformes_Totais_Amostras,'
      #9'qa_coliformes_Totais_Nao_Conformes,'
      #9'qa_coliformes_Termotolerantes_Amostras,'
      #9'qa_coliformes_Termotolerantes_Nao_Conformes,'
      #9'qa_pH_Amostras,'
      #9'qa_pH_Nao_Conformes,'
      #9'qa_cor_Amostras,'
      #9'qa_cor_Nao_Conformes,'
      #9'qa_fluoreto_Amostras,'
      #9'qa_fluoreto_Nao_Conformes'
      ''
      ')'
      '('
      #9'select'
      #9#9'grupo,'
      #9#9'(select referencia'
      #9#9'      from '#9#9'DIADEMA_IV.dbo.IDA_GRUPOS'
      #9#9'      where '#9'grupo = :grupo'
      #9#9'      and '#9#9'data_processamento is null),'
      #9#9'data,'
      #9#9'turbidez,'
      #9#9'cloro,'
      #9#9'coliformes_totais,'
      #9#9'coliformes_termotolerantes,'
      #9#9'ph,'
      #9#9'cor,'
      #9#9'fluoreto,'
      #9#9'isnull(Turbidez_Amostras, 150),'
      #9#9'isnull(Turbidez_Nao_Conformes, 0),'
      #9#9'isnull(Cloro_Amostras, 150),'
      #9#9'isnull(Cloro_Nao_Conformes, 0),'
      #9#9'isnull(Coliformes_Totais_Amostras, 150),'
      #9#9'isnull(Coliformes_Totais_Nao_Conformes, 0),'
      #9#9'isnull(Coliformes_Termotolerantes_Amostras, 150),'
      #9#9'isnull(Coliformes_Termotolerantes_Nao_Conformes, 0),'
      #9#9'isnull(pH_Amostras, 150),'
      #9#9'isnull(pH_Nao_Conformes, 0),'
      #9#9'isnull(Cor_Amostras, 150),'
      #9#9'isnull(Cor_Nao_Conformes, 0),'
      #9#9'isnull(Fluoreto_Amostras, 150),'
      #9#9'isnull(Fluoreto_Nao_Conformes, 0)'
      #9'from'
      #9#9'DIADEMA_IV.dbo.IDA_QUALIDADE_AGUA'
      '  where grupo = :grupo'
      '  and data = '
      '          (  select max(data)'
      '             from DIADEMA_IV.dbo.IDA_QUALIDADE_AGUA'
      '             where grupo = :grupo'
      '          )'
      ')')
    Left = 224
    Top = 280
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
  end
  object qryGeral: TQuery
    DatabaseName = 'dbMain'
    Left = 400
    Top = 32
  end
  object qryDesfazer: TQuery
    DatabaseName = 'dbMain'
    Left = 400
    Top = 104
  end
  object qryValida: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'declare'#9'@nQtde'#9#9'int'
      ''
      #9'-- apaga as ocorr'#234'ncias existentes'
      #9'begin tran'
      '   '#9'delete '#9'from dbo.report_ocorrencia'
      #9'where'#9'ro_grupo = :grupo'
      #9'and'#9'ro_referencia = :referencia'
      #9'commit'
      ''
      #9'-- VALIDA A QUANTIDA DE REGISTRO NA TABELA IDA_GRUPO'
      #9'select '#9'@nQtde = count(*)'
      #9'from'#9'DIADEMA_IV.dbo.IDA_GRUPOS'
      #9'where'#9'Referencia = :referencia'
      #9'and'#9'Grupo = :grupo'
      #9'if @nQtde = 0 begin'
      #9#9'insert into dbo.report_ocorrencia'
      
        #9#9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descric' +
        'ao)'
      
        #9#9'values'#9'(:grupo, :referencia, '#39'IDA_GRUPOS'#39', null, '#39'INEXISTE REG' +
        'ISTROS'#39')'
      #9'end'
      ''
      
        '  -- VALIDA A DATA DE PREVIS'#195'O LEITURA N'#195'O PODE SER INFERIOR Dia' +
        ' atual - 5 dias'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        '  select'#9':grupo, :referencia, '#39'IDA_GRUPOS'#39', null, '#39'DATA PREVIS'#195'O' +
        ' LEITURA INFERIOR A DATA LIMITE'#39
      '  from '#9'diadema_iv.dbo.ida_grupos'
      #9'where'#9'Referencia = :referencia'
      #9'and'#9'Grupo = :grupo'
      '  and'#9'Data_Leitura < (getdate()-5)'
      ''
      
        '    -- VALIDA A DATA DE PROXIMA LEITURA N'#195'O PODE SER INFERIOR Di' +
        'a Atual + 15 dias'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        '  select'#9':grupo, :referencia, '#39'IDA_GRUPOS'#39', null, '#39'DATA PREVIS'#195'O' +
        ' PR'#211'XIMA LEITURA INFERIOR A DATA LIMITE'#39
      '  from '#9'diadema_iv.dbo.ida_grupos'
      #9'where'#9'Referencia = :referencia'
      #9'and'#9'Grupo = :grupo'
      '  and'#9'Data_Proxima_Leitura < (getdate()+15)'
      ''
      #9'-- VALIDA A QUANTIDA DE REGISTRO NA TABELA IDA_AGENTES'
      #9'select '#9'@nQtde = count(*)'
      #9'from'#9'DIADEMA_IV.dbo.IDA_AGENTES'
      #9'where'#9'Grupo = :grupo'
      #9'if @nQtde = 0 begin'
      #9#9'insert into dbo.report_ocorrencia'
      
        #9#9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descric' +
        'ao)'
      
        #9#9'values'#9'(:grupo, :referencia, '#39'IDA_AGENTES'#39', null, '#39'INEXISTE RE' +
        'GISTROS'#39')'
      #9'end'
      ''
      #9'-- VALIDA A QUANTIDA DE REGISTRO NA TABELA IDA_TARIFAS'
      #9'select '#9'@nQtde = count(*)'
      #9'from'#9'DIADEMA_IV.dbo.IDA_TARIFAS'
      #9'where'#9'Grupo = :grupo'
      #9'if @nQtde = 0 begin'
      #9#9'insert into dbo.report_ocorrencia'
      
        #9#9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descric' +
        'ao)'
      
        #9#9'values'#9'(:grupo, :referencia, '#39'IDA_TARIFAS'#39', null, '#39'INEXISTE RE' +
        'GISTROS'#39')'
      #9'end'
      ''
      #9'-- VALIDA A QUANTIDA DE REGISTRO NA TABELA IDA_QUALIDADE_AGUA'
      #9'select '#9'@nQtde = count(*)'
      #9'from'#9'DIADEMA_IV.dbo.IDA_QUALIDADE_AGUA'
      #9'where'#9'Grupo = :grupo'
      #9'if @nQtde = 0 begin'
      #9#9'insert into dbo.report_ocorrencia'
      
        #9#9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descric' +
        'ao)'
      
        #9#9'values'#9'(:grupo, :referencia, '#39'IDA_QUALIDADE_AGUA'#39', null, '#39'INEX' +
        'ISTE REGISTROS'#39')'
      #9'end'
      ''
      #9'-- VALIDA A QUANTIDA DE REGISTRO NA TABELA IDA_OCORRENCIAS'
      #9'select '#9'@nQtde = count(*)'
      #9'from'#9'DIADEMA_IV.dbo.IDA_OCORRENCIAS'
      #9'where'#9'Grupo = :grupo'
      #9'if @nQtde = 0 begin'
      #9#9'insert into dbo.report_ocorrencia'
      
        #9#9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descric' +
        'ao)'
      
        #9#9'values'#9'(:grupo, :referencia, '#39'IDA_OCORRENCIAS'#39', null, '#39'INEXIST' +
        'E REGISTROS'#39')'
      #9'end'
      ''
      #9'-- VALIDA A QUANTIDA DE REGISTRO NA TABELA IDA_LOGRADOUROS'
      #9'select '#9'@nQtde = count(*)'
      #9'from'#9'DIADEMA_IV.dbo.IDA_LOGRADOUROS'
      #9'where'#9'Grupo = :grupo'
      #9'if @nQtde = 0 begin'
      #9#9'insert into dbo.report_ocorrencia'
      
        #9#9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descric' +
        'ao)'
      
        #9#9'values'#9'(:grupo, :referencia, '#39'IDA_LOGRADOUROS'#39', null, '#39'INEXIST' +
        'E REGISTROS'#39')'
      #9'end'
      ''
      
        #9'-- VALIDA A QUANTIDA DE REGISTRO NA TABELA IDA_CLASSIFICACAO_IM' +
        'OVEIS'
      #9'select '#9'@nQtde = count(*)'
      #9'from'#9'DIADEMA_IV.dbo.IDA_CLASSIFICACAO_IMOVEIS'
      #9'where'#9'Grupo = :grupo'
      #9'if @nQtde = 0 begin'
      #9#9'insert into dbo.report_ocorrencia'
      
        #9#9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descric' +
        'ao)'
      
        #9#9'values'#9'(:grupo, :referencia, '#39'IDA_CLASSIFICACAO_IMOVEIS'#39', null' +
        ', '#39'INEXISTE REGISTROS'#39')'
      #9'end'
      ''
      #9'-- VALIDA A QUANTIDA DE REGISTRO NA TABELA IDA_IMPOSTOS'
      #9'select '#9'@nQtde = count(*)'
      #9'from'#9'DIADEMA_IV.dbo.IDA_IMPOSTOS'
      #9'where'#9'Grupo = :grupo'
      #9'if @nQtde = 0 begin'
      #9#9'insert into dbo.report_ocorrencia'
      
        #9#9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descric' +
        'ao)'
      
        #9#9'values'#9'(:grupo, :referencia, '#39'IDA_IMPOSTOS'#39', null, '#39'INEXISTE R' +
        'EGISTROS'#39')'
      #9'end'
      ''
      #9'-- VALIDA A QUANTIDA DE REGISTRO NA TABELA IDA_IDENT_CONSUMIDOR'
      #9'select '#9'@nQtde = count(*)'
      #9'from'#9'DIADEMA_IV.dbo.IDA_IDENT_CONSUMIDOR'
      #9'where'#9'Grupo = :grupo'
      #9'if @nQtde = 0 begin'
      #9#9'insert into dbo.report_ocorrencia'
      
        #9#9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descric' +
        'ao)'
      
        #9#9'values'#9'(:grupo, :referencia, '#39'IDA_IDENT_CONSUMIDOR'#39', null, '#39'IN' +
        'EXISTE REGISTROS'#39')'
      #9'end'
      ''
      #9'-- VALIDA A QUANTIDA DE REGISTRO NA TABELA IDA_MENSAGENS'
      #9'select '#9'@nQtde = count(*)'
      #9'from'#9'DIADEMA_IV.dbo.IDA_MENSAGENS'
      #9'where'#9'Grupo = :grupo'
      #9'if @nQtde = 0 begin'
      #9#9'insert into dbo.report_ocorrencia'
      
        #9#9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descric' +
        'ao)'
      
        #9#9'values'#9'(:grupo, :referencia, '#39'IDA_MENSAGENS'#39', null, '#39'INEXISTE ' +
        'REGISTROS'#39')'
      #9'end'
      ''
      #9'-- VALIDA A QUANTIDA DE REGISTRO NA TABELA IDA_LIGACOES'
      #9'select '#9'@nQtde = count(*)'
      #9'from'#9'DIADEMA_IV.dbo.IDA_LIGACOES'
      #9'where'#9'Grupo = :grupo'
      #9'if @nQtde = 0 begin'
      #9#9'insert into dbo.report_ocorrencia'
      
        #9#9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descric' +
        'ao)'
      
        #9#9'values'#9'(:grupo, :referencia, '#39'IDA_LIGACOES'#39', null, '#39'INEXISTE R' +
        'EGISTROS'#39')'
      #9'end'
      ''
      #9'-- -------------------------'
      #9'-- VALIDA TABELA DE LIGA'#199#213'ES'
      ''
      #9'-- Verifica Emite Conta'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_LIGACOES'#39', CDC, '#39'FLAG EMITE CO' +
        'NTA DIFERENTE DE S OU N'#39
      #9'from'#9'DIADEMA_IV.dbo.IDA_LIGACOES'
      #9'where'#9'Grupo = :grupo'
      #9'and'#9'isnull(emite_conta,'#39'X'#39') not in ('#39'S'#39','#39'N'#39')'
      ''
      '  '#9'-- Verifica Calcula Conta'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_LIGACOES'#39', CDC, '#39'FLAG CALCULA ' +
        'CONTA DIFERENTE DE S OU N'#39
      #9'from'#9'DIADEMA_IV.dbo.IDA_LIGACOES'
      #9'where'#9'Grupo = :grupo'
      #9'and'#9'isnull(emite_conta,'#39'X'#39') not in ('#39'S'#39','#39'N'#39')'
      ''
      '  '#9'-- Verifica Calcula Imposto'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_LIGACOES'#39', CDC, '#39'FLAG CALCULA ' +
        'IMPOSTO DIFERENTE DE S OU N'#39
      #9'from'#9'DIADEMA_IV.dbo.IDA_LIGACOES'
      #9'where'#9'Grupo = :grupo'
      #9'and'#9'isnull(calcula_imposto,'#39'X'#39') not in ('#39'S'#39','#39'N'#39')'
      ''
      #9'-- Verifica Economias igual a ZERO'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_LIGACOES'#39', CDC, '#39'CDC COM ECONO' +
        'MIAS IGUAL A ZERO'#39
      #9'from'#9'DIADEMA_IV.dbo.IDA_LIGACOES'
      #9'where'#9'Grupo = :grupo'
      
        #9'and'#9'(IsNull(Eco_Res, 0) + IsNull(Eco_Com, 0) + IsNull(Eco_Ind, ' +
        '0) + IsNull(Eco_Pub, 0) + IsNull(Eco_Soc, 0)) = 0'
      ''
      #9'-- Verifica M'#233'dia de Consumo NULA ou inferior a Zero'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_LIGACOES'#39', CDC, '#39'CDC COM M'#201'DIA' +
        ' DE CONSUMO INV'#193'LIDA'#39
      #9'from'#9'DIADEMA_IV.dbo.IDA_LIGACOES'
      #9'where'#9'Grupo = :grupo'
      #9'and'#9'(Media is null or Media < 0)'
      ''
      #9'-- Verifica Categoria'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_LIGACOES'#39', CDC, '#39'CDC COM CATEG' +
        'ORIA INEXISTENTE: '#39' + RTRIM(CONVERT(CHAR, Categoria_Imovel))'
      #9'from'#9'DIADEMA_IV.dbo.IDA_LIGACOES'
      #9'where'#9'Grupo = :grupo'
      #9'and'#9'IsNull(Categoria_Imovel,0) not in (1, 2, 3, 4, 5, 6, 7, 8)'
      ''
      
        #9'-- Verifica Categoria Entidade Assistencial = 8 n'#227'o pode ser mi' +
        'sta'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_LIGACOES'#39', CDC, '#39'CDC COM CATEG' +
        'ORIA 8 E ECONOMIAS MISTAS'#39
      #9'from'#9'DIADEMA_IV.dbo.IDA_LIGACOES'
      #9'where'#9'Grupo = :grupo'
      #9'and'#9'Categoria_Imovel = 8'
      #9'and'#9'((case when IsNull(Eco_Res, 0) > 0 then 1 else 0 end) +'
      #9#9' (case when IsNull(Eco_Com, 0) > 0 then 1 else 0 end) +'
      #9#9' (case when IsNull(Eco_Ind, 0) > 0 then 1 else 0 end) +'
      #9#9' (case when IsNull(Eco_Pub, 0) > 0 then 1 else 0 end) +'
      #9#9' (case when IsNull(Eco_Soc, 0) > 0 then 1 else 0 end)) > 1'
      ''
      
        #9'-- Verifica Categoria Grandes Consumidores = 7 n'#227'o pode ter eco' +
        'nomia diferente de 1'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_LIGACOES'#39', CDC, '#39'CDC COM CATEG' +
        'ORIA 8 E ECONOMIAS MISTAS'#39
      #9'from'#9'DIADEMA_IV.dbo.IDA_LIGACOES'
      #9'where'#9'Grupo = :grupo'
      #9'and'#9'Categoria_Imovel = 7'
      
        #9'and'#9'(IsNull(Eco_Res, 0) + IsNull(Eco_Com, 0) + IsNull(Eco_Ind, ' +
        '0) + IsNull(Eco_Pub, 0) + IsNull(Eco_Soc, 0)) != 1'
      ''
      ''
      #9'-- Verifica Natureza da Liga'#231#227'o'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_LIGACOES'#39', CDC, '#39'CDC COM NATUR' +
        'EZA INEXISTENTE: '#39' + RTRIM(CONVERT(CHAR, Natureza_Ligacao))'
      #9'from'#9'DIADEMA_IV.dbo.IDA_LIGACOES'
      #9'where'#9'Grupo = :grupo'
      #9'and'#9'IsNull(Natureza_Ligacao,0) not in (1, 2, 3)'
      ''
      #9'-- Verifica Data de Vencimento'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_LIGACOES'#39', CDC, '#39'CDC COM DATA ' +
        'DE VENCIMENTO NULA OU INFERIOR A REFERENCIA'#39
      #9'from'#9'DIADEMA_IV.dbo.IDA_LIGACOES'
      #9'where'#9'Grupo = :grupo'
      #9'and'#9'(Data_Vencimento is null'
      #9'or'#9'Data_Vencimento < :referencia)'
      ''
      #9'-- Verifica Data de Vencimento'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_LIGACOES'#39', CDC, '#39'CDC COM DATA ' +
        'DE VENCIMENTO SUPERIORES A 90 DIAS'#39
      #9'from'#9'DIADEMA_IV.dbo.IDA_LIGACOES'
      #9'where'#9'Grupo = :grupo'
      #9'and'#9'(Data_Vencimento > (CAST(:referencia AS Datetime) + 90))'
      ''
      #9'-- Verifica CDC inexistente ou fora do Roteiro'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_LIGACOES'#39', CDC, '#39'CDC PAI '#39' + R' +
        'TRIM(CONVERT(CHAR, CDC_Pai)) + '#39' INEXISTENTE NO ROTEIRO'#39
      #9'from'#9'DIADEMA_IV.dbo.IDA_LIGACOES P'
      #9'where'#9'Grupo = :grupo'
      #9'and'#9'CDC_Pai is not null'
      #9'and'#9'CDC_Pai > 0'
      #9'and'#9'0 = '#9'(select'#9'count(*)'
      #9#9#9'from'#9'DIADEMA_IV.dbo.IDA_LIGACOES C'
      #9#9#9'where'#9'C.Grupo = P.Grupo'
      #9#9#9'and'#9'C.Rota = P.Rota'
      #9#9#9'and'#9'C.CDC = P.CDC_Pai)'
      ''
      #9'-- -------------------------------------------------'
      #9'-- Valida a exist'#234'ncia de CDC na tabela IDA_LIGACOES'
      #9'-- Valida IDA_HISTORICOS_CONSUMO'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_HISTORICOS_CONSUMO'#39', CDC, '#39'CDC' +
        ' N'#195'O ENVIADO NO TABELA DE LIGA'#199#213'ES'#39
      #9'from'#9'DIADEMA_IV.dbo.IDA_HISTORICOS_CONSUMO P'
      #9'where'#9'Grupo = :grupo'
      
        #9'and'#9'0 = (select count(*) from DIADEMA_IV.dbo.IDA_LIGACOES C whe' +
        're C.Grupo = P.Grupo and C.CDC = P.CDC)'
      ''
      #9'-- Valida IDA_SERVICOS'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_SERVICOS'#39', CDC, '#39'CDC N'#195'O ENVIA' +
        'DO NO TABELA DE LIGA'#199#213'ES'#39
      #9'from'#9'DIADEMA_IV.dbo.IDA_SERVICOS P'
      #9'where'#9'Grupo = :grupo'
      
        #9'and'#9'0 = (select count(*) from DIADEMA_IV.dbo.IDA_LIGACOES C whe' +
        're C.Grupo = P.Grupo and C.CDC = P.CDC)'
      ''
      #9'-- Valida IDA_CREDITOS'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_CREDITOS'#39', CDC, '#39'CDC N'#195'O ENVIA' +
        'DO NO TABELA DE LIGA'#199#213'ES'#39
      #9'from'#9'DIADEMA_IV.dbo.IDA_CREDITOS P'
      #9'where'#9'Grupo = :grupo'
      
        #9'and'#9'0 = (select count(*) from DIADEMA_IV.dbo.IDA_LIGACOES C whe' +
        're C.Grupo = P.Grupo and C.CDC = P.CDC)'
      ''
      #9'-- Valida IDA_SEGUNDAS_VIAS'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_SEGUNDAS_VIAS'#39', CDC, '#39'CDC N'#195'O ' +
        'ENVIADO NO TABELA DE LIGA'#199#213'ES'#39
      #9'from'#9'DIADEMA_IV.dbo.IDA_SEGUNDAS_VIAS P'
      #9'where'#9'Grupo = :grupo'
      
        #9'and'#9'0 = (select count(*) from DIADEMA_IV.dbo.IDA_LIGACOES C whe' +
        're C.Grupo = P.Grupo and C.CDC = P.CDC)'
      ''
      #9'-- Valida IDA_SEGUNDAS_VIAS'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_SEGUNDAS_VIAS'#39', CDC, '#39'CDC COM ' +
        'VALOR MENOR QUE ZERO'#39
      #9'from'#9'DIADEMA_IV.dbo.IDA_SEGUNDAS_VIAS P'
      #9'where'#9'Grupo = :grupo'
      #9'and'#9'Valor_Total < 0'
      ''
      #9'-- Valida IDA_DEBITOS'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_DEBITOS'#39', CDC, '#39'CDC N'#195'O ENVIAD' +
        'O NO TABELA DE LIGA'#199#213'ES'#39
      #9'from'#9'DIADEMA_IV.dbo.IDA_DEBITOS P'
      #9'where'#9'Grupo = :grupo'
      
        #9'and'#9'0 = (select count(*) from DIADEMA_IV.dbo.IDA_LIGACOES C whe' +
        're C.Grupo = P.Grupo and C.CDC = P.CDC)'
      ''
      #9'-- Valida IDA_DEBITOS'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_DEBITOS'#39', CDC, '#39'CDC COM VALOR ' +
        'MENOR QUE ZERO'#39
      #9'from'#9'DIADEMA_IV.dbo.IDA_DEBITOS P'
      #9'where'#9'Grupo = :grupo'
      #9'and'#9'Valor_Total < 0'
      ''
      #9'-- Valida IDA_DEBITOS_ITENS'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_DEBITOS_ITENS'#39', CDC, '#39'CDC N'#195'O ' +
        'ENVIADO NO TABELA DE LIGA'#199#213'ES'#39
      #9'from'#9'DIADEMA_IV.dbo.IDA_DEBITOS_ITENS P'
      #9'where'#9'Grupo = :grupo'
      
        #9'and'#9'0 = (select count(*) from DIADEMA_IV.dbo.IDA_LIGACOES C whe' +
        're C.Grupo = P.Grupo and C.CDC = P.CDC)'
      ''
      #9'-- Valida IDA_DEBITOS_ITENS'
      #9'insert into dbo.report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select'#9':grupo, :referencia, '#39'IDA_DEBITOS_ITENS'#39', CDC, '#39'CDC N'#195'O ' +
        'ENVIADO NO TABELA DE D'#201'BITOS'#39
      #9'from'#9'DIADEMA_IV.dbo.IDA_DEBITOS_ITENS P'
      #9'where'#9'Grupo = :grupo'
      
        #9'and'#9'0 = (select count(*) from DIADEMA_IV.dbo.IDA_LIGACOES C whe' +
        're C.Grupo = P.Grupo and C.CDC = P.CDC)'
      ''
      #9'-- Valida SEQUENCIALIZACAO DO GRUPO'
      #9'insert into report_ocorrencia'
      #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_descricao)'
      
        #9'select '#9'grupo, :referencia, '#39'IDA_LIGACOES'#39', '#39'Sequ'#234'ncia repetida' +
        ': '#39' + rtrim(convert(char, Sequencia))'
      #9'from'#9'DIADEMA_IV.dbo.IDA_LIGACOES'
      #9'where '#9'grupo = :grupo'
      
        #9'group '#9'by grupo, '#39'Sequ'#234'ncia repetida: '#39' + rtrim(convert(char, S' +
        'equencia))'
      #9'having '#9'count(*) > 1'
      ''
      #9'-- Valida Conjuntos (Subnormal/Compostos) em rotas diferentes'
      #9'insert into report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select '#9'grupo, :referencia, '#39'IDA_LIGACOES'#39', cdc_pai, '#39'Conjunto ' +
        'com CDC Filho em Rotas distintas'#39
      #9'from '#9'DIADEMA_IV.dbo.ida_ligacoes'
      #9'where '#9'grupo = :grupo'
      #9'and '#9'cdc_pai <> 0'
      #9'group by '#9'grupo, cdc_pai'
      #9'having '#9'count(distinct rota) > 1'
      ''
      '  '#9'-- Valida Pais cortados'
      #9'insert into report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select '#9'grupo, :referencia, '#39'IDA_LIGACOES'#39', cdc_pai, '#39'CDC Pai n' +
        #227'o pode estar cortado'#39
      #9'from '#9'DIADEMA_IV.dbo.ida_ligacoes'
      #9'where '#9'grupo = :grupo'
      #9'and '#9'cdc_pai <> 0'
      #9'and '#9'cdc_pai = cdc'
      #9'and '#9'ident_calculo = '#39'B'#39
      ''
      #9'-- Valida filhos do subnormal cortado'
      #9'insert into report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select '#9'grupo, :referencia, '#39'IDA_LIGACOES'#39', cdc_pai, '#39'CDC Filho' +
        ' de Subnormal n'#227'o pode estar cortado'#39
      #9'from '#9'DIADEMA_IV.dbo.ida_ligacoes'
      #9'where '#9'grupo = :grupo'
      #9'and '#9'cdc_pai <> 0'
      #9'and '#9'cdc_pai <> cdc'
      #9'and '#9'ident_calculo = '#39'B'#39
      #9'and '#9'ident_consumidor = 2'
      ''
      #9'-- valida servicos apenas em CDCs que tem fatura'
      #9'insert into report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select '#9'L.grupo, :referencia, '#39'IDA_LIGACOES'#39', L.cdc, '#39'CDC com s' +
        'ervi'#231'o indevido'#39
      #9'from '#9'DIADEMA_IV.dbo.ida_ligacoes L,'
      #9#9'DIADEMA_IV.dbo.ida_servicos S'
      #9'where '#9'L.cdc = S.cdc'
      #9'and   '#9'L.grupo = S.grupo'
      #9'and   '#9'L.grupo = :grupo'
      
        #9'and  '#9'((L.ident_consumidor in (2,9) and L.cdc = L.cdc_pai) or /' +
        '*pai de subnormal*/ /*pai de apartamento*/'
      
        #9#9'(L.ident_consumidor in (3,8) and L.cdc <> L.cdc_pai and cdc_pa' +
        'i <> 0)) /*filho de composto*/'
      ''
      #9'-- valida segundas vias apenas em CDCs que tem fatura'
      #9'insert into report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select '#9'L.grupo, :referencia, '#39'IDA_LIGACOES'#39', L.cdc, '#39'CDC com s' +
        'egunda via indevida'#39
      #9'from '#9'DIADEMA_IV.dbo.ida_ligacoes L,'
      #9#9'DIADEMA_IV.dbo.ida_segundas_vias S'
      #9'where '#9'L.cdc = S.cdc'
      #9'and   '#9'L.grupo = S.grupo'
      #9'and   '#9'L.grupo = S.grupo'
      #9'and   '#9'L.grupo = :grupo'
      
        #9'and  '#9'((L.ident_consumidor in (2,9) and L.cdc = L.cdc_pai) or /' +
        '*pai de subnormal*/ /*pai de apartamento*/'
      
        #9#9'(L.ident_consumidor in (3,8) and L.cdc <> L.cdc_pai and cdc_pa' +
        'i <> 0)) /*filho de composto*/'
      ''
      #9'-- valida cr'#233'ditos apenas em CDCs que tem fatura'
      #9'insert into report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select '#9'L.grupo, :referencia, '#39'IDA_LIGACOES'#39', L.cdc, '#39'CDC com c' +
        'r'#233'dito indevido'#39
      #9'from '#9'DIADEMA_IV.dbo.ida_ligacoes L,'
      #9#9'DIADEMA_IV.dbo.ida_creditos S'
      #9'where '#9'L.cdc = S.cdc'
      #9'and   '#9'L.grupo = S.grupo'
      #9'and   '#9'L.grupo = :grupo'
      
        #9'and  '#9'((L.ident_consumidor in (2,9) and L.cdc = L.cdc_pai) or /' +
        '*pai de subnormal*/ /*pai de apartamento*/'
      
        #9#9'(L.ident_consumidor in (3,8) and L.cdc <> L.cdc_pai and cdc_pa' +
        'i <> 0)) /*filho de composto*/'
      ''
      #9'-- valida d'#233'bitos apenas em CDCs que tem fatura'
      #9'insert into report_ocorrencia'
      
        #9#9'(ro_grupo, ro_referencia, ro_tabela, ro_matricula, ro_descrica' +
        'o)'
      
        #9'select '#9'L.grupo, :referencia, '#39'IDA_LIGACOES'#39', L.cdc, '#39'CDC com n' +
        'otifica'#231#227'o/aviso de d'#233'bito indevida'#39
      #9'from  '#9'DIADEMA_IV.dbo.ida_ligacoes L,'
      #9#9'DIADEMA_IV.dbo.ida_debitos S'
      #9'where '#9'L.cdc = S.cdc '
      #9'and '#9'L.grupo = S.grupo'
      #9'and   '#9'L.grupo = :grupo'
      
        #9'and  '#9'((L.ident_consumidor in (2,9) and L.cdc = L.cdc_pai) or /' +
        '*pai de subnormal*/ /*pai de apartamento*/'
      
        #9#9'(L.ident_consumidor in (3,8) and L.cdc <> L.cdc_pai and cdc_pa' +
        'i <> 0)) /*filho de composto*/'
      '        ')
    Left = 400
    Top = 184
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftDateTime
        Name = 'referencia'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
  end
  object qryValidaRegistro: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      '-- valida liga'#231#245'es'
      'insert into report_ocorrencia'
      #9'(ro_grupo, ro_referencia, ro_tabela, ro_descricao)'
      
        'select'#9'rt_grupo, rt_referencia, '#39'IDA_LIGACOES'#39', '#39'Diferen'#231'a na qu' +
        'antidade de registro importados'#39
      ' '#9'FROM'#9'ROTEIROS R1'
      #9'WHERE '#9'RT_GRUPO = :grupo'
      
        #9'AND'#9'RT_ROTA = (SELECT MAX(RT_ROTA) FROM ROTEIROS R2 WHERE R1.RT' +
        '_GRUPO = R2.RT_GRUPO)'
      
        #9'and'#9'(select  count(*) from DIADEMA_IV.dbo.IDA_LIGACOES where gr' +
        'upo = RT_GRUPO)  <>'
      #9#9'(select  count(*) from CARGA where cg_grupo = RT_GRUPO)'
      'group by rt_grupo, rt_referencia'
      '-- valida hist'#243'ricos de consumo'
      'insert into report_ocorrencia'
      #9'(ro_grupo, ro_referencia, ro_tabela, ro_descricao)'
      
        'select'#9'rt_grupo, rt_referencia, '#39'IDA_HISTORICOS_CONSUMO'#39', '#39'Difer' +
        'en'#231'a na quantidade de registro importados'#39
      ' '#9'FROM'#9'ROTEIROS R1'
      #9'WHERE '#9'RT_GRUPO = :grupo'
      
        #9'AND'#9'RT_ROTA = (SELECT MAX(RT_ROTA) FROM ROTEIROS R2 WHERE R1.RT' +
        '_GRUPO = R2.RT_GRUPO)'
      
        #9'and'#9'(select  count(*) from DIADEMA_IV.dbo.IDA_HISTORICOS_CONSUM' +
        'O where grupo = RT_GRUPO) <>'
      
        #9#9'(select  count(*) from HISTORICO_CONSUMO where hc_grupo = RT_G' +
        'RUPO)'#9
      'group by rt_grupo, rt_referencia'
      '-- valida d'#233'bitos'
      'insert into report_ocorrencia'
      #9'(ro_grupo, ro_referencia, ro_tabela, ro_descricao)'
      
        'select'#9'rt_grupo, rt_referencia, '#39'IDA_DEBITOS'#39', '#39'Diferen'#231'a na qua' +
        'ntidade de registro importados'#39
      ' '#9'FROM'#9'ROTEIROS R1'
      #9'WHERE '#9'RT_GRUPO = :grupo'
      
        #9'AND'#9'RT_ROTA = (SELECT MAX(RT_ROTA) FROM ROTEIROS R2 WHERE R1.RT' +
        '_GRUPO = R2.RT_GRUPO)'
      
        #9'and'#9'(select  count(*) from DIADEMA_IV.dbo.IDA_DEBITOS where gru' +
        'po = RT_GRUPO) <>'
      #9#9'(select  count(*) from DEBITOS where db_grupo = RT_GRUPO)'
      'group by rt_grupo, rt_referencia'
      '-- valida d'#233'bitos itens'
      'insert into report_ocorrencia'
      #9'(ro_grupo, ro_referencia, ro_tabela, ro_descricao)'
      
        'select'#9'rt_grupo, rt_referencia, '#39'IDA_DEBITOS_ITENS'#39', '#39'Diferen'#231'a ' +
        'na quantidade de registro importados'#39
      ' '#9'FROM'#9'ROTEIROS R1'
      #9'WHERE '#9'RT_GRUPO = :grupo'
      
        #9'AND'#9'RT_ROTA = (SELECT MAX(RT_ROTA) FROM ROTEIROS R2 WHERE R1.RT' +
        '_GRUPO = R2.RT_GRUPO)'
      
        #9'and'#9'(select  count(*) from DIADEMA_IV.dbo.IDA_DEBITOS_ITENS whe' +
        're grupo = RT_GRUPO) <>'
      
        #9#9'(select  count(*) from DEBITOS_ITENS where di_grupo = RT_GRUPO' +
        ')'
      'group by rt_grupo, rt_referencia'
      '-- valida segundas vias'
      'insert into report_ocorrencia'
      #9'(ro_grupo, ro_referencia, ro_tabela, ro_descricao)'
      
        'select'#9'rt_grupo, rt_referencia, '#39'IDA_SEGUNDAS_VIAS'#39', '#39'Diferen'#231'a ' +
        'na quantidade de registro importados'#39
      ' '#9'FROM'#9'ROTEIROS R1'
      #9'WHERE '#9'RT_GRUPO = :grupo'
      
        #9'AND'#9'RT_ROTA = (SELECT MAX(RT_ROTA) FROM ROTEIROS R2 WHERE R1.RT' +
        '_GRUPO = R2.RT_GRUPO)'
      
        #9'and'#9'(select  count(*) from DIADEMA_IV.dbo.IDA_SEGUNDAS_VIAS whe' +
        're grupo = RT_GRUPO) <>'
      
        #9#9'(select  count(*) from SEGUNDAS_VIAS where sv_grupo = RT_GRUPO' +
        ')'
      'group by rt_grupo, rt_referencia'
      '-- valida servicos'
      'insert into report_ocorrencia'
      #9'(ro_grupo, ro_referencia, ro_tabela, ro_descricao)'
      
        'select'#9'rt_grupo, rt_referencia, '#39'IDA_SERVICOS OU IDA_CREDITOS'#39', ' +
        #39'Diferen'#231'a na quantidade de registro importados'#39
      ' '#9'FROM'#9'ROTEIROS R1'
      #9'WHERE '#9'RT_GRUPO = :grupo'
      
        #9'AND'#9'RT_ROTA = (SELECT MAX(RT_ROTA) FROM ROTEIROS R2 WHERE R1.RT' +
        '_GRUPO = R2.RT_GRUPO)'
      
        #9'and'#9'((select  count(*) from DIADEMA_IV.dbo.IDA_SERVICOS where g' +
        'rupo = RT_GRUPO) +'
      
        #9#9' (select  count(*) from DIADEMA_IV.dbo.IDA_CREDITOS where grup' +
        'o = RT_GRUPO)) <>'
      #9#9'((select  count(*) from SERVICOS where sr_grupo = RT_GRUPO) + '
      #9#9' (select  count(*) from CREDITOS where cr_grupo = RT_GRUPO))'
      'group by rt_grupo, rt_referencia')
    Left = 400
    Top = 248
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
  end
end
