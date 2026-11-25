using System;
using System.Collections.Generic;

namespace Bibliotec_MVC__Manha.Models;

public partial class Administrador
{
    public int IdAdministrador { get; set; }

    public string NIF { get; set; } = null!;

    public int NivelAcesso { get; set; }

    public virtual Usuario IdAdministradorNavigation { get; set; } = null!;
}
