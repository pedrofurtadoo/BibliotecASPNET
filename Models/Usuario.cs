using System;
using System.Collections.Generic;

namespace Bibliotec_MVC__Manha.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public DateTime? DataCadastro { get; set; }

    public string? CaminhoFoto { get; set; }

    public bool? Excluido { get; set; }

    public virtual Administrador? Administrador { get; set; }

    public virtual Aluno? Aluno { get; set; }
}
