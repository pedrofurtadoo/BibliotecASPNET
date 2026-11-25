using System;
using System.Collections.Generic;

namespace Bibliotec_MVC__Manha.Models;

public partial class Aluno
{
    public int IdAluno { get; set; }

    public string Matricula { get; set; } = null!;

    public string? Celular { get; set; }

    public DateOnly DataNascimento { get; set; }

    public string? CodVerifEmail { get; set; }

    public bool EmailVerificado { get; set; }

    public int IdCurso { get; set; }

    public virtual ICollection<Favoritos> Favoritos { get; set; } = new List<Favoritos>();

    public virtual Usuario IdAlunoNavigation { get; set; } = null!;

    public virtual Curso IdCursoNavigation { get; set; } = null!;

    public virtual ICollection<Reserva> Reserva { get; set; } = new List<Reserva>();
}
