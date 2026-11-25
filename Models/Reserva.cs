using System;
using System.Collections.Generic;

namespace Bibliotec_MVC__Manha.Models;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public int IdAluno { get; set; }

    public int IdLivro { get; set; }

    public int IdStatus { get; set; }

    public DateOnly DataReserva { get; set; }

    public DateOnly? DataRetirada { get; set; }

    public DateOnly? DataPrevistaDevolucao { get; set; }

    public DateOnly? DataDevolucao { get; set; }

    public string? Observacoes { get; set; }

    public virtual Aluno IdAlunoNavigation { get; set; } = null!;

    public virtual Livro IdLivroNavigation { get; set; } = null!;

    public virtual Status IdStatusNavigation { get; set; } = null!;
}
