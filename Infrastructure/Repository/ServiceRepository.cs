using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _appDbContext;
        public static Dictionary<Guid, int> booking = new Dictionary<Guid, int>();
        public static ServiceObject memoryServiceObject = new ServiceObject();
        public ServiceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Guid> Create(ServiceObject serviceObject)
        {
            await _appDbContext.AddAsync(serviceObject);
            await _appDbContext.SaveChangesAsync();
            
            return serviceObject.Id;
        }

        public async Task<Guid?> Update(ServiceObject serviceObject)
        {
            var search = await _appDbContext.ServiceObjects
            .Where(b => b.ServiceName == serviceObject.ServiceName)
            .FirstOrDefaultAsync();

            if (search != null)
            {
                search.Amount = serviceObject.Amount;
                search.ServiceName = serviceObject.ServiceName;
                await _appDbContext.SaveChangesAsync();
                return search.Id;
            }
            return null;
        }
        public async Task<ServiceObject> Booking(ServiceObject serviceObject)
        {
            //проверка на существование такого предмета в справочнике
            if (_appDbContext.ServiceObjects.First(t => t.Id == serviceObject.Id).Id != serviceObject.Id)
            {
                memoryServiceObject.Ok = false;
                memoryServiceObject.Error = "Такого Id не существует";
                return memoryServiceObject;
            }

            //Проверка, есть ли брони на этот товар
            //если отсутствуют, то добавляем id и кол-во
            if (booking.ContainsKey(serviceObject.Id) == false)
            {
                booking.Add(serviceObject.Id, _appDbContext.ServiceObjects.Find(serviceObject.Id).Amount);
            }

            if (booking.ContainsKey(serviceObject.Id) == true & booking[serviceObject.Id] <= 0)
            {
                memoryServiceObject.Error = "Закончилось оборудование!";
                memoryServiceObject.Ok = false;
                memoryServiceObject.Amount = booking[serviceObject.Id];
                return memoryServiceObject;
            }
            else if (booking.ContainsKey(serviceObject.Id) == true & booking[serviceObject.Id] < serviceObject.Amount)
            {
                memoryServiceObject.Error = "У нас нет столько оборудования!";
                memoryServiceObject.Ok = false;
                memoryServiceObject.Amount = booking[serviceObject.Id];
                return memoryServiceObject;
            }
            else
            {
                booking[serviceObject.Id] -= serviceObject.Amount;
                memoryServiceObject.Ok = true;
                memoryServiceObject.Amount = booking[serviceObject.Id];
                return memoryServiceObject;
            }
        }
    }
}