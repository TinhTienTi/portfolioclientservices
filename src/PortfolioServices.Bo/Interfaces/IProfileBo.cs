using PortfolioServices.Model;

namespace PortfolioServices.Bo.Interfaces
{
    public interface IProfileBo
    {
        Task<IEnumerable<HomeProfileResponse>> GetHomeInfoQueryableAsync(string languageId);
    }
}
