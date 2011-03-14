using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlServerCe;
using Strategos.Api.Log4CS;
using System.Data;

namespace OnPlaceMovel.Source.Controladores {
	public static class UpdateControler {
		private const string DBUpdateFile = @"\Program files\OnPlaceMovel\UpdateDB.sql";

		/// <summary>
		/// Verifica se há atualizações a serem aplicadas
		/// </summary>
		public static void VerifyUpdates() {
			//Verifica se há atualizações no banco
			if (File.Exists(DBUpdateFile)) {
				doUpdateDB();
			}
		}

		/// <summary>
		/// Executa a atualização do banco
		/// </summary>
		private static void doUpdateDB() {
			IDbCommand command = null;
			IDbConnection connection = null;
			StreamReader reader = null;

			try {
				string connectionString = @"Data Source=" + ConfigXML.ArquivoBase;
				StringBuilder sqlCommand = new StringBuilder();

				reader = File.OpenText(DBUpdateFile);

				connection = new SqlCeConnection(connectionString);
				connection.Open();

				for (string line = reader.ReadLine(); line != null; line = reader.ReadLine()) {
					if (line.Trim().ToUpper().Equals("GO")) {
						command = connection.CreateCommand();
						command.CommandText = sqlCommand.ToString();
						command.ExecuteNonQuery();
						command.Dispose();
						command = null;
						
						sqlCommand = new StringBuilder();
					} else {
						sqlCommand.Append(line);
					}
				}

				string sufix = "_" + DateTime.Now.ToString("yyyymmddhhMMss") + ".executed";
				string executedFileName = DBUpdateFile.Replace(".sql", sufix);
				File.Move(DBUpdateFile, executedFileName);
			} catch (Exception ex) {
				Log4CS.Error(ex);
				throw;
			} finally {
				if (command != null) {
					command.Dispose();
				}

				if (reader != null) {
					reader.Close();
				}

				if (connection != null) {
					connection.Close();
					connection.Dispose();
				}
			}
		}

	}
}
