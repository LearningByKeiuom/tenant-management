namespace Application.Features.Tenancy;

public class UpdateTenantSubscriptionRequest
{
    public string TenantId { get; set; } = string.Empty;
    public DateTime NewExpiryDate { get; set; }
}