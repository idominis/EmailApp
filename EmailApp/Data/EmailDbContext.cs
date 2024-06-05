﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using EmailApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailApp.Data;

public partial class EmailDbContext : DbContext
{
    public EmailDbContext(DbContextOptions<EmailDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Email> Emails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Email>(entity =>
        {
            entity.HasKey(e => e.EmailId).HasName("PK_dbo_EmailId");

            entity.Property(e => e.CcEmails).HasMaxLength(255);
            entity.Property(e => e.Content)
                .IsRequired()
                .HasColumnType("ntext");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CreatedDate ");
            entity.Property(e => e.FromEmail)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Importance)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Subject)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.ToEmail)
                .IsRequired()
                .HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}