using System.Collections.Generic;
using System;
using Twitter.Data;
using Twitter.Models;
using System.Linq;

namespace Twitter.Repositorios
{
    public class UsuarioRepostorio : IUsuarioRepositorio
    {
        private TwitterContext _context;

        public UsuarioRepostorio(TwitterContext context)
        {
            _context = context;
        }

        public List<Usuario> BuscarTodos()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }
        public Usuario Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public Usuario Atualizar(Usuario usuario)
        {
            Usuario usuarioDB = BuscarPorId(usuario.Id);
            if (usuarioDB == null) throw new Exception("Houve um erro na atualização!");
            _context.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            Usuario usuarioDB = BuscarPorId(id);
            if (usuarioDB == null) throw new Exception("Houve um erro na deleção!");
            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges();
            return true;
        }
    }
}
