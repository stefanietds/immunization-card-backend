using backend.src.Domain.Models;
using backend.src.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using backend.src.Infrastructure.Data;

namespace backend.src.Infrastructure.Repositories;

public class RepositoryCard : IRepositoryCard
{
    private readonly AppDbContext _context;

    public RepositoryCard(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ImmunizationSummaryDto>> GetAll()
    {
        return await _context.Immunizations
            .AsNoTracking()
            .Include(i => i.Patient)
            .GroupBy(i => i.PatientId)
            .Select(g => new ImmunizationSummaryDto
            {
                PatientId = g.Key,
                PatientName = g.First().Patient.Name
            })
            .ToListAsync();
    }

    public async Task<PatientImmunizationDto?> GetByPatientId(int patientId)
    {
        var patient = await _context.Patients
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == patientId);

        if (patient == null) return null;

        var doses = await _context.Immunizations
            .AsNoTracking()
            .Include(i => i.Vaccine)
            .Where(i => i.PatientId == patientId)
            .Select(i => new DoseDto
            {
                CardId = i.Id,
                VaccineId = i.VaccineId,
                VaccineName = i.Vaccine.Name,
                DoseNumber = i.Dose,
                Date = i.ApplicationDate
            })
            .ToListAsync();

        return new PatientImmunizationDto
        {
            PatientId = patientId,
            PatientName = patient.Name,
            Doses = doses
        };
    }

    public async Task<bool> AddCard(ImmunizationCard card)
    {
        try
        {
            await _context.Immunizations.AddAsync(card);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> DeleteRegisterById(int id)
    {
        try
        {
            var card = await _context.Immunizations.FindAsync(id);
            if (card == null)
                return false;

            _context.Immunizations.Remove(card);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
