using System;
using System.Collections.Generic;

namespace Bibliotec_MVC__Manha.Models;

public partial class Livro
{
    public int IdLivro { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public string? Editora { get; set; }

    public string? Idioma { get; set; }

    public string? CaminhoImagem { get; set; }

    public int IdAutor { get; set; }

    public int IdStatus { get; set; }

    public virtual ICollection<Favoritos> Favoritos { get; set; } = new List<Favoritos>();

    public virtual Autor IdAutorNavigation { get; set; } = null!;

    public virtual Status IdStatusNavigation { get; set; } = null!;

    public virtual ICollection<Reserva> Reserva { get; set; } = new List<Reserva>();

    public virtual ICollection<Categoria> IdCategoria { get; set; } = new List<Categoria>();
}
