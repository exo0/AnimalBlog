using Microsoft.EntityFrameworkCore.Migrations;

namespace AWWW_Projekt.Migrations
{
    public partial class DodanieCommentu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentAuthor",
                table: "PostComments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentAuthor",
                table: "PostComments");
        }
    }
}
