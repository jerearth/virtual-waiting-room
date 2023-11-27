using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class DbUpdate_AddModelProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllowedUser_Rooms_RoomId",
                table: "AllowedUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AllowedUser_Users_UserId",
                table: "AllowedUser");

            migrationBuilder.DropForeignKey(
                name: "FK_QueuedUser_Rooms_RoomId",
                table: "QueuedUser");

            migrationBuilder.DropForeignKey(
                name: "FK_QueuedUser_Users_UserId",
                table: "QueuedUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAdmin_Rooms_RoomId",
                table: "RoomAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAdmin_Users_UserId",
                table: "RoomAdmin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAdmin",
                table: "RoomAdmin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QueuedUser",
                table: "QueuedUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllowedUser",
                table: "AllowedUser");

            migrationBuilder.RenameTable(
                name: "RoomAdmin",
                newName: "RoomAdmins");

            migrationBuilder.RenameTable(
                name: "QueuedUser",
                newName: "QueuedUsers");

            migrationBuilder.RenameTable(
                name: "AllowedUser",
                newName: "AllowedUsers");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAdmin_UserId",
                table: "RoomAdmins",
                newName: "IX_RoomAdmins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAdmin_RoomId",
                table: "RoomAdmins",
                newName: "IX_RoomAdmins_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_QueuedUser_UserId",
                table: "QueuedUsers",
                newName: "IX_QueuedUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_QueuedUser_RoomId",
                table: "QueuedUsers",
                newName: "IX_QueuedUsers_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_AllowedUser_UserId",
                table: "AllowedUsers",
                newName: "IX_AllowedUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AllowedUser_RoomId",
                table: "AllowedUsers",
                newName: "IX_AllowedUsers_RoomId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DailyLimit",
                table: "RoomTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomType",
                table: "RoomTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DailyLimit",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Rooms",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Rooms",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OpeningHours",
                table: "Rooms",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Rooms",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "QRCode",
                table: "Rooms",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "RoomType",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QueueState",
                table: "QueuedUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReasonId",
                table: "QueuedUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAdmins",
                table: "RoomAdmins",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QueuedUsers",
                table: "QueuedUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllowedUsers",
                table: "AllowedUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Reason",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Note = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Color = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoomId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reason", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reason_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReasonTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Note = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Color = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoomTemplateId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReasonTemplates_RoomTemplates_RoomTemplateId",
                        column: x => x.RoomTemplateId,
                        principalTable: "RoomTemplates",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_QueuedUsers_ReasonId",
                table: "QueuedUsers",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Reason_RoomId",
                table: "Reason",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonTemplates_RoomTemplateId",
                table: "ReasonTemplates",
                column: "RoomTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllowedUsers_Rooms_RoomId",
                table: "AllowedUsers",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AllowedUsers_Users_UserId",
                table: "AllowedUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QueuedUsers_Reason_ReasonId",
                table: "QueuedUsers",
                column: "ReasonId",
                principalTable: "Reason",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QueuedUsers_Rooms_RoomId",
                table: "QueuedUsers",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QueuedUsers_Users_UserId",
                table: "QueuedUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAdmins_Rooms_RoomId",
                table: "RoomAdmins",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAdmins_Users_UserId",
                table: "RoomAdmins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllowedUsers_Rooms_RoomId",
                table: "AllowedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AllowedUsers_Users_UserId",
                table: "AllowedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_QueuedUsers_Reason_ReasonId",
                table: "QueuedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_QueuedUsers_Rooms_RoomId",
                table: "QueuedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_QueuedUsers_Users_UserId",
                table: "QueuedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAdmins_Rooms_RoomId",
                table: "RoomAdmins");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAdmins_Users_UserId",
                table: "RoomAdmins");

            migrationBuilder.DropTable(
                name: "Reason");

            migrationBuilder.DropTable(
                name: "ReasonTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAdmins",
                table: "RoomAdmins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QueuedUsers",
                table: "QueuedUsers");

            migrationBuilder.DropIndex(
                name: "IX_QueuedUsers_ReasonId",
                table: "QueuedUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllowedUsers",
                table: "AllowedUsers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DailyLimit",
                table: "RoomTemplates");

            migrationBuilder.DropColumn(
                name: "RoomType",
                table: "RoomTemplates");

            migrationBuilder.DropColumn(
                name: "DailyLimit",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "OpeningHours",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "QRCode",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomType",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "QueueState",
                table: "QueuedUsers");

            migrationBuilder.DropColumn(
                name: "ReasonId",
                table: "QueuedUsers");

            migrationBuilder.RenameTable(
                name: "RoomAdmins",
                newName: "RoomAdmin");

            migrationBuilder.RenameTable(
                name: "QueuedUsers",
                newName: "QueuedUser");

            migrationBuilder.RenameTable(
                name: "AllowedUsers",
                newName: "AllowedUser");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAdmins_UserId",
                table: "RoomAdmin",
                newName: "IX_RoomAdmin_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAdmins_RoomId",
                table: "RoomAdmin",
                newName: "IX_RoomAdmin_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_QueuedUsers_UserId",
                table: "QueuedUser",
                newName: "IX_QueuedUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_QueuedUsers_RoomId",
                table: "QueuedUser",
                newName: "IX_QueuedUser_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_AllowedUsers_UserId",
                table: "AllowedUser",
                newName: "IX_AllowedUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AllowedUsers_RoomId",
                table: "AllowedUser",
                newName: "IX_AllowedUser_RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAdmin",
                table: "RoomAdmin",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QueuedUser",
                table: "QueuedUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllowedUser",
                table: "AllowedUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AllowedUser_Rooms_RoomId",
                table: "AllowedUser",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AllowedUser_Users_UserId",
                table: "AllowedUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QueuedUser_Rooms_RoomId",
                table: "QueuedUser",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QueuedUser_Users_UserId",
                table: "QueuedUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAdmin_Rooms_RoomId",
                table: "RoomAdmin",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAdmin_Users_UserId",
                table: "RoomAdmin",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
