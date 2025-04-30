using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Repositries.interfcae;

namespace Demo.DAL.Data.Repositries.Classes
{
    public class UnitofWork : InUnitOfWork
    {

        // Lazy Implemntion 

        /**** Lazy Implemntion 
         *  Dependecy Injection مش مسؤل عن عمل الاوبجكت أنا كده الي بعمل الاوبجكت لما أحتاجه وكده ده مش مطبق مفهوم  clr  هنا ال 
         *   حتي لو مش محتاجها ده مش صح constructor  بعمل أوبجكت من كل الكلاس الي عندي في UnitofWork ليه بستخدم الطريقه دي عشان خاطر لو انا بعمل أوبجكت من 
         * 
         * 
         */

        Lazy< IDepartmentRepostry> _departmentRepostry;
       Lazy< IEmployeeRepositry> _employeeRepositry;
        private readonly AppDpContext _dbContext;

        public UnitofWork(AppDpContext dbContext )
        {
            _departmentRepostry =new Lazy<IDepartmentRepostry>(()=>new DepartmentRepostry(dbContext));
            _employeeRepositry = new Lazy<IEmployeeRepositry>(()=>new EmployeeRepsoitry(dbContext));
            this._dbContext = dbContext;
        }

        public IEmployeeRepositry EmployeeRepositry 
        {
            get
            {
                return _employeeRepositry.Value;

            }
        }
        public IDepartmentRepostry DepartmentRepostry
        {
            get
            {

                return _departmentRepostry.Value;
            }
        }
        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
