using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mscs.Services;
using mscs.Models;


namespace src.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public DataBaseDeviceService DeviceService;
    public IEnumerable<Device> Devices{get; private set;}

    public IndexModel(
        ILogger<IndexModel> logger,     
        DataBaseDeviceService deviceService)
    {
        _logger = logger;
        DeviceService = deviceService;
    }

    public void OnGet()
    {
        Devices = DeviceService.GetAllDevices();
    }
}
