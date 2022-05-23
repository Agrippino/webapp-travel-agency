﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapp_travel_agency.Data;

#nullable disable

namespace webapp_travel_agency.Migrations
{
    [DbContext(typeof(AgenziaViaggioContext))]
    partial class AgenziaViaggioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("webapp_travel_agency.Models.Viaggio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("CostoViaggio")
                        .HasColumnType("float");

                    b.Property<string>("DescrizioneViaggio")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("Text");

                    b.Property<int>("DestinazioniViaggio")
                        .HasColumnType("int");

                    b.Property<int>("DurataViaggio")
                        .HasColumnType("int");

                    b.Property<string>("ImmagineViaggio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitoloViaggio")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Viaggi");
                });
#pragma warning restore 612, 618
        }
    }
}
