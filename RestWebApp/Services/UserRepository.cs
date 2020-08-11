using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestWebApp.Services
{
    public class UserRepository : IUserInfoRepository
    {
        private ILogger<UserRepository> _logger;
        private IConfiguration _configuration;
        string apiBaseUrl = "";

        public UserRepository(ILogger<UserRepository> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
            apiBaseUrl = _configuration.GetValue<string>("WebApiBaseUrl");
        }

        public UserInfoViewModel GetUserById(int userID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserInfoViewModel> GetuserInfo()
        {
            throw new NotImplementedException();
            //IEnumerable<UserInfoViewModel> listUserInfo = new List<UserInfoViewModel>();
            //using (var httpClient = new HttpClient())
            //{
            //    httpClient.BaseAddress = new Uri(apiBaseUrl);
            //    var response = httpClient.GetAsync("users");
            //    response.Wait();
            //    var result = response.Result;
            //        //string apiResponse = response.Content.ReadAsStringAsync();
            //        //listUserInfo = JsonConvert.DeserializeObject<List<UserInfoViewModel>>(apiResponse);

            //    if (result.IsSuccessStatusCode)
            //    {
            //        var readTask = result.http.ReadAsStreamAsync<IList<UserInfoViewModel>>();
            //    }

            //}
            //return View(listUserInfo);
        }
    }
}
