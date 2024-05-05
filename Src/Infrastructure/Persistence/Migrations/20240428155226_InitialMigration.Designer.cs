﻿// <auto-generated />
using System;
using System.Numerics;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240428155226_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ClientEstablishment", b =>
                {
                    b.Property<BigInteger>("ClientsId")
                        .HasColumnType("numeric");

                    b.Property<BigInteger>("EstablishmentsId")
                        .HasColumnType("numeric");

                    b.HasKey("ClientsId", "EstablishmentsId");

                    b.HasIndex("EstablishmentsId");

                    b.ToTable("ClientEstablishment");
                });

            modelBuilder.Entity("Core.Entities.Appointment", b =>
                {
                    b.Property<BigInteger>("Id")
                        .HasColumnType("numeric");

                    b.Property<BigInteger>("ClientId")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<BigInteger>("EstablishmentId")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("EstablishmentId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Core.Entities.Client", b =>
                {
                    b.Property<BigInteger>("Id")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Core.Entities.Establishment", b =>
                {
                    b.Property<BigInteger>("Id")
                        .HasColumnType("numeric");

                    b.Property<int>("Active")
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Permalink")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Establishments");
                });

            modelBuilder.Entity("Core.Entities.Service", b =>
                {
                    b.Property<BigInteger>("Id")
                        .HasColumnType("numeric");

                    b.Property<int>("Active")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<BigInteger>("EstablishmentId")
                        .HasColumnType("numeric");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<long>("TimeInMinutes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EstablishmentId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("ClientEstablishment", b =>
                {
                    b.HasOne("Core.Entities.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Establishment", null)
                        .WithMany()
                        .HasForeignKey("EstablishmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Appointment", b =>
                {
                    b.HasOne("Core.Entities.Client", "Client")
                        .WithMany("Appointments")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Establishment", "Establishment")
                        .WithMany("Appointments")
                        .HasForeignKey("EstablishmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Establishment");
                });

            modelBuilder.Entity("Core.Entities.Service", b =>
                {
                    b.HasOne("Core.Entities.Establishment", "Establishment")
                        .WithMany("Services")
                        .HasForeignKey("EstablishmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Establishment");
                });

            modelBuilder.Entity("Core.Entities.Client", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Core.Entities.Establishment", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
