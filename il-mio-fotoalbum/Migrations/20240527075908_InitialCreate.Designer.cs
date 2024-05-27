﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using il_mio_fotoalbum.Data;

#nullable disable

namespace il_mio_fotoalbum.Migrations
{
    [DbContext(typeof(FotoContext))]
    [Migration("20240527075908_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CategoriaFoto", b =>
                {
                    b.Property<int>("CategoriasId")
                        .HasColumnType("int");

                    b.Property<int>("FotosId")
                        .HasColumnType("int");

                    b.HasKey("CategoriasId", "FotosId");

                    b.HasIndex("FotosId");

                    b.ToTable("CategoriaFoto");
                });

            modelBuilder.Entity("il_mio_fotoalbum.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("il_mio_fotoalbum.Models.Foto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("descrizione");

                    b.Property<byte[]>("Immagine")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("immagine");

                    b.Property<string>("Titolo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("titolo");

                    b.Property<bool>("Visibile")
                        .HasColumnType("bit")
                        .HasColumnName("visibile");

                    b.HasKey("Id");

                    b.ToTable("Foto");
                });

            modelBuilder.Entity("CategoriaFoto", b =>
                {
                    b.HasOne("il_mio_fotoalbum.Models.Categoria", null)
                        .WithMany()
                        .HasForeignKey("CategoriasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("il_mio_fotoalbum.Models.Foto", null)
                        .WithMany()
                        .HasForeignKey("FotosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
