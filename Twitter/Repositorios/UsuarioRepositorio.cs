using System.Collections.Generic;
using System;
using Twitter.Data;
using Twitter.Models;
using System.Linq;

namespace Twitter.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private TwitterContext _context;

        public UsuarioRepositorio(TwitterContext context)
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

        public Usuario BuscarPorEmail(string email)
        {   
            return _context.Usuarios.FirstOrDefault(x =>x.Email == email);
        }

        public Usuario BuscarPorTag(string tag)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Tag == tag);
        }

        public Usuario Adicionar(Usuario usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public Usuario Atualizar(Usuario usuario)
        {
            Usuario usuarioDB = BuscarPorId(usuario.Id);
            if (usuarioDB == null) throw new Exception("Houve um erro na atualização!");
            usuarioDB.DataAtualizacao = DateTime.Now;
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

        public bool ApagarTodos()
        {
            IEnumerable<Usuario> usuarios = BuscarTodos();
            foreach(Usuario usuario in usuarios)
            {
                _context.Usuarios.Remove(usuario);
            }
            _context.SaveChanges();
            return true;
        }
    }
}
