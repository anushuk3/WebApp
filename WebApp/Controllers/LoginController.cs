using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public HttpResponseMessage Signin(FormCollection collection)
        {
            string UserName = collection["username"];
            string Password = collection["password"];
            //string requesturi = "Prod/profile?username=" + UserName + "&password=" + Password;

            HttpClient client = new HttpClient
            {
                // BaseAddress = new Uri("https://hm70oia080.execute-api.ap-south-1.amazonaws.com/")
                //BaseAddress = new Uri("https://ldd8lfkdu6.execute-api.ap-south-1.amazonaws.com/")
                  BaseAddress = new Uri(" https://ejchvxgzeg.execute-api.us-east-1.amazonaws.com/")
               //Prod/Dynamo
            };
            //client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "true");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Access-Control-Allow-Origin", "true");
            //Define request data format  
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Oauth token");
            var response = client.GetAsync("Prod/Dynamo").Result;

            if (response.IsSuccessStatusCode)
            {
                return new HttpResponseMessage(response.StatusCode);
            }
            return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.BadRequest };

        }
        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public HttpResponseMessage Signup(FormCollection collection)
        {
            Profile student = new Profile
            {
                UserName = collection["username"],
                Password = collection["password"],
                Email = collection["username"]
            };
            HttpClient client = new HttpClient
            {
                //BaseAddress = new Uri("https://hm70oia080.execute-api.ap-south-1.amazonaws.com/")
                BaseAddress = new Uri("https://ldd8lfkdu6.execute-api.ap-south-1.amazonaws.com/")
            };
           

            var response = client.PostAsync("Prod/Profile", new StringContent(new JavaScriptSerializer().Serialize(student), Encoding.UTF8, "application/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                return new HttpResponseMessage(response.StatusCode);
            }
            return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.BadRequest };
        }
    }
}
