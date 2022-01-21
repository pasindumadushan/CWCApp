using CWCApp.Data.Data;
using CWCApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Application.Services
{
    public class UpdatePasswordService
    {
        UserProfileRepository userProfileRepository = new UserProfileRepository();
        public UserProfile updatePassword(UserProfile userProfile)
        {
            var objResult = userProfileRepository.GetUserProfileByEmail(userProfile);
            objResult.UserPassword = userProfile.UserPassword;

            userProfileRepository.UpdateUserProfile(objResult.UserId,objResult);

            return objResult;
        }
    }
}
