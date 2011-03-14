----------------------------------------------------------------------------------------------------

-----------------------------FATURA------------------------------------------------------

	INSERT INTO 
		ONP_FATURA
		(
			dat_leitura, 
			cod_referencia, 
			seq_fatura, 
			dat_vencimento, 
			val_valor_faturado, 
			seq_roteiro,
			seq_matricula, 
			ind_fatura_emitida, 
			ind_status, 
			des_codigo_barras, 
			des_linha_digitavel,
			ind_tipo_documento_origem, 
			des_documento_origem 
		)
		VALUES	
		(
			CONVERT(datetime, '19740506'), 
			CONVERT(CHAR(7), CONVERT(datetime, '19740506'), 102), 
			(
				SELECT MAX(seq_fatura)+1 AS  seq_fatura
				FROM	ONP_FATURA
			) AS seq_fatura, 
			dat_vencimento, 
			val_valor_faturado, 
			roteiro,
			seq_matricula, 
			'S', 
			'RE',  
			des_codigo_barras , 
			des_linha_digitavel,
			4, 
			CONVERT(VARCHAR, 
						(
							SELECT	MAX(seq_aviso)+1
							FROM	ONP_AVISO
						)
					)
		)	
		
	-- Insere Aviso
	INSERT INTO ONP_AVISO_DEBITO
		(
			seq_aviso, 
			seq_matricula, 
			seq_politica_corte, 
			seq_processo_corte,
			seq_fatura, 
			dat_geracao_aviso, 
			val_quantidade_debito, 
			val_valor_debito, 
			ind_confirma_entrega,
			ind_documento
		)
		values	
	   (
			@seq_aviso, 
			@av_matricula, 
			1, 
			@seq_processo_corte,
			@seq_fatura, 
			convert(datetime, convert(char(8), getdate(), 112)), 
			@av_qtde_debito, 
			@av_valor_total, 
			'N', 
			@av_tipo
		)
		
		
--------------------------------------------------------------------CAMPOS DO MOVIMENTO----------------------			
		
		  SELECT
			D.data_vencimento AS dat_vencimento,  
			D.valor_total AS val_valor_faturado,
			CONVERT(NUMERIC, '1'+OnPlaceSANED.dbo.fc_completa_zeros(D.grupo, 3)+OnPlaceSANED.dbo.fc_completa_zeros(D.grupo,3)) AS roteiro ,
			D.cdc AS seq_matricula,
			'S' AS ind_fatura_emitida, 
			'RE' AS ind_status, 
			D.codigo_barras AS des_codigo_barras,
			OnPlaceSANED_Movimento.dbo.FC_CODIGO_BARRAS_CONTROLE(D.codigo_barras) AS des_linha_digitavel,
			4 AS ind_tipo_documento_origem 
		  FROM
			  DIADEMA_IV.dbo.IDA_DEBITOS D
		  WHERE 
			D.grupo = 1  ---PARAMETRO INFORMADO PARA CADA REGISTRO
			
--------------------------------------------------------------------------------------------------------------

-----------------------------INSERT ONP_FATURA_CATEGORIA------------------------------------------------------
	-- ATENÇÃO VERIRIFICAR A PROCEDULE PARA VER AS CONDICIOES RELACIONADA COM A RESIDENCIA--
		
		INSERT INTO ONP_FATURA_CATEGORIA
					(
						seq_fatura, 
						seq_categoria, 
						val_numero_economia
					)
		values	(
					(
						SELECT MAX(seq_fatura)+1 AS  seq_fatura
						FROM	ONP_FATURA
					), 
					5, 
					SELECT CG_economia_res FROM CARGA WHERE CG_MATRICULA = 933 ---PARAMETRO INFORMADO PARA CADA REGISTRO
				)
				
--------------------------------------------------------------------------------------------------------------------

-----------------------------INSERT ONP_FATURA_TAXA-------------------------------------------------------------
		
		
		INSERT INTO ONP_FATURA_TAXA
					(
						seq_fatura, 
						seq_categoria, 
						seq_taxa,
						val_numero_economia, 
						ind_situacao, 
						ind_tipo_consumo,
						val_valor_faturado, 
						val_valor_calculado, 
						val_consumo_faturado
					)
					values	
					(
						(
							SELECT MAX(seq_fatura)+1 AS  seq_fatura
							FROM	ONP_FATURA
						), 
						5, 
						1,
						@svTotalEco, 
						1, 
						'L',
						@sv_servico_ag, 
						@sv_servico_ag, 
						@svConsumoEco 
						@svTotalEco
					)
		
		
		
---------------------------------------------------------------------------------------------------------------------

------------------------------------------QUALIDADE DA AGUA---------------------------------------------------------------------------

			-- 1 - PH
			
			INSERT INTO ONP_QUALIDADE_AGUA
					(
						dat_referencia, 
						seq_zona_abastecimento, 
						seq_parametro, 
						des_parametro, 
						val_previstas, 
						val_realizadas, 
						val_fora_limite, 
						val_media
					)
						SELECT 	
							(
								SELECT referencia
									FROM IDA_GRUPOS
									WHERE grupo = 1 ---PARAMETRO INFORMADO 
									--AND data_processamento is null -- VERIFICAR 
							) AS dat_referencia, 
							grupo AS seq_zona_abastecimento,
							1 AS seq_parametro, 
							'pH' AS des_parametro,
							ISNULL(pH_Amostras,150) AS val_previstas, 
							ISNULL(pH_Amostras,150) AS val_realizadas, 
							ISNULL(pH_Nao_Conformes, 150) AS val_fora_limite, 
							CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						FROM 	IDA_QUALIDADE_AGUA
						WHERE	grupo = 1 
								AND data = 
											(  SELECT MAX(data)
											   FROM IDA_QUALIDADE_AGUA
											   WHERE grupo = 1
											)
	
			-- 2 - CLORO RESIDUAL
			
			INSERT INTO ONP_QUALIDADE_AGUA
					(
						dat_referencia, 
						seq_zona_abastecimento, 
						seq_parametro, 
						des_parametro, 
						val_previstas, 
						val_realizadas, 
						val_fora_limite, 
						val_media
					)
						SELECT 	
							(
								SELECT referencia
									FROM IDA_GRUPOS
									WHERE grupo = 1 ---PARAMETRO INFORMADO 
									--AND data_processamento is null -- VERIFICAR 
							) AS dat_referencia, 
							grupo AS seq_zona_abastecimento,
							2 AS seq_parametro, 
							'Cloro Residual' AS des_parametro,
							ISNULL(cloro_Amostras,150) AS val_previstas, 
							ISNULL(cloro_Amostras,150) AS val_realizadas, 
							ISNULL(cloro_Amostras, 0) AS val_fora_limite, 
							CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						FROM 	IDA_QUALIDADE_AGUA
						WHERE	grupo = 1 
								AND data = 
											(  SELECT MAX(data)
											   FROM IDA_QUALIDADE_AGUA
											   WHERE grupo = 1
											)
			
			-- 3 - COR APARENTE
			
			INSERT INTO ONP_QUALIDADE_AGUA
					(
						dat_referencia, 
						seq_zona_abastecimento, 
						seq_parametro, 
						des_parametro, 
						val_previstas, 
						val_realizadas, 
						val_fora_limite, 
						val_media
					)
						SELECT 	
							(
								SELECT referencia
									FROM IDA_GRUPOS
									WHERE grupo = 1 ---PARAMETRO INFORMADO 
									--AND data_processamento is null -- VERIFICAR 
							) AS dat_referencia, 
							grupo AS seq_zona_abastecimento,
							3 AS seq_parametro, 
							'Cor Aparente' AS des_parametro,
							ISNULL(cor_Amostras,150) AS val_previstas, 
							ISNULL(cor_Amostras,150) AS val_realizadas, 
							ISNULL(cor_Amostras, 0) AS val_fora_limite, 
							CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						FROM 	IDA_QUALIDADE_AGUA
						WHERE	grupo = 1 
								AND data = 
											(  SELECT MAX(data)
											   FROM IDA_QUALIDADE_AGUA
											   WHERE grupo = 1
											)
			
			-- 4 - TURBIDEZ
			
			INSERT INTO ONP_QUALIDADE_AGUA
					(
						dat_referencia, 
						seq_zona_abastecimento, 
						seq_parametro, 
						des_parametro, 
						val_previstas, 
						val_realizadas, 
						val_fora_limite, 
						val_media
					)
						SELECT 	
							(
								SELECT referencia
									FROM IDA_GRUPOS
									WHERE grupo = 1 ---PARAMETRO INFORMADO 
									--AND data_processamento is null -- VERIFICAR 
							) AS dat_referencia, 
							grupo AS seq_zona_abastecimento,
							4 AS seq_parametro, 
							'Turbidez' AS des_parametro,
							ISNULL(turbidez_Amostras,150) AS val_previstas, 
							ISNULL(turbidez_Amostras,150) AS val_realizadas, 
							ISNULL(turbidez_Amostras, 0) AS val_fora_limite, 
							CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						FROM 	IDA_QUALIDADE_AGUA
						WHERE	grupo = 1 
								AND data = 
											(  SELECT MAX(data)
											   FROM IDA_QUALIDADE_AGUA
											   WHERE grupo = 1
											)
											
			-- 5 - FLUORETO
			
			INSERT INTO ONP_QUALIDADE_AGUA
					(
						dat_referencia, 
						seq_zona_abastecimento, 
						seq_parametro, 
						des_parametro, 
						val_previstas, 
						val_realizadas, 
						val_fora_limite, 
						val_media
					)
						SELECT 	
							(
								SELECT referencia
									FROM IDA_GRUPOS
									WHERE grupo = 1 ---PARAMETRO INFORMADO 
									--AND data_processamento is null -- VERIFICAR 
							) AS dat_referencia, 
							grupo AS seq_zona_abastecimento,
							5 AS seq_parametro, 
							'Fluoreto' AS des_parametro,
							ISNULL(fluoreto_Amostras,150) AS val_previstas, 
							ISNULL(fluoreto_Amostras,150) AS val_realizadas, 
							ISNULL(fluoreto_Amostras, 0) AS val_fora_limite, 
							CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						FROM 	IDA_QUALIDADE_AGUA
						WHERE	grupo = 1 
								AND data = 
											(  SELECT MAX(data)
											   FROM IDA_QUALIDADE_AGUA
											   WHERE grupo = 1
											)

			-- 6 - COLIF. TOTAIS
			
			INSERT INTO ONP_QUALIDADE_AGUA
					(
						dat_referencia, 
						seq_zona_abastecimento, 
						seq_parametro, 
						des_parametro, 
						val_previstas, 
						val_realizadas, 
						val_fora_limite, 
						val_media
					)
						SELECT 	
							(
								SELECT referencia
									FROM IDA_GRUPOS
									WHERE grupo = 1 ---PARAMETRO INFORMADO 
									--AND data_processamento is null -- VERIFICAR 
							) AS dat_referencia, 
							grupo AS seq_zona_abastecimento,
							6 AS seq_parametro, 
							'Colif. Totais' AS des_parametro,
							ISNULL(coliformes_Totais_Amostras,150) AS val_previstas, 
							ISNULL(coliformes_Totais_Amostras,150) AS val_realizadas, 
							ISNULL(coliformes_Totais_Amostras, 0) AS val_fora_limite, 
							CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						FROM 	IDA_QUALIDADE_AGUA
						WHERE	grupo = 1 
								AND data = 
											(  SELECT MAX(data)
											   FROM IDA_QUALIDADE_AGUA
											   WHERE grupo = 1
											)

			-- 7 - E. COLI
			
			INSERT INTO ONP_QUALIDADE_AGUA
					(
						dat_referencia, 
						seq_zona_abastecimento, 
						seq_parametro, 
						des_parametro, 
						val_previstas, 
						val_realizadas, 
						val_fora_limite, 
						val_media
					)
						SELECT 	
							(
								SELECT referencia
									FROM IDA_GRUPOS
									WHERE grupo = 1 ---PARAMETRO INFORMADO 
									--AND data_processamento is null -- VERIFICAR 
							) AS dat_referencia, 
							grupo AS seq_zona_abastecimento,
							7 AS seq_parametro, 
							'E. Coli' AS des_parametro,
							ISNULL(coliformes_Termotolerantes_Amostras,150) AS val_previstas, 
							ISNULL(coliformes_Termotolerantes_Amostras,150) AS val_realizadas, 
							ISNULL(coliformes_Termotolerantes_Amostras, 0) AS val_fora_limite, 
							CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						FROM 	IDA_QUALIDADE_AGUA
						WHERE	grupo = 1 
								AND data = 
											(  SELECT MAX(data)
											   FROM IDA_QUALIDADE_AGUA
											   WHERE grupo = 1
											)
											
-----------------------------------------------------------------------------------------------------------------------------------------------	

-----------------------------------------------------------------------------------------------------------------------------------------------
		select
			  grupo,
			  (select referencia
					from DIADEMA_IV.dbo.IDA_GRUPOS
					where grupo = :grupo
					and data_processamento is null),
			  data,
			  turbidez,
			  cloro,
			  coliformes_totais,
			  coliformes_termotolerantes,
			  ph,
			  cor,
			  fluoreto,
			  isnull(Turbidez_Amostras, 150),
			  isnull(Turbidez_Nao_Conformes, 0),
			  isnull(Cloro_Amostras, 150),
			  isnull(Cloro_Nao_Conformes, 0),
			  isnull(Coliformes_Totais_Amostras, 150),
			  isnull(Coliformes_Totais_Nao_Conformes, 0),
			  isnull(Coliformes_Termotolerantes_Amostras, 150),
			  isnull(Coliformes_Termotolerantes_Nao_Conformes, 0),
			  isnull(pH_Amostras, 150),
			  isnull(pH_Nao_Conformes, 0),
			  isnull(Cor_Amostras, 150),
			  isnull(Cor_Nao_Conformes, 0),
			  isnull(Fluoreto_Amostras, 150),
			  isnull(Fluoreto_Nao_Conformes, 0)
			  from
			  DIADEMA_IV.dbo.IDA_QUALIDADE_AGUA
				where grupo = :grupo
				and data = 
						(  select max(data)
						   from DIADEMA_IV.dbo.IDA_QUALIDADE_AGUA
						   where grupo = :grupo
						)





-----------------------------------------------------------------------------------------------------------------------
		select  
			db_data_vencimento as dat_vencimento,
			db_valor_total as val_valor_faturado,
			0 as roteiro,
			db_matricula as seq_matricula,
			db_referencia as cod_referencia, 
			db_codigo_barras as des_codigo_barras,
			OnPlaceSANED_Movimento.dbo.FC_CODIGO_BARRAS_CONTROLE(db_codigo_barras) as des_linha_digitavel,
			isnull(db_tipo,'N')
		FROM 	debitos, carga
		where	cg_matricula = db_matricula 
		and	cg_referencia = db_referencia
		and	cg_grupo = db_grupo
		and	cg_grupo = 1
		and	cg_rota between 0 and 100
		and	cg_referencia = (	select 	max(cg_referencia)
								from	OnPlaceSaned..carga
								where	cg_grupo = 1
								and	cg_rota between 0 and 100
							 )
		order	by db_matricula, db_data_vencimento 

------------------------------------------------------------IDA E VOLTA-----------------------------------------------------

	  select
		  D.cdc,
		  L.grupo,
		  L.rota,
		  (
			select referencia
				from DIADEMA_IV.dbo.IDA_GRUPOS
				where grupo = L.grupo
				and data_processamento is null
		  ),
		  D.tipo,
		  D.qtde_debitos,
		  D.valor_total,
		  D.data_vencimento,
		  D.codigo_barras
	  from
		  DIADEMA_IV.dbo.IDA_LIGACOES L,
		  DIADEMA_IV.dbo.IDA_DEBITOS D
	  where 
		L.cdc = D.cdc
		and L.grupo = :grupo
		and D.grupo = :grupo

-----------------------------------------------------------------------------------------------------------------------------
      select
		  L.cdc as cg_matricula,
		  isnull(L.cdc_pai,0) as cg_matricula_pai,
		  G.referencia as cg_referencia,
		  L.grupo as cg_grupo,
		  L.setor as cg_setor,
		  L.rota as cg_rota,
		  L.sequencia as cg_sequencia,
		  E.nome as cg_endereco,
		  L.numero_imovel as cg_num_imovel,
		  L.complemento as cg_complemento,
		  L.inscricao as cg_inscricao,
		  L.nome as cg_nome,
		  L.medidor as cg_numero_hd,
		  L.qtde_ponteiros as cg_capacidade_hidrometro,
        case when H.data_leitura is null then isnull(L.leitura_inicial_hd,0) else isnull(H.leitura,0) end as cg_leitura_ant,
        case when H.data_leitura is null then 71 else H.ocorrencia end as cg_ocorrencia_ant,
		case when H.data_leitura is null then IsNull(L.Data_Inst_HD, (G.data_leitura-30)) else H.data_leitura end as cg_data_leit_ant,
		L.media as cg_consumo_medio,
		CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_res END as cg_economia_res,
		CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_com END as cg_economia_com,
		CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_ind END as cg_economia_ind,
		CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_pub END as cg_economia_pub,
		CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_soc END as cg_economia_soc,
		CASE L.categoria_imovel WHEN 8 THEN (L.eco_res + L.eco_com + L.eco_ind + L.eco_pub +  +L.eco_soc) ELSE 0 END as cg_economia_ea,
		L.categoria_imovel as cg_categoria,
		isnull(L.qtde_debitos,0) as cg_qtde_debito_ant,
		L.data_vencimento as cg_data_vencto,
		(CASE WHEN L.mensagem1 = null THEN '' ELSE L.mensagem1 END) as mensagem1,
		(CASE WHEN L.mensagem2 = null THEN '' ELSE L.mensagem2 END) as cg_mensagem2,
		L.banco as cg_codigo_banco,
		L.agencia as cg_agencia,
		(CASE WHEN ((L.Data_Inst_HD > isnull(H.data_leitura,getdate())) and (IsNull(Ident_Ligacao_Nova,'') <> 'S')) THEN 'S' ELSE 'N' END) as cg_flag_troca,
		L.leitura_inicial_hd as cg_leitura_inicial,
		CASE WHEN ((L.Data_Inst_HD > isnull(H.data_leitura,getdate())) and (IsNull(Ident_Ligacao_Nova,'') <> 'S')) THEN L.data_inst_hd ELSE null END as cg_data_instalacao_hd,
		IsNull(H.consumo,0) as cg_consumo_anterior,
		L.cachorro as cg_cachorro,
		L.natureza_ligacao as cg_natureza_ligacao,
		L.bloqueado as cg_bloqueado,
		(CASE WHEN L.qtde_registros_fraude = null THEN 0 ELSE L.qtde_registros_fraude END) as cg_qtde_registros_fraude,
        case when (L.clas_imovel in (4, 64)) and (isnull(L.cdc_pai,0)= 0) then 0 else L.clas_imovel end as cg_desconto,
        
		/*EMITE_CONTA*/
   
        case when (isnull(L.cdc_pai,0) = 0) and (L.ident_consumidor =  + 3) then 1 else L.ident_consumidor end as cg_ident_consumidor,
		L.ident_calculo as cg_ident_calculo,
		CASE /*EMITE_CONTA*/
			  WHEN (L.ident_consumidor = 1)
			  THEN L.emite_conta
			  WHEN (L.ident_consumidor = 2) and (L.cdc <> L.cdc_pai)
			  THEN L.emite_conta
			  WHEN (L.ident_consumidor = 3) and (L.cdc = L.cdc_pai)
			  THEN L.emite_conta
			  WHEN (L.ident_consumidor = 4) and (L.cdc = L.cdc_pai)
			  THEN L.emite_conta
			  WHEN (L.ident_consumidor = 5) and (L.cdc = L.cdc_pai)
			  THEN L.emite_conta
			  WHEN (L.ident_consumidor = 6) and (L.cdc = L.cdc_pai)
			  THEN L.emite_conta
			  WHEN (L.ident_consumidor = 7) and (L.cdc = L.cdc_pai)
			  THEN L.emite_conta
			  WHEN (L.ident_consumidor = 8) and (L.cdc = L.cdc_pai)
			  THEN L.emite_conta
			  WHEN (L.ident_consumidor = 9) and (L.cdc <> L.cdc_pai)
			  THEN L.emite_conta
			  WHEN (L.ident_consumidor = 10) and (L.cdc = L.cdc_pai)
			  THEN L.emite_conta
			  ELSE 'N'
			  END as cg_flag_emite_conta,
		CASE
			WHEN L.cortar = null THEN 'N' ELSE L.cortar
		 END as cg_flag_cortar,
		L.calcula_imposto as cg_flag_calcula_imposto,
	    (CASE WHEN L.endereco_entrega = NULL THEN '' ELSE L.endereco_entrega END) as cg_entrega_alternativa,
		CASE /*CALCULA_CONTA*/
			WHEN (L.ident_consumidor = 1)
			THEN L.calcula_conta
			WHEN (L.ident_consumidor = 2) and (L.cdc <> L.cdc_pai)
			THEN L.calcula_conta
			WHEN (L.ident_consumidor = 3) and (L.cdc = L.cdc_pai)
			THEN L.calcula_conta
			WHEN (L.ident_consumidor = 4) and (L.cdc = L.cdc_pai)
			THEN L.calcula_conta
			WHEN (L.ident_consumidor = 5) and (L.cdc = L.cdc_pai)
			THEN L.calcula_conta
			WHEN (L.ident_consumidor = 6) and (L.cdc = L.cdc_pai)
			THEN L.calcula_conta
			WHEN (L.ident_consumidor = 7) and (L.cdc = L.cdc_pai)
			THEN L.calcula_conta
			WHEN (L.ident_consumidor = 8) and (L.cdc = L.cdc_pai)
			THEN L.calcula_conta
			WHEN (L.ident_consumidor = 9) and (L.cdc <> L.cdc_pai)
			THEN L.calcula_conta
			WHEN (L.ident_consumidor = 10) and (L.cdc = L.cdc_pai)
			THEN L.calcula_conta
		ELSE ''
		END as cg_flag_calcula_conta,
		dias_bloqueio_tarifa_ant as cg_dias_bloqueio_tarifa_ant,
		dias_bloqueio_tarifa_atual as cg_dias_bloqueio_tarifa_atual,
		CASE  /*VIRTUAL*/
			WHEN (L.ident_consumidor = 1) 
			THEN ''
			WHEN (L.ident_consumidor = 2) and (L.cdc = L.cdc_pai) 
			THEN ''
			WHEN (L.ident_consumidor = 9) 
			THEN ''
			WHEN (L.ident_consumidor <> 1) and (L.ident_consumidor <> 2) and(L.ident_consumidor <> 9) and(L.cdc <> L.cdc_pai)
			THEN ''
		ELSE ''
      
		END as cg_virtual,
        L.codigo_logradouro as cg_cod_logradouro,
		CASE
			WHEN L.bloqueado <> 'L'
			  THEN L.data_bloqueio
			ELSE
			  null
		END as cg_data_bloqueio,
        G.data_proxima_leitura as cg_proxima_leitura
      from 
		DIADEMA_IV.dbo.IDA_GRUPOS G, 
		DIADEMA_IV.dbo.IDA_LOGRADOUROS E, 
		DIADEMA_IV.dbo.IDA_LIGACOES L
      LEFT OUTER JOIN DIADEMA_IV.dbo.IDA_HISTORICOS_CONSUMO H ON L.cdc = H.cdc 
															and L.grupo = H.grupo 
															and H.referencia = (
																					select MAX(referencia)
																					from DIADEMA_IV.dbo.IDA_HISTORICOS_CONSUMO H2
																					where H2.GRUPO = L.GRUPO
																					AND	H2.cdc = L.cdc
																				)
      where 
		L.grupo = 3
		AND L.grupo = G.grupo
        and E.grupo = L.grupo
		and L.codigo_logradouro = E.codigo
		--and G.Data_Processamento is null	