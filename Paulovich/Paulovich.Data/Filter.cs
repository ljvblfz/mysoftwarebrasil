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
//           * Rigel (rigel.octaviano@gmail.com)
//           Blog: http://rigel-aguilar.blogspot.com/
//           Messenger: rigelaguilar@hotmail.com 
//


using System;
using Paulovich.Data.Resources;
using System.Runtime.Serialization;

namespace Paulovich.Data
{
    [DataContract]
    public class Filter
    {
        #region Enum

        public enum Types
        {
            IsEqualTo,
            Contains,
            StartsWith,
            EndsWith,
            IsGreaterThanOrEqualTo,
            IsGreaterThan,
            IsLessThanOrEqualTo,
            IsLessThan,
            IsNotEqualTo,
            IsContainedIn
        }

        #endregion

        #region Property's

        public Types Type { get; set; }
        public string Name { get; set; }
        private object Value { get; set; }

        #endregion

        #region Constructor's

        public Filter(string name, object value)
        {
            #region debug

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name", Messages.InvalidArgumentValue);

            #endregion

            Name = name;
            Value = value;
            Type = Types.IsEqualTo;
        }

        public Filter(string name, object value, Types type)
        {
            #region debug

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name", Messages.InvalidArgumentValue);

            if (value == null)
                throw new ArgumentNullException("value", Messages.InvalidArgumentValue);

            #endregion

            Name = name;
            Value = value;
            Type = type;
        }

        #endregion

        #region public methods

        public object GetValue(Dialect.Dialect dialect)
        {
            object retValue;

            switch (Type)
            {
                case Types.Contains:
                    retValue = dialect.GetWildcard() + Value + dialect.GetWildcard();
                    break;

                case Types.StartsWith:
                    retValue = Value + dialect.GetWildcard();
                    break;

                case Types.EndsWith:
                    retValue = dialect.GetWildcard() + Value;
                    break;

                default:
                    retValue = Value;
                    break;
            }

            return retValue;
        }

        public string Operator()
        {
            string operatorString = "";

            switch (Type)
            {
                case Types.IsEqualTo:

                    operatorString = " = ";
                    break;

                case Types.Contains:
                    operatorString = " LIKE ";
                    break;

                case Types.StartsWith:

                    operatorString = " LIKE ";
                    break;

                case Types.EndsWith:

                    operatorString = " LIKE ";
                    break;

                case Types.IsGreaterThanOrEqualTo:

                    operatorString = " >= ";
                    break;

                case Types.IsGreaterThan:

                    operatorString = " > ";
                    break;

                case Types.IsLessThanOrEqualTo:

                    operatorString = " <= ";
                    break;

                case Types.IsLessThan:

                    operatorString = " < ";
                    break;

                case Types.IsNotEqualTo:

                    operatorString = " != ";
                    break;
            }

            return operatorString;
        }

        #endregion
    }
}