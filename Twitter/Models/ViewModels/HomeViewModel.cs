using System.Collections.Generic;

namespace Twitter.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Tweet> Tweets { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public Tweet Tweet { get; set; }
    }
}
