using Demo.BLL.DTO;
using Demo.BLL.DTO.DepartmentDto;
using Demo.BLL.Services.Interface;
using Demo.PL.viewModels;
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


        #region Details
        [HttpGet]
        public IActionResult Details(int ?id)
        {
            if (!id.HasValue) return BadRequest();// 400
            var department = departmentServices.GetDepartmentById(id.Value);
            if (department == null) return NotFound();// 404
            return View(department);

        }
        #endregion


        #region Edit
        [HttpGet]

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest(); // not find id ==null
            var department = departmentServices.GetDepartmentById(id.Value);
            if (department == null) return NotFound();
            // manula mapping take  data from frontend to backend beacuase  GetDepartmentById return object type DepartmentDetailsDto

            // in Html i need to binding data from class UpdatedDetaildDto to make this add class in ViewModel (DepartmentEditViewModel)
            // to take data you need to binding
            var departmentEditViewModel = new DepartmentEditViewModel()
            {

                code=department.Code,
                Name=department.Name,
                DateofCreation=department.CreatedOn,
                Description=department.Description
            };

            return View(departmentEditViewModel);


        }
        [ValidateAntiForgeryToken]  // يمنع اي حاجه تكلم الاكشن ده غير الويب سيت الي انتا فاتحه 
        [HttpPost]
        public IActionResult Edit([FromRoute]int ? Id,DepartmentEditViewModel ViewModel)
        {
            if (!ModelState.IsValid) return View(ViewModel); // data in form not wriiten return the same view Edit
            try
            {

                // manual mapping from  DepartmentEditViewModel to  UpdateDepartmentDto to make upadte beacause method update take object from UpdateDepartmentDto

                var departmentUpdateDto = new UpdateDepartmentDto()
                {
                    Id=Id.Value,
                    code= ViewModel.code,
                    Name= ViewModel.Name,
                    Description = ViewModel.Description,
                    DateofCreation= ViewModel.DateofCreation

                };

                // call method updated

                int result = departmentServices.UpdateDepartment(departmentUpdateDto);
                if(result>0)
                
                    // after updated go to Action Index to show new Data updated
                    return RedirectToAction(nameof(Index));
                else
                    ModelState.AddModelError(String.Empty, "Department canot created"); // to display error

            }
            catch(Exception ex)
            {
                //log Exception

                if (_envinoment.IsDevelopment())
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


            // لو مدخلش في التراي ولا الايرور يرجع نفس الفيو 

            return View(ViewModel);

        }
        #endregion


        #region Delete Departmnet

        //[HttpGet]
        //public IActionResult Delete(int?id)
        //{
        //    if (!id.HasValue) return BadRequest();
        //    var department = departmentServices.GetDepartmentById(id.Value);
        //    if (department == null) return NotFound();
        //    return View(department);


        //}

        [HttpPost]
        public IActionResult Delete(int id)
        {

            if (id == 0) return BadRequest();
            try
            {

                bool isdelete = departmentServices.DeleteDepartment(id);
                if (isdelete) return RedirectToAction(nameof(Index));

                else
                {
                    ModelState.AddModelError("", "department is not Deleted");

                    return RedirectToAction(nameof(Delete), new { id });
                }


            }
            catch (Exception ex)
            {

                //log Exception

                if (_envinoment.IsDevelopment())
                {
                    // Development =>log error in console then return error message in the same view

                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));

                }

                else
                {

                    // Deployment=> log error in file or table database and return error view

                    _logger.LogError(ex.Message);

                    return View("Error");

                }
            }


        }


        #endregion
    }
}
