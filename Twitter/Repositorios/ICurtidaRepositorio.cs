using System.Collections.Generic;
using Twitter.Models;

namespace Twitter.Repositorios
{
    public interface ICurtidaRepositorio
    {
        Curtida Adicionar(Curtida curtida);
        Curtida BuscarCurtidaTweet(int userId, int tweetId);
        Curtida BuscarCurtidaComentario(int userId, int comentarioId);
        bool RemoverCurtidaTweet(int userId, int tweetId);
        bool RemoverCurtidaComentario(int userId, int comentarioId);

        List<Curtida> BuscarCurtidasDoUsuario(int userId);
    }
}
