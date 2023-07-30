﻿using System;
using System.Collections.Generic;

namespace Twitter.Models
{
    public class Tweet
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public List<Comentario> Comentarios { get; set; }
        public int QteComentarios { get; set; }
        public DateTime DataTweetado { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public int Curtidas { get; set; }
        public int Retweets { get; set; }
        public string Conteudo { get; set; }


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
                return DataTweetado.ToString("d MMM");
            }
            else
            {
                return DataTweetado.ToString("d MMM yyyy");
            }
        }
    }


}