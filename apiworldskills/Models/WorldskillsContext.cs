using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace apiworldskills.Models;

public partial class WorldskillsContext : DbContext
{
    public WorldskillsContext()
    {
    }

    public WorldskillsContext(DbContextOptions<WorldskillsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Competition> Competitions { get; set; }

    public virtual DbSet<CompetitionSkill> CompetitionSkills { get; set; }

    public virtual DbSet<Competitor> Competitors { get; set; }

    public virtual DbSet<Region> Regions { get; set; }


    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SkillBlock> SkillBlocks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Competition>(entity =>
        {
            entity.ToTable("competition'");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.DateEnd)
                .HasMaxLength(255)
                .HasColumnName("date_end");
            entity.Property(e => e.DateStart)
                .HasMaxLength(255)
                .HasColumnName("date_start");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<CompetitionSkill>(entity =>
        {
            entity.ToTable("competition skill");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CompetitionId).HasColumnName("competition_id");
            entity.Property(e => e.SkillId).HasColumnName("skill_id");
        });

        modelBuilder.Entity<Competitor>(entity =>
        {
            entity.ToTable("competitors");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DatetimeOfLogin)
                .HasColumnType("datetime")
                .HasColumnName("datetime of login");
            entity.Property(e => e.Ip)
                .HasMaxLength(15)
                .HasColumnName("ip");
            entity.Property(e => e.NameOfPc)
                .HasMaxLength(50)
                .HasColumnName("name of pc");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable("regions");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Area)
                .HasMaxLength(255)
                .HasColumnName("area");
            entity.Property(e => e.Capital)
                .HasMaxLength(255)
                .HasColumnName("capital");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__role__3213E83F7AF556F1");

            entity.ToTable("role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Role1)
                .HasMaxLength(50)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.ToTable("skill");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsFuture).HasColumnName("is_future");
            entity.Property(e => e.SkillBlockId).HasColumnName("skill_block_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.ЗонаБрифингаКвМ).HasColumnName("зона брифинга (кв# м)");
            entity.Property(e => e.КоличествоУчастниковВКоманде).HasColumnName("количество участников в команде");
            entity.Property(e => e.ПлощадьКомнатыОценкиНаОднуЭкспертнуюГруппуКвМ).HasColumnName("площадь комнаты оценки на одну экспертную группу (кв# м)");
            entity.Property(e => e.ПлощадьНаРабочееМестоКвМ).HasColumnName("площадь на рабочее место (кв#м)");
            entity.Property(e => e.ПлощадьСкладаКвМ).HasColumnName("площадь склада (кв# м)");
        });

        modelBuilder.Entity<SkillBlock>(entity =>
        {
            entity.ToTable("[skill block]");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.F10).HasMaxLength(255);
            entity.Property(e => e.Fio)
                .HasMaxLength(255)
                .HasColumnName("FIO");
            entity.Property(e => e.Gender)
                .HasMaxLength(255)
                .HasColumnName("gender");
            entity.Property(e => e.IdRole).HasColumnName("ID role");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Pin).HasColumnName("PIN");
            entity.Property(e => e.Region).HasColumnName("region");
            entity.Property(e => e.Skill).HasColumnName("skill");
            entity.Property(e => e.ДатаРождения)
                .HasColumnType("datetime")
                .HasColumnName("Дата рождения");
            entity.Property(e => e.Место).HasColumnName("место");
            entity.Property(e => e.Чемпионат).HasColumnName("чемпионат");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
