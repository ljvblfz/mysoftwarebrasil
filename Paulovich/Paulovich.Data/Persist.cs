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
//           * André Paulovich (paulovich@100loop.com)     
//           Blog: http://www.100loop.com/blogs/           
//           Messenger: andrepaulovich@hotmail.com
//           
//           * Rigel (rigel.octaviano@gmail.com)
//           Blog: http://rigel-aguilar.blogspot.com/
//           Messenger: rigelaguilar@hotmail.com 
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Paulovich.Data.Resources;

namespace Paulovich.Data
{
    public class ValidatingEventArgs : CancelEventArgs
    {
        public Persist.Operation Operation { get; set; }
    }

    /// <summary>
    /// Persistent Class.
    /// </summary>
    [Serializable]
    public abstract class Persist
    {
        #region enums

        /// <summary>
        /// Supported operations.
        /// Get     = SELECT * FROM tableName WHERE (pk=@pk)
        /// Select  = SELECT * FROM tableName
        /// Insert  = INSERT INTO tableName(field1, fieldn) VALUES(@field1, @fieldn)
        /// Update  = UPDATE tableName SET field1=@field1, fieldn=@fieldn WHERE (pk=@pk)
        /// Delete  = DELETE FROM tableName WHERE (pk=@pk)
        /// </summary>
        public enum Operation
        {
            Get = 1,
            Select,
            Insert,
            Update,
            Delete
        }

        #endregion

        #region fields and properties

        [XmlIgnore]
        protected Command Command { get; set; }

        /// <summary>
        /// If is a new registry, return true else false.
        /// </summary>
        [XmlIgnore]
        public bool IsNew { get; set; }

        /// <summary>
        /// Can commits a transaction.
        /// </summary>
        [XmlIgnore]
        public bool IsDone { get; set; }

        /// <summary>
        /// List of objects to delete.
        /// </summary>
        [XmlIgnore]
        [ListToDelete]
        public Collection<Persist> ListToDelete { get; set; }

        [XmlIgnore]
        public Collection<Filter> Filters { get; set; }

        public event CancelEventHandler Inserting;
        public event CancelEventHandler Inserted;
        public event EventHandler CommitInserted;
        public event CancelEventHandler Updating;
        public event CancelEventHandler Updated;
        public event EventHandler CommitUpdated;
        public event CancelEventHandler Getting;
        public event CancelEventHandler Got;
        public event CancelEventHandler Deleting;
        public event CancelEventHandler Deleted;
        public event EventHandler CommitDeleted;
        public event EventHandler<ValidatingEventArgs> Validating;

        #endregion

        #region constructors

        /// <summary>
        /// Creates a new object loading it from database
        /// </summary>
        /// <param name="keys"></param>
        protected Persist(params object[] keys)
            : this()
        {
            if (keys != null && keys.Length > 0)
            {
                PrimaryKeys = keys;

                #region Loads the object

                if (!Get(0))
                {
                    throw new ObjectNotFoundException(GetType());
                }

                #endregion
            }
        }

        /// <summary>
        /// Creates a new Persistent Object
        /// </summary>
        protected Persist()
        {
            IsNew = true;
            IsDone = true;
            Command = new Command();

            Filters = new Collection<Filter>();

            //
            // Inicializa todas as coleções marcadas com o atributo [ListTo]
            //
            Mapper.InitializeCollections(this);
        }

        /// <summary>
        /// Create a new Persistent Object based in command argument, using current transaction.
        /// </summary>
        /// <param name="command"></param>
        protected Persist(Command command)
            : this()
        {
            #region debug

            if (command == null)
                throw new ArgumentNullException("command", Messages.InvalidArgumentValue);

            #endregion

            Command = command;
        }

        protected object[] PrimaryKeys
        {
            get
            {
                var keys = new Dictionary<string, Property>();
                var columns = new Dictionary<string, Property>();
                var allColumns = new Dictionary<string, Property>();

                Mapper.LoadMetaData(this, keys, columns, allColumns);

                var primaryKeys = new object[keys.Count];

                int i = 0;

                foreach (var item in keys)
                {
                    primaryKeys[i] = item.Value;

                    i++;
                }

                return primaryKeys;
            }

            set
            {
                #region Validate parameters

                var keys = new Dictionary<string, Property>();
                var columns = new Dictionary<string, Property>();
                var allColumns = new Dictionary<string, Property>();

                Mapper.LoadMetaData(this, keys, columns, allColumns);

                if (value.Length != keys.Count)
                {
                    throw new InvalidPrimaryKeyException(GetType());
                }

                int i = 0;

                foreach (var entry in keys)
                {
                    entry.Value.SetValue(value[i]);

                    i++;
                }

                #endregion
            }
        }

        /// <summary>
        /// Sets the current command.
        /// </summary>
        /// <param name="command">Command</param>
        public void UseCommand(Command command)
        {
            #region debug

            if (command == null)
                throw new ArgumentNullException("command", Messages.InvalidArgumentValue);

            #endregion

            Command = command;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Insere o objeto na base de dados
        /// </summary>
        /// <param name="depth">Até que profundidade os objetos filhos serão salvos</param>
        private void Insert(int depth)
        {
            try
            {
                //
                // Chamamos o evento de validação dos dados
                //
                var validatingArgs = new ValidatingEventArgs {Cancel = false, Operation = Operation.Insert};

                OnValidating(this, validatingArgs);

                if (validatingArgs.Cancel)
                {
                    throw new InvalidObjectException(GetType());
                }

                Command.BeginTransaction();

                //
                // Chamamos o evento de inserção dos dados
                //
                var insertingArgs = new CancelEventArgs {Cancel = false};

                OnInserting(this, insertingArgs);

                if (insertingArgs.Cancel)
                {
                    throw new OnInsertingException(GetType());
                }

                #region generates and executes insert query

                string query = CodeGenerator.Generate(this, Command, Operation.Insert);

                if (Command.ExecuteNonQuery(query) == 0)
                {
                    throw new NonAffectedRowsException(GetType());
                }

                #endregion

                #region loads the Identity or Sequence Columns

                object result;

                var keys = new Dictionary<string, Property>();
                var columns = new Dictionary<string, Property>();
                var allColumns = new Dictionary<string, Property>();

                Mapper.LoadMetaData(this, keys, columns, allColumns);

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
                    SaveChildren(depth - 1, false, true);
                }

                #endregion

                //
                // Chamamos o evento de após inserção dos dados
                //
                var insertedArgs = new CancelEventArgs {Cancel = false};

                OnInserted(this, insertedArgs);

                if (insertedArgs.Cancel)
                {
                    throw new OnInsertedException(GetType());
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
            OnCommitInserted(this, EventArgs.Empty);
        }

        private void SaveChildren(int depth, bool delete, bool save)
        {
            try
            {
                PropertyInfo[] propertyInfos =
                    GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                object[] attributes;

                if (delete)
                {
                    #region iterates properties finding ListToDeleteAttribute

                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        attributes = propertyInfo.GetCustomAttributes(typeof (ListToDelete), true);

                        if (attributes != null && attributes.Length > 0)
                        {
                            var list = (IEnumerable) propertyInfo.GetValue(this, null);

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
                                                                               relatedProperty.GetValue(this, null),
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

                            var list = (IEnumerable) propertyInfo.GetValue(this, null);

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
                                                                                   relatedProperty.GetValue(this,
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
                            var persist = propertyInfo.GetValue(this, null) as Persist;

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
                                                                                       this, null), null);

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
                            var list = (IEnumerable) propertyInfo.GetValue(this, null);

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
                                                                                      relatedProperty.GetValue(this,
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="depth"></param>
        private void Update(int depth)
        {
            try
            {
                //
                // Chamamos o evento de validação dos dados
                //
                var validatingArgs = new ValidatingEventArgs {Cancel = false, Operation = Operation.Update};

                OnValidating(this, validatingArgs);

                if (validatingArgs.Cancel)
                {
                    throw new InvalidObjectException(GetType());
                }

                Command.BeginTransaction();

                //
                // chamamos o evento de atualização dos dados
                //

                var updatingArgs = new CancelEventArgs {Cancel = false};

                OnUpdating(this, updatingArgs);

                if (updatingArgs.Cancel)
                {
                    throw new OnUpdatingException(GetType());
                }

                #region generates and makes update query

                string query = CodeGenerator.Generate(this, Command, Operation.Update);

                if (query != string.Empty && Command.ExecuteNonQuery(query) == 0)
                {
                    throw new NonAffectedRowsException(GetType());
                }

                #endregion

                #region saves or deletes children objects

                if (depth > 0)
                {
                    SaveChildren(depth - 1, true, true);
                }

                #endregion

                //
                // chamamos o evento de atualização dos dados
                //

                var updatedArgs = new CancelEventArgs {Cancel = false};

                OnUpdated(this, updatedArgs);

                if (updatedArgs.Cancel)
                {
                    throw new OnUpdatingException(GetType());
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

            #region chamamos o evento CommitUpdated

            OnCommitUpdated(this, EventArgs.Empty);

            #endregion
        }

        #endregion

        #region data access

        /// <summary>
        /// Retrieves an object
        /// </summary>
        /// <returns>Return true if have else false</returns>
        public bool Get()
        {
            return Get(0);
        }

        /// <summary>
        /// Retrieves an object recursively
        /// </summary>
        /// <param name="depth">Depth to load children objects</param>
        /// <returns>Return true if succeeded else throw an exception</returns>
        public bool Get(int depth)
        {

            IsNew = false;

            #region calls OnGetting Delegate

            var gettingArgs = new CancelEventArgs {Cancel = false};

            OnGetting(this, gettingArgs);

            if (gettingArgs.Cancel)
            {
                return false;
            }

            #endregion

            #region generates and makes select query

            string query = CodeGenerator.Generate(this, Command, Operation.Get);

            object objectTable = Command.ExecuteQuery(query, ReturnType.DataTable);

            #endregion

            if (objectTable != null)
            {
                var dt = (DataTable) objectTable;

                #region loads the object or leaves the method

                if (dt.Rows.Count == 0)
                {
                    return false;
                }
                if (dt.Rows.Count == 1)
                {
                    var keys = new Dictionary<string, Property>();
                    var columns = new Dictionary<string, Property>();
                    var allColumns = new Dictionary<string, Property>();

                    Mapper.LoadMetaData(this, keys, columns, allColumns);

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
                                entry.Value.Info.SetValue(this, null, null);
                            }

                            #endregion
                        }

                        #endregion
                    }

                    #endregion
                }
                else
                {
                    return false;
                }

                #endregion

                #region loads children objects

                if (depth - 1 >= 0 && !LoadChildren(depth - 1))
                {
                    throw new LoadChildrenException(GetType(), depth - 1);
                }

                #endregion
            }
            else
            {
                return false;
            }

            #region calls OnGot Delegate

            var gotArgs = new CancelEventArgs {Cancel = false};

            OnGot(this, gotArgs);

            if (gotArgs.Cancel)
            {
                return false;
            }

            #endregion

            return true;
        }

        public bool LoadProperty(string property)
        {
            return LoadProperty(property, 0);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        public bool LoadProperty(string property, int depth)
        {
            #region debug

            if (string.IsNullOrEmpty(property))
                throw new ArgumentNullException("property", Messages.InvalidArgumentValue);

            #endregion

            //
            // Carrega as propriedades desse objeto
            // carrega também os métodos públicos, privados e protegidos da instancia
            //
            PropertyInfo[] propertyInfos =
                GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            object[] attributes;

            //
            // Percorre as propriedades
            //
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.Name == property)
                {
                    attributes = propertyInfo.GetCustomAttributes(typeof (OneToMany), true);

                    //
                    // Se a propriedade for uma ListToSave
                    //
                    if (attributes != null && attributes.Length > 0)
                    {
                        Command.ClearParameters();

                        #region creates an instance of the generic argument type

                        //
                        // Esse objeto é usado como filtro para buscar os registros
                        // que possuem propriedades semelhantes
                        //


                        //
                        // É permitido ter construtores privados ou internos nas classes persistentes
                        //

                        object childType = Activator.CreateInstance(propertyInfo.PropertyType.GetGenericArguments()[0],
                                                                    true);

                        #endregion

                        #region sets the instance properties foreign keys and stores in properties array

                        var properties = new List<string>();

                        var keys = new Dictionary<string, Property>();
                        var columns = new Dictionary<string, Property>();
                        var allColumns = new Dictionary<string, Property>();

                        Mapper.LoadMetaData(this, keys, columns, allColumns);

                        foreach (var entry in keys)
                        {
                            //
                            // Procura pela propriedade no objeto filho relacionada
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

                            //
                            // Define a propriedade relacionada como sendo a chave primária do objeto-pai
                            //
                            childProperty.SetValue(childType, entry.Value.Value, null);

                            //
                            // Guarda o nome dessa propriedade
                            //
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
                            //
                            // Chama o método DataSource da classe passado o objeto como parâmetro
                            //
                            object listResult = genericMethodInfo.Invoke(null,
                                                                         new[] {childType, 0, properties.ToArray()});

                            //
                            // Define a propriedade "coleção de objetos" atual como sendo essa lista
                            //
                            propertyInfo.SetValue(this, listResult, null);
                        }
                        catch (InvalidCastException ex)
                        {
                            throw new SetPropertyException(
                                string.Format(Messages.MSG_00014, propertyInfo.Name, GetType().Name), ex);
                        }

                        #endregion
                    }

                    #region carrega uma entidade relacionada (ObjectToSave)

                    attributes = propertyInfo.GetCustomAttributes(typeof (OneToOne), true);

                    if (attributes != null && attributes.Length > 0)
                    {
                        //
                        // Temos um objeto a ser carregado
                        //

                        #region creates an instance of the generic argument type

                        object parentType = Activator.CreateInstance(propertyInfo.PropertyType);

                        #endregion

                        #region sets the instance properties foreign keys and stores in properties array

                        var properties = new List<string>();

                        var parentTypeEntity = parentType as Persist;

                        //
                        // Procura pelas propriedades que possuem o atributo PrimaryKey
                        //
                        if (parentTypeEntity != null)
                        {
                            var parentTypeEntityKeys = new Dictionary<string, Property>();
                            var parentTypeEntityColumns = new Dictionary<string, Property>();
                            var parentTypeEntityAllColumns = new Dictionary<string, Property>();

                            Mapper.LoadMetaData(parentTypeEntity, parentTypeEntityKeys, parentTypeEntityColumns,
                                                parentTypeEntityAllColumns);

                            foreach (var entry in parentTypeEntityKeys)
                            {
                                //
                                // Procura pela propriedade no objeto filho relacionada
                                //
                                string propertyName = entry.Value.Info.Name;

                                foreach (Constraint item in entry.Value.Field.Constraints)
                                {
                                    if (parentType.ToString() == Convert.ToString(item.Type))
                                    {
                                        propertyName = Convert.ToString(item.Property);

                                        break;
                                    }
                                }
                                PropertyInfo thisProperty = GetType().GetProperty(propertyName);

                                PropertyInfo parentProperty = parentType.GetType().GetProperty(propertyName);

                                parentProperty.SetValue(parentType, thisProperty.GetValue(this, null), null);

                                properties.Add(parentProperty.Name);
                            }
                        }

                        #endregion

                        #region generates generic method

                        MethodInfo selectMethod = (typeof (Persist)).GetMethod("Get", new[] {typeof (Int32)});

                        #endregion

                        #region set current list property based in DataSource method

                        try
                        {
                            object objectResult = selectMethod.Invoke(parentType, new object[] {depth});

                            if (Convert.ToBoolean(objectResult))
                            {
                                propertyInfo.SetValue(this, parentType, null);
                            }
                            else
                            {
                                return false;
                            }
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
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="depth"></param>
        /// <returns></returns>
        private bool LoadChildren(int depth)
        {

            #region iterates propertyInfos finding ListToSaveAttribute

            PropertyInfo[] propertyInfos =
                GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

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

                    Mapper.LoadMetaData(this, keys, columns, allColumns);

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

                        propertyInfo.SetValue(this, listResult, null);
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

                    Mapper.LoadMetaData(this, keys, columns, allColumns);

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

                    var genericMethodInfo = typeof (Session).GetGenericMethod(
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

                        propertyInfo.SetValue(this, listResult, null);
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

        /// <summary>
        /// Delete the registry
        /// </summary>
        /// <returns>If a error occurs, return false</returns>
        public int Delete()
        {
            return Delete(0);
        }

        /// <summary>
        /// Delete the object from list.
        /// </summary>
        /// <param name="list">List</param>
        /// <param name="persist">Persistent Object</param>
        public void Delete(IList list, Persist persist)
        {
            #region debug

            if (list == null)
                throw new ArgumentNullException("list", Messages.InvalidArgumentValue);

            if (persist == null)
                throw new ArgumentNullException("persist", Messages.InvalidArgumentValue);

            #endregion

            ListToDelete.Add(persist);
            list.Remove(persist);
        }

        /// <summary>
        /// Delete the object from list based in index.
        /// </summary>
        /// <param name="list">List</param>
        /// <param name="index">Index</param>
        public void Delete(IList list, int index)
        {
            #region debug

            if (list == null)
                throw new ArgumentNullException("list", Messages.InvalidArgumentValue);

            if (index < 0)
                throw new ArgumentNullException("index", Messages.InvalidArgumentValue);

            #endregion

            ListToDelete.Add((Persist) list[index]);
            list.RemoveAt(index);
        }

        /// <summary>
        /// Delete the registry
        /// </summary>
        /// <returns>If a error occurs, return false</returns>
        public int Delete(int depth)
        {
            return Delete(depth, true);
        }

        /// <summary>
        /// Delete the registry
        /// </summary>
        /// <returns>If a error occurs, return false</returns>
        public void Delete(Persist obj)
        {
            #region debug

            if (obj == null)
                throw new ArgumentNullException("obj", Messages.InvalidArgumentValue);

            #endregion

            ListToDelete.Add(obj);
        }

        /// <summary>
        /// Delete the registry
        /// </summary>
        /// <returns>If a error occurs, return false</returns>
        public int Delete(int depth, bool getBefore)
        {

            int affectedRows;
            CheckNew();

            try
            {
                Command.BeginTransaction();

                #region if getBefore is true, gets the object from database

                if (getBefore && !Get(depth - 1))
                {
                    throw new ObjectNotFoundException(GetType());
                }

                #endregion

                //
                // Chamamos o evento antes de excluir
                //

                var deletingArgs = new CancelEventArgs { Cancel = false };

                OnDeleting(this, deletingArgs);

                if (deletingArgs.Cancel)
                {
                    throw new OnDeletingException(GetType());
                }

                #region delete all children

                if (depth - 1 >= 0)
                {
                    #region iterates propertyInfos finding ListToAttribute

                    PropertyInfo[] propertyInfos =
                        GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                    object[] attributes;

                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        attributes = propertyInfo.GetCustomAttributes(typeof(ListTo), true);

                        if (attributes != null && attributes.Length > 0)
                        {
                            var list = (IEnumerable)propertyInfo.GetValue(this, null);

                            //Se a lista for nula, passar para o próximo item da lista de propriedades
                            if (list == null) continue;

                            foreach (object obj in list)
                            {
                                var persist = (Persist)obj;
                                persist.UseCommand(Command);
                                persist.IsDone = false;

                                if (persist.Delete(depth - 1) == 0)
                                {
                                    throw new NonAffectedRowsException(GetType());
                                }
                            }
                        }
                    }

                    #endregion
                }

                #endregion

                #region generates and executes the query

                Command.ClearParameters();
                Command.CommandType = CommandType.Text;

                string query = CodeGenerator.Generate(this, Command, Operation.Delete);

                affectedRows = Command.ExecuteNonQuery(query);

                #endregion

                //
                // Chamamos o evento após a exclusão
                //

                var deletedArgs = new CancelEventArgs { Cancel = false };

                OnDeleted(this, deletedArgs);

                if (deletedArgs.Cancel)
                {
                    throw new OnDeletedException(GetType());
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

            #region calls OnDeleted Delegate

            OnCommitDeleted(this, EventArgs.Empty);

            #endregion

            return affectedRows;
        }

        private void CheckNew()
        {
            var keys = new Dictionary<string, Property>();
            var columns = new Dictionary<string, Property>();
            var allColumns = new Dictionary<string, Property>();

            Mapper.LoadMetaData(this, keys, columns, allColumns);

            foreach (var entry in keys)
            {
                if ((entry.Value.Field.IsIdentity || entry.Value.Field.IsSequence) &&
                    Convert.ToInt32(entry.Value.Value) > 0)
                {
                    IsNew = false;
                    break;
                }
            }
        }

        /// <summary>
        /// Insert a object if is new else update.
        /// </summary>
        /// <returns>If a error occurs, return false.</returns>
        public bool Save()
        {
            CheckNew();

            if (IsNew)
            {
                Insert(0);
            }
            else
            {
                Update(0);
            }

            IsNew = false;

            return true;
        }

        /// <summary>
        /// Insert a object if is new else update.
        /// </summary>
        /// <returns>If a error occurs, return false.</returns>
        public bool Save(int depth)
        {
            CheckNew();

            if (IsNew)
            {
                Insert(depth);
            }
            else
            {
                Update(depth);
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Obsolete("Utilize o método Mapper.GetTableName()")]
        public string GetTableName()
        {
            object[] attributes = GetType().GetCustomAttributes(typeof (Table), true);

            #region debug

            if (attributes == null)
                throw new NullReferenceException("attributes");

            #endregion

            string name = (attributes.Length == 1)
                              ? ((Table) attributes[0]).TableName
                              : GetType().Name;

            if (attributes.Length == 0)
                return Command.CurrentDialect.GetOpenBracketString() + name + Command.CurrentDialect.GetCloseBracketString();
            
            return (((Table) attributes[0]).MatchCase)
                       ? Command.CurrentDialect.GetOpenBracketString() + name + Command.CurrentDialect.GetCloseBracketString()
                       : name;
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
        protected virtual void OnGetting(object sender, CancelEventArgs e)
        {
            if (Getting != null)
            {
                Getting(sender, e);
            }
        }

        /// <summary>
        /// After getting.
        /// </summary>
        /// <returns>Must return true.</returns>
        protected virtual void OnGot(object sender, CancelEventArgs e)
        {
            if (Got != null)
            {
                Got(sender, e);
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

        #region public static methods

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
            where T : Persist, new()
        {
            return Select(null, null, null, null, null, null, depth, persist, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Collection<T> Select<T>()
            where T : Persist, new()
        {
            return Select<T>(null, null, null, null, null, null, 0, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="persist"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Collection<T> Select<T>(T persist, params string[] parameters)
            where T : Persist, new()
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
            where T : Persist, new()
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
            where T : Persist, new()
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
            where T : Persist, new()
        {
            return Select(null, null, where, null, null, orderBy, 0, persist, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="select"></param>
        /// <param name="from"></param>
        /// <param name="where"></param>
        /// <param name="groupBy"></param>
        /// <param name="having"></param>
        /// <param name="orderBy"></param>
        /// <param name="depth"></param>
        /// <param name="persist"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Collection<T> Select<T>(string select, string from, string where,
                                              string groupBy, string having, string orderBy, int depth, T persist,
                                              params string[] parameters)
            where T : Persist, new()
        {
            var result = new Collection<T>();
            var command = new Command();

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

                    var obj = new T {IsNew = false};

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

                    if (depth - 1 >= 0 && !obj.LoadChildren(depth - 1))
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

        public Collection<T> Join<T>(params Type[] relationShipType)
            where T : Persist, new()
        {
            #region debug

            string from = "";
            string query = "";
            var command = new Command();
            var result = new Collection<T>();

            if (relationShipType == null)
                throw new ArgumentNullException("relationShipType", Messages.InvalidArgumentValue);

            #endregion
            foreach (Type itemRelationShipType in relationShipType)
            {


                var relationShip = (Persist)Activator.CreateInstance(itemRelationShipType);
                var child = new T { IsNew = false };

                var childKeys = new Dictionary<string, Property>();
                var childColumns = new Dictionary<string, Property>();
                var childAllColumns = new Dictionary<string, Property>();

                Mapper.LoadMetaData(child, childKeys, childColumns, childAllColumns);

                var properties = new List<string>();

                PropertyInfo sideAProperty;
                PropertyInfo relationShipAProperty;

                PropertyInfo relationShipBProperty = null;
                PropertyInfo sideBProperty = null;

                var relationShipKeys = new Dictionary<string, Property>();
                var relationShipColumns = new Dictionary<string, Property>();
                var relationShipAllColumns = new Dictionary<string, Property>();

                Mapper.LoadMetaData(relationShip, relationShipKeys, relationShipColumns, relationShipAllColumns);

                foreach (var entry in relationShipKeys)
                {

                    for (int i = 0; i < entry.Value.Field.Constraints.Count; i++)
                    {
                        //
                        // Se a classe relacionada na constraint desse relacionamento for o mesmo
                        // nós atualizamos o nome da propriedade com o nome sugerido.
                        //

                        if (ToString() == Convert.ToString(entry.Value.Field.Constraints[i].Type))
                        {
                            //
                            // Encontramos o relacionamento
                            //
                            relationShipAProperty = relationShip.GetType().GetProperty(entry.Key);

                            if (relationShipAProperty == null)
                                throw new InvalidForeignKeyException(GetType());

                            sideAProperty = GetType().GetProperty(entry.Value.Field.Constraints[i].Property);

                            if (sideAProperty == null)
                                throw new InvalidForeignKeyException(GetType());

                            //
                            // Definimos a propriedade no relacionamento
                            //

                            relationShipAProperty.SetValue(relationShip, sideAProperty.GetValue(this, null), null);

                            //
                            // Guardamos o nome da propriedade
                            //

                            properties.Add(relationShipAProperty.Name);
                        }


                        //
                        // Se a classe relacionada na constraint desse relacionamento for o mesmo
                        // nós atualizamos o nome da propriedade com o nome sugerido.
                        //

                        if (child.ToString() == Convert.ToString(entry.Value.Field.Constraints[i].Type))
                        {
                            //
                            // Encontramos o relacionamento
                            //

                            relationShipBProperty = relationShip.GetType().GetProperty(entry.Key);

                            if (relationShipBProperty == null)
                                throw new InvalidForeignKeyException(GetType());

                            sideBProperty = child.GetType().GetProperty(entry.Value.Field.Constraints[i].Property);

                            if (sideBProperty == null)
                                throw new InvalidForeignKeyException(GetType());
                        }
                    }
                }

                #region debug

                if (relationShipBProperty == null)
                {
                    throw new NullReferenceException("relationShipBProperty");
                }

                #endregion

                from += string.Format("{0} INNER JOIN {1} ON {2} = {3}",
                                            Mapper.GetTableName(child, command.CurrentDialect),
                                            Mapper.GetTableName(relationShip, command.CurrentDialect),
                                            childKeys[relationShipBProperty.Name].ColumnWithMatchCase(Command.CurrentDialect),
                                            relationShipKeys[sideBProperty.Name].ColumnWithMatchCase(Command.CurrentDialect));

                #region generates and executes query

                query = SqlBuilder.Select.Join(from, child.GetType(), relationShip, command, properties.ToArray());
            }

            object objectTable = command.ExecuteQuery(query, ReturnType.DataTable);

            #endregion

            if (objectTable != null)
            {
                var dt = (DataTable) objectTable;

                #region for each row, create a Persistent object adding to the result

                foreach (DataRow dtRow in dt.Rows)
                {
                    #region create a new persistent object

                    var obj = new T {IsNew = false};

                    #endregion

                    #region sets all properties

                    var keys = new Dictionary<string, Property>();
                    var columns = new Dictionary<string, Property>();
                    var allColumns = new Dictionary<string, Property>();

                    Mapper.LoadMetaData(obj, keys, columns, allColumns);

                    foreach (var entry in allColumns)
                    {
                        if (dtRow.Table.Columns.IndexOf(entry.Value.Alias()) != -1 &&
                            dtRow[entry.Value.Alias()] != DBNull.Value)
                        {
                            entry.Value.SetValue(dtRow[entry.Value.Alias()]);
                        }
                    }

                    #endregion

                    result.Add(obj);
                }

                #endregion

                return result;
            }

            return null;
            
        }

        public static int Count<T>(T filter, string[] parameters)
            where T : Persist, new()
        {
            var command = new Command();

            var metadataFilter = filter ?? new T();

            var countQuery = SqlBuilder.Select.Count(metadataFilter, parameters, command);

            var objectRowsCount = command.ExecuteQuery(countQuery, ReturnType.Scalar);

            if (objectRowsCount == null)
                throw new NullReferenceException("objectRowsCount");

            return (int)objectRowsCount;
        }

        public static int Count<T>(Filter[] parameters)
            where T : Persist, new()
        {
            var command = new Command();

            var metadataFilter = new T();

            var countQuery = SqlBuilder.Select.Count(metadataFilter, parameters, command);

            var objectRowsCount = command.ExecuteQuery(countQuery, ReturnType.Scalar);

            if (objectRowsCount == null)
                throw new NullReferenceException("objectRowsCount");

            return (int)objectRowsCount;
        }

        public static Collection<T> Paging<T>(int pageNumber, int pageSize, out int rowsCount, T filter, string[] parameters, string orderBy)
             where T : Persist, new()
        {

            var result = new Collection<T>();

            var command = new Command();

            var metadataFilter = filter ?? new T();

            rowsCount = Count(metadataFilter, parameters);

            #region generates and executes query

            var query = SqlBuilder.Select.Paging(metadataFilter, parameters, orderBy, command, pageSize, pageNumber);

            var objectTable = command.ExecuteQuery(query, ReturnType.DataTable);

            #endregion

            if (objectTable != null)
            {
                var dt = (DataTable)objectTable;

                #region for each row, create a Persistent object adding to the result

                foreach (DataRow dtRow in dt.Rows)
                {
                    #region create a new persistent object

                    var obj = new T { IsNew = false };

                    #endregion

                    #region sets all properties

                    var keys = new Dictionary<string, Property>();
                    var columns = new Dictionary<string, Property>();
                    var allColumns = new Dictionary<string, Property>();

                    Mapper.LoadMetaData(obj, keys, columns, allColumns);

                    foreach (var entry in allColumns)
                    {
                        if (dtRow.Table.Columns.IndexOf(entry.Value.Alias()) != -1 &&
                            dtRow[entry.Value.Alias()] != DBNull.Value)
                        {
                            entry.Value.SetValue(dtRow[entry.Value.Alias()]);
                        }
                    }

                    #endregion

                    result.Add(obj);
                }

                #endregion

                return result;
            }

            return null;
            

        }

        public static Collection<T> Paging<T>(int pageNumber, int pageSize, out int rowsCount, Filter[] parameters, OrderBy[] orderBy)
            where T : Persist, new()
        {

            pageNumber = pageNumber >= 0 ? pageNumber : 0;
            pageSize = pageSize > 0 ? pageSize : 10;

            var result = new Collection<T>();

            var command = new Command();

            var metadataFilter = new T();

            rowsCount = Count<T>(parameters);

            #region generates and executes query

            var query = SqlBuilder.Select.Paging<T>(parameters, orderBy, command, pageSize, pageNumber);

            var objectTable = command.ExecuteQuery(query, ReturnType.DataTable);

            #endregion

            if (objectTable != null)
            {
                var dt = (DataTable)objectTable;

                #region for each row, create a Persistent object adding to the result

                foreach (DataRow dtRow in dt.Rows)
                {
                    #region create a new persistent object

                    var obj = new T { IsNew = false };

                    #endregion

                    #region sets all properties

                    var keys = new Dictionary<string, Property>();
                    var columns = new Dictionary<string, Property>();
                    var allColumns = new Dictionary<string, Property>();

                    Mapper.LoadMetaData(obj, keys, columns, allColumns);

                    foreach (var entry in allColumns)
                    {
                        if (dtRow.Table.Columns.IndexOf(entry.Value.Alias()) != -1 &&
                            dtRow[entry.Value.Alias()] != DBNull.Value)
                        {
                            entry.Value.SetValue(dtRow[entry.Value.Alias()]);
                        }
                    }

                    #endregion

                    result.Add(obj);
                }

                #endregion

                return result;
            }

            return null;


        }

        #endregion
    }
}