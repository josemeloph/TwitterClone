using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Twitter.Models.ViewModels;
using Twitter.Models;
using Twitter.Repositorios;

namespace Twitter.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
