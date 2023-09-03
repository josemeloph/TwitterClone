using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Models
{
    public class Usuario
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Qual é o seu nome?")]
        [MaxLength(50, ErrorMessage = "Muito longo")]
        public string Nome { get; set; }
        public string Tag { get; set; }

        [Required(ErrorMessage = "Insira um e-mail válido.")]
        [EmailAddress(ErrorMessage = "Insira um e-mail válido.")]
        public string Email { get; set; }
        public string Celular { get; set; }

        [Required(ErrorMessage = "Insira uma senha.")]
        [MinLength(8, ErrorMessage = "Sua senha precisa ter pelo menos 8 caracteres. Insira uma mais longa.")]
        public string Senha { get; set; }
        public List<Tweet> Tweets { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        [Required]
        public string CodigoVerificacao { get; set; }

        public byte[] ImagemPerfil { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }

    }
}
