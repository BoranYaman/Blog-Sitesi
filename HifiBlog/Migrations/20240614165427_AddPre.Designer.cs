﻿// <auto-generated />
using System;
using HifiBlog.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HifiBlog.Migrations
{
    [DbContext(typeof(HifiContext))]
    [Migration("20240614165427_AddPre")]
    partial class AddPre
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("HifiBlog.Entity.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ActiveNoiseCanceling")
                        .HasColumnType("TEXT");

                    b.Property<string>("BlogImg")
                        .HasColumnType("TEXT");

                    b.Property<string>("BlogName")
                        .HasColumnType("TEXT");

                    b.Property<string>("BlogTag")
                        .HasColumnType("TEXT");

                    b.Property<string>("BlogText")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConnectionType")
                        .HasColumnType("TEXT");

                    b.Property<string>("DriveType")
                        .HasColumnType("TEXT");

                    b.Property<string>("FrequencyRange")
                        .HasColumnType("TEXT");

                    b.Property<string>("HighlightsValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("Impedance")
                        .HasColumnType("TEXT");

                    b.Property<string>("IsActive")
                        .HasColumnType("TEXT");

                    b.Property<string>("JakType")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("PublishedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("SoundLoudity")
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeOfUse")
                        .HasColumnType("TEXT");

                    b.Property<string>("Weight")
                        .HasColumnType("TEXT");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("HifiBlog.Entity.PreliminaryInormation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PITitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("preliminaryInormations");
                });

            modelBuilder.Entity("HifiBlog.Entity.Slider", b =>
                {
                    b.Property<int>("SliderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("IsActive")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("PublishedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("SliderImg")
                        .HasColumnType("TEXT");

                    b.Property<string>("SliderName")
                        .HasColumnType("TEXT");

                    b.Property<string>("SliderText")
                        .HasColumnType("TEXT");

                    b.HasKey("SliderId");

                    b.ToTable("Sliders");
                });
#pragma warning restore 612, 618
        }
    }
}
