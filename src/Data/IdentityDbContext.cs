using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mscs.Models;
namespace mscs.Data
{
  class AppDbContext
  (DbContextOptions<AppDbContext> options) : IdentityDbContext<MyUser>(options)
  { }
}
