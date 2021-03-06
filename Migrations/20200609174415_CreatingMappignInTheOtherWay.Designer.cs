﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Myo.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Myo.Migrations
{
    [DbContext(typeof(MyoContext))]
    [Migration("20200609174415_CreatingMappignInTheOtherWay")]
    partial class CreatingMappignInTheOtherWay
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "5.0.0-preview.4.20220.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Myo.Models.Checkpoint", b =>
                {
                    b.Property<int>("IdCheckpoint")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("MyoIdMyo")
                        .HasColumnType("integer");

                    b.Property<string>("TestDescription")
                        .HasColumnType("text");

                    b.HasKey("IdCheckpoint");

                    b.HasIndex("MyoIdMyo");

                    b.ToTable("Checkpoints");
                });

            modelBuilder.Entity("Myo.Models.Myo", b =>
                {
                    b.Property<int>("IdMyo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Goal")
                        .HasColumnType("text");

                    b.Property<int?>("OwnerIdUser")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("IdMyo");

                    b.HasIndex("OwnerIdUser");

                    b.ToTable("Myos");
                });

            modelBuilder.Entity("Myo.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("IdUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Myo.Models.Checkpoint", b =>
                {
                    b.HasOne("Myo.Models.Myo", null)
                        .WithMany("CheckpointList")
                        .HasForeignKey("MyoIdMyo");
                });

            modelBuilder.Entity("Myo.Models.Myo", b =>
                {
                    b.HasOne("Myo.Models.User", "Owner")
                        .WithMany("MyoList")
                        .HasForeignKey("OwnerIdUser");
                });
#pragma warning restore 612, 618
        }
    }
}
