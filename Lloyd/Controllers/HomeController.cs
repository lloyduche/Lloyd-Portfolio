using Lloyd.Data.Mail;
using Lloyd.Data.Models;
using Lloyd.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lloyd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMailService _mailService;

        public HomeController(ILogger<HomeController> logger,UserManager<AppUser> userManager,IMailService mailService)
        {
            _logger = logger;
            _userManager = userManager;
            _mailService = mailService;
        }


        public async Task<IActionResult >Index()
        {
            
            var user =await _userManager.Users
                .Include(x => x.Educations)
                .Include(x => x.Projects)
                .Include(x => x.Experiences).FirstOrDefaultAsync();           

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> MailMe([FromForm] string email,string subject,string message)
        {
            try
            {
                var mail = new MailRequest
                {
                    RecipientMail = email,
                    Subject = subject,
                    Body = message

                };

               await _mailService.SendMailAsync(mail);

            }catch(Exception ex)
            {

            }

            ViewBag.Message = "Mail Sent"; 
            return RedirectToAction("Index");
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
}
