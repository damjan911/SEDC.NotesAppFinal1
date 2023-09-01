﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEDC.NotesAppFinal1.DataAccess;

#nullable disable

namespace SEDC.NotesAppFinal1.DataAccess.Migrations
{
    [DbContext(typeof(NotesAppFinal1DbContext))]
    partial class NotesAppFinal1DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SEDC.NotesAppFinal1.Domain.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("Tag")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Userid");

                    b.ToTable("Notes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Priority = 3,
                            Tag = 1,
                            Text = "Buy groceries for the week.",
                            Userid = 2
                        },
                        new
                        {
                            Id = 2,
                            Priority = 2,
                            Tag = 3,
                            Text = "Prepare presentation for client meeting.",
                            Userid = 1
                        },
                        new
                        {
                            Id = 3,
                            Priority = 1,
                            Tag = 2,
                            Text = "Call plumber to fix the leaking faucet.",
                            Userid = 3
                        },
                        new
                        {
                            Id = 4,
                            Priority = 2,
                            Tag = 3,
                            Text = "Research new recipe ideas for dinner party.",
                            Userid = 2
                        });
                });

            modelBuilder.Entity("SEDC.NotesAppFinal1.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 25,
                            FirstName = "Bojan",
                            LastName = "Damchevski",
                            UserName = "BojanDamchevski"
                        },
                        new
                        {
                            Id = 2,
                            Age = 28,
                            FirstName = "Damjan",
                            LastName = "Krstevski",
                            UserName = "DamjanKrstevski"
                        },
                        new
                        {
                            Id = 3,
                            Age = 20,
                            FirstName = "Antonio",
                            LastName = "Novoselski",
                            UserName = "AntonioNovoselski"
                        });
                });

            modelBuilder.Entity("SEDC.NotesAppFinal1.Domain.Models.Note", b =>
                {
                    b.HasOne("SEDC.NotesAppFinal1.Domain.Models.User", "User")
                        .WithMany("Notes")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SEDC.NotesAppFinal1.Domain.Models.User", b =>
                {
                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
