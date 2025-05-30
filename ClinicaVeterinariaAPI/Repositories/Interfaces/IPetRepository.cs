using ClinicaVeterinariaApi.Models;

namespace ClinicaVeterinariaApi.Repositories.Interfaces;

public interface IPetRepository
{
    Task<IEnumerable<Pet>> GetAllAsync();
    Task<Pet?> GetByIdAsync(int id);
    Task<Pet> AddAsync(Pet pet);
    Task<Pet?> UpdateAsync(Pet pet);
    Task<bool> DeleteAsync(int id);
}