using Armada.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Armada.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        [HttpGet()]
        public IActionResult GetUsers()
        {
            var listUser = DataStore.Users;

            //JsonResult resultat = new JsonResult(listUser);
            
            //resultat.StatusCode = 404;

            return Ok(listUser);
        }
        [HttpGet("{IdUser}")]
        public IActionResult GetUser(int idUser)
        {
            var user = DataStore.Users.FirstOrDefault(u => u.UserID == idUser);
            if (user == null)
            {
                return NotFound();
            }

           
            return Ok(user);


        }


    }
}
