using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TemperatureWeb.Models;
using Temperature;

namespace TemperatureWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Conversion conversion = new Conversion();
        // ViewBag.InUnit = "The 'from' unit";
        // ViewBag.OutUnit = "the 'to' unit";
        // ViewBag.Temperature = "???";
        // ViewBag.Conversion = "???";
        return View();
    }

    [HttpPost]
    public ActionResult form1(string inUnit = "The 'from' unit",
    string outUnit = "the 'to' unit", double temperature = 0)
    {
        Conversion conversion = new Conversion();
        ViewBag.InUnit = inUnit;
        ViewBag.OutUnit = outUnit;
        ViewBag.Temperature = temperature;
        ViewBag.Conversion = temperature;

        if (inUnit == "Celsius" && outUnit == "Fahrenheit")
        {
            ViewBag.Conversion = conversion.Convert(Conversion.ConversionMode.Celsius_to_Fahrenheit, 100);
        }
        if (inUnit == "Kelvin" && outUnit == "Fahrenheit")
        {
            ViewBag.Conversion = conversion.Convert(Conversion.ConversionMode.Kelvin_to_Fahrenheit, 100);
        }
        if (inUnit == "Fahrenheit" && outUnit == "Celsius")
        {
            ViewBag.Conversion = conversion.Convert(Conversion.ConversionMode.Fahrenheit_to_Celsius, 100);
        }
        if (inUnit == "Celsius" && outUnit == "Kelvin")
        {
            ViewBag.Conversion = conversion.Convert(Conversion.ConversionMode.Celsius_to_Kelvin, 100);
        }
        if (inUnit == "Kelvin" && outUnit == "Celsius")
        {
            ViewBag.Conversion = conversion.Convert(Conversion.ConversionMode.Kelvin_to_Celsius, 100);
        }
        if (inUnit == "Fahrenheit" && outUnit == "Kelvin")
        {
            ViewBag.Conversion = conversion.Convert(Conversion.ConversionMode.Fahrenheit_to_Kelvin, 100);
        }
        return View("Index");
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
