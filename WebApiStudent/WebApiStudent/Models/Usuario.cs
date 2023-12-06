using System;
using System.Collections.Generic;

namespace WebApiLibrary.Models;

public partial class Usuario
{
    public int IdUsuarios { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Clave { get; set; }
}
