using ApiTurnos.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTurnos.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Turno> Turnos => Set<Turno>();
}
