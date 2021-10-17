using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;
using System;
using System.Linq;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;

        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }
        public void Seed() 
        {
            if (_context.Department.Any() || 
                _context.Seller.Any() || 
                _context.SaleRecord.Any()) 
            {
                return;
            }

            Department d1 = new Department(1, "Computadores");
            Department d2 = new Department(2, "Eletronicos");
            Department d3 = new Department(3, "Moda");
            Department d4 = new Department(4, "Livros");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Seller s4 = new Seller(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Seller s6 = new Seller(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            SaleRecord r1 = new SaleRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s1);
            SaleRecord r2 = new SaleRecord(2, new DateTime(2018, 09, 4), 7000.0, SaleStatus.Billed, s5);
            SaleRecord r3 = new SaleRecord(3, new DateTime(2018, 09, 13), 4000.0, SaleStatus.Canceled, s4);
            SaleRecord r4 = new SaleRecord(4, new DateTime(2018, 09, 1), 8000.0, SaleStatus.Billed, s1);
            SaleRecord r5 = new SaleRecord(5, new DateTime(2018, 09, 21), 3000.0, SaleStatus.Billed, s3);
            SaleRecord r6 = new SaleRecord(6, new DateTime(2018, 09, 15), 2000.0, SaleStatus.Billed, s1);
            SaleRecord r7 = new SaleRecord(7, new DateTime(2018, 09, 28), 13000.0, SaleStatus.Billed, s2);
            SaleRecord r8 = new SaleRecord(8, new DateTime(2018, 09, 11), 4000.0, SaleStatus.Billed, s4);
            SaleRecord r9 = new SaleRecord(9, new DateTime(2018, 09, 14), 11000.0, SaleStatus.Pending, s6);
            SaleRecord r10 = new SaleRecord(10, new DateTime(2018, 09, 7), 9000.0, SaleStatus.Billed, s6);
            SaleRecord r11 = new SaleRecord(11, new DateTime(2018, 09, 13), 6000.0, SaleStatus.Billed, s2);
            SaleRecord r12 = new SaleRecord(12, new DateTime(2018, 09, 25), 7000.0, SaleStatus.Pending, s3);
            SaleRecord r13 = new SaleRecord(13, new DateTime(2018, 09, 29), 10000.0, SaleStatus.Billed, s4);
            SaleRecord r14 = new SaleRecord(14, new DateTime(2018, 09, 4), 3000.0, SaleStatus.Billed, s5);
            SaleRecord r15 = new SaleRecord(15, new DateTime(2018, 09, 12), 4000.0, SaleStatus.Billed, s1);
            SaleRecord r16 = new SaleRecord(16, new DateTime(2018, 10, 5), 2000.0, SaleStatus.Billed, s4);
            SaleRecord r17 = new SaleRecord(17, new DateTime(2018, 10, 1), 12000.0, SaleStatus.Billed, s1);
            SaleRecord r18 = new SaleRecord(18, new DateTime(2018, 10, 24), 6000.0, SaleStatus.Billed, s3);
            SaleRecord r19 = new SaleRecord(19, new DateTime(2018, 10, 22), 8000.0, SaleStatus.Billed, s5);
            SaleRecord r20 = new SaleRecord(20, new DateTime(2018, 10, 15), 8000.0, SaleStatus.Billed, s6);
            SaleRecord r21 = new SaleRecord(21, new DateTime(2018, 10, 17), 9000.0, SaleStatus.Billed, s2);
            SaleRecord r22 = new SaleRecord(22, new DateTime(2018, 10, 24), 4000.0, SaleStatus.Billed, s4);
            SaleRecord r23 = new SaleRecord(23, new DateTime(2018, 10, 19), 11000.0, SaleStatus.Canceled, s2);
            SaleRecord r24 = new SaleRecord(24, new DateTime(2018, 10, 12), 8000.0, SaleStatus.Billed, s5);
            SaleRecord r25 = new SaleRecord(25, new DateTime(2018, 10, 31), 7000.0, SaleStatus.Billed, s3);
            SaleRecord r26 = new SaleRecord(26, new DateTime(2018, 10, 6), 5000.0, SaleStatus.Billed, s4);
            SaleRecord r27 = new SaleRecord(27, new DateTime(2018, 10, 13), 9000.0, SaleStatus.Pending, s1);
            SaleRecord r28 = new SaleRecord(28, new DateTime(2018, 10, 7), 4000.0, SaleStatus.Billed, s3);
            SaleRecord r29 = new SaleRecord(29, new DateTime(2018, 10, 23), 12000.0, SaleStatus.Billed, s5);
            SaleRecord r30 = new SaleRecord(30, new DateTime(2018, 10, 12), 5000.0, SaleStatus.Billed, s2);

            _context.Department.AddRange(d1,d2,d3,d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SaleRecord.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17, r18, r19, r20, r21, r22, r23, r24, r25, r26, r27, r28, r29, r30);           
            _context.SaveChanges();
        }
    }
}
