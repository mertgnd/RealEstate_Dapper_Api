﻿namespace RealEstate_Dapper_Api.Dtos.ToDoListDtos
{
    public class ResultToDoListDto
    {
        public int ToDoListID { get; set; }
        public string TaskDescription { get; set; }
        public bool TaskStatus { get; set; }
    }
}
