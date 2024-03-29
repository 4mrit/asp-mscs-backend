//----Format_of_request-------------//
//  {
//    "client_mac_address": "40:F5:20:23:01:2E";
//  }
//----------------------------------//

//-----format of response---------//
// {
// "status": true,
// "expired": true,
// "mac_address": "40:F5:20:23:01:2E",ssresponse["AP_password"]
// "expiry_date": {
//     "year": 2023,
//     "month": 4,
//     "day": 23
// }
//---------------------------------//

using mscs.Services;
using mscs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
namespace mscs.Controllers;

public class DeviceDTO
{
  public string MacAddress { get; set; }
  public bool isExpired { get; set; }
}

[Route("api/[controller]")]
[ApiController]
public class DevicesController : ControllerBase
{
  public DataBaseDeviceService DeviceService { get; }
  public DevicesController(DataBaseDeviceService deviceService)
  {
    this.DeviceService = deviceService;
  }

  [HttpGet]
  public IEnumerable<Device> Get() { return DeviceService.GetAllDevices(); }

  [HttpGet("{MacAddress}")]
  public DeviceDTO GetDeviceUsingMacAddress(string MacAddress)
  {
    var device = DeviceService.GetDeviceUsingMacAddress(MacAddress);
    DeviceDTO deviceDto = new DeviceDTO();
    deviceDto.MacAddress = device.macAddress;
    deviceDto.isExpired = false;
    return deviceDto;
  }
}
