﻿// <auto-generated />
using System;
using Discord_Bot.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Discord_Bot.Migrations
{
    [DbContext(typeof(BdayBotContext))]
    [Migration("20200307235803_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Discord_Bot.Db.Guild", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("numeric")
                        .HasMaxLength(18);

                    b.Property<decimal>("AnnouncementChannel")
                        .HasColumnName("announcementChannel")
                        .HasColumnType("numeric")
                        .HasMaxLength(18);

                    b.HasKey("Id");

                    b.ToTable("guild");
                });

            modelBuilder.Entity("Discord_Bot.Db.User", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("numeric")
                        .HasMaxLength(18);

                    b.Property<DateTime>("Birthday")
                        .HasColumnName("birthday")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("user");
                });
#pragma warning restore 612, 618
        }
    }
}
