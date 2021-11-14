using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Controllers
{
    public class SaleRecordsController : Controller
    {
        private readonly SaleRecordsService _saleRecordsService;

        public SaleRecordsController(SaleRecordsService saleRecordsService) 
        {
            _saleRecordsService = saleRecordsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!(minDate.HasValue && maxDate.HasValue))
                return RedirectToAction(nameof(Error), new { message = "Ambas as datas devem ser preenchidas para realizar a busca." });
            
            var saleRecordsService = await _saleRecordsService.FindByDateAsync(minDate, maxDate);
            
            @ViewData["minDate"] = minDate.Value.ToString("dd/MM/yyyy");
            @ViewData["maxDate"] = maxDate.Value.ToString("dd/MM/yyyy");            

            return View(saleRecordsService);
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }

        public IActionResult Error(string message)
        {

            var errorView = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(errorView);
        }
    }
}
