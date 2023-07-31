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

        public bool Apagar(int id)
        {
            Tweet tweetDB = BuscarPorId(id);
            if (tweetDB == null) throw new Exception("Houve um erro na deleção!");
            _context.Tweets.Remove(tweetDB);
            _context.SaveChanges();
            return true;
        }
    }
}
