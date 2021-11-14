using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class SaleRecordsService
    {
        private readonly SalesWebMVCContext _context;
        public SaleRecordsService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<SaleRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate) 
        {
            //Sem banco, apenas montagem da consulta.
            var consult = from listConsult in _context.SaleRecord select listConsult;
            
            if (minDate.HasValue)
                consult = consult.Where(sale => sale.Date >= minDate);
            if (maxDate.HasValue)
                consult = consult.Where(sale => sale.Date <= maxDate);

           return await consult.Include(sale => sale.Seller)
                .Include(sale => sale.Seller.Department)
                .OrderByDescending(sale => sale.Date)
                .ToListAsync();
        }

        public async Task<List<SaleRecord>> FindByGrouping(int DeparmentId,DateTime dateMin, DateTime dateMax)
        {
            return await _context.SaleRecord.Where(sale => sale.Date >= dateMin && sale.Date <= dateMax).ToListAsync();
        }
    }
}
