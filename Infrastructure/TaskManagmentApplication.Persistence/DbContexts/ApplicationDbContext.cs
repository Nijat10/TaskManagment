using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.Domain.Entities;

namespace TaskManagmentApplication.Persistence.DbContexts
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public virtual DbSet<Exercise> Exercises { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Taskassign> Taskassigns { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.HasKey(e => e.Taskid);

                entity.ToTable("EXERCISES");

                entity.Property(e => e.Taskid).HasColumnName("TASKID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Enddate)
                    .HasColumnType("date")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("date")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Status).HasColumnName("STATUS");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("IMAGES");

                entity.Property(e => e.Imageid).HasColumnName("IMAGEID");

                entity.Property(e => e.Imageurl)
                    .HasMaxLength(200)
                    .HasColumnName("IMAGEURL");

                entity.Property(e => e.Taskid).HasColumnName("TASKID");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.Taskid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Images_Exercises");
            });

            modelBuilder.Entity<Taskassign>(entity =>
            {
                entity.ToTable("TASKASSIGNS");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Taskid).HasColumnName("TASKID");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Taskassigns)
                    .HasForeignKey(d => d.Taskid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TASKASSIG__USERI__2F10007B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Taskassigns)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TASKASSIG__USERI__300424B4");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Confirmpassword).HasColumnName("CONFIRMPASSWORD");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(100)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Password).HasColumnName("PASSWORD");

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
