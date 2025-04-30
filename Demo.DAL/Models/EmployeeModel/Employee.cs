using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models.DepartmentModel;

namespace Demo.DAL.Models.EmployeeDepartment
{
    public class Employee :BaseEntity
    {
        public string Name { get; set; } = null;

        public int Age { get; set; }

        public string? Address { get; set; }

        public decimal Salary { get; set; }

        public bool IsActive { get; set; }
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime hireDate { get; set; }

        public Gander gander { get; set; }

        public EmployeeType employeeType { get; set; }

        // Navigation Property  one (Department)

        public int? DepartmentId { get; set; } //Fk
        public virtual Department? Departments { get; set; }


        public string? imageName { get; set; }



    }
}
