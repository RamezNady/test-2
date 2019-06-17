using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZwajApp.API.Migrations
{
    public partial class My3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 8);

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    PMId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardOwnerName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CardNumber = table.Column<string>(type: "varchar(16)", nullable: false),
                    ExpirationDate = table.Column<string>(type: "varchar(5)", nullable: false),
                    CVV = table.Column<string>(type: "varchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.PMId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
