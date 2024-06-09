using İleri_Veri_tabani.Data;
using İleri_Veri_tabani.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
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
           
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=İleriVeriTabani;Trusted_Connection=True;";

            List<Player> Players = new List<Player>();

            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT TOP(100) * FROM Players"; 
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Player player = new Player
                            {
                                PlayerID = dr.GetInt32(dr.GetOrdinal("PlayerID")),
                                PlayerName = dr.GetString(dr.GetOrdinal("PlayerName")),
                                PlayerAge = dr.GetInt32(dr.GetOrdinal("PlayerAge")),
                                PlayerPosition = dr.GetString(dr.GetOrdinal("PlayerPosition")),
                                PlayerSquad = dr.GetString(dr.GetOrdinal("PlayerSquad")),
                                PlayerMinutesPlayed = dr.GetInt32(dr.GetOrdinal("PlayerMinutesPlayed")),
                                PlayerTouches = dr.GetFloat(dr.GetOrdinal("PlayerTouches")),
                                PlayerTackles = dr.GetFloat(dr.GetOrdinal("PlayerTackles"))
                            };
                            Players.Add(player);
                        }
                    }
                }
            }
            return View(Players);
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
