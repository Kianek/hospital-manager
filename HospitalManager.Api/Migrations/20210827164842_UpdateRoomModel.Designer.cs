﻿// <auto-generated />
using System;
using HospitalManager.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalManager.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210827164842_UpdateRoomModel")]
    partial class UpdateRoomModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("HospitalManager.Api.Beds.Bed", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsOccupied")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<Guid?>("PatientId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.HasIndex("RoomId");

                    b.ToTable("Beds");
                });

            modelBuilder.Entity("HospitalManager.Api.Hospitals.Hospital", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfRooms")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("HospitalManager.Api.Patients.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("BedId")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HospitalManager.Api.Rooms.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("HospitalId")
                        .HasColumnType("TEXT");

                    b.Property<string>("HospitalName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfBeds")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0);

                    b.Property<int>("OccupiedBeds")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0);

                    b.Property<int>("RoomNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HospitalManager.Api.Beds.Bed", b =>
                {
                    b.HasOne("HospitalManager.Api.Patients.Patient", "Patient")
                        .WithOne("Bed")
                        .HasForeignKey("HospitalManager.Api.Beds.Bed", "PatientId");

                    b.HasOne("HospitalManager.Api.Rooms.Room", "Room")
                        .WithMany("Beds")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HospitalManager.Api.Patients.Patient", b =>
                {
                    b.HasOne("HospitalManager.Api.Rooms.Room", "Room")
                        .WithMany("Patients")
                        .HasForeignKey("RoomId");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HospitalManager.Api.Rooms.Room", b =>
                {
                    b.HasOne("HospitalManager.Api.Hospitals.Hospital", "Hospital")
                        .WithMany("Rooms")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("HospitalManager.Api.Hospitals.Hospital", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HospitalManager.Api.Patients.Patient", b =>
                {
                    b.Navigation("Bed");
                });

            modelBuilder.Entity("HospitalManager.Api.Rooms.Room", b =>
                {
                    b.Navigation("Beds");

                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
