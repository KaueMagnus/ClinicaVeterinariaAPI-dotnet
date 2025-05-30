using ClinicaVeterinariaApi.Models;

namespace ClinicaVeterinariaApi.Services
{
    public interface ITutorService
    {
        Task<Tutor> CreateTutorAsync(Tutor tutor);
        Task<IEnumerable<Tutor>> GetAllAsync();
        Task<Tutor?> GetByIdAsync(int id);
        Task<Tutor?> UpdateAsync(int id, Tutor tutor);
        Task<bool> DeleteAsync(int id);
    }
}