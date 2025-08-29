using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DepartmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        //private readonly UserManager<IdentityUser> _userManager;

        //public UserController(UserManager<IdentityUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        //public async Task<IActionResult> AddUserToRole(string userEmail, string roleName)
        //{
        //    var user = await _userManager.FindByEmailAsync(userEmail);

        //    if (user == null)
        //    {
        //        return NotFound("User not found");
        //    }

        //    var result = await _userManager.AddToRoleAsync(user, roleName);

        //    if (result.Succeeded)
        //    {
        //        return Ok($"User {userEmail} added to role {roleName}");
        //    }

        //    return BadRequest(result.Errors);
        //}

        private readonly DepartmentContext _context;

        public UserController(DepartmentContext context)
        {
            _context = context;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}


//using Microsoft.AspNetCore.Identity;

//async Task CreateRolesAsync(IApplicationBuilder app)
//{
//    using var scope = app.ApplicationServices.CreateScope();
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

//    string[] roleNames = { "Admin", "Manager", "User" };

//    foreach (var roleName in roleNames)
//    {
//        if (!await roleManager.RoleExistsAsync(roleName))
//        {
//            await roleManager.CreateAsync(new IdentityRole(roleName));
//        }
//    }
//}

//await CreateRolesAsync(app);
//Assign role to user
//public class AccountController : Controller
//{
    //private readonly UserManager<IdentityUser> _userManager;

    //public AccountController(UserManager<IdentityUser> userManager)
    //{
    //    _userManager = userManager;
    //}

    //public async Task<IActionResult> AddUserToRole(string userEmail, string roleName)
    //{
    //    var user = await _userManager.FindByEmailAsync(userEmail);

    //    if (user == null)
    //    {
    //        return NotFound("User not found");
    //    }

    //    var result = await _userManager.AddToRoleAsync(user, roleName);

    //    if (result.Succeeded)
    //    {
    //        return Ok($"User {userEmail} added to role {roleName}");
    //    }

    //    return BadRequest(result.Errors);
    //}