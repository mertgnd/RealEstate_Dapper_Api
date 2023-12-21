using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async void CreateEmployee(CreateEmployeeDto employeeDto)
        {
            string query = "insert into Employee (Name,Title,Phone,Email,ImageURL,Status) values (@Name,@Title,@Phone,@Email,@ImageURL,@Status)";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", employeeDto.Name);
            parameters.Add("@Title", employeeDto.Title);
            parameters.Add("@Phone", employeeDto.Phone);
            parameters.Add("@Email", employeeDto.Email);
            parameters.Add("@ImageURL", employeeDto.ImageURL);
            parameters.Add("@Status", employeeDto.Status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteEmployee(int id)
        {
            string query = "Delete From Employee Where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllAsync()
        {
            string query = "Select * From Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdEmployeeDto> GetEmployeeById(int id)
        {
            string query = "Select * From Employee Where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            string query = "Update Employee Set Name=@name,Title=@title,Phone=@phone,Email=@email,ImageURL=@imageURL,Status=@status where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", employeeDto.EmployeeID);
            parameters.Add("@name", employeeDto.Name);
            parameters.Add("@title", employeeDto.Title);
            parameters.Add("@phone", employeeDto.Phone);
            parameters.Add("@email", employeeDto.Email);
            parameters.Add("@imageURL", employeeDto.ImageURL);
            parameters.Add("@status", employeeDto.Status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
