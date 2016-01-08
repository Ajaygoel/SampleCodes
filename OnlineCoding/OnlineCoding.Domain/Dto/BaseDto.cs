#region usings

using System.Collections.Generic;

#endregion

namespace OnlineCoding.Domain.Dto
{
    /// <summary>
    ///     Base dto abstract only to inherit
    /// </summary>
    public class BaseDto
    {
        #region Public Properties

        /// <summary>
        ///     Request is success or not
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        ///     list of errors if request is not successful
        /// </summary>
        public List<Error> Errors { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     json conditional serialization handle
        ///     method with the signature public bool ShouldSerialize*PropertyName*()
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeIsSuccess()
        {
            return true;
        }

        /// <summary>
        ///     json conditional serialization handle
        ///     method with the signature public bool ShouldSerialize*PropertyName*()
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeErrors()
        {
            return !IsSuccess;
        }

        #endregion
    }
}