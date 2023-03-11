namespace PortfolioServices.Bo.ApiServices;

public interface IPingApiService<T>
{
    Task<T> GetAsync(string apiPath);
}
