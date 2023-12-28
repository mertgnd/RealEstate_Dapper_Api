using Dapper;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async void CreatePopularLocation(CreatePopularLocationDto popularLocationDto)
        {
            string query = "insert into PopularLocations (CityName,ImageURL) values (@cityName,@imageURL)";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", popularLocationDto.CityName);
            parameters.Add("@imageURL", popularLocationDto.ImageURL);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeletePopularLocation(int id)
        {
            string query = "Delete From PopularLocations Where PopularLocationID=@popularLocationID";
            var parameters = new DynamicParameters();
            parameters.Add("@popularLocationID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
            string query = "Select * From PopularLocations";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdPopularLocationDto> GetPopularLocationById(int id)
        {
            string query = "Select * From PopularLocations Where PopularLocationID=@popularLocationID";
            var parameters = new DynamicParameters();
            parameters.Add("@popularLocationID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdPopularLocationDto>(query, parameters);
                return values;
            }
        }

        public async void UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto)
        {
            string query = "Update PopularLocations Set CityName=@cityName,ImageURL=@imageURL where PopularLocationID=@popularLocationID";
            var parameters = new DynamicParameters();
            parameters.Add("@popularLocationID", popularLocationDto.PopularLocationID);
            parameters.Add("@cityName", popularLocationDto.CityName);
            parameters.Add("@imageURL", popularLocationDto.ImageURL);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}