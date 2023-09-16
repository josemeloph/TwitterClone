using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using Twitter.Helper;
using Twitter.Models;
using Twitter.Models.ViewModels;
using Twitter.Repositorios;

namespace Twitter.Controllers
{
    public class PostController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ITweetRepositorio _tweetRepositorio;
        private readonly ICurtidaRepositorio _curtidaRepositorio;
        private readonly IComentarioRepositorio _comentarioRepositorio;
        private readonly ISessao _sessao;

        public PostController(IUsuarioRepositorio usuarioRepostorio, ISessao sessao, ITweetRepositorio tweetRepositorio,
            ICurtidaRepositorio curtidaRepositorio, IComentarioRepositorio comentarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepostorio;
            _sessao = sessao;
            _tweetRepositorio = tweetRepositorio;
            _curtidaRepositorio = curtidaRepositorio;
            _comentarioRepositorio = comentarioRepositorio;
        }

        public IActionResult Index(int tweetId)
        {
            var tweet = _tweetRepositorio.BuscarPorId(tweetId);
            var usuarioSessao = _sessao.BuscarSessaoUsuario();
            var usuarioTweet = _usuarioRepositorio.BuscarPorId(tweet.UsuarioId);
            var curtidas = _curtidaRepositorio.BuscarCurtidasDoUsuario(usuarioSessao.Id);
            var comentarios = _comentarioRepositorio.BuscarComentariosDoTweet(tweetId);
            var viewModel = new PostViewModel { Tweet = tweet, UsuarioSessao = usuarioSessao, Curtidas = curtidas, UsuarioTweet = usuarioTweet, Comentarios = comentarios};
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Comentar(Comentario comentario, int tweetId, IFormFile imagem)
        {
            try
            {
                var user = _sessao.BuscarSessaoUsuario();
                comentario.UsuarioId = user.Id;
                comentario.TweetId = tweetId;
                if (imagem != null && imagem.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        imagem.CopyTo(ms);
                        comentario.Imagem = ms.ToArray();
                    }
                }
                _tweetRepositorio.AdicionarComentario(tweetId);
                _comentarioRepositorio.Adicionar(comentario);
                return RedirectToAction("Index", new {tweetId = tweetId});

            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public IActionResult CurtirComentario(int comentarioId, int tweetId)
        {
            var user = _sessao.BuscarSessaoUsuario();
            var curtida = _curtidaRepositorio.BuscarCurtidaComentario(user.Id, comentarioId);

            if (curtida == null)
            {
                _curtidaRepositorio.Adicionar(new Curtida { ComentarioId = comentarioId, UsuarioId = user.Id });
                _comentarioRepositorio.AdicionarCurtida(comentarioId);
            }
            else
            {
                _curtidaRepositorio.RemoverCurtidaComentario(user.Id, comentarioId);
                _comentarioRepositorio.RemoverCurtida(comentarioId);
            }
            return RedirectToAction("Index", new { tweetId = tweetId });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}