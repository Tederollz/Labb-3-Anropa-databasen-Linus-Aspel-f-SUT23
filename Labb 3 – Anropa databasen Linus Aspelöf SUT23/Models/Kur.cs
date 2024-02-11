using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Labb_3___Anropa_databasen_Linus_Aspelöf_SUT23.Models;

public partial class Kur
{
    [Key]
    [Column("KursID")]
    public int KursId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Kursnamn { get; set; }

    [InverseProperty("Kurs")]
    public virtual ICollection<Betyg> Betygs { get; set; } = new List<Betyg>();
}
