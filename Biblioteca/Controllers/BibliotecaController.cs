using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class LivroController : Controller
    {

        //Lista para gravar os Livros
        private static IList<Livro> _lista = new List<Livro>();
        private static int _id = 0;

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _lista.Remove(_lista.First(v => v.Id == id));
            
            TempData["msg"] = "Livro removido!";
            //Redirect para a Index
            return RedirectToAction("Index");
        }

        public IActionResult Index(string searchTerm)
        {
                List<Livro> livros;

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    // Realize a pesquisa filtrando por título (ou outra propriedade do modelo)
                    livros = _lista.Where(l => l.Titulo.Contains(searchTerm)).ToList();
                }
                else
                {
                    // Caso não haja termo de pesquisa, exiba todos os livros
                    livros = _lista.Cast<Livro>().ToList();
                }

                return View(livros);    
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            
            var livro = _lista.First(v => v.Id == id);
            
            return View(livro);
        }

        [HttpPost]
        public IActionResult Editar(Livro livro)
        {
            //Atualizar o veiculo na lista
            //Pesquisar a posição do veiculo na lista
            var index = _lista.ToList().FindIndex(v => v.Id == livro.Id);
            //Atualiza o veiculo na lista, adicionando o novo veiculo na posição do veiculo antigo
            _lista[index] = livro;
            //Enviar uma mensagem para view
            TempData["msg"] = "Livro Atualizado!";
            //Redirect para a listagem (index)
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            livro.Id = ++_id;
            //Cadastrar na lista
            _lista.Add(livro);
            //Mostrar uma mensagem de sucesso
            TempData["mensagem"] = "Livro cadastrado!";
            return RedirectToAction("Cadastrar"); //Nome do método
        }
    }
}
