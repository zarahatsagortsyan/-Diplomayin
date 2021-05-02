using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EquipmentShop.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AboutSections",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Dest = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AboutSections", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AdminUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        AdminVerificationCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AdminUsers", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "BasketProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForWhom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketProducts", x => x.Id);
                });

        //    migrationBuilder.CreateTable(
        //        name: "Categories",
        //        columns: table => new
        //        {
        //            CategoryId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Categories", x => x.CategoryId);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ContactSections",
        //        columns: table => new
        //        {
        //            ID = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ContactSections", x => x.ID);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ForWhoms",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ForWhoms", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "HeadSections",
        //        columns: table => new
        //        {
        //            HeadSectionId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            HeadTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            HeadOverview = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_HeadSections", x => x.HeadSectionId);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "materialLists",
        //        columns: table => new
        //        {
        //            id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_materialLists", x => x.id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Orders",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ProductId = table.Column<int>(type: "int", nullable: false),
        //            ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Price = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
        //            PCount = table.Column<int>(type: "int", nullable: false),
        //            Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Orders", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Products",
        //        columns: table => new
        //        {
        //            ProductID = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Price = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
        //            Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ForWhom = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Availability = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Products", x => x.ProductID);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "RoleClaims",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_RoleClaims", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Roles",
        //        columns: table => new
        //        {
        //            Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Roles", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "StaffSections",
        //        columns: table => new
        //        {
        //            ID = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Position = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_StaffSections", x => x.ID);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "UserClaims",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_UserClaims", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Users",
        //        columns: table => new
        //        {
        //            Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
        //            PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
        //            TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
        //            LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //            LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
        //            AccessFailedCount = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Users", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Materials",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ProductID = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Materials", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Materials_Products_ProductID",
        //                column: x => x.ProductID,
        //                principalTable: "Products",
        //                principalColumn: "ProductID",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Materials_ProductID",
        //        table: "Materials",
        //        column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutSections");

            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.DropTable(
                name: "BasketProducts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ContactSections");

            migrationBuilder.DropTable(
                name: "ForWhoms");

            migrationBuilder.DropTable(
                name: "HeadSections");

            migrationBuilder.DropTable(
                name: "materialLists");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "StaffSections");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
