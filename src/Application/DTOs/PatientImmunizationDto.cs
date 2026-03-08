namespace backend.src.Application.DTOs;

public class PatientImmunizationDto
{
    public int PatientId { get; set; }
    public string PatientName { get; set; }  = "";
    public List<DoseDto> Doses { get; set; }
}
