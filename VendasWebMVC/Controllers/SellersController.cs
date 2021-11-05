using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;
using SalesWebMVC.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var listSeller = _sellerService.FindAll();
            return View(listSeller);
        }


        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public IActionResult Create(Seller seller) 
        {
            if (!ModelState.IsValid) 
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel {Seller = seller, Departments = departments };
                return View(viewModel);
            }
            
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id) 
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "O identificador do vendedor não pode ser nulo." });

            var seller = _sellerService.FindById(id.Value);

            if (seller == null)
                return RedirectToAction(nameof(Error), new { message = "Vendedor não localizado." });

            return View(seller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) 
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id) 
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "O identificador do vendedor não pode ser nulo." });

            var seller = _sellerService.FindById(id.Value);

            if (seller == null)
                return RedirectToAction(nameof(Error),new { message = "Vendedor não localizado."});

            return View(seller);
        }

        public IActionResult Edit(int? id) 
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { Message = "O identificador do vendedor não pode ser nulo." });

            var seller = _sellerService.FindById(id.Value);

            if (seller == null)
                return RedirectToAction(nameof(Error), new { message = "Vendedor não localizado." });

            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel {Seller = seller, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Seller seller) 
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }

            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "O identificador do vendedor é diferente do informado na requisição." });
            }
            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

            
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
