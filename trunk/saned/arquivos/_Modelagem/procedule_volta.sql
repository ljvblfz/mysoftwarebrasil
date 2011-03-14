insert into DIADEMA_IV.dbo.VOLTA_LOG_ATENDIMENTO 
	(
		grupo,
		CDC,
		Tipo,
		Referencia,
		Data_Emissao,
		Operador
	)
	(
		SELECT DISTINCT
			R.seq_grupo_fatura as Grupo
			,O.seq_matricula as CDC
			,'S'as Tipo
			,convert(datetime, substring(O.cod_referencia, 1, 4) + substring(O.cod_referencia, 6, 2) + '01')
			,O.dat_leitura as Data_Emissao
			,M.cod_agente as Operador
		FROM 
			ONP_FATURA O,
			ONP_ROTEIRO R,
			ONP_MOVIMENTO M
		WHERE	
			---O.ind_fatura_emitida = 'S'
			--AND 
			O.seq_roteiro = R.seq_roteiro
			AND R.seq_roteiro = M.seq_roteiro
			AND M.dat_leitura is not null
			AND O.cod_hidrometro is not null
		/*
		SELECT
			R.seq_grupo_fatura,
			O.seq_matricula,
			'S',
			O.ind_fatura_emitida--,
			--convert(datetime, substring(O.cod_referencia, 1, 4) + substring(O.cod_referencia, 6, 2) + '01'),
			--isnull(O.val_impressoes, 1)
		FROM 
			ONP_FATURA O,
			ONP_ROTEIRO R
		WHERE	
			O.ind_fatura_emitida = 'S'
			AND O.seq_roteiro = R.seq_roteiro
		*/
	)

----------------------------------------------------------------------------------------------------------------------------------------
	
INSERT INTO DIADEMA_IV.dbo.VOLTA_LOG_ATENDIMENTO 
	(
		grupo,
		CDC,
		Tipo,
		Referencia,
		Data_Emissao ,
		Operador
	)
	(
			
		SELECT
			R.seq_grupo_fatura,
			D.seq_matricula_pai,
			'N',
			--@referencia --data valor informado,
			--max(isnull(O.dat_leitura,(convert(datetime, convert(char(8), getdate(), 112))))),
			isnull(O.val_impressoes, 1)--VERIFICAR OPERADOR
		FROM
			ONP_FATURA O,
			ONP_ROTEIRO R,
			ONP_MATRICULA_DIADEMA D,
			ONP_FATURAS_AVISO A,
			ONP_AVISO_DEBITO AD,
			ONP_MATRICULA M
		WHERE
			
			--AND
		/*	(
					CASE WHEN (
								SELECT	
									COUNT(*)
								FROM ONP_AVISO_DEBITO
								WHERE	
									seq_matricula = 1 
							  ) > 0 THEN 'N'
						 ELSE 'S' END
				) = 'S'
			
			and*/ 
			O.seq_roteiro = R.seq_roteiro
			and AD.seq_matricula = M.seq_matricula
			and O.seq_matricula = M.seq_matricula
			and D.seq_matricula = M.seq_matricula
			and AD.ind_documento = 'N'
	)
	
	insert into DIADEMA_IV.dbo.VOLTA_LOG_ATENDIMENTO 
	(
		grupo,
		CDC,
		Tipo,
		Referencia,
		Data_Emissao ,
		Operador
	)
	(
			
		SELECT
			R.seq_grupo_fatura,
			D.seq_matricula_pai,
			'A',
			--@referencia --data valor informado,
			--max(isnull(O.dat_leitura,(convert(datetime, convert(char(8), getdate(), 112))))),
			isnull(O.val_impressoes, 1)--VERIFICAR OPERADOR
		FROM
			ONP_FATURA O,
			ONP_ROTEIRO R,
			ONP_MATRICULA_DIADEMA D,
			ONP_FATURAS_AVISO A,
			ONP_AVISO_DEBITO AD,
			ONP_MATRICULA M
		WHERE
			--AND
		/*	(
					CASE WHEN (
								SELECT	
									COUNT(*)
								FROM ONP_AVISO_DEBITO
								WHERE	
									seq_matricula = 1 
							  ) > 0 THEN 'N'
						 ELSE 'S' END
				) = 'S'
			
			and*/ 
			(
				SELECT  
					case when isnull(AD.val_impressoes,0) = 0 
				      then 'N' 
					  else 'S' 
					 end
			) = 'S'
			and O.seq_roteiro = R.seq_roteiro
			and AD.seq_matricula = M.seq_matricula
			and O.seq_matricula = M.seq_matricula
			and D.seq_matricula = M.seq_matricula
			and AD.ind_documento = 'A'
	)

	insert into DIADEMA_IV.dbo.VOLTA_ROTEIRO
	(
		Referencia,
		Grupo,
		Rota,
		Data_Inicial,
		Data_Final,
		Data_Envio,
		Aparelho,
		Data_Problema,
		Chuva
	)
	(
		select
		F.cod_referencia,
		R.seq_grupo_fatura,
		F.seq_roteiro,
		(
			select 
			min( F.data_leitura ) 
			from ONP_FATURA F 
			where 
			and M.seq_roteiro = R.seq_roteiro 
			and F.data_leitura is not null
		),
		(
			select max( F.data_leitura ) 
			from ONP_FATURA F 
			where 
			and M.seq_roteiro = R.seq_roteiro 
			and F.data_leitura is not null
		),
		getdate(),
		isnull(rt_maleta,0),--verificar
		rt_ind_chuva--verificar
	from roteiros R
	where rt_grupo = :grupo
	and rt_rota = :rota
	
	
		SELECT
		--F.cod_referencia,
		--R.seq_grupo_fatura,
		--F.seq_roteiro,
		(
			SELECT 
				MIN(F.dat_leitura) 
			FROM ONP_FATURA F 
			WHERE 
				F.dat_leitura is not null
		)as t,
		(
			SELECT 
				MAX( F.dat_leitura ) 
			FROM ONP_FATURA F 
			WHERE 
				F.dat_leitura is not null
		) as f
	FROM 
		ONP_FATURA F,
		ONP_ROTEIRO R
	WHERE	
		F.seq_roteiro = R.seq_roteiro
	
	
	
	
-------------------------------------------------------------------------	
	insert into DIADEMA_IV.dbo.VOLTA_LEITURA
	(
	Grupo,
	Setor,
	Rota,
	CDC,--
	Leitura_Ajustada,--
	Leitura_Real,--
	Data_Leitura,
	Consumo_Ajustado,
	consumo_rateado,
	Esgoto_Ajustado,
	Dias_Consumo,
	Ocorrencia,
	Ocorrencia2,
	Ident_fraude,
	Indic_cortado,
	Operador,--
	Flag_Calculo,
	Flag_Emissao,
	Referencia,
	Data_Emissao,
	Vencimento,
	Valor_Agua,
	Valor_Esgoto,
	valor_saldo_debito,
	Valor_Credito,
	Valor_Reducao,
	Valor_IR,
	Valor_CSLL,
	Valor_PIS,
	Valor_COFINS,
	Categoria,
	Eco_Res,
	Eco_Com,
	Eco_Ind,
	Eco_Pub,
	Eco_Soc,
	Flag_Lido,
	Flag_Faturado
	)
	(
	SELECT
		R.grupo_fatura,
		(
			SELECT MAX(seq_roteiro) 
			FROM ONP_FATURA 
			--where D.dg_matricula = cg_matricula 
			--and D.dg_grupo = cg_grupo
		),
		F.seq_roteiro,
		F.seq_matricula,
		M.leitura_atribuida,
		M.leitura_real,
		M.data_leitura,
		M.consumo_atribuida,
		M.consumo_rateado,
		CASE
			WHEN (
					SELECT 
						MAX(FC.seq_categoria) FROM ONP_FATURA_CATEGORIA 
				 ) = 2 
						or
				(	SELECT 
						MAX(FC.seq_categoria) FROM ONP_FATURA_CATEGORIA 
				) = 3
			THEN M.consumo_rateado
			ELSE 0
		END,
		DATEDIFF(d, M.dat_leitura_anterior, M.dat_leitura),
		H.cod_ocorrencia,
		H.cod_ocorrencia,
		CASE 
			WHEN MD.val_fraudes = 0
			THEN 'N'
			ELSE 'S'
		END,
		CASE 
			WHEN MD.indica_cortou_ligacao is null
			THEN 'N'
			ElSE 'S'
		END,
		M.cod_agente,
		MD.ind_calcula_fatura,
		MD.ind_emite_fatura,
		M.referencia,
		F.data_leitura,
		(
			SELECT MAX(data_vencimento) 
			FROM ONP_MOVIMENTO 
		),
		(
			SELECT
				ISNULL(val_valor_faturado,0),
				FROM 
					ONP_FATURA_TAXA
				WHERE seq_taxa = 1 ---AGUA
		),
		(
			SELECT
				ISNULL(val_valor_faturado,0),
				FROM 
					ONP_FATURA_TAXA
				WHERE seq_taxa = 2 ---ESGOTO
		),
		ISNULL(MAX(ISNULL(F.val_valor_credito,0)),0),
		ISNULL(
				(
				  SUM(sr_valor)-F.val_valor_credito 
				),
			  ) as valor_credito,
		ISNULL(F.val_desconto,0),
		(SELECT ABS(val_valor_calculado) from ONP_FATURA_IMPOSTO_DIADEMA where cod_imposto = 'IRRF' and seq_matricula = F.seq_matricula),
		(SELECT ABS(val_valor_calculado) from ONP_FATURA_IMPOSTO_DIADEMA where cod_imposto = 'CSLL' and seq_matricula = F.seq_matricula),
		(SELECT ABS(val_valor_calculado) from ONP_FATURA_IMPOSTO_DIADEMA where cod_imposto = 'PIS' and seq_matricula = F.seq_matricula),
		(SELECT ABS(val_valor_calculado) from ONP_FATURA_IMPOSTO_DIADEMA where cod_imposto = 'COFINS' and seq_matricula = F.seq_matricula),
		FC.val_valor_economia,
		CASE FC.val_valor_economia WHEN 1 THEN 1 ELSE 0 END,
		CASE FC.val_valor_economia WHEN 2 THEN 1 ELSE 0 END,
		CASE FC.val_valor_economia WHEN 3 THEN 1 ELSE 0 END,
		CASE FC.val_valor_economia WHEN 4 THEN 1 ELSE 0 END,
		CASE FC.val_valor_economia WHEN 6 THEN 1 ELSE 0 END,
		M.ind_situacao_movimento,
		CASE(count(F.cod_referencia))WHEN >0 THEN 'S' ELSE 'N' END
	FROM 
		ONP_FATURA F,
		ONP_MOVIMENTO M,
		ONP_ROTEIRO R,
		ONP_FATURA_CATEGORIA FC,
		ONP_MATRICULA_DIADEMA MD,
		ONP_HISTORICO H
		
	WHERE 
		dg_grupo = :grupo
		AND dg_rota = :rota
		AND F.seq_matricula = M.seq_matricula
		AND R.seq_roteiro = M.seq_roteiro
		AND F.seq_matricula = FC.seq_matricula
		AND F.seq_matricula = MD.seq_matricula
		AND F.seq_matricula = H.seq_matricula
	)
---------------------------------------------------------------------------------------	
		
		insert into DIADEMA_IV.dbo.VOLTA_ALTERACAO
		(
			Grupo,
			CDC,
			referencia,
			Numero_Imovel,
			--tipo 2
			Complemento,
			--tipo 4
			Medidor,
			--tipo 1
			Nome_Consumidor,
			--tipo 7
			observacao
			--tipo 8
		)
		(

			SELECT DISTINCT
				R.seq_grupo_fatura,
				F.seq_matricula,
				F.cod_referencia,
				M.val_numero_imovel,
				M.des_complemento,
				F.cod_hidrometro,
				M.nom_cliente,
				MA.des_conteudo_novo
			FROM 
				ONP_MATRICULA M,
				ONP_MATRICULA_ALTERACAO MA,
				ONP_ROTEIRO R,
				ONP_FATURA F
			WHERE 
				F.seq_matricula = M.seq_matricula
				AND M.seq_matricula = MA.seq_matricula
				AND F.seq_roteiro = R.seq_roteiro
				AND F.seq_matricula = :matricula
				AND D.al_grupo = :grupo
				AND D.al_rota = :rota
		)
----------------------------------------------------------------------
	
	INSERT INTO DIADEMA_IV.dbo.VOLTA_NOVO_REGISTRO
	(
		Grupo,
		Rota,
		referencia,
		Logradouro,
		--tipo 3
		Numero,
		--tipo 2
		Complemento,
		--tipo 4
		Medidor,
		-- tipo 1
		Nome,
		--tipo 7
		OBS
		--tipo 8
	)
	(
			SELECT DISTINCT
				R.seq_grupo_fatura,
				R.seq_roteiro,
				R.dat_base,
				L.des_logradouro,
				M.val_numero_imovel,
				M.des_complemento,
				F.cod_hidrometro,
				M.nom_cliente,
				MA.des_conteudo_novo
			FROM 
				ONP_MATRICULA M,
				ONP_LOGRADOURO L,
				ONP_MATRICULA_ALTERACAO MA,
				ONP_ROTEIRO R,
				ONP_FATURA F
			WHERE 
				F.seq_matricula = M.seq_matricula
				AND L.seq_logradouro = M.seq_logradouro
				AND M.seq_matricula = MA.seq_matricula
				AND F.seq_roteiro = R.seq_roteiro
				AND F.seq_matricula = :matricula
				AND D.al_grupo = :grupo
				AND D.al_rota = :rota
	)
	---------------------------------------------------------------------------------------------------------------------------------
	
	--------------------------------------------------------------------------------------------------------------------------------
