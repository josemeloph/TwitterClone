using System.Collections.Generic;

namespace Twitter.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Tweet> Tweets { get; set; }
        public Tweet Tweet { get; set; }
        public Usuario Usuario { get; set; }
        public List<Curtida> Curtidas { get; set; }
    }
}
