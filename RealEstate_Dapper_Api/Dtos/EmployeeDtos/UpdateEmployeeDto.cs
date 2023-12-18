namespace RealEstate_Dapper_Api.Dtos.EmployeeDtos
{
    public class UpdateEmployeeDto
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImageURL { get; set; }
        public bool Status { get; set; }
    }
}
