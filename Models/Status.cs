using System;
using System.Collections.Generic;

namespace Bibliotec_MVC__Manha.Models;

public partial class Status
{
    public int IdStatus { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<Livro> Livro { get; set; } = new List<Livro>();

    public virtual ICollection<Reserva> Reserva { get; set; } = new List<Reserva>();
}
