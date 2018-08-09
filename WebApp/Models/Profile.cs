using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Profile
    {
      
        public string UserName { get; set; }
       
        public string Password { get; set; }
      
        public string Email { get; set; }
       
        public string Birthdate { get; set; }
        
        public string Gender { get; set; }
      
        public string AccessToken { get; set; }
    }
}

