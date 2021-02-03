using Microsoft.AspNetCore.Mvc;
using RestAPI.Services;
using Microsoft.AspNetCore.Authorization;
using RestAPI.Models.Data.DTO;

namespace RestAPI.Controllers
{

    /*CLASSE DE LOGIN PARA EFETUAR O ACESSO*/

    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class LoginController : Controller
    {
        private ILoginBusiness _loginBusiness;

        public LoginController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody]UserDTO user)
        {
            if (user == null) return BadRequest();
            return _loginBusiness.FindByLogin(user);
        }

      
    }
}
