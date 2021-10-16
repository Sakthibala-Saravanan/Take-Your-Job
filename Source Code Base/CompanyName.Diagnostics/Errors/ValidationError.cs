using AspireSystems.Diagnostics.Errors.Base;

namespace AspireSystems.Diagnostics.Errors
{
    public class ValidationError:BaseError
    {
        #region Constructor

        /// <summary>
        /// Initialize a new BaseError instance with category ErrorCategory.Validation
        /// </summary>
        public ValidationError() : base()
        {
            this.Category = Enums.ErrorCategory.Validation;
        }

        #endregion Constructor
    }
}
