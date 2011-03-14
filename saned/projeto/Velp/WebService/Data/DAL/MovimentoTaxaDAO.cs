using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using Data.Model;

namespace Data.DAL
{
    public class MovimentoTaxaDAO : BaseDAO<MovimentoTaxaONP>
    {
        /// <summary>
        ///  Metodo que retorna uma lista de dados de movimento taxa
        /// </summary>
        /// <param name="grupo">Grupo</param>
        /// <param name="referencia">Referencia (NÂO UTILIZADA)</param>
        /// <param name="rotaInicial">rota unica</param>
        /// <param name="rotaFinal">rota unica</param>
        /// <returns>Lista de MovimentoTaxaONP</returns>
        public List<MovimentoTaxaONP> Lista(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            string sql = @"
DECLARE @CATEGORIA NVARCHAR(11)
DECLARE @QUANT_ECONOMIAS NVARCHAR(11)
DECLARE @QUERY NVARCHAR(MAX)
DECLARE @QUERY2 NVARCHAR(MAX)
DECLARE @QUERY3 NVARCHAR(MAX)
DECLARE @QUERY4 NVARCHAR(MAX)
DECLARE @QUERY5 NVARCHAR(MAX)
DECLARE @QUERY6 NVARCHAR(MAX)
DECLARE @QUERY7 NVARCHAR(MAX)
DECLARE @QUERY8 NVARCHAR(MAX)
DECLARE @QUERY9 NVARCHAR(MAX)
DECLARE @QUERY10 NVARCHAR(MAX)
DECLARE @QUERY11 NVARCHAR(MAX)
DECLARE @QUERY12 NVARCHAR(MAX)
DECLARE @CDC NVARCHAR(11)
DECLARE @eco_res NVARCHAR(11)
DECLARE @eco_com NVARCHAR(11)
DECLARE @eco_ind NVARCHAR(11)
DECLARE @eco_pub NVARCHAR(11)
DECLARE @eco_soc NVARCHAR(11)
DECLARE @Q_eco_res NVARCHAR(4000)
DECLARE @Q_eco_com NVARCHAR(4000)
DECLARE @Q_eco_ind NVARCHAR(4000)
DECLARE @Q_eco_pub NVARCHAR(4000)
DECLARE @Q_eco_soc NVARCHAR(4000)
DECLARE @Q_mix NVARCHAR(4000)
DECLARE @teste NVARCHAR(4000)

SET @Q_mix = '0,'
SET @Q_eco_res = '0,'
SET @Q_eco_com = '0,'
SET @Q_eco_ind = '0,'
SET @Q_eco_pub = '0,'
SET @Q_eco_soc = '0,'
SET @teste = ''
SET @CDC = '0'

DECLARE cursCol CURSOR FOR 
	 SELECT CDC FROM IDA_LIGACOES WHERE GRUPO = ?grupo AND rota BETWEEN ?rotaInicial AND ?rotaFinal
OPEN cursCol
	FETCH NEXT FROM cursCol INTO @CDC
	WHILE @@FETCH_STATUS = 0  
	BEGIN 

		SELECT		
			@CATEGORIA = L.categoria_imovel,
			@eco_res = L.eco_res ,
			@eco_com = L.eco_com ,
			@eco_ind = L.eco_ind ,
			@eco_pub = L.eco_pub ,
			@eco_soc = L.eco_soc ,
			@QUANT_ECONOMIAS = CAST ((
												CASE  WHEN L.eco_res <= 0 THEN 0 ELSE L.eco_res END+
												CASE  WHEN L.eco_com <= 0 THEN 0 ELSE L.eco_com END+
												CASE  WHEN L.eco_ind <= 0 THEN 0 ELSE L.eco_ind END+
												CASE  WHEN L.eco_pub <= 0 THEN 0 ELSE L.eco_pub END+
												CASE  WHEN L.eco_soc <= 0 THEN 0 ELSE L.eco_soc END
											   ) AS INT)
		FROM 
		IDA_LIGACOES L
		WHERE 
			CDC = @CDC
	IF @CATEGORIA = 5
		BEGIN
			IF	@eco_res > 0
				BEGIN
					SET @Q_eco_res = @Q_eco_res+@CDC+','
				END
			IF	@eco_com > 0
				BEGIN
					SET @Q_eco_com = @Q_eco_com+@CDC+','
				END
			IF	@eco_ind > 0
				BEGIN
					SET @Q_eco_ind = @Q_eco_ind+@CDC+','
				END
			IF	@eco_pub > 0
				BEGIN
					SET @Q_eco_pub = @Q_eco_pub+@CDC+','
				END
			IF	@eco_soc > 0
				BEGIN
					SET @Q_eco_soc = @Q_eco_soc+@CDC+','
				END
		END
	ELSE
		BEGIN
			SET @Q_mix = @Q_mix+@CDC+','
		END

		FETCH NEXT FROM cursCol INTO @CDC 
	END   
CLOSE cursCol  
DEALLOCATE cursCol


SET @Q_eco_res = @Q_eco_res+'0'
SET @Q_eco_com = @Q_eco_com+'0'
SET @Q_eco_ind = @Q_eco_ind+'0'
SET @Q_eco_pub = @Q_eco_pub+'0'
SET @Q_eco_soc = @Q_eco_soc+'0'
SET @Q_mix = @Q_mix+'0'
SET @QUERY = N' 
SELECT	DISTINCT
        1 AS seq_taxa,--AGUA
        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
        L.cdc AS seq_matricula, 
        CONVERT(numeric,''1'' + RIGHT (''000''+ CAST (L.grupo AS varchar), 3) + RIGHT (''000''+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
		L.categoria_imovel AS seq_categoria,
		(
			CASE 
				WHEN L.categoria_imovel = 1 
				THEN L.eco_res
				WHEN L.categoria_imovel = 2 
				THEN L.eco_com
				WHEN L.categoria_imovel = 3 
				THEN L.eco_ind
				WHEN L.categoria_imovel = 4 
				THEN L.eco_pub
				WHEN L.categoria_imovel = 6 
				THEN L.eco_soc
				ELSE NULL
			END
		) AS val_economias,
        NULL AS val_consumo_fixo,
        NULL AS val_consumo_estimado,
        CASE 	WHEN ISNULL(L.bloqueado, ''L'') NOT IN (''L'', '''') THEN
                CASE 	WHEN L.natureza_ligacao IN (1, 2) THEN 3 
                    ELSE 4 
                END
            WHEN L.natureza_ligacao in (1, 2) THEN 1 
            ELSE 4 
        END AS ind_situacao 
		
    FROM	
        IDA_GRUPOS G, 
        IDA_LIGACOES L
    WHERE	
    G.grupo = L.grupo
    AND L.CDC IN ('+@Q_mix+')'

SET @QUERY2 = N'
UNION ALL

    SELECT	DISTINCT
        2 AS seq_taxa,--ESGOTO
        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
        L.cdc AS seq_matricula, 
        CONVERT(numeric,''1'' + RIGHT (''000''+ CAST (L.grupo AS varchar), 3) + RIGHT (''000''+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
		L.categoria_imovel AS seq_categoria,
		(
			CASE 
				WHEN L.categoria_imovel = 1 
				THEN L.eco_res
				WHEN L.categoria_imovel = 2 
				THEN L.eco_com
				WHEN L.categoria_imovel = 3 
				THEN L.eco_ind
				WHEN L.categoria_imovel = 4 
				THEN L.eco_pub
				WHEN L.categoria_imovel = 6 
				THEN L.eco_soc
				ELSE NULL
			END
		) AS val_economias,
        NULL AS val_consumo_fixo,
        NULL AS val_consumo_estimado,
        case 	when isnull(L.bloqueado, ''L'') NOT IN (''L'', '''') then
                case 	when L.natureza_ligacao in (2, 3) then 3 
                    else 4 
                END
            when L.natureza_ligacao in (2, 3) then 1 
            else 4 
        END AS ind_situacao 
		
    FROM	
        IDA_GRUPOS G, 
        IDA_LIGACOES L
    WHERE	
    G.grupo = L.grupo
    AND L.CDC IN('+@Q_mix+')'

SET @QUERY3 = N'
UNION ALL

    SELECT	DISTINCT
        1 AS seq_taxa,--AGUA
        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
        L.cdc AS seq_matricula, 
        CONVERT(numeric,''1'' + RIGHT (''000''+ CAST (L.grupo AS varchar), 3) + RIGHT (''000''+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
		1 AS seq_categoria,
		L.eco_res AS val_economias,
        NULL AS val_consumo_fixo,
        NULL AS val_consumo_estimado,
        CASE 	WHEN ISNULL(L.bloqueado, ''L'') NOT IN (''L'', '''') THEN
                CASE 	WHEN L.natureza_ligacao IN (1, 2) THEN 3 
                    ELSE 4 
                END
            WHEN L.natureza_ligacao in (1, 2) THEN 1 
            ELSE 4 
        END AS ind_situacao 
		
    FROM	
        IDA_GRUPOS G, 
        IDA_LIGACOES L
    WHERE	
    G.grupo = L.grupo
    AND L.CDC IN ('+@Q_eco_res+')'

SET @QUERY4 = N'
UNION ALL

    SELECT	DISTINCT
        2 AS seq_taxa,--ESGOTO
        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
        L.cdc AS seq_matricula, 
        CONVERT(numeric,''1'' + RIGHT (''000''+ CAST (L.grupo AS varchar), 3) + RIGHT (''000''+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
		1 AS seq_categoria,
		L.eco_res AS val_economias,
        NULL AS val_consumo_fixo,
        NULL AS val_consumo_estimado,
        case 	when isnull(L.bloqueado, ''L'') NOT IN (''L'', '''') then
                case 	when L.natureza_ligacao in (2, 3) then 3 
                    else 4 
                END
            when L.natureza_ligacao in (2, 3) then 1 
            else 4 
        END AS ind_situacao 
		
    FROM	
        IDA_GRUPOS G, 
        IDA_LIGACOES L
    WHERE	
    G.grupo = L.grupo
	AND L.CDC IN ('+@Q_eco_res+')'

SET @QUERY5 = N'
UNION ALL

    SELECT	DISTINCT
        1 AS seq_taxa,--AGUA
        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
        L.cdc AS seq_matricula, 
        CONVERT(numeric,''1'' + RIGHT (''000''+ CAST (L.grupo AS varchar), 3) + RIGHT (''000''+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
		2 AS seq_categoria,
		L.eco_com AS val_economias,
        NULL AS val_consumo_fixo,
        NULL AS val_consumo_estimado,
        CASE 	WHEN ISNULL(L.bloqueado, ''L'') NOT IN (''L'', '''') THEN
                CASE 	WHEN L.natureza_ligacao IN (1, 2) THEN 3 
                    ELSE 4 
                END
            WHEN L.natureza_ligacao in (1, 2) THEN 1 
            ELSE 4 
        END AS ind_situacao 
		
    FROM	
        IDA_GRUPOS G, 
        IDA_LIGACOES L
    WHERE	
    G.grupo = L.grupo
    AND L.CDC IN ('+@Q_eco_com+')'

SET @QUERY6 = N'
UNION ALL

    SELECT	DISTINCT
        2 AS seq_taxa,--ESGOTO
        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
        L.cdc AS seq_matricula, 
        CONVERT(numeric,''1'' + RIGHT (''000''+ CAST (L.grupo AS varchar), 3) + RIGHT (''000''+ CAST (L.rota AS varchar), 3)) as seq_roteiro,	
		2 AS seq_categoria,
		L.eco_com AS val_economias,
        NULL AS val_consumo_fixo,
        NULL AS val_consumo_estimado,
        case 	when isnull(L.bloqueado, ''L'') NOT IN (''L'', '''') then
                case 	when L.natureza_ligacao in (2, 3) then 3 
                    else 4 
                END
            when L.natureza_ligacao in (2, 3) then 1 
            else 4 
        END AS ind_situacao 
		
    FROM	
        IDA_GRUPOS G, 
        IDA_LIGACOES L
    WHERE	
    G.grupo = L.grupo
	AND L.CDC IN ('+@Q_eco_com+')'

SET @QUERY7 = N'
UNION ALL

    SELECT	DISTINCT
        1 AS seq_taxa,--AGUA
        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
        L.cdc AS seq_matricula, 
        CONVERT(numeric,''1'' + RIGHT (''000''+ CAST (L.grupo AS varchar), 3) + RIGHT (''000''+ CAST (L.rota AS varchar), 3)) as seq_roteiro,		
		3 AS seq_categoria,
		eco_ind AS val_economias,
        NULL AS val_consumo_fixo,
        NULL AS val_consumo_estimado,
        CASE 	WHEN ISNULL(L.bloqueado, ''L'') NOT IN (''L'', '''') THEN
                CASE 	WHEN L.natureza_ligacao IN (1, 2) THEN 3 
                    ELSE 4 
                END
            WHEN L.natureza_ligacao in (1, 2) THEN 1 
            ELSE 4 
        END AS ind_situacao 
		
    FROM	
        IDA_GRUPOS G, 
        IDA_LIGACOES L
    WHERE	
    G.grupo = L.grupo
    AND L.CDC IN ('+@Q_eco_ind+')'

SET @QUERY8 = N'
UNION ALL

    SELECT	DISTINCT
        2 AS seq_taxa,--ESGOTO
        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
        L.cdc AS seq_matricula, 
        CONVERT(numeric,''1'' + RIGHT (''000''+ CAST (L.grupo AS varchar), 3) + RIGHT (''000''+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
		3 AS seq_categoria,
		eco_ind AS val_economias,
        NULL AS val_consumo_fixo,
        NULL AS val_consumo_estimado,
        case 	when isnull(L.bloqueado, ''L'') NOT IN (''L'', '''') then
                case 	when L.natureza_ligacao in (2, 3) then 3 
                    else 4 
                END
            when L.natureza_ligacao in (2, 3) then 1 
            else 4 
        END AS ind_situacao 
		
    FROM	
        IDA_GRUPOS G, 
        IDA_LIGACOES L
    WHERE	
    G.grupo = L.grupo
	AND L.CDC IN ('+@Q_eco_ind+')'

SET @QUERY9 = N'
UNION ALL

    SELECT	DISTINCT
        1 AS seq_taxa,--AGUA
        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
        L.cdc AS seq_matricula, 
        CONVERT(numeric,''1'' + RIGHT (''000''+ CAST (L.grupo AS varchar), 3) + RIGHT (''000''+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
		4 AS seq_categoria,
		L.eco_pub AS val_economias,
        NULL AS val_consumo_fixo,
        NULL AS val_consumo_estimado,
        CASE 	WHEN ISNULL(L.bloqueado, ''L'') NOT IN (''L'', '''') THEN
                CASE 	WHEN L.natureza_ligacao IN (1, 2) THEN 3 
                    ELSE 4 
                END
            WHEN L.natureza_ligacao in (1, 2) THEN 1 
            ELSE 4 
        END AS ind_situacao 
		
    FROM	
        IDA_GRUPOS G, 
        IDA_LIGACOES L
    WHERE	
    G.grupo = L.grupo
    AND L.CDC IN ('+@Q_eco_pub+')'

SET @QUERY10 = N'
UNION ALL

    SELECT	DISTINCT
        2 AS seq_taxa,--ESGOTO
        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
        L.cdc AS seq_matricula, 
        CONVERT(numeric,''1'' + RIGHT (''000''+ CAST (L.grupo AS varchar), 3) + RIGHT (''000''+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
		4 AS seq_categoria,
		L.eco_pub AS val_economias,
        NULL AS val_consumo_fixo,
        NULL AS val_consumo_estimado,
        case 	when isnull(L.bloqueado, ''L'') NOT IN (''L'', '''') then
                case 	when L.natureza_ligacao in (2, 3) then 3 
                    else 4 
                END
            when L.natureza_ligacao in (2, 3) then 1 
            else 4 
        END AS ind_situacao 
    FROM	
        IDA_GRUPOS G, 
        IDA_LIGACOES L
    WHERE	
    G.grupo = L.grupo
	AND L.CDC IN ('+@Q_eco_pub+')'

SET @QUERY11 = N'
UNION ALL

    SELECT	DISTINCT
        1 AS seq_taxa,--AGUA
        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
        L.cdc AS seq_matricula, 
        CONVERT(numeric,''1'' + RIGHT (''000''+ CAST (L.grupo AS varchar), 3) + RIGHT (''000''+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
		6 AS seq_categoria,
		L.eco_soc AS val_economias,
        NULL AS val_consumo_fixo,
        NULL AS val_consumo_estimado,
        CASE 	WHEN ISNULL(L.bloqueado, ''L'') NOT IN (''L'', '''') THEN
                CASE 	WHEN L.natureza_ligacao IN (1, 2) THEN 3 
                    ELSE 4 
                END
            WHEN L.natureza_ligacao in (1, 2) THEN 1 
            ELSE 4 
        END AS ind_situacao 
		
    FROM	
        IDA_GRUPOS G, 
        IDA_LIGACOES L
    WHERE	
    G.grupo = L.grupo
    AND L.CDC IN ('+@Q_eco_soc+')'

SET @QUERY12 = N'
UNION ALL

    SELECT	DISTINCT
        2 AS seq_taxa,--ESGOTO
        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
        L.cdc AS seq_matricula, 
        CONVERT(numeric,''1'' + RIGHT (''000''+ CAST (L.grupo AS varchar), 3) + RIGHT (''000''+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
		6 AS seq_categoria,
		L.eco_soc AS val_economias,
        NULL AS val_consumo_fixo,
        NULL AS val_consumo_estimado,
        case 	when isnull(L.bloqueado, ''L'') NOT IN (''L'', '''') then
                case 	when L.natureza_ligacao in (2, 3) then 3 
                    else 4 
                END
            when L.natureza_ligacao in (2, 3) then 1 
            else 4 
        END AS ind_situacao 
		
    FROM	
        IDA_GRUPOS G, 
        IDA_LIGACOES L
    WHERE	
    G.grupo = L.grupo
	AND L.CDC IN ('+@Q_eco_soc+')'
EXECUTE(@QUERY+@QUERY2+@QUERY3+@QUERY4+@QUERY5+@QUERY6+@QUERY7+@QUERY8+@QUERY9+@QUERY10+@QUERY11+@QUERY12)
                          ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo), new GDAParameter("?referencia", referencia), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal));
        }


        //OBSOLETO
        public List<MovimentoTaxaONP> Lista_old(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            string sql = @"
	                        SELECT	DISTINCT
		                        1 AS seq_taxa,--AGUA
		                        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
		                        L.cdc AS seq_matricula, 
		                        --CONVERT(numeric, '1' + dbo.fc_completa_zeros(L.grupo, 3)+dbo.fc_completa_zeros(L.rota,3)) AS seq_roteiro, 	
		                        CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
                                ISNULL(L.categoria_imovel,0) AS seq_categoria,
		                        (
			                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_res END+
			                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_com END+
			                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_ind END+
			                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_pub END+
			                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_soc END
		                        ) as val_economias,
		                        NULL AS val_consumo_fixo,
		                        NULL AS val_consumo_estimado,
		                        CASE 	WHEN ISNULL(L.bloqueado, 'L') NOT IN ('L', '') THEN
				                        CASE 	WHEN L.natureza_ligacao IN (1, 2) THEN 3 
					                        ELSE 4 
				                        END
			                        WHEN L.natureza_ligacao in (1, 2) THEN 1 
			                        ELSE 4 
		                        END AS ind_situacao 
                        		
	                        FROM	--.carga, .roteiros
		                        IDA_GRUPOS G, 
		                        IDA_LIGACOES L
	                        WHERE	
	                        G.grupo = L.grupo
	                        AND	L.grupo = ?Grupo
	                        AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
	                        --AND	G.referencia = ?referencia

                        UNION ALL

	                        SELECT	DISTINCT
		                        2 AS seq_taxa,--ESGOTO
		                        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
		                        L.cdc AS seq_matricula, 
		                        --CONVERT(numeric, '1' + dbo.fc_completa_zeros(L.grupo, 3)+dbo.fc_completa_zeros(L.rota,3)) AS seq_roteiro, 	
		                        CONVERT(numeric,'1' + RIGHT ('000'+ CAST (L.grupo AS varchar), 3) + RIGHT ('000'+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
                                L.categoria_imovel AS seq_categoria,
		                        (
			                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_res END+
			                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_com END+
			                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_ind END+
			                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_pub END+
			                        CASE L.categoria_imovel WHEN 8 THEN 0 ELSE L.eco_soc END
		                        ) as val_economias,
		                        NULL AS val_consumo_fixo,
		                        NULL AS val_consumo_estimado,
		                        case 	when isnull(L.bloqueado, 'L') NOT IN ('L', '') then
				                        case 	when L.natureza_ligacao in (2, 3) then 3 
					                        else 4 
				                        END
			                        when L.natureza_ligacao in (2, 3) then 1 
			                        else 4 
		                        END AS ind_situacao 
                        		
	                        FROM	--.carga, .roteiros
		                        IDA_GRUPOS G, 
		                        IDA_LIGACOES L
	                        WHERE	
	                        G.grupo = L.grupo
	                        AND	L.grupo = ?Grupo
	                        AND	L.rota BETWEEN ?rotaInicial AND ?rotaFinal
	                        --AND	G.referencia = ?referencia


                          ";
            return CurrentPersistenceObject.LoadData(sql, new GDAParameter("?Grupo", grupo), new GDAParameter("?referencia", referencia), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal));
        }
    }
}

