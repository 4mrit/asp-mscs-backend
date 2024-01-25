using mscs.Models;
using mscs.Data;


namespace mscs.Services{
    public class DataBaseDeviceService{
        public IWebHostEnvironment WebHostEnvironment { get;}

        private readonly MscsContext _context;

        //constructor
        public DataBaseDeviceService(IWebHostEnvironment webHostEnvironment, MscsContext context ){
            this.WebHostEnvironment = webHostEnvironment;
            this._context = context;
        }
        public IEnumerable<Device> GetAllDevices(){

            // ----- fluent API ------------------//
            // var devices = _context.Devices
            //                     .Where(d=>d.DeviceName == "node")
            //                     .OrderBy(d=> d.Id)
            //                     .GroupBy(d=> d.DeviceName);
            //--------------------------------------//

            //------------ LINQ ---------------------//
            // var devices = from device in _context.Devices
            //                 where device.DeviceName == "node"
            //                 orderby device.Id
            //                 group device by device.DeviceName into newGroup
            //                 select newGroup;
            //----------------------------------------//

            IEnumerable<Device> devices = _context.Devices;
            return devices;
        }
    }
}