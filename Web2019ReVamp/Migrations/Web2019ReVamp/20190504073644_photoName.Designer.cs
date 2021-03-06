﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web2019ReVamp.Models;

namespace Web2019ReVamp.Migrations.Web2019ReVamp
{
    [DbContext(typeof(Web2019ReVampContext))]
    [Migration("20190504073644_photoName")]
    partial class photoName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Web2019ReVamp.Models.Catagories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Catagory");

                    b.HasKey("Id");

                    b.ToTable("Catagoies");
                });

            modelBuilder.Entity("Web2019ReVamp.Models.Reports", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("HazardDateTime");

                    b.Property<string>("HazardType");

                    b.Property<int>("InvId");

                    b.Property<string>("Location");

                    b.Property<string>("Photo");

                    b.Property<string>("PhotoName");

                    b.Property<DateTime>("RepDate");

                    b.Property<string>("RepDescription");

                    b.Property<string>("Status");

                    b.Property<string>("Title");

                    b.Property<int>("Upvotes");

                    b.Property<string>("UserId");

                    b.Property<string>("userEmail");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
