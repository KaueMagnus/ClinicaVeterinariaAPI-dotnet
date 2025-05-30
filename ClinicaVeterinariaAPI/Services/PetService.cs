using ClinicaVeterinariaApi.Models;
using ClinicaVeterinariaApi.Repositories.Interfaces;

namespace ClinicaVeterinariaApi.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly ITutorRepository _tutorRepository;

        public PetService(IPetRepository petRepository, ITutorRepository tutorRepository)
        {
            _petRepository = petRepository;
            _tutorRepository = tutorRepository;
        }

        public async Task<Pet> CreatePetAsync(Pet pet)
        {
            var tutor = await _tutorRepository.GetByIdAsync(pet.TutorId);
            if (tutor == null)
                throw new ArgumentException("Tutor não encontrado");

            return await _petRepository.AddAsync(pet);
        }

        public async Task<IEnumerable<Pet>> GetAllAsync() => await _petRepository.GetAllAsync();

        public async Task<Pet?> GetByIdAsync(int id) => await _petRepository.GetByIdAsync(id);

        public async Task<Pet?> UpdateAsync(int id, Pet pet)
        {
            var existing = await _petRepository.GetByIdAsync(id);
            if (existing == null)
                return null;

            pet.Id = id;
            return await _petRepository.UpdateAsync(pet);
        }

        public async Task<bool> DeleteAsync(int id) => await _petRepository.DeleteAsync(id);
    }
}