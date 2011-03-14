#region Usings
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Collections.Generic;
#endregion // Usings

namespace OnPlaceLoader.Controladores {
	class ControladorUploader : Controlador {
		#region Metodos privados
		#region Misc
		/// <summary>
		/// Sobrescrito em outras classes para executar descarga de tabelas
		/// especificas de clientes
		/// </summary>
		protected virtual void OutrasDescarga() {
		}

		/// <summary>
		/// Descarga de tabelas inteiras da base do onplace para a base do origem
		/// </summary>
		/// <param name="tabela">Nome da tabela</param>
		protected void DescarregarTabela(string tabela) {
			System.Diagnostics.Trace.TraceInformation("Descarregando '{0}'", tabela);

			ExecutarCommand(tabela, CriarSelectAll(tabela));
		}
		#endregion // Misc

		#region Metodos com override
		/// <summary>
		/// Faz a carga/descarga de dados
		/// </summary>
		protected override void ExecutarOutros() {
			DescarregarTabela("ONP_MOVIMENTO");
			DescarregarTabela("ONP_MOVIMENTO_TAXA");
			DescarregarTabela("ONP_MOVIMENTO_CATEGORIA");
			DescarregarTabela("ONP_MOVIMENTO_OCORRENCIA");

			DescarregarTabela("ONP_FATURA");
			DescarregarTabela("ONP_FATURA_TAXA");
			DescarregarTabela("ONP_FATURA_CATEGORIA");
			DescarregarTabela("ONP_FATURA_SERVICO");

			DescarregarTabela("ONP_MATRICULA_ALTERACAO");
			DescarregarTabela("ONP_MATRICULA_SERVICO");

			OutrasDescarga();
		}

		/// <summary>
		/// Cria um objeto DataAdapter sem configura-lo
		/// </summary>
		/// <returns>Retorna o objeto criado</returns>
		protected override IDbDataAdapter CriarDataAdapter() {
			return new SqlDataAdapter();
		}

		/// <summary>
		/// Configura a conexão com a base de movel
		/// </summary>
		protected override void ConfigConexaoDestino() {
			System.Diagnostics.Trace.TraceInformation("Configurando conexão do banco de dados de destino (SqlConnection)");
			string connString = "Server={0};Database={1};User ID={2};Password={3}";
			_connectionDestino = new SqlConnection(string.Format(connString, _cmdLine.Server, _cmdLine.Database, _cmdLine.Username, _cmdLine.Password));
			_connectionDestino.Open();
		}

		/// <summary>
		/// Configura a conexão com a base de manager
		/// </summary>
		protected override void ConfigConexaoOrigem() {
			System.Diagnostics.Trace.TraceInformation("Configurando conexão do banco de dados de origem (SqlCeConnection)");
			string connString = "DataSource={0}";
			_connectionOrigem = new SqlCeConnection(string.Format(connString, _cmdLine.Target));
			_connectionOrigem.Open();
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
			SqlCommandBuilder scb = new SqlCommandBuilder(retorno as SqlDataAdapter);
			scb.SetAllValues = true;
			scb.ConflictOption = ConflictOption.OverwriteChanges;

			retorno.InsertCommand = scb.GetInsertCommand();
			retorno.UpdateCommand = scb.GetUpdateCommand();

			return retorno;
		}
		#endregion // Metodos com override
        
		#endregion // Metodos privados
	}
}
