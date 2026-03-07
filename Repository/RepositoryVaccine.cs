using backend.Models;
using Microsoft.EntityFrameworkCore;

public class RepositoryVaccine : IRepositoryVaccine
{
    private readonly AppDbContext _context;

    public RepositoryVaccine(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Vaccine>> GetAll()
    {
        return await Task.FromResult(_context.Vaccines.AsNoTracking());
    }

    public async Task<bool> AddVaccine(Vaccine vaccine)
    {
        try
        {
            await _context.Vaccines.AddAsync(vaccine);
             return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}