using ClinicaVeterinariaApi.Models;

namespace ClinicaVeterinariaApi.Services
{
    public interface IPetService
    {
        Task<Pet> CreatePetAsync(Pet pet);
        Task<IEnumerable<Pet>> GetAllAsync();
        Task<Pet?> GetByIdAsync(int id);
        Task<Pet?> UpdateAsync(int id, Pet pet);
        Task<bool> DeleteAsync(int id);
    }
}