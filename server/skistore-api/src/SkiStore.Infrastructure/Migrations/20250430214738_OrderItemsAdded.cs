using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkiStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderItemsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BuyerEmail = table.Column<string>(type: "text", nullable: true),
                    ShippingAddress_Name = table.Column<string>(type: "text", nullable: true),
                    ShippingAddress_City = table.Column<string>(type: "text", nullable: true),
                    ShippingAddress_State = table.Column<string>(type: "text", nullable: true),
                    ShippingAddress_Country = table.Column<string>(type: "text", nullable: true),
                    ShippingAddress_Reference = table.Column<string>(type: "text", nullable: true),
                    ShippingAddress_PostalCode = table.Column<string>(type: "text", nullable: true),
                    ShippingAddress_Line1 = table.Column<string>(type: "text", nullable: true),
                    ShippingAddress_Line2 = table.Column<string>(type: "text", nullable: true),
                    DeliveryMethodId = table.Column<int>(type: "integer", nullable: true),
                    PaymentSummary_Last4 = table.Column<int>(type: "integer", nullable: true),
                    PaymentSummary_Brand = table.Column<string>(type: "text", nullable: true),
                    PaymentSummary_ExpMonth = table.Column<int>(type: "integer", nullable: true),
                    PaymentSummary_Year = table.Column<int>(type: "integer", nullable: true),
                    SubTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    OrderStatus = table.Column<string>(type: "text", nullable: false),
                    PaymentIntentId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryMethods_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "DeliveryMethods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemOrdered_ProductId = table.Column<int>(type: "integer", nullable: false),
                    ItemOrdered_ProductName = table.Column<string>(type: "text", nullable: false),
                    ItemOrdered_PictureUrl = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryMethodId",
                table: "Orders",
                column: "DeliveryMethodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
