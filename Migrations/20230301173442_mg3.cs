using Microsoft.EntityFrameworkCore.Migrations;

namespace Tour_management_app.Migrations
{
    public partial class mg3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingData",
                columns: table => new
                {
                    bookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    touristId = table.Column<int>(nullable: false),
                    tourId = table.Column<int>(nullable: false),
                    bookingdate = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingData", x => x.bookingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingData");
        }
    }
}
