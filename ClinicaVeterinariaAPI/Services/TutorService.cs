using ClinicaVeterinariaApi.Models;
using ClinicaVeterinariaApi.Repositories.Interfaces;

namespace ClinicaVeterinariaApi.Services
{
    public class TutorService : ITutorService
    {
        private readonly ITutorRepository _tutorRepository;

        public TutorService(ITutorRepository tutorRepository)
        {
            _tutorRepository = tutorRepository;
        }

        public async Task<Tutor> CreateTutorAsync(Tutor tutor)
        {
            if (string.IsNullOrWhiteSpace(tutor.Nome) || string.IsNullOrWhiteSpace(tutor.Telefone))
                throw new ArgumentException("Nome e telefone são obrigatórios.");

            return await _tutorRepository.AddAsync(tutor);
        }

        public async Task<IEnumerable<Tutor>> GetAllAsync() => await _tutorRepository.GetAllAsync();

        public async Task<Tutor?> GetByIdAsync(int id) => await _tutorRepository.GetByIdAsync(id);

        public async Task<Tutor?> UpdateAsync(int id, Tutor tutor)
        {
            var existing = await _tutorRepository.GetByIdAsync(id);
            if (existing == null)
            return null;

            tutor.Id = id; 
            return await _tutorRepository.UpdateAsync(tutor);
        }

        public async Task<bool> DeleteAsync(int id) => await _tutorRepository.DeleteAsync(id);
    }
}
