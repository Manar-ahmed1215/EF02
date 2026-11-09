using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF02.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizerId",
                table: "OrganizerProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizerId",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AttendeeId",
                table: "Badges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizerProfiles_OrganizerId",
                table: "OrganizerProfiles",
                column: "OrganizerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_OrganizerId",
                table: "Event",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_AttendeeId",
                table: "Badges",
                column: "AttendeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Badges_Attendees_AttendeeId",
                table: "Badges",
                column: "AttendeeId",
                principalTable: "Attendees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_EventOrganizers_OrganizerId",
                table: "Event",
                column: "OrganizerId",
                principalTable: "EventOrganizers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizerProfiles_EventOrganizers_OrganizerId",
                table: "OrganizerProfiles",
                column: "OrganizerId",
                principalTable: "EventOrganizers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Badges_Attendees_AttendeeId",
                table: "Badges");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_EventOrganizers_OrganizerId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizerProfiles_EventOrganizers_OrganizerId",
                table: "OrganizerProfiles");

            migrationBuilder.DropIndex(
                name: "IX_OrganizerProfiles_OrganizerId",
                table: "OrganizerProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Event_OrganizerId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Badges_AttendeeId",
                table: "Badges");

            migrationBuilder.DropColumn(
                name: "OrganizerId",
                table: "OrganizerProfiles");

            migrationBuilder.DropColumn(
                name: "OrganizerId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "AttendeeId",
                table: "Badges");
        }
    }
}
