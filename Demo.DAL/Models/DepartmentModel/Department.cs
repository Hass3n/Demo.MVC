using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models.EmployeeDepartment;

namespace Demo.DAL.Models.DepartmentModel
{
   public class Department :BaseEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string? Description { get; set; }

        // Navigation Prpoerty Employess (many)

        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
