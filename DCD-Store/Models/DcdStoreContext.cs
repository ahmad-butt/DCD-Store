using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using post_add.Models;

namespace DCD_Store.Models;

public partial class DcdStoreContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Add> Adds { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost; Database=DCD_Store; User Id=sa; Password=132qweasd; TrustServerCertificate=True");
}
