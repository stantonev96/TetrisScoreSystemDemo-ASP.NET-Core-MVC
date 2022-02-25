using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTetrisScoreSystem.Migrations
{
    public partial class ChangeScoreToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_Players_PlayerId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_Players_PlayerId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Players_PlayerId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_PlayerId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserLogins_PlayerId",
                table: "AspNetUserLogins");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserClaims_PlayerId",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "AspNetUserLogins");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "AspNetUserClaims");

            migrationBuilder.RenameColumn(
                name: "playerNickname",
                schema: "dbo",
                table: "Players",
                newName: "PlayerNickname");

            migrationBuilder.AlterColumn<string>(
                name: "Score",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlayerNickname",
                schema: "dbo",
                table: "Players",
                newName: "playerNickname");

            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "Games",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlayerId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlayerId",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlayerId",
                table: "AspNetUserClaims",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_PlayerId",
                table: "AspNetUserRoles",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_PlayerId",
                table: "AspNetUserLogins",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_PlayerId",
                table: "AspNetUserClaims",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_Players_PlayerId",
                table: "AspNetUserClaims",
                column: "PlayerId",
                principalSchema: "dbo",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_Players_PlayerId",
                table: "AspNetUserLogins",
                column: "PlayerId",
                principalSchema: "dbo",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Players_PlayerId",
                table: "AspNetUserRoles",
                column: "PlayerId",
                principalSchema: "dbo",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
