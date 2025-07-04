﻿
using ScreenSound8.Shared.Modelos.Modelos;
using System.Reflection.Metadata.Ecma335;

namespace ScreenSound8.Modelos;

public class Musica
{
    public Musica()
    {

    }
    public Musica(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; set; }
    public int Id { get; set; }
    public int? AnoLancamento { get; set; }
    public int? ArtistaId { get; set; }
    public virtual Artista? Artista { get; set; }
    public virtual ICollection<Genero> Generos { get; set; }
    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");

    }

    public override string ToString()
    {
        return @$"Id: {Id}
        Nome: {Nome}";

    }
}
