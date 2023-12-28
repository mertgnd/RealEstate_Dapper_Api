using RealEstate_Dapper_Api.Dtos.ContactDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllAsync();
        Task<List<ResultLast4ContactDto>> GetLast4ContactAsync();
        void CreateEmployee(CreateContactDto categoryDto);
        Task<GetByIdContactDto> GetEmployeeById(int id);
        void DeleteEmployee(int id);
    }
}
