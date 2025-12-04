using Domain.Entities;
using Finbuckle.MultiTenant.Abstractions;
using Infrastructure.Tenancy;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class ApplicationDbContext(
    IMultiTenantContextAccessor<ABCSchoolTenantInfo> tenantInfoContextAccessor,
    DbContextOptions<ApplicationDbContext> options)
    : BaseDbContext(tenantInfoContextAccessor, options)
{
    public DbSet<School> Schools => Set<School>();
}