using Dapper;
using RealEstate_Dapper_Api.Dtos.ProsedureDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
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

        public async void CreateProsedure(CreateProsedureDto createProsedureDto)
        {
            string query = "insert into Prosedures (Icon,Title,Description) values (@icon,@title,@description)";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", createProsedureDto.Icon);
            parameters.Add("@title", createProsedureDto.Title);
            parameters.Add("@description", createProsedureDto.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteProsedure(int id)
        {
            string query = "Delete From Prosedures Where ProsedureID=@prosedureID";
            var parameters = new DynamicParameters();
            parameters.Add("@prosedureID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
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

        public async Task<GetByIdProsedureDto> GetProsedureById(int id)
        {
            string query = "Select * From Prosedures Where ProsedureID=@proseduresID";
            var parameters = new DynamicParameters();
            parameters.Add("@proseduresID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdProsedureDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateProsedure(UpdateProsedureDto updateProsedureDto)
        {
            string query = "Update Prosedures Set Icon=@icon,Title=@title,Description=@description where ProsedureID=@prosedureID";
            var parameters = new DynamicParameters();
            parameters.Add("@prosedureID", updateProsedureDto.ProsedureID);
            parameters.Add("@icon", updateProsedureDto.Icon);
            parameters.Add("@title", updateProsedureDto.Title);
            parameters.Add("@description", updateProsedureDto.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
