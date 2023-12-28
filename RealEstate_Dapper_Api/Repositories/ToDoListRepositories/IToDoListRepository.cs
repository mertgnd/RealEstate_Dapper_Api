using RealEstate_Dapper_Api.Dtos.ToDoListDtos;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GetAllAsync();
        void CreateCategory(CreateToDoListDto categoryDto);
        void UpdateCategory(UpdateToDoListDto categoryDto);
        Task<GetByIdToDoListDto> GetCategoryById(int id);
        void DeleteCategory(int id);
    }
}