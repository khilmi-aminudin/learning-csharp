using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFUpskilling.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_customer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    address = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    phone_number = table.Column<string>(type: "VARCHAR(13)", nullable: false),
                    email = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_customer", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_customer");
        }
    }
}
