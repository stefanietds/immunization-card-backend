using backend.Models;
using Microsoft.EntityFrameworkCore;

public class RepositoryPatient : IRepositoryPatient
{
    private readonly AppDbContext _context;

    public RepositoryPatient(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Patient>> GetAll()
    {
        return await Task.FromResult(_context.Patients.AsNoTracking());
    }

    public async Task<bool> AddPatient(Patient patient)
    {
        try
        {
            await _context.Patients.AddAsync(patient);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> RemovePatient(int patientId)
    {
        try
        {
            var patient = await _context.Patients.FindAsync(patientId);
            if (patient == null) return false;
            _context.Patients.Remove(patient);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}