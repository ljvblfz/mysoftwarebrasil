using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using Strategos.Api.Database.Impl;
using Strategos.Api.Log4CS;

namespace OnPlaceMovel.Source.Diadema {
	public static class QueriesDiadema {
		/// <summary>
		/// Pega o número de filhos não processados
		/// </summary>
		/// <param name="md">Matricula pai</param>
		/// <returns>Retorna o numero de filhos ainda não processados ou -1 caso tenha ocorrido um erro</returns>
		public static int getFilhosNaoProcessados(OnpMatriculaDiadema mdPai) {
			int resultado = 0;

			string select =
				"select count(*) " +
				"from onp_matricula m, onp_matricula_diadema md " +
				"where md.seq_matricula_pai = @seqMatricula " +
				"and m.seq_matricula = md.seq_matricula " +
				"and md.seq_matricula <> md.seq_matricula_pai " + // Exclui o pai da pesquisa
				"and m.ind_processado = 'N'";

			SqlCeConnection connection = null;
			SqlCeCommand command = null;

			try {
				connection = new SqlCeConnection("DataSource=" + ConfigXML.ArquivoBase);
				connection.Open();

				command = new SqlCeCommand(select, connection);
				command.Parameters.AddWithValue("@seqMatricula", mdPai.SeqMatricula.ToString());
				command.Prepare();
				resultado = (int)command.ExecuteScalar();
			} catch (SqlCeException e) {
				resultado = -1;
				Log4CS.Error(e);
			} finally {
				if (command != null)
					command.Dispose();

				if (connection != null)
					connection.Close();
			}

			return resultado;
		}

		/// <summary>
		/// Pega o número de filhos retidos para analise
		/// </summary>
		/// <param name="md">Matricula pai</param>
		/// <returns>Retorna o numero de filhos retido para analise ou -1 caso tenha ocorrido um erro</returns>
		public static int getFilhosRetidos(OnpMatriculaDiadema mdPai) {
			int resultado = 0;

			string select =
				"select count(*) " +
				"from onp_movimento mov, onp_matricula_diadema md " +
				"where md.seq_matricula_pai = @seqMatriculaPai " +
				"and mov.seq_matricula = md.seq_matricula " +
				"and mov.ind_situacao_movimento = 'R' ";

			SqlCeConnection connection = null;
			SqlCeCommand command = null;
			try {
				connection = new SqlCeConnection("DataSource=" + ConfigXML.ArquivoBase);
				connection.Open();

				command = new SqlCeCommand(select, connection);
				command.Parameters.AddWithValue("@seqMatriculaPai", mdPai.SeqMatriculaPai);
				command.Prepare();
				resultado = (int)command.ExecuteScalar();
			} catch (SqlCeException e) {
				resultado = -1;
				Log4CS.Error(e);
			} finally {
				if (command != null)
					command.Dispose();

				if (connection != null)
					connection.Close();
			}

			return resultado;
		}

		public static bool SetTipoEntregaFilhos(int? pai, int seqTipoEntrega) {
			return SetTipoEntregaFilhos(pai, seqTipoEntrega, "onp_fatura", true) &&
			SetTipoEntregaFilhos(pai, seqTipoEntrega, "onp_movimento", false);
		}

		private static bool SetTipoEntregaFilhos(int? pai, int seqTipoEntrega, string table, bool seqFatura) {
			int resultado = 0;

			string select =
				"update " + table + " set seq_tipo_entrega = @seqTipoEntrega " +
				"where seq_matricula in " +
				"	(select seq_matricula " +
				"	from onp_matricula_diadema " +
				"	where seq_matricula_pai = @seqMatriculaPai) ";

			if (seqFatura)
				select += " and seq_fatura = 0";

			SqlCeConnection connection = null;
			SqlCeCommand command = null;
			
			try {
				connection = new SqlCeConnection("DataSource=" + ConfigXML.ArquivoBase);
				connection.Open();

				command = new SqlCeCommand(select, connection);
				command.Parameters.AddWithValue("@seqMatriculaPai", pai.Value);
				command.Parameters.AddWithValue("@seqTipoEntrega", seqTipoEntrega);
				command.Prepare();
				resultado = (int)command.ExecuteNonQuery();
			} catch (SqlCeException e) {
				resultado = -1;
				Log4CS.Error(e);
			} finally {
				if (command != null)
					command.Dispose();

				if (connection != null)
					connection.Close();
			}

			return resultado > 0;
		}
	}
}
