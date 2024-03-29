using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
namespace mscs.Models
{
  public class Device
  {

    // [Column (string name, Properties:[Order = int],[TypeName = string])
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string DeviceName { get; set; } = null!;

    [Column("mac_address")]
    [MaxLength(20)]
    public string macAddress { get; set; } = null!;

    [Column("Improved_mac_address")]
    public PhysicalAddress macAddressImproved { get; set; } = null!;
    // allow null
    // public string? Address { get; set; }
    // doesnt allow null
    // public string Address { get; set; } = null!;

    public override string ToString()
    {
      return "id : " + Id + "  Name: " + DeviceName;
    }
  }
}
