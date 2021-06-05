
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetSystem.Entity;

namespace NetSystem.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(typeBuilder =>
            {
                typeBuilder.Property(x => x.Id).HasColumnName("User_Id");


            });

            builder.Entity<Coding>(op =>
            {

                op.Property(x => x.ID).UseIdentityColumn(1, 1);
                op.Property(x => x.CodeIndex).IsRequired();
                op.Property(x => x.Code).IsRequired();
                op.Property(x => x.CodeTitle).IsRequired().HasMaxLength(150);
                op.Property(x => x.Description).HasMaxLength(250);


                op.HasOne(x => x.Company)
                    .WithMany(x => x.Codings)
                    .HasForeignKey(x => x.CompanyID_FK)
                    .OnDelete(DeleteBehavior.Restrict).IsRequired();
                op.HasOne(x => x.Group)
                    .WithMany(x => x.Codings)
                    .HasForeignKey(x => x.GroupID_FK)
                    .OnDelete(DeleteBehavior.Restrict).IsRequired();
                op.HasOne(x => x.SubGroup)
                    .WithMany(x => x.Codings)
                    .HasForeignKey(x => x.SubGroupID_FK)
                    .OnDelete(DeleteBehavior.Restrict).IsRequired();
                op.HasOne(x => x.ApplicationUser)
                    .WithMany(x => x.Codings)
                    .HasForeignKey(x => x.UserID_FK)
                    .OnDelete(DeleteBehavior.Restrict).IsRequired();
            });

            builder.Entity<Applicant>(op =>
            {
                op.Property(x => x.ID).UseIdentityColumn(1, 1);
                op.Property(x => x.ApplicantTitle).IsRequired().HasMaxLength(150);
                op.Property(x => x.Description).HasMaxLength(250);
            });

            builder.Entity<Company>(op =>
            {
                op.Property(x => x.ID).UseIdentityColumn(1, 1);
                op.Property(x => x.CompanyTiltle).IsRequired().HasMaxLength(150);
                op.Property(x => x.Description).HasMaxLength(250);
                op.Property(x => x.CompnayIndex).IsRequired();

            });

            builder.Entity<ConsumablePart>(op =>
            {
                op.Property(x => x.ID).UseIdentityColumn(1, 1);
                op.Property(x => x.ConsumablePartTitel).IsRequired().HasMaxLength(250);
                op.HasOne(x => x.RequestRepair)
                    .WithMany(x => x.ConsumableParts)
                    .HasForeignKey(x => x.RequestID_FK)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
                op.HasOne(x => x.UnitOfMeasurement)
                    .WithMany(x => x.ConsumableParts)
                    .HasForeignKey(x => x.UnitID_FK)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);


            });

            builder.Entity<UnitOfMeasurement>(op =>
            {
                op.Property(x => x.ID).UseIdentityColumn(1, 1);
                op.Property(x => x.Unit).HasMaxLength(150).IsRequired();
                op.Property(x => x.Description).HasMaxLength(250);
            });

            builder.Entity<RequestRepair>(op =>
            {
                op.Property(x => x.ID).UseIdentityColumn(1, 1).IsRequired();
                op.Property(x => x.Registered).IsRequired().HasColumnType("datetime");
                op.Property(x => x.IsActive).IsRequired();
                op.Property(x => x.IsDelete).IsRequired();
                op.Property(x => x.RequestTitle).HasMaxLength(500).IsRequired();
                op.Property(x => x.RequestDataTime).IsRequired();

                op.HasOne(x => x.ApplicationUser)
                    .WithMany(x => x.RequestRepairs)
                    .HasForeignKey(x => x.UserID_FK)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
                op.HasOne(x => x.Applicant)
                     .WithMany(x => x.RequestRepairs)
                     .OnDelete(DeleteBehavior.Restrict)
                     .HasForeignKey(x => x.ApplicantID_FK)
                     .IsRequired();
                op.HasOne(x => x.Machinery)
                    .WithMany(x => x.RequestRepairs)
                    .HasForeignKey(x => x.MachineryID_FK)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
                op.HasOne(x => x.TypeofRepair)
                    .WithMany(x => x.RequestRepairs)
                    .HasForeignKey(x => x.TypeofRepairID_FK)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            builder.Entity<Group>(op =>
            {
                op.Property(x => x.ID).UseIdentityColumn(1, 1);
                op.Property(x => x.GroupIndex).IsRequired();
                op.Property(x => x.GroupTitle).HasMaxLength(250).IsRequired();
                op.Property(x => x.Description).HasMaxLength(250);

                op.HasOne(x => x.Company)
                    .WithMany(x => x.Groups)
                    .HasForeignKey(x => x.CompanyID_FK)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            builder.Entity<Machinery>(op =>
            {
                op.Property(x => x.ID).UseIdentityColumn(1, 1);
                op.Property(x => x.IsActive).IsRequired();
                op.Property(x => x.IsDelete).IsRequired();
                op.Property(x => x.MachineryTitle).HasMaxLength(250).IsRequired();
                op.Property(x => x.Description).HasMaxLength(250);
                op.HasOne(x => x.Coding)
                    .WithMany(x => x.Machineries)
                    .HasForeignKey(x => x.CodeID_FK)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

            });

            builder.Entity<SubGroup>(op =>
            {
                op.Property(x => x.ID).UseIdentityColumn(1, 1);
                op.Property(x => x.SubGroupIndex).IsRequired();
                op.Property(x => x.SubGroupTitle).IsRequired().HasMaxLength(250);
                op.Property(x => x.Description).HasMaxLength(250);
                op.HasOne(x => x.Group)
                     .WithMany(x => x.SubGroups)
                     .HasForeignKey(x => x.GroupID_FK)
                     .OnDelete(DeleteBehavior.Restrict).IsRequired();

                op.HasOne(x => x.Company)
                     .WithMany(s => s.SubGroups)
                     .HasForeignKey(x => x.CompanyID_FK)
                     .OnDelete(DeleteBehavior.Restrict).IsRequired();
            });

            builder.Entity<TypeofRepair>(op =>
            {
                op.Property(x => x.ID).UseIdentityColumn(1, 1);
                op.Property(x => x.TypeTitle).IsRequired().HasMaxLength(250);

            });

            builder.Entity<WorkOrder>(op =>
            {
                op.Property(x => x.ID).UseIdentityColumn(1, 1);
                op.Property(x => x.IsActive).IsRequired();
                op.Property(x => x.IsDelete).IsRequired();
                op.HasOne(x => x.RequestRepair)
                    .WithMany(x => x.WorkOrders)
                    .HasForeignKey(x => x.RequestID_FK)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
                op.Property(x => x.Electrical).IsRequired();
                op.Property(x => x.Mecanical).IsRequired();
                op.Property(x => x.Piping).IsRequired();
                op.Property(x => x.Creating).IsRequired();
                op.Property(x => x.Equip).IsRequired();
                op.Property(x => x.StartWorking).HasColumnType("datetime").IsRequired();
                op.Property(x => x.Cause_Exhaustion).IsRequired();
                op.Property(x => x.Cause_OperatorNegligence).IsRequired();
                op.Property(x => x.Cause_QualityofSpareParts).IsRequired();
                op.Property(x => x.Cause_RepairmanError).IsRequired();
                op.Property(x => x.OtherError).IsRequired();
                op.Property(x => x.OtherErrorDescription).HasMaxLength(500);
                op.Property(x => x.ReportRepair).IsRequired().HasMaxLength(800);
                op.Property(x => x.PersonHours).IsRequired();
                op.Property(x => x.ProductionPlanning).IsRequired();
                op.Property(x => x.NoSpareParts).IsRequired();
                op.Property(x => x.Other).IsRequired();
                op.Property(x => x.CloseRequest).IsRequired();
                op.Property(x => x.ProductionPlanningDescription).HasMaxLength(250);
                op.Property(x => x.NoSparePartsDescription).HasMaxLength(250);
                op.Property(x => x.OtherDescription).HasMaxLength(250);
                op.Property(x => x.PersonHoursDescription).HasMaxLength(250);
                op.Property(x => x.DateTimeClosing).HasColumnType("datetime");



            });

        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Coding> Codings { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<ConsumablePart> ConsumableParts { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Machinery> Machineries { get; set; }
        public virtual DbSet<RequestRepair> RequestRepairs { get; set; }
        public virtual DbSet<SubGroup> SubGroups { get; set; }
        public virtual DbSet<TypeofRepair> TypeofRepairs { get; set; }
        public virtual DbSet<WorkOrder> WorkOrders { get; set; }
        public virtual DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }

    }
}
