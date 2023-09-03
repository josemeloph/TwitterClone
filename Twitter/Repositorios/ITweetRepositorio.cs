using Microsoft.EntityFrameworkCore;
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

        bool Apagar(int id);
        bool ApagarTodos();
        bool ApagarTodosDoUsuario(int userId);
    }
}
