namespace domain.Model
{
    public class AuthenticationToken
    {
        public bool IsAuthorized { get; set; }
        public string UserName { get; set; }
        public string MobileNumber { get; set; }

    }
}