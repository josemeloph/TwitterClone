using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Twitter.Filters;
using Twitter.Helper;
using Twitter.Models;
using Twitter.Models.ViewModels;
using Twitter.Repositorios;

namespace Twitter.Controllers
{
    [PaginaParaUsuarioLogado]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITweetRepositorio _tweetRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public HomeController(ILogger<HomeController> logger, ITweetRepositorio tweetRepositorio, 
            IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _logger = logger;
            _tweetRepositorio = tweetRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            IEnumerable<Tweet> tweets = _tweetRepositorio.BuscarTodos().OrderByDescending(x => x.DataTweetado);
            var viewModel = new HomeViewModel { Tweets = tweets};
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Tweetar(Tweet tweet)
        {
            try
            {
                var user = _sessao.BuscarSessaoUsuario();
                tweet.UsuarioId = user.Id;
                _tweetRepositorio.Adicionar(tweet);
                return RedirectToAction(nameof(Index));

            }
            catch
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
