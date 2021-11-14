using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext context) 
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync() 
        {
            return await _context.Seller.Include(seller => seller.Department).ToListAsync();
        }
        public async Task InsertAsync(Seller seller) 
        {            
            _context.Seller.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id) 
        {
            return await _context.Seller.Include(seller => seller.Department).FirstOrDefaultAsync(seller => seller.Id == id);
        }

        public async Task RemoveAsync(int id) 
        {
            try
            {
                var seller = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
            
        }

        public async Task UpdateAsync(Seller seller) 
        {

            if (! await _context.Seller.AnyAsync(sel => sel.Id == seller.Id))             
                throw new NotFoundException("Vendendor não localizado.");
            
            try
            {
                _context.Seller.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
        
    }
}
