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

namespace Paulovich.Data.SqlBuilder.SqlServer
{
    [Table("information_schema.columns")]
    public class Column : Persist
    {
        [PrimaryKeyField(Column = "table_name")]
        public string TableName { get; set; }

        [Field(Column = "column_name")]
        public string ColumnName { get; set; }

        [Field(Column = "is_nullable")]
        public string IsNullable { get; set; }

        [Field(Column = "data_type")]
        public string DataType { get; set; }

        [Field(Column = "character_maximum_length")]
        public int CharacterMaximumLength { get; set; }
    }
}