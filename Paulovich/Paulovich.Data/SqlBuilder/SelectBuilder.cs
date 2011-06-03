//
//  Copyright (c) 2008, Ivan Paulovich
//  All rights reserved.
//
//  Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
//
//  * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//
//  * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other 
//  materials provided with the distribution.
//
//  * Neither the name of Paulovich nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior 
//  written permission.
//
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
//  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT 
//  OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT 
//  LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON 
//  ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
//  USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
//  Authors: 
//           
//           * Ivan Paulovich (ivan@100loop.com)
//           Blog: http://www.100loop.com/blogs/           
//           Messenger: ivanpaulovich@hotmail.com 
//
//           * Rigel (rigel.octaviano@gmail.com)
//           Blog: http://rigel-aguilar.blogspot.com/
//           Messenger: rigelaguilar@hotmail.com 
//
//           * Andr� Paulovich (paulovich@100loop.com)
//           Blog: http://www.100loop.com/blogs/           
//           Messenger: andrepaulovich@hotmail.com 
//
//

using System;
using System.Collections.Generic;
using System.Text;
using Paulovich.Data.Resources;

namespace Paulovich.Data.SqlBuilder
{
    public class ValuePairItem
    {
        public string Key { get; set; }

        public string Separator { get; set; }

        public string Value { get; set; }

        #region Constructors

        public ValuePairItem()
        {
        }

        public ValuePairItem(string key, string value)
        {
            #region debug

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key", Messages.InvalidArgumentValue);
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value", Messages.InvalidArgumentValue);
            }

            #endregion

            Key = key;
            Value = value;
        }

        public ValuePairItem(string key, string value, string separator)
        {
            #region debug

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key", Messages.InvalidArgumentValue);
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value", Messages.InvalidArgumentValue);
            }

            if (string.IsNullOrEmpty(separator))
            {
                throw new ArgumentNullException("separator", Messages.InvalidArgumentValue);
            }

            #endregion

            Key = key;
            Value = value;
            Separator = separator;
        }

        #endregion
    }

    public class SelectBuilder
    {
        public SelectBuilder()
        {
            Select = new List<string>();
            Where = new List<ValuePairItem>();
            From = new StringBuilder();
        }

        public string TableName { get; set; }

        public StringBuilder From { get; set; }

        public List<string> Select { get; set; }

        public List<ValuePairItem> Where { get; set; }

        public string GroupBy { get; set; }

        public string Having { get; set; }

        public string OrderBy { get; set; }

        public string ToString(string whereSeparator)
        {
            var query = new StringBuilder();

            query.Append("SELECT ").Append(SqlHelper.Add(Select, ",")).Append(" FROM ").Append(
                string.IsNullOrEmpty(TableName) ? From.ToString() : TableName);

            if (Where.Count != 0)
            {
                query.Append(" WHERE ").Append(SqlHelper.Add(Where, whereSeparator));
            }

            if (!string.IsNullOrEmpty(GroupBy))
            {
                query.Append(" GROUP BY ").Append(GroupBy);
            }

            if (!string.IsNullOrEmpty(Having))
            {
                query.Append(" HAVING ").Append(Having);
            }

            if (!string.IsNullOrEmpty(OrderBy))
            {
                query.Append(" ORDER BY ").Append(OrderBy);
            }

            return query.ToString();
        }

        public override string ToString()
        {
            return ToString(" AND ");
        }

        /// <summary>
        /// Retorna somente a parte da query que determina as condi��es do SELECT, ou seja: " WHERE CODICAO = VALOR ... "
        /// </summary>
        /// <returns>string com o WHERE completo</returns>
        public string GetConditions()
        {
            var sb = new StringBuilder();

            if (Where.Count > 0)
                sb.Append(" WHERE ");

            for (int i = 0; i < Where.Count; i++)
            {
                if (i > 0)
                    sb.Append(" AND ");

                sb.Append(Where[i].Key + " " + Where[i].Separator + " " + Where[i].Value);
            }

            return sb.ToString();
        }
    }
}