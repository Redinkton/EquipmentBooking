using Core.Entities;

namespace Infrastructure.Repository.Interface
{
    public interface IServiceRepository
    {
        Task<Guid> Create(ServiceObject serviceObject);
        Task<Guid?> Update(ServiceObject serviceObject);
        Task<ServiceObject> Booking(ServiceObject serviceObject);
    }
}
