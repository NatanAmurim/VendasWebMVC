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
        public async Task<IActionResult> Index()
        {
            var listSeller = await _sellerService.FindAllAsync();
            return View(listSeller);
        }


        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public async Task<IActionResult> Create(Seller seller) 
        {
            if (!ModelState.IsValid) 
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel {Seller = seller, Departments = departments };
                return View(viewModel);
            }
            
            await _sellerService.InsertAsync    (seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id) 
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "O identificador do vendedor não pode ser nulo." });

            var seller = await _sellerService.FindByIdAsync(id.Value);

            if (seller == null)
                return RedirectToAction(nameof(Error), new { message = "Vendedor não localizado." });

            return View(seller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id) 
        {
            try
            {
                await _sellerService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));

            }
            catch (IntegrityException)
            {

                return RedirectToAction(nameof(Error), new { message = "Não é possível deletar um vendedor que possua vendas." });
            }

        }

        public IActionResult Details(int? id) 
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "O identificador do vendedor não pode ser nulo." });

            var seller = _sellerService.FindByIdAsync(id.Value);

            if (seller == null)
                return RedirectToAction(nameof(Error),new { message = "Vendedor não localizado."});

            return View(seller);
        }

        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "O identificador do vendedor não pode ser nulo." });

            var seller = await _sellerService.FindByIdAsync(id.Value);

            if (seller == null)
                return RedirectToAction(nameof(Error), new { message = "Vendedor não localizado." });

            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel {Seller = seller, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Seller seller) 
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }

            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "O identificador do vendedor é diferente do informado na requisição." });
            }
            try
            {
                await _sellerService.UpdateAsync(seller);
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
