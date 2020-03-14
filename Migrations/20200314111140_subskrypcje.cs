using Microsoft.EntityFrameworkCore.Migrations;

namespace MessengerApp.Migrations
{
    public partial class subskrypcje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubscriptionModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ChannelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionModel_ChanelModel_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "ChanelModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubscriptionModel_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionModel_ChannelId",
                table: "SubscriptionModel",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionModel_UserId",
                table: "SubscriptionModel",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscriptionModel");
        }
    }
}
