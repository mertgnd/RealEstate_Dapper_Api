using Dapper;
using RealEstate_Dapper_Api.Dtos.AboutUsDtos;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AboutUsRepository
{
    public class AboutUsRepository : IAboutUsRepository
    {
        private readonly Context _context;

        public AboutUsRepository(Context context)
        {
            _context = context;
        }

        public async void CreateAboutUs(CreateAboutUsDto aboutUsDto)
        {
            string query = "insert into AboutUs (Title,SubTitle,Description,SubDescription) values (@title,@subTitle,@description,@subDescription)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", aboutUsDto.Title);
            parameters.Add("@subTitle", aboutUsDto.SubTitle);
            parameters.Add("@description", aboutUsDto.Description);
            parameters.Add("@subDescription", aboutUsDto.SubDescription);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteAboutUs(int id)
        {
            string query = "Delete From AboutUs Where AboutUsID=@aboutUsID";
            var parameters = new DynamicParameters();
            parameters.Add("@aboutUsID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIdAboutUsDto> GetAboutUsById(int id)
        {
            string query = "Select * From AboutUs Where AboutUsID=@aboutUsID";
            var parameters = new DynamicParameters();
            parameters.Add("@aboutUsID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdAboutUsDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultAboutUsDto>> GetAllAboutUsAsync()
        {
            string query = "Select * From AboutUs";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAboutUsDto>(query);
                return values.ToList();
            }

        }

        public async void UpdateAboutUs(UpdateAboutUsDto aboutUsDto)
        {
            string query = "Update AboutUs Set Title=@title,SubTitle=@subTitle,Description=@description,SubDescription=@subDescription where AboutUsID=@aboutUsID";
            var parameters = new DynamicParameters();
            //parameters.Add("@aboutUsID", aboutUsDto.AboutUsID);
            parameters.Add("@aboutUsID", aboutUsDto.AboutUsID);
            parameters.Add("@title", aboutUsDto.Title);
            parameters.Add("@subTitle", aboutUsDto.SubTitle);
            parameters.Add("@description", aboutUsDto.Description);
            parameters.Add("@subDescription", aboutUsDto.SubDescription);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}