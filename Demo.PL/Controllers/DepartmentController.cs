using Demo.BLL.DTO;
using Demo.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentController(IDepartmentServices departmentServices,
        ILogger<DepartmentController> _logger ,IWebHostEnvironment _envinoment) : Controller
    {
        //private readonly IDepartmentServices departmentServices = departmentServices;

        public IActionResult Index()
        {

          var departments=  departmentServices.GetAllDepartments();
            
            return View(departments);
        }

        #region Create Departmnet

        [HttpGet]   // open form for create Department
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto departmentDto)
        {

            if(ModelState.IsValid)  // server vaildation to check validation of data
            {

                try
                {

                  int result=  departmentServices.AddDepartment(departmentDto);

                    if (result > 0)
                        // call Action Index and get lasted Added Data
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError(String.Empty, "Department canot created"); // to display error

                }
                catch (Exception ex)
                {

                    //log Exception

                    if(_envinoment.IsDevelopment())
                    {
                        // Development =>log error in console then return error message in the same view

                        ModelState.AddModelError(string.Empty, ex.Message);

                    }

                    else
                    {

                        // Deployment=> log error in file or table database and return error view

                        _logger.LogError(ex.Message);

                    }




                }

            }
         

                return View(departmentDto);


            
        }
        #endregion
    }
}
