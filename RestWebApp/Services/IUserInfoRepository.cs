using RestWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWebApp.Services
{
    public interface IUserInfoRepository
    {
        IEnumerable<UserInfoViewModel> GetuserInfo();
        UserInfoViewModel GetUserById(int userID);
    }
}
