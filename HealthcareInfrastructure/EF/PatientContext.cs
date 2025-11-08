using HealthcareModel.Models.PatientManagement;
using HealthcareModel.Models.PatientManagement.PatientAppointment;
using HealthcareModel.Models.PatientManagement.PatientMedRecord;
using HealthcareModel.Models.PatientManagement.PatientPersonalnfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.Metrics;

namespace HealthcareInfrastructure.EF
{
    public class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options) : base(options)
        {

        }
        // DbSets for Patient Personal Information
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientContact> PatientContacts { get; set; }
        public DbSet<PatientAddress> PatientAddresses { get; set; }
        public DbSet<AddressLocation> AddressLocations { get; set; }
        public DbSet<PatientAudit> PatientAudits { get; set; }

        // DbSets for Patient Medical Records
        public DbSet<PatientMedicalRecord> PatientMedicalRecords { get; set; }
        public DbSet<PatientAllergy> PatientAllergies { get; set; }
        public DbSet<PatientMedication> PatientMedications { get; set; }

        // DbSets for Patient Appointments and Treatments
        public DbSet<PatientAppointment> PatientAppointments { get; set; }
        public DbSet<PatientAppointmentReminder> PatientAppointmentReminders { get; set; }
        public DbSet<PatientAppointmentDetail> PatientAppointmentDetails { get; set; }
        public DbSet<PatientAppointmentCancellation> PatientAppointmentCancellations { get; set; }
        public DbSet<PatientTreatmentPlan> PatientTreatmentPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Config for Patient Personal Information
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("patients", "patient_management");
                entity.HasKey(e => e.PatientId);
                entity.Property(e => e.PatientId).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.Occupation).IsRequired();
                entity.Property(e => e.MaritalStatus).HasConversion(typeof(string));

                entity.HasIndex(e => e.DateOfBirth);
                entity.HasIndex(e => new { e.FirstName, e.LastName });
                entity.HasIndex(e => e.PatientId);
                
                entity.HasOne(e => e.Contact)
                      .WithOne()
                      .HasForeignKey<PatientContact>(c => c.PatientId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Audits)
                      .WithOne()
                      .HasForeignKey<PatientAudit>(a => a.PatientId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(e => e.Addresses)
                      .WithOne()
                      .HasForeignKey(a => a.PatientId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(e => e.MedicalRecords)
                      .WithOne()
                      .HasForeignKey(mr => mr.PatientId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<PatientContact>(entity =>
            {
                entity.ToTable("patient_contacts", "patient_management");
                entity.HasKey(e => e.PatientContactId);
                entity.Property(e => e.PatientContactId).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.PatientId).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.PhoneNumber).IsRequired();

                entity.HasIndex(e => e.PatientId);
            });
            modelBuilder.Entity<PatientAddress>(entity => {
                entity.ToTable("patient_addresses", "patient_management");
                entity.HasKey(e => e.PatientAddressId);
                entity.Property(e => e.PatientAddressId).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.PatientId).IsRequired();
                entity.Property(e => e.Address1).IsRequired();
                
                entity.HasIndex(e => e.PatientId);

                entity.HasOne(e => e.Location)
                      .WithOne()
                      .HasForeignKey<AddressLocation>(l => l.PatientAddressId);
            });
            modelBuilder.Entity<AddressLocation>(entity =>
            {
                entity.ToTable("address_locations", "patient_management");
                entity.HasKey(e => e.AddressLocationId);
                entity.Property(e => e.AddressLocationId).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.PatientAddressId).IsRequired();

                entity.HasIndex(e => e.PatientAddressId);
                entity.HasIndex(e => e.City);
                entity.HasIndex(e => e.Country);
            });
            modelBuilder.Entity<PatientAudit>(entity =>
            {
                entity.ToTable("patient_audits", "patient_management");
                entity.HasKey(e => e.PatientAuditId);
                entity.Property(e => e.PatientAuditId).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.PatientId).IsRequired();
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasIndex(e => e.PatientId);
                entity.HasIndex(e => e.UpdatedAt);
            });

            // Config for Medical Records
            modelBuilder.Entity<PatientMedicalRecord>(entity =>
            {
                entity.ToTable("patient_medical_records", "patient_management");
                entity.HasKey(e => e.MedicalRecordId);
                entity.Property(e => e.MedicalRecordId).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.PatientId).IsRequired();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasIndex(e => e.PatientId);

                entity.HasMany(e => e.Allergies)
                      .WithOne()
                      .HasForeignKey(a => a.MedicalRecordId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(e => e.Medications)
                      .WithOne()
                      .HasForeignKey(m => m.MedicalRecordId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<PatientAllergy>(entity =>
            {
                entity.ToTable("patient_allergies", "patient_management");
                entity.HasKey(e => e.AllergyId);
                entity.Property(e => e.AllergyId).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.MedicalRecordId).IsRequired();
            });
            modelBuilder.Entity<PatientMedication>(entity =>
            {
                entity.ToTable("patient_medications", "patient_management");
                entity.HasKey(e => e.MedicationId);
                entity.Property(e => e.MedicationId).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.MedicalRecordId).IsRequired();
            });

            // Config for Appointments and Treatments
            modelBuilder.Entity<PatientAppointment>(entity =>
            {
                entity.ToTable("patient_appointments", "patient_management");
                entity.HasKey(e => e.AppointmentId);
                entity.Property(e => e.AppointmentId).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.Status).HasConversion(typeof(string));
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasIndex(e => e.PatientId);
                entity.HasIndex(e => e.DoctorId);
                entity.HasIndex(e => e.AppointmentDate);
                entity.HasIndex(e => e.Status);

                entity.HasOne(e => e.Patient)
                      .WithMany()
                      .HasForeignKey(e => e.PatientId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.AppointmentDetail)
                      .WithOne()
                      .HasForeignKey<PatientAppointmentDetail>(k => k.AppointmentId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.AppointmentCancellation)
                      .WithOne()
                      .HasForeignKey<PatientAppointmentCancellation>(k => k.AppointmentId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(e => e.AppointmentReminders)
                      .WithOne()
                      .HasForeignKey(r => r.AppointmentId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<PatientAppointmentReminder>(entity =>
            {
                entity.ToTable("patient_appointment_reminders", "patient_management");
                entity.HasKey(e => e.ReminderId);
                entity.Property(e => e.ReminderId).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.AppointmentId).IsRequired();
                entity.Property(e => e.ReminderMethod).HasConversion(typeof(string));
                entity.Property(e => e.ReminderMethod).IsRequired();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
            modelBuilder.Entity<PatientAppointmentDetail>(entity =>
            {
                entity.ToTable("patient_appointment_details", "patient_management");
                entity.HasKey(e => e.AppointmentDetailId);
                entity.Property(e => e.AppointmentDetailId).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.AppointmentId).IsRequired();
                entity.Property(e => e.ReasonForVisit).IsRequired();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
            modelBuilder.Entity<PatientAppointmentCancellation>(entity =>
            {
                entity.ToTable("patient_appointment_cancellations", "patient_management");
                entity.HasKey(e => e.CancellationId);
                entity.Property(e => e.CancellationId).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.AppointmentId).IsRequired();
                entity.Property(e => e.CancellationReason).IsRequired();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            }); 
            modelBuilder.Entity<PatientTreatmentPlan>(entity =>
            {
                entity.ToTable("patient_treatment_plans", "patient_management");
                entity.HasKey(e => e.TreatmentPlanId);
                entity.Property(e => e.TreatmentPlanId).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.TreatmentDescription).IsRequired();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.Status).HasConversion(typeof(string));

                entity.HasOne(e => e.Patient)
                      .WithMany()
                      .HasForeignKey(e => e.PatientId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Additional configurations for other entities can be added here
        }
    }
}
