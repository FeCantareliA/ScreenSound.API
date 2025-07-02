
using Microsoft.AspNetCore.Mvc;
using ScreenSound8.API.Requests;
using ScreenSound8.API.Response;
using ScreenSound8.Banco;
using ScreenSound8.Modelos;
using ScreenSound8.Shared.Modelos.Modelos;

namespace ScreenSound8.API.Endpoints;

public static class GenerosExtensions
{
    public static void AddEndPointsGeneros(this WebApplication app)
    {
        #region Endpoint Músicas
        app.MapGet("/Generos", ([FromServices] DAL<Genero> dal) =>
        {
            var generoList = dal.Listar();
            if (generoList is null)
            {
                return Results.NotFound();
            }
            var generoListResponse = EntityListToResponseList(generoList);
            return Results.Ok(generoListResponse);
        });

        app.MapGet("/Generos/{nome}", ([FromServices] DAL<Genero> dal, string nome) =>
        {
            var genero = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (genero is null)
            {
                return Results.NotFound();
            }
            var response = EntityToResponse(genero!);
            return Results.Ok(response);

        });

        app.MapPost("/Generos", ([FromServices] DAL<Genero> dal, [FromServices] DAL<Genero> dalGenero, [FromBody] GeneroRequest generoRequest) =>
        {
            dal.Adicionar(RequestToEntity(generoRequest));
        });

        app.MapDelete("/Generos/{id}", ([FromServices] DAL<Genero> dal, int id) => {
            var genero = dal.RecuperarPor(a => a.Id == id);
            if (genero is null)
            {
                return Results.NotFound("Gênero para exclusão não encontrado.");
            }
            dal.Deletar(genero);
            return Results.NoContent();

        });

        app.MapPut("/Generos", ([FromServices] DAL<Genero> dal, [FromBody] GeneroRequestEdit GeneroRequestEdit) => {
            var GeneroAAtualizar = dal.RecuperarPor(a => a.Id == GeneroRequestEdit.Id);
            if (GeneroAAtualizar is null)
            {
                return Results.NotFound();
            }
            GeneroAAtualizar.Nome = GeneroRequestEdit.Nome;
            GeneroAAtualizar.Descricao = GeneroRequestEdit.Descricao;

            dal.Atualizar(GeneroAAtualizar);
            return Results.Ok();
        });
        #endregion

    }

    private static ICollection<Genero> GeneroRequestConverter(ICollection<GeneroRequest> generos, [FromServices] DAL<Genero> dalGenero)
    {
        var listaDeGeneros = new List<Genero>();
        foreach (var item in generos)
        {
            var entity = RequestToEntity(item);
            var genero = dalGenero.RecuperarPor(g => g.Nome.ToUpper().Equals(item.Nome.ToUpper()));
            if (genero is not null)
            {
                listaDeGeneros.Add(genero);
            }
            else
            {
                listaDeGeneros.Add(entity);
            }
        }
        return listaDeGeneros;
    }
    private static Genero RequestToEntity(GeneroRequest genero)
    {
        return new Genero() { Nome = genero.Nome, Descricao = genero.Descricao };
    }

    private static ICollection<GeneroResponse> EntityListToResponseList(IEnumerable<Genero> GeneroList)
    {
        return GeneroList.Select(a => EntityToResponse(a)).ToList();
    }

    private static GeneroResponse EntityToResponse(Genero genero)
    {
        return new GeneroResponse(genero.Id, genero.Nome!, genero.Descricao!);
    }
}

