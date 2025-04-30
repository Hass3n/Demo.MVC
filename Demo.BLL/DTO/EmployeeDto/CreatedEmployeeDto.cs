using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models.EmployeeDepartment;
using Microsoft.AspNetCore.Http;

namespace Demo.BLL.DTO.EmployeeDto
{
    public class CreatedEmployeeDto
    {

        //  كل الفلاديشن ده مش هيسمع عندي في الداتا بيز  ده بعمله عشان قبل ما ابعت الداتا الي الداتا بيز أعمل عليها فلاديشن 
        [Required (ErrorMessage ="Name must be not null")]
        [MaxLength(50, ErrorMessage = "Max length should be 50 character")]
        [MinLength(5, ErrorMessage = "Min length should be 5 characters")]
        public string Name { get; set; } = null!;
        [Range(22, 30)]
        public int? Age { get; set; }
        [RegularExpression("^[1-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$",
           ErrorMessage = "Address must be like 123-Street-City-Country")]
        public string? Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; } 
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Display(Name = "Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }
        // Enum  عشان اعرف احكمه مش هيعرف يدخل قيم غير الي موجدين في Gander أنا عامل ده من نوع 
        public Gander Gender { get; set; }
        // Enum  عشان اعرف احكمه مش هيعرف يدخل قيم غير الي موجدين في EmployeeType أنا عامل ده من نوع 

        [Display(Name ="Employee Type")]
        public EmployeeType EmployeeType { get; set; }

        public int? DepartmentId { get; set; }

        public IFormFile?  Image { get; set; }
    }
}
