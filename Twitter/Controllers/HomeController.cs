using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Twitter.Models;
using Twitter.Models.ViewModels;
using Twitter.Repositorios;

namespace Twitter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITweetRepositorio _tweetRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public HomeController(ILogger<HomeController> logger, ITweetRepositorio tweetRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _logger = logger;
            _tweetRepositorio = tweetRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<Tweet> tweets = _tweetRepositorio.BuscarTodos();
            List<Usuario> usuarios = _usuarioRepositorio.BuscarTodos();
            var viewModel = new HomeViewModel { Tweets = tweets, Usuarios = usuarios };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Tweetar(Tweet tweet)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Index));
                }
                tweet.Usuario = new Usuario { Nome = "José", Tag = "@josemeloph" };
                _tweetRepositorio.Adicionar(tweet);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
