﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagmentApplication.Persistence.DbContexts;

#nullable disable

namespace TaskManagmentApplication.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskManagmentApplication.Domain.Entities.Exercise", b =>
                {
                    b.Property<int>("Taskid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TASKID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Taskid"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<DateTime>("Enddate")
                        .HasColumnType("date")
                        .HasColumnName("ENDDATE");

                    b.Property<DateTime>("Startdate")
                        .HasColumnType("date")
                        .HasColumnName("STARTDATE");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("STATUS");

                    b.HasKey("Taskid");

                    b.ToTable("EXERCISES", (string)null);
                });

            modelBuilder.Entity("TaskManagmentApplication.Domain.Entities.Image", b =>
                {
                    b.Property<int>("Imageid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IMAGEID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Imageid"));

                    b.Property<string>("Imageurl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("IMAGEURL");

                    b.Property<int>("Taskid")
                        .HasColumnType("int")
                        .HasColumnName("TASKID");

                    b.HasKey("Imageid");

                    b.HasIndex("Taskid");

                    b.ToTable("IMAGES", (string)null);
                });

            modelBuilder.Entity("TaskManagmentApplication.Domain.Entities.Taskassign", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("Taskid")
                        .HasColumnType("int")
                        .HasColumnName("TASKID");

                    b.Property<int>("Userid")
                        .HasColumnType("int")
                        .HasColumnName("USERID");

                    b.HasKey("Id");

                    b.HasIndex("Taskid");

                    b.HasIndex("Userid");

                    b.ToTable("TASKASSIGNS", (string)null);
                });

            modelBuilder.Entity("TaskManagmentApplication.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Confirmpassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CONFIRMPASSWORD");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("FIRSTNAME");

                    b.Property<string>("Lastname")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("LASTNAME");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PASSWORD");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("ROLE");

                    b.HasKey("Id");

                    b.ToTable("USERS", (string)null);
                });

            modelBuilder.Entity("TaskManagmentApplication.Domain.Entities.Image", b =>
                {
                    b.HasOne("TaskManagmentApplication.Domain.Entities.Exercise", "Task")
                        .WithMany("Images")
                        .HasForeignKey("Taskid")
                        .IsRequired()
                        .HasConstraintName("FK_Images_Exercises");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("TaskManagmentApplication.Domain.Entities.Taskassign", b =>
                {
                    b.HasOne("TaskManagmentApplication.Domain.Entities.Exercise", "Task")
                        .WithMany("Taskassigns")
                        .HasForeignKey("Taskid")
                        .IsRequired()
                        .HasConstraintName("FK__TASKASSIG__USERI__2F10007B");

                    b.HasOne("TaskManagmentApplication.Domain.Entities.User", "User")
                        .WithMany("Taskassigns")
                        .HasForeignKey("Userid")
                        .IsRequired()
                        .HasConstraintName("FK__TASKASSIG__USERI__300424B4");

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManagmentApplication.Domain.Entities.Exercise", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Taskassigns");
                });

            modelBuilder.Entity("TaskManagmentApplication.Domain.Entities.User", b =>
                {
                    b.Navigation("Taskassigns");
                });
#pragma warning restore 612, 618
        }
    }
}