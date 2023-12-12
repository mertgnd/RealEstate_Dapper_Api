using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();
        void CreateService(CreateServiceDto serviceDto);
        void UpdateService(UpdateServiceDto serviceDto);
        Task<GetByIdServiceDto> GetServiceById(int id);
        void DeleteService(int id); 
    }
}
