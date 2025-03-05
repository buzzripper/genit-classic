using System;
using System.Collections.Generic;
using Dyvenix.App1.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dyvenix.App1.Data;

public partial class Db : DbContext
{
    public Db(DbContextOptions<Db> options)
        : base(options)
    {
    }

    public virtual DbSet<AccessClaim> AccessClaims { get; set; }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<LogEvent> LogEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccessClaim>(entity =>
        {
            entity.ToTable("AccessClaim");

            entity.HasIndex(e => e.AppUserId, "IX_AccessClaim_AppUserId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClaimName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.ClaimValue)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.AppUser).WithMany(p => p.AccessClaims).HasForeignKey(d => d.AppUserId);
        });

        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.ToTable("AppUser");

            entity.HasIndex(e => e.Email, "IX_AppUser_Email");

            entity.HasIndex(e => e.IdentityId, "IX_AppUser_IdentityId");

            entity.HasIndex(e => e.LastName, "IX_AppUser_LastName");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.IdentityId)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<LogEvent>(entity =>
        {
            entity.ToTable("LogEvents", "Logs");

            entity.Property(e => e.Application).HasMaxLength(200);
            entity.Property(e => e.CorrelationId).HasMaxLength(50);
            entity.Property(e => e.Source).HasMaxLength(200);
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
