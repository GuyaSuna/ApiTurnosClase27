using ApiTurnos.Data;
using ApiTurnos.Entities;

namespace ApiTurnos.Repositories;

public class TurnoRepository(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public List<Turno> ObtenerTodos()
    {
        return _context.Turnos.OrderBy(t => t.Fecha).ToList();
    }

    public Turno? ObtenerPorId(int id)
    {
        return _context.Turnos.Find(id);
    }

    public Turno Crear(Turno turno)
    {
        _context.Turnos.Add(turno);
        _context.SaveChanges();
        return turno;
    }

    public void Modificar(Turno turno)
    {
        _context.Turnos.Update(turno);
        _context.SaveChanges();
    }

    public void Eliminar(Turno turno)
    {
        _context.Turnos.Remove(turno);
        _context.SaveChanges();
    }
}
