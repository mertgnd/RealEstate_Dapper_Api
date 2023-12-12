using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllAsync();
        Task<ResultCategoryDto> CreateCategory(CreateCategoryDto categoryDto);
        Task<ResultCategoryDto> UpdateCategory(UpdateCategoryDto categoryDto);
        Task<GetByIdCategoryDto> GetCategoryById(int id);
        void DeleteCategory(int id);
    }
}