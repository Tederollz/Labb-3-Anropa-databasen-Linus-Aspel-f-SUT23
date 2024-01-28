using System;
using System.Collections.Generic;

namespace Labb_3___Anropa_databasen_Linus_Aspelöf_SUT23.Models;

public partial class Kur
{
    public int KursId { get; set; }

    public string? Kursnamn { get; set; }

    public virtual ICollection<Betyg> Betygs { get; set; } = new List<Betyg>();
}
