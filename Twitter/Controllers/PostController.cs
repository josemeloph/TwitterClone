using Microsoft.AspNetCore.Mvc;
using Twitter.Helper;
using Twitter.Repositorios;

namespace Twitter.Controllers
{
    public class PostController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ITweetRepositorio _tweetRepositorio;
        private readonly ICurtidaRepositorio _curtidaRepositorio;
        private readonly ISessao _sessao;

        public PostController(IUsuarioRepositorio usuarioRepostorio, ISessao sessao, ITweetRepositorio tweetRepositorio,
            ICurtidaRepositorio curtidaRepositorio)
        {
            _usuarioRepositorio = usuarioRepostorio;
            _sessao = sessao;
            _tweetRepositorio = tweetRepositorio;
            _curtidaRepositorio = curtidaRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}