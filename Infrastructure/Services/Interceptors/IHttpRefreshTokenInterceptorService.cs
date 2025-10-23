namespace Infrastructure.Services.Interceptors;

public interface IHttpRefreshTokenInterceptorService
{
    Task InterceptBeforeHttpRequestAsync(object sender, HttpClientInterceptorEventArgs eventArgs);
    void RegisterEvent();
}