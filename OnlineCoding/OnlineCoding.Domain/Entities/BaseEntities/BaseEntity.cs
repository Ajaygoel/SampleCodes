#region usings

using System;

#endregion

namespace OnlineCoding.Domain.BaseEntities
{
    /// <summary>
    ///     base entity to be inherited by all table entities
    /// </summary>
    public class BaseEntity
    {
        #region Public Properties

        public DateTime TimeStamp { get; set; }

        #endregion
    }
}