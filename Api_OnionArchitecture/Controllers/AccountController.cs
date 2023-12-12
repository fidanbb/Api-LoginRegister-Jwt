using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Account;
using Service.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_OnionArchitecture.Controllers
{
    public class AccountController : BaseController
    {

        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]

        public async Task<IActionResult> CreateRoles()
        {
            await _accountService.CreateRoleAsync();
            return Ok();
        }

        [HttpGet]

        public IActionResult GetAllRoles()
        {
            var data = _accountService.GetAllRoles();
            return Ok(data);
        }

        [HttpPost]

        public async Task<IActionResult> SignUp([FromBody] RegisterDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _accountService.SignUpAsync(request));
        }


        [HttpGet]

        public IActionResult GetAllUsers()
        {
            return Ok(_accountService.GetAllUsers());
        }



        [HttpPost]

        public async Task<IActionResult> SignIn([FromBody] LoginDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _accountService.SignInAsync(request));
        }


        [HttpPost]

        public async Task<IActionResult> AddRoleToUser([FromBody]UserRoleDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _accountService.AddRoleToUSerAsync(request);

            return Ok();
        }
    }
}

