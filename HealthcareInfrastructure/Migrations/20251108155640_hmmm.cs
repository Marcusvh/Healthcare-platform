using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthcareInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class hmmm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patient_medical_records_patients_PatientId",
                schema: "patient_management",
                table: "patient_medical_records");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_patient_medical_records_patients_PatientId",
                schema: "patient_management",
                table: "patient_medical_records",
                column: "PatientId",
                principalSchema: "patient_management",
                principalTable: "patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
