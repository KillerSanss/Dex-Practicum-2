using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DrugStore",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    drug_network = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    city = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    street = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    house = table.Column<int>(type: "integer", nullable: true),
                    postal_code = table.Column<int>(type: "integer", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugStore", x => x.id);
                    table.CheckConstraint("CK_House_GreaterThanZero", "[house] > 0");
                    table.CheckConstraint("CK_Number_GreaterThanZero", "[number] > 0");
                    table.CheckConstraint("CK_PostalCode_Range", "[postal_code] >= 10000 AND [postal_code] <= 999999");
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    external_id = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Drug",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    manufacturer = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    country_code_id = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drug", x => x.id);
                    table.ForeignKey(
                        name: "FK_Drug_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "DrugItem",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    drug_id = table.Column<Guid>(type: "uuid", nullable: false),
                    drugstore_id = table.Column<Guid>(type: "uuid", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    DrugId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugItem", x => x.id);
                    table.CheckConstraint("CK_Amount_Range", "[amount] >= 0 AND [amount] <= 10000");
                    table.CheckConstraint("CK_Price_GreaterThanOrEqualZero", "[price] >= 0");
                    table.ForeignKey(
                        name: "FK_DrugItem_DrugStore_drugstore_id",
                        column: x => x.drugstore_id,
                        principalTable: "DrugStore",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugItem_Drug_DrugId1",
                        column: x => x.DrugId1,
                        principalTable: "Drug",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_DrugItem_Drug_drug_id",
                        column: x => x.drug_id,
                        principalTable: "Drug",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteDrug",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    profile_id = table.Column<Guid>(type: "uuid", nullable: false),
                    drug_id = table.Column<Guid>(type: "uuid", nullable: false),
                    DrugStoreId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteDrug", x => x.id);
                    table.ForeignKey(
                        name: "FK_FavouriteDrug_DrugStore_DrugStoreId",
                        column: x => x.DrugStoreId,
                        principalTable: "DrugStore",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_FavouriteDrug_Drug_drug_id",
                        column: x => x.drug_id,
                        principalTable: "Drug",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteDrug_UserProfile_profile_id",
                        column: x => x.profile_id,
                        principalTable: "UserProfile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drug_CountryId",
                table: "Drug",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugItem_drug_id",
                table: "DrugItem",
                column: "drug_id");

            migrationBuilder.CreateIndex(
                name: "IX_DrugItem_DrugId1",
                table: "DrugItem",
                column: "DrugId1");

            migrationBuilder.CreateIndex(
                name: "IX_DrugItem_drugstore_id",
                table: "DrugItem",
                column: "drugstore_id");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteDrug_drug_id",
                table: "FavouriteDrug",
                column: "drug_id");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteDrug_DrugStoreId",
                table: "FavouriteDrug",
                column: "DrugStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteDrug_profile_id",
                table: "FavouriteDrug",
                column: "profile_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugItem");

            migrationBuilder.DropTable(
                name: "FavouriteDrug");

            migrationBuilder.DropTable(
                name: "DrugStore");

            migrationBuilder.DropTable(
                name: "Drug");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
