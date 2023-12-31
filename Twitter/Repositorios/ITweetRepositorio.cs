﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Twitter.Data;
using Twitter.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Twitter.Repositorios
{
    public interface ITweetRepositorio
    {
        List<Tweet> BuscarTodos();

        Tweet BuscarPorId(int id);

        Tweet Adicionar(Tweet tweet);

        Tweet Atualizar(Tweet tweet);
        void AdicionarCurtida(int id);
        void RemoverCurtida(int id);
        void AdicionarComentario(int id);
        void RemoverComentario(int id);
        bool Apagar(int id);
        bool ApagarTodos();
        bool ApagarTodosDoUsuario(int userId);
    }
}
