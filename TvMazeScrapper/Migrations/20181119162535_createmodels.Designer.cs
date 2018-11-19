﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TvMazeScrapper.Context;

namespace TvMazeScrapper.Migrations
{
    [DbContext(typeof(MazeContext))]
    [Migration("20181119162535_createmodels")]
    partial class createmodels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TvMazeScrapper.Core.CastMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("TvShowId");

                    b.HasKey("Id");

                    b.HasIndex("TvShowId");

                    b.ToTable("CastMembers");
                });

            modelBuilder.Entity("TvMazeScrapper.Core.TvShow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TvShows");
                });

            modelBuilder.Entity("TvMazeScrapper.Core.CastMember", b =>
                {
                    b.HasOne("TvMazeScrapper.Core.TvShow")
                        .WithMany("Cast")
                        .HasForeignKey("TvShowId");
                });
#pragma warning restore 612, 618
        }
    }
}
