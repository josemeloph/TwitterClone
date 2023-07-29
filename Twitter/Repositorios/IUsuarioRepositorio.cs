using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Twitter.Data;
using Twitter.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Twitter.Repositorios
{
    public interface IUsuarioRepositorio
    {
        List<Usuario> BuscarTodos();

        Usuario BuscarPorId(int id);

        Usuario Adicionar(Usuario usuario);

        Usuario Atualizar(Usuario usuario);

        bool Apagar(int id);
    }
}
