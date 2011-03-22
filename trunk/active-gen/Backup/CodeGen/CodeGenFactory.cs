using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace ActiveRecordGenerator.CodeGen
{
	public class CodeGenFactory
	{
		// get a list of tables
		//
		// if username is blank, use integrated security
		// if bInclude is false, use filter to exclude
		public static DbTableInfo[] GetTables(BackgroundWorker bw, 
			string p_Server, string p_Database, 
			string p_Username, string p_Password,
			bool bInclude, string p_FilterPrefix)
		{
			System.Data.Common.DbProviderFactory sqlFactory = System.Data.SqlClient.SqlClientFactory.Instance;

			IDbConnection conn = null;

			// Connect to database, collect list of tables 
			conn = sqlFactory.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			string table;
			List<DbTableInfo> dbList = new List<DbTableInfo>();
			DbTableInfo dbTableInfo;

			if (bw != null) bw.ReportProgress(0, "Connecting ...");
			if (p_Username.Length == 0)
				conn.ConnectionString = "Data Source=" + p_Server + ";Initial Catalog=" + p_Database
					+ ";Integrated Security=SSPI" ;
			else
				conn.ConnectionString = "Data Source=" + p_Server + ";Initial Catalog=" + p_Database
					+ ";user id=" + p_Username + ";password=" + p_Password;
			conn.Open();
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandType = CommandType.Text;
//#if DEBUG
//				cmd.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME LIKE 'AG%';";
//#else
				if (bInclude)
				{
					// only include tables starting with our prefix
					cmd.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES" +
					" WHERE TABLE_NAME LIKE '" + p_FilterPrefix
						+"%' ;";
				}
				else
				{
					cmd.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES;";
				}
//#endif

				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					table = reader.GetString(0);
					if (table.Equals("dtproperties")) continue;
					if (table.StartsWith("sys")) continue;

					if ((p_FilterPrefix.Length > 0) && (!bInclude))
					{
						// exclude tables starting with our prefix
						if (table.StartsWith(p_FilterPrefix))
							continue;
					}

					dbTableInfo = new DbTableInfo(table);
					dbTableInfo.GetFields();
					dbList.Add(dbTableInfo);
				}
				reader.Close();
				if (bw != null) bw.ReportProgress(50, "Tables collected");

				foreach(DbTableInfo tableInfo in dbList)
				{
					tableInfo.CollectFields(conn);
				}
				if (bw != null) bw.ReportProgress(100, "Fields collected");
			}
			finally
			{
				if (reader != null) reader.Close();
				if (cmd != null) cmd.Dispose();
				conn.Close();
			}
			
			return dbList.ToArray();
		}
	}
}
