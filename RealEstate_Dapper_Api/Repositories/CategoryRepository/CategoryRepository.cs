using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async Task<ResultCategoryDto> CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "INSERT INTO Category (CategoryName, CategoryStatus) VALUES (@categoryName, @categoryStatus); SELECT SCOPE_IDENTITY();";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.Name);
            parameters.Add("@categoryStatus", true);

            using (var connection = _context.CreateConnection())
            {
                var categoryId = await connection.QuerySingleAsync<int>(query, parameters);

                // Retrieve the created category immediately after insertion
                string getCategoryQuery = "SELECT * FROM Category WHERE CategoryID = @categoryId";
                var getCategoryParameters = new DynamicParameters();
                getCategoryParameters.Add("@categoryId", categoryId);

                return await connection.QuerySingleOrDefaultAsync<ResultCategoryDto>(getCategoryQuery, getCategoryParameters);
            }
        }

        public async void DeleteCategory(int id)
        {
            string query = "Delete from Category Where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllAsync()
        {
            string query = "Select * from Category";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCategoryDto> GetCategoryById(int id)
        {
            string query = "Select * From Category Where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryID", id);

            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
                return values;
            }
        }

        public async Task<ResultCategoryDto> UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "Update Category Set CategoryName=@categoryName,CategoryStatus=@categoryStatus where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", categoryDto.CategoryID);
            parameters.Add("@categoryName", categoryDto.Name);
            parameters.Add("@categoryStatus", categoryDto.Status);

            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

                string getCategoryQuery = "SELECT * FROM Category WHERE CategoryID = @categoryID";
                return await connection.QuerySingleOrDefaultAsync<ResultCategoryDto>(getCategoryQuery, parameters);
            }
        }
    }
}