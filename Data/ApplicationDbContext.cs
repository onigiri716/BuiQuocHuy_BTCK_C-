using BuiQuocHuy_BTCK_C_.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BuiQuocHuy_BTCK_C_.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<ThongBao> ThongBaos { get; set; }
        public DbSet<TheLoai> TheLoais { get; set; }
    } 
}
