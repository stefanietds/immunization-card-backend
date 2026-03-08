namespace backend.src.Application.DTOs;

public class DoseDto
{
    public int CardId { get; set; }
    public int VaccineId { get; set; }
    public string VaccineName { get; set; }  = "";
    public int DoseNumber { get; set; }
    public DateTime Date { get; set; }
}
