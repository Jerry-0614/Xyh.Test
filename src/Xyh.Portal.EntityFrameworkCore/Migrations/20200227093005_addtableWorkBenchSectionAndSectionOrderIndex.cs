using Microsoft.EntityFrameworkCore.Migrations;

namespace Yc.Portal.Migrations
{
    public partial class addtableWorkBenchSectionAndSectionOrderIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SectionName",
                table: "WorkBenches",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "WorkBenches",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "WorkBenches");

            migrationBuilder.AlterColumn<string>(
                name: "SectionName",
                table: "WorkBenches",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
