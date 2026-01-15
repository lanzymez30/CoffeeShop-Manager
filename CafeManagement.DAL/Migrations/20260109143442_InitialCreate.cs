using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CafeManagement.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.AppUserId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableId);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Revenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderCount = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.ShiftId);
                    table.ForeignKey(
                        name: "FK_Shifts_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "AppUserId", "CreatedDate", "FullName", "IsActive", "PasswordHash", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 9, 21, 34, 42, 275, DateTimeKind.Local).AddTicks(2792), "Nguyễn Từ Lân", true, "1", "Admin", "admin" },
                    { 2, new DateTime(2026, 1, 9, 21, 34, 42, 275, DateTimeKind.Local).AddTicks(2804), "Nhân viên", true, "1", "Staff", "staff" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description", "IsActive" },
                values: new object[,]
                {
                    { 1, "Cà phê Việt Nam", "Đậm đà bản sắc", true },
                    { 2, "Trà Trái Cây Trend", "Mát lạnh", true },
                    { 3, "Trà Sữa & Kem", "Béo ngậy", true },
                    { 4, "Đá Xay & Smoothie", "Sảng khoái", true }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "CurrentOrderId", "Status", "TableName" },
                values: new object[,]
                {
                    { 1, 4, null, "Available", "Bàn 1" },
                    { 2, 4, null, "Available", "Bàn 2" },
                    { 3, 4, null, "Available", "Bàn 3" },
                    { 4, 6, null, "Available", "Bàn 4" },
                    { 5, 8, null, "Available", "Bàn 5" },
                    { 6, 2, null, "Available", "Bàn 6" },
                    { 7, 2, null, "Available", "Bàn 7" },
                    { 8, 10, null, "Available", "Bàn 8" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImagePath", "IsAvailable", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, 1, null, null, true, 29000m, "Cà phê Muối Huế" },
                    { 2, 1, null, null, true, 35000m, "Cà phê Trứng Hà Nội" },
                    { 3, 1, null, null, true, 32000m, "Bạc Xỉu Cốt Dừa" },
                    { 4, 1, null, null, true, 45000m, "Cold Brew Cam Vàng" },
                    { 5, 1, null, null, true, 39000m, "Cà phê Sữa Hạt Dẻ" },
                    { 6, 1, null, null, true, 42000m, "Latte Khoai Môn" },
                    { 7, 1, null, null, true, 39000m, "Cà Phê Dừa Đá Xay" },
                    { 8, 1, null, null, true, 35000m, "Espresso Tonic" },
                    { 9, 2, null, null, true, 35000m, "Trà Mãng Cầu Xiêm" },
                    { 10, 2, null, null, true, 45000m, "Trà Măng Cụt Hoa Đậu Biếc" },
                    { 11, 2, null, null, true, 35000m, "Trà Ổi Hồng Muối Ớt" },
                    { 12, 2, null, null, true, 39000m, "Trà Dâu Tằm Pha Lê" },
                    { 13, 2, null, null, true, 42000m, "Trà Nhãn Sen Vàng" },
                    { 14, 2, null, null, true, 39000m, "Trà Lựu Đỏ Hạt Chia" },
                    { 15, 2, null, null, true, 39000m, "Trà Vải Hoa Hồng" },
                    { 16, 2, null, null, true, 35000m, "Trà Đào Cam Sả" },
                    { 17, 2, null, null, true, 38000m, "Lục Trà Kiwi Táo Xanh" },
                    { 18, 2, null, null, true, 38000m, "Trà Hibiscus Dâu Tây" },
                    { 19, 3, null, null, true, 45000m, "Trà Sữa Nướng Vân Nam" },
                    { 20, 3, null, null, true, 40000m, "Sữa Tươi Trân Châu Đường Đen" },
                    { 21, 3, null, null, true, 42000m, "Trà Sữa Oolong Lài Kem Cheese" },
                    { 22, 3, null, null, true, 45000m, "Trà Sữa Than Tre Nhật Bản" },
                    { 23, 3, null, null, true, 45000m, "Matcha Latte Kem Trứng" },
                    { 24, 3, null, null, true, 30000m, "Trà Sữa Thái Xanh" },
                    { 25, 3, null, null, true, 35000m, "Hồng Trà Macchiato" },
                    { 26, 3, null, null, true, 45000m, "Sữa Tươi Kem Trứng Nướng" },
                    { 27, 4, null, null, true, 49000m, "Cookie Đá Xay Bạc Hà" },
                    { 28, 4, null, null, true, 55000m, "Sinh Tố Bơ Dừa Sáp" },
                    { 29, 4, null, null, true, 45000m, "Sữa Chua Hy Lạp Granola" },
                    { 30, 4, null, null, true, 35000m, "Chanh Tuyết Cốt Dừa" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableId",
                table: "Orders",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_UserId",
                table: "Shifts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
