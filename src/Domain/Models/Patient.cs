namespace backend.src.Domain.Models;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Cpf { get; set; } = "";
    public List<ImmunizationCard>? Immunizations { get; set; }
}
