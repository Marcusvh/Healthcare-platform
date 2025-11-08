using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthcareInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class shitgoesloose : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "patient_addresses",
                schema: "patient_management",
                columns: table => new
                {
                    PatientAddressId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    Address1 = table.Column<string>(type: "text", nullable: false),
                    Address2 = table.Column<string>(type: "text", nullable: true),
                    Address1Type = table.Column<int>(type: "integer", nullable: false),
                    Address2Type = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_addresses", x => x.PatientAddressId);
                    table.ForeignKey(
                        name: "FK_patient_addresses_patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "patient_management",
                        principalTable: "patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patient_appointments",
                schema: "patient_management",
                columns: table => new
                {
                    AppointmentId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppointmentDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AppointmentTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    DurationInMinutes = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    RoomNumber = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_patient_appointments_patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "patient_management",
                        principalTable: "patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patient_audits",
                schema: "patient_management",
                columns: table => new
                {
                    PatientAuditId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_audits", x => x.PatientAuditId);
                    table.ForeignKey(
                        name: "FK_patient_audits_patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "patient_management",
                        principalTable: "patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patient_contacts",
                schema: "patient_management",
                columns: table => new
                {
                    PatientContactId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    EmergencyContactName = table.Column<string>(type: "text", nullable: false),
                    EmergencyContactPhone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_contacts", x => x.PatientContactId);
                    table.ForeignKey(
                        name: "FK_patient_contacts_patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "patient_management",
                        principalTable: "patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patient_medical_records",
                schema: "patient_management",
                columns: table => new
                {
                    MedicalRecordId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    BloodType = table.Column<string>(type: "text", nullable: false),
                    SmokingStatus = table.Column<string>(type: "text", nullable: false),
                    AlcoholConsumption = table.Column<string>(type: "text", nullable: false),
                    HeightInCm = table.Column<double>(type: "double precision", nullable: false),
                    WeightInKg = table.Column<double>(type: "double precision", nullable: false),
                    BMI = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_medical_records", x => x.MedicalRecordId);
                });

            migrationBuilder.CreateTable(
                name: "patient_treatment_plans",
                schema: "patient_management",
                columns: table => new
                {
                    TreatmentPlanId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    Diagnosis = table.Column<string>(type: "text", nullable: false),
                    PrescribedMedications = table.Column<List<string>>(type: "text[]", nullable: false),
                    TreatmentDescription = table.Column<string>(type: "text", nullable: false),
                    RecommendedTests = table.Column<string>(type: "text", nullable: true),
                    FollowUpInstructions = table.Column<string>(type: "text", nullable: true),
                    NextReviewDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_treatment_plans", x => x.TreatmentPlanId);
                    table.ForeignKey(
                        name: "FK_patient_treatment_plans_patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "patient_management",
                        principalTable: "patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "address_locations",
                schema: "patient_management",
                columns: table => new
                {
                    AddressLocationId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    PatientAddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address_locations", x => x.AddressLocationId);
                    table.ForeignKey(
                        name: "FK_address_locations_patient_addresses_PatientAddressId",
                        column: x => x.PatientAddressId,
                        principalSchema: "patient_management",
                        principalTable: "patient_addresses",
                        principalColumn: "PatientAddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patient_appointment_cancellations",
                schema: "patient_management",
                columns: table => new
                {
                    CancellationId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    AppointmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CancellationReason = table.Column<string>(type: "text", nullable: false),
                    CancelledAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CancelledBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_appointment_cancellations", x => x.CancellationId);
                    table.ForeignKey(
                        name: "FK_patient_appointment_cancellations_patient_appointments_Appo~",
                        column: x => x.AppointmentId,
                        principalSchema: "patient_management",
                        principalTable: "patient_appointments",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patient_appointment_reminders",
                schema: "patient_management",
                columns: table => new
                {
                    ReminderId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    AppointmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReminderMethod = table.Column<string>(type: "text", nullable: false),
                    IsSent = table.Column<bool>(type: "boolean", nullable: false),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_appointment_reminders", x => x.ReminderId);
                    table.ForeignKey(
                        name: "FK_patient_appointment_reminders_patient_appointments_Appointm~",
                        column: x => x.AppointmentId,
                        principalSchema: "patient_management",
                        principalTable: "patient_appointments",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patient_allergies",
                schema: "patient_management",
                columns: table => new
                {
                    AllergyId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    MedicalRecordId = table.Column<Guid>(type: "uuid", nullable: false),
                    AllergyName = table.Column<string>(type: "text", nullable: false),
                    Severity = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_allergies", x => x.AllergyId);
                    table.ForeignKey(
                        name: "FK_patient_allergies_patient_medical_records_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalSchema: "patient_management",
                        principalTable: "patient_medical_records",
                        principalColumn: "MedicalRecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patient_medications",
                schema: "patient_management",
                columns: table => new
                {
                    MedicationId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    MedicalRecordId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicationName = table.Column<string>(type: "text", nullable: false),
                    Dosage = table.Column<string>(type: "text", nullable: false),
                    Frequency = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_medications", x => x.MedicationId);
                    table.ForeignKey(
                        name: "FK_patient_medications_patient_medical_records_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalSchema: "patient_management",
                        principalTable: "patient_medical_records",
                        principalColumn: "MedicalRecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patient_appointment_details",
                schema: "patient_management",
                columns: table => new
                {
                    AppointmentDetailId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    AppointmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReasonForVisit = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    TreatmentPlanId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_appointment_details", x => x.AppointmentDetailId);
                    table.ForeignKey(
                        name: "FK_patient_appointment_details_patient_appointments_Appointmen~",
                        column: x => x.AppointmentId,
                        principalSchema: "patient_management",
                        principalTable: "patient_appointments",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_patient_appointment_details_patient_treatment_plans_Treatme~",
                        column: x => x.TreatmentPlanId,
                        principalSchema: "patient_management",
                        principalTable: "patient_treatment_plans",
                        principalColumn: "TreatmentPlanId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_patients_DateOfBirth",
                schema: "patient_management",
                table: "patients",
                column: "DateOfBirth");

            migrationBuilder.CreateIndex(
                name: "IX_patients_FirstName_LastName",
                schema: "patient_management",
                table: "patients",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_patients_PatientId",
                schema: "patient_management",
                table: "patients",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_address_locations_City",
                schema: "patient_management",
                table: "address_locations",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_address_locations_Country",
                schema: "patient_management",
                table: "address_locations",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_address_locations_PatientAddressId",
                schema: "patient_management",
                table: "address_locations",
                column: "PatientAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_patient_addresses_PatientId",
                schema: "patient_management",
                table: "patient_addresses",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_patient_allergies_MedicalRecordId",
                schema: "patient_management",
                table: "patient_allergies",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_patient_appointment_cancellations_AppointmentId",
                schema: "patient_management",
                table: "patient_appointment_cancellations",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_patient_appointment_details_AppointmentId",
                schema: "patient_management",
                table: "patient_appointment_details",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_patient_appointment_details_TreatmentPlanId",
                schema: "patient_management",
                table: "patient_appointment_details",
                column: "TreatmentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_patient_appointment_reminders_AppointmentId",
                schema: "patient_management",
                table: "patient_appointment_reminders",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_patient_appointments_AppointmentDate",
                schema: "patient_management",
                table: "patient_appointments",
                column: "AppointmentDate");

            migrationBuilder.CreateIndex(
                name: "IX_patient_appointments_DoctorId",
                schema: "patient_management",
                table: "patient_appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_patient_appointments_PatientId",
                schema: "patient_management",
                table: "patient_appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_patient_appointments_Status",
                schema: "patient_management",
                table: "patient_appointments",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_patient_audits_PatientId",
                schema: "patient_management",
                table: "patient_audits",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_patient_audits_UpdatedAt",
                schema: "patient_management",
                table: "patient_audits",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_patient_contacts_PatientId",
                schema: "patient_management",
                table: "patient_contacts",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_patient_medical_records_PatientId",
                schema: "patient_management",
                table: "patient_medical_records",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_patient_medications_MedicalRecordId",
                schema: "patient_management",
                table: "patient_medications",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_patient_treatment_plans_PatientId",
                schema: "patient_management",
                table: "patient_treatment_plans",
                column: "PatientId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patients_patient_medical_records_PatientId",
                schema: "patient_management",
                table: "patients");

            migrationBuilder.DropTable(
                name: "address_locations",
                schema: "patient_management");

            migrationBuilder.DropTable(
                name: "patient_allergies",
                schema: "patient_management");

            migrationBuilder.DropTable(
                name: "patient_appointment_cancellations",
                schema: "patient_management");

            migrationBuilder.DropTable(
                name: "patient_appointment_details",
                schema: "patient_management");

            migrationBuilder.DropTable(
                name: "patient_appointment_reminders",
                schema: "patient_management");

            migrationBuilder.DropTable(
                name: "patient_audits",
                schema: "patient_management");

            migrationBuilder.DropTable(
                name: "patient_contacts",
                schema: "patient_management");

            migrationBuilder.DropTable(
                name: "patient_medications",
                schema: "patient_management");

            migrationBuilder.DropTable(
                name: "patient_addresses",
                schema: "patient_management");

            migrationBuilder.DropTable(
                name: "patient_treatment_plans",
                schema: "patient_management");

            migrationBuilder.DropTable(
                name: "patient_appointments",
                schema: "patient_management");

            migrationBuilder.DropTable(
                name: "patient_medical_records",
                schema: "patient_management");

            migrationBuilder.DropIndex(
                name: "IX_patients_DateOfBirth",
                schema: "patient_management",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_patients_FirstName_LastName",
                schema: "patient_management",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_patients_PatientId",
                schema: "patient_management",
                table: "patients");
        }
    }
}
