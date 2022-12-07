﻿using Contracts.Identitydtos;
using Domain.Entities.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly IServiceManager _serviceManager;


        public AccountController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        [HttpPost]
        [Route("Register")]
        public IActionResult Register(User user)
        {
            _serviceManager.AuthUsers.Register(user);

            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginModelDto dto)
        {
           var user =  _serviceManager.AuthUsers.Login(dto);


            return Ok(new { user.Token, user.RefreshToken });
        }

        
    }
}
