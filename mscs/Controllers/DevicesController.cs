using Microsoft.AspNetCore.Mvc;
using mscs.Services;
using mscs.Models;

namespace mscs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        public DataBaseDeviceService DeviceService { get;}
        public DevicesController(DataBaseDeviceService deviceService)
        {
            this.DeviceService = deviceService;
        }

        [HttpGet]
        public IEnumerable<Device> Get(){
            return DeviceService.GetAllDevices();
        }
    }
}
