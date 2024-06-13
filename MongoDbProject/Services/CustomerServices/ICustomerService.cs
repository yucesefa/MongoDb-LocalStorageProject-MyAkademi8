using MongoDbProject.Dtos.CustomerDto;
using MongoDbProject.Dtos.CustomerServices;

namespace MongoDbProject.Services.CustomerServices
{
    public interface ICustomerService
    {
        Task<List<ResultCustomerDto>> GetAllCustomerAsync();
        Task CreateCustomerAsync(CreateCustomerDto createUpdateDto);
        Task UpdateCustomerAsync(UpdateCustomerDto updateUpdateDto);
        Task DeleteCustomerAsync(string id);
        Task<GetByIdCustomerDto> GetByIdCustomerAsync(string id);
    }
}
