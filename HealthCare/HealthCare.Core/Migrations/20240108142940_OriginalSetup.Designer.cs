﻿// <auto-generated />
using System;
using HealthCare.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthCare.Core.Migrations
{
    [DbContext(typeof(HealthcareContext))]
    [Migration("20240108142940_OriginalSetup")]
    partial class OriginalSetup
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HealthCare.Core.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<Guid>("CaregiverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("BookingId");

                    b.HasIndex("CaregiverId");

                    b.HasIndex("PatientId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("HealthCare.Core.Models.Caregiver", b =>
                {
                    b.Property<Guid>("CaregiverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CaregiverId");

                    b.ToTable("Caregivers");
                });

            modelBuilder.Entity("HealthCare.Core.Models.Patient", b =>
                {
                    b.Property<Guid>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HealthCare.Core.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewId");

                    b.HasIndex("PatientId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("HealthCare.Core.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("HealthCare.Core.Models.Booking", b =>
                {
                    b.HasOne("HealthCare.Core.Models.Caregiver", "Caregiver")
                        .WithMany("Bookings")
                        .HasForeignKey("CaregiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare.Core.Models.Patient", "Patient")
                        .WithMany("Bookings")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare.Core.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caregiver");

                    b.Navigation("Patient");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("HealthCare.Core.Models.Review", b =>
                {
                    b.HasOne("HealthCare.Core.Models.Patient", "Patient")
                        .WithMany("Reviews")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HealthCare.Core.Models.Caregiver", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("HealthCare.Core.Models.Patient", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
