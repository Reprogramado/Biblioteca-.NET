using System;
using System.ComponentModel.DataAnnotations;
using Biblioteca.Models;

namespace Biblioteca.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        [Display(Name = "Ano de publicação")]   
        public DateTime DataPublicacao { get; set; }
        public GeneroLivro Tipo{ get; set; }
    }

    public enum GeneroLivro
    {
        Romance,FiccaoCientifica,Terror,Aventura,Suspense
    }
}
