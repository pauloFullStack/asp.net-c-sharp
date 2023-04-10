using CadastroDeContatos.Models;
using CadastroDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeContatos.Controllers;

public class ContatoController : Controller
{

    private readonly IContatoRepositorio _contatoRepositorio;

    public ContatoController(IContatoRepositorio contatoRepositorio)
    {
        _contatoRepositorio = contatoRepositorio;
    }

    public IActionResult Index()
    {
        List<ContatoModel> contatos = _contatoRepositorio.GetAll();
        return View("~/Views/ListContatos/Index.cshtml", contatos);
    }

    public IActionResult Create()
    {
        return View("~/Views/ListContatos/Create.cshtml");
    }

    public IActionResult Update(int id)
    {
        ContatoModel contato = _contatoRepositorio.GetSingleContact(id);
        return View("~/Views/ListContatos/Update.cshtml", contato);
    }

    public IActionResult DeleteConfirmation(int id)
    {
        ContatoModel contato = _contatoRepositorio.GetSingleContact(id);
        return View("~/Views/ListContatos/DeleteConfirmation.cshtml", contato);
    }

    public IActionResult Delete(int id)
    {
        try
        {
            bool delete = _contatoRepositorio.Delete(id);

            if (delete)
            {
                TempData["MsgSuccess"] = "Contato deletado com sucesso!";
            }
            else
            {
                TempData["MsgSuccess"] = "Erro ao deletar contato, tente novamente";
            }

            return RedirectToAction("Index");

        }
        catch (System.Exception erro)
        {
            TempData["MsgError"] = $"Erro ao deletar contato, tente novamente, detalhes {erro.Message}";
            return RedirectToAction("Index");
        }

    }

    [HttpPost]
    public IActionResult Create(ContatoModel contato)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _contatoRepositorio.Adicionar(contato);
                TempData["MsgSuccess"] = "Contato cadastrado com sucesso!";
                return RedirectToAction("Index");
            }

            return View("~/Views/ListContatos/Create.cshtml", contato);
        }
        catch (System.Exception erro)
        {
            TempData["MsgError"] = $"Erro ao cadastrar contato, tente novamente, detalhes {erro.Message}";
            return RedirectToAction("Index");
        }

    }

    [HttpPost]
    public IActionResult UpdateContact(ContatoModel contato)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _contatoRepositorio.UpdateContact(contato);
                TempData["MsgSuccess"] = "Contato atualizado com sucesso!";
                return RedirectToAction("Index");
            }

            return View("~/Views/ListContatos/Update.cshtml", contato);
        }
        catch (System.Exception erro)
        {
            TempData["MsgError"] = $"Erro ao atualizar contato, tente novamente, detalhes {erro.Message}";
            return RedirectToAction("Index");
        }

    }


}
