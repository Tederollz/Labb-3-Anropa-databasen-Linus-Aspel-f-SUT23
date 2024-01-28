using System;
using System.Collections.Generic;

namespace Labb_3___Anropa_databasen_Linus_Aspelöf_SUT23.Models;

public partial class Lärare
{
    public int LärarId { get; set; }

    public int? PersonId { get; set; }

    public virtual ICollection<Betyg> Betygs { get; set; } = new List<Betyg>();

    public virtual Person? Person { get; set; }
}
