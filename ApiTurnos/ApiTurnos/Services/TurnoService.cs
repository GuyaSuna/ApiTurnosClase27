using ApiTurnos.Entities;
using ApiTurnos.Repositories;

namespace ApiTurnos.Services;

public class TurnoService(TurnoRepository turnoRepository)
{
    private readonly TurnoRepository _turnoRepository = turnoRepository;

    public List<Turno> ObtenerTodos()
    {
        return _turnoRepository.ObtenerTodos();
    }

    public Turno? ObtenerPorId(int id)
    {
        return _turnoRepository.ObtenerPorId(id);
    }

    public Turno Crear(Turno turno)
    {
        Validar(turno);
        return _turnoRepository.Crear(turno);
    }

    public Turno? Modificar(int id, Turno turno)
    {
        var turnoExistente = _turnoRepository.ObtenerPorId(id);
        if (turnoExistente is null)
        {
            return null;
        }

        Validar(turno);
        turnoExistente.NombrePaciente = turno.NombrePaciente;
        turnoExistente.Especialidad = turno.Especialidad;
        turnoExistente.Fecha = turno.Fecha;
        turnoExistente.Confirmado = turno.Confirmado;

        _turnoRepository.Modificar(turnoExistente);
        return turnoExistente;
    }

    public bool Eliminar(int id)
    {
        var turno = _turnoRepository.ObtenerPorId(id);
        if (turno is null)
        {
            return false;
        }

        _turnoRepository.Eliminar(turno);
        return true;
    }

    private static void Validar(Turno turno)
    {
        if (string.IsNullOrWhiteSpace(turno.NombrePaciente))
        {
            throw new ArgumentException("El nombre del paciente es obligatorio.");
        }

        if (string.IsNullOrWhiteSpace(turno.Especialidad))
        {
            throw new ArgumentException("La especialidad es obligatoria.");
        }

        if (turno.Fecha.Date < DateTime.Today)
        {
            throw new ArgumentException("La fecha del turno no puede ser anterior a la fecha actual.");
        }
    }
}
