/*
 *  Author1: Ivan Paulovich
 *           E-mail: ivanpaulovich@gmail.com - MSN: ivanpaulovich@hotmail.com 
 */

using System.Collections.Generic;
using System.Text;

namespace Paulovich.Data.SqlBuilder
{
    public class DeleteBuilder
    {
        public DeleteBuilder()
        {
            Where = new Dictionary<string, string>();
        }

        public string TableName { get; set; }

        public Dictionary<string, string> Where { get; set; }

        public override string ToString()
        {
            var query = new StringBuilder();

            query.Append("DELETE FROM ").Append(TableName);

            if (Where.Count > 0)
            {
                query.Append(" WHERE ");

                query.Append(SqlHelper.Add(Where, " AND "));
            }

            return query.ToString();
        }
    }
}