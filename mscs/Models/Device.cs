using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data;

namespace mscs.Models{
    public class Device{

        // [Column (string name, Properties:[Order = int],[TypeName = string])
        [Column("id")]
        public string Id { get; set;}="NOT FOUND";

        [Column("name")]
        public string DeviceName { get; set; } = "-";
        // private string name;
        // public string DeviceName
        // {
        //     get { return name; }
        //     set { name = value; }
        // }

        public override string ToString(){
            return "id : " + Id + "  Name: "+DeviceName;
        }
    }
}