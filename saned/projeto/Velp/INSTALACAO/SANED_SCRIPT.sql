USE [DIADEMA_IV]
GO

-- =============================================
-- Author:		<Alexis Moura>
-- Create date: <14/12/2010>
-- Description:	<Criação da tabela de coletores>
-- =============================================
CREATE TABLE Coletor(
	id nvarchar(255) NULL,
	modelo nvarchar(255) NULL,
	fabricante nvarchar(255) NULL,
	num_serie nvarchar(255) NULL,
	codigo int NULL
) 
-- =============================================
-- Author:		<Alexis Moura>
-- Create date: <19/07/2010>
-- Description:	<Criação da tabela de distribuicao>
-- =============================================
	CREATE TABLE IDA_DISTRIBUICAO(
		Codigo_Agente int NULL,
		Situacao varchar(1) NOT NULL,
		Referencia datetime NULL,
		Grupo int NOT NULL,
		Rota int NULL,
		Data_Carga datetime NULL,
		Data_Descarga datetime NULL
	) 
GO
	
-- =============================================
-- Author:		<Alexis Moura>
-- Create date: <15/09/2010>
-- Description:	<Criação da Tabela de usuarios> 
-- =============================================

CREATE TABLE IDA_USUARIO(
	Codigo [int] IDENTITY(1,1) NOT NULL,
	Nome [nchar](30) NOT NULL,
	Login [nchar](10) NOT NULL,
	Senha [varchar](50) NOT NULL
	)
GO

------------------------------------------------------------------------------------------------------------------------------
--Alteração no servidor 
alter table dbo.LOGSYNCSERVER alter column TABELA nvarchar(100)
------------------------------------------------------------------------------------------------------------------------------
--Alteração no servidor 
alter table dbo.LOGSYNCSERVER alter column coletor nvarchar(50)
------------------------------------------------------------------------------------------------------------------------------
--Alteração no servidor 
alter table Coletor alter column id nvarchar(50);

------------------------------------------------------------------------------------------------------------------------------
  -- tabela criada no servidor Registrar log de sincronização (data hora, coletor, funcionário, tabela, update/download)
 CREATE TABLE LOGSYNCSERVER
  ( 
		COLETOR NVARCHAR(20) NOT NULL,
		DATASYNC DATETIME NOT NULL,
		FUNCIONARIO BIGINT NOT NULL,
		TABELA NVARCHAR (15) NOT NULL,
		TIPOTRANFER NCHAR(1) NOT NULL, -- 'U' PARA UPLOAD, 'D' PARA DOWNLOAD	
		OBS NVARCHAR(200)		
  )

-- =============================================
-- Author:		<Alexis Moura>
-- Create date: <23/07/2010>
-- Description:	<Criação da tabelas de parametros fixos no PDA> 
-- (obs: estas tabelas são um espelhos das do PDA)
-- =============================================

	CREATE TABLE [IDA_CATEGORIA](
		[seq_categoria] [numeric](3, 0) NOT NULL,
		[des_categoria] [nvarchar](30) NOT NULL,
	 ) 
	;

	CREATE TABLE [IDA_DESCONTO_DIADEMA](
		[seq_desconto] [numeric](3, 0) NOT NULL,
		[ind_tipo_desconto] [nvarchar](1) NULL,
		[val_limite_inicial] [numeric](7, 0) NULL,
		[val_valor_desconto] [numeric](6, 3) NULL,
	 ) 
	;

	CREATE TABLE [IDA_IMPOSTO_DIADEMA](
		[cod_imposto] [nvarchar](16) NOT NULL,
		[val_porcentagem] [numeric](5, 2) NULL,
	 )
	;

	CREATE TABLE [IDA_LOCALIZACAO_HIDROMETRO](
		[seq_local] [numeric](3, 0) NOT NULL,
		[des_local] [nvarchar](30) NOT NULL,
	 );

	CREATE TABLE [IDA_OCORRENCIA](
		[cod_ocorrencia] [numeric](3, 0) NOT NULL,
		[des_ocorrencia] [nvarchar](40) NOT NULL,
		[des_mensagem] [nvarchar](40) NOT NULL,
		[ind_grupo] [nvarchar](1) NULL,
		[ind_leitura] [nvarchar](1) NULL,
		[ind_consumo] [nvarchar](2) NULL,
		[ind_emite] [nvarchar](1) NULL,
	 );

	CREATE TABLE [IDA_PARAMETRO](
		[des_nome] [nvarchar](40) NOT NULL,
		[des_valor] [nvarchar](150) NULL,
	 );

	CREATE TABLE [IDA_PARAMETRO_RETENCAO](
		[ind_retencao] [nvarchar](1) NOT NULL,
		[seq_faixa] [numeric](3, 0) NOT NULL,
		[val_media_inicial] [numeric](7, 0) NULL,
		[val_media_final] [numeric](7, 0) NULL,
		[val_variacao_aviso] [numeric](11, 3) NULL,
		[val_variacao_retencao] [numeric](11, 3) NULL,
		[ind_unidade_variacao] [nvarchar](1) NULL,
	 );

	CREATE TABLE [IDA_TAXA](
		[seq_taxa] [numeric](5, 0) NOT NULL,
		[des_taxa] [nvarchar](60) NOT NULL,
	 );

	CREATE TABLE [IDA_TIPO_ENTREGA](
		[seq_tipo_entrega] [numeric](3, 0) NOT NULL,
		[des_tipo_entrega] [nvarchar](30) NOT NULL,
	 );
	
-- =============================================
-- Author:		<Alexis Moura>
-- Create date: <06/08/2010>
-- Description:	<alimentação das tabelas fixas> 
-- (obs: estas tabelas são um espelhos das do PDA)
-- =============================================
		
	----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	INSERT IDA_CATEGORIA(seq_categoria,des_categoria) VALUES('1','RESIDENCIAL')
	INSERT IDA_CATEGORIA(seq_categoria,des_categoria) VALUES('2','COMERCIAL')
	INSERT IDA_CATEGORIA(seq_categoria,des_categoria) VALUES('3','INDUSTRIAL')
	INSERT IDA_CATEGORIA(seq_categoria,des_categoria) VALUES('4','PÚBLICA')
	INSERT IDA_CATEGORIA(seq_categoria,des_categoria) VALUES('5','Mista')
	INSERT IDA_CATEGORIA(seq_categoria,des_categoria) VALUES('6','SOCIAL')
	INSERT IDA_CATEGORIA(seq_categoria,des_categoria) VALUES('7','GRANDES CONSUMIDORES')
	INSERT IDA_CATEGORIA(seq_categoria,des_categoria) VALUES('8','ENTIDADE ASSISTENCIAL')


	----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	INSERT IDA_DESCONTO_DIADEMA(seq_desconto,ind_tipo_desconto,val_limite_inicial,val_valor_desconto) VALUES('0','0','0','0.000')
	INSERT IDA_DESCONTO_DIADEMA(seq_desconto,ind_tipo_desconto,val_limite_inicial,val_valor_desconto) VALUES('3','1','1','100.000')
	INSERT IDA_DESCONTO_DIADEMA(seq_desconto,ind_tipo_desconto,val_limite_inicial,val_valor_desconto) VALUES('4','1','21','100.000')
	INSERT IDA_DESCONTO_DIADEMA(seq_desconto,ind_tipo_desconto,val_limite_inicial,val_valor_desconto) VALUES('5','0','0','0.000')
	INSERT IDA_DESCONTO_DIADEMA(seq_desconto,ind_tipo_desconto,val_limite_inicial,val_valor_desconto) VALUES('6','0','0','0.000')
	INSERT IDA_DESCONTO_DIADEMA(seq_desconto,ind_tipo_desconto,val_limite_inicial,val_valor_desconto) VALUES('7','0','0','0.000')
	INSERT IDA_DESCONTO_DIADEMA(seq_desconto,ind_tipo_desconto,val_limite_inicial,val_valor_desconto) VALUES('60','0','0','0.000')
	INSERT IDA_DESCONTO_DIADEMA(seq_desconto,ind_tipo_desconto,val_limite_inicial,val_valor_desconto) VALUES('63','1','1','100.000')
	INSERT IDA_DESCONTO_DIADEMA(seq_desconto,ind_tipo_desconto,val_limite_inicial,val_valor_desconto) VALUES('64','1','21','100.000')
	INSERT IDA_DESCONTO_DIADEMA(seq_desconto,ind_tipo_desconto,val_limite_inicial,val_valor_desconto) VALUES('80','2','500','10.000')
	INSERT IDA_DESCONTO_DIADEMA(seq_desconto,ind_tipo_desconto,val_limite_inicial,val_valor_desconto) VALUES('84','2','200','4.000')
	INSERT IDA_DESCONTO_DIADEMA(seq_desconto,ind_tipo_desconto,val_limite_inicial,val_valor_desconto) VALUES('86','2','300','6.000')
	INSERT IDA_DESCONTO_DIADEMA(seq_desconto,ind_tipo_desconto,val_limite_inicial,val_valor_desconto) VALUES('88','2','400','8.000')
	INSERT IDA_DESCONTO_DIADEMA(seq_desconto,ind_tipo_desconto,val_limite_inicial,val_valor_desconto) VALUES('90','2','500','10.000')
	INSERT IDA_DESCONTO_DIADEMA(seq_desconto,ind_tipo_desconto,val_limite_inicial,val_valor_desconto) VALUES('94','2','200','4.000')
	INSERT IDA_DESCONTO_DIADEMA(seq_desconto,ind_tipo_desconto,val_limite_inicial,val_valor_desconto) VALUES('96','2','300','6.000')
	INSERT IDA_DESCONTO_DIADEMA(seq_desconto,ind_tipo_desconto,val_limite_inicial,val_valor_desconto) VALUES('98','2','400','8.000')


	----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	INSERT IDA_IMPOSTO_DIADEMA(cod_imposto,val_porcentagem) VALUES('COFINS','3.00')
	INSERT IDA_IMPOSTO_DIADEMA(cod_imposto,val_porcentagem) VALUES('CSLL','1.00')
	INSERT IDA_IMPOSTO_DIADEMA(cod_imposto,val_porcentagem) VALUES('IRRF','4.80')
	INSERT IDA_IMPOSTO_DIADEMA(cod_imposto,val_porcentagem) VALUES('PIS','0.65')


	----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	INSERT IDA_LOCALIZACAO_HIDROMETRO(seq_local,des_local) VALUES('1','FRENTE MEIO')
	INSERT IDA_LOCALIZACAO_HIDROMETRO(seq_local,des_local) VALUES('2','FRENTE LADO DIREITO')
	INSERT IDA_LOCALIZACAO_HIDROMETRO(seq_local,des_local) VALUES('3','FRENTE LADO ESQUERDO')
	INSERT IDA_LOCALIZACAO_HIDROMETRO(seq_local,des_local) VALUES('4','FUNDO MEIO')
	INSERT IDA_LOCALIZACAO_HIDROMETRO(seq_local,des_local) VALUES('5','FUNDO LADO DIREITO')
	INSERT IDA_LOCALIZACAO_HIDROMETRO(seq_local,des_local) VALUES('6','FUNDO LADO ESQUERDO')
	INSERT IDA_LOCALIZACAO_HIDROMETRO(seq_local,des_local) VALUES('7','MEIO LADO DIREITO')
	INSERT IDA_LOCALIZACAO_HIDROMETRO(seq_local,des_local) VALUES('8','MEIO LADO ESQUERDO')
	INSERT IDA_LOCALIZACAO_HIDROMETRO(seq_local,des_local) VALUES('9','DENTRO DO IMOVEL')
	INSERT IDA_LOCALIZACAO_HIDROMETRO(seq_local,des_local) VALUES('10','NA GARAGEM')
	INSERT IDA_LOCALIZACAO_HIDROMETRO(seq_local,des_local) VALUES('11','NA CALCADA MEIO')
	INSERT IDA_LOCALIZACAO_HIDROMETRO(seq_local,des_local) VALUES('12','NA CALCADA LADO DIREITO')
	INSERT IDA_LOCALIZACAO_HIDROMETRO(seq_local,des_local) VALUES('13','NA CALCADA LADO ESQUERDO')
	INSERT IDA_LOCALIZACAO_HIDROMETRO(seq_local,des_local) VALUES('14','HD NA CASA AO LADO')
	INSERT IDA_LOCALIZACAO_HIDROMETRO(seq_local,des_local) VALUES('15','EMBAIXO DO IMOVEL')
GO

	----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('1','VITRINE FECHADA / ABRIGO TRANC          ','VITRINE FECHADA / ABRIGO TRANC          ','O','N','1','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('2','LOCAL ESCURO / OBSTRUIDO                ','LOCAL ESCURO / OBSTRUIDO                ','O','N','1','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('3','LOCAL DESABITADO/ SEM ATIVIDADE / TERREN','','O','P','9','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('4','PORTAO FECHADO                          ','PORTAO FECHADO                          ','O','N','1','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('5','HIDROMETRO NAO LOCALIZADO               ','','O','N','1','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('6','ENDERECO NAO LOCALIZADO                 ','','O','N','1','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('7','USUARIO NAO QUIS ATENDER                ','USUARIO NAO QUIS ATENDER                ','O','N','1','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('8','CAO SOLTO NO IMOVEL                     ','CAO SOLTO NO IMOVEL                     ','O','P','10','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('9','CAO SOLTO NA RUA                        ','CAO SOLTO NA RUA                        ','O','N','1','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('11','HIDROMETRO COM CUPULA SUJA / EMBACADA / ','HIDROMETRO COM CUPULA SUJA / EMBACADA / ','O','N','1','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('12','HIDROMETRO INVERTIDO                    ','','O','S','1','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('13','HIDROMETRO VIOLADO / QUEBRADO           ','','O','P','1','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('14','HIDROMETRO DIFERENTE DO CADASTRADO      ','','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('15','HIDROMETRO COM IDENTIFICAÇÃO ILEGÍVEL   ','','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('16','HIDROMETRO COM VAZAMENTOS               ','','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('17','HIDROMETRO PARADO/LIGAÇÃO CORTADA       ','','O','S','1','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('18','HIDROMETRO INCLINADO / ABRIGO BAIXO     ','HIDROMETRO INCLINADO / ABRIGO BAIXO     ','O','P','10','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('21','SUSPEITA DE FRAUDE                      ','','O','P','10','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('22','LACRE DE CORTE VIOLADO                  ','','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('31','ALUGOU IMOVEL ANTES DESABITADO          ','','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('32','VAZAMENTO NA VALVULA DO BANHEIRO / CX DE','VAZAMENTO NA VALVULA DO BANHEIRO / CX DE','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('33','VAZAMENTO EM TORNEIRAS                  ','VAZAMENTO EM TORNEIRAS                  ','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('34','VAZAMENTO APARENTE EM ENCANAMENTOS      ','VAZAMENTO APARENTE EM ENCANAMENTOS      ','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('35','VAZAMENTO APARENTE CONSERTADO           ','VAZAMENTO APARENTE CONSERTADO           ','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('36','VAZAMENTO NAO APARENTE CONSERTADO       ','VAZAMENTO NAO APARENTE CONSERTADO       ','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('37','IMOVEL EM CONSTRUCAO / REFORMA          ','IMOVEL EM CONSTRUCAO / REFORMA          ','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('38','AUMENTOU NUMERO DE ECONOMIAS / CATEGORIA','','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('39','AUMENTOU NUMERO DE MORADORES / FUNCIONAR','','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('41','CONSUMO MEDIO APARENTEMENTE IMCOMPATIVEL','','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('42','DIMINUIU NUMERO DE MORADORES            ','','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('43','CONSTRUCAO PARALIZADA / ENCERRADA       ','','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('44','USUARIOS EM FERIAS                      ','','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('45','IMOVEL DEMOLIDO                         ','IMOVEL DEMOLIDO                         ','O','P','10','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('46','ABASTECIMENTO ALTERNATIVO               ','','O','P','10','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('47','PEQUENO COMERCIO                        ','','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('48','CALIBRAR HIDROMETRO                     ','','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('51','VAZAMENTO NO RAMAL DE AGUA              ','','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('52','VAZAMENTO NA REDE DE AGUA               ','','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('61','CAVALETE QUEBRADO / COM VAZAMENTO       ','','O','P','10','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('62','REMANEJAR CAVALETE                      ','','O','P','10','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('63','REGISTRO COM VAZAMENTO                  ','','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('66','CALCULO POR MEDIA                       ','CALCULO POR MEDIA                       ','O','N','1','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('71','NENHUMA ANORMALIDADE CONSTATADA         ','NENHUMA ANORMALIDADE CONSTATADA         ','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('72','VIRADA DE HIDROMETRO                    ','','O','S','0','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('77','CALCULO CONSUMO MINIMO                  ','CALCULO CONSUMO MINIMO                  ','O','N','9','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('81','LEITURA NAO REALIZADA / PENDENCIA       ','LEITURA NAO REALIZADA / PENDENCIA       ','O','N','1','S')
	INSERT IDA_OCORRENCIA(cod_ocorrencia,des_ocorrencia,des_mensagem,ind_grupo,ind_leitura,ind_consumo,ind_emite) VALUES('91','ORIENTADO SOBRE VAZAMENTOS              ','ORIENTADO SOBRE VAZAMENTOS              ','O','S','0','S')
GO

	-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	INSERT IDA_PARAMETRO(des_nome,des_valor) VALUES('versao_minima','1.2.3336.7')
GO


	----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	INSERT IDA_PARAMETRO_RETENCAO(ind_retencao,seq_faixa,val_media_inicial,val_media_final,val_variacao_aviso,val_variacao_retencao,ind_unidade_variacao) VALUES('A','1','0','3',NULL,NULL,'C')
	INSERT IDA_PARAMETRO_RETENCAO(ind_retencao,seq_faixa,val_media_inicial,val_media_final,val_variacao_aviso,val_variacao_retencao,ind_unidade_variacao) VALUES('A','2','3','10','80.000',NULL,'P')
	INSERT IDA_PARAMETRO_RETENCAO(ind_retencao,seq_faixa,val_media_inicial,val_media_final,val_variacao_aviso,val_variacao_retencao,ind_unidade_variacao) VALUES('A','3','10','20','70.000','200.000','P')
	INSERT IDA_PARAMETRO_RETENCAO(ind_retencao,seq_faixa,val_media_inicial,val_media_final,val_variacao_aviso,val_variacao_retencao,ind_unidade_variacao) VALUES('A','4','20','30','60.000','150.000','P')
	INSERT IDA_PARAMETRO_RETENCAO(ind_retencao,seq_faixa,val_media_inicial,val_media_final,val_variacao_aviso,val_variacao_retencao,ind_unidade_variacao) VALUES('A','5','30','50','50.000','100.000','P')
	INSERT IDA_PARAMETRO_RETENCAO(ind_retencao,seq_faixa,val_media_inicial,val_media_final,val_variacao_aviso,val_variacao_retencao,ind_unidade_variacao) VALUES('A','6','50','9999999','40.000','100.000','P')
	INSERT IDA_PARAMETRO_RETENCAO(ind_retencao,seq_faixa,val_media_inicial,val_media_final,val_variacao_aviso,val_variacao_retencao,ind_unidade_variacao) VALUES('D','1','0','3',NULL,NULL,'C')
	INSERT IDA_PARAMETRO_RETENCAO(ind_retencao,seq_faixa,val_media_inicial,val_media_final,val_variacao_aviso,val_variacao_retencao,ind_unidade_variacao) VALUES('D','2','3','10','50.000',NULL,'P')
	INSERT IDA_PARAMETRO_RETENCAO(ind_retencao,seq_faixa,val_media_inicial,val_media_final,val_variacao_aviso,val_variacao_retencao,ind_unidade_variacao) VALUES('D','3','10','20','40.000',NULL,'P')
	INSERT IDA_PARAMETRO_RETENCAO(ind_retencao,seq_faixa,val_media_inicial,val_media_final,val_variacao_aviso,val_variacao_retencao,ind_unidade_variacao) VALUES('D','4','20','30','35.000',NULL,'P')
	INSERT IDA_PARAMETRO_RETENCAO(ind_retencao,seq_faixa,val_media_inicial,val_media_final,val_variacao_aviso,val_variacao_retencao,ind_unidade_variacao) VALUES('D','5','30','50','30.000',NULL,'P')
	INSERT IDA_PARAMETRO_RETENCAO(ind_retencao,seq_faixa,val_media_inicial,val_media_final,val_variacao_aviso,val_variacao_retencao,ind_unidade_variacao) VALUES('D','6','50','9999999','25.000',NULL,'P')


	----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	INSERT IDA_TAXA(seq_taxa,des_taxa) VALUES('1','ÁGUA')
	INSERT IDA_TAXA(seq_taxa,des_taxa) VALUES('2','ESGOTO')
GO


	----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	INSERT IDA_TIPO_ENTREGA(seq_tipo_entrega,des_tipo_entrega) VALUES('0','Não Entregue')
	INSERT IDA_TIPO_ENTREGA(seq_tipo_entrega,des_tipo_entrega) VALUES('1','Cliente')
	INSERT IDA_TIPO_ENTREGA(seq_tipo_entrega,des_tipo_entrega) VALUES('2','Casa ao Lado')
	INSERT IDA_TIPO_ENTREGA(seq_tipo_entrega,des_tipo_entrega) VALUES('3','Porta')
	INSERT IDA_TIPO_ENTREGA(seq_tipo_entrega,des_tipo_entrega) VALUES('4','Caixa de Correio')
	INSERT IDA_TIPO_ENTREGA(seq_tipo_entrega,des_tipo_entrega) VALUES('5','Recusado')
	INSERT IDA_TIPO_ENTREGA(seq_tipo_entrega,des_tipo_entrega) VALUES('6','Portão Fechado')
	INSERT IDA_TIPO_ENTREGA(seq_tipo_entrega,des_tipo_entrega) VALUES('7','Não Executado')
	INSERT IDA_TIPO_ENTREGA(seq_tipo_entrega,des_tipo_entrega) VALUES('8','Outro')
GO


-- =============================================
-- Author:		<Alexis Moura>
-- Create date: <23/07/2010>
-- Description:	<Criação da Functions de geração de codigo de barra> 
-- =============================================
	
	CREATE function FC_RESTO
			   (@NVAL INT, @NDEC INT)
		RETURNS INT
		with ENCRYPTION 
		as
		BEGIN
			RETURN @NVAL - (round(@NVAL/@NDEC,0,1)*@NDEC)
		END
	GO	
	CREATE FUNCTION FC_DIGITO_10
		 (@s_P_Texto varchar(100))
		returns integer
		with ENCRYPTION 
		as
		BEGIN
		   declare @sTexto     Varchar(100),
				   @nPos       integer,
				   @nLen       integer,
				   @nInd       integer,
				   @nAux       integer,
				   @nTotal     integer,
				   @nDigito    integer

		   set @sTexto = ltrim(rTrim(@s_P_Texto))
		   set @nInd   = 2
		   set @nLen   = Len( @sTexto )
		   set @nPos   = @nLen
		   set @nTotal = 0

		   While @nPos > 0 
		   begin
			  SET @nAux = convert(int, Substring( @sTexto, @nPos, 1 ) )
			  SET @nAux = (@nAux * @nInd)

			  If @nAux < 10
			  begin
				 set @nTotal = (@nTotal + @nAux)
			  end
			  else
			  begin
				 set @nTotal = (@nTotal + 1) 
				 set @nTotal = (@nTotal + (@nAux - 10))
			  end

			  If @nInd = 2
			  BEGIN
				 set @nInd = 1
			  END
			  else
			  BEGIN
				 set @nInd = 2
			  END

			  set @nPos = (@nPos - 1)
		   end
		   select @nDigito = dbo.FC_RESTO(@nTotal, 10)
		   If @nDigito != 0 BEGIN
			  SET @nDigito = (10 - @nDigito)
		   end 
		   Return @nDigito
		END
		
	GO	
	CREATE FUNCTION FC_CODIGO_BARRAS_CONTROLE(@sAuxiliar varchar(44))
		returns varchar(50)
		with ENCRYPTION 
		as
		BEGIN
		   declare @sResultado varchar(50),
				   @nDig01     Int,
				   @nDig02     Int,
				   @nDig03     Int,
				   @nDig04     Int
				   
		   set @sResultado = ''

		   if len(@sAuxiliar) = 44 begin

			  set @nDig01 = dbo.FC_DIGITO_10(Substring(@sAuxiliar, 01, 11))
			  set @nDig02 = dbo.FC_DIGITO_10(Substring(@sAuxiliar, 12, 11))
			  set @nDig03 = dbo.FC_DIGITO_10(Substring(@sAuxiliar, 23, 11))
			  set @nDig04 = dbo.FC_DIGITO_10(Substring(@sAuxiliar, 34, 11))

			  set @sResultado  = Substring(@sAuxiliar, 01, 11) + 
								 convert(char(1), @nDig01 )    + 
								 Substring(@sAuxiliar, 12, 11) +
								 convert(char(1), @nDig02 )    + 
								 Substring(@sAuxiliar, 23, 11) +
								 convert(char(1), @nDig03 )    + 
								 Substring(@sAuxiliar, 34, 11) +
								 convert(char(1), @nDig04 )    
		   end
		   return @sResultado
		END 
	GO

-- =============================================
-- Author:		<Alexis Moura>
-- Create date: <15/09/2010>
-- Description:	<Adicionando os campos repassse e ind_situacao_movimento> 
-- =============================================

ALTER TABLE VOLTA_LEITURA ADD Flag_Situacao_Movimento nchar (1), Flag_Repasse nchar (1)
GO

-- =============================================
-- Author:		<Alexis Moura>
-- Create date: <17/09/2010>
-- Description:	<Inserindo usuario administrador> 
-- =============================================

INSERT IDA_USUARIO
		(
			
			Nome,
			Login,
			Senha
		) VALUES
		(
			
			'ADMIN',
			'ADMIN',
			'698dc19d489c4e4db73e28a713eab07b'
		);
	

