using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;

namespace Axis.Infrastructure.Linq
{
    /// <summary>
    /// Classe de manipulação de expressão lambda.
    /// </summary>
    public class LambdaExpressionBase
    {
        /// <summary>
        ///  Delegate de expressão recursiva (tipo delegate genérico)
        ///  detalhes: 
        /// </summary>
        /// <typeparam name="T">tipo da expressão</typeparam>
        /// <param name="self">valor da expressão</param>
        delegate T SelfApplicable<T>(SelfApplicable<T> self);

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
            MemberInfo info = null;

            // Retorna o operador da expressão
            var nextOperand = expression.Body;

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

            return info.Name;
        }

        /// <summary>
        ///  Retorna o valor do objeto
        /// </summary>
        /// <typeparam name="T">type do objeto</typeparam>
        /// <param name="model">objeto</param>
        /// <param name="expression">expression lambda</param>
        /// <returns>object</returns>
        public static object GetValue<T>(T model, Func<T, object> function)
        {
            SelfApplicable<Func<T, object>> myDelegate = x => function;
            Func<T, object> Fix = myDelegate(myDelegate);
            var result = Fix(model);
            return ( result != null ? result : new object());
        }

        public static object GetValue<T>(T model, Expression<Func<T, object>> expression)
        {
            return GetValue(model, expression.Compile());
        }

        /// <summary>
        ///  Seta o valor no objeto
        /// </summary>
        /// <typeparam name="T">type do objeto</typeparam>
        /// <param name="model">objeto</param>
        /// <param name="expression">expression lambda</param>
        /// <returns>objeto</returns>
        public static object SetValue<T>(T model, Func<T, object> expression)
        {
            SelfApplicable<Func<T, object>> myDelegate = x => expression;
            Func<T, object> Fix = myDelegate(myDelegate);
            return Fix(model);
        }
    }
}
