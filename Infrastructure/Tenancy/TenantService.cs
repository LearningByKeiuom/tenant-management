using Application.Features.Tenancy;
using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.Abstractions;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Tenancy;

public class TenantService : ITenantService
{
    private readonly IMultiTenantStore<ABCSchoolTenantInfo> _tenantStore;
    private readonly ApplicationDbSeeder _dbSeeder;
    private readonly IServiceProvider _serviceProvider;

    public TenantService(IMultiTenantStore<ABCSchoolTenantInfo> tenantStore, ApplicationDbSeeder dbSeeder, IServiceProvider serviceProvider)
    {
        _tenantStore = tenantStore;
        _dbSeeder = dbSeeder;
        _serviceProvider = serviceProvider;
    }
    
    public Task<string> CreateTenantAsync(CreateTenantRequest createTenant, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<string> ActivateAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<string> DeactivateAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<string> UpdateSubscriptionAsync(UpdateTenantSubscriptionRequest updateTenantSubscription)
    {
        throw new NotImplementedException();
    }

    public Task<List<TenantResponse>> GetTenantsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TenantResponse> GetTenantByIdAsync(string id)
    {
        throw new NotImplementedException();
    }
}