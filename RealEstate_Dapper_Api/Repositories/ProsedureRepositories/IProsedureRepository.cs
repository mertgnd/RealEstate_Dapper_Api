using RealEstate_Dapper_Api.Dtos.ProsedureDtos;

namespace RealEstate_Dapper_Api.Repositories.ProsedureRepositories
{
    public interface IProsedureRepository
    {
        Task<List<ResultProsedureDto>> GetAllAsync();
        void CreateProsedure(CreateProsedureDto categoryDto);
        void UpdateProsedure(UpdateProsedureDto categoryDto);
        Task<GetByIdProsedureDto> GetProsedureById(int id);
        void DeleteProsedure(int id);
    }
}
