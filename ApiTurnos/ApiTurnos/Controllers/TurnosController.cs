using ApiTurnos.Entities;
using ApiTurnos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTurnos.Controllers;

[ApiController]
[Route("[controller]")]
public class TurnosController(TurnoService turnoService) : ControllerBase
{
    private readonly TurnoService _turnoService = turnoService;

    [HttpGet]
    public ActionResult<List<Turno>> ObtenerTodos()
    {
        return Ok(_turnoService.ObtenerTodos());
    }

    [HttpGet("{id}")]
    public ActionResult<Turno> ObtenerPorId(int id)
    {
        var turno = _turnoService.ObtenerPorId(id);
        return turno is null ? NotFound() : Ok(turno);
    }

    [HttpPost]
    public ActionResult<Turno> Crear(Turno turno)
    {
        try
        {
            var turnoCreado = _turnoService.Crear(turno);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = turnoCreado.Id }, turnoCreado);
        }
        catch (ArgumentException exception)
        {
            return BadRequest(new { mensaje = exception.Message });
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Turno> Modificar(int id, Turno turno)
    {
        try
        {
            var turnoModificado = _turnoService.Modificar(id, turno);
            return turnoModificado is null ? NotFound() : Ok(turnoModificado);
        }
        catch (ArgumentException exception)
        {
            return BadRequest(new { mensaje = exception.Message });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        return _turnoService.Eliminar(id) ? NoContent() : NotFound();
    }
}
