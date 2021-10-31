using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext context) 
        {
            _context = context;
        }

        public List<Seller> FindAll() 
        {
            return _context.Seller.Include(seller => seller.Department).ToList();
        }
        public void Insert(Seller seller) 
        {            
            _context.Seller.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id) 
        {
            return _context.Seller.Include(seller => seller.Department).FirstOrDefault(seller => seller.Id == id);
        }

        public void Remove(int id) 
        {
            var seller = _context.Seller.Find(id);
            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }

        public void Update(Seller seller) 
        {

            if (!_context.Seller.Any(sel => sel.Id == seller.Id)) 
            {
                throw new NotFoundException("Vendendor não localizado.");
            }
            try
            {
                _context.Seller.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
        
    }
}
