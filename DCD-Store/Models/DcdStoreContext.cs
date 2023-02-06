using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using post_add.Models;
using System.Web;

namespace DCD_Store.Models;

public partial class DcdStoreContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Add> Adds { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost; Database=DCD_Store; User Id=sa; Password=rootroot123; TrustServerCertificate=True");

    public override int SaveChanges()
    {
        var tracker = ChangeTracker;

        foreach (var entry in tracker.Entries())
        {
            if(entry.Entity is FullAuditModel)
            {
                var referenceEntity = entry.Entity as FullAuditModel;
                switch (entry.State)
                {
                    case EntityState.Added:
                        referenceEntity.CreatedDate = DateTime.Now;
                        referenceEntity.IsActive = true;
                        break;
                    case EntityState.Modified:
                        referenceEntity.LastModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        referenceEntity.IsActive = false;
                        break;
                    default:
                        break;
                }
            }
        }
        return base.SaveChanges();
    }
}
