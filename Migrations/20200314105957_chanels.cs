using Microsoft.EntityFrameworkCore.Migrations;

namespace MessengerApp.Migrations
{
    public partial class chanels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChanelId",
                table: "Messages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChanelModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    OwnerUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChanelModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChanelModel_AspNetUsers_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChanelId",
                table: "Messages",
                column: "ChanelId");

            migrationBuilder.CreateIndex(
                name: "IX_ChanelModel_OwnerUserId",
                table: "ChanelModel",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChanelModel_ChanelId",
                table: "Messages",
                column: "ChanelId",
                principalTable: "ChanelModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChanelModel_ChanelId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "ChanelModel");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ChanelId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ChanelId",
                table: "Messages");
        }
    }
}
