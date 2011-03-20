using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;
using System.Data;
using System.Data.SqlClient;

namespace GeraBase.DAL
{
    public class MovimentoCategoriaDAO : BaseDAO<MovimentoCategoriaONP>
    {

        /// <summary>
        ///  Retorna uma lista da tabela movimento categoria
        /// </summary>
        /// <param name="grupo">grupo</param>
        /// <param name="referencia">referencia (NÃO UTILIZADO)</param>
        /// <param name="rotaInicial">rota (ROTA UNICA)</param>
        /// <param name="rotaFinal">rota (ROTA UNICA)</param>
        /// <returns>Lista de MovimentoCategoriaONP</returns>
        public List<MovimentoCategoriaONP> Lista(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            List<MovimentoCategoriaONP> listaMovimentoCategoria = new List<MovimentoCategoriaONP>();

            string sql = @"
DECLARE @CATEGORIA NVARCHAR(11)
DECLARE @QUANT_ECONOMIAS NVARCHAR(11)
DECLARE @QUERY VARCHAR(8000)
DECLARE @QUERY2 VARCHAR(8000)
DECLARE @QUERY3 VARCHAR(8000)
DECLARE @QUERY4 VARCHAR(8000)
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
			)as val_numero_economia,
			NULL AS val_valor_faturado
	    	
		FROM	--.carga, .roteiros
			IDA_GRUPOS G, 
			IDA_LIGACOES L
		WHERE	
		G.grupo = L.grupo
		AND L.CDC IN('+@Q_mix+')
'
SET @QUERY2 = N'
UNION ALL

	SELECT	DISTINCT
        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
        L.cdc AS seq_matricula, 
        CONVERT(numeric,''1'' + RIGHT (''000''+ CAST (L.grupo AS varchar), 3) + RIGHT (''000''+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
        1 AS seq_categoria,
		L.eco_res AS val_numero_economia,
        NULL AS val_valor_faturado
    	
    FROM	--.carga, .roteiros
        IDA_GRUPOS G, 
        IDA_LIGACOES L
    WHERE	
    G.grupo = L.grupo
	AND L.CDC IN ('+@Q_eco_res+')

UNION ALL

	SELECT	DISTINCT
        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
        L.cdc AS seq_matricula, 
        CONVERT(numeric,''1'' + RIGHT (''000''+ CAST (L.grupo AS varchar), 3) + RIGHT (''000''+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
        2 AS seq_categoria,
		L.eco_com AS val_numero_economia,
        NULL AS val_valor_faturado
    	
    FROM	--.carga, .roteiros
        IDA_GRUPOS G, 
        IDA_LIGACOES L
    WHERE	
    G.grupo = L.grupo
	AND L.CDC IN ('+@Q_eco_com+')'

SET @QUERY3 = N'
UNION ALL

	SELECT	DISTINCT
        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
        L.cdc AS seq_matricula, 
        CONVERT(numeric,''1'' + RIGHT (''000''+ CAST (L.grupo AS varchar), 3) + RIGHT (''000''+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
        3 AS seq_categoria,
		eco_ind AS val_numero_economia,
        NULL AS val_valor_faturado
    	
    FROM	--.carga, .roteiros
        IDA_GRUPOS G, 
        IDA_LIGACOES L
    WHERE	
    G.grupo = L.grupo
	AND L.CDC IN ('+@Q_eco_ind+')

UNION ALL

	SELECT	DISTINCT
        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
        L.cdc AS seq_matricula, 
        CONVERT(numeric,''1'' + RIGHT (''000''+ CAST (L.grupo AS varchar), 3) + RIGHT (''000''+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
        4 AS seq_categoria,
		L.eco_pub AS val_numero_economia,
        NULL AS val_valor_faturado
    	
    FROM	--.carga, .roteiros
        IDA_GRUPOS G, 
        IDA_LIGACOES L
    WHERE	
    G.grupo = L.grupo
	AND L.CDC IN ('+@Q_eco_pub+')'

SET @QUERY4 = N'
UNION ALL

	SELECT	DISTINCT
        CONVERT(char(7), G.referencia, 102) AS cod_referencia,
        L.cdc AS seq_matricula, 
        CONVERT(numeric,''1'' + RIGHT (''000''+ CAST (L.grupo AS varchar), 3) + RIGHT (''000''+ CAST (L.rota AS varchar), 3)) as seq_roteiro,
        6 AS seq_categoria,
		L.eco_soc AS val_numero_economia,
        NULL AS val_valor_faturado
    	
    FROM	--.carga, .roteiros
        IDA_GRUPOS G, 
        IDA_LIGACOES L
    WHERE	
    G.grupo = L.grupo
	AND L.CDC IN ('+@Q_eco_soc+')'


EXECUTE(@QUERY+@QUERY2+@QUERY3+@QUERY4)
                         ";
            listaMovimentoCategoria = CurrentPersistenceObject.LoadData(sql, new GDAParameter("?grupo", grupo), new GDAParameter("?rotaInicial", rotaInicial), new GDAParameter("?rotaFinal", rotaFinal));
            return listaMovimentoCategoria;
        }


        //OBSOLETO METODO ANTIGO
        public List<MovimentoCategoriaONP> Lista_old(int grupo, DateTime referencia, int rotaInicial, int rotaFinal)
        {
            string sql = @"
                            SELECT	DISTINCT
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
                                ) as val_numero_economia,
	                            NULL AS val_valor_faturado
                            	
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