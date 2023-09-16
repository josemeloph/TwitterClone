using System.Collections.Generic;

namespace Twitter.Models.ViewModels
{
    public class PostViewModel
    {
        public Usuario UsuarioSessao { get; set; }
        public Usuario UsuarioTweet { get; set; }
        public Tweet Tweet { get; set; }
        public Comentario Comentario { get; set; }
        public List<Comentario> Comentarios { get; set; }
        public List<Curtida> Curtidas { get; set; }
    }
}
