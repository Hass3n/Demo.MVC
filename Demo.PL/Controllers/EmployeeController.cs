using Demo.BLL.DTO.EmployeeDto;
using Demo.BLL.Services.Interface;
using Demo.DAL.Models.EmployeeDepartment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Demo.PL.Controllers
{
    public class EmployeeController(IEmployeeServices _employeeServices,ILogger<EmployeeController> _logger,IWebHostEnvironment _envirnoment) : Controller
    {
        public IActionResult Index()
        {
            var Employees = _employeeServices.getAllEmployee();
            return View(Employees);
        }

        [HttpGet]
        public IActionResult Create() => View();


        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto EmployeeDto)
        {

            if(ModelState.IsValid)
            {
                try
                {
                    int result = _employeeServices.Createemployee(EmployeeDto);

                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError(string.Empty, "Employee canot created");
                }
                catch(Exception ex)
                {

                    if(_envirnoment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }

                    else
                    {
                        _logger.LogError(ex.Message);
                    }


                }
            }
            return View(EmployeeDto);

        }


        public IActionResult Details(int?id)
        {
            if (!id.HasValue) return BadRequest();
            var employee = _employeeServices.getEmployeeByID(id.Value);
            if (employee == null) return NotFound();

            return View(employee);
        }


        [HttpGet]
        public IActionResult Edit(int?id)
        {

            if (!id.HasValue) return BadRequest();
            var employee = _employeeServices.getEmployeeByID(id.Value);
            if (employee == null) return NotFound();

            var updatedEmployee = new UpdateEmployeeDto()
            {
                Id = employee.Id,
                Address = employee.Address,
                Name = employee.Name,
                Age = employee.Age,
                Email = employee.Email,
                Salary = employee.Salary,
                PhoneNumber = employee.PhoneNumber,
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
                Gender = Enum.Parse<Gander>(employee.Gender),
                IsActive=employee.IsActive

            };

            return View(updatedEmployee);

        }

        [ValidateAntiForgeryToken]  // يمنع اي حاجه تكلم الاكشن ده غير الويب سيت الي انتا فاتحه 
        [HttpPost]
        public IActionResult Edit([FromRoute]int? id ,UpdateEmployeeDto employeeDto)
        {

            if (!ModelState.IsValid) return View(employeeDto);
         
            try
            {
                int result = _employeeServices.UpadteEmployee(employeeDto);

                if (result > 0) return RedirectToAction(nameof(Index));

                else
                {
                    ModelState.AddModelError(string.Empty, "employee Cannot updated");
                }

            }
            catch(Exception ex)
            {
                //log Exception

                if (_envirnoment.IsDevelopment())
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


            return View(employeeDto);

        }


        [HttpPost]
        public IActionResult Delete(int ?id)
        {
            if (id == 0) return BadRequest();
            try
            {
                var delete = _employeeServices.DeleteEmployee(id.Value);
                if (delete)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee not delted");

                    return RedirectToAction(nameof(Index));

                }


            }
            catch(Exception ex)
            {
                if (_envirnoment.IsDevelopment())
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
            return RedirectToAction(nameof(Index));

        }
    }

}
