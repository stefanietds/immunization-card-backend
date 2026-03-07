using backend.Models;

public interface IRepositoryPatient
{
    public Task<IQueryable<Patient>> GetAll();
    public Task<bool> AddPatient(Patient patient);
    public Task<bool> RemovePatient(int id);
}