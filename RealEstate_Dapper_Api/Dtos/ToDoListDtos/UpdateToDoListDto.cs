namespace RealEstate_Dapper_Api.Dtos.ToDoListDtos
{
    public class UpdateToDoListDto
    {
        public int ToDoListID { get; set; }
        public string TaskDescription { get; set; }
        public bool TaskStatus { get; set; }
    }
}