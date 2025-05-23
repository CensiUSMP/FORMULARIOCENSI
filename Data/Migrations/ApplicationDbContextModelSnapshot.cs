﻿// <auto-generated />
using System;
using FORMULARIOCENSI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FORMULARIOCENSI.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FORMULARIOCENSI.Models.Ambiente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("NomAmb")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("t_ambiente");
                });

            modelBuilder.Entity("FORMULARIOCENSI.Models.AmbienteA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AmbienteId")
                        .HasColumnType("integer");

                    b.Property<string>("Codigo")
                        .HasColumnType("text");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan>("HoraFin")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnType("interval");

                    b.Property<int>("PrincipalId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AmbienteId");

                    b.HasIndex("PrincipalId");

                    b.ToTable("t_ambientea");
                });

            modelBuilder.Entity("FORMULARIOCENSI.Models.Dialogo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FormularioId")
                        .HasColumnType("integer");

                    b.Property<string>("Guion")
                        .HasColumnType("text");

                    b.Property<string>("Personaje")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FormularioId");

                    b.ToTable("t_dialogo");
                });

            modelBuilder.Entity("FORMULARIOCENSI.Models.Especifico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("NomEsp")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("t_especifico");
                });

            modelBuilder.Entity("FORMULARIOCENSI.Models.Estados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("text")
                        .HasColumnName("descripcion");

                    b.Property<int>("FormularioId")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FormularioId");

                    b.ToTable("t_estados");
                });

            modelBuilder.Entity("FORMULARIOCENSI.Models.Estadosa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("text")
                        .HasColumnName("descripcion");

                    b.Property<int>("FormularioId")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FormularioId");

                    b.ToTable("t_estadosa");
                });

            modelBuilder.Entity("FORMULARIOCENSI.Models.Formulario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Abdomen")
                        .HasColumnType("text")
                        .HasColumnName("abdomen");

                    b.Property<string>("Alergias")
                        .HasColumnType("text")
                        .HasColumnName("alergias");

                    b.Property<string>("Analisis")
                        .HasColumnType("text")
                        .HasColumnName("analisis");

                    b.Property<string>("Analizar")
                        .HasColumnType("text")
                        .HasColumnName("analizar");

                    b.Property<string>("Aplicar")
                        .HasColumnType("text")
                        .HasColumnName("aplicar");

                    b.Property<byte[]>("Archivo")
                        .HasColumnType("bytea")
                        .HasColumnName("archivo");

                    b.Property<string>("ArchivoName")
                        .HasColumnType("text")
                        .HasColumnName("archivo_name");

                    b.Property<string>("ArchivoTextoExtraido")
                        .HasColumnType("text");

                    b.Property<string>("Autores")
                        .HasColumnType("text")
                        .HasColumnName("autores");

                    b.Property<string>("Baseline")
                        .HasColumnType("text")
                        .HasColumnName("baseline");

                    b.Property<string>("BaselineApren")
                        .HasColumnType("text")
                        .HasColumnName("baselineapren");

                    b.Property<string>("CV")
                        .HasColumnType("text")
                        .HasColumnName("cv");

                    b.Property<string>("Confederado")
                        .HasColumnType("text")
                        .HasColumnName("confederado");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text")
                        .HasColumnName("descripcion");

                    b.Property<string>("Distinguir")
                        .HasColumnType("text")
                        .HasColumnName("distinguir");

                    b.Property<string>("Emociones")
                        .HasColumnType("text")
                        .HasColumnName("emociones");

                    b.Property<string>("Equipos_de_suministro")
                        .HasColumnType("text")
                        .HasColumnName("equipos_de_suministro");

                    b.Property<string>("EscenariosP")
                        .HasColumnType("text")
                        .HasColumnName("escenariosp");

                    b.Property<string>("Estado_general")
                        .HasColumnType("text")
                        .HasColumnName("estado_general");

                    b.Property<string>("Evaluación")
                        .HasColumnType("text")
                        .HasColumnName("evaluación");

                    b.Property<string>("Historia_familiar")
                        .HasColumnType("text")
                        .HasColumnName("historial_familiar");

                    b.Property<string>("Historial_medico")
                        .HasColumnType("text")
                        .HasColumnName("historial_medico");

                    b.Property<byte[]>("Imagen")
                        .HasColumnType("bytea")
                        .HasColumnName("Imagen");

                    b.Property<string>("ImagenName")
                        .HasColumnType("text")
                        .HasColumnName("imagename");

                    b.Property<string>("ImagenNamea")
                        .HasColumnType("text")
                        .HasColumnName("imagenamea");

                    b.Property<string>("ImagenNamec")
                        .HasColumnType("text")
                        .HasColumnName("imagenamec");

                    b.Property<byte[]>("Imagena")
                        .HasColumnType("bytea")
                        .HasColumnName("Imagena");

                    b.Property<byte[]>("Imagenc")
                        .HasColumnType("bytea")
                        .HasColumnName("Imagenc");

                    b.Property<string>("Indicar")
                        .HasColumnType("text")
                        .HasColumnName("indicar");

                    b.Property<string>("Introduccion")
                        .HasColumnType("text")
                        .HasColumnName("introduccion");

                    b.Property<string>("Laboratorio")
                        .HasColumnType("text")
                        .HasColumnName("laboratorio");

                    b.Property<string>("Medicamentos")
                        .HasColumnType("text")
                        .HasColumnName("medicamentos");

                    b.Property<string>("Medidas_esenciales")
                        .HasColumnType("text")
                        .HasColumnName("medidas_esenciales");

                    b.Property<string>("Neurologico")
                        .HasColumnType("text")
                        .HasColumnName("neurologico");

                    b.Property<string>("Nota_de_hospitalizacion")
                        .HasColumnType("text")
                        .HasColumnName("nota_de_hospitalizacion");

                    b.Property<string>("Orden_inicial")
                        .HasColumnType("text")
                        .HasColumnName("orden_inicial");

                    b.Property<string>("Piel")
                        .HasColumnType("text")
                        .HasColumnName("piel");

                    b.Property<string>("PreguntasDD")
                        .HasColumnType("text")
                        .HasColumnName("preguntasdd");

                    b.Property<string>("Preguntas_de_preparacion")
                        .HasColumnType("text")
                        .HasColumnName("preguntas_de_preparacion");

                    b.Property<string>("ReferenciasB")
                        .HasColumnType("text")
                        .HasColumnName("referenciasb");

                    b.Property<string>("Signos_vitales")
                        .HasColumnType("text")
                        .HasColumnName("signos_vitales");

                    b.Property<string>("Sinopsis")
                        .HasColumnType("text")
                        .HasColumnName("sinopsis");

                    b.Property<string>("Sintesis")
                        .HasColumnType("text")
                        .HasColumnName("sintesis");

                    b.Property<string>("Situacion")
                        .HasColumnType("text")
                        .HasColumnName("situacion");

                    b.Property<string>("Titulo")
                        .HasColumnType("text")
                        .HasColumnName("titulo");

                    b.Property<string>("Torax")
                        .HasColumnType("text")
                        .HasColumnName("torax");

                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("userid");

                    b.HasKey("Id");

                    b.ToTable("t_formulario");
                });

            modelBuilder.Entity("FORMULARIOCENSI.Models.Global", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("NomGlo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("t_global");
                });

            modelBuilder.Entity("FORMULARIOCENSI.Models.Principal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EspecificoId")
                        .HasColumnType("integer");

                    b.Property<int>("GlobalId")
                        .HasColumnType("integer");

                    b.Property<int>("RespAcademicoId")
                        .HasColumnType("integer");

                    b.Property<int>("RespOperadorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EspecificoId");

                    b.HasIndex("GlobalId");

                    b.HasIndex("RespAcademicoId");

                    b.HasIndex("RespOperadorId");

                    b.ToTable("t_principal");
                });

            modelBuilder.Entity("FORMULARIOCENSI.Models.RespAcademico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("NomAcad")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("t_respacademico");
                });

            modelBuilder.Entity("FORMULARIOCENSI.Models.RespOperador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("NomOpe")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("t_respoperador");
                });

            modelBuilder.Entity("FORMULARIOCENSI.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("text")
                        .HasColumnName("descripcion");

                    b.Property<int>("FormularioId")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FormularioId");

                    b.ToTable("t_status");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FORMULARIOCENSI.Models.AmbienteA", b =>
                {
                    b.HasOne("FORMULARIOCENSI.Models.Ambiente", "Ambiente")
                        .WithMany()
                        .HasForeignKey("AmbienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FORMULARIOCENSI.Models.Principal", "Principal")
                        .WithMany("AmbienteA")
                        .HasForeignKey("PrincipalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ambiente");

                    b.Navigation("Principal");
                });

            modelBuilder.Entity("FORMULARIOCENSI.Models.Dialogo", b =>
                {
                    b.HasOne("FORMULARIOCENSI.Models.Formulario", "Formulario")
                        .WithMany("Dialogo")
                        .HasForeignKey("FormularioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Formulario");
                });

            modelBuilder.Entity("FORMULARIOCENSI.Models.Estados", b =>
                {
                    b.HasOne("FORMULARIOCENSI.Models.Formulario", "Formulario")
                        .WithMany("Estados")
                        .HasForeignKey("FormularioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Formulario");
                });

            modelBuilder.Entity("FORMULARIOCENSI.Models.Estadosa", b =>
                {
                    b.HasOne("FORMULARIOCENSI.Models.Formulario", "Formulario")
                        .WithMany("Estadosa")
                        .HasForeignKey("FormularioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Formulario");
                });

            modelBuilder.Entity("FORMULARIOCENSI.Models.Principal", b =>
                {
                    b.HasOne("FORMULARIOCENSI.Models.Especifico", "Especifico")
                        .WithMany()
                        .HasForeignKey("EspecificoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FORMULARIOCENSI.Models.Global", "Global")
                        .WithMany()
                        .HasForeignKey("GlobalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FORMULARIOCENSI.Models.RespAcademico", "RespAcademico")
                        .WithMany()
                        .HasForeignKey("RespAcademicoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FORMULARIOCENSI.Models.RespOperador", "RespOperador")
                        .WithMany()
                        .HasForeignKey("RespOperadorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Especifico");

                    b.Navigation("Global");

                    b.Navigation("RespAcademico");

                    b.Navigation("RespOperador");
                });

            modelBuilder.Entity("FORMULARIOCENSI.Models.Status", b =>
                {
                    b.HasOne("FORMULARIOCENSI.Models.Formulario", "Formulario")
                        .WithMany("Status")
                        .HasForeignKey("FormularioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Formulario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FORMULARIOCENSI.Models.Formulario", b =>
                {
                    b.Navigation("Dialogo");

                    b.Navigation("Estados");

                    b.Navigation("Estadosa");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("FORMULARIOCENSI.Models.Principal", b =>
                {
                    b.Navigation("AmbienteA");
                });
#pragma warning restore 612, 618
        }
    }
}
