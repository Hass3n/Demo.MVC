﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models.DepartmentModel;

namespace Demo.DAL.Data.Repositries.interfcae
{
    public interface IDepartmentRepostry:IGenericRepositry<Department>
    {


        IQueryable<Department> GetAllDepartment();
    

    }
}
