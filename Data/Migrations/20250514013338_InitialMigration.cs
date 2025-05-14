using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FORMULARIOCENSI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_ambiente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomAmb = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_ambiente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_especifico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomEsp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_especifico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_formulario",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<string>(type: "text", nullable: true),
                    titulo = table.Column<string>(type: "text", nullable: true),
                    sinopsis = table.Column<string>(type: "text", nullable: true),
                    Imagen = table.Column<byte[]>(type: "bytea", nullable: true),
                    imagename = table.Column<string>(type: "text", nullable: true),
                    autores = table.Column<string>(type: "text", nullable: true),
                    historial_medico = table.Column<string>(type: "text", nullable: true),
                    alergias = table.Column<string>(type: "text", nullable: true),
                    medicamentos = table.Column<string>(type: "text", nullable: true),
                    historial_familiar = table.Column<string>(type: "text", nullable: true),
                    situacion = table.Column<string>(type: "text", nullable: true),
                    nota_de_hospitalizacion = table.Column<string>(type: "text", nullable: true),
                    signos_vitales = table.Column<string>(type: "text", nullable: true),
                    estado_general = table.Column<string>(type: "text", nullable: true),
                    piel = table.Column<string>(type: "text", nullable: true),
                    torax = table.Column<string>(type: "text", nullable: true),
                    cv = table.Column<string>(type: "text", nullable: true),
                    abdomen = table.Column<string>(type: "text", nullable: true),
                    neurologico = table.Column<string>(type: "text", nullable: true),
                    laboratorio = table.Column<string>(type: "text", nullable: true),
                    Imagena = table.Column<byte[]>(type: "bytea", nullable: true),
                    imagenamea = table.Column<string>(type: "text", nullable: true),
                    orden_inicial = table.Column<string>(type: "text", nullable: true),
                    distinguir = table.Column<string>(type: "text", nullable: true),
                    indicar = table.Column<string>(type: "text", nullable: true),
                    analizar = table.Column<string>(type: "text", nullable: true),
                    evaluación = table.Column<string>(type: "text", nullable: true),
                    aplicar = table.Column<string>(type: "text", nullable: true),
                    medidas_esenciales = table.Column<string>(type: "text", nullable: true),
                    baseline = table.Column<string>(type: "text", nullable: true),
                    preguntas_de_preparacion = table.Column<string>(type: "text", nullable: true),
                    equipos_de_suministro = table.Column<string>(type: "text", nullable: true),
                    confederado = table.Column<string>(type: "text", nullable: true),
                    archivo = table.Column<byte[]>(type: "bytea", nullable: true),
                    archivo_name = table.Column<string>(type: "text", nullable: true),
                    ArchivoTextoExtraido = table.Column<string>(type: "text", nullable: true),
                    introduccion = table.Column<string>(type: "text", nullable: true),
                    emociones = table.Column<string>(type: "text", nullable: true),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    analisis = table.Column<string>(type: "text", nullable: true),
                    sintesis = table.Column<string>(type: "text", nullable: true),
                    preguntasdd = table.Column<string>(type: "text", nullable: true),
                    baselineapren = table.Column<string>(type: "text", nullable: true),
                    referenciasb = table.Column<string>(type: "text", nullable: true),
                    escenariosp = table.Column<string>(type: "text", nullable: true),
                    Imagenc = table.Column<byte[]>(type: "bytea", nullable: true),
                    imagenamec = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_formulario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_global",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomGlo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_global", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_respacademico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomAcad = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_respacademico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_respoperador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomOpe = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_respoperador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_dialogo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Personaje = table.Column<string>(type: "text", nullable: true),
                    Guion = table.Column<string>(type: "text", nullable: true),
                    FormularioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_dialogo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_dialogo_t_formulario_FormularioId",
                        column: x => x.FormularioId,
                        principalTable: "t_formulario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    FormularioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_estados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_estados_t_formulario_FormularioId",
                        column: x => x.FormularioId,
                        principalTable: "t_formulario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_estadosa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    FormularioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_estadosa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_estadosa_t_formulario_FormularioId",
                        column: x => x.FormularioId,
                        principalTable: "t_formulario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    FormularioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_status_t_formulario_FormularioId",
                        column: x => x.FormularioId,
                        principalTable: "t_formulario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_principal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GlobalId = table.Column<int>(type: "integer", nullable: false),
                    EspecificoId = table.Column<int>(type: "integer", nullable: false),
                    RespAcademicoId = table.Column<int>(type: "integer", nullable: false),
                    RespOperadorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_principal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_principal_t_especifico_EspecificoId",
                        column: x => x.EspecificoId,
                        principalTable: "t_especifico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_principal_t_global_GlobalId",
                        column: x => x.GlobalId,
                        principalTable: "t_global",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_principal_t_respacademico_RespAcademicoId",
                        column: x => x.RespAcademicoId,
                        principalTable: "t_respacademico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_principal_t_respoperador_RespOperadorId",
                        column: x => x.RespOperadorId,
                        principalTable: "t_respoperador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_ambientea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "interval", nullable: false),
                    HoraFin = table.Column<TimeSpan>(type: "interval", nullable: false),
                    AmbienteId = table.Column<int>(type: "integer", nullable: false),
                    PrincipalId = table.Column<int>(type: "integer", nullable: false),
                    Codigo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_ambientea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_ambientea_t_ambiente_AmbienteId",
                        column: x => x.AmbienteId,
                        principalTable: "t_ambiente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_ambientea_t_principal_PrincipalId",
                        column: x => x.PrincipalId,
                        principalTable: "t_principal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_ambientea_AmbienteId",
                table: "t_ambientea",
                column: "AmbienteId");

            migrationBuilder.CreateIndex(
                name: "IX_t_ambientea_PrincipalId",
                table: "t_ambientea",
                column: "PrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_t_dialogo_FormularioId",
                table: "t_dialogo",
                column: "FormularioId");

            migrationBuilder.CreateIndex(
                name: "IX_t_estados_FormularioId",
                table: "t_estados",
                column: "FormularioId");

            migrationBuilder.CreateIndex(
                name: "IX_t_estadosa_FormularioId",
                table: "t_estadosa",
                column: "FormularioId");

            migrationBuilder.CreateIndex(
                name: "IX_t_principal_EspecificoId",
                table: "t_principal",
                column: "EspecificoId");

            migrationBuilder.CreateIndex(
                name: "IX_t_principal_GlobalId",
                table: "t_principal",
                column: "GlobalId");

            migrationBuilder.CreateIndex(
                name: "IX_t_principal_RespAcademicoId",
                table: "t_principal",
                column: "RespAcademicoId");

            migrationBuilder.CreateIndex(
                name: "IX_t_principal_RespOperadorId",
                table: "t_principal",
                column: "RespOperadorId");

            migrationBuilder.CreateIndex(
                name: "IX_t_status_FormularioId",
                table: "t_status",
                column: "FormularioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "t_ambientea");

            migrationBuilder.DropTable(
                name: "t_dialogo");

            migrationBuilder.DropTable(
                name: "t_estados");

            migrationBuilder.DropTable(
                name: "t_estadosa");

            migrationBuilder.DropTable(
                name: "t_status");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "t_ambiente");

            migrationBuilder.DropTable(
                name: "t_principal");

            migrationBuilder.DropTable(
                name: "t_formulario");

            migrationBuilder.DropTable(
                name: "t_especifico");

            migrationBuilder.DropTable(
                name: "t_global");

            migrationBuilder.DropTable(
                name: "t_respacademico");

            migrationBuilder.DropTable(
                name: "t_respoperador");
        }
    }
}
