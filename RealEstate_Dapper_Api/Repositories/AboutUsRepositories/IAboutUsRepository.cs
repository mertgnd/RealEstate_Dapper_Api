using RealEstate_Dapper_Api.Dtos.AboutUsDtos;

namespace RealEstate_Dapper_Api.Repositories.AboutUsRepositories
{
    public interface IAboutUsRepository
    {
        Task<List<ResultAboutUsDto>> GetAllAboutUsAsync();
        Task<GetByIdAboutUsDto> GetAboutUsById(int id);
        void CreateAboutUs(CreateAboutUsDto aboutUsDto);
        void UpdateAboutUs(UpdateAboutUsDto aboutUsDto);
        void DeleteAboutUs(int id);
    }
}