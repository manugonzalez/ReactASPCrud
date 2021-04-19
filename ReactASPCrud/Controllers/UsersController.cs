using System.Collections.Generic;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ReactASPCrud.Models;
using ReactASPCrud.Repository;
using ReactASPCrud.Services;
using ReactASPCrud.Helpers;

namespace ReactASPCrud.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReactPolicy")]
    public class UsersController : ControllerBase
    {
        //userService handle both user authentication
        //and data access (EF) trough repository pattern
        private readonly IUserService userService;

        public UsersController(IGenericRepository<User> repo, IUserService userService) => this.userService = userService;


        [Authorize]
        [HttpGet]
        public IEnumerable<User> Get() => this.userService.GetAll();

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(this.userService.GetById(id));

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user) => CreatedAtAction("Get", new { id = user.Id }, this.userService.Insert(user));

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            this.userService.Update(id, user);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            this.userService.Delete(this.userService.GetById(id));
            return NoContent();
        }

        public override NoContentResult NoContent() => base.NoContent();

        //New method to auth
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = this.userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

    }
}
