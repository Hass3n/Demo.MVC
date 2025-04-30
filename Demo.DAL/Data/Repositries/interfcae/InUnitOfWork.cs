using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositries.interfcae
{
    public interface InUnitOfWork
    {
       public IEmployeeRepositry EmployeeRepositry { get; }

        public IDepartmentRepostry DepartmentRepostry { get; }

        int SaveChanges();
    }
}
