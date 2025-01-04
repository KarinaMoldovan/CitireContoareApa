﻿// <auto-generated />
using System;
using CitireContoareApa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CitireContoareApa.Migrations
{
    [DbContext(typeof(CitireContoareApaContext))]
    [Migration("20250103221026_InitialCreate2")]
    partial class InitialCreate2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CitireContoareApa.Models.Contor", b =>
                {
                    b.Property<int>("ContorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContorId"));

                    b.Property<string>("NumarSerie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValoareActuala")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ContorId");

                    b.HasIndex("UserId");

                    b.ToTable("Contor");
                });

            modelBuilder.Entity("CitireContoareApa.Models.Factura", b =>
                {
                    b.Property<int>("FacturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacturaId"));

                    b.Property<int>("ContorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataEmitere")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PlataId")
                        .HasColumnType("int");

                    b.Property<decimal>("Suma")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TarifId")
                        .HasColumnType("int");

                    b.HasKey("FacturaId");

                    b.HasIndex("ContorId");

                    b.HasIndex("PlataId");

                    b.HasIndex("TarifId");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("CitireContoareApa.Models.Plata", b =>
                {
                    b.Property<int>("PlataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlataId"));

                    b.Property<DateTime>("DataPlatii")
                        .HasColumnType("datetime2");

                    b.Property<int>("FacturaId")
                        .HasColumnType("int");

                    b.Property<int>("ModalitateDePlata")
                        .HasColumnType("int");

                    b.Property<decimal>("SumaPlatita")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PlataId");

                    b.HasIndex("FacturaId");

                    b.ToTable("Plata");
                });

            modelBuilder.Entity("CitireContoareApa.Models.Tarif", b =>
                {
                    b.Property<int>("TarifId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TarifId"));

                    b.Property<DateTime>("DataInceput")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataSfarsit")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PretPeMetruCub")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TarifId");

                    b.ToTable("Tarif");
                });

            modelBuilder.Entity("CitireContoareApa.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CitireContoareApa.Models.Contor", b =>
                {
                    b.HasOne("CitireContoareApa.Models.User", "User")
                        .WithMany("Contoare")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CitireContoareApa.Models.Factura", b =>
                {
                    b.HasOne("CitireContoareApa.Models.Contor", "Contor")
                        .WithMany("Facturi")
                        .HasForeignKey("ContorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitireContoareApa.Models.Plata", "Plata")
                        .WithMany()
                        .HasForeignKey("PlataId");

                    b.HasOne("CitireContoareApa.Models.Tarif", "Tarif")
                        .WithMany("Facturi")
                        .HasForeignKey("TarifId");

                    b.Navigation("Contor");

                    b.Navigation("Plata");

                    b.Navigation("Tarif");
                });

            modelBuilder.Entity("CitireContoareApa.Models.Plata", b =>
                {
                    b.HasOne("CitireContoareApa.Models.Factura", "Factura")
                        .WithMany()
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factura");
                });

            modelBuilder.Entity("CitireContoareApa.Models.Contor", b =>
                {
                    b.Navigation("Facturi");
                });

            modelBuilder.Entity("CitireContoareApa.Models.Tarif", b =>
                {
                    b.Navigation("Facturi");
                });

            modelBuilder.Entity("CitireContoareApa.Models.User", b =>
                {
                    b.Navigation("Contoare");
                });
#pragma warning restore 612, 618
        }
    }
}
