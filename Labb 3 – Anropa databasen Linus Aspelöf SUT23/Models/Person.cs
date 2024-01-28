using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Labb_3___Anropa_databasen_Linus_Aspelöf_SUT23.Models;

public partial class Person
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PersonId { get; set; }

    public string? Förnamn { get; set; }

    public string? Efternamn { get; set; }

    public string? Personnummer { get; set; }

    public string? Befattning { get; set; }

    public virtual ICollection<Lärare> Lärares { get; set; } = new List<Lärare>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
