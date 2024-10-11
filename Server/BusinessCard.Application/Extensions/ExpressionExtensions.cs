using System;
using System.Linq.Expressions;

namespace BusinessCard.Application.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expression1, Expression<Func<T, bool>> expression2)
        {
            var parameter = expression1.Parameters[0];

            var body = Expression.AndAlso(
                expression1.Body,
                Expression.Invoke(expression2, parameter)
            );

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expression1, Expression<Func<T, bool>> expression2)
        {
            var parameter = expression1.Parameters[0];

            var body = Expression.OrElse(
                expression1.Body,
                Expression.Invoke(expression2, parameter)
            );

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}
