using MySqlConnector;
using mscs.Models;

namespace mscs.Services{
    public class DataBaseDeviceService{
        
        public IWebHostEnvironment WebHostEnvironment { get;}
        public string ConnectionString { get; set; } = ".";

        //constructor
        public DataBaseDeviceService(IWebHostEnvironment webHostEnvironment , IConfiguration configuration){
            this.WebHostEnvironment = webHostEnvironment;
            this.ConnectionString = configuration.GetConnectionString("MySqlConnectionString");
        }
        

        private MySqlConnection GetMySqlConnection(){
            return new MySqlConnection(ConnectionString);
        }

        public IEnumerable<Device> GetAllDevices(){
            using (MySqlConnection conn = GetMySqlConnection())
            {
                try{
                    conn.Open();
                }catch(MySqlException e){
                    Console.WriteLine("Exception occured" + e.Message);
                }
                
                MySqlCommand cmd = new MySqlCommand("select * from devices", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Device()
                        {
                            Id = reader["Id"].ToString(),
                            DeviceName = reader["Name"].ToString()
                        };
                    }
                }
            }
        }
    }
}