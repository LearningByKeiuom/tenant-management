using Application.Features.Schools;
using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Schools;

public class SchoolService : ISchoolService
{
    private readonly ApplicationDbContext _context;

    public SchoolService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> CreateAsync(School school)
    {
        await _context.Schools.AddAsync(school);
        await _context.SaveChangesAsync();
        return school.Id;
    }

    public Task<int> UpdateAsync(School school)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(School school)
    {
        throw new NotImplementedException();
    }

    public Task<School> GetByIdAsync(int schoolId)
    {
        throw new NotImplementedException();
    }

    public Task<List<School>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<School> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }
}