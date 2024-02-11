using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Labb_3___Anropa_databasen_Linus_Aspelöf_SUT23.Models;

[Table("Klass")]
public partial class Klass
{
    [Key]
    [Column("KlassID")]
    public int KlassId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Klassnamn { get; set; }

    [InverseProperty("Klass")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
