﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using İleri_Veri_tabani.Data;

#nullable disable

namespace İleri_Veri_tabani.Migrations
{
    [DbContext(typeof(PlayerDbContext))]
    partial class PlayerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("İleri_Veri_tabani.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerID"));

                    b.Property<int>("PlayerAge")
                        .HasColumnType("int");

                    b.Property<int>("PlayerMinutesPlayed")
                        .HasColumnType("int");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerPosition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerSquad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PlayerTackles")
                        .HasColumnType("real");

                    b.Property<float>("PlayerTouches")
                        .HasColumnType("real");

                    b.HasKey("PlayerID");

                    b.ToTable("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
