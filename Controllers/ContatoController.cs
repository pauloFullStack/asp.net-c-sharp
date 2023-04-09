using CadastroDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CadastroDeContatos.Controllers;

public class ContatoController : Controller
{

    public IActionResult Index()
    {
        return View("~/Views/ListContatos/Index.cshtml");
    }

    public IActionResult Create()
    {
        return View("~/Views/ListContatos/Create.cshtml");
    }

    public IActionResult Update()
    {
        return View("~/Views/ListContatos/Update.cshtml");
    }

    public IActionResult DeleteConfirmation()
    {
        return View("~/Views/ListContatos/DeleteConfirmation.cshtml");
    }
}
