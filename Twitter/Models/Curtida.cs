namespace Twitter.Models
{
    public class Curtida
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int TweetId { get; set; }
        public int ComentarioId { get; set; }
    }
}
