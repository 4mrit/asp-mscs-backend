using mscs.Models;
using mscs.Data;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
namespace mscs.Services;
public class DataBaseDeviceService {
  public IWebHostEnvironment WebHostEnvironment { get; }
  private readonly MscsContext _context;

  public DataBaseDeviceService(IWebHostEnvironment webHostEnvironment,
                               MscsContext context) {
    this.WebHostEnvironment = webHostEnvironment;
    this._context = context;
  }

  public IEnumerable<Device> GetAllDevices() {
    IEnumerable<Device> devices = _context.Devices;
    return devices;
  }

  public DeviceDTOResponse GetDeviceUsingMacAddress(string MacAddress) {
    Device device =
        _context.Devices.FirstOrDefault(d => d.macAddress.Equals(MacAddress));
    if (device == null) {
      return new DeviceDTOResponse();
    }
    return mapDeviceToDeviceDTOResponse(device);
  }

  public DeviceDTOResponse GetDeviceUsingId(int Id) {
    Device device = _context.Devices.Find(Id);
    if (device == null) {
      return new DeviceDTOResponse();
    }
    return mapDeviceToDeviceDTOResponse(device);
  }

  public async Task<DeviceDTOResponse>
  AddDevice(DeviceDTORequest deviceDTORequest) {
    var device = mapDeviceDTORequestToDevice(deviceDTORequest);
    await _context.AddAsync(device);
    await _context.SaveChangesAsync();
    return mapDeviceToDeviceDTOResponse(device);
  }

  public async Task<Device>
  UpdateDeviceUsingId(int DeviceId, DeviceDTORequest deviceDTORequest) {
    if (deviceDTORequest == null) {
      throw new Exception($"item info was not supplied");
    }
    var device = mapDeviceDTORequestToDevice(deviceDTORequest);
    device.Id = DeviceId;

    _context.Devices.Attach(device);
    _context.Entry(device).Property(x => x.macAddress).IsModified = true;
    if (deviceDTORequest.deviceName is not null) {
      _context.Entry(device).Property(x => x.DeviceName).IsModified = true;
    }
    if (deviceDTORequest.isExpired.HasValue) {
      Console.WriteLine("is expired changed");
      _context.Entry(device).Property(x => x.isExpired).IsModified = true;
    }
    await _context.SaveChangesAsync();
    return device;
  }

  public async Task<Device> DeleteDevice(int DeviceId) {
    await _context.Devices.Where(device => device.Id == DeviceId)
        .ExecuteDeleteAsync();
    return new Device();
  }

  public DeviceDTOResponse mapDeviceToDeviceDTOResponse(Device device) {
    return new DeviceDTOResponse() {
      Id = device.Id,
      MacAddress = device.macAddress,
      isExpired = device.isExpired,
      DeviceName = device.DeviceName,
    };
  }
  public Device mapDeviceDTORequestToDevice(DeviceDTORequest deviceDTORequest) {
    Device device = new Device() { macAddress = deviceDTORequest.MacAddress };

    if (deviceDTORequest.deviceName is not null)
      device.DeviceName = deviceDTORequest.deviceName;

    if (deviceDTORequest.isExpired.HasValue)
      device.isExpired = (bool)deviceDTORequest.isExpired;

    return device;
    // Console.WriteLine("Map device -> dto request returned :");
    // Console.WriteLine("Id : " + device.Id);
    // Console.WriteLine("Device : " + device.DeviceName);
    // Console.WriteLine("Mac : " + device.macAddress);
    // Console.WriteLine("IsExpired : " + device.isExpired);
  }
}
