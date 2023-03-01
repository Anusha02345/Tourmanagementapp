using Microsoft.EntityFrameworkCore.Migrations;

namespace Tour_management_app.Migrations
{
    public partial class mg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tourlist",
                columns: table => new
                {
                    TourId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourName = table.Column<string>(nullable: false),
                    DestinationId = table.Column<int>(nullable: false),
                    tourdate = table.Column<string>(nullable: false),
                    tourtime = table.Column<string>(nullable: false),
                    tourguide=table.Column<string>(nullable:false),
                    price=table.Column<double>(nullable:false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourlist", x => x.TourId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tourlist");

        }

        
       
    }
}
