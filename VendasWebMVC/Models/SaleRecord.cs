using SalesWebMVC.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models
{
    public class SaleRecord
    {
        public int Id { get; set; }

        [Display(Name = "Data venda")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Display(Name = "Quantia")]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [Display(Name = "Status")]
        public SaleStatus SalesStatus { get; set; }

        [Display(Name = "Vendedor")]
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
