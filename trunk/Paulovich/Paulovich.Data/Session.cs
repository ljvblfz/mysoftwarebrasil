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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Paulovich.Data.Resources;

namespace Paulovich.Data
{
    public class Session : IDisposable
    {
        #region padrão singleton

        [ThreadStatic] private static Session current;

        protected Session()
        {
            Command = new Command();
        }

        protected Session(string connectionString, string providerName)
        {
            #region debug

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("connectionString", Messages.InvalidArgumentValue);

            if (string.IsNullOrEmpty(providerName))
                throw new ArgumentNullException("providerName", Messages.InvalidArgumentValue);

            #endregion

            Command = new Command(connectionString, providerName);
        }

        protected Session(string connectionName)
        {
            #region debug

            if (string.IsNullOrEmpty(connectionName))
                throw new ArgumentNullException("connectionName", Messages.InvalidArgumentValue);

            #endregion

            Command = new Command();
        }

        public static Session Current()
        {
            if (current == null)
            {
                current = new Session();
            }

            return current;
        }

        public static Session Current(string connectionString, string providerName)
        {
            #region debug

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("connectionString", Messages.InvalidArgumentValue);

            if (string.IsNullOrEmpty(providerName))
                throw new ArgumentNullException("providerName", Messages.InvalidArgumentValue);

            #endregion

            if (current == null)
            {
                current = new Session(connectionString, providerName);
            }

            return current;
        }

        public static Session Current(string connectionName)
        {
            #region debug

            if (string.IsNullOrEmpty(connectionName))
                throw new ArgumentNullException("connectionName", Messages.InvalidArgumentValue);

            #endregion

            if (current == null)
            {
                current = new Session();
            }

            return current;
        }

        #endregion

        #region propriedades privadas

        /// <summary>
        /// Lista de objetos a serem apagados
        /// </summary>
        [XmlIgnore]
        [ListToDelete]
        private Collection<Persist> ListToDelete { get; set; }

        #endregion

        #region eventos

        public event CancelEventHandler Inserting;
        public event CancelEventHandler Inserted;
        public event EventHandler CommitInserted;
        public event CancelEventHandler Updating;
        public event CancelEventHandler Updated;
        public event EventHandler CommitUpdated;
        public event CancelEventHandler Loading;
        public event CancelEventHandler Loaded;
        public event CancelEventHandler Deleting;
        public event CancelEventHandler Deleted;
        public event EventHandler CommitDeleted;
        public event EventHandler<ValidatingEventArgs> Validating;

        #endregion

        #region variáveis para acesso a dados

        [XmlIgnore]
        public Command Command { get; set; }

        /// <summary>
        /// Can commits a transaction.
        /// </summary>
        [XmlIgnore]
        public bool IsDone { get; set; }

        #endregion

        #region métodos públicos

        public T Load<T>(params object[] primaryKeys)
            where T : class, new()
        {
            #region calls OnGetting Delegate

            var loadingArgs = new CancelEventArgs {Cancel = false};

            OnLoading(this, loadingArgs);

            if (loadingArgs.Cancel)
            {
                return null;
            }

            #endregion

            //
            // Instancia o objeto
            //

            var entity = new T();

            //
            // Carrega os metadados
            //

            var keys = new Dictionary<string, Property>();
            var columns = new Dictionary<string, Property>();
            var allColumns = new Dictionary<string, Property>();

            Mapper.LoadMetaData(entity, keys, columns, allColumns);

            //
            // Define as chaves primárias
            //

            int i = 0;

            foreach (var entry in keys)
            {
                entry.Value.SetValue(primaryKeys[i]);

                i++;
            }

            #region generates and makes select query

            string query = CodeGenerator.Generate(entity, Command, Persist.Operation.Get);

            object objectTable = Command.ExecuteQuery(query, ReturnType.DataTable);

            #endregion

            if (objectTable == null)
            {
                throw new ADOException("Não foi possível executar a query no banco de dados.");
            }

            var dt = (DataTable) objectTable;

            #region loads the object or leaves the method

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            if (dt.Rows.Count == 1)
            {
                #region iterates allColumns

                foreach (var entry in allColumns)
                {
                    #region If the table contains the Alias, sets the entry value

                    if (dt.Rows[0].Table.Columns.Contains(entry.Value.Alias()))
                    {
                        #region sets the entry value

                        if (dt.Rows[0][entry.Value.Alias()] != DBNull.Value)
                        {
                            entry.Value.SetValue(dt.Rows[0][entry.Value.Alias()]);
                        }
                        else
                        {
                            entry.Value.Info.SetValue(entity, null, null);
                        }

                        #endregion
                    }

                    #endregion
                }

                #endregion
            }
            else
            {
                throw new NonUniqueObjectException(GetType());
            }

            #endregion

            #region calls OnGot Delegate

            var loadedArgs = new CancelEventArgs {Cancel = false};

            OnLoaded(entity, loadedArgs);

            if (loadedArgs.Cancel)
            {
                return null;
            }

            #endregion

            return entity;
        }

        public bool SaveOrUpdate(object entity)
        {
            #region debug

            if (entity == null)
                throw new ArgumentNullException("entity", Messages.InvalidArgumentValue);

            #endregion

            bool result;

            bool isNew = CheckNew(entity);

            result = isNew ? Insert(entity, 0) : Update(entity, 0);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="depth"></param>
        /// <returns></returns>
        public static Collection<T> Select<T>(int depth)
            where T : Persist, new()
        {
            return Select<T>(null, null, null, null, null, null, depth, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="persist"></param>
        /// <param name="depth"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Collection<T> DataSource<T>(T persist, int depth, string[] parameters)
            where T : new()
        {
            return Select(null, null, null, null, null, null, depth, persist, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Collection<T> Select<T>()
            where T : new()
        {
            return Select(null, null, null, null, null, null, 0, new T(), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="persist"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Collection<T> Select<T>(T persist, params string[] parameters)
            where T : new()
        {
            return Select(null, null, null, null, null, null, 0, persist, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="persist"></param>
        /// <returns></returns>
        public static Collection<T> Select<T>(T persist)
            where T : new()
        {
            return Select(null, null, null, null, null, null, 0, persist, null);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <param name="persist"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Collection<T> Select<T>(string where, T persist, params string[] parameters)
            where T : new()
        {
            return Select(null, null, where, null, null, null, 0, persist, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="persist"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Collection<T> Select<T>(string where, string orderBy, T persist, params string[] parameters)
            where T : new()
        {
            return Select(null, null, where, null, null, orderBy, 0, persist, parameters);
        }

        public static Collection<T> Select<T>(string select, string from, string where,
                                              string groupBy, string having, string orderBy, int depth, T persist,
                                              params string[] parameters)
            where T : new()
        {
            var result = new Collection<T>();
            Command command = Current().Command;

            #region generates and executes query

            string query = SqlBuilder.Select.Generate<T>(persist, select, from, where, groupBy, having, orderBy, command,
                                                         parameters);

            object objectTable = command.ExecuteQuery(query, ReturnType.DataTable);

            #endregion

            if (objectTable != null)
            {
                var dt = (DataTable) objectTable;

                #region for each row, create a Persistent object adding to the result

                foreach (DataRow dtRow in dt.Rows)
                {
                    #region create a new persistent object

                    var obj = new T();

                    #endregion

                    var keys = new Dictionary<string, Property>();
                    var columns = new Dictionary<string, Property>();
                    var allColumns = new Dictionary<string, Property>();

                    Mapper.LoadMetaData(obj, keys, columns, allColumns);

                    #region sets all properties

                    foreach (var entry in allColumns)
                    {
                        if (dtRow.Table.Columns.IndexOf(entry.Value.Alias()) != -1 &&
                            dtRow[entry.Value.Alias()] != DBNull.Value)
                        {
                            entry.Value.SetValue(dtRow[entry.Value.Alias()]);
                        }
                    }

                    #endregion

                    #region loads recursevely if needed

                    if (depth - 1 >= 0 && !Current().LoadChildren(obj, depth - 1))
                    {
                        throw new LoadChildrenException(typeof (T), depth - 1);
                    }

                    #endregion

                    result.Add(obj);
                }

                #endregion
            }
            else
            {
                throw new NonAffectedRowsException(persist.GetType());
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        private bool LoadChildren(object entity, int depth)
        {
            #region debug

            Debug.Assert(entity != null);

            Debug.Assert(depth >= 0);

            #endregion

            #region iterates propertyInfos finding ListToSaveAttribute

            PropertyInfo[] propertyInfos =
                entity.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            object[] attributes;

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                //
                //Para cada atributo podemos ter um comportamento diferente
                //

                #region carrega coleção (ListToSave)

                attributes = propertyInfo.GetCustomAttributes(typeof (OneToMany), true);

                if (attributes != null && attributes.Length > 0)
                {
                    //
                    // Temos uma coleção de objetos relaciodos pra carregar
                    //

                    Command.ClearParameters();

                    #region creates an instance of the generic argument type

                    object childType = Activator.CreateInstance(propertyInfo.PropertyType.GetGenericArguments()[0]);

                    #endregion

                    #region sets the instance properties foreign keys and stores in properties array

                    var properties = new List<string>();

                    var keys = new Dictionary<string, Property>();
                    var columns = new Dictionary<string, Property>();
                    var allColumns = new Dictionary<string, Property>();

                    Mapper.LoadMetaData(entity, keys, columns, allColumns);

                    foreach (var entry in keys)
                    {
                        //
                        // Procura pela propriedade no objto filho relacionada
                        //
                        string propertyName = entry.Value.Info.Name;

                        for (int i = 0; i < entry.Value.Field.Constraints.Count; i++)
                        {
                            if (childType.ToString() == Convert.ToString(entry.Value.Field.Constraints[i].Type))
                            {
                                propertyName = Convert.ToString(entry.Value.Field.Constraints[i].Property);

                                break;
                            }
                        }

                        PropertyInfo childProperty = childType.GetType().GetProperty(propertyName);

                        childProperty.SetValue(childType, entry.Value.Value, null);

                        properties.Add(childProperty.Name);
                    }

                    #endregion

                    #region generates generic method

                    MethodInfo selectMethod = (typeof (Persist)).GetMethod("DataSource");
                    MethodInfo genericMethodInfo = selectMethod.MakeGenericMethod(new[] {childType.GetType()});

                    #endregion

                    #region set current list property based in DataSource method

                    try
                    {
                        object listResult = genericMethodInfo.Invoke(null,
                                                                     new[] {childType, depth - 1, properties.ToArray()});

                        propertyInfo.SetValue(entity, listResult, null);
                    }
                    catch (InvalidCastException ex)
                    {
                        throw new SetPropertyException(
                            string.Format(Messages.MSG_00014, propertyInfo.Name, GetType().Name), ex);
                    }

                    #endregion
                }

                #endregion

                //
                //Para cada atributo podemos ter um comportamento diferente
                //

                #region carrega coleção (ManyToMany)

                attributes = propertyInfo.GetCustomAttributes(typeof (ManyToMany), true);

                if (attributes != null && attributes.Length > 0)
                {
                    //
                    // Temos uma coleção de objetos relaciodos pra carregar
                    //

                    Command.ClearParameters();

                    #region creates an instance of the generic argument type

                    var relationShipType = (Persist) Activator.CreateInstance(((ManyToMany) attributes[0]).Relationship);

                    var relationShipTypeKeys = new Dictionary<string, Property>();
                    var relationShipTypeColumns = new Dictionary<string, Property>();
                    var relationShipTypeAllColumns = new Dictionary<string, Property>();

                    Mapper.LoadMetaData(relationShipType, relationShipTypeKeys, relationShipTypeColumns,
                                        relationShipTypeAllColumns);

                    #endregion

                    #region sets the instance properties foreign keys and stores in properties array

                    var properties = new List<string>();

                    var keys = new Dictionary<string, Property>();
                    var columns = new Dictionary<string, Property>();
                    var allColumns = new Dictionary<string, Property>();

                    Mapper.LoadMetaData(entity, keys, columns, allColumns);

                    foreach (var entry in keys)
                    {
                        //
                        // Procura pela propriedade no objto filho relacionada
                        //
                        string propertyName = entry.Value.Info.Name;

                        for (int i = 0; i < entry.Value.Field.Constraints.Count; i++)
                        {
                            if (relationShipType.ToString() == Convert.ToString(entry.Value.Field.Constraints[i].Type))
                            {
                                propertyName = Convert.ToString(entry.Value.Field.Constraints[i].Property);

                                break;
                            }
                        }

                        PropertyInfo childProperty = relationShipType.GetType().GetProperty(propertyName);

                        childProperty.SetValue(relationShipType, entry.Value.Value, null);

                        properties.Add(childProperty.Name);
                    }

                    #endregion

                    #region generates generic method

                    var childType =
                        (Persist) Activator.CreateInstance(propertyInfo.PropertyType.GetGenericArguments()[0]);

                    var childTypeKeys = new Dictionary<string, Property>();
                    var childTypeColumns = new Dictionary<string, Property>();
                    var childTypeAllColumns = new Dictionary<string, Property>();

                    Mapper.LoadMetaData(childType, childTypeKeys, childTypeColumns, childTypeAllColumns);

                    var genericMethodInfo = typeof (Persist).GetGenericMethod(
                        "Select", new[] {childType.GetType()},
                        new[]
                            {
                                typeof (string),
                                typeof (string),
                                typeof (string),
                                typeof (string),
                                typeof (string),
                                typeof (string),
                                typeof (int),
                                childType.GetType(),
                                typeof (string[])
                            },
                        typeof (ICollection<Persist>));

                    #endregion

                    #region set current list property based in DataSource method

                    try
                    {
                        var listResult = genericMethodInfo.Invoke(null,
                                                                  new object[]
                                                                      {
                                                                          null,
                                                                          null,
                                                                          null,
                                                                          null,
                                                                          null,
                                                                          depth - 1,
                                                                          childType,
                                                                          properties.ToArray()
                                                                      });

                        propertyInfo.SetValue(entity, listResult, null);
                    }
                    catch (InvalidCastException ex)
                    {
                        throw new SetPropertyException(
                            string.Format(Messages.MSG_00014, propertyInfo.Name, GetType().Name), ex);
                    }

                    #endregion
                }

                #endregion
            }

            #endregion

            return true;
        }

        #endregion

        #region métodos privadas

        private static bool CheckNew(object entity)
        {
            #region debug

            Debug.Assert(entity != null);

            #endregion

            var keys = new Dictionary<string, Property>();
            var columns = new Dictionary<string, Property>();
            var allColumns = new Dictionary<string, Property>();

            Mapper.LoadMetaData(entity, keys, columns, allColumns);

            foreach (var entry in keys)
            {
                object tmp = Activator.CreateInstance(entry.Value.Type);

                if (tmp != entry.Value.Value)
                    return false;

                if ((entry.Value.Field.IsIdentity || entry.Value.Field.IsSequence) &&
                    Convert.ToInt32(entry.Value.Value) > 0)
                    return false;
            }

            return true;
        }

        private bool Insert(object entity, int depth)
        {
            #region debug

            Debug.Assert(entity != null);

            Debug.Assert(depth >= 0);

            #endregion

            try
            {
                //
                // Chamamos o evento de validação dos dados
                //
                var validatingArgs = new ValidatingEventArgs {Cancel = false, Operation = Persist.Operation.Insert};

                OnValidating(entity, validatingArgs);

                if (validatingArgs.Cancel)
                {
                    return false;
                }

                Command.BeginTransaction();

                //
                // Chamamos o evento de inserção dos dados
                //
                var insertingArgs = new CancelEventArgs {Cancel = false};

                OnInserting(entity, insertingArgs);

                if (insertingArgs.Cancel)
                {
                    return false;
                }

                #region generates and executes insert query

                string query = CodeGenerator.Generate(entity, Command, Persist.Operation.Insert);

                if (Command.ExecuteNonQuery(query) == 0)
                {
                    return false;
                }

                #endregion

                #region loads the Identity or Sequence Columns

                object result;

                var keys = new Dictionary<string, Property>();
                var columns = new Dictionary<string, Property>();
                var allColumns = new Dictionary<string, Property>();

                Mapper.LoadMetaData(entity, keys, columns, allColumns);

                if (Command.CurrentDialect.SupportsIdentityColumns() && keys.Count == 1)
                {
                    #region sets identities properties (SQL Server)

                    foreach (var entry in keys)
                    {
                        if (entry.Value.Field.IsIdentity)
                        {
                            switch (Command.DataBaseType)
                            {
                                case DataBaseType.MySql:
                                    result = Command.ExecuteQuery("SELECT LAST_INSERT_ID()", ReturnType.Scalar);
                                    break;
                                case DataBaseType.Sql:
                                    result = Command.GetParameterValue(entry.Value.ParamName(Command.CurrentDialect));
                                    break;
                                default:
                                    result = 0;
                                    break;
                            }

                            entry.Value.SetValue(result);
                        }
                    }

                    #endregion
                }
                else if (Command.CurrentDialect.SupportsSequences())
                {
                    #region sets sequence properties (Oracle)

                    foreach (var entry in allColumns)
                    {
                        if (entry.Value.Field.IsSequence)
                        {
                            Command.ClearParameters();

                            result =
                                Command.ExecuteQuery(
                                    Command.CurrentDialect.GetSequenceSelectString(entry.Value.Field.Sequence),
                                    ReturnType.Scalar);

                            entry.Value.SetValue(result);
                        }
                    }

                    #endregion
                }

                #endregion

                #region save all children objects

                if (depth > 0)
                {
                    SaveChildren(entity, depth - 1, false, true);
                }

                #endregion

                //
                // Chamamos o evento de após inserção dos dados
                //
                var insertedArgs = new CancelEventArgs {Cancel = false};

                OnInserted(entity, insertedArgs);

                if (insertedArgs.Cancel)
                {
                    return false;
                }

                if (IsDone)
                {
                    Command.Commit();
                }
            }
            catch (Exception)
            {
                Command.RollBack();

                throw;
            }

            //
            //chamamos o evento CommitInserted
            //
            OnCommitInserted(entity, EventArgs.Empty);

            return true;
        }

        public void SaveChildren(object entity, int depth, bool delete, bool save)
        {
            #region debug

            if (entity == null)
                throw new ArgumentNullException("entity", Messages.InvalidArgumentValue);

            if (depth < 0)
                throw new ArgumentNullException("depth", Messages.InvalidArgumentValue);

            #endregion

            try
            {
                PropertyInfo[] propertyInfos =
                    entity.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                object[] attributes;

                if (delete)
                {
                    #region iterates properties finding ListToDeleteAttribute

                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        attributes = propertyInfo.GetCustomAttributes(typeof (ListToDelete), true);

                        if (attributes != null && attributes.Length > 0)
                        {
                            var list = (IEnumerable) propertyInfo.GetValue(entity, null);

                            foreach (object obj in list)
                            {
                                #region loads properties from current object

                                var persist = (Persist) obj;
                                persist.UseCommand(Command);
                                persist.IsDone = false;

                                PropertyInfo[] childProperties =
                                    persist.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance |
                                                                    BindingFlags.Public);

                                foreach (PropertyInfo childProperty in childProperties)
                                {
                                    attributes = childProperty.GetCustomAttributes(typeof (DbField), true);

                                    if (attributes.Length > 0)
                                    {
                                        #region finds the relationship

                                        foreach (Constraint column in ((DbField) attributes[0]).Constraints)
                                        {
                                            if (GetType() == column.Type)
                                            {
                                                foreach (PropertyInfo relatedProperty in propertyInfos)
                                                {
                                                    if (column.Property ==
                                                        relatedProperty.ToString().Substring(
                                                            relatedProperty.ToString().IndexOf(" ") + 1))
                                                    {
                                                        #region sets the parent related property of child object

                                                        childProperty.SetValue(persist,
                                                                               relatedProperty.GetValue(entity, null),
                                                                               null);

                                                        #endregion
                                                    }
                                                }
                                            }
                                        }

                                        #endregion
                                    }
                                }

                                #endregion

                                #region deletes the child object

                                if (persist.Delete(depth - 1) == 0)
                                {
                                    throw new NonAffectedRowsException(GetType());
                                }

                                #endregion
                            }
                        }
                    }

                    #endregion
                }

                if (save)
                {
                    #region Percorre os atributos procurando listas com o atributo ListToSave

                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        #region Salva a coleção de objetos filhos

                        attributes = propertyInfo.GetCustomAttributes(typeof (OneToMany), true);

                        if (attributes != null && attributes.Length > 0)
                        {
                            //
                            // Encontramos uma propriedade com o atributo ListToSave
                            //

                            var list = (IEnumerable) propertyInfo.GetValue(entity, null);

                            if (list == null)
                                continue;
                            //
                            // Como essa propriedade é IEnumerable podemos percorre-la
                            //
                            foreach (object obj in list)
                            {
                                //
                                // Para cada item da lista atualizamos as propriedades
                                // relacionadas FK->PK automaticamente
                                //

                                #region loads properties from current object

                                //
                                // Convertemos o Item para uma classe persistente
                                //
                                var persist = (Persist) obj;

                                //
                                // Habilitamos transação
                                //
                                persist.UseCommand(Command);

                                //
                                // Informamos ao objeto para não fechar a transação
                                //
                                persist.IsDone = false;

                                PropertyInfo[] childProperties =
                                    persist.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance |
                                                                    BindingFlags.Public);

                                //
                                // Percorremos as propriedades do objeto filho
                                //
                                foreach (PropertyInfo childProperty in childProperties)
                                {
                                    attributes = childProperty.GetCustomAttributes(typeof (DbField), true);

                                    //
                                    // O objeto precisa ser um campo mapeado
                                    //
                                    if (attributes.Length > 0)
                                    {
                                        //
                                        // Somente precisamos atualizar a propriedade se ele for novo
                                        // e não for uma chave primária
                                        //
                                        if (persist.IsNew && !((DbField) attributes[0]).IsIdentity)
                                        {
                                            #region finds the relationship

                                            foreach (Constraint column in ((DbField) attributes[0]).Constraints)
                                            {
                                                if (GetType() == column.Type || GetType().IsSubclassOf(column.Type))
                                                {
                                                    foreach (PropertyInfo relatedProperty in propertyInfos)
                                                    {
                                                        if (column.Property ==
                                                            relatedProperty.ToString().Substring(
                                                                relatedProperty.ToString().IndexOf(" ") + 1))
                                                        {
                                                            #region sets the parent related property of child object

                                                            childProperty.SetValue(persist,
                                                                                   relatedProperty.GetValue(entity,
                                                                                                            null),
                                                                                   null);

                                                            #endregion
                                                        }
                                                    }
                                                }
                                            }

                                            #endregion
                                        }
                                    }
                                }

                                #endregion

                                #region saves the child object recursevely

                                persist.Save(depth - 1);

                                #endregion
                            }
                        }

                        #endregion

                        #region Salva os objetos filhos

                        attributes = propertyInfo.GetCustomAttributes(typeof (OneToOne), true);

                        if (attributes != null && attributes.Length > 0)
                        {
                            //
                            // Para cada item da lista atualizamos as propriedades
                            // relacionadas FK->PK automaticamente
                            //

                            #region loads properties from current object

                            //
                            // Convertemos o Item para uma classe persistente
                            //
                            var persist = propertyInfo.GetValue(entity, null) as Persist;

                            //
                            // Habilitamos transação
                            //
                            if (persist != null)
                            {
                                persist.UseCommand(Command);

                                //
                                // Informamos ao objeto para não fechar a transação
                                //
                                persist.IsDone = false;

                                PropertyInfo[] childProperties =
                                    persist.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance |
                                                                    BindingFlags.Public);

                                //
                                // Percorremos as propriedades do objeto filho
                                //
                                foreach (PropertyInfo childProperty in childProperties)
                                {
                                    attributes = childProperty.GetCustomAttributes(typeof (DbField), true);

                                    //
                                    // O objeto precisa ser um campo mapeado
                                    //
                                    if (attributes.Length > 0)
                                    {
                                        //
                                        // Somente precisamos atualizar a propriedade se ele for novo
                                        // e não for uma chave primária
                                        //
                                        if (persist.IsNew && !((DbField) attributes[0]).IsIdentity)
                                        {
                                            #region finds the relationship

                                            foreach (Constraint column in ((DbField) attributes[0]).Constraints)
                                            {
                                                if (GetType() == column.Type)
                                                {
                                                    foreach (PropertyInfo relatedProperty in propertyInfos)
                                                    {
                                                        if (column.Property ==
                                                            relatedProperty.ToString().Substring(
                                                                relatedProperty.ToString().IndexOf(" ") + 1))
                                                        {
                                                            #region sets the parent related property of child object

                                                            childProperty.SetValue(persist,
                                                                                   relatedProperty.GetValue(
                                                                                       entity, null), null);

                                                            #endregion
                                                        }
                                                    }
                                                }
                                            }

                                            #endregion
                                        }
                                    }
                                }

                                #endregion

                                #region saves the child object recursevely

                                persist.Save(depth - 1);

                                #endregion
                            }
                        }

                        #endregion

                        #region Salva os relacionamentos muitos-para-muitos

                        attributes = propertyInfo.GetCustomAttributes(typeof (ManyToMany), true);

                        if (attributes != null && attributes.Length > 0)
                        {
                            //
                            // Encontramos uma propriedade com o atributo ManyToMany
                            //
                            var list = (IEnumerable) propertyInfo.GetValue(entity, null);

                            if (list == null)
                                continue;

                            //
                            // Como essa propriedade é IEnumerable podemos percorre-la
                            //
                            foreach (object obj in list)
                            {
                                //
                                // Para cada item da lista atualizamos as propriedades
                                // relacionadas FK->PK automaticamente
                                //

                                #region loads properties from current object

                                //
                                // Convertemos o Item para uma classe persistente
                                //
                                var persist = (Persist) obj;

                                //
                                // Habilitamos transação
                                //
                                persist.UseCommand(Command);

                                //
                                // Informamos ao objeto para não fechar a transação
                                //
                                persist.IsDone = false;

                                #endregion

                                #region saves the child object recursevely

                                persist.Save(depth - 1);

                                #endregion

                                var relationShip =
                                    (Persist) Activator.CreateInstance(((ManyToMany) attributes[0]).Relationship);

                                relationShip.UseCommand(Command);
                                relationShip.IsDone = false;


                                IEnumerable<PropertyInfo> relationShipProperties =
                                    from e in
                                        relationShip.GetType().GetProperties(BindingFlags.NonPublic |
                                                                             BindingFlags.Instance | BindingFlags.Public)
                                    where e.GetCustomAttributes(typeof (DbField), true).Length > 0
                                    select e;

                                //
                                // Percorremos as propriedades da classe de relacionamento
                                //
                                foreach (PropertyInfo relationShipProperty in relationShipProperties)
                                {
                                    object[] relationShipAttributes =
                                        relationShipProperty.GetCustomAttributes(typeof (DbField), true);

                                    //
                                    // Somente precisamos atualizar a propriedade se ele for novo
                                    // e não for uma chave primária
                                    //
                                    if (relationShip.IsNew && !((DbField) relationShipAttributes[0]).IsIdentity)
                                    {
                                        //
                                        // Procuramos o relacionamento entre a classe e suas constraints
                                        //

                                        foreach (Constraint column in ((DbField) relationShipAttributes[0]).Constraints)
                                        {
                                            if (GetType() == column.Type || GetType().IsSubclassOf(column.Type))
                                            {
                                                foreach (PropertyInfo relatedProperty in propertyInfos)
                                                {
                                                    if (column.Property ==
                                                        relatedProperty.ToString().Substring(
                                                            relatedProperty.ToString().IndexOf(" ") + 1))
                                                    {
                                                        #region sets the parent related property of child object

                                                        relationShipProperty.SetValue(relationShip,
                                                                                      relatedProperty.GetValue(entity,
                                                                                                               null),
                                                                                      null);

                                                        #endregion
                                                    }
                                                }
                                            }

                                            if (persist.GetType() == column.Type ||
                                                persist.GetType().IsSubclassOf(column.Type))
                                            {
                                                PropertyInfo[] propInfos =
                                                    persist.GetType().GetProperties(BindingFlags.NonPublic |
                                                                                    BindingFlags.Instance |
                                                                                    BindingFlags.Public);

                                                foreach (PropertyInfo relatedProperty in propInfos)
                                                {
                                                    if (column.Property ==
                                                        relatedProperty.ToString().Substring(
                                                            relatedProperty.ToString().IndexOf(" ") + 1))
                                                    {
                                                        #region sets the parent related property of child object

                                                        relationShipProperty.SetValue(relationShip,
                                                                                      relatedProperty.GetValue(persist,
                                                                                                               null),
                                                                                      null);

                                                        #endregion
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                relationShip.IsDone = false;
                                relationShip.Save(0);
                            }
                        }

                        #endregion
                    }

                    #endregion
                }
            }
            catch (Exception)
            {
                Command.RollBack();

                throw;
            }
        }

        private bool Update(object entity, int depth)
        {
            #region debug

            Debug.Assert(entity != null);
            Debug.Assert(depth >= 0);

            #endregion

            try
            {
                //
                // Chamamos o evento de validação dos dados
                //
                var validatingArgs = new ValidatingEventArgs {Cancel = false, Operation = Persist.Operation.Update};

                OnValidating(entity, validatingArgs);

                if (validatingArgs.Cancel)
                {
                    throw new InvalidObjectException(GetType());
                }

                Command.BeginTransaction();

                //
                // chamamos o evento de atualização dos dados
                //

                var updatingArgs = new CancelEventArgs {Cancel = false};

                OnUpdating(entity, updatingArgs);

                if (updatingArgs.Cancel)
                {
                    return false;
                }

                #region generates and makes update query

                string query = CodeGenerator.Generate(entity, Command, Persist.Operation.Update);

                if (query != string.Empty && Command.ExecuteNonQuery(query) == 0)
                {
                    return false;
                }

                #endregion

                #region saves or deletes children objects

                if (depth > 0)
                {
                    SaveChildren(entity, depth - 1, true, true);
                }

                #endregion

                //
                // chamamos o evento de atualização dos dados
                //

                var updatedArgs = new CancelEventArgs {Cancel = false};

                OnUpdated(entity, updatedArgs);

                if (IsDone)
                {
                    Command.Commit();
                }
            }
            catch (Exception)
            {
                Command.RollBack();

                throw;
            }

            #region chamamos o evento CommitUpdated

            OnCommitUpdated(entity, EventArgs.Empty);

            #endregion

            return true;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Command.Commit();
        }

        #endregion

        #region protected virtual methods

        /// <summary>
        /// Inserção concluída
        /// </summary>
        /// <param name="sender">Objeto referente</param>
        /// <param name="e">Args</param>
        protected virtual void OnCommitInserted(object sender, EventArgs e)
        {
            if (CommitInserted != null)
            {
                CommitInserted(sender, e);
            }
        }

        /// <summary>
        /// Atualização concluída
        /// </summary>
        /// <param name="sender">Objeto referente</param>
        /// <param name="e">Args</param>
        protected virtual void OnCommitUpdated(object sender, EventArgs e)
        {
            if (CommitUpdated != null)
            {
                CommitInserted(sender, e);
            }
        }

        /// <summary>
        /// Exclusão concluída
        /// </summary>
        /// <param name="sender">Objeto referente</param>
        /// <param name="e">Args</param>
        protected virtual void OnCommitDeleted(object sender, EventArgs e)
        {
            if (CommitDeleted != null)
            {
                CommitDeleted(sender, e);
            }
        }


        /// <summary>
        /// Imediatamente antes de buscar
        /// </summary>
        /// <param name="sender">Objeto referente</param>
        /// <param name="e">Args</param>
        protected virtual void OnLoading(object sender, CancelEventArgs e)
        {
            if (Loading != null)
            {
                Loading(sender, e);
            }
        }

        /// <summary>
        /// After getting.
        /// </summary>
        /// <returns>Must return true.</returns>
        protected virtual void OnLoaded(object sender, CancelEventArgs e)
        {
            if (Loaded != null)
            {
                Loaded(sender, e);
            }
        }

        /// <summary>
        /// After saving.
        /// </summary>
        /// <returns>Must return true.</returns>
        protected virtual void OnInserting(object sender, CancelEventArgs e)
        {
            if (Inserting != null)
            {
                Inserting(sender, e);
            }
        }

        /// <summary>
        /// After saving.
        /// </summary>
        /// <returns>Must return true.</returns>
        protected virtual void OnInserted(object sender, CancelEventArgs e)
        {
            if (Inserted != null)
            {
                Inserted(sender, e);
            }
        }

        /// <summary>
        /// After saving.
        /// </summary>
        /// <returns>Must return true.</returns>
        protected virtual void OnUpdating(object sender, CancelEventArgs e)
        {
            if (Updating != null)
            {
                Updating(sender, e);
            }
        }

        /// <summary>
        /// After saving.
        /// </summary>
        /// <returns>Must return true.</returns>
        protected virtual void OnUpdated(object sender, CancelEventArgs e)
        {
            if (Updated != null)
            {
                Updated(sender, e);
            }
        }

        /// <summary>
        /// After deleting.
        /// </summary>
        /// <returns>Must return true.</returns>
        protected virtual void OnDeleting(object sender, CancelEventArgs e)
        {
            if (Deleting != null)
            {
                Deleting(sender, e);
            }
        }

        /// <summary>
        /// After deleting.
        /// </summary>
        /// <returns>Must return true.</returns>
        protected virtual void OnDeleted(object sender, CancelEventArgs e)
        {
            if (Deleted != null)
            {
                Deleted(sender, e);
            }
        }

        /// <summary>
        /// Before inserting or updating.
        /// </summary>
        /// <returns>Must return true.</returns>
        protected virtual void OnValidating(object sender, ValidatingEventArgs e)
        {
            if (Validating != null)
            {
                Validating(sender, e);
            }
        }

        #endregion
    }
}