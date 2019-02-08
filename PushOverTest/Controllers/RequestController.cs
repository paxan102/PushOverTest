using System;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PushOverTest.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class RequestController : Controller
    {
        [HttpPost]
        public void Post(string token, string user, string message)
        {
            var parameters = new NameValueCollection {
                { "token", token },
                { "user", user },
                { "message", message }
            };
            
            try
            {
                using (var client = new WebClient())
                {
                    client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
                }
            }
            catch
            {
                BadRequest();
            }
        }
    }
}