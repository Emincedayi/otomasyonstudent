using Microsoft.EntityFrameworkCore;
using otomasyonstudent.Attendances;
using otomasyonstudent.Courses;
using otomasyonstudent.Enrollments;
using otomasyonstudent.Grades;
using otomasyonstudent.Students;
using otomasyonstudent.Teachers;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace otomasyonstudent.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class otomasyonstudentDbContext :
    AbpDbContext<otomasyonstudentDbContext>,
    ITenantManagementDbContext,
    IIdentityDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Enrollment> Enrollments { get; set; } = null!;
    public DbSet<Grade> Grades { get; set; } = null!;
    public DbSet<Attendance> Attendances { get; set; } = null!;

    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public otomasyonstudentDbContext(DbContextOptions<otomasyonstudentDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        builder.ConfigureBlobStoring();
        
        /* Configure your own tables/entities inside here */

        builder.Entity<Student>(b =>
            {
                b.ToTable("Students");
                b.HasKey(x => x.Id);
                b.Property(x => x.FirstName).IsRequired().HasMaxLength(StudentConsts.MaxFirstNameLength);
                b.Property(x => x.LastName).IsRequired().HasMaxLength(StudentConsts.MaxLastNameLength);
                b.Property(x => x.Email).HasMaxLength(StudentConsts.MaxEmailLength);
                b.Property(x => x.PhoneNumber).HasMaxLength(StudentConsts.MaxPhoneNumberLength);
            });

            builder.Entity<Teacher>(b =>
            {
                b.ToTable("Teachers");
                b.HasKey(x => x.Id);
                b.Property(x => x.FirstName).IsRequired().HasMaxLength(TeacherConsts.MaxFirstNameLength);
                b.Property(x => x.LastName).IsRequired().HasMaxLength(TeacherConsts.MaxLastNameLength);
                b.Property(x => x.Email).HasMaxLength(TeacherConsts.MaxEmailLength);
                b.Property(x => x.PhoneNumber).HasMaxLength(TeacherConsts.MaxPhoneNumberLength);
            });

            builder.Entity<Course>(b =>
            {
                b.ToTable("Courses");
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).IsRequired().HasMaxLength(CourseConsts.MaxTitleLength);
                b.Property(x => x.Code).HasMaxLength(CourseConsts.MaxCodeLength);
                b.HasOne<Teacher>().WithMany().HasForeignKey(x => x.TeacherId).OnDelete(DeleteBehavior.SetNull);
            });

            builder.Entity<Enrollment>(b =>
            {
                b.ToTable("Enrollments");
                b.HasKey(x => x.Id);
                b.Property(x => x.Note).HasMaxLength(EnrollmentConsts.MaxNoteLength);
                b.HasOne<Student>().WithMany().HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne<Course>().WithMany().HasForeignKey(x => x.CourseId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Grade>(b =>
            {
                b.ToTable("Grades");
                b.HasKey(x => x.Id);
                b.Property(x => x.Value).IsRequired();
                b.Property(x => x.Note).HasMaxLength(GradeConsts.MaxNoteLength);
                b.HasOne<Enrollment>().WithMany().HasForeignKey(x => x.EnrollmentId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Attendance>(b =>
            {
                b.ToTable("Attendances");
                b.HasKey(x => x.Id);
                b.Property(x => x.Note).HasMaxLength(AttendanceConsts.MaxNoteLength);
                b.HasOne<Enrollment>().WithMany().HasForeignKey(x => x.EnrollmentId).OnDelete(DeleteBehavior.Cascade);
            });








        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(otomasyonstudentConsts.DbTablePrefix + "YourEntities", otomasyonstudentConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
