namespace GreenTrack.DTO
{
    public class LoginDTO
    {
        #region Properties
        public string Email { get; set; }
        public string Password { get; set; }
        #endregion
        #region Constructor
        public LoginDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
        #endregion
    }
}
