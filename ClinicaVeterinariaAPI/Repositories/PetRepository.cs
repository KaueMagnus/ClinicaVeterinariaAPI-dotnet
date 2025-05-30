using ClinicaVeterinariaApi.Data;
using ClinicaVeterinariaApi.Models;
using ClinicaVeterinariaApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinariaApi.Repositories;

public class PetRepository : IPetRepository
{
    private readonly AppDbContext _context;

    public PetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pet>> GetAllAsync()
    {
        return await _context.Pets.Include(p => p.Tutor).ToListAsync();
    }

    public async Task<Pet?> GetByIdAsync(int id)
    {
        return await _context.Pets.Include(p => p.Tutor).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Pet> AddAsync(Pet pet)
    {
        _context.Pets.Add(pet);
        await _context.SaveChangesAsync();
        return pet;
    }

    public async Task<Pet?> UpdateAsync(Pet pet)
    {
        var existingPet = await _context.Pets.FindAsync(pet.Id);
        if (existingPet == null) return null;

        existingPet.Nome = pet.Nome;
        existingPet.Especie = pet.Especie;
        existingPet.Raca = pet.Raca;
        existingPet.TutorId = pet.TutorId;

        await _context.SaveChangesAsync();
        return existingPet;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pet = await _context.Pets.FindAsync(id);
        if (pet == null) return false;

        _context.Pets.Remove(pet);
        await _context.SaveChangesAsync();
        return true;
    }
}
