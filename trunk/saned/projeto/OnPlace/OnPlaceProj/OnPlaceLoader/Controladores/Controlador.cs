#region Usings
using System;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Collections.Generic;
using OnPlaceLoader.CommandLine;
using OnPlaceLoader.Enumerations;
#endregion // Usings

namespace OnPlaceLoader.Controladores {
	/// <summary>
	/// Classe base (abstrata) para controladores
	/// </summary>
	abstract class Controlador : OnPlaceLoader.Interfaces.IControlador {
		#region Atributos e Propriedades
		// Conexões
		protected IDbConnection _connectionOrigem;
		protected IDbConnection _connectionDestino;

		/// <summary>
		/// Parametros da linha de comando
		/// </summary>
		protected CommandLineParser _cmdLine;

		protected EstadoControlador _estado;
		/// <summary>
		/// Estado atual do controlador
		/// </summary>
		public EstadoControlador Estado {
			get { return _estado; }
		}
		#endregion // Atributos e Propriedades

		public Controlador() {
			_cmdLine = CommandLine.CommandLineParser.Instancia;
			_estado = EstadoControlador.Idle;
		}

		#region Metodos publicos
		/// <summary>
		/// Executa a tarefa para qual o controlador foi feito
		/// </summary>
		public virtual void Executar() {
			try {
				_estado = EstadoControlador.Executando;
				SetupLog("loader");

				System.Diagnostics.Trace.TraceInformation(">>> INICIO <<<" + System.Environment.NewLine);

				System.Diagnostics.Trace.TraceInformation("================================");
				System.Diagnostics.Trace.TraceInformation("Descarga: " + _cmdLine.Descarga.ToString());
				System.Diagnostics.Trace.TraceInformation("Cliente: " + _cmdLine.Cliente.ToString());
				System.Diagnostics.Trace.TraceInformation("Servidor: " + _cmdLine.Server);
				System.Diagnostics.Trace.TraceInformation("Database: " + _cmdLine.Database);
				System.Diagnostics.Trace.TraceInformation("Username: " + _cmdLine.Username);
				System.Diagnostics.Trace.TraceInformation("Password: " + new string('*', _cmdLine.Password != null ? _cmdLine.Password.Length : 0));
				System.Diagnostics.Trace.TraceInformation("Roteiro: " + _cmdLine.Roteiro);
				System.Diagnostics.Trace.TraceInformation("Referência: " + _cmdLine.Referencia);
				System.Diagnostics.Trace.TraceInformation("Target: " + _cmdLine.Target);
				System.Diagnostics.Trace.TraceInformation("================================" + System.Environment.NewLine);

				ConfigConexaoOrigem();
				ConfigConexaoDestino();

				ExecutarOutros();

				_estado = EstadoControlador.Encerrado;
			} catch (Exception ex) {
				_estado = EstadoControlador.Erro;
				System.Diagnostics.Trace.TraceError(ex.Message + System.Environment.NewLine + ex.StackTrace);
			} finally {
				if (_connectionDestino != null)
					_connectionDestino.Close();

				if (_connectionOrigem != null)
					_connectionOrigem.Close();

				System.Diagnostics.Trace.TraceInformation(">>> FIM <<<" + Environment.NewLine + Environment.NewLine);
				System.Diagnostics.Trace.Close();
			}
		}

		#endregion // Metodos publicos

		#region Metodos privados
		/// <summary>
		/// Faz a carga/descarga de dados
		/// </summary>
		protected abstract void ExecutarOutros();

		/// <summary>
		/// Cria um objeto DataAdapter sem configura-lo
		/// </summary>
		/// <returns>Retorna o objeto criado</returns>
		protected abstract IDbDataAdapter CriarDataAdapter();

		/// <summary>
		/// Configura a conexão com a base de dados de destino
		/// </summary>
		protected abstract void ConfigConexaoDestino();

		/// <summary>
		/// Configura a conexão com a base de dados de origem
		/// </summary>
		protected abstract void ConfigConexaoOrigem();

		/// <summary>
		/// Cria um IDbCommand com base no texto de comando fornecido
		/// para ser executado na conexao de origem
		/// </summary>
		/// <param name="cmdText">Comando a ser executado</param>
		/// <returns>Retorna o objeto criado com base no parametro recebido.</returns>
		protected virtual IDbCommand CriarCommand(string cmdText) {
			IDbCommand retorno = _connectionOrigem.CreateCommand();
			retorno.CommandText = cmdText;

			return retorno;
		}

		/// <summary>
		/// Cria um comando que seleciona todos os registros da tabela
		/// </summary>
		/// <param name="tabela">Nome da tabela</param>
		/// <returns>Retorna o objeto criado com base no parametro recebido.</returns>
		protected virtual IDbCommand CriarSelectAll(string tabela) {
			string cmd = "SELECT * FROM " + tabela;
			return CriarCommand(cmd);
		}

		/// <summary>
		/// Cria um data adapter para manipulacao de dados
		/// </summary>
		/// <param name="tabela">Nome da tabela para qual o data adapter sera criado</param>
		/// <param name="dt">Data table que vai receber schema da tabela</param>
		/// <param name="transaction">Transação</param>
		/// <returns>Retorna o data adapter criado</returns>
		protected virtual IDbDataAdapter CriarDataAdapter(string tabela, out DataTable dt, IDbTransaction transaction) {
			IDbCommand selectCmd = _connectionDestino.CreateCommand();
			selectCmd.CommandText = "SELECT * FROM " + tabela + " WHERE 1 = 0";
			selectCmd.Transaction = transaction;

			DataSet ds = new DataSet(tabela);
			dt = new DataTable(tabela);
			ds.Tables.Add(dt);

			IDbDataAdapter retorno = CriarDataAdapter();
			retorno.SelectCommand = selectCmd;
			retorno.FillSchema(ds, SchemaType.Source);
			retorno.TableMappings.Add("Table", tabela);

			ds.Tables.Remove(dt);

			return retorno;
		}

		/// <summary>
		/// Executa o comando passado e coloca o resulta na tabela passada
		/// </summary>
		/// <param name="tabela">Nome da tabela que vai receber dados</param>
		/// <param name="commandSql">Comando a ser executado.</param>
		/// <param name="connection">Conexao a ser usada pra conectar no banco de dados de movel dos dados.</param>
		protected virtual void ExecutarCommand(string tabela, IDbCommand command) {
			IDbTransaction transOrigem = _connectionOrigem.BeginTransaction();
			IDbTransaction transDestino = _connectionDestino.BeginTransaction();
			IDbDataAdapter dataAdapter = null;

			try {
				command.Transaction = transOrigem;

				using (IDataReader dataReader = command.ExecuteReader()) {
					if (dataReader.Read()) {
						DataTable dados;
						dataAdapter = CriarDataAdapter(tabela, out dados, transDestino);

						// Carrega as informacoes ja existentes
						DataSet ds = new DataSet(tabela);
						ds.Tables.Add(dados);
						dataAdapter.Fill(ds);

						// Copiando informações
						dados.Load(dataReader, LoadOption.Upsert);

						try {
							// Tenta dar um insert
							foreach (DataRow row in dados.Rows)
								if (row.RowState != DataRowState.Added) {
									row.AcceptChanges();
									row.SetAdded();
								}

							dataAdapter.Update(ds);
						} catch (Exception) {
							// Se insert falhar, tenta dar um update
							foreach (DataRow row in dados.Rows)
								if (row.RowState != DataRowState.Modified) {
									row.AcceptChanges();
									row.SetModified();
								}

							dataAdapter.Update(ds);
						}
					}
				}

				transDestino.Commit();
				transOrigem.Commit();
			} catch (Exception ex) {
				if (transDestino != null)
					transDestino.Rollback();

				if (transOrigem != null)
					transOrigem.Rollback();

				throw ex;
			} finally {
				if (dataAdapter != null)
					DisposeAdapter(dataAdapter);

				if (command != null)
					command.Dispose();
			}
		}

		/// <summary>
		/// Libera recursos usados pelo data adapter
		/// </summary>
		/// <param name="dbAdapter">Data a ter recursos liberados</param>
		protected void DisposeAdapter(IDbDataAdapter dataAdapter) {
			if (dataAdapter == null)
				return;

			IDbCommand cmd = dataAdapter.SelectCommand;
			if (cmd != null)
				cmd.Dispose();

			cmd = dataAdapter.InsertCommand;
			if (cmd != null)
				cmd.Dispose();

			cmd = dataAdapter.UpdateCommand;
			if (cmd != null)
				cmd.Dispose();

			cmd = dataAdapter.DeleteCommand;
			if (cmd != null)
				cmd.Dispose();

			IDisposable disp = dataAdapter as IDisposable;
			if (disp != null)
				disp.Dispose();
		}

		/// <summary>
		/// Gera o nome do arquivo de log
		/// </summary>
		/// <returns>Nome do arquivo de log, sem caminho.</returns>
		private string GerarNomeArquivoLog(string prefix) {
			string formato = "{0}-{1}-{2}.log";
			string retorno = null;

			if (_cmdLine.Descarga)
				retorno = string.Format(formato, prefix, _cmdLine.Referencia, _cmdLine.Roteiro);
			else
				retorno = string.Format(formato, prefix, _cmdLine.Referencia, _cmdLine.Roteiro);

			return retorno;
		}

		/// <summary>
		/// Configura o sistema de log para arquivo usando o prefixo e o roteiro como nome do arquivo
		/// </summary>
		/// <param name="prefix">Prefixo do arquivo de log</param>
		private void SetupLog(string prefix) {
			System.Diagnostics.Trace.AutoFlush = true;
			System.Diagnostics.Trace.UseGlobalLock = true;
			System.Diagnostics.Trace.Listeners.Add(new TextWriterTraceListener(GerarNomeArquivoLog(prefix)));
			System.Diagnostics.Trace.IndentSize = 4;
		}
		#endregion // Metodos privados
	}
}
