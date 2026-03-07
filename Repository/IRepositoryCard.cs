using backend.Models;
using backend.DTO;

public interface IRepositoryCard
{
    public Task<IEnumerable<ImmunizationSummaryDto>> GetAll();
    public Task<PatientImmunizationDto?> GetByPatientId(int patientId); 
    public Task<bool> AddCard(ImmunizationCard card);
    public Task<bool> DeleteRegisterById(int id);
}