using System;
using System.Collections.Generic;

namespace Labb_3___Anropa_databasen_Linus_Aspelöf_SUT23.Models;

public partial class Klass
{
    public int KlassId { get; set; }

    public string? Kursnamn { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
