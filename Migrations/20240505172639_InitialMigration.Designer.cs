﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProdavnicaObuce.Settings;

#nullable disable

namespace ProdavnicaObuce.Migrations
{
    [DbContext(typeof(ProdavnicaDbContext))]
    [Migration("20240505172639_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProdavnicaObuce.Models.Dobavljac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Kontakt")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Dobavljaci");
                });

            modelBuilder.Entity("ProdavnicaObuce.Models.Korisinik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("KorisnickoIme")
                        .IsUnique();

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("ProdavnicaObuce.Models.Porudzbina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("CenaPorudzbine")
                        .HasColumnType("float");

                    b.Property<int>("IdDobavljaca")
                        .HasColumnType("int");

                    b.Property<int>("IdZaposlenog")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VremeDostave")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VremePorudzbe")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdDobavljaca");

                    b.HasIndex("IdZaposlenog");

                    b.ToTable("Porudzbine");
                });

            modelBuilder.Entity("ProdavnicaObuce.Models.Prodaja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("CenaProdaje")
                        .HasColumnType("float");

                    b.Property<int>("IdKupca")
                        .HasColumnType("int");

                    b.Property<string>("NacinPlacanja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VremeProdaje")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdKupca");

                    b.ToTable("Prodaje");
                });

            modelBuilder.Entity("ProdavnicaObuce.Models.Proizvod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Boja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Brend")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Proizvodi");
                });

            modelBuilder.Entity("ProdavnicaObuce.Models.StavkaProdaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdProdaje")
                        .HasColumnType("int");

                    b.Property<int>("IdProizvoda")
                        .HasColumnType("int");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdProdaje");

                    b.HasIndex("IdProizvoda");

                    b.ToTable("StavkeProdaje");
                });

            modelBuilder.Entity("ProdavnicaObuce.Models.Porudzbina", b =>
                {
                    b.HasOne("ProdavnicaObuce.Models.Dobavljac", "Dobavljac")
                        .WithMany("Porudzbine")
                        .HasForeignKey("IdDobavljaca")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ProdavnicaObuce.Models.Korisinik", "Korisinik")
                        .WithMany("Porudzbine")
                        .HasForeignKey("IdZaposlenog")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Dobavljac");

                    b.Navigation("Korisinik");
                });

            modelBuilder.Entity("ProdavnicaObuce.Models.Prodaja", b =>
                {
                    b.HasOne("ProdavnicaObuce.Models.Korisinik", "Kupac")
                        .WithMany("Prodaje")
                        .HasForeignKey("IdKupca")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Kupac");
                });

            modelBuilder.Entity("ProdavnicaObuce.Models.StavkaProdaje", b =>
                {
                    b.HasOne("ProdavnicaObuce.Models.Prodaja", "Prodaja")
                        .WithMany("StavkeProdaje")
                        .HasForeignKey("IdProdaje")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ProdavnicaObuce.Models.Proizvod", "Proizvod")
                        .WithMany("StavkeProdaje")
                        .HasForeignKey("IdProizvoda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prodaja");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("ProdavnicaObuce.Models.Dobavljac", b =>
                {
                    b.Navigation("Porudzbine");
                });

            modelBuilder.Entity("ProdavnicaObuce.Models.Korisinik", b =>
                {
                    b.Navigation("Porudzbine");

                    b.Navigation("Prodaje");
                });

            modelBuilder.Entity("ProdavnicaObuce.Models.Prodaja", b =>
                {
                    b.Navigation("StavkeProdaje");
                });

            modelBuilder.Entity("ProdavnicaObuce.Models.Proizvod", b =>
                {
                    b.Navigation("StavkeProdaje");
                });
#pragma warning restore 612, 618
        }
    }
}
