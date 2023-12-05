using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientAppointmentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "AppointmentModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentModel_PatientId",
                table: "AppointmentModel",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentModel_Patients_PatientId",
                table: "AppointmentModel",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentModel_Patients_PatientId",
                table: "AppointmentModel");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentModel_PatientId",
                table: "AppointmentModel");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "AppointmentModel");
        }
    }
}
