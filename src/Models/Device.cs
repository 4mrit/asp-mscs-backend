using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
namespace mscs.Models;
public class Device {

  // [Column (string name, Properties:[Order = int],[TypeName = string])
  [Column("id")]
  public int Id { get; set; }

  [Column("name")]
  public string? DeviceName { get; set; }

  [Column("mac_address")]
  [MaxLength(20)]
  public string macAddress { get; set; } = null!;

  [Column("is_expired")]
  public bool isExpired { get; set; } = true;
  public override string ToString() {
    return "id : " + Id + "  Name: " + DeviceName;
  }
}
public class DeviceDTORequest {
  public string MacAddress { get; set; } = null!;
  public bool? isExpired { get; set; }
  public string? deviceName { get; set; }
}
public class DeviceDTOResponse {
  public int Id { get; set; }
  public string DeviceName { get; set; } = null!;
  public string MacAddress { get; set; } = null!;
  public bool isExpired { get; set; }
}
