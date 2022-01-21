using CWCApp.Data.Data;
using CWCApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Application.Services
{
    public class LoginExistService
    {
        UserProfileRepository userProfileRepository = new UserProfileRepository();
        public int loginExist(UserProfile userProfile)
        {
            var objResult = userProfileRepository.GetUserProfileByEmail(userProfile);

            if (objResult == null)
            {
                return 1;
            }
            else if (objResult.Email.ToUpper() == userProfile.Email.ToUpper() && objResult.UserPassword != userProfile.UserPassword)
            {
                return 2;
            }
            else if (objResult.Email.ToUpper() == userProfile.Email.ToUpper() && objResult.UserPassword == userProfile.UserPassword)
            {
                return 3;
            }
            return 1;
        }

    }
}
