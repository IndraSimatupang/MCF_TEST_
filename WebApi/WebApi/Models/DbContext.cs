using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MsUser>().HasData(
                new MsUser { user_id = 2, user_name = "user2" },
                new MsUser { user_id = 3, user_name = "user3" }

            );

            modelBuilder.Entity<MsStorageLocation>().HasData(
                new MsStorageLocation { location_id = 2, location_name = "Location A" },
                new MsStorageLocation { location_id = 3, location_name = "Location B" }

            );
        }
    }

    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<TrBpkb> tr_bpkbs { get; set; }
        public DbSet<MsStorageLocation> ms_storage_location { get; set; }
        public DbSet<MsUser> ms_user { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TrBpkb>(entity =>
            {
                entity.HasKey(e => e.AgreementNumber);

            });

            modelBuilder.Entity<MsStorageLocation>(entity =>
            {
                entity.HasKey(e => e.location_id);

            });

            modelBuilder.Entity<MsUser>(entity =>
            {
                entity.HasKey(e => e.user_id);

            });

            modelBuilder.Seed();
        }
    }
}