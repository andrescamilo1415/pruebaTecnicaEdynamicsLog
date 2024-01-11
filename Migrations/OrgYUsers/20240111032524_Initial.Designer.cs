﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pruebaTecnicaEdynamicsLog.Domain.Entities.OrgsYUsers;

#nullable disable

namespace pruebaTecnicaEdynamicsLog.Migrations.OrgYUsers
{
    [DbContext(typeof(DbContextOrgsYUsers))]
    [Migration("20240111032524_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("pruebaTecnicaEdynamicsLog.Domain.Entities.OrgsYUsers.Organizacion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlugTenant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizaciones");
                });

            modelBuilder.Entity("pruebaTecnicaEdynamicsLog.Domain.Entities.OrgsYUsers.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrganizacionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizacionId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("pruebaTecnicaEdynamicsLog.Domain.Entities.OrgsYUsers.Usuario", b =>
                {
                    b.HasOne("pruebaTecnicaEdynamicsLog.Domain.Entities.OrgsYUsers.Organizacion", "Organizacion")
                        .WithMany("Usuarios")
                        .HasForeignKey("OrganizacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizacion");
                });

            modelBuilder.Entity("pruebaTecnicaEdynamicsLog.Domain.Entities.OrgsYUsers.Organizacion", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
