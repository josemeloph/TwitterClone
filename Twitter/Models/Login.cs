using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class Login
    {
        public string Tag { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
