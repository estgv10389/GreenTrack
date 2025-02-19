using GreenTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTrack.Services
{
    public class SessionService
    {
        #region Properties
        public User? LoggedInUser { get; private set; }
        public string? Token { get; set; }
        #endregion

        #region
        public void StartSession(User user, string token)
        {
            LoggedInUser = user;
            Token = token;
        }

        public void EndSession()
        {
            LoggedInUser = null;
            Token = null;
        }

        public bool IsLoggedIn()
        {
            return LoggedInUser != null && Token != null;
        }

        #endregion
    }
}
