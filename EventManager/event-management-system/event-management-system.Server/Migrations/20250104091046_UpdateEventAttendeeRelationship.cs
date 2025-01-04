using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace event_management_system.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEventAttendeeRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "Events",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "Events",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "EvenId",
                table: "Events",
                newName: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Events",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Events",
                newName: "endDate");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Events",
                newName: "EvenId");
        }
    }
}
