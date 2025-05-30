using ClinicaVeterinariaApi.Models;

namespace ClinicaVeterinariaApi.Repositories.Interfaces;

public interface ITutorRepository
{
    Task<IEnumerable<Tutor>> GetAllAsync();
    Task<Tutor?> GetByIdAsync(int id);
    Task<Tutor> AddAsync(Tutor tutor);
    Task<Tutor?> UpdateAsync(Tutor tutor);
    Task<bool> DeleteAsync(int id);
}