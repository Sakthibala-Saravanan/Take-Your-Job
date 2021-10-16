using System;
using System.Linq.Expressions;

namespace AspireSystems.Service.ModelContracts
{
    public interface ISearchCondition<T>
    {
        /// <summary>
        /// Gets the search condition Predicate
        /// </summary>
        /// <value>The search condition Predicate.</value>
        Expression<Func<T, bool>> Predicate { get; }
    }
}
