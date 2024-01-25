using Microsoft.EntityFrameworkCore;
using mscs.Models;


namespace mscs.Data{
    public class MscsContext : DbContext
    {
        public MscsContext(DbContextOptions options) : base(options) {}
        public DbSet<Device> Devices { get; set; } =null!;
    }
}