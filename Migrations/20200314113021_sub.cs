using Microsoft.EntityFrameworkCore.Migrations;

namespace MessengerApp.Migrations
{
    public partial class sub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChanelModel_ChanelId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionModel_ChanelModel_ChannelId",
                table: "SubscriptionModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionModel_AspNetUsers_UserId",
                table: "SubscriptionModel");

            migrationBuilder.DropTable(
                name: "ChanelModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionModel",
                table: "SubscriptionModel");

            migrationBuilder.RenameTable(
                name: "SubscriptionModel",
                newName: "Subscriptions");

            migrationBuilder.RenameIndex(
                name: "IX_SubscriptionModel_UserId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SubscriptionModel_ChannelId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_ChannelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Channels",
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
                    table.PrimaryKey("PK_Channels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Channels_AspNetUsers_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Channels_OwnerUserId",
                table: "Channels",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Channels_ChanelId",
                table: "Messages",
                column: "ChanelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Channels_ChannelId",
                table: "Subscriptions",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_AspNetUsers_UserId",
                table: "Subscriptions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Channels_ChanelId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Channels_ChannelId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AspNetUsers_UserId",
                table: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions");

            migrationBuilder.RenameTable(
                name: "Subscriptions",
                newName: "SubscriptionModel");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_UserId",
                table: "SubscriptionModel",
                newName: "IX_SubscriptionModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_ChannelId",
                table: "SubscriptionModel",
                newName: "IX_SubscriptionModel_ChannelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionModel",
                table: "SubscriptionModel",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ChanelModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionModel_ChanelModel_ChannelId",
                table: "SubscriptionModel",
                column: "ChannelId",
                principalTable: "ChanelModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionModel_AspNetUsers_UserId",
                table: "SubscriptionModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
