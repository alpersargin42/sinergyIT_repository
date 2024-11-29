using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository_Pratik.Databases.Models;

namespace Repository_Pratik.Databases.DbContext
{
    public class UrunDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        // dbcontext methodu
        public UrunDbContext(DbContextOptions<UrunDbContext> options) : base(options) { }

        public DbSet<Urun> Urunler { get; set; }
    }
}
