﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Samurai.Repo.Data;

#nullable disable

namespace Samurai.Repo.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240425065025_war3")]
    partial class war3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KrigerSamurais", b =>
                {
                    b.Property<int>("KrigereId")
                        .HasColumnType("int");

                    b.Property<int>("SamuraisId")
                        .HasColumnType("int");

                    b.HasKey("KrigereId", "SamuraisId");

                    b.HasIndex("SamuraisId");

                    b.ToTable("KrigerSamurais");
                });

            modelBuilder.Entity("Samurai.Repo.Models.Kriger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kills")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kriger");
                });

            modelBuilder.Entity("Samurai.Repo.Models.Ninja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weapon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ninjas");
                });

            modelBuilder.Entity("Samurai.Repo.Models.Samurais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Samurais");
                });

            modelBuilder.Entity("Samurai.Repo.Models.TestModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("TestModels");
                });

            modelBuilder.Entity("Samurai.Repo.Models.Viking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Mead")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vikings");
                });

            modelBuilder.Entity("Samurai.Repo.Models.War", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NinjasId")
                        .HasColumnType("int");

                    b.Property<int>("VikingsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NinjasId");

                    b.HasIndex("VikingsId");

                    b.ToTable("Wars");
                });

            modelBuilder.Entity("KrigerSamurais", b =>
                {
                    b.HasOne("Samurai.Repo.Models.Kriger", null)
                        .WithMany()
                        .HasForeignKey("KrigereId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Samurai.Repo.Models.Samurais", null)
                        .WithMany()
                        .HasForeignKey("SamuraisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Samurai.Repo.Models.War", b =>
                {
                    b.HasOne("Samurai.Repo.Models.Ninja", "Ninjas")
                        .WithMany("Wars")
                        .HasForeignKey("NinjasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Samurai.Repo.Models.Viking", "Vikings")
                        .WithMany("Wars")
                        .HasForeignKey("VikingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ninjas");

                    b.Navigation("Vikings");
                });

            modelBuilder.Entity("Samurai.Repo.Models.Ninja", b =>
                {
                    b.Navigation("Wars");
                });

            modelBuilder.Entity("Samurai.Repo.Models.Viking", b =>
                {
                    b.Navigation("Wars");
                });
#pragma warning restore 612, 618
        }
    }
}