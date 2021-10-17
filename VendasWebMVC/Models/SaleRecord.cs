using SalesWebMVC.Models.Enums;
using System;

namespace SalesWebMVC.Models
{
    public class SaleRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus SalesStatus { get; set; }
        public Seller Seller { get; set; }

        public SaleRecord()
        {
        }

        public SaleRecord(int id, DateTime date, double amount, SaleStatus salesStatus, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            SalesStatus = salesStatus;
            Seller = seller;
        }
    }
}
