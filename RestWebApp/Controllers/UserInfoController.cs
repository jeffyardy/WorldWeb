using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestWebApp.Models;

namespace RestWebApp.Controllers
{
    public class UserInfoController : Controller
    {
        private ILogger<UserInfoController> _logger;
        private IConfiguration _configuration;
        string apiBaseUrl = "";

        public UserInfoController(ILogger<UserInfoController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
            apiBaseUrl = _configuration.GetValue<string>("WebApiBaseUrl");
        }

        public async Task<IActionResult> Index()
        {
            List<User> listUserInfo = new List<User>();
            using(var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync(apiBaseUrl+"users"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listUserInfo = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                    
                }
            }
            return View(listUserInfo);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User userInfo)
        {
            UserInfoViewModel UserInfo = new UserInfoViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync(apiBaseUrl + "users/login", userInfo))
                {
                    if(response.IsSuccessStatusCode)
                    {
                       string apiResponse = await response.Content.ReadAsStringAsync();
                        UserInfo = JsonConvert.DeserializeObject<UserInfoViewModel>(apiResponse);
                    }
                    else
                    {
                        
                    }
                }
            }
            if(UserInfo._user.Token != null)
            {
                HttpContext.Session.SetString("userId", UserInfo._user.UserId);
                HttpContext.Session.SetString("JWToken", UserInfo._user.Token);
            }
            return RedirectToAction("Authors", "Author");
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("JWToken");

            return RedirectToAction("Login", "UserInfo");
        }
    }
}
