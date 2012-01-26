using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;

namespace PontoEncontro.Infrastructure.Linq
{
    /// <summary>
    /// Classe de manipulação de expressão lambda.
    /// </summary>
    public class LambdaExpressionBase
    {
        /// <summary>
        /// Nome da propriedade
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  Construtor
        /// </summary>
        public LambdaExpressionBase() { }

        /// <summary>
        ///  Retorna o nome da expressão
        /// </summary>
        /// <typeparam name="TSouce">tipo da expressao</typeparam>
        /// <param name="expression">expressão lambda</param>
        /// <returns>nome da propriedade</returns>
        public static string GetName<TSouce>(Expression<Func<TSouce, object>> expression)
        {
            var lambda = new LambdaExpressionBase();
            lambda.SetPropety(expression.Body);
            return lambda.Name;
        }

        /// <summary>
        ///  Seta o objeto apartir da expressao
        /// </summary>
        /// <param name="member">corpo da expressão</param>
        public void SetPropety(Expression member)
        {
            MemberInfo info = null;

            // Retorna o operador da expressão
            var nextOperand = member;

            // Verifica os tipos da árvore de expressão.
            // ExpressionType.Convert : Uma operação de conversão ou de conversão, como (SampleType)obj 
            if (nextOperand.NodeType == ExpressionType.Convert)
            {
                var unaryExpression = (UnaryExpression)nextOperand;
                info = (unaryExpression.Operand as MemberExpression).Member;
            }
            // ExpressionType.MemberAccess : Uma operação que lê a partir de um campo ou propriedade, como obj.SampleProperty.
            else if (nextOperand.NodeType == ExpressionType.MemberAccess)
            {
                info = (nextOperand as MemberExpression).Member;
            }
            // Se não a expressão não e assesivel
            else
            {
                throw new ArgumentException("Not a member access", "expression");
            }

            this.Name = info.Name;
        }
    }
}
