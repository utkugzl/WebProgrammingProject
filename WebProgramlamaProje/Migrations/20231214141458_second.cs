using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramlamaProje.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightBooking_Flights_FlightID",
                table: "FlightBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightBooking_Tickets_TicketID",
                table: "FlightBooking");

            migrationBuilder.DropIndex(
                name: "IX_FlightBooking_TicketID",
                table: "FlightBooking");

            migrationBuilder.RenameColumn(
                name: "FlightID",
                table: "FlightBooking",
                newName: "FlightId");

            migrationBuilder.RenameColumn(
                name: "TicketID",
                table: "FlightBooking",
                newName: "TicketNumber");

            migrationBuilder.RenameIndex(
                name: "IX_FlightBooking_FlightID",
                table: "FlightBooking",
                newName: "IX_FlightBooking_FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightBooking_Flights_FlightId",
                table: "FlightBooking",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "FlightID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightBooking_Flights_FlightId",
                table: "FlightBooking");

            migrationBuilder.RenameColumn(
                name: "FlightId",
                table: "FlightBooking",
                newName: "FlightID");

            migrationBuilder.RenameColumn(
                name: "TicketNumber",
                table: "FlightBooking",
                newName: "TicketID");

            migrationBuilder.RenameIndex(
                name: "IX_FlightBooking_FlightId",
                table: "FlightBooking",
                newName: "IX_FlightBooking_FlightID");

            migrationBuilder.CreateIndex(
                name: "IX_FlightBooking_TicketID",
                table: "FlightBooking",
                column: "TicketID");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightBooking_Flights_FlightID",
                table: "FlightBooking",
                column: "FlightID",
                principalTable: "Flights",
                principalColumn: "FlightID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightBooking_Tickets_TicketID",
                table: "FlightBooking",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "TicketID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
