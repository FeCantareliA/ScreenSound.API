using System.ComponentModel.DataAnnotations;

namespace ScreenSound8.API.Requests;

public record ArtistaRequest([Required] string nome, [Required] string bio, string? fotoPerfil);