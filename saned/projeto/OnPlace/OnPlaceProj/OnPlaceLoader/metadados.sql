
CREATE TABLE ONP_AGENTE (
       cod_agente           numeric(7) NOT NULL,
       nom_agente           nvarchar(40) NULL,
       des_senha            nvarchar(40) NULL
);
go

CREATE UNIQUE INDEX XPKONP_AGENTE ON ONP_AGENTE
(
       cod_agente                    
);
go


CREATE TABLE ONP_AVISO_DEBITO (
       seq_matricula        numeric(9) NOT NULL,
       dat_emissao          datetime NOT NULL,
       ind_documento        nvarchar(1) NULL,
       ind_pagavel          nvarchar(1) NULL,
       val_quantidade_debito numeric(4) NULL,
       val_impressoes       numeric(2) NULL,
       ind_protocolado      nvarchar(1) NULL,
       seq_fatura           numeric(11) NULL
);
go

CREATE UNIQUE INDEX XPKONP_AVISO_DEBITO ON ONP_AVISO_DEBITO
(
       seq_matricula                 
);
go


CREATE TABLE ONP_CATEGORIA (
       seq_categoria        numeric(3) NOT NULL,
       des_categoria        nvarchar(30) NOT NULL
);
go

CREATE UNIQUE INDEX XPKONP_CATEGORIA ON ONP_CATEGORIA
(
       seq_categoria                 
);
go


CREATE TABLE ONP_CATEGORIA_DIADEMA (
       seq_categoria        numeric(3) NOT NULL,
       val_minimo           numeric(5,2) NULL
);
go

CREATE UNIQUE INDEX XPKONP_CATEGORIA_DIADEMA ON ONP_CATEGORIA_DIADEMA
(
       seq_categoria                 
);
go


CREATE TABLE ONP_DESCONTO_DIADEMA (
       seq_desconto         numeric(3) NOT NULL,
       ind_tipo_desconto    nvarchar(1) NULL,
       val_limite_inicial   numeric(7) NULL,
       val_valor_desconto   numeric(6,3) NULL
);
go

CREATE UNIQUE INDEX XPKONP_DESCONTO_DIADEMA ON ONP_DESCONTO_DIADEMA
(
       seq_desconto                  
);
go


CREATE TABLE ONP_FATURA (
       seq_fatura           numeric(11) NOT NULL,
       cod_referencia       nvarchar(8) NOT NULL,
       seq_roteiro          numeric(12) NOT NULL,
       seq_matricula        numeric(9) NOT NULL,
       seq_tipo_entrega     numeric(3) NULL,
       cod_hidrometro       nvarchar(12) NULL,
       ind_fatura_emitida   nvarchar(1) NULL,
       dat_vencimento       datetime NULL,
       val_arredonda_anterior numeric(3,2) NULL,
       val_arredonda_atual  numeric(3,2) NULL,
       dat_hora_emissao     datetime NULL,
       val_valor_faturado   numeric(11,3) NULL,
       dat_leitura          datetime NULL,
       dat_leitura_anterior datetime NULL,
       ind_entrega_especial nvarchar(1) NULL,
       des_banco_debito     nvarchar(30) NULL,
       des_banco_agencia_debito nvarchar(20) NULL,
       val_quantidade_pendente numeric(4) NULL,
       val_consumo_medio    numeric(7) NULL,
       val_desconto         numeric(11,3) NULL,
       des_linha_digitavel  nvarchar(48) NULL,
       des_codigo_barras    nvarchar(44) NULL,
       val_consumo_medido   numeric(7) NULL,
       val_consumo_atribuido numeric(7) NULL,
       val_consumo_rateado  numeric(7) NULL,
       val_leitura_anterior numeric(7) NULL,
       val_leitura_real     numeric(7) NULL,
       val_leitura_atribuida numeric(7) NULL,
       val_impressoes       numeric(2) NULL,
       dat_proxima_leitura  datetime NULL,
       val_valor_credito    numeric(11,3) NULL
);
go

CREATE UNIQUE INDEX XPKONP_FATURA ON ONP_FATURA
(
       seq_fatura                    ,
       cod_referencia                ,
       seq_roteiro                   ,
       seq_matricula                 
);
go

CREATE INDEX XIF2ONP_FATURA ON ONP_FATURA
(
       seq_tipo_entrega              
);
go

CREATE INDEX XIF3ONP_FATURA ON ONP_FATURA
(
       cod_referencia                ,
       seq_roteiro                   ,
       seq_matricula                 
);
go


CREATE TABLE ONP_FATURA_CATEGORIA (
       seq_categoria        numeric(3) NOT NULL,
       seq_fatura           numeric(11) NOT NULL,
       cod_referencia       nvarchar(8) NOT NULL,
       seq_roteiro          numeric(12) NOT NULL,
       seq_matricula        numeric(9) NOT NULL,
       val_numero_economia  numeric(3) NULL,
       val_valor_faturado   numeric(11,3) NULL
);
go

CREATE UNIQUE INDEX XPKONP_FATURA_CATEGORIA ON ONP_FATURA_CATEGORIA
(
       seq_categoria                 ,
       seq_fatura                    ,
       cod_referencia                ,
       seq_roteiro                   ,
       seq_matricula                 
);
go

CREATE INDEX XIF1ONP_FATURA_CATEGORIA ON ONP_FATURA_CATEGORIA
(
       seq_categoria                 
);
go

CREATE INDEX XIF2ONP_FATURA_CATEGORIA ON ONP_FATURA_CATEGORIA
(
       seq_fatura                    ,
       cod_referencia                ,
       seq_roteiro                   ,
       seq_matricula                 
);
go


CREATE TABLE ONP_FATURA_IMPOSTO_DIADEMA (
       seq_fatura           numeric(11) NOT NULL,
       cod_referencia       nvarchar(8) NOT NULL,
       seq_roteiro          numeric(12) NOT NULL,
       seq_matricula        numeric(9) NOT NULL,
       cod_imposto          nvarchar(16) NOT NULL,
       val_valor_calculado  numeric(11,3) NULL
);
go

CREATE UNIQUE INDEX XPKONP_FATURA_IMPOSTO_DIADEMA ON ONP_FATURA_IMPOSTO_DIADEMA
(
       seq_fatura                    ,
       cod_referencia                ,
       seq_roteiro                   ,
       seq_matricula                 ,
       cod_imposto                   
);
go

CREATE INDEX XIF2ONP_FATURA_IMPOSTO_DIADEMA ON ONP_FATURA_IMPOSTO_DIADEMA
(
       seq_fatura                    ,
       cod_referencia                ,
       seq_roteiro                   ,
       seq_matricula                 
);
go

CREATE INDEX XIF3ONP_FATURA_IMPOSTO_DIADEMA ON ONP_FATURA_IMPOSTO_DIADEMA
(
       cod_imposto                   
);
go


CREATE TABLE ONP_FATURA_SERVICO (
       seq_fatura           numeric(11) NOT NULL,
       seq_item_servico     numeric(3) NOT NULL,
       cod_referencia       nvarchar(8) NOT NULL,
       seq_roteiro          numeric(12) NOT NULL,
       seq_matricula        numeric(9) NOT NULL,
       des_servico          nvarchar(60) NULL,
       seq_parcela          numeric(3) NULL,
       val_parcela          numeric(11,3) NULL,
       ind_credito          nvarchar(1) NULL
);
go

CREATE UNIQUE INDEX XPKONP_FATURA_SERVICO ON ONP_FATURA_SERVICO
(
       seq_fatura                    ,
       seq_item_servico              ,
       cod_referencia                ,
       seq_roteiro                   ,
       seq_matricula                 
);
go

CREATE INDEX XIF1ONP_FATURA_SERVICO ON ONP_FATURA_SERVICO
(
       seq_fatura                    ,
       cod_referencia                ,
       seq_roteiro                   ,
       seq_matricula                 
);
go


CREATE TABLE ONP_FATURA_TAXA (
       seq_taxa             numeric(5) NOT NULL,
       seq_categoria        numeric(3) NOT NULL,
       seq_fatura           numeric(11) NOT NULL,
       cod_referencia       nvarchar(8) NOT NULL,
       seq_roteiro          numeric(12) NOT NULL,
       seq_matricula        numeric(9) NOT NULL,
       val_numero_economia  numeric(3) NULL,
       val_consumo_faturado numeric(7) NULL,
       val_valor_calculado  numeric(11,3) NULL,
       val_valor_faturado   numeric(11,3) NULL,
       ind_situacao         nvarchar(1) NULL,
       ind_tipo_consumo     nvarchar(1) NULL
);
go

CREATE UNIQUE INDEX XPKONP_FATURA_TAXA ON ONP_FATURA_TAXA
(
       seq_taxa                      ,
       seq_categoria                 ,
       seq_fatura                    ,
       cod_referencia                ,
       seq_roteiro                   ,
       seq_matricula                 
);
go

CREATE INDEX XIF2ONP_FATURA_TAXA ON ONP_FATURA_TAXA
(
       seq_taxa                      
);
go

CREATE INDEX XIF3ONP_FATURA_TAXA ON ONP_FATURA_TAXA
(
       seq_categoria                 
);
go

CREATE INDEX XIF4ONP_FATURA_TAXA ON ONP_FATURA_TAXA
(
       seq_categoria                 ,
       seq_fatura                    ,
       cod_referencia                ,
       seq_roteiro                   ,
       seq_matricula                 
);
go


CREATE TABLE ONP_FATURAS_AVISO (
       seq_matricula        numeric(9) NOT NULL,
       seq_fatura           numeric(11) NOT NULL,
       cod_referencia       nvarchar(8) NULL,
       dat_vencimento       datetime NULL,
       val_valor_fatura     numeric(11,3) NULL
);
go

CREATE UNIQUE INDEX XPKONP_FATURAS_AVISO ON ONP_FATURAS_AVISO
(
       seq_matricula                 ,
       seq_fatura                    
);
go

CREATE INDEX XIF1ONP_FATURAS_AVISO ON ONP_FATURAS_AVISO
(
       seq_matricula                 
);
go


CREATE TABLE ONP_GRUPO_FATURA (
       seq_grupo_fatura     numeric(7) NOT NULL,
       ind_tipo_vencimento  nvarchar(1) NULL,
       num_dias             numeric(3) NULL,
       des_dias_vencimento  nvarchar(256) NULL
);
go

CREATE UNIQUE INDEX XPKONP_GRUPO_FATURA ON ONP_GRUPO_FATURA
(
       seq_grupo_fatura              
);
go


CREATE TABLE ONP_HIDROMETRO (
       cod_hidrometro       nvarchar(12) NOT NULL,
       seq_matricula        numeric(9) NOT NULL,
       seq_local            numeric(3) NULL,
       cod_marca            nvarchar(3) NULL,
       seq_tamanho_hidrometro numeric(3) NULL,
       val_numero_digitos   numeric(3) NULL,
       seq_diametro_ligacao numeric(3) NULL,
       dat_fabricacao       datetime NULL,
       dat_aquisicao        datetime NULL,
       des_classe           nvarchar(30) NULL
);
go

CREATE UNIQUE INDEX XPKONP_HIDROMETRO ON ONP_HIDROMETRO
(
       cod_hidrometro                ,
       seq_matricula                 
);
go

CREATE INDEX XIF1ONP_HIDROMETRO ON ONP_HIDROMETRO
(
       seq_local                     
);
go

CREATE INDEX XIF2ONP_HIDROMETRO ON ONP_HIDROMETRO
(
       seq_matricula                 
);
go


CREATE TABLE ONP_HISTORICO (
       seq_matricula        numeric(9) NOT NULL,
       cod_referencia       nvarchar(8) NOT NULL,
       val_consumo          numeric(7) NULL,
       cod_ocorrencia       nvarchar(3) NULL
);
go

CREATE UNIQUE INDEX XPKONP_HISTORICO ON ONP_HISTORICO
(
       seq_matricula                 ,
       cod_referencia                
);
go

CREATE INDEX XIF1ONP_HISTORICO ON ONP_HISTORICO
(
       seq_matricula                 
);
go


CREATE TABLE ONP_IMPOSTO_DIADEMA (
       cod_imposto          nvarchar(16) NOT NULL,
       val_porcentagem      numeric(5,2) NULL
);
go

CREATE UNIQUE INDEX XPKONP_IMPOSTO_DIADEMA ON ONP_IMPOSTO_DIADEMA
(
       cod_imposto                   
);
go


CREATE TABLE ONP_LOCALIZACAO_HIDROMETRO (
       seq_local            numeric(3) NOT NULL,
       des_local            nvarchar(30) NOT NULL
);
go

CREATE UNIQUE INDEX XPKONP_LOCALIZACAO_HIDROMETRO ON ONP_LOCALIZACAO_HIDROMETRO
(
       seq_local                     
);
go


CREATE TABLE ONP_LOGRADOURO (
       seq_logradouro       numeric(9) NOT NULL,
       des_logradouro       nvarchar(60) NOT NULL
);
go

CREATE UNIQUE INDEX XPKONP_LOGRADOURO ON ONP_LOGRADOURO
(
       seq_logradouro                
);
go


CREATE TABLE ONP_MATRICULA (
       seq_matricula        numeric(9) NOT NULL,
       seq_logradouro       numeric(9) NULL,
       seq_utilizacao_ligacao numeric(3) NULL,
       nom_cliente          nvarchar(40) NULL,
       val_numero_imovel    numeric(6) NULL,
       des_complemento      nvarchar(40) NULL,
       ind_processado       nvarchar(1) NULL,
       seq_rota             numeric(7) NULL,
       seq_leitura          numeric(7) NULL,
       ind_impresso         nvarchar(1) NULL,
       des_cep              nvarchar(12) NULL,
       seq_zona_abastecimento numeric(7) NULL,
       val_fotos_minima     numeric(3) NULL,
       val_fotos_maxima     numeric(3) NULL,
       des_inscricao        nvarchar(40) NULL,
       des_endereco_alternativo nvarchar(80) NULL
);
go

CREATE UNIQUE INDEX XPKONP_MATRICULA ON ONP_MATRICULA
(
       seq_matricula                 
);
go

CREATE INDEX XIF1ONP_MATRICULA ON ONP_MATRICULA
(
       seq_logradouro                
);
go

CREATE INDEX XIF2ONP_MATRICULA ON ONP_MATRICULA
(
       seq_utilizacao_ligacao        
);
go


CREATE TABLE ONP_MATRICULA_ALTERACAO (
       seq_matricula        numeric(9) NOT NULL,
       ind_dado_alterado    nvarchar(2) NOT NULL,
       seq_item             numeric(3) NOT NULL,
       des_conteudo_anterior nvarchar(40) NOT NULL,
       des_conteudo_novo    nvarchar(40) NOT NULL
);
go

CREATE UNIQUE INDEX XPKONP_MATRICULA_ALTERACAO ON ONP_MATRICULA_ALTERACAO
(
       seq_matricula                 ,
       ind_dado_alterado             ,
       seq_item                      
);
go

CREATE INDEX XIF1ONP_MATRICULA_ALTERACAO ON ONP_MATRICULA_ALTERACAO
(
       seq_matricula                 
);
go


CREATE TABLE ONP_MATRICULA_DIADEMA (
       seq_matricula        numeric(9) NOT NULL,
       seq_matricula_pai    numeric(9) NULL,
       seq_desconto         numeric(3) NULL,
       ind_corta_ligacao    nvarchar(1) NULL,
       ind_cortou_ligacao   nvarchar(1) NULL,
       ind_retencao_impostos nvarchar(1) NULL,
       ind_bloqueio         nvarchar(1) NULL,
       val_dias_bloqueio_anterior numeric(3) NULL,
       val_dias_bloqueio_atual numeric(3) NULL,
       ind_cachorro         nvarchar(1) NULL,
       val_fraudes          numeric(5) NULL,
       ind_emite_fatura     nvarchar(1) NULL,
       ind_calcula_fatura   nvarchar(1) NULL,
       ind_tipo_consumidor  nvarchar(2) NULL,
       des_mensagem_1       nvarchar(30) NULL,
       des_mensagem_2       nvarchar(180) NULL,
       dat_bloqueio         datetime NULL
);
go

CREATE UNIQUE INDEX XPKONP_MATRICULA_DIADEMA ON ONP_MATRICULA_DIADEMA
(
       seq_matricula                 
);
go

CREATE INDEX XIF2ONP_MATRICULA_DIADEMA ON ONP_MATRICULA_DIADEMA
(
       seq_matricula_pai             
);
go

CREATE INDEX XIF3ONP_MATRICULA_DIADEMA ON ONP_MATRICULA_DIADEMA
(
       seq_desconto                  
);
go


CREATE TABLE ONP_MATRICULA_SERVICO (
       seq_item             numeric(2) NOT NULL,
       seq_matricula        numeric(9) NOT NULL,
       seq_servico          numeric(4) NULL,
       ind_solicitante      nvarchar(1) NULL
);
go

CREATE UNIQUE INDEX XPKONP_MATRICULA_SERVICO ON ONP_MATRICULA_SERVICO
(
       seq_item                      ,
       seq_matricula                 
);
go

CREATE INDEX XIF1ONP_MATRICULA_SERVICO ON ONP_MATRICULA_SERVICO
(
       seq_matricula                 
);
go

CREATE INDEX XIF2ONP_MATRICULA_SERVICO ON ONP_MATRICULA_SERVICO
(
       seq_servico                   
);
go


CREATE TABLE ONP_MATRICULAS_CARGA (
       seq_matricula        numeric(9) NOT NULL,
       ind_carga            nvarchar(1) NOT NULL,
       ind_descarga         nvarchar(1) NOT NULL
);
go

CREATE UNIQUE INDEX XPKONP_MATRICULAS_CARGA ON ONP_MATRICULAS_CARGA
(
       seq_matricula                 
);
go


CREATE TABLE ONP_MENSAGEM_MOVIMENTO (
       seq_mensagem_movimento numeric(7) NOT NULL,
       seq_matricula        numeric(9) NULL,
       seq_roteiro          numeric(12) NULL,
       seq_grupo_fatura     numeric(7) NULL,
       des_mensagem_movimento nvarchar(500) NOT NULL,
       dat_inicio           datetime NULL,
       dat_final            datetime NULL,
       seq_tipo_documento   numeric(3) NULL
);
go

CREATE UNIQUE INDEX XPKONP_MENSAGEM_MOVIMENTO ON ONP_MENSAGEM_MOVIMENTO
(
       seq_mensagem_movimento        
);
go

CREATE INDEX XIF1ONP_MENSAGEM_MOVIMENTO ON ONP_MENSAGEM_MOVIMENTO
(
       seq_matricula                 
);
go

CREATE INDEX XIF2ONP_MENSAGEM_MOVIMENTO ON ONP_MENSAGEM_MOVIMENTO
(
       seq_grupo_fatura              
);
go

CREATE INDEX XIF3ONP_MENSAGEM_MOVIMENTO ON ONP_MENSAGEM_MOVIMENTO
(
       seq_roteiro                   
);
go


CREATE TABLE ONP_MOVIMENTO (
       cod_referencia       nvarchar(8) NOT NULL,
       seq_roteiro          numeric(12) NOT NULL,
       seq_matricula        numeric(9) NOT NULL,
       cod_agente           numeric(7) NOT NULL,
       cod_hidrometro       nvarchar(12) NULL,
       seq_tipo_entrega     numeric(3) NULL,
       val_leitura_anterior numeric(7) NULL,
       val_leitura_real     numeric(7) NULL,
       val_leitura_atribuida numeric(7) NULL,
       val_numero_leituras  numeric(5) NULL,
       ind_leitura_divergente nvarchar(1) NULL,
       val_consumo_medido   numeric(7) NULL,
       val_consumo_medio    numeric(7) NULL,
       val_consumo_atribuido numeric(7) NULL,
       val_consumo_troca    numeric(7) NULL,
       val_consumo_rateado  numeric(7) NULL,
       des_banco_debito     nvarchar(30) NULL,
       des_banco_agencia_debito nvarchar(20) NULL,
       dat_leitura          datetime NULL,
       dat_proxima_leitura  datetime NULL,
       dat_vencimento       datetime NULL,
       dat_leitura_anterior datetime NULL,
       ind_entrega_especial nvarchar(1) NULL,
       val_quantidade_pendente numeric(4) NULL,
       val_desconto         numeric(11,3) NULL,
       ind_motivo_retirada  nvarchar(1) NULL,
       dat_troca            datetime NULL,
       ind_situacao_movimento nvarchar(1) NULL,
       ind_fatura_emitida   nvarchar(1) NULL,
       val_arredonda_anterior numeric(3,2) NULL,
       val_impressoes       numeric(2) NULL,
       val_consumo_estimado numeric(7) NULL
);
go

CREATE UNIQUE INDEX XPKONP_MOVIMENTO ON ONP_MOVIMENTO
(
       cod_referencia                ,
       seq_roteiro                   ,
       seq_matricula                 
);
go

CREATE INDEX XIF1ONP_MOVIMENTO ON ONP_MOVIMENTO
(
       cod_agente                    
);
go

CREATE INDEX XIF2ONP_MOVIMENTO ON ONP_MOVIMENTO
(
       seq_matricula                 
);
go

CREATE INDEX XIF3ONP_MOVIMENTO ON ONP_MOVIMENTO
(
       cod_hidrometro                ,
       seq_matricula                 
);
go

CREATE INDEX XIF4ONP_MOVIMENTO ON ONP_MOVIMENTO
(
       seq_roteiro                   
);
go

CREATE INDEX XIF5ONP_MOVIMENTO ON ONP_MOVIMENTO
(
       seq_tipo_entrega              
);
go


CREATE TABLE ONP_MOVIMENTO_CATEGORIA (
       cod_referencia       nvarchar(8) NOT NULL,
       seq_roteiro          numeric(12) NOT NULL,
       seq_matricula        numeric(9) NOT NULL,
       seq_categoria        numeric(3) NOT NULL,
       val_numero_economia  numeric(3) NULL,
       val_valor_faturado   numeric(11,3) NULL
);
go

CREATE UNIQUE INDEX XPKONP_MOVIMENTO_CATEGORIA ON ONP_MOVIMENTO_CATEGORIA
(
       cod_referencia                ,
       seq_roteiro                   ,
       seq_matricula                 ,
       seq_categoria                 
);
go

CREATE INDEX XIF1ONP_MOVIMENTO_CATEGORIA ON ONP_MOVIMENTO_CATEGORIA
(
       cod_referencia                ,
       seq_matricula                 ,
       seq_roteiro                   
);
go

CREATE INDEX XIF2ONP_MOVIMENTO_CATEGORIA ON ONP_MOVIMENTO_CATEGORIA
(
       seq_categoria                 
);
go


CREATE TABLE ONP_MOVIMENTO_FOTO (
       cod_referencia       nvarchar(8) NOT NULL,
       seq_roteiro          numeric(12) NOT NULL,
       seq_matricula        numeric(9) NOT NULL,
       seq_foto             numeric(3) NOT NULL,
       arq_foto             image NULL,
       des_caminho          nvarchar(100) NULL
);
go

CREATE UNIQUE INDEX XPKONP_MOVIMENTO_FOTO ON ONP_MOVIMENTO_FOTO
(
       cod_referencia                ,
       seq_roteiro                   ,
       seq_matricula                 ,
       seq_foto                      
);
go

CREATE INDEX XIF1ONP_MOVIMENTO_FOTO ON ONP_MOVIMENTO_FOTO
(
       cod_referencia                ,
       seq_roteiro                   ,
       seq_matricula                 
);
go


CREATE TABLE ONP_MOVIMENTO_OCORRENCIA (
       cod_referencia       nvarchar(8) NOT NULL,
       seq_matricula        numeric(9) NOT NULL,
       cod_ocorrencia       numeric(3) NOT NULL,
       seq_roteiro          numeric(12) NOT NULL,
       seq_sequencial       numeric(2) NOT NULL
);
go

CREATE UNIQUE INDEX XPKONP_MOVIMENTO_OCORRENCIA ON ONP_MOVIMENTO_OCORRENCIA
(
       cod_referencia                ,
       seq_matricula                 ,
       cod_ocorrencia                ,
       seq_roteiro                   ,
       seq_sequencial                
);
go

CREATE INDEX XIF1ONP_MOVIMENTO_OCORRENCIA ON ONP_MOVIMENTO_OCORRENCIA
(
       cod_referencia                ,
       seq_matricula                 ,
       seq_roteiro                   
);
go

CREATE INDEX XIF2ONP_MOVIMENTO_OCORRENCIA ON ONP_MOVIMENTO_OCORRENCIA
(
       cod_ocorrencia                
);
go


CREATE TABLE ONP_MOVIMENTO_TAXA (
       seq_taxa             numeric(5) NOT NULL,
       cod_referencia       nvarchar(8) NOT NULL,
       seq_matricula        numeric(9) NOT NULL,
       seq_categoria        numeric(3) NOT NULL,
       seq_roteiro          numeric(12) NOT NULL,
       val_economias        numeric(3) NULL,
       val_consumo_fixo     numeric(7) NULL,
       val_consumo_estimado numeric(7) NULL,
       ind_situacao         nvarchar(1) NULL
);
go

CREATE UNIQUE INDEX XPKONP_MOVIMENTO_TAXA ON ONP_MOVIMENTO_TAXA
(
       seq_taxa                      ,
       cod_referencia                ,
       seq_matricula                 ,
       seq_categoria                 ,
       seq_roteiro                   
);
go

CREATE INDEX XIF2ONP_MOVIMENTO_TAXA ON ONP_MOVIMENTO_TAXA
(
       seq_taxa                      
);
go

CREATE INDEX XIF3ONP_MOVIMENTO_TAXA ON ONP_MOVIMENTO_TAXA
(
       cod_referencia                ,
       seq_matricula                 ,
       seq_categoria                 ,
       seq_roteiro                   
);
go


CREATE TABLE ONP_OCORRENCIA (
       cod_ocorrencia       numeric(3) NOT NULL,
       des_ocorrencia       nvarchar(40) NOT NULL,
       des_mensagem         nvarchar(40) NOT NULL,
       ind_grupo            nvarchar(1) NULL,
       ind_leitura          nvarchar(1) NULL,
       ind_consumo          nvarchar(2) NULL,
       ind_emite            nvarchar(1) NULL
);
go

CREATE UNIQUE INDEX XPKONP_OCORRENCIA ON ONP_OCORRENCIA
(
       cod_ocorrencia                
);
go


CREATE TABLE ONP_PARAMETRO (
       des_nome             nvarchar(40) NOT NULL,
       des_valor            nvarchar(150) NULL
);
go

CREATE UNIQUE INDEX XPKONP_PARAMETRO ON ONP_PARAMETRO
(
       des_nome                      
);
go


CREATE TABLE ONP_PARAMETRO_RETENCAO (
       ind_retencao         nvarchar(1) NOT NULL,
       seq_faixa            numeric(3) NOT NULL,
       val_media_inicial    numeric(7) NULL,
       val_media_final      numeric(7) NULL,
       val_variacao_aviso   numeric(11,3) NULL,
       val_variacao_retencao numeric(11,3) NULL,
       ind_unidade_variacao nvarchar(1) NULL
);
go

CREATE UNIQUE INDEX XPKONP_PARAMETRO_RETENCAO ON ONP_PARAMETRO_RETENCAO
(
       ind_retencao                  ,
       seq_faixa                     
);
go


CREATE TABLE ONP_QUALIDADE_AGUA (
       seq_zona_abastecimento numeric(7) NOT NULL,
       dat_referencia       datetime NOT NULL,
       seq_parametro        numeric(3) NOT NULL,
       des_parametro        nvarchar(40) NULL,
       val_previstas        numeric(4) NULL,
       val_realizadas       numeric(4) NULL,
       val_fora_limite      numeric(4) NULL,
       val_media            numeric(5,2) NULL
);
go

CREATE UNIQUE INDEX XPKONP_QUALIDADE_AGUA ON ONP_QUALIDADE_AGUA
(
       seq_zona_abastecimento        ,
       dat_referencia                ,
       seq_parametro                 
);
go


CREATE TABLE ONP_REFERENCIA_PENDENTE (
       seq_matricula        numeric(9) NOT NULL,
       seq_fatura           numeric(11) NOT NULL,
       dat_vencimento       datetime NOT NULL
);
go

CREATE UNIQUE INDEX XPKONP_REFERENCIA_PENDENTE ON ONP_REFERENCIA_PENDENTE
(
       seq_matricula                 ,
       seq_fatura                    
);
go

CREATE INDEX XIF1ONP_REFERENCIA_PENDENTE ON ONP_REFERENCIA_PENDENTE
(
       seq_matricula                 
);
go


CREATE TABLE ONP_ROTEIRO (
       seq_roteiro          numeric(12) NOT NULL,
       seq_grupo_fatura     numeric(7) NULL,
       ind_fatura           nvarchar(1) NULL,
       dat_base             datetime NULL,
       cod_referencia       nvarchar(8) NULL,
       dat_servidor         datetime NULL
);
go

CREATE UNIQUE INDEX XPKONP_ROTEIRO ON ONP_ROTEIRO
(
       seq_roteiro                   
);
go

CREATE INDEX XIF1ONP_ROTEIRO ON ONP_ROTEIRO
(
       seq_grupo_fatura              
);
go


CREATE TABLE ONP_SERVICO (
       seq_servico          numeric(4) NOT NULL,
       des_servico          nvarchar(40) NOT NULL,
       val_servico          numeric(11,3) NOT NULL
);
go

CREATE UNIQUE INDEX XPKONP_SERVICO ON ONP_SERVICO
(
       seq_servico                   
);
go


CREATE TABLE ONP_SERVICO_FATURA (
       seq_matricula        numeric(9) NOT NULL,
       seq_item_servico     numeric(3) NOT NULL,
       cod_referencia       nvarchar(8) NOT NULL,
       seq_roteiro          numeric(12) NOT NULL,
       des_servico          nvarchar(60) NULL,
       seq_plano            numeric(2) NULL,
       seq_parcela          numeric(3) NULL,
       val_parcela          numeric(11,3) NULL,
       ind_credito          nvarchar(1) NULL,
       val_diferenca_fatura numeric(11,3) NULL
);
go

CREATE UNIQUE INDEX XPKONP_SERVICO_FATURA ON ONP_SERVICO_FATURA
(
       seq_matricula                 ,
       seq_item_servico              ,
       cod_referencia                ,
       seq_roteiro                   
);
go

CREATE INDEX XIF1ONP_SERVICO_FATURA ON ONP_SERVICO_FATURA
(
       cod_referencia                ,
       seq_matricula                 ,
       seq_roteiro                   
);
go


CREATE TABLE ONP_TABELAS_CARGA (
       nom_tabela           nvarchar(30) NOT NULL,
       ind_carga            nvarchar(1) NOT NULL,
       ind_descarga         nvarchar(1) NOT NULL
);
go

CREATE UNIQUE INDEX XPKONP_TABELAS_CARGA ON ONP_TABELAS_CARGA
(
       nom_tabela                    
);
go


CREATE TABLE ONP_TAXA (
       seq_taxa             numeric(5) NOT NULL,
       des_taxa             nvarchar(60) NOT NULL
);
go

CREATE UNIQUE INDEX XPKONP_TAXA ON ONP_TAXA
(
       seq_taxa                      
);
go


CREATE TABLE ONP_TAXA_TARIFA (
       seq_categoria        numeric(3) NOT NULL,
       seq_taxa             numeric(5) NOT NULL,
       seq_taxa_tarifa      numeric(9) NOT NULL,
       seq_taxa_base        numeric(5) NULL,
       dat_inicio           datetime NULL,
       ind_tipo_taxa        nvarchar(1) NULL,
       ind_escalonada       nvarchar(1) NULL,
       ind_dias_consumo     nvarchar(1) NULL,
       ind_minimo           nvarchar(1) NULL,
       ind_proporcional     nvarchar(1) NULL,
       val_valor_tarifa     numeric(11,3) NULL,
       val_percentual       numeric(5,2) NULL
);
go

CREATE UNIQUE INDEX XPKONP_TAXA_TARIFA ON ONP_TAXA_TARIFA
(
       seq_categoria                 ,
       seq_taxa                      ,
       seq_taxa_tarifa               
);
go

CREATE INDEX XIF1ONP_TAXA_TARIFA ON ONP_TAXA_TARIFA
(
       seq_categoria                 
);
go

CREATE INDEX XIF3ONP_TAXA_TARIFA ON ONP_TAXA_TARIFA
(
       seq_taxa                      
);
go

CREATE INDEX XIF4ONP_TAXA_TARIFA ON ONP_TAXA_TARIFA
(
       seq_taxa_base                 
);
go


CREATE TABLE ONP_TAXA_TARIFA_FAIXA (
       seq_categoria        numeric(3) NOT NULL,
       seq_taxa_tarifa      numeric(9) NOT NULL,
       seq_taxa             numeric(5) NOT NULL,
       seq_taxa_tarifa_faixa numeric(5) NOT NULL,
       val_limite_consumo   numeric(7) NULL,
       val_valor_tarifa     numeric(11,3) NULL
);
go

CREATE UNIQUE INDEX XPKONP_TAXA_TARIFA_FAIXA ON ONP_TAXA_TARIFA_FAIXA
(
       seq_categoria                 ,
       seq_taxa_tarifa               ,
       seq_taxa                      ,
       seq_taxa_tarifa_faixa         
);
go

CREATE INDEX XIF1ONP_TAXA_TARIFA_FAIXA ON ONP_TAXA_TARIFA_FAIXA
(
       seq_categoria                 ,
       seq_taxa_tarifa               ,
       seq_taxa                      
);
go


CREATE TABLE ONP_TIPO_ENTREGA (
       seq_tipo_entrega     numeric(3) NOT NULL,
       des_tipo_entrega     nvarchar(30) NOT NULL
);
go

CREATE UNIQUE INDEX XPKONP_TIPO_ENTREGA ON ONP_TIPO_ENTREGA
(
       seq_tipo_entrega              
);
go


CREATE TABLE ONP_UTILIZACAO_LIGACAO (
       seq_utilizacao_ligacao numeric(3) NOT NULL,
       des_utilizacao_ligacao nvarchar(60) NULL
);
go

CREATE UNIQUE INDEX XPKONP_UTILIZACAO_LIGACAO ON ONP_UTILIZACAO_LIGACAO
(
       seq_utilizacao_ligacao        
);
go



