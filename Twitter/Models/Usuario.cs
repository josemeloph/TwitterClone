using System;
using System.Collections.Generic;

namespace Twitter.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tag { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Senha { get; set; }
        public string Foto { get; set; }
        public List<Tweet> Tweets { get; set; }

    }
}
