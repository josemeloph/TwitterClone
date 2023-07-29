using System;

namespace Twitter.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set;}
        public DateTime Momento { get; set; }
        public string Conteudo { get; set; }
        public int Retweets { get; set; }
        public int Curtidas { get; set; }

    }
}
