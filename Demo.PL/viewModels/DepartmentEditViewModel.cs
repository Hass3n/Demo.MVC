namespace Demo.PL.viewModels
{
    public class DepartmentEditViewModel
    {

        public String Name { get; set; } = string.Empty;// default value

        public String code { get; set; } = string.Empty;// default value

        public DateOnly? DateofCreation { get; set; }

        public String? Description { get; set; }
    }
}
