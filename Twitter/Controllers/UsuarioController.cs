using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Twitter.Models.ViewModels;
using Twitter.Models;
using Twitter.Repositorios;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Twitter.Helper;
using Twitter.Filters;

namespace Twitter.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ITweetRepositorio _tweetRepositorio;
        private readonly ISessao _sessao;

        public UsuarioController(IUsuarioRepositorio usuarioRepostorio, ISessao sessao, ITweetRepositorio tweetRepositorio)
        {
            _usuarioRepositorio = usuarioRepostorio;
            _sessao = sessao;
            _tweetRepositorio = tweetRepositorio;
        }

        public IActionResult Index()
        {
            var user = _usuarioRepositorio.BuscarPorId(48);
            _sessao.CriarSessaoUsuario(user);
            return RedirectToAction("Index", "Home");
            //return View();
        }

        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(UsuarioViewModel usuarioViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_usuarioRepositorio.BuscarPorEmail(usuarioViewModel.Usuario.Email) != null)
            {
                TempData["MensagemErro"] = "Este e-mail já está sendo usado.";
                return View();
            }

            usuarioViewModel.Usuario.DataNascimento = new DateTime(usuarioViewModel.Ano, usuarioViewModel.Mes, usuarioViewModel.Dia);
            _usuarioRepositorio.Adicionar(usuarioViewModel.Usuario);
            _sessao.CriarSessaoUsuario(usuarioViewModel.Usuario);
            return RedirectToAction(nameof(Finalizar));


        }

        public IActionResult Finalizar()
        {
            var user = _sessao.BuscarSessaoUsuario();
            var usuario = _usuarioRepositorio.BuscarPorId(user.Id);
            return View(usuario);
        }


        [HttpPost]
        public IActionResult Finalizar(IFormFile imagem, string tag, int usuarioId)
        {
            try
            {
                var user = _usuarioRepositorio.BuscarPorId(usuarioId);
                if (user == null)
                {
                    return NotFound();
                }
                if (imagem != null && imagem.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        imagem.CopyTo(ms);
                        user.ImagemPerfil = ms.ToArray();
                    }
                }
                if (tag != null)
                {
                    if (_usuarioRepositorio.BuscarPorTag(tag) != null)
                    {
                        TempData["MensagemErro"] = "Este nome de usuário já está sendo usado, por favor escolha outro.";
                        return View(user);
                    }
                    if (tag.Length >= 15)
                    {
                        TempData["MensagemErro"] = "Seu nome de usuário deve ter menos de 15 caracteres.";
                        return View(user);
                    }
                    user.Tag = tag;
                }
                _usuarioRepositorio.Atualizar(user);
                _sessao.CriarSessaoUsuario(user);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                var user = _usuarioRepositorio.BuscarPorId(usuarioId);
                return View(usuarioId);
            }
        }

        public IActionResult Entrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(Login login)
        {
            try
            {
                if (login.Tag != null)
                {
                    if (_usuarioRepositorio.BuscarPorTag(login.Tag) != null)
                    {
                        return RedirectToAction(nameof(Senha), new { tag = login.Tag });
                    }
                    TempData["MensagemErro"] = "Desculpe, mas não encontramos sua conta.";
                    return View();
                }
                TempData["MensagemErro"] = "Desculpe, mas não encontramos sua conta.";
                return View();
            }
            catch
            {
                TempData["MensagemErro"] = "Desculpe, mas não encontramos sua conta.";
                return View();
            }
        }

        public IActionResult Senha(string tag)
        {
            Login login = new Login { Tag = tag };
            return View(login);
        }

        [HttpPost]
        public IActionResult Senha(Login login)
        {
            try
            {
                var user = _usuarioRepositorio.BuscarPorTag(login.Tag);
                if (user.SenhaValida(login.Senha))
                {
                    _sessao.CriarSessaoUsuario(user);
                    return RedirectToAction("Index", "Home");
                }
                TempData["MensagemErro"] = "Senha inválida";
                return View(login);
            }
            catch
            {
                return View(login);
            }
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult TrocarDeConta()
        {
            return View();
        }
    }
}

