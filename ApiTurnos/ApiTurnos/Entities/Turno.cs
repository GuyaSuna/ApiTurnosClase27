namespace ApiTurnos.Entities;

public class Turno
{
    public int Id { get; set; }

    public string NombrePaciente { get; set; } = string.Empty;

    public string Especialidad { get; set; } = string.Empty;

    public DateTime Fecha { get; set; }

    public bool Confirmado { get; set; }
}
