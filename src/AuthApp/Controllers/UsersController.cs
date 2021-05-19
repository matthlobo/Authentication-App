using AuthApp.Service;
using AuthApp.Service.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        [Authorize]
        [HttpGet("{userId}")]
        public ActionResult GetById(Guid userId)
        {
            return Ok(service.GetById(userId));
        }

        [Authorize]
        [Route("search")]
        [HttpGet("{username}")]
        public ActionResult GetByUser(UserRequest request)
        {
            return Ok(service.GetByUser(request));
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserRequest request)
        {
            var userId = request.Id;
            var user = service.GetById(userId);

            if (user is null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpPost]
        [Route("register")]
        public ActionResult Add([FromBody] UserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(service.Add(request));
        }

        // POST: UsersController/Create
        [HttpPut("{userId}")]
        public ActionResult Edit([FromRoute] Guid userId, [FromBody] UserRequest request)
        {
            request.Id = userId;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(service.Edit(request));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{userId}")]
        public IActionResult Delete([FromRoute] Guid userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Delete(userId);
            return Ok();
        }
    }
}
