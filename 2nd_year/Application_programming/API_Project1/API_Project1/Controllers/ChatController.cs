using Microsoft.AspNetCore.Mvc;
using API_Project1.Data;
using API_Project1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace API_Project1.Controllers
{
    [Route("chat")]
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ChatController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var messages = await _context.Messages
                .Include(m => m.FromUser)  // Включите данные пользователя
                .OrderByDescending(m => m.MessageId)
                .ToListAsync();

            return View(messages);
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage(string messageText)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var message = new Message
            {
                FromUserId = user.UserId, // Используем ID пользователя из UserManager
                FromUser = user,
                Text = messageText
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index"); // Перенаправляем обратно на страницу чата
        }

        [HttpGet("getmessages")]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await _context.Messages
                .Include(m => m.FromUser)
                .OrderByDescending(m => m.MessageId)
                .ToListAsync();

            var result = messages.Select(m => new
            {
                user = string.IsNullOrWhiteSpace(m.FromUser.FirstName) && string.IsNullOrWhiteSpace(m.FromUser.LastName)
                       ? m.FromUser.Id.ToString()
                       : $"{m.FromUser.FirstName} {m.FromUser.LastName}",
                text = m.Text
            });

            return Json(result);
        }
    }
}
