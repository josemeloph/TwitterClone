using System;
using System.Collections.Generic;
using System.Linq;
using Twitter.Data;
using Twitter.Models;

namespace Twitter.Repositorios
{
    public class ComentarioRepositorio : IComentarioRepositorio
    {
        private readonly TwitterContext _context;

        public ComentarioRepositorio(TwitterContext context)
        {
            _context = context;
        }

        public Comentario Adicionar(Comentario comentario)
        {
            comentario.Momento = DateTime.Now;
            _context.Comentarios.Add(comentario);
            _context.SaveChanges();
            return comentario;
        }

        public bool Remover(int comentarioId)
        {
            var comentario = BuscarComentario(comentarioId);
            if (comentario != null)
            {
                _context.Comentarios.Remove(comentario);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Comentario BuscarComentario(int comentarioId)
        {
            return _context.Comentarios.FirstOrDefault(c => c.Id == comentarioId);
        }

        public List<Comentario> BuscarComentariosDoTweet(int tweetId)
        {
            return _context.Comentarios.Where(x => x.TweetId == tweetId).ToList();
        }

        public List<Comentario> BuscarComentariosDoUsuario(int userId)
        {
            return _context.Comentarios.Where(x => x.UsuarioId == userId).ToList();
        }

        public void AdicionarCurtida(int id)
        {
            Comentario comentario = BuscarComentario(id);
            comentario.Curtidas += 1;
            _context.Update(comentario);
            _context.SaveChanges();
        }

        public void RemoverCurtida(int id)
        {
            Comentario comentario = BuscarComentario(id);
            comentario.Curtidas -= 1;
            _context.Update(comentario);
            _context.SaveChanges();
        }

      
    }
}
