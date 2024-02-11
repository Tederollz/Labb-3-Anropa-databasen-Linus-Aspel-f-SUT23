using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Labb_3___Anropa_databasen_Linus_Aspelöf_SUT23.Models;

[Table("Lärare")]
public partial class Lärare
{
    [Key]
    [Column("LärarID")]
    public int LärarId { get; set; }

    [Column("PersonID")]
    public int? PersonId { get; set; }

    public DateOnly? Anställningsdatum { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Avdelning { get; set; }

    public int? Lön { get; set; }

    [InverseProperty("Lärar")]
    public virtual ICollection<Betyg> Betygs { get; set; } = new List<Betyg>();

    [ForeignKey("PersonId")]
    [InverseProperty("Lärares")]
    public virtual Person? Person { get; set; }
}
