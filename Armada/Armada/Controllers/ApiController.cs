using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Armada.Database;
using Armada.Models;
using Microsoft.AspNetCore.Mvc;

namespace Armada.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        public string getResult(int x)
        {
            return $"je vaut {x}";
        }

        [HttpGet]
        public string logIn(string mail, string pwd)
        {
            ArmadaContext context = new ArmadaContext();
            //var usermails = context.Users.Where(u => u.Mail.ToLower() == mail.ToLower());
            //var usermails = context.Users.Where(u => string.Compare(u.Mail, mail, true) == 0);
            //var usermails = context.Users.Where<User>(u => string.Compare(u.Mail, mail, true) == 0);
            //var tempMail = mail.ToPascalCase();
            //var usermails = context.Users.Where(compareMail);
            var userMails = from u in context.Users where u.Mail.ToLower() == mail.ToLower() && u.Password == pwd orderby u.Name select new { u.Password, u.Mail };
            //Console.WriteLine(userMails3.GetEnumerator().Current.Password);
            //var userMails = from u in context.Users where u.Mail == mail orderby u.Name select u;
            //var userMails2 = context.Users.Where(u => u.Mail == mail).OrderBy(u => u.Name).Select(u => u);

            // TODO : génère TOKEN
            Debug.Assert(userMails.Count() < 2, "Trop de users");
            return userMails.Count() > 1 || userMails.Count() == 0 ? "bad" : "good";
        }



        //private string tempMail = "";
        //private bool compareMail(User user)
        //{
        //    return string.Compare(user.Mail, tempMail, true) == 0;
        //}

        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
