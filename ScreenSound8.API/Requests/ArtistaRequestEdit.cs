using ScreenSound8.API.Requests;

namespace ScreenSound8.API.Requests
{

    public record ArtistaRequestEdit(int Id, string nome, string bio, string? fotoPerfil)
     : ArtistaRequest(nome, bio, fotoPerfil);
}
