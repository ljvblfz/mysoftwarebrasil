using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using PontoEncontro.Infrastructure.Linq;

namespace PontoEncontro.Application.Validate
{
    /// <summary>
    ///  Classe que implemta metodos essenciais a validações
    /// </summary>
    public abstract class Validate<TSouce> where TSouce : class
    {
        /// <summary>
        ///  Indica se o objeto e valido
        ///  TRUE : valido
        ///  FALSE : não é valido
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Objetos de validação
        /// </summary>
        public Dictionary<string, IValidate> Validators = new Dictionary<string, IValidate>();

        /// <summary>
        ///  Messagens de erro
        /// </summary>
        public Dictionary<string, string> ErrorMessages = new Dictionary<string, string>();

        /// <summary>
        /// Entidade a ser validada
        /// </summary>
        private object EntityObj { get; set; }

        /// <summary>
        ///  Adiciona o objeto a ser validado ao objeto
        ///   OBS: a entidade deve ser adicionada primeiro
        /// </summary>
        /// <param name="entity">objeto</param>
        public virtual void Entity(object entity)
        {
            this.EntityObj = entity;
        }

        /// <summary>
        ///  Adiciona o validador ao dicionario
        ///     OBS: o objeto a ser validado ja deve estar adicionado
        /// </summary>
        /// <typeparam name="TValidate">Class validadora</typeparam>
        /// <param name="memberExpression">Expressão com a propriedade validada</param>
        /// <returns>Objeto Validate</returns>
        public virtual Validate<TSouce> Add<TValidate>(Expression<Func<TSouce, object>> memberExpression)
        {
            // Nome da propriedade a ser validada
            var name = LambdaExpressionBase.GetName(memberExpression);

            // Valida e add ao dicionario e validadores
            Validators.Add(name, Validating(typeof(TValidate), name));
            return this;
        }

        /// <summary>
        /// Classe de validação
        ///     Executa dinamicamente o validador especifico
        /// </summary>
        /// <param name="EntityType">tipo da entidade</param>
        /// <param name="propeties">propriedade de validação</param>
        /// <returns>objeto de validação</returns>
        public virtual IValidate Validating(Type EntityType, string propeties)
        {
            IValidate obj = (IValidate)Activator.CreateInstance(EntityType, this.EntityObj);

            if (!obj.IsValid)
            {
                this.IsValid = false;
                this.ErrorMessages.Add(propeties, String.Format(obj.ErrorMessage, propeties));
            }
            return obj;
        }
    }
}
