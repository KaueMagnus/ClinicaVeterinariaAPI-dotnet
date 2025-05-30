using ClinicaVeterinariaApi.Models;
using ClinicaVeterinariaApi.Repositories.Interfaces;
using ClinicaVeterinariaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinariaApi.Repositories;

public class TutorRepository : ITutorRepository
{
    private readonly AppDbContext _context;

    public TutorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tutor>> GetAllAsync()
    {
        return await _context.Tutores.Include(t => t.Pets).ToListAsync();
    }

    public async Task<Tutor?> GetByIdAsync(int id)
    {
        return await _context.Tutores.Include(t => t.Pets).FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Tutor> AddAsync(Tutor tutor)
    {
        _context.Tutores.Add(tutor);
        await _context.SaveChangesAsync();
        return tutor;
    }

    public async Task<Tutor?> UpdateAsync(Tutor tutor)
    {
        var tutorExistente = await _context.Tutores.FindAsync(tutor.Id);
        if (tutorExistente == null) return null;

        tutorExistente.Nome = tutor.Nome;
        tutorExistente.Telefone = tutor.Telefone;
        tutorExistente.Email = tutor.Email;

        await _context.SaveChangesAsync();
        return tutorExistente;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var tutor = await _context.Tutores.FindAsync(id);
        if (tutor == null) return false;

        _context.Tutores.Remove(tutor);
        await _context.SaveChangesAsync();
        return true;
    }
}