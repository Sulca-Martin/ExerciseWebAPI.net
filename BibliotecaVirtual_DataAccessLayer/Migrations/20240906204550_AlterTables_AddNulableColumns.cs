using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaVirtual_DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AlterTables_AddNulableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Loans_LoanId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Loans_LoanId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_LoanId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_LoanId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LoanId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LoanId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "loanItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "loanItems");

            migrationBuilder.DropColumn(
                name: "PublicacionDate",
                table: "Books");

            migrationBuilder.AddColumn<DateTime>(
                name: "LoanDate",
                table: "Loans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LoanNumber",
                table: "Loans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReturnDateId",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "loanItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Synopsis",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublicationDate",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ReturnDate",
                columns: table => new
                {
                    ReturnDateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnLoan = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnDate", x => x.ReturnDateId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_ReturnDateId",
                table: "Loans",
                column: "ReturnDateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_ReturnDate_ReturnDateId",
                table: "Loans",
                column: "ReturnDateId",
                principalTable: "ReturnDate",
                principalColumn: "ReturnDateId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_ReturnDate_ReturnDateId",
                table: "Loans");

            migrationBuilder.DropTable(
                name: "ReturnDate");

            migrationBuilder.DropIndex(
                name: "IX_Loans_ReturnDateId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "LoanDate",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "LoanNumber",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "ReturnDateId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "loanItems");

            migrationBuilder.DropColumn(
                name: "PublicationDate",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "LoanId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoanId1",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "loanItems",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Quantity",
                table: "loanItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Synopsis",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "PublicacionDate",
                table: "Books",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_LoanId",
                table: "Users",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LoanId1",
                table: "Users",
                column: "LoanId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Loans_LoanId",
                table: "Users",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Loans_LoanId1",
                table: "Users",
                column: "LoanId1",
                principalTable: "Loans",
                principalColumn: "Id");
        }
    }
}
