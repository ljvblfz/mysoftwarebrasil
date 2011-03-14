#region Usings
using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
#endregion // Usings

namespace OnPlaceLoader.Controladores {
	class ControladorDownloader : Controlador {
		#region Atributos e Propriedades
		private string SCRIPT_TO_DATABASE = "metadados.sql";
		#endregion // Atributos e Propriedades

		public ControladorDownloader() {
		}

		#region Metodos privados
		#region Cargas
		/// <summary>
		/// Sobrescrito em outras classes para fazer cargas especificas de outras tabela
		/// </summary>
		protected virtual void OutrasCargas() {
		}

		private void CarregarAvisoDebito() {
			string cmdText = null, tabela = "ONP_AVISO_DEBITO";
			System.Diagnostics.Trace.TraceInformation("Carregando '{0}'", tabela);

			cmdText = "SELECT ad.* FROM onp_aviso_debito ad, onp_movimento mov WHERE mov.seq_roteiro = @roteiro AND mov.cod_referencia = @referencia AND mov.seq_matricula = ad.seq_matricula";

			ExecutarCommand(tabela, CriarCommand(cmdText));
		}

		private void CarregarFaturaAviso() {
			string cmdText = null, tabela = "ONP_FATURAS_AVISO";
			System.Diagnostics.Trace.TraceInformation("Carregando '{0}'", tabela);

			cmdText = "SELECT fa.* FROM onp_faturas_aviso fa, onp_movimento mov WHERE mov.seq_roteiro = @roteiro AND mov.cod_referencia = @referencia AND mov.seq_matricula = fa.seq_matricula";

			ExecutarCommand(tabela, CriarCommand(cmdText));
		}

		private void CarregarHistorico() {
			string cmdText = null, tabela = "ONP_HISTORICO";
			System.Diagnostics.Trace.TraceInformation("Carregando '{0}'", tabela);

			cmdText = "SELECT hist.* FROM onp_historico hist, onp_movimento mov WHERE hist.cod_referencia < @referencia AND hist.seq_matricula = mov.seq_matricula AND mov.seq_roteiro = @roteiro AND mov.cod_referencia = @referencia";

			ExecutarCommand(tabela, CriarCommand(cmdText));
		}

		private void CarregarLogradouro() {
			string cmdText = null, tabela = "ONP_LOGRADOURO";
			System.Diagnostics.Trace.TraceInformation("Carregando '{0}'", tabela);

			cmdText = "SELECT DISTINCT lg.* FROM onp_logradouro lg, onp_movimento mov, onp_matricula mat WHERE mov.seq_matricula = mat.seq_matricula AND mat.seq_logradouro = lg.seq_logradouro AND mov.seq_roteiro = @roteiro AND mov.cod_referencia = @referencia";

			ExecutarCommand(tabela, CriarCommand(cmdText));
		}

		private void CarregarMatricula() {
			string cmdText = null, tabela = "ONP_MATRICULA";
			System.Diagnostics.Trace.TraceInformation("Carregando '{0}'", tabela);

			cmdText = "SELECT mat.* FROM onp_movimento mov, onp_matricula mat WHERE mov.seq_matricula = mat.seq_matricula AND mov.seq_roteiro = @roteiro AND mov.cod_referencia = @referencia";

			ExecutarCommand(tabela, CriarCommand(cmdText));
		}

		private void CarregarMedidor() {
			string cmdText = null, tabela = "ONP_HIDROMETRO";
			System.Diagnostics.Trace.TraceInformation("Carregando '{0}'", tabela);

			cmdText = "SELECT med.* FROM onp_movimento mov, onp_medidor med WHERE mov.seq_matricula = med.seq_matricula AND mov.seq_roteiro = @roteiro AND mov.cod_referencia = @referencia";

			ExecutarCommand(tabela, CriarCommand(cmdText));
		}

		private void CarregarMensagemMovimento() {
			string cmdText = null, tabela = "ONP_MENSAGEM_MOVIMENTO";
			System.Diagnostics.Trace.TraceInformation("Carregando '{0}'", tabela);

			cmdText = "SELECT mm.* FROM onp_mensagem_movimento mm, onp_roteiro rot, onp_movimento mov WHERE (mm.seq_matricula = mov.seq_matricula) OR (mm.seq_matricula is null and mm.seq_roteiro is null) OR (mm.seq_roteiro = @roteiro) AND rot.dat_base between dat_inicio AND dat_final AND mov.seq_roteiro = @roteiro AND mov.cod_referencia = @referencia";

			ExecutarCommand(tabela, CriarCommand(cmdText));
		}

		private void CarregarQualidadeAgua() {
			string cmdText = null, tabela = "ONP_QUALIDADE_AGUA";
			System.Diagnostics.Trace.TraceInformation("Carregando '{0}'", tabela);

			cmdText = "SELECT qa.* FROM onp_qualidade_agua qa, onp_matricula mat, onp_roteiro rot WHERE qa.seq_zona_abastecimento = mat.seq_zona_abastecimento AND dat_referencia <= rot.dat_base";

			ExecutarCommand(tabela, CriarCommand(cmdText));
		}

		private void CarregarReferenciaPendente() {
			string cmdText = null, tabela = "ONP_REFERENCIA_PENDENTE";
			System.Diagnostics.Trace.TraceInformation("Carregando '{0}'", tabela);

			cmdText = "SELECT rp.* FROM onp_referencia_pendente rp, onp_movimento mov WHERE rp.seq_matricula = mov.seq_matricula AND mov.seq_roteiro = @roteiro AND mov.cod_referencia = @referencia";

			ExecutarCommand(tabela, CriarCommand(cmdText));
		}
		#endregion // Cargas

		#region Misc.
		/// <summary>
		/// Adiciona uma usuario padrão ao sistema usado para fazer carga de roteiro
		/// </summary>
		private void AdicionarUsuarioPadrao() {
			System.Diagnostics.Trace.TraceInformation("Adicionando usuario padrão");

			using (IDbCommand cmd = _connectionDestino.CreateCommand()) {
				cmd.CommandText = "INSERT INTO onp_agente VALUES (1001, null, '310895')";
				cmd.ExecuteNonQuery();
			}
		}

		/// <summary>
		/// Marca a carga como completada na base do onplace
		/// </summary>
		protected void MarcarStatusMovel() {
			System.Diagnostics.Trace.TraceInformation("Marcando carga no movel");

			using (IDbCommand cmd = _connectionDestino.CreateCommand()) {
				cmd.CommandText = "INSERT INTO onp_tabelas_carga VALUES ('STATUS', 'S', 'S')";
				cmd.ExecuteNonQuery();
			}
		}

		/// <summary>
		/// Vai gerar uma base da dados pelo SQL CE que sera preenchiada com dados
		/// </summary>
		private void GerarBaseMovel() {
			System.Diagnostics.Trace.TraceInformation("Criando base do onplace com script '{0}'", SCRIPT_TO_DATABASE);

			// monta o nome do arquivo ou usa o nome fornecido
			if (string.IsNullOrEmpty(_cmdLine.Target)) {
				string formato = "OnPlace-{0}-{1}.sdf";
				_cmdLine.Target = string.Format(formato, _cmdLine.Referencia, _cmdLine.Roteiro);
			}

			string connStr = "Data Source = " + _cmdLine.Target;

			// Apaga o banco existente
			if (System.IO.File.Exists(_cmdLine.Target))
				System.IO.File.Delete(_cmdLine.Target);

			// Cria um arquivo de banco de dados novo
			using (SqlCeEngine engine = new SqlCeEngine(connStr))
				engine.CreateDatabase();

			// Abre a base de dados criada
			using (SqlCeConnection conn = new SqlCeConnection(connStr))
				try {
					StringBuilder sb = new StringBuilder();
					string[] linhas = System.IO.File.ReadAllLines(SCRIPT_TO_DATABASE);
					conn.Open();

					// Passa por todas as linhas
					// A cada "go" encontrado executa os comandos acumulados
					foreach (string linha in linhas) {
						if (string.Compare(linha, "go", true) == 0) {
							using (SqlCeCommand cmd = new SqlCeCommand(sb.ToString(), conn))
								cmd.ExecuteNonQuery();

							sb = new StringBuilder();
						} else {
							sb.AppendLine(linha);
						}
					}
				} finally {
					conn.Close();
				}
		}
		#endregion // Misc.

		#region Metodos de cargas genericos
		/// <summary>
		/// Faz a copia de dados filtrando por roteiro e referencia menor (somente para taxas e categorias de faturas)
		/// </summary>
		/// <param name="tabela">Nome da tabela a ser carregado</param>
		protected void CarregarSegundasVias(string tabela) {
			System.Diagnostics.Trace.TraceInformation("Carregando '{0}'", tabela);

			string cmdText = "SELECT tb.* FROM " + tabela + " tb, onp_movimento mov WHERE tb.seq_matricula = mov.seq_matricula AND mov.seq_roteiro = @roteiro AND mov.cod_referencia < @referencia";

			ExecutarCommand(tabela, CriarCommand(cmdText));
		}

		/// <summary>
		/// Faz a copia de dados filtrando por roteiro e referencia
		/// </summary>
		/// <param name="tabela">Nome da tabela a ser carregada</param>
		protected void CarregarPorRoteiro(string tabela) {
			System.Diagnostics.Trace.TraceInformation("Carregando '{0}'", tabela);

			string cmdText = "SELECT * FROM " + tabela + " WHERE cod_referencia = @referencia AND seq_roteiro = @roteiro";
			ExecutarCommand(tabela, CriarCommand(cmdText));
		}

		/// <summary>
		/// Carrega tabela inteira com os nomes especificados de uma base para outra
		/// </summary>
		/// <param name="tabelaOrigem">Nome da tabela na base de manager (fornecida na linha de comando)</param>
		/// <param name="tabelaDestino">Nome da tabela na base de movel</param>
		protected void CarregarTabela(string tabela) {
			System.Diagnostics.Trace.TraceInformation("Carregando '{0}'", tabela);

			ExecutarCommand(tabela, CriarSelectAll(tabela));
		}
		#endregion // Metodos de cargas genericos

		#region Metodos com override
		/// <summary>
		/// Faz a carga/descarga de dados
		/// </summary>
		protected override void ExecutarOutros() {
			if (!_cmdLine.Empty) {
				CarregarTabela("ONP_AGENTE");
				CarregarTabela("ONP_SERVICO");
				CarregarTabela("ONP_PARAMETRO");
				CarregarTabela("ONP_OCORRENCIA");
				CarregarTabela("ONP_TIPO_ENTREGA");
				CarregarTabela("ONP_UTILIZACAO_LIGACAO");
				CarregarTabela("ONP_PARAMETRO_RETENCAO");
				//CarregarTabela("ONP_LOCAL_HIDROMETRO");

				CarregarSegundasVias("ONP_FATURA");
				CarregarSegundasVias("ONP_FATURA_TAXA");
				CarregarSegundasVias("ONP_FATURA_SERVICO");
				CarregarSegundasVias("ONP_FATURA_CATEGORIA");

				CarregarPorRoteiro("ONP_MOVIMENTO");
				CarregarPorRoteiro("ONP_MOVIMENTO_TAXA");
				CarregarPorRoteiro("ONP_MOVIMENTO_CATEGORIA");
				CarregarPorRoteiro("ONP_SERVICO_FATURA");
				CarregarMensagemMovimento();

				CarregarTabela("ONP_CATEGORIA");
				CarregarTabela("ONP_TAXA");
				CarregarTabela("ONP_TAXA_TARIFA");
				CarregarTabela("ONP_TAXA_TARIFA_FAIXA");

				CarregarAvisoDebito();
				CarregarFaturaAviso();

				CarregarPorRoteiro("ONP_ROTEIRO");
				CarregarHistorico();
				CarregarLogradouro();
				CarregarMatricula();
				//CarregarMedidor();
				//CarregarQualidadeAgua();
				CarregarReferenciaPendente();

				//OutrasCargas();

				MarcarStatusMovel();
			}

			AdicionarUsuarioPadrao();

			// Guarda a string de conexão do OnPlace
			string connString = _connectionDestino.ConnectionString;

			// Precisa fechar a conexão antes de executar a compactação
			_connectionDestino.Close();
			_connectionDestino = null;

			// Remove espaco alocado desnecessario no arquivo do onplace
			using (SqlCeEngine engine = new SqlCeEngine(connString))
				engine.Compact(null);
		}

		/// <summary>
		/// Configura a conexão com a base de movel
		/// </summary>
		protected override void ConfigConexaoDestino() {
			GerarBaseMovel();

			System.Diagnostics.Trace.TraceInformation("Configurando conexão do banco de dados de destino (SqlCeConnection)");
			string connString = "DataSource={0}";
			_connectionDestino = new SqlCeConnection(string.Format(connString, _cmdLine.Target));
			_connectionDestino.Open();
		}

		/// <summary>
		/// Configura a conexão com a base de manager
		/// </summary>
		protected override void ConfigConexaoOrigem() {
			System.Diagnostics.Trace.TraceInformation("Configurando conexão do banco de dados de origem (SqlConnection)");
			string connString = "Server={0};Database={1};User ID={2};Password={3}";
			_connectionOrigem = new SqlConnection(string.Format(connString, _cmdLine.Server, _cmdLine.Database, _cmdLine.Username, _cmdLine.Password));
			_connectionOrigem.Open();
		}

		/// <summary>
		/// Cria um objeto DataAdapter sem configura-lo
		/// </summary>
		/// <returns>Retorna o objeto criado</returns>
		protected override IDbDataAdapter CriarDataAdapter() {
			return new SqlCeDataAdapter();
		}

		/// <summary>
		/// Criar um DataAdapter para Sql Server
		/// </summary>
		/// <param name="tableName">Nome da tabela</param>
		/// <param name="dt">Datatable criado para a tabela</param>
		/// <param name="transaction">Transaction para ser usada</param>
		/// <returns>Retorna o DataAdapter criado</returns>
		protected override IDbDataAdapter CriarDataAdapter(string tableName, out DataTable dt, IDbTransaction transaction) {
			IDbDataAdapter retorno = base.CriarDataAdapter(tableName, out dt, transaction);

			// Cria o comando de insert e update			
			SqlCeCommandBuilder scb = new SqlCeCommandBuilder(retorno as SqlCeDataAdapter);
			scb.SetAllValues = true;
			scb.ConflictOption = ConflictOption.OverwriteChanges;

			retorno.InsertCommand = scb.GetInsertCommand();
			retorno.UpdateCommand = scb.GetUpdateCommand();

			return retorno;
		}

		/// <summary>
		/// Cria um SqlCommand setando parametros roteiro, data e referencia, nao faz prepare.
		/// </summary>
		/// <param name="cmdText">SQL a ser executada</param>
		/// <returns>Retorna o SqlCommand criado.</returns>
		protected override IDbCommand CriarCommand(string cmdText) {
			IDbCommand retorno = base.CriarCommand(cmdText);

			IDbDataParameter paramRoteiro = retorno.CreateParameter();
			paramRoteiro.ParameterName = "@roteiro";
			paramRoteiro.Value = _cmdLine.Roteiro;
			paramRoteiro.DbType = DbType.Int32;
			retorno.Parameters.Add(paramRoteiro);

			IDbDataParameter paramReferencia = retorno.CreateParameter();
			paramReferencia.ParameterName = "@referencia";
			paramReferencia.Value = _cmdLine.Referencia;
			paramReferencia.Size = 8;
			paramReferencia.DbType = DbType.String;
			retorno.Parameters.Add(paramReferencia);

			return retorno;
		}
		#endregion // Metodos com override

		#endregion // Metodos privados
	}
}
