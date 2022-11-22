using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public StatusResponse CheckToken()
        {
            var Token = HttpContext.Session.GetString("SaveToken");
            if (Token == null)
            {
                return new StatusResponse
                {
                    StatusCode = 401,
                    Messages = "You aren't login!",
                    Token = null
                };
            }
            return new StatusResponse
            {
                StatusCode = 200,
                Messages = "Show data successuly!",
                Token = Token
            };
        }
    }
}
