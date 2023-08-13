using System;
using System.Collections.Generic;
using ApplicationLayer.Domain;
using ApplicationLayer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

public partial class AccountsManagerDbContext : DbContext
{
    public AccountsManagerDbContext()
    {
    }

    public AccountsManagerDbContext(DbContextOptions<AccountsManagerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PK__Account__BE2ACD6E23DC7730");

            entity.ToTable("Account");

            entity.Property(e => e.AccountNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AccountType)
                .HasConversion<string>()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.InitialBalance).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Status)
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Client).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Account__ClientI__4BAC3F29")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Client__E67E1A04DE116727");

            entity.ToTable("Client");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasConversion<string>()
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Identification)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A4B46835FA7");

            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.AvailableBalance).HasColumnName("Balance").HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.TransactionType)
                .HasConversion<string>()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("FK__Transacti__Accou__4E88ABD4")
                .OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
