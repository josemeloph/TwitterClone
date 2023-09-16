using System;
using System.Collections.Generic;
using System.Globalization;

namespace Twitter.Models
{
    public class Tweet
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataTweetado { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public int Curtidas { get; set; }
        public int Comentarios { get; set; }
        public int Salvos { get; set; }
        public int Retweets { get; set; }
        public string Conteudo { get; set; }
        public byte[] Imagem { get; set; }


        public string HoraTweet()
        {
            CultureInfo cultureInfo = new CultureInfo("en-US");
            return DataTweetado.ToString("h:mm tt", cultureInfo);
        }
        public string DataTweet()
        {
            return DataTweetado.Day.ToString() + " de " + DataTweetado.ToString("MMM") + " de " + DataTweetado.Year.ToString();
        }

        public string TempoDecorrido()
        {
            TimeSpan tempoDecorrido = DateTime.Now - DataTweetado;
            double tempoDecorridoSegundos = tempoDecorrido.TotalSeconds;
            if(tempoDecorridoSegundos < 60)
            {
                return ((int)tempoDecorridoSegundos).ToString() + "s";
            }
            else if((int)tempoDecorridoSegundos < 3600)
            {
                return ((int)tempoDecorridoSegundos / 60).ToString() + "min";
            }
            else if((int)tempoDecorridoSegundos < 86400)
            {
                return ((int)tempoDecorridoSegundos / 3600).ToString() + "h";
            }
            else if(DateTime.Now.Year == DataTweetado.Year)
            {
                return DataTweetado.Day.ToString() + " de " + DataTweetado.ToString("MMM");
            }
            else
            {
                return DataTweetado.Day.ToString() + " de " + DataTweetado.ToString("MMM") + " de " + DataTweetado.Year.ToString();
            }
        }
    }


}
