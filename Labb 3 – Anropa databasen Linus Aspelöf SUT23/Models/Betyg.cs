using System;
using System.Collections.Generic;

namespace Labb_3___Anropa_databasen_Linus_Aspelöf_SUT23.Models;

public partial class Betyg
{
    public int BetygId { get; set; }

    public int? KursId { get; set; }

    public int? StudentId { get; set; }

    public int? LärarId { get; set; }

    public string? Betyg1 { get; set; }

    public DateOnly? Datum { get; set; }

    public virtual Kur? Kurs { get; set; }

    public virtual Lärare? Lärar { get; set; }

    public virtual Student? Student { get; set; }
}
