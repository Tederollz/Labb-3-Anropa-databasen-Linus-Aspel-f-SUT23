using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

    public virtual DbSet<Betyg> Betygs { get; set; }

    public virtual DbSet<Klass> Klasses { get; set; }

    public virtual DbSet<Kur> Kurs { get; set; }

    public virtual DbSet<Lärare> Lärares { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = LINUSDESKTOP;Initial Catalog=SkolaDB;Integrated security = True;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Betyg>(entity =>
        {
            entity.HasKey(e => e.BetygId).HasName("PK__Betyg__E90ED048101BD7BB");

            entity.HasOne(d => d.Kurs).WithMany(p => p.Betygs).HasConstraintName("FK__Betyg__KursID__440B1D61");

            entity.HasOne(d => d.Lärar).WithMany(p => p.Betygs).HasConstraintName("FK__Betyg__LärarID__45F365D3");

            entity.HasOne(d => d.Student).WithMany(p => p.Betygs).HasConstraintName("FK__Betyg__StudentID__44FF419A");
        });

        modelBuilder.Entity<Klass>(entity =>
        {
            entity.HasKey(e => e.KlassId).HasName("PK__Klass__CF47A60DDF41CA7A");

            entity.Property(e => e.KlassId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Kur>(entity =>
        {
            entity.HasKey(e => e.KursId).HasName("PK__Kurs__BCCFFF3B84B09963");
        });

        modelBuilder.Entity<Lärare>(entity =>
        {
            entity.HasKey(e => e.LärarId).HasName("PK__Lärare__AD685B6C4AB2DBA2");

            entity.HasOne(d => d.Person).WithMany(p => p.Lärares).HasConstraintName("FK__Lärare__PersonID__3F466844");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Person__AA2FFB858D68ED45");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52A7946753E61");

            entity.HasOne(d => d.Klass).WithMany(p => p.Students).HasConstraintName("FK__Student__KlassID__3B75D760");

            entity.HasOne(d => d.Person).WithMany(p => p.Students).HasConstraintName("FK__Student__PersonI__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
