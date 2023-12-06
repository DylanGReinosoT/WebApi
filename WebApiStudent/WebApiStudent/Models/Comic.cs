using System;
using System.Collections.Generic;

namespace WebApiLibrary.Models;

public partial class Comic
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Tipo { get; set; }

    public DateOnly? FechaPublicacion { get; set; }
}
