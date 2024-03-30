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
using System.ComponentModel.DataAnnotations;
using mscs.Extensions;
namespace mscs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DevicesController : ControllerBase {
  public DataBaseDeviceService DeviceService { get; }
  public DevicesController(DataBaseDeviceService deviceService) {
    this.DeviceService = deviceService;
  }

  [HttpGet]
  public IEnumerable<Device> Get() { return DeviceService.GetAllDevices(); }

  [HttpGet("MacAddress/{MacAddress}")]
  public DeviceDTOResponse GetDeviceUsingMacAddress(string MacAddress) {
    var device = DeviceService.GetDeviceUsingMacAddress(MacAddress);
    return device;
  }
  [HttpGet("DeviceId/{DeviceId}")]
  public DeviceDTOResponse GetDeviceUsingId(int DeviceId) {
    var device = DeviceService.GetDeviceUsingId(DeviceId);
    return device;
  }

  [HttpPut("{DeviceId}")]
  public async Task<ActionResult<DeviceDTOResponse>>
  UpdateDevice(int DeviceId, DeviceDTORequest deviceDTORequest) {
    if (await DeviceService.UpdateDeviceUsingId(DeviceId, deviceDTORequest) ==
        null) {
      return NotFound();
    }
    return NoContent();
  }

  [HttpPost]
  public async Task<ActionResult<DeviceDTOResponse>>
  AddDevice(DeviceDTORequest deviceDTORequest) {
    DeviceDTOResponse AddedDevice =
        await DeviceService.AddDevice(deviceDTORequest);
    return CreatedAtAction(
        actionName: nameof(GetDeviceUsingId),
        controllerName: ControllerContext.GetControllerName(),
        routeValues: new { DeviceId = AddedDevice.Id }, value: AddedDevice);
  }

  [HttpDelete("{DeviceId}")]
  public async Task<ActionResult> DeleteDevice(int DeviceId) {
    await DeviceService.DeleteDevice(DeviceId);
    return NoContent();
  }
}
