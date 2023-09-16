using System;

namespace Twitter.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int TweetId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime Momento { get; set; }
        public int Retweets { get; set; }
        public int Curtidas { get; set; }
        public int Comentarios { get; set; }
        public string Conteudo { get; set; }
        public byte[] Imagem { get; set; }

        public string TempoDecorrido()
        {
            TimeSpan tempoDecorrido = DateTime.Now - Momento;
            double tempoDecorridoSegundos = tempoDecorrido.TotalSeconds;
            if (tempoDecorridoSegundos < 60)
            {
                return ((int)tempoDecorridoSegundos).ToString() + "s";
            }
            else if ((int)tempoDecorridoSegundos < 3600)
            {
                return ((int)tempoDecorridoSegundos / 60).ToString() + "min";
            }
            else if ((int)tempoDecorridoSegundos < 86400)
            {
                return ((int)tempoDecorridoSegundos / 3600).ToString() + "h";
            }
            else if (DateTime.Now.Year == Momento.Year)
            {
                return Momento.Day.ToString() + " de " + Momento.ToString("MMM");
            }
            else
            {
                return Momento.Day.ToString() + " de " + Momento.ToString("MMM") + " de " + Momento.Year.ToString();
            }
        }
    }
}
