using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tp02.Models;

namespace Tp02.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Resultado(string NombreCocinero, DateTime Fecha, string TipoComida,int Presupuesto, int CantPersonas)
    {
        Receta receta = new Receta();
        if (receta.CalcularEdad() > 20) return View("Maxpersonas");
        receta.NombreCocinero = NombreCocinero;
        receta.FechaNacimiento = Fecha; 
        receta.Tipo = TipoComida;
        receta.Precio = Presupuesto;
        receta.CantPersonas = CantPersonas;

        ViewBag.Edad = receta.CalcularEdad();
        ViewBag.Nombre = NombreCocinero;
        ViewBag.CantPersonas = CantPersonas;
        receta.DeterminarPlato();
        ViewBag.Plato = receta.NombrePlato;
        receta.CalcularTiempo();
        ViewBag.Tiempo = receta.Tiempo;
        receta.DeterminarDificultad();
        ViewBag.Dificultad = receta.Dificultad;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
