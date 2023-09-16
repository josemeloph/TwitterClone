using System.Collections.Generic;
using System.Linq;
using Twitter.Data;
using Twitter.Models;

namespace Twitter.Repositorios
{
    public class CurtidaRepositorio : ICurtidaRepositorio
    {
        private readonly TwitterContext _context;

        public CurtidaRepositorio(TwitterContext context)
        {
            _context = context;
        }

        public Curtida Adicionar(Curtida curtida)
        {
            _context.Curtidas.Add(curtida);
            _context.SaveChanges();
            return curtida;
        }

        public bool RemoverCurtidaComentario(int userId, int comentarioId)
        {
            var curtida = BuscarCurtidaComentario(userId, comentarioId);
            if (curtida != null)
            {
                _context.Curtidas.Remove(curtida);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoverCurtidaTweet(int userId, int tweetId)
        {
            var curtida = BuscarCurtidaTweet(userId, tweetId);
            if (curtida != null)
            {
                _context.Curtidas.Remove(curtida);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Curtida BuscarCurtidaTweet(int userId, int tweetId)
        {
            return _context.Curtidas.FirstOrDefault(c => c.UsuarioId == userId && c.TweetId == tweetId);
        }

        public Curtida BuscarCurtidaComentario(int userId, int comentarioId)
        {
            return _context.Curtidas.FirstOrDefault(c => c.UsuarioId == userId && c.ComentarioId == comentarioId);
        }

        public List<Curtida> BuscarCurtidasDoUsuario(int userId)
        {
            return _context.Curtidas.Where(x => x.UsuarioId == userId).ToList();
        }


    }
}
