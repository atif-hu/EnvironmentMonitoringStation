﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonitoringStationAPI.Database;

#nullable disable

namespace MonitoringStationAPI.Migrations
{
    [DbContext(typeof(MonitoringStationDbContext))]
    partial class MonitoringStationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("MonitoringStationAPI.Models.AirPollutionData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("AirPollution")
                        .HasColumnType("REAL");

                    b.Property<int>("SensorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TriggerThresholdWarning")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("AirPollutionData");
                });

            modelBuilder.Entity("MonitoringStationAPI.Models.CO2EmissionsData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("CO2Emissions")
                        .HasColumnType("REAL");

                    b.Property<int>("SensorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TriggerThresholdWarning")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CO2EmissionsData");
                });

            modelBuilder.Entity("MonitoringStationAPI.Models.HumidityData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Humidity")
                        .HasColumnType("REAL");

                    b.Property<int>("SensorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TriggerThresholdWarning")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("HumidityData");
                });

            modelBuilder.Entity("MonitoringStationAPI.Models.RainfallData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Rainfall")
                        .HasColumnType("REAL");

                    b.Property<int>("SensorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TriggerThresholdWarning")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("RainfallData");
                });

            modelBuilder.Entity("MonitoringStationAPI.Models.Sensor", b =>
                {
                    b.Property<int>("SensorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataCollectionInterval")
                        .HasColumnType("TEXT");

                    b.Property<float>("DataRangeMax")
                        .HasColumnType("REAL");

                    b.Property<float>("DataRangeMin")
                        .HasColumnType("REAL");

                    b.Property<float>("NormalThresholdMax")
                        .HasColumnType("REAL");

                    b.Property<float>("NormalThresholdMin")
                        .HasColumnType("REAL");

                    b.Property<string>("ParameterType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Unit")
                        .HasColumnType("TEXT");

                    b.HasKey("SensorId");

                    b.ToTable("Sensor");
                });

            modelBuilder.Entity("MonitoringStationAPI.Models.TemperatureData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("SensorId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Temperature")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TriggerThresholdWarning")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TemperatureData");
                });
#pragma warning restore 612, 618
        }
    }
}
