using System;
using System.Linq.Expressions;
using AspireSystems.Service.ModelContracts;

namespace AspireSystems.Service.Models
{
    public class SearchCondition<TEntity>:ISearchCondition<TEntity>
        where TEntity : BaseModel
    {
        #region Members

        /// <summary>
        ///  Expression<TDelegate> instance
        /// </summary>
        private readonly Expression<Func<TEntity, bool>> _predicate;

        #endregion Members

        #region Constructor

        /// <summary>
        /// Create search condition instance
        /// </summary>
        /// <param name="predicate"></param>
        public SearchCondition(Expression<Func<TEntity, bool>> predicate)
        {
            _predicate = predicate;
        }

        #endregion Constructor

        /// <summary>
        /// Gets the search condition Predicate
        /// </summary>
        /// <value>The search condition Predicate.</value>
        public Expression<Func<TEntity, bool>> Predicate
        {
            get
            {
                return _predicate ?? (entity => true);
            }
        }
    }
}
