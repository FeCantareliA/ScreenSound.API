
using ScreenSound8.Banco;
using ScreenSound8.Modelos;

namespace ScreenSound8.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}
