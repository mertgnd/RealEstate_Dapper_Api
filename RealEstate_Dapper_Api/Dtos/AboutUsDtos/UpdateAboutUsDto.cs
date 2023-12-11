namespace RealEstate_Dapper_Api.Dtos.AboutUsDtos
{
    public class UpdateAboutUsDto
    {
        public int AboutUsID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string SubDescription { get; set; }
    }
}