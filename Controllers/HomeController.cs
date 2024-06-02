using İleri_Veri_tabani.Data;
using İleri_Veri_tabani.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace İleri_Veri_tabani.Controllers
{
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ekle(Player model)
        {
            if (ModelState.IsValid)
            {
               
                try
                {
                    using (var db = new PlayerDbContext()) 
                    {
                        
                        db.Players.Add(model);
                        db.SaveChanges();
                    }

                    
                    ViewBag.Message = "Form başarıyla gönderildi!";
                }
                catch (Exception ex)
                {
                   
                    ViewBag.Message = "Form gönderilirken bir hata oluştu: " + ex.Message;
                }
            }
            else
            {
                ViewBag.Message = "Form geçersiz, lütfen girdileri kontrol edin!";
            }

            return View();
        }

        // Hata yönetimi için bu metot kullanılır
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
