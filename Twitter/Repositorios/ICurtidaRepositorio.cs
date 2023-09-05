using System.Collections.Generic;
using Twitter.Models;

namespace Twitter.Repositorios
{
    public interface ICurtidaRepositorio
    {
        Curtida Adicionar(Curtida curtida);
        Curtida BuscarCurtida(int userId, int tweetId);
        int NumCurtidas(int tweetId);
        bool Remover(int userId, int tweetId);

        List<Curtida> BuscarCurtidasDoUsuario(int userId);
    }
}
