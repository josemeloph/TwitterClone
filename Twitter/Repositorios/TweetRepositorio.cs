using System.Collections.Generic;
using System;
using Twitter.Data;
using Twitter.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Twitter.Repositorios
{
    public class TweetRepositorio : ITweetRepositorio
    {
        private TwitterContext _context;

        public TweetRepositorio(TwitterContext context)
        {
            _context = context;
        }

        public List<Tweet> BuscarTodos()
        {
            return _context.Tweets
                .Include(x => x.Usuario)
                .ToList();
        }

        public Tweet BuscarPorId(int id)
        {
            return _context.Tweets.FirstOrDefault(x => x.Id == id);
        }
        public Tweet Adicionar(Tweet tweet)
        {
            tweet.DataTweetado = DateTime.Now;
            _context.Tweets.Add(tweet);
            _context.SaveChanges();
            return tweet;
        }

        public Tweet Atualizar(Tweet tweet)
        {
            Tweet tweetDB = BuscarPorId(tweet.Id);
            if (tweetDB == null) throw new Exception("Houve um erro na atualização!");
            tweetDB.Conteudo = tweet.Conteudo;
            tweetDB.DataAtualizacao = DateTime.Now;
            _context.SaveChanges();

            return tweetDB;
        }

        public void AdicionarCurtida(int id)
        {
            Tweet tweetDB = BuscarPorId(id);
            tweetDB.Curtidas += 1;
            _context.SaveChanges();
        }

        public void RemoverCurtida(int id)
        {
            Tweet tweetDB = BuscarPorId(id);
            tweetDB.Curtidas -= 1;
            _context.SaveChanges();
        }

        public void AdicionarComentario(int id)
        {
            Tweet tweetDB = BuscarPorId(id);
            tweetDB.Comentarios += 1;
            _context.SaveChanges();
        }

        public void RemoverComentario(int id)
        {
            Tweet tweetDB = BuscarPorId(id);
            tweetDB.Comentarios -= 1;
            _context.SaveChanges();
        }


        public bool Apagar(int id)
        {
            Tweet tweetDB = BuscarPorId(id);
            if (tweetDB == null) throw new Exception("Houve um erro na deleção!");
            _context.Tweets.Remove(tweetDB);
            _context.SaveChanges();
            return true;
        }

        public bool ApagarTodos()
        {
            var tweets = BuscarTodos();
            foreach (Tweet tweet in tweets)
            {
                _context.Tweets.Remove(tweet);
            }
            _context.SaveChanges();
            return true;
        }

        public bool ApagarTodosDoUsuario(int userId)
        {
            var tweets = _context.Tweets.Where(s => s.UsuarioId == userId).ToList();
            foreach(var tweet in tweets)
            {
                _context.Tweets.Remove(tweet);
            }
            _context.SaveChanges();
            return true;
        }
    }
}
