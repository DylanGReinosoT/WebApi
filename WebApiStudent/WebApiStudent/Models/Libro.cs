using System;
using System.Collections.Generic;

namespace WebApiLibrary.Models;

public partial class Libro
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Autor { get; set; }

    public string? Genero { get; set; }

    public DateOnly? Fechapublicacion { get; set; }
}
