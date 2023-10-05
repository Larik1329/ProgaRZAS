using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kakoyzheyadebil.Domain;

public partial class InspectorTestContext : DbContext
{
    public InspectorTestContext()
    {
    }

    public InspectorTestContext(DbContextOptions<InspectorTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Application1> Applications1 { get; set; }

    public virtual DbSet<EducationManager> EducationManagers { get; set; }

    public virtual DbSet<EducationManager1> EducationManagers1 { get; set; }

    public virtual DbSet<HeadEducation> HeadEducations { get; set; }

    public virtual DbSet<HeadEducation1> HeadEducations1 { get; set; }

    public virtual DbSet<InspectorList> InspectorLists { get; set; }

    public virtual DbSet<InspectorsList> InspectorsLists { get; set; }

    public virtual DbSet<Operator> Operators { get; set; }

    public virtual DbSet<Operator1> Operators1 { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Report1> Reports1 { get; set; }

    public virtual DbSet<TestInf> TestInfs { get; set; }

    public virtual DbSet<TestInf1> TestInfs1 { get; set; }

    public virtual DbSet<TestResult> TestResults { get; set; }

    public virtual DbSet<TestResult1> TestResults1 { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-6FUOB0C;Database=INSPECTOR_TEST;Trusted_Connection = True;Integrated Security = true;Encrypt = false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.IdApplication).HasName("XPKApplication");

            entity.ToTable("Application");

            entity.Property(e => e.IdApplication)
                .ValueGeneratedNever()
                .HasColumnName("ID_application");
            entity.Property(e => e.DateTest)
                .HasColumnType("datetime")
                .HasColumnName("Date_Test");
            entity.Property(e => e.InspectorFio)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Inspector_FIO");
        });

        modelBuilder.Entity<Application1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Application$");

            entity.Property(e => e.DateTest)
                .HasColumnType("datetime")
                .HasColumnName("Date_Test");
            entity.Property(e => e.F4).HasMaxLength(255);
            entity.Property(e => e.F5).HasMaxLength(255);
            entity.Property(e => e.IdApplication).HasColumnName("ID_application");
            entity.Property(e => e.InspectorFio)
                .HasMaxLength(255)
                .HasColumnName("Inspector_FIO");
        });

        modelBuilder.Entity<EducationManager>(entity =>
        {
            entity.HasKey(e => e.IdEducationManager).HasName("XPKEducation_Manager");

            entity.ToTable("Education_Manager");

            entity.Property(e => e.IdEducationManager)
                .ValueGeneratedNever()
                .HasColumnName("ID_Education_Manager");
            entity.Property(e => e.DateTest)
                .HasColumnType("datetime")
                .HasColumnName("Date_Test");
            entity.Property(e => e.InspectorInformation)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Inspector_Information");
            entity.Property(e => e.JudgingCriteria)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Judging_Criteria");
        });

        modelBuilder.Entity<EducationManager1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Education_Manager$");

            entity.Property(e => e.DateTest)
                .HasColumnType("datetime")
                .HasColumnName("Date_Test");
            entity.Property(e => e.F5).HasMaxLength(255);
            entity.Property(e => e.IdEducationManager).HasColumnName("ID_Education_Manager");
            entity.Property(e => e.InspectorInformation)
                .HasMaxLength(255)
                .HasColumnName("Inspector_Information");
            entity.Property(e => e.JudgingCriteria)
                .HasMaxLength(255)
                .HasColumnName("Judging_Criteria");
        });

        modelBuilder.Entity<HeadEducation>(entity =>
        {
            entity.HasKey(e => new { e.IdOperator, e.IdHeadEducation, e.IdApplication }).HasName("XPKHead_education");

            entity.ToTable("Head_education");

            entity.Property(e => e.IdOperator).HasColumnName("ID_Operator");
            entity.Property(e => e.IdHeadEducation).HasColumnName("ID_Head_education");
            entity.Property(e => e.IdApplication).HasColumnName("ID_application");
            entity.Property(e => e.InfApplication)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Inf__application");
            entity.Property(e => e.InspectorAddress)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Inspector_Address");
            entity.Property(e => e.InspectorEmail)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Inspector_email");
            entity.Property(e => e.InspectorFio)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Inspector_FIO");
            entity.Property(e => e.InspectorPassport)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Inspector_passport");
            entity.Property(e => e.InspectorTelephone)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Inspector_telephone");

            entity.HasOne(d => d.Id).WithMany(p => p.HeadEducations)
                .HasForeignKey(d => new { d.IdOperator, d.IdApplication })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Запрашивает");
        });

        modelBuilder.Entity<HeadEducation1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Head_education$");

            entity.Property(e => e.IdApplication).HasColumnName("ID_application");
            entity.Property(e => e.IdHeadEducation).HasColumnName("ID_Head_education");
            entity.Property(e => e.IdOperator).HasColumnName("ID_Operator");
            entity.Property(e => e.InfApplication)
                .HasMaxLength(255)
                .HasColumnName("Inf_application");
            entity.Property(e => e.InspectorAddress)
                .HasMaxLength(255)
                .HasColumnName("Inspector_Address");
            entity.Property(e => e.InspectorEmail)
                .HasMaxLength(255)
                .HasColumnName("Inspector_email");
            entity.Property(e => e.InspectorFio)
                .HasMaxLength(255)
                .HasColumnName("Inspector_FIO");
            entity.Property(e => e.InspectorPassport).HasColumnName("Inspector_passport");
            entity.Property(e => e.InspectorTelephone)
                .HasMaxLength(255)
                .HasColumnName("Inspector_telephone");
        });

        modelBuilder.Entity<InspectorList>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Inspector_List$");

            entity.Property(e => e.DateTest)
                .HasColumnType("datetime")
                .HasColumnName("Date_Test");
            entity.Property(e => e.IdApplication).HasColumnName("ID_application");
            entity.Property(e => e.IdEducationManager).HasColumnName("ID_Education_Manager");
            entity.Property(e => e.IdHeadEducation).HasColumnName("ID_Head_education");
            entity.Property(e => e.IdInspector).HasColumnName("ID_Inspector");
            entity.Property(e => e.IdOperator).HasColumnName("ID_Operator");
            entity.Property(e => e.InspectorAddress)
                .HasMaxLength(255)
                .HasColumnName("Inspector_Address");
            entity.Property(e => e.InspectorEmail)
                .HasMaxLength(255)
                .HasColumnName("Inspector_email");
            entity.Property(e => e.InspectorFio)
                .HasMaxLength(255)
                .HasColumnName("Inspector_FIO");
            entity.Property(e => e.InspectorPassport).HasColumnName("Inspector_passport");
            entity.Property(e => e.InspectorTelephone)
                .HasMaxLength(255)
                .HasColumnName("Inspector_telephone");
        });

        modelBuilder.Entity<InspectorsList>(entity =>
        {
            entity.HasKey(e => new { e.IdOperator, e.IdHeadEducation, e.IdEducationManager, e.IdInspector, e.IdApplication }).HasName("XPKInspectors_Inf");

            entity.ToTable("Inspectors_List");

            entity.Property(e => e.IdOperator).HasColumnName("ID_Operator");
            entity.Property(e => e.IdHeadEducation).HasColumnName("ID_Head_education");
            entity.Property(e => e.IdEducationManager).HasColumnName("ID_Education_Manager");
            entity.Property(e => e.IdInspector).HasColumnName("ID_Inspector");
            entity.Property(e => e.IdApplication).HasColumnName("ID_application");
            entity.Property(e => e.DateTest)
                .HasColumnType("datetime")
                .HasColumnName("Date_Test");
            entity.Property(e => e.InspectorAddress)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Inspector_Address");
            entity.Property(e => e.InspectorEmail)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Inspector_email");
            entity.Property(e => e.InspectorFio)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Inspector_FIO");
            entity.Property(e => e.InspectorPassport)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Inspector_passport");
            entity.Property(e => e.InspectorTelephone)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Inspector_telephone");

            entity.HasOne(d => d.IdEducationManagerNavigation).WithMany(p => p.InspectorsLists)
                .HasForeignKey(d => d.IdEducationManager)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Использует");

            entity.HasOne(d => d.Id).WithMany(p => p.InspectorsLists)
                .HasForeignKey(d => new { d.IdOperator, d.IdHeadEducation, d.IdApplication })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Формирует");
        });

        modelBuilder.Entity<Operator>(entity =>
        {
            entity.HasKey(e => new { e.IdOperator, e.IdApplication }).HasName("XPKOperator");

            entity.ToTable("Operator");

            entity.Property(e => e.IdOperator).HasColumnName("ID_Operator");
            entity.Property(e => e.IdApplication).HasColumnName("ID_application");
            entity.Property(e => e.InfApplication)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Inf_application");

            entity.HasOne(d => d.IdApplicationNavigation).WithMany(p => p.Operators)
                .HasForeignKey(d => d.IdApplication)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Поступает");
        });

        modelBuilder.Entity<Operator1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Operator$");

            entity.Property(e => e.IdApplication).HasColumnName("ID_application");
            entity.Property(e => e.IdOperator).HasColumnName("ID_Operator");
            entity.Property(e => e.InfApplication)
                .HasMaxLength(255)
                .HasColumnName("Inf_application");
            entity.Property(e => e.РябIdДолжности).HasColumnName("Ряб_ID_должности");
            entity.Property(e => e.РябАдрес)
                .HasMaxLength(255)
                .HasColumnName("Ряб_Адрес");
            entity.Property(e => e.РябОтчество)
                .HasMaxLength(255)
                .HasColumnName("Ряб_Отчество");
            entity.Property(e => e.РябТелефон)
                .HasMaxLength(255)
                .HasColumnName("Ряб_Телефон");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => new { e.IdOperator, e.IdReport, e.IdEducationManager, e.IdInspector, e.IdApplication }).HasName("XPKReport");

            entity.ToTable("Report");

            entity.Property(e => e.IdOperator).HasColumnName("ID_Operator");
            entity.Property(e => e.IdReport).HasColumnName("ID_Report");
            entity.Property(e => e.IdEducationManager).HasColumnName("ID_Education_Manager");
            entity.Property(e => e.IdInspector).HasColumnName("ID_Inspector");
            entity.Property(e => e.IdApplication).HasColumnName("ID_application");
            entity.Property(e => e.DateTest)
                .HasColumnType("datetime")
                .HasColumnName("Date_Test");
            entity.Property(e => e.InspectorInformation)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Inspector_Information");
            entity.Property(e => e.ScoreInspector).HasColumnName("Score_Inspector");

            entity.HasOne(d => d.Id).WithMany(p => p.Reports)
                .HasForeignKey(d => new { d.IdOperator, d.IdApplication })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Оформляет");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => new { d.IdOperator, d.IdEducationManager, d.IdInspector, d.IdApplication })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Используется");
        });

        modelBuilder.Entity<Report1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Report$");

            entity.Property(e => e.DateTest)
                .HasColumnType("datetime")
                .HasColumnName("Date_Test");
            entity.Property(e => e.IdApplication).HasColumnName("ID_application");
            entity.Property(e => e.IdEducationManager).HasColumnName("ID_Education_Manager");
            entity.Property(e => e.IdInspector).HasColumnName("ID_Inspector");
            entity.Property(e => e.IdOperator).HasColumnName("ID_Operator");
            entity.Property(e => e.IdReport).HasColumnName("ID_Report");
            entity.Property(e => e.InspectorInformation)
                .HasMaxLength(255)
                .HasColumnName("Inspector_Information");
            entity.Property(e => e.ScoreInspector).HasColumnName("Score_Inspector");
        });

        modelBuilder.Entity<TestInf>(entity =>
        {
            entity.HasKey(e => new { e.IdEducationManager, e.IdTest }).HasName("XPKTest_Inf");

            entity.ToTable("Test_Inf");

            entity.Property(e => e.IdEducationManager).HasColumnName("ID_Education_Manager");
            entity.Property(e => e.IdTest).HasColumnName("ID_Test");
            entity.Property(e => e.DateTest)
                .HasColumnType("datetime")
                .HasColumnName("Date_Test");
            entity.Property(e => e.InspectorInformation)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Inspector_Information");
            entity.Property(e => e.JudgingCriteria)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Judging_Criteria");
            entity.Property(e => e.Questions)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RightAnswers)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Right_Answers");
            entity.Property(e => e.TopicTest)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Topic_Test");

            entity.HasOne(d => d.IdEducationManagerNavigation).WithMany(p => p.TestInfs)
                .HasForeignKey(d => d.IdEducationManager)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Разрабатывает");
        });

        modelBuilder.Entity<TestInf1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Test_Inf$");

            entity.Property(e => e.DateTest)
                .HasColumnType("datetime")
                .HasColumnName("Date_Test");
            entity.Property(e => e.F8).HasMaxLength(255);
            entity.Property(e => e.IdEducationManager).HasColumnName("ID_Education_Manager");
            entity.Property(e => e.IdTest).HasColumnName("ID_Test");
            entity.Property(e => e.InspectorInformation)
                .HasMaxLength(255)
                .HasColumnName("Inspector_Information");
            entity.Property(e => e.JudgingCriteria)
                .HasMaxLength(255)
                .HasColumnName("Judging_Criteria");
            entity.Property(e => e.Questions).HasMaxLength(255);
            entity.Property(e => e.RightAnswers)
                .HasMaxLength(255)
                .HasColumnName("Right_Answers");
            entity.Property(e => e.TopicTest)
                .HasMaxLength(255)
                .HasColumnName("Topic_Test");
        });

        modelBuilder.Entity<TestResult>(entity =>
        {
            entity.HasKey(e => new { e.IdOperator, e.IdEducationManager, e.IdInspector, e.IdApplication }).HasName("XPKTest_Results");

            entity.ToTable("Test_Results");

            entity.Property(e => e.IdOperator).HasColumnName("ID_Operator");
            entity.Property(e => e.IdEducationManager).HasColumnName("ID_Education_Manager");
            entity.Property(e => e.IdInspector).HasColumnName("ID_Inspector");
            entity.Property(e => e.IdApplication).HasColumnName("ID_application");
            entity.Property(e => e.DateTest)
                .HasColumnType("datetime")
                .HasColumnName("Date_Test");
            entity.Property(e => e.InspectorInformation)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Inspector_Information");
            entity.Property(e => e.ScoreInspector).HasColumnName("Score_Inspector");

            entity.HasOne(d => d.IdOperatorNavigation).WithMany(p => p.TestResults)
                .HasForeignKey(d => d.IdOperator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Регистрирует");
        });

        modelBuilder.Entity<TestResult1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Test_Results$");

            entity.Property(e => e.DateTest)
                .HasColumnType("datetime")
                .HasColumnName("Date_Test");
            entity.Property(e => e.IdApplication).HasColumnName("ID_application");
            entity.Property(e => e.IdEducationManager).HasColumnName("ID_Education_Manager");
            entity.Property(e => e.IdInspector).HasColumnName("ID_Inspector");
            entity.Property(e => e.IdOperator).HasColumnName("ID_Operator");
            entity.Property(e => e.InspectorInformation)
                .HasMaxLength(255)
                .HasColumnName("Inspector_Information");
            entity.Property(e => e.ScoreInspector).HasColumnName("Score_Inspector");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
