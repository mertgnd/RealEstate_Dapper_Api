using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDto>> GetAllAsync();
        void CreateEmployee(CreateEmployeeDto categoryDto);
        void UpdateEmployee(UpdateEmployeeDto categoryDto);
        Task<GetByIdEmployeeDto> GetEmployeeById(int id);
        void DeleteEmployee(int id);
    }
}
