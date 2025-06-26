using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScreenSound8.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound8.Banco;
public class ScreenSound8Context : DbContext
{
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSoundV0;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    public ScreenSound8Context(DbContextOptions<ScreenSound8Context> options)
            : base(options)
    {
    }
    public ScreenSound8Context()
    : base(new DbContextOptionsBuilder<ScreenSound8Context>()
        .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSoundV0;Integrated Security=True;Encrypt=False;")
        .Options)
    { }



}