using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using System.Linq.Expressions;
using System.ComponentModel;
using NHibernate.Criterion;
using System.Collections;
using NHibernate.Metadata;
using Axis.Infrastructure.Filter;
using Axis.Infrastructure.Order;
using Axis.Infrastructure.Enum;

namespace Axis.Domain
{
    /// <summary>
    /// Oferece acesso e manipulação dos dados existentes na entidade com NHibernate.
    /// </summary>
    /// <typeparam name="TContext">Tipo da entidade de contexto.</typeparam>
    /// <typeparam name="TSource">Tipo da entidade a ser manipulada.</typeparam>
    public class GenericRepository<TSource>  where TSource : class
    {

        #region Public Properties

        /// <summary>
        ///  Objeto de fabrica de sessões
        /// </summary>
        public ISessionFactory SessionFactory { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa o objeto de acesso a dados especificando o contexto de acesso a dados.
        /// </summary>
        /// <param name="connectionString">Representa o contexto do serviço de acesso a dados do ADO.Net</param>
        public GenericRepository()
        {
            this.SessionFactory = SessionFactoryHelper.GetSessionFactory();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Retorna uma lista de TSource a partir dos Id's especificados.
        /// </summary>
        /// <param name="ids">Valores referentes aos Id's das entidades.</param>
        /// <returns>Lista de TSource</returns>
        public virtual IList<TSource> GetById(params object[] ids)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        IList<TSource> results = new List<TSource>();

                        foreach (var item in ids)
                        {
                            TSource objAux = session.Get<TSource>(item);
                            results.Add(objAux);
                        }
                        session.Flush();
                        session.Close();
                        return results;
                    }
                    catch (NHibernate.HibernateException ex)
                    {
                        transaction.Rollback();
                        if (ex.InnerException != null)
                            throw new Exception(ex.InnerException.Message, ex);
                        throw new Exception(ex.Message, ex);
                    }
                }
            }
        }

        /// <summary>
        /// Retorna um objeto da entidade manipulada conforme o valor do ID.
        /// </summary>
        /// <param name="ids">Valor referente ao ID da entidade.</param>
        /// <returns>Entidade encontrada. Caso contrário retorna null.</returns>
        public virtual TSource GetById(int id)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        TSource result = session.Get<TSource>(id);
                        session.Flush();
                        session.Close();
                        return result;
                    }
                    catch (NHibernate.HibernateException ex)
                    {
                        transaction.Rollback();
                        if (ex.InnerException != null)
                            throw new Exception(ex.InnerException.Message, ex);
                        throw new Exception(ex.Message, ex);
                    }
                }
            }
        }

        /// <summary>
        /// Retorna os objetos da entidade manipulada de acordo a condição informada.
        /// </summary>
        /// <param name="Filter">Filtros da pesquisa</param>
        /// <returns>Retorna uma lista dos objetos</returns>
        public IList<TSource> GetWhere(FilterBy[] Filter)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        ICriteria criteria = session.CreateCriteria<TSource>();
                        this.AddFilterBy(criteria, Filter);
                        IList<TSource> result = criteria.List<TSource>();
                        session.Flush();
                        session.Close();
                        return result;
                    }
                    catch (NHibernate.HibernateException ex)
                    {
                        transaction.Rollback();
                        if (ex.InnerException != null)
                            throw new Exception(ex.InnerException.Message, ex);
                        throw new Exception(ex.Message, ex);
                    }
                }
            }
        }


        /// <summary>
        ///  Obtem um lista de dados apartir de uma entidade e os seu filtros
        /// </summary>
        /// <param name="entityName">nome da entidade (POCO)</param>
        /// <param name="filter">Filtros</param>
        /// <returns>lista de objetos</returns>
        public virtual IList GetWhere(string entityName, params FilterBy[] filter)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        var criteria = session.CreateCriteria(entityName);
                        this.AddFilterBy(criteria, filter);
                        var result = criteria.List();
                        session.Flush();
                        session.Close();
                        return result;
                    }
                    catch (NHibernate.HibernateException ex)
                    {
                        if (ex.InnerException != null)
                            throw new Exception(ex.InnerException.Message, ex);
                        throw new Exception(ex.Message, ex);
                    }
                }
            }
        }

        /// <summary>
        /// Retorna todos objetos da entidade manipulada.
        /// </summary>
        /// <param name="currentPage">Número da pagina corrente</param>
        /// <param name="pageSize">Tamanho da pagina</param>
        /// <param name="ordeBy">Ordenação</param>
        /// <param name="Filter">Filtros da pesquisa</param>
        /// <param name="total">Total de registros retornados</param>
        /// <returns>Retorna uma lista de TSource.</returns>
        public virtual IList<TSource> List(int currentPage, int pageSize, OrderBy[] orderBy, FilterBy[] Filter, out int total)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        ICriteria criteria = session.CreateCriteria<TSource>();
                        this.AddFilterBy(criteria, Filter);
                        this.AddOrderBy(criteria, orderBy);

                        criteria.SetFirstResult(currentPage * pageSize);
                        criteria.SetMaxResults(pageSize);

                        IList<TSource> result = criteria.List<TSource>();

                        session.Close();
                        total = this.Count();
                        return result;
                    }
                    catch (NHibernate.HibernateException ex)
                    {
                        transaction.Rollback();
                        if (ex.InnerException != null)
                            throw new Exception(ex.InnerException.Message, ex);
                        throw new Exception(ex.Message, ex);
                    }
                }
            }
        }

        /// <summary>
        /// Retorna todos objetos da entidade manipulada.
        /// </summary>
        /// <returns>Retorna uma lista de TSource.</returns>
        public virtual IList<TSource> ListAll()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        IList<TSource> result = (from t in session.Query<TSource>()
                                                 select t).ToList<TSource>();
                        session.Flush();
                        session.Close();
                        return result;
                    }
                    catch (NHibernate.HibernateException ex)
                    {
                        transaction.Rollback();
                        if (ex.InnerException != null)
                            throw new Exception(ex.InnerException.Message, ex);
                        throw new Exception(ex.Message, ex);
                    }
                }
            }
        }

        /// <summary>
        ///  Retorna uma lista comtendo valor e texto 
        ///     ex : para carregamento de um DropDown na View
        /// </summary>
        /// <param name="text">campo texto da entidade</param>
        /// <param name="value">campo valor da entidade</param>
        /// <returns>lista contendo objeto texto->valor </returns>
        public virtual IList ListDropDown(string text, string value)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        IList result = (from t in session.Query<TSource>()
                                        select new
                                        {
                                            Text = (t.GetType().GetProperty(text).GetValue(t, null)),
                                            Value = (t.GetType().GetProperty(value).GetValue(t, null))
                                        }
                                        ).ToList();
                        session.Flush();
                        session.Close();
                        return result;
                    }
                    catch (NHibernate.HibernateException ex)
                    {
                        transaction.Rollback();
                        if (ex.InnerException != null)
                            throw new Exception(ex.InnerException.Message, ex);
                        throw new Exception(ex.Message, ex);
                    }
                }
            }
        }

        /// <summary>
        ///  Retorna a quantidade de registros na tabela
        /// </summary>
        /// <returns>quantidades de linhas</returns>
        public virtual int Count()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        var result = (
                                        from t in session.Query<TSource>()
                                        select t
                                    ).Count();

                        session.Flush();
                        session.Close();
                        return result;
                    }
                    catch (NHibernate.HibernateException ex)
                    {
                        transaction.Rollback();
                        if (ex.InnerException != null)
                            throw new Exception(ex.InnerException.Message, ex);
                        throw new Exception(ex.Message, ex);
                    }
                }
            }
        }

        /// <summary>
        /// Salva um objeto no banco de dados
        /// </summary>
        /// <param name="entity">Entida a ser persistida</param>
        public virtual void Save(TSource entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entity);
                        transaction.Commit();
                        session.Flush();
                        session.Close();
                    }
                    catch (NHibernate.HibernateException ex)
                    {
                        transaction.Rollback();
                        if (ex.InnerException != null)
                            throw new Exception(ex.InnerException.Message, ex);
                        throw new Exception(ex.Message, ex);
                    }
                }
            }
        }

        /// <summary>
        /// Salva uma lista de objetos no banco de dados.
        /// </summary>
        /// <param name="entity">Lista de entidades a serem persistidas</param>
        public virtual void Save(IList<TSource> listEntity)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach (var entity in listEntity)
                        {
                            session.Save(entity);
                        }

                        transaction.Commit();
                        session.Flush();
                        session.Close();
                    }
                    catch (NHibernate.HibernateException ex)
                    {
                        transaction.Rollback();
                        if (ex.InnerException != null)
                            throw new Exception(ex.InnerException.Message, ex);
                        throw new Exception(ex.Message, ex);
                    }
                }
            }
        }

        /// <summary>
        /// Exclui a entidade indicada.
        /// </summary>
        /// <param name="id">Id da entidade</param>
        public virtual void Delete(int id)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        TSource result = session.Get<TSource>(id);
                        session.Delete(result);
                        transaction.Commit();
                        session.Flush();
                        session.Close();
                    }
                    catch (NHibernate.HibernateException ex)
                    {
                        transaction.Rollback();
                        if (ex.InnerException != null)
                            throw new Exception(ex.InnerException.Message, ex);
                        throw new Exception(ex.Message, ex);
                    }
                }
            }
        }

        /// <summary>
        /// Exclui a entidade indicada.
        /// </summary>
        /// <param name="entity">Entidade a ser deletada.</param>
        /// <returns>Retorna true se a entidade for excluido. Caso contrário retorna false.</returns>
        public virtual bool Delete(TSource entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entity);
                        transaction.Commit();
                        session.Flush();
                        session.Close();
                        return true;
                    }
                    catch (NHibernate.HibernateException ex)
                    {
                        transaction.Rollback();
                        if (ex.InnerException != null)
                            throw new Exception(ex.InnerException.Message, ex);
                        throw new Exception(ex.Message, ex);
                    }
                }
            }
        }

        /// <summary>
        /// Retorna todas as entidades referenciadas no mapeamento.
        ///     (Utilizada para varificação de restrição de integridade)
        /// </summary>
        /// <param name="entity">Entidade a ser deletada.</param>
        /// <returns>Retorna lista com os mepeamentos vinculados a entidade.</returns>
        public virtual IClassMetadata[] GetReference(TSource entity)
        {
            try
            {
                return (
                            from m in SessionFactory.GetAllClassMetadata().Values.ToList()
                            where
                                (
                                    from p in m.PropertyTypes
                                    where (p.ReturnedClass.Name.Contains(typeof(TSource).Name))
                                    select m
                                ).Count() > 0
                            select m
                          ).ToArray();
            }
            catch (NHibernate.HibernateException ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        ///  Verifica restrição de integridade da entidade
        /// </summary>
        /// <param name="entity">Entidade</param>
        /// <returns>true indica que existe vinculo da entidade.</returns>
        public virtual bool CheckedIntegity(TSource entity)
        {
            // Chave da entidade
            var key = this.GetKey(typeof(TSource));

            // Retorna um mapa dos objetos de referencia
            var mapCollection = this.GetReference(entity);

            // Verifica se existe referencia da entidade nos objetos mapeados
            foreach (var item in mapCollection)
            {
                var result = this.GetWhere(item.EntityName,
                                            new FilterBy
                                            {
                                                Member = key,
                                                Operator = LogicalOperator.IsEqualTo.ToString(),
                                                Value = entity.GetType().GetProperty(key).GetValue(entity, null)
                                            }
                                            );
                if (result != null && result.Count > 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        ///  Retorna a chave o campo chave do objeto informado
        /// </summary>
        /// <param name="string">Nome da entidade</param>
        public virtual string GetKey(Type entityType)
        {
            try
            {
                var key = from m in SessionFactory.GetAllClassMetadata().Values.ToList()
                          where m.EntityName == entityType.FullName
                          select m.IdentifierPropertyName;

                return key != null ? key.First() : String.Empty;
            }
            catch (NHibernate.HibernateException ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Atualiza a entidade indicada.
        /// </summary>
        /// <param name="entity">Entidade a ser atualizada.</param>
        public virtual void Update(TSource entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entity);
                        transaction.Commit();
                        session.Flush();
                        session.Close();
                    }
                    catch (NHibernate.HibernateException ex)
                    {
                        transaction.Rollback();
                        if (ex.InnerException != null)
                            throw new Exception(ex.InnerException.Message, ex);
                        throw new Exception(ex.Message, ex);
                    }
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///  Adiciona os filtros de pesquisa
        /// </summary>
        /// <param name="criteria">Objeto de consulta orientada por critérios API</param>
        /// <param name="Filter">Objeto de filtros de pesquisa</param>
        /// <returns>ICriteria</returns>
        private ICriteria AddFilterBy(ICriteria criteria, FilterBy[] Filter)
        {
            if (Filter != null && Filter.Length > 0)
            {
                foreach (var item in Filter)
                {
                    if (item.Operator == LogicalOperator.IsEqualTo.ToString())
                        criteria.Add(Restrictions.Eq(item.Member, item.Value));

                    else if (item.Operator == LogicalOperator.Contains.ToString())
                        criteria.Add(new LikeExpression(item.Member, "%" + item.Value.ToString() + "%"));

                    else if (item.Operator == LogicalOperator.IsGreaterThan.ToString())
                        criteria.Add(Restrictions.Gt(item.Member, item.Value));

                    else if (item.Operator == LogicalOperator.IsGreaterThanOrEqualTo.ToString())
                        criteria.Add(Restrictions.Ge(item.Member, item.Value));

                    else if (item.Operator == LogicalOperator.IsLessThan.ToString())
                        criteria.Add(Restrictions.Lt(item.Member, item.Value));

                    else if (item.Operator == LogicalOperator.IsLessThanOrEqualTo.ToString())
                        criteria.Add(Restrictions.Le(item.Member, item.Value));

                    else if (item.Operator == LogicalOperator.IsNotEqualTo.ToString())
                        criteria.Add(Restrictions.NotEqProperty(item.Member, item.Value.ToString()));

                    else if (item.Operator == LogicalOperator.EndsWith.ToString())
                        criteria.Add(new LikeExpression(item.Member, "%" + item.Value.ToString()));

                    else if (item.Operator == LogicalOperator.StartsWith.ToString())
                        criteria.Add(new LikeExpression(item.Member, item.Value.ToString() + "%"));
                }
            }
            return criteria;
        }


        /// <summary>
        ///  Adiciona as ordenações de pesquisa
        /// </summary>
        /// <param name="criteria">Objeto de consulta orientada por critérios API</param>
        /// <param name="Orders">Objeto de ordenação</param>
        /// <returns>ICriteria</returns>
        private ICriteria AddOrderBy(ICriteria criteria, OrderBy[] orderBy)
        {
            // Adiciona a ordenação da pesquisa
            if (orderBy != null && orderBy.Length > 0)
            {
                foreach (var item in orderBy)
                {
                    NHibernate.Criterion.Order order = new NHibernate.Criterion
                                                                     .Order(
                                                                            item.Member,
                                                                            (item.SortDirection == ListSortDirection.Ascending ? true : false)
                                                                           );
                    criteria.AddOrder(order);
                }
            }
            return criteria;
        }

        #endregion

    }
}
