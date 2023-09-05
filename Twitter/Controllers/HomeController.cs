using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
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
        private readonly ICurtidaRepositorio _curtidaRepositorio;

        public HomeController(ILogger<HomeController> logger, ITweetRepositorio tweetRepositorio, 
            IUsuarioRepositorio usuarioRepositorio, ISessao sessao, ICurtidaRepositorio curtidaRepositorio)
        {
            _logger = logger;
            _tweetRepositorio = tweetRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _curtidaRepositorio = curtidaRepositorio;
        }

        public IActionResult Index()
        {
            var tweets = _tweetRepositorio.BuscarTodos().OrderByDescending(x => x.DataTweetado);
            var usuario = _sessao.BuscarSessaoUsuario();
            var curtidas = _curtidaRepositorio.BuscarCurtidasDoUsuario(usuario.Id);
            var viewModel = new HomeViewModel { Tweets = tweets, Usuario = usuario, Curtidas = curtidas};
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Tweetar(Tweet tweet, IFormFile imagem)
        {
            try
            {
                var user = _sessao.BuscarSessaoUsuario();
                tweet.UsuarioId = user.Id;
                if (imagem != null && imagem.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        imagem.CopyTo(ms);
                        tweet.Imagem = ms.ToArray();
                    }
                }
                _tweetRepositorio.Adicionar(tweet);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public IActionResult Curtir(int tweetId)
        {
            var user = _sessao.BuscarSessaoUsuario();
            var curtida = _curtidaRepositorio.BuscarCurtida(user.Id, tweetId);

            if (curtida == null)
            {
                _curtidaRepositorio.Adicionar(new Curtida { TweetId = tweetId, UsuarioId = user.Id });
                _tweetRepositorio.AdicionarCurtida(tweetId);
            } 
            else
            {
                _curtidaRepositorio.Remover(user.Id, tweetId);
                _tweetRepositorio.RemoverCurtida(tweetId);
            }
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
