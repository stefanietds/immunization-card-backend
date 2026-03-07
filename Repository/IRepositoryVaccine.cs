using backend.Models;

public interface IRepositoryVaccine
{
    public Task<IQueryable<Vaccine>> GetAll();
    public Task<bool> AddVaccine(Vaccine vaccine);
}