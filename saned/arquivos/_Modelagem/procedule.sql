
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

	select 	@parReferencia = max(cg_referencia)
	from	OnPlaceSaned..carga
	where	cg_grupo = @parGrupo
	and	cg_rota between @parRoteiroIni and @parRoteiroFim

	-- ******************************
	-- APAGA TABELAS
	exec OnPlaceSaned_Movimento..sp_desfaz_carga_movimento @parGrupo
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Processou sp_desfaz_carga_movimento ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ******************************
	-- Atualiza as Agentes
	exec OnPlaceSaned_Movimento..sp_atualiza_agentes @parReferencia, @parGrupo
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Processou sp_atualiza_agentes ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ******************************
	-- Atualiza as Ocorrência
	exec OnPlaceSaned_Movimento..sp_atualiza_anormalidade @parGrupo, @parReferencia
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Processou sp_atualiza_anormalidade ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

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

	insert into OnPlaceSANED_movimento..ACQ_ZONA_ABASTECIMENTO 
			(seq_zona_abastecimento, des_zona_abastecimento)
	select 	distinct rt_grupo, 'Zona Abastecimento Grupo ' + convert(varchar, rt_grupo)
	from 	OnPlaceSANED..roteiros
	where	rt_grupo = @parGrupo
	and	rt_grupo not in (select seq_zona_abastecimento from OnPlaceSANED_movimento..ACQ_ZONA_ABASTECIMENTO)
	and	rt_rota between @parRoteiroIni and @parRoteiroFim
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_ZONA_ABASTECIMENTO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	
 
	-- 1 - pH
	INSERT INTO OnPlaceSANED_movimento..ACQ_QUALIDADE_AGUA
		(dat_referencia, seq_zona_abastecimento, 
		seq_parametro, des_parametro, 
		val_previstas, val_realizadas, val_fora_limite, val_media)
	select 	qa_referencia, qa_grupo,
		1, 'pH',
		isnull(qa_pH_Amostras,150), isnull(qa_pH_Amostras,150), isnull(qa_pH_Nao_Conformes, 150), convert (numeric (5,2), replace(qa_ph, ',', '.'))
	from 	OnPlaceSANED..qualidades_agua
	where	qa_grupo = @parGrupo

	-- 2 - Cloro Residual
	INSERT INTO OnPlaceSANED_movimento..ACQ_QUALIDADE_AGUA
		(dat_referencia, seq_zona_abastecimento, 
		seq_parametro, des_parametro, 
		val_previstas, val_realizadas, val_fora_limite, val_media)
	select 	qa_referencia, qa_grupo,
		2, 'Cloro Residual',
		isnull(qa_cloro_Amostras,150), isnull(qa_cloro_Amostras,150), isnull(qa_cloro_Nao_Conformes,0), convert (numeric (5,2), replace(qa_cloro, ',', '.'))
	from 	OnPlaceSANED..qualidades_agua
	where	qa_grupo = @parGrupo

	-- 3 - Cor Aparente
	INSERT INTO OnPlaceSANED_movimento..ACQ_QUALIDADE_AGUA
		(dat_referencia, seq_zona_abastecimento, 
		seq_parametro, des_parametro, 
		val_previstas, val_realizadas, val_fora_limite, val_media)
	select 	qa_referencia, qa_grupo,
		3, 'Cor Aparente',
		isnull(qa_cor_Amostras, 150), isnull(qa_cor_Amostras, 150), isnull(qa_cor_Nao_Conformes, 0), convert (numeric (5,2), replace(qa_cor, ',', '.'))
	from 	OnPlaceSANED..qualidades_agua
	where	qa_grupo = @parGrupo

	-- 4 - Turbidez
	INSERT INTO OnPlaceSANED_movimento..ACQ_QUALIDADE_AGUA
		(dat_referencia, seq_zona_abastecimento, 
		seq_parametro, des_parametro, 
		val_previstas, val_realizadas, val_fora_limite, val_media)
	select 	qa_referencia, qa_grupo,
		4, 'Turbidez',
		isnull(qa_turbidez_Amostras, 150), isnull(qa_turbidez_Amostras, 150), isnull(qa_turbidez_Nao_Conformes, 0), convert (numeric (5,2), replace(qa_turbidez, ',', '.'))
	from 	OnPlaceSANED..qualidades_agua
	where	qa_grupo = @parGrupo

	-- 5 - Fluoreto
	INSERT INTO OnPlaceSANED_movimento..ACQ_QUALIDADE_AGUA
		(dat_referencia, seq_zona_abastecimento, 
		seq_parametro, des_parametro, 
		val_previstas, val_realizadas, val_fora_limite, val_media)
	select 	qa_referencia, qa_grupo,
		5, 'Fluoreto',
		isnull(qa_fluoreto_Amostras, 150),  isnull(qa_fluoreto_Amostras, 150),  isnull(qa_fluoreto_Nao_Conformes, 0), convert (numeric (5,2), replace(qa_fluoreto, ',', '.'))
	from 	OnPlaceSANED..qualidades_agua
	where	qa_grupo = @parGrupo

	-- 6 - Colif. Totais
	INSERT INTO OnPlaceSANED_movimento..ACQ_QUALIDADE_AGUA
		(dat_referencia, seq_zona_abastecimento, 
		seq_parametro, des_parametro, 
		val_previstas, val_realizadas, val_fora_limite, val_media)
	select 	qa_referencia, qa_grupo,
		6, 'Colif. Totais',
		isnull(qa_coliformes_Totais_Amostras, 150), isnull(qa_coliformes_Totais_Amostras, 150), isnull(qa_coliformes_Totais_Nao_Conformes, 0), convert (numeric (5,2), replace(qa_coliformes_totais, ',', '.'))		
	from 	OnPlaceSANED..qualidades_agua
	where	qa_grupo = @parGrupo

	-- 7 - E. Coli
	INSERT INTO OnPlaceSANED_movimento..ACQ_QUALIDADE_AGUA
		(dat_referencia, seq_zona_abastecimento, 
		seq_parametro, des_parametro, 
		val_previstas, val_realizadas, val_fora_limite, val_media)
	select 	qa_referencia, qa_grupo,
		7, 'E. Coli',
		isnull(qa_coliformes_Termotolerantes_Amostras, 150), isnull(qa_coliformes_Termotolerantes_Amostras, 150), isnull(qa_coliformes_Termotolerantes_Nao_Conformes, 0), convert (numeric (5,2), replace(qa_coliformes_termotolerantes, ',', '.'))		
	from 	OnPlaceSANED..qualidades_agua
	where	qa_grupo = @parGrupo
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_QUALIDADE_AGUA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	
 

	-- ******************************
	-- Tabelas do GRUPO

	-- ---------------------------
	-- Atualiza dados do Grupo Leitura
	insert 	into OnPlaceSANED_movimento..ACQ_GRUPO_FATURA		
		(seq_grupo_fatura, des_grupo_fatura, 
		val_periodicidade_leitura, val_periodicidade_fatura, ind_tipo_vencimento)
	values	(@parGrupo, convert(varchar, @parGrupo), 
		30, 30, 'D')
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_GRUPO_FATURA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Atualiza dados do Roteiro
	insert 	into OnPlaceSANED_movimento..ACQ_ROTEIRO		
		(seq_roteiro, 
		seq_grupo_fatura, ind_criterio_roteiro)
	select 	convert(numeric, '1'+OnPlaceSANED.dbo.fc_completa_zeros(rt_grupo, 3)+OnPlaceSANED.dbo.fc_completa_zeros(rt_rota,3)), 
		rt_grupo, 'C' 
	from 	OnPlaceSANED..roteiros
	where	rt_grupo = @parGrupo
	and	rt_referencia = @parReferencia
	and	rt_rota between @parRoteiroIni and @parRoteiroFim
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_ROTEIRO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Atualiza dados do Grupo Refer?ncia
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
		Print ' -- Atualizou as ACQ_GRUPO_REFERENCIA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Atualiza dados do Grupo Cronograma
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
		Print ' -- Atualizou as ACQ_GRUPO_FATURA_CRONOGRAMA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- -------------------------
	-- Insere os dados de tarifa

	
	-- Insere tarifa de ?gua
	-- select * from OnPlaceSANED_movimento..ACQ_TAXA_TARIFA
	INSERT INTO OnPlaceSANED_movimento..ACQ_TAXA_TARIFA
		(seq_categoria, seq_taxa, seq_taxa_tarifa,
		seq_taxa_base, dat_inicio, 
		ind_tipo_taxa, ind_escalonada, ind_dias_consumo, 
		ind_minimo, val_valor_tarifa, val_percentual)
	select  distinct  
		tr_categoria, 1, convert(numeric(9), convert(char(6), tr_data_inicial, 112) + OnPlaceSANED.dbo.fc_completa_zeros(tr_grupo, 3)),
		 null, tr_data_inicial, 
		'C', 'S', 'N', 
		'S', null, null
	from 	 OnPlaceSANED..tarifas
	where	 tr_referencia = @parReferencia
	and	 tr_grupo = @parGrupo
	and      tr_categoria not in 
				 (select seq_categoria 
				  from 	OnPlaceSANED_movimento..ACQ_TAXA_TARIFA
				  where seq_taxa = 1
				  and 	seq_taxa_tarifa = convert(numeric(9), convert(char(6), tr_data_inicial, 112) + OnPlaceSANED.dbo.fc_completa_zeros(tr_grupo, 3)))
	and	0 = 
		(select count(*)
		 from 	OnPlaceSANED_movimento..ACQ_TAXA_TARIFA 
		 where 	seq_categoria = tr_categoria
		 and	seq_taxa = 1
		 and 	seq_taxa_tarifa = convert(numeric(9), convert(char(6), tr_data_inicial, 112) + OnPlaceSANED.dbo.fc_completa_zeros(tr_grupo, 3)))

	-- Insere tarifa de ?gua - Limite
	insert into OnPlaceSANED_movimento..ACQ_TAXA_TARIFA_FAIXA
			(seq_categoria,  seq_taxa,  seq_taxa_tarifa_faixa, 
			seq_taxa_tarifa,  val_limite_consumo, val_valor_tarifa) 
	select  distinct 
		tr_categoria as seq_categoria, 
		1 as seq_taxa, 
		tr_sequencia as seq_taxa_tarifa_faixa,
		convert(numeric(9), convert(char(6), tr_data_inicial, 112) + OnPlaceSANED.dbo.fc_completa_zeros(tr_grupo, 3)) as seq_taxa_tarifa, 
		case when tr_faixa_final >= 999999 then 9999999 else tr_faixa_final end as val_limite_consumo,
		tr_agua as val_valor_tarifa
	from 	OnPlaceSANED..tarifas t1
	where	tr_grupo = @parGrupo
	and 	tr_referencia = @parReferencia 
	and		0 =  	(select count(*)
				 from 	OnPlaceSANED_movimento..ACQ_TAXA_TARIFA_FAIXA 
				 where 	seq_categoria = tr_categoria
				 and	seq_taxa = 1
				 and	seq_taxa_tarifa_faixa = tr_sequencia
				 and 	seq_taxa_tarifa = convert(numeric(9), convert(char(6), tr_data_inicial, 112) + OnPlaceSANED.dbo.fc_completa_zeros(tr_grupo, 3)))


	-- Insere tarifa de Esgoto
	-- alterado de percentual p/ categoria. 
	INSERT	INTO OnPlaceSANED_movimento..ACQ_TAXA_TARIFA
			(seq_categoria, seq_taxa, seq_taxa_tarifa,
			seq_taxa_base, dat_inicio, 
			ind_tipo_taxa, ind_escalonada, ind_dias_consumo, 
			ind_minimo, val_valor_tarifa, val_percentual)
	select	distinct 
		tr_categoria, 2, convert(numeric(9), convert(char(6), tr_data_inicial, 112) + OnPlaceSANED.dbo.fc_completa_zeros(tr_grupo, 3)),
		 null, tr_data_inicial, 
		'C', 'S', 'N', 
		'S', null, null
	from 	OnPlaceSANED..tarifas
	where	tr_grupo = @parGrupo
	and 	tr_referencia = @parReferencia
	and	tr_categoria not in 
				(select seq_categoria
				 from 	 OnPlaceSANED_movimento..ACQ_TAXA_TARIFA
				 where 	 seq_taxa = 2
				 and 	 seq_taxa_tarifa = convert(numeric(9), convert(char(6),  tr_data_inicial, 112) + OnPlaceSANED.dbo.fc_completa_zeros(tr_grupo, 3)))
	and	0 =  (  select count(*)
			from 	OnPlaceSANED_movimento..ACQ_TAXA_TARIFA 
			where 	seq_categoria = tr_categoria
			and	seq_taxa = 2
			and 	seq_taxa_tarifa = convert(numeric(9), convert(char(6), tr_data_inicial, 112) + OnPlaceSANED.dbo.fc_completa_zeros(tr_grupo, 3)))

	-- Insere tarifa de Esgoto - Limite
	insert into OnPlaceSANED_movimento..ACQ_TAXA_TARIFA_FAIXA
			(seq_categoria,  seq_taxa,  seq_taxa_tarifa_faixa, 
			 seq_taxa_tarifa,  val_limite_consumo, val_valor_tarifa) 
	select  distinct 
			tr_categoria as seq_categoria, 
			2 as seq_taxa, 
			tr_sequencia as seq_taxa_tarifa_faixa,
			convert(numeric(9), convert(char(6), tr_data_inicial, 112) + OnPlaceSANED.dbo.fc_completa_zeros(tr_grupo, 3)) as seq_taxa_tarifa, 
			case when tr_faixa_final >= 999999 then 9999999 else tr_faixa_final end as val_limite_consumo,
			tr_esgoto as val_valor_tarifa
	from 	OnPlaceSANED..tarifas t1
	where	tr_grupo = @parGrupo
	and 	tr_referencia =  @parReferencia
	and	0 =  	(select count(*)
			 from 	OnPlaceSANED_movimento..ACQ_TAXA_TARIFA_FAIXA 
			 where 	seq_categoria = tr_categoria
			 and	seq_taxa = 2
			 and	seq_taxa_tarifa_faixa = tr_sequencia
			 and 	seq_taxa_tarifa = convert(numeric(9), convert(char(6), tr_data_inicial, 112) + OnPlaceSANED.dbo.fc_completa_zeros(tr_grupo, 3)))
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_TAXA_TARIFA_FAIXA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	


	-- ---------------------------
	-- Insere os dados de Mensagem - Social
	delete 	from OnPlaceSANED_movimento..ACQ_MENSAGEM_MOVIMENTO
	where	seq_mensagem_movimento = 0

	INSERT INTO OnPlaceSANED_movimento..ACQ_MENSAGEM_MOVIMENTO
		(seq_mensagem_movimento, 
		seq_tipo_documento, des_mensagem_movimento, 
		dat_inicio, dat_final)
	select	0,  
		1, convert(char(62), isnull(mg_descricao1, '') ) + convert(char(62), isnull(mg_descricao2, '') ) + convert(char(62), isnull(mg_descricao3, '') ), 
		@parReferencia-100, 
		@parReferencia+100 
	from 	OnPlaceSaned..mensagens
	where	mg_grupo = @parGrupo


	-- ---------------------------
	-- Insere os dados de Mensagem - Indiviual
	INSERT INTO OnPlaceSANED_movimento..ACQ_MENSAGEM_MOVIMENTO
  		(seq_matricula, seq_mensagem_movimento, seq_grupo_fatura, 
		seq_tipo_documento, des_mensagem_movimento, 
		dat_inicio, dat_final)
	select	cg_matricula, cg_matricula,  cg_grupo,
		1, --convert(char(62), isnull(cg_mensagem1,'') ) + convert(char(62), isnull(cg_mensagem2,'')), 
		(case when len(cg_mensagem1) > 0 then convert(char(62), cg_mensagem1) + isnull(cg_mensagem2,'') else isnull(cg_mensagem2,'') end),
		@parReferencia-100, 
		@parReferencia+100
	from 	OnPlaceSANED..carga
	where	cg_grupo = @parGrupo
	and	cg_referencia = @parReferencia	
	and	cg_rota between @parRoteiroIni and @parRoteiroFim
	and	ltrim(rtrim(isnull(cg_mensagem1,'') + ' ' + isnull(cg_mensagem2,''))) != ''
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_MENSAGEM_MOVIMENTO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	


	declare @DescricaoTexto	varchar(100), @Codigo integer

	-- *******************************
	-- Cursor para atualizar LOGRADOURO
	
	-- Qtde Registros
	select  @nQtdeReg = count(distinct ltrim(rtrim(cg_endereco)))
	from    OnPlaceSANED..carga
	where	cg_grupo = @parGrupo
	and	cg_referencia = @parReferencia	
	and	cg_rota between @parRoteiroIni and @parRoteiroFim
	and	ltrim(rtrim(cg_endereco)) not in 
		(select des_logradouro from OnPlaceSANED_movimento..ACQ_LOGRADOURO) 

	-- Verifica quantidade
	if @nQtdeReg > 0 begin
		declare CUR_LOGRADOURO CURSOR read_only for
		select  distinct ltrim(rtrim(cg_endereco)) as Logradouro
		from    OnPlaceSANED..carga
		where	cg_grupo = @parGrupo
		and	cg_referencia = @parReferencia	
		and	cg_rota between @parRoteiroIni and @parRoteiroFim
		and	ltrim(rtrim(cg_endereco)) not in 
			(select des_logradouro from OnPlaceSANED_movimento..ACQ_LOGRADOURO) 

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


	end
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_LOGRADOURO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	


	-- ******************************
	-- Cursor para atualizar SERVICO
	
	-- Qtde Registros
	select  @nQtdeReg = count(*)
	from    OnPlaceSANED..servicos
	where   ltrim(rtrim(sr_descricao)) not in 
		(select des_servico_fatura from OnPlaceSANED_movimento..ACQ_SERVICO_FATURA)

	-- Verifica se processa
	if @nQtdeReg > 0 begin
		declare CUR_SERVICO CURSOR read_only for
		select  distinct ltrim(rtrim(sr_descricao)) as Servico
		from    OnPlaceSANED..servicos
		where   ltrim(rtrim(sr_descricao)) not in 
				(select des_servico_fatura from OnPlaceSANED_movimento..ACQ_SERVICO_FATURA) 

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
	
		-- Fecha o cursor servi?o
		CLOSE CUR_SERVICO
		DEALLOCATE CUR_SERVICO

		-- Inclui servi?o de notifica??o
		exec OnPlaceSANED_movimento.dbo.sp_atualiza_servico 'NOTIFICACAO DE DEBITO'
	
	end
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_SERVICO_FATURA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ******************************
	-- Atualiza Movimento

	-- ---------------------------
	-- Insere dados Pessoa
	INSERT INTO OnPlaceSANED_movimento..ACQ_PESSOA
			(seq_pessoa, des_nome, cod_cpf_cnpj, des_cidade, des_uf, 
			des_logradouro, des_numero, des_complemento, des_bairro, des_cep)
	select 	cg_matricula, cg_nome, Null , 'DIADEMA', 'SP',
			cg_endereco, cg_num_imovel, cg_complemento, Null, Null
	from 	OnPlaceSANED..carga
	where	cg_grupo = @parGrupo
	and	cg_referencia =  @parReferencia
	and	cg_rota between @parRoteiroIni and @parRoteiroFim
	and 	cg_matricula not in ( select seq_pessoa from 
				      OnPlaceSANED_movimento..ACQ_PESSOA)
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_PESSOA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Insere dados Matricula
	INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA
		(seq_matricula,seq_matricula_principal, seq_pessoa_proprietario, cod_uf, seq_localidade, 
		seq_rota, seq_leitura, des_inscricao_imobiliaria, des_registro_imovel, 
		seq_setor, seq_logradouro, val_numero_imovel, des_complemento, 
		ind_entrega_especial, ind_agrupa_fatura, val_dia_vencimento)
	select	cg_matricula, case when cg_matricula_pai = 0 then null else cg_matricula_pai end, cg_matricula, 'SP', 1,
		cg_grupo, cg_sequencia, OnPlaceSaned.dbo.FC_COMPLETA_ZEROS(cg_setor, 3) + cg_inscricao, '', 
		cg_setor, dbo.fc_busca_logradouro(ltrim(rtrim(cg_endereco))), cg_num_imovel, cg_complemento, 
		case 	when (isnull(cg_codigo_banco,0) > 0) and (cg_entrega_alternativa <> '') then '5'
			when (isnull(cg_codigo_banco,0) > 0) and (cg_entrega_alternativa <> '') then '1'
			when (isnull(cg_codigo_banco,0) = 0) and (cg_entrega_alternativa <> '') then '2'
		else '0' end, 
		case when cg_ident_consumidor in (1, 2, 7, 9) then 'N' else 'S' end,
		datepart(d, cg_data_vencto)
	from 	OnPlaceSANED..carga
	where	cg_grupo =  @parGrupo
	and	cg_referencia = @parReferencia
	and	cg_rota between @parRoteiroIni and @parRoteiroFim
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_MATRICULA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Insere dados Mensagem Individual
	INSERT INTO OnPlaceSANED_movimento..ACQ_MENSAGEM_MOVIMENTO
			(seq_matricula, seq_mensagem_movimento, 
			 seq_tipo_documento, des_mensagem_movimento, 
			 dat_inicio, dat_final)
	select 	cg_matricula, cg_matricula, 
		1, isnull(cg_mensagem1,'')+ isnull(cg_mensagem2,''), 
		convert(datetime, convert(char(9), getdate(),112)), (convert(datetime, convert(char(9), getdate(),112))+15)
	from 	OnPlaceSANED..carga
	where	cg_grupo = @parGrupo
	and	cg_referencia = @parReferencia
	and	cg_rota between @parRoteiroIni and @parRoteiroFim
	and	ltrim(rtrim(isnull(cg_mensagem1,'') + isnull(cg_mensagem2,''))) != ''
	and  	cg_matricula not in 
		(select seq_matricula  
		from	OnPlaceSANED_movimento..ACQ_MENSAGEM_MOVIMENTO)
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_MENSAGEM_MOVIMENTO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Insere dados Matricula Leituras - Histórico de consumo - Leituras
	-- Enviado na data de leitura a referencia devido existirem datas repetidas para referências diversas
	-- Como neste caso precisamos apenas do cosnumo
	INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_LEITURAS
			(seq_matricula, cod_referencia, seq_grupo_fatura, 
			 dat_leitura, cod_hidrometro, 
			val_consumo_real, val_leitura_real)
	select 	hc_matricula, convert(char(7), hc_ref_historico, 102), cg_grupo,
		hc_ref_historico, cg_numero_hd, 
		hc_consumo, hc_leitura
	from 	OnPlaceSANED..historico_consumo, OnPlaceSANED..carga
	where	cg_matricula = hc_matricula
	and 	cg_grupo = hc_grupo
	and	cg_referencia = hc_referencia
	and	cg_grupo = @parGrupo
	and	cg_referencia = @parReferencia	
	and	cg_rota between @parRoteiroIni and @parRoteiroFim
	and	0 = 	(select count(*) 
			from 	OnPlaceSANED_movimento..ACQ_MATRICULA_LEITURAS
			where	cod_referencia = convert(char(7), hc_ref_historico, 102)
			and	seq_matricula  = hc_matricula)
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_MATRICULA_LEITURAS ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Insere dados Matricula Leituras - Histórico de consumo - Ocorrências

	INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_OCORRENCIA
			(seq_roteiro, 
			cod_referencia, 
			seq_matricula, cod_ocorrencia)
	select 	convert(numeric, '1'+OnPlaceSANED.dbo.fc_completa_zeros(cg_grupo, 3)+OnPlaceSANED.dbo.fc_completa_zeros(cg_rota,3)), 
		convert(char(7), hc_ref_historico, 102), 
		hc_matricula, hc_ocorrencia_leitura
	from 	OnPlaceSANED..historico_consumo, OnPlaceSANED..carga
	where	cg_matricula = hc_matricula
	and 	cg_grupo = hc_grupo
	and	cg_referencia = hc_referencia
	and	cg_grupo = @parGrupo
	and	cg_referencia = @parReferencia	
	and	cg_rota between @parRoteiroIni and @parRoteiroFim
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_MOVIMENTO_OCORRENCIA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Insere dados Matricula Entrega
	INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_ENTREGA
		(seq_matricula, seq_pessoa_entrega,
		des_logradouro, des_numero, des_complemento, des_bairro, des_cidade, des_uf, des_cep)
	select	 cg_matricula, cg_matricula, 
		cg_entrega_alternativa, Null, Null, Null, 'DIADEMA', 'SP', Null
	from 	OnPlaceSANED..carga
	where	cg_grupo = @parGrupo
	and	cg_referencia = @parReferencia
	and 	isnull(cg_entrega_alternativa,'') <> ''
	and	cg_rota between @parRoteiroIni and @parRoteiroFim
	and	cg_matricula not in ( select seq_matricula from 
			      OnPlaceSANED_movimento..ACQ_MATRICULA_ENTREGA)
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_MATRICULA_ENTREGA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Insere dados Matricula D?bito Autom?tico
	INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_DEB_AUTOMATICO
		(seq_matricula, seq_matricula_deb_automatico, 
		cod_banco, cod_banco_agencia, des_conta_corrente,
		dat_opcao_debito, seq_convenio)
	select	cg_matricula, 1, 
		cg_codigo_banco , isnull(cg_agencia,0), 'DEBITO AUT',
		(cg_referencia - 500), cg_codigo_banco
	from 	OnPlaceSANED..carga
	where	cg_grupo = @parGrupo
	and	cg_referencia = @parReferencia
	and	isnull(cg_codigo_banco,0) > 0
	and	cg_rota between @parRoteiroIni and @parRoteiroFim
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_MATRICULA_DEB_AUTOMATICO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Insere dados Matricula Liga??o
	INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_LIGACAO
		(seq_matricula, seq_zona_abastecimento, seq_padrao_imovel, seq_situacao_imovel, 
		seq_tipo_despejo_esgoto, seq_tipo_esgotamento, seq_material_cavalete, seq_diametro_ligacao, 
		ind_reservatorio_superior, ind_reservatorio_inferior, ind_piscina, ind_calcada, 
		ind_jardim, ind_fonte_alternativa, seq_tipo_ligacao, seq_utilizacao_ligacao,
		ind_consumo_estimado, val_consumo_estimado, ind_protecao_hidrometro, seq_localizacao_hidrometro)
	select	cg_matricula, cg_grupo, 6, 0, 
		0, 1, 1, 1, 
		'S', 'S', 'N', 'S', 
		'S', case when cg_ident_consumidor = 6 then 4 else 0 end, 1, cg_categoria, 
		case 	when ltrim(rtrim(isnull(cg_numero_hd,''))) = '' 
			then 'S' 
			else 'N' end, 0,  1, 5
	from 	OnPlaceSANED..carga
	where	cg_grupo = @parGrupo
	and	cg_referencia = @parReferencia
	and	cg_rota between @parRoteiroIni and @parRoteiroFim
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_MATRICULA_LIGACAO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- --------------------------
	-- Insere dados dos Hidrometros
	INSERT INTO OnPlaceSANED_movimento..ACQ_HIDROMETRO
		(cod_hidrometro, val_numero_digitos, 
		cod_modelo_hidrometro, cod_marca, seq_tamanho_hidrometro, ind_tipo_hidrometro, 
		seq_diametro_ligacao, seq_capacidade_hidrometro, ind_status, seq_composicao_numero_medidor, 
		ind_transmissao)
	select	cg_numero_hd, max(isnull(cg_capacidade_hidrometro,5)), 
		9, 9, 1, 'C',
		1, 1, 'U', 1,
		2 
	from	OnPlaceSANED..carga
	where	cg_grupo = @parGrupo
	and	cg_referencia = @parReferencia
	and	cg_rota between @parRoteiroIni and @parRoteiroFim
	and	ltrim(rtrim(isnull(cg_numero_hd,''))) != ''
	and	cg_numero_hd not in (select cod_hidrometro from OnPlaceSANED_movimento..ACQ_HIDROMETRO)
	group	by cg_numero_hd
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_HIDROMETRO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Insere dados Matricula Hidrometro
	-- Inclui os dados dos hidr?metros - troca

	INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_HIDROMETRO
		(seq_matricula, seq_matricula_hidrometro,
		 cod_hidrometro,  
		 dat_instalacao, val_leitura_instalacao,
		 dat_encerramento, dat_retirada, val_leitura_encerramento,
		 ind_motivo_retirada, 
		 ind_estado_retirada, val_leitura_retirada)
	select 	cg_matricula, 1, cg_numero_hd,  
		cg_referencia - 500, cg_leitura_inicial,
		cg_data_instalacao_hd, cg_data_instalacao_hd, Null,  
		 'D', 'C', 0
	from	OnPlaceSANED..carga
	where	cg_grupo = @parGrupo
	and	cg_referencia = @parReferencia
	and	cg_rota between @parRoteiroIni and @parRoteiroFim
	and	ltrim(rtrim(isnull(cg_numero_hd,''))) != ''
	and	cg_flag_troca = 'S'
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_MATRICULA_HIDROMETRO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- Inclui os dados dos hidr?metros - atuais
	INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_HIDROMETRO
		(seq_matricula, seq_matricula_hidrometro,
		cod_hidrometro, dat_instalacao, 
		val_leitura_instalacao)
	select 	distinct cg_matricula, 1 + (case when cg_flag_troca = 'S' then 1 else 0 end), 
		cg_numero_hd, cg_data_instalacao_hd, 
		case when cg_flag_troca = 'S' then cg_leitura_inicial else 0 end
	from	OnPlaceSANED..carga
	where	cg_grupo = @parGrupo
	and	cg_referencia = @parReferencia
	and	cg_rota between @parRoteiroIni and @parRoteiroFim
	and	ltrim(rtrim(isnull(cg_numero_hd,''))) != ''
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_MATRICULA_HIDROMETRO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Insere Movimento - CARGA
	INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO
		(seq_matricula, ind_situacao_movimento, 
		seq_roteiro, cod_referencia,
		cod_agente, cod_hidrometro, val_numero_digitos, 
		dat_vencimento, val_consumo_medio,
		cod_banco, cod_banco_agencia, ind_entrega_especial, 
		dat_leitura_anterior, 
		dat_leitura_proxima,
		val_leitura_anterior, 
		dat_troca, 
		val_consumo_troca,
		val_quantidade_pendente) 
	select	cg_matricula, 'P', 
		convert(numeric, '1' + OnPlaceSANED.dbo.fc_completa_zeros(cg_grupo, 3)+OnPlaceSANED.dbo.fc_completa_zeros(cg_rota,3)), 	convert(char(7), cg_referencia, 102),
		rt_agente, cg_numero_hd, cg_capacidade_hidrometro, 
		cg_data_vencto, cg_consumo_medio,
		cg_codigo_banco,cg_agencia, 
		CASE 	when (isnull(cg_entrega_alternativa,'') <> '') and (cg_codigo_banco > 0) THEN '5' 
			when (isnull(cg_entrega_alternativa,'') <> '') THEN '2' 
			when (cg_codigo_banco > 0) THEN '1'
		ELSE '0' 
		end ,
		convert( datetime, convert(char(8), isnull(cg_data_leit_ant, cg_referencia), 112) ), 
		cg_proxima_leitura,
		case when isnull(cg_flag_troca, 'N') = 'S' then isnull(cg_leitura_inicial, 0) else isnull(cg_leitura_ant, 0) end, 
		case when isnull(cg_flag_troca, 'N') = 'S' then isnull(cg_data_instalacao_hd, isnull(cg_data_leit_ant, cg_referencia)) else null end, 
		case when isnull(cg_flag_troca, 'N') = 'S' then cg_consumo_anterior else null end,
		cg_qtde_debito_ant
	from	OnPlaceSANED..carga, OnPlaceSANED..roteiros
	where	cg_grupo = rt_grupo
	and	cg_rota = rt_rota
	and	cg_referencia = rt_referencia
	and	cg_grupo = @parGrupo
	and	cg_rota between @parRoteiroIni and @parRoteiroFim
	and	cg_referencia = @parReferencia
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_MOVIMENTO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- -----------------------------
	-- Insere Matricula DIADEMA	
	INSERT INTO OnPlaceSaned_Movimento..ACQ_MATRICULA_DIADEMA
		(seq_matricula, val_fraudes, 
		ind_corta_ligacao, ind_retencao_impostos, 
		ind_bloqueio, val_dias_bloqueio_anterior, val_dias_bloqueio_atual, 
		ind_cachorro, ind_tipo_consumidor, ind_calcula_fatura, 
		ind_emite_fatura, 
		seq_desconto, des_mensagem_1, des_mensagem_2, dat_bloqueio)
	select	cg_matricula, cg_qtde_registros_fraude, 
		cg_flag_cortar, cg_flag_calcula_imposto, 
		case when isnull(cg_bloqueado,'L') in ('L', '') then 'N' else 'S' end, isnull(cg_dias_bloqueio_tarifa_ant,0), isnull(cg_dias_bloqueio_tarifa_atual,0),
		cg_cachorro, cg_ident_consumidor, cg_flag_calcula_conta, 
		case 	when (isnull(cg_bloqueado,'L') not in ('L', '')) and (cg_ident_consumidor = 9) then 'N'
			else cg_flag_emite_conta
		end, 
		cg_desconto, cg_mensagem1, cg_mensagem2, cg_data_bloqueio
	from	OnPlaceSaned..carga
	where	cg_grupo = @parGrupo
	and	cg_referencia = @parReferencia
	and	cg_rota between @parRoteiroIni and @parRoteiroFim
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as ACQ_MATRICULA_DIADEMA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- -----------------------------
	-- Insere Movimento Categoria - CARGA
	begin
		declare @mvMatricula 	int, 
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

		declare CUR_CATEGORIA_MOV CURSOR read_only for
		select	cg_matricula, 
			convert(numeric, '1' + OnPlaceSANED.dbo.fc_completa_zeros(cg_grupo, 3) + OnPlaceSANED.dbo.fc_completa_zeros(cg_rota,3)) as roteiro, 
			cg_referencia, 
			cg_categoria, 
			cg_economia_res, 
			cg_economia_com, 
			cg_economia_ind, 
			cg_economia_pub, 
			cg_economia_soc, 
			cg_economia_ea, 
			case 	when isnull(cg_bloqueado, 'L') not in ('L', '') then
					case 	when cg_natureza_ligacao in (1, 2) then 3 
						else 4 
					end
				when cg_natureza_ligacao in (1, 2) then 1 
				else 4 
			end as ct_lig_agua, 
			case 	when isnull(cg_bloqueado, 'L') not in ('L', '') then
					case 	when cg_natureza_ligacao in (2, 3) then 3 
						else 4 
					end
				when cg_natureza_ligacao in (2, 3) then 1 
				else 4 
			end as ct_lig_esg
		from	OnPlaceSANED..carga
		left	outer join OnPlaceSANED_movimento..ACQ_CATEGORIA
		on	cg_categoria = seq_categoria
		where	cg_grupo = @parGrupo
		and	cg_referencia = @parReferencia
		and	cg_rota between @parRoteiroIni and @parRoteiroFim

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
			declare @mvNumEco int
			-- Residencial
			if @mvEcoRes > 0 begin
				select @mvCatAux = 1
				set @mvNumEco = @mvEcoRes

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

				-- Movimento
				INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_CATEGORIA
					(seq_matricula, seq_roteiro, cod_referencia,
					 seq_categoria, val_numero_economia)
				values	(@mvMatricula, @mvRoteiro, convert( char(7), @mvReferencia, 102 ),
					@mvCatAux, @mvNumEco)

				-- Movimento Taxa de Agua
				INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, convert( char(7), @mvReferencia, 102 ), 1,
					@mvCatAux, @mvNumEco, @mvSitAgua, 'L', 0)

				-- Movimento Taxa de Esgoto
				INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, convert( char(7), @mvReferencia, 102 ), 2,
					 @mvCatAux, @mvNumEco, @mvSitEsgoto, 'L', 0)
			end

			-- Comercial
			if @mvEcoCom > 0 begin
				select @mvCatAux = 2
				set @mvNumEco = @mvEcoCom

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

				-- Movimento
				INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_CATEGORIA
					(seq_matricula, seq_roteiro, cod_referencia,
					 seq_categoria, val_numero_economia)
				values	(@mvMatricula, @mvRoteiro, convert( char(7), @mvReferencia, 102 ),
					@mvCatAux, @mvNumEco)

				-- Movimento Taxa Água
				INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, convert( char(7), @mvReferencia, 102 ), 1,
					@mvCatAux, @mvNumEco, @mvSitAgua, 'L', 0)
				
				-- Movimento Taxa Esgoto
				INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, convert( char(7), @mvReferencia, 102 ), 2,
					 @mvCatAux, @mvNumEco, @mvSitEsgoto, 'L', 0)
			end

			-- Industrial
			if @mvEcoInd > 0 begin
				select @mvCatAux = 3
				set @mvNumEco = @mvEcoInd


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

				-- Movimento
				INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_CATEGORIA
					(seq_matricula, seq_roteiro, cod_referencia,
					 seq_categoria, val_numero_economia)
				values	(@mvMatricula, @mvRoteiro, convert( char(7), @mvReferencia, 102 ),
					@mvCatAux, @mvNumEco)

				-- ?gua
				INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, convert( char(7), @mvReferencia, 102 ), 1,
					@mvCatAux, @mvNumEco, @mvSitAgua, 'L', 0)
				
				-- Esgoto
				INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, convert( char(7), @mvReferencia, 102 ), 2,
					 @mvCatAux, @mvNumEco, @mvSitEsgoto, 'L', 0)
			end

			-- Publica
			if @mvEcoPub > 0 begin
				select @mvCatAux = 4
				set @mvNumEco = @mvEcoPub


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

				-- Movimento
				INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_CATEGORIA
					(seq_matricula, seq_roteiro, cod_referencia,
					 seq_categoria, val_numero_economia)
				values	(@mvMatricula, @mvRoteiro, convert( char(7), @mvReferencia, 102 ),
					@mvCatAux, @mvNumEco)

				-- ?gua
				INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, convert( char(7), @mvReferencia, 102 ), 1,
					@mvCatAux, @mvNumEco, @mvSitAgua, 'L', 0)
				
				-- Esgoto
				INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, convert( char(7), @mvReferencia, 102 ), 2,
					 @mvCatAux, @mvNumEco, @mvSitEsgoto, 'L', 0)
			end

			-- Social 
			if @mvEcoSoc > 0 begin
				select @mvCatAux = 6
				set @mvNumEco = @mvEcoSoc


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

				-- Movimento
				INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_CATEGORIA
					(seq_matricula, seq_roteiro, cod_referencia,
					 seq_categoria, val_numero_economia)
				values	(@mvMatricula, @mvRoteiro, convert( char(7), @mvReferencia, 102 ),
					@mvCatAux, @mvNumEco)

				-- ?gua
				INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, convert( char(7), @mvReferencia, 102 ), 1,
					@mvCatAux, @mvNumEco, @mvSitAgua, 'L', 0)
				
				-- Esgoto
				INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, convert( char(7), @mvReferencia, 102 ), 2,
					 @mvCatAux, @mvNumEco, @mvSitEsgoto, 'L', 0)
			end

			-- Entidade Assistencial 
			if @mvEcoEA > 0 begin
				select @mvCatAux = 8
				set @mvNumEco = @mvEcoEA


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

				-- Movimento
				INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_CATEGORIA
					(seq_matricula, seq_roteiro, cod_referencia,
					 seq_categoria, val_numero_economia)
				values	(@mvMatricula, @mvRoteiro, convert( char(7), @mvReferencia, 102 ),
					@mvCatAux, @mvNumEco)

				-- ?gua
				INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, convert( char(7), @mvReferencia, 102 ), 1,
					@mvCatAux, @mvNumEco, @mvSitAgua, 'L', 0)
				
				-- Esgoto
				INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_TAXA
					(seq_matricula, seq_roteiro, cod_referencia, seq_taxa,
					seq_categoria, val_numero_economia, ind_situacao, ind_tipo_consumo, val_valor_calculado)
				values	(@mvMatricula, @mvRoteiro, convert( char(7), @mvReferencia, 102 ), 2,
					 @mvCatAux, @mvNumEco, @mvSitEsgoto, 'L', 0)
			end


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

	end
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as CATEGORIAS ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Insere dados Matricula Servico Parcela + Movimento Servi?o

	-- ******************************
	-- Cursor para atualizar ACQ_MATRICULA_SERVICO_PARCELA e ACQ_MOVIMENTO_SERVICO
	
	begin
		declare @ssMatriculaAnt int,
			@ssInd		int,
			@ssMatricula 	int,
			@ssGrupo	int,
			@ssReferencia	datetime,
			@ssRoteiro	dec(11),
			@ssServico	int,
			@ssValor	dec(12,2)

		select	@ssMatriculaAnt = 0,
			@ssInd		= 0
	
		declare CUR_SERVICO_STR CURSOR read_only for
		select  sr_matricula as matricula,
			sr_grupo as grupo,
			sr_referencia as referencia, 
			convert(numeric, '1'+OnPlaceSANED.dbo.fc_completa_zeros(cg_grupo, 3)+OnPlaceSANED.dbo.fc_completa_zeros(cg_rota,3)) as roteiro, 
			dbo.fc_busca_servico(ltrim(rtrim(sr_descricao))) as Servico, case when sr_ind_credito = 'S' then -1 else 1 end * sr_valor
		from    OnPlaceSANED..servicos, OnPlaceSANED..carga
		where	cg_matricula = sr_matricula
		and	cg_referencia = sr_referencia
		and	cg_grupo = sr_grupo
		and	cg_grupo = @parGrupo
		and	cg_referencia = @parReferencia
		and	sr_valor > 0
		and	cg_rota between @parRoteiroIni and @parRoteiroFim

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
			if @ssMatriculaAnt <> @ssMatricula begin
				set @ssInd = 0
			end
			set 	@ssInd = (@ssInd + 1)
			select @ssMatriculaAnt = @ssMatricula

			select	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
			from	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
			where	seq_matricula = @ssMatricula

			select	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
			from	OnPlaceSANED_movimento..ACQ_MOVIMENTO_SERVICO
			where	cod_referencia = convert(char(7), @ssReferencia, 102)
			and	seq_roteiro    = @ssRoteiro
			and	seq_matricula  = @ssMatricula

			-- Insere ACQ_MATRICULA_SERVICO_PARCELA
			INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					( seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
					  seq_servico_fatura, cod_referencia, seq_roteiro, 
					  val_valor_parcela, ind_status, ind_documento_origem)
			values	(@ssMatricula, @seq_matricula_servico_parcela, @ssInd,
					 @ssServico, convert(char(7), @ssReferencia, 102), @ssRoteiro,
					 @ssValor, 'A', '01')

			-- Insere ACQ_MOVIMENTO_SERVICO
			INSERT INTO OnPlaceSANED_movimento..ACQ_MOVIMENTO_SERVICO
				(seq_matricula, seq_matricula_servico_parcela, seq_item_servico, 
				 cod_referencia, seq_roteiro, ind_documento_origem, val_valor_servico )
			values	(@ssMatricula, @seq_matricula_servico_parcela, @seq_item_servico,
			    	 convert(char(7), @ssReferencia, 102), @ssRoteiro, '01', @ssValor)

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

	end
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou os SERVIÇOS FATURADOS ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ******************************
	-- Cursor para atualizar NOTIFICACOES

	begin
		declare	@av_matricula int, 
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

		select 	@av_matricula_ant = 0,
			@avAux = 250

		declare CUR_NOTIFICACAO CURSOR read_only for
		select  db_matricula, db_grupo, db_referencia, 
			db_data_vencimento, db_qtde_debitos, db_valor_total, 
			convert(numeric, '1'+OnPlaceSANED.dbo.fc_completa_zeros(cg_grupo, 3)+OnPlaceSANED.dbo.fc_completa_zeros(cg_rota,3)) as roteiro ,
			db_codigo_barras,
			OnPlaceSANED_Movimento.dbo.FC_CODIGO_BARRAS_CONTROLE(db_codigo_barras),
			isnull(db_tipo,'N')
		FROM 	OnPlaceSANED.dbo.debitos, OnPlaceSANED..carga
		where	cg_matricula = db_matricula 
		and	cg_referencia = db_referencia
		and	cg_grupo = db_grupo
		and	cg_grupo = @parGrupo
		and	cg_rota between @parRoteiroIni and @parRoteiroFim
		and	cg_referencia = @parReferencia
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

			if  @av_matricula_ant != @av_matricula begin
				set 	@avAux = 0
			end
			select 	@av_matricula_ant = @av_matricula

			select	@seq_processo_corte = isnull(max(seq_processo_corte),0)+1
			from	OnPlaceSANED_movimento..ACQ_PROCESSO_CORTE

			INSERT INTO OnPlaceSANED_movimento..ACQ_PROCESSO_CORTE
				(seq_processo_corte, seq_matricula, seq_politica_corte, dat_abertura)
			values	(@seq_processo_corte, @av_matricula, 1,
				convert(datetime, convert(char(8), getdate(), 112)))

			select	@seq_aviso = isnull(max(seq_aviso),0)+1
			from	OnPlaceSANED_movimento..ACQ_AVISO
	
			-- Monta a sequencia da fatura
			select	@seq_fatura = isnull(max(seq_fatura),0)+1
			from	OnPlaceSANED_movimento..ACQ_FATURA

			-- Insere Fatura
			INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA
				(dat_leitura, cod_referencia, dat_vencimento, val_valor_faturado, 
				seq_fatura, seq_roteiro,
				seq_matricula, ind_fatura_emitida, ind_status, 
				des_codigo_barras, des_linha_digitavel,
				ind_tipo_documento_origem, des_documento_origem )
			values	(convert(datetime, '19740506'), convert(char(7), convert(datetime, '19740506'), 102), @av_data_vencimento, @av_valor_total, 
				@seq_fatura, @av_roteiro,
				@av_matricula, 'S', 'RE',  
				@av_codigo_barras , @av_codigo_barras_linha,
				4, convert(varchar, @seq_aviso) )

			-- Insere Aviso
			INSERT INTO OnPlaceSANED_movimento..ACQ_AVISO
				(seq_aviso, seq_matricula, seq_politica_corte, seq_processo_corte,
				seq_fatura, dat_geracao_aviso, 
				val_quantidade_debito, val_valor_debito, ind_confirma_entrega,
				ind_documento)
			values	(@seq_aviso, @av_matricula, 1, @seq_processo_corte,
				@seq_fatura, convert(datetime, convert(char(8), getdate(), 112)), 
				@av_qtde_debito, @av_valor_total, 'N', 
				@av_tipo)

			-- Inclui as refer?ncias somente se houver menos que 06 d?bitos
			IF @av_qtde_debito <= 6
			begin
						
				declare CUR_AVISO CURSOR read_only for	
				select 	di_referencia_debito, di_valor
				FROM 	OnPlaceSANED.dbo.debitos_itens
				where 	di_matricula = @av_matricula
				and 	di_referencia = @parReferencia
				and	di_referencia_debito is not null
				and	di_valor > 0
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
					select	@seq_fatura = isnull(max(seq_fatura),0)+1
					from	OnPlaceSANED_movimento..ACQ_FATURA
		
					-- Insere Fatura
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA
						(dat_leitura, cod_referencia, dat_vencimento, val_valor_faturado, 
						seq_fatura, seq_roteiro,
						seq_matricula, ind_fatura_emitida, ind_status )
					values	(@av_referencia_debito, convert(char(7), @av_referencia_debito, 102), @av_data_vencimento, @av_valor_item, 
						@seq_fatura, @av_roteiro,
						@av_matricula, 'S', 'RE')


					-- Insere Aviso Fatura
					INSERT INTO OnPlaceSANED_movimento..ACQ_AVISO_FATURA
						(seq_aviso, seq_aviso_fatura, seq_fatura)
					values	(@seq_aviso, @avAux, @seq_fatura)

					-- Busca servi?o fatura
					select	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
					from	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					where	seq_matricula = @av_matricula

					-- Insere ACQ_MATRICULA_SERVICO_PARCELA
					INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
						(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
						 seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
						 cod_referencia, val_valor_parcela)
					values	(@av_matricula, @seq_matricula_servico_parcela, @avAux,
						 OnPlaceSANED_movimento.dbo.fc_busca_servico('NOTIFICACAO DE DEBITO'), @ssRoteiro, 'A', '01',
						 convert(char(7), @av_referencia_debito, 102), @av_valor_item)

					select	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
					from	OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
					where	seq_fatura = @seq_fatura

					-- Insere ACQ_FATURA_SERVICO
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
						(seq_fatura, seq_matricula_servico_parcela, seq_item_servico, seq_parcela,
						 ind_documento_origem, val_valor_servico)
					values	(@seq_fatura, @seq_matricula_servico_parcela, @seq_item_servico, 1,
						'01', @av_valor_item)

					-- Pr?ximo registro
					FETCH 	NEXT 
					from 	CUR_AVISO
					into 	@av_referencia_debito, @av_valor_item
				end

				-- FECHAR O CURSOR
				CLOSE CUR_AVISO
				DEALLOCATE CUR_AVISO
			end

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

	end
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou os AVISOS DE DÉBITOS ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ******************************
	-- Inclui dados da Segunda via

	begin
		--
		declare	@sv_matricula int , @sv_referencia datetime ,
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

		declare @sv_matricula_ant int, 
			@svAux int, 
			@svConsumoEco int, 
			@svTotalEco int,
			@svCodServico int

		select 	@sv_matricula_ant = 0,
			@svAux = 100,
			@avAux = 500

		declare CUR_SEGVIA CURSOR read_only for
		select  sv_matricula , sv_referencia , sv_data_vencimento ,
			sv_grupo , 
			convert(numeric, '1'+OnPlaceSANED.dbo.fc_completa_zeros(cg_grupo, 3)+OnPlaceSANED.dbo.fc_completa_zeros(cg_rota,3)) as roteiro, 
			sv_referencia_seg_via ,
			sv_leitura_anterior , sv_leitura_atual,
			sv_data_leitura_anterior, sv_data_leitura,
			sv_consumo_faturado, sv_media, cg_categoria, 
			cg_economia_res, cg_economia_com, cg_economia_ind, 
			cg_economia_pub, cg_economia_soc, cg_economia_ea, 
			case when (	case when cg_economia_res > 0 then 1 else 0 end +
					case when cg_economia_com > 0 then 1 else 0 end +
					case when cg_economia_ind > 0 then 1 else 0 end +
					case when cg_economia_pub > 0 then 1 else 0 end +
					case when cg_economia_soc > 0 then 1 else 0 end +
					case when cg_economia_ea > 0 then 1 else 0 end) >= 2
				then 1 else 0 end,
			sv_servico_01 , sv_valor_01 ,
			sv_servico_02 , sv_valor_02 ,
			sv_servico_03 , sv_valor_03 ,
			sv_servico_04 , sv_valor_04 ,
			sv_servico_05 , sv_valor_05 ,
			sv_servico_06 , sv_valor_06 ,
			sv_servico_07 , sv_valor_07 ,
			sv_servico_08 , sv_valor_08 ,
			sv_servico_09 , sv_valor_09 ,
			sv_ref_cons_1 , sv_cons_1 ,
			sv_ref_cons_2 , sv_Cons_2 ,
			sv_ref_cons_3 , sv_Cons_3 ,
			sv_ref_cons_4 , sv_Cons_4 ,
			sv_ref_cons_5 , sv_Cons_5 ,
			sv_ref_cons_6 , sv_Cons_6 ,
			sv_valor_total,
			sv_codigo_barras,
			OnPlaceSANED_Movimento.dbo.FC_CODIGO_BARRAS_CONTROLE(sv_codigo_barras)
		FROM 	OnPlaceSANED..segundas_vias, OnPlaceSANED..carga
		where	cg_matricula = sv_matricula
		and	cg_referencia = sv_referencia
		and	cg_grupo = sv_grupo
		and	cg_grupo = @parGrupo
		and	cg_referencia = @parReferencia
		and	cg_rota between @parRoteiroIni and @parRoteiroFim

		-- CHAMA O CURSOR
		OPEN 	CUR_SEGVIA
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

		-- LOOP CURSOR 
		WHILE (@@fetch_status <> -1)
		BEGIN
			-- Executa
			-- Inicializa
			if @sv_matricula != @sv_matricula_ant begin
				set	@svAux = 100
				set	@avAux = 500
			end

			select	@sv_matricula_ant = @sv_matricula
			set	@svAux = (@svAux+1)
	
			-- Monta a sequencia da fatura
			select	@seq_fatura = isnull(max(seq_fatura),0)+1
			from	OnPlaceSANED_movimento..ACQ_FATURA
	
			-- Insere Fatura
			INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA
				(dat_leitura, dat_leitura_proxima, 
				 cod_referencia, dat_vencimento, val_valor_faturado, 
				 seq_fatura, seq_roteiro,
				 seq_matricula, ind_fatura_emitida, ind_status,
				 dat_leitura_anterior, 
				 val_leitura_real, val_leitura_anterior, 
				 val_consumo_medido, val_consumo_medio,
				 seq_tipo_entrega, des_codigo_barras, des_linha_digitavel )
			values	(@sv_data_leitura, @sv_data_proxima_leit,
				 convert(char(7), @sv_ref_2via, 102), @sv_data_vencimento, @sv_total, 
				 @seq_fatura, @sv_roteiro,
				 @sv_matricula, 'N', 'PE',
	 			 @sv_data_leitura_anterior , 
				 @sv_leitura_atual, @sv_leitura_ant, 
				 @sv_consumo, @sv_consumo_medio, 
				 null,  @sv_codigo_barras , @sv_codigo_barras_linha )

			select 	@sv_servico_ag = 0, 
				@sv_servico_es = 0 

			-- Verifica se existe servi?o
			-- Servi?o 01
			if (ltrim(rtrim(isnull(@sv_desc_servico_01, ''))) != '') and (isnull(@sv_valor_servico_01,0) != 0) begin
				select	@DescricaoTexto = ltrim(rtrim(isnull(@sv_desc_servico_01, '')))
				exec 	OnPlaceSANED_movimento..sp_atualiza_servico @DescricaoTexto
				select	@svCodServico = OnPlaceSANED_movimento.dbo.fc_busca_servico(@DescricaoTexto)
				--isnull(@svCodServico,0)

				if @DescricaoTexto = 'AGUA' begin
					select 	@sv_servico_ag = @sv_valor_servico_01 
				end
				else if @DescricaoTexto = 'ESGOTO' begin
					select 	@sv_servico_es = @sv_valor_servico_01  
				end
				else begin
				

					select	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
					from	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					where	seq_matricula = @sv_matricula
	
					set	@avAux = (@avAux + 1)

					-- Insere ACQ_MATRICULA_SERVICO_PARCELA
					INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
						(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
						 seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
						 cod_referencia, val_valor_parcela)
					values	(@sv_matricula, @seq_matricula_servico_parcela, @avAux,
						 isnull(@svCodServico,0), @sv_roteiro, 'A', '01',
						 convert(char(7), @sv_ref_2via, 102), @sv_valor_servico_01)

					select	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
					from	OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
					where	seq_fatura = @seq_fatura

					-- Insere ACQ_FATURA_SERVICO
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
						(seq_fatura, seq_matricula_servico_parcela, seq_item_servico, seq_parcela,
						seq_servico_fatura, ind_documento_origem, val_valor_servico)
					values	(@seq_fatura, @seq_matricula_servico_parcela, @seq_item_servico, 1,
						isnull(@svCodServico,0), '01', @sv_valor_servico_01)
				end
			end

			-- Servi?o 02
			if (ltrim(rtrim(isnull(@sv_desc_servico_02, ''))) != '') and (isnull(@sv_valor_servico_02,0) != 0) begin
				select	@DescricaoTexto = ltrim(rtrim(isnull(@sv_desc_servico_02, '')))
				exec 	OnPlaceSANED_movimento..sp_atualiza_servico @DescricaoTexto

				select	@svCodServico = OnPlaceSANED_movimento.dbo.fc_busca_servico(@DescricaoTexto)
				--isnull(@svCodServico,0)
				
				if @DescricaoTexto = 'AGUA' begin
					select 	@sv_servico_ag = @sv_valor_servico_02 
				end
				else if @DescricaoTexto = 'ESGOTO' begin
					select 	@sv_servico_es = @sv_valor_servico_02  
				end
				else begin
				
					select	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
					from	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					where	seq_matricula = @sv_matricula
	
					set	@avAux = (@avAux + 1)

					-- Insere ACQ_MATRICULA_SERVICO_PARCELA
					INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
						(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
						seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
						cod_referencia, val_valor_parcela)
					values	(@sv_matricula, @seq_matricula_servico_parcela, @avAux,
						isnull(@svCodServico,0), @sv_roteiro, 'A', '01',
						convert(char(7), @sv_ref_2via, 102), @sv_valor_servico_02)

					select	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
					from	OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
					where	seq_fatura = @seq_fatura

					-- Insere ACQ_FATURA_SERVICO
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
						(seq_fatura, seq_matricula_servico_parcela, seq_item_servico, seq_parcela,
						seq_servico_fatura, ind_documento_origem, val_valor_servico)
					values	(@seq_fatura, @seq_matricula_servico_parcela, @seq_item_servico, 1,
						isnull(@svCodServico,0), '01', @sv_valor_servico_02)
				end
			end

			-- Servi?o 03
			if (ltrim(rtrim(isnull(@sv_desc_servico_03, ''))) != '') and (isnull(@sv_valor_servico_03,0) != 0) begin
				select	@DescricaoTexto = ltrim(rtrim(isnull(@sv_desc_servico_03, '')))
				exec 	OnPlaceSANED_movimento..sp_atualiza_servico @DescricaoTexto

				select	@svCodServico = OnPlaceSANED_movimento.dbo.fc_busca_servico(@DescricaoTexto)
				--isnull(@svCodServico,0)

				select	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
				from	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
				where	seq_matricula = @sv_matricula

				set	@avAux = (@avAux + 1)

				-- Insere ACQ_MATRICULA_SERVICO_PARCELA
				INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
					seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
					cod_referencia, val_valor_parcela)
				values	(@sv_matricula, @seq_matricula_servico_parcela, @avAux,
					isnull(@svCodServico,0), @sv_roteiro, 'A', '01',
					convert(char(7), @sv_ref_2via, 102), @sv_valor_servico_03)

				select	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
				from	OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
				where	seq_fatura = @seq_fatura

				-- Insere ACQ_FATURA_SERVICO
				INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
					(seq_fatura, seq_matricula_servico_parcela, seq_item_servico, seq_parcela,
					seq_servico_fatura, ind_documento_origem, val_valor_servico)
				values	(@seq_fatura, @seq_matricula_servico_parcela, @seq_item_servico, 1,
					isnull(@svCodServico,0), '01', @sv_valor_servico_03)
			end

			-- Servi?o 04
			if (ltrim(rtrim(isnull(@sv_desc_servico_04, ''))) != '') and (isnull(@sv_valor_servico_04,0) != 0) begin
				select	@DescricaoTexto = ltrim(rtrim(isnull(@sv_desc_servico_04, '')))
				exec 	OnPlaceSANED_movimento..sp_atualiza_servico @DescricaoTexto
				
				select	@svCodServico = OnPlaceSANED_movimento.dbo.fc_busca_servico(@DescricaoTexto)
				--isnull(@svCodServico,0)

				select	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
				from	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
				where	seq_matricula = @sv_matricula

				set	@avAux = (@avAux + 1)

				-- Insere ACQ_MATRICULA_SERVICO_PARCELA
				INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
					seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
					cod_referencia, val_valor_parcela)
				values	(@sv_matricula, @seq_matricula_servico_parcela, @avAux,
					isnull(@svCodServico,0), @sv_roteiro, 'A', '01',
					convert(char(7), @sv_ref_2via, 102), @sv_valor_servico_04)

				select	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
				from	OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
				where	seq_fatura = @seq_fatura

				-- Insere ACQ_FATURA_SERVICO
				INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
					(seq_fatura, seq_matricula_servico_parcela, seq_item_servico, seq_parcela,
					seq_servico_fatura, ind_documento_origem, val_valor_servico)
				values	(@seq_fatura, @seq_matricula_servico_parcela, @seq_item_servico, 1,
					isnull(@svCodServico,0), '01', @sv_valor_servico_04)
			end

			-- Servi?o 05
			if (ltrim(rtrim(isnull(@sv_desc_servico_05, ''))) != '') and (isnull(@sv_valor_servico_05,0) != 0) begin
				select	@DescricaoTexto = ltrim(rtrim(isnull(@sv_desc_servico_05, '')))
				exec 	OnPlaceSANED_movimento..sp_atualiza_servico @DescricaoTexto

				select	@svCodServico = OnPlaceSANED_movimento.dbo.fc_busca_servico(@DescricaoTexto)
				--isnull(@svCodServico,0)

				select	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
				from	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
				where	seq_matricula = @sv_matricula

				set	@avAux = (@avAux + 1)

				-- Insere ACQ_MATRICULA_SERVICO_PARCELA
				INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
					seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
					cod_referencia, val_valor_parcela)
				values	(@sv_matricula, @seq_matricula_servico_parcela, @avAux,
					isnull(@svCodServico,0), @sv_roteiro, 'A', '01',
					convert(char(7), @sv_ref_2via, 102), @sv_valor_servico_05)

				select	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
				from	OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
				where	seq_fatura = @seq_fatura

				-- Insere ACQ_FATURA_SERVICO
				INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
					(seq_fatura, seq_matricula_servico_parcela, seq_item_servico, seq_parcela,
					seq_servico_fatura, ind_documento_origem, val_valor_servico)
				values	(@seq_fatura, @seq_matricula_servico_parcela, @seq_item_servico, 1,
					isnull(@svCodServico,0), '01', @sv_valor_servico_05)
			end

			-- Servi?o 06
			if (ltrim(rtrim(isnull(@sv_desc_servico_06, ''))) != '') and (isnull(@sv_valor_servico_06,0) != 0) begin
				select	@DescricaoTexto = ltrim(rtrim(isnull(@sv_desc_servico_06, '')))
				exec 	OnPlaceSANED_movimento..sp_atualiza_servico @DescricaoTexto

				select	@svCodServico = OnPlaceSANED_movimento.dbo.fc_busca_servico(@DescricaoTexto)
				--isnull(@svCodServico,0)
				
				select	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
				from	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
				where	seq_matricula = @sv_matricula

				set	@avAux = (@avAux + 1)

				-- Insere ACQ_MATRICULA_SERVICO_PARCELA
				INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
					seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
					cod_referencia, val_valor_parcela)
				values	(@sv_matricula, @seq_matricula_servico_parcela, @avAux,
					isnull(@svCodServico,0), @sv_roteiro, 'A', '01',
					convert(char(7), @sv_ref_2via, 102), @sv_valor_servico_06)

				select	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
				from	OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
				where	seq_fatura = @seq_fatura

				-- Insere ACQ_FATURA_SERVICO
				INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
					(seq_fatura, seq_matricula_servico_parcela, seq_item_servico, seq_parcela,
					seq_servico_fatura, ind_documento_origem, val_valor_servico)
				values	(@seq_fatura, @seq_matricula_servico_parcela, @seq_item_servico, 1,
					isnull(@svCodServico,0), '01', @sv_valor_servico_06)
			end

			-- Servi?o 07
			if (ltrim(rtrim(isnull(@sv_desc_servico_07, ''))) != '') and (isnull(@sv_valor_servico_07,0) != 0) begin
				select	@DescricaoTexto = ltrim(rtrim(isnull(@sv_desc_servico_07, '')))
				exec 	OnPlaceSANED_movimento..sp_atualiza_servico @DescricaoTexto
				
				select	@svCodServico = OnPlaceSANED_movimento.dbo.fc_busca_servico(@DescricaoTexto)
				--isnull(@svCodServico,0)

				select	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
				from	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
				where	seq_matricula = @sv_matricula

				set	@avAux = (@avAux + 1)

				-- Insere ACQ_MATRICULA_SERVICO_PARCELA
				INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
					seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
					cod_referencia, val_valor_parcela)
				values	(@sv_matricula, @seq_matricula_servico_parcela, @avAux,
					isnull(@svCodServico,0), @sv_roteiro, 'A', '01',
					convert(char(7), @sv_ref_2via, 102), @sv_valor_servico_07)

				select	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
				from	OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
				where	seq_fatura = @seq_fatura

				-- Insere ACQ_FATURA_SERVICO
				INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
					(seq_fatura, seq_matricula_servico_parcela, seq_item_servico, seq_parcela,
					seq_servico_fatura, ind_documento_origem, val_valor_servico)
				values	(@seq_fatura, @seq_matricula_servico_parcela, @seq_item_servico, 1,
					isnull(@svCodServico,0), '01', @sv_valor_servico_07)
			end

			-- Servi?o 08
			if (ltrim(rtrim(isnull(@sv_desc_servico_08, ''))) != '') and (isnull(@sv_valor_servico_08,0) != 0) begin
				select	@DescricaoTexto = ltrim(rtrim(isnull(@sv_desc_servico_08, '')))
				exec 	OnPlaceSANED_movimento..sp_atualiza_servico @DescricaoTexto

				select	@svCodServico = OnPlaceSANED_movimento.dbo.fc_busca_servico(@DescricaoTexto)
				--isnull(@svCodServico,0)
				
				select	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
				from	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
				where	seq_matricula = @sv_matricula

				set	@avAux = (@avAux + 1)

				-- Insere ACQ_MATRICULA_SERVICO_PARCELA
				INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
					seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
					cod_referencia, val_valor_parcela)
				values	(@sv_matricula, @seq_matricula_servico_parcela, @avAux,
					isnull(@svCodServico,0), @sv_roteiro, 'A', '01',
					convert(char(7), @sv_ref_2via, 102), @sv_valor_servico_08)

				select	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
				from	OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
				where	seq_fatura = @seq_fatura

				-- Insere ACQ_FATURA_SERVICO
				INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
					(seq_fatura, seq_matricula_servico_parcela, seq_item_servico, seq_parcela,
					seq_servico_fatura, ind_documento_origem, val_valor_servico)
				values	(@seq_fatura, @seq_matricula_servico_parcela, @seq_item_servico, 1,
					isnull(@svCodServico,0), '01', @sv_valor_servico_08)
			end

			-- Servi?o 09
			if (ltrim(rtrim(isnull(@sv_desc_servico_09, ''))) != '') and (isnull(@sv_valor_servico_09,0) != 0) begin
				select	@DescricaoTexto = ltrim(rtrim(isnull(@sv_desc_servico_09, '')))
				exec 	OnPlaceSANED_movimento..sp_atualiza_servico @DescricaoTexto

				select	@svCodServico = OnPlaceSANED_movimento.dbo.fc_busca_servico(@DescricaoTexto)
				--isnull(@svCodServico,0)
				
				select	@seq_matricula_servico_parcela = isnull(max(isnull(seq_matricula_servico_parcela,0)),0)+1
				from	OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
				where	seq_matricula = @sv_matricula

				set	@avAux = (@avAux + 1)

				-- Insere ACQ_MATRICULA_SERVICO_PARCELA
				INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
					(seq_matricula, seq_matricula_servico_parcela, seq_item_servico_fatura, 
					seq_servico_fatura, seq_roteiro, ind_status, ind_documento_origem, 
					cod_referencia, val_valor_parcela)
				values	(@sv_matricula, @seq_matricula_servico_parcela, @avAux,
					isnull(@svCodServico,0), @sv_roteiro, 'A', '01',
					convert(char(7), @sv_ref_2via, 102), @sv_valor_servico_09)

				select	@seq_item_servico = isnull(max(isnull(seq_item_servico,0)),0)+1
				from	OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
				where	seq_fatura = @seq_fatura

				-- Insere ACQ_FATURA_SERVICO
				INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
					(seq_fatura, seq_matricula_servico_parcela, seq_item_servico, seq_parcela,
					seq_servico_fatura, ind_documento_origem, val_valor_servico)
				values	(@seq_fatura, @seq_matricula_servico_parcela, @seq_item_servico, 1,
					isnull(@svCodServico,0), '01', @sv_valor_servico_09)
			end


			select @svTotalEco = @sv_economia_res + @sv_economia_com + @sv_economia_ind + @sv_economia_pub + @sv_economia_soc + @sv_economia_ea
			if @svTotalEco <= 0 begin
				select @svTotalEco = 1
			end
			select @svConsumoEco = @sv_consumo / @svTotalEco

			-- Mista
			if @sv_ind_mista > 0 begin
				select @mvCatAux = 5

				INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_CATEGORIA
					(seq_fatura, seq_categoria, val_numero_economia)
				values	(@seq_fatura, @mvCatAux, @sv_economia_res)

				-- ?gua
				if isnull(@sv_servico_ag,0) > 0 begin
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 1,
						@svTotalEco, 1, 'L',
						@sv_servico_ag, @sv_servico_ag, @svConsumoEco * @svTotalEco)
				end

				-- Esgoto
				if isnull(@sv_servico_es,0) > 0 begin
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 2,
						@svTotalEco, 1, 'L',
						@sv_servico_es, @sv_servico_es, @svConsumoEco * @svTotalEco)
				end

			end

			-- Residencial
			else if @sv_economia_res > 0 begin
				select @mvCatAux = 1

				INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_CATEGORIA
					(seq_fatura, seq_categoria, val_numero_economia)
				values	(@seq_fatura, @mvCatAux, @sv_economia_res)

				-- ?gua
				if isnull(@sv_servico_ag,0) > 0 begin
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 1,
						@sv_economia_res, 1, 'L',
						@sv_servico_ag, @sv_servico_ag, @svConsumoEco * @sv_economia_res)
				end

				-- Esgoto
				if isnull(@sv_servico_es,0) > 0 begin
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_TAXA
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
							@sv_economia_res, 
							1, 
							'L',
							@sv_servico_es, 
							@sv_servico_es, 
							@svConsumoEco
							@sv_economia_res
						)
				end

			end

			-- Comercial
			else if @sv_economia_com > 0 begin
				select @mvCatAux = 2

				INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_CATEGORIA
					(seq_fatura, seq_categoria, val_numero_economia)
				values	(@seq_fatura, @mvCatAux, @sv_economia_com)

				-- ?gua
				if isnull(@sv_servico_ag,0) > 0 begin
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 1,
						@sv_economia_com, 1, 'L',
						@sv_servico_ag, @sv_servico_ag, @svConsumoEco * @sv_economia_com)
				end

				-- Esgoto
				if isnull(@sv_servico_es,0) > 0 begin
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 2,
						@sv_economia_com, 1, 'L',
						@sv_servico_es, @sv_servico_es, @svConsumoEco * @sv_economia_com)
				end

			end

			-- Industrial
			else if @sv_economia_ind > 0 begin
				select @mvCatAux = 3

				INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_CATEGORIA
					(seq_fatura, seq_categoria, val_numero_economia)
				values	(@seq_fatura, @mvCatAux, @sv_economia_ind)

				-- ?gua
				if isnull(@sv_servico_ag,0) > 0 begin
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 1,
						@sv_economia_ind, 1, 'L',
						@sv_servico_ag, @sv_servico_ag, @svConsumoEco * @sv_economia_ind)
				end

				-- Esgoto
				if isnull(@sv_servico_es,0) > 0 begin
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 2,
						@sv_economia_ind, 1, 'L',
						@sv_servico_es, @sv_servico_es, @svConsumoEco * @sv_economia_ind)
				end

			end
			
			-- P?BLICA
			else if @sv_economia_pub > 0 begin
				select @mvCatAux = 4

				INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_CATEGORIA
					(seq_fatura, seq_categoria, val_numero_economia)
				values	(@seq_fatura, @mvCatAux, @sv_economia_pub)

				-- ?gua
				if isnull(@sv_servico_ag,0) > 0 begin
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 1,
						@sv_economia_pub, 1, 'L',
						@sv_servico_ag, @sv_servico_ag, @svConsumoEco * @sv_economia_pub)
				end

				-- Esgoto
				if isnull(@sv_servico_es,0) > 0 begin
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 2,
						@sv_economia_pub, 1, 'L',
						@sv_servico_es, @sv_servico_es, @svConsumoEco * @sv_economia_pub)
				end

			end			

			-- Social 
			else if @sv_economia_soc  > 0 begin
				select @mvCatAux = 6

				INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_CATEGORIA
					(seq_fatura, seq_categoria, val_numero_economia)
				values	(@seq_fatura, @mvCatAux, @sv_economia_soc)

				-- ?gua
				if isnull(@sv_servico_ag,0) > 0 begin
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 1,
						@sv_economia_soc, 1, 'L',
						@sv_servico_ag, @sv_servico_ag, @svConsumoEco * @sv_economia_soc)
				end

				-- Esgoto
				if isnull(@sv_servico_es,0) > 0 begin
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 2,
						@sv_economia_soc, 1, 'L',
						@sv_servico_es, @sv_servico_es, @svConsumoEco * @sv_economia_soc)
				end

			end			

			-- Entidade assistencial 
			else if @sv_economia_ea  > 0 begin
				select @mvCatAux = 8

				INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_CATEGORIA
					(seq_fatura, seq_categoria, val_numero_economia)
				values	(@seq_fatura, @mvCatAux, @sv_economia_ea)

				-- ?gua
				if isnull(@sv_servico_ag,0) > 0 begin
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 1,
						@sv_economia_ea, 1, 'L',
						@sv_servico_ag, @sv_servico_ag, @svConsumoEco * @sv_economia_ea)
				end

				-- Esgoto
				if isnull(@sv_servico_es,0) > 0 begin
					INSERT INTO OnPlaceSANED_movimento..ACQ_FATURA_TAXA
						(seq_fatura, seq_categoria, seq_taxa,
						val_numero_economia, ind_situacao, ind_tipo_consumo,
						val_valor_faturado, val_valor_calculado, val_consumo_faturado)
					values	(@seq_fatura, @mvCatAux, 2,
						@sv_economia_ea, 1, 'L',
						@sv_servico_es, @sv_servico_es, @svConsumoEco * @sv_economia_ea)
				end

			end			

			-- Atualiza Hist?rico de consumo
			-- Ref 01
			if @sv_ref_01 > 0 begin
				exec OnPlaceSANED_movimento.dbo.sp_atualiza_matricula_leitura @sv_matricula, @sv_ref_01, @sv_ref_01, @sv_hidrometro, @sv_grupo, @sv_consumo_01, 0
			end 

			-- Ref 02
			if @sv_ref_02 > 0 begin
				exec OnPlaceSANED_movimento.dbo.sp_atualiza_matricula_leitura @sv_matricula, @sv_ref_02, @sv_ref_02, @sv_hidrometro, @sv_grupo, @sv_consumo_02, 0
			end 

			-- Ref 03
			if @sv_ref_03 > 0 begin
				exec OnPlaceSANED_movimento.dbo.sp_atualiza_matricula_leitura @sv_matricula, @sv_ref_03, @sv_ref_03, @sv_hidrometro, @sv_grupo, @sv_consumo_03, 0
			end 

			-- Ref 04
			if @sv_ref_04 > 0 begin
				exec OnPlaceSANED_movimento.dbo.sp_atualiza_matricula_leitura @sv_matricula, @sv_ref_04, @sv_ref_04, @sv_hidrometro, @sv_grupo, @sv_consumo_04, 0
			end 

			-- Ref 05
			if @sv_ref_05 > 0 begin
				exec OnPlaceSANED_movimento.dbo.sp_atualiza_matricula_leitura @sv_matricula, @sv_ref_05, @sv_ref_05, @sv_hidrometro, @sv_grupo, @sv_consumo_05, 0
			end 

			-- Ref 06
			if @sv_ref_06 > 0 begin
				exec OnPlaceSANED_movimento.dbo.sp_atualiza_matricula_leitura @sv_matricula, @sv_ref_06, @sv_ref_06, @sv_hidrometro, @sv_grupo, @sv_consumo_06, 0
			end 

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
	end
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou as SEGUNDAS-VIAS ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ******************************
	-- Finaliza
	-- ---------------------------
	-- Atualiza a Fatura Cronograma para liberar a transmiss?o

	update	OnPlaceSANED_movimento..ACQ_GRUPO_FATURA_CRONOGRAMA
	set	ind_gerado = 'S'
	from	OnPlaceSANED_movimento..ACQ_GRUPO_REFERENCIA
	where	seq_grupo_fatura = @parGrupo
	and	ACQ_GRUPO_FATURA_CRONOGRAMA.seq_roteiro = ACQ_GRUPO_REFERENCIA.seq_roteiro
	and	ACQ_GRUPO_FATURA_CRONOGRAMA.cod_referencia = ACQ_GRUPO_REFERENCIA.cod_referencia
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Atualizou o ACQ_GRUPO_FATURA_CRONOGRAMA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicioGeral
		select	@hrInicio = getdate()
		Print ' -- FIM ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	
end

GO

-----------------------------------------------------------FIM------------------------------------------------------------------



-- exec dbo.sp_desfaz_carga_movimento 14
 CREATE  procedure dbo.sp_desfaz_carga_movimento (@parGrupo int)
 
 AS
begin

	declare @nTeste     	int,
		@hrInicio   	datetime,
		@hrInicioGeral 	datetime,
		@hrAnterior 	datetime
	set 	@nTeste = 0

	-- Para teste
--	declare @parGrupo int
--	select @parGrupo = 1
--	select @nTeste = 1

	if @nTeste = 1 begin
		select	@hrInicio = getdate()
		select	@hrInicioGeral = @hrInicio
		Print ' -- Inicio em ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108)
	end	
	-- ---------------------------
	-- Apaga as Mensagens
	delete	from OnPlaceSANED_movimento..acq_mensagem_movimento
	from	OnPlaceSANED..carga
	where 	cg_grupo = @parGrupo
	and	cg_matricula = seq_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar acq_mensagem_movimento ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Apaga Alteração Cadastral
	delete	from OnPlaceSANED_movimento..ACQ_ALTERACAO_CADASTRAL
	from	OnPlaceSANED..carga
	where 	cg_grupo = @parGrupo
	and	cg_matricula = seq_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_ALTERACAO_CADASTRAL ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Apaga Qualidade da Água
	delete	from OnPlaceSANED_movimento..ACQ_QUALIDADE_AGUA
	where 	seq_zona_abastecimento = @parGrupo
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_QUALIDADE_AGUA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Apaga Mensagem movimento
	delete	from OnPlaceSANED_movimento..ACQ_MENSAGEM_MOVIMENTO
	where 	OnPlaceSANED_movimento..ACQ_MENSAGEM_MOVIMENTO.seq_grupo_fatura = @parGrupo
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_MENSAGEM_MOVIMENTO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_MENSAGEM_MOVIMENTO
	from	OnPlaceSANED_movimento..ACQ_MATRICULA
	where 	seq_rota = @parGrupo
	and	OnPlaceSANED_movimento..ACQ_MENSAGEM_MOVIMENTO.seq_matricula = OnPlaceSANED_movimento..ACQ_MATRICULA.seq_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_MENSAGEM_MOVIMENTO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Apaga dados da Notificação
	delete	from OnPlaceSANED_movimento..ACQ_AVISO_FATURA
	from	OnPlaceSANED_movimento..ACQ_AVISO, OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	and	OnPlaceSANED_movimento..ACQ_AVISO_FATURA.seq_aviso = OnPlaceSANED_movimento..ACQ_AVISO.seq_aviso
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_AVISO_FATURA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_PROCESSO_CORTE
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_PROCESSO_CORTE ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_AVISO
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_AVISO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Apaga dados do retorno do MCP
	-- Aviso de Débito
	delete	from OnPlaceSANED_movimento..ONP_AVISO_DEBITO
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ONP_AVISO_DEBITO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- Serviços
	delete	from OnPlaceSANED_movimento..ONP_MATRICULA_SERVICO
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ONP_MATRICULA_SERVICO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- Diadema
	delete	from OnPlaceSANED_movimento..ONP_MATRICULA_DIADEMA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ONP_MATRICULA_DIADEMA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- Diadema
	delete	from OnPlaceSANED_movimento..ONP_MATRICULAS_CARGA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ONP_MATRICULAS_CARGA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- Alteração cadastra
	delete	from OnPlaceSANED_movimento..ONP_MATRICULA_ALTERACAO
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ONP_MATRICULA_ALTERACAO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- Faturas
	delete	from OnPlaceSANED_movimento..ONP_FATURA_TAXA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ONP_FATURA_TAXA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ONP_FATURA_CATEGORIA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ONP_FATURA_CATEGORIA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ONP_FATURA_SERVICO
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ONP_FATURA_SERVICO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ONP_FATURA_IMPOSTO_DIADEMA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ONP_FATURA_IMPOSTO_DIADEMA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ONP_FATURA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ONP_FATURA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- Movimento
	delete	from OnPlaceSANED_movimento..ONP_MOVIMENTO_TAXA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ONP_MOVIMENTO_TAXA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ONP_MOVIMENTO_CATEGORIA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ONP_MOVIMENTO_CATEGORIA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ONP_MOVIMENTO_FOTO
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ONP_MOVIMENTO_FOTO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ONP_MOVIMENTO_OCORRENCIA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ONP_MOVIMENTO_OCORRENCIA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ONP_MOVIMENTO
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ONP_MOVIMENTO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Apaga dados da Faturas
	delete	from OnPlaceSANED_movimento..ACQ_FATURA_TAXA
	from	OnPlaceSANED_movimento..ACQ_FATURA, OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	and	OnPlaceSANED_movimento..ACQ_FATURA_TAXA.seq_fatura = OnPlaceSANED_movimento..ACQ_FATURA.seq_fatura
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_FATURA_TAXA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_FATURA_CATEGORIA
	from	OnPlaceSANED_movimento..ACQ_FATURA, OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	and	OnPlaceSANED_movimento..ACQ_FATURA_CATEGORIA.seq_fatura = OnPlaceSANED_movimento..ACQ_FATURA.seq_fatura
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_FATURA_CATEGORIA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_FATURA_SERVICO
	from	OnPlaceSANED_movimento..ACQ_FATURA, OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	and	OnPlaceSANED_movimento..ACQ_FATURA_SERVICO.seq_fatura = OnPlaceSANED_movimento..ACQ_FATURA.seq_fatura
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_FATURA_SERVICO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_FATURA_IMPOSTO_DIADEMA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_FATURA_IMPOSTO_DIADEMA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_FATURA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_FATURA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Apaga dados da Taxas das Matriculas
	delete	from OnPlaceSANED_movimento..ACQ_TAXA_MATRICULA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_TAXA_MATRICULA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Apaga dados do Movimento
	delete	from OnPlaceSANED_movimento..ACQ_MOVIMENTO_SERVICO
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_MOVIMENTO_SERVICO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_MOVIMENTO_TAXA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_MOVIMENTO_TAXA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_MOVIMENTO_CATEGORIA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_MOVIMENTO_CATEGORIA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_MOVIMENTO_FOTO
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_MOVIMENTO_FOTO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_MOVIMENTO_OCORRENCIA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_MOVIMENTO_OCORRENCIA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_MOVIMENTO
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_MOVIMENTO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Apaga dados da Matricula
	delete	from OnPlaceSANED_movimento..ACQ_MATRICULA_LEITURAS
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_MATRICULA_LEITURAS ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_MATRICULA_DEB_AUTOMATICO
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_MATRICULA_DEB_AUTOMATICO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_MATRICULA_HIDROMETRO
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_MATRICULA_HIDROMETRO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_MATRICULA_SERVICO_PARCELA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_MATRICULA_SERVICO_PARCELA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_MATRICULA_ENTREGA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_MATRICULA_ENTREGA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_MATRICULA_DIADEMA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_MATRICULA_DIADEMA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_MATRICULA_CATEGORIA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_MATRICULA_CATEGORIA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_MATRICULA_ESPECIAL
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_MATRICULA_ESPECIAL ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_MATRICULA_LIGACAO
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_MATRICULA_LIGACAO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_MATRICULA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	isnull(cg_matricula_pai,0) > 0
	and	cg_matricula_pai = cg_matricula
	and	seq_matricula_principal = cg_matricula_pai
	and	seq_matricula != isnull(seq_matricula_principal,0)
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_MATRICULA - FILHOS ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_MATRICULA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_MATRICULA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_PESSOA
	from	OnPlaceSANED..CARGA
	where 	cg_grupo = @parGrupo
	and	seq_pessoa = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_PESSOA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Apaga dados do HIDROMETRO
	delete	from OnPlaceSANED_movimento..ACQ_HIDROMETRO_DIADEMA
	from	OnPlaceSANED..carga
	where	cg_grupo = @parGrupo
	and	seq_matricula = cg_matricula
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_HIDROMETRO_DIADEMA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_HIDROMETRO
	from	OnPlaceSANED..carga
	where	cg_grupo = @parGrupo
	and	cod_hidrometro = cg_numero_hd
	and	ltrim(rtrim(isnull(cg_numero_hd,''))) != ''
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_HIDROMETRO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	-- ---------------------------
	-- Apaga dados do GRUPO
	delete	from OnPlaceSANED_movimento..ACQ_GRUPO_FATURA_CRONOGRAMA
	from	OnPlaceSANED..ROTEIROS
	where	rt_grupo = @parGrupo
	and	seq_roteiro = convert(numeric, '1'+OnPlaceSANED.dbo.fc_completa_zeros(rt_grupo, 3)+OnPlaceSANED.dbo.fc_completa_zeros(rt_rota,3))
	and	cod_referencia = convert(varchar(7), rt_referencia, 102 )
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_GRUPO_FATURA_CRONOGRAMA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	
	
	delete	from OnPlaceSANED_movimento..ACQ_GRUPO_REFERENCIA		
	where	seq_grupo_fatura = @parGrupo
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_GRUPO_REFERENCIA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	
	
	delete	from OnPlaceSANED_movimento..ACQ_ROTEIRO		
	where	seq_grupo_fatura = @parGrupo
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_ROTEIRO ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	delete	from OnPlaceSANED_movimento..ACQ_GRUPO_FATURA		
	where	seq_grupo_fatura = @parGrupo
	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicio 
		select	@hrInicio = getdate()
		Print ' -- Apagar ACQ_GRUPO_FATURA ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	

	if @nTeste = 1 begin
		select	@hrAnterior = @hrInicioGeral
		select	@hrInicio = getdate()
		Print ' -- FIM ' + convert(varchar, getdate(), 103) + ' ' + convert(varchar, @hrInicio, 108) + ' Tempo: ' + convert(varchar, datediff(s, @hrAnterior, @hrInicio )) + ' segundos.'
	end	
end

GO



create procedure sp_acerta_agentes
as
begin
	update 	onplacesaned..roteiros
	set	rt_agente = 
		(select max(dg_agente) 
		from 	onplacesaned..descarga 
		where 	dg_grupo = rt_grupo 
		and 	dg_rota = rt_rota 
		and 	dg_agente is not null)
	where 	rt_agente is null
end

GO



-- Cria
CREATE  procedure dbo.sp_atualiza_agentes
(@parReferencia datetime, @parGrupo int)

AS
begin tran
	truncate table OnPlaceSANED_movimento..ACQ_AGENTE
	insert into OnPlaceSANED_movimento..ACQ_AGENTE
			(cod_agente, nom_agente, des_senha, ind_ativo)
	select  ag_codigo, ag_nome, isnull(ag_senha,ag_codigo), 'S'
	from	OnPlaceSANED..agentes
	where 	ag_grupo = @parGrupo
	and 	ag_referencia = @parReferencia
commit

GO



CREATE   procedure [dbo].[sp_atualiza_anormalidade] 
(@parGrupo int, @parReferencia datetime)

AS
begin tran

	-- Atualiza Ocorrência de Leitura
	truncate table OnPlaceSaned_Movimento..acq_ocorrencia
	
	insert 	into OnPlaceSaned_Movimento..acq_ocorrencia
		(cod_ocorrencia, des_ocorrencia, des_mensagem, ind_grupo, 
		ind_leitura, 
		ind_emite, 
		ind_consumo,
		ind_ativo)
	select 	oc_codigo, oc_descricao, case when oc_mensagem = 0 then '' else oc_descricao end, 'O', 
		case when oc_acesso = 1 then 'P'
		     when oc_acesso = 2 then 'N'
		else 'S' end,
		'S',
		case when oc_calculo = 2 then 1
		     when oc_calculo = 7 then 10 -- Média quando não tiver consumo/leitura real
		     when oc_calculo = 8 then 9  -- Mínimo quando não tiver consumo/leitura real
		else 0 -- Consumo medido
		end,
		'S'
	from	OnPlaceSaned..ocorrencias
	where 	oc_grupo = @parGrupo
	and	oc_referencia = @parReferencia

commit

GO



-- Cria
CREATE procedure dbo.sp_atualiza_bairro
(@parNome varchar(100))

AS
begin 
	declare @Existe int

	select @Existe = isnull(min(seq_bairro),0)
	from   OnPlaceSANED_movimento..ACQ_BAIRRO
	where  des_bairro = @parNome

	if @Existe = 0
	begin
		begin tran
		insert into OnPlaceSANED_movimento..ACQ_BAIRRO
			(seq_bairro, cod_uf, seq_localidade, des_bairro)
		select 	isnull(max(seq_bairro),0)+1,
			'SP', 1, @parNome
		from	OnPlaceSANED_movimento..ACQ_BAIRRO
		commit
	end
end

GO




-- Cria
CREATE procedure dbo.sp_atualiza_bancos
(@parBanco int, @parAgencia int)

AS
begin

	declare	@Qtde int

	select 	@Qtde = Count(*) 
	from 	OnPlaceSANED_Movimento..ACQ_BANCO
	where	cod_banco = @parBanco

	if @Qtde = 0 begin
		insert into OnPlaceSANED_Movimento..ACQ_BANCO 	
			(cod_banco, des_nome, des_nome_abreviado, des_endereco_telegrafico, cod_cnpj) 
		values  (@parBanco,'BANCO ' + convert(varchar,@parBanco),'BANCO ' + convert(varchar,@parBanco), 'BANCO ' + convert(varchar,@parBanco), 00000000000000)
	end

	select 	@Qtde = Count(*) 
	from 	OnPlaceSaned_Movimento..ACQ_BANCO_AGENCIA
	where	cod_banco = @parBanco
	and	cod_banco_agencia = @parAgencia

	if @Qtde = 0 begin
		insert into OnPlaceSANED_Movimento..ACQ_BANCO_AGENCIA 	
			(cod_banco_agencia, cod_banco, des_nome, des_endereco, des_local) 
		values  (@parAgencia, @parBanco, 'BANCO ' + convert(varchar,@parBanco),'BANCO ' + convert(varchar,@parBanco), 'DIADEMA')
	end
	
	insert into OnPlaceSANED_movimento..ACQ_DEBITO_CONVENIO 
		(seq_convenio, des_convenio, cod_banco, cod_banco_credito, cod_banco_agencia_credito)
	select 	cod_banco, des_nome, cod_banco, cod_banco, cod_banco
	from 	OnPlaceSANED_Movimento..ACQ_BANCO
	where	cod_banco not in (select seq_convenio from OnPlaceSANED_movimento..ACQ_DEBITO_CONVENIO)

end

GO



-- Cria
CREATE procedure dbo.sp_atualiza_cep
(@parCEP varchar(20), @parLog int)

AS
begin 
	declare @Existe int

	select @Existe = count(*)
	from   OnPlaceSANED_movimento..ACQ_CEP
	where  cod_cep = @parCEP

	if @Existe = 0
	begin
		begin tran
		insert into OnPlaceSANED_movimento..ACQ_CEP
			(cod_cep, ind_tipo_cep, seq_registro)
		values	(@parCEP, 'L', 'SP;1;'+convert(varchar, @parLog))
		commit
	end
end

GO



CREATE procedure [dbo].[sp_atualiza_descontos] 
(@parGrupo int, @parReferencia datetime)

AS
begin tran

	-- Atualiza Descontos
	truncate table OnPlaceSaned_Movimento..ACQ_DESCONTO_DIADEMA

	INSERT INTO OnplaceSaned_Movimento..ACQ_DESCONTO_DIADEMA
		(seq_desconto, ind_tipo_desconto, val_limite_inicial, val_valor_desconto)
	select 	de_codigo, de_tipo_desconto, de_limite_inicial, de_percentual
	from 	OnPlaceSaned..descontos
	where	de_grupo = @parGrupo
	and	de_referencia = @parReferencia


commit

GO



-- Cria
CREATE procedure dbo.sp_atualiza_logradouro
(@parNome varchar(100)) 

AS
begin 
	declare @Existe int

	select @Existe = isnull(min(seq_logradouro),0)
	from   OnPlaceSANED_movimento..ACQ_LOGRADOURO
	where  des_logradouro = @parNome

	if @Existe = 0
	begin
		begin tran
		insert into OnPlaceSANED_movimento..ACQ_LOGRADOURO
			(seq_logradouro, cod_uf, seq_localidade, des_logradouro)
		select 	isnull(max(seq_logradouro),0)+1,
			'SP', 1, @parNome
		from	OnPlaceSANED_movimento..ACQ_LOGRADOURO
		commit
	end
end

GO



-- Cria
CREATE procedure dbo.sp_atualiza_matricula_leitura
(@parMatricula int, @parData datetime, @parReferencia datetime, @parHidrometro varchar, @parGrupo int, @parConsumo int, @parLeitura int)

AS
begin 
	declare @Existe int

	select @Existe = count(*)
	from   	OnPlaceSANED_movimento..ACQ_MATRICULA_LEITURAS
	where  	seq_matricula = @parMatricula
	and    	cod_referencia = convert(char(7), @parReferencia, 102)

	begin tran
	if @Existe = 0 begin
		INSERT INTO OnPlaceSANED_movimento..ACQ_MATRICULA_LEITURAS
			(seq_matricula, cod_referencia, seq_grupo_fatura, 
			 dat_leitura, cod_hidrometro, 
			 val_consumo_real, val_leitura_real)
		values( @parMatricula, convert(char(7), @parReferencia, 102), @parGrupo,
				 @parData, @parHidrometro,
				 isnull(@parConsumo,0), isnull(@parLeitura,0))
	end
	else begin
		update OnPlaceSANED_movimento..ACQ_MATRICULA_LEITURAS
		set    	seq_grupo_fatura = @parGrupo, 
				dat_leitura = @parData, 
				cod_hidrometro = @parHidrometro, 
				val_consumo_real = isnull(@parConsumo,0), 
				val_leitura_real = isnull(@parLeitura,0)
		where  	seq_matricula = @parMatricula
		and    	cod_referencia = convert(char(7), @parReferencia, 102)
	end	
	commit
end

GO



-- Cria
CREATE procedure dbo.sp_atualiza_servico
(@parNome varchar(100))

AS
begin 
	declare @Existe int

	select @Existe = isnull(min(seq_servico_fatura),0)
	from   OnPlaceSANED_movimento..ACQ_SERVICO_FATURA
	where  des_servico_fatura = @parNome

	if @Existe = 0
	begin
		begin tran
		insert into OnPlaceSANED_movimento..ACQ_SERVICO_FATURA
			(seq_servico_fatura, des_servico_fatura)
		select 	isnull(max(seq_servico_fatura),0)+1,
			@parNome
		from	OnPlaceSANED_movimento..ACQ_SERVICO_FATURA
		commit
	end
end

GO



-- Cria
create procedure dbo.sp_desfaz_retorno_movimento
(@parGrupo int, @parReferencia datetime, @parRoteiro numeric(12), @parChave varchar(8))
AS
begin
	declare	@cod_referencia    varchar(8)

	select @cod_referencia  = convert(char(7), @parReferencia, 102)

	-- Atualiza tabela de processamento
	update	OnPlaceSaned_Movimento..ACQ_GRUPO_FATURA_CRONOGRAMA
	set	ind_validado   = 'N'
	,	ind_processado = 'N'
	where	seq_roteiro    = @parRoteiro
	and	cod_referencia = @cod_referencia

end

GO


CREATE procedure dbo.sp_incrementa_controle_contador
(@Tipo int)
 
as
begin

	declare @Valor numeric(7)
	select	@Valor = 0

	begin tran
	-- Sequencia FATURA
	if @tipo = 1 begin
		update 	OnPlaceSANED_movimento.dbo.ACQ_CONTROLE_CONTADOR
		set	seq_fatura = (seq_fatura + 1)

		select	@Valor = seq_fatura 
		from	OnPlaceSANED_movimento.dbo.ACQ_CONTROLE_CONTADOR
	end

	-- Sequencia AVISO
	if @tipo = 2 begin
		update 	OnPlaceSANED_movimento.dbo.ACQ_CONTROLE_CONTADOR
		set	seq_aviso = (seq_aviso + 1)

		select	@Valor = seq_aviso
		from	OnPlaceSANED_movimento.dbo.ACQ_CONTROLE_CONTADOR
	end
	commit	
	-- Retorna
	select @valor as Proximo
end

GO



-- exec sp_retorno_movimento 1, '20080501', 1001002, 'ALFREDO'
CREATE   procedure [dbo].[sp_retorno_movimento] (@parGrupo int, @parReferencia datetime, @parRoteiro numeric(12), @parChave varchar(8))

AS
begin
	-- Teste
	-- declare @parGrupo int, @parReferencia datetime, @parRoteiro numeric(12), @parChave varchar(8)
	-- select @parGrupo = 5, @parReferencia = '20080501', @parRoteiro = 1005007, @parChave = 'ALFREDO'

	-- Movimento
	declare	@mv_cod_referencia            	varchar(8),
		@mv_seq_roteiro               	numeric(12),
		@mv_seq_matricula             	numeric(9),
		@mv_cod_agente                	numeric(7),
		@mv_cod_hidrometro            	varchar(12),
		@mv_seq_tipo_entrega          	numeric(3),
		@mv_val_leitura_anterior      	numeric(7),
		@mv_val_leitura_real          	numeric(7),
		@mv_val_leitura_atribuida     	numeric(7),
		@mv_val_numero_leituras       	numeric(5),
		@mv_ind_leitura_divergente    	char(1),
		@mv_val_consumo_medido        	numeric(7),
		@mv_val_consumo_medio         	numeric(7),
		@mv_val_consumo_estimado      	numeric(7),
		@mv_val_consumo_estimado_esg  	numeric(7),
		@mv_val_consumo_atribuido     	numeric(7),
		@mv_val_consumo_troca         	numeric(7),
		@mv_val_consumo_rateado       	numeric(7),
		@mv_des_banco_debito          	varchar(30),
		@mv_des_banco_agencia_debito  	varchar(20),
		@mv_dat_leitura               	datetime,
		@mv_dat_proxima_leitura       	datetime,
		@mv_dat_vencimento            	datetime,
		@mv_dat_leitura_anterior      	datetime,
		@mv_ind_entrega_especial      	char(1),
		@mv_val_quantidade_pendente   	numeric(4),
		@mv_val_desconto              	numeric(11, 3),
		@val_valor_credito 		numeric(11, 3),
		@mv_ind_motivo_retirada       	char(1),
		@mv_dat_troca                 	datetime,
		@mv_ind_situacao_movimento    	char(1),
		@mv_ind_fatura_emitida        	char(1),
		@mv_val_arredonda_anterior    	numeric(3, 2),
		@mv_val_impressoes            	numeric(2)

	-- Faturas
	declare	@ExisteFat                	int,
		@seq_fatura               	numeric(7),
		@seq_tipo_entrega         	numeric(3),
		@cod_referencia           	varchar(8),
		@seq_roteiro              	numeric(12),
		@Rota               	  	int,
		@seq_matricula            	numeric(9),
		@ind_fatura_emitida       	char(1),
		@dat_vencimento           	datetime,
		@val_arredonda_anterior   	numeric(3,2),
		@val_arredonda_atual      	numeric(3,2),
		@dat_hora_emissao         	datetime,
		@val_valor_faturado       	numeric(11,3),
		@dat_leitura              	datetime,
		@dat_leitura_anterior     	datetime,
		@ind_entrega_especial     	char(1),
		@des_banco_debito         	varchar(30),
		@des_banco_agencia_debito 	varchar(20),
		@val_quantidade_pendente  	numeric(4),
		@val_consumo_medio        	numeric(7),
		@val_consumo_rateado      	numeric(7),
		@val_desconto             	numeric(11,3),
		@des_linha_digitavel      	char(48),
		@des_codigo_barras        	char(44),
		@val_impressoes           	numeric(2),
 		@cod_ocorrencia           	numeric(3)



	-- Auxiliar
	declare	@RoteiroIni			numeric(12),
		@RoteiroFim			numeric(12),
		@Cont_Ocorr             	int,
		@Cont_Sv                	int,
		@nExiste			int,
		@nLinha				int,
		@dtAtual			datetime, 
		@dg_chave			varchar(8),
		@nCateg				int,
		@dataaux			datetime

	select	@dataaux = convert(datetime, convert(char(8), getdate(), 112))
		
	-- Serviços Faturados
	declare @sf_ind_credito           	char(1), 
		@sf_val_parcela           	numeric(11,3)

	-- Impostos Faturados
	declare @fi_codigo                	varchar(16), 
		@fi_val_imposto           	numeric(11,3)

	-- Segundas-Vias
	declare	@sv_referencia             	datetime,
		@sv_val_impressoes         	numeric(2)

	-- Serviço solicitado
	declare	@ss_seq_servico		   	numeric(4), 
		@ss_ind_solicitante	   	char(1)

	-- Aviso de Débito
	declare	@ExisteAd                  	int,
		@ad_impressoes             	int, 
		@ad_protocolado            	char(1)

	-- Descarga
	declare	@dg_grupo 			int, 
		@dg_setor 			int, 
		@dg_rota 			int, 
		@dg_referencia 			datetime, 
		@dg_matricula 			int, 
		@dg_leitura_ajustada 		int, 
		@dg_leitura_real 		int, 
		@dg_consumo_ajustado 		int, 
		@dg_consumo_rateado 		int, 
		@dg_situacao_consumo 		int, 
		@dg_dias_consumo 		int, 
		@dg_ocorrencia 			int, 
		@dg_ocorrencia2 		int, 
		@dg_flag_calculada 		varchar(1), 
		@dg_flag_emitida 		varchar(1), 
		@dg_flag_cortado 		varchar(1), 
		@dg_flag_aviso 			varchar(1), 
		@dg_valor_agua 			decimal(14,2), 
		@dg_valor_esgoto 		decimal(14,2), 
		@dg_valor_servico 		decimal(14,2), 
		@dg_valor_credito 		decimal(15,2), 
		@dg_valor_devolucao 		decimal(14,2), 
		@dg_valor_saldo_credito 	decimal(14,2), 
		@dg_valor_saldo_debito 		decimal(14,2), 
		@dg_valor_ir 			decimal(14,2), 
		@dg_valor_csll 			decimal(14,2), 
		@dg_valor_pis 			decimal(14,2), 
		@dg_valor_cofins 		decimal(14,2), 
		@dg_leitura_agente 		int, 
		@dg_forma_entrega 		int, 
		@dg_data_leitura 		datetime, 
		@dg_vias 			int, 
		@dg_motivo_nao_faturamento 	int, 
		@dg_agente 			int, 
		@dg_status 			int, 
		@dg_consumo_medido 		int, 
		@dg_consumo_faturado_res 	int, 
		@dg_consumo_faturado_com 	int, 
		@dg_consumo_faturado_ind 	int, 
		@dg_consumo_faturado_pub 	int, 
		@dg_consumo_faturado_soc 	int, 
		@dg_consumo_faturado_ea 	int, 
		@dg_consumo_ajustado_esg 	int, 
		@dg_consumo_medido_esg 		int, 
		@dg_consumo_faturado_esg_res 	int, 
		@dg_consumo_faturado_esg_com 	int, 
		@dg_consumo_faturado_esg_ind 	int, 
		@dg_consumo_faturado_esg_pub 	int, 
		@dg_consumo_faturado_esg_soc 	int, 
		@dg_consumo_faturado_esg_ea 	int, 
		@dg_consumo_rateado_esg 	int, 
		@dg_flag_fraude 		char(1), 
		@dg_flag_faturado 		char(1), 
		@dg_flag_lido 			char(1), 
		@cg_valor_credito		decimal(12,2),
		@cg_ident_consumidor		int,
		@cg_matricula_pai		int,
		@dg_consumo_faturado 		int

	declare	@ac_ind_dado_alterado      	int,
		@ac_des_conteudo_anterior  	varchar(40),
		@ac_des_conteudo_novo      	varchar(40),
		@ac_tipo                   	int

	declare	@cg_ident_calculo		varchar(1), 
		@cg_flag_calcula_conta		varchar(1),
		@cg_flag_troca			varchar(1)

	-- --------------------------
	-- Inicializa dados
	select	@dg_chave   	 = @parChave,
		@dg_grupo        = @parGrupo,
		@RoteiroIni      = @parRoteiro,
		@RoteiroFim      = @parRoteiro,
		@Rota		 = convert(int, substring(convert(varchar, @parRoteiro),5,3)),
		@dg_referencia   = @parReferencia, 
		@cod_referencia  = convert(char(7), @parReferencia, 102)

	-- **********************************************
	-- Atualiza tabela de processamento
	update	OnPlaceSaned_movimento..ACQ_GRUPO_FATURA_CRONOGRAMA
	set	ind_validado   = 'N'
	,	ind_processado = 'N'
	where	seq_roteiro    = @parRoteiro
	and	cod_referencia = @cod_referencia

	-- -------------------------------
	-- Busca toda a movimentação
	declare	CUR_MOVIMENTO CURSOR read_only for
	SELECT 	cod_referencia, seq_roteiro, seq_matricula, 
		cod_agente, cod_hidrometro, isnull(seq_tipo_entrega,0), 
		val_leitura_anterior, val_leitura_real, val_leitura_atribuida, val_numero_leituras, 
		ind_leitura_divergente, val_consumo_medido, val_consumo_medio, 
		val_consumo_atribuido, val_consumo_troca, val_consumo_rateado, des_banco_debito, 
		des_banco_agencia_debito, dat_leitura, dat_proxima_leitura, dat_vencimento, 
		dat_leitura_anterior, ind_entrega_especial, val_quantidade_pendente, isnull(val_desconto,0), 
		ind_motivo_retirada, dat_troca, ind_situacao_movimento, isnull(ind_fatura_emitida,'N'), 
		isnull(val_arredonda_anterior,0), isnull(val_impressoes,0)
	FROM 	OnPlaceSaned_movimento..ONP_MOVIMENTO
	where	seq_roteiro between @RoteiroIni and @RoteiroFim
	and	cod_referencia = @cod_referencia

	-- CHAMA O CURSOR MOVIMENTO
	OPEN 	CUR_MOVIMENTO
	FETCH 	NEXT 
	FROM 	CUR_MOVIMENTO
	INTO 	@mv_cod_referencia,
		@mv_seq_roteiro,
		@mv_seq_matricula,
		@mv_cod_agente,
		@mv_cod_hidrometro,
		@mv_seq_tipo_entrega,
		@mv_val_leitura_anterior,
		@mv_val_leitura_real,
		@mv_val_leitura_atribuida,
		@mv_val_numero_leituras,
		@mv_ind_leitura_divergente,
		@mv_val_consumo_medido,
		@mv_val_consumo_medio,
		@mv_val_consumo_atribuido,
		@mv_val_consumo_troca,
		@mv_val_consumo_rateado,
		@mv_des_banco_debito,
		@mv_des_banco_agencia_debito,
		@mv_dat_leitura,
		@mv_dat_proxima_leitura,
		@mv_dat_vencimento,
		@mv_dat_leitura_anterior,
		@mv_ind_entrega_especial,
		@mv_val_quantidade_pendente,
		@mv_val_desconto,
		@mv_ind_motivo_retirada,
		@mv_dat_troca,
		@mv_ind_situacao_movimento,
		@mv_ind_fatura_emitida,
		@mv_val_arredonda_anterior,
		@mv_val_impressoes

	-- Consumo estimado retirado
	select @mv_val_consumo_estimado     = 0
	select @mv_val_consumo_estimado_esg = 0

	select @dg_motivo_nao_faturamento   = 0

	-- LOOP CURSOR MOVIMENTO
	WHILE (@@fetch_status <> -1)
	BEGIN

		-- ------------------------------
		-- Inicializa variáveis
		select 	@seq_roteiro    = @mv_seq_roteiro,
			@cod_referencia = @mv_cod_referencia,
			@seq_matricula  = @mv_seq_matricula

		-- -------------------------------
		-- Busca dados da fatura atual	
		select	@ExisteFat         	  = count(*),
			@seq_fatura               = isnull(max(isnull(seq_fatura,0)),0), 
			@seq_tipo_entrega         = isnull(max(isnull(seq_tipo_entrega, 0)),0), 
			@ind_fatura_emitida       = max(isnull(ind_fatura_emitida,'N')), 	
			@dat_vencimento           = max(dat_vencimento), 
			@val_arredonda_anterior   = isnull(max(isnull(val_arredonda_anterior,0)),0), 
			@val_arredonda_atual      = isnull(max(isnull(val_arredonda_atual,0)),0), 
			@dat_hora_emissao         = max(isnull(dat_hora_emissao, isnull(dat_leitura,@dataaux))), 
			@val_valor_faturado       = isnull(max(isnull(val_valor_faturado,0)),0), 
			@dat_leitura              = max(isnull(dat_leitura,@dataaux)), 
			@dat_leitura_anterior     = max(dat_leitura_anterior), 
			@ind_entrega_especial     = max(ind_entrega_especial), 
			@des_banco_debito         = max(isnull(des_banco_debito,'')), 
			@des_banco_agencia_debito = max(isnull(des_banco_agencia_debito,'')), 
			@val_quantidade_pendente  = isnull(max(isnull(val_quantidade_pendente,0)),0), 
			@val_consumo_medio        = isnull(max(isnull(val_consumo_medio,0)),0), 
			@val_consumo_rateado      = isnull(max(isnull(val_consumo_rateado,0)),0),
			@val_desconto             = isnull(max(isnull(val_desconto,0)),0), 
			@des_linha_digitavel      = max(isnull(des_linha_digitavel,'')), 
			@des_codigo_barras        = max(isnull(des_codigo_barras,'')),
			@val_impressoes           = isnull(max(isnull(val_impressoes,0)),0),
			@val_valor_credito        = isnull(max(isnull(val_valor_credito,0)),0)
		from	OnPlaceSaned_movimento..ONP_FATURA
		where	seq_matricula  = @mv_seq_matricula
		and	cod_referencia = @mv_cod_referencia
		and	seq_fatura = 0


		-- --------------------------------
		-- Caso não tenha encontrado a fatura
		if @ExisteFat = 0 begin
			select	@dat_vencimento     	  = @mv_dat_vencimento, 
				@dat_leitura              = @mv_dat_leitura, 
				@dat_leitura_anterior     = @mv_dat_leitura_anterior, 
				@dat_hora_emissao         = @mv_dat_leitura, 
				@seq_tipo_entrega         = @mv_seq_tipo_entrega,
				@ind_fatura_emitida	  = 'N',
				@dat_hora_emissao         = 0, 
				@val_impressoes           = 0
		end

		select @dtAtual = getdate()
		if     @dat_leitura > @dtAtual begin
		       Select @dat_leitura = convert(datetime, convert(char(8), @dtAtual, 112) )
		end

		declare @dgaux_estimado decimal(7),
			@dg_aux_taxa	decimal(5)

		-- ---------------------------
		-- Busca as volumes estimado
		declare CUR_EST_VOLUME CURSOR read_only for
		select	seq_taxa, sum(isnull(val_consumo_estimado,0))
		from	OnPlaceSaned_movimento.dbo.ONP_MOVIMENTO_TAXA
		where	seq_matricula  = @seq_matricula	 
		and	cod_referencia = @cod_referencia 
		and	seq_roteiro    = @seq_roteiro 
		group	by seq_taxa


		-- CHAMA O CURSOR
		OPEN 	CUR_EST_VOLUME
		FETCH 	NEXT 
		FROM 	CUR_EST_VOLUME
		into	@dg_aux_taxa,
			@dgaux_estimado

		-- LOOP CURSOR SERVICO
		WHILE (@@fetch_status <> -1)
		BEGIN

			If  @dg_aux_taxa = 1 /*1	ÁGUA */
	   		    Select  @mv_val_consumo_estimado = isnull(@dgaux_estimado,0)

			Else /* 2 ESGOTO */
	   		    Select  @mv_val_consumo_estimado_esg = isnull(@dgaux_estimado,0)

			-- Proximo
			FETCH 	NEXT 
			FROM 	CUR_EST_VOLUME
			into	@dg_aux_taxa,
				@dgaux_estimado
		END

		-- Fecha o cursor ocorrência
		CLOSE CUR_EST_VOLUME
		DEALLOCATE CUR_EST_VOLUME
		
		-- ------------------------------------------------
		-- Inicializa informações nas variáveis do Descarga
		-- Inicializa com NULO
		-- Inicializa com Valores
		select	@dg_setor	                = cg_setor, 
			@dg_rota                        = cg_rota, 
			@dg_matricula                   = @mv_seq_matricula, 
			@dg_data_leitura                = @dat_leitura, 
			@dg_dias_consumo                = datediff(d, @mv_dat_leitura_anterior, @mv_dat_leitura),
			@dg_vias                        = case	when @mv_ind_situacao_movimento in ('R', 'P') then 3
								when @mv_ind_situacao_movimento in ('L', 'C') then 4
								when @mv_ind_situacao_movimento = 'N' then 0
								else case	when @val_impressoes is null then 3
										when @val_impressoes > 1 then 2 
										else 1 
										end
								end, 
			@dg_flag_calculada 		= case 	when (@mv_ind_situacao_movimento in ('C', 'F' )) and (@ExisteFat > 0) then 'S' else 'N' end,
			@dg_flag_emitida 		= case 	when (@mv_ind_situacao_movimento = 'F') and (isnull(@val_impressoes,0) > 0) and (@ExisteFat > 0) then 'S' else 'N' end,
			@dg_leitura_real                = case	when (@mv_val_leitura_atribuida > 0) and (@mv_val_leitura_real = 0) then @mv_val_leitura_atribuida
								when @mv_val_leitura_real > 0 then @mv_val_leitura_real 
								else 0 
								end, 
			@dg_consumo_medido              = case	when (@mv_val_consumo_atribuido > 0) and (@mv_val_consumo_medido = 0) then @mv_val_consumo_atribuido 
								when @mv_val_consumo_estimado > 0 then @mv_val_consumo_estimado 
								when @mv_val_consumo_medido > 0 then @mv_val_consumo_medido 
								else 0 
								end,  
			@dg_consumo_medido_esg 	        = case	when (@mv_val_consumo_atribuido > 0) and (@mv_val_consumo_medido = 0) then @mv_val_consumo_atribuido 
								when @mv_val_consumo_estimado_esg > 0 then @mv_val_consumo_estimado_esg 
								when @mv_val_consumo_medido > 0 then @mv_val_consumo_medido 
								else 0 
								end,  
			@dg_consumo_rateado 		= isnull(@mv_val_consumo_rateado, 0),
			@dg_agente              	= @mv_cod_agente, 
			@dg_referencia 			= @parReferencia, 
			@dg_leitura_ajustada 		= isnull( @mv_val_leitura_atribuida, @mv_val_leitura_real), 
			@dg_consumo_ajustado_esg 	= isnull( @mv_val_consumo_atribuido, case when (@mv_val_consumo_atribuido > 0) and (@mv_val_consumo_medido = 0) then @mv_val_consumo_atribuido 
								when @mv_val_consumo_estimado_esg > 0 then @mv_val_consumo_estimado_esg 
								when @mv_val_consumo_medido > 0 then @mv_val_consumo_medido 
								else 0 
								end),
			@dg_consumo_ajustado 		= isnull( @mv_val_consumo_atribuido, case when (@mv_val_consumo_atribuido > 0) and (@mv_val_consumo_medido = 0) then @mv_val_consumo_atribuido 
								when @mv_val_consumo_estimado > 0 then @mv_val_consumo_estimado 
								when @mv_val_consumo_medido > 0 then @mv_val_consumo_medido 
								else 0 
								end),
			@dg_forma_entrega               = isnull(@seq_tipo_entrega, 7),
			@dg_flag_fraude 		= 'N',
			@dg_flag_faturado 		= case 	when @ExisteFat > 0 then 'S' else 'N' end,
			@dg_flag_lido 			= case	when @mv_ind_situacao_movimento = 'P' then 'N' else 'S' end,
			@dg_situacao_consumo 		= 1,
			@dg_ocorrencia 			= NULL,
			@dg_ocorrencia2 		= NULL,
			@dg_flag_cortado 		= 'N',
			@dg_flag_aviso 			= 'N',
			@dg_valor_agua  		= 0,
			@dg_valor_esgoto  		= 0,
			@dg_valor_servico  		= 0,
			@dg_valor_credito  		= 0,
			@dg_valor_devolucao  		= isnull(@val_desconto,0),
			@dg_valor_ir  			= 0,
			@dg_valor_csll  		= 0,
			@dg_valor_pis  			= 0,
			@dg_valor_cofins  		= 0,
			@dg_valor_saldo_credito  	= case when isnull(@val_valor_credito,0) < 0 then @val_valor_credito*(-1) else 0 end,
			@dg_valor_saldo_debito  	= case when isnull(@val_valor_credito,0) > 0 then @val_valor_credito else 0 end,
			@dg_leitura_agente 		= 0,
			@dg_agente 			= @mv_cod_agente,
			@dg_status 			= case	when @mv_ind_situacao_movimento = 'P' then 0
								when @mv_ind_situacao_movimento = 'L' then 1
								when @mv_ind_situacao_movimento = 'C' then 2
								when @mv_ind_situacao_movimento = 'R' then 4
								when (@mv_ind_situacao_movimento = 'F') and (isnull(@val_impressoes,0) = 0) and (cg_flag_emite_conta = 'S') then 5
								else 5
								end, 
			@dg_consumo_faturado		= 0,
			@dg_consumo_faturado_res 	= 0,
			@dg_consumo_faturado_com 	= 0,
			@dg_consumo_faturado_ind 	= 0,
			@dg_consumo_faturado_pub 	= 0,
			@dg_consumo_faturado_soc 	= 0,
			@dg_consumo_faturado_ea 	= 0,
			@dg_consumo_faturado_esg_res 	= 0,
			@dg_consumo_faturado_esg_com 	= 0,
			@dg_consumo_faturado_esg_ind 	= 0,
			@dg_consumo_faturado_esg_pub 	= 0,
			@dg_consumo_faturado_esg_soc 	= 0,
			@dg_consumo_faturado_esg_ea 	= 0,
			@dg_consumo_rateado_esg 	= 0,
			@cg_ident_calculo		= isnull(cg_ident_calculo, '' ),
			@cg_ident_consumidor		= cg_ident_consumidor,
			@cg_matricula_pai		= cg_matricula_pai,
			@cg_flag_calcula_conta          = isnull(cg_flag_calcula_conta, 'N'),
			@cg_flag_troca			= isnull(cg_flag_troca, 'N')
		from	OnPlaceSaned..carga
		where	cg_grupo     = @dg_grupo
		and	cg_matricula = @mv_seq_matricula

		if @cg_ident_consumidor = 2 begin
			if @dg_matricula = @cg_matricula_pai begin
				select	@dg_consumo_rateado 	= 0,
					@dg_consumo_rateado_esg	= 0
			end
			else begin
				select	@dg_leitura_ajustada	 = @dg_consumo_rateado,
					@dg_consumo_ajustado_esg = @dg_consumo_rateado_esg

				select	@dg_consumo_rateado 	 = 0,
					@dg_consumo_rateado_esg	 = 0
			end
		end

		if @cg_flag_calcula_conta = 'S' begin
			select	@dg_valor_servico = isnull( sum( isnull(sr_valor,0) ), 0 )
			from	OnPlaceSaned..servicos
			where	sr_grupo     = @dg_grupo
			and	sr_matricula = @mv_seq_matricula

			select	@dg_valor_credito = isnull( sum( isnull(cr_valor,0) ), 0 )
			from	OnPlaceSaned..creditos
			where	cr_grupo     = @dg_grupo
			and	cr_matricula = @mv_seq_matricula
		end 
		else if @cg_flag_calcula_conta = 'N' begin
			if (@dg_status = 4) and (@dg_vias = 3)
			begin
				set	@dg_status = 5
			end
			if (@cg_ident_calculo = 'B') and (@dg_vias = 3)
			begin
				set	@dg_status = 5
				set	@dg_vias = 4	
				set	@dg_flag_emitida = 'N'
			end
		end

		if (@dg_flag_faturado = 'N') and (@dg_flag_calculada = 'S')
		begin
			set 	@dg_flag_calculada = 'N'
		end

		-- --------------------
		-- Verifica se foi emitido o aviso de débito
		select	@ExisteAd       = count(*), 
			@ad_impressoes  = isnull(max(val_impressoes), 0), 
			@ad_protocolado = isnull(max(ind_protocolado), 'N')
		from	OnPlaceSaned_movimento..ONP_AVISO_DEBITO
		where	seq_matricula = @mv_seq_matricula 

		if @ExisteAd > 0 begin
			Select @dg_flag_aviso = 'S'
		end

			
		declare	@dgaux_valor	decimal(14,2),
			@dgaux_volume	integer,
			@dgaux_categ 	integer

		select	@dg_valor_agua       = 0
		select	@dg_valor_esgoto     = 0
		select	@dg_consumo_faturado = 0

		-- ---------------------------
		-- Busca as volumes e valores de ÁGUA
		declare CUR_TAXA_FAT CURSOR read_only for
		select	isnull(FT.val_valor_faturado,0), 
			isnull(FT.val_consumo_faturado,0), 
			FT.seq_categoria
		from	OnPlaceSaned_movimento.dbo.ONP_FATURA_TAXA FT	 	
		where	FT.seq_matricula  = @seq_matricula	 
		and	FT.cod_referencia = @cod_referencia 
		and	FT.seq_roteiro    = @seq_roteiro 
		and	seq_taxa          = 1 -- ÁGUA
		ORDER BY FT.seq_categoria
			
		-- CHAMA O CURSOR
		OPEN 	CUR_TAXA_FAT
		FETCH 	NEXT 
		FROM 	CUR_TAXA_FAT
		into	@dgaux_valor,
			@dgaux_volume,
			@dgaux_categ

		-- LOOP CURSOR SERVICO
		WHILE (@@fetch_status <> -1)
		BEGIN

			select	@dg_valor_agua = @dg_valor_agua + @dgaux_valor
			select  @dg_consumo_faturado = @dg_consumo_faturado + @dgaux_volume

			If  @dgaux_categ = 1 /*1 Residencial */
	   		    Select  @dg_consumo_faturado_res = @dgaux_volume

			Else If  @dgaux_categ = 2 /* 2 Comercial*/
	   		    Select  @dg_consumo_faturado_com = @dgaux_volume

			Else If  @dgaux_categ = 3 /* 3	Industrial*/
	   		    Select  @dg_consumo_faturado_ind = @dgaux_volume

			Else If  @dgaux_categ = 4 /*4	Publica*/
	   		    Select  @dg_consumo_faturado_pub = @dgaux_volume

			Else If  @dgaux_categ = 6 /* 6	Social */
	   		    Select  @dg_consumo_faturado_soc = @dgaux_volume

			Else If  @dgaux_categ = 8 /*8	Entidade Assistencial*/
	   		    Select  @dg_consumo_faturado_ea = @dgaux_volume


			-- Proximo
			FETCH 	NEXT 
			FROM 	CUR_TAXA_FAT
			into	@dgaux_valor,
				@dgaux_volume,
				@dgaux_categ
		END

		-- Fecha o cursor ocorrência
		CLOSE CUR_TAXA_FAT
		DEALLOCATE CUR_TAXA_FAT

		-- ---------------------------
		-- Busca as volumes e valores de ESGOTO
		declare CUR_TAXA_FAT CURSOR read_only for
		select	isnull(FT.val_valor_faturado,0), 
			isnull(FT.val_consumo_faturado,0), 
			FT.seq_categoria
		from	OnPlaceSaned_movimento.dbo.ONP_FATURA_TAXA FT	 	
		where	FT.seq_matricula  = @seq_matricula	 
		and	FT.cod_referencia = @cod_referencia 
		and	FT.seq_roteiro    = @seq_roteiro 
		and	seq_taxa          = 2 -- ESGOTO	
		ORDER BY FT.seq_categoria
			
		-- CHAMA O CURSOR
		OPEN 	CUR_TAXA_FAT
		FETCH 	NEXT 
		FROM 	CUR_TAXA_FAT
		into	@dgaux_valor,
			@dgaux_volume,
			@dgaux_categ

		-- LOOP CURSOR SERVICO
		WHILE (@@fetch_status <> -1)
		BEGIN

			select	@dg_valor_esgoto = @dg_valor_esgoto + @dgaux_valor

			If  @dgaux_categ = 1 /*1	Residencial */
	   		    Select  @dg_consumo_faturado_esg_res = @dgaux_volume

			Else If  @dgaux_categ = 2 /* 2 Comercial*/
	   		    Select  @dg_consumo_faturado_esg_com = @dgaux_volume

			Else If  @dgaux_categ = 3 /* 3	Industrial*/
	   		    Select  @dg_consumo_faturado_esg_ind = @dgaux_volume

			Else If  @dgaux_categ = 4 /*4	Publica*/
	   		    Select  @dg_consumo_faturado_esg_pub = @dgaux_volume

			Else If  @dgaux_categ = 6 /* 6	Social */
	   		    Select  @dg_consumo_faturado_esg_soc = @dgaux_volume

			Else If  @dgaux_categ = 8 /*8	Entidade Assistencial*/
	   		    Select  @dg_consumo_faturado_esg_ea = @dgaux_volume


			-- Proximo
			FETCH 	NEXT 
			FROM 	CUR_TAXA_FAT
			into	@dgaux_valor,
				@dgaux_volume,
				@dgaux_categ
		END

		-- Fecha o cursor ocorrência
		CLOSE CUR_TAXA_FAT
		DEALLOCATE CUR_TAXA_FAT

		-- ---------------------------
		-- Busca as Serviços Faturados
		declare CUR_SERVICO_FAT CURSOR read_only for
		select	isnull(FS.ind_credito,'D'), FS.val_parcela
		from	OnPlaceSaned_movimento..ONP_FATURA_SERVICO FS
		where	FS.seq_matricula  = @seq_matricula
		and		FS.cod_referencia = @cod_referencia
		and		FS.seq_roteiro    = @seq_roteiro
		order	by seq_item_servico
			
		-- CHAMA O CURSOR
		OPEN 	CUR_SERVICO_FAT
		FETCH 	NEXT 
		FROM 	CUR_SERVICO_FAT
		INTO 	@sf_ind_credito, 
			@sf_val_parcela

		set @nLinha = 0

		-- LOOP CURSOR SERVICO
		WHILE (@@fetch_status <> -1)
		BEGIN


			if @nLinha = 0 begin
				select	@dg_valor_servico  = 0,
					@dg_valor_credito  = 0
			end
			select @nLinha = (@nLinha + 1)

			if @sf_ind_credito = 'C' begin
				select @dg_valor_credito = (@dg_valor_credito + ABS(@sf_val_parcela)) 
			end
			else begin
				select @dg_valor_servico = (@dg_valor_servico + ABS(@sf_val_parcela)) 
			end

			-- Proximo
			FETCH 	NEXT 
			FROM 	CUR_SERVICO_FAT
			INTO 	@sf_ind_credito, 
				@sf_val_parcela
		END

		-- Fecha o cursor ocorrência
		CLOSE CUR_SERVICO_FAT
		DEALLOCATE CUR_SERVICO_FAT


		-- Verifica se há Saldo de Crédito e se houve cobrança de crédito
		if (@dg_valor_credito > @dg_valor_saldo_credito) and (@dg_valor_saldo_credito > 0) begin
			select @dg_valor_credito = (@dg_valor_credito - @dg_valor_saldo_credito) 
		end

		-- Trata o saldo de crédito
		select 	@cg_valor_credito = isnull(sum(isnull(cr_valor,0)),0)
		from	OnPlaceSaned..carga, OnPlaceSaned..creditos
		where	cg_grupo = @parGrupo
		and	cg_matricula = @seq_matricula
		and	cr_grupo = cg_grupo
		and	cr_matricula = cg_matricula

		if (@cg_valor_credito > 0) and (@dg_valor_credito > 0) begin
			select @dg_valor_saldo_credito = (@cg_valor_credito - @dg_valor_credito)
			if @dg_valor_saldo_credito < 0 begin
				select @dg_valor_saldo_credito = 0
			end 
		end

		-- ---------------------------
		-- Busca os Impostos Faturados
		declare CUR_IMPOSTOS_FAT CURSOR read_only for
		select	cod_imposto, val_valor_calculado
		from	OnPlaceSaned_Movimento..ONP_FATURA_IMPOSTO_DIADEMA
		where	seq_matricula  = @seq_matricula
		and	cod_referencia = @cod_referencia
		and	seq_roteiro    = @seq_roteiro
			
		-- CHAMA O CURSOR
		OPEN 	CUR_IMPOSTOS_FAT
		FETCH 	NEXT 
		FROM 	CUR_IMPOSTOS_FAT
		INTO 	@fi_codigo, 
			@fi_val_imposto

		-- LOOP CURSOR SERVICO
		WHILE (@@fetch_status <> -1)
		BEGIN

			if @fi_codigo = 'IRRF' begin
				select @dg_valor_ir = ABS(@fi_val_imposto)
			end
			else if @fi_codigo = 'CSLL' begin
				select @dg_valor_csll = ABS(@fi_val_imposto)
			end
			else if @fi_codigo = 'PIS' begin
				select @dg_valor_pis = ABS(@fi_val_imposto)
			end
			else if @fi_codigo = 'COFINS' begin
				select @dg_valor_cofins = ABS(@fi_val_imposto)
			end

			-- Proximo
			FETCH 	NEXT 
			FROM 	CUR_IMPOSTOS_FAT
			INTO 	@fi_codigo, 
				@fi_val_imposto
		END

		-- Fecha o cursor ocorrência
		CLOSE CUR_IMPOSTOS_FAT
		DEALLOCATE CUR_IMPOSTOS_FAT
		
		-- --------------------
		-- Busca as Ocorrências	
		set	@Cont_Ocorr = 0

		declare CUR_OCORRENCIA_EMITIDAS CURSOR read_only for
		select	cod_ocorrencia
		from	OnPlaceSaned_movimento..ONP_MOVIMENTO_OCORRENCIA
		where	seq_matricula  = @seq_matricula
		and	cod_referencia = @cod_referencia

		-- CHAMA O CURSOR
		OPEN 	CUR_OCORRENCIA_EMITIDAS
		FETCH 	NEXT 
		FROM 	CUR_OCORRENCIA_EMITIDAS
		INTO 	@cod_ocorrencia

		-- LOOP CURSOR SERVICO
		WHILE (@@fetch_status <> -1)
		BEGIN
			-- Incrementa contador
			set	@Cont_Ocorr = (@Cont_Ocorr+1)

			-- Verifica qual ocorrência lançar
			if @Cont_Ocorr = 1 begin
				select @dg_ocorrencia  = OnPlaceSaned.DBO.FC_COMPLETA_ZEROS( IsNull(@cod_ocorrencia,0), 2)

				select	@dg_situacao_consumo = 	
						isnull(max(case 	when (isnull(oc_calculo,0) = 2) then 07
									when (isnull(oc_calculo,0) = 7) and (@dg_leitura_real = 0) then 07
									when (isnull(oc_calculo,0) = 8) and (@dg_leitura_real = 0) then 99
									else 1
									end),1)
				from	OnPlaceSaned..Ocorrencias
				where 	oc_grupo = @parGrupo
				and	oc_codigo = @dg_ocorrencia
			end
			else if @Cont_Ocorr = 2 begin
				select @dg_ocorrencia2 = OnPlaceSaned.DBO.FC_COMPLETA_ZEROS( IsNull(@cod_ocorrencia,0), 2)
			end
			-- Proximo
			FETCH 	NEXT 
			FROM 	CUR_OCORRENCIA_EMITIDAS
			INTO 	@cod_ocorrencia
		END

		-- Fecha o cursor ocorrência
		CLOSE CUR_OCORRENCIA_EMITIDAS
		DEALLOCATE CUR_OCORRENCIA_EMITIDAS

                -- -------------------------
		-- Verifica a troca
		if (@dg_ocorrencia = 71) and 
                   (@cg_flag_troca = 'S') and 
                   (@dg_leitura_ajustada > @dg_leitura_real) begin
			select @dg_leitura_ajustada = @dg_leitura_real
		end

		-- -------------------------
		-- Busca as Faturas emitidas	
		insert	into OnPlaceSaned..descarga_seg_vias
			(ds_grupo, ds_setor, ds_rota, ds_referencia, ds_matricula, 
			 ds_referencia_seg_via, ds_data_emissao )
		select	cg_grupo, cg_setor, cg_rota, cg_referencia, cg_matricula, 
			convert(datetime, substring(cod_referencia, 1, 4) + substring(cod_referencia, 6, 2) + '01'), 
			isnull(val_impressoes, 1)
		from	OnPlaceSaned_movimento..ONP_FATURA,
			OnPlaceSaned..carga
		where	isnull(ind_fatura_emitida, 'N') = 'S'
		and	seq_matricula = @seq_matricula
		and	cod_referencia < @cod_referencia
		and	cg_grupo      = @dg_grupo
		and	cg_referencia = @dg_referencia
		and 	cg_matricula  = seq_matricula

		-- ------------------------------
		-- Busca as Alterações Cadastrais
		-- Apaga
		delete 	from OnPlaceSaned..descarga_alteracoes
		where 	al_grupo      = @dg_grupo
		and	al_referencia = @dg_referencia
		and 	al_matricula  = @dg_matricula

		-- Busca 
		declare CUR_ALTERACAO_CADASTRO CURSOR read_only for
		select	case 	when ind_dado_alterado = 'OB' then 8
				when ind_dado_alterado = 'NM' then 7
				when ind_dado_alterado = 'CT' then 5
				when ind_dado_alterado = 'CP' then 4
				when ind_dado_alterado = 'LG' then 3
				when ind_dado_alterado = 'NI' then 2
				when ind_dado_alterado = 'HD' then 1
			else 0
			end, 
			des_conteudo_anterior, des_conteudo_novo
		from	OnPlaceSaned_movimento..ONP_MATRICULA_ALTERACAO
		where	seq_matricula = @seq_matricula
		order	by seq_item

		-- CHAMA O CURSOR
		OPEN 	CUR_ALTERACAO_CADASTRO
		FETCH 	NEXT 
		FROM 	CUR_ALTERACAO_CADASTRO
		INTO 	@ac_ind_dado_alterado, 
			@ac_des_conteudo_anterior, 
			@ac_des_conteudo_novo

		-- LOOP CURSOR SERVICO
		WHILE (@@fetch_status <> -1)
		BEGIN
			-- Inseri alterações
			insert into OnPlaceSaned..descarga_alteracoes
				(al_grupo, al_referencia, al_matricula, 
				 al_agente, al_rota, al_datahora, 
				 al_tipo, al_descricao)
			values	(@dg_grupo, @dg_referencia, @dg_matricula, 
				 @dg_agente, @dg_rota, @dg_data_leitura, 
				 @ac_ind_dado_alterado,  @ac_des_conteudo_novo)

			-- Proximo
			FETCH 	NEXT 
			FROM 	CUR_ALTERACAO_CADASTRO
			INTO 	@ac_ind_dado_alterado, 
				@ac_des_conteudo_anterior, 
				@ac_des_conteudo_novo
		END

		-- Fecha o cursor ocorrência
		CLOSE CUR_ALTERACAO_CADASTRO
		DEALLOCATE CUR_ALTERACAO_CADASTRO

		-- ---------------------------
		-- Inseri os dados no Descarga
		begin tran
			-- delete
			delete 	from OnPlaceSaned..descarga
			where	dg_grupo      = @dg_grupo
			and	dg_referencia = @dg_referencia
			and	dg_matricula  = @dg_matricula

			-- inseri no descarga
			INSERT INTO OnPlaceSaned.dbo.descarga
				(dg_grupo, dg_setor, dg_rota, dg_referencia, dg_matricula, 
				 dg_leitura_ajustada, dg_leitura_real, 
				 dg_consumo_ajustado, dg_consumo_rateado, dg_consumo_medido, 
				 dg_consumo_ajustado_esg, dg_consumo_medido_esg, dg_consumo_rateado_esg, 
				 dg_situacao_consumo, 
				 dg_dias_consumo, dg_ocorrencia, dg_ocorrencia2, 
				 dg_flag_calculada, dg_flag_emitida, dg_flag_cortado, dg_flag_aviso, 
				 dg_flag_fraude, dg_flag_faturado, dg_flag_lido, 
				 dg_valor_agua, dg_valor_esgoto, dg_valor_servico, dg_valor_credito, dg_valor_saldo_credito, 
				 dg_valor_devolucao, dg_valor_saldo_debito, 	
				 dg_valor_ir, dg_valor_csll, dg_valor_pis, dg_valor_cofins, 
				 dg_leitura_agente, dg_forma_entrega, dg_data_leitura, 
				 dg_vias, dg_motivo_nao_faturamento, dg_agente, dg_status, 
				 dg_consumo_faturado_res, dg_consumo_faturado_com, dg_consumo_faturado_ind, dg_consumo_faturado_pub, dg_consumo_faturado_soc, dg_consumo_faturado_ea, 
				 dg_consumo_faturado_esg_res, dg_consumo_faturado_esg_com, dg_consumo_faturado_esg_ind, dg_consumo_faturado_esg_pub, dg_consumo_faturado_esg_soc, dg_consumo_faturado_esg_ea)
			values	(@dg_grupo, @dg_setor, @dg_rota, @dg_referencia, @dg_matricula, 
				 @dg_leitura_ajustada, @dg_leitura_real, 
				 @dg_consumo_ajustado, @dg_consumo_rateado, @dg_consumo_medido, 
				 @dg_consumo_ajustado_esg, @dg_consumo_medido_esg, @dg_consumo_rateado_esg, 
				 @dg_situacao_consumo, @dg_dias_consumo, @dg_ocorrencia, @dg_ocorrencia2, 
				 @dg_flag_calculada, @dg_flag_emitida, @dg_flag_cortado, @dg_flag_aviso, 
				 @dg_flag_fraude, @dg_flag_faturado, @dg_flag_lido, 
				 @dg_valor_agua, @dg_valor_esgoto, @dg_valor_servico, @dg_valor_credito, @dg_valor_saldo_credito, 
				 @dg_valor_devolucao, @dg_valor_saldo_debito, 	
				 @dg_valor_ir, @dg_valor_csll, @dg_valor_pis, @dg_valor_cofins, 
				 @dg_leitura_agente, @dg_forma_entrega, @dg_data_leitura, 
				 @dg_vias, @dg_motivo_nao_faturamento, @dg_agente, @dg_status, 
				 @dg_consumo_faturado_res, @dg_consumo_faturado_com, @dg_consumo_faturado_ind, @dg_consumo_faturado_pub, @dg_consumo_faturado_soc, @dg_consumo_faturado_ea, 
				 @dg_consumo_faturado_esg_res, @dg_consumo_faturado_esg_com, @dg_consumo_faturado_esg_ind, @dg_consumo_faturado_esg_pub, @dg_consumo_faturado_esg_soc, @dg_consumo_faturado_esg_ea)

		commit

		-- Proximo
		FETCH 	NEXT 
		FROM 	CUR_MOVIMENTO
		INTO 		@mv_cod_referencia,
				@mv_seq_roteiro,
				@mv_seq_matricula,
				@mv_cod_agente,
				@mv_cod_hidrometro,
				@mv_seq_tipo_entrega,
				@mv_val_leitura_anterior,
				@mv_val_leitura_real,
				@mv_val_leitura_atribuida,
				@mv_val_numero_leituras,
				@mv_ind_leitura_divergente,
				@mv_val_consumo_medido,
				@mv_val_consumo_medio,
				@mv_val_consumo_atribuido,
				@mv_val_consumo_troca,
				@mv_val_consumo_rateado,
				@mv_des_banco_debito,
				@mv_des_banco_agencia_debito,
				@mv_dat_leitura,
				@mv_dat_proxima_leitura,
				@mv_dat_vencimento,
				@mv_dat_leitura_anterior,
				@mv_ind_entrega_especial,
				@mv_val_quantidade_pendente,
				@mv_val_desconto,
				@mv_ind_motivo_retirada,
				@mv_dat_troca,
				@mv_ind_situacao_movimento,
				@mv_ind_fatura_emitida,
				@mv_val_arredonda_anterior,
				@mv_val_impressoes
	END

	-- Fecha o cursor ocorrência
	CLOSE CUR_MOVIMENTO
	DEALLOCATE CUR_MOVIMENTO

	-- AVISO DE DÉBITO
	update	OnPlaceSaned..descarga
	Set	@dg_flag_aviso    =  (SELECT  case when isnull(val_impressoes,0) = 0 
				      then 'N' else 'S' end) 
	from	OnPlaceSaned_Movimento..onp_aviso_debito
	where	dg_grupo = @parGrupo
	and	dg_rota = @Rota
	and	dg_matricula = seq_matricula

	-- Atualiza tabela de processamento
	update	OnPlaceSaned_movimento..ACQ_GRUPO_FATURA_CRONOGRAMA
	set		ind_validado   = 'S' 	
	,		ind_processado = 'S'
	where		seq_roteiro    = @parRoteiro
	and		cod_referencia = @cod_referencia

	-- Finaliza roteiro	
	update OnPlaceSaned..roteiros 
	set	rt_ind_leitura 	= 3
	where 	rt_grupo       = @parGrupo
	and 	rt_rota        = @Rota
	
end

GO
