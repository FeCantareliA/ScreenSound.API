namespace ScreenSound8.Web.Requests
{
    public record GeneroRequestEdit(int Id, string nome, string descricao)
     : GeneroRequest(nome,descricao);
}
