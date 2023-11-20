using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class TripsDbContext : DbContext
{
    public TripsDbContext()
    {
    }

    public TripsDbContext(DbContextOptions<TripsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kind> Kinds { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Database=TripsDB; Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kind>(entity =>
        {
            entity.ToTable("kinds");

            entity.Property(e => e.KindId).HasColumnName("kind_id");
            entity.Property(e => e.KindName)
                .HasMaxLength(15)
                .HasColumnName("kind_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("orders");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderDate)
                .HasColumnType("date")
                .HasColumnName("order_date");
            entity.Property(e => e.OrderPlaces).HasColumnName("order_places");
            entity.Property(e => e.OrderTime).HasColumnName("order_time");
            entity.Property(e => e.TripId).HasColumnName("trip_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Trip).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TripId)
                .HasConstraintName("FK_orders_trips");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_orders_users");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.ToTable("trips");

            entity.Property(e => e.TripId).HasColumnName("trip_id");
            entity.Property(e => e.KindId).HasColumnName("kind_id");
            entity.Property(e => e.TripAvailability).HasColumnName("trip_availability");
            entity.Property(e => e.TripDate)
                .HasColumnType("date")
                .HasColumnName("trip_date");
            entity.Property(e => e.TripDestination)
                .HasMaxLength(15)
                .HasColumnName("trip_destination");
            entity.Property(e => e.TripHour).HasColumnName("trip_hour");
            entity.Property(e => e.TripImage)
                .HasMaxLength(25)
                .HasColumnName("trip_image");
            entity.Property(e => e.TripPrice)
                .HasColumnType("money")
                .HasColumnName("trip_price");
            entity.Property(e => e.TripTime).HasColumnName("trip_time");

            entity.HasOne(d => d.Kind).WithMany(p => p.Trips)
                .HasForeignKey(d => d.KindId)
                .HasConstraintName("FK_trips_kinds");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserFirstAid).HasColumnName("user_first_aid");
            entity.Property(e => e.UserFirstName)
                .HasMaxLength(15)
                .HasColumnName("user_first_name");
            entity.Property(e => e.UserLastName)
                .HasMaxLength(15)
                .HasColumnName("user_last_name");
            entity.Property(e => e.UserMail)
                .HasMaxLength(20)
                .HasColumnName("user_mail");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(10)
                .HasColumnName("user_password");
            entity.Property(e => e.UserPhon)
                .HasMaxLength(10)
                .HasColumnName("user_phon");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
