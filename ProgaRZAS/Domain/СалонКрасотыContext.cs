using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kakoyzheyadebil.Domain;

public partial class appDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public appDbContext()
    {
    }

    public appDbContext(DbContextOptions<appDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<РябГруппыУслуг> РябГруппыУслугs { get; set; }

    public virtual DbSet<РябДолжности> РябДолжностиs { get; set; }

    public virtual DbSet<РябКлиенты> РябКлиентыs { get; set; }

    public virtual DbSet<РябКонтакты> РябКонтактыs { get; set; }

    public virtual DbSet<РябОказанныеУслуги> РябОказанныеУслугиs { get; set; }

    public virtual DbSet<РябПосещения> РябПосещенияs { get; set; }

    public virtual DbSet<РябСотрудники> РябСотрудникиs { get; set; }

    public virtual DbSet<РябУслуги> РябУслугиs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-6FUOB0C;Database=Салон_красоты;Trusted_Connection = True;Integrated Security = true;Encrypt = false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<РябГруппыУслуг>(entity =>
        {
            entity.HasKey(e => e.РябIdГруппы).HasName("XPKГруппы_услуг");

            entity.ToTable("Ряб_Группы_услуг");

            entity.Property(e => e.РябIdГруппы)
                .ValueGeneratedNever()
                .HasColumnName("Ряб_ID_группы");
            entity.Property(e => e.РябIdДолжности).HasColumnName("Ряб_ID_должности");
            entity.Property(e => e.РябНазвание)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_Название");

            entity.HasOne(d => d.РябIdДолжностиNavigation).WithMany(p => p.РябГруппыУслугs)
                .HasForeignKey(d => d.РябIdДолжности)
                .HasConstraintName("Имеют1");
        });

        modelBuilder.Entity<РябДолжности>(entity =>
        {
            entity.HasKey(e => e.РябIdДолжности).HasName("XPKДолжности");

            entity.ToTable("Ряб_Должности");

            entity.Property(e => e.РябIdДолжности)
                .ValueGeneratedNever()
                .HasColumnName("Ряб_ID_должности");
            entity.Property(e => e.РябГрафикРаботы)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_График_работы");
            entity.Property(e => e.РябГруппаУслуг)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ряб_Группа_услуг");
            entity.Property(e => e.РябНазвание)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ряб_Название");
        });

        modelBuilder.Entity<РябКлиенты>(entity =>
        {
            entity.HasKey(e => new { e.РябIdКлиента, e.РябIdПосетителя }).HasName("XPKКлиенты");

            entity.ToTable("Ряб_Клиенты");

            entity.Property(e => e.РябIdКлиента).HasColumnName("Ряб_ID_клиента");
            entity.Property(e => e.РябIdПосетителя).HasColumnName("Ряб_ID_посетителя");
            entity.Property(e => e.РябПостоянство)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_Постоянство");
            entity.Property(e => e.РябФио)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_ФИО");

            entity.HasOne(d => d.РябIdПосетителяNavigation).WithMany(p => p.РябКлиентыs)
                .HasForeignKey(d => d.РябIdПосетителя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Включают1");
        });

        modelBuilder.Entity<РябКонтакты>(entity =>
        {
            entity.HasKey(e => new { e.РябIdКлиента, e.РябIdПосетителя }).HasName("XPKКонтакты");

            entity.ToTable("Ряб_Контакты");

            entity.Property(e => e.РябIdКлиента).HasColumnName("Ряб_ID_клиента");
            entity.Property(e => e.РябIdПосетителя).HasColumnName("Ряб_ID_посетителя");
            entity.Property(e => e.РябEmail).HasColumnName("Ряб_Email");
            entity.Property(e => e.РябSkype)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Ряб_Skype");
            entity.Property(e => e.РябTelegram)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Ряб_Telegram");
            entity.Property(e => e.РябТелефон).HasColumnName("Ряб_Телефон");

            entity.HasOne(d => d.Ряб).WithOne(p => p.РябКонтакты)
                .HasForeignKey<РябКонтакты>(d => new { d.РябIdКлиента, d.РябIdПосетителя })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Имеют");
        });

        modelBuilder.Entity<РябОказанныеУслуги>(entity =>
        {
            entity.HasKey(e => new { e.РябIdУслуги, e.РябIdГруппы, e.РябIdСотрудника, e.РябIdПосетителя }).HasName("XPKОказанные_услуги");

            entity.ToTable("Ряб_Оказанные_услуги");

            entity.Property(e => e.РябIdУслуги).HasColumnName("Ряб_ID_услуги");
            entity.Property(e => e.РябIdГруппы).HasColumnName("Ряб_ID_группы");
            entity.Property(e => e.РябIdСотрудника).HasColumnName("Ряб_ID_сотрудника");
            entity.Property(e => e.РябIdПосетителя).HasColumnName("Ряб_ID_посетителя");
            entity.Property(e => e.РябСкидка).HasColumnName("Ряб_Скидка");

            entity.HasOne(d => d.РябIdПосетителяNavigation).WithMany(p => p.РябОказанныеУслугиs)
                .HasForeignKey(d => d.РябIdПосетителя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Содержит");

            entity.HasOne(d => d.РябIdСотрудникаNavigation).WithMany(p => p.РябОказанныеУслугиs)
                .HasForeignKey(d => d.РябIdСотрудника)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Включают");

            entity.HasOne(d => d.Ряб).WithMany(p => p.РябОказанныеУслугиs)
                .HasForeignKey(d => new { d.РябIdУслуги, d.РябIdГруппы })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Включают2");
        });

        modelBuilder.Entity<РябПосещения>(entity =>
        {
            entity.HasKey(e => e.РябIdПосетителя).HasName("XPKПосещения");

            entity.ToTable("Ряб_Посещения");

            entity.Property(e => e.РябIdПосетителя)
                .ValueGeneratedNever()
                .HasColumnName("Ряб_ID_посетителя");
            entity.Property(e => e.РябДата)
                .HasColumnType("datetime")
                .HasColumnName("Ряб_Дата");
            entity.Property(e => e.РябКомментарийКлиента)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_Комментарий_клиента");
            entity.Property(e => e.РябУслугаОказана)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Ряб_Услуга_оказана");
        });

        modelBuilder.Entity<РябСотрудники>(entity =>
        {
            entity.HasKey(e => e.РябIdСотрудника).HasName("XPKСотрудники");

            entity.ToTable("Ряб_Сотрудники");

            entity.Property(e => e.РябIdСотрудника)
                .ValueGeneratedNever()
                .HasColumnName("Ряб_ID_сотрудника");
            entity.Property(e => e.РябIdДолжности).HasColumnName("Ряб_ID_должности");
            entity.Property(e => e.РябАдрес)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Ряб_Адрес");
            entity.Property(e => e.РябАдресШифр)
                .HasMaxLength(256)
                .HasColumnName("Ряб_Адрес_шифр");
            entity.Property(e => e.РябИмя)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_Имя");
            entity.Property(e => e.РябОтчество)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_Отчество");
            entity.Property(e => e.РябТелефон)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_Телефон");
            entity.Property(e => e.РябФамилия)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_Фамилия");

            entity.HasOne(d => d.РябIdДолжностиNavigation).WithMany(p => p.РябСотрудникиs)
                .HasForeignKey(d => d.РябIdДолжности)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ряб_Сотрудники_Ряб_Должности");
        });

        modelBuilder.Entity<РябУслуги>(entity =>
        {
            entity.HasKey(e => new { e.РябIdУслуги, e.РябIdГруппы }).HasName("XPKУслуги");

            entity.ToTable("Ряб_Услуги");

            entity.Property(e => e.РябIdУслуги).HasColumnName("Ряб_ID_услуги");
            entity.Property(e => e.РябIdГруппы).HasColumnName("Ряб_ID_группы");
            entity.Property(e => e.РябНазвание)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_Название");
            entity.Property(e => e.РябОписаниеУслуги)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ряб_Описание_услуги");
            entity.Property(e => e.РябСебестоимость).HasColumnName("Ряб_Себестоимость");
            entity.Property(e => e.РябЦена).HasColumnName("Ряб_Цена");

            entity.HasOne(d => d.РябIdГруппыNavigation).WithMany(p => p.РябУслугиs)
                .HasForeignKey(d => d.РябIdГруппы)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Входят");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
