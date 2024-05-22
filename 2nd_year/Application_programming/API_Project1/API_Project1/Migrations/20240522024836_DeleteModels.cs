using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_Project1.Migrations
{
    /// <inheritdoc />
    public partial class DeleteModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Dialogs_DialogId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Dialogs_DialogId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Dialogs");

            migrationBuilder.DropIndex(
                name: "IX_Messages_DialogId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DialogId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DialogId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "DialogId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Messages",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "DialogId",
                table: "Messages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DialogId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dialogs",
                columns: table => new
                {
                    DialogId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dialogs", x => x.DialogId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DialogId",
                table: "Messages",
                column: "DialogId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DialogId",
                table: "AspNetUsers",
                column: "DialogId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Dialogs_DialogId",
                table: "AspNetUsers",
                column: "DialogId",
                principalTable: "Dialogs",
                principalColumn: "DialogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Dialogs_DialogId",
                table: "Messages",
                column: "DialogId",
                principalTable: "Dialogs",
                principalColumn: "DialogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
