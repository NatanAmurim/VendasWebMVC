using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService) 
        {
            _sellerService = sellerService;
        }
        public IActionResult Index()
        {
            var listSeller = _sellerService.FindAll();
            return View(listSeller);
        }
    }
}
