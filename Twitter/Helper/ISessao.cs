using Twitter.Models;

namespace Twitter.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario(Usuario usuario);

        void RemoverSessaoUsuario();

        Usuario BuscarSessaoUsuario();
    }
}
