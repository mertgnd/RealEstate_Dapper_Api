using Dapper;
using RealEstate_Dapper_Api.Dtos.ProsedureDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProsedureRepositories
{
    public class ProsedureRepository : IProsedureRepository
    {
        private readonly Context _context;

        public ProsedureRepository(Context context)
        {
            _context = context;
        }

        public void CreateProsedure(CreateProsedureDto categoryDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteProsedure(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultProsedureDto>> GetAllAsync()
        {
            string query = "Select * From Prosedures";
            using ( var connection = _context.CreateConnection() )
            {
                var values = await connection.QueryAsync<ResultProsedureDto>(query);
                return values.ToList();
            }
        }

        public Task<GetByIdProsedureDto> GetProsedureById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProsedure(UpdateProsedureDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
