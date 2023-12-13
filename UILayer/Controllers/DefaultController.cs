using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UILayer.Models;

namespace UILayer.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ICustomerService _customerService;

        public DefaultController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index( CustomerViewModel viewModel)
        {
            var sender = _customerService.TGetById(viewModel.SendeId);
            var receiver = _customerService.TGetById(viewModel.ReceiverId);

            sender.Balance -= viewModel.Amount;
            receiver.Balance += viewModel.Amount;

            List<Customer> modifiedCustomer = new List<Customer>()
            {
                sender,receiver
            };
            _customerService.TMultipleUpdate(modifiedCustomer);

            return View();
        }
    }
}
