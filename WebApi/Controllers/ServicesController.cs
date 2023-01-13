using AutoMapper;
using Core.Entities;
using WebApi.DTOs;
using Infrastructure.Repository.Interface;
using Microsoft.AspNetCore.Mvc;


namespace EquipmentBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        
        public ServicesController(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("services/create()")]
        public async Task<object> Create(ServiceObjectCrUpDto serviceObjectDto)
        {
            var id = await _serviceRepository.Create(_mapper.Map<ServiceObject>(serviceObjectDto));

            return (new { id = id });
        }
        [HttpPost]
        [Route("services/update")]
        public async Task<object> Update(ServiceObjectCrUpDto serviceObjectDto)
        {
            var id = await _serviceRepository.Update(_mapper.Map<ServiceObject>(serviceObjectDto));

            if (id == null) 
                return "Service Object not found";

            return (new { id = id });

        }
        [HttpPost]
        [Route("services/booking")]
        public async Task<object> Booking(ServiceObjectBoDto serviceObjectDto)
        {
            var result = await _serviceRepository.Booking(_mapper.Map<ServiceObject>(serviceObjectDto));

            if (result.Ok == true)
            {
                return (new { ok =result.Ok, amount = result.Amount });
            }
            else
            {
               return (new { error = result.Error});
            }
        }
    }
}
