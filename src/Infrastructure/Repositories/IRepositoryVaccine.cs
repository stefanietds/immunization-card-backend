using backend.src.Domain.Models;

namespace backend.src.Infrastructure.Repositories;

public interface IRepositoryVaccine
{
    public Task<IQueryable<Vaccine>> GetAll();
    public Task<bool> AddVaccine(Vaccine vaccine);
}
