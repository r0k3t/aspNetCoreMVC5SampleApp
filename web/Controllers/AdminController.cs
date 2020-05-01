using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Services;
using Core.Models;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
    public class AdminController : Controller
    {
        private IContactService _service;

        public AdminController(IContactService service)
        {
            _service = service;
        }

        public ActionResult AddUser()
        {
            return View("AddUser");
        }

        [HttpPost]
        public ActionResult AddUser(ContactViewModel model)
        {
            var result = _service.AddNewContact(model);
            return View(model);
        }
    }
}