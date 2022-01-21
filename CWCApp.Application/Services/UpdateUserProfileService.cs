using CWCApp.Data.Data;
using CWCApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Application.Services
{
    public class UpdateUserProfileService
    {
        UserProfileRepository userProfileRepository = new UserProfileRepository();
        public UserProfile UpdateUserProfile(UserProfile userProfile)
        {
            var objResult = userProfileRepository.GetUserProfileById(userProfile.UserId);
            userProfile.UserPassword = objResult.UserPassword;
            if (userProfile.ProfilePicture == null)
            {
                userProfile.ProfilePicture = objResult.ProfilePicture;
            }

            var objResult2 = userProfileRepository.UpdateUserProfile(userProfile.UserId, userProfile);

            return objResult2;
        }
    }
}
