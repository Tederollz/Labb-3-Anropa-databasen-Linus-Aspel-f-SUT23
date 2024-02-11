using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Labb_3___Anropa_databasen_Linus_Aspelöf_SUT23.Models;

[Table("Person")]
public partial class Person
{
    [Key]
    [Column("PersonID")]
    public int PersonId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Förnamn { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Efternamn { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string? Personnummer { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Befattning { get; set; }

    [InverseProperty("Person")]
    public virtual ICollection<Lärare> Lärares { get; set; } = new List<Lärare>();

    [InverseProperty("Person")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
