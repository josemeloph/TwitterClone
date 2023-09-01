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

namespace Twitter.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepostorio)
        {
            _usuarioRepositorio = usuarioRepostorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(UsuarioViewModel usuarioViewModel)
        {
            try
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
                return RedirectToAction(nameof(Finalizar), new { usuarioId = usuarioViewModel.Usuario.Id});
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Finalizar(int usuarioId)
        {
            var usuario = _usuarioRepositorio.BuscarPorId(usuarioId);
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
                if(tag != null)
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
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                var user = _usuarioRepositorio.BuscarPorId(usuarioId);
                return View(usuarioId);
            }


        }
    }
}
