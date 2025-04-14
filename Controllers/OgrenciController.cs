using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OgrenciTakip.Models;

namespace OgrenciTakip.Controllers;

public class OgrenciController : Controller
{
    private readonly ILogger<OgrenciController> _logger;

    public OgrenciController(ILogger<OgrenciController> logger)
    {
        _logger = logger;
    }

   public IActionResult Index()
{
    // Hata mesajını başlangıçta null olarak ayarla
    ViewBag.Hata = null;
    return View();
}

[HttpPost]
public IActionResult Gonder(string ad, string soyad, string sinif, string cinsiyet, string[] diller)
{
    // Null veya boş değer kontrolü
    if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(sinif) || string.IsNullOrEmpty(cinsiyet) || diller == null || diller.Length == 0)
    {
        ViewBag.Hata = "Lütfen tüm alanları doldurunuz.";
        return View("Index");
    }

    // Gelen verileri ViewBag ve ViewData ile gönderme
    ViewBag.Ad = ad;
    ViewBag.Soyad = soyad;

    ViewData["Sinif"] = sinif;
    ViewData["Cinsiyet"] = cinsiyet;
    ViewData["Diller"] = diller;

    return View("Sonuc");
}
}