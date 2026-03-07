using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

[Table("Immunizations")]
public class ImmunizationCard
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }
    public int VaccineId { get; set; }
    public Vaccine? Vaccine { get; set; }
    public int Dose { get; set; }
    public DateTime ApplicationDate { get; set; }
}