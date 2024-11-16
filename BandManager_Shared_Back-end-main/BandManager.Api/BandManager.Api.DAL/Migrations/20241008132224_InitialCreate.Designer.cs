﻿// <auto-generated />
using System;
using BandManager.Api.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BandManager.Api.DAL.Migrations
{
    [DbContext(typeof(BandManagerContext))]
    [Migration("20241008132224_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BandManager.Api.Resources.Models.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.Band", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.BandUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BandId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.HasIndex("UserId");

                    b.ToTable("Band_User");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("BandId")
                        .HasColumnType("int");

                    b.Property<string>("BookingNotes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BookingNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ChangeOverTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DinnerTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FoodDetails")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsPublicEvent")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ParkingDetails")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PaymentDetails")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Planning")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ShowEndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ShowStartTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("SoundCheckTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("StageNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("TourbusLeaveTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("BandId");

                    b.HasIndex("VenueId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<string>("DataLink")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.Set", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.SetSong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SetId")
                        .HasColumnType("int");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SetId");

                    b.HasIndex("SongId");

                    b.ToTable("Set_Song");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("UserId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BandUserId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("HasCar")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("HomeAdress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactPhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.BandUser", b =>
                {
                    b.HasOne("BandManager.Api.Resources.Models.Band", "Band")
                        .WithMany("BandUsers")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BandManager.Api.Resources.Models.User", "User")
                        .WithMany("BandUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Band");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.Booking", b =>
                {
                    b.HasOne("BandManager.Api.Resources.Models.Agent", "Agent")
                        .WithMany("Bookings")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BandManager.Api.Resources.Models.Band", "Band")
                        .WithMany("Bookings")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BandManager.Api.Resources.Models.Venue", "Venue")
                        .WithMany("Bookings")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("Band");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.File", b =>
                {
                    b.HasOne("BandManager.Api.Resources.Models.Booking", "Booking")
                        .WithMany("Files")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.Set", b =>
                {
                    b.HasOne("BandManager.Api.Resources.Models.Booking", "Booking")
                        .WithMany("Sets")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.SetSong", b =>
                {
                    b.HasOne("BandManager.Api.Resources.Models.Set", "Set")
                        .WithMany("SetSongs")
                        .HasForeignKey("SetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BandManager.Api.Resources.Models.Song", "Song")
                        .WithMany("SetSongs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Set");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.Task", b =>
                {
                    b.HasOne("BandManager.Api.Resources.Models.Booking", "Booking")
                        .WithMany("Tasks")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BandManager.Api.Resources.Models.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId");

                    b.Navigation("Booking");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.Agent", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.Band", b =>
                {
                    b.Navigation("BandUsers");

                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.Booking", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("Sets");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.Set", b =>
                {
                    b.Navigation("SetSongs");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.Song", b =>
                {
                    b.Navigation("SetSongs");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.User", b =>
                {
                    b.Navigation("BandUsers");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("BandManager.Api.Resources.Models.Venue", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}