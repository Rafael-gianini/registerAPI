using Microsoft.AspNetCore.Mvc;
using registerAPI.Services.Token;

namespace registerAPI.Controllers.v1
{
    [ApiController]
    [Route("api/v1/authLogin")]
    public class UserAdmLogin : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "admmottu" &&  password == "admmottu")
            {
                var token = TokenService.GenerationToken(username);
                return Ok(token);
            }
            return BadRequest("username ou password inválidos");
        } 
    }
}
