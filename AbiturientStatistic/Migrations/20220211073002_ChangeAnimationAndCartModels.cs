using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ChangeAnimationAndCartModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimationId",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Carts",
                newName: "CartId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Animations",
                newName: "AnimationId");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Animations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Carts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AnimationId",
                table: "Animations",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "AnimationId",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Animations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
