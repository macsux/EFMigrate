﻿// <auto-generated />
using EFMigrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFMigrate.Migrations
{
    [DbContext(typeof(FunnyQuotesContext))]
    partial class FunnyQuotesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EFMigrate.FunnyQuote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Message");

                    b.HasKey("Id");

                    b.ToTable("Quotes");

                    b.HasData(
                        new { Id = 1, Message = "Hello" },
                        new { Id = 2, Message = "There" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}