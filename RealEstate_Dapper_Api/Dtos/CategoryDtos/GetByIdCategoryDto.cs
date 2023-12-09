namespace RealEstate_Dapper_Api.Dtos.CategoryDtos
{
    public class GetByIdCategoryDto
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}