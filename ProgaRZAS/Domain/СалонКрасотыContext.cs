using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProgaRZAS.Domain;

namespace kakoyzheyadebil.Domain;

public partial class ВанappDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ВанappDbContext()
    {
    }

    public ВанappDbContext(DbContextOptions<ВанappDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ВанГруппыУслуг> ВанГруппыУслугs { get; set; }

    public virtual DbSet<ВанДолжности> ВанДолжностиs { get; set; }

    public virtual DbSet<ВанКлиенты> ВанКлиентыs { get; set; }

    public virtual DbSet<ВанКонтакты> ВанКонтактыs { get; set; }

    public virtual DbSet<ВанОказанныеУслуги> ВанОказанныеУслугиs { get; set; }

    public virtual DbSet<ВанПосещения> ВанПосещенияs { get; set; }

    public virtual DbSet<ВанСотрудники> ВанСотрудникиs { get; set; }

    public virtual DbSet<ВанУслуги> ВанУслугиs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-6FUOB0C;Database=Салон_красоты;Trusted_Connection = True;Integrated Security = true;Encrypt = false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ВанГруппыУслуг>(entity =>
        {
            entity.HasKey(e => e.ВанIdГруппы).HasName("XPKГруппы_услуг");

            entity.ToTable("Ряб_Группы_услуг");

            entity.Property(e => e.ВанIdГруппы)
                .ValueGeneratedNever()
                .HasColumnName("Ряб_ID_группы");
            entity.Property(e => e.ВанIdДолжности).HasColumnName("Ряб_ID_должности");
            entity.Property(e => e.ВанНазвание)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_Название");

            entity.HasOne(d => d.ВанIdДолжностиNavigation).WithMany(p => p.ВанГруппыУслугs)
                .HasForeignKey(d => d.ВанIdДолжности)
                .HasConstraintName("Имеют1");
        });

        modelBuilder.Entity<ВанДолжности>(entity =>
        {
            entity.HasKey(e => e.ВанIdДолжности).HasName("XPKДолжности");

            entity.ToTable("Ряб_Должности");

            entity.Property(e => e.ВанIdДолжности)
                .ValueGeneratedNever()
                .HasColumnName("Ряб_ID_должности");
            entity.Property(e => e.ВанГрафикРаботы)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_График_работы");
            entity.Property(e => e.ВанГруппаУслуг)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ряб_Группа_услуг");
            entity.Property(e => e.ВанНазвание)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ряб_Название");
        });

        modelBuilder.Entity<ВанКлиенты>(entity =>
        {
            entity.HasKey(e => new { e.ВанIdКлиента, e.ВанIdПосетителя }).HasName("XPKКлиенты");

            entity.ToTable("Ряб_Клиенты");

            entity.Property(e => e.ВанIdКлиента).HasColumnName("Ряб_ID_клиента");
            entity.Property(e => e.ВанIdПосетителя).HasColumnName("Ряб_ID_посетителя");
            entity.Property(e => e.ВанПостоянство)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_Постоянство");
            entity.Property(e => e.ВанФио)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_ФИО");

            entity.HasOne(d => d.ВанIdПосетителяNavigation).WithMany(p => p.ВанКлиентыs)
                .HasForeignKey(d => d.ВанIdПосетителя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Включают1");
        });

        modelBuilder.Entity<ВанКонтакты>(entity =>
        {
            entity.HasKey(e => new { e.ВанIdКлиента, e.ВанIdПосетителя }).HasName("XPKКонтакты");

            entity.ToTable("Ряб_Контакты");

            entity.Property(e => e.ВанIdКлиента).HasColumnName("Ряб_ID_клиента");
            entity.Property(e => e.ВанIdПосетителя).HasColumnName("Ряб_ID_посетителя");
            entity.Property(e => e.ВанEmail).HasColumnName("Ряб_Email");
            entity.Property(e => e.ВанSkype)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Ряб_Skype");
            entity.Property(e => e.ВанTelegram)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Ряб_Telegram");
            entity.Property(e => e.ВанТелефон).HasColumnName("Ряб_Телефон");

            entity.HasOne(d => d.Ван).WithOne(p => p.ВанКонтакты)
                .HasForeignKey<ВанКонтакты>(d => new { d.ВанIdКлиента, d.ВанIdПосетителя })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Имеют");
        });

        modelBuilder.Entity<ВанОказанныеУслуги>(entity =>
        {
            entity.HasKey(e => new { e.ВанIdУслуги, e.ВанIdГруппы, e.ВанIdСотрудника, e.ВанIdПосетителя }).HasName("XPKОказанные_услуги");

            entity.ToTable("Ряб_Оказанные_услуги");

            entity.Property(e => e.ВанIdУслуги).HasColumnName("Ряб_ID_услуги");
            entity.Property(e => e.ВанIdГруппы).HasColumnName("Ряб_ID_группы");
            entity.Property(e => e.ВанIdСотрудника).HasColumnName("Ряб_ID_сотрудника");
            entity.Property(e => e.ВанIdПосетителя).HasColumnName("Ряб_ID_посетителя");
            entity.Property(e => e.ВанСкидка).HasColumnName("Ряб_Скидка");

            entity.HasOne(d => d.ВанIdПосетителяNavigation).WithMany(p => p.ВанОказанныеУслугиs)
                .HasForeignKey(d => d.ВанIdПосетителя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Содержит");

            entity.HasOne(d => d.ВанIdСотрудникаNavigation).WithMany(p => p.ВанОказанныеУслугиs)
                .HasForeignKey(d => d.ВанIdСотрудника)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Включают");

            entity.HasOne(d => d.Ван).WithMany(p => p.ВанОказанныеУслугиs)
                .HasForeignKey(d => new { d.ВанIdУслуги, d.ВанIdГруппы })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Включают2");
        });

        modelBuilder.Entity<ВанПосещения>(entity =>
        {
            entity.HasKey(e => e.ВанIdПосетителя).HasName("XPKПосещения");

            entity.ToTable("Ряб_Посещения");

            entity.Property(e => e.ВанIdПосетителя)
                .ValueGeneratedNever()
                .HasColumnName("Ряб_ID_посетителя");
            entity.Property(e => e.ВанДата)
                .HasColumnType("datetime")
                .HasColumnName("Ряб_Дата");
            entity.Property(e => e.ВанКомментарийКлиента)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_Комментарий_клиента");
            entity.Property(e => e.ВанУслугаОказана)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Ряб_Услуга_оказана");
        });

        modelBuilder.Entity<ВанСотрудники>(entity =>
        {
            entity.HasKey(e => e.ВанIdСотрудника).HasName("XPKСотрудники");

            entity.ToTable("Ряб_Сотрудники");

            entity.Property(e => e.ВанIdСотрудника)
                .ValueGeneratedNever()
                .HasColumnName("Ряб_ID_сотрудника");
            entity.Property(e => e.ВанIdДолжности).HasColumnName("Ряб_ID_должности");
            entity.Property(e => e.ВанАдрес)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Ряб_Адрес");
            entity.Property(e => e.ВанАдресШифр)
                .HasMaxLength(256)
                .HasColumnName("Ряб_Адрес_шифр");
            entity.Property(e => e.ВанИмя)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_Имя");
            entity.Property(e => e.ВанОтчество)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_Отчество");
            entity.Property(e => e.ВанТелефон)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_Телефон");
            entity.Property(e => e.ВанФамилия)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_Фамилия");

            entity.HasOne(d => d.ВанIdДолжностиNavigation).WithMany(p => p.ВанСотрудникиs)
                .HasForeignKey(d => d.ВанIdДолжности)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ван_Сотрудники_Ван_Должности");
        });

        modelBuilder.Entity<ВанУслуги>(entity =>
        {
            entity.HasKey(e => new { e.ВанIdУслуги, e.ВанIdГруппы }).HasName("XPKУслуги");

            entity.ToTable("Ряб_Услуги");

            entity.Property(e => e.ВанIdУслуги).HasColumnName("Ряб_ID_услуги");
            entity.Property(e => e.ВанIdГруппы).HasColumnName("Ряб_ID_группы");
            entity.Property(e => e.ВанНазвание)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_Название");
            entity.Property(e => e.ВанОписаниеУслуги)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_Описание_услуги");
            entity.Property(e => e.ВанСебестоимость).HasColumnName("Ряб_Себестоимость");
            entity.Property(e => e.ВанЦена).HasColumnName("Ряб_Цена");

            entity.HasOne(d => d.ВанIdГруппыNavigation).WithMany(p => p.ВанУслугиs)
                .HasForeignKey(d => d.ВанIdГруппы)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Входят");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
