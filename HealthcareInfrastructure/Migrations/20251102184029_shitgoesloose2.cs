using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthcareInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class shitgoesloose2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patients_patient_medical_records_PatientId",
                schema: "patient_management",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_patients_PatientId",
                schema: "patient_management",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_patient_medical_records_PatientId",
                schema: "patient_management",
                table: "patient_medical_records");

            migrationBuilder.CreateIndex(
                name: "IX_patients_PatientId",
                schema: "patient_management",
                table: "patients",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_patient_medical_records_PatientId",
                schema: "patient_management",
                table: "patient_medical_records",
                column: "PatientId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patient_medical_records_patients_PatientId",
                schema: "patient_management",
                table: "patient_medical_records");

            migrationBuilder.DropIndex(
                name: "IX_patients_PatientId",
                schema: "patient_management",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_patient_medical_records_PatientId",
                schema: "patient_management",
                table: "patient_medical_records");

            migrationBuilder.CreateIndex(
                name: "IX_patients_PatientId",
                schema: "patient_management",
                table: "patients",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_patient_medical_records_PatientId",
                schema: "patient_management",
                table: "patient_medical_records",
                column: "PatientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_patients_patient_medical_records_PatientId",
                schema: "patient_management",
                table: "patients",
                column: "PatientId",
                principalSchema: "patient_management",
                principalTable: "patient_medical_records",
                principalColumn: "MedicalRecordId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
