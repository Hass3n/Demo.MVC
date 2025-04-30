using AutoMapper;
using Demo.BLL.DTO.EmployeeDto;
using Demo.BLL.Services.Interface;
using Demo.DAL.Models.EmployeeDepartment;
using Demo.PL.viewModels.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Demo.PL.Controllers
{
    public class EmployeeController(IMapper _mapper,IEmployeeServices _employeeServices,ILogger<EmployeeController> _logger,IWebHostEnvironment _envirnoment) : Controller
    {
        public IActionResult Index(string? EmployeeSearchName)
        {
            // save Data from Temp Data if you index go to anthor actio the Data is saved
            TempData.Keep();

            // Transfer Extra Data send data from Action to view

            // first way  ViewData  
            ViewData["Message"] = "Hiii ViewData";

            // second way
            ViewBag.Message = "Hii ViewBag";

            dynamic _Employees = null;

            if (string.IsNullOrEmpty(EmployeeSearchName))
            {
                 _Employees = _employeeServices.getAllEmployee();

            }

            else
            {

                _Employees=_employeeServices.searchEmployeeByName(EmployeeSearchName);

            }
            return View(_Employees);
        }

        [HttpGet]
        public IActionResult Create(/*[FromServices]IDepartmentServices departmentServices*/) {

            // send Data to Create Design Employee view 
            //ViewData["Departments"] = departmentServices.GetAllDepartments();
            return View();
                
         }



        [HttpPost]
        public IActionResult Create(EmployeeViewModel EmployeeDto)
        {

            if(ModelState.IsValid)  // Server client validation
            {
                try
                {
                    // make manual mapping


                    var employeeCreatedDto = new CreatedEmployeeDto()
                    {
                        Name = EmployeeDto.Name,
                        Address = EmployeeDto.Address,
                        Age = EmployeeDto.Age,
                        IsActive = EmployeeDto.IsActive,
                        Email = EmployeeDto.Email,
                        EmployeeType = EmployeeDto.EmployeeType,
                        Gender = EmployeeDto.Gender,
                        Salary = EmployeeDto.Salary,
                        HiringDate = EmployeeDto.HiringDate,
                        PhoneNumber = EmployeeDto.PhoneNumber,
                        DepartmentId = EmployeeDto.DepartmentId,
                        Image=EmployeeDto.Image

                    };


                    int result = _employeeServices.Createemployee(employeeCreatedDto);

                    if (result > 0)

                    {
                        // send Dat from Action to Action    TempData["Message"] 
                        TempData["Message"] = "Employee Create sucessful";
                        return RedirectToAction(nameof(Index));


                    }

                    else
                    {
                        // send Dat from Action to Action    TempData["Message"] 
                        TempData["Message"] = "failed Created Employee";
                        ModelState.AddModelError(string.Empty, "Employee canot created");


                    }

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
        public IActionResult Edit(int?id /*[FromServices] IDepartmentServices departmentServices*/)
        {

            if (!id.HasValue) return BadRequest();
            var employee = _employeeServices.getEmployeeByID(id.Value);
            if (employee == null) return NotFound();



            // get full path images
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Images", employee.imageName);
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            IFormFile formFile = new FormFile(fileStream, 0, fileStream.Length, "Images", employee.imageName);




            // manual mapping
            var updatedEmployee = new EmployeeViewModel()
            {

                Address = employee.Address,
                Name = employee.Name,
                Age = employee.Age,
                Email = employee.Email,
                Salary = employee.Salary,
                PhoneNumber = employee.PhoneNumber,
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
                Gender = Enum.Parse<Gander>(employee.Gender),
                IsActive = employee.IsActive,
                Image=formFile



            };

            // send Data to Edit Design Employee 

            //ViewData["Departments"] = departmentServices.GetAllDepartments();

            return View(updatedEmployee);

        }

        [ValidateAntiForgeryToken]  // يمنع اي حاجه تكلم الاكشن ده غير الويب سيت الي انتا فاتحه 
        [HttpPost]
        public IActionResult Edit([FromRoute]int? id ,EmployeeViewModel viewModel)
        {

            if (!ModelState.IsValid) return View(viewModel);
         
            try
            {
                // make manual mapping

                var updatedEmployee = new UpdateEmployeeDto()
                {
                    Id=id.Value,
                    Name = viewModel.Name,
                    Address = viewModel.Address,
                    Age = viewModel.Age,
                    IsActive = viewModel.IsActive,
                    Email = viewModel.Email,
                    EmployeeType = viewModel.EmployeeType,
                    Gender = viewModel.Gender,
                    Salary=viewModel.Salary,
                    HiringDate = viewModel.HiringDate,

                };


                int result = _employeeServices.UpadteEmployee(updatedEmployee);

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


            return View(viewModel);

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
