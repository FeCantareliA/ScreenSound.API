namespace ScreenSound8.API.Requests
{
    public record GeneroRequestEdit(int Id, string nome, string descricao)
     : GeneroRequest(nome,descricao);
}
