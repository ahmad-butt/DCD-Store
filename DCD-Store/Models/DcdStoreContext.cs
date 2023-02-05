using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DCD_Store.Models;

public partial class DcdStoreContext : DbContext
{
    public DbSet<User> Users { get; set; }
    //    public DcdStoreContext()
    //    {
    //    }

    //    public DcdStoreContext(DbContextOptions<DcdStoreContext> options)
    //        : base(options)
    //    {
    //    }

    //    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost; Database=DCD_Store; User Id=sa; Password=rootroot123; TrustServerCertificate=True");
}
