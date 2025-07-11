using System.ComponentModel.DataAnnotations;

namespace ScreenSound8.Web.Requests;

public record ArtistaRequest([Required]string nome, [Required]string bio, string? fotoPerfil);