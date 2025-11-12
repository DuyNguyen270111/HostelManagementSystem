using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HostelManagement.BusinessObject;

namespace HostelManagement.Models;

public partial class ProjectttContext : DbContext
{
    public ProjectttContext()
    {
    }

    public ProjectttContext(DbContextOptions<ProjectttContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Allotment> Allotments { get; set; }

    public virtual DbSet<Complaint> Complaints { get; set; }

    public virtual DbSet<Hostel> Hostels { get; set; }

    public virtual DbSet<HostelUser> HostelUsers { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Visitor> Visitors { get; set; }

    public virtual DbSet<Warden> Wardens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Projecttt;Integrated Security=True;TrustServerCertificate=True\n");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allotment>(entity =>
        {
            entity.HasKey(e => e.AllotmentId).HasName("PK__allotmen__18DE9A964116240E");

            entity.ToTable("allotments");

            entity.Property(e => e.AllotmentId).HasColumnName("allotment_id");
            entity.Property(e => e.AllotDate).HasColumnName("allot_date");
            entity.Property(e => e.LeaveDate).HasColumnName("leave_date");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Room).WithMany(p => p.Allotments)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__allotment__room___440B1D61");

            entity.HasOne(d => d.Student).WithMany(p => p.Allotments)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__allotment__stude__4316F928");
        });

        modelBuilder.Entity<Complaint>(entity =>
        {
            entity.HasKey(e => e.ComplaintId).HasName("PK__complain__A771F61C010674CA");

            entity.ToTable("complaints");

            entity.Property(e => e.ComplaintId).HasColumnName("complaint_id");
            entity.Property(e => e.DateFiled).HasColumnName("date_filed");
            entity.Property(e => e.Issue)
                .HasColumnType("text")
                .HasColumnName("issue");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Room).WithMany(p => p.Complaints)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__complaint__room___4AB81AF0");

            entity.HasOne(d => d.Student).WithMany(p => p.Complaints)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__complaint__stude__49C3F6B7");
        });

        modelBuilder.Entity<Hostel>(entity =>
        {
            entity.HasKey(e => e.HostelId).HasName("PK__hostels__A3EE317ED7D0F976");

            entity.ToTable("hostels");

            entity.Property(e => e.HostelId).HasColumnName("hostel_id");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TotalRooms).HasColumnName("total_rooms");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<HostelUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__hostel_u__B9BE370FBA052B48");

            entity.ToTable("hostel_user");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__inventor__52020FDDB7B17803");

            entity.ToTable("inventory");

            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.Condition)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("condition");
            entity.Property(e => e.HostelId).HasColumnName("hostel_id");
            entity.Property(e => e.ItemName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("item_name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Hostel).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.HostelId)
                .HasConstraintName("FK__inventory__hoste__5070F446");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__payment__ED1FC9EA2C5553AB");

            entity.ToTable("payment");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Method)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("method");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Student).WithMany(p => p.Payments)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__payment__student__46E78A0C");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__rooms__19675A8A00187265");

            entity.ToTable("rooms");

            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.HostelId).HasColumnName("hostel_id");
            entity.Property(e => e.Occupied).HasColumnName("occupied");
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("room_number");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.Hostel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HostelId)
                .HasConstraintName("FK__rooms__hostel_id__3D5E1FD2");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__student__2A33069AA7CCEE6F");

            entity.ToTable("student");

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.Address)
                .HasColumnType("text")
                .HasColumnName("address");
            entity.Property(e => e.Course)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("course");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Visitor>(entity =>
        {
            entity.HasKey(e => e.VisitorId).HasName("PK__visitors__87ED1B51292AB7BE");

            entity.ToTable("visitors");

            entity.Property(e => e.VisitorId).HasColumnName("visitor_id");
            entity.Property(e => e.InTime).HasColumnName("in_time");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.OutTime).HasColumnName("out_time");
            entity.Property(e => e.Relation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("relation");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.VisitDate).HasColumnName("visit_date");

            entity.HasOne(d => d.Student).WithMany(p => p.Visitors)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__visitors__studen__4D94879B");
        });

        modelBuilder.Entity<Warden>(entity =>
        {
            entity.HasKey(e => e.WardenId).HasName("PK__warden__52CE2AA61AB08547");

            entity.ToTable("warden");

            entity.Property(e => e.WardenId).HasColumnName("warden_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.HostelId).HasColumnName("hostel_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");

            entity.HasOne(d => d.Hostel).WithMany(p => p.Wardens)
                .HasForeignKey(d => d.HostelId)
                .HasConstraintName("FK__warden__hostel_i__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
