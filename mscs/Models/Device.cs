using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace mscs.Models{
    public class Device{

        // [Column (string name, Properties:[Order = int],[TypeName = string])
        [Column("id")]
        public int Id { get; set;}

        [Column("name")]
        public string DeviceName { get; set; } = null!;

        [Column("mac_address")]
        public string macAddress { get; set; } = null!;

        // allow null
        // public string? Address { get; set; }
        // doesnt allow null
        // public string Address { get; set; } = null!;

        public override string ToString(){
            return "id : " + Id + "  Name: "+DeviceName;
        }
    }
}