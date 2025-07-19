using AD_CW_1.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Helpers
{
    class AuthSessionHelper
    {
        public static void ActiveSesion(string userId, string Role)
        {
            Settings.Default.UserId = userId;
            Settings.Default.IsLoggedIn = true;
            Settings.Default.Role = Role;
            Settings.Default.Save();
        }

        public static void RemoveSession()
        {
            Settings.Default.UserId = "";
            Settings.Default.IsLoggedIn = false;
            Settings.Default.Role = "";
            Settings.Default.Save();
        }

        public bool IsAdmin()
        {
            return Settings.Default.Role == "admin";
        }

        public static bool IsActive()
        {
            return Settings.Default.IsLoggedIn;
        }

        public static int GetAuthUserId()
        {
            if (int.TryParse(Settings.Default.UserId, out int userId))
            {
                return userId;
            }
            else
            {
                throw new InvalidOperationException("UserId is not a valid integer.");
            }
        }
    }
}
