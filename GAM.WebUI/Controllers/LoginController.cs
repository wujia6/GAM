using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GAM.Application.IServices;
using GAM.WebUI.Models;

namespace GAM.WebUI.Controllers 
{
    public class LoginController : Controller 
    {
        private readonly IUserService iUserService;

        public LoginController(IUserService iService)
        {
            this.iUserService = iService;
        }

        public IActionResult Login(LoginModel model)
        {
            return View();
        }
    }
}