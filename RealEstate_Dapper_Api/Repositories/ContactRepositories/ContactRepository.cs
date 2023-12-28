using Dapper;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }

        public void CreateEmployee(CreateContactDto categoryDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultContactDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdContactDto> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultLast4ContactDto>> GetLast4ContactAsync()
        {
            string query = "Select Top(4) * From Contact order by ContactID desc";
            using( var connection = _context.CreateConnection() )
            {
                var values = await connection.QueryAsync<ResultLast4ContactDto>(query);
                return values.ToList();
            }
        }
    }
}