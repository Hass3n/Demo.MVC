using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demo.BLL.DTO.EmployeeDto;
using Demo.DAL.Models.EmployeeDepartment;

namespace Demo.BLL.Profiles
{
    public class MappingProfiles:Profile
    {

        // ده من خلاله بعمل الماب CreateMap  ده انا ورثته لما نزلت الباكج بتاع الماب فيه داله اسمها Profile انا بورث من كلاس 
        public MappingProfiles()
        {

            //  مختلف في الكلاس  انتا بتعرفه عشان يعرف يماب عاليه تعرفه اني ده هو ده  prop  انا بستخدمها لو عند اسم من ForMember
            //  بس الاسماء مختلفه Employee الي في كلاس gander  هو هو mgander  عندي  EmployeeDto  يعني هنا عندي في كلاس  
            // كذلك لو مختلفين في نوع الداتا طيب 
            CreateMap<Employee, EmployeeDto>()
                .ForMember(des => des.mGender, option => option.MapFrom(src => src.gander))
                .ForMember(des => des.EmpType, option => option.MapFrom(src => src.employeeType));

            CreateMap<Employee, EmployeeDetailsDto>()
                 .ForMember(des => des.Gender, option => option.MapFrom(src => src.gander))
                .ForMember(des => des.EmployeeType, option => option.MapFrom(src => src.employeeType))
                .ForMember(des => des.HiringDate, option => option.MapFrom(src => DateOnly.FromDateTime(src.hireDate)));

            CreateMap<CreatedEmployeeDto, Employee>()
                //convert from Date only to Date time 
                .ForMember(des => des.hireDate, option => option.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)))
                .ForMember(des => des.gander, option => option.MapFrom(src => src.Gender))
                .ForMember(des => des.employeeType, option => option.MapFrom(src => src.EmployeeType));


            // وينفع العكس B  الي كلاس A لو عاوز اخلي التحويل ينفع مثلا من كلاس  

            // CreateMap<CreatedEmployeeDto, Employee>().ReverseMap();


            CreateMap<UpdateEmployeeDto, Employee>()
             //convert from Date only to Date time 
             .ForMember(des => des.hireDate, option => option.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

        }
    }
}
