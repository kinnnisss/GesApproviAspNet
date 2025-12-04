using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GestAproAspNet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Libelle = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PrixDefaut = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fournisseurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Telephone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Adresse = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fournisseurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "approvis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Reference = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DateApprovi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Observations = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Statut = table.Column<int>(type: "integer", nullable: false),
                    FournisseurId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_approvis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_approvis_fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transactions_appro_article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantite = table.Column<int>(type: "integer", nullable: false),
                    PrixUnitaire = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Montant = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ArticleId = table.Column<int>(type: "integer", nullable: false),
                    ApproviId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions_appro_article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactions_appro_article_approvis_ApproviId",
                        column: x => x.ApproviId,
                        principalTable: "approvis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transactions_appro_article_articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_approvis_FournisseurId",
                table: "approvis",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_appro_article_ApproviId",
                table: "transactions_appro_article",
                column: "ApproviId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_appro_article_ArticleId",
                table: "transactions_appro_article",
                column: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions_appro_article");

            migrationBuilder.DropTable(
                name: "approvis");

            migrationBuilder.DropTable(
                name: "articles");

            migrationBuilder.DropTable(
                name: "fournisseurs");
        }
    }
}
