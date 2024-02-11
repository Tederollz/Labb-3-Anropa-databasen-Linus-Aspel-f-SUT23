using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Labb_3___Anropa_databasen_Linus_Aspelöf_SUT23.Models;

[Table("Betyg")]
public partial class Betyg
{
    [Key]
    [Column("BetygID")]
    public int BetygId { get; set; }

    [Column("KursID")]
    public int? KursId { get; set; }

    [Column("StudentID")]
    public int? StudentId { get; set; }

    [Column("LärarID")]
    public int? LärarId { get; set; }

    [Column("Betyg")]
    [StringLength(2)]
    [Unicode(false)]
    public string? Betyg1 { get; set; }

    public DateOnly? Datum { get; set; }

    [ForeignKey("KursId")]
    [InverseProperty("Betygs")]
    public virtual Kur? Kurs { get; set; }

    [ForeignKey("LärarId")]
    [InverseProperty("Betygs")]
    public virtual Lärare? Lärar { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("Betygs")]
    public virtual Student? Student { get; set; }
}
