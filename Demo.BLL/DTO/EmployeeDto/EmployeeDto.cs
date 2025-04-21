using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DTO.EmployeeDto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        //عشان عاوز أظهر علامه الدولار جمب المرتب 
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        //Is Active بالشكل ده IsActive  عشان عاوز أظهر  
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        // Email formate عشان عاوز اعمل 
        [EmailAddress]
        public string? Email { get; set; }
        public string mGender { get; set; }
        [Display(Name = "Employee Type")]
        public string EmpType { get; set; }
    }
}
