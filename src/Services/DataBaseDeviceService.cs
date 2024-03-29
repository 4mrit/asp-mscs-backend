using mscs.Models;
using mscs.Data;
using System.Net.NetworkInformation;
namespace mscs.Services
{
  public class DataBaseDeviceService
  {
    public IWebHostEnvironment WebHostEnvironment { get; }
    private readonly MscsContext _context;

    public DataBaseDeviceService(IWebHostEnvironment webHostEnvironment,
                                 MscsContext context)
    {
      this.WebHostEnvironment = webHostEnvironment;
      this._context = context;
    }

    public IEnumerable<Device> GetAllDevices()
    {
      IEnumerable<Device> devices = _context.Devices;
      return devices;
    }
    public Device GetDeviceUsingMacAddress(string MacAddress)
    {
      Console.WriteLine("finding address : " + MacAddress.ToString());
      // Device device = _context.Devices.FirstOrDefault(
      //     d => d.macAddressImproved.ToString().Equals(MacAddress.TcoString()));
      Device device =
          _context.Devices.FirstOrDefault(d => d.macAddress.Equals(MacAddress));
      if (device == null)
      {
        return new Device();
      }
      return device;
    }
  }
}
