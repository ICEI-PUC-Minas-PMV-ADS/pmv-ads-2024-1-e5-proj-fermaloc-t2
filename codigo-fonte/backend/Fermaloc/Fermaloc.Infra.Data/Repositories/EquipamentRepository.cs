﻿using Fermaloc.Domain;
using Microsoft.EntityFrameworkCore;
namespace Fermaloc.Infra.Data;

public class EquipamentRepository : IEquipamentRepository
{
    private readonly ApplicationDbContext _context;

    public EquipamentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Equipament> CreateEquipamentAsync(Equipament equipament)
    {
        _context.Equipaments.Add(equipament);
        await _context.SaveChangesAsync();
        return equipament;
    }
    public async Task<Equipament> GetEquipamentByIdAsync(Guid id)
    {
        Equipament equipament = await _context.Equipaments.FindAsync(id);
        return equipament;
    }
    public async Task<IEnumerable<Equipament>> GetAllEquipamentsAsync()
    {
        IEnumerable<Equipament> equipaments = await _context.Equipaments.ToListAsync();
        return equipaments;
    }
    public async Task<IEnumerable<Equipament>> GetEquipamentsByStatusAsync(bool status)
    {
        IEnumerable<Equipament> equipaments = await _context.Equipaments.Where(e => e.Status == status).ToListAsync();
        return equipaments;
    }
    public async Task<IEnumerable<Equipament>> GetEquipamentsByStatusAndCategoryAsync(bool status, Guid categoryId)
    {
        IEnumerable<Equipament> equipaments = await _context.Equipaments.Where(e => e.Status == status && e.CategoryId == categoryId).ToListAsync();
        return equipaments;
    }
    public async Task<IEnumerable<Equipament>> GetEquipamentsSearchNameEquipamentAsync(string nameEquipament)
    {
        IEnumerable<Equipament> equipaments = await _context.Equipaments.Where(e => e.Name.Contains(nameEquipament)).ToListAsync();
        return equipaments;
    }
    public async Task<Equipament> UpdateEquipamentAsync(Equipament equipament)
    {
        _context.Equipaments.Update(equipament);
        await _context.SaveChangesAsync();
        return equipament;
    }
    public async Task<Equipament> UpdateEquipamentStatusAsync(Guid id)
    {
        Equipament equipament = await _context.Equipaments.FindAsync(id);
        equipament.Status = !equipament.Status;
        _context.Equipaments.Update(equipament);
        await _context.SaveChangesAsync();
        return equipament;
    }
    public async Task<Equipament> AddClickCountEquipamentAsync(Guid id)
    {
        Equipament equipament = await _context.Equipaments.FindAsync(id);
        equipament.NumberOfClicks += 1;
        _context.Equipaments.Update(equipament);
        await _context.SaveChangesAsync();
        return equipament;
    }
    public async Task<Equipament> DeleteEquipamentAsync(Guid id)
    {
        Equipament equipament = await _context.Equipaments.FindAsync(id);
        _context.Equipaments.Remove(equipament);
        await _context.SaveChangesAsync();
        return equipament;
    }
}
