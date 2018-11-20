﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TvMazeScrapper.Context;

namespace TvMazeScrapper.Migrations
{
    [DbContext(typeof(MazeContext))]
    partial class MazeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TvMazeScrapper.Core.Models.CastMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDay");

                    b.Property<int>("CastMemberId");

                    b.Property<string>("Name");

                    b.Property<int>("ShowId");

                    b.Property<int?>("TvShowId");

                    b.HasKey("Id");

                    b.HasIndex("TvShowId");

                    b.ToTable("CastMembers");
                });

            modelBuilder.Entity("TvMazeScrapper.Core.Models.TvShow", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TvShows");
                });

            modelBuilder.Entity("TvMazeScrapper.Core.Models.CastMember", b =>
                {
                    b.HasOne("TvMazeScrapper.Core.Models.TvShow")
                        .WithMany("Cast")
                        .HasForeignKey("TvShowId");
                });
#pragma warning restore 612, 618
        }
    }
}
