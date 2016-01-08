namespace OnlineCoding.Domain.Dto
{
    public class Error
    {
        #region Public Properties

        public string ErrorMessage { get; set; }

        #endregion

        #region Public Methods

        public bool ShouldSerializeErrorMessage()
        {
            return !string.IsNullOrWhiteSpace(ErrorMessage);
        }

        #endregion
    }
}