﻿// <auto-generated />
using System;
using Empowerment.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Empowerment.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200604000920_ModificacionBD")]
    partial class ModificacionBD
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Empowerment.Web.Data.Entities.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteId");

                    b.Property<string>("Comentarios");

                    b.Property<bool>("Disponibilidad");

                    b.Property<DateTime>("Fecha");

                    b.Property<int?>("InscripcionId");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("InscripcionId");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("Empowerment.Web.Data.Entities.Asistencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteId");

                    b.Property<DateTime>("FechaEntrada");

                    b.Property<DateTime>("FechaSalida");

                    b.Property<string>("Usuario")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Asistencias");
                });

            modelBuilder.Entity("Empowerment.Web.Data.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Direccion")
                        .HasMaxLength(100);

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Empowerment.Web.Data.Entities.Cortesia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("ClaseCortesia");

                    b.Property<string>("Cual")
                        .HasMaxLength(20);

                    b.Property<string>("Direccion")
                        .HasMaxLength(100);

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<bool>("Facebook");

                    b.Property<DateTime>("FechaInscripcion");

                    b.Property<bool>("Instagram");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("Otro");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20);

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<bool>("Web");

                    b.HasKey("Id");

                    b.ToTable("Cortesias");
                });

            modelBuilder.Entity("Empowerment.Web.Data.Entities.Inscripcion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteId");

                    b.Property<bool>("Deuda");

                    b.Property<bool>("Efectivo");

                    b.Property<DateTime>("FechaFin");

                    b.Property<DateTime>("FechaInicio");

                    b.Property<string>("Observacion")
                        .HasMaxLength(100);

                    b.Property<int?>("PlanId");

                    b.Property<string>("Renovacion")
                        .HasMaxLength(5);

                    b.Property<bool>("Tarjeta");

                    b.Property<string>("Vigencia")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PlanId");

                    b.ToTable("Inscripciones");
                });

            modelBuilder.Entity("Empowerment.Web.Data.Entities.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Costo")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(150);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sesiones")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sigla")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("Empowerment.Web.Data.Entities.Seguimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comentarios")
                        .HasMaxLength(100);

                    b.Property<DateTime>("FechaInscripcion");

                    b.Property<int?>("InscripcionId");

                    b.HasKey("Id");

                    b.HasIndex("InscripcionId");

                    b.ToTable("Seguimientos");
                });

            modelBuilder.Entity("Empowerment.Web.Data.Entities.Agenda", b =>
                {
                    b.HasOne("Empowerment.Web.Data.Entities.Cliente", "Cliente")
                        .WithMany("Agendas")
                        .HasForeignKey("ClienteId");

                    b.HasOne("Empowerment.Web.Data.Entities.Inscripcion", "Inscripcion")
                        .WithMany("Agendas")
                        .HasForeignKey("InscripcionId");
                });

            modelBuilder.Entity("Empowerment.Web.Data.Entities.Asistencia", b =>
                {
                    b.HasOne("Empowerment.Web.Data.Entities.Cliente", "Cliente")
                        .WithMany("Asistencias")
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("Empowerment.Web.Data.Entities.Inscripcion", b =>
                {
                    b.HasOne("Empowerment.Web.Data.Entities.Cliente", "Cliente")
                        .WithMany("Inscripciones")
                        .HasForeignKey("ClienteId");

                    b.HasOne("Empowerment.Web.Data.Entities.Plan", "Plan")
                        .WithMany("Inscripciones")
                        .HasForeignKey("PlanId");
                });

            modelBuilder.Entity("Empowerment.Web.Data.Entities.Seguimiento", b =>
                {
                    b.HasOne("Empowerment.Web.Data.Entities.Inscripcion", "Inscripcion")
                        .WithMany("Seguimientos")
                        .HasForeignKey("InscripcionId");
                });
#pragma warning restore 612, 618
        }
    }
}
