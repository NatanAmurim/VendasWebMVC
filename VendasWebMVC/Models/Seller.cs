using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage ="Nome obrigatório.")]
        [StringLength(60,MinimumLength = 4,ErrorMessage ="O tamanho do nome deve estar entre {2} e {1}.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email obrigatório.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Entre com um email válido.")]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Data de nascimento obrigatória.")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Salário base")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Salário obrigatório.")]
        [Range(1000,100000, ErrorMessage ="O salário deve estar entre {2} e {1}.")]
        //[DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }

        [Display(Name = "Departamento")]
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SaleRecord> Sales { get; set; } = new List<SaleRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;            
        }

        public void AddSale(SaleRecord sale)
        {
            Sales.Add(sale);
        }
        public void RemoveSale(SaleRecord sale)
        {
            Sales.Remove(sale);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sale => sale.Date >= initial && sale.Date <= final)
                .Sum(sale => sale.Amount);
        }

    }
}
