using Microsoft.AspNetCore.Mvc;
using API_Project1.Data;
using Microsoft.EntityFrameworkCore;
using API_Project1.Models;

namespace API_Project1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return RedirectToAction("Profile", "Account");
            // Получение списка всех пользователей для отображения
            var users = await _context.Users.Select(u => u.PasswordHash).ToListAsync();
            return View(users);
        }
    }
}
