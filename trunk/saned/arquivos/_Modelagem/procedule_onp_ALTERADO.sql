
-----------------------------------------------DBO.SP_ATUALIZA_SERVICO-------------------------------------------------------------------

					-- Cria
					CREATE PROCEDURE dbo.sp_atualiza_servico
					(@parNome VARCHAR(100))

					AS
					BEGIN 
						DECLARE @Existe INT

						SELECT @Existe = ISNULL(MIN(seq_servico_fatura),0)
						FROM   ONP_SERVICO_FATURA
						WHERE  des_servico_fatura = @parNome

						IF @Existe = 0
						BEGIN
							BEGIN tran
							INSERT INTO ONP_SERVICO_FATURA
								(
									seq_servico_fatura, 
									des_servico_fatura
								)
							SELECT 	
								ISNULL(MAX(seq_servico_fatura),0)+1,
								@parNome
							FROM	ONP_SERVICO_FATURA
							COMMIT
						END
					END

					GO
------------------------------------------------------------------------------------------------------------------------------------------

------------------------------------------------DBO.SP_ATUALIZA_LOGRADOURO----------------------------------------------------------------
			
					-- Cria
					CREATE PROCEDURE dbo.sp_atualiza_logradouro
					(@parNome VARCHAR(100)) 

					AS
					BEGIN 
						DECLARE @Existe INT

						SELECT 
							@Existe = ISNULL(MIN(seq_logradouro),0)
						FROM   ONP_LOGRADOURO
						WHERE  des_logradouro = @parNome

						IF @Existe = 0
						BEGIN
							BEGIN tran
							INSERT INTO ONP_LOGRADOURO
								(
									seq_logradouro, 
									cod_uf, 
									seq_localidade, 
									des_logradouro
								)
								SELECT 	
									ISNULL(MAX(seq_logradouro),0)+1,
									'SP', 
									1, 
									@parNome
								FROM ONP_LOGRADOURO
							COMMIT
						END
					END

					GO
----------------------------------------------------------------------------------------------------------------

-------------------------------------------------DBO.SP_CARGA_MOVIMENTO---------------------------------------------------------------

-- exec dbo.sp_carga_movimento 11, 0, 9999
 CREATE procedure dbo.sp_carga_movimento
 (@parGrupo int, @parRoteiroIni int, @parRoteiroFim int)
 
 AS
begin

	declare @nTeste     	int,
		@hrInicio   	datetime,
		@hrInicioGeral 	datetime,
		@hrAnterior 	datetime,
		@nQtdeReg	int
	set 	@nTeste = 0

	-- para testes
--	 declare @parGrupo int, @parRoteiroIni int, @parRoteiroFim int
--	 select @parGrupo = 1, @parRoteiroIni = 0, @parRoteiroFim = 9999
--	 set 	@nTeste = 1

	--
	if @nTeste = 1 begin
		select	@hrInicio = getdate()
		select	@hrInicioGeral = @hrInicio
		Print ' -- Inicio em ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108)
	end	

	declare @parReferencia datetime
	
	select 	@parReferencia = max(G.referencia)
	from	
			DIADEMA_IV.dbo.IDA_GRUPOS G,
			DIADEMA_IV.dbo.IDA_LIGACOES L
	where	
		L.grupo = @parGrupo
		AND L.grupo = G.grupo
		and	L.rota between @parRoteiroIni and @parRoteiroFim

	-- ******************************
	-- APAGA TABELas
	-- ******************************
	
	-- Atualiza AS Agentes


	-- ******************************
	-- Atualiza AS Ocorrência


	-- ******************************
	-- contadore gerais
	declare	@seq_fatura			numeric(11)
	declare	@seq_aviso			numeric(7)
	declare	@seq_processo_corte		numeric(7)
	declare	@seq_matricula_servico_parcela 	numeric(7)
	declare	@seq_item_servico		numeric(7)

	-- ******************************
	-- Tabelas GERAIS
	
	-- ******************************
	-- Tabelas Qualidade de ?gua
/*
	INSERT INTO OnPlaceSANED_movimento..ACQ_ZONA_ABasTECIMENTO 
			(seq_zona_abastecimento, des_zona_abastecimento)
	select 	distinct rt_grupo, 'Zona Abastecimento Grupo ' + convert(varchar, rt_grupo)
	from 	OnPlaceSANED..roteiros
	where	rt_grupo = @parGrupo
	and	rt_grupo not in (select seq_zona_abastecimento from OnPlaceSANED_movimento..ACQ_ZONA_ABasTECIMENTO)
	and	rt_rota between @parRoteiroIni and @parRoteiroFim
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = GETDATE()
		Print ' -- Atualizou AS ACQ_ZONA_ABasTECIMENTO ' + CONVERT(VARCHAR, GETDATE(), 103) + ' ' + CONVERT(VARCHAR, @hrInicio, 108) + ' Tempo: ' + CONVERT(VARCHAR, DATEDIFF(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END
 */
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
									WHERE grupo = @parGrupo ---PARAMETRO INFORMADO 
									--AND data_processamento is null -- VERIFICAR 
							) AS dat_referencia, 
							grupo AS seq_zona_abastecimento,
							1 AS seq_parametro, 
							'PH' AS des_parametro,
							ISNULL(pH_Amostras,150) AS val_previstas, 
							ISNULL(pH_Amostras,150) AS val_realizadas, 
							ISNULL(pH_Nao_Conformes, 150) AS val_fora_limite, 
							CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						FROM 	IDA_QUALIDADE_AGUA
						WHERE	grupo = @parGrupo 
								AND data = 
											(  SELECT MAX(data)
											   FROM IDA_QUALIDADE_AGUA
											   WHERE grupo = @parGrupo
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
									WHERE grupo = @parGrupo ---PARAMETRO INFORMADO 
									--AND data_processamento is null -- VERIFICAR 
							) AS dat_referencia, 
							grupo AS seq_zona_abastecimento,
							2 AS seq_parametro, 
							'CLORO RESIDUAL' AS des_parametro,
							ISNULL(cloro_Amostras,150) AS val_previstas, 
							ISNULL(cloro_Amostras,150) AS val_realizadas, 
							ISNULL(cloro_Amostras, 0) AS val_fora_limite, 
							CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						FROM 	IDA_QUALIDADE_AGUA
						WHERE	grupo =@parGrupo 
								AND data = 
											(  SELECT MAX(data)
											   FROM IDA_QUALIDADE_AGUA
											   WHERE grupo = @parGrupo											)
			
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
									WHERE grupo =@parGrupo ---PARAMETRO INFORMADO 
									--AND data_processamento is null -- VERIFICAR 
							) AS dat_referencia, 
							grupo AS seq_zona_abastecimento,
							3 AS seq_parametro, 
							'COR APARENTE' AS des_parametro,
							ISNULL(cor_Amostras,150) AS val_previstas, 
							ISNULL(cor_Amostras,150) AS val_realizadas, 
							ISNULL(cor_Amostras, 0) AS val_fora_limite, 
							CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						FROM 	IDA_QUALIDADE_AGUA
						WHERE	grupo =@parGrupo
								AND data = 
											(  SELECT MAX(data)
											   FROM IDA_QUALIDADE_AGUA
											   WHERE grupo =@parGrupo
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
									WHERE grupo =@parGrupo ---PARAMETRO INFORMADO 
									--AND data_processamento is null -- VERIFICAR 
							) AS dat_referencia, 
							grupo AS seq_zona_abastecimento,
							4 AS seq_parametro, 
							'TURBIDEZ' AS des_parametro,
							ISNULL(turbidez_Amostras,150) AS val_previstas, 
							ISNULL(turbidez_Amostras,150) AS val_realizadas, 
							ISNULL(turbidez_Amostras, 0) AS val_fora_limite, 
							CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						FROM 	IDA_QUALIDADE_AGUA
						WHERE	grupo =@parGrupo 
								AND data = 
											(  SELECT MAX(data)
											   FROM IDA_QUALIDADE_AGUA
											   WHERE grupo =@parGrupo
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
									WHERE grupo =@parGrupo ---PARAMETRO INFORMADO 
									--AND data_processamento is null -- VERIFICAR 
							) AS dat_referencia, 
							grupo AS seq_zona_abastecimento,
							5 AS seq_parametro, 
							'FLUORETO' AS des_parametro,
							ISNULL(fluoreto_Amostras,150) AS val_previstas, 
							ISNULL(fluoreto_Amostras,150) AS val_realizadas, 
							ISNULL(fluoreto_Amostras, 0) AS val_fora_limite, 
							CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						FROM 	IDA_QUALIDADE_AGUA
						WHERE	grupo =@parGrupo 
								AND data = 
											(  SELECT MAX(data)
											   FROM IDA_QUALIDADE_AGUA
											   WHERE grupo =@parGrupo
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
									WHERE grupo =@parGrupo ---PARAMETRO INFORMADO 
									--AND data_processamento is null -- VERIFICAR 
							) AS dat_referencia, 
							grupo AS seq_zona_abastecimento,
							6 AS seq_parametro, 
							'COLIF. TOTAIS' AS des_parametro,
							ISNULL(coliformes_Totais_Amostras,150) AS val_previstas, 
							ISNULL(coliformes_Totais_Amostras,150) AS val_realizadas, 
							ISNULL(coliformes_Totais_Amostras, 0) AS val_fora_limite, 
							CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						FROM 	IDA_QUALIDADE_AGUA
						WHERE	grupo =@parGrupo 
								AND data = 
											(  SELECT MAX(data)
											   FROM IDA_QUALIDADE_AGUA
											   WHERE grupo =@parGrupo
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
									WHERE grupo =@parGrupo ---PARAMETRO INFORMADO 
									--AND data_processamento is null -- VERIFICAR 
							) AS dat_referencia, 
							grupo AS seq_zona_abastecimento,
							7 AS seq_parametro, 
							'E. COLI' AS des_parametro,
							ISNULL(coliformes_Termotolerantes_Amostras,150) AS val_previstas, 
							ISNULL(coliformes_Termotolerantes_Amostras,150) AS val_realizadas, 
							ISNULL(coliformes_Termotolerantes_Amostras, 0) AS val_fora_limite, 
							CONVERT (NUMERIC (5,2), REPLACE(ph, ',', '.')) AS val_media
						FROM 	IDA_QUALIDADE_AGUA
						WHERE	grupo =@parGrupo 
								AND data = 
											(  SELECT MAX(data)
											   FROM IDA_QUALIDADE_AGUA
											   WHERE grupo =@parGrupo
											)
		if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou AS ACQ_QUALIDADE_AGUA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	
 

	-- ******************************
	-- Tabelas do GRUPO

	-- ---------------------------
	-- Atualiza dados do Grupo Leitura
	INSERT 	INTO ONP_GRUPO_FATURA		
		(
			seq_grupo_fatura, 
			des_grupo_fatura, 
			val_periodicidade_leitura, 
			val_periodicidade_fatura, 
			ind_tipo_vencimento
		)
	VALUES	
		(
			@parGrupo, 
			CONVERT(VARCHAR, @parGrupo), 
			30, 
			30, 
			'D'
		)
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = GETDATE()
		Print ' -- Atualizou AS ACQ_GRUPO_FATURA ' + CONVERT(VARCHAR, GETDATE(), 103) + ' ' + CONVERT(VARCHAR, @hrInicio, 108) + ' Tempo: ' + CONVERT(VARCHAR, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	

	-- ---------------------------
	-- Atualiza dados do Roteiro
	INSERT 	INTO ONP_ROTEIRO		
		(
			seq_roteiro, 
			seq_grupo_fatura, 
			ind_fatura
			dat_base,
			dat_servidor
		)
	SELECT 	
			CONVERT(NUMERIC, '1'+OnPlaceSANED.dbo.fc_completa_zeros(R.grupo, 3)+OnPlaceSANED.dbo.fc_completa_zeros(R.rota,3)), 
			G.grupo,
			'C',
			G.data_proxima_leitura,
			GETDATE()
	FROM 	
		VOLTA_ROTEIRO R,
		IDA_GRUPOS G
	WHERE	
		R.grupo = @parGrupo
		AND R.grupo = G.grupo
		AND	referencia = @parReferencia
		--AND	rota between @parRoteiroIni and @parRoteiroFim
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = GETDATE()
		Print ' -- Atualizou AS ACQ_ROTEIRO ' + CONVERT(VARCHAR, GETDATE(), 103) + ' ' + CONVERT(VARCHAR, @hrInicio, 108) + ' Tempo: ' + CONVERT(VARCHAR, DATEDIFF(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	

	-- ---------------------------
	-- Atualiza dados do Grupo Refer?ncia
	/*
	insert 	into OnPlaceSANED_movimento..ACQ_GRUPO_REFERENCIA	
		(seq_roteiro, 
		seq_grupo_fatura, cod_referencia, ind_fatura, dat_base)
	select 	convert(numeric, '1'+OnPlaceSANED.dbo.fc_completa_zeros(rt_grupo, 3)+OnPlaceSANED.dbo.fc_completa_zeros(rt_rota,3)), 
		rt_grupo, convert(varchar(7), rt_referencia, 102 ), 'S', rt_leitura_prev
	from 	OnPlaceSANED..roteiros
	where	rt_grupo = @parGrupo
	and	rt_referencia = @parReferencia
	and	rt_rota between @parRoteiroIni and @parRoteiroFim
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou AS ACQ_GRUPO_REFERENCIA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	
	*/
	-- ---------------------------
	-- Atualiza dados do Grupo Cronograma
	/*
	insert 	into OnPlaceSANED_movimento..ACQ_GRUPO_FATURA_CRONOGRAMA
		(seq_roteiro, 
		cod_referencia, cod_agente, dat_leitura_prevista, dat_vencimento,
		ind_gerado, ind_enviado, ind_obtido, ind_validado, ind_processado, ind_fatura, ind_encerrado)
	select 	convert(numeric, '1'+OnPlaceSANED.dbo.fc_completa_zeros(rt_grupo, 3)+OnPlaceSANED.dbo.fc_completa_zeros(rt_rota,3)), 
		convert(varchar(7), rt_referencia, 102 ), rt_agente, rt_leitura_prev, rt_data_vencto,
		'N', 'N', 'N', 'N', 'N', 'N', 'N'
 	from 	OnPlaceSANED..roteiros	
	where	rt_grupo = @parGrupo
	and	rt_referencia = @parReferencia
	and	rt_rota between @parRoteiroIni and @parRoteiroFim
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou AS ACQ_GRUPO_FATURA_CRONOGRAMA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	
	*/
	-- -------------------------
	-- Insere os dados de tarifa

	
	-- Insere tarifa de ?gua
	-- select * from OnPlaceSANED_movimento..ACQ_TAXA_TARIFA
	INSERT INTO ONP_TAXA_TARIFA
		(
			seq_categoria, 
			seq_taxa, 
			seq_taxa_tarifa,
			seq_taxa_base, 
			dat_inicio, 
			ind_tipo_taxa, 
			ind_escalonada, 
			ind_dias_consumo, 
			ind_minimo, 
			val_valor_tarifa, 
			val_percentual
		)
	select  distinct  
			categoria, 
			1, 
			convert(numeric(9), convert(char(6), data_vigencia, 112) + OnPlaceSANED.dbo.fc_completa_zeros(grupo, 3)),
			null, 
			data_vigencia, 
			'C', 
			'S', 
			'N', 
			'S', 
			null, 
			null
	from 	 IDA_TARIFAS
	where	 
		 referencia = @parReferencia
		 and grupo = @parGrupo
		 and categoria not in 
				 (
					select seq_categoria 
					from 	ONP_TAXA_TARIFA
					where seq_taxa = 1
					and seq_taxa_tarifa = convert(numeric(9), convert(char(6), data_inicial, 112) + OnPlaceSANED.dbo.fc_completa_zeros(grupo, 3))
				 )
		 and	0 = (
						SELECT 
							COUNT(*)
						from 	ONP_TAXA_TARIFA 
						where 	seq_categoria = categoria
								and	seq_taxa = 1
								and seq_taxa_tarifa = convert(numeric(9), convert(char(6), data_inicial, 112) + OnPlaceSANED.dbo.fc_completa_zeros(grupo, 3))
					)

	-- Insere tarifa de ?gua - Limite
	INSERT INTO ONP_TAXA_TARIFA_FAIXA
			(
				seq_categoria,  
				seq_taxa,  
				seq_taxa_tarifa_faixa, 
				seq_taxa_tarifa,  
				val_limite_consumo, 
				val_valor_tarifa
			) 
      SELECT DISTINCT
		  T.categoria AS seq_categoria,
		  1 AS seq_taxa,
		  (
			SELECT COUNT(*) + 1
				FROM  DIADEMA_IV.dbo.IDA_TARIFAS T2
				WHERE T2.categoria = T.categoria
				  AND T2.data_vigencia = T.data_vigencia
				  AND T2.limite_consumo < T.limite_consumo
				  AND T2.data_vigencia = T.data_vigencia
				  AND T2.grupo = T.grupo
		  ) AS seq_taxa_tarifa_faixa,
		  CONVERT(NUMERIC(9), CONVERT(CHAR(6), T.data_vigencia, 112) + OnPlaceSANED.dbo.fc_completa_zeros(T.grupo, 3)) AS seq_taxa_tarifa,
		  CasE WHEN T.limite_consumo >= 999999 THEN 9999999 ELSE T.limite_consumo END AS val_limite_consumo,
		  T.agua
		  FROM DIADEMA_IV.dbo.IDA_TARIFas T
			WHERE T.grupo = @parGrupo
			AND 	(
						SELECT referencia
							FROM DIADEMA_IV.dbo.IDA_GRUPOS
							WHERE grupo = @parGrupo
							AND data_processamento IS NULL
							AND data_retorno IS NULL
					) = @parReferencia 
			AND		0 =  	(
								SELECT COUNT(*)
								 FROM 	ONP_TAXA_TARIFA_FAIXA 
								 WHERE 	
									seq_categoria = tr_categoria
									 AND	seq_taxa = 1
									 AND	seq_taxa_tarifa_faixa = tr_sequencia
									 AND 	seq_taxa_tarifa = CONVERT(NUMERIC(9), CONVERT(CHAR(6), tr_data_inicial, 112) + OnPlaceSANED.dbo.fc_completa_zeros(tr_grupo, 3))
							 )


	-- Insere tarifa de Esgoto
	-- alterado de percentual p/ categoria. 
	INSERT	INTO ONP_TAXA_TARIFA
			(
				seq_categoria, 
				seq_taxa, 
				seq_taxa_tarifa,
				seq_taxa_base, 
				dat_inicio, 
				ind_tipo_taxa, 
				ind_escalonada, 
				ind_dias_consumo, 
				ind_minimo, 
				val_valor_tarifa, 
				val_percentual
			)
	SELECT	DISTINCT 
		T.categoria, 
		2, 
		CONVERT(NUMERIC(9), CONVERT(CHAR(6), T.data_vigencia, 112) + OnPlaceSANED.dbo.fc_completa_zeros(T.grupo, 3)),
		NULL, 
		T.data_vigencia, 
		'C', 
		'S', 
		'N', 
		'S', 
		NULL, 
		NULL
	FROM 	DIADEMA_IV.dbo.IDA_TARIFAS T
	WHERE	T.grupo = @parGrupo
	AND 	(
				SELECT referencia
					FROM DIADEMA_IV.dbo.IDA_GRUPOS
					WHERE grupo = @parGrupo
					AND data_processamento IS NULL
					AND data_retorno IS NULL
			) = @parReferencia
			
	AND	T.categoria NOT IN(
							SELECT seq_categoria
							 FROM 	 ONP_TAXA_TARIFA
							 WHERE 	 seq_taxa = 2
							 AND 	 seq_taxa_tarifa = convert(numeric(9), convert(char(6),  T.data_vigencia, 112) + OnPlaceSANED.dbo.fc_completa_zeros(T.grupo, 3))
						  )
	and	0 =  (  
				select count(*)
				from 	ONP_TAXA_TARIFA 
				where 	seq_categoria = T.categoria
				and		seq_taxa = 2
				and 	seq_taxa_tarifa = convert(numeric(9), convert(char(6), T.data_vigencia, 112) + OnPlaceSANED.dbo.fc_completa_zeros(T.grupo, 3))
			 )

	-- Insere tarifa de Esgoto - Limite
	INSERT INTO ONP_TAXA_TARIFA_FAIXA
			(
				seq_categoria,  
				seq_taxa,  
				seq_taxa_tarifa_faixa, 
				seq_taxa_tarifa,  
				val_limite_consumo, 
				val_valor_tarifa
			) 
      SELECT DISTINCT
		  T.categoria AS seq_categoria,
		  2 AS seq_taxa,
		  (
			SELECT COUNT(*) + 1
				FROM  DIADEMA_IV.dbo.IDA_TARIFas T2
				WHERE T2.categoria = T.categoria
				  AND T2.data_vigencia = T.data_vigencia
				  AND T2.limite_consumo < T.limite_consumo
				  AND T2.data_vigencia = T.data_vigencia
				  AND T2.grupo = T.grupo
		  ) AS seq_taxa_tarifa_faixa,
		  CONVERT(NUMERIC(9), CONVERT(CHAR(6), T.data_vigencia, 112) + OnPlaceSANED.dbo.fc_completa_zeros(T.grupo, 3)) AS seq_taxa_tarifa,
		  CasE WHEN T.limite_consumo >= 999999 THEN 9999999 ELSE T.limite_consumo END AS val_limite_consumo,
		  T.agua
		  FROM DIADEMA_IV.dbo.IDA_TARIFas T
			WHERE T.grupo = @parGrupo
			AND 	(
						SELECT referencia
							FROM DIADEMA_IV.dbo.IDA_GRUPOS
							WHERE grupo = @parGrupo
							AND data_processamento IS NULL
							AND data_retorno IS NULL
					) = @parReferencia 
			AND	0 =  	(
							SELECT COUNT(*)
							FROM 	ONP_TAXA_TARIFA_FAIXA 
							WHERE 	seq_categoria = T.categoria
							AND	seq_taxa = 2
							AND	seq_taxa_tarifa_faixa = T.sequencia
							AND seq_taxa_tarifa = CONVERT(NUMERIC(9), CONVERT(CHAR(6), T.data_inicial, 112) + OnPlaceSANED.dbo.fc_completa_zeros(T.grupo, 3))
						 )
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = GETDATE()
		Print ' -- Atualizou AS ONP_TAXA_TARIFA_FAIXA ' + CONVERT(VARCHAR, GETDATE(), 103) + ' ' + CONVERT(VARCHAR, @hrInicio, 108) + ' Tempo: ' + CONVERT(VARCHAR, DATEDIFF(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	


	-- ---------------------------
	-- Insere os dados de Mensagem - Social
	DELETE 	
		FROM ONP_MENSAGEM_MOVIMENTO
		WHERE	seq_mensagem_movimento = 0

	INSERT INTO ONP_MENSAGEM_MOVIMENTO
		(
			seq_mensagem_movimento, 
			seq_tipo_documento, 
			des_mensagem_movimento, 
			dat_inicio, 
			dat_final
		)
		SELECT	
			null as seq_matricula,
			0 as seq_mensagem_movimento,  
			null as seq_grupo_fatura,
			1 as seq_tipo_documento, 
			CONVERT(CHAR(62), ISNULL(Mensagem1, '') ) + CONVERT(CHAR(62), ISNULL(Mensagem2, '') ) + CONVERT(CHAR(62), ISNULL(Mensagem3, '') ) as des_mensagem_movimento, 
			@parReferencia-100 as dat_inicio, 
			@parReferencia+100 as dat_final
		FROM 	DIADEMA_IV.dbo.IDA_MENSAGENS 
		WHERE	Grupo = @parGrupo


	-- ---------------------------
	-- Insere os dados de Mensagem - Indiviual
	INSERT INTO ONP_MENSAGEM_MOVIMENTO
  		(
			seq_matricula, 
			seq_mensagem_movimento, 
			seq_grupo_fatura, 
			seq_tipo_documento, 
			des_mensagem_movimento, 
			dat_inicio, 
			dat_final
		)
	SELECT	
		L.cdc, 
		L.cdc,  
		L.grupo,
		1, --convert(char(62), ISNULL(L.mensagem1,'') ) + convert(char(62), ISNULL(L.mensagem2,'')), 
		(CasE WHEN LEN(L.mensagem1) > 0 THEN CONVERT(CHAR(62), L.mensagem1) + ISNULL(L.mensagem2,'') ELSE ISNULL(L.mensagem2,'') END),
		@parReferencia-100, 
		@parReferencia+100
	FROM 			  
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
	WHERE	
		L.grupo = @parGrupo
		AND L.grupo = G.grupo
        and E.grupo = L.grupo
		and L.codigo_logradouro = E.codigo
		AND	(
				SELECT referencia
					FROM DIADEMA_IV.dbo.IDA_GRUPOS
					WHERE grupo = L.grupo
					AND data_processamento is null
			) = @parReferencia	
		AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim
		AND	LTRIM(RTRIM(ISNULL(L.mensagem1,'') + ' ' + ISNULL(L.mensagem2,''))) != ''
		
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = GETDATE()
		Print ' -- Atualizou AS ONP_MENSAGEM_MOVIMENTO ' + CONVERT(VARCHAR, GETDATE(), 103) + ' ' + CONVERT(VARCHAR, @hrInicio, 108) + ' Tempo: ' + CONVERT(VARCHAR, DATEDIFF(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	


	DECLARE @DescricaoTexto	VARCHAR(100), @Codigo INTEGER

	-- *******************************
	-- Cursor para atualizar LOGRADOURO
	-- Qtde Registros
	SELECT  
		@nQtdeReg = COUNT(DISTINCT LTRIM(RTRIM(E.nome)))
	FROM    
		DIADEMA_IV.dbo.IDA_GRUPOS G, 
		DIADEMA_IV.dbo.IDA_LOGRADOUROS E, 
		DIADEMA_IV.dbo.IDA_LIGACOES L
	LEFT OUTER JOIN DIADEMA_IV.dbo.IDA_HISTORICOS_CONSUMO H ON L.cdc = H.cdc 
																AND L.grupo = H.grupo 
																AND H.referencia = (
																						SELECT MAX(referencia)
																						FROM DIADEMA_IV.dbo.IDA_HISTORICOS_CONSUMO H2
																						WHERE H2.GRUPO = L.GRUPO
																						AND	H2.cdc = L.cdc
																					)

	WHERE	
	L.grupo = G.grupo
	AND E.grupo = L.grupo
	AND L.codigo_logradouro = E.codigo
	AND	G.referencia = @parReferencia	
	AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim
	AND	LTRIM(RTRIM(E.nome)) NOT IN (SELECT des_logradouro FROM ONP_LOGRADOURO) 

	-- Verifica quantidade
	IF @nQtdeReg > 0 BEGIN
		DECLARE CUR_LOGRADOURO CURSOR read_only for
		
		SELECT  DISTINCT 
			LTRIM(RTRIM(E.nome)) AS Logradouro
		FROM        
			DIADEMA_IV.dbo.IDA_GRUPOS G, 
			DIADEMA_IV.dbo.IDA_LOGRADOUROS E, 
			DIADEMA_IV.dbo.IDA_LIGACOES L
			LEFT OUTER JOIN DIADEMA_IV.dbo.IDA_HISTORICOS_CONSUMO H ON L.cdc = H.cdc 
																		AND L.grupo = H.grupo 
																		AND H.referencia = (
																								SELECT MAX(referencia)
																								FROM DIADEMA_IV.dbo.IDA_HISTORICOS_CONSUMO H2
																								WHERE H2.GRUPO = L.GRUPO
																								AND	H2.cdc = L.cdc
																							)

		WHERE	
			L.grupo = G.grupo
			AND E.grupo = L.grupo
			AND L.codigo_logradouro = E.codigo	
			L.grupo = @parGrupo
			AND	G.referencia = @parReferencia	
			AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim
			AND	LTRIM(RTRIM(E.nome)) NOT IN 
				(SELECT des_logradouro FROM ONP_LOGRADOURO) 

		-- CHAMA O CURSOR
		OPEN 	CUR_LOGRADOURO
		FETCH 	NEXT 
		FROM 	CUR_LOGRADOURO
		INTO 	@DescricaoTexto

		-- LOOP CURSOR LOGRADOURO
		WHILE (@@fetch_status <> -1)
		BEGIN
			-- Executa
			exec OnPlaceSANED_movimento.dbo.sp_atualiza_logradouro @DescricaoTexto
			
			-- Proximo
			FETCH NEXT 
			FROM CUR_LOGRADOURO
			INTO @DescricaoTexto
		END

		-- Fecha o cursor Logradouro
		CLOSE CUR_LOGRADOURO
		DEALLOCATE CUR_LOGRADOURO


	END
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = GETDATE()
		Print ' -- Atualizou AS ONP_LOGRADOURO ' + CONVERT(VARCHAR, GETDATE(), 103) + ' ' + CONVERT(VARCHAR, @hrInicio, 108) + ' Tempo: ' + CONVERT(VARCHAR, DATEDIFF(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	


	-- ******************************
	-- Cursor para atualizar SERVICO
	
	-- Qtde Registros
	SELECT  
		@nQtdeReg = count(*)
	FROM    
		DIADEMA_IV.dbo.IDA_SERVICOS S,
		DIADEMA_IV.dbo.IDA_LIGACOES L,
		DIADEMA_IV.dbo.IDA_GRUPOS G
      WHERE 
		L.grupo = G.grupo
		AND S.cdc = L.cdc
		LTRIM(RTRIM(S.descricao)) NOT IN (SELECT des_servico FROM ONP_SERVICO_FATURA)

	-- VerIFica se processa
	IF @nQtdeReg > 0 BEGIN
		DECLARE CUR_SERVICO CURSOR read_only for
		SELECT  DISTINCT 
			LTRIM(RTRIM(S.descricao)) AS Servico
		FROM    DIADEMA_IV.dbo.IDA_SERVICOS S
		where   LTRIM(RTRIM(S.descricao)) NOT IN (SELECT des_servico FROM ONP_SERVICO_FATURA) 

		-- CHAMA O CURSOR
		OPEN 	CUR_SERVICO
		FETCH 	NEXT 
		FROM 	CUR_SERVICO
		INTO 	@DescricaoTexto
	
		-- LOOP CURSOR SERVICO
		WHILE (@@fetch_status <> -1)
		BEGIN
			-- Executa
			exec sp_atualiza_servico @DescricaoTexto
	
			-- Proximo
			FETCH NEXT 
			FROM CUR_SERVICO
			INTO @DescricaoTexto
		END
	
		-- Fecha o cursor servico
		CLOSE CUR_SERVICO
		DEALLOCATE CUR_SERVICO

		-- Inclui servi?o de notIFicacao
		exec OnPlaceSANED_movimento.dbo.sp_atualiza_servico 'NOTIFICACAO DE DEBITO'
	
	END
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = getdate()
		Print ' -- Atualizou AS ONP_SERVICO_FATURA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	

	-- ******************************
	-- Atualiza Movimento

	-- ---------------------------
	-- Insere dados Pessoa
	/*
	INSERT INTO OnPlaceSANED_movimento..ACQ_PESSOA
			(seq_pessoa, des_nome, cod_cpf_cnpj, des_cidade, des_uf, 
			des_logradouro, des_numero, des_complemento, des_bairro, des_cep)
	SELECT 	cg_matricula, cg_nome, Null , 'DIADEMA', 'SP',
			cg_ENDereco, cg_num_imovel, cg_complemento, Null, Null
	FROM 	OnPlaceSANED..carga
	where	L.grupo = @parGrupo
	AND	cg_referencia =  @parReferencia
	AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim
	AND 	cg_matricula NOT IN ( SELECT seq_pessoa FROM 
				      OnPlaceSANED_movimento..ACQ_PESSOA)
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = getdate()
		Print ' -- Atualizou AS ACQ_PESSOA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	
	*/
	-- ---------------------------
	-- Insere dados Matricula
	INSERT INTO ONP_MATRICULA
		(
			seq_matricula,
			seq_rota, 
			seq_leitura, 
			seq_logradouro, 
			val_numero_imovel,
			des_inscricao
			des_complemento,
			nom_cliente
		)
	SELECT	
			L.cdc, 
			case when isnull(L.cdc_pai,0) = 0 then null else L.cdc_pai END, 
			L.cdc, 
			L.sequencia,
			L.Numero_Imovel
			OnPlaceSaned.dbo.FC_COMPLETA_ZEROS(L.setor, 3) + L.inscricao, 
			L.complemento,
			L.NOME

	FROM
		DIADEMA_IV.dbo.IDA_GRUPOS G, 
		DIADEMA_IV.dbo.IDA_LOGRADOUROS E, 
		DIADEMA_IV.dbo.IDA_LIGACOES L,
		
      LEFT OUTER JOIN DIADEMA_IV.dbo.IDA_HISTORICOS_CONSUMO H ON L.cdc = H.cdc 
															and L.grupo = H.grupo 
															and H.referencia = (
																					select MAX(referencia)
																					from DIADEMA_IV.dbo.IDA_HISTORICOS_CONSUMO H2
																					where H2.GRUPO = L.GRUPO
																					AND	H2.cdc = L.cdc
																				)
	where
	
	AND L.grupo = G.grupo
	AND E.grupo = L.grupo
	AND L.codigo_logradouro = E.codigo
	AND L.grupo =  @parGrupo
	AND	G.referencia = @parReferencia
	AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = getdate()
		Print ' -- Atualizou AS ACQ_MATRICULA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	

	-- ---------------------------
	-- Insere dados Mensagem Individual
	INSERT INTO ONP_MENSAGEM_MOVIMENTO
			(
				seq_matricula, 
				seq_mensagem_movimento, 
				seq_tipo_documento, 
				des_mensagem_movimento, 
				dat_inicio, 
				dat_final
			)
		SELECT 	
			L.cdc, 
			L.cdc, 
			1 AS seq_tipo_documento, 
			isnull(L.mensagem1,'')+ isnull(L.mensagem2,'') AS des_mensagem_movimento, 
			convert(datetime, convert(char(9), getdate(),112)) AS dat_inicio, 
			(convert(datetime, convert(char(9), getdate(),112))+15) AS dat_final
		FROM 			
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
		WHERE	L.grupo = @parGrupo
		AND	cg_referencia = @parReferencia
		AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim
		AND	LTRIM(RTRIM(isnull(L.mensagem1,'') + isnull(L.mensagem2,''))) != ''
		AND  	L.cdc NOT IN(
										SELECT seq_matricula  
										FROM	ONP_MENSAGEM_MOVIMENTO
									)
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = getdate()
		Print ' -- Atualizou AS ACQ_MENSAGEM_MOVIMENTO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	

	-- ---------------------------
	-- Insere dados Matricula Leituras - Histórico de consumo - Leituras
	-- Enviado na data de leitura a referencia devido existirem datas repetidas para referências diversas
	-- Como neste caso precisamos apenas do cosnumo
	/*
	INSERT INTO ONP_MATRICULA_LEITURas
			(seq_matricula, cod_referencia, seq_grupo_fatura, 
			 dat_leitura, cod_hidrometro, 
			val_consumo_real, val_leitura_real)
	SELECT 	hc_matricula, convert(char(7), hc_ref_historico, 102), L.grupo,
		hc_ref_historico, cg_numero_hd, 
		hc_consumo, hc_leitura
	FROM 	OnPlaceSANED..historico_consumo, OnPlaceSANED..carga
	where	L.cdc = hc_matricula
	AND 	L.grupo = hc_grupo
	AND	cg_referencia = hc_referencia
	AND	L.grupo = @parGrupo
	AND	cg_referencia = @parReferencia	
	AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim
	AND	0 = 	(SELECT count(*) 
			FROM 	OnPlaceSANED_movimento..ACQ_MATRICULA_LEITURas
			where	cod_referencia = convert(char(7), hc_ref_historico, 102)
			AND	seq_matricula  = hc_matricula)
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = getdate()
		Print ' -- Atualizou AS ACQ_MATRICULA_LEITURas ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	
	*/
	-- ---------------------------
	-- Insere dados Matricula Leituras - Histórico de consumo - Ocorrências
	/*
	INSERT INTO ONP_MOVIMENTO_OCORRENCIA
			(
				seq_roteiro, 
				cod_referencia, 
				seq_matricula, 
				cod_ocorrencia
			)
		SELECT 	
			CONVERT(numeric, '1'+OnPlaceSANED.dbo.fc_completa_zeros(L.grupo, 3)+OnPlaceSANED.dbo.fc_completa_zeros(L.rota,3)) AS seq_roteiro, 
			CONVERT(char(7), H.referencia, 102) AS cod_referencia, 
			H.cdc AS seq_matricula, 
			H.ocorrencia AS cod_ocorrencia
		FROM 	
			DIADEMA_IV.dbo.IDA_HISTORICOS_CONSUMO H,
			DIADEMA_IV.dbo.IDA_LIGACOES L,
			DIADEMA_IV.dbo.IDA_GRUPOS G
		WHERE	
			L.cdc = H.cdc
			AND L.cdc = H.cdc
			AND L.grupo = G.grupo
			AND L.grupo = H.grupo
			AND	cg_referencia = hc_referencia
			AND	L.grupo = @parGrupo
			AND	cg_referencia = @parReferencia	
			AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = getdate()
		Print ' -- Atualizou AS ACQ_MOVIMENTO_OCORRENCIA ' + CONVERT(varchar, getdate(), 103) + ' ' + CONVERT(varchar, @hrInicio, 108) + ' Tempo: ' + CONVERT(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	
	*/
	/*
	-- ---------------------------
	-- Insere dados Matricula Entrega
	INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_ENTREGA
		(seq_matricula, seq_pessoa_entrega,
		des_logradouro, des_numero, des_complemento, des_bairro, des_cidade, des_uf, des_cep)
	SELECT	 L.cdc, L.cdc, 
		cg_entrega_alternativa, Null, Null, Null, 'DIADEMA', 'SP', Null
	FROM 	OnPlaceSANED..carga
	where	L.grupo = @parGrupo
	AND	cg_referencia = @parReferencia
	AND 	isnull(cg_entrega_alternativa,'') <> ''
	AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim
	AND	L.cdc NOT IN ( SELECT seq_matricula FROM 
			      OnPlaceSANED_movimento..ACQ_MATRICULA_ENTREGA)
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = getdate()
		Print ' -- Atualizou AS ACQ_MATRICULA_ENTREGA ' + CONVERT(varchar, getdate(), 103) + ' ' + CONVERT(varchar, @hrInicio, 108) + ' Tempo: ' + CONVERT(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	
	
	-- ---------------------------
	-- Insere dados Matricula D?bito Autom?tico
	INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_DEB_AUTOMATICO
		(seq_matricula, seq_matricula_deb_automatico, 
		cod_banco, cod_banco_agencia, des_conta_corrente,
		dat_opcao_debito, seq_convenio)
	SELECT	L.cdc, 1, 
		cg_codigo_banco , isnull(cg_agencia,0), 'DEBITO AUT',
		(cg_referencia - 500), cg_codigo_banco
	FROM 	OnPlaceSANED..carga
	where	L.grupo = @parGrupo
	AND	cg_referencia = @parReferencia
	AND	isnull(cg_codigo_banco,0) > 0
	AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = getdate()
		Print ' -- Atualizou AS ACQ_MATRICULA_DEB_AUTOMATICO ' + CONVERT(varchar, getdate(), 103) + ' ' + CONVERT(varchar, @hrInicio, 108) + ' Tempo: ' + CONVERT(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	

	-- ---------------------------
	-- Insere dados Matricula Liga??o
	INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_LIGACAO
		(seq_matricula, seq_zona_abastecimento, seq_padrao_imovel, seq_situacao_imovel, 
		seq_tipo_despejo_esgoto, seq_tipo_esgotamento, seq_material_cavalete, seq_diametro_ligacao, 
		ind_reservatorio_superior, ind_reservatorio_inferior, ind_piscina, ind_calcada, 
		ind_jardim, ind_fonte_alternativa, seq_tipo_ligacao, seq_utilizacao_ligacao,
		ind_consumo_estimado, val_consumo_estimado, ind_protecao_hidrometro, seq_localizacao_hidrometro)
	SELECT	L.cdc, L.grupo, 6, 0, 
		0, 1, 1, 1, 
		'S', 'S', 'N', 'S', 
		'S', case when cg_ident_consumidor = 6 then 4 else 0 END, 1, cg_categoria, 
		case 	when LTRIM(RTRIM(isnull(cg_numero_hd,''))) = '' 
			then 'S' 
			else 'N' END, 0,  1, 5
	FROM 	OnPlaceSANED..carga
	where	L.grupo = @parGrupo
	AND	cg_referencia = @parReferencia
	AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = getdate()
		Print ' -- Atualizou AS ACQ_MATRICULA_LIGACAO ' + CONVERT(varchar, getdate(), 103) + ' ' + CONVERT(varchar, @hrInicio, 108) + ' Tempo: ' + CONVERT(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	
	*/
	-- --------------------------
	-- Insere dados dos Hidrometros
	INSERT INTO ONP_HIDROMETRO
		(
			seq_matricula
			cod_hidrometro, 
			val_numero_digitos, 
			cod_modelo_hidrometro, 
			cod_marca, 
			seq_tamanho_hidrometro, 
			ind_tipo_hidrometro, 
			seq_diametro_ligacao, 
			seq_capacidade_hidrometro, 
			ind_status, 
			seq_composicao_numero_medidor, 
			ind_transmissao,
			seq_local
		)
	SELECT
		L.cdc AS seq_matricula,
		L.medidor AS cod_hidrometro, 
		max(isnull(L.qtde_ponteiros,5)) AS val_numero_digitos, 
		9 AS cod_modelo_hidrometro, 
		9 AS cod_marca, 
		1 AS seq_tamanho_hidrometro, 
		'C' AS ind_tipo_hidrometro,
		1 AS seq_diametro_ligacao, 
		1 AS seq_capacidade_hidrometro, 
		'U' AS ind_status, 
		1 AS seq_composicao_numero_medidor,
		2 AS ind_transmissao,
		5 AS seq_local		
	FROM	DIADEMA_IV.dbo.IDA_LIGACOES L
	where	L.grupo = @parGrupo
	AND	cg_referencia = @parReferencia
	AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim
	AND	LTRIM(RTRIM(isnull(L.medidor,''))) != ''
	AND	L.medidor NOT IN (SELECT cod_hidrometro FROM ONP_HIDROMETRO)
	group	by L.medidor,L.cdc
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = getdate()
		Print ' -- Atualizou AS ACQ_HIDROMETRO ' + CONVERT(varchar, getdate(), 103) + ' ' + CONVERT(varchar, @hrInicio, 108) + ' Tempo: ' + CONVERT(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	

	-- ---------------------------
	-- Insere dados Matricula Hidrometro
	-- Inclui os dados dos hidr?metros - troca
	/*
	INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_HIDROMETRO
		(seq_matricula, seq_matricula_hidrometro,
		 cod_hidrometro,  
		 dat_instalacao, val_leitura_instalacao,
		 dat_encerramento, dat_retirada, val_leitura_encerramento,
		 ind_motivo_retirada, 
		 ind_estado_retirada, val_leitura_retirada)
	SELECT 	L.cdc, 1, L.medidor,  
		cg_referencia - 500, cg_leitura_inicial,
		cg_data_instalacao_hd, cg_data_instalacao_hd, Null,  
		 'D', 'C', 0
	FROM	OnPlaceSANED..carga
	where	L.grupo = @parGrupo
	AND	cg_referencia = @parReferencia
	AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim
	AND	LTRIM(RTRIM(isnull(L.medidor,''))) != ''
	AND	cg_flag_troca = 'S'
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = getdate()
		Print ' -- Atualizou AS ACQ_MATRICULA_HIDROMETRO ' + CONVERT(varchar, getdate(), 103) + ' ' + CONVERT(varchar, @hrInicio, 108) + ' Tempo: ' + CONVERT(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	
	
	-- Inclui os dados dos hidr?metros - atuais
	INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_HIDROMETRO
		(seq_matricula, seq_matricula_hidrometro,
		cod_hidrometro, dat_instalacao, 
		val_leitura_instalacao)
	SELECT 	DISTINCT L.cdc, 1 + (case when cg_flag_troca = 'S' then 1 else 0 END), 
		L.medidor, cg_data_instalacao_hd, 
		case when cg_flag_troca = 'S' then cg_leitura_inicial else 0 END
	FROM	OnPlaceSANED..carga
	where	L.grupo = @parGrupo
	AND	cg_referencia = @parReferencia
	AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim
	AND	LTRIM(RTRIM(isnull(L.medidor,''))) != ''
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = getdate()
		Print ' -- Atualizou AS ACQ_MATRICULA_HIDROMETRO ' + CONVERT(varchar, getdate(), 103) + ' ' + CONVERT(varchar, @hrInicio, 108) + ' Tempo: ' + CONVERT(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	
	*/
	-- ---------------------------
	-- Insere Movimento - CARGA
	INSERT INTO ONP_MOVIMENTO
		(
			seq_matricula, 
			ind_situacao_movimento, 
			seq_roteiro, 
			cod_referencia,
			cod_agente, 
			cod_hidrometro, 
			val_numero_digitos, 
			dat_vencimento, 
			val_consumo_medio,
			cod_banco, 
			cod_banco_agencia, 
			ind_entrega_especial, 
			dat_leitura_anterior, 
			dat_leitura_proxima,
			val_leitura_anterior, 
			dat_troca, 
			val_consumo_troca,
			val_quantidade_pendente
		) 
	SELECT	
		L.cdc AS seq_matricula, 
		'P' AS ind_situacao_movimento, 
		CONVERT(numeric, '1' + OnPlaceSANED.dbo.fc_completa_zeros(L.grupo, 3)+OnPlaceSANED.dbo.fc_completa_zeros(L.rota,3)) AS seq_roteiro, 	
		CONVERT(char(7), G.referencia, 102) AS cod_referencia,
		1 AS cod_agente, -- valor fixo para o agente
		L.medidor AS cod_hidrometro, 
		L.medidor AS val_numero_digitos, 
		L.data_vencimento AS dat_vencimento, 
		L.media AS val_consumo_medio,
		L.banco AS cod_banco,
		L.agencia AS cod_banco_agencia, 
		CasE 	
			when (isnull(L.endereco_entrega,'') <> '') AND (L.banco > 0) THEN '5' 
			when (isnull(L.endereco_entrega,'') <> '') THEN '2' 
			when (L.banco > 0) THEN '1'
		ELSE '0' 
		END AS ind_entrega_especial,
		CONVERT( datetime, CONVERT(char(8), isnull(case when H.data_leitura is null then IsNull(L.Data_Inst_HD, ( + G.data_leitura-30)) else H.data_leitura end, G.referencia), 112) ) AS dat_leitura_anterior, 
		G.data_proxima_leitura AS dat_leitura_proxima,
		CasE WHEN isnull(
							(
								CasE WHEN (
											(
												L.Data_Inst_HD > isnull(
																		 H.data_leitura,getdate()
																		)
											) and (
													IsNull(
															Ident_Ligacao_Nova,''
														   ) != ''
												   )
										   ) THEN '' ELSE 1 END
							), 'N') = 0 THEN isnull(L.leitura_inicial_hd, 0) ELSE isnull((CasE WHEN H.data_leitura is null THEN isnull(L.leitura_inicial_hd,0) ELSE isnull(H.leitura,0) END), 0) END AS val_leitura_anterior, 
		
		CasE WHEN isnull(
							(
								CasE WHEN (
											(
												L.Data_Inst_HD > isnull(
																		 H.data_leitura,getdate()
																		)
											) and (
													IsNull(
															Ident_Ligacao_Nova,''
														   ) != ''
												  )
											) THEN '' ELSE 1 END
							), 'N') = 0 THEN isnull(
														(
															CasE WHEN (
																		(
																			L.Data_Inst_HD > isnull(H.data_leitura,getdate()
																		 )
																	   ) and (
																				IsNull(Ident_Ligacao_Nova,'') != '')) THEN L.data_inst_hd ELSE null END), isnull((CasE WHEN H.data_leitura is null THEN IsNull(L.Data_Inst_HD, ( + G.data_leitura-30)) ELSE H.data_leitura END), G.referencia)) ELSE null END AS dat_troca, 
		
		CasE WHEN isnull(
							(
								CasE WHEN (
											(
												L.Data_Inst_HD > isnull(
																			H.data_leitura,getdate()
																		)
											 ) and (
														IsNull(Ident_Ligacao_Nova,'') != ''
													)
											) THEN '' ELSE 1 END
													), 'N') = 0 THEN 2 ELSE null END AS val_consumo_troca,
		isnull(L.qtde_debitos,0) AS val_quantidade_pendente
	FROM	--OnPlaceSANED..carga, OnPlaceSANED..roteiros
		DIADEMA_IV.dbo.IDA_GRUPOS G, 
		DIADEMA_IV.dbo.IDA_LOGRADOUROS E, 
		DIADEMA_IV.dbo.IDA_LIGACOES L
      LEFT OUTER JOIN DIADEMA_IV.dbo.IDA_HISTORICOS_CONSUMO H ON L.cdc = H.cdc 
															and L.grupo = H.grupo 
															and H.referencia = (
																					SELECT MAX(referencia)
																					FROM DIADEMA_IV.dbo.IDA_HISTORICOS_CONSUMO H2
																					WHERE H2.GRUPO = L.GRUPO
																					AND	H2.cdc = L.cdc
																				)
	WHERE	
	L.grupo = G.grupo
	and E.grupo = L.grupo
	AND	L.grupo = @parGrupo
	AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim
	AND	G.referencia = @parReferencia
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = getdate()
		Print ' -- Atualizou AS ONP_MOVIMENTO ' + CONVERT(varchar, getdate(), 103) + ' ' + CONVERT(varchar, @hrInicio, 108) + ' Tempo: ' + CONVERT(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	

	-- -----------------------------
	-- Insere Matricula DIADEMA	
	INSERT INTO ONP_MATRICULA_DIADEMA
		(
			seq_matricula,
			seq_matricula_pai
			val_fraudes, 
			ind_corta_ligacao, 
			ind_retencao_impostos, 
			ind_bloqueio, 
			val_dias_bloqueio_anterior, 
			val_dias_bloqueio_atual, 
			ind_cachorro, 
			ind_tipo_consumidor, 
			ind_calcula_fatura, 
			ind_emite_fatura, 
			seq_desconto, 
			des_mensagem_1, 
			des_mensagem_2, 
			dat_bloqueio
		)
	SELECT	
			L.cdc AS seq_matricula,
			L.cdc_pai AS seq_matricula_pai,
			isnull(L.qtde_registros_fraude,0)  AS val_fraudes, 
			CASE WHEN isnull(L.cortar,'') = '' THEN '' ELSE L.cortar END AS ind_corta_ligacao, 
			L.calcula_imposto AS ind_retencao_impostos, 
			case when isnull(L.bloqueado,'L') in ('L', '') then 'N' else 'S' END AS ind_bloqueio, 
			isnull(L.dias_bloqueio_tarifa_ant,0) AS val_dias_bloqueio_anterior,
			isnull(L.dias_bloqueio_tarifa_atual,0) AS val_dias_bloqueio_atual,
			L.cachorro AS ind_cachorro, 
			L.ident_consumidor AS ind_tipo_consumidor,
			
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
			ELSE 'N' END AS ind_calcula_fatura, 
			CASE WHEN (ISNULL(L.bloqueado,'L') NOT IN ('L', '')) AND (L.ident_consumidor = 9) then 'N' else L.emite_conta END AS ind_emite_fatura, 
			CASE WHEN (L.clas_imovel IN (4, 64)) AND (ISNULL(L.cdc_pai,0) = 0) THEN 0 ELSE L.clas_imovel END AS seq_desconto, 
			L.mensagem1 AS des_mensagem_1, 
			L.mensagem2 AS des_mensagem_2, 
			L.data_bloqueio AS dat_bloqueio
			
	FROM	
		DIADEMA_IV.dbo.IDA_GRUPOS G, 
		DIADEMA_IV.dbo.IDA_LIGACOES L	
	WHERE
		L.grupo = G.grupo
		L.grupo = @parGrupo
		AND	G.referencia = @parReferencia
		AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim
	
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = getdate()
		Print ' -- Atualizou AS ONP_MATRICULA_DIADEMA ' + CONVERT(varchar, getdate(), 103) + ' ' + CONVERT(varchar, @hrInicio, 108) + ' Tempo: ' + CONVERT(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	

	-- -----------------------------
	-- Insere Movimento Categoria - CARGA
	BEGIN
		DECLARE @mvMatricula 	int, 
			@mvRoteiro	dec(11),
			@mvReferencia	datetime,
			@mvCategoria	int,
			@mvCatAux	int,
			@mvEcoRes	int,
			@mvEcoCom	int,
			@mvEcoInd	int,
			@mvEcoPub	int,
			@mvEcoSoc	int,
			@mvEcoEA	int,
			@mvSitAgua	 int,
			@mvSitEsgoto int

		DECLARE CUR_CATEGORIA_MOV CURSOR read_only for
		SELECT	
			L.cdc, 
			CONVERT(numeric, '1' + OnPlaceSANED.dbo.fc_completa_zeros(L.grupo, 3) + OnPlaceSANED.dbo.fc_completa_zeros(L.rota,3)) AS roteiro, 
			G.referencia, 
			L.categoria_imovel, 
			CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_res END, 
			CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_com END, 
			CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_ind END, 
			CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_pub END, 
			CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_soc END, 
			CASE L.categoria_imovel WHEN 8 THEN (L.eco_res + L.eco_com + L.eco_ind + L.eco_pub +  +L.eco_soc) ELSE 0 END, 
			CASE 	WHEN ISNULL(L.bloqueado, 'L') NOT IN ('L', '') THEN
					CASE 	WHEN L.natureza_ligacao IN (1, 2) THEN 3 
						ELSE 4 
					END
				WHEN L.natureza_ligacao in (1, 2) THEN 1 
				ELSE 4 
			END AS ct_lig_agua, 
			case 	when isnull(L.bloqueado, 'L') NOT IN ('L', '') then
					case 	when L.natureza_ligacao in (2, 3) then 3 
						else 4 
					END
				when L.natureza_ligacao in (2, 3) then 1 
				else 4 
			END AS ct_lig_esg
		FROM	DIADEMA_IV.dbo.IDA_LIGACOES L	
		left outer join ONP_CATEGORIA
		on	L.categoria_imovel = seq_categoria
		where	L.grupo = @parGrupo
		AND	G.referencia = @parReferencia
		AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim

		-- CHAMA O CURSOR
		OPEN 	CUR_CATEGORIA_MOV
		FETCH 	NEXT 
		FROM 	CUR_CATEGORIA_MOV
		INTO 	@mvMatricula, 
			@mvRoteiro,
			@mvReferencia,
			@mvCategoria,
			@mvEcoRes,
			@mvEcoCom,
			@mvEcoInd,
			@mvEcoPub,
			@mvEcoSoc,
			@mvEcoEA,
			@mvSitAgua,
			@mvSitEsgoto

		-- LOOP CURSOR SERVICO
		WHILE (@@fetch_status <> -1)
		BEGIN
			DECLARE @mvNumEco int
			-- Residencial
			IF @mvEcoRes > 0 BEGIN
				SELECT @mvCatAux = 1
				set @mvNumEco = @mvEcoRes
				/*
				-- Matricula Taxa Água
				INSERT INTO OnPlaceSANED_movimento..ACQ_TAXA_MATRICULA
					(seq_matricula, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao)
				values	(@mvMatricula, 1,
					@mvCatAux, @mvNumEco, @mvSitAgua)

				-- Matricula Taxa Esgoto
				INSERT INTO OnPlaceSANED_movimento..ACQ_TAXA_MATRICULA
					(seq_matricula, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao)
				values	(@mvMatricula, 2,
					@mvCatAux, @mvNumEco, @mvSitEsgoto)
				*/
				-- Movimento
				INSERT INTO ONP_MOVIMENTO_CATEGORIA
					(
						seq_matricula, 
						seq_roteiro, 
						cod_referencia,
						seq_categoria, 
						val_numero_economia
					)
				values	
					(
						@mvMatricula, 
						@mvRoteiro, 
						CONVERT( char(7), @mvReferencia, 102 ),
						@mvCatAux, 
						@mvNumEco
					)

				-- Movimento Taxa de Agua
				INSERT INTO ONP_MOVIMENTO_TAXA
					(
						seq_matricula, 
						seq_roteiro, 
						cod_referencia, 
						seq_taxa,
						seq_categoria, 
						val_numero_economia, 
						ind_situacao, 
						ind_tipo_consumo, 
						val_valor_calculado
					)
				values	
					(
						@mvMatricula, 
						@mvRoteiro, 
						CONVERT( char(7), @mvReferencia, 102 ), 1,
						@mvCatAux, 
						@mvNumEco, 
						@mvSitAgua, 
						'L', 
						0
					)

				-- Movimento Taxa de Esgoto
				INSERT INTO ONP_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, CONVERT( char(7), @mvReferencia, 102 ), 2,
					 @mvCatAux, @mvNumEco, @mvSitEsgoto, 'L', 0)
			END

			-- Comercial
			IF @mvEcoCom > 0 BEGIN
				SELECT @mvCatAux = 2
				set @mvNumEco = @mvEcoCom
				/*
				-- Matricula Taxa Água
				INSERT INTO OnPlaceSANED_movimento..ACQ_TAXA_MATRICULA
					(seq_matricula, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao)
				values	(@mvMatricula, 1,
					@mvCatAux, @mvNumEco, @mvSitAgua)

				-- Matricula Taxa Esgoto
				INSERT INTO OnPlaceSANED_movimento..ACQ_TAXA_MATRICULA
					(seq_matricula, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao)
				values	(@mvMatricula, 2,
					@mvCatAux, @mvNumEco, @mvSitEsgoto)
				*/
				-- Movimento
				INSERT INTO ONP_MOVIMENTO_CATEGORIA
					(seq_matricula, seq_roteiro, cod_referencia,
					 seq_categoria, val_numero_economia)
				values	(@mvMatricula, @mvRoteiro, CONVERT( char(7), @mvReferencia, 102 ),
					@mvCatAux, @mvNumEco)

				-- Movimento Taxa Água
				INSERT INTO ONP_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, CONVERT( char(7), @mvReferencia, 102 ), 1,
					@mvCatAux, @mvNumEco, @mvSitAgua, 'L', 0)
				
				-- Movimento Taxa Esgoto
				INSERT INTO ONP_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, CONVERT( char(7), @mvReferencia, 102 ), 2,
					 @mvCatAux, @mvNumEco, @mvSitEsgoto, 'L', 0)
			END

			-- Industrial
			IF @mvEcoInd > 0 BEGIN
				SELECT @mvCatAux = 3
				set @mvNumEco = @mvEcoInd

				/*
				-- Matricula Taxa Água
				INSERT INTO OnPlaceSANED_movimento..ACQ_TAXA_MATRICULA
					(seq_matricula, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao)
				values	(@mvMatricula, 1,
					@mvCatAux, @mvNumEco, @mvSitAgua)

				-- Matricula Taxa Esgoto
				INSERT INTO OnPlaceSANED_movimento..ACQ_TAXA_MATRICULA
					(seq_matricula, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao)
				values	(@mvMatricula, 2,
					@mvCatAux, @mvNumEco, @mvSitEsgoto)
				*/
				-- Movimento
				INSERT INTO ONP_MOVIMENTO_CATEGORIA
					(seq_matricula, seq_roteiro, cod_referencia,
					 seq_categoria, val_numero_economia)
				values	(@mvMatricula, @mvRoteiro, CONVERT( char(7), @mvReferencia, 102 ),
					@mvCatAux, @mvNumEco)

				-- ?gua
				INSERT INTO ONP_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, CONVERT( char(7), @mvReferencia, 102 ), 1,
					@mvCatAux, @mvNumEco, @mvSitAgua, 'L', 0)
				
				-- Esgoto
				INSERT INTO ONP_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, CONVERT( char(7), @mvReferencia, 102 ), 2,
					 @mvCatAux, @mvNumEco, @mvSitEsgoto, 'L', 0)
			END

			-- Publica
			IF @mvEcoPub > 0 BEGIN
				SELECT @mvCatAux = 4
				set @mvNumEco = @mvEcoPub

				/*
				-- Matricula Taxa Água
				INSERT INTO OnPlaceSANED_movimento..ACQ_TAXA_MATRICULA
					(seq_matricula, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao)
				values	(@mvMatricula, 1,
					@mvCatAux, @mvNumEco, @mvSitAgua)

				-- Matricula Taxa Esgoto
				INSERT INTO OnPlaceSANED_movimento..ACQ_TAXA_MATRICULA
					(seq_matricula, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao)
				values	(@mvMatricula, 2,
					@mvCatAux, @mvNumEco, @mvSitEsgoto)
				*/
				-- Movimento
				INSERT INTO ONP_MOVIMENTO_CATEGORIA
					(seq_matricula, seq_roteiro, cod_referencia,
					 seq_categoria, val_numero_economia)
				values	(@mvMatricula, @mvRoteiro, CONVERT( char(7), @mvReferencia, 102 ),
					@mvCatAux, @mvNumEco)

				-- ?gua
				INSERT INTO OPN_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, CONVERT( char(7), @mvReferencia, 102 ), 1,
					@mvCatAux, @mvNumEco, @mvSitAgua, 'L', 0)
				
				-- Esgoto
				INSERT INTO ONP_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, CONVERT( char(7), @mvReferencia, 102 ), 2,
					 @mvCatAux, @mvNumEco, @mvSitEsgoto, 'L', 0)
			END

			-- Social 
			IF @mvEcoSoc > 0 BEGIN
				SELECT @mvCatAux = 6
				set @mvNumEco = @mvEcoSoc

				/*
				-- Matricula Taxa Água
				INSERT INTO OnPlaceSANED_movimento..ACQ_TAXA_MATRICULA
					(seq_matricula, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao)
				values	(@mvMatricula, 1,
					@mvCatAux, @mvNumEco, @mvSitAgua)

				-- Matricula Taxa Esgoto
				INSERT INTO OnPlaceSANED_movimento..ACQ_TAXA_MATRICULA
					(seq_matricula, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao)
				values	(@mvMatricula, 2,
					@mvCatAux, @mvNumEco, @mvSitEsgoto)
				*/
				-- Movimento
				INSERT INTO ONP_MOVIMENTO_CATEGORIA
					(seq_matricula, seq_roteiro, cod_referencia,
					 seq_categoria, val_numero_economia)
				values	(@mvMatricula, @mvRoteiro, CONVERT( char(7), @mvReferencia, 102 ),
					@mvCatAux, @mvNumEco)

				-- ?gua
				INSERT INTO ONP_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, CONVERT( char(7), @mvReferencia, 102 ), 1,
					@mvCatAux, @mvNumEco, @mvSitAgua, 'L', 0)
				
				-- Esgoto
				INSERT INTO ONP_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, CONVERT( char(7), @mvReferencia, 102 ), 2,
					 @mvCatAux, @mvNumEco, @mvSitEsgoto, 'L', 0)
			END

			-- Entidade assistencial 
			IF @mvEcoEA > 0 BEGIN
				SELECT @mvCatAux = 8
				set @mvNumEco = @mvEcoEA

				/*
				-- Matricula Taxa Água
				INSERT INTO OnPlaceSANED_movimento..ACQ_TAXA_MATRICULA
					(seq_matricula, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao)
				values	(@mvMatricula, 1,
					@mvCatAux, @mvNumEco, @mvSitAgua)

				-- Matricula Taxa Esgoto
				INSERT INTO OnPlaceSANED_movimento..ACQ_TAXA_MATRICULA
					(seq_matricula, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao)
				values	(@mvMatricula, 2,
					@mvCatAux, @mvNumEco, @mvSitEsgoto)
				*/
				-- Movimento
				INSERT INTO ONP_MOVIMENTO_CATEGORIA
					(seq_matricula, seq_roteiro, cod_referencia,
					 seq_categoria, val_numero_economia)
				values	(@mvMatricula, @mvRoteiro, CONVERT( char(7), @mvReferencia, 102 ),
					@mvCatAux, @mvNumEco)

				-- ?gua
				INSERT INTO ONP_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, CONVERT( char(7), @mvReferencia, 102 ), 1,
					@mvCatAux, @mvNumEco, @mvSitAgua, 'L', 0)
				
				-- Esgoto
				INSERT INTO ONP_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, CONVERT( char(7), @mvReferencia, 102 ), 2,
					 @mvCatAux, @mvNumEco, @mvSitEsgoto, 'L', 0)
			END


			-- Proximo
			FETCH 	NEXT 
			FROM 	CUR_CATEGORIA_MOV
			INTO 	@mvMatricula, 
				@mvRoteiro,
				@mvReferencia,
				@mvCategoria,
				@mvEcoRes,
				@mvEcoCom,
				@mvEcoInd,
				@mvEcoPub,
				@mvEcoSoc,
				@mvEcoEA,
				@mvSitAgua,
				@mvSitEsgoto
		END

		-- Fecha o cursor Logradouro
		CLOSE CUR_CATEGORIA_MOV
		DEALLOCATE CUR_CATEGORIA_MOV

	END
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = getdate()
		Print ' -- Atualizou AS CATEGORIas ' + CONVERT(varchar, getdate(), 103) + ' ' + CONVERT(varchar, @hrInicio, 108) + ' Tempo: ' + CONVERT(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	

	-- ---------------------------
	-- Insere dados Matricula Servico Parcela + Movimento Servi?o

	-- ******************************
	-- Cursor para atualizar ACQ_MATRICULA_SERVICO_PARCELA e ACQ_MOVIMENTO_SERVICO
	/*
	BEGIN
		DECLARE @ssMatriculaAnt int,
			@ssInd		int,
			@ssMatricula 	int,
			@ssGrupo	int,
			@ssReferencia	datetime,
			@ssRoteiro	dec(11),
			@ssServico	int,
			@ssValor	dec(12,2)

		SELECT	@ssMatriculaAnt = 0,
			@ssInd		= 0
	
		DECLARE CUR_SERVICO_STR CURSOR read_only for
		SELECT  sr_matricula AS matricula,
			sr_grupo AS grupo,
			sr_referencia AS referencia, 
			CONVERT(numeric, '1'+OnPlaceSANED.dbo.fc_completa_zeros(L.grupo, 3)+OnPlaceSANED.dbo.fc_completa_zeros(L.rota,3)) AS roteiro, 
			dbo.fc_busca_servico(LTRIM(RTRIM(S.descricao))) AS Servico, case when sr_ind_credito = 'S' then -1 else 1 END * sr_valor
		FROM    OnPlaceSANED..servicos, OnPlaceSANED..carga
		where	L.cdc = sr_matricula
		AND	G.referencia = sr_referencia
		AND	L.grupo = sr_grupo
		AND	L.grupo = @parGrupo
		AND	G.referencia = @parReferencia
		AND	sr_valor > 0
		AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim

		-- CHAMA O CURSOR
		OPEN 	CUR_SERVICO_STR
		FETCH 	NEXT 
		FROM 	CUR_SERVICO_STR
		INTO 	@ssMatricula, 
			@ssGrupo,
			@ssReferencia,
			@ssRoteiro,
			@ssServico,
			@ssValor

		-- LOOP CURSOR SERVICO
		WHILE (@@fetch_status <> -1)
		BEGIN
			IF @ssMatriculaAnt <> @ssMatricula BEGIN
				set @ssInd = 0
			END
			set 	@ssInd = (@ssInd + 1)
			SELECT @ssMatriculaAnt = @ssMatricula

			SELECT	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
			FROM	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
			where	seq_matricula = @ssMatricula

			SELECT	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
			FROM	OnPlaceSANED_movimento..ACQ_MOVIMENTO_SERVICO
			where	cod_referencia = CONVERT(char(7), @ssReferencia, 102)
			AND	seq_roteiro    = @ssRoteiro
			AND	seq_matricula  = @ssMatricula
			
			-- Insere ACQ_MATRICULA_SERVICO_PARCELA
			INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					( seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
					  seq_servico_fatura, cod_referencia, seq_roteiro, 
					  val_valor_parcela, ind_status, ind_documento_origem)
			values	(@ssMatricula, @seq_matricula_servico_parcela, @ssInd,
					 @ssServico, CONVERT(char(7), @ssReferencia, 102), @ssRoteiro,
					 @ssValor, 'A', '01')

			-- Insere ACQ_MOVIMENTO_SERVICO
			INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_SERVICO
				(
					seq_matricula, 
					seq_matricula_servico_parcela, 
					seq_item_servico, 
					cod_referencia, 
					seq_roteiro, 
					ind_documento_origem, 
					val_valor_servico 
				 )
			values	(@ssMatricula, @seq_matricula_servico_parcela, @seq_item_servico,
			    	 CONVERT(char(7), @ssReferencia, 102), @ssRoteiro, '01', @ssValor)
			
			-- Proximo
			FETCH 	NEXT 
			FROM 	CUR_SERVICO_STR
			INTO 	@ssMatricula, 
				@ssGrupo,
				@ssReferencia,
				@ssRoteiro,
				@ssServico,
				@ssValor
		END

		-- Fecha o cursor Logradouro
		CLOSE CUR_SERVICO_STR
		DEALLOCATE CUR_SERVICO_STR

	END
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = getdate()
		Print ' -- Atualizou os SERVIÇOS FATURADOS ' + CONVERT(varchar, getdate(), 103) + ' ' + CONVERT(varchar, @hrInicio, 108) + ' Tempo: ' + CONVERT(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	
	*/
	-- ******************************
	-- Cursor para atualizar NOTIFICACOES
	/*
	BEGIN
		DECLARE	@av_matricula int, 
			@av_grupo int, 
			@av_referencia datetime, 
			@av_data_vencimento datetime, 
			@av_qtde_debito int, 
			@av_valor_total dec(15,2), 
			@av_roteiro int, 
			@av_referencia_debito datetime, 
			@av_valor dec(15,2),  
			@av_valor_item dec(15,2),  
			@av_matricula_ant int, 
			@avAux int, 
			@av_codigo_barras varchar(44),
			@av_codigo_barras_linha  varchar(48),
			@av_tipo varchar(1)

		SELECT 	@av_matricula_ant = 0,
			@avAux = 250

		DECLARE CUR_NOTIFICACAO CURSOR read_only for
		SELECT  db_matricula, db_grupo, db_referencia, 
			db_data_vencimento, db_qtde_debitos, db_valor_total, 
			CONVERT(numeric, '1'+OnPlaceSANED.dbo.fc_completa_zeros(L.grupo, 3)+OnPlaceSANED.dbo.fc_completa_zeros(L.rota,3)) AS roteiro ,
			db_codigo_barras,
			OnPlaceSANED_Movimento.dbo.FC_CODIGO_BARRas_CONTROLE(db_codigo_barras),
			isnull(db_tipo,'N')
		FROM 	OnPlaceSANED.dbo.debitos, OnPlaceSANED..carga
		where	L.cdc = db_matricula 
		AND	G.referencia = db_referencia
		AND	L.grupo = db_grupo
		AND	L.grupo = @parGrupo
		AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim
		AND	G.referencia = @parReferencia
		order	by db_matricula, db_data_vencimento 
		

		-- CHAMA O CURSOR
		OPEN 	CUR_NOTIFICACAO
		FETCH 	NEXT 
		FROM 	CUR_NOTIFICACAO
		INTO 	@av_matricula, @av_grupo, @av_referencia, 
			@av_data_vencimento, @av_qtde_debito, @av_valor_total, 
			@av_roteiro,
			@av_codigo_barras, @av_codigo_barras_linha,
			@av_tipo
		
		-- LOOP CURSOR NOTIFICACAO
		WHILE (@@fetch_status <> -1)
		BEGIN

			IF  @av_matricula_ant != @av_matricula BEGIN
				set 	@avAux = 0
			END
			SELECT 	@av_matricula_ant = @av_matricula

			SELECT	@seq_processo_corte = isnull(max(seq_processo_corte),0)+1
			FROM	OnPlaceSANED_movimento..ACQ_PROCESSO_CORTE

			INSERT INTO OnPlaceSANED_movimento..ACQ_PROCESSO_CORTE
				(seq_processo_corte, seq_matricula, seq_politica_corte, dat_abertura)
			values	(@seq_processo_corte, @av_matricula, 1,
				CONVERT(datetime, CONVERT(char(8), getdate(), 112)))

			SELECT	@seq_aviso = isnull(max(seq_aviso),0)+1
			FROM	OnPlaceSANED_movimento..ACQ_AVISO
	
			-- Monta a sequencia da fatura
			SELECT	@seq_fatura = isnull(max(seq_fatura),0)+1
			FROM	OnPlaceSANED_movimento..ACQ_FATURA

			-- Insere Fatura
			INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA
				(dat_leitura, cod_referencia, dat_vencimento, val_valor_faturado, 
				seq_fatura, seq_roteiro,
				seq_matricula, ind_fatura_emitida, ind_status, 
				des_codigo_barras, des_linha_digitavel,
				ind_tipo_documento_origem, des_documento_origem )
			values	(CONVERT(datetime, '19740506'), CONVERT(char(7), CONVERT(datetime, '19740506'), 102), @av_data_vencimento, @av_valor_total, 
				@seq_fatura, @av_roteiro,
				@av_matricula, 'S', 'RE',  
				@av_codigo_barras , @av_codigo_barras_linha,
				4, CONVERT(varchar, @seq_aviso) )

			-- Insere Aviso
			INSERT INTO OnPlaceSANED_movimento..ACQ_AVISO
				(seq_aviso, seq_matricula, seq_politica_corte, seq_processo_corte,
				seq_fatura, dat_geracao_aviso, 
				val_quantidade_debito, val_valor_debito, ind_confirma_entrega,
				ind_documento)
			values	(@seq_aviso, @av_matricula, 1, @seq_processo_corte,
				@seq_fatura, CONVERT(datetime, CONVERT(char(8), getdate(), 112)), 
				@av_qtde_debito, @av_valor_total, 'N', 
				@av_tipo)

			-- Inclui AS refer?ncias somente se houver menos que 06 d?bitos
			IF @av_qtde_debito <= 6
			BEGIN
						
				DECLARE CUR_AVISO CURSOR read_only for	
				SELECT 	di_referencia_debito, di_valor
				FROM 	OnPlaceSANED.dbo.debitos_itens
				where 	di_matricula = @av_matricula
				AND 	di_referencia = @parReferencia
				AND	di_referencia_debito is not null
				AND	di_valor > 0
				order	by di_sequencia
			
				-- CHAMA O CURSOR
				OPEN 	 CUR_AVISO
				FETCH 	 NEXT 
				FROM 	 CUR_AVISO 
				into 	 @av_referencia_debito, @av_valor_item

				-- LOOP CURSOR ITENS D?BITO
				WHILE (@@fetch_status <> -1)
				BEGIN

					-- Contadores
					set	@avAux = (@avAux + 1)   

					-- Monta a sequencia da fatura
					SELECT	@seq_fatura = isnull(max(seq_fatura),0)+1
					FROM	OnPlaceSANED_movimento..ACQ_FATURA
		
					-- Insere Fatura
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA
						(dat_leitura, cod_referencia, dat_vencimento, val_valor_faturado, 
						seq_fatura, seq_roteiro,
						seq_matricula, ind_fatura_emitida, ind_status )
					values	(@av_referencia_debito, CONVERT(char(7), @av_referencia_debito, 102), @av_data_vencimento, @av_valor_item, 
						@seq_fatura, @av_roteiro,
						@av_matricula, 'S', 'RE')


					-- Insere Aviso Fatura
					INSERT INTO OnPlaceSANED_movimento..ACQ_AVISO_FATURA
						(seq_aviso, seq_aviso_fatura, seq_fatura)
					values	(@seq_aviso, @avAux, @seq_fatura)

					-- Busca servi?o fatura
					SELECT	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
					FROM	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					where	seq_matricula = @av_matricula

					-- Insere ACQ_MATRICULA_SERVICO_PARCELA
					INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
						(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
						 seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
						 cod_referencia, val_valor_parcela)
					values	(@av_matricula, @seq_matricula_servico_parcela, @avAux,
						 OnPlaceSANED_movimento.dbo.fc_busca_servico('NOTIFICACAO DE DEBITO'), @ssRoteiro, 'A', '01',
						 CONVERT(char(7), @av_referencia_debito, 102), @av_valor_item)

					SELECT	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
					FROM	OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
					where	seq_fatura = @seq_fatura

					-- Insere ACQ_FATURA_SERVICO
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
						(seq_fatura, seq_matricula_servico_parcela, seq_item_servico, seq_parcela,
						 ind_documento_origem, val_valor_servico)
					values	(@seq_fatura, @seq_matricula_servico_parcela, @seq_item_servico, 1,
						'01', @av_valor_item)

					-- Pr?ximo registro
					FETCH 	NEXT 
					FROM 	CUR_AVISO
					into 	@av_referencia_debito, @av_valor_item
				END

				-- FECHAR O CURSOR
				CLOSE CUR_AVISO
				DEALLOCATE CUR_AVISO
			END

			-- Proximo
			FETCH 	NEXT 
			FROM 	CUR_NOTIFICACAO
			INTO 	@av_matricula, @av_grupo, @av_referencia, 
				@av_data_vencimento, @av_qtde_debito, @av_valor_total, 
				@av_roteiro,
				@av_codigo_barras, @av_codigo_barras_linha,
				@av_tipo

		END

		-- Fecha o cursor Logradouro
		CLOSE CUR_NOTIFICACAO
		DEALLOCATE CUR_NOTIFICACAO

	END
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = getdate()
		Print ' -- Atualizou os AVISOS DE DÉBITOS ' + CONVERT(varchar, getdate(), 103) + ' ' + CONVERT(varchar, @hrInicio, 108) + ' Tempo: ' + CONVERT(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	
	*/
	-- ******************************
	-- Inclui dados da Segunda via
	
	BEGIN
		--
		DECLARE	@sv_matricula int , @sv_referencia datetime ,
			@sv_grupo int , @sv_cod_iptu int ,
			@sv_roteiro int ,
			@sv_ref_2via datetime ,
			@sv_leitura_ant int , @sv_leitura_atual int ,
			@sv_hidrometro varchar (9) , 
			@sv_ocorrencia_ant int , @sv_consumo int , @sv_consumo_medio int ,	
			@sv_data_vencimento datetime , @sv_data_leitura_anterior datetime , @sv_data_leitura datetime , @sv_data_proxima_leit datetime ,
			@sv_categoria int , 
			@sv_economia_res int , 
			@sv_economia_com int , 
			@sv_economia_ind int ,
			@sv_economia_pub int ,  
			@sv_economia_soc int ,  
			@sv_economia_ea int , 
			@sv_ind_mista int ,
			@sv_servico_ag decimal(11, 2) , @sv_servico_es decimal(11, 2) ,
			@sv_desc_servico_01 varchar (30) , @sv_valor_servico_01 decimal(11, 2) ,
			@sv_desc_servico_02 varchar (30) , @sv_valor_servico_02 decimal(11, 2) ,
			@sv_desc_servico_03 varchar (30) , @sv_valor_servico_03 decimal(11, 2) ,
			@sv_desc_servico_04 varchar (30) , @sv_valor_servico_04 decimal(11, 2) ,
			@sv_desc_servico_05 varchar (30) , @sv_valor_servico_05 decimal(11, 2) ,
			@sv_desc_servico_06 varchar (30) , @sv_valor_servico_06 decimal(11, 2) ,
			@sv_desc_servico_07 varchar (30) , @sv_valor_servico_07 decimal(11, 2) ,
			@sv_desc_servico_08 varchar (30) , @sv_valor_servico_08 decimal(11, 2) ,
			@sv_desc_servico_09 varchar (30) , @sv_valor_servico_09 decimal(11, 2) ,
			@sv_ref_01 datetime , @sv_consumo_01 int ,
			@sv_ref_02 datetime , @sv_Consumo_02 int ,
			@sv_ref_03 datetime , @sv_Consumo_03 int ,
			@sv_ref_04 datetime , @sv_Consumo_04 int ,
			@sv_ref_05 datetime , @sv_Consumo_05 int ,
			@sv_ref_06 datetime , @sv_Consumo_06 int ,
			@sv_codigo_barras varchar(44),
			@sv_total dec(13, 2),
			@sv_codigo_barras_linha  varchar(48)

		DECLARE @sv_matricula_ant int, 
			@svAux int, 
			@svConsumoEco int, 
			@svTotalEco int,
			@svCodServico int

		SELECT 	@sv_matricula_ant = 0,
			@svAux = 100,
			@avAux = 500

		DECLARE CUR_SEGVIA CURSOR read_only for
		SELECT  
			SV.cdc , 
			(
				SELECT referencia
				FROM DIADEMA_IV.dbo.IDA_GRUPOS
				WHERE grupo = L.grupo
				AND data_processamento IS NULL
			), 
			SV.data_vencimento ,
			SV.grupo , 
			CONVERT(numeric, '1'+OnPlaceSANED.dbo.fc_completa_zeros(L.grupo, 3)+OnPlaceSANED.dbo.fc_completa_zeros(L.rota,3)) AS roteiro, 
			SV.referencia ,
			SV.leitura_anterior , 
			SV.leitura_atual,
			SV.data_leitura_anterior, 
			SV.data_leitura,
			SV.consumo_faturado, 
			SV.media, 
			L.categoria_imovel, 
			CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_res END,
			CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_com END,
			CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_ind END,
			CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_pub END,
			CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_soc END,
			CASE L.categoria_imovel WHEN 8 THEN (L.eco_res + L.eco_com + L.eco_ind + L.eco_pub +  +L.eco_soc) ELSE 0 END,
			case when (	
						case when (CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_res END) > 0 then 1 else 0 END +
						case when (
									CASE L.categoria_imovel 
															WHEN 8 
																THEN 0 
																	ELSE L.eco_res END) > 0 then 1 else 0 END +
						case when (
									CASE L.categoria_imovel 
															WHEN 8 
																THEN 0 
																	ELSE L.eco_ind 
																					END) > 0 
																							then 1 else 0 END +
						case when (CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_pub END) > 0 then 1 else 0 END +
						case when (CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_soc END) > 0 then 1 else 0 END +
						case when (CASE L.categoria_imovel WHEN 8 THEN (L.eco_res + L.eco_com + L.eco_ind + L.eco_pub +  +L.eco_soc) ELSE 0 END) > 0 then 1 else 0 END) >= 2
						then 1 else 0 END,
			isnull(SV.servico_01,''), isnull(SV.valor_01,0),
			isnull(SV.servico_02,''), isnull(SV.valor_02,0),
			isnull(SV.servico_03,''), isnull(SV.valor_03,0),
			isnull(SV.servico_04,''), isnull(SV.valor_04,0),
			isnull(SV.servico_05,''), isnull(SV.valor_05,0),
			isnull(SV.servico_06,''), isnull(SV.valor_06,0),
			isnull(SV.servico_07,''), isnull(SV.valor_07,0),
			isnull(SV.servico_08,''), isnull(SV.valor_08,0),
			isnull(SV.servico_09,''), isnull(SV.valor_09,0),
			isnull(SV.ref_cons_1,getdate()) , isnull(SV.cons_1,0),
			isnull(SV.ref_cons_2,getdate()) , isnull(SV.cons_1,0),
			isnull(SV.ref_cons_3,getdate()) , isnull(SV.cons_1,0),
			isnull(SV.ref_cons_4,getdate()) , isnull(SV.cons_1,0),
			isnull(SV.ref_cons_5,getdate()) , isnull(SV.cons_1,0),
			isnull(SV.ref_cons_6,getdate()) , isnull(SV.cons_1,0),
			SV.valor_total,
			SV.codigo_barras,
			OnPlaceSANED_Movimento.dbo.FC_CODIGO_BARRas_CONTROLE(SV.codigo_barras)
		FROM	
			DIADEMA_IV.dbo.IDA_GRUPOS G, 
			DIADEMA_IV.dbo.IDA_LIGACOES L, 
			DIADEMA_IV.dbo.IDA_SEGUNDAS_VIAS SV
		WHERE 
		L.cdc = SV.cdc	
		AND	L.grupo = SV.grupo
		AND	G.referencia = SV.referencia
		AND	L.grupo = @parGrupo
		AND	G.referencia = @parReferencia
		AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim

		-- CHAMA O CURSOR
		OPEN 	CUR_SEGVIA
		FETCH 	NEXT 
		FROM 	CUR_SEGVIA
		INTO 	
			@sv_matricula , 
			@sv_referencia , 
			@sv_data_vencimento ,
			@sv_grupo ,
			@sv_roteiro ,
			@sv_ref_2via ,
			@sv_leitura_ant , 
			@sv_leitura_atual ,
			@sv_data_leitura_anterior , 
			@sv_data_leitura ,
			@sv_consumo , 
			@sv_consumo_medio , 
			@sv_categoria , 
			@sv_economia_res , 
			@sv_economia_com , 
			@sv_economia_ind ,
			@sv_economia_pub , 
			@sv_economia_soc , 
			@sv_economia_ea ,  
			@sv_ind_mista ,
			@sv_desc_servico_01 , @sv_valor_servico_01 ,
			@sv_desc_servico_02 , @sv_valor_servico_02 ,
			@sv_desc_servico_03 , @sv_valor_servico_03 ,
			@sv_desc_servico_04 , @sv_valor_servico_04 ,
			@sv_desc_servico_05 , @sv_valor_servico_05 ,
			@sv_desc_servico_06 , @sv_valor_servico_06 ,
			@sv_desc_servico_07 , @sv_valor_servico_07 , 	
			@sv_desc_servico_08 , @sv_valor_servico_08 ,
			@sv_desc_servico_09 , @sv_valor_servico_09 ,
			@sv_ref_01 , @sv_consumo_01 ,
			@sv_ref_02 , @sv_Consumo_02 ,
			@sv_ref_03 , @sv_Consumo_03 ,
			@sv_ref_04 , @sv_Consumo_04 ,
			@sv_ref_05 , @sv_Consumo_05 ,
			@sv_ref_06 , @sv_Consumo_06 ,
			@sv_total, 
			@sv_codigo_barras , @sv_codigo_barras_linha

		-- LOOP CURSOR 
		WHILE (@@fetch_status <> -1)
		BEGIN
			-- Executa
			-- Inicializa
			IF @sv_matricula != @sv_matricula_ant BEGIN
				set	@svAux = 100
				set	@avAux = 500
			END

			SELECT	@sv_matricula_ant = @sv_matricula
			set	@svAux = (@svAux+1)
	
			-- Monta a sequencia da fatura
			SELECT	@seq_fatura = isnull(max(seq_fatura),0)+1
			FROM	ONP_FATURA
	
			-- Insere Fatura
			INSERT INTO ONP_FATURA
				(
					dat_leitura, 
					cod_referencia, 
					dat_vencimento, 
					val_valor_faturado, 
					seq_fatura, 
					seq_roteiro,
					seq_matricula, 
					ind_fatura_emitida, 
					dat_leitura_anterior, 
					val_leitura_real, 
					val_leitura_anterior, 
					val_consumo_medido, 
					val_consumo_medio,
					seq_tipo_entrega, 
					des_codigo_barras, 
					des_linha_digitavel 
				)
			values	(
						@sv_data_leitura, 
						CONVERT(char(7), 
						@sv_ref_2via, 102), 
						@sv_data_vencimento, 
						@sv_total, 
						@seq_fatura, 
						@sv_roteiro,
						@sv_matricula, 
						'N', 
						@sv_data_leitura_anterior , 
						@sv_leitura_atual, 
						@sv_leitura_ant, 
						@sv_consumo, 
						@sv_consumo_medio, 
						null,  
						@sv_codigo_barras , 
						@sv_codigo_barras_linha 
					)

			SELECT 	@sv_servico_ag = 0, 
				@sv_servico_es = 0 

				
---------------------------------------------------ATENCAO VERIFIACAR OS SERVIÇOS-------------------------------------------------				
				
				
				
			-- VerIFica se existe servi?o
			-- Servico 01
			IF (LTRIM(RTRIM(isnull(@sv_desc_servico_01, ''))) != '') AND (isnull(@sv_valor_servico_01,0) != 0) BEGIN
				SELECT	@DescricaoTexto = LTRIM(RTRIM(isnull(@sv_desc_servico_01, '')))
				exec 	OnPlaceSANED_movimento..sp_atualiza_servico @DescricaoTexto
				SELECT	@svCodServico = OnPlaceSANED_movimento.dbo.fc_busca_servico(@DescricaoTexto) -- OLHAR A PROCEDULE
				--isnull(@svCodServico,0)

				IF @DescricaoTexto = 'AGUA' BEGIN
					SELECT 	@sv_servico_ag = @sv_valor_servico_01 
				END
				else IF @DescricaoTexto = 'ESGOTO' BEGIN
					SELECT 	@sv_servico_es = @sv_valor_servico_01  
				END
				else BEGIN
				
					/*
					SELECT	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
					FROM	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					where	seq_matricula = @sv_matricula
	
					set	@avAux = (@avAux + 1)

					-- Insere ACQ_MATRICULA_SERVICO_PARCELA
					INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
						(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
						 seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
						 cod_referencia, val_valor_parcela)
					values	(@sv_matricula, @seq_matricula_servico_parcela, @avAux,
						 isnull(@svCodServico,0), @sv_roteiro, 'A', '01',
						 CONVERT(char(7), @sv_ref_2via, 102), @sv_valor_servico_01)
					*/
					SELECT	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
					FROM	ONP_FATURA_SERVICO
					where	seq_fatura = @seq_fatura

					-- Insere ACQ_FATURA_SERVICO
					INSERT INTO ONP_FATURA_SERVICO
						(
							seq_fatura, 
							seq_item_servico, 
							seq_parcela,
							cod_referencia,
							seq_roteiro,
							seq_matricula,
							des_servico,
							val_parcela,
							ind_credito
						)
					values	(
								SELECT  
									null AS seq_fatura,
									null AS seq_item_servico,
									CONVERT(char(7),SV.referencia,102) AS cod_referencia,
									CONVERT(numeric, '1'+OnPlaceSANED.dbo.fc_completa_zeros(L.grupo, 3)+OnPlaceSANED.dbo.fc_completa_zeros(L.rota,3)) AS roteiro, 
									SV.cdc AS seq_matricula,
									isnull(SV.servico_01,'') AS desc_servico, 
									1 AS seq_parcela,
									isnull(SV.valor_01,0) AS val_parcela,
									null AS ind_credito
								FROM	
									DIADEMA_IV.dbo.IDA_GRUPOS G, 
									DIADEMA_IV.dbo.IDA_LIGACOES L, 
									DIADEMA_IV.dbo.IDA_SEGUNDAS_VIAS SV
								WHERE 
								L.cdc = SV.cdc	
								AND	L.grupo = SV.grupo
								AND	G.referencia = SV.referencia
								AND	L.grupo = @parGrupo
								--AND	G.referencia = @parReferencia
								--AND	L.rota BETWEEN @parRoteiroIni AND @parRoteiroFim
								
							)
				END
			END

			-- Servico 02
			IF (LTRIM(RTRIM(isnull(@sv_desc_servico_02, ''))) != '') AND (isnull(@sv_valor_servico_02,0) != 0) BEGIN
				SELECT	@DescricaoTexto = LTRIM(RTRIM(isnull(@sv_desc_servico_02, '')))
				exec 	OnPlaceSANED_movimento..sp_atualiza_servico @DescricaoTexto

				SELECT	@svCodServico = OnPlaceSANED_movimento.dbo.fc_busca_servico(@DescricaoTexto)
				--isnull(@svCodServico,0)
				
				IF @DescricaoTexto = 'AGUA' BEGIN
					SELECT 	@sv_servico_ag = @sv_valor_servico_02 
				END
				else IF @DescricaoTexto = 'ESGOTO' BEGIN
					SELECT 	@sv_servico_es = @sv_valor_servico_02  
				END
				else BEGIN
					/*
					SELECT	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
					FROM	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					where	seq_matricula = @sv_matricula
	
					set	@avAux = (@avAux + 1)

					-- Insere ACQ_MATRICULA_SERVICO_PARCELA
					INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
						(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
						seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
						cod_referencia, val_valor_parcela)
					values	(@sv_matricula, @seq_matricula_servico_parcela, @avAux,
						isnull(@svCodServico,0), @sv_roteiro, 'A', '01',
						CONVERT(char(7), @sv_ref_2via, 102), @sv_valor_servico_02)
					*/
					SELECT	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
					FROM	ONP_FATURA_SERVICO
					where	seq_fatura = @seq_fatura

					-- Insere ACQ_FATURA_SERVICO
					INSERT INTO ONP_FATURA_SERVICO
						(
							seq_fatura, 
							seq_item_servico, 
							seq_parcela,
							
							cod_referencia,
							seq_roteiro,
							seq_matricula,
							des_servico,
							val_parcela,
							ind_credito
						)
					values	(
								@seq_fatura, 
								@seq_item_servico, 
								1,
								
								@sv_consumo_02,
								@sv_roteiro,
								@sv_matricula,
								@sv_desc_servico_02,
								@sv_valor_servico_02,
								null--VERIFICAR
								
							)
				END
			END

			-- Servico 03
			IF (LTRIM(RTRIM(isnull(@sv_desc_servico_03, ''))) != '') AND (isnull(@sv_valor_servico_03,0) != 0) BEGIN
				SELECT	@DescricaoTexto = LTRIM(RTRIM(isnull(@sv_desc_servico_03, '')))
				exec 	OnPlaceSANED_movimento..sp_atualiza_servico @DescricaoTexto

				SELECT	@svCodServico = OnPlaceSANED_movimento.dbo.fc_busca_servico(@DescricaoTexto)
				--isnull(@svCodServico,0)
				/*
				SELECT	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
				FROM	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
				where	seq_matricula = @sv_matricula

				set	@avAux = (@avAux + 1)

				-- Insere ACQ_MATRICULA_SERVICO_PARCELA
				INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
					seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
					cod_referencia, val_valor_parcela)
				values	(@sv_matricula, @seq_matricula_servico_parcela, @avAux,
					isnull(@svCodServico,0), @sv_roteiro, 'A', '01',
					CONVERT(char(7), @sv_ref_2via, 102), @sv_valor_servico_03)
				*/
				SELECT	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
				FROM	ONP_FATURA_SERVICO
				where	seq_fatura = @seq_fatura

				-- Insere ONP_FATURA_SERVICO
				INSERT INTO ONP_FATURA_SERVICO
					(
						seq_fatura, 
						seq_matricula_servico_parcela, 
						seq_item_servico, 
						seq_parcela,
						seq_servico_fatura, 
						ind_documento_origem, 
						val_valor_servico
					)
				values	(
							@seq_fatura, 
							@seq_matricula_servico_parcela, 
							@seq_item_servico, 
							1,
							isnull(@svCodServico,0), 
							'01', 
							@sv_valor_servico_03
						)
			END

			-- Servico 04
			IF (LTRIM(RTRIM(isnull(@sv_desc_servico_04, ''))) != '') AND (isnull(@sv_valor_servico_04,0) != 0) BEGIN
				SELECT	@DescricaoTexto = LTRIM(RTRIM(isnull(@sv_desc_servico_04, '')))
				exec 	OnPlaceSANED_movimento..sp_atualiza_servico @DescricaoTexto
				
				SELECT	@svCodServico = OnPlaceSANED_movimento.dbo.fc_busca_servico(@DescricaoTexto)
				--isnull(@svCodServico,0)
				/*
				SELECT	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
				FROM	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
				where	seq_matricula = @sv_matricula

				set	@avAux = (@avAux + 1)

				-- Insere ACQ_MATRICULA_SERVICO_PARCELA
				INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
					seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
					cod_referencia, val_valor_parcela)
				values	(@sv_matricula, @seq_matricula_servico_parcela, @avAux,
					isnull(@svCodServico,0), @sv_roteiro, 'A', '01',
					CONVERT(char(7), @sv_ref_2via, 102), @sv_valor_servico_04)
				*/
				SELECT	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
				FROM	ONP_FATURA_SERVICO
				where	seq_fatura = @seq_fatura

				-- Insere ACQ_FATURA_SERVICO
				INSERT INTO ONP_FATURA_SERVICO
					(seq_fatura, seq_matricula_servico_parcela, seq_item_servico, seq_parcela,
					seq_servico_fatura, ind_documento_origem, val_valor_servico)
				values	(@seq_fatura, @seq_matricula_servico_parcela, @seq_item_servico, 1,
					isnull(@svCodServico,0), '01', @sv_valor_servico_04)
			END

			-- Servico 05
			IF (LTRIM(RTRIM(isnull(@sv_desc_servico_05, ''))) != '') AND (isnull(@sv_valor_servico_05,0) != 0) BEGIN
				SELECT	@DescricaoTexto = LTRIM(RTRIM(isnull(@sv_desc_servico_05, '')))
				exec 	OnPlaceSANED_movimento..sp_atualiza_servico @DescricaoTexto

				SELECT	@svCodServico = OnPlaceSANED_movimento.dbo.fc_busca_servico(@DescricaoTexto)
				--isnull(@svCodServico,0)
				/*
				SELECT	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
				FROM	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
				where	seq_matricula = @sv_matricula

				set	@avAux = (@avAux + 1)

				-- Insere ACQ_MATRICULA_SERVICO_PARCELA
				INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
					seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
					cod_referencia, val_valor_parcela)
				values	(@sv_matricula, @seq_matricula_servico_parcela, @avAux,
					isnull(@svCodServico,0), @sv_roteiro, 'A', '01',
					CONVERT(char(7), @sv_ref_2via, 102), @sv_valor_servico_05)
				*/
				SELECT	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
				FROM	ONP_FATURA_SERVICO
				where	seq_fatura = @seq_fatura

				-- Insere ACQ_FATURA_SERVICO
				INSERT INTO ONP_FATURA_SERVICO
					(seq_fatura, seq_matricula_servico_parcela, seq_item_servico, seq_parcela,
					seq_servico_fatura, ind_documento_origem, val_valor_servico)
				values	(@seq_fatura, @seq_matricula_servico_parcela, @seq_item_servico, 1,
					isnull(@svCodServico,0), '01', @sv_valor_servico_05)
			END

			-- Servico 06
			IF (LTRIM(RTRIM(isnull(@sv_desc_servico_06, ''))) != '') AND (isnull(@sv_valor_servico_06,0) != 0) BEGIN
				SELECT	@DescricaoTexto = LTRIM(RTRIM(isnull(@sv_desc_servico_06, '')))
				exec 	OnPlaceSANED_movimento..sp_atualiza_servico @DescricaoTexto

				SELECT	@svCodServico = OnPlaceSANED_movimento.dbo.fc_busca_servico(@DescricaoTexto)
				--isnull(@svCodServico,0)
				/*
				SELECT	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
				FROM	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
				where	seq_matricula = @sv_matricula

				set	@avAux = (@avAux + 1)

				-- Insere ACQ_MATRICULA_SERVICO_PARCELA
				INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
					seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
					cod_referencia, val_valor_parcela)
				values	(@sv_matricula, @seq_matricula_servico_parcela, @avAux,
					isnull(@svCodServico,0), @sv_roteiro, 'A', '01',
					CONVERT(char(7), @sv_ref_2via, 102), @sv_valor_servico_06)
				*/
				SELECT	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
				FROM	ONP_FATURA_SERVICO
				where	seq_fatura = @seq_fatura

				-- Insere ONP_FATURA_SERVICO
				INSERT INTO ONP_FATURA_SERVICO
					(seq_fatura, seq_matricula_servico_parcela, seq_item_servico, seq_parcela,
					seq_servico_fatura, ind_documento_origem, val_valor_servico)
				values	(@seq_fatura, @seq_matricula_servico_parcela, @seq_item_servico, 1,
					isnull(@svCodServico,0), '01', @sv_valor_servico_06)
			END

			-- Servico 07
			IF (LTRIM(RTRIM(isnull(@sv_desc_servico_07, ''))) != '') AND (isnull(@sv_valor_servico_07,0) != 0) BEGIN
				SELECT	@DescricaoTexto = LTRIM(RTRIM(isnull(@sv_desc_servico_07, '')))
				exec 	OnPlaceSANED_movimento..sp_atualiza_servico @DescricaoTexto
				
				SELECT	@svCodServico = OnPlaceSANED_movimento.dbo.fc_busca_servico(@DescricaoTexto)
				--isnull(@svCodServico,0)
				/*
				SELECT	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
				FROM	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
				where	seq_matricula = @sv_matricula

				set	@avAux = (@avAux + 1)

				-- Insere ACQ_MATRICULA_SERVICO_PARCELA
				INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
					seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
					cod_referencia, val_valor_parcela)
				values	(@sv_matricula, @seq_matricula_servico_parcela, @avAux,
					isnull(@svCodServico,0), @sv_roteiro, 'A', '01',
					CONVERT(char(7), @sv_ref_2via, 102), @sv_valor_servico_07)
				*/
				SELECT	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
				FROM	ONP_FATURA_SERVICO
				where	seq_fatura = @seq_fatura
				
				-- Insere ONP_FATURA_SERVICO
				INSERT INTO ONP_FATURA_SERVICO
					(seq_fatura, seq_matricula_servico_parcela, seq_item_servico, seq_parcela,
					seq_servico_fatura, ind_documento_origem, val_valor_servico)
				values	(@seq_fatura, @seq_matricula_servico_parcela, @seq_item_servico, 1,
					isnull(@svCodServico,0), '01', @sv_valor_servico_07)
			END

			-- Servico 08
			IF (LTRIM(RTRIM(isnull(@sv_desc_servico_08, ''))) != '') AND (isnull(@sv_valor_servico_08,0) != 0) BEGIN
				SELECT	@DescricaoTexto = LTRIM(RTRIM(isnull(@sv_desc_servico_08, '')))
				exec 	OnPlaceSANED_movimento..sp_atualiza_servico @DescricaoTexto

				SELECT	@svCodServico = OnPlaceSANED_movimento.dbo.fc_busca_servico(@DescricaoTexto)
				--isnull(@svCodServico,0)
				/*
				SELECT	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
				FROM	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
				where	seq_matricula = @sv_matricula

				set	@avAux = (@avAux + 1)

				-- Insere ACQ_MATRICULA_SERVICO_PARCELA
				INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
					seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
					cod_referencia, val_valor_parcela)
				values	(@sv_matricula, @seq_matricula_servico_parcela, @avAux,
					isnull(@svCodServico,0), @sv_roteiro, 'A', '01',
					CONVERT(char(7), @sv_ref_2via, 102), @sv_valor_servico_08)
				*/
				SELECT	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
				FROM	ONP_FATURA_SERVICO
				where	seq_fatura = @seq_fatura

				-- Insere ACQ_FATURA_SERVICO
				INSERT INTO ONP_FATURA_SERVICO
					(seq_fatura, seq_matricula_servico_parcela, seq_item_servico, seq_parcela,
					seq_servico_fatura, ind_documento_origem, val_valor_servico)
				values	(@seq_fatura, @seq_matricula_servico_parcela, @seq_item_servico, 1,
					isnull(@svCodServico,0), '01', @sv_valor_servico_08)
			END

			-- Servico 09
			IF (LTRIM(RTRIM(isnull(@sv_desc_servico_09, ''))) != '') AND (isnull(@sv_valor_servico_09,0) != 0) BEGIN
				SELECT	@DescricaoTexto = LTRIM(RTRIM(isnull(@sv_desc_servico_09, '')))
				exec 	OnPlaceSANED_movimento..sp_atualiza_servico @DescricaoTexto

				SELECT	@svCodServico = OnPlaceSANED_movimento.dbo.fc_busca_servico(@DescricaoTexto)
				--isnull(@svCodServico,0)
				/*
				SELECT	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
				FROM	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
				where	seq_matricula = @sv_matricula

				set	@avAux = (@avAux + 1)

				-- Insere ACQ_MATRICULA_SERVICO_PARCELA
				INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
					seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
					cod_referencia, val_valor_parcela)
				values	(@sv_matricula, @seq_matricula_servico_parcela, @avAux,
					isnull(@svCodServico,0), @sv_roteiro, 'A', '01',
					CONVERT(char(7), @sv_ref_2via, 102), @sv_valor_servico_09)
				*/
				SELECT	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
				FROM	ONP_FATURA_SERVICO
				where	seq_fatura = @seq_fatura

				-- Insere ONP_FATURA_SERVICO
				INSERT INTO ONP_FATURA_SERVICO
					(seq_fatura, seq_matricula_servico_parcela, seq_item_servico, seq_parcela,
					seq_servico_fatura, ind_documento_origem, val_valor_servico)
				values	(@seq_fatura, @seq_matricula_servico_parcela, @seq_item_servico, 1,
					isnull(@svCodServico,0), '01', @sv_valor_servico_09)
			END


			SELECT @svTotalEco = @sv_economia_res + @sv_economia_com + @sv_economia_ind + @sv_economia_pub + @sv_economia_soc + @sv_economia_ea
			IF @svTotalEco <= 0 BEGIN
				SELECT @svTotalEco = 1
			END
			SELECT @svConsumoEco = @sv_consumo / @svTotalEco

			-- Mista
			IF @sv_ind_mista > 0 BEGIN
				SELECT @mvCatAux = 5

				INSERT INTO ONP_FATURA_CATEGORIA
					(
						seq_fatura, 
						seq_categoria, 
						val_numero_economia
					)
				values	(
							@seq_fatura, 
							@mvCatAux, 
							@sv_economia_res
						)

				-- ?gua
				IF isnull(@sv_servico_ag,0) > 0 BEGIN
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
							@seq_fatura, 
							@mvCatAux, 
							1,
							@svTotalEco, 
							1, 
							'L',
							@sv_servico_ag, 
							@svConsumoEco 
							
						)
				END

				-- Esgoto
				IF isnull(@sv_servico_es,0) > 0 BEGIN
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
							@seq_fatura, 
							@mvCatAux, 
							2,
							@svTotalEco, 
							1, 
							'L',
							@sv_servico_es, 
							@svConsumoEco 
							@svTotalEco
						)
				END

			END

			-- Residencial
			else IF @sv_economia_res > 0 BEGIN
				SELECT @mvCatAux = 1

				INSERT INTO ONP_FATURA_CATEGORIA
					(seq_fatura, seq_categoria, val_numero_economia)
				values	(@seq_fatura, @mvCatAux, @sv_economia_res)

				-- ?gua
				IF isnull(@sv_servico_ag,0) > 0 BEGIN
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
							@seq_fatura, 
							@mvCatAux, 
							1,
							@sv_economia_res, 
							1, 
							'L',
							@sv_servico_ag, 
							@svConsumoEco 
							@sv_economia_res
						)
				END

				-- Esgoto
				IF isnull(@sv_servico_es,0) > 0 BEGIN
					INSERT INTO ONP_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 2,
						@sv_economia_res, 1, 'L',
						@sv_servico_es, @sv_servico_es, @svConsumoEco * @sv_economia_res)
				END

			END

			-- Comercial
			else IF @sv_economia_com > 0 BEGIN
				SELECT @mvCatAux = 2

				INSERT INTO ONP_FATURA_CATEGORIA
					(seq_fatura, seq_categoria, val_numero_economia)
				values	(@seq_fatura, @mvCatAux, @sv_economia_com)

				-- ?gua
				IF isnull(@sv_servico_ag,0) > 0 BEGIN
					INSERT INTO ONP_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 1,
						@sv_economia_com, 1, 'L',
						@sv_servico_ag, @sv_servico_ag, @svConsumoEco * @sv_economia_com)
				END

				-- Esgoto
				IF isnull(@sv_servico_es,0) > 0 BEGIN
					INSERT INTO ONP_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 2,
						@sv_economia_com, 1, 'L',
						@sv_servico_es, @sv_servico_es, @svConsumoEco * @sv_economia_com)
				END

			END

			-- Industrial
			else IF @sv_economia_ind > 0 BEGIN
				SELECT @mvCatAux = 3

				INSERT INTO ONP_FATURA_CATEGORIA
					(seq_fatura, seq_categoria, val_numero_economia)
				values	(@seq_fatura, @mvCatAux, @sv_economia_ind)

				-- ?gua
				IF isnull(@sv_servico_ag,0) > 0 BEGIN
					INSERT INTO ONP_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 1,
						@sv_economia_ind, 1, 'L',
						@sv_servico_ag, @sv_servico_ag, @svConsumoEco * @sv_economia_ind)
				END

				-- Esgoto
				IF isnull(@sv_servico_es,0) > 0 BEGIN
					INSERT INTO ONP_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 2,
						@sv_economia_ind, 1, 'L',
						@sv_servico_es, @sv_servico_es, @svConsumoEco * @sv_economia_ind)
				END

			END
			
			-- P?BLICA
			else IF @sv_economia_pub > 0 BEGIN
				SELECT @mvCatAux = 4

				INSERT INTO ONP_FATURA_CATEGORIA
					(seq_fatura, seq_categoria, val_numero_economia)
				values	(@seq_fatura, @mvCatAux, @sv_economia_pub)

				-- ?gua
				IF isnull(@sv_servico_ag,0) > 0 BEGIN
					INSERT INTO ONP_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 1,
						@sv_economia_pub, 1, 'L',
						@sv_servico_ag, @sv_servico_ag, @svConsumoEco * @sv_economia_pub)
				END

				-- Esgoto
				IF isnull(@sv_servico_es,0) > 0 BEGIN
					INSERT INTO ONP_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 2,
						@sv_economia_pub, 1, 'L',
						@sv_servico_es, @sv_servico_es, @svConsumoEco * @sv_economia_pub)
				END

			END			

			-- Social 
			else IF @sv_economia_soc  > 0 BEGIN
				SELECT @mvCatAux = 6

				INSERT INTO ONP_FATURA_CATEGORIA
					(seq_fatura, seq_categoria, val_numero_economia)
				values	(@seq_fatura, @mvCatAux, @sv_economia_soc)

				-- ?gua
				IF isnull(@sv_servico_ag,0) > 0 BEGIN
					INSERT INTO ONP_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 1,
						@sv_economia_soc, 1, 'L',
						@sv_servico_ag, @sv_servico_ag, @svConsumoEco * @sv_economia_soc)
				END

				-- Esgoto
				IF isnull(@sv_servico_es,0) > 0 BEGIN
					INSERT INTO ONP_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 2,
						@sv_economia_soc, 1, 'L',
						@sv_servico_es, @sv_servico_es, @svConsumoEco * @sv_economia_soc)
				END

			END			

			-- Entidade assistencial 
			else IF @sv_economia_ea  > 0 BEGIN
				SELECT @mvCatAux = 8

				INSERT INTO ONP_FATURA_CATEGORIA
					(seq_fatura, seq_categoria, val_numero_economia)
				values	(@seq_fatura, @mvCatAux, @sv_economia_ea)

				-- ?gua
				IF isnull(@sv_servico_ag,0) > 0 BEGIN
					INSERT INTO ONP_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 1,
						@sv_economia_ea, 1, 'L',
						@sv_servico_ag, @sv_servico_ag, @svConsumoEco * @sv_economia_ea)
				END

				-- Esgoto
				IF isnull(@sv_servico_es,0) > 0 BEGIN
					INSERT INTO ONP_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 2,
						@sv_economia_ea, 1, 'L',
						@sv_servico_es, @sv_servico_es, @svConsumoEco * @sv_economia_ea)
				END

			END			
			/*
			-- Atualiza Hist?rico de consumo
			-- Ref 01
			IF @sv_ref_01 > 0 BEGIN
				exec OnPlaceSANED_movimento.dbo.sp_atualiza_matricula_leitura @sv_matricula, @sv_ref_01, @sv_ref_01, @sv_hidrometro, @sv_grupo, @sv_consumo_01, 0
			END 

			-- Ref 02
			IF @sv_ref_02 > 0 BEGIN
				exec OnPlaceSANED_movimento.dbo.sp_atualiza_matricula_leitura @sv_matricula, @sv_ref_02, @sv_ref_02, @sv_hidrometro, @sv_grupo, @sv_consumo_02, 0
			END 

			-- Ref 03
			IF @sv_ref_03 > 0 BEGIN
				exec OnPlaceSANED_movimento.dbo.sp_atualiza_matricula_leitura @sv_matricula, @sv_ref_03, @sv_ref_03, @sv_hidrometro, @sv_grupo, @sv_consumo_03, 0
			END 

			-- Ref 04
			IF @sv_ref_04 > 0 BEGIN
				exec OnPlaceSANED_movimento.dbo.sp_atualiza_matricula_leitura @sv_matricula, @sv_ref_04, @sv_ref_04, @sv_hidrometro, @sv_grupo, @sv_consumo_04, 0
			END 

			-- Ref 05
			IF @sv_ref_05 > 0 BEGIN
				exec OnPlaceSANED_movimento.dbo.sp_atualiza_matricula_leitura @sv_matricula, @sv_ref_05, @sv_ref_05, @sv_hidrometro, @sv_grupo, @sv_consumo_05, 0
			END 

			-- Ref 06
			IF @sv_ref_06 > 0 BEGIN
				exec OnPlaceSANED_movimento.dbo.sp_atualiza_matricula_leitura @sv_matricula, @sv_ref_06, @sv_ref_06, @sv_hidrometro, @sv_grupo, @sv_consumo_06, 0
			END 
			*/
			-- Proximo
			FETCH 	NEXT 
			FROM 	CUR_SEGVIA
			INTO 	@sv_matricula , @sv_referencia , @sv_data_vencimento ,
				@sv_grupo ,
				@sv_roteiro ,
				@sv_ref_2via ,
				@sv_leitura_ant , @sv_leitura_atual ,
				@sv_data_leitura_anterior , @sv_data_leitura ,
				@sv_consumo , @sv_consumo_medio , @sv_categoria , 
				@sv_economia_res , @sv_economia_com , @sv_economia_ind ,
				@sv_economia_pub , @sv_economia_soc , @sv_economia_ea ,  
				@sv_ind_mista ,
				@sv_desc_servico_01 , @sv_valor_servico_01 ,
				@sv_desc_servico_02 , @sv_valor_servico_02 ,
				@sv_desc_servico_03 , @sv_valor_servico_03 ,
				@sv_desc_servico_04 , @sv_valor_servico_04 ,
				@sv_desc_servico_05 , @sv_valor_servico_05 ,
				@sv_desc_servico_06 , @sv_valor_servico_06 ,
				@sv_desc_servico_07 , @sv_valor_servico_07 , 	
				@sv_desc_servico_08 , @sv_valor_servico_08 ,
				@sv_desc_servico_09 , @sv_valor_servico_09 ,
				@sv_ref_01 , @sv_consumo_01 ,
				@sv_ref_02 , @sv_Consumo_02 ,
				@sv_ref_03 , @sv_Consumo_03 ,
				@sv_ref_04 , @sv_Consumo_04 ,
				@sv_ref_05 , @sv_Consumo_05 ,
				@sv_ref_06 , @sv_Consumo_06 ,
				@sv_total, 
				@sv_codigo_barras , @sv_codigo_barras_linha
		END

		-- Fecha o cursor Logradouro
		CLOSE CUR_SEGVIA
		DEALLOCATE CUR_SEGVIA
	END
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = getdate()
		Print ' -- Atualizou AS SEGUNDas-VIas ' + CONVERT(varchar, getdate(), 103) + ' ' + CONVERT(varchar, @hrInicio, 108) + ' Tempo: ' + CONVERT(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	

	-- ******************************
	-- Finaliza
	-- ---------------------------
	-- Atualiza a Fatura Cronograma para liberar a transmiss?o
	/*
	update	OnPlaceSANED_movimento..ACQ_GRUPO_FATURA_CRONOGRAMA
	set	ind_gerado = 'S'
	FROM	OnPlaceSANED_movimento..ACQ_GRUPO_REFERENCIA
	where	seq_grupo_fatura = @parGrupo
	AND	ACQ_GRUPO_FATURA_CRONOGRAMA.seq_roteiro = ACQ_GRUPO_REFERENCIA.seq_roteiro
	AND	ACQ_GRUPO_FATURA_CRONOGRAMA.cod_referencia = ACQ_GRUPO_REFERENCIA.cod_referencia
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicio 
		SELECT	@hrInicio = getdate()
		Print ' -- Atualizou o ACQ_GRUPO_FATURA_CRONOGRAMA ' + CONVERT(varchar, getdate(), 103) + ' ' + CONVERT(varchar, @hrInicio, 108) + ' Tempo: ' + CONVERT(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	
	*/
	IF @nTeste = 1 BEGIN
		SELECT	@hrAnterior = @hrInicioGeral
		SELECT	@hrInicio = getdate()
		Print ' -- FIM ' + CONVERT(varchar, getdate(), 103) + ' ' + CONVERT(varchar, @hrInicio, 108) + ' Tempo: ' + CONVERT(varchar, datedIFf(s, @hrAnterior, @hrInicio )) + ' segundos.'
	END	
END

GO

-----------------------------------------------------------FIM------------------------------------------------------------------


