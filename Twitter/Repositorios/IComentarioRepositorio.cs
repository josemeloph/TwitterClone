using System.Collections.Generic;
using Twitter.Models;

namespace Twitter.Repositorios
{
    public interface IComentarioRepositorio
    {
        Comentario Adicionar(Comentario comentario);
        bool Remover(int comentarioId);
        void AdicionarCurtida(int id);
        void RemoverCurtida(int id);

        Comentario BuscarComentario(int comentarioId);
        List<Comentario> BuscarComentariosDoTweet(int tweetId);
        List<Comentario> BuscarComentariosDoUsuario(int userId);
    }
}
