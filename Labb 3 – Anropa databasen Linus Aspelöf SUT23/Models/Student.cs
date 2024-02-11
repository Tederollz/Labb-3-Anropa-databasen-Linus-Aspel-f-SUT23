using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Labb_3___Anropa_databasen_Linus_Aspelöf_SUT23.Models;

[Table("Student")]
public partial class Student
{
    [Key]
    [Column("StudentID")]
    public int StudentId { get; set; }

    [Column("KlassID")]
    public int? KlassId { get; set; }

    [Column("PersonID")]
    public int? PersonId { get; set; }

    [InverseProperty("Student")]
    public virtual ICollection<Betyg> Betygs { get; set; } = new List<Betyg>();

    [ForeignKey("KlassId")]
    [InverseProperty("Students")]
    public virtual Klass? Klass { get; set; }

    [ForeignKey("PersonId")]
    [InverseProperty("Students")]
    public virtual Person? Person { get; set; }
}
