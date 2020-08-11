using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestWebApp.Models;

namespace RestWebApp.Controllers
{
    public class AuthorController : Controller
    {
        private ILogger<AuthorController> _logger;
        private IConfiguration _configuration;
        string apiBaseUrl = "";
        public AuthorController(ILogger<AuthorController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
            apiBaseUrl = _configuration.GetValue<string>("WebApiBaseUrl");
        }
        public async Task<IActionResult> Authors()
        {
            
            List<Author> listauthor = new List<Author>();
            using (var httpClient = new HttpClient())
            {
                //string accessToken = await HttpContext.GetTokenAsync("JWToken");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("JWToken"));

                using (var response = await httpClient.GetAsync(apiBaseUrl+"author"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        listauthor = JsonConvert.DeserializeObject<List<Author>>(apiResponse);
                    }
                    else
                    {

                    }
                }
            }

                return View(listauthor);
        }
           
        
        

    }
}
