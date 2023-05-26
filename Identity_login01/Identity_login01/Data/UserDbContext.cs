using System;
using System.Collections.Generic;
using Identity_login01.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity_login01.Data;

public partial class UserDbContext : IdentityDbContext<T_MUSERKANRI>
{
    public UserDbContext()
    {
    }

    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<T_MUSERKANRI> T_MUSERKANRIs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = WebApplication.CreateBuilder();
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseOracle(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("RENKEI")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<T_MUSERKANRI>(entity =>
        {
            entity.HasKey(e => e.E_USERID).HasName("PK_ASPNETUSERS");

            entity.Property(e => e.E_GROUPMDMGETSYSFLAG).HasDefaultValueSql("'0'");
            entity.Property(e => e.E_PASSWORDGONYUURYOKUKAISUU).HasDefaultValueSql("0");
            entity.Property(e => e.E_SAKUJOFLAG).HasDefaultValueSql("'0'");
            entity.Property(e => e.E_SIYOUFUKAFLAG).HasDefaultValueSql("'0'");
            entity.Property(e => e.E_TOUROKUKOUSINNITIJI).HasDefaultValueSql("SYSDATE ");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
