using Application.Features.Schools;
using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Schools;

public class SchoolService : ISchoolService
{
    public Task<int> CreateAsync(School school)
    {
        throw new NotImplementedException();
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