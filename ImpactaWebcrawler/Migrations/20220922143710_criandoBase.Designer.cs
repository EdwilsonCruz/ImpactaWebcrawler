// <auto-generated />
using System;
using ImpactaWebcrawler.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ImpactaWebcrawler.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220922143710_criandoBase")]
    partial class criandoBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ImpactaWebcrawler.Domain.Resposta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("horaFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("horaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("linhas")
                        .HasColumnType("int");

                    b.Property<int>("paginas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("resposta", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
