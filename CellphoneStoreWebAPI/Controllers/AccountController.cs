using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CellphoneStoreWebAPI.Models.AccountModel;
using Microsoft.AspNetCore.Authorization;
using CellphoneStoreWebAPI.Models;

namespace CellphoneStoreWebAPI.Areas.Admin.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }

        public AccountController( UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        // GET: api/Account 
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CheckAdmin()
        {
            return Ok();
        }

        // POST: api/Account/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AccountRegister model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
            }

            var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
            var result = await UserManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var result1 = await UserManager.AddToRoleAsync(user, "User");

            } else {
                return BadRequest(result.Errors.Select(x => x.Description).ToList());
            } 

            await SignInManager.SignInAsync(user, false);

            return Ok();
        }
        // POST: api/Account/Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AccountLogin model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await SignInManager.PasswordSignInAsync(model.Username, model.Password, model.saveLogin, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Account/LogOut
        [HttpPost("logout")]

        public async Task<IActionResult> LogOut()
        {
            await SignInManager.SignOutAsync();
            return Ok();
        }

    }
}