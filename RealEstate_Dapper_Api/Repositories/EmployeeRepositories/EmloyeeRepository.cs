using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public class EmloyeeRepository : IEmployeeRepository
    {
        public void CreateEmployee(CreateEmployeeDto categoryDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultEmployeeDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdEmployeeDto> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(UpdateEmployeeDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
