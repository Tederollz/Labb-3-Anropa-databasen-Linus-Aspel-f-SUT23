using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Labb_3___Anropa_databasen_Linus_Aspelöf_SUT23.Models;

public partial class SampleDBContext : DbContext
{
    public SampleDBContext()
    {
    }

    public SampleDBContext(DbContextOptions<SampleDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Betyg> Grades { get; set; }

    public virtual DbSet<Klass> Classes { get; set; }

    public virtual DbSet<Kur> Course { get; set; }

    public virtual DbSet<Lärare> Lärares { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = LINUSDESKTOP;Initial Catalog=SkolaDB;integrated security = True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Betyg>(entity =>
        {
            entity.HasKey(e => e.BetygId).HasName("PK__Betyg__E90ED048101BD7BB");

            entity.ToTable("Betyg");

            entity.Property(e => e.BetygId)
                .ValueGeneratedNever()
                .HasColumnName("BetygID");
            entity.Property(e => e.Betyg1)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("Betyg");
            entity.Property(e => e.KursId).HasColumnName("KursID");
            entity.Property(e => e.LärarId).HasColumnName("LärarID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Kurs).WithMany(p => p.Betygs)
                .HasForeignKey(d => d.KursId)
                .HasConstraintName("FK__Betyg__KursID__440B1D61");

            entity.HasOne(d => d.Lärar).WithMany(p => p.Betygs)
                .HasForeignKey(d => d.LärarId)
                .HasConstraintName("FK__Betyg__LärarID__45F365D3");

            entity.HasOne(d => d.Student).WithMany(p => p.Betygs)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Betyg__StudentID__44FF419A");
        });

        modelBuilder.Entity<Klass>(entity =>
        {
            entity.HasKey(e => e.KlassId).HasName("PK__Klass__CF47A60DDF41CA7A");

            entity.ToTable("Klass");

            entity.Property(e => e.KlassId)
                .ValueGeneratedNever()
                .HasColumnName("KlassID");
            entity.Property(e => e.Kursnamn)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Kur>(entity =>
        {
            entity.HasKey(e => e.KursId).HasName("PK__Kurs__BCCFFF3B84B09963");

            entity.Property(e => e.KursId)
                .ValueGeneratedNever()
                .HasColumnName("KursID");
            entity.Property(e => e.Kursnamn)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Lärare>(entity =>
        {
            entity.HasKey(e => e.LärarId).HasName("PK__Lärare__AD685B6C4AB2DBA2");

            entity.ToTable("Lärare");

            entity.Property(e => e.LärarId)
                .ValueGeneratedNever()
                .HasColumnName("LärarID");
            entity.Property(e => e.PersonId).HasColumnName("PersonID");

            entity.HasOne(d => d.Person).WithMany(p => p.Lärares)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__Lärare__PersonID__3F466844");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Person__AA2FFB858D68ED45");

            entity.ToTable("Person");

            entity.Property(e => e.PersonId)
                .ValueGeneratedOnAdd()
                .HasColumnName("PersonID");
            entity.Property(e => e.Befattning)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Efternamn)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Förnamn)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Personnummer)
                .HasMaxLength(12)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52A7946753E61");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("StudentID");
            entity.Property(e => e.KlassId).HasColumnName("KlassID");
            entity.Property(e => e.PersonId).HasColumnName("PersonID");

            entity.HasOne(d => d.Klass).WithMany(p => p.Students)
                .HasForeignKey(d => d.KlassId)
                .HasConstraintName("FK__Student__KlassID__3B75D760");

            entity.HasOne(d => d.Person).WithMany(p => p.Students)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__Student__PersonI__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
