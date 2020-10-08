﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServerMagazin.Data;

namespace ServerMagazin.Migrations
{
    [DbContext(typeof(CommanderContext))]
    partial class CommanderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ServerMagazin.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ServerMagazin.Models.Comanda", b =>
                {
                    b.Property<int>("IdC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IdC");

                    b.ToTable("Comanda");
                });

            modelBuilder.Entity("ServerMagazin.Models.SlabComanda", b =>
                {
                    b.Property<int>("IdSC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdC")
                        .HasColumnType("int");

                    b.Property<int>("IdSS")
                        .HasColumnType("int");

                    b.Property<double>("Latime")
                        .HasColumnType("float");

                    b.Property<double>("Lungime")
                        .HasColumnType("float");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSC");

                    b.ToTable("SlabComanda");
                });

            modelBuilder.Entity("ServerMagazin.Models.SlabComandaMod", b =>
                {
                    b.Property<int>("IdSC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Id1")
                        .HasColumnType("int");

                    b.Property<int>("Id2")
                        .HasColumnType("int");

                    b.Property<int>("IdSS")
                        .HasColumnType("int");

                    b.Property<double>("Latime")
                        .HasColumnType("float");

                    b.Property<double>("Lungime")
                        .HasColumnType("float");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSC");

                    b.ToTable("SlabComandaMod");
                });

            modelBuilder.Entity("ServerMagazin.Models.SlabStoc", b =>
                {
                    b.Property<int>("IdSS")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Latime")
                        .HasColumnType("float");

                    b.Property<double>("Lungime")
                        .HasColumnType("float");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Taken")
                        .HasColumnType("bit");

                    b.HasKey("IdSS");

                    b.ToTable("SlabStoc");
                });
#pragma warning restore 612, 618
        }
    }
}
