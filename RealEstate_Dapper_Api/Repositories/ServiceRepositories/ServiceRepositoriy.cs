using Dapper;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepositoriy : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepositoriy(Context context)
        {
            _context = context;
        }

        public void CreateService(CreateServiceDto serviceDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteService(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            string query = "Select * From Service";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public Task<GetByIdServiceDto> GetServiceById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateService(UpdateServiceDto serviceDto)
        {
            throw new NotImplementedException();
        }
    }
}
