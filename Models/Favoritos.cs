using System;
using System.Collections.Generic;

namespace Bibliotec_MVC__Manha.Models;

public partial class Favoritos
{
    public int IdFavorito { get; set; }

    public int IdAluno { get; set; }

    public int IdLivro { get; set; }

    public DateTime? DataFavorito { get; set; }

    public virtual Aluno IdAlunoNavigation { get; set; } = null!;

    public virtual Livro IdLivroNavigation { get; set; } = null!;
}
