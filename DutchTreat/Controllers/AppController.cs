using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Controllers.Web
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IDutchRepository _repository;       

        public AppController(IMailService mailService, IDutchRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }

        public IActionResult Index()
        {  

            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            //throw new InvalidOperationException("Some error");            
            
            return View();
        }

        [HttpPost("Contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMail("aidasz_b@yahoo.com",
                                        model.Subject,
                                        $"From: {model.Name} - {model.Email}",
                                        $"Message: {model.Message}");

                ViewBag.UserMessage = "Mail sent";
                ModelState.Clear();

                //return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About us";

            return View();
        }

        //[Authorize]
        public IActionResult Shop()
        {
            //var results = _repository.GetAllProducts();
            return View(/*results*/);
        }

    }
}
