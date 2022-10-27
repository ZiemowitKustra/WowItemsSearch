﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WoWItems.API.DbContexts;

#nullable disable

namespace WoWItems.API.Migrations
{
    [DbContext(typeof(WoWItemsContext))]
    [Migration("20221027105904_UpdateDBFields4")]
    partial class UpdateDBFields4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("WoWItems.API.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Armor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Durability")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EquipEffect")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Stamina")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UseEffect")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Armor = 0,
                            Durability = 145,
                            EquipEffect = "Deals 5 fire dmg to anyone who strikes you with mele attack",
                            Name = "Sulfuras, Hand of Ragnaros",
                            Stamina = 12,
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            Armor = 679,
                            Durability = 120,
                            Name = "Ruined Crest of Lorderon",
                            Stamina = 81,
                            Type = 0
                        });
                });

            modelBuilder.Entity("WoWItems.API.Entities.PrimaryStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrimaryStatType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("PrimaryStat");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ItemId = 1,
                            PrimaryStatType = 1,
                            Value = 12
                        },
                        new
                        {
                            Id = 2,
                            ItemId = 2,
                            PrimaryStatType = 0,
                            Value = 133
                        });
                });

            modelBuilder.Entity("WoWItems.API.Entities.SecondaryStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SecondaryStatType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("SecondaryStat");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ItemId = 2,
                            SecondaryStatType = 1,
                            Value = 21
                        },
                        new
                        {
                            Id = 2,
                            ItemId = 2,
                            SecondaryStatType = 2,
                            Value = 52
                        });
                });

            modelBuilder.Entity("WoWItems.API.Entities.PrimaryStat", b =>
                {
                    b.HasOne("WoWItems.API.Entities.Item", "Item")
                        .WithOne("PrimaryStat")
                        .HasForeignKey("WoWItems.API.Entities.PrimaryStat", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("WoWItems.API.Entities.SecondaryStat", b =>
                {
                    b.HasOne("WoWItems.API.Entities.Item", "Item")
                        .WithMany("SecondaryStats")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("WoWItems.API.Entities.Item", b =>
                {
                    b.Navigation("PrimaryStat")
                        .IsRequired();

                    b.Navigation("SecondaryStats");
                });
#pragma warning restore 612, 618
        }
    }
}
