-- Script Date: 21/5/2010 10:33  - Generated by ExportSqlCe version 3.0.0.2
-- Database information:
-- locale identifier: 1033
-- encryption mode: 
-- case sensitive: False
-- Database: D:\Velp\Sistemas\SANED\OnPlace.sdf
-- ServerVersion: 3.5.8080.0
-- DatabaseSize: 2527232
-- Created: 17/5/2010 11:38

-- User Table information:
-- Number of tables: 45
-- ONP_AGENTE: 35 row(s)
-- ONP_AVISO_DEBITO: 65 row(s)
-- ONP_CATEGORIA: 8 row(s)
-- ONP_CATEGORIA_DIADEMA: 0 row(s)
-- ONP_DESCONTO_DIADEMA: 17 row(s)
-- ONP_FATURA: 610 row(s)
-- ONP_FATURA_CATEGORIA: 433 row(s)
-- ONP_FATURA_IMPOSTO_DIADEMA: 0 row(s)
-- ONP_FATURA_SERVICO: 0 row(s)
-- ONP_FATURA_TAXA: 0 row(s)
-- ONP_FATURAS_AVISO: 112 row(s)
-- ONP_GRUPO_FATURA: 1 row(s)
-- ONP_HIDROMETRO: 334 row(s)
-- ONP_HISTORICO: 2520 row(s)
-- ONP_IMPOSTO_DIADEMA: 4 row(s)
-- ONP_LOCALIZACAO_HIDROMETRO: 15 row(s)
-- ONP_LOGRADOURO: 1 row(s)
-- ONP_MATRICULA: 334 row(s)
-- ONP_MATRICULA_ALTERACAO: 0 row(s)
-- ONP_MATRICULA_DIADEMA: 334 row(s)
-- ONP_MATRICULA_SCS: 0 row(s)
-- ONP_MATRICULA_SERVICO: 0 row(s)
-- ONP_MATRICULAS_CARGA: 334 row(s)
-- ONP_MENSAGEM_MOVIMENTO: 99 row(s)
-- ONP_MOVIMENTO: 334 row(s)
-- ONP_MOVIMENTO_CATEGORIA: 336 row(s)
-- ONP_MOVIMENTO_FOTO: 0 row(s)
-- ONP_MOVIMENTO_OCORRENCIA: 0 row(s)
-- ONP_MOVIMENTO_TAXA: 672 row(s)
-- ONP_MOVIMENTO_TAXA_SCS: 0 row(s)
-- ONP_OCORRENCIA: 47 row(s)
-- ONP_PARAMETRO: 1 row(s)
-- ONP_PARAMETRO_RETENCAO: 12 row(s)
-- ONP_QUALIDADE_AGUA: 7 row(s)
-- ONP_REFERENCIA_PENDENTE: 423 row(s)
-- ONP_ROTEIRO: 1 row(s)
-- ONP_SERVICO: 0 row(s)
-- ONP_SERVICO_FATURA: 171 row(s)
-- ONP_TABELAS_CARGA: 19 row(s)
-- ONP_TAXA: 2 row(s)
-- ONP_TAXA_TARIFA: 28 row(s)
-- ONP_TAXA_TARIFA_FAIXA: 144 row(s)
-- ONP_TAXA_TARIFA_SCS: 0 row(s)
-- ONP_TIPO_ENTREGA: 9 row(s)
-- ONP_UTILIZACAO_LIGACAO: 8 row(s)

CREATE TABLE [ONP_AGENTE] (
  [cod_agente] numeric(7,0) NOT NULL
, [nom_agente] nvarchar(40) NOT NULL
, [des_senha] nvarchar(40) NOT NULL
);
GO
CREATE TABLE [ONP_AVISO_DEBITO] (
  [seq_matricula] numeric(9,0) NOT NULL
, [dat_emissao] datetime NOT NULL
, [ind_documento] nvarchar(1) NULL
, [ind_pagavel] nvarchar(1) NULL
, [val_quantidade_debito] numeric(4,0) NULL
, [val_impressoes] numeric(2,0) NULL
, [ind_protocolado] nvarchar(1) NULL
, [seq_fatura] numeric(11,0) NULL
);
GO
CREATE TABLE [ONP_CATEGORIA] (
  [seq_categoria] numeric(3,0) NOT NULL
, [des_categoria] nvarchar(30) NOT NULL
);
GO
CREATE TABLE [ONP_CATEGORIA_DIADEMA] (
  [seq_categoria] numeric(3,0) NOT NULL
, [val_minimo] numeric(5,2) NULL
);
GO
CREATE TABLE [ONP_DESCONTO_DIADEMA] (
  [seq_desconto] numeric(3,0) NOT NULL
, [ind_tipo_desconto] nvarchar(1) NULL
, [val_limite_inicial] numeric(7,0) NULL
, [val_valor_desconto] numeric(6,3) NULL
);
GO
CREATE TABLE [ONP_FATURA] (
  [seq_fatura] numeric(11,0) NOT NULL
, [cod_referencia] nvarchar(8) NOT NULL
, [seq_roteiro] numeric(12,0) NOT NULL
, [seq_matricula] numeric(9,0) NOT NULL
, [seq_tipo_entrega] numeric(3,0) NULL
, [cod_hidrometro] nvarchar(12) NULL
, [ind_fatura_emitida] nvarchar(1) NULL
, [dat_vencimento] datetime NULL
, [val_arredonda_anterior] numeric(3,2) NULL
, [val_arredonda_atual] numeric(3,2) NULL
, [dat_hora_emissao] datetime NULL
, [val_valor_faturado] numeric(11,3) NULL
, [dat_leitura] datetime NULL
, [dat_leitura_anterior] datetime NULL
, [ind_entrega_especial] nvarchar(1) NULL
, [des_banco_debito] nvarchar(30) NULL
, [des_banco_agencia_debito] nvarchar(20) NULL
, [val_quantidade_pendente] numeric(4,0) NULL
, [val_consumo_medio] numeric(7,0) NULL
, [val_desconto] numeric(11,3) NULL
, [des_linha_digitavel] nvarchar(48) NULL
, [des_codigo_barras] nvarchar(44) NULL
, [val_consumo_medido] numeric(7,0) NULL
, [val_consumo_atribuido] numeric(7,0) NULL
, [val_consumo_rateado] numeric(7,0) NULL
, [val_leitura_anterior] numeric(7,0) NULL
, [val_leitura_real] numeric(7,0) NULL
, [val_leitura_atribuida] numeric(7,0) NULL
, [val_impressoes] numeric(2,0) NULL
, [dat_proxima_leitura] datetime NULL
, [val_valor_credito] numeric(11,3) NULL
);
GO
CREATE TABLE [ONP_FATURA_CATEGORIA] (
  [seq_categoria] numeric(3,0) NOT NULL
, [seq_fatura] numeric(11,0) NOT NULL
, [cod_referencia] nvarchar(8) NOT NULL
, [seq_roteiro] numeric(12,0) NOT NULL
, [seq_matricula] numeric(9,0) NOT NULL
, [val_numero_economia] numeric(3,0) NULL
, [val_valor_faturado] numeric(11,3) NULL
);
GO
CREATE TABLE [ONP_FATURA_IMPOSTO_DIADEMA] (
  [seq_fatura] numeric(11,0) NOT NULL
, [cod_referencia] nvarchar(8) NOT NULL
, [seq_roteiro] numeric(12,0) NOT NULL
, [seq_matricula] numeric(9,0) NOT NULL
, [cod_imposto] nvarchar(16) NOT NULL
, [val_valor_calculado] numeric(11,3) NULL
);
GO
CREATE TABLE [ONP_FATURA_SERVICO] (
  [seq_fatura] numeric(11,0) NOT NULL
, [seq_item_servico] numeric(3,0) NOT NULL
, [cod_referencia] nvarchar(8) NOT NULL
, [seq_roteiro] numeric(12,0) NOT NULL
, [seq_matricula] numeric(9,0) NOT NULL
, [des_servico] nvarchar(60) NULL
, [seq_parcela] numeric(3,0) NULL
, [val_parcela] numeric(11,3) NULL
, [ind_credito] nvarchar(1) NULL
);
GO
CREATE TABLE [ONP_FATURA_TAXA] (
  [seq_taxa] numeric(5,0) NOT NULL
, [seq_categoria] numeric(3,0) NOT NULL
, [seq_fatura] numeric(11,0) NOT NULL
, [cod_referencia] nvarchar(8) NOT NULL
, [seq_roteiro] numeric(12,0) NOT NULL
, [seq_matricula] numeric(9,0) NOT NULL
, [val_numero_economia] numeric(3,0) NULL
, [val_consumo_faturado] numeric(7,0) NULL
, [val_valor_calculado] numeric(11,3) NULL
, [val_valor_faturado] numeric(11,3) NULL
, [ind_situacao] nvarchar(1) NULL
, [ind_tipo_consumo] nvarchar(1) NULL
);
GO
CREATE TABLE [ONP_FATURAS_AVISO] (
  [seq_matricula] numeric(9,0) NOT NULL
, [seq_fatura] numeric(11,0) NOT NULL
, [cod_referencia] nvarchar(8) NULL
, [dat_vencimento] datetime NULL
, [val_valor_fatura] numeric(11,3) NULL
);
GO
CREATE TABLE [ONP_GRUPO_FATURA] (
  [seq_grupo_fatura] numeric(7,0) NOT NULL
, [ind_tipo_vencimento] nvarchar(1) NULL
, [num_dias] numeric(3,0) NULL
, [des_dias_vencimento] nvarchar(256) NULL
);
GO
CREATE TABLE [ONP_HIDROMETRO] (
  [cod_hidrometro] nvarchar(12) NOT NULL
, [seq_matricula] numeric(9,0) NOT NULL
, [seq_local] numeric(3,0) NULL
, [cod_marca] nvarchar(3) NULL
, [seq_tamanho_hidrometro] numeric(3,0) NULL
, [val_numero_digitos] numeric(3,0) NULL
, [seq_diametro_ligacao] numeric(3,0) NULL
, [dat_fabricacao] datetime NULL
, [dat_aquisicao] datetime NULL
, [des_classe] nvarchar(30) NULL
);
GO
CREATE TABLE [ONP_HISTORICO] (
  [seq_matricula] numeric(9,0) NOT NULL
, [cod_referencia] nvarchar(8) NOT NULL
, [val_consumo] numeric(7,0) NULL
, [cod_ocorrencia] nvarchar(3) NULL
);
GO
CREATE TABLE [ONP_IMPOSTO_DIADEMA] (
  [cod_imposto] nvarchar(16) NOT NULL
, [val_porcentagem] numeric(5,2) NULL
);
GO
CREATE TABLE [ONP_LOCALIZACAO_HIDROMETRO] (
  [seq_local] numeric(3,0) NOT NULL
, [des_local] nvarchar(30) NOT NULL
);
GO
CREATE TABLE [ONP_LOGRADOURO] (
  [seq_logradouro] numeric(9,0) NOT NULL
, [des_logradouro] nvarchar(60) NOT NULL
);
GO
CREATE TABLE [ONP_MATRICULA] (
  [seq_matricula] numeric(9,0) NOT NULL
, [seq_logradouro] numeric(9,0) NULL
, [seq_utilizacao_ligacao] numeric(3,0) NULL
, [nom_cliente] nvarchar(40) NULL
, [val_numero_imovel] numeric(6,0) NULL
, [des_complemento] nvarchar(40) NULL
, [ind_processado] nvarchar(1) NULL
, [seq_rota] numeric(7,0) NULL
, [seq_leitura] numeric(7,0) NULL
, [ind_impresso] nvarchar(1) NULL
, [des_cep] nvarchar(12) NULL
, [seq_zona_abastecimento] numeric(7,0) NULL
, [val_fotos_minima] numeric(3,0) NULL
, [val_fotos_maxima] numeric(3,0) NULL
, [des_inscricao] nvarchar(40) NULL
, [des_endereco_alternativo] nvarchar(80) NULL
);
GO
CREATE TABLE [ONP_MATRICULA_ALTERACAO] (
  [seq_matricula] numeric(9,0) NOT NULL
, [ind_dado_alterado] nvarchar(2) NOT NULL
, [seq_item] numeric(3,0) NOT NULL
, [des_conteudo_anterior] nvarchar(40) NOT NULL
, [des_conteudo_novo] nvarchar(40) NOT NULL
);
GO
CREATE TABLE [ONP_MATRICULA_DIADEMA] (
  [seq_matricula] numeric(9,0) NOT NULL
, [seq_matricula_pai] numeric(9,0) NULL
, [seq_desconto] numeric(3,0) NULL
, [ind_corta_ligacao] nvarchar(1) NULL
, [ind_cortou_ligacao] nvarchar(1) NULL
, [ind_retencao_impostos] nvarchar(1) NULL
, [ind_bloqueio] nvarchar(1) NULL
, [val_dias_bloqueio_anterior] numeric(7,0) NULL
, [val_dias_bloqueio_atual] numeric(7,0) NULL
, [ind_cachorro] nvarchar(1) NULL
, [val_fraudes] numeric(5,0) NULL
, [ind_emite_fatura] nvarchar(1) NULL
, [ind_calcula_fatura] nvarchar(1) NULL
, [ind_tipo_consumidor] nvarchar(2) NULL
, [des_mensagem_1] nvarchar(30) NULL
, [des_mensagem_2] nvarchar(180) NULL
, [dat_bloqueio] datetime NULL
);
GO
CREATE TABLE [ONP_MATRICULA_SCS] (
  [seq_matricula] numeric(9,0) NOT NULL
, [ind_lancamento] nvarchar(1) NULL
);
GO
CREATE TABLE [ONP_MATRICULA_SERVICO] (
  [seq_item] numeric(2,0) NOT NULL
, [seq_matricula] numeric(9,0) NOT NULL
, [seq_servico] numeric(4,0) NULL
, [ind_solicitante] nvarchar(1) NULL
);
GO
CREATE TABLE [ONP_MATRICULAS_CARGA] (
  [seq_matricula] numeric(9,0) NOT NULL
, [ind_carga] nvarchar(1) NOT NULL
, [ind_descarga] nvarchar(1) NOT NULL
);
GO
CREATE TABLE [ONP_MENSAGEM_MOVIMENTO] (
  [seq_mensagem_movimento] numeric(7,0) NOT NULL
, [seq_matricula] numeric(9,0) NULL
, [seq_roteiro] numeric(12,0) NULL
, [seq_grupo_fatura] numeric(7,0) NULL
, [des_mensagem_movimento] nvarchar(500) NOT NULL
, [dat_inicio] datetime NULL
, [dat_final] datetime NULL
, [seq_tipo_documento] numeric(3,0) NULL
);
GO
CREATE TABLE [ONP_MOVIMENTO] (
  [cod_referencia] nvarchar(8) NOT NULL
, [seq_roteiro] numeric(12,0) NOT NULL
, [seq_matricula] numeric(9,0) NOT NULL
, [cod_agente] numeric(7,0) NOT NULL
, [cod_hidrometro] nvarchar(12) NULL
, [seq_tipo_entrega] numeric(3,0) NULL
, [val_leitura_anterior] numeric(7,0) NULL
, [val_leitura_real] numeric(7,0) NULL
, [val_leitura_atribuida] numeric(7,0) NULL
, [val_numero_leituras] numeric(5,0) NULL
, [ind_leitura_divergente] nvarchar(1) NULL
, [val_consumo_medido] numeric(7,0) NULL
, [val_consumo_medio] numeric(7,0) NULL
, [val_consumo_atribuido] numeric(7,0) NULL
, [val_consumo_troca] numeric(7,0) NULL
, [val_consumo_rateado] numeric(7,0) NULL
, [des_banco_debito] nvarchar(30) NULL
, [des_banco_agencia_debito] nvarchar(20) NULL
, [dat_leitura] datetime NULL
, [dat_proxima_leitura] datetime NULL
, [dat_vencimento] datetime NULL
, [dat_leitura_anterior] datetime NULL
, [ind_entrega_especial] nvarchar(1) NULL
, [val_quantidade_pendente] numeric(4,0) NULL
, [val_desconto] numeric(11,3) NULL
, [ind_motivo_retirada] nvarchar(1) NULL
, [dat_troca] datetime NULL
, [ind_situacao_movimento] nvarchar(1) NULL
, [ind_fatura_emitida] nvarchar(1) NULL
, [val_arredonda_anterior] numeric(3,2) NULL
, [val_impressoes] numeric(2,0) NULL
, [val_consumo_estimado] numeric(7,0) NULL
);
GO
CREATE TABLE [ONP_MOVIMENTO_CATEGORIA] (
  [cod_referencia] nvarchar(8) NOT NULL
, [seq_roteiro] numeric(12,0) NOT NULL
, [seq_matricula] numeric(9,0) NOT NULL
, [seq_categoria] numeric(3,0) NOT NULL
, [val_numero_economia] numeric(3,0) NULL
, [val_valor_faturado] numeric(11,3) NULL
);
GO
CREATE TABLE [ONP_MOVIMENTO_FOTO] (
  [cod_referencia] nvarchar(8) NOT NULL
, [seq_roteiro] numeric(12,0) NOT NULL
, [seq_matricula] numeric(9,0) NOT NULL
, [seq_foto] numeric(3,0) NOT NULL
, [arq_foto] image NULL
, [des_caminho] nvarchar(100) NULL
);
GO
CREATE TABLE [ONP_MOVIMENTO_OCORRENCIA] (
  [cod_referencia] nvarchar(8) NOT NULL
, [seq_matricula] numeric(9,0) NOT NULL
, [cod_ocorrencia] numeric(3,0) NOT NULL
, [seq_roteiro] numeric(12,0) NOT NULL
, [seq_sequencial] numeric(2,0) NOT NULL
);
GO
CREATE TABLE [ONP_MOVIMENTO_TAXA] (
  [seq_taxa] numeric(5,0) NOT NULL
, [cod_referencia] nvarchar(8) NOT NULL
, [seq_matricula] numeric(9,0) NOT NULL
, [seq_categoria] numeric(3,0) NOT NULL
, [seq_roteiro] numeric(12,0) NOT NULL
, [val_economias] numeric(3,0) NULL
, [val_consumo_fixo] numeric(7,0) NULL
, [val_consumo_estimado] numeric(7,0) NULL
, [ind_situacao] nvarchar(1) NULL
);
GO
CREATE TABLE [ONP_MOVIMENTO_TAXA_SCS] (
  [seq_taxa] numeric(5,0) NOT NULL
, [cod_referencia] nvarchar(8) NOT NULL
, [seq_matricula] numeric(9,0) NOT NULL
, [seq_categoria] numeric(3,0) NOT NULL
, [seq_roteiro] numeric(12,0) NOT NULL
, [val_percentual_desconto] numeric(5,2) NULL
);
GO
CREATE TABLE [ONP_OCORRENCIA] (
  [cod_ocorrencia] numeric(3,0) NOT NULL
, [des_ocorrencia] nvarchar(40) NOT NULL
, [des_mensagem] nvarchar(40) NOT NULL
, [ind_grupo] nvarchar(1) NULL
, [ind_leitura] nvarchar(1) NULL
, [ind_consumo] nvarchar(2) NULL
, [ind_emite] nvarchar(1) NULL
);
GO
CREATE TABLE [ONP_PARAMETRO] (
  [des_nome] nvarchar(40) NOT NULL
, [des_valor] nvarchar(150) NULL
);
GO
CREATE TABLE [ONP_PARAMETRO_RETENCAO] (
  [ind_retencao] nvarchar(1) NOT NULL
, [seq_faixa] numeric(3,0) NOT NULL
, [val_media_inicial] numeric(7,0) NULL
, [val_media_final] numeric(7,0) NULL
, [val_variacao_aviso] numeric(11,3) NULL
, [val_variacao_retencao] numeric(11,3) NULL
, [ind_unidade_variacao] nvarchar(1) NULL
);
GO
CREATE TABLE [ONP_QUALIDADE_AGUA] (
  [seq_zona_abastecimento] numeric(7,0) NOT NULL
, [dat_referencia] datetime NOT NULL
, [seq_parametro] numeric(3,0) NOT NULL
, [des_parametro] nvarchar(40) NULL
, [val_previstas] numeric(4,0) NULL
, [val_realizadas] numeric(4,0) NULL
, [val_fora_limite] numeric(4,0) NULL
, [val_media] numeric(5,2) NULL
);
GO
CREATE TABLE [ONP_REFERENCIA_PENDENTE] (
  [seq_matricula] numeric(9,0) NOT NULL
, [seq_fatura] numeric(11,0) NOT NULL
, [dat_vencimento] datetime NOT NULL
);
GO
CREATE TABLE [ONP_ROTEIRO] (
  [seq_roteiro] numeric(12,0) NOT NULL
, [seq_grupo_fatura] numeric(7,0) NULL
, [ind_fatura] nvarchar(1) NULL
, [dat_base] datetime NULL
, [cod_referencia] nvarchar(8) NULL
, [dat_servidor] datetime NULL
);
GO
CREATE TABLE [ONP_SERVICO] (
  [seq_servico] numeric(4,0) NOT NULL
, [des_servico] nvarchar(40) NOT NULL
, [val_servico] numeric(11,3) NOT NULL
);
GO
CREATE TABLE [ONP_SERVICO_FATURA] (
  [seq_matricula] numeric(9,0) NOT NULL
, [seq_item_servico] numeric(3,0) NOT NULL
, [cod_referencia] nvarchar(8) NOT NULL
, [seq_roteiro] numeric(12,0) NOT NULL
, [des_servico] nvarchar(60) NULL
, [seq_plano] numeric(2,0) NULL
, [seq_parcela] numeric(3,0) NULL
, [val_parcela] numeric(11,3) NULL
, [ind_credito] nvarchar(1) NULL
, [val_diferenca_fatura] numeric(11,3) NULL
);
GO
CREATE TABLE [ONP_TABELAS_CARGA] (
  [nom_tabela] nvarchar(30) NOT NULL
, [ind_carga] nvarchar(1) NOT NULL
, [ind_descarga] nvarchar(1) NOT NULL
);
GO
CREATE TABLE [ONP_TAXA] (
  [seq_taxa] numeric(5,0) NOT NULL
, [des_taxa] nvarchar(60) NOT NULL
);
GO
CREATE TABLE [ONP_TAXA_TARIFA] (
  [seq_categoria] numeric(3,0) NOT NULL
, [seq_taxa] numeric(5,0) NOT NULL
, [seq_taxa_tarifa] numeric(9,0) NOT NULL
, [seq_taxa_base] numeric(5,0) NULL
, [dat_inicio] datetime NULL
, [ind_tipo_taxa] nvarchar(1) NULL
, [ind_escalonada] nvarchar(1) NULL
, [ind_dias_consumo] nvarchar(1) NULL
, [ind_minimo] nvarchar(1) NULL
, [ind_proporcional] nvarchar(1) NULL
, [val_valor_tarifa] numeric(11,3) NULL
, [val_percentual] numeric(5,2) NULL
);
GO
CREATE TABLE [ONP_TAXA_TARIFA_FAIXA] (
  [seq_categoria] numeric(3,0) NOT NULL
, [seq_taxa_tarifa] numeric(9,0) NOT NULL
, [seq_taxa] numeric(5,0) NOT NULL
, [seq_taxa_tarifa_faixa] numeric(5,0) NOT NULL
, [val_limite_consumo] numeric(7,0) NULL
, [val_valor_tarifa] numeric(11,3) NULL
);
GO
CREATE TABLE [ONP_TAXA_TARIFA_SCS] (
  [seq_categoria] numeric(3,0) NOT NULL
, [seq_taxa_tarifa] numeric(9,0) NOT NULL
, [seq_taxa] numeric(5,0) NOT NULL
, [val_minimo] numeric(11,3) NULL
);
GO
CREATE TABLE [ONP_TIPO_ENTREGA] (
  [seq_tipo_entrega] numeric(3,0) NOT NULL
, [des_tipo_entrega] nvarchar(30) NOT NULL
);
GO
CREATE TABLE [ONP_UTILIZACAO_LIGACAO] (
  [seq_utilizacao_ligacao] numeric(3,0) NOT NULL
, [des_utilizacao_ligacao] nvarchar(60) NULL
);
GO
ALTER TABLE [ONP_AGENTE] ADD CONSTRAINT [PK__ONP_AGENTE__0000000000000008] PRIMARY KEY ([cod_agente]);
GO
ALTER TABLE [ONP_AVISO_DEBITO] ADD CONSTRAINT [PK__ONP_AVISO_DEBITO__000000000000001D] PRIMARY KEY ([seq_matricula]);
GO
ALTER TABLE [ONP_CATEGORIA] ADD CONSTRAINT [PK__ONP_CATEGORIA__0000000000000026] PRIMARY KEY ([seq_categoria]);
GO
ALTER TABLE [ONP_CATEGORIA_DIADEMA] ADD CONSTRAINT [PK__ONP_CATEGORIA_DIADEMA__000000000000002F] PRIMARY KEY ([seq_categoria]);
GO
ALTER TABLE [ONP_DESCONTO_DIADEMA] ADD CONSTRAINT [PK__ONP_DESCONTO_DIADEMA__000000000000003C] PRIMARY KEY ([seq_desconto]);
GO
ALTER TABLE [ONP_FATURA] ADD CONSTRAINT [PK__ONP_FATURA__000000000000007F] PRIMARY KEY ([seq_fatura],[cod_referencia],[seq_roteiro],[seq_matricula]);
GO
ALTER TABLE [ONP_FATURA_CATEGORIA] ADD CONSTRAINT [PK__ONP_FATURA_CATEGORIA__0000000000000098] PRIMARY KEY ([seq_categoria],[seq_fatura],[cod_referencia],[seq_roteiro],[seq_matricula]);
GO
ALTER TABLE [ONP_FATURA_IMPOSTO_DIADEMA] ADD CONSTRAINT [PK__ONP_FATURA_IMPOSTO_DIADEMA__00000000000000AF] PRIMARY KEY ([seq_fatura],[cod_referencia],[seq_roteiro],[seq_matricula],[cod_imposto]);
GO
ALTER TABLE [ONP_FATURA_SERVICO] ADD CONSTRAINT [PK__ONP_FATURA_SERVICO__00000000000000CC] PRIMARY KEY ([seq_fatura],[seq_item_servico],[cod_referencia],[seq_roteiro],[seq_matricula]);
GO
ALTER TABLE [ONP_FATURA_TAXA] ADD CONSTRAINT [PK__ONP_FATURA_TAXA__00000000000000EC] PRIMARY KEY ([seq_taxa],[seq_categoria],[seq_fatura],[cod_referencia],[seq_roteiro],[seq_matricula]);
GO
ALTER TABLE [ONP_FATURAS_AVISO] ADD CONSTRAINT [PK__ONP_FATURAS_AVISO__0000000000000104] PRIMARY KEY ([seq_matricula],[seq_fatura]);
GO
ALTER TABLE [ONP_GRUPO_FATURA] ADD CONSTRAINT [PK__ONP_GRUPO_FATURA__0000000000000114] PRIMARY KEY ([seq_grupo_fatura]);
GO
ALTER TABLE [ONP_HIDROMETRO] ADD CONSTRAINT [PK__ONP_HIDROMETRO__000000000000012D] PRIMARY KEY ([cod_hidrometro],[seq_matricula]);
GO
ALTER TABLE [ONP_HISTORICO] ADD CONSTRAINT [PK__ONP_HISTORICO__0000000000000140] PRIMARY KEY ([seq_matricula],[cod_referencia]);
GO
ALTER TABLE [ONP_IMPOSTO_DIADEMA] ADD CONSTRAINT [PK__ONP_IMPOSTO_DIADEMA__000000000000014C] PRIMARY KEY ([cod_imposto]);
GO
ALTER TABLE [ONP_LOCALIZACAO_HIDROMETRO] ADD CONSTRAINT [PK__ONP_LOCALIZACAO_HIDROMETRO__0000000000000155] PRIMARY KEY ([seq_local]);
GO
ALTER TABLE [ONP_LOGRADOURO] ADD CONSTRAINT [PK__ONP_LOGRADOURO__000000000000015E] PRIMARY KEY ([seq_logradouro]);
GO
ALTER TABLE [ONP_MATRICULA] ADD CONSTRAINT [PK__ONP_MATRICULA__0000000000000183] PRIMARY KEY ([seq_matricula]);
GO
ALTER TABLE [ONP_MATRICULA_ALTERACAO] ADD CONSTRAINT [PK__ONP_MATRICULA_ALTERACAO__0000000000000198] PRIMARY KEY ([seq_matricula],[ind_dado_alterado],[seq_item]);
GO
ALTER TABLE [ONP_MATRICULA_DIADEMA] ADD CONSTRAINT [PK__ONP_MATRICULA_DIADEMA__00000000000001C2] PRIMARY KEY ([seq_matricula]);
GO
ALTER TABLE [ONP_MATRICULA_SCS] ADD CONSTRAINT [PK__ONP_MATRICULA_SCS__00000000000001D1] PRIMARY KEY ([seq_matricula]);
GO
ALTER TABLE [ONP_MATRICULA_SERVICO] ADD CONSTRAINT [PK__ONP_MATRICULA_SERVICO__00000000000001DE] PRIMARY KEY ([seq_item],[seq_matricula]);
GO
ALTER TABLE [ONP_MATRICULAS_CARGA] ADD CONSTRAINT [PK__ONP_MATRICULAS_CARGA__00000000000001EF] PRIMARY KEY ([seq_matricula]);
GO
ALTER TABLE [ONP_MENSAGEM_MOVIMENTO] ADD CONSTRAINT [PK__ONP_MENSAGEM_MOVIMENTO__0000000000000204] PRIMARY KEY ([seq_mensagem_movimento]);
GO
ALTER TABLE [ONP_MOVIMENTO] ADD CONSTRAINT [PK__ONP_MOVIMENTO__0000000000000252] PRIMARY KEY ([cod_referencia],[seq_roteiro],[seq_matricula]);
GO
ALTER TABLE [ONP_MOVIMENTO_CATEGORIA] ADD CONSTRAINT [PK__ONP_MOVIMENTO_CATEGORIA__0000000000000272] PRIMARY KEY ([cod_referencia],[seq_roteiro],[seq_matricula],[seq_categoria]);
GO
ALTER TABLE [ONP_MOVIMENTO_FOTO] ADD CONSTRAINT [PK__ONP_MOVIMENTO_FOTO__0000000000000289] PRIMARY KEY ([cod_referencia],[seq_roteiro],[seq_matricula],[seq_foto]);
GO
ALTER TABLE [ONP_MOVIMENTO_OCORRENCIA] ADD CONSTRAINT [PK__ONP_MOVIMENTO_OCORRENCIA__000000000000029B] PRIMARY KEY ([cod_referencia],[seq_matricula],[cod_ocorrencia],[seq_roteiro],[seq_sequencial]);
GO
ALTER TABLE [ONP_MOVIMENTO_TAXA] ADD CONSTRAINT [PK__ONP_MOVIMENTO_TAXA__00000000000002B8] PRIMARY KEY ([seq_taxa],[cod_referencia],[seq_matricula],[seq_categoria],[seq_roteiro]);
GO
ALTER TABLE [ONP_MOVIMENTO_TAXA_SCS] ADD CONSTRAINT [PK__ONP_MOVIMENTO_TAXA_SCS__00000000000002CF] PRIMARY KEY ([seq_taxa],[cod_referencia],[seq_matricula],[seq_categoria],[seq_roteiro]);
GO
ALTER TABLE [ONP_OCORRENCIA] ADD CONSTRAINT [PK__ONP_OCORRENCIA__00000000000002E2] PRIMARY KEY ([cod_ocorrencia]);
GO
ALTER TABLE [ONP_PARAMETRO] ADD CONSTRAINT [PK__ONP_PARAMETRO__00000000000002EB] PRIMARY KEY ([des_nome]);
GO
ALTER TABLE [ONP_PARAMETRO_RETENCAO] ADD CONSTRAINT [PK__ONP_PARAMETRO_RETENCAO__00000000000002FE] PRIMARY KEY ([ind_retencao],[seq_faixa]);
GO
ALTER TABLE [ONP_QUALIDADE_AGUA] ADD CONSTRAINT [PK__ONP_QUALIDADE_AGUA__0000000000000313] PRIMARY KEY ([seq_zona_abastecimento],[dat_referencia],[seq_parametro]);
GO
ALTER TABLE [ONP_REFERENCIA_PENDENTE] ADD CONSTRAINT [PK__ONP_REFERENCIA_PENDENTE__000000000000031E] PRIMARY KEY ([seq_matricula],[seq_fatura]);
GO
ALTER TABLE [ONP_ROTEIRO] ADD CONSTRAINT [PK__ONP_ROTEIRO__0000000000000332] PRIMARY KEY ([seq_roteiro]);
GO
ALTER TABLE [ONP_SERVICO] ADD CONSTRAINT [PK__ONP_SERVICO__0000000000000340] PRIMARY KEY ([seq_servico]);
GO
ALTER TABLE [ONP_SERVICO_FATURA] ADD CONSTRAINT [PK__ONP_SERVICO_FATURA__0000000000000359] PRIMARY KEY ([seq_matricula],[seq_item_servico],[cod_referencia],[seq_roteiro]);
GO
ALTER TABLE [ONP_TABELAS_CARGA] ADD CONSTRAINT [PK__ONP_TABELAS_CARGA__0000000000000367] PRIMARY KEY ([nom_tabela]);
GO
ALTER TABLE [ONP_TAXA] ADD CONSTRAINT [PK__ONP_TAXA__0000000000000370] PRIMARY KEY ([seq_taxa]);
GO
ALTER TABLE [ONP_TAXA_TARIFA] ADD CONSTRAINT [PK__ONP_TAXA_TARIFA__000000000000038D] PRIMARY KEY ([seq_categoria],[seq_taxa],[seq_taxa_tarifa]);
GO
ALTER TABLE [ONP_TAXA_TARIFA_FAIXA] ADD CONSTRAINT [PK__ONP_TAXA_TARIFA_FAIXA__00000000000003A7] PRIMARY KEY ([seq_categoria],[seq_taxa_tarifa],[seq_taxa],[seq_taxa_tarifa_faixa]);
GO
ALTER TABLE [ONP_TAXA_TARIFA_SCS] ADD CONSTRAINT [PK__ONP_TAXA_TARIFA_SCS__00000000000003B7] PRIMARY KEY ([seq_categoria],[seq_taxa_tarifa],[seq_taxa]);
GO
ALTER TABLE [ONP_TIPO_ENTREGA] ADD CONSTRAINT [PK__ONP_TIPO_ENTREGA__00000000000003C0] PRIMARY KEY ([seq_tipo_entrega]);
GO
ALTER TABLE [ONP_UTILIZACAO_LIGACAO] ADD CONSTRAINT [PK__ONP_UTILIZACAO_LIGACAO__00000000000003C9] PRIMARY KEY ([seq_utilizacao_ligacao]);
GO
CREATE INDEX [XIF2ONP_FATURA] ON [ONP_FATURA] ([seq_tipo_entrega] ASC);
GO
CREATE INDEX [XIF3ONP_FATURA] ON [ONP_FATURA] ([cod_referencia] ASC,[seq_roteiro] ASC,[seq_matricula] ASC);
GO
CREATE INDEX [XIF1ONP_FATURA_CATEGORIA] ON [ONP_FATURA_CATEGORIA] ([seq_categoria] ASC);
GO
CREATE INDEX [XIF2ONP_FATURA_CATEGORIA] ON [ONP_FATURA_CATEGORIA] ([seq_fatura] ASC,[cod_referencia] ASC,[seq_roteiro] ASC,[seq_matricula] ASC);
GO
CREATE INDEX [XIF2ONP_FATURA_IMPOSTO_DIADEMA] ON [ONP_FATURA_IMPOSTO_DIADEMA] ([seq_fatura] ASC,[cod_referencia] ASC,[seq_roteiro] ASC,[seq_matricula] ASC);
GO
CREATE INDEX [XIF3ONP_FATURA_IMPOSTO_DIADEMA] ON [ONP_FATURA_IMPOSTO_DIADEMA] ([cod_imposto] ASC);
GO
CREATE INDEX [XIF1ONP_FATURA_SERVICO] ON [ONP_FATURA_SERVICO] ([seq_fatura] ASC,[cod_referencia] ASC,[seq_roteiro] ASC,[seq_matricula] ASC);
GO
CREATE INDEX [XIF2ONP_FATURA_TAXA] ON [ONP_FATURA_TAXA] ([seq_taxa] ASC);
GO
CREATE INDEX [XIF3ONP_FATURA_TAXA] ON [ONP_FATURA_TAXA] ([seq_categoria] ASC);
GO
CREATE INDEX [XIF4ONP_FATURA_TAXA] ON [ONP_FATURA_TAXA] ([seq_categoria] ASC,[seq_fatura] ASC,[cod_referencia] ASC,[seq_roteiro] ASC,[seq_matricula] ASC);
GO
CREATE INDEX [XIF1ONP_FATURAS_AVISO] ON [ONP_FATURAS_AVISO] ([seq_matricula] ASC);
GO
CREATE INDEX [XIF1ONP_HIDROMETRO] ON [ONP_HIDROMETRO] ([seq_local] ASC);
GO
CREATE INDEX [XIF2ONP_HIDROMETRO] ON [ONP_HIDROMETRO] ([seq_matricula] ASC);
GO
CREATE INDEX [XIF1ONP_HISTORICO] ON [ONP_HISTORICO] ([seq_matricula] ASC);
GO
CREATE INDEX [XIF1ONP_MATRICULA] ON [ONP_MATRICULA] ([seq_logradouro] ASC);
GO
CREATE INDEX [XIF2ONP_MATRICULA] ON [ONP_MATRICULA] ([seq_utilizacao_ligacao] ASC);
GO
CREATE INDEX [XIF1ONP_MATRICULA_ALTERACAO] ON [ONP_MATRICULA_ALTERACAO] ([seq_matricula] ASC);
GO
CREATE INDEX [XIF2ONP_MATRICULA_DIADEMA] ON [ONP_MATRICULA_DIADEMA] ([seq_matricula_pai] ASC);
GO
CREATE INDEX [XIF3ONP_MATRICULA_DIADEMA] ON [ONP_MATRICULA_DIADEMA] ([seq_desconto] ASC);
GO
CREATE INDEX [XIF1ONP_MATRICULA_SERVICO] ON [ONP_MATRICULA_SERVICO] ([seq_matricula] ASC);
GO
CREATE INDEX [XIF2ONP_MATRICULA_SERVICO] ON [ONP_MATRICULA_SERVICO] ([seq_servico] ASC);
GO
CREATE INDEX [XIF1ONP_MENSAGEM_MOVIMENTO] ON [ONP_MENSAGEM_MOVIMENTO] ([seq_matricula] ASC);
GO
CREATE INDEX [XIF2ONP_MENSAGEM_MOVIMENTO] ON [ONP_MENSAGEM_MOVIMENTO] ([seq_grupo_fatura] ASC);
GO
CREATE INDEX [XIF3ONP_MENSAGEM_MOVIMENTO] ON [ONP_MENSAGEM_MOVIMENTO] ([seq_roteiro] ASC);
GO
CREATE INDEX [XIF1ONP_MOVIMENTO] ON [ONP_MOVIMENTO] ([cod_agente] ASC);
GO
CREATE INDEX [XIF2ONP_MOVIMENTO] ON [ONP_MOVIMENTO] ([seq_matricula] ASC);
GO
CREATE INDEX [XIF3ONP_MOVIMENTO] ON [ONP_MOVIMENTO] ([cod_hidrometro] ASC,[seq_matricula] ASC);
GO
CREATE INDEX [XIF4ONP_MOVIMENTO] ON [ONP_MOVIMENTO] ([seq_roteiro] ASC);
GO
CREATE INDEX [XIF5ONP_MOVIMENTO] ON [ONP_MOVIMENTO] ([seq_tipo_entrega] ASC);
GO
CREATE INDEX [XIF1ONP_MOVIMENTO_CATEGORIA] ON [ONP_MOVIMENTO_CATEGORIA] ([cod_referencia] ASC,[seq_matricula] ASC,[seq_roteiro] ASC);
GO
CREATE INDEX [XIF2ONP_MOVIMENTO_CATEGORIA] ON [ONP_MOVIMENTO_CATEGORIA] ([seq_categoria] ASC);
GO
CREATE INDEX [XIF1ONP_MOVIMENTO_FOTO] ON [ONP_MOVIMENTO_FOTO] ([cod_referencia] ASC,[seq_roteiro] ASC,[seq_matricula] ASC);
GO
CREATE INDEX [XIF1ONP_MOVIMENTO_OCORRENCIA] ON [ONP_MOVIMENTO_OCORRENCIA] ([cod_referencia] ASC,[seq_matricula] ASC,[seq_roteiro] ASC);
GO
CREATE INDEX [XIF2ONP_MOVIMENTO_OCORRENCIA] ON [ONP_MOVIMENTO_OCORRENCIA] ([cod_ocorrencia] ASC);
GO
CREATE INDEX [XIF2ONP_MOVIMENTO_TAXA] ON [ONP_MOVIMENTO_TAXA] ([seq_taxa] ASC);
GO
CREATE INDEX [XIF3ONP_MOVIMENTO_TAXA] ON [ONP_MOVIMENTO_TAXA] ([cod_referencia] ASC,[seq_matricula] ASC,[seq_categoria] ASC,[seq_roteiro] ASC);
GO
CREATE INDEX [XIF1ONP_REFERENCIA_PENDENTE] ON [ONP_REFERENCIA_PENDENTE] ([seq_matricula] ASC);
GO
CREATE INDEX [XIF1ONP_ROTEIRO] ON [ONP_ROTEIRO] ([seq_grupo_fatura] ASC);
GO
CREATE INDEX [XIF1ONP_SERVICO_FATURA] ON [ONP_SERVICO_FATURA] ([cod_referencia] ASC,[seq_matricula] ASC,[seq_roteiro] ASC);
GO
CREATE INDEX [XIF1ONP_TAXA_TARIFA] ON [ONP_TAXA_TARIFA] ([seq_categoria] ASC);
GO
CREATE INDEX [XIF3ONP_TAXA_TARIFA] ON [ONP_TAXA_TARIFA] ([seq_taxa] ASC);
GO
CREATE INDEX [XIF4ONP_TAXA_TARIFA] ON [ONP_TAXA_TARIFA] ([seq_taxa_base] ASC);
GO
CREATE INDEX [XIF1ONP_TAXA_TARIFA_FAIXA] ON [ONP_TAXA_TARIFA_FAIXA] ([seq_categoria] ASC,[seq_taxa_tarifa] ASC,[seq_taxa] ASC);
GO

